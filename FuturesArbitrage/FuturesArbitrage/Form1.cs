﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace FuturesArbitrage
{
	public partial class Form1 : Form
	{

		double x;
		double x2;
		int x2idx;

        double x3;
        int x3idx = 2;

        // excel 에서 받아온 데이터 저장할 배열
        int[] numbers = new int[1000];
		int[] futures = new int[1000];

        object[,] mydata;

        //private string filePath = "C:\\Users\\USER\\Desktop\\test.xlsx";
        private string filePath = "";

        public Form1()
		{
			InitializeComponent();
            filePath = SettingForm.filePath;
            System.Console.WriteLine("Form1으로 넘어와서 filePath 전달 확인");
            System.Console.WriteLine(filePath);

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

            chart3.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart3.Series[0].Color = Color.Red;

            chart3.Series.Add("Futures");
            chart3.Series["Futures"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart3.Series["Futures"].Color = Color.Blue;

            //numbers 초기화
            for (int i = 0; i < 1000; i++)
            {
				numbers[i] = i + 10;
				futures[i] = 1100 - i;
            }
            
            Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = application.Workbooks.Open(Filename: @filePath);
            Worksheet worksheet1 = workbook.Worksheets.get_Item(1);
            application.Visible = false;
            Range range = worksheet1.UsedRange;
            //Form 멤버로 있는 mydata에 저장
            mydata = range.Value;

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
            if (numbers[x2idx] > futures[x2idx])
            {
                showAlert("");
            }

            if (chart2.Series[0].Points.Count > 1000)
			{
                chart2.Series[0].Points.RemoveAt(0);
				chart2.Series["Futures"].Points.RemoveAt(0);

            }

            //chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = 100;
			chart2.ChartAreas[0].AxisY.Minimum = 0;
			chart2.ChartAreas[0].AxisY.Maximum = 3000;

            x2idx++;// 다음인덱스 가리켜야하므로
			x2 += 0.1; //그래프 상 오른쪽에 그려야하므로

            //chart3 엑셀데이터 뿌리기
            System.Console.WriteLine("출력하는중-------------------------------------------");
            System.Console.WriteLine(x3idx);
            System.Console.WriteLine(mydata[x3idx, 3]);
            System.Console.WriteLine(mydata[x3idx, 3].GetType().Name);
            System.Console.WriteLine();
            chart3.Series[0].Points.AddXY(x3, mydata[x3idx,2]);
            double temp =  Convert.ToDouble(( (double)mydata[x3idx, 3] + 10000.0).ToString());
            chart3.Series["Futures"].Points.AddXY(x3, temp);
            if ( (double)mydata[x3idx, 2] > (double)mydata[x3idx, 3])
            {
                showAlert("");
            }

            if (chart3.Series[0].Points.Count > 1000)
            {
                chart3.Series[0].Points.RemoveAt(0);
                chart3.Series["Futures"].Points.RemoveAt(0);
            }

            //chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
            chart3.ChartAreas[0].AxisX.Minimum = 0;
            chart3.ChartAreas[0].AxisX.Maximum = 100;
            chart3.ChartAreas[0].AxisY.Minimum = 0;
            chart3.ChartAreas[0].AxisY.Maximum = 80000;

            x3idx++;// 다음인덱스 가리켜야하므로
            x3 += 0.1; //그래프 상 오른쪽에 그려야하므로

        }

		private void read_excel_data()
		{
            if (filePath != "")
            {
                System.Console.WriteLine("들어옴");

                Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                Workbook workbook = application.Workbooks.Open(Filename: @filePath);
                Worksheet worksheet1 = workbook.Worksheets.get_Item(1);
                application.Visible = false;
                Range range = worksheet1.UsedRange;
                /*
                                Range startRange = worksheet1.Cells[3, 0];
                                Range endRange = worksheet1.Cells[10, 10];
                                Range range = worksheet1.get_Range(startRange, endRange);*/
                object[,] rawData = range.Value;

                for (int i = 1; i <= rawData.GetLength(1); i++)
                {
                    for (int j = 1; j <= rawData.GetLength(0); ++j)
                    {
                        numbers[i] = (int)rawData[j, i];
                        //System.Console.Write(rawData[i, j]);
                    }
                    System.Console.WriteLine();
                }

                String data = "";

                for (int i = 1; i <= rawData.GetLength(0); ++i)
                {
                    for (int j = 1; j <= rawData.GetLength(1); ++j)
                    {
                        if (rawData[i, j] == null) continue;
                        data += (rawData[i, j].ToString() + " ");
                        //data += ((range.Cells[i, j] as Range).Value2.ToString() + " ");
                    }
                    data += "\n";
                }


                richTextBox2.Text = data;

                /* DeleteObject(worksheet1);
                 DeleteObject(workbook);
                 application.Quit();
                 DeleteObject(application);*/
            }
            else
            {
                System.Console.WriteLine("들어오지 못함");
            }
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

        private void showAlert(string msg)
        {
            //msg출력해주는 것으로 바꿔야함

            this.Alert("Test MEssage");
        }
		private void button2_Click(object sender, EventArgs e)
		{
            showAlert("");
			///this.Alert("Test MEssage");
		}

		private void button3_Click(object sender, EventArgs e)
		{
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Clear();
                richTextBox1.Text = OFD.FileName;
                filePath = OFD.FileName;
            }
        }

		private void button4_Click(object sender, EventArgs e)
		{
            if (filePath != "")
            {
				System.Console.WriteLine("들어옴");
				
                Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                Workbook workbook = application.Workbooks.Open(Filename: @filePath);
                Worksheet worksheet1 = workbook.Worksheets.get_Item(1);
                application.Visible = false;
				Range range = worksheet1.UsedRange;
/*
				Range startRange = worksheet1.Cells[3, 0];
				Range endRange = worksheet1.Cells[10, 10];
				Range range = worksheet1.get_Range(startRange, endRange);*/
				object[,] rawData = range.Value;

				for(int i=1; i<= rawData.GetLength(1); i++)
				{
					for(int j=1; j <= rawData.GetLength(0); ++j)
					{
						numbers[i] = (int)rawData[j, i];
						System.Console.Write(rawData[i, j]);
					}System.Console.WriteLine();
				}

                String data = "";

                for (int i = 1; i <= rawData.GetLength(0); ++i)
                {
                    for (int j = 1; j <= rawData.GetLength(1); ++j)
                    {
						if (rawData[i, j] == null) continue;
						data += (rawData[i, j].ToString() + " ");
                        //data += ((range.Cells[i, j] as Range).Value2.ToString() + " ");
                    }
                    data += "\n";
                }


                richTextBox2.Text = data;

               /* DeleteObject(worksheet1);
                DeleteObject(workbook);
                application.Quit();
                DeleteObject(application);*/
            }
			else
			{
                System.Console.WriteLine("들어오지 못함");
            }
        }

        private void DeleteObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("메모리 할당을 해제하는 중 문제가 발생하였습니다." + ex.ToString(), "경고!");
            }
            finally
            {
                GC.Collect();
            }
        }

      
    }
}
