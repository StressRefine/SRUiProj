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
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace SRUi
{
    public enum NasResTypes { automatic, csv, op2, f06, none };
    public partial class Form1 : Form
    {
        //main form for the ui

        // model size constants:
        int maxElementsFullModel = 20000;
        public int minElementsForBreakout = 5000;
        public int maxNodesForBktCentroidDT = 100000;

        ToolTip form1TT = null;
        bool checklicense = false;
        bool deleteEngineFiles = false;
        string SRDefFolder;
        string SRtail0;
        List<string> resultStrings = null;
        string newline = System.Environment.NewLine;
        bool unsupported = false;
        bool flattened = false;
        bool abnormalSolve = false;
        bool logCreated = false;
        bool haveResultsText = false;
        public Stopwatch mainTimer = null;

        string stressUnitString;
        double lengthConvert = 1.0;
        string lengthUnitStr = null;
        string sescratchName = "SESimulation\\Scratch";
        double SRoutStressConversion = 1.0;
        string breakoutDispFileName = null;
        bool incompatibleDispFile = false;
        string logName = null;

        public bool noPynas = false;
        public string op2Name;
        public string feaFolder;
        public int inStressUnits = 0;
        public bool useStressUnits = false;
        public int stressUnits;
        public int numStressPasses = 0;
        public double[] stressPassVec = null;
        public bool okf06 = false;
        public string feaFileName;
        public string installDir;
        public string workingDir;
        public int breakoutMat = -1;
        public bool breakoutRun = false;
        public bool breakoutAtNode = false;
        public int breakoutNode = -1;
        public bool econSolve = false;
        public int minP = 2;
        public int maxP = 8;
        public int maxIts = 3;
        public double errTol = 5;
        public bool ignoreSacrificial = false;
        public bool useSoftSprings = false;
        public string translateCmdFile = null;
        public string tempFolder = null;
        public string f06File;
        public string FEtail;
        public string SRFolder;
        public string SRtail;
        public int fullModelNumElements = 0;
        public int fullModelNumNodes = 0;
        public bool resFolderIsFeaFolder = true;
        public string userResFolderName = null;

        public bool uniformP = false;
        public int maxPJump = 100;
        public bool newModel = true;
        public bool partialDisplacements = false;
        public bool FemapModel = false;
        public bool outputF06 = true;

        public string pyExe = null;
        public string pynasExe = null;
        public bool op2toSROK = false;

        public NasResTypes nasResType = NasResTypes.automatic;
        public NasResTypes activeResultType = NasResTypes.none;

        public Form1()
        {
            try
            {
                InitializeComponent();
                System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.PrimaryScreen;
                int w = this.Width;
                //int x = screen.Bounds.Width - w;
                int x = screen.Bounds.Width / 2;
                this.Location = new Point(x, 0);
                fearesgb.Visible = false;
                RunGB.Visible = false;
                ResultsGB.Visible = false;
                FeaFileTB.Visible = false;
                installDir = System.IO.Directory.GetCurrentDirectory() + "\\";
                if(installDir.StartsWith("C:\\Users\\rich\\Documents\\Visual Studio 2013"))
                    installDir = "C:\\Users\\rich\\Documents\\stressrefineWorking\\";

                workingDir = installDir;
                logName = workingDir + "srui.log";
                feaFolder = workingDir;
                ReadConfig();
                ReadSettings();
                SRDefFolder = workingDir + "SRFiles\\";
                if (!Directory.Exists(SRDefFolder))
                    Directory.CreateDirectory(SRDefFolder);
                //note: translator, engine, and cgx have to be in installdir.
            }
            catch
            {
                shutdown();
            }
        }

        void initialize()
        {
            try
            {
                numStressPasses = 0;
                stressPassVec = null;
                logCreated = false;
                okf06 = false;
                breakoutMat = -1;
                breakoutRun = false;
                breakoutNode = -1;
                breakoutAtNode = false;
                econSolve = false;
            }
            catch
            {
                shutdown();
            }
        }

        private void DoneBut_Click(object sender, EventArgs e)
        {
            setStressUnits();
            WriteSettings();
            Close();
        }

        private void RunBut_Click(object sender, EventArgs e)
        {
            //implement the "solve" button

            breakoutRun = localRad.Checked;
            bool needbktNode = (activeResultType == NasResTypes.csv && !partialDisplacements
                                 && (fullModelNumNodes > maxNodesForBktCentroidDT));
            if (nodeRad.Checked)
            {
                string snode = nodeTB.Text;
                int nodenum;
                if (snode.Length > 0)
                {
                    if (int.TryParse(snode, out nodenum))
                        breakoutNode = nodenum;
                    else
                        breakoutNode = -1;
                }
            }

            if (breakoutRun && needbktNode)
            {
                if (breakoutNode == -1)
                {
                    ShowMessage("Please specify node ID for local region");
                    return;
                }
            }

            setStressUnits();
            SRtail = SRtail0;
            SRFolder = SRDefFolder + SRtail + "\\";
            ResultsGB.Visible = true;
            cnvBut.Visible = false;
            haveResultsText = false;
            if (Solve())
            {
                ResultsGB.Visible = true;
                ShowResults();
                newModel = false;
            }
            else if (haveResultsText)
            {
                //there may be details of the failure in engine report file:
                ShowResults();
            }
        }

        private void Report_Click(object sender, EventArgs e)
        {
            ShowResults();
        }

        private void VizBut_Click(object sender, EventArgs e)
        {
            doViz();
        }

        private void SettBut_Click(object sender, EventArgs e)
        {
            //"Settings" button
            Settings dlg = new Settings();
            dlg.mainform = this;
            dlg.ShowDialog();
        }

        private void ShowResults()
        {
            //show results output by engine in report.txt

            try
            {
                if (resultStrings == null || resultStrings.Count == 0)
                    return;
                ResultsGB.Visible = true;
                ResForm dlg = new ResForm();
                dlg.mainform = this;
                for (int i = 0; i < resultStrings.Count; i++)
                    dlg.appendResultString(resultStrings[i]);
                dlg.ShowDialog();
            }
            catch
            {
                shutdown();
            }
        }

        public void catchWarningMsg(string msg)
        {
            try
            {
                writeToLog("Exception Caught: " + msg);
            }
            catch
            {
                return;
            }
        }


        bool fatalMsgCalled = false;
        public void fatalMsg(string msg)
        {
            if (fatalMsgCalled)
                return;
            fatalMsgCalled = true;
            try
            {
                writeToLog("Exception Caught: " + msg);
                stackTraceToLog();
                Close();
            }
            catch
            {
                shutdown();
            }
        }

        bool traceShown = false;
        void stackTraceToLog()
        {
            //upon fatal error, get the stack trace and write it to the log file

            try
            {
                if (traceShown)
                    return;
                traceShown = true;
                StackFrame stackFrame = new StackFrame(1, true);
                string caller = stackFrame.GetMethod().ToString();
                int linenum = stackFrame.GetFileLineNumber();
                writeToLog("showTrace: caller: " + caller + " linenum: " + linenum);
                StackTrace st = new StackTrace();
                StackTrace st1 = new StackTrace(new StackFrame(true));
                writeToLog(" Stack trace :" + st1.ToString());
                writeToLog(st.ToString());
            }
            catch
            {
                shutdown();
            }
        }

        public bool fillResultsText(bool plooprun = false)
        {
            //read the engine report.txt file and store it in memory in resultStrings
            //some flags from the engine are interpreted

            try
            {
                bool anySolveError = false;
                clearResultStrings();
                writeToLog("fillResultsText");
                string filename = SRFolder + "report.txt";
                resultStrings = new List<string>();
                if (!File.Exists(filename))
                {
                    writeToLog("report.txt not found");
                    addResultString(newline);
                    addResultString("==========================================");
                    addResultString(newline);
                    addResultString("abnormal termination");
                    addResultString(newline);
                    addResultString("==========================================");
                    ShowMessage("stressRefine solution abnormal termination");
                    abnormalSolve = true;
                    return false;
                }
                else
                {
                    StreamReader reportStream = new StreamReader(filename);
                    if (ignoreSacrificial)
                    {
                        addResultString(newline + "Warning: 'detect singularities' was unchecked.");
                        addResultString(newline + "Results may not be physically meaningful");
                        addResultString(newline + "near any singularities in your model" + newline);
                    }
                    bool highError = false;
                    bool singular = false;
                    bool anyWarning = false;

                    while (true)
                    {
                        if (reportStream.EndOfStream)
                            break;
                        string line = reportStream.ReadLine();
                        if (line.StartsWith("MaxVMIts"))
                        {
                            string[] subs = line.Split(',');
                            numStressPasses = subs.Length - 1;
                            stressPassVec = new double[numStressPasses];
                            for (int i = 0; i < numStressPasses; i++)
                                double.TryParse(subs[i + 1], out stressPassVec[i]);
                            cnvBut.Visible = true;
                        }
                        else if (line.StartsWith("ERROR:"))
                        {
                            writeToLog("ERROR from report.txt: " + line);
                            addResultString(newline);
                            addResultString(line);
                            addResultString("==========================================");
                            addResultString(newline);
                            addResultString("abnormal termination");
                            addResultString(newline);
                            addResultString("==========================================");
                            anySolveError = true;
                            break;
                        }
                        else if (line.StartsWith("StressRefine abnormal termination"))
                        {
                            writeToLog("ERROR from report.txt: " + line);
                            addResultString(newline);
                            addResultString("==========================================");
                            addResultString(newline);
                            addResultString("abnormal termination");
                            addResultString(newline);
                            addResultString("==========================================");
                            anySolveError = true;
                            break;
                        }
                        else if (line.StartsWith("Singular") && !singular)
                        {
                            singular = true;
                            addResultString(newline + "Warning:");
                            addResultString(newline + "The highest stress in the model occurs near a singularity.");
                            addResultString(newline + "Results may not be physically meaningful. Please review your model.");
                            singMessage(line);
                            anyWarning = true;
                        }
                        else if (line.StartsWith("SlopeKinkAtMax"))
                        {
                            addResultString(newline + "Warning:");
                            addResultString(newline + "The highest stress in the model occurs at an element");
                            addResultString(newline + "that has a kink in slope with its neighbor of 10 degrees or more");
                            addResultString(newline + "which can cause artificially high stresses.");
                            addResultString(newline + "Please make sure curved geometry of your model is followed well by the mesh.");
                            addResultString(newline + "Curvature-based refinement and 'midside nodes on surfaces' are recommended,");
                            addResultString(newline + "see user's guide.");
                            addResultString(newline + "A mesh control in the vicinity of maximum stress may also help.");
                            singMessage(line);
                            anyWarning = true;
                        }
                        else if (!flattened && line.StartsWith("Flattened"))
                        {
                            if (!singular)
                            {
                                flattened = true;
                                addResultString(newline + "Warning:");
                                addResultString(newline + "One or more elements with high stress are highly distorted");
                                addResultString(newline + "A mesh control is recommended in the vicinity of maximum stress.");
                                anyWarning = true;
                            }
                        }
                        else if (!highError && line.StartsWith("HighError:"))
                        {
                            if (!singular)
                            {
                                highError = true;
                                addResultString(newline + "Warning:");
                                addResultString(newline + "The estimate of stress error is greater than 10 percent.");
                                if (econSolve)
                                {
                                    addResultString(newline + "Turning off 'full model economy solve'");
                                    addResultString(newline + "will result in more accurate results.");
                                    addResultString(newline + "A fine mesh control on the face at maximum stress");
                                    addResultString(newline + "may also be needed");

                                }
                                else
                                {
                                    addResultString(newline + "A fine mesh control on the face at maximum stress");
                                    addResultString(newline + "will result in more accurate results.");
                                }
                                anyWarning = true;
                            }
                        }
                        else if (line.StartsWith("SmallStressDetected"))
                        {
                            addResultString(newline);
                            addResultString(newline + "The maximum stress in your model");
                            addResultString(newline + "is very small compared to the allowable stress");
                            addResultString(newline + "for the model matrials(s)");
                            addResultString(newline + "Please review loads and restraints");
                            anyWarning = true;
                        }
                        else if (line.StartsWith("BktNodeNotInBB"))
                        {
                            addResultString(newline);
                            addResultString(newline + "The node specified for the local region center");
                            addResultString(newline + "is not within the bounds of the nodes in the displacement");
                            addResultString(newline + "data. Please review the node specified for the local region");
                            addResultString(newline + "and your data table");
                            anyWarning = true;
                        }
                        else
                            addResultString(newline + line);
                    }


                    if (!anyWarning && !anySolveError)
                        addResultString(newline + newline + "Results OK");
                    haveResultsText = true;
                    if (anySolveError)
                    {
                        abnormalSolve = true;
                        string logName = workingDir + "srui.log";
                        addResultString(newline + "adaptive analysis failed. please see log file for details: "
                                      + newline + logName);
                    }

                    if (plooprun)
                    {
                        mainTimer.Stop();
                        TimeSpan ts = mainTimer.Elapsed;
                        solveSeconds = GetElapsedSeconds(ts);
                        double totalElapsed = xlateSeconds + solveSeconds;
                        addResultString(newline + newline + "Total Translation and Solution Elapsed Seconds: " + totalElapsed);
                    }

                    reportStream.Close();
                }
            }
            catch
            {
                catchWarningMsg(": fillResultsText");
                abnormalSolve = true;
                return false;
            }

            return true;
        }

        public void writeToLog(string msg)
        {
            try
            {
                FileStream fs = null;
                if (!logCreated)
                {
                    if (File.Exists(logName))
                        File.Delete(logName);
                    fs = new FileStream(logName, FileMode.Create);
                }
                else
                    fs = new FileStream(logName, FileMode.Append);
                logCreated = true;
                StreamWriter writer = new StreamWriter(fs);
                writer.WriteLine(msg);
                writer.Close();
            }
            catch
            {
                shutdown();
            }
        }

        void addResultString(string s)
        {
            resultStrings.Add(s);
        }

        bool singMessage(string line)
        {
            //add messages to resultStrings if singularities detected by engine
            try
            {
                string[] subs = line.Split(',');
                if (subs.Length > 3)
                {
                    addResultString(newline + "Type(s) of Singularities Detected");
                    if (subs[1] == "1")
                        addResultString(newline + "Concentrated Load, Restraint, or Connection (Nodal or Edge)");
                    if (subs[2] == "1")
                        addResultString(newline + "Fixed Face Restraint");
                    if (subs[3] == "1")
                        addResultString(newline + "Reentrant Corner");
                }
                if (subs.Length == 5 && subs[4] == "1")
                    addResultString(newline + "Shell-Solid connection");
                bool settingsMsg = true;
                settingsMsg = false;
                if (settingsMsg)
                    addResultString(newline + "'Ignore Singularities' can be checked in 'Advanced' to ignore this effect.");
                addResultString(newline);
            }
            catch
            {
                catchWarningMsg(" singMessage");
            }
            return true;
        }

        public void WriteSettings()
        {
            //write current user settings to settings.txt file
            try
            {
                StreamWriter tmp = new StreamWriter(workingDir + "settings.txt");
                tmp.WriteLine(feaFolder + " //feaFolder for importing Nastran Model");
                tmp.WriteLine(ignoreSacrificial + " //ignoreSacrificial");
                tmp.WriteLine(econSolve+ " //econSolve");
                tmp.WriteLine(errTol + " //errTol");
                tmp.WriteLine(maxIts + " //maxIts");
                tmp.WriteLine(minP + " //minP");
                tmp.WriteLine(maxP + " //maxP");
                tmp.WriteLine(useStressUnits + " //useStressUnits");
                tmp.WriteLine(inStressUnits + " //inStressUnits");
                tmp.WriteLine(stressUnits + " //outStressUnits");
                tmp.WriteLine(outputF06 + " //outputF06");
                int restype = (int)nasResType;
                tmp.WriteLine(restype + " //nastran result type");
                if (resFolderIsFeaFolder)
                    tmp.WriteLine("True //resFolderIsFeaFolder");
                else
                    tmp.WriteLine("False," + userResFolderName + ",//resFolderIsFeaFolder");
                tmp.Close();
            }
            catch
            {
                shutdown();
            }
        }
        public void deleteSettings()
        {
            try
            {
                string tmp = workingDir + "settings.txt";
                if (File.Exists(tmp))
                    File.Delete(tmp);
            }
            catch
            {
                shutdown();
            }
        }

        void ReadSettings()
        {
            //read current user settings from settings.txt file

            StreamReader tmp = null;
            try
            {
                if (File.Exists(workingDir + "settings.txt"))
                {
                    tmp = new StreamReader(workingDir + "settings.txt");
                    string s = tmp.ReadLine();
                    feaFolder = s;
                    s = GetFirstToken(tmp.ReadLine());
                    bool.TryParse(s, out ignoreSacrificial);
                    s = GetFirstToken(tmp.ReadLine());
                    bool.TryParse(s, out econSolve);
                    s = GetFirstToken(tmp.ReadLine());
                    double.TryParse(s, out errTol);
                    s = GetFirstToken(tmp.ReadLine());
                    int.TryParse(s, out maxIts);
                    s = GetFirstToken(tmp.ReadLine());
                    int.TryParse(s, out minP);
                    s = GetFirstToken(tmp.ReadLine());
                    int.TryParse(s, out maxP);
                    s = GetFirstToken(tmp.ReadLine());
                    bool.TryParse(s, out useStressUnits);
                    s = GetFirstToken(tmp.ReadLine());
                    int.TryParse(s, out inStressUnits);
                    s = GetFirstToken(tmp.ReadLine());
                    int.TryParse(s, out stressUnits);
                    s = GetFirstToken(tmp.ReadLine());
                    bool.TryParse(s, out outputF06);
                    s = GetFirstToken(tmp.ReadLine());
                    int restype;
                    int.TryParse(s, out restype);
                    nasResType = (NasResTypes)restype;
                    string line = tmp.ReadLine();
                    s = GetFirstToken(line);
                    bool.TryParse(s, out resFolderIsFeaFolder);
                    if (!resFolderIsFeaFolder)
                    {
                        string[] subs2 = line.Split(',');
                        userResFolderName = subs2[1];
                    }
                    if (useStressUnits)
                        setStressUnits();
                    tmp.Close();
                }
            }
            catch
            {
                if (tmp != null)
                {
                    try
                    {
                        tmp.Close();
                    }
                    catch
                    {

                    }
                }
                return;
            }
        }

        public bool ShowMessage(string msg, bool checkyesno = false)
        {
            //write "msg" in user dialog box

            try
            {
                msgBox dlg = new msgBox();
                dlg.TopMost = true;
                dlg.msg = msg;
                dlg.checkyesno = checkyesno;
                dlg.ShowDialog();
                if (checkyesno)
                    return !dlg.cancelled;
                else
                    return true;
            }
            catch
            {
                shutdown();
                return true;
            }
        }

        private void doViz()
        {
            //implement "stress Fringes" button

            try
            {
                Process CGXexe = new Process();
                writeToLog("VizBut_Click");
                vizForm vizf = new vizForm();
                vizf.Left += 500;
                vizf.Top -= 200;
                if (setupCGX(CGXexe))
                {
                    CGXexe.Start();
                    vizf.ShowDialog();
                    if (!CGXexe.HasExited)
                        CGXexe.Kill();
                }
            }
            catch
            {
                catchWarningMsg("doViz");
            }
        }

        public bool setupCGX(Process CGXexe)
        {
            //set up cgx.exe for use

            string cgxLoc = installDir + "cgx.exe";
            try
            {
                if (!File.Exists(cgxLoc))
                {
                    writeToLog(" cgxLoc missing: " + cgxLoc);
                    catchWarningMsg("startCgx");
                    return false;
                }
                else
                    writeToLog("cgxLoc: " + cgxLoc);
                CGXexe.StartInfo.FileName = cgxLoc;
                string filename = SRFolder + SRtail + ".frd";
                if (!File.Exists(filename))
                    return false;
                int n = filename.IndexOf(' ');
                if(n != -1)
                {
                    //filename has blanks, cgx can't take. copy to temp folder:
                    string sourcefile = filename;
                    filename = Path.GetTempPath() + SRtail + ".frd";
                    if (File.Exists(filename))
                        File.Delete(filename);
                    File.Copy(sourcefile, filename);
                    writeToLog("frd file has spaces, copied to: " + filename);
                }
                CGXexe.StartInfo.Arguments = filename;
                CGXexe.StartInfo.UseShellExecute = false;
                CGXexe.StartInfo.CreateNoWindow = true;
                return true;
            }
            catch
            {
                writeToLog("***catch in setupCGX");
                if(cgxLoc == null)
                    writeToLog("cgxLocnull");
                else
                    writeToLog("cgxLoc: " + cgxLoc);
                return false;
            }
        }


        public bool setSRFolder()
        {
            //set SRFolder, the folder where all engine input and output is stored

            try
            {
                if (DelSRFolder())
                    Directory.CreateDirectory(SRFolder);
            }
            catch
            {
                fatalMsg(" setSRFolder");
                return false;
            }
            return true;
        }

        string GetFirstToken(string s)
        {
            try
            {
            int nn = s.IndexOf('/');
            if (nn == -1)
                return s;
            else
                return s.Substring(0, nn-1);
            }
            catch
            {
                return null;
            }
        }

        private void showCnvPlot()
        {
            //show convergence plot

            try
            {
                chart dlg = new chart();
                dlg.mainform = this;
                dlg.ShowDialog();
            }
            catch
            {
                catchWarningMsg(" showCnvPlot");
            }
        }

        private void cnvBut_Click(object sender, EventArgs e)
        {
            showCnvPlot();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!eulaCheck())
                Close();
            licenseChecker lc = null;
            if (checklicense)
            {
                lc = new licenseChecker();
                lc.mainForm = this;
                if (!lc.licCheck(false))
                    Close();
                deleteEngineFiles = true;
            }
            else
                deleteEngineFiles = false;
            tempFolder = Path.GetTempPath();
            form1TT = new ToolTip();
            form1TT.SetToolTip(RunBut, "Perform a P-adaptive solution of the model to calculate refined stresses");
            form1TT.SetToolTip(SettBut, "Settings to control the adaptive analysis");
            form1TT.SetToolTip(fullRad, "adaptively reanalyze entire finite element model in stressRefine");
            form1TT.SetToolTip(localRad, "extract a local region for adaptive analysis in stressRefine");
            form1TT.SetToolTip(maxRad, "center the local region at the point of max stress from the Nastran Results");
            form1TT.SetToolTip(nodeRad, "center the local region at a specified node or point");
        }

        void setupAndTranslate()
        {
            try
            {
                int nn = feaFileName.IndexOf('.');
                string tmp = feaFileName.Substring(nn + 1);
                tmp = feaFileName.Substring(0, nn);
                nn = tmp.LastIndexOf('\\');
                feaFolder = tmp.Substring(0, nn);
                FEtail = tmp.Substring(nn + 1);
                op2Name = feaFolder + "\\" + FEtail + ".op2";
                SRtail = FEtail.Replace(' ', '_');
                SRtail = FEtail.Replace(' ', '_');
                SRtail0 = SRtail;
                SRFolder = SRDefFolder + SRtail + "\\";
                setSRFolder();

                FeaFileTB.Text = feaFileName;
                if (!doTranslation())
                    return;

                if(breakoutDispFromCSV() && partialDisplacements && !checkForBktAtMaxDefault())
                {
                    breakoutAtNode = true;
                    breakoutNode = -1;
                }

                setRunGBVis();
                FeaFileTB.Visible = true;
                cnvBut.Visible = false;
            }
            catch
            {
                shutdown();
            }
        }

        private void FeaFileBut_Click(object sender, EventArgs e)
        {
            newModel = true;
            FemapModel = false;
            nodeTB.Clear();
            fearestb.Clear();
            RunGB.Visible = false;
            f06File = null;
            op2Name = null;
            breakoutDispFileName = null;
            activeResultType = NasResTypes.none;
            getGenericNastranModel();

        }

        private void getGenericNastranModel()
        {
            try
            {
                OpenFileDialog feaFileDlg = new OpenFileDialog();

                // Set filter options and filter index.
                feaFileDlg.Filter = "Nastran Files (*.bdf;*.dat)|*.bdf;*.dat";
                feaFileDlg.FilterIndex = 1;
                feaFileDlg.InitialDirectory = feaFolder;

                DialogResult res = new DialogResult();
                res = feaFileDlg.ShowDialog();
                if (res == DialogResult.OK)
                {
                    FeaFileTB.Text = feaFileDlg.FileName;
                    feaFileName = feaFileDlg.FileName;
                    //see if there is a valid csv file with displacements
                    //if so,this will set active result type to csv:
                    if( nasResType == NasResTypes.automatic || nasResType == NasResTypes.csv)
                        findDispCsvFile();
                    setupAndTranslate();
                }
            }
            catch
            {
                fatalMsg("getGenNastranModel");
            }
        }

        public void setStressUnits()
        {
            try
            {
                if (stressUnits == 0)
                {
                    stressUnitString = "Pa (N/m^2)";
                    lengthUnitStr = " m";
                    lengthConvert = 1.0;
                    SRoutStressConversion = 1.0;
                }
                else if (stressUnits == 1)
                {
                    stressUnitString = "ksi";
                    lengthUnitStr = " in";
                    lengthConvert = 39.37;
                    SRoutStressConversion = 1.45038e-07; //Pa to ksi
                }
                else if (stressUnits == 2)
                {
                    stressUnitString = "Kgf/cm^2";
                    lengthUnitStr = " cm";
                    lengthConvert = 100.0;
                    SRoutStressConversion = 1.0 / 98066.5; //pa to Kgf/m^2
                }
                else if (stressUnits == 3)
                {
                    stressUnitString = "Mpa(N/mm^2)";
                    lengthUnitStr = " mm";
                    lengthConvert = 1000.0;
                    SRoutStressConversion = 1.0e-06; //pa to Mpa
                }
                else if (stressUnits == 4)
                {
                    stressUnitString = "psi";
                    lengthUnitStr = " in";
                    lengthConvert = 39.37;
                    SRoutStressConversion = 0.000145038; //Pa to psi
                }
            }
            catch
            {
                shutdown();
            }
        }

        public bool eulaCheck()
        {
            try
            {
                string eulaCheckName = installDir + "\\eulaChecked.txt";
                if (File.Exists(eulaCheckName))
                    return true;
                eula dlg = new eula();
                dlg.ShowDialog();
                if (dlg.agreed)
                {
                    StreamWriter tmp = new StreamWriter(eulaCheckName);
                    tmp.WriteLine("User agreed to Eula");
                    return true;
                }
                else
                {
                    ShowMessage(" StressRefine cannot be run without agreeing to the" + System.Environment.NewLine +
                        "terms of the license agreement");
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        bool shutdownCalled = false;
        public void shutdown()
        {
            if (shutdownCalled)
                return;
            shutdownCalled = true;
            ShowMessage("A fatal error has occurred");
            writeToLog("A fatal error has occurred");
            stackTraceToLog();
        }



        private void ReadConfig()
        {
            try
            {
                string cfname = workingDir + "config.txt";
                if (!File.Exists(cfname))
                    return;
                StreamReader tmp = new StreamReader(cfname);
                string s = GetFirstToken(tmp.ReadLine());
                sescratchName = s;
            }
            catch
            {
                return;
            }
        }

        public bool modelTooSmallForBreakout()
        {
            if (fullModelNumElements > minElementsForBreakout || partialDisplacements)
                return false;
            else
                return true;
        }

        private void helpBut_Click(object sender, EventArgs e)
        {
            Process helper = new Process();
            helper.StartInfo.FileName = installDir + "helpFiles\\form1help.pdf";
            helper.Start();
            helper.WaitForExit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            eula edlg = new eula();
            edlg.setAboutMode();
            edlg.ShowDialog();

        }

        void findDispCsvFile()
        {
            try
            {
                setFeaFolder();
                //find the csv file.
                string resfolder = getResFolderName();
                //find latest csv in feafolder
                breakoutDispFileName = FindDispFileInFolder(resfolder);

                if (breakoutDispFileName != null)
                {
                    activeResultType = NasResTypes.csv;
                    breakoutAtNode = true;
                    breakoutNode = -1;
                }
                else
                    writeToLog("no displacement csv file");
            }
            catch
            {
                ShowMessage("cannot read displacement csv file. Please make sure it is not open in another program");
            }
        }

        void setFeaFolder()
        {
            int nn = feaFileName.IndexOf('.');
            string tmp = feaFileName.Substring(nn + 1);
            tmp = feaFileName.Substring(0, nn);
            nn = tmp.LastIndexOf('\\');
            feaFolder = tmp.Substring(0, nn);
        }

        private void optionsBut_Click(object sender, EventArgs e)
        {
            optionsDlg dlg = new optionsDlg();
            dlg.mainform = this;
            dlg.ShowDialog();
        }

        void setRunGBVis()
        {
            maxRad.Text = "At Maximum Stress in Model";
            RunGB.Visible = true;
            fullOnlyLab.Visible = true;
            fearesgb.Visible = false;
            localRad.Visible = false;
            fullRad.Checked = true;
            fullRad.Enabled = false;
            FullBktGB.Visible = false;
            if (modelTooSmallForBreakout())
                fullOnlyLab.Text = "Model size less than " + minElementsForBreakout + " elements. local region analysis not available";
            else if (!haveResults())
            {
                fullOnlyLab.Text = "No previous results available. This model can only be solved as full model";
            }
            else
            {
                fullRad.Enabled = true;
                fullOnlyLab.Visible = false;
                fearesgb.Visible = true;
                FullBktGB.Visible = true;
                localRad.Visible = true;
                fullRad.Checked = !breakoutRun;
                localRad.Checked = breakoutRun;
                FullBktGB.Visible = localRad.Checked;
                maxRad.Checked = !breakoutAtNode;
                if (breakoutDispFromCSV())
                {
                    if (!checkForBktAtMaxDefault())
                    {
                        maxRad.Visible = false;
                        nodeRad.Checked = true;
                        nodeRad.Visible = nodeTB.Visible = true;
                        breakoutAtNode = true;
                    }
                }
                if (breakoutAtNode)
                {
                    nodeRad.Checked = true;
                    nodeTB.Visible = true;

                    if (breakoutNode != -1)
                    {
                        int n = breakoutNode;
                        nodeTB.Text = n.ToString();
                    }
                    else
                        nodeTB.Clear();
                }
                else
                    nodeTB.Visible = false;
                if (activeResultType == NasResTypes.csv)
                {
                    fearestb.Text = breakoutDispFileName;
                    if (partialDisplacements)
                        maxRad.Text = "In Selected Region (Data Table)";
                }
                else if (activeResultType == NasResTypes.op2)
                    fearestb.Text = op2Name;
                else if (activeResultType ==  NasResTypes.f06)
                    fearestb.Text = f06File;
            }
        }

        private void fullRad_CheckedChanged(object sender, EventArgs e)
        {
            FullBktGB.Visible = !fullRad.Checked;
        }

        private void localRad_CheckedChanged(object sender, EventArgs e)
        {
            FullBktGB.Visible = localRad.Checked;
        }

        bool haveResults()
        {
            return activeResultType != NasResTypes.none;
        }

        private void nodeRad_CheckedChanged(object sender, EventArgs e)
        {
            nodeTB.Visible = nodeRad.Checked;
            breakoutAtNode = nodeRad.Checked;
        }

        private void maxRad_CheckedChanged(object sender, EventArgs e)
        {
            nodeTB.Visible = !maxRad.Checked;
            breakoutAtNode = !maxRad.Checked;
        }

        private void FeaFileTB_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class matstress
    {
        public matstress()
        {
            pos = new double[3];
            for (int i = 0; i < 3; i++)
                pos[i] = 0.0;
        }
        public double[] pos;
        public double svm;
    }

}
