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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.futures_order_chart = new System.Windows.Forms.DataGridView();
            this.jongmokComboBox = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.stock_sell_listview = new System.Windows.Forms.ListView();
            this.stock_buy_listview = new System.Windows.Forms.ListView();
            this.futures_sell_listview = new System.Windows.Forms.ListView();
            this.futures_buy_listview = new System.Windows.Forms.ListView();
            this.futures_selljr_listview = new System.Windows.Forms.ListView();
            this.futures_buyjr_listview = new System.Windows.Forms.ListView();
            this.abtChart_backwardation = new System.Windows.Forms.Button();
            this.abtChart_contango = new System.Windows.Forms.Button();
            this.abtChart_name = new System.Windows.Forms.Label();
            this.arbitrageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.stock_order_chart = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.futures_order_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arbitrageChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stock_order_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Location = new System.Drawing.Point(1194, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "돌아가기";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // futures_order_chart
            // 
            this.futures_order_chart.AllowUserToResizeColumns = false;
            this.futures_order_chart.AllowUserToResizeRows = false;
            this.futures_order_chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.futures_order_chart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.futures_order_chart.ColumnHeadersHeight = 29;
            this.futures_order_chart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.futures_order_chart.Location = new System.Drawing.Point(12, 40);
            this.futures_order_chart.Name = "futures_order_chart";
            this.futures_order_chart.ReadOnly = true;
            this.futures_order_chart.RowHeadersVisible = false;
            this.futures_order_chart.RowHeadersWidth = 51;
            this.futures_order_chart.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.futures_order_chart.RowTemplate.Height = 28;
            this.futures_order_chart.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.futures_order_chart.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.futures_order_chart.ShowCellToolTips = false;
            this.futures_order_chart.ShowEditingIcon = false;
            this.futures_order_chart.Size = new System.Drawing.Size(533, 350);
            this.futures_order_chart.TabIndex = 2;
            this.futures_order_chart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.logDataGridView_CellContentClick);
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
            this.stock_sell_listview.Location = new System.Drawing.Point(1112, 90);
            this.stock_sell_listview.Name = "stock_sell_listview";
            this.stock_sell_listview.Size = new System.Drawing.Size(78, 147);
            this.stock_sell_listview.TabIndex = 36;
            this.stock_sell_listview.UseCompatibleStateImageBehavior = false;
            // 
            // stock_buy_listview
            // 
            this.stock_buy_listview.HideSelection = false;
            this.stock_buy_listview.Location = new System.Drawing.Point(1194, 243);
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
            this.futures_sell_listview.Location = new System.Drawing.Point(1126, 385);
            this.futures_sell_listview.Name = "futures_sell_listview";
            this.futures_sell_listview.Scrollable = false;
            this.futures_sell_listview.Size = new System.Drawing.Size(62, 239);
            this.futures_sell_listview.TabIndex = 39;
            this.futures_sell_listview.UseCompatibleStateImageBehavior = false;
            // 
            // futures_buy_listview
            // 
            this.futures_buy_listview.HideSelection = false;
            this.futures_buy_listview.Location = new System.Drawing.Point(1238, 121);
            this.futures_buy_listview.Name = "futures_buy_listview";
            this.futures_buy_listview.Size = new System.Drawing.Size(78, 147);
            this.futures_buy_listview.TabIndex = 40;
            this.futures_buy_listview.UseCompatibleStateImageBehavior = false;
            // 
            // futures_selljr_listview
            // 
            this.futures_selljr_listview.HideSelection = false;
            this.futures_selljr_listview.Location = new System.Drawing.Point(1093, 385);
            this.futures_selljr_listview.Name = "futures_selljr_listview";
            this.futures_selljr_listview.Size = new System.Drawing.Size(33, 239);
            this.futures_selljr_listview.TabIndex = 41;
            this.futures_selljr_listview.UseCompatibleStateImageBehavior = false;
            // 
            // futures_buyjr_listview
            // 
            this.futures_buyjr_listview.HideSelection = false;
            this.futures_buyjr_listview.Location = new System.Drawing.Point(1188, 385);
            this.futures_buyjr_listview.Name = "futures_buyjr_listview";
            this.futures_buyjr_listview.Size = new System.Drawing.Size(33, 239);
            this.futures_buyjr_listview.TabIndex = 42;
            this.futures_buyjr_listview.UseCompatibleStateImageBehavior = false;
            // 
            // abtChart_backwardation
            // 
            this.abtChart_backwardation.Location = new System.Drawing.Point(1053, 13);
            this.abtChart_backwardation.Name = "abtChart_backwardation";
            this.abtChart_backwardation.Size = new System.Drawing.Size(85, 23);
            this.abtChart_backwardation.TabIndex = 46;
            this.abtChart_backwardation.Text = "Backwardation";
            this.abtChart_backwardation.UseVisualStyleBackColor = true;
            // 
            // abtChart_contango
            // 
            this.abtChart_contango.Location = new System.Drawing.Point(962, 13);
            this.abtChart_contango.Name = "abtChart_contango";
            this.abtChart_contango.Size = new System.Drawing.Size(85, 23);
            this.abtChart_contango.TabIndex = 45;
            this.abtChart_contango.Text = "Contango";
            this.abtChart_contango.UseVisualStyleBackColor = true;
            // 
            // abtChart_name
            // 
            this.abtChart_name.AutoSize = true;
            this.abtChart_name.Font = new System.Drawing.Font("굴림", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.abtChart_name.Location = new System.Drawing.Point(559, 13);
            this.abtChart_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.abtChart_name.Name = "abtChart_name";
            this.abtChart_name.Size = new System.Drawing.Size(79, 19);
            this.abtChart_name.TabIndex = 44;
            this.abtChart_name.Text = "CJ ENM";
            // 
            // arbitrageChart
            // 
            chartArea2.Name = "ChartArea1";
            this.arbitrageChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.arbitrageChart.Legends.Add(legend2);
            this.arbitrageChart.Location = new System.Drawing.Point(642, 13);
            this.arbitrageChart.Margin = new System.Windows.Forms.Padding(2);
            this.arbitrageChart.Name = "arbitrageChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.arbitrageChart.Series.Add(series2);
            this.arbitrageChart.Size = new System.Drawing.Size(600, 350);
            this.arbitrageChart.TabIndex = 43;
            this.arbitrageChart.Text = "chart2";
            // 
            // stock_order_chart
            // 
            this.stock_order_chart.AllowUserToResizeColumns = false;
            this.stock_order_chart.AllowUserToResizeRows = false;
            this.stock_order_chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stock_order_chart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stock_order_chart.ColumnHeadersHeight = 29;
            this.stock_order_chart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.stock_order_chart.Location = new System.Drawing.Point(12, 396);
            this.stock_order_chart.Name = "stock_order_chart";
            this.stock_order_chart.ReadOnly = true;
            this.stock_order_chart.RowHeadersVisible = false;
            this.stock_order_chart.RowHeadersWidth = 51;
            this.stock_order_chart.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.stock_order_chart.RowTemplate.Height = 28;
            this.stock_order_chart.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.stock_order_chart.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.stock_order_chart.ShowCellToolTips = false;
            this.stock_order_chart.ShowEditingIcon = false;
            this.stock_order_chart.Size = new System.Drawing.Size(533, 350);
            this.stock_order_chart.TabIndex = 47;
            // 
            // myasset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 765);
            this.Controls.Add(this.stock_order_chart);
            this.Controls.Add(this.abtChart_backwardation);
            this.Controls.Add(this.abtChart_contango);
            this.Controls.Add(this.abtChart_name);
            this.Controls.Add(this.arbitrageChart);
            this.Controls.Add(this.futures_buyjr_listview);
            this.Controls.Add(this.futures_selljr_listview);
            this.Controls.Add(this.futures_buy_listview);
            this.Controls.Add(this.futures_sell_listview);
            this.Controls.Add(this.stock_buy_listview);
            this.Controls.Add(this.stock_sell_listview);
            this.Controls.Add(this.jongmokComboBox);
            this.Controls.Add(this.futures_order_chart);
            this.Controls.Add(this.button1);
            this.Name = "myasset";
            this.Text = "myasset";
            ((System.ComponentModel.ISupportInitialize)(this.futures_order_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arbitrageChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stock_order_chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView futures_order_chart;
        private System.Windows.Forms.ComboBox jongmokComboBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListView stock_sell_listview;
        private System.Windows.Forms.ListView stock_buy_listview;
        private System.Windows.Forms.ListView futures_sell_listview;
        private System.Windows.Forms.ListView futures_buy_listview;
        private System.Windows.Forms.ListView futures_selljr_listview;
        private System.Windows.Forms.ListView futures_buyjr_listview;
        private System.Windows.Forms.Button abtChart_backwardation;
        private System.Windows.Forms.Button abtChart_contango;
        private System.Windows.Forms.Label abtChart_name;
        private System.Windows.Forms.DataVisualization.Charting.Chart arbitrageChart;
        private System.Windows.Forms.DataGridView stock_order_chart;
    }
}