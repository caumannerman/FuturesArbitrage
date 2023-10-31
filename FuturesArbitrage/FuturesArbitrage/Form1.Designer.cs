namespace FuturesArbitrage
{
	partial class Form1
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.button1 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
			this.SuspendLayout();
			// 
			// chart1
			// 
			chartArea9.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea9);
			legend9.Name = "Legend1";
			this.chart1.Legends.Add(legend9);
			this.chart1.Location = new System.Drawing.Point(70, 12);
			this.chart1.Name = "chart1";
			series9.ChartArea = "ChartArea1";
			series9.Legend = "Legend1";
			series9.Name = "Series1";
			this.chart1.Series.Add(series9);
			this.chart1.Size = new System.Drawing.Size(848, 533);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(38, 936);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(225, 98);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// chart2
			// 
			chartArea10.Name = "ChartArea1";
			this.chart2.ChartAreas.Add(chartArea10);
			legend10.Name = "Legend1";
			this.chart2.Legends.Add(legend10);
			this.chart2.Location = new System.Drawing.Point(1232, 22);
			this.chart2.Name = "chart2";
			series10.ChartArea = "ChartArea1";
			series10.Legend = "Legend1";
			series10.Name = "Series1";
			this.chart2.Series.Add(series10);
			this.chart2.Size = new System.Drawing.Size(950, 585);
			this.chart2.TabIndex = 2;
			this.chart2.Text = "chart2";
			// 
			// chart3
			// 
			chartArea11.Name = "ChartArea1";
			this.chart3.ChartAreas.Add(chartArea11);
			legend11.Name = "Legend1";
			this.chart3.Legends.Add(legend11);
			this.chart3.Location = new System.Drawing.Point(59, 540);
			this.chart3.Name = "chart3";
			series11.ChartArea = "ChartArea1";
			series11.Legend = "Legend1";
			series11.Name = "Series1";
			this.chart3.Series.Add(series11);
			this.chart3.Size = new System.Drawing.Size(1103, 390);
			this.chart3.TabIndex = 3;
			this.chart3.Text = "chart3";
			// 
			// chart4
			// 
			chartArea12.Name = "ChartArea1";
			this.chart4.ChartAreas.Add(chartArea12);
			legend12.Name = "Legend1";
			this.chart4.Legends.Add(legend12);
			this.chart4.Location = new System.Drawing.Point(1532, 591);
			this.chart4.Name = "chart4";
			series12.ChartArea = "ChartArea1";
			series12.Legend = "Legend1";
			series12.Name = "Series1";
			this.chart4.Series.Add(series12);
			this.chart4.Size = new System.Drawing.Size(895, 422);
			this.chart4.TabIndex = 4;
			this.chart4.Text = "chart4";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(315, 941);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(229, 93);
			this.button2.TabIndex = 5;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(620, 941);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(256, 93);
			this.button3.TabIndex = 6;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(946, 941);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(163, 93);
			this.button4.TabIndex = 7;
			this.button4.Text = "button4";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(2460, 1062);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.chart4);
			this.Controls.Add(this.chart3);
			this.Controls.Add(this.chart2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.chart1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
	}
}

