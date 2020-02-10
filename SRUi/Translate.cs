/*
Copyright (c) 2020 Richard King

stressRefine is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

stressRefine is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

The terms of the GNU General Public License are explained in the file COPYING.txt,
also available at <https://www.gnu.org/licenses/>
 
stressRefine makes uses of the free software program CalculiX cgx http://www.dhondt.de/
which is also subject to the terms of the GNU General Public License
*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace SRUi
{
    public partial class Form1 : Form
    {
        double xlateSeconds = 0.0;
        bool doTranslation()
        {
            try
            {

                mainTimer = new Stopwatch();
                mainTimer.Start();

                string xlateStatusFile = workingDir + "xlate_status.txt";
                if (File.Exists(xlateStatusFile))
                    File.Delete(xlateStatusFile);

                initialize();

                //automatic choice of disp result source:
                if(nasResType == NasResTypes.automatic)
                {
                    //automatic: look for breakoutDispFromCSV first, f06 with disp second, op2 3rd
                    if(!breakoutDispFromCSV())
                    {
                        f06HasDisp(); //sets the okf06 flag
                        if (!okf06)
                            checkForDoOp2toSR(true);
                    }
                }
                else if (nasResType == NasResTypes.op2)
                    checkForDoOp2toSR(true);
                else if (nasResType == NasResTypes.f06 && !okf06)
                    f06HasDisp();

                unsupported = false;
                translateCtrl dlg = new translateCtrl();
                dlg.mainform = this;
                dlg.title = "Nastran Model Translation";
                translateCmdFile = workingDir + "translateCmd.txt";
                StreamWriter translateWrite = new StreamWriter(translateCmdFile);
                translateWrite.WriteLine(feaFileName);
                translateWrite.WriteLine(SRDefFolder + SRtail);
                if(breakoutDispFromCSV())
                {
                    translateWrite.WriteLine(breakoutDispFileName);
                }

                translateWrite.Close();

                dlg.ShowDialog();

                if(activeResultType == NasResTypes.op2)
                    writeToLog("op2seconds: " + dlg.op2Seconds);
                writeToLog("bdfseconds: " +dlg.bdfSeconds);

                int nnode = 0;
                int nelem = 0;
                if (!dlg.cancelled)
                {

                    appendXlateLogToUILog();
                    bool statusOk = false;
                    for (int numtrys = 0; numtrys < 10; numtrys++)
                    {
                        if (File.Exists(xlateStatusFile))
                        {
                            statusOk = true;
                            break;
                        }
                        Thread.Sleep(250);
                    }

                    if(!statusOk)
                    {
                        ShowMessage("Translation of Nastran input file unsuccessful"
                            + newline + "please see log file for details: "
                            + newline + logName);
                        writeToLog("Translate exited but did not create status file");
                        writeToLog("probably exited abnormally");
                        return dlg.cancelled;
                    }
                    //count nodes and elements in .msh file:
                    string mshname = SRFolder;
                    mshname += SRtail;
                    mshname += ".msh";
                    if (File.Exists(mshname))
                    {
                        StreamReader tmp = new StreamReader(mshname);

                        while (!tmp.EndOfStream)
                        {
                            string s = tmp.ReadLine();
                            string sl, sr;
                            int nn = s.LastIndexOf('/');
                            if (nn < 1)
                                continue;
                            sr = s.Substring(nn + 1);
                            nn = s.IndexOf('/');
                            sl = s.Substring(0, nn);
                            if (sr.Equals("nodes"))
                                int.TryParse(sl, out nnode);
                            else if (sr.StartsWith("elements"))
                                int.TryParse(sl, out nelem);
                        }
                        tmp.Close();
                    }

                    //check translation status
                    StreamReader statF = new StreamReader(workingDir + "xlate_status.txt");
                    bool success = false;
                    partialDisplacements = false;
                    while(!statF.EndOfStream)
                    {
                        String s = statF.ReadLine();
                        if (s.StartsWith("translation successful"))
                            success = true;
                        else if (s.StartsWith("unsupported"))
                            unsupported = true;
                        else if (s.StartsWith("linearMesh"))
                        {
                            ShowMessage("linear (without midnodes) meshes are not supported in stressRefine");
                            success = false;
                        }
                        else if (s.StartsWith("Partial Displacement File"))
                            partialDisplacements = true;
                        else if (s.StartsWith("incompatible disp file"))
                        {
                            activeResultType =NasResTypes.none;
                            incompatibleDispFile = true;
                        }
                        else if(s.StartsWith("NxNastran"))
                        {
                            FemapModel = true;
                        }
                    }

                    statF.Close();

                    if(!success)
                        return dlg.cancelled;

                    fullModelNumElements = nelem;
                    fullModelNumNodes = nnode;

                    if (activeResultType == NasResTypes.none)
                    {
                        if (unsupported)
                        {
                            string msg = "No Nastran Results available.";
                            if(nasResType != NasResTypes.automatic)
                                msg += newline + "Please try setting Nastran results type to 'automatic' in the options form";
                            if (incompatibleDispFile)
                            {
                                msg += newline + "(Displacement table is incompatible with this model.";
                                msg += newline + "Try setting nastran results type to binary or ascii under options.";
                            }
                            msg += newline + "This model cannot be solved in stressRefine.";

                            ShowMessage(msg);
                            return false;
                        }
                    }
                    else
                    {
                        if(nelem > maxElementsFullModel || breakoutDispFromCSV())
                        {
                            breakoutRun = true;
                            breakoutAtNode = false;
                        }
                    }
                }

                xlateSeconds = GetElapsedSeconds();
                mainTimer.Stop();
                return !dlg.cancelled;
            }
            catch
            {
                catchWarningMsg("doTranslation");
                return false;
            }
        }

        public bool FindNode(int num)
        {
            try
            {
                string mshname = SRFolder + SRtail + ".msh";
                if (!File.Exists(mshname))
                    return false;
                StreamReader tmp = new StreamReader(mshname);
                //parse till node header:
                bool nodeheaderfound = false;
                int nodeRead = -1;
                while(!tmp.EndOfStream)
                {
                    string line = tmp.ReadLine();
                    if (!nodeheaderfound)
                    {
                        if (line.StartsWith("nodes"))
                        {
                            nodeheaderfound = true;
                        }
                    }
                    else
                    {
                        if (line.StartsWith("end nodes"))
                            break;
                        string[] subs = line.Split(' ');
                        if (!int.TryParse(subs[1], out nodeRead))
                            int.TryParse(subs[0], out nodeRead);
                        if (nodeRead == num)
                        {
                            tmp.Close();
                            return true;
                        }
                    }
                }
                tmp.Close();
                return false;
            }
            catch
            {
                return false;
            }
        }

        void appendXlateLogToUILog()
        {
            try
            {
                writeToLog("=================================================");
                writeToLog("From bdfxlate:");
                string filename = workingDir + "xlate_log.txt";
                StreamReader inStream = new StreamReader(filename, false);
                int num = 0;
                while (true)
                {
                    if (inStream.EndOfStream)
                        break;
                    num++;
                    if (num > 10000)
                        break; //infinite loop prevention
                    string line = inStream.ReadLine();
                    writeToLog(line + newline);
                }
                inStream.Close();
                writeToLog("=================================================");
            }
            catch
            {
                return;
            }
        }

        public void checkForDoOp2toSR(bool setResFlag = false)
        {
            try
            {
                op2toSROK = true;
                string pyLoc = installDir + "\\pyNas.txt";
                if (!File.Exists(pyLoc))
                {
                    op2toSROK = false;
                    noPynas = true;
                }
                else
                {
                    StreamReader tmp = new StreamReader(pyLoc);
                    pyExe = tmp.ReadLine();
                    pynasExe = tmp.ReadLine();
                    pynasExe += "\\pyNastran\\op2\\test\\test_op2dispPlusSvmMaxEidAtMax.py";
                    tmp.Close();
                    if (!File.Exists(pyExe) || !File.Exists(pynasExe))
                    {
                        op2toSROK = false;
                        noPynas = true;
                        writeToLog("nopynas");
                        if (!File.Exists(pyExe))
                            writeToLog("no pyexe " + pyExe);
                        if(!File.Exists(pynasExe))
                            writeToLog("no pyNasExe" + pynasExe);
                    }
                }

                if (!File.Exists(op2Name))
                    findOp2File();
                else
                    writeToLog("no op2 results. resfolder: " + getResFolderName());
                if (op2toSROK && setResFlag && (op2Name != null) && (File.Exists(op2Name)) )
                {
                    fearestb.Text = op2Name;
                    activeResultType = NasResTypes.op2;
                }
                    
            }
            catch
            {
                op2toSROK = false;
                return;
            }
        }

        bool f06HasDisp()
        {
            try
            {
                if (!File.Exists(f06File))
                {
                    f06File = findF06File();
                    if (f06File == null)
                        return false;
                }
                StreamReader tmp = new StreamReader(f06File);
                string s = null;
                while(!tmp.EndOfStream)
                {
                    s = tmp.ReadLine();
                    int n = s.IndexOf('D');
                    if(n != -1)
                    {
                        string s2 = s.Substring(n);
                        if (s2.StartsWith("D I S P L A C E M E N T   V E C T O R"))
                        {
                            okf06 = true;
                            tmp.Close();
                            activeResultType = NasResTypes.f06;
                            return true;
                        }
                    }
                }
                tmp.Close();
                writeToLog("no valid f06 results. f06File: " + f06File);
                return false;
            }
            catch
            {
                return false;
            }

        }

        public bool checkForBktAtMaxDefault()
        {
            if (fullModelNumElements < maxElementsFullModel && !partialDisplacements)
                return false;
            if (partialDisplacements && (fullModelNumNodes > maxNodesForBktCentroidDT))
                return false;
            return true;
        }

        public string FindLatestFileInFolder(string folder, string extension)
        {
            //extension is e.g. "*.txt"
            try
            {
                string[] files = Directory.GetFiles(folder, extension, SearchOption.TopDirectoryOnly);
                if (files.Length == 1)
                    return files[0];
                else if (files.Length > 1)
                {
                    //loop files, find latest date
                    int latest = 0;
                    int latestDate = 0;
                    for (int i = 0; i < files.Length; i++)
                    {
                        DateTime d = File.GetLastWriteTimeUtc(files[i]);
                        int idate = d.Year * 365;
                        idate += d.DayOfYear;
                        idate += d.Hour / 24;
                        idate += d.Minute / (24 * 60);
                        idate += d.Second / (24 * 3600);
                        if (idate > latestDate)
                        {
                            latestDate = idate;
                            latest = i;
                        }
                    }
                    return files[latest];
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public string FindDispFileInFolder(string folder)
        {
            try
            {
                string[] files = Directory.GetFiles(folder, "*.csv", SearchOption.TopDirectoryOnly);
                if (files.Length == 0)
                    return null;
                else if (files.Length == 1)
                    return files[0];
                else if (files.Length > 1)
                {
                    //loop files, find latest date
                    int latest = 0;
                    double latestDate = 0;
                    for (int i = 0; i < files.Length; i++)
                    {
                        //make sure header is correct:
                        if (!checkDispDataTable(files[i]))
                            continue;
                        DateTime d = File.GetLastWriteTimeUtc(files[i]);
                        double idate = d.Year * 365;
                        idate += d.DayOfYear;
                        idate += d.Hour / 24;
                        idate += d.Minute / (24 * 60);
                        idate += d.Second / (24 * 3600);
                        if (idate > latestDate)
                        {
                            latestDate = idate;
                            latest = i;
                        }
                    }
                    return files[latest];
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        bool checkDispDataTable(string filename)
        {
            //make sure header is correct:
            StreamReader csvin = new StreamReader(filename);
            string line = csvin.ReadLine();//skip header
            line = csvin.ReadLine();//1st data line. should be id,u,v,w
            csvin.Close();
            string[] subs = line.Split(',');
            if (subs.Length == 4)
            {
                int ii;
                double u;
                if (int.TryParse(subs[0], out ii))
                {
                    for (ii = 0; ii < 3; ii++)
                    {
                        if (!double.TryParse(subs[ii + 1], out u))
                            break;
                    }
                    return true;
                }
            }
            return false;
        }

        string findF06File()
        {
            try
            {
                setFeaFolder();
                //find the f06 file.
                string resfolder = getResFolderName();

                string[] files = Directory.GetFiles(resfolder, "*.f06", SearchOption.TopDirectoryOnly);
                if (files.Length == 1)
                    return files[0];
                else if (files.Length > 1)
                {
                    //loop files, find latest date
                    int latest = -1;
                    int latestDate = 0;
                    for (int i = 0; i < files.Length; i++)
                    {
                        //skip files that end in "_SR.f06", they were written by engine:
                        if (files[i].EndsWith("_SR.f06"))
                            continue;
                        DateTime d = File.GetLastWriteTimeUtc(files[i]);
                        int idate = d.Year * 365;
                        idate += d.DayOfYear;
                        idate += d.Hour / 24;
                        idate += d.Minute / (24 * 60);
                        idate += d.Second / (24 * 3600);
                        if (idate > latestDate)
                        {
                            latestDate = idate;
                            latest = i;
                        }
                    }
                    if (latest != -1)
                        return files[latest];
                    else
                        return null;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
        string findOp2File()
        {
            try
            {
                setFeaFolder();
                string resfolder = getResFolderName();
                op2Name = FindLatestFileInFolder(feaFolder, "*.op2");
                return op2Name;
            }
            catch
            {
                return null;
            }
        }

        string getResFolderName()
        {
            string resfolder = feaFolder;
            if (!resFolderIsFeaFolder)
                resfolder = userResFolderName;
            return resfolder;
        }
    }

}
