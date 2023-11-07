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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SettingForm form = new SettingForm();
            this.Hide();
            this.Close();
            form.Show();
        }
    }
}
