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
using System.Windows.Forms;

namespace SRUi
{
    public partial class vizForm : Form
    {
        //class for supporting visualization form using open source program cgx
        private TextBox textBox1;
        private Button doneBut;

        public vizForm()
        {
            InitializeComponent();
            //System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.PrimaryScreen;
            //int x = screen.Bounds.Width - 700;
            //this.Location = new Point(x, 500);
        }

        private void done_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vizForm));
            this.doneBut = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // doneBut
            // 
            this.doneBut.Location = new System.Drawing.Point(191, 346);
            this.doneBut.Name = "doneBut";
            this.doneBut.Size = new System.Drawing.Size(80, 27);
            this.doneBut.TabIndex = 0;
            this.doneBut.Text = "done";
            this.doneBut.UseVisualStyleBackColor = true;
            this.doneBut.Click += new System.EventHandler(this.doneBut_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(57, 36);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(331, 292);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // vizForm
            // 
            this.ClientSize = new System.Drawing.Size(454, 388);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.doneBut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "vizForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "stressRefine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void doneBut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
