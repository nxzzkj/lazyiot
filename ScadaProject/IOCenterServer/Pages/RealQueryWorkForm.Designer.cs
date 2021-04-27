using Scada.Controls.Controls.List;
using Scada.Controls.Controls.SCADAChart;

namespace ScadaCenterServer.Pages
{
    partial class RealQueryWorkForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealQueryWorkForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.导出CSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.hsComboBox = new ScadaCenterServer.Controls.HsComboBox(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView = new SCADAListView ();
            this.columnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDataValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnQualityStamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RealChart = new SCADAChart();
            this.ucArrowPre = new Scada.Controls.Controls.UCArrow();
            this.ucArrowNext = new Scada.Controls.Controls.UCArrow();
            this.realtimer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer.Panel1.Controls.Add(this.hsComboBox);
            this.splitContainer.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer.Size = new System.Drawing.Size(869, 494);
            this.splitContainer.SplitterDistance = 28;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 0;
            // 
            // hsComboBox
            // 
            this.hsComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.hsComboBox.CheckedListBox = null;
            this.hsComboBox.CtlType = ScadaCenterServer.Controls.HsComboBox.TypeC.TreeView;
            this.hsComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.hsComboBox.DropDownHeight = 1;
            this.hsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hsComboBox.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hsComboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.hsComboBox.FormattingEnabled = true;
            this.hsComboBox.IntegralHeight = false;
            this.hsComboBox.ItemHeight = 20;
            this.hsComboBox.Location = new System.Drawing.Point(34, 0);
            this.hsComboBox.Name = "hsComboBox";
            this.hsComboBox.Size = new System.Drawing.Size(617, 28);
            this.hsComboBox.TabIndex = 18;
            this.hsComboBox.SelectedIndexChanged += new System.EventHandler(this.hsComboBox_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.RealChart);
            this.splitContainer1.Panel2.Controls.Add(this.ucArrowPre);
            this.splitContainer1.Panel2.Controls.Add(this.ucArrowNext);
            this.splitContainer1.Size = new System.Drawing.Size(869, 465);
            this.splitContainer1.SplitterDistance = 208;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // listView
            // 
            this.listView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView.AllowDrop = true;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnID,
            this.columnName,
            this.columnLabel,
            this.columnDataValue,
            this.columnDateTime,
            this.columnQualityStamp,
            this.columnUnit});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView.ForeColor = System.Drawing.SystemColors.MenuText;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(869, 208);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // columnID
            // 
            this.columnID.Text = "编号";
            this.columnID.Width = 133;
            // 
            // columnName
            // 
            this.columnName.Text = "IO名称";
            this.columnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnName.Width = 164;
            // 
            // columnLabel
            // 
            this.columnLabel.Text = "中文名称";
            this.columnLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnLabel.Width = 141;
            // 
            // columnDataValue
            // 
            this.columnDataValue.Text = "实时值";
            this.columnDataValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnDataValue.Width = 154;
            // 
            // columnDateTime
            // 
            this.columnDateTime.Text = "时间";
            this.columnDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnDateTime.Width = 188;
            // 
            // columnQualityStamp
            // 
            this.columnQualityStamp.Text = "质量戳";
            this.columnQualityStamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnQualityStamp.Width = 81;
            // 
            // columnUnit
            // 
            this.columnUnit.Text = "单位";
            this.columnUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnUnit.Width = 63;
            // 
            // RealChart
            // 
            chartArea1.Name = "IOChartArea";
            this.RealChart.ChartAreas.Add(chartArea1);
            this.RealChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.DockedToChartArea = "IOChartArea";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.RealChart.Legends.Add(legend1);
            this.RealChart.Location = new System.Drawing.Point(40, 0);
            this.RealChart.Name = "RealChart";
            this.RealChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.RealChart.Size = new System.Drawing.Size(791, 256);
            this.RealChart.SuppressExceptions = true;
            this.RealChart.TabIndex = 0;
            this.RealChart.Text = "chart1";
            // 
            // ucArrowPre
            // 
            this.ucArrowPre.ArrowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ucArrowPre.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucArrowPre.BorderColor = null;
            this.ucArrowPre.Direction = Scada.Controls.Controls.ArrowDirection.Left;
            this.ucArrowPre.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucArrowPre.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucArrowPre.ForeColor = System.Drawing.Color.Brown;
            this.ucArrowPre.Location = new System.Drawing.Point(0, 0);
            this.ucArrowPre.Name = "ucArrowPre";
            this.ucArrowPre.Size = new System.Drawing.Size(40, 256);
            this.ucArrowPre.TabIndex = 34;
            this.ucArrowPre.Text = "前";
            this.ucArrowPre.Click += new System.EventHandler(this.ucArrowPre_Click);
            // 
            // ucArrowNext
            // 
            this.ucArrowNext.ArrowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ucArrowNext.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucArrowNext.BorderColor = null;
            this.ucArrowNext.Direction = Scada.Controls.Controls.ArrowDirection.Right;
            this.ucArrowNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucArrowNext.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucArrowNext.ForeColor = System.Drawing.Color.Brown;
            this.ucArrowNext.Location = new System.Drawing.Point(831, 0);
            this.ucArrowNext.Name = "ucArrowNext";
            this.ucArrowNext.Size = new System.Drawing.Size(38, 256);
            this.ucArrowNext.TabIndex = 35;
            this.ucArrowNext.Text = "后";
            this.ucArrowNext.Click += new System.EventHandler(this.ucArrowNext_Click);
            // 
            // realtimer
            // 
            this.realtimer.Interval = 3000;
            // 
            // RealQueryWorkForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(869, 494);
            this.Controls.Add(this.splitContainer);
            this.Name = "RealQueryWorkForm";
            this.Text = "实时数据";
            this.contextMenuStrip.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RealChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 导出CSVToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SCADAListView listView;
        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnLabel;
        private System.Windows.Forms.ColumnHeader columnDataValue;
        private System.Windows.Forms.ColumnHeader columnDateTime;
        private System.Windows.Forms.ColumnHeader columnQualityStamp;
        private System.Windows.Forms.ColumnHeader columnUnit;
        private SCADAChart RealChart;
        private Controls.HsComboBox hsComboBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer realtimer;
        private Scada.Controls.Controls.UCArrow ucArrowPre;
        private Scada.Controls.Controls.UCArrow ucArrowNext;
    }
}