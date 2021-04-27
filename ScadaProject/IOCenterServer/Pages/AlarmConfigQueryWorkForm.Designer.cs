using Scada.Controls.Controls.List;
using Scada.Controls.Controls.Page;
using Scada.Controls.Controls.SCADAChart;

namespace ScadaCenterServer.Pages
{
    partial class AlarmConfigQueryWorkForm
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
            this.search = new ScadaCenterServer.Controls.Search();
            this.listViewSendCommand = new Scada.Controls.Controls.List.SCADAListView();
            this.ucPagerControl = new Scada.Controls.Controls.Page.SCADAPager();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.splitContainer.Panel2.Controls.Add(this.listViewSendCommand);
            this.splitContainer.Panel2.Controls.Add(this.ucPagerControl);
            this.splitContainer.Size = new System.Drawing.Size(916, 494);
            this.splitContainer.SplitterDistance = 28;
            this.splitContainer.TabIndex = 0;
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.search.EndDate = new System.DateTime(2019, 12, 13, 3, 25, 21, 77);
            this.search.Location = new System.Drawing.Point(0, 0);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(916, 28);
            this.search.StartDate = new System.DateTime(2019, 12, 13, 3, 25, 21, 72);
            this.search.TabIndex = 0;
            this.search.SearchClick += new System.EventHandler(this.Search_SearchClick);
            this.search.SelectedIndexChanged += new System.EventHandler(this.Search_SelectedIndexChanged);
            // 
            // listViewSendCommand
            // 
            this.listViewSendCommand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewSendCommand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader13,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20});
            this.listViewSendCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSendCommand.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewSendCommand.FullRowSelect = true;
            this.listViewSendCommand.GridLines = true;
            this.listViewSendCommand.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSendCommand.Location = new System.Drawing.Point(0, 0);
            this.listViewSendCommand.Name = "listViewSendCommand";
            this.listViewSendCommand.Size = new System.Drawing.Size(916, 427);
            this.listViewSendCommand.TabIndex = 12;
            this.listViewSendCommand.UseCompatibleStateImageBehavior = false;
            this.listViewSendCommand.View = System.Windows.Forms.View.Details;
            // 
            // ucPagerControl
            // 
            this.ucPagerControl.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ucPagerControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPagerControl.Location = new System.Drawing.Point(0, 427);
            this.ucPagerControl.Name = "ucPagerControl";
            this.ucPagerControl.PageCount = 0;
            this.ucPagerControl.PageIndex = 1;
            this.ucPagerControl.PageSize = 100;
            this.ucPagerControl.RecordCount = 0;
            this.ucPagerControl.Size = new System.Drawing.Size(916, 35);
            this.ucPagerControl.TabIndex = 6;
            this.ucPagerControl.OnPageIndexed += new Scada.Controls.Controls.PageChanged(this.UcPagerControl_OnPageIndexed);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "修改时间";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "修改结果";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "修改用户";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "IO参数";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "IO_名称";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "报警前置";
            this.columnHeader8.Width = 200;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "超高限开关";
            this.columnHeader9.Width = 200;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "报警级别";
            this.columnHeader10.Width = 200;
            // 
            // columnHeader11
            // 
            this.columnHeader11.DisplayIndex = 10;
            this.columnHeader11.Text = "高限开关";
            this.columnHeader11.Width = 200;
            // 
            // columnHeader12
            // 
            this.columnHeader12.DisplayIndex = 11;
            this.columnHeader12.Text = "报警级别";
            this.columnHeader12.Width = 200;
            // 
            // columnHeader13
            // 
            this.columnHeader13.DisplayIndex = 12;
            this.columnHeader13.Text = "报警限值";
            this.columnHeader13.Width = 200;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "报警限值";
            this.columnHeader14.Width = 200;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "低限报警开关";
            this.columnHeader15.Width = 200;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "报警级别";
            this.columnHeader16.Width = 200;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "报警值";
            this.columnHeader17.Width = 200;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "超低限开关";
            this.columnHeader18.Width = 200;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "报警级别";
            this.columnHeader19.Width = 200;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "报警限值";
            this.columnHeader20.Width = 200;
            // 
            // AlarmConfigQueryWorkForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(916, 494);
            this.Controls.Add(this.splitContainer);
            this.Name = "AlarmConfigQueryWorkForm";
            this.Text = "报警配置修改记录";
            this.Load += new System.EventHandler(this.AlarmConfigQueryWorkForm_Load);
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
        private Controls.Search search;
        public SCADAListView listViewSendCommand;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
    }
}