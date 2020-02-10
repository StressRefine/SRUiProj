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
    public partial class eula : Form
    {
        //class to support form that show end-user license agreement

        public bool agreed = false;
        public eula()
        {
            InitializeComponent();
        }


        public void setAboutMode()
        {
            button1.Text = "OK";
            button2.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            agreed = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
