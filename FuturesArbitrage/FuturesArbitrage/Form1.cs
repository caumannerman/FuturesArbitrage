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
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Windows.Forms.DataVisualization.Charting;

namespace FuturesArbitrage
{
	public partial class Form1 : Form
	{

		double x1, x2, x3, x4, x5, x6;
		
        // excel 에서 받아온 데이터 저장할 배열
        int[] numbers = new int[1000];
		int[] futures = new int[1000];

        //private string filePath = "C:\\Users\\USER\\Desktop\\test.xlsx";
        private string sv_myMoney = "";
        private string sv_fee_stock_buy = "";
        private string sv_fee_stock_sell = "";
        private string sv_fee_futures = "";
        private string sv_stt_rate = "";
        private string sv_norisk_interest_rate = "";
        private string sv_borrow_interest_rate = "";
        private string sv_loan_interest_rate = "";
        private string sv_enddate = "";
        private string sv_filePath = "";

		int k = 0;
		double r_lending = 1.04;
		double r_borrow = 1.06;
		int T = 6;

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
			sv_enddate = SettingForm.sv_enddate;
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
            System.Console.WriteLine(sv_enddate);
            System.Console.WriteLine(sv_filePath);

			r_borrow = Double.Parse( sv_borrow_interest_rate);
			r_lending = Double.Parse(sv_loan_interest_rate);
			T = int.Parse(sv_enddate);



		}

