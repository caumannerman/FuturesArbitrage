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
using Microsoft.Office.Interop.Excel;

namespace FuturesArbitrage
{
    public partial class myasset : Form
    {
        string access_token = "Bearer " + "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJ0b2tlbiIsImF1ZCI6IjkyMjY1ZTk3LWQwYmMtNGJlMy1hOTljLTc2ZDMwMDQ2MTgyYyIsImlzcyI6InVub2d3IiwiZXhwIjoxNjk5OTIwNjg5LCJpYXQiOjE2OTk4MzQyODksImp0aSI6IlBTYnJpOVQyOThWeXhmSjAwNHg5TW5DUW54N2dLSlI4djY1OCJ9.YRk48LVCgZtWOdSJ2LaHsA48GfjB_MadEkYRhHX1C8AJ3kjgDOj3RDhg73cfrDYhlgxH2dxuvuPZfAFzLQGu5g";
        //현재 선택된 북코드와 북 이름
        // Default는 CJ ENM
        private string now_book_code = "KR7035760008";
        private string now_stock_name = "CJ ENM";
        private string now_stock_code = "035760";
        private string now_futures_code = "1DTT12000";
        private string now_date = "231030";

        static string[] book_code = { "KR7035760008", "KR7097950000", "KR7002380004", "KR7373220003", "KR7011070000", "KR7011780004", "KR7138040001", "KR7010140002", "KR7066970005", "KR7271560005", "KR7122870009", "KR7039030002", "KR7377300009", "KR7091700005", "KR7015760002", "KR701880005", "KR7064350002", "KR7012330007" };
        static string[] stock_name = { "CJ ENM", "CJ 제일제당", "KCC", "LG에너지솔루션", "LG이노텍", "금호석유", "메리츠금융지주", "삼성중공업", "엘앤에프", "오리온", "와이지엔터테인먼트", "이오테크닉스", "카카오페이", "파트론", "한국전력", "한온시스템", "현대로템", "현대모비스" };
        static string[] stock_code = {"035760", "097950", "002380", "373220", "011070", "011780", "138040", "010140", "066970", "271560", "122870", "039030", "377300", "091700", "015760", "018880", "064350", "012330"};
        static string[] futures_code = {"1DTT12000", "1D1T12000", "1D3T12000", "1F5T12000", "1BYT12000", "1C3T12000", "1FKT12000", "1BFT12000", "1FMT12000", "1FJT12000", "1CQT12000", "1GCT12000", "1F7T12000", "1E3T12000", "115T12000", "1CYT12000", "1G6T12000", "120T12000" };
        // 우리가 활용하는 날짜들
        string[] date_arr = { "231030", "231031", "231101", "231102" };
        
        ///////////////////////////////// 그래프 그리는 데 필요한 변수 ///////////////////////////////////////
        int k = 0;
        double r_lending = 0.04;
        double r_borrow = 0.06;
        int T = 6;
        //차익거래 차트 x축 좌표
        double arbt_chart_x = 0.0;

        //ㄹfep log의 id
        String former_log_id = "0"; 


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

            // API 5번 호출 ( 해당 종목,해당 날짜 수익 내역 GET 받아오기)
            api5_get_asset("M:"+this.now_book_code, this.now_date);

        }


