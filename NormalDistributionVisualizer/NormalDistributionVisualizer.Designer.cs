
namespace NormalDistributionVisualizer
{
	partial class NormalDistributionVisualizer
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
			this.chartDistribution = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.cbWeapon = new System.Windows.Forms.ComboBox();
			this.cbStat = new System.Windows.Forms.ComboBox();
			this.lblLowerLimit = new System.Windows.Forms.Label();
			this.txtLowerLimit = new System.Windows.Forms.TextBox();
			this.txtUpperLimit = new System.Windows.Forms.TextBox();
			this.lblUpperLimit = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.chartDistribution)).BeginInit();
			this.SuspendLayout();
			// 
			// chartDistribution
			// 
			chartArea1.Name = "ChartArea1";
			this.chartDistribution.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chartDistribution.Legends.Add(legend1);
			this.chartDistribution.Location = new System.Drawing.Point(12, 51);
			this.chartDistribution.Name = "chartDistribution";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chartDistribution.Series.Add(series1);
			this.chartDistribution.Size = new System.Drawing.Size(1700, 651);
			this.chartDistribution.TabIndex = 0;
			this.chartDistribution.Text = "chart1";
			// 
			// cbWeapon
			// 
			this.cbWeapon.FormattingEnabled = true;
			this.cbWeapon.Location = new System.Drawing.Point(13, 13);
			this.cbWeapon.Name = "cbWeapon";
			this.cbWeapon.Size = new System.Drawing.Size(159, 24);
			this.cbWeapon.TabIndex = 1;
			this.cbWeapon.SelectedIndexChanged += new System.EventHandler(this.cbWeapon_SelectedIndexChanged);
			// 
			// cbStat
			// 
			this.cbStat.FormattingEnabled = true;
			this.cbStat.Location = new System.Drawing.Point(178, 12);
			this.cbStat.Name = "cbStat";
			this.cbStat.Size = new System.Drawing.Size(159, 24);
			this.cbStat.TabIndex = 2;
			this.cbStat.SelectedIndexChanged += new System.EventHandler(this.cbStat_SelectedIndexChanged);
			// 
			// lblLowerLimit
			// 
			this.lblLowerLimit.AutoSize = true;
			this.lblLowerLimit.Location = new System.Drawing.Point(363, 15);
			this.lblLowerLimit.Name = "lblLowerLimit";
			this.lblLowerLimit.Size = new System.Drawing.Size(79, 17);
			this.lblLowerLimit.TabIndex = 3;
			this.lblLowerLimit.Text = "Lower Limit";
			// 
			// txtLowerLimit
			// 
			this.txtLowerLimit.Location = new System.Drawing.Point(448, 13);
			this.txtLowerLimit.Name = "txtLowerLimit";
			this.txtLowerLimit.Size = new System.Drawing.Size(100, 22);
			this.txtLowerLimit.TabIndex = 4;
			// 
			// txtUpperLimit
			// 
			this.txtUpperLimit.Location = new System.Drawing.Point(640, 12);
			this.txtUpperLimit.Name = "txtUpperLimit";
			this.txtUpperLimit.Size = new System.Drawing.Size(100, 22);
			this.txtUpperLimit.TabIndex = 6;
			// 
			// lblUpperLimit
			// 
			this.lblUpperLimit.AutoSize = true;
			this.lblUpperLimit.Location = new System.Drawing.Point(554, 15);
			this.lblUpperLimit.Name = "lblUpperLimit";
			this.lblUpperLimit.Size = new System.Drawing.Size(80, 17);
			this.lblUpperLimit.TabIndex = 5;
			this.lblUpperLimit.Text = "Upper Limit";
			// 
			// NormalDistributionVisualizer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1724, 714);
			this.Controls.Add(this.txtUpperLimit);
			this.Controls.Add(this.lblUpperLimit);
			this.Controls.Add(this.txtLowerLimit);
			this.Controls.Add(this.lblLowerLimit);
			this.Controls.Add(this.cbStat);
			this.Controls.Add(this.cbWeapon);
			this.Controls.Add(this.chartDistribution);
			this.Name = "NormalDistributionVisualizer";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.chartDistribution)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chartDistribution;
		private System.Windows.Forms.ComboBox cbWeapon;
		private System.Windows.Forms.ComboBox cbStat;
		private System.Windows.Forms.Label lblLowerLimit;
		private System.Windows.Forms.TextBox txtLowerLimit;
		private System.Windows.Forms.TextBox txtUpperLimit;
		private System.Windows.Forms.Label lblUpperLimit;
	}
}

