using Scada.Controls.Controls.List;
using Scada.Controls.Controls.Page;
using Scada.Controls.Controls.SCADAChart;

namespace ScadaCenterServer.Pages
{
    partial class HistoryAlarmQueryWorkForm
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
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.导出CSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.search = new ScadaCenterServer.Controls.HistoryAlarmSearch();
            this.listView = new Scada.Controls.Controls.List.SCADAListView();
            this.columnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnView = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucPagerControl = new Scada.Controls.Controls.Page.SCADAPager();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
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
            this.splitContainer.Panel2.Controls.Add(this.listView);
            this.splitContainer.Panel2.Controls.Add(this.ucPagerControl);
            this.splitContainer.Size = new System.Drawing.Size(869, 494);
            this.splitContainer.SplitterDistance = 33;
            this.splitContainer.TabIndex = 0;
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.search.EndDate = new System.DateTime(2019, 12, 13, 3, 25, 21, 77);
            this.search.Location = new System.Drawing.Point(0, 0);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(869, 33);
            this.search.StartDate = new System.DateTime(2019, 12, 13, 3, 25, 21, 72);
            this.search.TabIndex = 0;
            this.search.SearchClick += new System.EventHandler(this.Search_SearchClick);
            this.search.SelectedIndexChanged += new System.EventHandler(this.Search_SelectedIndexChanged);
            // 
            // listView
            // 
            this.listView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView.AllowDrop = true;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnID,
            this.columnName,
            this.columnLabel,
            this.columnValue,
            this.columnDateTime,
            this.columnLevel,
            this.columnType,
            this.columnView,
            this.columnUser});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView.ForeColor = System.Drawing.SystemColors.MenuText;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(869, 422);
            this.listView.TabIndex = 7;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // columnID
            // 
            this.columnID.Text = "编号";
            this.columnID.Width = 64;
            // 
            // columnName
            // 
            this.columnName.Text = "IO名称";
            this.columnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnName.Width = 82;
            // 
            // columnLabel
            // 
            this.columnLabel.Text = "中文名称";
            this.columnLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnLabel.Width = 109;
            // 
            // columnValue
            // 
            this.columnValue.Text = "报警值";
            this.columnValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnValue.Width = 97;
            // 
            // columnDateTime
            // 
            this.columnDateTime.Text = "报警时间";
            this.columnDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnDateTime.Width = 133;
            // 
            // columnLevel
            // 
            this.columnLevel.Text = "报警级别";
            this.columnLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnLevel.Width = 89;
            // 
            // columnType
            // 
            this.columnType.Text = "报警类型";
            this.columnType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnType.Width = 97;
            // 
            // columnView
            // 
            this.columnView.Text = "处理意见";
            this.columnView.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnView.Width = 247;
            // 
            // columnUser
            // 
            this.columnUser.Text = "处理人";
            this.columnUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnUser.Width = 90;
            // 
            // ucPagerControl
            // 
            this.ucPagerControl.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ucPagerControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPagerControl.Location = new System.Drawing.Point(0, 422);
            this.ucPagerControl.Name = "ucPagerControl";
            this.ucPagerControl.PageCount = 0;
            this.ucPagerControl.PageIndex = 1;
            this.ucPagerControl.PageSize = 100;
            this.ucPagerControl.RecordCount = 0;
            this.ucPagerControl.Size = new System.Drawing.Size(869, 35);
            this.ucPagerControl.TabIndex = 6;
            this.ucPagerControl.OnPageIndexed += new Scada.Controls.Controls.PageChanged(this.UcPagerControl_OnPageIndexed);
            // 
            // RealAlarmQueryWorkForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(869, 494);
            this.Controls.Add(this.splitContainer);
            this.Name = "RealAlarmQueryWorkForm";
            this.Text = "实时报警";
            this.Load += new System.EventHandler(this.RealAlarmQueryWorkForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private SCADAPager ucPagerControl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 导出CSVToolStripMenuItem;
        private SCADAListView listView;
        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnLabel;
        private System.Windows.Forms.ColumnHeader columnValue;
        private System.Windows.Forms.ColumnHeader columnDateTime;
        private System.Windows.Forms.ColumnHeader columnLevel;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.ColumnHeader columnView;
        private System.Windows.Forms.ColumnHeader columnUser;
        private Controls.HistoryAlarmSearch search;
    }
}