using Scada.Controls.Controls.List;
using Scada.Controls.Controls.Page;
using Scada.Controls.Controls.SCADAChart;

namespace ScadaCenterServer.Pages
{
    partial class SendCommandQueryWorkForm
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
            this.columnDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnioparaname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnvalue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnresult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnuser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucPagerControl = new Scada.Controls.Controls.Page.SCADAPager();
            this.columnparalabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.splitContainer.Size = new System.Drawing.Size(869, 494);
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
            this.search.Size = new System.Drawing.Size(869, 28);
            this.search.StartDate = new System.DateTime(2019, 12, 13, 3, 25, 21, 72);
            this.search.TabIndex = 0;
            this.search.SearchClick += new System.EventHandler(this.Search_SearchClick);
            this.search.SelectedIndexChanged += new System.EventHandler(this.Search_SelectedIndexChanged);
            // 
            // listViewSendCommand
            // 
            this.listViewSendCommand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewSendCommand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDateTime,
            this.columnioparaname,
            this.columnparalabel,
            this.columnvalue,
            this.columnresult,
            this.columnuser});
            this.listViewSendCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSendCommand.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewSendCommand.FullRowSelect = true;
            this.listViewSendCommand.GridLines = true;
            this.listViewSendCommand.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSendCommand.Location = new System.Drawing.Point(0, 0);
            this.listViewSendCommand.Name = "listViewSendCommand";
            this.listViewSendCommand.Size = new System.Drawing.Size(869, 427);
            this.listViewSendCommand.TabIndex = 12;
            this.listViewSendCommand.UseCompatibleStateImageBehavior = false;
            this.listViewSendCommand.View = System.Windows.Forms.View.Details;
            // 
            // columnDateTime
            // 
            this.columnDateTime.Text = "下置时间";
            this.columnDateTime.Width = 137;
            // 
            // columnioparaname
            // 
            this.columnioparaname.Text = "IO参数";
            this.columnioparaname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnioparaname.Width = 120;
            // 
            // columnvalue
            // 
            this.columnvalue.Text = "下置值";
            this.columnvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnvalue.Width = 105;
            // 
            // columnresult
            // 
            this.columnresult.Text = "下置结果";
            this.columnresult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnresult.Width = 118;
            // 
            // columnuser
            // 
            this.columnuser.Text = "操作用户";
            this.columnuser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnuser.Width = 92;
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
            this.ucPagerControl.Size = new System.Drawing.Size(869, 35);
            this.ucPagerControl.TabIndex = 6;
            this.ucPagerControl.OnPageIndexed += new Scada.Controls.Controls.PageChanged(this.UcPagerControl_OnPageIndexed);
            // 
            // columnparalabel
            // 
            this.columnparalabel.Text = "中午名称";
            this.columnparalabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnparalabel.Width = 120;
            // 
            // SendCommandQueryWorkForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(869, 494);
            this.Controls.Add(this.splitContainer);
            this.Name = "SendCommandQueryWorkForm";
            this.Text = "下置历史查询";
            this.Load += new System.EventHandler(this.SendCommandQueryWorkForm_Load);
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
        private System.Windows.Forms.ColumnHeader columnDateTime;
        private System.Windows.Forms.ColumnHeader columnioparaname;
        private System.Windows.Forms.ColumnHeader columnvalue;
        private System.Windows.Forms.ColumnHeader columnresult;
        private System.Windows.Forms.ColumnHeader columnuser;
        private System.Windows.Forms.ColumnHeader columnparalabel;
    }
}