namespace SRUi
{
    partial class msgBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(msgBox));
            this.doneBut = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cancelBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // doneBut
            // 
            this.doneBut.Location = new System.Drawing.Point(318, 229);
            this.doneBut.Margin = new System.Windows.Forms.Padding(4);
            this.doneBut.Name = "doneBut";
            this.doneBut.Size = new System.Drawing.Size(100, 28);
            this.doneBut.TabIndex = 0;
            this.doneBut.Text = "OK";
            this.doneBut.UseVisualStyleBackColor = true;
            this.doneBut.Click += new System.EventHandler(this.doneBut_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 31);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(819, 179);
            this.textBox1.TabIndex = 1;
            // 
            // cancelBut
            // 
            this.cancelBut.Location = new System.Drawing.Point(458, 229);
            this.cancelBut.Name = "cancelBut";
            this.cancelBut.Size = new System.Drawing.Size(75, 29);
            this.cancelBut.TabIndex = 2;
            this.cancelBut.Text = "No";
            this.cancelBut.UseVisualStyleBackColor = true;
            this.cancelBut.Click += new System.EventHandler(this.cancelBut_Click);
            // 
            // msgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 270);
            this.Controls.Add(this.cancelBut);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.doneBut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "msgBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StressRefine Message";
            this.Load += new System.EventHandler(this.msgBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button doneBut;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button cancelBut;
    }
}