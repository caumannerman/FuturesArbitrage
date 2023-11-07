using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuturesArbitrage
{
    public partial class myasset : Form
    {
        //현재 선택된 북코드와 북 이름
        // Default는 CJ ENM
        private string now_book_code = "KR7035760008";
        private string now_stock_name = "CJ ";

        static string[] book_code = { "KR7035760008", "KR7097950000", "KR7002380004", "KR7373220003", "KR7011070000", "KR7011780004", "KR7138040001", "KR7010140002", "KR7066970005", "KR7271560005", "KR7122870009", "KR7039030002", "KR7377300009", "KR7091700005", "KR7015760002", "KR701880005", "KR7064350002", "KR7012330007" };
        static string[] stock_name = { "CJ ENM", "CJ 제일제당", "KCC", "LG에너지솔루션", "LG이노텍", "금호석유", "메리츠금융지주", "삼성중공업", "엘앤에프", "오리온", "와이지엔터테인먼트", "이오테크닉스", "카카오페이", "파트론", "한국전력", "한온시스템", "현대로템", "현대모비스" };
        static string[] stock_code = {"035760", "097950", "002380", "373220", "011070", "011780", "138040", "010140", "066970", "271560", "122870", "039030", "377300", "091700", "015760", "018880", "064350", "012330"};
        static string[] futures_code = {"1DTTB000", "1D1TB000", "1D3TB000", "1F5TB000", "1BYTB000", "1C3TB000", "1FKTB000", "1BFTB000", "1FMTB000", "1FJTB000", "1CQTB000", "1GCTB000", "1F7TB000", "1E3TB000", "115TB000", "1CYTB000", "1G6TB000", "120TB000" };
        
        // 콤보박스에 한화투자증권에서 다루는 종목들을 추가
        string[] data = new string[book_code.Length];
           

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


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SettingForm form = new SettingForm();
            this.Hide();
            this.Close();
            form.Show();
        }

        private void jongmokComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            MessageBox.Show(cb.Items[cb.SelectedIndex].ToString());
            this.now_book_code = book_code[cb.SelectedIndex];
            this.now_stock_name = stock_name[cb.SelectedIndex];
        }
    }
}