        public myasset()
        {
            InitializeComponent();  

            /////////////////////////////////////////////////// 총 손익창 //////////////////////////////////////////////////
            ////첫 행 삭제
            asset_view.Columns.Clear();
            asset_view.Rows.Clear();
            asset_view.RowHeadersVisible = false;
            asset_view.Columns.Add("COL1", "종목명");
            asset_view.Columns.Add("COL2", "T이론가");
            asset_view.Columns.Add("COL3", "T평가금");
            asset_view.Columns.Add("COL4", "T실현손익");
            asset_view.Columns.Add("COL5", "누적 이론가");
            asset_view.Columns.Add("COL6", "총 평가금");
            asset_view.Columns.Add("COL7", "총 실현손익");
            asset_view.Columns.Add("COL8", "총 실현손익2");
            asset_view.Rows.Add("1", "1", "1", "1", "1", "1", "1", "1");




            /////////////////////////////////////////////////// 우리사 관리종목 현황창 //////////////////////////////////////////////////

            all_book_gridview.Rows.Clear();
            all_book_gridview.Columns.Clear();
            all_book_gridview.RowHeadersVisible = false;
            all_book_gridview.ColumnHeadersVisible = true;
            all_book_gridview.Columns.Add("COL1", "주식종목명 ");
            all_book_gridview.Columns.Add("COL2", "북코드");
            all_book_gridview.Columns.Add("COL3", "S종목코드  ");
            all_book_gridview.Columns.Add("COL4", "F종목코드  ");

            all_book_gridview.Columns.Add("COL5", "F청산가능수량 ");
            all_book_gridview.Columns.Add("COL6", "F평가금액 ");
            all_book_gridview.Columns.Add("COL7", "F평가손익 ");

            all_book_gridview.Columns.Add("COL8", "S보유수량 ");
            all_book_gridview.Columns.Add("COL9", "S평가금액 ");
            all_book_gridview.Columns.Add("COL10", "S평가손익");
            // col10과 col7의 합이다.
            all_book_gridview.Columns.Add("COL11", "북평가손익");
            for(int i = 0; i < book_code.Length; i++)
            {
                all_book_gridview.Rows.Add(stock_name[i], book_code[i], stock_code[i], futures_code[i], "", "", "", "", "", "", "");
            }


            /////////////////////////////////////////////////// 선물 호가창 //////////////////////////////////////////////////
            //기본 첫 열 삭제
            futures_order_chart.RowHeadersVisible = false;
            futures_order_chart.ColumnHeadersVisible = false;
            ////첫 행 삭제
            futures_order_chart.Columns.Clear();
            futures_order_chart.Rows.Clear();
            futures_order_chart.Columns.Add("COL1", "매도미체결건수");
            futures_order_chart.Columns.Add("COL2", "매도잔량");
            futures_order_chart.Columns.Add("COL3", "호가");
            futures_order_chart.Columns.Add("COL4", "매수잔량");
            futures_order_chart.Columns.Add("COL5", "매수미체결건수");
            futures_order_chart.Rows.Add("0", "0", "0", "", "");
            futures_order_chart.Rows.Add("0", "0", "0", "", "");
            futures_order_chart.Rows.Add("0", "0", "0", "", "");
            futures_order_chart.Rows.Add("0", "0", "0", "", "");
            futures_order_chart.Rows.Add("0", "0", "0", "", "");
            futures_order_chart.Rows.Add("", "", "0", "0", "0");
            futures_order_chart.Rows.Add("", "", "0", "0", "0");
            futures_order_chart.Rows.Add("", "", "0", "0", "0");
            futures_order_chart.Rows.Add("", "", "0", "0", "0");
            futures_order_chart.Rows.Add("", "", "0", "0", "0");
            
            for(int i = 0; i < 5; i++)
            {
                futures_order_chart[0, i].Style.BackColor = Color.FromArgb(190, 210, 255);
                futures_order_chart[1, i].Style.BackColor = Color.FromArgb(190, 210, 255);
                futures_order_chart[3, i + 5].Style.BackColor = Color.FromArgb(240, 180, 180);
                futures_order_chart[ 4, i+5].Style.BackColor = Color.FromArgb(240, 180, 180);
            }
            /////////////////////////////////////////////////// 선물 호가창 //////////////////////////////////////////////////


            /////////////////////////////////////////////////// 현물(주식) 호가창 //////////////////////////////////////////////////
            //기본 첫 열 삭제
            stock_order_chart.RowHeadersVisible = false;
            stock_order_chart.ColumnHeadersVisible = false;
            ////첫 행 삭제
            stock_order_chart.Columns.Clear();
            stock_order_chart.Rows.Clear();
            stock_order_chart.Columns.Add("COL1", "매도미체결건수");
            stock_order_chart.Columns.Add("COL2", "매도잔량");
            stock_order_chart.Columns.Add("COL3", "호가");
            stock_order_chart.Columns.Add("COL4", "매수잔량");
            stock_order_chart.Columns.Add("COL5", "매수미체결건수");
            stock_order_chart.Rows.Add("0", "0", "0", "", "");
            stock_order_chart.Rows.Add("0", "0", "0", "", "");
            stock_order_chart.Rows.Add("0", "0", "0", "", "");
            stock_order_chart.Rows.Add("0", "0", "0", "", "");
            stock_order_chart.Rows.Add("0", "0", "0", "", "");
            stock_order_chart.Rows.Add("", "", "0", "0", "0");
            stock_order_chart.Rows.Add("", "", "0", "0", "0");
            stock_order_chart.Rows.Add("", "", "0", "0", "0");
            stock_order_chart.Rows.Add("", "", "0", "0", "0");
            stock_order_chart.Rows.Add("", "", "0", "0", "0");
            /////////////////////////////////////////////////// 현물(주식) 호가창 //////////////////////////////////////////////////

            /////////////////////////////////////////////////// log view //////////////////////////////////////////////////
            //기본 첫 열 삭제
            fep_log_view.RowHeadersVisible = false;
            fep_log_view.ColumnHeadersVisible = true;
            ////첫 행 삭제
            fep_log_view.Columns.Clear();
            fep_log_view.Rows.Clear();
            fep_log_view.Columns.Add("COL1", "체결시각");
            fep_log_view.Columns.Add("COL2", "Book 코드");
            fep_log_view.Columns.Add("COL3", "isinCode");
            fep_log_view.Columns.Add("COL4", "체결수량");
            fep_log_view.Columns.Add("COL5", "체결가격");
            fep_log_view.Columns.Add("COL6", "주문번호");

            fep_log_view.Columns.Add("COL7", "메시지 길이");
            fep_log_view.Columns.Add("COL8", "메시지 타입");
            fep_log_view.Columns.Add("COL9", "응답코드");
            fep_log_view.Columns.Add("COL10", "메시지 번호");
            fep_log_view.Columns.Add("COL11", "메시지 개수");
            fep_log_view.Columns.Add("COL12", "계좌번호");
            fep_log_view.Columns.Add("COL13", "회원기준 체결번호");
            fep_log_view.Columns.Add("COL14", "체결유형코드");
            fep_log_view.Columns.Add("COL15", "최근월물체결가격");
            fep_log_view.Columns.Add("COL16", "차근월물체결가격");
            fep_log_view.Columns.Add("COL17", "매도/매수 구분코드");
            fep_log_view.Columns.Add("COL18", "보드ID");
            fep_log_view.Columns.Add("COL19", "보드ID");
            fep_log_view.Columns.Add("COL20", "보드ID");
            fep_log_view.Columns.Add("COL21", "보드ID");
            fep_log_view.Columns.Add("COL22", "보드ID");
            fep_log_view.Columns.Add("COL23", "보드ID");
            fep_log_view.Columns.Add("COL24", "visited"); fep_log_view.Columns.Add("COL25", "tableID");
            fep_log_view.Rows.Add("", "", "", "", "");
            

            //색상 변경 매수-red, 매도-blue
            for (int i = 0; i < 5; i++)
            {
                stock_order_chart[0, i].Style.BackColor = Color.FromArgb(190, 210, 255);
                stock_order_chart[1, i].Style.BackColor = Color.FromArgb(190, 210, 255);
                stock_order_chart[3, i + 5].Style.BackColor = Color.FromArgb(240, 180, 180);
                stock_order_chart[4, i + 5].Style.BackColor = Color.FromArgb(240, 180, 180);
            }
            /////////////////////////////////////////////////// 현물(주식) 호가창 //////////////////////////////////////////////////


            ////////////////////////////////////// 종목 선택 콤보박스 초기화 //////////////////////////////////////
            for (int i = 0; i < book_code.Length; i++)
            {
                data[i] = book_code[i] + "  " + stock_name[i];
            }
            //콤보 박스에 18개 종목 추가
            jongmokComboBox.Items.AddRange(data);
            //default는 순서 상 첫 종목 CJ ENM
            jongmokComboBox.Text = now_book_code + "  " + now_stock_name;

            dateComboBox.Items.AddRange(date_arr);
            dateComboBox.Text = now_date;
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
            // DataGridView 기본 선택 셀 없애기
            futures_order_chart.ClearSelection();
            stock_order_chart.ClearSelection();
            asset_view.ClearSelection();
            all_book_gridview.ClearSelection();

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
            stock_chart_name.Text = this.now_stock_name;
            futures_chart_name.Text = this.now_stock_name;
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

        private void dateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            this.now_date = date_arr[cb.SelectedIndex];

            // API3번 호출 ( 해당 종목, 날짜에서 받았던 로그만 visited30 GET 받아오기)

            
        }

