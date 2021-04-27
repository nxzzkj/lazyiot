namespace IOManager.Controls
{
    partial class IOListView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOListView));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.contextPara = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加参数ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.复制参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.剪贴toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem全选 = new System.Windows.Forms.ToolStripMenuItem();
            this.取消全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出CSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextPara.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtPath);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView);
            this.splitContainer1.Size = new System.Drawing.Size(665, 383);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPath.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPath.ForeColor = System.Drawing.Color.Maroon;
            this.txtPath.Location = new System.Drawing.Point(35, 0);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(630, 23);
            this.txtPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "     ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView
            // 
            this.listView.ContextMenuStrip = this.contextPara;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(665, 354);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // contextPara
            // 
            this.contextPara.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加参数ToolStripMenuItem1,
            this.删除参数ToolStripMenuItem,
            this.编辑参数ToolStripMenuItem,
            this.toolStripSeparator7,
            this.复制参数ToolStripMenuItem,
            this.剪贴toolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.toolStripSeparator15,
            this.toolStripMenuItem全选,
            this.取消全选ToolStripMenuItem,
            this.导出CSVToolStripMenuItem});
            this.contextPara.Name = "contextPoint";
            this.contextPara.Size = new System.Drawing.Size(153, 236);
            // 
            // 添加参数ToolStripMenuItem1
            // 
            this.添加参数ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("添加参数ToolStripMenuItem1.Image")));
            this.添加参数ToolStripMenuItem1.Name = "添加参数ToolStripMenuItem1";
            this.添加参数ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.添加参数ToolStripMenuItem1.Text = "添加参数";
            this.添加参数ToolStripMenuItem1.Click += new System.EventHandler(this.添加参数ToolStripMenuItem1_Click);
            // 
            // 删除参数ToolStripMenuItem
            // 
            this.删除参数ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("删除参数ToolStripMenuItem.Image")));
            this.删除参数ToolStripMenuItem.Name = "删除参数ToolStripMenuItem";
            this.删除参数ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除参数ToolStripMenuItem.Text = "删除参数";
            this.删除参数ToolStripMenuItem.Click += new System.EventHandler(this.删除参数ToolStripMenuItem_Click);
            // 
            // 编辑参数ToolStripMenuItem
            // 
            this.编辑参数ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("编辑参数ToolStripMenuItem.Image")));
            this.编辑参数ToolStripMenuItem.Name = "编辑参数ToolStripMenuItem";
            this.编辑参数ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.编辑参数ToolStripMenuItem.Text = "编辑参数";
            this.编辑参数ToolStripMenuItem.Click += new System.EventHandler(this.编辑参数ToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(149, 6);
            // 
            // 复制参数ToolStripMenuItem
            // 
            this.复制参数ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("复制参数ToolStripMenuItem.Image")));
            this.复制参数ToolStripMenuItem.Name = "复制参数ToolStripMenuItem";
            this.复制参数ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.复制参数ToolStripMenuItem.Text = "复制";
            this.复制参数ToolStripMenuItem.Click += new System.EventHandler(this.复制参数ToolStripMenuItem_Click);
            // 
            // 剪贴toolStripMenuItem
            // 
            this.剪贴toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("剪贴toolStripMenuItem.Image")));
            this.剪贴toolStripMenuItem.Name = "剪贴toolStripMenuItem";
            this.剪贴toolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.剪贴toolStripMenuItem.Text = "剪贴";
            this.剪贴toolStripMenuItem.Click += new System.EventHandler(this.剪贴toolStripMenuItem_Click);
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("粘贴ToolStripMenuItem.Image")));
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            this.粘贴ToolStripMenuItem.Click += new System.EventHandler(this.粘贴ToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem全选
            // 
            this.toolStripMenuItem全选.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem全选.Image")));
            this.toolStripMenuItem全选.Name = "toolStripMenuItem全选";
            this.toolStripMenuItem全选.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem全选.Text = "全选";
            this.toolStripMenuItem全选.Click += new System.EventHandler(this.toolStripMenuItem全选_Click);
            // 
            // 取消全选ToolStripMenuItem
            // 
            this.取消全选ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("取消全选ToolStripMenuItem.Image")));
            this.取消全选ToolStripMenuItem.Name = "取消全选ToolStripMenuItem";
            this.取消全选ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.取消全选ToolStripMenuItem.Text = "取消全选";
            this.取消全选ToolStripMenuItem.Click += new System.EventHandler(this.取消全选ToolStripMenuItem_Click);
            // 
            // 导出CSVToolStripMenuItem
            // 
            this.导出CSVToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("导出CSVToolStripMenuItem.Image")));
            this.导出CSVToolStripMenuItem.Name = "导出CSVToolStripMenuItem";
            this.导出CSVToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.导出CSVToolStripMenuItem.Text = "导出CSV";
            // 
            // IOListView
            // 
            this.Controls.Add(this.splitContainer1);
            this.Name = "IOListView";
            this.Size = new System.Drawing.Size(665, 383);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextPara.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.ListView listView;
        public System.Windows.Forms.ContextMenuStrip contextPara;
        private System.Windows.Forms.ToolStripMenuItem 添加参数ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 删除参数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑参数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem 复制参数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem全选;
        private System.Windows.Forms.ToolStripMenuItem 取消全选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 剪贴toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出CSVToolStripMenuItem;
    }
}
