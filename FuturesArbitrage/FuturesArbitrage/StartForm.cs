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
	public partial class StartForm : Form
	{
		public StartForm()
		{
			InitializeComponent();
		}
 
        private void StartForm_Load(object sender, EventArgs e)
		{
			System.Console.WriteLine("시작!!!!!!!");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			/*Form1 form1 = new Form1();
			form1.Tag = this;
			form1.Show();
			this.Hide();*/
		}

        private void button2_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.Tag = this;
            settingForm.Show();
			this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
			this.Close();
        }
    }
}
