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
        private string now_futures_code = "1DTTB000";

        static string[] book_code = { "KR7035760008", "KR7097950000", "KR7002380004", "KR7373220003", "KR7011070000", "KR7011780004", "KR7138040001", "KR7010140002", "KR7066970005", "KR7271560005", "KR7122870009", "KR7039030002", "KR7377300009", "KR7091700005", "KR7015760002", "KR701880005", "KR7064350002", "KR7012330007" };
        static string[] stock_name = { "CJ ENM", "CJ 제일제당", "KCC", "LG에너지솔루션", "LG이노텍", "금호석유", "메리츠금융지주", "삼성중공업", "엘앤에프", "오리온", "와이지엔터테인먼트", "이오테크닉스", "카카오페이", "파트론", "한국전력", "한온시스템", "현대로템", "현대모비스" };
        static string[] stock_code = {"035760", "097950", "002380", "373220", "011070", "011780", "138040", "010140", "066970", "271560", "122870", "039030", "377300", "091700", "015760", "018880", "064350", "012330"};
        static string[] futures_code = {"1DTTB000", "1D1TB000", "1D3TB000", "1F5TB000", "1BYTB000", "1C3TB000", "1FKTB000", "1BFTB000", "1FMTB000", "1FJTB000", "1CQTB000", "1GCTB000", "1F7TB000", "1E3TB000", "115TB000", "1CYTB000", "1G6TB000", "120TB000" };

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
            listView1.Items[0].SubItems[0].Text = testint.ToString();
        }


        public myasset()
        {
            InitializeComponent();
            
            
            logDataGridView.Columns.Add("COL1", "ll1");
            logDataGridView.Columns.Add("COL2", "ll2");
            logDataGridView.Columns.Add("COL3", "ll3");
            logDataGridView.Columns.Add("COL4", "ll4");
            logDataGridView.Columns.Add("COL5", "ll5");
            logDataGridView.Rows.Add("ID 1", "제목 1번", "사용중", "2019/03/11", "2019/03/18");
            logDataGridView.Rows.Add("ID 2", "제목 2번", "미사용", "2019/03/12", "2019/03/18");
            logDataGridView.Rows.Add("ID 3", "제목 3번", "미사용", "2019/03/13", "2019/03/18");
            logDataGridView.Rows.Add("ID 4", "제목 4번", "사용중", "2019/03/14", "2019/03/18");
            logDataGridView.Rows.Add("ID 4", "제목 4번", "사용중", "2019/03/14", "2019/03/18");
            logDataGridView.Rows.Add("ID 4", "제목 4번", "사용중", "2019/03/14", "2019/03/18");
            logDataGridView.Rows.Add("ID 4", "제목 4번", "사용중", "2019/03/14", "2019/03/18");

            for (int i = 0; i < book_code.Length; i++)
            {
                data[i] = book_code[i] + "  " + stock_name[i];
            }
            //콤보 박스에 18개 종목 추가
            jongmokComboBox.Items.AddRange(data);
            jongmokComboBox.Text = now_book_code + "  " + now_stock_name;


        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            System.Console.WriteLine("load되엉ㅆ습니다.");
            timer1.Tick += timer1_Tick;
            timer1.Interval = 300;

            listBox1.Items.Add("VIP 회원");
            listBox1.Items.Add("정회원");
            listBox1.Items.Add("준회원");
            listBox1.Items.Add("일일 회원");
            listBox1.SelectedIndex = 1;

            listView1.GridLines = true;
            listView1.View = View.Details;
            listView1.Items.Clear();
            listView1.Columns.Clear();
            
            listView1.Columns.Add("매도호가", 250);

            String[] aa = { "10" };
            ListViewItem newitem = new ListViewItem(aa);
            newitem.SubItems.Add("99");
            newitem.SubItems.Add("88");
            listView1.Items.Add(newitem);
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
    }
        async void test1()
        {
            Console.WriteLine("잘 받고가세요8");
            try
            {
                //주식 매수매도 호가
                string URL = "https://openapi.koreainvestment.com:9443/uapi/domestic-stock/v1/quotations/inquire-asking-price-exp-ccn?FID_COND_MRKT_DIV_CODE=J&FID_INPUT_ISCD=017670";
                              
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
                string URL2 = "https://openapi.koreainvestment.com:9443/uapi/domestic-futureoption/v1/quotations/inquire-asking-price?FID_COND_MRKT_DIV_CODE=JF&FID_INPUT_ISCD=112T11000";
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
                future_buy5.Text = futs_bidp[4].ToString();



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
