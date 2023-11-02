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
            this.SuspendLayout();
            // 
            // myMoney
            // 
            this.myMoney.Location = new System.Drawing.Point(27, 38);
            this.myMoney.Name = "myMoney";
            this.myMoney.Size = new System.Drawing.Size(113, 25);
            this.myMoney.TabIndex = 0;
            this.myMoney.TextChanged += new System.EventHandler(this.myMoney_TextChanged);
            // 
            // fee_stock_buy
            // 
            this.fee_stock_buy.Location = new System.Drawing.Point(27, 120);
            this.fee_stock_buy.Name = "fee_stock_buy";
            this.fee_stock_buy.Size = new System.Drawing.Size(130, 25);
            this.fee_stock_buy.TabIndex = 1;
            this.fee_stock_buy.TextChanged += new System.EventHandler(this.fee_stock_buy_TextChanged);
            // 
            // labell
            // 
            this.labell.AutoSize = true;
            this.labell.Location = new System.Drawing.Point(25, 9);
            this.labell.Name = "labell";
            this.labell.Size = new System.Drawing.Size(67, 15);
            this.labell.TabIndex = 2;
            this.labell.Text = "운용자금";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 15);
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
            this.button2.Location = new System.Drawing.Point(27, 366);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(235, 72);
            this.button2.TabIndex = 8;
            this.button2.Text = "시뮬레이션 시작";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 15);
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
            this.fee_futures.Location = new System.Drawing.Point(347, 120);
            this.fee_futures.Name = "fee_futures";
            this.fee_futures.Size = new System.Drawing.Size(114, 25);
            this.fee_futures.TabIndex = 11;
            this.fee_futures.TextChanged += new System.EventHandler(this.fee_futures_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "excel 파일 선택";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(397, 395);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(380, 25);
            this.textBox5.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "주식 매수 수수료(%)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "주식 매도 수수료(%)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(493, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "증권 거래세 요율(%)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(344, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "선물계약 수수료";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(175, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "차입 이자율";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(298, 181);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 15);
            this.label10.TabIndex = 19;
            this.label10.Text = "대출 이자율";
            // 
            // fee_stock_sell
            // 
            this.fee_stock_sell.Location = new System.Drawing.Point(178, 120);
            this.fee_stock_sell.Name = "fee_stock_sell";
            this.fee_stock_sell.Size = new System.Drawing.Size(127, 25);
            this.fee_stock_sell.TabIndex = 22;
            this.fee_stock_sell.TextChanged += new System.EventHandler(this.fee_stock_sell_TextChanged);
            // 
            // stt_rate
            // 
            this.stt_rate.Location = new System.Drawing.Point(496, 120);
            this.stt_rate.Name = "stt_rate";
            this.stt_rate.Size = new System.Drawing.Size(142, 25);
            this.stt_rate.TabIndex = 23;
            this.stt_rate.TextChanged += new System.EventHandler(this.stt_rate_TextChanged);
            // 
            // norisk_interest_rate
            // 
            this.norisk_interest_rate.Location = new System.Drawing.Point(28, 215);
            this.norisk_interest_rate.Name = "norisk_interest_rate";
            this.norisk_interest_rate.Size = new System.Drawing.Size(112, 25);
            this.norisk_interest_rate.TabIndex = 24;
            this.norisk_interest_rate.TextChanged += new System.EventHandler(this.norisk_interest_rate_TextChanged);
            // 
            // borrow_interest_rate
            // 
            this.borrow_interest_rate.Location = new System.Drawing.Point(178, 215);
            this.borrow_interest_rate.Name = "borrow_interest_rate";
            this.borrow_interest_rate.Size = new System.Drawing.Size(93, 25);
            this.borrow_interest_rate.TabIndex = 25;
            this.borrow_interest_rate.TextChanged += new System.EventHandler(this.borrow_interest_rate_TextChanged);
            // 
            // loan_interest_rate
            // 
            this.loan_interest_rate.Location = new System.Drawing.Point(301, 215);
            this.loan_interest_rate.Name = "loan_interest_rate";
            this.loan_interest_rate.Size = new System.Drawing.Size(84, 25);
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
            this.comboBox1.Location = new System.Drawing.Point(28, 305);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(610, 23);
            this.comboBox1.TabIndex = 27;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Name = "SettingForm";
            this.Text = "SettingForm";
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
    }
}