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
	public partial class ShowAlert : Form
	{
		public ShowAlert()
		{
			InitializeComponent();
		}

		private void ShowAlert_Load(object sender, EventArgs e)
		{

		}

		public enum enmAction
		{
			ignore,
			boom,
			close
		}

		private ShowAlert.enmAction action;

		private int x, y;

		private void exit_button_Click(object sender, EventArgs e)
		{
			timer1.Interval = 1;
			action = enmAction.close;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			switch (this.action)
			{
				case enmAction.ignore:
					timer1.Interval = 5000;
					action = enmAction.close;
					break;

				case enmAction.boom:
					timer1.Interval = 1;
					this.Opacity += 0.1;
					if(this.x < this.Location.X)
					{
						this.Left--;
					}
					else
					{
						if(this.Opacity == 1.0)
						{
							action = enmAction.ignore;
						}
					}
					break;
				case enmAction.close:
					timer1.Interval = 1;
					this.Opacity -= 0.1;
					this.Left -= 3;
					if (base.Opacity == 0.0)
					{
						base.Close();
					}
					break;
			}
		}

		public void showAlert(string msg)
		{
			this.Opacity = 0.0;
			this.StartPosition = FormStartPosition.Manual;
			string fname;

			for(int i=0;i<10; i++)
			{
				fname = "alert" + i.ToString();
				ShowAlert frm = (ShowAlert)Application.OpenForms[fname];

				if(frm == null)
				{
					this.Name = fname;
					this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
					this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i;
					this.Location = new Point(this.x, this.y);
					break;
				}
			}
			this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

			this.ignore_button.Text = msg;
			this.Show();
			this.action = enmAction.boom;

			this.timer1.Interval = 1;
			timer1.Start();

		}
	}
}
