namespace SRUi
{
    partial class translateCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(translateCtrl));
            this.Cancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.feaFileLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(247, 116);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(100, 28);
            this.Cancel.TabIndex = 0;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(45, 69);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(537, 28);
            this.progressBar1.TabIndex = 1;
            // 
            // feaFileLabel
            // 
            this.feaFileLabel.AutoSize = true;
            this.feaFileLabel.Location = new System.Drawing.Point(45, 13);
            this.feaFileLabel.Name = "feaFileLabel";
            this.feaFileLabel.Size = new System.Drawing.Size(85, 17);
            this.feaFileLabel.TabIndex = 2;
            this.feaFileLabel.Text = "feaFileLabel";
            // 
            // translateCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(621, 159);
            this.Controls.Add(this.feaFileLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Cancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "translateCtrl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "translateCtrl";
            this.Load += new System.EventHandler(this.translateCtrl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label feaFileLabel;
    }
}