namespace SRUi
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.uniCB = new System.Windows.Forms.CheckBox();
            this.saveBut = new System.Windows.Forms.Button();
            this.resetBut = new System.Windows.Forms.Button();
            this.PGB = new System.Windows.Forms.GroupBox();
            this.minPCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maxPCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MaxItCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrTolCB = new System.Windows.Forms.ComboBox();
            this.Errlab = new System.Windows.Forms.Label();
            this.econCB = new System.Windows.Forms.CheckBox();
            this.singCB = new System.Windows.Forms.CheckBox();
            this.doneBut = new System.Windows.Forms.Button();
            this.softSpringCB = new System.Windows.Forms.CheckBox();
            this.cancelBut = new System.Windows.Forms.Button();
            this.helpBut = new System.Windows.Forms.Button();
            this.PGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // uniCB
            // 
            this.uniCB.AutoSize = true;
            this.uniCB.Location = new System.Drawing.Point(414, 110);
            this.uniCB.Name = "uniCB";
            this.uniCB.Size = new System.Drawing.Size(155, 21);
            this.uniCB.TabIndex = 6;
            this.uniCB.Text = "Uniform Refinement";
            this.uniCB.UseVisualStyleBackColor = true;
            this.uniCB.CheckedChanged += new System.EventHandler(this.uniCB_CheckedChanged);
            // 
            // saveBut
            // 
            this.saveBut.Location = new System.Drawing.Point(285, 370);
            this.saveBut.Margin = new System.Windows.Forms.Padding(4);
            this.saveBut.Name = "saveBut";
            this.saveBut.Size = new System.Drawing.Size(204, 28);
            this.saveBut.TabIndex = 5;
            this.saveBut.Text = "Save as default";
            this.saveBut.UseVisualStyleBackColor = true;
            this.saveBut.Click += new System.EventHandler(this.saveBut_Click);
            // 
            // resetBut
            // 
            this.resetBut.Location = new System.Drawing.Point(41, 370);
            this.resetBut.Margin = new System.Windows.Forms.Padding(4);
            this.resetBut.Name = "resetBut";
            this.resetBut.Size = new System.Drawing.Size(204, 28);
            this.resetBut.TabIndex = 4;
            this.resetBut.Text = "Reset to \"factory\" defaults";
            this.resetBut.UseVisualStyleBackColor = true;
            this.resetBut.Click += new System.EventHandler(this.resetBut_Click);
            // 
            // PGB
            // 
            this.PGB.Controls.Add(this.minPCB);
            this.PGB.Controls.Add(this.label3);
            this.PGB.Controls.Add(this.maxPCB);
            this.PGB.Controls.Add(this.label2);
            this.PGB.Controls.Add(this.MaxItCB);
            this.PGB.Controls.Add(this.label1);
            this.PGB.Controls.Add(this.ErrTolCB);
            this.PGB.Controls.Add(this.Errlab);
            this.PGB.Location = new System.Drawing.Point(41, 169);
            this.PGB.Margin = new System.Windows.Forms.Padding(4);
            this.PGB.Name = "PGB";
            this.PGB.Padding = new System.Windows.Forms.Padding(4);
            this.PGB.Size = new System.Drawing.Size(697, 145);
            this.PGB.TabIndex = 3;
            this.PGB.TabStop = false;
            // 
            // minPCB
            // 
            this.minPCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.minPCB.FormattingEnabled = true;
            this.minPCB.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.minPCB.Location = new System.Drawing.Point(195, 78);
            this.minPCB.Margin = new System.Windows.Forms.Padding(4);
            this.minPCB.Name = "minPCB";
            this.minPCB.Size = new System.Drawing.Size(73, 24);
            this.minPCB.TabIndex = 7;
            this.minPCB.SelectedIndexChanged += new System.EventHandler(this.minPCB_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Minimum Polynomial Order:";
            // 
            // maxPCB
            // 
            this.maxPCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maxPCB.FormattingEnabled = true;
            this.maxPCB.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.maxPCB.Location = new System.Drawing.Point(491, 84);
            this.maxPCB.Margin = new System.Windows.Forms.Padding(4);
            this.maxPCB.Name = "maxPCB";
            this.maxPCB.Size = new System.Drawing.Size(73, 24);
            this.maxPCB.TabIndex = 5;
            this.maxPCB.SelectedIndexChanged += new System.EventHandler(this.maxPCB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Maximum Polynomial Order:";
            // 
            // MaxItCB
            // 
            this.MaxItCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MaxItCB.FormattingEnabled = true;
            this.MaxItCB.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.MaxItCB.Location = new System.Drawing.Point(443, 25);
            this.MaxItCB.Margin = new System.Windows.Forms.Padding(4);
            this.MaxItCB.Name = "MaxItCB";
            this.MaxItCB.Size = new System.Drawing.Size(73, 24);
            this.MaxItCB.TabIndex = 3;
            this.MaxItCB.SelectedIndexChanged += new System.EventHandler(this.MaxItCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Maximum Numer of Iterations:";
            // 
            // ErrTolCB
            // 
            this.ErrTolCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ErrTolCB.FormattingEnabled = true;
            this.ErrTolCB.Items.AddRange(new object[] {
            "10%",
            "5%",
            "4%",
            "3%",
            "2%",
            "1%"});
            this.ErrTolCB.Location = new System.Drawing.Point(128, 25);
            this.ErrTolCB.Margin = new System.Windows.Forms.Padding(4);
            this.ErrTolCB.Name = "ErrTolCB";
            this.ErrTolCB.Size = new System.Drawing.Size(73, 24);
            this.ErrTolCB.TabIndex = 1;
            this.ErrTolCB.SelectedIndexChanged += new System.EventHandler(this.ErrTolCB_SelectedIndexChanged);
            // 
            // Errlab
            // 
            this.Errlab.AutoSize = true;
            this.Errlab.Location = new System.Drawing.Point(9, 25);
            this.Errlab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Errlab.Name = "Errlab";
            this.Errlab.Size = new System.Drawing.Size(112, 17);
            this.Errlab.TabIndex = 0;
            this.Errlab.Text = "Error Tolerance:";
            // 
            // econCB
            // 
            this.econCB.AutoSize = true;
            this.econCB.Location = new System.Drawing.Point(261, 110);
            this.econCB.Margin = new System.Windows.Forms.Padding(4);
            this.econCB.Name = "econCB";
            this.econCB.Size = new System.Drawing.Size(135, 21);
            this.econCB.TabIndex = 2;
            this.econCB.Text = "Econonmy Solve";
            this.econCB.UseVisualStyleBackColor = true;
            this.econCB.CheckedChanged += new System.EventHandler(this.econCB_CheckedChanged);
            // 
            // singCB
            // 
            this.singCB.AutoSize = true;
            this.singCB.Location = new System.Drawing.Point(41, 110);
            this.singCB.Margin = new System.Windows.Forms.Padding(4);
            this.singCB.Name = "singCB";
            this.singCB.Size = new System.Drawing.Size(194, 21);
            this.singCB.TabIndex = 0;
            this.singCB.Text = "Do not detect singularities";
            this.singCB.UseVisualStyleBackColor = true;
            this.singCB.CheckedChanged += new System.EventHandler(this.singCB_CheckedChanged);
            // 
            // doneBut
            // 
            this.doneBut.Location = new System.Drawing.Point(141, 456);
            this.doneBut.Margin = new System.Windows.Forms.Padding(4);
            this.doneBut.Name = "doneBut";
            this.doneBut.Size = new System.Drawing.Size(100, 28);
            this.doneBut.TabIndex = 5;
            this.doneBut.Text = "Done";
            this.doneBut.UseVisualStyleBackColor = true;
            this.doneBut.Click += new System.EventHandler(this.doneBut_Click);
            // 
            // softSpringCB
            // 
            this.softSpringCB.AutoSize = true;
            this.softSpringCB.Location = new System.Drawing.Point(41, 38);
            this.softSpringCB.Margin = new System.Windows.Forms.Padding(4);
            this.softSpringCB.Name = "softSpringCB";
            this.softSpringCB.Size = new System.Drawing.Size(232, 21);
            this.softSpringCB.TabIndex = 7;
            this.softSpringCB.Text = "stabilize Model with Soft Springs";
            this.softSpringCB.UseVisualStyleBackColor = true;
            this.softSpringCB.CheckedChanged += new System.EventHandler(this.softSpringCB_CheckedChanged);
            // 
            // cancelBut
            // 
            this.cancelBut.Location = new System.Drawing.Point(321, 455);
            this.cancelBut.Name = "cancelBut";
            this.cancelBut.Size = new System.Drawing.Size(75, 29);
            this.cancelBut.TabIndex = 8;
            this.cancelBut.Text = "Cancel";
            this.cancelBut.UseVisualStyleBackColor = true;
            this.cancelBut.Click += new System.EventHandler(this.cancelBut_Click);
            // 
            // helpBut
            // 
            this.helpBut.Location = new System.Drawing.Point(561, 456);
            this.helpBut.Name = "helpBut";
            this.helpBut.Size = new System.Drawing.Size(75, 29);
            this.helpBut.TabIndex = 10;
            this.helpBut.Text = "Help";
            this.helpBut.UseVisualStyleBackColor = true;
            this.helpBut.Click += new System.EventHandler(this.helpBut_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(812, 512);
            this.Controls.Add(this.saveBut);
            this.Controls.Add(this.uniCB);
            this.Controls.Add(this.resetBut);
            this.Controls.Add(this.helpBut);
            this.Controls.Add(this.PGB);
            this.Controls.Add(this.cancelBut);
            this.Controls.Add(this.softSpringCB);
            this.Controls.Add(this.doneBut);
            this.Controls.Add(this.econCB);
            this.Controls.Add(this.singCB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StressRefine Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.PGB.ResumeLayout(false);
            this.PGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveBut;
        private System.Windows.Forms.Button resetBut;
        private System.Windows.Forms.GroupBox PGB;
        private System.Windows.Forms.ComboBox minPCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox maxPCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox MaxItCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ErrTolCB;
        private System.Windows.Forms.Label Errlab;
        private System.Windows.Forms.CheckBox econCB;
        private System.Windows.Forms.CheckBox singCB;
        private System.Windows.Forms.Button doneBut;
        private System.Windows.Forms.CheckBox softSpringCB;
        private System.Windows.Forms.Button cancelBut;
        private System.Windows.Forms.Button helpBut;
        private System.Windows.Forms.CheckBox uniCB;
    }
}