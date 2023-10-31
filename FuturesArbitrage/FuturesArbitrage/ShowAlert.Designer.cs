namespace FuturesArbitrage
{
	partial class ShowAlert
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.ignore_button = new System.Windows.Forms.Button();
            this.boom_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ignore_button
            // 
            this.ignore_button.BackColor = System.Drawing.Color.Firebrick;
            this.ignore_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ignore_button.Location = new System.Drawing.Point(52, 32);
            this.ignore_button.Name = "ignore_button";
            this.ignore_button.Size = new System.Drawing.Size(94, 32);
            this.ignore_button.TabIndex = 0;
            this.ignore_button.Text = "무시";
            this.ignore_button.UseVisualStyleBackColor = false;
            // 
            // boom_button
            // 
            this.boom_button.BackColor = System.Drawing.Color.Lime;
            this.boom_button.Location = new System.Drawing.Point(188, 32);
            this.boom_button.Name = "boom_button";
            this.boom_button.Size = new System.Drawing.Size(82, 32);
            this.boom_button.TabIndex = 1;
            this.boom_button.Text = "발사";
            this.boom_button.UseVisualStyleBackColor = false;
            // 
            // exit_button
            // 
            this.exit_button.BackColor = System.Drawing.Color.Red;
            this.exit_button.Location = new System.Drawing.Point(357, 5);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(23, 23);
            this.exit_button.TabIndex = 3;
            this.exit_button.Text = "X";
            this.exit_button.UseVisualStyleBackColor = false;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ShowAlert
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(382, 105);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.boom_button);
            this.Controls.Add(this.ignore_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowAlert";
            this.Text = "ShowAlert";
            this.Load += new System.EventHandler(this.ShowAlert_Load);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button ignore_button;
		private System.Windows.Forms.Button boom_button;
		private System.Windows.Forms.Button exit_button;
		private System.Windows.Forms.Timer timer1;
	}
}