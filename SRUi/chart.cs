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
using System.Windows.Forms;

namespace SRUi
{
    public partial class chart : Form
    {
        //class for xy plotting using c# chart functionality
        public double[] stress = null;
        public string StressUnitString;
        public Form1 mainform = null;
        public chart()
        {
            InitializeComponent();
        }

        public new DialogResult ShowDialog()
        {
            stress = new double[mainform.numStressPasses];
            double smin = 1.0e20, smax = 0.0;
            for (int i = 0; i < mainform.numStressPasses; i++)
            {
                stress[i] = mainform.stressPassVec[i];
                if (stress[i] < smin)
                    smin = stress[i];
                if (stress[i] > smax)
                    smax = stress[i];
            }
            double sdiff = Math.Abs(smax - smin);
            if (sdiff < 0.1 * smax)
                smin *= 0.9;
            double ymin, ymax;
            ymin = axisScale(smin, false);//roundup is false
            ymax = axisScale(smax, true);
            double[] x = new double[10];
            for (int i = 0; i < 10; i++)
                x[i] = 1 + (double)i;
            CnvGraph.ChartAreas["ChartArea1"].AxisX.Minimum = 1;
            CnvGraph.ChartAreas["ChartArea1"].AxisX.Maximum = mainform.numStressPasses;
            CnvGraph.ChartAreas["ChartArea1"].AxisY.Minimum = ymin;
            CnvGraph.ChartAreas["ChartArea1"].AxisY.Maximum = ymax;
            CnvGraph.Titles["Title1"].Text = "Maximum Von Mises Stress" + System.Environment.NewLine + StressUnitString;
            for (int i = 0; i < mainform.numStressPasses; i++)
            {
                CnvGraph.Series["Stress"].Points.AddXY(x[i], stress[i]);
                CnvGraph.Series["StressPoints"].Points.AddXY(x[i], stress[i]);
            }
            return base.ShowDialog();
        }
        private void doneBut_Click(object sender, EventArgs e)
        {
            Close();
        }
        private double axisScale(double val, bool roundup)
        {
            double valt = val;
            string s = val.ToString("e2");
            //-1052.0329112756 ("e2", en-US) -> -1.05e+003
            int n = s.LastIndexOf('e');
            string smant = s.Substring(0, n);
            char c = s[n + 1];
            int pm = 1;
            if (c == '-')
                pm = -1;
            string sexp = s.Substring(n + 2);
            double xmant;
            int mant;
            double.TryParse(smant, out xmant);

            int expon;
            int firstNonZero = 0;
            for (int i = 0; i < sexp.Length; i++)
            {
                if (sexp[i] != '0')
                {
                    firstNonZero = i;
                    break;
                }
            }
            int.TryParse(sexp.Substring(firstNonZero), out expon);
            if (pm > 0)
            {
                if (expon > 0)
                {
                    xmant *= 10.0;
                    expon -= 1;
                }
            }
            else
            {
                if (expon > 0)
                {
                    xmant *= 10.0;
                    expon += 1;
                }
            }
            expon *= pm;
            mant = (int)xmant;
            if (roundup)
                mant++;
            s = mant + ".0e" + expon;
            double.TryParse(s, out valt);
            return valt;
        }
    }
}
