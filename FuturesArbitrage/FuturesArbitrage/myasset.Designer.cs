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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.futures_order_chart = new System.Windows.Forms.DataGridView();
            this.jongmokComboBox = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.abtChart_backwardation = new System.Windows.Forms.Button();
            this.abtChart_contango = new System.Windows.Forms.Button();
            this.abtChart_name = new System.Windows.Forms.Label();
            this.arbitrageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.stock_order_chart = new System.Windows.Forms.DataGridView();
            this.fep_log_view = new System.Windows.Forms.DataGridView();
            this.asset_view = new System.Windows.Forms.DataGridView();
            this.all_book_gridview = new System.Windows.Forms.DataGridView();
            this.get_log_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.futures_order_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arbitrageChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stock_order_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fep_log_view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset_view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.all_book_gridview)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Location = new System.Drawing.Point(1230, 9);
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
            this.futures_order_chart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.futures_order_chart.ColumnHeadersHeight = 29;
            this.futures_order_chart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.futures_order_chart.Location = new System.Drawing.Point(610, 117);
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
            this.futures_order_chart.Size = new System.Drawing.Size(364, 350);
            this.futures_order_chart.TabIndex = 2;
            this.futures_order_chart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.logDataGridView_CellContentClick);
            // 
            // jongmokComboBox
            // 
            this.jongmokComboBox.FormattingEnabled = true;
            this.jongmokComboBox.Location = new System.Drawing.Point(12, 9);
            this.jongmokComboBox.Name = "jongmokComboBox";
            this.jongmokComboBox.Size = new System.Drawing.Size(314, 23);
            this.jongmokComboBox.TabIndex = 20;
            this.jongmokComboBox.SelectedIndexChanged += new System.EventHandler(this.jongmokComboBox_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // abtChart_backwardation
            // 
            this.abtChart_backwardation.Location = new System.Drawing.Point(1157, 472);
            this.abtChart_backwardation.Name = "abtChart_backwardation";
            this.abtChart_backwardation.Size = new System.Drawing.Size(85, 23);
            this.abtChart_backwardation.TabIndex = 46;
            this.abtChart_backwardation.Text = "Backwardation";
            this.abtChart_backwardation.UseVisualStyleBackColor = true;
            // 
            // abtChart_contango
            // 
            this.abtChart_contango.Location = new System.Drawing.Point(1066, 472);
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
            this.abtChart_name.Location = new System.Drawing.Point(980, 472);
            this.abtChart_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.abtChart_name.Name = "abtChart_name";
            this.abtChart_name.Size = new System.Drawing.Size(79, 19);
            this.abtChart_name.TabIndex = 44;
            this.abtChart_name.Text = "CJ ENM";
            // 
            // arbitrageChart
            // 
            chartArea1.Name = "ChartArea1";
            this.arbitrageChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.arbitrageChart.Legends.Add(legend1);
            this.arbitrageChart.Location = new System.Drawing.Point(980, 497);
            this.arbitrageChart.Margin = new System.Windows.Forms.Padding(2);
            this.arbitrageChart.Name = "arbitrageChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.arbitrageChart.Series.Add(series1);
            this.arbitrageChart.Size = new System.Drawing.Size(548, 316);
            this.arbitrageChart.TabIndex = 43;
            this.arbitrageChart.Text = "chart2";
            // 
            // stock_order_chart
            // 
            this.stock_order_chart.AllowUserToResizeColumns = false;
            this.stock_order_chart.AllowUserToResizeRows = false;
            this.stock_order_chart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stock_order_chart.ColumnHeadersHeight = 29;
            this.stock_order_chart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.stock_order_chart.Location = new System.Drawing.Point(610, 472);
            this.stock_order_chart.Name = "stock_order_chart";
            this.stock_order_chart.ReadOnly = true;
            this.stock_order_chart.RowHeadersVisible = false;
            this.stock_order_chart.RowHeadersWidth = 51;
            this.stock_order_chart.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.stock_order_chart.RowTemplate.Height = 28;
            this.stock_order_chart.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.stock_order_chart.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stock_order_chart.ShowCellToolTips = false;
            this.stock_order_chart.ShowEditingIcon = false;
            this.stock_order_chart.Size = new System.Drawing.Size(365, 350);
            this.stock_order_chart.TabIndex = 47;
            // 
            // fep_log_view
            // 
            this.fep_log_view.AllowUserToResizeColumns = false;
            this.fep_log_view.AllowUserToResizeRows = false;
            this.fep_log_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fep_log_view.ColumnHeadersHeight = 29;
            this.fep_log_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.fep_log_view.Location = new System.Drawing.Point(980, 117);
            this.fep_log_view.Name = "fep_log_view";
            this.fep_log_view.ReadOnly = true;
            this.fep_log_view.RowHeadersVisible = false;
            this.fep_log_view.RowHeadersWidth = 51;
            this.fep_log_view.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.fep_log_view.RowTemplate.Height = 28;
            this.fep_log_view.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fep_log_view.ShowCellToolTips = false;
            this.fep_log_view.ShowEditingIcon = false;
            this.fep_log_view.Size = new System.Drawing.Size(619, 349);
            this.fep_log_view.TabIndex = 48;
            // 
            // asset_view
            // 
            this.asset_view.AllowUserToResizeColumns = false;
            this.asset_view.AllowUserToResizeRows = false;
            this.asset_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.asset_view.ColumnHeadersHeight = 29;
            this.asset_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.asset_view.Location = new System.Drawing.Point(12, 43);
            this.asset_view.Name = "asset_view";
            this.asset_view.ReadOnly = true;
            this.asset_view.RowHeadersVisible = false;
            this.asset_view.RowHeadersWidth = 51;
            this.asset_view.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.asset_view.RowTemplate.Height = 28;
            this.asset_view.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.asset_view.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.asset_view.ShowCellToolTips = false;
            this.asset_view.ShowEditingIcon = false;
            this.asset_view.Size = new System.Drawing.Size(1587, 54);
            this.asset_view.TabIndex = 49;
            // 
            // all_book_gridview
            // 
            this.all_book_gridview.AllowUserToResizeColumns = false;
            this.all_book_gridview.AllowUserToResizeRows = false;
            this.all_book_gridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.all_book_gridview.ColumnHeadersHeight = 29;
            this.all_book_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.all_book_gridview.Location = new System.Drawing.Point(12, 117);
            this.all_book_gridview.Name = "all_book_gridview";
            this.all_book_gridview.ReadOnly = true;
            this.all_book_gridview.RowHeadersVisible = false;
            this.all_book_gridview.RowHeadersWidth = 51;
            this.all_book_gridview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.all_book_gridview.RowTemplate.Height = 28;
            this.all_book_gridview.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.all_book_gridview.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.all_book_gridview.ShowCellToolTips = false;
            this.all_book_gridview.ShowEditingIcon = false;
            this.all_book_gridview.Size = new System.Drawing.Size(574, 650);
            this.all_book_gridview.TabIndex = 50;
            // 
            // get_log_button
            // 
            this.get_log_button.Location = new System.Drawing.Point(1131, 8);
            this.get_log_button.Name = "get_log_button";
            this.get_log_button.Size = new System.Drawing.Size(84, 23);
            this.get_log_button.TabIndex = 51;
            this.get_log_button.Text = "로그 받기";
            this.get_log_button.UseVisualStyleBackColor = true;
            this.get_log_button.Click += new System.EventHandler(this.get_log_button_Click);
            // 
            // myasset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1695, 765);
            this.Controls.Add(this.get_log_button);
            this.Controls.Add(this.all_book_gridview);
            this.Controls.Add(this.asset_view);
            this.Controls.Add(this.fep_log_view);
            this.Controls.Add(this.stock_order_chart);
            this.Controls.Add(this.abtChart_backwardation);
            this.Controls.Add(this.abtChart_contango);
            this.Controls.Add(this.abtChart_name);
            this.Controls.Add(this.arbitrageChart);
            this.Controls.Add(this.jongmokComboBox);
            this.Controls.Add(this.futures_order_chart);
            this.Controls.Add(this.button1);
            this.Name = "myasset";
            this.Text = "myasset";
            ((System.ComponentModel.ISupportInitialize)(this.futures_order_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arbitrageChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stock_order_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fep_log_view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset_view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.all_book_gridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView futures_order_chart;
        private System.Windows.Forms.ComboBox jongmokComboBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button abtChart_backwardation;
        private System.Windows.Forms.Button abtChart_contango;
        private System.Windows.Forms.Label abtChart_name;
        private System.Windows.Forms.DataVisualization.Charting.Chart arbitrageChart;
        private System.Windows.Forms.DataGridView stock_order_chart;
        private System.Windows.Forms.DataGridView fep_log_view;
        private System.Windows.Forms.DataGridView asset_view;
        private System.Windows.Forms.DataGridView all_book_gridview;
        private System.Windows.Forms.Button get_log_button;
    }
}