        private void Form1_Load(object sender, EventArgs e)
		{
			button1.Text = "Start";
			timer1.Tick += timer1_Tick;
			timer1.Interval = 50;

			chart1.Series.Clear();
			chart2.Series.Clear();
			chart3.Series.Clear();
			chart4.Series.Clear();
			chart5.Series.Clear();
			chart6.Series.Clear();

			chart1.Series.Add("선물매수1호가");
			chart1.Series["선물매수1호가"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart1.Series["선물매수1호가"].Color = Color.SkyBlue;
		

			// 선물 매도 1호가 (내가매수) -> 매도차익거래
			chart1.Series.Add("선물매도1호가");
			chart1.Series["선물매도1호가"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart1.Series["선물매도1호가"].Color = Color.DarkBlue;
			

			chart1.Series.Add("매수차익 하한(이론가)");
			chart1.Series["매수차익 하한(이론가)"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart1.Series["매수차익 하한(이론가)"].Color = Color.Red;
			

			chart1.Series.Add("매도차익 상한(이론가)");
			chart1.Series["매도차익 상한(이론가)"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart1.Series["매도차익 상한(이론가)"].Color = Color.Orange;


			chart2.Series.Add("선물매수1호가");
			chart2.Series["선물매수1호가"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart2.Series["선물매수1호가"].Color = Color.SkyBlue;

			chart2.Series.Add("선물매도1호가");
			chart2.Series["선물매도1호가"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart2.Series["선물매도1호가"].Color = Color.DarkBlue;

			chart2.Series.Add("매수차익 하한(이론가)");
			chart2.Series["매수차익 하한(이론가)"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart2.Series["매수차익 하한(이론가)"].Color = Color.Red;

			chart2.Series.Add("매도차익 상한(이론가)");
			chart2.Series["매도차익 상한(이론가)"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart2.Series["매도차익 상한(이론가)"].Color = Color.Orange;


			// 여기서부터 
			// 얘가 선물 매수 1호가 (나는 매수) -> 매수차익거래
			chart3.Series.Add("선물매수1호가");
			chart3.Series["선물매수1호가"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart3.Series["선물매수1호가"].Color = Color.SkyBlue;

			// 선물 매도 1호가 (내가매수) -> 매도차익거래
			chart3.Series.Add("선물매도1호가");
			chart3.Series["선물매도1호가"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart3.Series["선물매도1호가"].Color = Color.DarkBlue;

			chart3.Series.Add("매수차익 하한(이론가)");
            chart3.Series["매수차익 하한(이론가)"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart3.Series["매수차익 하한(이론가)"].Color = Color.Red;

			chart3.Series.Add("매도차익 상한(이론가)");
			chart3.Series["매도차익 상한(이론가)"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart3.Series["매도차익 상한(이론가)"].Color = Color.Orange;

			// 여기서부터 
			// 얘가 선물 매수 1호가 (나는 매수) -> 매수차익거래
			chart4.Series.Add("선물매수1호가");
			chart4.Series["선물매수1호가"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart4.Series["선물매수1호가"].Color = Color.SkyBlue;

			// 선물 매도 1호가 (내가매수) -> 매도차익거래
			chart4.Series.Add("선물매도1호가");
			chart4.Series["선물매도1호가"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart4.Series["선물매도1호가"].Color = Color.DarkBlue;

			chart4.Series.Add("매수차익 하한(이론가)");
			chart4.Series["매수차익 하한(이론가)"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart4.Series["매수차익 하한(이론가)"].Color = Color.Red;

			chart4.Series.Add("매도차익 상한(이론가)");
			chart4.Series["매도차익 상한(이론가)"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart4.Series["매도차익 상한(이론가)"].Color = Color.Orange;

			// 여기서부터 
			// 얘가 선물 매수 1호가 (나는 매수) -> 매수차익거래
			chart5.Series.Add("선물매수1호가");
			chart5.Series["선물매수1호가"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart5.Series["선물매수1호가"].Color = Color.SkyBlue;

			// 선물 매도 1호가 (내가매수) -> 매도차익거래
			chart5.Series.Add("선물매도1호가");
			chart5.Series["선물매도1호가"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart5.Series["선물매도1호가"].Color = Color.DarkBlue;

			chart5.Series.Add("매수차익 하한(이론가)");
			chart5.Series["매수차익 하한(이론가)"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart5.Series["매수차익 하한(이론가)"].Color = Color.Red;

			chart5.Series.Add("매도차익 상한(이론가)");
			chart5.Series["매도차익 상한(이론가)"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart5.Series["매도차익 상한(이론가)"].Color = Color.Orange;

			// 여기서부터 
			// 얘가 선물 매수 1호가 (나는 매수) -> 매수차익거래
			chart6.Series.Add("선물매수1호가");
			chart6.Series["선물매수1호가"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart6.Series["선물매수1호가"].Color = Color.SkyBlue;

			// 선물 매도 1호가 (내가매수) -> 매도차익거래
			chart6.Series.Add("선물매도1호가");
			chart6.Series["선물매도1호가"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart6.Series["선물매도1호가"].Color = Color.DarkBlue;

			chart6.Series.Add("매수차익 하한(이론가)");
			chart6.Series["매수차익 하한(이론가)"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart6.Series["매수차익 하한(이론가)"].Color = Color.Red;

			chart6.Series.Add("매도차익 상한(이론가)");
			chart6.Series["매도차익 상한(이론가)"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart6.Series["매도차익 상한(이론가)"].Color = Color.Orange;

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
		//KT
        async void test1(double r_lending, double r_borrow, int T)
        {
			try
			{

              
                
				//주식 매수매도 호가
				string URL = "https://openapi.koreainvestment.com:9443/uapi/domestic-stock/v1/quotations/inquire-asking-price-exp-ccn?FID_COND_MRKT_DIV_CODE=J&FID_INPUT_ISCD=030200";
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJ0b2tlbiIsImF1ZCI6ImIyMTkzNTlkLTg1ZjAtNDRiOS1hMjljLWYwYTI5YjY3N2ZhNiIsImlzcyI6InVub2d3IiwiZXhwIjoxNjk5MDEyMDgzLCJpYXQiOjE2OTg5MjU2ODMsImp0aSI6IlBTYnJpOVQyOThWeXhmSjAwNHg5TW5DUW54N2dLSlI4djY1OCJ9.881135Prt70_bn7VTGUTK75DYNONuho5uQjzm3nGAD50Bnc5ZMumrrcr_Br-oDXn66AizD7tWFNffqbFbXdCXA");
				request.Headers.Add("appkey", "PSbri9T298VyxfJ004x9MnCQnx7gKJR8v658");
				request.Headers.Add("appsecret", "VUn2CzaKPT1oTzwfBiXlY2ASg8SEndHMk/h5ukdZOElQVP5dfnfnv3OiTqw3aKYGR1NRYg17q05zOFlFhW8CdwYzMPI2wmqB9cNgx2f03O1ROveEw6Kr/CeGojxZBPMVU2MMzun4Gapcq1zu+lWYhbkDK/fAfmeCD+ftD2WMWPrJw9UBG0c=");
				request.Headers.Add("tr_id", "FHKST01010200");
				HttpWebResponse response_s = (HttpWebResponse)request.GetResponse();

				Stream stream_s = response_s.GetResponseStream();
				StreamReader reader_s = new StreamReader(stream_s, Encoding.UTF8);
				string text_s = reader_s.ReadToEnd();
				JObject obj_s = JObject.Parse(text_s);


				//선물 매수매도 호가
				string URL2 = "https://openapi.koreainvestment.com:9443/uapi/domestic-futureoption/v1/quotations/inquire-asking-price?FID_COND_MRKT_DIV_CODE=JF&FID_INPUT_ISCD=114T11000";
				HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(URL2);
				request2.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJ0b2tlbiIsImF1ZCI6ImIyMTkzNTlkLTg1ZjAtNDRiOS1hMjljLWYwYTI5YjY3N2ZhNiIsImlzcyI6InVub2d3IiwiZXhwIjoxNjk5MDEyMDgzLCJpYXQiOjE2OTg5MjU2ODMsImp0aSI6IlBTYnJpOVQyOThWeXhmSjAwNHg5TW5DUW54N2dLSlI4djY1OCJ9.881135Prt70_bn7VTGUTK75DYNONuho5uQjzm3nGAD50Bnc5ZMumrrcr_Br-oDXn66AizD7tWFNffqbFbXdCXA");
				request2.Headers.Add("appkey", "PSbri9T298VyxfJ004x9MnCQnx7gKJR8v658");
				request2.Headers.Add("appsecret", "VUn2CzaKPT1oTzwfBiXlY2ASg8SEndHMk/h5ukdZOElQVP5dfnfnv3OiTqw3aKYGR1NRYg17q05zOFlFhW8CdwYzMPI2wmqB9cNgx2f03O1ROveEw6Kr/CeGojxZBPMVU2MMzun4Gapcq1zu+lWYhbkDK/fAfmeCD+ftD2WMWPrJw9UBG0c=");
				request2.Headers.Add("tr_id", "FHMIF10010000");
				HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();

				Stream stream_f = response2.GetResponseStream();
				StreamReader reader_f = new StreamReader(stream_f, Encoding.UTF8);
				string text_f = reader_f.ReadToEnd();
				JObject obj_f = JObject.Parse(text_f);

                //string notice = obj["output1"]["askp1"].ToString();
                //Console.WriteLine(((int) obj["output1"]["askp1"]).GetType().Name);
                //Console.WriteLine((int)obj["output1"]["askp1"]);

               

				//선물 매수호가1~5
				int[] futs_bidp = { (int)obj_f["output2"]["futs_bidp1"], (int)obj_f["output2"]["futs_bidp2"] , (int)obj_f["output2"]["futs_bidp3"] ,
				(int)obj_f["output2"]["futs_bidp4"], (int)obj_f["output2"]["futs_bidp5"] };
				//선물 매수호가잔량 1~5
				int[] futs_bidp_rsqn = { (int)obj_f["output2"]["bidp_rsqn1"], (int)obj_f["output2"]["bidp_rsqn2"] , (int)obj_f["output2"]["bidp_rsqn3"],
				(int)obj_f["output2"]["bidp_rsqn4"] ,(int)obj_f["output2"]["bidp_rsqn5"] };
                // 현물 매도호가1~10
                int[] stock_askp = { (int)obj_s["output1"]["askp1"], (int)obj_s["output1"]["askp2"], (int)obj_s["output1"]["askp3"],
				(int)obj_s["output1"]["askp4"], (int)obj_s["output1"]["askp5"], (int)obj_s["output1"]["askp6"], (int)obj_s["output1"]["askp7"],
				(int)obj_s["output1"]["askp8"], (int)obj_s["output1"]["askp9"], (int)obj_s["output1"]["askp10"]};
				// 현물 매도호가잔량1~10
				int[] stock_askp_rsqn = { (int)obj_s["output1"]["askp_rsqn1"], (int)obj_s["output1"]["askp_rsqn2"], (int)obj_s["output1"]["askp_rsqn3"],
				(int)obj_s["output1"]["askp_rsqn4"], (int)obj_s["output1"]["askp_rsqn5"], (int)obj_s["output1"]["askp_rsqn6"], (int)obj_s["output1"]["askp_rsqn7"],
				(int)obj_s["output1"]["askp_rsqn8"], (int)obj_s["output1"]["askp_rsqn9"], (int)obj_s["output1"]["askp_rsqn10"]};

				//매도호가, 잔량으로 10주 살 때 평단을 S라 할 것임.
				double S_buyingArbitrage = 0;
                int count = 0;
                for(int i = 0; i < 10; i++)
                {
                    if (count < 10)
                    {
                        count += stock_askp_rsqn[i];

						if (count <= 10)
                        {
                            S_buyingArbitrage += stock_askp[i] * stock_askp_rsqn[i];
						}
                        else
                        {
                            S_buyingArbitrage += stock_askp[i] * (10 - count + stock_askp_rsqn[i]);
                            break;
						}
                    }
                    else
                    {
                        break;
                    }
                }
                //평단 완성
                S_buyingArbitrage /= 10;

                //현물 매수 평단을 S로 하여 선물이론가격 도출
                double book_value = (S_buyingArbitrage + 2 * k) * (1 + r_borrow * (T / 365));
                //이론가격보다 선물매수호가중 가장 높은 것 ( 선물매도할 때 받을 수 있는 최대가격 )이 이론가격보다 크면 매수차익거래 가능
	            if (book_value < futs_bidp[0])
                {
                    System.Console.WriteLine("매수차익거래 기회 나옴!!!!!!!!!!!!!!!");
					System.Console.WriteLine(futs_bidp[0] - book_value);
				}
				System.Console.WriteLine("매수차익거래 기회 나옴을 나옴!!!!!!!!!!!!!!!");

				//얼마의 차익을 얻을 수 있는지 보냄

				////////////////////////////////// 매도차익거래  ///////////////////////////////
				//선물 매도호가1~5
				int[] futs_askp = { (int)obj_f["output2"]["futs_askp1"], (int)obj_f["output2"]["futs_askp2"] , (int)obj_f["output2"]["futs_askp3"] ,
				(int)obj_f["output2"]["futs_askp4"], (int)obj_f["output2"]["futs_askp5"] };
				//선물 매도호가잔량 1~5
				int[] futs_askp_rsqn = { (int)obj_f["output2"]["askp_rsqn1"], (int)obj_f["output2"]["askp_rsqn2"] , (int)obj_f["output2"]["askp_rsqn3"],
				(int)obj_f["output2"]["askp_rsqn4"] ,(int)obj_f["output2"]["askp_rsqn5"] };
				// 현물 매수호가1~10
				int[] stock_bidp = { (int)obj_s["output1"]["bidp1"], (int)obj_s["output1"]["bidp2"], (int)obj_s["output1"]["bidp3"],
				(int)obj_s["output1"]["bidp4"], (int)obj_s["output1"]["bidp5"], (int)obj_s["output1"]["bidp6"], (int)obj_s["output1"]["bidp7"],
				(int)obj_s["output1"]["bidp8"], (int)obj_s["output1"]["bidp9"], (int)obj_s["output1"]["bidp10"]};
				// 현물 매수호가잔량1~10
				int[] stock_bidp_rsqn = { (int)obj_s["output1"]["bidp_rsqn1"], (int)obj_s["output1"]["bidp_rsqn2"], (int)obj_s["output1"]["bidp_rsqn3"],
				(int)obj_s["output1"]["bidp_rsqn4"], (int)obj_s["output1"]["bidp_rsqn5"], (int)obj_s["output1"]["bidp_rsqn6"], (int)obj_s["output1"]["bidp_rsqn7"],
				(int)obj_s["output1"]["bidp_rsqn8"], (int)obj_s["output1"]["bidp_rsqn9"], (int)obj_s["output1"]["bidp_rsqn10"]};

				//매수호가, 잔량으로 10주 팔 때 평단을 S라 할 것임.
				double S_sellingArbitrage = 0;
				int count2 = 0;
				for (int i = 0; i < 10; i++)
				{
					if (count2 < 10)
					{
						count2 += stock_bidp_rsqn[i];

						if (count <= 10)
						{
							S_sellingArbitrage += stock_bidp[i] * stock_bidp_rsqn[i];
						}
						else
						{
							S_sellingArbitrage += stock_bidp[i] * (10 - count2 + stock_bidp_rsqn[i]);
							break;
						}
					}
					else
					{
						break;
					}
				}
				//평단 완성
				S_sellingArbitrage /= 10;

				//현물 매도 평단을 S로 하여 선물이론가격 도출
				double book_value2 = (S_sellingArbitrage + 2 * k) * (1 + r_lending * (T / 365));
				//이론가격보다 선물매수호가중 가장 높은 것 ( 선물매도할 때 받을 수 있는 최대가격 )이 이론가격보다 크면 매수차익거래 가능
				if (book_value2 > futs_askp[0])
				{
					System.Console.WriteLine("매도차익거래 기회 나옴!!!!!!!!!!!!!!!");
					System.Console.WriteLine(book_value2 - futs_askp[0]);
				}
				System.Console.WriteLine("매도차익거래 기회 나옴을 나옴!!!!!!!!!!!!!!!");

				//얼마의 차익을 얻을 수 있는지 보냄


				//chart3 
				// 매수차익거래 선물 이론가격
				chart1.Series["선물매수1호가"].Points.AddXY(x1, futs_bidp[0]);

				chart1.Series["선물매도1호가"].Points.AddXY(x1, futs_askp[0]);

				// 매수차익거래 선물 매수1호가 ( 내가 매도할 가격 )
				chart1.Series["매수차익 하한(이론가)"].Points.AddXY(x1, book_value );
				chart1.Series["매도차익 상한(이론가)"].Points.AddXY(x1, book_value2 );

				//매수차익거래 가능!!!
				if (futs_bidp[0] > book_value)
				{
					//showAlert("매수차익거래 가능");
				}
				//매도차익거래 가능!!
				if (futs_askp[0] < book_value2)
				{
					//showAlert("매도차익거래 가능");
				}

				
				


				if (chart1.Series["선물매수1호가"].Points.Count > 500)
				{
					chart1.Series["선물매수1호가"].Points.RemoveAt(0);
					chart1.Series["선물매도1호가"].Points.RemoveAt(0);
					chart1.Series["매수차익 하한(이론가)"].Points.RemoveAt(0);
					chart1.Series["매도차익 상한(이론가)"].Points.RemoveAt(0);

				}

				//chart2.ChartAreas[0].AxisX.Minimum = chart2.Series["선물매수1호가"].Points[0].XValue;
				chart1.ChartAreas[0].AxisX.Minimum = chart1.Series["선물매수1호가"].Points[0].XValue;
				chart1.ChartAreas[0].AxisX.Maximum = 50;
				chart1.ChartAreas[0].AxisY.Minimum = Math.Min(Math.Min(Math.Min(book_value, book_value2), futs_bidp[0]), futs_askp[0]) - 10000;
				chart1.ChartAreas[0].AxisY.Maximum = Math.Max(Math.Max(Math.Max(book_value, book_value2), futs_bidp[0]), futs_askp[0]) + 10000;

				x1 += 0.1; //그래프 상 오른쪽에 그려야하므로


			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"ex.Message={ex.Message}");
				Console.WriteLine($"ex.InnerException.Message = {ex.InnerException.Message}");

				Console.WriteLine($"----------- 서버에 연결할수없습니다 ---------------------");
			}
			catch (Exception ex2)
			{
				Console.WriteLine($"Exception={ex2.Message}");
			}
		}
		//SK텔레콤
		async void test2(double r_lending, double r_borrow, int T)
		{
			try
			{


				//주식 매수매도 호가
				string URL = "https://openapi.koreainvestment.com:9443/uapi/domestic-stock/v1/quotations/inquire-asking-price-exp-ccn?FID_COND_MRKT_DIV_CODE=J&FID_INPUT_ISCD=017670";
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
				request.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJ0b2tlbiIsImF1ZCI6ImIyMTkzNTlkLTg1ZjAtNDRiOS1hMjljLWYwYTI5YjY3N2ZhNiIsImlzcyI6InVub2d3IiwiZXhwIjoxNjk5MDEyMDgzLCJpYXQiOjE2OTg5MjU2ODMsImp0aSI6IlBTYnJpOVQyOThWeXhmSjAwNHg5TW5DUW54N2dLSlI4djY1OCJ9.881135Prt70_bn7VTGUTK75DYNONuho5uQjzm3nGAD50Bnc5ZMumrrcr_Br-oDXn66AizD7tWFNffqbFbXdCXA");
				request.Headers.Add("appkey", "PSbri9T298VyxfJ004x9MnCQnx7gKJR8v658");
				request.Headers.Add("appsecret", "VUn2CzaKPT1oTzwfBiXlY2ASg8SEndHMk/h5ukdZOElQVP5dfnfnv3OiTqw3aKYGR1NRYg17q05zOFlFhW8CdwYzMPI2wmqB9cNgx2f03O1ROveEw6Kr/CeGojxZBPMVU2MMzun4Gapcq1zu+lWYhbkDK/fAfmeCD+ftD2WMWPrJw9UBG0c=");
				request.Headers.Add("tr_id", "FHKST01010200");
				HttpWebResponse response_s = (HttpWebResponse)request.GetResponse();

				Stream stream_s = response_s.GetResponseStream();
				StreamReader reader_s = new StreamReader(stream_s, Encoding.UTF8);
				string text_s = reader_s.ReadToEnd();
				JObject obj_s = JObject.Parse(text_s);


				//선물 매수매도 호가
				string URL2 = "https://openapi.koreainvestment.com:9443/uapi/domestic-futureoption/v1/quotations/inquire-asking-price?FID_COND_MRKT_DIV_CODE=JF&FID_INPUT_ISCD=112T11000";
				HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(URL2);
				request2.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJ0b2tlbiIsImF1ZCI6ImIyMTkzNTlkLTg1ZjAtNDRiOS1hMjljLWYwYTI5YjY3N2ZhNiIsImlzcyI6InVub2d3IiwiZXhwIjoxNjk5MDEyMDgzLCJpYXQiOjE2OTg5MjU2ODMsImp0aSI6IlBTYnJpOVQyOThWeXhmSjAwNHg5TW5DUW54N2dLSlI4djY1OCJ9.881135Prt70_bn7VTGUTK75DYNONuho5uQjzm3nGAD50Bnc5ZMumrrcr_Br-oDXn66AizD7tWFNffqbFbXdCXA");
				request2.Headers.Add("appkey", "PSbri9T298VyxfJ004x9MnCQnx7gKJR8v658");
				request2.Headers.Add("appsecret", "VUn2CzaKPT1oTzwfBiXlY2ASg8SEndHMk/h5ukdZOElQVP5dfnfnv3OiTqw3aKYGR1NRYg17q05zOFlFhW8CdwYzMPI2wmqB9cNgx2f03O1ROveEw6Kr/CeGojxZBPMVU2MMzun4Gapcq1zu+lWYhbkDK/fAfmeCD+ftD2WMWPrJw9UBG0c=");
				request2.Headers.Add("tr_id", "FHMIF10010000");
				HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();

				Stream stream_f = response2.GetResponseStream();
				StreamReader reader_f = new StreamReader(stream_f, Encoding.UTF8);
				string text_f = reader_f.ReadToEnd();
				JObject obj_f = JObject.Parse(text_f);

				//string notice = obj["output1"]["askp1"].ToString();
				//Console.WriteLine(((int) obj["output1"]["askp1"]).GetType().Name);
				//Console.WriteLine((int)obj["output1"]["askp1"]);



				//선물 매수호가1~5
				int[] futs_bidp = { (int)obj_f["output2"]["futs_bidp1"], (int)obj_f["output2"]["futs_bidp2"] , (int)obj_f["output2"]["futs_bidp3"] ,
				(int)obj_f["output2"]["futs_bidp4"], (int)obj_f["output2"]["futs_bidp5"] };
				//선물 매수호가잔량 1~5
				int[] futs_bidp_rsqn = { (int)obj_f["output2"]["bidp_rsqn1"], (int)obj_f["output2"]["bidp_rsqn2"] , (int)obj_f["output2"]["bidp_rsqn3"],
				(int)obj_f["output2"]["bidp_rsqn4"] ,(int)obj_f["output2"]["bidp_rsqn5"] };
				// 현물 매도호가1~10
				int[] stock_askp = { (int)obj_s["output1"]["askp1"], (int)obj_s["output1"]["askp2"], (int)obj_s["output1"]["askp3"],
				(int)obj_s["output1"]["askp4"], (int)obj_s["output1"]["askp5"], (int)obj_s["output1"]["askp6"], (int)obj_s["output1"]["askp7"],
				(int)obj_s["output1"]["askp8"], (int)obj_s["output1"]["askp9"], (int)obj_s["output1"]["askp10"]};
				// 현물 매도호가잔량1~10
				int[] stock_askp_rsqn = { (int)obj_s["output1"]["askp_rsqn1"], (int)obj_s["output1"]["askp_rsqn2"], (int)obj_s["output1"]["askp_rsqn3"],
				(int)obj_s["output1"]["askp_rsqn4"], (int)obj_s["output1"]["askp_rsqn5"], (int)obj_s["output1"]["askp_rsqn6"], (int)obj_s["output1"]["askp_rsqn7"],
				(int)obj_s["output1"]["askp_rsqn8"], (int)obj_s["output1"]["askp_rsqn9"], (int)obj_s["output1"]["askp_rsqn10"]};

				//매도호가, 잔량으로 10주 살 때 평단을 S라 할 것임.
				double S_buyingArbitrage = 0;
				int count = 0;
				for (int i = 0; i < 10; i++)
				{
					if (count < 10)
					{
						count += stock_askp_rsqn[i];

						if (count <= 10)
						{
							S_buyingArbitrage += stock_askp[i] * stock_askp_rsqn[i];
						}
						else
						{
							S_buyingArbitrage += stock_askp[i] * (10 - count + stock_askp_rsqn[i]);
							break;
						}
					}
					else
					{
						break;
					}
				}
				//평단 완성
				S_buyingArbitrage /= 10;

				//현물 매수 평단을 S로 하여 선물이론가격 도출
				double book_value = (S_buyingArbitrage + 2 * k) * (1 + r_borrow * (T / 365));
				//이론가격보다 선물매수호가중 가장 높은 것 ( 선물매도할 때 받을 수 있는 최대가격 )이 이론가격보다 크면 매수차익거래 가능
				if (book_value < futs_bidp[0])
				{
					System.Console.WriteLine("매수차익거래 기회 나옴!!!!!!!!!!!!!!!");
					System.Console.WriteLine(futs_bidp[0] - book_value);
				}
				System.Console.WriteLine("매수차익거래 기회 나옴을 나옴!!!!!!!!!!!!!!!");

				//얼마의 차익을 얻을 수 있는지 보냄

				////////////////////////////////// 매도차익거래  ///////////////////////////////
				//선물 매도호가1~5
				int[] futs_askp = { (int)obj_f["output2"]["futs_askp1"], (int)obj_f["output2"]["futs_askp2"] , (int)obj_f["output2"]["futs_askp3"] ,
				(int)obj_f["output2"]["futs_askp4"], (int)obj_f["output2"]["futs_askp5"] };
				//선물 매도호가잔량 1~5
				int[] futs_askp_rsqn = { (int)obj_f["output2"]["askp_rsqn1"], (int)obj_f["output2"]["askp_rsqn2"] , (int)obj_f["output2"]["askp_rsqn3"],
				(int)obj_f["output2"]["askp_rsqn4"] ,(int)obj_f["output2"]["askp_rsqn5"] };
				// 현물 매수호가1~10
				int[] stock_bidp = { (int)obj_s["output1"]["bidp1"], (int)obj_s["output1"]["bidp2"], (int)obj_s["output1"]["bidp3"],
				(int)obj_s["output1"]["bidp4"], (int)obj_s["output1"]["bidp5"], (int)obj_s["output1"]["bidp6"], (int)obj_s["output1"]["bidp7"],
				(int)obj_s["output1"]["bidp8"], (int)obj_s["output1"]["bidp9"], (int)obj_s["output1"]["bidp10"]};
				// 현물 매수호가잔량1~10
				int[] stock_bidp_rsqn = { (int)obj_s["output1"]["bidp_rsqn1"], (int)obj_s["output1"]["bidp_rsqn2"], (int)obj_s["output1"]["bidp_rsqn3"],
				(int)obj_s["output1"]["bidp_rsqn4"], (int)obj_s["output1"]["bidp_rsqn5"], (int)obj_s["output1"]["bidp_rsqn6"], (int)obj_s["output1"]["bidp_rsqn7"],
				(int)obj_s["output1"]["bidp_rsqn8"], (int)obj_s["output1"]["bidp_rsqn9"], (int)obj_s["output1"]["bidp_rsqn10"]};

				//매수호가, 잔량으로 10주 팔 때 평단을 S라 할 것임.
				double S_sellingArbitrage = 0;
				int count2 = 0;
				for (int i = 0; i < 10; i++)
				{
					if (count2 < 10)
					{
						count2 += stock_bidp_rsqn[i];

						if (count <= 10)
						{
							S_sellingArbitrage += stock_bidp[i] * stock_bidp_rsqn[i];
						}
						else
						{
							S_sellingArbitrage += stock_bidp[i] * (10 - count2 + stock_bidp_rsqn[i]);
							break;
						}
					}
					else
					{
						break;
					}
				}
				//평단 완성
				S_sellingArbitrage /= 10;

				//현물 매도 평단을 S로 하여 선물이론가격 도출
				double book_value2 = (S_sellingArbitrage + 2 * k) * (1 + r_lending * (T / 365));
				//이론가격보다 선물매수호가중 가장 높은 것 ( 선물매도할 때 받을 수 있는 최대가격 )이 이론가격보다 크면 매수차익거래 가능
				if (book_value2 > futs_askp[0])
				{
					System.Console.WriteLine("매도차익거래 기회 나옴!!!!!!!!!!!!!!!");
					System.Console.WriteLine(book_value2 - futs_askp[0]);
				}
				System.Console.WriteLine("매도차익거래 기회 나옴을 나옴!!!!!!!!!!!!!!!");

				//얼마의 차익을 얻을 수 있는지 보냄


				//chart3 
				// 매수차익거래 선물 이론가격
				chart2.Series["선물매수1호가"].Points.AddXY(x2, futs_bidp[0] );

				chart2.Series["선물매도1호가"].Points.AddXY(x2, futs_askp[0] );

				// 매수차익거래 선물 매수1호가 ( 내가 매도할 가격 )
				chart2.Series["매수차익 하한(이론가)"].Points.AddXY(x2, book_value );
				chart2.Series["매도차익 상한(이론가)"].Points.AddXY(x2, book_value2 );

				//매수차익거래 가능!!!
				if (futs_bidp[0] > book_value)
				{
					//showAlert("매수차익거래 가능");
				}
				//매도차익거래 가능!!
				if (futs_askp[0] < book_value2)
				{
					//showAlert("매도차익거래 가능");
				}




				if (chart2.Series["선물매수1호가"].Points.Count > 500)
				{
					chart2.Series["선물매수1호가"].Points.RemoveAt(0);
					chart2.Series["선물매도1호가"].Points.RemoveAt(0);
					chart2.Series["매수차익 하한(이론가)"].Points.RemoveAt(0);
					chart2.Series["매도차익 상한(이론가)"].Points.RemoveAt(0);

				}

				//chart2.ChartAreas[0].AxisX.Minimum = chart2.Series["선물매수1호가"].Points[0].XValue;
				chart2.ChartAreas[0].AxisX.Minimum = chart2.Series["선물매수1호가"].Points[0].XValue;
				chart2.ChartAreas[0].AxisX.Maximum = 50;
				chart2.ChartAreas[0].AxisY.Minimum = Math.Min(Math.Min(Math.Min(book_value, book_value2), futs_bidp[0]), futs_askp[0]) - 10000;
				chart2.ChartAreas[0].AxisY.Maximum = Math.Max(Math.Max(Math.Max(book_value, book_value2), futs_bidp[0]), futs_askp[0]) + 10000;

				x2 += 0.1; //그래프 상 오른쪽에 그려야하므로


			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"ex.Message={ex.Message}");
				Console.WriteLine($"ex.InnerException.Message = {ex.InnerException.Message}");

				Console.WriteLine($"----------- 서버에 연결할수없습니다 ---------------------");
			}
			catch (Exception ex2)
			{
				Console.WriteLine($"Exception={ex2.Message}");
			}
		}
		//삼성전자
		async void test3(double r_lending, double r_borrow, int T)
		{
			try
			{

				//주식 매수매도 호가
				string URL = "https://openapi.koreainvestment.com:9443/uapi/domestic-stock/v1/quotations/inquire-asking-price-exp-ccn?FID_COND_MRKT_DIV_CODE=J&FID_INPUT_ISCD=005930";
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
				request.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJ0b2tlbiIsImF1ZCI6ImIyMTkzNTlkLTg1ZjAtNDRiOS1hMjljLWYwYTI5YjY3N2ZhNiIsImlzcyI6InVub2d3IiwiZXhwIjoxNjk5MDEyMDgzLCJpYXQiOjE2OTg5MjU2ODMsImp0aSI6IlBTYnJpOVQyOThWeXhmSjAwNHg5TW5DUW54N2dLSlI4djY1OCJ9.881135Prt70_bn7VTGUTK75DYNONuho5uQjzm3nGAD50Bnc5ZMumrrcr_Br-oDXn66AizD7tWFNffqbFbXdCXA");
				request.Headers.Add("appkey", "PSbri9T298VyxfJ004x9MnCQnx7gKJR8v658");
				request.Headers.Add("appsecret", "VUn2CzaKPT1oTzwfBiXlY2ASg8SEndHMk/h5ukdZOElQVP5dfnfnv3OiTqw3aKYGR1NRYg17q05zOFlFhW8CdwYzMPI2wmqB9cNgx2f03O1ROveEw6Kr/CeGojxZBPMVU2MMzun4Gapcq1zu+lWYhbkDK/fAfmeCD+ftD2WMWPrJw9UBG0c=");
				request.Headers.Add("tr_id", "FHKST01010200");
				HttpWebResponse response_s = (HttpWebResponse)request.GetResponse();

				Stream stream_s = response_s.GetResponseStream();
				StreamReader reader_s = new StreamReader(stream_s, Encoding.UTF8);
				string text_s = reader_s.ReadToEnd();
				JObject obj_s = JObject.Parse(text_s);


				//선물 매수매도 호가
				string URL2 = "https://openapi.koreainvestment.com:9443/uapi/domestic-futureoption/v1/quotations/inquire-asking-price?FID_COND_MRKT_DIV_CODE=JF&FID_INPUT_ISCD=111T11000";
				HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(URL2);
				request2.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJ0b2tlbiIsImF1ZCI6ImIyMTkzNTlkLTg1ZjAtNDRiOS1hMjljLWYwYTI5YjY3N2ZhNiIsImlzcyI6InVub2d3IiwiZXhwIjoxNjk5MDEyMDgzLCJpYXQiOjE2OTg5MjU2ODMsImp0aSI6IlBTYnJpOVQyOThWeXhmSjAwNHg5TW5DUW54N2dLSlI4djY1OCJ9.881135Prt70_bn7VTGUTK75DYNONuho5uQjzm3nGAD50Bnc5ZMumrrcr_Br-oDXn66AizD7tWFNffqbFbXdCXA");
				request2.Headers.Add("appkey", "PSbri9T298VyxfJ004x9MnCQnx7gKJR8v658");
				request2.Headers.Add("appsecret", "VUn2CzaKPT1oTzwfBiXlY2ASg8SEndHMk/h5ukdZOElQVP5dfnfnv3OiTqw3aKYGR1NRYg17q05zOFlFhW8CdwYzMPI2wmqB9cNgx2f03O1ROveEw6Kr/CeGojxZBPMVU2MMzun4Gapcq1zu+lWYhbkDK/fAfmeCD+ftD2WMWPrJw9UBG0c=");
				request2.Headers.Add("tr_id", "FHMIF10010000");
				HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();

				Stream stream_f = response2.GetResponseStream();
				StreamReader reader_f = new StreamReader(stream_f, Encoding.UTF8);
				string text_f = reader_f.ReadToEnd();
				JObject obj_f = JObject.Parse(text_f);

				//string notice = obj["output1"]["askp1"].ToString();
				//Console.WriteLine(((int) obj["output1"]["askp1"]).GetType().Name);
				//Console.WriteLine((int)obj["output1"]["askp1"]);



				//선물 매수호가1~5
				int[] futs_bidp = { (int)obj_f["output2"]["futs_bidp1"], (int)obj_f["output2"]["futs_bidp2"] , (int)obj_f["output2"]["futs_bidp3"] ,
				(int)obj_f["output2"]["futs_bidp4"], (int)obj_f["output2"]["futs_bidp5"] };
				//선물 매수호가잔량 1~5
				int[] futs_bidp_rsqn = { (int)obj_f["output2"]["bidp_rsqn1"], (int)obj_f["output2"]["bidp_rsqn2"] , (int)obj_f["output2"]["bidp_rsqn3"],
				(int)obj_f["output2"]["bidp_rsqn4"] ,(int)obj_f["output2"]["bidp_rsqn5"] };
				// 현물 매도호가1~10
				int[] stock_askp = { (int)obj_s["output1"]["askp1"], (int)obj_s["output1"]["askp2"], (int)obj_s["output1"]["askp3"],
				(int)obj_s["output1"]["askp4"], (int)obj_s["output1"]["askp5"], (int)obj_s["output1"]["askp6"], (int)obj_s["output1"]["askp7"],
				(int)obj_s["output1"]["askp8"], (int)obj_s["output1"]["askp9"], (int)obj_s["output1"]["askp10"]};
				// 현물 매도호가잔량1~10
				int[] stock_askp_rsqn = { (int)obj_s["output1"]["askp_rsqn1"], (int)obj_s["output1"]["askp_rsqn2"], (int)obj_s["output1"]["askp_rsqn3"],
				(int)obj_s["output1"]["askp_rsqn4"], (int)obj_s["output1"]["askp_rsqn5"], (int)obj_s["output1"]["askp_rsqn6"], (int)obj_s["output1"]["askp_rsqn7"],
				(int)obj_s["output1"]["askp_rsqn8"], (int)obj_s["output1"]["askp_rsqn9"], (int)obj_s["output1"]["askp_rsqn10"]};

				//매도호가, 잔량으로 10주 살 때 평단을 S라 할 것임.
				double S_buyingArbitrage = 0;
				int count = 0;
				for (int i = 0; i < 10; i++)
				{
					if (count < 10)
					{
						count += stock_askp_rsqn[i];

						if (count <= 10)
						{
							S_buyingArbitrage += stock_askp[i] * stock_askp_rsqn[i];
						}
						else
						{
							S_buyingArbitrage += stock_askp[i] * (10 - count + stock_askp_rsqn[i]);
							break;
						}
					}
					else
					{
						break;
					}
				}
				//평단 완성
				S_buyingArbitrage /= 10;

				//현물 매수 평단을 S로 하여 선물이론가격 도출
				double book_value = (S_buyingArbitrage + 2 * k) * (1 + r_borrow * (T / 365));
				//이론가격보다 선물매수호가중 가장 높은 것 ( 선물매도할 때 받을 수 있는 최대가격 )이 이론가격보다 크면 매수차익거래 가능
				if (book_value < futs_bidp[0])
				{
					System.Console.WriteLine("매수차익거래 기회 나옴!!!!!!!!!!!!!!!");
					System.Console.WriteLine(futs_bidp[0] - book_value);
				}
				System.Console.WriteLine("매수차익거래 기회 나옴을 나옴!!!!!!!!!!!!!!!");

				//얼마의 차익을 얻을 수 있는지 보냄

				////////////////////////////////// 매도차익거래  ///////////////////////////////
				//선물 매도호가1~5
				int[] futs_askp = { (int)obj_f["output2"]["futs_askp1"], (int)obj_f["output2"]["futs_askp2"] , (int)obj_f["output2"]["futs_askp3"] ,
				(int)obj_f["output2"]["futs_askp4"], (int)obj_f["output2"]["futs_askp5"] };
				//선물 매도호가잔량 1~5
				int[] futs_askp_rsqn = { (int)obj_f["output2"]["askp_rsqn1"], (int)obj_f["output2"]["askp_rsqn2"] , (int)obj_f["output2"]["askp_rsqn3"],
				(int)obj_f["output2"]["askp_rsqn4"] ,(int)obj_f["output2"]["askp_rsqn5"] };
				// 현물 매수호가1~10
				int[] stock_bidp = { (int)obj_s["output1"]["bidp1"], (int)obj_s["output1"]["bidp2"], (int)obj_s["output1"]["bidp3"],
				(int)obj_s["output1"]["bidp4"], (int)obj_s["output1"]["bidp5"], (int)obj_s["output1"]["bidp6"], (int)obj_s["output1"]["bidp7"],
				(int)obj_s["output1"]["bidp8"], (int)obj_s["output1"]["bidp9"], (int)obj_s["output1"]["bidp10"]};
				// 현물 매수호가잔량1~10
				int[] stock_bidp_rsqn = { (int)obj_s["output1"]["bidp_rsqn1"], (int)obj_s["output1"]["bidp_rsqn2"], (int)obj_s["output1"]["bidp_rsqn3"],
				(int)obj_s["output1"]["bidp_rsqn4"], (int)obj_s["output1"]["bidp_rsqn5"], (int)obj_s["output1"]["bidp_rsqn6"], (int)obj_s["output1"]["bidp_rsqn7"],
				(int)obj_s["output1"]["bidp_rsqn8"], (int)obj_s["output1"]["bidp_rsqn9"], (int)obj_s["output1"]["bidp_rsqn10"]};

				//매수호가, 잔량으로 10주 팔 때 평단을 S라 할 것임.
				double S_sellingArbitrage = 0;
				int count2 = 0;
				for (int i = 0; i < 10; i++)
				{
					if (count2 < 10)
					{
						count2 += stock_bidp_rsqn[i];

						if (count <= 10)
						{
							S_sellingArbitrage += stock_bidp[i] * stock_bidp_rsqn[i];
						}
						else
						{
							S_sellingArbitrage += stock_bidp[i] * (10 - count2 + stock_bidp_rsqn[i]);
							break;
						}
					}
					else
					{
						break;
					}
				}
				//평단 완성
				S_sellingArbitrage /= 10;

				//현물 매도 평단을 S로 하여 선물이론가격 도출
				double book_value2 = (S_sellingArbitrage + 2 * k) * (1 + r_lending * (T / 365));
				//이론가격보다 선물매수호가중 가장 높은 것 ( 선물매도할 때 받을 수 있는 최대가격 )이 이론가격보다 크면 매수차익거래 가능
				if (book_value2 > futs_askp[0])
				{
					System.Console.WriteLine("매도차익거래 기회 나옴!!!!!!!!!!!!!!!");
					System.Console.WriteLine(book_value2 - futs_askp[0]);
				}
				System.Console.WriteLine("매도차익거래 기회 나옴을 나옴!!!!!!!!!!!!!!!");

				//얼마의 차익을 얻을 수 있는지 보냄


				//chart3 
				// 매수차익거래 선물 이론가격
				chart3.Series["선물매수1호가"].Points.AddXY(x3, futs_bidp[0] );

				chart3.Series["선물매도1호가"].Points.AddXY(x3, futs_askp[0] );

				// 매수차익거래 선물 매수1호가 ( 내가 매도할 가격 )
				chart3.Series["매수차익 하한(이론가)"].Points.AddXY(x3, book_value );
				chart3.Series["매도차익 상한(이론가)"].Points.AddXY(x3, book_value2 );

				//매수차익거래 가능!!!
				if (futs_bidp[0] > book_value)
				{
					//showAlert("매수차익거래 가능");
				}
				//매도차익거래 가능!!
				if (futs_askp[0] < book_value2)
				{
					//showAlert("매도차익거래 가능");
				}




				if (chart3.Series["선물매수1호가"].Points.Count > 500)
				{
					chart3.Series["선물매수1호가"].Points.RemoveAt(0);
					chart3.Series["선물매도1호가"].Points.RemoveAt(0);
					chart3.Series["매수차익 하한(이론가)"].Points.RemoveAt(0);
					chart3.Series["매도차익 상한(이론가)"].Points.RemoveAt(0);

				}

				//chart2.ChartAreas[0].AxisX.Minimum = chart2.Series["선물매수1호가"].Points[0].XValue;
				chart3.ChartAreas[0].AxisX.Minimum = chart3.Series["선물매수1호가"].Points[0].XValue;
				chart3.ChartAreas[0].AxisX.Maximum = 50;
				chart3.ChartAreas[0].AxisY.Minimum = Math.Min(Math.Min(Math.Min(book_value, book_value2), futs_bidp[0]), futs_askp[0]) - 10000;
				chart3.ChartAreas[0].AxisY.Maximum = Math.Max(Math.Max(Math.Max(book_value, book_value2), futs_bidp[0]), futs_askp[0]) + 10000;

				x3 += 0.1; //그래프 상 오른쪽에 그려야하므로


			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"ex.Message={ex.Message}");
				Console.WriteLine($"ex.InnerException.Message = {ex.InnerException.Message}");

				Console.WriteLine($"----------- 서버에 연결할수없습니다 ---------------------");
			}
			catch (Exception ex2)
			{
				Console.WriteLine($"Exception={ex2.Message}");
			}
		}

		//
		//현대차
		async void test4(double r_lending, double r_borrow, int T)
		{
			try
			{

				//주식 매수매도 호가
				string URL = "https://openapi.koreainvestment.com:9443/uapi/domestic-stock/v1/quotations/inquire-asking-price-exp-ccn?FID_COND_MRKT_DIV_CODE=J&FID_INPUT_ISCD=005380";
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
				request.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJ0b2tlbiIsImF1ZCI6ImIyMTkzNTlkLTg1ZjAtNDRiOS1hMjljLWYwYTI5YjY3N2ZhNiIsImlzcyI6InVub2d3IiwiZXhwIjoxNjk5MDEyMDgzLCJpYXQiOjE2OTg5MjU2ODMsImp0aSI6IlBTYnJpOVQyOThWeXhmSjAwNHg5TW5DUW54N2dLSlI4djY1OCJ9.881135Prt70_bn7VTGUTK75DYNONuho5uQjzm3nGAD50Bnc5ZMumrrcr_Br-oDXn66AizD7tWFNffqbFbXdCXA");
				request.Headers.Add("appkey", "PSbri9T298VyxfJ004x9MnCQnx7gKJR8v658");
				request.Headers.Add("appsecret", "VUn2CzaKPT1oTzwfBiXlY2ASg8SEndHMk/h5ukdZOElQVP5dfnfnv3OiTqw3aKYGR1NRYg17q05zOFlFhW8CdwYzMPI2wmqB9cNgx2f03O1ROveEw6Kr/CeGojxZBPMVU2MMzun4Gapcq1zu+lWYhbkDK/fAfmeCD+ftD2WMWPrJw9UBG0c=");
				request.Headers.Add("tr_id", "FHKST01010200");
				HttpWebResponse response_s = (HttpWebResponse)request.GetResponse();

				Stream stream_s = response_s.GetResponseStream();
				StreamReader reader_s = new StreamReader(stream_s, Encoding.UTF8);
				string text_s = reader_s.ReadToEnd();
				JObject obj_s = JObject.Parse(text_s);


				//선물 매수매도 호가
				string URL2 = "https://openapi.koreainvestment.com:9443/uapi/domestic-futureoption/v1/quotations/inquire-asking-price?FID_COND_MRKT_DIV_CODE=JF&FID_INPUT_ISCD=116T11000";
				HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(URL2);
				request2.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJ0b2tlbiIsImF1ZCI6ImIyMTkzNTlkLTg1ZjAtNDRiOS1hMjljLWYwYTI5YjY3N2ZhNiIsImlzcyI6InVub2d3IiwiZXhwIjoxNjk5MDEyMDgzLCJpYXQiOjE2OTg5MjU2ODMsImp0aSI6IlBTYnJpOVQyOThWeXhmSjAwNHg5TW5DUW54N2dLSlI4djY1OCJ9.881135Prt70_bn7VTGUTK75DYNONuho5uQjzm3nGAD50Bnc5ZMumrrcr_Br-oDXn66AizD7tWFNffqbFbXdCXA");
				request2.Headers.Add("appkey", "PSbri9T298VyxfJ004x9MnCQnx7gKJR8v658");
				request2.Headers.Add("appsecret", "VUn2CzaKPT1oTzwfBiXlY2ASg8SEndHMk/h5ukdZOElQVP5dfnfnv3OiTqw3aKYGR1NRYg17q05zOFlFhW8CdwYzMPI2wmqB9cNgx2f03O1ROveEw6Kr/CeGojxZBPMVU2MMzun4Gapcq1zu+lWYhbkDK/fAfmeCD+ftD2WMWPrJw9UBG0c=");
				request2.Headers.Add("tr_id", "FHMIF10010000");
				HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();

				Stream stream_f = response2.GetResponseStream();
				StreamReader reader_f = new StreamReader(stream_f, Encoding.UTF8);
				string text_f = reader_f.ReadToEnd();
				JObject obj_f = JObject.Parse(text_f);

				//string notice = obj["output1"]["askp1"].ToString();
				//Console.WriteLine(((int) obj["output1"]["askp1"]).GetType().Name);
				//Console.WriteLine((int)obj["output1"]["askp1"]);



				//선물 매수호가1~5
				int[] futs_bidp = { (int)obj_f["output2"]["futs_bidp1"], (int)obj_f["output2"]["futs_bidp2"] , (int)obj_f["output2"]["futs_bidp3"] ,
				(int)obj_f["output2"]["futs_bidp4"], (int)obj_f["output2"]["futs_bidp5"] };
				//선물 매수호가잔량 1~5
				int[] futs_bidp_rsqn = { (int)obj_f["output2"]["bidp_rsqn1"], (int)obj_f["output2"]["bidp_rsqn2"] , (int)obj_f["output2"]["bidp_rsqn3"],
				(int)obj_f["output2"]["bidp_rsqn4"] ,(int)obj_f["output2"]["bidp_rsqn5"] };
				// 현물 매도호가1~10
				int[] stock_askp = { (int)obj_s["output1"]["askp1"], (int)obj_s["output1"]["askp2"], (int)obj_s["output1"]["askp3"],
				(int)obj_s["output1"]["askp4"], (int)obj_s["output1"]["askp5"], (int)obj_s["output1"]["askp6"], (int)obj_s["output1"]["askp7"],
				(int)obj_s["output1"]["askp8"], (int)obj_s["output1"]["askp9"], (int)obj_s["output1"]["askp10"]};
				// 현물 매도호가잔량1~10
				int[] stock_askp_rsqn = { (int)obj_s["output1"]["askp_rsqn1"], (int)obj_s["output1"]["askp_rsqn2"], (int)obj_s["output1"]["askp_rsqn3"],
				(int)obj_s["output1"]["askp_rsqn4"], (int)obj_s["output1"]["askp_rsqn5"], (int)obj_s["output1"]["askp_rsqn6"], (int)obj_s["output1"]["askp_rsqn7"],
				(int)obj_s["output1"]["askp_rsqn8"], (int)obj_s["output1"]["askp_rsqn9"], (int)obj_s["output1"]["askp_rsqn10"]};

				//매도호가, 잔량으로 10주 살 때 평단을 S라 할 것임.
				double S_buyingArbitrage = 0;
				int count = 0;
				for (int i = 0; i < 10; i++)
				{
					if (count < 10)
					{
						count += stock_askp_rsqn[i];

						if (count <= 10)
						{
							S_buyingArbitrage += stock_askp[i] * stock_askp_rsqn[i];
						}
						else
						{
							S_buyingArbitrage += stock_askp[i] * (10 - count + stock_askp_rsqn[i]);
							break;
						}
					}
					else
					{
						break;
					}
				}
				//평단 완성
				S_buyingArbitrage /= 10;

				//현물 매수 평단을 S로 하여 선물이론가격 도출
				double book_value = (S_buyingArbitrage + 2 * k) * (1 + r_borrow * (T / 365));
				//이론가격보다 선물매수호가중 가장 높은 것 ( 선물매도할 때 받을 수 있는 최대가격 )이 이론가격보다 크면 매수차익거래 가능
				if (book_value < futs_bidp[0])
				{
					System.Console.WriteLine("매수차익거래 기회 나옴!!!!!!!!!!!!!!!");
					System.Console.WriteLine(futs_bidp[0] - book_value);
				}
				System.Console.WriteLine("매수차익거래 기회 나옴을 나옴!!!!!!!!!!!!!!!");

				//얼마의 차익을 얻을 수 있는지 보냄

				////////////////////////////////// 매도차익거래  ///////////////////////////////
				//선물 매도호가1~5
				int[] futs_askp = { (int)obj_f["output2"]["futs_askp1"], (int)obj_f["output2"]["futs_askp2"] , (int)obj_f["output2"]["futs_askp3"] ,
				(int)obj_f["output2"]["futs_askp4"], (int)obj_f["output2"]["futs_askp5"] };
				//선물 매도호가잔량 1~5
				int[] futs_askp_rsqn = { (int)obj_f["output2"]["askp_rsqn1"], (int)obj_f["output2"]["askp_rsqn2"] , (int)obj_f["output2"]["askp_rsqn3"],
				(int)obj_f["output2"]["askp_rsqn4"] ,(int)obj_f["output2"]["askp_rsqn5"] };
				// 현물 매수호가1~10
				int[] stock_bidp = { (int)obj_s["output1"]["bidp1"], (int)obj_s["output1"]["bidp2"], (int)obj_s["output1"]["bidp3"],
				(int)obj_s["output1"]["bidp4"], (int)obj_s["output1"]["bidp5"], (int)obj_s["output1"]["bidp6"], (int)obj_s["output1"]["bidp7"],
				(int)obj_s["output1"]["bidp8"], (int)obj_s["output1"]["bidp9"], (int)obj_s["output1"]["bidp10"]};
				// 현물 매수호가잔량1~10
				int[] stock_bidp_rsqn = { (int)obj_s["output1"]["bidp_rsqn1"], (int)obj_s["output1"]["bidp_rsqn2"], (int)obj_s["output1"]["bidp_rsqn3"],
				(int)obj_s["output1"]["bidp_rsqn4"], (int)obj_s["output1"]["bidp_rsqn5"], (int)obj_s["output1"]["bidp_rsqn6"], (int)obj_s["output1"]["bidp_rsqn7"],
				(int)obj_s["output1"]["bidp_rsqn8"], (int)obj_s["output1"]["bidp_rsqn9"], (int)obj_s["output1"]["bidp_rsqn10"]};

				//매수호가, 잔량으로 10주 팔 때 평단을 S라 할 것임.
				double S_sellingArbitrage = 0;
				int count2 = 0;
				for (int i = 0; i < 10; i++)
				{
					if (count2 < 10)
					{
						count2 += stock_bidp_rsqn[i];

						if (count <= 10)
						{
							S_sellingArbitrage += stock_bidp[i] * stock_bidp_rsqn[i];
						}
						else
						{
							S_sellingArbitrage += stock_bidp[i] * (10 - count2 + stock_bidp_rsqn[i]);
							break;
						}
					}
					else
					{
						break;
					}
				}
				//평단 완성
				S_sellingArbitrage /= 10;

				//현물 매도 평단을 S로 하여 선물이론가격 도출
				double book_value2 = (S_sellingArbitrage + 2 * k) * (1 + r_lending * (T / 365));
				//이론가격보다 선물매수호가중 가장 높은 것 ( 선물매도할 때 받을 수 있는 최대가격 )이 이론가격보다 크면 매수차익거래 가능
				if (book_value2 > futs_askp[0])
				{
					System.Console.WriteLine("매도차익거래 기회 나옴!!!!!!!!!!!!!!!");
					System.Console.WriteLine(book_value2 - futs_askp[0]);
				}
				System.Console.WriteLine("매도차익거래 기회 나옴을 나옴!!!!!!!!!!!!!!!");

				//얼마의 차익을 얻을 수 있는지 보냄


				//chart3 
				// 매수차익거래 선물 이론가격
				chart4.Series["선물매수1호가"].Points.AddXY(x4, futs_bidp[0] );

				chart4.Series["선물매도1호가"].Points.AddXY(x4, futs_askp[0] );

				// 매수차익거래 선물 매수1호가 ( 내가 매도할 가격 )
				chart4.Series["매수차익 하한(이론가)"].Points.AddXY(x4, book_value );
				chart4.Series["매도차익 상한(이론가)"].Points.AddXY(x4, book_value2 );

				//매수차익거래 가능!!!
				if (futs_bidp[0] > book_value)
				{
					//showAlert("매수차익거래 가능");
				}
				//매도차익거래 가능!!
				if (futs_askp[0] < book_value2)
				{
					//showAlert("매도차익거래 가능");
				}

				if (chart4.Series["선물매수1호가"].Points.Count > 500)
				{
					chart4.Series["선물매수1호가"].Points.RemoveAt(0);
					chart4.Series["선물매도1호가"].Points.RemoveAt(0);
					chart4.Series["매수차익 하한(이론가)"].Points.RemoveAt(0);
					chart4.Series["매도차익 상한(이론가)"].Points.RemoveAt(0);

				}

		
				chart4.ChartAreas[0].AxisX.Minimum = chart4.Series["선물매수1호가"].Points[0].XValue;
				chart4.ChartAreas[0].AxisX.Maximum = 50;
				chart4.ChartAreas[0].AxisY.Minimum = Math.Min(Math.Min(Math.Min(book_value, book_value2), futs_bidp[0]), futs_askp[0]) - 10000;
				chart4.ChartAreas[0].AxisY.Maximum = Math.Max(Math.Max(Math.Max(book_value, book_value2), futs_bidp[0]), futs_askp[0]) + 10000;

				x4 += 0.1; //그래프 상 오른쪽에 그려야하므로


			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"ex.Message={ex.Message}");
				Console.WriteLine($"ex.InnerException.Message = {ex.InnerException.Message}");

				Console.WriteLine($"----------- 서버에 연결할수없습니다 ---------------------");
			}
			catch (Exception ex2)
			{
				Console.WriteLine($"Exception={ex2.Message}");
			}
		}


		//한국전력
		async void test5(double r_lending, double r_borrow, int T)
		{
			try
			{

				//주식 매수매도 호가
				string URL = "https://openapi.koreainvestment.com:9443/uapi/domestic-stock/v1/quotations/inquire-asking-price-exp-ccn?FID_COND_MRKT_DIV_CODE=J&FID_INPUT_ISCD=015760";
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
				request.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJ0b2tlbiIsImF1ZCI6ImIyMTkzNTlkLTg1ZjAtNDRiOS1hMjljLWYwYTI5YjY3N2ZhNiIsImlzcyI6InVub2d3IiwiZXhwIjoxNjk5MDEyMDgzLCJpYXQiOjE2OTg5MjU2ODMsImp0aSI6IlBTYnJpOVQyOThWeXhmSjAwNHg5TW5DUW54N2dLSlI4djY1OCJ9.881135Prt70_bn7VTGUTK75DYNONuho5uQjzm3nGAD50Bnc5ZMumrrcr_Br-oDXn66AizD7tWFNffqbFbXdCXA");
				request.Headers.Add("appkey", "PSbri9T298VyxfJ004x9MnCQnx7gKJR8v658");
				request.Headers.Add("appsecret", "VUn2CzaKPT1oTzwfBiXlY2ASg8SEndHMk/h5ukdZOElQVP5dfnfnv3OiTqw3aKYGR1NRYg17q05zOFlFhW8CdwYzMPI2wmqB9cNgx2f03O1ROveEw6Kr/CeGojxZBPMVU2MMzun4Gapcq1zu+lWYhbkDK/fAfmeCD+ftD2WMWPrJw9UBG0c=");
				request.Headers.Add("tr_id", "FHKST01010200");
				HttpWebResponse response_s = (HttpWebResponse)request.GetResponse();

				Stream stream_s = response_s.GetResponseStream();
				StreamReader reader_s = new StreamReader(stream_s, Encoding.UTF8);
				string text_s = reader_s.ReadToEnd();
				JObject obj_s = JObject.Parse(text_s);


				//선물 매수매도 호가
				string URL2 = "https://openapi.koreainvestment.com:9443/uapi/domestic-futureoption/v1/quotations/inquire-asking-price?FID_COND_MRKT_DIV_CODE=JF&FID_INPUT_ISCD=115T11000";
				HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(URL2);
				request2.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJ0b2tlbiIsImF1ZCI6ImIyMTkzNTlkLTg1ZjAtNDRiOS1hMjljLWYwYTI5YjY3N2ZhNiIsImlzcyI6InVub2d3IiwiZXhwIjoxNjk5MDEyMDgzLCJpYXQiOjE2OTg5MjU2ODMsImp0aSI6IlBTYnJpOVQyOThWeXhmSjAwNHg5TW5DUW54N2dLSlI4djY1OCJ9.881135Prt70_bn7VTGUTK75DYNONuho5uQjzm3nGAD50Bnc5ZMumrrcr_Br-oDXn66AizD7tWFNffqbFbXdCXA");
				request2.Headers.Add("appkey", "PSbri9T298VyxfJ004x9MnCQnx7gKJR8v658");
				request2.Headers.Add("appsecret", "VUn2CzaKPT1oTzwfBiXlY2ASg8SEndHMk/h5ukdZOElQVP5dfnfnv3OiTqw3aKYGR1NRYg17q05zOFlFhW8CdwYzMPI2wmqB9cNgx2f03O1ROveEw6Kr/CeGojxZBPMVU2MMzun4Gapcq1zu+lWYhbkDK/fAfmeCD+ftD2WMWPrJw9UBG0c=");
				request2.Headers.Add("tr_id", "FHMIF10010000");
				HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();

				Stream stream_f = response2.GetResponseStream();
				StreamReader reader_f = new StreamReader(stream_f, Encoding.UTF8);
				string text_f = reader_f.ReadToEnd();
				JObject obj_f = JObject.Parse(text_f);

				//string notice = obj["output1"]["askp1"].ToString();
				//Console.WriteLine(((int) obj["output1"]["askp1"]).GetType().Name);
				//Console.WriteLine((int)obj["output1"]["askp1"]);



				//선물 매수호가1~5
				int[] futs_bidp = { (int)obj_f["output2"]["futs_bidp1"], (int)obj_f["output2"]["futs_bidp2"] , (int)obj_f["output2"]["futs_bidp3"] ,
				(int)obj_f["output2"]["futs_bidp4"], (int)obj_f["output2"]["futs_bidp5"] };
				//선물 매수호가잔량 1~5
				int[] futs_bidp_rsqn = { (int)obj_f["output2"]["bidp_rsqn1"], (int)obj_f["output2"]["bidp_rsqn2"] , (int)obj_f["output2"]["bidp_rsqn3"],
				(int)obj_f["output2"]["bidp_rsqn4"] ,(int)obj_f["output2"]["bidp_rsqn5"] };
				// 현물 매도호가1~10
				int[] stock_askp = { (int)obj_s["output1"]["askp1"], (int)obj_s["output1"]["askp2"], (int)obj_s["output1"]["askp3"],
				(int)obj_s["output1"]["askp4"], (int)obj_s["output1"]["askp5"], (int)obj_s["output1"]["askp6"], (int)obj_s["output1"]["askp7"],
				(int)obj_s["output1"]["askp8"], (int)obj_s["output1"]["askp9"], (int)obj_s["output1"]["askp10"]};
				// 현물 매도호가잔량1~10
				int[] stock_askp_rsqn = { (int)obj_s["output1"]["askp_rsqn1"], (int)obj_s["output1"]["askp_rsqn2"], (int)obj_s["output1"]["askp_rsqn3"],
				(int)obj_s["output1"]["askp_rsqn4"], (int)obj_s["output1"]["askp_rsqn5"], (int)obj_s["output1"]["askp_rsqn6"], (int)obj_s["output1"]["askp_rsqn7"],
				(int)obj_s["output1"]["askp_rsqn8"], (int)obj_s["output1"]["askp_rsqn9"], (int)obj_s["output1"]["askp_rsqn10"]};

				//매도호가, 잔량으로 10주 살 때 평단을 S라 할 것임.
				double S_buyingArbitrage = 0;
				int count = 0;
				for (int i = 0; i < 10; i++)
				{
					if (count < 10)
					{
						count += stock_askp_rsqn[i];

						if (count <= 10)
						{
							S_buyingArbitrage += stock_askp[i] * stock_askp_rsqn[i];
						}
						else
						{
							S_buyingArbitrage += stock_askp[i] * (10 - count + stock_askp_rsqn[i]);
							break;
						}
					}
					else
					{
						break;
					}
				}
				//평단 완성
				S_buyingArbitrage /= 10;

				//현물 매수 평단을 S로 하여 선물이론가격 도출
				double book_value = (S_buyingArbitrage + 2 * k) * (1 + r_borrow * (T / 365));
				//이론가격보다 선물매수호가중 가장 높은 것 ( 선물매도할 때 받을 수 있는 최대가격 )이 이론가격보다 크면 매수차익거래 가능
				if (book_value < futs_bidp[0])
				{
					System.Console.WriteLine("매수차익거래 기회 나옴!!!!!!!!!!!!!!!");
					System.Console.WriteLine(futs_bidp[0] - book_value);
				}
				System.Console.WriteLine("매수차익거래 기회 나옴을 나옴!!!!!!!!!!!!!!!");

				//얼마의 차익을 얻을 수 있는지 보냄

				////////////////////////////////// 매도차익거래  ///////////////////////////////
				//선물 매도호가1~5
				int[] futs_askp = { (int)obj_f["output2"]["futs_askp1"], (int)obj_f["output2"]["futs_askp2"] , (int)obj_f["output2"]["futs_askp3"] ,
				(int)obj_f["output2"]["futs_askp4"], (int)obj_f["output2"]["futs_askp5"] };
				//선물 매도호가잔량 1~5
				int[] futs_askp_rsqn = { (int)obj_f["output2"]["askp_rsqn1"], (int)obj_f["output2"]["askp_rsqn2"] , (int)obj_f["output2"]["askp_rsqn3"],
				(int)obj_f["output2"]["askp_rsqn4"] ,(int)obj_f["output2"]["askp_rsqn5"] };
				// 현물 매수호가1~10
				int[] stock_bidp = { (int)obj_s["output1"]["bidp1"], (int)obj_s["output1"]["bidp2"], (int)obj_s["output1"]["bidp3"],
				(int)obj_s["output1"]["bidp4"], (int)obj_s["output1"]["bidp5"], (int)obj_s["output1"]["bidp6"], (int)obj_s["output1"]["bidp7"],
				(int)obj_s["output1"]["bidp8"], (int)obj_s["output1"]["bidp9"], (int)obj_s["output1"]["bidp10"]};
				// 현물 매수호가잔량1~10
				int[] stock_bidp_rsqn = { (int)obj_s["output1"]["bidp_rsqn1"], (int)obj_s["output1"]["bidp_rsqn2"], (int)obj_s["output1"]["bidp_rsqn3"],
				(int)obj_s["output1"]["bidp_rsqn4"], (int)obj_s["output1"]["bidp_rsqn5"], (int)obj_s["output1"]["bidp_rsqn6"], (int)obj_s["output1"]["bidp_rsqn7"],
				(int)obj_s["output1"]["bidp_rsqn8"], (int)obj_s["output1"]["bidp_rsqn9"], (int)obj_s["output1"]["bidp_rsqn10"]};

				//매수호가, 잔량으로 10주 팔 때 평단을 S라 할 것임.
				double S_sellingArbitrage = 0;
				int count2 = 0;
				for (int i = 0; i < 10; i++)
				{
					if (count2 < 10)
					{
						count2 += stock_bidp_rsqn[i];

						if (count <= 10)
						{
							S_sellingArbitrage += stock_bidp[i] * stock_bidp_rsqn[i];
						}
						else
						{
							S_sellingArbitrage += stock_bidp[i] * (10 - count2 + stock_bidp_rsqn[i]);
							break;
						}
					}
					else
					{
						break;
					}
				}
				//평단 완성
				S_sellingArbitrage /= 10;

				//현물 매도 평단을 S로 하여 선물이론가격 도출
				double book_value2 = (S_sellingArbitrage + 2 * k) * (1 + r_lending * (T / 365));
				//이론가격보다 선물매수호가중 가장 높은 것 ( 선물매도할 때 받을 수 있는 최대가격 )이 이론가격보다 크면 매수차익거래 가능
				if (book_value2 > futs_askp[0])
				{
					System.Console.WriteLine("매도차익거래 기회 나옴!!!!!!!!!!!!!!!");
					System.Console.WriteLine(book_value2 - futs_askp[0]);
				}
				System.Console.WriteLine("매도차익거래 기회 나옴을 나옴!!!!!!!!!!!!!!!");

				//얼마의 차익을 얻을 수 있는지 보냄


				//chart3 
				// 매수차익거래 선물 이론가격
				chart5.Series["선물매수1호가"].Points.AddXY(x5, futs_bidp[0] );

				chart5.Series["선물매도1호가"].Points.AddXY(x5, futs_askp[0]);

				// 매수차익거래 선물 매수1호가 ( 내가 매도할 가격 )
				chart5.Series["매수차익 하한(이론가)"].Points.AddXY(x5, book_value );
				chart5.Series["매도차익 상한(이론가)"].Points.AddXY(x5, book_value2 );

				//매수차익거래 가능!!!
				if (futs_bidp[0] > book_value)
				{
					//showAlert("매수차익거래 가능");
				}
				//매도차익거래 가능!!
				if (futs_askp[0] < book_value2)
				{
					//showAlert("매도차익거래 가능");
				}

				if (chart5.Series["선물매수1호가"].Points.Count > 500)
				{
					chart5.Series["선물매수1호가"].Points.RemoveAt(0);
					chart5.Series["선물매도1호가"].Points.RemoveAt(0);
					chart5.Series["매수차익 하한(이론가)"].Points.RemoveAt(0);
					chart5.Series["매도차익 상한(이론가)"].Points.RemoveAt(0);

				}

				chart5.ChartAreas[0].AxisX.Minimum = chart5.Series["선물매수1호가"].Points[0].XValue;
				chart5.ChartAreas[0].AxisX.Maximum = 50;
				chart5.ChartAreas[0].AxisY.Minimum = Math.Min(Math.Min(Math.Min(book_value, book_value2), futs_bidp[0]), futs_askp[0]) - 10000;
				chart5.ChartAreas[0].AxisY.Maximum = Math.Max(Math.Max(Math.Max(book_value, book_value2), futs_bidp[0]), futs_askp[0]) + 10000;

				x5 += 0.1; //그래프 상 오른쪽에 그려야하므로


			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"ex.Message={ex.Message}");
				Console.WriteLine($"ex.InnerException.Message = {ex.InnerException.Message}");

				Console.WriteLine($"----------- 서버에 연결할수없습니다 ---------------------");
			}
			catch (Exception ex2)
			{
				Console.WriteLine($"Exception={ex2.Message}");
			}
		}


		//삼성SDI
		async void test6(double r_lending, double r_borrow, int T)
		{
			try
			{
				//주식 매수매도 호가
				string URL = "https://openapi.koreainvestment.com:9443/uapi/domestic-stock/v1/quotations/inquire-asking-price-exp-ccn?FID_COND_MRKT_DIV_CODE=J&FID_INPUT_ISCD=006400";
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
				request.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJ0b2tlbiIsImF1ZCI6ImIyMTkzNTlkLTg1ZjAtNDRiOS1hMjljLWYwYTI5YjY3N2ZhNiIsImlzcyI6InVub2d3IiwiZXhwIjoxNjk5MDEyMDgzLCJpYXQiOjE2OTg5MjU2ODMsImp0aSI6IlBTYnJpOVQyOThWeXhmSjAwNHg5TW5DUW54N2dLSlI4djY1OCJ9.881135Prt70_bn7VTGUTK75DYNONuho5uQjzm3nGAD50Bnc5ZMumrrcr_Br-oDXn66AizD7tWFNffqbFbXdCXA");
				request.Headers.Add("appkey", "PSbri9T298VyxfJ004x9MnCQnx7gKJR8v658");
				request.Headers.Add("appsecret", "VUn2CzaKPT1oTzwfBiXlY2ASg8SEndHMk/h5ukdZOElQVP5dfnfnv3OiTqw3aKYGR1NRYg17q05zOFlFhW8CdwYzMPI2wmqB9cNgx2f03O1ROveEw6Kr/CeGojxZBPMVU2MMzun4Gapcq1zu+lWYhbkDK/fAfmeCD+ftD2WMWPrJw9UBG0c=");
				request.Headers.Add("tr_id", "FHKST01010200");
				HttpWebResponse response_s = (HttpWebResponse)request.GetResponse();

				Stream stream_s = response_s.GetResponseStream();
				StreamReader reader_s = new StreamReader(stream_s, Encoding.UTF8);
				string text_s = reader_s.ReadToEnd();
				JObject obj_s = JObject.Parse(text_s);


				//선물 매수매도 호가
				string URL2 = "https://openapi.koreainvestment.com:9443/uapi/domestic-futureoption/v1/quotations/inquire-asking-price?FID_COND_MRKT_DIV_CODE=JF&FID_INPUT_ISCD=122T11000";
				HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(URL2);
				request2.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJ0b2tlbiIsImF1ZCI6ImIyMTkzNTlkLTg1ZjAtNDRiOS1hMjljLWYwYTI5YjY3N2ZhNiIsImlzcyI6InVub2d3IiwiZXhwIjoxNjk5MDEyMDgzLCJpYXQiOjE2OTg5MjU2ODMsImp0aSI6IlBTYnJpOVQyOThWeXhmSjAwNHg5TW5DUW54N2dLSlI4djY1OCJ9.881135Prt70_bn7VTGUTK75DYNONuho5uQjzm3nGAD50Bnc5ZMumrrcr_Br-oDXn66AizD7tWFNffqbFbXdCXA");
				request2.Headers.Add("appkey", "PSbri9T298VyxfJ004x9MnCQnx7gKJR8v658");
				request2.Headers.Add("appsecret", "VUn2CzaKPT1oTzwfBiXlY2ASg8SEndHMk/h5ukdZOElQVP5dfnfnv3OiTqw3aKYGR1NRYg17q05zOFlFhW8CdwYzMPI2wmqB9cNgx2f03O1ROveEw6Kr/CeGojxZBPMVU2MMzun4Gapcq1zu+lWYhbkDK/fAfmeCD+ftD2WMWPrJw9UBG0c=");
				request2.Headers.Add("tr_id", "FHMIF10010000");
				HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();

				Stream stream_f = response2.GetResponseStream();
				StreamReader reader_f = new StreamReader(stream_f, Encoding.UTF8);
				string text_f = reader_f.ReadToEnd();
				JObject obj_f = JObject.Parse(text_f);

				//string notice = obj["output1"]["askp1"].ToString();
				//Console.WriteLine(((int) obj["output1"]["askp1"]).GetType().Name);
				//Console.WriteLine((int)obj["output1"]["askp1"]);



				//선물 매수호가1~5
				int[] futs_bidp = { (int)obj_f["output2"]["futs_bidp1"], (int)obj_f["output2"]["futs_bidp2"] , (int)obj_f["output2"]["futs_bidp3"] ,
				(int)obj_f["output2"]["futs_bidp4"], (int)obj_f["output2"]["futs_bidp5"] };
				//선물 매수호가잔량 1~5
				int[] futs_bidp_rsqn = { (int)obj_f["output2"]["bidp_rsqn1"], (int)obj_f["output2"]["bidp_rsqn2"] , (int)obj_f["output2"]["bidp_rsqn3"],
				(int)obj_f["output2"]["bidp_rsqn4"] ,(int)obj_f["output2"]["bidp_rsqn5"] };
				// 현물 매도호가1~10
				int[] stock_askp = { (int)obj_s["output1"]["askp1"], (int)obj_s["output1"]["askp2"], (int)obj_s["output1"]["askp3"],
				(int)obj_s["output1"]["askp4"], (int)obj_s["output1"]["askp5"], (int)obj_s["output1"]["askp6"], (int)obj_s["output1"]["askp7"],
				(int)obj_s["output1"]["askp8"], (int)obj_s["output1"]["askp9"], (int)obj_s["output1"]["askp10"]};
				// 현물 매도호가잔량1~10
				int[] stock_askp_rsqn = { (int)obj_s["output1"]["askp_rsqn1"], (int)obj_s["output1"]["askp_rsqn2"], (int)obj_s["output1"]["askp_rsqn3"],
				(int)obj_s["output1"]["askp_rsqn4"], (int)obj_s["output1"]["askp_rsqn5"], (int)obj_s["output1"]["askp_rsqn6"], (int)obj_s["output1"]["askp_rsqn7"],
				(int)obj_s["output1"]["askp_rsqn8"], (int)obj_s["output1"]["askp_rsqn9"], (int)obj_s["output1"]["askp_rsqn10"]};

				//매도호가, 잔량으로 10주 살 때 평단을 S라 할 것임.
				double S_buyingArbitrage = 0;
				int count = 0;
				for (int i = 0; i < 10; i++)
				{
					if (count < 10)
					{
						count += stock_askp_rsqn[i];

						if (count <= 10)
						{
							S_buyingArbitrage += stock_askp[i] * stock_askp_rsqn[i];
						}
						else
						{
							S_buyingArbitrage += stock_askp[i] * (10 - count + stock_askp_rsqn[i]);
							break;
						}
					}
					else
					{
						break;
					}
				}
				//평단 완성
				S_buyingArbitrage /= 10;

				//현물 매수 평단을 S로 하여 선물이론가격 도출
				double book_value = (S_buyingArbitrage + 2 * k) * (1 + r_borrow * (T / 365));
				//이론가격보다 선물매수호가중 가장 높은 것 ( 선물매도할 때 받을 수 있는 최대가격 )이 이론가격보다 크면 매수차익거래 가능
				if (book_value < futs_bidp[0])
				{
					System.Console.WriteLine("매수차익거래 기회 나옴!!!!!!!!!!!!!!!");
					System.Console.WriteLine(futs_bidp[0] - book_value);
				}
				System.Console.WriteLine("매수차익거래 기회 나옴을 나옴!!!!!!!!!!!!!!!");

				//얼마의 차익을 얻을 수 있는지 보냄

				////////////////////////////////// 매도차익거래  ///////////////////////////////
				//선물 매도호가1~5
				int[] futs_askp = { (int)obj_f["output2"]["futs_askp1"], (int)obj_f["output2"]["futs_askp2"] , (int)obj_f["output2"]["futs_askp3"] ,
				(int)obj_f["output2"]["futs_askp4"], (int)obj_f["output2"]["futs_askp5"] };
				//선물 매도호가잔량 1~5
				int[] futs_askp_rsqn = { (int)obj_f["output2"]["askp_rsqn1"], (int)obj_f["output2"]["askp_rsqn2"] , (int)obj_f["output2"]["askp_rsqn3"],
				(int)obj_f["output2"]["askp_rsqn4"] ,(int)obj_f["output2"]["askp_rsqn5"] };
				// 현물 매수호가1~10
				int[] stock_bidp = { (int)obj_s["output1"]["bidp1"], (int)obj_s["output1"]["bidp2"], (int)obj_s["output1"]["bidp3"],
				(int)obj_s["output1"]["bidp4"], (int)obj_s["output1"]["bidp5"], (int)obj_s["output1"]["bidp6"], (int)obj_s["output1"]["bidp7"],
				(int)obj_s["output1"]["bidp8"], (int)obj_s["output1"]["bidp9"], (int)obj_s["output1"]["bidp10"]};
				// 현물 매수호가잔량1~10
				int[] stock_bidp_rsqn = { (int)obj_s["output1"]["bidp_rsqn1"], (int)obj_s["output1"]["bidp_rsqn2"], (int)obj_s["output1"]["bidp_rsqn3"],
				(int)obj_s["output1"]["bidp_rsqn4"], (int)obj_s["output1"]["bidp_rsqn5"], (int)obj_s["output1"]["bidp_rsqn6"], (int)obj_s["output1"]["bidp_rsqn7"],
				(int)obj_s["output1"]["bidp_rsqn8"], (int)obj_s["output1"]["bidp_rsqn9"], (int)obj_s["output1"]["bidp_rsqn10"]};

				//매수호가, 잔량으로 10주 팔 때 평단을 S라 할 것임.
				double S_sellingArbitrage = 0;
				int count2 = 0;
				for (int i = 0; i < 10; i++)
				{
					if (count2 < 10)
					{
						count2 += stock_bidp_rsqn[i];

						if (count <= 10)
						{
							S_sellingArbitrage += stock_bidp[i] * stock_bidp_rsqn[i];
						}
						else
						{
							S_sellingArbitrage += stock_bidp[i] * (10 - count2 + stock_bidp_rsqn[i]);
							break;
						}
					}
					else
					{
						break;
					}
				}
				//평단 완성
				S_sellingArbitrage /= 10;

				//현물 매도 평단을 S로 하여 선물이론가격 도출
				double book_value2 = (S_sellingArbitrage + 2 * k) * (1 + r_lending * (T / 365));
				//이론가격보다 선물매수호가중 가장 높은 것 ( 선물매도할 때 받을 수 있는 최대가격 )이 이론가격보다 크면 매수차익거래 가능
				if (book_value2 > futs_askp[0])
				{
					System.Console.WriteLine("매도차익거래 기회 나옴!!!!!!!!!!!!!!!");
					System.Console.WriteLine(book_value2 - futs_askp[0]);
				}
				System.Console.WriteLine("매도차익거래 기회 나옴을 나옴!!!!!!!!!!!!!!!");

				//얼마의 차익을 얻을 수 있는지 보냄


				//chart3 
				// 매수차익거래 선물 이론가격
				chart6.Series["선물매수1호가"].Points.AddXY(x6, futs_bidp[0] );

				chart6.Series["선물매도1호가"].Points.AddXY(x6, futs_askp[0] );

				// 매수차익거래 선물 매수1호가 ( 내가 매도할 가격 )
				chart6.Series["매수차익 하한(이론가)"].Points.AddXY(x6, book_value );
				chart6.Series["매도차익 상한(이론가)"].Points.AddXY(x6, book_value2 );

				//매수차익거래 가능!!!
				if (futs_bidp[0] > book_value)
				{
					//showAlert("매수차익거래 가능");
				}
				//매도차익거래 가능!!
				if (futs_askp[0] < book_value2)
				{
					//showAlert("매도차익거래 가능");
				}

				if (chart6.Series["선물매수1호가"].Points.Count > 500)
				{
					chart6.Series["선물매수1호가"].Points.RemoveAt(0);
					chart6.Series["선물매도1호가"].Points.RemoveAt(0);
					chart6.Series["매수차익 하한(이론가)"].Points.RemoveAt(0);
					chart6.Series["매도차익 상한(이론가)"].Points.RemoveAt(0);

				}
				chart6.ChartAreas[0].AxisX.Minimum = chart6.Series["선물매수1호가"].Points[0].XValue;
				chart6.ChartAreas[0].AxisX.Maximum = 50;
				chart6.ChartAreas[0].AxisY.Minimum = Math.Min(Math.Min(Math.Min(book_value, book_value2), futs_bidp[0]), futs_askp[0]) - 10000;
				chart6.ChartAreas[0].AxisY.Maximum = Math.Max(Math.Max(Math.Max(book_value, book_value2), futs_bidp[0]), futs_askp[0]) + 10000;
				x6 += 0.1; //그래프 상 오른쪽에 그려야하므로
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"ex.Message={ex.Message}");
				Console.WriteLine($"ex.InnerException.Message = {ex.InnerException.Message}");

				Console.WriteLine($"----------- 서버에 연결할수없습니다 ---------------------");
			}
			catch (Exception ex2)
			{
				Console.WriteLine($"Exception={ex2.Message}");
			}
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			
			string URL = "http://127.0.0.1:5000/total";

			test1( r_lending,  r_borrow,  T);
			test2(r_lending, r_borrow, T);
            test3(r_lending, r_borrow, T);
			test4(r_lending, r_borrow, T);
			test5(r_lending, r_borrow, T);
			test6(r_lending, r_borrow, T);


			/*using (WebClient wc = new WebClient())
			{
                var json = new WebClient().DownloadString(URL);
                
				//Console.WriteLine(json.ToString());
                Console.WriteLine(json.GetType().Name);
                Console.WriteLine(json[0]);
			}*/



			/* HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
			 HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			 Stream stream = response.GetResponseStream();
			 StreamReader reader = new StreamReader(stream, Encoding.UTF8);
			 string text = reader.ReadToEnd();

			 JObject obj = JObject.Parse(text);

			 string notice = obj["S_buyingArbitrage"].ToString();
			 Console.WriteLine(notice);*/

			/*
			//chart1관련
			chart1.Series["선물매수1호가"].Points.AddXY(x, 3 * Math.Sin(5 * x) + 5 * Math.Cos(3 * x));

			if (chart1.Series["선물매수1호가"].Points.Count > 100)
				chart1.Series["선물매수1호가"].Points.RemoveAt(0);

			chart1.ChartAreas[0].AxisX.Minimum = chart1.Series["선물매수1호가"].Points[0].XValue;
			chart1.ChartAreas[0].AxisX.Maximum = x;

			x += 0.1;

			//chart2 엑셀데이터 뿌리기
			chart2.Series["선물매수1호가"].Points.AddXY(x2, numbers[x2idx]);
			chart2.Series["Futures"].Points.AddXY(x2, futures[x2idx]);
            if (numbers[x2idx] > futures[x2idx])
            {
                showAlert("");
            }

            if (chart2.Series["선물매수1호가"].Points.Count > 1000)
			{
                chart2.Series["선물매수1호가"].Points.RemoveAt(0);
				chart2.Series["Futures"].Points.RemoveAt(0);

            }

            //chart2.ChartAreas[0].AxisX.Minimum = chart2.Series["선물매수1호가"].Points[0].XValue;
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = 100;
			chart2.ChartAreas[0].AxisY.Minimum = 0;
			chart2.ChartAreas[0].AxisY.Maximum = 3000;

            x2idx++;// 다음인덱스 가리켜야하므로
			x2 += 0.1; //그래프 상 오른쪽에 그려야하므로
			*/

		}

		private void label11_Click(object sender, EventArgs e)
		{

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
