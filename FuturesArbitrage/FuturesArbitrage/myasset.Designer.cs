namespace FuturesArbitrage
{
    partial class myasset
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.logDataGridView = new System.Windows.Forms.DataGridView();
            this.myAssetGridView = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.jongmokComboBox = new System.Windows.Forms.ComboBox();
            this.button17 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.future_sell5 = new System.Windows.Forms.Button();
            this.future_sell4 = new System.Windows.Forms.Button();
            this.future_sell3 = new System.Windows.Forms.Button();
            this.future_sell2 = new System.Windows.Forms.Button();
            this.future_sell1 = new System.Windows.Forms.Button();
            this.future_buy1 = new System.Windows.Forms.Button();
            this.future_buy2 = new System.Windows.Forms.Button();
            this.future_buy3 = new System.Windows.Forms.Button();
            this.future_buy4 = new System.Windows.Forms.Button();
            this.future_buy5 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAssetGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Location = new System.Drawing.Point(1064, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "돌아가기";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(472, 47);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(487, 282);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // logDataGridView
            // 
            this.logDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logDataGridView.Location = new System.Drawing.Point(12, 335);
            this.logDataGridView.Name = "logDataGridView";
            this.logDataGridView.RowHeadersWidth = 51;
            this.logDataGridView.RowTemplate.Height = 27;
            this.logDataGridView.Size = new System.Drawing.Size(524, 243);
            this.logDataGridView.TabIndex = 2;
            // 
            // myAssetGridView
            // 
            this.myAssetGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myAssetGridView.Location = new System.Drawing.Point(559, 335);
            this.myAssetGridView.Name = "myAssetGridView";
            this.myAssetGridView.RowHeadersWidth = 51;
            this.myAssetGridView.RowTemplate.Height = 27;
            this.myAssetGridView.Size = new System.Drawing.Size(524, 243);
            this.myAssetGridView.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(61, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(61, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(61, 87);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(61, 116);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(61, 145);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(61, 174);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 9;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(61, 203);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 10;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(61, 232);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 11;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(61, 261);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 12;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(61, 290);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 13;
            this.button11.Text = "button11";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(175, 29);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 14;
            this.button12.Text = "button12";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(175, 58);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 15;
            this.button13.Text = "button13";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(175, 87);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 16;
            this.button14.Text = "button14";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(175, 116);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 23);
            this.button15.TabIndex = 17;
            this.button15.Text = "button15";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(175, 145);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 23);
            this.button16.TabIndex = 18;
            this.button16.Text = "button16";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // jongmokComboBox
            // 
            this.jongmokComboBox.FormattingEnabled = true;
            this.jongmokComboBox.Location = new System.Drawing.Point(61, 0);
            this.jongmokComboBox.Name = "jongmokComboBox";
            this.jongmokComboBox.Size = new System.Drawing.Size(314, 23);
            this.jongmokComboBox.TabIndex = 20;
            this.jongmokComboBox.SelectedIndexChanged += new System.EventHandler(this.jongmokComboBox_SelectedIndexChanged);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(175, 174);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 23);
            this.button17.TabIndex = 21;
            this.button17.Text = "button17";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(175, 203);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(75, 23);
            this.button18.TabIndex = 22;
            this.button18.Text = "button18";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(175, 232);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(75, 23);
            this.button19.TabIndex = 23;
            this.button19.Text = "button19";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(175, 261);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(75, 23);
            this.button20.TabIndex = 24;
            this.button20.Text = "button20";
            this.button20.UseVisualStyleBackColor = true;
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(175, 290);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(75, 23);
            this.button21.TabIndex = 25;
            this.button21.Text = "button21";
            this.button21.UseVisualStyleBackColor = true;
            // 
            // future_sell5
            // 
            this.future_sell5.Location = new System.Drawing.Point(288, 41);
            this.future_sell5.Name = "future_sell5";
            this.future_sell5.Size = new System.Drawing.Size(75, 23);
            this.future_sell5.TabIndex = 26;
            this.future_sell5.Text = "future_sell5";
            this.future_sell5.UseVisualStyleBackColor = true;
            this.future_sell5.Click += new System.EventHandler(this.button22_Click);
            // 
            // future_sell4
            // 
            this.future_sell4.Location = new System.Drawing.Point(288, 70);
            this.future_sell4.Name = "future_sell4";
            this.future_sell4.Size = new System.Drawing.Size(75, 23);
            this.future_sell4.TabIndex = 27;
            this.future_sell4.Text = "future_sell4";
            this.future_sell4.UseVisualStyleBackColor = true;
            this.future_sell4.Click += new System.EventHandler(this.button23_Click);
            // 
            // future_sell3
            // 
            this.future_sell3.Location = new System.Drawing.Point(288, 99);
            this.future_sell3.Name = "future_sell3";
            this.future_sell3.Size = new System.Drawing.Size(75, 23);
            this.future_sell3.TabIndex = 28;
            this.future_sell3.Text = "future_sell3";
            this.future_sell3.UseVisualStyleBackColor = true;
            this.future_sell3.Click += new System.EventHandler(this.button24_Click);
            // 
            // future_sell2
            // 
            this.future_sell2.Location = new System.Drawing.Point(288, 128);
            this.future_sell2.Name = "future_sell2";
            this.future_sell2.Size = new System.Drawing.Size(75, 23);
            this.future_sell2.TabIndex = 29;
            this.future_sell2.Text = "future_sell2";
            this.future_sell2.UseVisualStyleBackColor = true;
            this.future_sell2.Click += new System.EventHandler(this.button25_Click);
            // 
            // future_sell1
            // 
            this.future_sell1.Location = new System.Drawing.Point(288, 157);
            this.future_sell1.Name = "future_sell1";
            this.future_sell1.Size = new System.Drawing.Size(75, 23);
            this.future_sell1.TabIndex = 30;
            this.future_sell1.Text = "future_sell1";
            this.future_sell1.UseVisualStyleBackColor = true;
            this.future_sell1.Click += new System.EventHandler(this.button26_Click);
            // 
            // future_buy1
            // 
            this.future_buy1.Location = new System.Drawing.Point(376, 187);
            this.future_buy1.Name = "future_buy1";
            this.future_buy1.Size = new System.Drawing.Size(75, 23);
            this.future_buy1.TabIndex = 31;
            this.future_buy1.Text = "future_buy1";
            this.future_buy1.UseVisualStyleBackColor = true;
            this.future_buy1.Click += new System.EventHandler(this.button27_Click);
            // 
            // future_buy2
            // 
            this.future_buy2.Location = new System.Drawing.Point(376, 216);
            this.future_buy2.Name = "future_buy2";
            this.future_buy2.Size = new System.Drawing.Size(75, 23);
            this.future_buy2.TabIndex = 32;
            this.future_buy2.Text = "future_buy2";
            this.future_buy2.UseVisualStyleBackColor = true;
            // 
            // future_buy3
            // 
            this.future_buy3.Location = new System.Drawing.Point(376, 245);
            this.future_buy3.Name = "future_buy3";
            this.future_buy3.Size = new System.Drawing.Size(75, 23);
            this.future_buy3.TabIndex = 33;
            this.future_buy3.Text = "future_buy3";
            this.future_buy3.UseVisualStyleBackColor = true;
            // 
            // future_buy4
            // 
            this.future_buy4.Location = new System.Drawing.Point(376, 274);
            this.future_buy4.Name = "future_buy4";
            this.future_buy4.Size = new System.Drawing.Size(75, 23);
            this.future_buy4.TabIndex = 34;
            this.future_buy4.Text = "future_buy4";
            this.future_buy4.UseVisualStyleBackColor = true;
            // 
            // future_buy5
            // 
            this.future_buy5.Location = new System.Drawing.Point(376, 300);
            this.future_buy5.Name = "future_buy5";
            this.future_buy5.Size = new System.Drawing.Size(75, 23);
            this.future_buy5.TabIndex = 35;
            this.future_buy5.Text = "future_buy5";
            this.future_buy5.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(974, 48);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(250, 259);
            this.listView1.TabIndex = 36;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listBox1
            // 
            this.listBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(1103, 335);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 94);
            this.listBox1.TabIndex = 37;
            // 
            // myasset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 590);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.future_buy5);
            this.Controls.Add(this.future_buy4);
            this.Controls.Add(this.future_buy3);
            this.Controls.Add(this.future_buy2);
            this.Controls.Add(this.future_buy1);
            this.Controls.Add(this.future_sell1);
            this.Controls.Add(this.future_sell2);
            this.Controls.Add(this.future_sell3);
            this.Controls.Add(this.future_sell4);
            this.Controls.Add(this.future_sell5);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.jongmokComboBox);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.myAssetGridView);
            this.Controls.Add(this.logDataGridView);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button1);
            this.Name = "myasset";
            this.Text = "myasset";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAssetGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView logDataGridView;
        private System.Windows.Forms.DataGridView myAssetGridView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.ComboBox jongmokComboBox;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button future_sell5;
        private System.Windows.Forms.Button future_sell4;
        private System.Windows.Forms.Button future_sell3;
        private System.Windows.Forms.Button future_sell2;
        private System.Windows.Forms.Button future_sell1;
        private System.Windows.Forms.Button future_buy1;
        private System.Windows.Forms.Button future_buy2;
        private System.Windows.Forms.Button future_buy3;
        private System.Windows.Forms.Button future_buy4;
        private System.Windows.Forms.Button future_buy5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListBox listBox1;
    }
}