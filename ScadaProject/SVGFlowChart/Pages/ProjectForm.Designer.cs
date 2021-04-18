
using Scada.FlowGraphEngine.GraphicsCusControl;

namespace ScadaFlowDesign
{
    partial class ToolForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolForm));
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("油田");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("煤矿");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("煤层气");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("电力");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("农业");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("金属冶炼");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("其它");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("视图模板", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            this.contextMenuView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑名称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.拷贝视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设为主视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.应用背景到其它视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑权限ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存为模板视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuProject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.删除工程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.粘贴视图ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.创建视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.全部关闭视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部打开视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.预览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发布工程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.treeView = new Scada.FlowGraphEngine.GraphicsCusControl.IOFlowTree();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.treeViewTemplate = new System.Windows.Forms.TreeView();
            this.treeViewUser = new System.Windows.Forms.TreeView();
            this.contextMenuStripUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.treeViewConnections = new System.Windows.Forms.TreeView();
            this.contextMenuConnection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuConnectionDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加SqlServer数据源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加Oracle数据源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加MySql数据源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加SyBase数据源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加SQLit数据源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除数据源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑数据源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuView.SuspendLayout();
            this.contextMenuProject.SuspendLayout();
            this.contextMenuStripUser.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.contextMenuConnection.SuspendLayout();
            this.contextMenuConnectionDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuView
            // 
            this.contextMenuView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除视图ToolStripMenuItem,
            this.编辑名称ToolStripMenuItem,
            this.toolStripSeparator2,
            this.拷贝视图ToolStripMenuItem,
            this.设为主视图ToolStripMenuItem,
            this.toolStripSeparator6,
            this.应用背景到其它视图ToolStripMenuItem,
            this.编辑权限ToolStripMenuItem,
            this.保存为模板视图ToolStripMenuItem});
            this.contextMenuView.Name = "contextMenuView";
            this.contextMenuView.Size = new System.Drawing.Size(185, 170);
            // 
            // 删除视图ToolStripMenuItem
            // 
            this.删除视图ToolStripMenuItem.Name = "删除视图ToolStripMenuItem";
            this.删除视图ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.删除视图ToolStripMenuItem.Text = "删除视图";
            this.删除视图ToolStripMenuItem.Click += new System.EventHandler(this.删除视图ToolStripMenuItem_Click);
            // 
            // 编辑名称ToolStripMenuItem
            // 
            this.编辑名称ToolStripMenuItem.Name = "编辑名称ToolStripMenuItem";
            this.编辑名称ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.编辑名称ToolStripMenuItem.Text = "编辑视图";
            this.编辑名称ToolStripMenuItem.Click += new System.EventHandler(this.编辑名称ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // 拷贝视图ToolStripMenuItem
            // 
            this.拷贝视图ToolStripMenuItem.Name = "拷贝视图ToolStripMenuItem";
            this.拷贝视图ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.拷贝视图ToolStripMenuItem.Text = "拷贝视图";
            this.拷贝视图ToolStripMenuItem.Click += new System.EventHandler(this.拷贝视图ToolStripMenuItem_Click);
            // 
            // 设为主视图ToolStripMenuItem
            // 
            this.设为主视图ToolStripMenuItem.Name = "设为主视图ToolStripMenuItem";
            this.设为主视图ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.设为主视图ToolStripMenuItem.Text = "设为主视图";
            this.设为主视图ToolStripMenuItem.Click += new System.EventHandler(this.设为主视图ToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(181, 6);
            // 
            // 应用背景到其它视图ToolStripMenuItem
            // 
            this.应用背景到其它视图ToolStripMenuItem.Name = "应用背景到其它视图ToolStripMenuItem";
            this.应用背景到其它视图ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.应用背景到其它视图ToolStripMenuItem.Text = "应用背景到其它视图";
            this.应用背景到其它视图ToolStripMenuItem.Click += new System.EventHandler(this.应用背景到其它视图ToolStripMenuItem_Click);
            // 
            // 编辑权限ToolStripMenuItem
            // 
            this.编辑权限ToolStripMenuItem.Name = "编辑权限ToolStripMenuItem";
            this.编辑权限ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.编辑权限ToolStripMenuItem.Text = "编辑权限";
            this.编辑权限ToolStripMenuItem.Click += new System.EventHandler(this.编辑权限ToolStripMenuItem_Click);
            // 
            // 保存为模板视图ToolStripMenuItem
            // 
            this.保存为模板视图ToolStripMenuItem.Name = "保存为模板视图ToolStripMenuItem";
            this.保存为模板视图ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.保存为模板视图ToolStripMenuItem.Text = "保存为模板视图";
            this.保存为模板视图ToolStripMenuItem.Click += new System.EventHandler(this.toolStripSaveTemplateView_Click);
            // 
            // contextMenuProject
            // 
            this.contextMenuProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSave,
            this.toolStripSaveAs,
            this.删除工程ToolStripMenuItem,
            this.toolStripSeparator7,
            this.粘贴视图ToolStripMenuItem1,
            this.创建视图ToolStripMenuItem,
            this.toolStripSeparator3,
            this.修改密码ToolStripMenuItem,
            this.toolStripSeparator1,
            this.全部关闭视图ToolStripMenuItem,
            this.全部打开视图ToolStripMenuItem,
            this.toolStripSeparator4,
            this.预览ToolStripMenuItem,
            this.发布工程ToolStripMenuItem,
            this.toolStripSeparator5});
            this.contextMenuProject.Name = "contextMenuView";
            this.contextMenuProject.Size = new System.Drawing.Size(161, 254);
            // 
            // toolStripSave
            // 
            this.toolStripSave.Name = "toolStripSave";
            this.toolStripSave.Size = new System.Drawing.Size(160, 22);
            this.toolStripSave.Text = "保存工程";
            this.toolStripSave.Click += new System.EventHandler(this.toolStripSave_Click);
            // 
            // toolStripSaveAs
            // 
            this.toolStripSaveAs.Name = "toolStripSaveAs";
            this.toolStripSaveAs.Size = new System.Drawing.Size(160, 22);
            this.toolStripSaveAs.Text = "工程另存为...";
            this.toolStripSaveAs.Click += new System.EventHandler(this.toolStripSaveAs_Click);
            // 
            // 删除工程ToolStripMenuItem
            // 
            this.删除工程ToolStripMenuItem.Name = "删除工程ToolStripMenuItem";
            this.删除工程ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.删除工程ToolStripMenuItem.Text = "删除工程";
            this.删除工程ToolStripMenuItem.Click += new System.EventHandler(this.删除工程ToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(157, 6);
            // 
            // 粘贴视图ToolStripMenuItem1
            // 
            this.粘贴视图ToolStripMenuItem1.Name = "粘贴视图ToolStripMenuItem1";
            this.粘贴视图ToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.粘贴视图ToolStripMenuItem1.Text = "粘贴视图";
            this.粘贴视图ToolStripMenuItem1.Click += new System.EventHandler(this.粘贴视图ToolStripMenuItem1_Click);
            // 
            // 创建视图ToolStripMenuItem
            // 
            this.创建视图ToolStripMenuItem.Name = "创建视图ToolStripMenuItem";
            this.创建视图ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.创建视图ToolStripMenuItem.Text = "创建视图";
            this.创建视图ToolStripMenuItem.Click += new System.EventHandler(this.新增视图ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.修改密码ToolStripMenuItem.Text = "编辑密码与标题";
            this.修改密码ToolStripMenuItem.Click += new System.EventHandler(this.修改密码ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // 全部关闭视图ToolStripMenuItem
            // 
            this.全部关闭视图ToolStripMenuItem.Name = "全部关闭视图ToolStripMenuItem";
            this.全部关闭视图ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.全部关闭视图ToolStripMenuItem.Text = "全部关闭视图";
            this.全部关闭视图ToolStripMenuItem.Click += new System.EventHandler(this.全部关闭视图ToolStripMenuItem_Click);
            // 
            // 全部打开视图ToolStripMenuItem
            // 
            this.全部打开视图ToolStripMenuItem.Name = "全部打开视图ToolStripMenuItem";
            this.全部打开视图ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.全部打开视图ToolStripMenuItem.Text = "全部打开视图";
            this.全部打开视图ToolStripMenuItem.Click += new System.EventHandler(this.全部打开视图ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
            // 
            // 预览ToolStripMenuItem
            // 
            this.预览ToolStripMenuItem.Name = "预览ToolStripMenuItem";
            this.预览ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.预览ToolStripMenuItem.Text = "工程预览";
            this.预览ToolStripMenuItem.Click += new System.EventHandler(this.预览ToolStripMenuItem_Click);
            // 
            // 发布工程ToolStripMenuItem
            // 
            this.发布工程ToolStripMenuItem.Name = "发布工程ToolStripMenuItem";
            this.发布工程ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.发布工程ToolStripMenuItem.Text = "发布工程";
            this.发布工程ToolStripMenuItem.Click += new System.EventHandler(this.发布工程ToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(157, 6);
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView.FullRowSelect = true;
            this.treeView.HideSelection = false;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.Location = new System.Drawing.Point(3, 21);
            this.treeView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.ShowNodeToolTips = true;
            this.treeView.Size = new System.Drawing.Size(281, 858);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseDoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "open-16x16.png");
            this.imageList.Images.SetKeyName(1, "w9.ico");
            this.imageList.Images.SetKeyName(2, "KillQuery.png");
            this.imageList.Images.SetKeyName(3, "Users.png");
            this.imageList.Images.SetKeyName(4, "DropUser.png");
            // 
            // treeViewTemplate
            // 
            this.treeViewTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTemplate.FullRowSelect = true;
            this.treeViewTemplate.HideSelection = false;
            this.treeViewTemplate.ImageIndex = 0;
            this.treeViewTemplate.ImageList = this.imageList;
            this.treeViewTemplate.Location = new System.Drawing.Point(3, 21);
            this.treeViewTemplate.Name = "treeViewTemplate";
            treeNode9.Name = "油田";
            treeNode9.Text = "油田";
            treeNode10.Name = "煤矿";
            treeNode10.Text = "煤矿";
            treeNode11.Name = "煤层气";
            treeNode11.Text = "煤层气";
            treeNode12.Name = "电力";
            treeNode12.Text = "电力";
            treeNode13.Name = "农业";
            treeNode13.Text = "农业";
            treeNode14.Name = "金属冶炼";
            treeNode14.Text = "金属冶炼";
            treeNode15.Name = "其它";
            treeNode15.Text = "其它";
            treeNode16.Name = "视图模板";
            treeNode16.Text = "视图模板";
            this.treeViewTemplate.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode16});
            this.treeViewTemplate.SelectedImageIndex = 0;
            this.treeViewTemplate.Size = new System.Drawing.Size(287, 864);
            this.treeViewTemplate.TabIndex = 2;
            this.treeViewTemplate.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewTemplate_NodeMouseDoubleClick);
            // 
            // treeViewUser
            // 
            this.treeViewUser.ContextMenuStrip = this.contextMenuStripUser;
            this.treeViewUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewUser.FullRowSelect = true;
            this.treeViewUser.HideSelection = false;
            this.treeViewUser.ImageIndex = 0;
            this.treeViewUser.ImageList = this.imageList;
            this.treeViewUser.Location = new System.Drawing.Point(3, 21);
            this.treeViewUser.Name = "treeViewUser";
            this.treeViewUser.SelectedImageIndex = 0;
            this.treeViewUser.ShowNodeToolTips = true;
            this.treeViewUser.Size = new System.Drawing.Size(287, 864);
            this.treeViewUser.TabIndex = 3;
            this.treeViewUser.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewUser_NodeMouseDoubleClick);
            // 
            // contextMenuStripUser
            // 
            this.contextMenuStripUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加用户ToolStripMenuItem,
            this.编辑用户ToolStripMenuItem,
            this.删除用户ToolStripMenuItem});
            this.contextMenuStripUser.Name = "contextMenuStripUser";
            this.contextMenuStripUser.Size = new System.Drawing.Size(125, 70);
            // 
            // 添加用户ToolStripMenuItem
            // 
            this.添加用户ToolStripMenuItem.Name = "添加用户ToolStripMenuItem";
            this.添加用户ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加用户ToolStripMenuItem.Text = "添加用户";
            this.添加用户ToolStripMenuItem.Click += new System.EventHandler(this.添加用户ToolStripMenuItem_Click);
            // 
            // 编辑用户ToolStripMenuItem
            // 
            this.编辑用户ToolStripMenuItem.Name = "编辑用户ToolStripMenuItem";
            this.编辑用户ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.编辑用户ToolStripMenuItem.Text = "编辑用户";
            this.编辑用户ToolStripMenuItem.Click += new System.EventHandler(this.编辑用户ToolStripMenuItem_Click);
            // 
            // 删除用户ToolStripMenuItem
            // 
            this.删除用户ToolStripMenuItem.Name = "删除用户ToolStripMenuItem";
            this.删除用户ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除用户ToolStripMenuItem.Text = "删除用户";
            this.删除用户ToolStripMenuItem.Click += new System.EventHandler(this.删除用户ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeViewUser);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 888);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户列表";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeViewTemplate);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 888);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.treeView);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 882);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "工程";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ImageList = this.imageList;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(324, 896);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.ImageKey = "open-16x16.png";
            this.tabPage1.Location = new System.Drawing.Point(27, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(293, 888);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "工程";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeViewConnections);
            this.tabPage2.ImageKey = "w9.ico";
            this.tabPage2.Location = new System.Drawing.Point(27, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(293, 888);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "数据库";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.ImageKey = "Users.png";
            this.tabPage3.Location = new System.Drawing.Point(27, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(293, 888);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "用户";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.ImageKey = "KillQuery.png";
            this.tabPage4.Location = new System.Drawing.Point(27, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(293, 888);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "模板";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // treeViewConnections
            // 
            this.treeViewConnections.ContextMenuStrip = this.contextMenuConnection;
            this.treeViewConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewConnections.Location = new System.Drawing.Point(3, 3);
            this.treeViewConnections.Name = "treeViewConnections";
            this.treeViewConnections.Size = new System.Drawing.Size(287, 882);
            this.treeViewConnections.TabIndex = 0;
            // 
            // contextMenuConnection
            // 
            this.contextMenuConnection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加SqlServer数据源ToolStripMenuItem,
            this.添加Oracle数据源ToolStripMenuItem,
            this.添加MySql数据源ToolStripMenuItem,
            this.添加SyBase数据源ToolStripMenuItem,
            this.添加SQLit数据源ToolStripMenuItem});
            this.contextMenuConnection.Name = "contextMenuStripUser";
            this.contextMenuConnection.Size = new System.Drawing.Size(196, 114);
            // 
            // contextMenuConnectionDelete
            // 
            this.contextMenuConnectionDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除数据源ToolStripMenuItem,
            this.编辑数据源ToolStripMenuItem});
            this.contextMenuConnectionDelete.Name = "contextMenuStripUser";
            this.contextMenuConnectionDelete.Size = new System.Drawing.Size(181, 70);
            // 
            // 添加SqlServer数据源ToolStripMenuItem
            // 
            this.添加SqlServer数据源ToolStripMenuItem.Name = "添加SqlServer数据源ToolStripMenuItem";
            this.添加SqlServer数据源ToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.添加SqlServer数据源ToolStripMenuItem.Text = " 添加SqlServer数据源";
            this.添加SqlServer数据源ToolStripMenuItem.Click += new System.EventHandler(this.添加SqlServer数据源ToolStripMenuItem_Click);
            // 
            // 添加Oracle数据源ToolStripMenuItem
            // 
            this.添加Oracle数据源ToolStripMenuItem.Name = "添加Oracle数据源ToolStripMenuItem";
            this.添加Oracle数据源ToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.添加Oracle数据源ToolStripMenuItem.Text = " 添加Oracle数据源";
            this.添加Oracle数据源ToolStripMenuItem.Click += new System.EventHandler(this.添加Oracle数据源ToolStripMenuItem_Click);
            // 
            // 添加MySql数据源ToolStripMenuItem
            // 
            this.添加MySql数据源ToolStripMenuItem.Name = "添加MySql数据源ToolStripMenuItem";
            this.添加MySql数据源ToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.添加MySql数据源ToolStripMenuItem.Text = " 添加MySql数据源";
            this.添加MySql数据源ToolStripMenuItem.Click += new System.EventHandler(this.添加MySql数据源ToolStripMenuItem_Click);
            // 
            // 添加SyBase数据源ToolStripMenuItem
            // 
            this.添加SyBase数据源ToolStripMenuItem.Name = "添加SyBase数据源ToolStripMenuItem";
            this.添加SyBase数据源ToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.添加SyBase数据源ToolStripMenuItem.Text = "添加SyBase数据源";
            this.添加SyBase数据源ToolStripMenuItem.Click += new System.EventHandler(this.添加SyBase数据源ToolStripMenuItem_Click);
            // 
            // 添加SQLit数据源ToolStripMenuItem
            // 
            this.添加SQLit数据源ToolStripMenuItem.Name = "添加SQLit数据源ToolStripMenuItem";
            this.添加SQLit数据源ToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.添加SQLit数据源ToolStripMenuItem.Text = "添加SQLit数据源";
            this.添加SQLit数据源ToolStripMenuItem.Click += new System.EventHandler(this.添加SQLit数据源ToolStripMenuItem_Click);
            // 
            // 删除数据源ToolStripMenuItem
            // 
            this.删除数据源ToolStripMenuItem.Name = "删除数据源ToolStripMenuItem";
            this.删除数据源ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除数据源ToolStripMenuItem.Text = "删除数据源";
            this.删除数据源ToolStripMenuItem.Click += new System.EventHandler(this.删除数据源ToolStripMenuItem_Click);
            // 
            // 编辑数据源ToolStripMenuItem
            // 
            this.编辑数据源ToolStripMenuItem.Name = "编辑数据源ToolStripMenuItem";
            this.编辑数据源ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.编辑数据源ToolStripMenuItem.Text = "编辑数据源";
            this.编辑数据源ToolStripMenuItem.Click += new System.EventHandler(this.编辑数据源ToolStripMenuItem_Click);
            // 
            // ToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 896);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ToolForm";
            this.Text = "工程";
            this.contextMenuView.ResumeLayout(false);
            this.contextMenuProject.ResumeLayout(false);
            this.contextMenuStripUser.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.contextMenuConnection.ResumeLayout(false);
            this.contextMenuConnectionDelete.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IOFlowTree treeView;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip contextMenuView;
        private System.Windows.Forms.ToolStripMenuItem 删除视图ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuProject;
        private System.Windows.Forms.ToolStripMenuItem toolStripSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 删除工程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部关闭视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部打开视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 编辑名称ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 预览ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拷贝视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴视图ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 设为主视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem 应用背景到其它视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发布工程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.TreeView treeViewTemplate;
        private System.Windows.Forms.TreeView treeViewUser;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripUser;
        private System.Windows.Forms.ToolStripMenuItem 添加用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除用户ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripMenuItem 编辑权限ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存为模板视图ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TreeView treeViewConnections;
        private System.Windows.Forms.ContextMenuStrip contextMenuConnection;
        private System.Windows.Forms.ContextMenuStrip contextMenuConnectionDelete;
        private System.Windows.Forms.ToolStripMenuItem 添加SqlServer数据源ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加Oracle数据源ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加MySql数据源ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加SyBase数据源ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加SQLit数据源ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除数据源ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑数据源ToolStripMenuItem;
    }
}