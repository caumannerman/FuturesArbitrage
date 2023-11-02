namespace FuturesArbitrage
{
    partial class SettingForm
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
			this.myMoney = new System.Windows.Forms.TextBox();
			this.fee_stock_buy = new System.Windows.Forms.TextBox();
			this.labell = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.button2 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.fee_futures = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.fee_stock_sell = new System.Windows.Forms.TextBox();
			this.stt_rate = new System.Windows.Forms.TextBox();
			this.norisk_interest_rate = new System.Windows.Forms.TextBox();
			this.borrow_interest_rate = new System.Windows.Forms.TextBox();
			this.loan_interest_rate = new System.Windows.Forms.TextBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// myMoney
			// 
			this.myMoney.Location = new System.Drawing.Point(44, 61);
			this.myMoney.Margin = new System.Windows.Forms.Padding(5);
			this.myMoney.Name = "myMoney";
			this.myMoney.Size = new System.Drawing.Size(181, 35);
			this.myMoney.TabIndex = 0;
			this.myMoney.TextChanged += new System.EventHandler(this.myMoney_TextChanged);
			// 
			// fee_stock_buy
			// 
			this.fee_stock_buy.Location = new System.Drawing.Point(44, 192);
			this.fee_stock_buy.Margin = new System.Windows.Forms.Padding(5);
			this.fee_stock_buy.Name = "fee_stock_buy";
			this.fee_stock_buy.Size = new System.Drawing.Size(209, 35);
			this.fee_stock_buy.TabIndex = 1;
			this.fee_stock_buy.TextChanged += new System.EventHandler(this.fee_stock_buy_TextChanged);
			// 
			// labell
			// 
			this.labell.AutoSize = true;
			this.labell.Location = new System.Drawing.Point(41, 14);
			this.labell.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.labell.Name = "labell";
			this.labell.Size = new System.Drawing.Size(106, 24);
			this.labell.TabIndex = 2;
			this.labell.Text = "운용자금";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(39, 438);
			this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(266, 24);
			this.label3.TabIndex = 4;
			this.label3.Text = "선물이론가격 공식 선택";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button2.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.button2.ForeColor = System.Drawing.Color.White;
			this.button2.Location = new System.Drawing.Point(44, 586);
			this.button2.Margin = new System.Windows.Forms.Padding(5);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(382, 115);
			this.button2.TabIndex = 8;
			this.button2.Text = "시뮬레이션 시작";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(41, 290);
			this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(162, 24);
			this.label4.TabIndex = 9;
			this.label4.Text = "무위험 이자율";
			// 
			// contextMenuStrip2
			// 
			this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
			// 
			// fee_futures
			// 
			this.fee_futures.Location = new System.Drawing.Point(564, 192);
			this.fee_futures.Margin = new System.Windows.Forms.Padding(5);
			this.fee_futures.Name = "fee_futures";
			this.fee_futures.Size = new System.Drawing.Size(183, 35);
			this.fee_futures.TabIndex = 11;
			this.fee_futures.TextChanged += new System.EventHandler(this.fee_futures_TextChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(647, 586);
			this.button1.Margin = new System.Windows.Forms.Padding(5);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(213, 37);
			this.button1.TabIndex = 12;
			this.button1.Text = "excel 파일 선택";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(645, 632);
			this.textBox5.Margin = new System.Windows.Forms.Padding(5);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(615, 35);
			this.textBox5.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(39, 146);
			this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(231, 24);
			this.label5.TabIndex = 14;
			this.label5.Text = "주식 매수 수수료(%)";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(284, 146);
			this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(231, 24);
			this.label6.TabIndex = 15;
			this.label6.Text = "주식 매도 수수료(%)";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(801, 146);
			this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(231, 24);
			this.label7.TabIndex = 16;
			this.label7.Text = "증권 거래세 요율(%)";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(559, 146);
			this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(186, 24);
			this.label8.TabIndex = 17;
			this.label8.Text = "선물계약 수수료";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(284, 290);
			this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(138, 24);
			this.label9.TabIndex = 18;
			this.label9.Text = "차입 이자율";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(484, 290);
			this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(138, 24);
			this.label10.TabIndex = 19;
			this.label10.Text = "대출 이자율";
			// 
			// fee_stock_sell
			// 
			this.fee_stock_sell.Location = new System.Drawing.Point(289, 192);
			this.fee_stock_sell.Margin = new System.Windows.Forms.Padding(5);
			this.fee_stock_sell.Name = "fee_stock_sell";
			this.fee_stock_sell.Size = new System.Drawing.Size(204, 35);
			this.fee_stock_sell.TabIndex = 22;
			this.fee_stock_sell.TextChanged += new System.EventHandler(this.fee_stock_sell_TextChanged);
			// 
			// stt_rate
			// 
			this.stt_rate.Location = new System.Drawing.Point(806, 192);
			this.stt_rate.Margin = new System.Windows.Forms.Padding(5);
			this.stt_rate.Name = "stt_rate";
			this.stt_rate.Size = new System.Drawing.Size(228, 35);
			this.stt_rate.TabIndex = 23;
			this.stt_rate.TextChanged += new System.EventHandler(this.stt_rate_TextChanged);
			// 
			// norisk_interest_rate
			// 
			this.norisk_interest_rate.Location = new System.Drawing.Point(46, 344);
			this.norisk_interest_rate.Margin = new System.Windows.Forms.Padding(5);
			this.norisk_interest_rate.Name = "norisk_interest_rate";
			this.norisk_interest_rate.Size = new System.Drawing.Size(180, 35);
			this.norisk_interest_rate.TabIndex = 24;
			this.norisk_interest_rate.TextChanged += new System.EventHandler(this.norisk_interest_rate_TextChanged);
			// 
			// borrow_interest_rate
			// 
			this.borrow_interest_rate.Location = new System.Drawing.Point(289, 344);
			this.borrow_interest_rate.Margin = new System.Windows.Forms.Padding(5);
			this.borrow_interest_rate.Name = "borrow_interest_rate";
			this.borrow_interest_rate.Size = new System.Drawing.Size(149, 35);
			this.borrow_interest_rate.TabIndex = 25;
			this.borrow_interest_rate.TextChanged += new System.EventHandler(this.borrow_interest_rate_TextChanged);
			// 
			// loan_interest_rate
			// 
			this.loan_interest_rate.Location = new System.Drawing.Point(489, 344);
			this.loan_interest_rate.Margin = new System.Windows.Forms.Padding(5);
			this.loan_interest_rate.Name = "loan_interest_rate";
			this.loan_interest_rate.Size = new System.Drawing.Size(134, 35);
			this.loan_interest_rate.TabIndex = 26;
			this.loan_interest_rate.TextChanged += new System.EventHandler(this.loan_interest_rate_TextChanged);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
			this.comboBox1.Location = new System.Drawing.Point(46, 488);
			this.comboBox1.Margin = new System.Windows.Forms.Padding(5);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(989, 32);
			this.comboBox1.TabIndex = 27;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(744, 290);
			this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 24);
			this.label1.TabIndex = 28;
			this.label1.Text = "만기까지";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(746, 344);
			this.textBox1.Margin = new System.Windows.Forms.Padding(5);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(143, 35);
			this.textBox1.TabIndex = 29;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// SettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1300, 720);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.loan_interest_rate);
			this.Controls.Add(this.borrow_interest_rate);
			this.Controls.Add(this.norisk_interest_rate);
			this.Controls.Add(this.stt_rate);
			this.Controls.Add(this.fee_stock_sell);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.fee_futures);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.labell);
			this.Controls.Add(this.fee_stock_buy);
			this.Controls.Add(this.myMoney);
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "SettingForm";
			this.Text = "SettingForm";
			this.Load += new System.EventHandler(this.SettingForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox myMoney;
        private System.Windows.Forms.TextBox fee_stock_buy;
        private System.Windows.Forms.Label labell;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.TextBox fee_futures;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox fee_stock_sell;
        private System.Windows.Forms.TextBox stt_rate;
        private System.Windows.Forms.TextBox norisk_interest_rate;
        private System.Windows.Forms.TextBox borrow_interest_rate;
        private System.Windows.Forms.TextBox loan_interest_rate;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
	}
}