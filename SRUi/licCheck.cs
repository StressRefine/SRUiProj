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
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using System.Runtime.InteropServices;
using System.Globalization;

namespace SRUi
{
    public class licenseChecker
    {
        public Form1 mainForm = null;
        public bool licCheck(bool checkEula)
        {
            bool ret = false;
            bool skiplic = false;
            if (skiplic)
                return true;
            string cuskey = null;
            int todayjul = GetJulianDate();
            bool licFileExists = false;
            try
            {
                string AcLicName = mainForm.installDir + "\\license.txt";
                if (!File.Exists(AcLicName))
                {
                    if (checkEula)
                    {
                        eula edlg = new eula();
                        edlg.ShowDialog();
                        if (!edlg.agreed)
                        {
                            mainForm.ShowMessage(" StressRefine cannot be run without agreeing to the" + System.Environment.NewLine +
                                "terms of the license agreement");
                            return false;
                        }
                    }
                    licForm dlg = new licForm();
                    dlg.ShowDialog();
                    cuskey = dlg.key;
                    StreamWriter tmp = new StreamWriter(AcLicName);
                    tmp.WriteLine(cuskey);
                    tmp.Close();
                }
                else
                {
                    StreamReader tmp = new StreamReader(AcLicName);
                    cuskey = tmp.ReadLine();
                    tmp.Close();
                    licFileExists = true;
                }
                if (cuskey.Length >= 24)
                {
                    bool academicLicense = false;
                    int numdays = 30;
                    int keyjuldate = keyParse(cuskey, out academicLicense);
                    if (academicLicense)
                    {
                        numdays = 180;
                        //int daysRem = numdays - (todayjul - keyjuldate);
                        //mainForm.ShowMessage(" academic license. days remaining " + daysRem);
                    }
                    if (todayjul - keyjuldate > numdays)
                    {
                        mainForm.ShowMessage("license expired");
                        if (licFileExists)
                            File.Delete(AcLicName);
                        return false;
                    }
                    else
                    {
                        if(checkEula && !academicLicense)
                        {
                            int daysleft = 30 - todayjul + keyjuldate;
                            mainForm.ShowMessage("days left in evaluation: " + daysleft);
                        }
                        return true;
                    }
                }
            }
            catch
            {
                ret = false;
            }

            if(!ret)
                mainForm.ShowMessage("no license");

            return ret;
        }

        private int keyParse(string key, out bool academicLicense)
        {
            int jd = 0;
            int nread = 0;
            int mult = 1000;
            academicLicense = false;
            if (key.StartsWith("A"))
                academicLicense = true;
            for (int n = 0; n < key.Length; n++)
            { 
                string c = new string(key[n], 1);
                int num;
                if(int.TryParse(c, out num))
                {
                    jd += num*mult;
                    nread++;
                    if(nread == 4)
                        break;
                    mult /= 10;
                }
            }
            return jd;
        }


        private int GetJulianDate()
        {
            int jul = 0;
            int []monthdays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            try
            {
                DateTime now = DateTime.Now;
                var culture = new CultureInfo("en-US");
                string s = now.ToString(culture);
                int n = s.IndexOf(' ');
                string date = s.Substring(0, n);
                char[] sep = { '/' };
                string[] subs = date.Split(sep);
                int day, month, year;
                int.TryParse(subs[0], out month);
                int.TryParse(subs[1], out day);
                int.TryParse(subs[2], out year);
                int m0 = month - 1;
                int prevMonthdays = 0;
                for (int i = 0; i < m0; i++)
                    prevMonthdays += monthdays[i];
                jul = year + prevMonthdays + day;
            }
            catch
            {
                return 0;
            }
            return jul;
        }
    }
}
