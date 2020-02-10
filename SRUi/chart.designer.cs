namespace SRUi
{
    partial class chart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chart));
            this.doneBut = new System.Windows.Forms.Button();
            this.CnvGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.CnvGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // doneBut
            // 
            this.doneBut.Location = new System.Drawing.Point(373, 677);
            this.doneBut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.doneBut.Name = "doneBut";
            this.doneBut.Size = new System.Drawing.Size(77, 33);
            this.doneBut.TabIndex = 2;
            this.doneBut.Text = "done";
            this.doneBut.UseVisualStyleBackColor = true;
            this.doneBut.Click += new System.EventHandler(this.doneBut_Click);
            // 
            // CnvGraph
            // 
            chartArea1.AxisX.Title = "Convergence Pass";
            chartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            chartArea1.AxisY.Title = "Max Von Mises Stress";
            chartArea1.Name = "ChartArea1";
            this.CnvGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.CnvGraph.Legends.Add(legend1);
            this.CnvGraph.Location = new System.Drawing.Point(19, 20);
            this.CnvGraph.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CnvGraph.Name = "CnvGraph";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Stress";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "StressPoints";
            this.CnvGraph.Series.Add(series1);
            this.CnvGraph.Series.Add(series2);
            this.CnvGraph.Size = new System.Drawing.Size(819, 640);
            this.CnvGraph.TabIndex = 1;
            this.CnvGraph.Text = "Convergence";
            title1.Name = "Title1";
            this.CnvGraph.Titles.Add(title1);
            // 
            // chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 719);
            this.Controls.Add(this.doneBut);
            this.Controls.Add(this.CnvGraph);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "chart";
            this.Text = "Convergence";
            ((System.ComponentModel.ISupportInitialize)(this.CnvGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button doneBut;
        private System.Windows.Forms.DataVisualization.Charting.Chart CnvGraph;
    }
}