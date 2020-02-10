namespace SRUi
{
    partial class optionsDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(optionsDlg));
            this.useStressUnitsCB = new System.Windows.Forms.CheckBox();
            this.stressUnitsGB = new System.Windows.Forms.GroupBox();
            this.inStressLab = new System.Windows.Forms.Label();
            this.inStressCombo = new System.Windows.Forms.ComboBox();
            this.stressUnitsCB = new System.Windows.Forms.ComboBox();
            this.stressUnitsLabel = new System.Windows.Forms.Label();
            this.OKBut = new System.Windows.Forms.Button();
            this.CancelBut = new System.Windows.Forms.Button();
            this.f06CK = new System.Windows.Forms.CheckBox();
            this.resfolderGB = new System.Windows.Forms.GroupBox();
            this.userFolderGB = new System.Windows.Forms.GroupBox();
            this.userFolderTB = new System.Windows.Forms.TextBox();
            this.userFolderBut = new System.Windows.Forms.Button();
            this.userFolderRad = new System.Windows.Forms.RadioButton();
            this.inpFolderRad = new System.Windows.Forms.RadioButton();
            this.stressUnitsGB.SuspendLayout();
            this.resfolderGB.SuspendLayout();
            this.userFolderGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // useStressUnitsCB
            // 
            this.useStressUnitsCB.AutoSize = true;
            this.useStressUnitsCB.ForeColor = System.Drawing.Color.Black;
            this.useStressUnitsCB.Location = new System.Drawing.Point(50, 248);
            this.useStressUnitsCB.Name = "useStressUnitsCB";
            this.useStressUnitsCB.Size = new System.Drawing.Size(151, 21);
            this.useStressUnitsCB.TabIndex = 9;
            this.useStressUnitsCB.Text = "Define Stress Units";
            this.useStressUnitsCB.UseVisualStyleBackColor = true;
            this.useStressUnitsCB.CheckedChanged += new System.EventHandler(this.useStressUnitsCB_CheckedChanged);
            // 
            // stressUnitsGB
            // 
            this.stressUnitsGB.Controls.Add(this.inStressLab);
            this.stressUnitsGB.Controls.Add(this.inStressCombo);
            this.stressUnitsGB.Controls.Add(this.stressUnitsCB);
            this.stressUnitsGB.Controls.Add(this.stressUnitsLabel);
            this.stressUnitsGB.Location = new System.Drawing.Point(224, 248);
            this.stressUnitsGB.Name = "stressUnitsGB";
            this.stressUnitsGB.Size = new System.Drawing.Size(269, 101);
            this.stressUnitsGB.TabIndex = 14;
            this.stressUnitsGB.TabStop = false;
            // 
            // inStressLab
            // 
            this.inStressLab.AutoSize = true;
            this.inStressLab.Location = new System.Drawing.Point(6, 35);
            this.inStressLab.Name = "inStressLab";
            this.inStressLab.Size = new System.Drawing.Size(112, 17);
            this.inStressLab.TabIndex = 7;
            this.inStressLab.Text = "Units in Input file";
            // 
            // inStressCombo
            // 
            this.inStressCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inStressCombo.FormattingEnabled = true;
            this.inStressCombo.Items.AddRange(new object[] {
            "Pa (N/m^2)",
            "ksi",
            "Kgf/cm^2",
            "Mpa(N/mm^2)",
            "psi"});
            this.inStressCombo.Location = new System.Drawing.Point(122, 32);
            this.inStressCombo.Name = "inStressCombo";
            this.inStressCombo.Size = new System.Drawing.Size(114, 24);
            this.inStressCombo.TabIndex = 6;
            // 
            // stressUnitsCB
            // 
            this.stressUnitsCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stressUnitsCB.FormattingEnabled = true;
            this.stressUnitsCB.Items.AddRange(new object[] {
            "Pa (N/m^2)",
            "ksi",
            "Kgf/cm^2",
            "Mpa(N/mm^2)",
            "psi"});
            this.stressUnitsCB.Location = new System.Drawing.Point(122, 72);
            this.stressUnitsCB.Name = "stressUnitsCB";
            this.stressUnitsCB.Size = new System.Drawing.Size(114, 24);
            this.stressUnitsCB.TabIndex = 4;
            // 
            // stressUnitsLabel
            // 
            this.stressUnitsLabel.AutoSize = true;
            this.stressUnitsLabel.Location = new System.Drawing.Point(34, 72);
            this.stressUnitsLabel.Name = "stressUnitsLabel";
            this.stressUnitsLabel.Size = new System.Drawing.Size(84, 17);
            this.stressUnitsLabel.TabIndex = 5;
            this.stressUnitsLabel.Text = "Stress Units";
            // 
            // OKBut
            // 
            this.OKBut.Location = new System.Drawing.Point(224, 430);
            this.OKBut.Name = "OKBut";
            this.OKBut.Size = new System.Drawing.Size(75, 23);
            this.OKBut.TabIndex = 15;
            this.OKBut.Text = "OK";
            this.OKBut.UseVisualStyleBackColor = true;
            this.OKBut.Click += new System.EventHandler(this.OKBut_Click);
            // 
            // CancelBut
            // 
            this.CancelBut.Location = new System.Drawing.Point(361, 430);
            this.CancelBut.Name = "CancelBut";
            this.CancelBut.Size = new System.Drawing.Size(75, 23);
            this.CancelBut.TabIndex = 16;
            this.CancelBut.Text = "Cancel";
            this.CancelBut.UseVisualStyleBackColor = true;
            this.CancelBut.Click += new System.EventHandler(this.CancelBut_Click);
            // 
            // f06CK
            // 
            this.f06CK.AutoSize = true;
            this.f06CK.Location = new System.Drawing.Point(50, 378);
            this.f06CK.Name = "f06CK";
            this.f06CK.Size = new System.Drawing.Size(332, 21);
            this.f06CK.TabIndex = 18;
            this.f06CK.Text = "Output Ascii Nastran Results From StressRefine";
            this.f06CK.UseVisualStyleBackColor = true;
            // 
            // resfolderGB
            // 
            this.resfolderGB.Controls.Add(this.userFolderGB);
            this.resfolderGB.Controls.Add(this.userFolderRad);
            this.resfolderGB.Controls.Add(this.inpFolderRad);
            this.resfolderGB.Location = new System.Drawing.Point(26, 71);
            this.resfolderGB.Name = "resfolderGB";
            this.resfolderGB.Size = new System.Drawing.Size(627, 132);
            this.resfolderGB.TabIndex = 22;
            this.resfolderGB.TabStop = false;
            this.resfolderGB.Text = "Nastran Displacement Results Folder";
            // 
            // userFolderGB
            // 
            this.userFolderGB.Controls.Add(this.userFolderTB);
            this.userFolderGB.Controls.Add(this.userFolderBut);
            this.userFolderGB.Location = new System.Drawing.Point(18, 48);
            this.userFolderGB.Name = "userFolderGB";
            this.userFolderGB.Size = new System.Drawing.Size(609, 78);
            this.userFolderGB.TabIndex = 2;
            this.userFolderGB.TabStop = false;
            // 
            // userFolderTB
            // 
            this.userFolderTB.Location = new System.Drawing.Point(6, 50);
            this.userFolderTB.Name = "userFolderTB";
            this.userFolderTB.ReadOnly = true;
            this.userFolderTB.Size = new System.Drawing.Size(597, 22);
            this.userFolderTB.TabIndex = 1;
            // 
            // userFolderBut
            // 
            this.userFolderBut.Location = new System.Drawing.Point(6, 12);
            this.userFolderBut.Name = "userFolderBut";
            this.userFolderBut.Size = new System.Drawing.Size(75, 23);
            this.userFolderBut.TabIndex = 0;
            this.userFolderBut.Text = "browse";
            this.userFolderBut.UseVisualStyleBackColor = true;
            this.userFolderBut.Click += new System.EventHandler(this.userFolderBut_Click);
            // 
            // userFolderRad
            // 
            this.userFolderRad.AutoSize = true;
            this.userFolderRad.Location = new System.Drawing.Point(119, 21);
            this.userFolderRad.Name = "userFolderRad";
            this.userFolderRad.Size = new System.Drawing.Size(75, 21);
            this.userFolderRad.TabIndex = 1;
            this.userFolderRad.TabStop = true;
            this.userFolderRad.Text = "Specify";
            this.userFolderRad.UseVisualStyleBackColor = true;
            this.userFolderRad.CheckedChanged += new System.EventHandler(this.userFolderRad_CheckedChanged);
            // 
            // inpFolderRad
            // 
            this.inpFolderRad.AutoSize = true;
            this.inpFolderRad.Location = new System.Drawing.Point(18, 21);
            this.inpFolderRad.Name = "inpFolderRad";
            this.inpFolderRad.Size = new System.Drawing.Size(104, 21);
            this.inpFolderRad.TabIndex = 0;
            this.inpFolderRad.TabStop = true;
            this.inpFolderRad.Text = "Input Folder";
            this.inpFolderRad.UseVisualStyleBackColor = true;
            this.inpFolderRad.CheckedChanged += new System.EventHandler(this.inpFolderRad_CheckedChanged);
            // 
            // optionsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 475);
            this.Controls.Add(this.resfolderGB);
            this.Controls.Add(this.f06CK);
            this.Controls.Add(this.CancelBut);
            this.Controls.Add(this.OKBut);
            this.Controls.Add(this.stressUnitsGB);
            this.Controls.Add(this.useStressUnitsCB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "optionsDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Result Options";
            this.Load += new System.EventHandler(this.optionsDlg_Load);
            this.stressUnitsGB.ResumeLayout(false);
            this.stressUnitsGB.PerformLayout();
            this.resfolderGB.ResumeLayout(false);
            this.resfolderGB.PerformLayout();
            this.userFolderGB.ResumeLayout(false);
            this.userFolderGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox useStressUnitsCB;
        private System.Windows.Forms.GroupBox stressUnitsGB;
        private System.Windows.Forms.Label inStressLab;
        private System.Windows.Forms.ComboBox inStressCombo;
        private System.Windows.Forms.ComboBox stressUnitsCB;
        private System.Windows.Forms.Label stressUnitsLabel;
        private System.Windows.Forms.Button OKBut;
        private System.Windows.Forms.Button CancelBut;
        private System.Windows.Forms.CheckBox f06CK;
        private System.Windows.Forms.GroupBox resfolderGB;
        private System.Windows.Forms.GroupBox userFolderGB;
        private System.Windows.Forms.TextBox userFolderTB;
        private System.Windows.Forms.Button userFolderBut;
        private System.Windows.Forms.RadioButton userFolderRad;
        private System.Windows.Forms.RadioButton inpFolderRad;
    }
}