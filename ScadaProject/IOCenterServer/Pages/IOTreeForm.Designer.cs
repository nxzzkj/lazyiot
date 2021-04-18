namespace ScadaCenterServer.Pages
{
    partial class IOTreeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOTreeForm));
            this.ioTree = new ScadaCenterServer.Controls.IOTree();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.实时数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史报警ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.日志查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.下置查询toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.统计查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ioTree
            // 
            this.ioTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ioTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ioTree.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ioTree.FullRowSelect = true;
            this.ioTree.ImageIndex = 0;
            this.ioTree.ImageList = this.imageList;
            this.ioTree.ItemHeight = 28;
            this.ioTree.LineColor = System.Drawing.Color.DimGray;
            this.ioTree.Location = new System.Drawing.Point(0, 0);
            this.ioTree.Name = "ioTree";
            this.ioTree.SelectedImageIndex = 0;
            this.ioTree.ShowNodeToolTips = true;
            this.ioTree.Size = new System.Drawing.Size(334, 492);
            this.ioTree.TabIndex = 1;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "network%20harddrive.ico");
            this.imageList.Images.SetKeyName(1, "comm2.png");
            this.imageList.Images.SetKeyName(2, "comm1.png");
            this.imageList.Images.SetKeyName(3, "RAID.ico");
            this.imageList.Images.SetKeyName(4, "wifi2.png");
            this.imageList.Images.SetKeyName(5, "wifi.png");
            // 
            // 实时数据ToolStripMenuItem
            // 
            this.实时数据ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("实时数据ToolStripMenuItem.Image")));
            this.实时数据ToolStripMenuItem.Name = "实时数据ToolStripMenuItem";
            this.实时数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.实时数据ToolStripMenuItem.Text = "实时数据查询";
            this.实时数据ToolStripMenuItem.Click += new System.EventHandler(this.实时数据ToolStripMenuItem_Click);
            // 
            // 历史查询ToolStripMenuItem
            // 
            this.历史查询ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("历史查询ToolStripMenuItem.Image")));
            this.历史查询ToolStripMenuItem.Name = "历史查询ToolStripMenuItem";
            this.历史查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.历史查询ToolStripMenuItem.Text = "历史数据查询";
            this.历史查询ToolStripMenuItem.Click += new System.EventHandler(this.历史查询ToolStripMenuItem_Click);
            // 
            // 历史报警ToolStripMenuItem
            // 
            this.历史报警ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("历史报警ToolStripMenuItem.Image")));
            this.历史报警ToolStripMenuItem.Name = "历史报警ToolStripMenuItem";
            this.历史报警ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.历史报警ToolStripMenuItem.Text = "历史报警查询";
            this.历史报警ToolStripMenuItem.Click += new System.EventHandler(this.历史报警ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // 日志查询ToolStripMenuItem
            // 
            this.日志查询ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("日志查询ToolStripMenuItem.Image")));
            this.日志查询ToolStripMenuItem.Name = "日志查询ToolStripMenuItem";
            this.日志查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.日志查询ToolStripMenuItem.Text = "日志事件查询";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.实时数据ToolStripMenuItem,
            this.历史查询ToolStripMenuItem,
            this.历史报警ToolStripMenuItem,
            this.下置查询toolStripMenuItem,
            this.统计查询ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.日志查询ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 186);
            // 
            // 下置查询toolStripMenuItem
            // 
            this.下置查询toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("下置查询toolStripMenuItem.Image")));
            this.下置查询toolStripMenuItem.Name = "下置查询toolStripMenuItem";
            this.下置查询toolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.下置查询toolStripMenuItem.Text = "历史下置查询";
            this.下置查询toolStripMenuItem.Click += new System.EventHandler(this.下置查询toolStripMenuItem_Click);
            // 
            // 统计查询ToolStripMenuItem
            // 
            this.统计查询ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("统计查询ToolStripMenuItem.Image")));
            this.统计查询ToolStripMenuItem.Name = "统计查询ToolStripMenuItem";
            this.统计查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.统计查询ToolStripMenuItem.Text = "历史统计查询";
            this.统计查询ToolStripMenuItem.Click += new System.EventHandler(this.统计查询ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "报警配置日志";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // IOTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 492);
            this.Controls.Add(this.ioTree);
            this.Name = "IOTreeForm";
            this.Text = "IOTreeForm";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public Controls.IOTree ioTree;
        private System.Windows.Forms.ToolStripMenuItem 实时数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史报警ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 日志查询ToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 统计查询ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem 下置查询toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}