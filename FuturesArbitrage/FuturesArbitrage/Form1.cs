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

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			chart1.Series[0].Points.AddXY(x, 3 * Math.Sin(5 * x) + 5 * Math.Cos(3 * x));

			if (chart1.Series[0].Points.Count > 100)
				chart1.Series[0].Points.RemoveAt(0);

			chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
			chart1.ChartAreas[0].AxisX.Maximum = x;

			x += 0.1;
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
