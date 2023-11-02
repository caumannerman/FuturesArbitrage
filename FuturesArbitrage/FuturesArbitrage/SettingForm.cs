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
    public partial class SettingForm : Form
    {

        static public String sv_myMoney = "";
        static public String sv_fee_stock_buy = "";
        static public String sv_fee_stock_sell = "";
        static public String sv_fee_futures = "";
        static public String sv_stt_rate = "";
        static public String sv_norisk_interest_rate = "";
        static public String sv_borrow_interest_rate = "";
        static public String sv_loan_interest_rate = "";
        static public String sv_formula = "";
        static public String sv_filePath = "";

        public SettingForm()
        {
            InitializeComponent();
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Tag = this;
            form1.Show();
            this.Hide();
        }

        //컴퓨터에서 엑셀파일 선택하여 그 경로를 static 변수에 저장한다.
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                textBox5.Clear();
                textBox5.Text = OFD.FileName;
                sv_filePath = OFD.FileName;
            }
        }
        // 각 항목의 텍스트 입력창 입력내용이 변경될 때마다 static 변수에 변경해서 넣어주는 코드들

        private void myMoney_TextChanged(object sender, EventArgs e)
        {
            sv_myMoney = myMoney.Text;
        }

        private void fee_stock_buy_TextChanged(object sender, EventArgs e)
        {
            sv_fee_stock_buy = fee_stock_buy.Text;
        }

        private void fee_stock_sell_TextChanged(object sender, EventArgs e)
        {
            sv_fee_stock_sell = fee_stock_sell.Text;
        }

        private void fee_futures_TextChanged(object sender, EventArgs e)
        {
            sv_fee_futures = fee_futures.Text;
        }

        private void stt_rate_TextChanged(object sender, EventArgs e)
        {
            sv_stt_rate = stt_rate.Text;
        }

        private void norisk_interest_rate_TextChanged(object sender, EventArgs e)
        {
            sv_norisk_interest_rate = norisk_interest_rate.Text;
        }

        private void borrow_interest_rate_TextChanged(object sender, EventArgs e)
        {
            sv_borrow_interest_rate = borrow_interest_rate.Text;
        }

        private void loan_interest_rate_TextChanged(object sender, EventArgs e)
        {
            sv_loan_interest_rate = loan_interest_rate.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sv_formula = comboBox1.Text;
        }
    }
}
