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
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace SRUi
{
    public partial class translateCtrl : Form
    {
        public Form1 mainform = null;
        public bool cancelled = false;
        public string title;
        public double op2Seconds = 0.0;
        public double bdfSeconds = 0.0;
        
        string translateLoc = null;

        Process translator = null;
        int numTicks = 0;
        Process op2toSRbat = null;

        string op2name = null;
        bool prePendNX = false;


        public translateCtrl()
        {
            InitializeComponent();
        }

        public new DialogResult ShowDialog()
        {
            try
            {
                op2Seconds = mainform.GetElapsedSeconds();

                if (mainform.activeResultType == NasResTypes.op2)
                {
                    //run pynastran op2 translate:
                    doOp2toSR();
                }
                else
                    StartXlate();
            }
            catch
            {
                mainform.fatalMsg("translateCtrl showDialog");
            }
            return base.ShowDialog();
        }

        void StartXlate()
        {
            try
            {
                translateLoc = mainform.installDir + "BdfTranslate.exe";
                translator = new Process();
                translator.StartInfo.FileName = translateLoc;
                translator.StartInfo.Arguments = mainform.workingDir;
                translator.StartInfo.UseShellExecute = false;
                translator.StartInfo.CreateNoWindow = true;

                translator.Start();
                System.Windows.Forms.Timer xlateTimer = new System.Windows.Forms.Timer();
                xlateTimer.Interval = 100;
                xlateTimer.Tick += translateTimerHandler;
                xlateTimer.Start();
            }
            catch
            {
                mainform.fatalMsg("could not start translator. translateloc: " + translateLoc);
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            cancelled = true;
            Close();
        }

        public bool checkTranslateFinished()
        {
            try
            {
                if (translator.HasExited)
                {
                    mainform.writeToLog("translateExe HasExited");
                    return true;
                }
                    return false;
            }
            catch
            {
                mainform.catchWarningMsg("checkTranslateFinished");
                return false;
            }
        }

        public bool checkOp2Finished()
        {
            try
            {
                if (op2toSRbat.HasExited)
                {
                    mainform.writeToLog("op2toSR HasExited");
                    Thread.Sleep(250);
                    moveSRresFile();
                    return true;
                }
                return false;
            }
            catch
            {
                mainform.catchWarningMsg("checkOp2Finished");
                return false;
            }
        }

        void translateTimerHandler(Object caller, EventArgs args)
        {
            try
            {
                if (checkTranslateFinished())
                {
                    progressBar1.Value = 100;
                    var timer = (System.Windows.Forms.Timer)caller;
                    timer.Stop();
                    Thread.Sleep(250);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    bdfSeconds = mainform.GetElapsedSeconds() - op2Seconds;
                    Close();
                }
                else if(numTicks == 10)
                {
                    progressBar1.Value += 10;
                    if (progressBar1.Value > 100)
                        progressBar1.Value = 100;
                    numTicks = 0;
                }
                numTicks++;
            }
            catch
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                //assume this is benign but warn in log
                mainform.catchWarningMsg("translateTimerHandler");
                Close();
            }
        }

        void op2TimerHandler(Object caller, EventArgs args)
        {
            try
            {
                if (checkOp2Finished())
                {
                    var timer = (System.Windows.Forms.Timer)caller;
                    progressBar1.Value = 0;
                    timer.Stop();
                    op2Seconds = mainform.GetElapsedSeconds() - op2Seconds;
                    if (prePendNX)
                        feaFileLabel.Text = "Translating Model from Nx/Nastran...";
                    else
                        feaFileLabel.Text = "Translating Model from Nastran...";
                    Update();
                    StartXlate();
                    return;
                }
                else
                {
                    if (numTicks == 10)
                    {
                        progressBar1.Value += 10;
                        if (progressBar1.Value > 100)
                            progressBar1.Value = 100;
                        numTicks = 0;
                    }
                    numTicks++;
                }
            }
            catch
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                //assume this is benign but warn in log
                mainform.catchWarningMsg("op2TimerHandler");
                return;
            }
        }

        private void translateCtrl_Load(object sender, EventArgs e)
        {
            Text = title;
            if (!mainform.FemapModel)
            {
                feaFileLabel.Text = "Translating Nastran model...";
                if (mainform.activeResultType == NasResTypes.csv)
                    feaFileLabel.Text = "Translating Nastran model and results";
            }
            else
            {
                prePendNX = true;
                if (mainform.activeResultType != NasResTypes.csv)
                    feaFileLabel.Text = "Translating Nx/Nastran model and results";
            }
            if(mainform.activeResultType == NasResTypes.op2)
            {
                if(prePendNX)
                    feaFileLabel.Text = "Translating Binary Results From Nx/Nastran...";
                else
                    feaFileLabel.Text = "Translating Binary Results From Nastran...";
            }
        }

        public void doOp2toSR()
        {
            try
            {
                if (mainform.activeResultType != NasResTypes.op2)
                    return;
                op2name = mainform.op2Name;
                if (!mainform.op2toSROK || op2name == null)
                    return;
                string op2nameNoSpaces = op2name.Replace(' ', '_');
                if (op2nameNoSpaces != op2name)
                {
                    File.Copy(op2name, op2nameNoSpaces);
                    op2name = op2nameNoSpaces;
                }
                if (!File.Exists(op2name))
                    mainform.op2toSROK = false;
                this.Refresh();
                Thread.Sleep(250);
                string pybat;
                pybat = mainform.installDir + "op2toSR.bat";
                if (File.Exists(pybat))
                    File.Delete(pybat);
                StreamWriter tmpo = new StreamWriter(pybat);
                tmpo.WriteLine(mainform.pyExe + " " + mainform.pynasExe + " -cf " + op2name);
                tmpo.Close();
                string tmpSrrfile = op2name;
                tmpSrrfile += ".srr";
                if (File.Exists(tmpSrrfile))
                    File.Delete(tmpSrrfile);
                op2toSRbat = new Process();
                op2toSRbat.StartInfo.FileName = pybat;
                op2toSRbat.StartInfo.UseShellExecute = false;
                op2toSRbat.StartInfo.CreateNoWindow = true;

                System.Windows.Forms.Timer op2Timer = new System.Windows.Forms.Timer();
                op2Timer.Interval = 100;
                op2Timer.Tick += op2TimerHandler;
                op2Timer.Start();

                op2toSRbat.Start();
            }
            catch
            {
                mainform.op2toSROK = false;
                return;
            }
        }

        void moveSRresFile()
        {
            try
            {
                string tmpSRresFile = op2name;
                tmpSRresFile += ".srr";
                string SRresFile = mainform.SRFolder + "\\" + mainform.SRtail + ".srr";
                bool tmpSrrFound = false;
                for (int numtrys = 0; numtrys < 10; numtrys++)
                {
                    if (File.Exists(tmpSRresFile))
                    {
                        if (File.Exists(SRresFile))
                            File.Delete(SRresFile);
                        File.Move(tmpSRresFile, SRresFile);
                        tmpSrrFound = true;
                        break;
                    }
                    else
                        Thread.Sleep(250);
                }
                if (!tmpSrrFound)
                {
                    mainform.op2toSROK = false;
                    mainform.writeToLog("pynastran script failed to create srr file");
                }


            }
            catch
            {
                return;
            }
        }

    }
}
