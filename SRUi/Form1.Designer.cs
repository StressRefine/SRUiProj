namespace SRUi
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.FeaFileTB = new System.Windows.Forms.TextBox();
            this.RunBut = new System.Windows.Forms.Button();
            this.SettBut = new System.Windows.Forms.Button();
            this.DoneBut = new System.Windows.Forms.Button();
            this.RunGB = new System.Windows.Forms.GroupBox();
            this.FullBktGB = new System.Windows.Forms.GroupBox();
            this.nodeTB = new System.Windows.Forms.TextBox();
            this.nodeRad = new System.Windows.Forms.RadioButton();
            this.maxRad = new System.Windows.Forms.RadioButton();
            this.fullOnlyLab = new System.Windows.Forms.Label();
            this.localRad = new System.Windows.Forms.RadioButton();
            this.fullRad = new System.Windows.Forms.RadioButton();
            this.ResultsGB = new System.Windows.Forms.GroupBox();
            this.cnvBut = new System.Windows.Forms.Button();
            this.VizBut = new System.Windows.Forms.Button();
            this.Report = new System.Windows.Forms.Button();
            this.FeaFileBut = new System.Windows.Forms.Button();
            this.helpBut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.OptionsBut = new System.Windows.Forms.Button();
            this.fearesgb = new System.Windows.Forms.GroupBox();
            this.fearestb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RunGB.SuspendLayout();
            this.FullBktGB.SuspendLayout();
            this.ResultsGB.SuspendLayout();
            this.fearesgb.SuspendLayout();
            this.SuspendLayout();
            // 
            // FeaFileTB
            // 
            this.FeaFileTB.Location = new System.Drawing.Point(28, 66);
            this.FeaFileTB.Margin = new System.Windows.Forms.Padding(4);
            this.FeaFileTB.Name = "FeaFileTB";
            this.FeaFileTB.ReadOnly = true;
            this.FeaFileTB.Size = new System.Drawing.Size(769, 22);
            this.FeaFileTB.TabIndex = 1;
            this.FeaFileTB.TextChanged += new System.EventHandler(this.FeaFileTB_TextChanged);
            // 
            // RunBut
            // 
            this.RunBut.Location = new System.Drawing.Point(25, 17);
            this.RunBut.Margin = new System.Windows.Forms.Padding(4);
            this.RunBut.Name = "RunBut";
            this.RunBut.Size = new System.Drawing.Size(124, 30);
            this.RunBut.TabIndex = 2;
            this.RunBut.Text = "Solve";
            this.RunBut.UseVisualStyleBackColor = true;
            this.RunBut.Click += new System.EventHandler(this.RunBut_Click);
            // 
            // SettBut
            // 
            this.SettBut.Location = new System.Drawing.Point(680, 8);
            this.SettBut.Margin = new System.Windows.Forms.Padding(4);
            this.SettBut.Name = "SettBut";
            this.SettBut.Size = new System.Drawing.Size(100, 26);
            this.SettBut.TabIndex = 3;
            this.SettBut.Text = "Settings";
            this.SettBut.UseVisualStyleBackColor = true;
            this.SettBut.Click += new System.EventHandler(this.SettBut_Click);
            // 
            // DoneBut
            // 
            this.DoneBut.Location = new System.Drawing.Point(342, 483);
            this.DoneBut.Margin = new System.Windows.Forms.Padding(4);
            this.DoneBut.Name = "DoneBut";
            this.DoneBut.Size = new System.Drawing.Size(100, 28);
            this.DoneBut.TabIndex = 7;
            this.DoneBut.Text = "Done";
            this.DoneBut.UseVisualStyleBackColor = true;
            this.DoneBut.Click += new System.EventHandler(this.DoneBut_Click);
            // 
            // RunGB
            // 
            this.RunGB.Controls.Add(this.FullBktGB);
            this.RunGB.Controls.Add(this.fullOnlyLab);
            this.RunGB.Controls.Add(this.localRad);
            this.RunGB.Controls.Add(this.RunBut);
            this.RunGB.Controls.Add(this.fullRad);
            this.RunGB.Controls.Add(this.SettBut);
            this.RunGB.Location = new System.Drawing.Point(28, 156);
            this.RunGB.Margin = new System.Windows.Forms.Padding(4);
            this.RunGB.Name = "RunGB";
            this.RunGB.Padding = new System.Windows.Forms.Padding(4);
            this.RunGB.Size = new System.Drawing.Size(788, 217);
            this.RunGB.TabIndex = 8;
            this.RunGB.TabStop = false;
            // 
            // FullBktGB
            // 
            this.FullBktGB.Controls.Add(this.nodeTB);
            this.FullBktGB.Controls.Add(this.nodeRad);
            this.FullBktGB.Controls.Add(this.maxRad);
            this.FullBktGB.Location = new System.Drawing.Point(84, 123);
            this.FullBktGB.Name = "FullBktGB";
            this.FullBktGB.Size = new System.Drawing.Size(559, 89);
            this.FullBktGB.TabIndex = 4;
            this.FullBktGB.TabStop = false;
            // 
            // nodeTB
            // 
            this.nodeTB.Location = new System.Drawing.Point(188, 45);
            this.nodeTB.Name = "nodeTB";
            this.nodeTB.Size = new System.Drawing.Size(55, 22);
            this.nodeTB.TabIndex = 17;
            // 
            // nodeRad
            // 
            this.nodeRad.AutoSize = true;
            this.nodeRad.Location = new System.Drawing.Point(7, 45);
            this.nodeRad.Name = "nodeRad";
            this.nodeRad.Size = new System.Drawing.Size(164, 21);
            this.nodeRad.TabIndex = 15;
            this.nodeRad.TabStop = true;
            this.nodeRad.Text = "Near Specified Node:";
            this.nodeRad.UseVisualStyleBackColor = true;
            this.nodeRad.CheckedChanged += new System.EventHandler(this.nodeRad_CheckedChanged);
            // 
            // maxRad
            // 
            this.maxRad.AutoSize = true;
            this.maxRad.Location = new System.Drawing.Point(7, 16);
            this.maxRad.Margin = new System.Windows.Forms.Padding(4);
            this.maxRad.Name = "maxRad";
            this.maxRad.Size = new System.Drawing.Size(205, 21);
            this.maxRad.TabIndex = 13;
            this.maxRad.TabStop = true;
            this.maxRad.Text = "At Maximum Stress in Model";
            this.maxRad.UseVisualStyleBackColor = true;
            this.maxRad.CheckedChanged += new System.EventHandler(this.maxRad_CheckedChanged);
            // 
            // fullOnlyLab
            // 
            this.fullOnlyLab.AutoSize = true;
            this.fullOnlyLab.Location = new System.Drawing.Point(173, 68);
            this.fullOnlyLab.Name = "fullOnlyLab";
            this.fullOnlyLab.Size = new System.Drawing.Size(472, 17);
            this.fullOnlyLab.TabIndex = 10;
            this.fullOnlyLab.Text = "No previous results available. This model can only be solved as full model";
            // 
            // localRad
            // 
            this.localRad.AutoSize = true;
            this.localRad.Location = new System.Drawing.Point(34, 95);
            this.localRad.Margin = new System.Windows.Forms.Padding(4);
            this.localRad.Name = "localRad";
            this.localRad.Size = new System.Drawing.Size(151, 21);
            this.localRad.TabIndex = 14;
            this.localRad.TabStop = true;
            this.localRad.Text = "Solve Local Region";
            this.localRad.UseVisualStyleBackColor = true;
            this.localRad.CheckedChanged += new System.EventHandler(this.localRad_CheckedChanged);
            // 
            // fullRad
            // 
            this.fullRad.AutoSize = true;
            this.fullRad.Location = new System.Drawing.Point(34, 66);
            this.fullRad.Margin = new System.Windows.Forms.Padding(4);
            this.fullRad.Name = "fullRad";
            this.fullRad.Size = new System.Drawing.Size(132, 21);
            this.fullRad.TabIndex = 11;
            this.fullRad.TabStop = true;
            this.fullRad.Text = "Solve Full Model";
            this.fullRad.UseVisualStyleBackColor = true;
            this.fullRad.CheckedChanged += new System.EventHandler(this.fullRad_CheckedChanged);
            // 
            // ResultsGB
            // 
            this.ResultsGB.Controls.Add(this.cnvBut);
            this.ResultsGB.Controls.Add(this.VizBut);
            this.ResultsGB.Controls.Add(this.Report);
            this.ResultsGB.Location = new System.Drawing.Point(28, 390);
            this.ResultsGB.Margin = new System.Windows.Forms.Padding(4);
            this.ResultsGB.Name = "ResultsGB";
            this.ResultsGB.Padding = new System.Windows.Forms.Padding(4);
            this.ResultsGB.Size = new System.Drawing.Size(732, 75);
            this.ResultsGB.TabIndex = 7;
            this.ResultsGB.TabStop = false;
            this.ResultsGB.Text = "Results";
            // 
            // cnvBut
            // 
            this.cnvBut.Location = new System.Drawing.Point(302, 34);
            this.cnvBut.Margin = new System.Windows.Forms.Padding(4);
            this.cnvBut.Name = "cnvBut";
            this.cnvBut.Size = new System.Drawing.Size(112, 28);
            this.cnvBut.TabIndex = 2;
            this.cnvBut.Text = "Convergence";
            this.cnvBut.UseVisualStyleBackColor = true;
            this.cnvBut.Click += new System.EventHandler(this.cnvBut_Click);
            // 
            // VizBut
            // 
            this.VizBut.Location = new System.Drawing.Point(140, 34);
            this.VizBut.Margin = new System.Windows.Forms.Padding(4);
            this.VizBut.Name = "VizBut";
            this.VizBut.Size = new System.Drawing.Size(135, 28);
            this.VizBut.TabIndex = 1;
            this.VizBut.Text = "Stress Fringes";
            this.VizBut.UseVisualStyleBackColor = true;
            this.VizBut.Click += new System.EventHandler(this.VizBut_Click);
            // 
            // Report
            // 
            this.Report.Location = new System.Drawing.Point(9, 34);
            this.Report.Margin = new System.Windows.Forms.Padding(4);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(100, 28);
            this.Report.TabIndex = 0;
            this.Report.Text = "Report";
            this.Report.UseVisualStyleBackColor = true;
            this.Report.Click += new System.EventHandler(this.Report_Click);
            // 
            // FeaFileBut
            // 
            this.FeaFileBut.Location = new System.Drawing.Point(28, 28);
            this.FeaFileBut.Name = "FeaFileBut";
            this.FeaFileBut.Size = new System.Drawing.Size(306, 31);
            this.FeaFileBut.TabIndex = 9;
            this.FeaFileBut.Text = "Import Nastran Model";
            this.FeaFileBut.UseVisualStyleBackColor = true;
            this.FeaFileBut.Click += new System.EventHandler(this.FeaFileBut_Click);
            // 
            // helpBut
            // 
            this.helpBut.Location = new System.Drawing.Point(662, 483);
            this.helpBut.Name = "helpBut";
            this.helpBut.Size = new System.Drawing.Size(75, 28);
            this.helpBut.TabIndex = 11;
            this.helpBut.Text = "Help";
            this.helpBut.UseVisualStyleBackColor = true;
            this.helpBut.Click += new System.EventHandler(this.helpBut_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(675, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "About stressRefine";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OptionsBut
            // 
            this.OptionsBut.Location = new System.Drawing.Point(533, 1);
            this.OptionsBut.Name = "OptionsBut";
            this.OptionsBut.Size = new System.Drawing.Size(127, 23);
            this.OptionsBut.TabIndex = 13;
            this.OptionsBut.Text = "Result Options";
            this.OptionsBut.UseVisualStyleBackColor = true;
            this.OptionsBut.Click += new System.EventHandler(this.optionsBut_Click);
            // 
            // fearesgb
            // 
            this.fearesgb.Controls.Add(this.fearestb);
            this.fearesgb.Controls.Add(this.label1);
            this.fearesgb.Location = new System.Drawing.Point(28, 95);
            this.fearesgb.Name = "fearesgb";
            this.fearesgb.Size = new System.Drawing.Size(769, 62);
            this.fearesgb.TabIndex = 14;
            this.fearesgb.TabStop = false;
            // 
            // fearestb
            // 
            this.fearestb.Location = new System.Drawing.Point(0, 26);
            this.fearestb.Name = "fearestb";
            this.fearestb.ReadOnly = true;
            this.fearestb.Size = new System.Drawing.Size(769, 22);
            this.fearestb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fea Results:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 524);
            this.Controls.Add(this.fearesgb);
            this.Controls.Add(this.OptionsBut);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.helpBut);
            this.Controls.Add(this.FeaFileBut);
            this.Controls.Add(this.ResultsGB);
            this.Controls.Add(this.RunGB);
            this.Controls.Add(this.DoneBut);
            this.Controls.Add(this.FeaFileTB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "StressRefine";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.RunGB.ResumeLayout(false);
            this.RunGB.PerformLayout();
            this.FullBktGB.ResumeLayout(false);
            this.FullBktGB.PerformLayout();
            this.ResultsGB.ResumeLayout(false);
            this.fearesgb.ResumeLayout(false);
            this.fearesgb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FeaFileTB;
        private System.Windows.Forms.Button RunBut;
        private System.Windows.Forms.Button SettBut;
        private System.Windows.Forms.Button DoneBut;
        private System.Windows.Forms.GroupBox RunGB;
        private System.Windows.Forms.GroupBox ResultsGB;
        private System.Windows.Forms.Button VizBut;
        private System.Windows.Forms.Button Report;
        private System.Windows.Forms.Button cnvBut;
        private System.Windows.Forms.Button FeaFileBut;
        private System.Windows.Forms.Button helpBut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button OptionsBut;
        private System.Windows.Forms.GroupBox FullBktGB;
        private System.Windows.Forms.Label fullOnlyLab;
        private System.Windows.Forms.RadioButton fullRad;
        private System.Windows.Forms.RadioButton maxRad;
        private System.Windows.Forms.RadioButton localRad;
        private System.Windows.Forms.RadioButton nodeRad;
        private System.Windows.Forms.TextBox nodeTB;
        private System.Windows.Forms.GroupBox fearesgb;
        private System.Windows.Forms.TextBox fearestb;
        private System.Windows.Forms.Label label1;
    }
}

