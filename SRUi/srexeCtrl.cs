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
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace SRUi
{
    public partial class srexeCtrl : Form
    {
        public Form1 mainform = null;
        public string title = "StressRefine Solution";
        public bool ploopRun = false;
        public string engineLoc;
        public int deltaSolveProgress = 7;
        int prevSolveProgress = 0;
        Process SRexe = null;
        string srOut = " ";
        string prevSRout = " ";
        int solveProgress = 0;
        int breakoutProg = 0;

        public srexeCtrl()
        {
            InitializeComponent();
        }

        public new DialogResult ShowDialog()
        {
            try
            {
                SRexe = new Process();
                SRexe.StartInfo.FileName = engineLoc;
                mainform.writeToLog("Srexe: " + engineLoc);
                SRexe.StartInfo.UseShellExecute = false;
                SRexe.StartInfo.CreateNoWindow = true;
                SRexe.StartInfo.RedirectStandardOutput = true;
                SRexe.StartInfo.Arguments = mainform.workingDir;
                SRexe.OutputDataReceived += new DataReceivedEventHandler(SROutputHandler);
                srOut = "Run Started";
                prevSRout = null;
                solveProgress = 0;
                breakoutProg = 0;
                SRexe.Start();
                mainform.writeToLog("Srexe started");
                Thread.Sleep(250);
                mainform.writeToLog("srexe BeginOutputReadLine");
                SRexe.BeginOutputReadLine();

                System.Windows.Forms.Timer exeTimer = new System.Windows.Forms.Timer();
                exeTimer.Tick += SrExeTimer;
                //note: default interval is 100 msec;
                exeTimer.Start();
                if (ploopRun)
                    UpdateStatus("Starting adaptive stress Analysis");
                else
                    UpdateStatus("preparing model for localized stress analysis...");
            }
            catch
            {
                mainform.catchWarningMsg("srexeCtrl showDialog");
            }
            return base.ShowDialog();
        }

        void SrExeTimer(Object caller, EventArgs args)
        {
            try
            {
                if (checkSRfinished())
                {
                    progUpdate(0);
                    var timer = (System.Windows.Forms.Timer)caller;
                    timer.Stop();
                    Thread.Sleep(500);
                    Close();
                    return;
                }
                if (ploopRun)
                {
                    if (solveProgress > prevSolveProgress)
                    {
                        progUpdate(solveProgress);
                        if (ploopRun)
                            UpdateStatus(srOut);
                    }
                    prevSolveProgress = solveProgress;
                }
                else
                {
                    breakoutProg++;
                    if (breakoutProg > 100)
                        breakoutProg = 0;
                    progUpdate(breakoutProg);
                }
            }
            catch
            {
                mainform.catchWarningMsg("SrExeTimer");
            }
        }

        void progUpdate(int prog)
        {
            try
            {
                progressBar1.Value = prog;
                progressBar1.Update();
            }
            catch
            {
                mainform.catchWarningMsg(": progZero");
            }
        }

        void UpdateStatus(string s)
        {
            try
            {
                statusTB.Text = s;
                statusTB.Update();
            }
            catch
            {
                mainform.catchWarningMsg(": UpdateStatus");
            }
        }

        private void cancelBut_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SRexe.HasExited)
                    SRexe.Kill();
                mainform.cancelClicked = true;
                Close();
            }
            catch
            {
                mainform.catchWarningMsg(": cancelBut_Click");
            }
        }

        private void SROutputHandler(object sendingProcess,
             DataReceivedEventArgs outLine)
        {
            try
            {
                if (!String.IsNullOrEmpty(outLine.Data))
                {
                    srOut = outLine.Data;
                    mainform.writeToLog("SROutputHandler: " + srOut);
                    if (srOut != prevSRout)
                        solveProgress += deltaSolveProgress;
                    prevSRout = srOut;
                    if (solveProgress > 100)
                        solveProgress = 100;
                }
            }
            catch
            {
                mainform.catchWarningMsg(": SROutputHandler");
            }
        }

        public bool checkSRfinished()
        {
            try
            {
                if (SRexe.HasExited)
                {
                    mainform.writeToLog("srexe HasExited");
                    SRexe.CancelOutputRead();
                    return true;
                }
            }
            catch
            {
                mainform.catchWarningMsg("checkSRfinished");
                return false;
            }
            return false;
        }

        private void srexeCtrl_Load(object sender, EventArgs e)
        {
            Text = title;
        }
    }
}
