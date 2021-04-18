namespace ScadaCenterServer.Pages
{
    partial class DeviceGroupForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("我的分组");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceGroupForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewGroup = new System.Windows.Forms.TreeView();
            this.ioTree = new ScadaCenterServer.Controls.IOTree();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucBtnSearch = new SCADA_Controls.Controls.UCBtnExt();
            this.ucBtnExt1 = new SCADA_Controls.Controls.UCBtnExt();
            this.ucBtnExt2 = new SCADA_Controls.Controls.UCBtnExt();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ucBtnExt3 = new SCADA_Controls.Controls.UCBtnExt();
            this.contextMenuStripGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加子分组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除当前分组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改当前分组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStripGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel1.Controls.Add(this.treeViewGroup);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel2.Controls.Add(this.ioTree);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(863, 519);
            this.splitContainer1.SplitterDistance = 233;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewGroup
            // 
            this.treeViewGroup.ContextMenuStrip = this.contextMenuStripGroup;
            this.treeViewGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewGroup.ImageIndex = 0;
            this.treeViewGroup.ImageList = this.imageList;
            this.treeViewGroup.Location = new System.Drawing.Point(0, 50);
            this.treeViewGroup.Name = "treeViewGroup";
            treeNode1.Name = "节点0";
            treeNode1.Text = "我的分组";
            this.treeViewGroup.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeViewGroup.SelectedImageIndex = 0;
            this.treeViewGroup.Size = new System.Drawing.Size(233, 469);
            this.treeViewGroup.TabIndex = 0;
            // 
            // ioTree
            // 
            this.ioTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ioTree.Location = new System.Drawing.Point(0, 50);
            this.ioTree.Name = "ioTree";
            this.ioTree.Size = new System.Drawing.Size(626, 469);
            this.ioTree.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.ucBtnExt2);
            this.groupBox1.Controls.Add(this.ucBtnExt1);
            this.groupBox1.Controls.Add(this.ucBtnSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ucBtnSearch
            // 
            this.ucBtnSearch.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnSearch.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnSearch.BtnFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnSearch.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnSearch.BtnText = "删除";
            this.ucBtnSearch.ConerRadius = 5;
            this.ucBtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucBtnSearch.FillColor = System.Drawing.Color.DarkOliveGreen;
            this.ucBtnSearch.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnSearch.ForeColor = System.Drawing.Color.White;
            this.ucBtnSearch.IsRadius = true;
            this.ucBtnSearch.IsShowRect = false;
            this.ucBtnSearch.IsShowTips = false;
            this.ucBtnSearch.Location = new System.Drawing.Point(3, 18);
            this.ucBtnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnSearch.Name = "ucBtnSearch";
            this.ucBtnSearch.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnSearch.RectWidth = 1;
            this.ucBtnSearch.Size = new System.Drawing.Size(58, 29);
            this.ucBtnSearch.TabIndex = 28;
            this.ucBtnSearch.TabStop = false;
            this.ucBtnSearch.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnSearch.TipsText = "";
            // 
            // ucBtnExt1
            // 
            this.ucBtnExt1.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnExt1.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnExt1.BtnFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt1.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnExt1.BtnText = "修改";
            this.ucBtnExt1.ConerRadius = 5;
            this.ucBtnExt1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucBtnExt1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.ucBtnExt1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnExt1.ForeColor = System.Drawing.Color.White;
            this.ucBtnExt1.IsRadius = true;
            this.ucBtnExt1.IsShowRect = false;
            this.ucBtnExt1.IsShowTips = false;
            this.ucBtnExt1.Location = new System.Drawing.Point(61, 18);
            this.ucBtnExt1.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt1.Name = "ucBtnExt1";
            this.ucBtnExt1.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnExt1.RectWidth = 1;
            this.ucBtnExt1.Size = new System.Drawing.Size(62, 29);
            this.ucBtnExt1.TabIndex = 29;
            this.ucBtnExt1.TabStop = false;
            this.ucBtnExt1.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt1.TipsText = "";
            // 
            // ucBtnExt2
            // 
            this.ucBtnExt2.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnExt2.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnExt2.BtnFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt2.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnExt2.BtnText = "新增";
            this.ucBtnExt2.ConerRadius = 5;
            this.ucBtnExt2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucBtnExt2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ucBtnExt2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnExt2.ForeColor = System.Drawing.Color.White;
            this.ucBtnExt2.IsRadius = true;
            this.ucBtnExt2.IsShowRect = false;
            this.ucBtnExt2.IsShowTips = false;
            this.ucBtnExt2.Location = new System.Drawing.Point(123, 18);
            this.ucBtnExt2.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt2.Name = "ucBtnExt2";
            this.ucBtnExt2.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnExt2.RectWidth = 1;
            this.ucBtnExt2.Size = new System.Drawing.Size(63, 29);
            this.ucBtnExt2.TabIndex = 30;
            this.ucBtnExt2.TabStop = false;
            this.ucBtnExt2.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt2.TipsText = "";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.ucBtnExt3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(626, 50);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // ucBtnExt3
            // 
            this.ucBtnExt3.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnExt3.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnExt3.BtnFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt3.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnExt3.BtnText = "新增";
            this.ucBtnExt3.ConerRadius = 5;
            this.ucBtnExt3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt3.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucBtnExt3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ucBtnExt3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnExt3.ForeColor = System.Drawing.Color.White;
            this.ucBtnExt3.IsRadius = true;
            this.ucBtnExt3.IsShowRect = false;
            this.ucBtnExt3.IsShowTips = false;
            this.ucBtnExt3.Location = new System.Drawing.Point(3, 18);
            this.ucBtnExt3.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt3.Name = "ucBtnExt3";
            this.ucBtnExt3.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnExt3.RectWidth = 1;
            this.ucBtnExt3.Size = new System.Drawing.Size(63, 29);
            this.ucBtnExt3.TabIndex = 30;
            this.ucBtnExt3.TabStop = false;
            this.ucBtnExt3.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt3.TipsText = "";
            // 
            // contextMenuStripGroup
            // 
            this.contextMenuStripGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加子分组ToolStripMenuItem,
            this.删除当前分组ToolStripMenuItem,
            this.修改当前分组ToolStripMenuItem});
            this.contextMenuStripGroup.Name = "contextMenuStripGroup";
            this.contextMenuStripGroup.Size = new System.Drawing.Size(149, 70);
            // 
            // 添加子分组ToolStripMenuItem
            // 
            this.添加子分组ToolStripMenuItem.Name = "添加子分组ToolStripMenuItem";
            this.添加子分组ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加子分组ToolStripMenuItem.Text = "添加子分组";
            // 
            // 删除当前分组ToolStripMenuItem
            // 
            this.删除当前分组ToolStripMenuItem.Name = "删除当前分组ToolStripMenuItem";
            this.删除当前分组ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除当前分组ToolStripMenuItem.Text = "删除当前分组";
            // 
            // 修改当前分组ToolStripMenuItem
            // 
            this.修改当前分组ToolStripMenuItem.Name = "修改当前分组ToolStripMenuItem";
            this.修改当前分组ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.修改当前分组ToolStripMenuItem.Text = "修改当前分组";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "open-16x16.png");
            this.imageList.Images.SetKeyName(1, "Name.png");
            // 
            // DeviceGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 519);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DeviceGroupForm";
            this.Text = "设备分组管理";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStripGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.IOTree ioTree;
        private SCADA_Controls.Controls.UCBtnExt ucBtnExt2;
        private SCADA_Controls.Controls.UCBtnExt ucBtnExt1;
        private SCADA_Controls.Controls.UCBtnExt ucBtnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private SCADA_Controls.Controls.UCBtnExt ucBtnExt3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGroup;
        private System.Windows.Forms.ToolStripMenuItem 添加子分组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除当前分组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改当前分组ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList;
    }
}