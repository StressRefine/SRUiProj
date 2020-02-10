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

namespace SRUi
{
    public partial class Settings : Form
    {
        public Form1 mainform;
        public bool cancelled = false;
        double[] errTolVec = { 10, 5, 4, 3, 2, 1 };

        public Settings()
        {
            try
            {
                InitializeComponent();
            }
            catch
            {
                mainform.catchWarningMsg("settings");
            }
        }

        private void doneBut_Click(object sender, EventArgs e)
        {
            try
            {
                mainform.ignoreSacrificial = singCB.Checked;
                Close();
            }
            catch
            {
                mainform.catchWarningMsg("settings doneBut_Click");
            }
        }

        private void singCB_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                mainform.ignoreSacrificial = singCB.Checked;
            }
            catch
            {
                mainform.catchWarningMsg("singCB_CheckedChanged");
            }
        }

        private void econCB_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                mainform.econSolve = econCB.Checked;
                PGB.Visible = !econCB.Checked;
            }
            catch
            {
                mainform.catchWarningMsg("econCB_CheckedChanged");
            }
        }

        private void ErrTolCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int sel = ErrTolCB.SelectedIndex;
                mainform.errTol = errTolVec[sel];
            }
            catch
            {
                mainform.catchWarningMsg("ErrTolCB_SelectedIndexChanged");
            }
        }

        private void MaxItCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int sel = MaxItCB.SelectedIndex;
                mainform.maxIts = sel + 2;
            }
            catch
            {
                mainform.catchWarningMsg("MaxItCB_SelectedIndexChanged");
            }
        }

        private void minPCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int sel = minPCB.SelectedIndex;
                mainform.minP = sel + 2;
                pOKCheck();
            }
            catch
            {
                mainform.catchWarningMsg("minPCB_SelectedIndexChanged");
            }
        }

        private void maxPCB_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                int sel = maxPCB.SelectedIndex;
                mainform.maxP = sel + 2;
                pOKCheck();
            }
            catch
            {
                mainform.catchWarningMsg("maxPCB_SelectedIndexChanged");
            }
        }

        private void resetBut_Click(object sender, EventArgs e)
        {
            try
            {
                singCB.Checked = false;
                mainform.ignoreSacrificial = false;
                econCB.Checked = false;
                mainform.econSolve = false;
                ErrTolCB.SelectedIndex = 1;
                mainform.errTol = 5;
                MaxItCB.SelectedIndex = 1;
                mainform.maxIts = 3;
                minPCB.SelectedIndex = 0;
                mainform.minP = 2;
                maxPCB.SelectedIndex = 6;
                mainform.maxP = 8;
                mainform.uniformP = false;
                uniCB.Checked = false;
                mainform.deleteSettings();
            }
            catch
            {
                mainform.catchWarningMsg("resetBut_Click");
            }
        }

        private void saveBut_Click(object sender, EventArgs e)
        {
            try
            {
                mainform.WriteSettings();
            }
            catch
            {
                mainform.catchWarningMsg("saveBut_Click");
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
                singCB.Checked = mainform.ignoreSacrificial;
                econCB.Checked = mainform.econSolve;
                PGB.Visible = !mainform.econSolve;
                softSpringCB.Checked = mainform.useSoftSprings;
                ToolTip settingsTT = new ToolTip();
                settingsTT.SetToolTip(singCB, "Do not use sacrificial elements to eliminate singularities");
                settingsTT.SetToolTip(softSpringCB, "select if the model’s loads are in equilibrium but not all rigid body motion has been constrained");
                settingsTT.SetToolTip(econCB, "use automatic iteration and polynomial settings for a faster solution for large models");
                settingsTT.SetToolTip(minPCB, "set minimum polynomial order for the analysis (see user's guide)");
                settingsTT.SetToolTip(maxPCB, "set maximum polynomial order for the analysis (see user's guide)");
                settingsTT.SetToolTip(MaxItCB, "set maximum number of iterations for the analysis (see user's guide)");
                settingsTT.SetToolTip(ErrTolCB, "set target for the analysis for percentage error in stress  (see user's guide)");
                settingsTT.SetToolTip(resetBut, "reset to the default settings (shown in user's guide or if you click help below)");
                settingsTT.SetToolTip(saveBut, "save the current settings on this form for future stressrefine runs");

                bool found = false;
                for (int i = 0; i < 6; i++)
                {
                    if (errTolVec[i] == mainform.errTol)
                    {
                        found = true;
                        ErrTolCB.SelectedIndex = i;
                        break;
                    }
                }
                if (!found)//can't happen
                    ErrTolCB.SelectedIndex = 1;
                MaxItCB.SelectedIndex = mainform.maxIts - 2;
                minPCB.SelectedIndex = mainform.minP - 2;
                maxPCB.SelectedIndex = mainform.maxP - 2;
            }
            catch
            {
                mainform.catchWarningMsg("settings");
            }
        }

        void pOKCheck()
        {
            if (mainform.minP > mainform.maxP)
            {
                mainform.minP = mainform.maxP;
                minPCB.SelectedIndex = mainform.minP - 2;
                mainform.ShowMessage(" maximum P must be >= minumum P");
            }
        }

        private void softSpringCB_CheckedChanged(object sender, EventArgs e)
        {
            mainform.useSoftSprings = softSpringCB.Checked;
        }

        private void cancelBut_Click(object sender, EventArgs e)
        {
            cancelled = true;
            Close();
        }

        private void helpBut_Click(object sender, EventArgs e)
        {
            Process helper = new Process();
            helper.StartInfo.FileName = mainform.installDir + "helpFiles\\settingsHelp.pdf";
            helper.Start();
            helper.WaitForExit();
        }

        private void uniCB_CheckedChanged(object sender, EventArgs e)
        {
            mainform.uniformP = uniCB.Checked;
        }

        private void nodeTB_TextChanged(object sender, EventArgs e)
        {

        }

    }

}