        async void setup_asset_view()
        {
            
            //futures_order_chart.Rows[i].Cells[2].Value = futs_askp[4 - i];
            //static string[] book_code = { "KR7035760008", "KR7097950000", "KR7002380004", "KR7373220003", "KR7011070000", "KR7011780004", "KR7138040001", "KR7010140002", "KR7066970005", "KR7271560005", "KR7122870009", "KR7039030002", "KR7377300009", "KR7091700005", "KR7015760002", "KR701880005", "KR7064350002", "KR7012330007" };
            //static string[] stock_name = { "CJ ENM", "CJ 제일제당", "KCC", "LG에너지솔루션", "LG이노텍", "금호석유", "메리츠금융지주", "삼성중공업", "엘앤에프", "오리온", "와이지엔터테인먼트", "이오테크닉스", "카카오페이", "파트론", "한국전력", "한온시스템", "현대로템", "현대모비스" };
            //static string[] stock_code = { "035760", "097950", "002380", "373220", "011070", "011780", "138040", "010140", "066970", "271560", "122870", "039030", "377300", "091700", "015760", "018880", "064350", "012330" };
            //static string[] futures_code = {"1DTT12000", "1D1T12000", "1D3T12000", "1F5T12000", "1BYT12000", "1C3T12000", "
            try
            {
                //주식 잔고조회
                string URL = "https://openapi.koreainvestment.com:9443/uapi/domestic-stock/v1/trading/inquire-balance?CANO=73085780&ACNT_PRDT_CD=01&AFHR_FLPR_YN=N&OFL_YN&INQR_DVSN=02&UNPR_DVSN=01&FUND_STTL_ICLD_YN=N&FNCG_AMT_AUTO_RDPT_YN=N&PRCS_DVSN=00&CTX_AREA_FK100&CTX_AREA_NK100";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Headers.Add("Authorization", access_token);
                request.Headers.Add("appkey", "PSbri9T298VyxfJ004x9MnCQnx7gKJR8v658");
                request.Headers.Add("appsecret", "VUn2CzaKPT1oTzwfBiXlY2ASg8SEndHMk/h5ukdZOElQVP5dfnfnv3OiTqw3aKYGR1NRYg17q05zOFlFhW8CdwYzMPI2wmqB9cNgx2f03O1ROveEw6Kr/CeGojxZBPMVU2MMzun4Gapcq1zu+lWYhbkDK/fAfmeCD+ftD2WMWPrJw9UBG0c=");
                request.Headers.Add("tr_id", "TTTC8434R");
                HttpWebResponse response_s = (HttpWebResponse)request.GetResponse();
                Stream stream_s = response_s.GetResponseStream();
                StreamReader reader_s = new StreamReader(stream_s, Encoding.UTF8);
                string text_s = reader_s.ReadToEnd();
                JObject obj_s = JObject.Parse(text_s);


                // 주식 종목명, 북코드, S종목콛, F종목코드, F청산가능수량, F평가금액, f평가손익, S보유수량, S평가금액, S평가손익


                // for문 돌면서 18개 종목에 대하여 출력해줘야함.
                // 주식 보유수량 obj_s["output1"]["hldg_qty"]
                // 주식 평가금액 obj_s["output1"]["evlu_amt"]
                // 주식 평가손익금액 obj_s["output1"]["evlu_pfls_amt"]

                for (int i = 0; i < book_code.Length; i++)
                {
                    all_book_gridview.Rows[i].Cells[7].Value = obj_s["output1"]["hldg_qty"];
                    all_book_gridview.Rows[i].Cells[8].Value = obj_s["output1"]["evlu_amt"];
                    all_book_gridview.Rows[i].Cells[9].Value = obj_s["output1"]["evlu_pfls_amt"];
                }

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


        // Spring Boot API 5가지.

        // API 1번
        async void api1_get_log(String bookcode, String date)
        {
            try
            {
                //주식 매수매도 호가
                string URL = "http://127.0.0.1:8080/api/v1/get/notvisited1?bookcode=" + bookcode + "&date=" + date;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string text = reader.ReadToEnd();
                JObject obj = JObject.Parse(text);

                fep_log_view.Rows.Insert(0, obj["strdTime"], obj["sbookCode"], obj["sissueCode"], obj["strdQty"], obj["strdPrice"], obj["sorderNo"], obj["smsgGb"],
                    obj["sseq"], obj["sacctNo"], obj["id"], obj["slength"], obj["strCode"], obj["sdataCnt"], obj["srpCode"], obj["strdNo"],
                    obj["strdType"], obj["sfarTrdPrice"], obj["sside"], obj["sbalanceType"], obj["sfiller"], obj["spurpose"], obj["snearTrdPrice"], obj["sdontknow"], obj["visited"], obj["id"]);
                //API2번이 patch를 보내야하기 때문에 id를 저장.
                this.former_log_id = (String) obj["id"];
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

        // API 2번
        // 직전에 받아온 log의 id를 사용하여 해당 log를 받아온적 있다고 DB에 visited처리.
        async void api2_patch_log()
        {
            try
            {
                //주식 매수매도 호가
                string URL = "http://127.0.0.1:8080/api/v1/patch/logvisited?id=" + this.former_log_id;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "PATCH";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string text = reader.ReadToEnd();
                JObject obj = JObject.Parse(text);

                // visited 된 것 차트에 수정해주기.
                fep_log_view.Rows.Insert(0, obj["strdTime"], obj["sbookCode"], obj["sissueCode"], obj["strdQty"], obj["strdPrice"], obj["sorderNo"], obj["smsgGb"],
                    obj["sseq"], obj["sacctNo"], obj["id"], obj["slength"], obj["strCode"], obj["sdataCnt"], obj["srpCode"], obj["strdNo"],
                    obj["strdType"], obj["sfarTrdPrice"], obj["sside"], obj["sbalanceType"], obj["sfiller"], obj["spurpose"], obj["snearTrdPrice"], obj["sdontknow"], obj["visited"], obj["id"]);

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


        // API 5번
        async void api5_get_asset(String bookcode, String date)
        {
            try
            {
                //주식 매수매도 호가
                string URL = "http://127.0.0.1:8080/api/v1/get/totalasset?bookcode=" + bookcode + "&date=" + date;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string text = reader.ReadToEnd();
                JObject obj = JObject.Parse(text);

                asset_view.Rows[0].Cells[1].Value = obj["buyquantity"];
                asset_view.Rows[0].Cells[2].Value = obj["buytotalprice"];
                asset_view.Rows[0].Cells[3].Value = obj["sellquantity"];
                asset_view.Rows[0].Cells[4].Value = obj["selltotalprice"];
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

                //logDataGridView
                //매도호가 5개
                for(int i = 0; i < 5; i++)
                {
                    ////////////////////////////////////// 선물 chart /////////////////////////////////
                    //매도호가 5개
                    futures_order_chart.Rows[i].Cells[2].Value = futs_askp[4-i];
                    //매수호가 5개
                    futures_order_chart.Rows[i + 5].Cells[2].Value = futs_bidp[i];
                    //매도호가잔량 5개
                    futures_order_chart.Rows[i].Cells[1].Value = futs_askp_rsqn[4 - i];
                    //매수호가잔량 5개
                    futures_order_chart.Rows[i+5].Cells[3].Value = futs_bidp_rsqn[i];

                }

                for(int i = 0; i < 5; i++)
                {
                    ////////////////////////////////////// 현물 chart /////////////////////////////////
                    //매도호가 10개
                    stock_order_chart.Rows[i].Cells[2].Value = stock_askp[4 - i];
                    //매수호가 10개
                    stock_order_chart.Rows[i + 5].Cells[2].Value = stock_bidp[i];
                    //매도호가잔량 10개
                    stock_order_chart.Rows[i].Cells[1].Value = stock_askp_rsqn[4 - i];
                    //매수호가잔량 10개
                    stock_order_chart.Rows[i + 5].Cells[3].Value = stock_bidp_rsqn[i];
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


        private void logDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            futures_order_chart.ClearSelection();
        }
        private void get_log_button_Click(object sender, EventArgs e)
        {

            // API 1번 호출.
            // 받은 적 없는 log를 받아와 따로 구조체 저장 없이 바로 row에 뿌려줌
            api1_get_log("M:" + this.now_book_code, this.now_date);

            //이제 방금 API 1번으로 받아온 로그에 대하여 DB상에 visited처리해줘야한다. (API 2번으로 PATCH)
            api2_patch_log();


        }

        

     
    }
}
