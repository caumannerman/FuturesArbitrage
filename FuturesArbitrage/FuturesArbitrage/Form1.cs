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
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.Security.Policy;

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
        private string sv_myMoney = "";
        private string sv_fee_stock_buy = "";
        private string sv_fee_stock_sell = "";
        private string sv_fee_futures = "";
        private string sv_stt_rate = "";
        private string sv_norisk_interest_rate = "";
        private string sv_borrow_interest_rate = "";
        private string sv_loan_interest_rate = "";
        private string sv_formula = "";
        private string sv_filePath = "";
        private BookValue bv = new BookValue();

        //엑셀에서 가져와야하는 것 : 주식 현재가, 만기일까지 남은 일수, 선물 현재가  ( 가격, 수량 )
        
        //현재가, 남은 일 수까지 활용해서 이론가격 가져옴. 
        // 이론가격보다 하나 높은 틱에 선물 매수, 매도 대고있다고 가정.

        // 매 순간 그 가격에 선물이 매수 혹은 매도될 때, 헷지할 수 있는 현물 가격과 수량을 계속 반복체크
        // 


        public Form1()
		{
			InitializeComponent();

            // SettingsForm에서 입력받은 정보 static 변수를 잘 불러왔는지 확인
            sv_myMoney = SettingForm.sv_myMoney;
            sv_fee_stock_buy = SettingForm.sv_fee_stock_buy;
            sv_fee_stock_sell = SettingForm.sv_fee_stock_sell;
            sv_fee_futures = SettingForm.sv_fee_futures;
            sv_stt_rate = SettingForm.sv_stt_rate;
            sv_norisk_interest_rate = SettingForm.sv_norisk_interest_rate;
            sv_borrow_interest_rate = SettingForm.sv_borrow_interest_rate;
            sv_loan_interest_rate = SettingForm.sv_loan_interest_rate;
            sv_formula = SettingForm.sv_formula;
            sv_filePath = SettingForm.sv_filePath;
            System.Console.WriteLine("Form1으로 넘어와서 filePath 전달 확인");
            System.Console.WriteLine(sv_myMoney);
            System.Console.WriteLine(sv_fee_stock_buy);
            System.Console.WriteLine(sv_fee_stock_sell);
            System.Console.WriteLine(sv_fee_futures);
            System.Console.WriteLine(sv_stt_rate);
            System.Console.WriteLine(sv_norisk_interest_rate);
            System.Console.WriteLine(sv_borrow_interest_rate);
            System.Console.WriteLine(sv_loan_interest_rate);
            System.Console.WriteLine(sv_formula);
            System.Console.WriteLine(sv_filePath);

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
            
           /* Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = application.Workbooks.Open(Filename: @sv_filePath);
            Worksheet worksheet1 = workbook.Worksheets.get_Item(1);
            application.Visible = false;
            Range range = worksheet1.UsedRange;
            //Form 멤버로 있는 mydata에 저장
            mydata = range.Value;*/

        }

        private void timer1_Tick(object sender, EventArgs e)
		{
			
			string URL = "http://127.0.0.1:5000/total";

            /*WebClient webClient = new WebClient();
            var json = new WebClient().DownloadString(URL);

            Console.WriteLine(json.ToString());*/

			using (WebClient wc = new WebClient())
			{
				var json = new WebClient().DownloadString(URL);
				Console.WriteLine(json.ToString());
			}

			/*
						HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
						request.Method = "GET";
						request.ContentType = "application/json";
						request.Timeout = 30* 1000;*/





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
