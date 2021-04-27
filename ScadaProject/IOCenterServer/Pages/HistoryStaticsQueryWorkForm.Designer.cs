using Scada.Controls.Controls.List;
using Scada.Controls.Controls.Page;
using Scada.Controls.Controls.SCADAChart;

namespace ScadaCenterServer.Pages
{
    partial class HistoryStaticsQueryWorkForm
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
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.导出CSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.search = new ScadaCenterServer.Controls.HistoryStaticsSearch();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView = new Scada.Controls.Controls.List.SCADAListView();
            this.ucPagerControl = new Scada.Controls.Controls.Page.SCADAPager();
            this.RealChart = new Scada.Controls.Controls.SCADAChart.SCADAChart();
            this.listBoxSeries = new System.Windows.Forms.ListBox();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RealChart)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出CSVToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(124, 26);
            // 
            // 导出CSVToolStripMenuItem
            // 
            this.导出CSVToolStripMenuItem.Name = "导出CSVToolStripMenuItem";
            this.导出CSVToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.导出CSVToolStripMenuItem.Text = "导出CSV";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.search);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer.Size = new System.Drawing.Size(869, 494);
            this.splitContainer.SplitterDistance = 28;
            this.splitContainer.TabIndex = 0;
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.search.EndDate = new System.DateTime(2019, 12, 14, 10, 50, 46, 303);
            this.search.Location = new System.Drawing.Point(0, 0);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(869, 28);
            this.search.StartDate = new System.DateTime(2019, 12, 14, 10, 50, 46, 293);
            this.search.TabIndex = 0;
            this.search.SearchClick += new System.EventHandler(this.Search_SearchClick);
            this.search.SelectedIndexChanged += new System.EventHandler(this.Search_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView);
            this.splitContainer1.Panel1.Controls.Add(this.ucPagerControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.RealChart);
            this.splitContainer1.Panel2.Controls.Add(this.listBoxSeries);
            this.splitContainer1.Size = new System.Drawing.Size(869, 462);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 7;
            // 
            // listView
            // 
            this.listView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView.AllowDrop = true;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView.ForeColor = System.Drawing.SystemColors.MenuText;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(869, 200);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // ucPagerControl
            // 
            this.ucPagerControl.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ucPagerControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPagerControl.Location = new System.Drawing.Point(0, 200);
            this.ucPagerControl.Name = "ucPagerControl";
            this.ucPagerControl.PageCount = 0;
            this.ucPagerControl.PageIndex = 1;
            this.ucPagerControl.PageSize = 100;
            this.ucPagerControl.RecordCount = 0;
            this.ucPagerControl.Size = new System.Drawing.Size(869, 35);
            this.ucPagerControl.TabIndex = 6;
            // 
            // RealChart
            // 
            chartArea1.Name = "IOChartArea";
            this.RealChart.ChartAreas.Add(chartArea1);
            this.RealChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.RealChart.Legends.Add(legend1);
            this.RealChart.Location = new System.Drawing.Point(0, 0);
            this.RealChart.Name = "RealChart";
            series1.ChartArea = "IOChartArea";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.RealChart.Series.Add(series1);
            this.RealChart.Size = new System.Drawing.Size(734, 226);
            this.RealChart.TabIndex = 0;
            this.RealChart.Text = "chart1";
            // 
            // listBoxSeries
            // 
            this.listBoxSeries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxSeries.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxSeries.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxSeries.FormattingEnabled = true;
            this.listBoxSeries.ItemHeight = 17;
            this.listBoxSeries.Location = new System.Drawing.Point(734, 0);
            this.listBoxSeries.Name = "listBoxSeries";
            this.listBoxSeries.Size = new System.Drawing.Size(135, 226);
            this.listBoxSeries.TabIndex = 1;
            this.listBoxSeries.SelectedIndexChanged += new System.EventHandler(this.listBoxSeries_SelectedIndexChanged);
            // 
            // HistoryStaticsQueryWorkForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(869, 494);
            this.Controls.Add(this.splitContainer);
            this.Name = "HistoryStaticsQueryWorkForm";
            this.Text = "WorkForm";
            this.contextMenuStrip.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RealChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private SCADAPager ucPagerControl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 导出CSVToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SCADAListView listView;
        private SCADAChart RealChart;
        private System.Windows.Forms.ListBox listBoxSeries;
        private Controls.HistoryStaticsSearch search;
    }
}