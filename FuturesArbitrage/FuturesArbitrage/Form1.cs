using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FuturesArbitrage
{
	public partial class Form1 : Form
	{

		double x;
		double x2;
		int x2idx;
		// excel 에서 받아온 데이터 저장할 배열
		int[] numbers = new int[1000];
		int[] futures = new int[1000];
		
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			button1.Text = "Start";
			timer1.Tick += timer1_Tick;
			timer1.Interval = 50;

			chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart2.Series[0].Color = Color.Red;

			chart2.Series.Add("Futures");
            chart2.Series["Futures"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart2.Series["Futures"].Color = Color.Blue;
            //numbers 초기화
            for (int i = 0; i < 1000; i++)
            {
				numbers[i] = i + 10;
				futures[i] = 1100 - i;
            }
        }

		private void timer1_Tick(object sender, EventArgs e)
		{
			//chart1관련
			chart1.Series[0].Points.AddXY(x, 3 * Math.Sin(5 * x) + 5 * Math.Cos(3 * x));

			if (chart1.Series[0].Points.Count > 100)
				chart1.Series[0].Points.RemoveAt(0);

			chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
			chart1.ChartAreas[0].AxisX.Maximum = x;

			x += 0.1;

			//chart2 엑셀데이터 뿌리기
			chart2.Series[0].Points.AddXY(x2, numbers[x2idx]);
			chart2.Series["Futures"].Points.AddXY(x2, futures[x2idx]);

			if (chart2.Series[0].Points.Count > 100)
			{
                chart2.Series[0].Points.RemoveAt(0);
				chart2.Series["Futures"].Points.RemoveAt(0);

            }
				
			chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
			chart2.ChartAreas[0].AxisX.Maximum = x2;
			chart2.ChartAreas[0].AxisY.Minimum = 0;
			chart2.ChartAreas[0].AxisY.Maximum = 3000;

            x2idx++;// 다음인덱스 가리켜야하므로
			x2 += 0.1; //그래프 상 오른쪽에 그려야하므로

        }

		private void button1_Click(object sender, EventArgs e)
		{
			if (timer1.Enabled)
			{
				timer1.Stop();
				button1.Text = "Start";
			}

			else
			{
				timer1.Start();
				button1.Text = "Stop";
			}
		}

		public void Alert(string msg)
		{
			ShowAlert frm = new ShowAlert();
			frm.showAlert(msg);
		}
		private void button2_Click(object sender, EventArgs e)
		{
			
			this.Alert("Test MEssage");
		}

		private void button3_Click(object sender, EventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{

		}
	}
}
