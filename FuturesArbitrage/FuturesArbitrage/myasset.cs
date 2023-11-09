using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FuturesArbitrage
{
    public partial class myasset : Form
    {
        string access_token = "Bearer " + "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJ0b2tlbiIsImF1ZCI6IjNlMTA4NjY2LTM5M2YtNGY1YS05ZTU3LTBiMDY0YzFmZDRmOSIsImlzcyI6InVub2d3IiwiZXhwIjoxNjk5NTA1Nzg3LCJpYXQiOjE2OTk0MTkzODcsImp0aSI6IlBTYnJpOVQyOThWeXhmSjAwNHg5TW5DUW54N2dLSlI4djY1OCJ9.LNfdn7RbmwcmaXsOOEdpFmnN5XcTLuLuRJbzyjeO3P2zglJiVjyLMWOEdm5Q6dyZIjH7wLmwwcW5J70BodIwjg";
        //현재 선택된 북코드와 북 이름
        // Default는 CJ ENM
        private string now_book_code = "KR7035760008";
        private string now_stock_name = "CJ ENM";
        private string now_stock_code = "035760";
        private string now_futures_code = "1DTT11000";

        static string[] book_code = { "KR7035760008", "KR7097950000", "KR7002380004", "KR7373220003", "KR7011070000", "KR7011780004", "KR7138040001", "KR7010140002", "KR7066970005", "KR7271560005", "KR7122870009", "KR7039030002", "KR7377300009", "KR7091700005", "KR7015760002", "KR701880005", "KR7064350002", "KR7012330007" };
        static string[] stock_name = { "CJ ENM", "CJ 제일제당", "KCC", "LG에너지솔루션", "LG이노텍", "금호석유", "메리츠금융지주", "삼성중공업", "엘앤에프", "오리온", "와이지엔터테인먼트", "이오테크닉스", "카카오페이", "파트론", "한국전력", "한온시스템", "현대로템", "현대모비스" };
        static string[] stock_code = {"035760", "097950", "002380", "373220", "011070", "011780", "138040", "010140", "066970", "271560", "122870", "039030", "377300", "091700", "015760", "018880", "064350", "012330"};
        static string[] futures_code = {"1DTT11000", "1D1T11000", "1D3T11000", "1F5T11000", "1BYT11000", "1C3T11000", "1FKT11000", "1BFT11000", "1FMT11000", "1FJT11000", "1CQT11000", "1GCT11000", "1F7T11000", "1E3T11000", "115T11000", "1CYT11000", "1G6T11000", "120T11000" };
        ///////////////////////////////// 그래프 그리는 데 필요한 변수 ///////////////////////////////////////
        int k = 0;
        double r_lending = 0.04;
        double r_borrow = 0.06;
        int T = 6;
        //차익거래 차트 x축 좌표
        double arbt_chart_x = 0.0;


        //선물 매수호가1~5
        int[] futs_bidp = { 0,0,0,0,0 };
        //선물 매수호가잔량 1~5
        int[] futs_bidp_rsqn = { 0,0,0,0,0 };
        // 현물 매도호가1~10
        int[] stock_askp = { 0,0,0,0,0,0,0,0,0,0};
        // 현물 매도호가잔량1~10
        int[] stock_askp_rsqn = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        
        ////////////////////////////////// 매도차익거래  ///////////////////////////////
        //선물 매도호가1~5
        int[] futs_askp = { 0, 0, 0, 0, 0 };
        //선물 매도호가잔량 1~5
        int[] futs_askp_rsqn = { 0, 0, 0, 0, 0 };
        // 현물 매수호가1~10
        int[] stock_bidp = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        // 현물 매수호가잔량1~10
        int[] stock_bidp_rsqn = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        // 콤보박스에 한화투자증권에서 다루는 종목들을 추가
        string[] data = new string[book_code.Length];
        int testint = 10;
        // 바뀐 종목 코드, 선물 코드로 이곳에서 api와 엑셀 데이터를 DB에서 받아와 새로운 데이터를 화면에 뿌려줄 것임.
        private void timer1_Tick(object sender, EventArgs e)
        {
            /*getfuturestockprice(futs_bidp, futs_bidp_rsqn, stock_askp, stock_askp_rsqn, futs_askp, futs_askp_rsqn, stock_bidp, stock_bidp_rsqn);
            //선물 매도호가 변경
            future_sell1.Text = futs_askp[0].ToString();
            future_sell2.Text = futs_askp[1].ToString();
            future_sell3.Text = futs_askp[2].ToString();
            future_sell4.Text = futs_askp[3].ToString();
            future_sell5.Text = futs_askp[4].ToString();
            //선물 매수호가 변경
            future_buy1.Text = futs_bidp[0].ToString();
            future_buy2.Text = futs_bidp[1].ToString();
            future_buy3.Text = futs_bidp[2].ToString();
            future_buy4.Text = futs_bidp[3].ToString();
            future_buy5.Text = futs_bidp[4].ToString();*/

            test1();
            testint++;
            stock_sell_listview.Items[0].SubItems[0].Text = testint.ToString();
        }


        public myasset()
        {
            InitializeComponent();
            //기본 첫 열 삭제
            logDataGridView.RowHeadersVisible = false;
            logDataGridView.ColumnHeadersVisible = false;
            ////첫 행 삭제
            
            logDataGridView.Columns.Clear();
            logDataGridView.Rows.Clear();
            logDataGridView.Columns.Add("COL1", "매도미체결건수");
            logDataGridView.Columns.Add("COL2", "매도잔량");
            logDataGridView.Columns.Add("COL3", "호가");
            logDataGridView.Columns.Add("COL4", "매수잔량");
            logDataGridView.Columns.Add("COL5", "매수미체결건수");
            logDataGridView.Rows.Add("0", "0", "0", "0", "0");
            logDataGridView.Rows.Add("0", "0", "0", "0", "0");
            logDataGridView.Rows.Add("0", "0", "0", "0", "0");
            logDataGridView.Rows.Add("0", "0", "0", "0", "0");
            logDataGridView.Rows.Add("0", "0", "0", "0", "0");
            logDataGridView.Rows.Add("0", "0", "0", "0", "0");
            logDataGridView.Rows.Add("0", "0", "0", "0", "0");
            logDataGridView.Rows.Add("0", "0", "0", "0", "0");
            logDataGridView.Rows.Add("0", "0", "0", "0", "0");
            logDataGridView.Rows.Add("0", "0", "0", "0", "0");
            logDataGridView.Rows.Add("0", "0", "0", "0", "0");


            for (int i = 0; i < book_code.Length; i++)
            {
                data[i] = book_code[i] + "  " + stock_name[i];
            }
            //콤보 박스에 18개 종목 추가
            jongmokComboBox.Items.AddRange(data);
            jongmokComboBox.Text = now_book_code + "  " + now_stock_name;


        }
        private void init_chart()
        {
            ///////////////////////////////////////////////////// 차익거래 차트 설정 ////////////////////////////////////////////
            arbitrageChart.Series.Clear();
            arbitrageChart.Series.Add("선물매수1호가");
            arbitrageChart.Series["선물매수1호가"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            arbitrageChart.Series["선물매수1호가"].Color = Color.SkyBlue;

            // 선물 매도 1호가 (내가매수) -> 매도차익거래
            arbitrageChart.Series.Add("선물매도1호가");
            arbitrageChart.Series["선물매도1호가"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            arbitrageChart.Series["선물매도1호가"].Color = Color.DarkBlue;

            arbitrageChart.Series.Add("매수차익 하한(이론가)");
            arbitrageChart.Series["매수차익 하한(이론가)"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            arbitrageChart.Series["매수차익 하한(이론가)"].Color = Color.Red;

            arbitrageChart.Series.Add("매도차익 상한(이론가)");
            arbitrageChart.Series["매도차익 상한(이론가)"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            arbitrageChart.Series["매도차익 상한(이론가)"].Color = Color.Orange;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            System.Console.WriteLine("load되엉ㅆ습니다.");
            timer1.Tick += timer1_Tick;
            timer1.Interval = 300;
            init_chart();

            ///////////////////////////////////////////////////// 호가창 ////////////////////////////////////////////
            stock_sell_listview.GridLines = false;
            stock_sell_listview.View = View.Details;
            stock_sell_listview.Items.Clear();
            stock_sell_listview.Columns.Clear();
            stock_sell_listview.Columns.Add("매도호가", 150);

            String[] aa = { "10" };
            ListViewItem newitem = new ListViewItem(aa);
            //newitem.SubItems.Add("99");
            stock_sell_listview.Items.Add(newitem);

            //선물매도호가창
            futures_sell_listview.GridLines = true;
            futures_sell_listview.View = View.List;
            futures_sell_listview.Items.Clear();
            futures_sell_listview.Columns.Clear();
            futures_sell_listview.Columns.Add("선물매도호가", 150);
            futures_sell_listview.Scrollable = false;
            for( int i = 0; i < 5; i++)
            {
                futures_sell_listview.Items.Add(new ListViewItem());
                futures_sell_listview.Items[i].Text = "0";
            }
            //선물매도호가 잔량창
            futures_selljr_listview.GridLines = true;
            futures_selljr_listview.View = View.List;
            futures_selljr_listview.Items.Clear();
            futures_selljr_listview.Columns.Clear();
            futures_selljr_listview.Columns.Add("선물매도호가", 150);
            futures_selljr_listview.HeaderStyle = ColumnHeaderStyle.None;
            futures_selljr_listview.Scrollable = false;
            for (int i = 0; i < 5; i++)
            {
                futures_selljr_listview.Items.Add(new ListViewItem());
                futures_selljr_listview.Items[i].Text = "0";
            }
            //선물매수호가 
            futures_buy_listview.GridLines = true;
            futures_buy_listview.View = View.List;
            futures_buy_listview.Items.Clear();
            futures_buy_listview.Columns.Clear();
            futures_buy_listview.Columns.Add("선물매수호가", 150);
            futures_buy_listview.HeaderStyle = ColumnHeaderStyle.None;
            futures_buy_listview.Scrollable = false;
            for (int i = 0; i < 5; i++)
            {
                futures_buy_listview.Items.Add(new ListViewItem());
                futures_buy_listview.Items[i].Text = "0";
            }
            //선물매수호가 잔량
            futures_buyjr_listview.GridLines = true;
            futures_buyjr_listview.View = View.List;
            futures_buyjr_listview.Items.Clear();
            futures_buyjr_listview.Columns.Clear();
            futures_buyjr_listview.Columns.Add("선물매수호가 잔량", 150);
            futures_buyjr_listview.HeaderStyle = ColumnHeaderStyle.None;
            futures_buyjr_listview.Scrollable = false;
            for (int i = 0; i < 5; i++)
            {
                futures_buyjr_listview.Items.Add(new ListViewItem());
                futures_buyjr_listview.Items[i].Text = "0";
            }
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            /*SettingForm form = new SettingForm();
            this.Hide();
            this.Close();
            form.Show();*/
            timer1.Start();
        }

        private void jongmokComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            MessageBox.Show(cb.Items[cb.SelectedIndex].ToString());
            this.now_book_code = book_code[cb.SelectedIndex];
            this.now_stock_name = stock_name[cb.SelectedIndex];
            this.now_stock_code = stock_code[cb.SelectedIndex];
            this.now_futures_code = futures_code[cb.SelectedIndex];
            //바뀐 종목 이름으로 변경
            abtChart_name.Text = this.now_stock_name;
            //종목이 바뀌었으니 chart를 지우고 다시 그려야함
            arbitrageChart.Series.Clear();
            init_chart();
            arbt_chart_x = 0.0;
            //arbitrageChart.Series["선물매수1호가"].Points.Clear();

            //arbitrageChart.Series["선물매도1호가"].Points.Clear();

            // 매수차익거래 선물 매수1호가 ( 내가 매도할 가격 )
            //arbitrageChart.Series["매수차익 하한(이론가)"].Points.Clear();
            //arbitrageChart.Series["매도차익 상한(이론가)"].Points.Clear();
        }

        async void test1()
        {
            Console.WriteLine("잘 받고가세요8");
            Console.WriteLine(this.now_stock_code, this.now_futures_code);
            try
            {
                //주식 매수매도 호가
                //string URL = "https://openapi.koreainvestment.com:9443/uapi/domestic-stock/v1/quotations/inquire-asking-price-exp-ccn?FID_COND_MRKT_DIV_CODE=J&FID_INPUT_ISCD=017670";
                string URL = "https://openapi.koreainvestment.com:9443/uapi/domestic-stock/v1/quotations/inquire-asking-price-exp-ccn?FID_COND_MRKT_DIV_CODE=J&FID_INPUT_ISCD=" + this.now_stock_code;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Headers.Add("Authorization", access_token);
                request.Headers.Add("appkey", "PSbri9T298VyxfJ004x9MnCQnx7gKJR8v658");
                request.Headers.Add("appsecret", "VUn2CzaKPT1oTzwfBiXlY2ASg8SEndHMk/h5ukdZOElQVP5dfnfnv3OiTqw3aKYGR1NRYg17q05zOFlFhW8CdwYzMPI2wmqB9cNgx2f03O1ROveEw6Kr/CeGojxZBPMVU2MMzun4Gapcq1zu+lWYhbkDK/fAfmeCD+ftD2WMWPrJw9UBG0c=");
                request.Headers.Add("tr_id", "FHKST01010200");
                HttpWebResponse response_s = (HttpWebResponse)request.GetResponse();

                Stream stream_s = response_s.GetResponseStream();
                StreamReader reader_s = new StreamReader(stream_s, Encoding.UTF8);
                string text_s = reader_s.ReadToEnd();
                JObject obj_s = JObject.Parse(text_s);

                //선물 매수매도 호가
                //string URL2 = "https://openapi.koreainvestment.com:9443/uapi/domestic-futureoption/v1/quotations/inquire-asking-price?FID_COND_MRKT_DIV_CODE=JF&FID_INPUT_ISCD=112T11000";
                string URL2 = "https://openapi.koreainvestment.com:9443/uapi/domestic-futureoption/v1/quotations/inquire-asking-price?FID_COND_MRKT_DIV_CODE=JF&FID_INPUT_ISCD=" + this.now_futures_code;
                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(URL2);
                request2.Headers.Add("Authorization", access_token);
                request2.Headers.Add("appkey", "PSbri9T298VyxfJ004x9MnCQnx7gKJR8v658");
                request2.Headers.Add("appsecret", "VUn2CzaKPT1oTzwfBiXlY2ASg8SEndHMk/h5ukdZOElQVP5dfnfnv3OiTqw3aKYGR1NRYg17q05zOFlFhW8CdwYzMPI2wmqB9cNgx2f03O1ROveEw6Kr/CeGojxZBPMVU2MMzun4Gapcq1zu+lWYhbkDK/fAfmeCD+ftD2WMWPrJw9UBG0c=");
                request2.Headers.Add("tr_id", "FHMIF10010000");
                HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();

                Stream stream_f = response2.GetResponseStream();
                StreamReader reader_f = new StreamReader(stream_f, Encoding.UTF8);
                string text_f = reader_f.ReadToEnd();
                JObject obj_f = JObject.Parse(text_f);

                Console.WriteLine(text_s);
                Console.WriteLine("출력중.....");
                Console.WriteLine(text_f);


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

                //이론가격보다 선물매수호가중 가장 높은 것 ( 선물매도할 때 받을 수 있는 최대가격 )이 이론가격보다 크면 매수차익거래 가능

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
                
                // ListView 호가창 그리기 
                //선물 매도호가 
                for (int i = 0; i < 5; i++)
                {

                    futures_sell_listview.Items[i].Text = (futs_askp[4-i]).ToString();
                }
                //선물 매도호가잔량
                for (int i = 0; i < 5; i++)
                {
                    futures_selljr_listview.Items[i].Text = (futs_askp_rsqn[4 - i]).ToString();
                }
                //선물 매수호가
                for (int i = 0; i < 5; i++)
                {
                    futures_buy_listview.Items[i].Text = (futs_bidp[i]).ToString();
                }
                //선물 매수호가잔량
                for (int i = 0; i < 5; i++)
                {
                    futures_buyjr_listview.Items[i].Text = (futs_bidp_rsqn[i]).ToString();
                }


                //logDataGridView
                for(int i = 0; i < 5; i++)
                {
                    logDataGridView.Rows[0].Cells[i].Value = "11";
                }
                


                //////////////////////////////////////////   차트 그리기 /////////////////////////////////////////
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
                double book_value = (S_buyingArbitrage + 2 * k) * Math.Pow(1 + r_borrow, T / 365);

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
                double book_value2 = (S_sellingArbitrage + 2 * k) * Math.Pow(1 + r_lending, T / 365);


                //chart1
                // 매수차익거래 선물 이론가격
                arbitrageChart.Series["선물매수1호가"].Points.AddXY(arbt_chart_x, futs_bidp[0]);

                arbitrageChart.Series["선물매도1호가"].Points.AddXY(arbt_chart_x, futs_askp[0]);

                // 매수차익거래 선물 매수1호가 ( 내가 매도할 가격 )
                arbitrageChart.Series["매수차익 하한(이론가)"].Points.AddXY(arbt_chart_x, book_value);
                arbitrageChart.Series["매도차익 상한(이론가)"].Points.AddXY(arbt_chart_x, book_value2);
                System.Console.WriteLine(book_value2);
                System.Console.WriteLine(futs_askp[0]);
                System.Console.WriteLine(futs_bidp[0]);
                System.Console.WriteLine(book_value);

                //매수차익거래 가능!!!
                if (futs_bidp[0] > book_value)
                {
                    abtChart_contango.BackColor = Color.HotPink;
                }
                else
                {
                    abtChart_contango.BackColor = Color.DarkGray;
                }
                //매도차익거래 가능!!
                if (futs_askp[0] < book_value2)
                {
                    abtChart_backwardation.BackColor = Color.HotPink;
                }
                else
                {
                    abtChart_backwardation.BackColor = Color.DarkGray;
                }

                if (arbitrageChart.Series["선물매수1호가"].Points.Count >= 125)
                {
                    arbitrageChart.Series["선물매수1호가"].Points.RemoveAt(0);
                    arbitrageChart.Series["선물매도1호가"].Points.RemoveAt(0);
                    arbitrageChart.Series["매수차익 하한(이론가)"].Points.RemoveAt(0);
                    arbitrageChart.Series["매도차익 상한(이론가)"].Points.RemoveAt(0);

                }

                //chart2.ChartAreas[0].AxisX.Minimum = chart2.Series["선물매수1호가"].Points[0].XValue;
                arbitrageChart.ChartAreas[0].AxisX.Minimum = arbitrageChart.Series["선물매수1호가"].Points[0].XValue;
                arbitrageChart.ChartAreas[0].AxisX.Maximum = 50;
                arbitrageChart.ChartAreas[0].AxisY.Minimum = Math.Min(Math.Min(Math.Min(book_value, book_value2), futs_bidp[0]), futs_askp[0]) - 200;
                arbitrageChart.ChartAreas[0].AxisY.Maximum = Math.Max(Math.Max(Math.Max(book_value, book_value2), futs_bidp[0]), futs_askp[0]) + 200;

                arbt_chart_x += 0.4; //그래프 상 오른쪽에 그려야하므로


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

        async void getfuturestockprice(int[] futs_bidp, int[] futs_bidp_rsqn, int[] stock_askp, int[] stock_askp_rsqn, int[] futs_askp, int[] futs_askp_rsqn, int[] stock_bidp, int[] stock_bidp_rsqn)
        {
            try
            {
                //주식 매수매도 호가
                string URL = "https://openapi.koreainvestment.com:9443/uapi/domestic-stock/v1/quotations/inquire-asking-price-exp-ccn?FID_COND_MRKT_DIV_CODE=J&FID_INPUT_ISCD=005930";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Headers.Add("Authorization", access_token);
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
                request2.Headers.Add("Authorization", access_token);
                request2.Headers.Add("appkey", "PSbri9T298VyxfJ004x9MnCQnx7gKJR8v658");
                request2.Headers.Add("appsecret", "VUn2CzaKPT1oTzwfBiXlY2ASg8SEndHMk/h5ukdZOElQVP5dfnfnv3OiTqw3aKYGR1NRYg17q05zOFlFhW8CdwYzMPI2wmqB9cNgx2f03O1ROveEw6Kr/CeGojxZBPMVU2MMzun4Gapcq1zu+lWYhbkDK/fAfmeCD+ftD2WMWPrJw9UBG0c=");
                request2.Headers.Add("tr_id", "FHMIF10010000");
                HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
                Stream stream_f = response2.GetResponseStream();
                StreamReader reader_f = new StreamReader(stream_f, Encoding.UTF8);
                string text_f = reader_f.ReadToEnd();
                JObject obj_f = JObject.Parse(text_f);

                //선물 매수호가1~5
                int[] _futs_bidp = { (int)obj_f["output2"]["futs_bidp1"], (int)obj_f["output2"]["futs_bidp2"] , (int)obj_f["output2"]["futs_bidp3"] ,
                (int)obj_f["output2"]["futs_bidp4"], (int)obj_f["output2"]["futs_bidp5"] };
                futs_bidp = _futs_bidp;
                //선물 매수호가잔량 1~5
                int[] _futs_bidp_rsqn = { (int)obj_f["output2"]["bidp_rsqn1"], (int)obj_f["output2"]["bidp_rsqn2"] , (int)obj_f["output2"]["bidp_rsqn3"],
                (int)obj_f["output2"]["bidp_rsqn4"] ,(int)obj_f["output2"]["bidp_rsqn5"] };
                futs_bidp_rsqn = _futs_bidp_rsqn;
                // 현물 매도호가1~10
                int[] _stock_askp = { (int)obj_s["output1"]["askp1"], (int)obj_s["output1"]["askp2"], (int)obj_s["output1"]["askp3"],
                (int)obj_s["output1"]["askp4"], (int)obj_s["output1"]["askp5"], (int)obj_s["output1"]["askp6"], (int)obj_s["output1"]["askp7"],
                (int)obj_s["output1"]["askp8"], (int)obj_s["output1"]["askp9"], (int)obj_s["output1"]["askp10"]};
                stock_askp = _stock_askp;
                // 현물 매도호가잔량1~10
                int[] _stock_askp_rsqn = { (int)obj_s["output1"]["askp_rsqn1"], (int)obj_s["output1"]["askp_rsqn2"], (int)obj_s["output1"]["askp_rsqn3"],
                (int)obj_s["output1"]["askp_rsqn4"], (int)obj_s["output1"]["askp_rsqn5"], (int)obj_s["output1"]["askp_rsqn6"], (int)obj_s["output1"]["askp_rsqn7"],
                (int)obj_s["output1"]["askp_rsqn8"], (int)obj_s["output1"]["askp_rsqn9"], (int)obj_s["output1"]["askp_rsqn10"]};
                stock_askp_rsqn = _stock_askp_rsqn;
                ////////////////////////////////// 매도차익거래  ///////////////////////////////
                //선물 매도호가1~5
                int[] _futs_askp = { (int)obj_f["output2"]["futs_askp1"], (int)obj_f["output2"]["futs_askp2"] , (int)obj_f["output2"]["futs_askp3"] ,
                (int)obj_f["output2"]["futs_askp4"], (int)obj_f["output2"]["futs_askp5"] };
                futs_askp = _futs_askp;
                //선물 매도호가잔량 1~5
                int[] _futs_askp_rsqn = { (int)obj_f["output2"]["askp_rsqn1"], (int)obj_f["output2"]["askp_rsqn2"] , (int)obj_f["output2"]["askp_rsqn3"],
                (int)obj_f["output2"]["askp_rsqn4"] ,(int)obj_f["output2"]["askp_rsqn5"] };
                futs_askp_rsqn = _futs_askp_rsqn;
                // 현물 매수호가1~10
                int[] _stock_bidp = { (int)obj_s["output1"]["bidp1"], (int)obj_s["output1"]["bidp2"], (int)obj_s["output1"]["bidp3"],
                (int)obj_s["output1"]["bidp4"], (int)obj_s["output1"]["bidp5"], (int)obj_s["output1"]["bidp6"], (int)obj_s["output1"]["bidp7"],
                (int)obj_s["output1"]["bidp8"], (int)obj_s["output1"]["bidp9"], (int)obj_s["output1"]["bidp10"]};
                stock_bidp = _stock_bidp;
                // 현물 매수호가잔량1~10
                int[] _stock_bidp_rsqn = { (int)obj_s["output1"]["bidp_rsqn1"], (int)obj_s["output1"]["bidp_rsqn2"], (int)obj_s["output1"]["bidp_rsqn3"],
                (int)obj_s["output1"]["bidp_rsqn4"], (int)obj_s["output1"]["bidp_rsqn5"], (int)obj_s["output1"]["bidp_rsqn6"], (int)obj_s["output1"]["bidp_rsqn7"],
                (int)obj_s["output1"]["bidp_rsqn8"], (int)obj_s["output1"]["bidp_rsqn9"], (int)obj_s["output1"]["bidp_rsqn10"]};
                stock_bidp_rsqn = _stock_bidp_rsqn;


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

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }
    }
}
