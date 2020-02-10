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

namespace SRUi
{
    public partial class optionsDlg : Form
    {
        //form for user options

        public Form1 mainform = null;
        string newline = System.Environment.NewLine;

        public optionsDlg()
        {
            InitializeComponent();
        }

        private void optionsDlg_Load(object sender, EventArgs e)
        {
            ToolTip optTT = new ToolTip();
            optTT.SetToolTip(useStressUnitsCB, "uncheck this box to use the units in the Nastran file, check to set your own");

            useStressUnitsCB.Checked = mainform.useStressUnits;
            SetStressUnitsVis();
            stressUnitsGB.Visible = mainform.useStressUnits;
            stressUnitsCB.SelectedIndex = mainform.stressUnits;
            inStressCombo.SelectedIndex = mainform.inStressUnits;
            f06CK.Checked = mainform.outputF06;
            inpFolderRad.Checked = mainform.resFolderIsFeaFolder;
            userFolderRad.Checked = userFolderGB.Visible = !mainform.resFolderIsFeaFolder;
            if(userFolderGB.Visible)
                userFolderTB.Text = mainform.userResFolderName;
        }

        private void SetStressUnitsVis()
        {
            stressUnitsGB.Visible = useStressUnitsCB.Checked;
            inStressLab.Visible = useStressUnitsCB.Checked;
            inStressCombo.Visible = useStressUnitsCB.Checked;
            stressUnitsLabel.Visible = useStressUnitsCB.Checked;
            stressUnitsCB.Visible = useStressUnitsCB.Checked;

        }

        private void useStressUnitsCB_CheckedChanged(object sender, EventArgs e)
        {
            SetStressUnitsVis();
        }

        private void OKBut_Click(object sender, EventArgs e)
        {
            try
            {
                mainform.useStressUnits = useStressUnitsCB.Checked;
                mainform.inStressUnits = inStressCombo.SelectedIndex;
                mainform.stressUnits = stressUnitsCB.SelectedIndex;
                mainform.setStressUnits();
                mainform.outputF06 = f06CK.Checked;
                Close();
            }
            catch
            {
                mainform.catchWarningMsg("optionsDlg doneBut_Click");
            }
        }

        private void CancelBut_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch
            {
                mainform.catchWarningMsg("optionsDlg CancelBut_Click");
            }
        }

        private void userFolderBut_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog userFolderDlg = new FolderBrowserDialog();

                // Set the help text description for the FolderBrowserDialog.
                userFolderDlg.Description =
                    "Select the folder for Nastran results";

                // Do not allow the user to create new files via the FolderBrowserDialog.
                userFolderDlg.ShowNewFolderButton = false;

                // Default to the My Documents folder.
                userFolderDlg.RootFolder = Environment.SpecialFolder.Personal;

                DialogResult result = userFolderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    mainform.userResFolderName = userFolderDlg.SelectedPath;
                    userFolderTB.Text = mainform.userResFolderName;
                }
                else
                    mainform.resFolderIsFeaFolder = true;
            }
            catch
            {
                mainform.resFolderIsFeaFolder = true;
            }

        }

        private void inpFolderRad_CheckedChanged(object sender, EventArgs e)
        {
            mainform.resFolderIsFeaFolder = inpFolderRad.Checked;
            userFolderGB.Visible = !inpFolderRad.Checked;
        }

        private void userFolderRad_CheckedChanged(object sender, EventArgs e)
        {
            mainform.resFolderIsFeaFolder = !userFolderRad.Checked;
            userFolderGB.Visible = userFolderRad.Checked;
        }
    }
}
