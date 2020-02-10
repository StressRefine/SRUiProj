namespace SRUi
{
    partial class srexeCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(srexeCtrl));
            this.cancelBut = new System.Windows.Forms.Button();
            this.statusTB = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // cancelBut
            // 
            this.cancelBut.Location = new System.Drawing.Point(289, 106);
            this.cancelBut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelBut.Name = "cancelBut";
            this.cancelBut.Size = new System.Drawing.Size(100, 28);
            this.cancelBut.TabIndex = 0;
            this.cancelBut.Text = "Cancel";
            this.cancelBut.UseVisualStyleBackColor = true;
            this.cancelBut.Click += new System.EventHandler(this.cancelBut_Click);
            // 
            // statusTB
            // 
            this.statusTB.Location = new System.Drawing.Point(19, 23);
            this.statusTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statusTB.Name = "statusTB";
            this.statusTB.ReadOnly = true;
            this.statusTB.Size = new System.Drawing.Size(648, 22);
            this.statusTB.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(156, 66);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(372, 28);
            this.progressBar1.TabIndex = 2;
            // 
            // srexeCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(684, 149);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.statusTB);
            this.Controls.Add(this.cancelBut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "srexeCtrl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "stressRefine Solution";
            this.Load += new System.EventHandler(this.srexeCtrl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBut;
        private System.Windows.Forms.TextBox statusTB;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}