namespace SRUi
{
    partial class ResForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResForm));
            this.doneBut = new System.Windows.Forms.Button();
            this.resTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // doneBut
            // 
            this.doneBut.Location = new System.Drawing.Point(386, 760);
            this.doneBut.Margin = new System.Windows.Forms.Padding(4);
            this.doneBut.Name = "doneBut";
            this.doneBut.Size = new System.Drawing.Size(100, 28);
            this.doneBut.TabIndex = 0;
            this.doneBut.Text = "Done";
            this.doneBut.UseVisualStyleBackColor = true;
            this.doneBut.Click += new System.EventHandler(this.doneBut_Click);
            // 
            // resTB
            // 
            this.resTB.Font = new System.Drawing.Font("Lucida Console", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resTB.Location = new System.Drawing.Point(21, 13);
            this.resTB.Margin = new System.Windows.Forms.Padding(4);
            this.resTB.Multiline = true;
            this.resTB.Name = "resTB";
            this.resTB.ReadOnly = true;
            this.resTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resTB.Size = new System.Drawing.Size(813, 719);
            this.resTB.TabIndex = 1;
            // 
            // ResForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(847, 801);
            this.Controls.Add(this.resTB);
            this.Controls.Add(this.doneBut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StressRefine Results";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button doneBut;
        private System.Windows.Forms.TextBox resTB;
    }
}