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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.logDataGridView = new System.Windows.Forms.DataGridView();
            this.myAssetGridView = new System.Windows.Forms.DataGridView();
            this.jongmokComboBox = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.stock_sell_listview = new System.Windows.Forms.ListView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.stock_buy_listview = new System.Windows.Forms.ListView();
            this.futures_sell_listview = new System.Windows.Forms.ListView();
            this.futures_buy_listview = new System.Windows.Forms.ListView();
            this.futures_selljr_listview = new System.Windows.Forms.ListView();
            this.futures_buyjr_listview = new System.Windows.Forms.ListView();
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
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart1.Legends.Add(legend7);
            this.chart1.Location = new System.Drawing.Point(596, 47);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chart1.Series.Add(series7);
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
            // jongmokComboBox
            // 
            this.jongmokComboBox.FormattingEnabled = true;
            this.jongmokComboBox.Location = new System.Drawing.Point(61, 0);
            this.jongmokComboBox.Name = "jongmokComboBox";
            this.jongmokComboBox.Size = new System.Drawing.Size(314, 23);
            this.jongmokComboBox.TabIndex = 20;
            this.jongmokComboBox.SelectedIndexChanged += new System.EventHandler(this.jongmokComboBox_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // stock_sell_listview
            // 
            this.stock_sell_listview.HideSelection = false;
            this.stock_sell_listview.Location = new System.Drawing.Point(61, 29);
            this.stock_sell_listview.Name = "stock_sell_listview";
            this.stock_sell_listview.Size = new System.Drawing.Size(78, 147);
            this.stock_sell_listview.TabIndex = 36;
            this.stock_sell_listview.UseCompatibleStateImageBehavior = false;
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
            // stock_buy_listview
            // 
            this.stock_buy_listview.HideSelection = false;
            this.stock_buy_listview.Location = new System.Drawing.Point(143, 182);
            this.stock_buy_listview.Name = "stock_buy_listview";
            this.stock_buy_listview.Size = new System.Drawing.Size(78, 147);
            this.stock_buy_listview.TabIndex = 38;
            this.stock_buy_listview.UseCompatibleStateImageBehavior = false;
            // 
            // futures_sell_listview
            // 
            this.futures_sell_listview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.futures_sell_listview.GridLines = true;
            this.futures_sell_listview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.futures_sell_listview.HideSelection = false;
            this.futures_sell_listview.Location = new System.Drawing.Point(282, 29);
            this.futures_sell_listview.Name = "futures_sell_listview";
            this.futures_sell_listview.Scrollable = false;
            this.futures_sell_listview.Size = new System.Drawing.Size(78, 147);
            this.futures_sell_listview.TabIndex = 39;
            this.futures_sell_listview.UseCompatibleStateImageBehavior = false;
            // 
            // futures_buy_listview
            // 
            this.futures_buy_listview.HideSelection = false;
            this.futures_buy_listview.Location = new System.Drawing.Point(367, 182);
            this.futures_buy_listview.Name = "futures_buy_listview";
            this.futures_buy_listview.Size = new System.Drawing.Size(78, 147);
            this.futures_buy_listview.TabIndex = 40;
            this.futures_buy_listview.UseCompatibleStateImageBehavior = false;
            // 
            // futures_selljr_listview
            // 
            this.futures_selljr_listview.HideSelection = false;
            this.futures_selljr_listview.Location = new System.Drawing.Point(244, 29);
            this.futures_selljr_listview.Name = "futures_selljr_listview";
            this.futures_selljr_listview.Size = new System.Drawing.Size(33, 147);
            this.futures_selljr_listview.TabIndex = 41;
            this.futures_selljr_listview.UseCompatibleStateImageBehavior = false;
            // 
            // futures_buyjr_listview
            // 
            this.futures_buyjr_listview.HideSelection = false;
            this.futures_buyjr_listview.Location = new System.Drawing.Point(451, 182);
            this.futures_buyjr_listview.Name = "futures_buyjr_listview";
            this.futures_buyjr_listview.Size = new System.Drawing.Size(33, 147);
            this.futures_buyjr_listview.TabIndex = 42;
            this.futures_buyjr_listview.UseCompatibleStateImageBehavior = false;
            // 
            // myasset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 590);
            this.Controls.Add(this.futures_buyjr_listview);
            this.Controls.Add(this.futures_selljr_listview);
            this.Controls.Add(this.futures_buy_listview);
            this.Controls.Add(this.futures_sell_listview);
            this.Controls.Add(this.stock_buy_listview);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.stock_sell_listview);
            this.Controls.Add(this.jongmokComboBox);
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
        private System.Windows.Forms.ComboBox jongmokComboBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListView stock_sell_listview;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListView stock_buy_listview;
        private System.Windows.Forms.ListView futures_sell_listview;
        private System.Windows.Forms.ListView futures_buy_listview;
        private System.Windows.Forms.ListView futures_selljr_listview;
        private System.Windows.Forms.ListView futures_buyjr_listview;
    }
}