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

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form1 form1 = new Form1();
			form1.Tag = this;
			form1.Show();
			this.Hide();
		}
	}
}
