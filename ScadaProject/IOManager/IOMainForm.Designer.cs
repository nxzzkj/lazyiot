using Scada.Controls;

namespace IOManager
{
    partial class IOMainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOMainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载工程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建工程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发布工程toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.导出CSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.保存工程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem另存为 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.复制toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.剪贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.编辑点表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设备管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通讯通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.驱动管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通讯驱动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工程视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iO表视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日志视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolOpen = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolCreate = new System.Windows.Forms.ToolStripButton();
            this.toolPublish = new System.Windows.Forms.ToolStripButton();
            this.toolStripExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripCut = new System.Windows.Forms.ToolStripButton();
            this.toolCopy = new System.Windows.Forms.ToolStripButton();
            this.toolPaste = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolClose = new System.Windows.Forms.ToolStripButton();
            this.dockPanel = new Scada.Controls.DockPanel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.设备管理ToolStripMenuItem,
            this.通讯通道ToolStripMenuItem,
            this.驱动管理ToolStripMenuItem,
            this.视图ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1013, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载工程ToolStripMenuItem,
            this.新建工程ToolStripMenuItem,
            this.发布工程toolStripMenuItem,
            this.toolStripSeparator1,
            this.导出CSVToolStripMenuItem,
            this.toolStripSeparator6,
            this.保存工程ToolStripMenuItem,
            this.toolStripMenuItem另存为,
            this.toolStripSeparator7,
            this.退出系统ToolStripMenuItem});
            this.文件ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("文件ToolStripMenuItem.Image")));
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 加载工程ToolStripMenuItem
            // 
            this.加载工程ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("加载工程ToolStripMenuItem.Image")));
            this.加载工程ToolStripMenuItem.Name = "加载工程ToolStripMenuItem";
            this.加载工程ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.加载工程ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.加载工程ToolStripMenuItem.Text = "加载工程&O";
            this.加载工程ToolStripMenuItem.Click += new System.EventHandler(this.加载工程ToolStripMenuItem_Click);
            // 
            // 新建工程ToolStripMenuItem
            // 
            this.新建工程ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("新建工程ToolStripMenuItem.Image")));
            this.新建工程ToolStripMenuItem.Name = "新建工程ToolStripMenuItem";
            this.新建工程ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.新建工程ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.新建工程ToolStripMenuItem.Text = "新建工程&N";
            this.新建工程ToolStripMenuItem.Click += new System.EventHandler(this.新建工程ToolStripMenuItem_Click);
            // 
            // 发布工程toolStripMenuItem
            // 
            this.发布工程toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("发布工程toolStripMenuItem.Image")));
            this.发布工程toolStripMenuItem.Name = "发布工程toolStripMenuItem";
            this.发布工程toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.发布工程toolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.发布工程toolStripMenuItem.Text = "发布工程&P";
            this.发布工程toolStripMenuItem.Click += new System.EventHandler(this.发布工程toolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // 导出CSVToolStripMenuItem
            // 
            this.导出CSVToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("导出CSVToolStripMenuItem.Image")));
            this.导出CSVToolStripMenuItem.Name = "导出CSVToolStripMenuItem";
            this.导出CSVToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.导出CSVToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.导出CSVToolStripMenuItem.Text = "导出CSV工程";
            this.导出CSVToolStripMenuItem.Click += new System.EventHandler(this.导出CSVToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(185, 6);
            // 
            // 保存工程ToolStripMenuItem
            // 
            this.保存工程ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("保存工程ToolStripMenuItem.Image")));
            this.保存工程ToolStripMenuItem.Name = "保存工程ToolStripMenuItem";
            this.保存工程ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存工程ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.保存工程ToolStripMenuItem.Text = "保存工程&S";
            this.保存工程ToolStripMenuItem.Click += new System.EventHandler(this.保存工程ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem另存为
            // 
            this.toolStripMenuItem另存为.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem另存为.Image")));
            this.toolStripMenuItem另存为.Name = "toolStripMenuItem另存为";
            this.toolStripMenuItem另存为.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.toolStripMenuItem另存为.Size = new System.Drawing.Size(188, 22);
            this.toolStripMenuItem另存为.Text = "另存为...&A";
            this.toolStripMenuItem另存为.Click += new System.EventHandler(this.toolStripMenuItem另存为_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(185, 6);
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("退出系统ToolStripMenuItem.Image")));
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.退出系统ToolStripMenuItem.Text = "退出系统&E";
            this.退出系统ToolStripMenuItem.Click += new System.EventHandler(this.退出系统ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem,
            this.创建ToolStripMenuItem,
            this.修改ToolStripMenuItem,
            this.toolStripSeparator2,
            this.全选ToolStripMenuItem,
            this.取消全选ToolStripMenuItem,
            this.toolStripSeparator5,
            this.复制toolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.剪贴ToolStripMenuItem,
            this.toolStripSeparator8,
            this.编辑点表ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("编辑ToolStripMenuItem.Image")));
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(86, 21);
            this.编辑ToolStripMenuItem.Text = "IO点管理";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("删除ToolStripMenuItem.Image")));
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 创建ToolStripMenuItem
            // 
            this.创建ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("创建ToolStripMenuItem.Image")));
            this.创建ToolStripMenuItem.Name = "创建ToolStripMenuItem";
            this.创建ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.创建ToolStripMenuItem.Text = "新建";
            this.创建ToolStripMenuItem.Click += new System.EventHandler(this.创建ToolStripMenuItem_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("修改ToolStripMenuItem.Image")));
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // 全选ToolStripMenuItem
            // 
            this.全选ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("全选ToolStripMenuItem.Image")));
            this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
            this.全选ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.全选ToolStripMenuItem.Text = "全选";
            this.全选ToolStripMenuItem.Click += new System.EventHandler(this.全选ToolStripMenuItem_Click);
            // 
            // 取消全选ToolStripMenuItem
            // 
            this.取消全选ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("取消全选ToolStripMenuItem.Image")));
            this.取消全选ToolStripMenuItem.Name = "取消全选ToolStripMenuItem";
            this.取消全选ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.取消全选ToolStripMenuItem.Text = "取消全选";
            this.取消全选ToolStripMenuItem.Click += new System.EventHandler(this.取消全选ToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // 复制toolStripMenuItem
            // 
            this.复制toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("复制toolStripMenuItem.Image")));
            this.复制toolStripMenuItem.Name = "复制toolStripMenuItem";
            this.复制toolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.复制toolStripMenuItem.Text = "复制";
            this.复制toolStripMenuItem.Click += new System.EventHandler(this.复制toolStripMenuItem_Click);
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("粘贴ToolStripMenuItem.Image")));
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            this.粘贴ToolStripMenuItem.Click += new System.EventHandler(this.粘贴ToolStripMenuItem_Click);
            // 
            // 剪贴ToolStripMenuItem
            // 
            this.剪贴ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("剪贴ToolStripMenuItem.Image")));
            this.剪贴ToolStripMenuItem.Name = "剪贴ToolStripMenuItem";
            this.剪贴ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.剪贴ToolStripMenuItem.Text = "剪贴";
            this.剪贴ToolStripMenuItem.Click += new System.EventHandler(this.剪贴ToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(149, 6);
            // 
            // 编辑点表ToolStripMenuItem
            // 
            this.编辑点表ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("编辑点表ToolStripMenuItem.Image")));
            this.编辑点表ToolStripMenuItem.Name = "编辑点表ToolStripMenuItem";
            this.编辑点表ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.编辑点表ToolStripMenuItem.Text = "编辑点表";
            this.编辑点表ToolStripMenuItem.Click += new System.EventHandler(this.编辑点表ToolStripMenuItem_Click);
            // 
            // 设备管理ToolStripMenuItem
            // 
            this.设备管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加设备ToolStripMenuItem,
            this.删除设备ToolStripMenuItem,
            this.修改设备ToolStripMenuItem});
            this.设备管理ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("设备管理ToolStripMenuItem.Image")));
            this.设备管理ToolStripMenuItem.Name = "设备管理ToolStripMenuItem";
            this.设备管理ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.设备管理ToolStripMenuItem.Text = "设备管理";
            // 
            // 添加设备ToolStripMenuItem
            // 
            this.添加设备ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("添加设备ToolStripMenuItem.Image")));
            this.添加设备ToolStripMenuItem.Name = "添加设备ToolStripMenuItem";
            this.添加设备ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加设备ToolStripMenuItem.Text = "添加设备";
            this.添加设备ToolStripMenuItem.Click += new System.EventHandler(this.添加设备ToolStripMenuItem_Click);
            // 
            // 删除设备ToolStripMenuItem
            // 
            this.删除设备ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("删除设备ToolStripMenuItem.Image")));
            this.删除设备ToolStripMenuItem.Name = "删除设备ToolStripMenuItem";
            this.删除设备ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除设备ToolStripMenuItem.Text = "删除设备";
            this.删除设备ToolStripMenuItem.Click += new System.EventHandler(this.删除设备ToolStripMenuItem_Click);
            // 
            // 修改设备ToolStripMenuItem
            // 
            this.修改设备ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("修改设备ToolStripMenuItem.Image")));
            this.修改设备ToolStripMenuItem.Name = "修改设备ToolStripMenuItem";
            this.修改设备ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改设备ToolStripMenuItem.Text = "修改设备";
            this.修改设备ToolStripMenuItem.Click += new System.EventHandler(this.修改设备ToolStripMenuItem_Click);
            // 
            // 通讯通道ToolStripMenuItem
            // 
            this.通讯通道ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加通道ToolStripMenuItem,
            this.删除通道ToolStripMenuItem,
            this.修改通道ToolStripMenuItem});
            this.通讯通道ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("通讯通道ToolStripMenuItem.Image")));
            this.通讯通道ToolStripMenuItem.Name = "通讯通道ToolStripMenuItem";
            this.通讯通道ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.通讯通道ToolStripMenuItem.Text = "通讯通道";
            // 
            // 添加通道ToolStripMenuItem
            // 
            this.添加通道ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("添加通道ToolStripMenuItem.Image")));
            this.添加通道ToolStripMenuItem.Name = "添加通道ToolStripMenuItem";
            this.添加通道ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加通道ToolStripMenuItem.Text = "添加通道";
            this.添加通道ToolStripMenuItem.Click += new System.EventHandler(this.添加通道ToolStripMenuItem_Click);
            // 
            // 删除通道ToolStripMenuItem
            // 
            this.删除通道ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("删除通道ToolStripMenuItem.Image")));
            this.删除通道ToolStripMenuItem.Name = "删除通道ToolStripMenuItem";
            this.删除通道ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除通道ToolStripMenuItem.Text = "删除通道";
            this.删除通道ToolStripMenuItem.Click += new System.EventHandler(this.删除通道ToolStripMenuItem_Click);
            // 
            // 修改通道ToolStripMenuItem
            // 
            this.修改通道ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("修改通道ToolStripMenuItem.Image")));
            this.修改通道ToolStripMenuItem.Name = "修改通道ToolStripMenuItem";
            this.修改通道ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改通道ToolStripMenuItem.Text = "修改通道";
            this.修改通道ToolStripMenuItem.Click += new System.EventHandler(this.修改通道ToolStripMenuItem_Click);
            // 
            // 驱动管理ToolStripMenuItem
            // 
            this.驱动管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.通讯驱动ToolStripMenuItem});
            this.驱动管理ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("驱动管理ToolStripMenuItem.Image")));
            this.驱动管理ToolStripMenuItem.Name = "驱动ToolStripMenuItem";
            this.驱动管理ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.驱动管理ToolStripMenuItem.Text = "驱动管理";
            // 
            // 通讯驱动ToolStripMenuItem
            // 
            this.通讯驱动ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("通讯驱动ToolStripMenuItem.Image")));
            this.通讯驱动ToolStripMenuItem.Name = "驱动管理ToolStripMenuItem";
            this.通讯驱动ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.通讯驱动ToolStripMenuItem.Text = "驱动管理";
            this.通讯驱动ToolStripMenuItem.Click += new System.EventHandler(this.驱动管理ToolStripMenuItem_Click);
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工程视图ToolStripMenuItem,
            this.iO表视图ToolStripMenuItem,
            this.日志视图ToolStripMenuItem});
            this.视图ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("视图ToolStripMenuItem.Image")));
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.视图ToolStripMenuItem.Text = "视图";
            // 
            // 工程视图ToolStripMenuItem
            // 
            this.工程视图ToolStripMenuItem.Name = "工程视图ToolStripMenuItem";
            this.工程视图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.工程视图ToolStripMenuItem.Text = "工程视图";
            this.工程视图ToolStripMenuItem.Click += new System.EventHandler(this.工程视图ToolStripMenuItem_Click);
            // 
            // iO表视图ToolStripMenuItem
            // 
            this.iO表视图ToolStripMenuItem.Name = "iO表视图ToolStripMenuItem";
            this.iO表视图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.iO表视图ToolStripMenuItem.Text = "IO表视图";
            this.iO表视图ToolStripMenuItem.Click += new System.EventHandler(this.iO表视图ToolStripMenuItem_Click);
            // 
            // 日志视图ToolStripMenuItem
            // 
            this.日志视图ToolStripMenuItem.Name = "日志视图ToolStripMenuItem";
            this.日志视图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.日志视图ToolStripMenuItem.Text = "日志视图";
            this.日志视图ToolStripMenuItem.Click += new System.EventHandler(this.日志视图ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于我们ToolStripMenuItem,
            this.帮助ToolStripMenuItem1});
            this.帮助ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("帮助ToolStripMenuItem.Image")));
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于我们ToolStripMenuItem
            // 
            this.关于我们ToolStripMenuItem.Name = "关于我们ToolStripMenuItem";
            this.关于我们ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关于我们ToolStripMenuItem.Text = "关于我们";
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.帮助ToolStripMenuItem1.Text = "帮助";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolDate,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.progressBar,
            this.toolStripStatusLabel3,
            this.progressStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 452);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1013, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolDate
            // 
            this.toolDate.Image = ((System.Drawing.Image)(resources.GetObject("toolDate.Image")));
            this.toolDate.Name = "toolDate";
            this.toolDate.Size = new System.Drawing.Size(95, 17);
            this.toolDate.Text = "正式版 V2    ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(426, 17);
            this.toolStripStatusLabel1.Text = "版权所有：宁夏众智科技有限公司    联系电话:18695221159  QQ:249250126";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel2.Image")));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel2.ToolTipText = "任务进度";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(300, 16);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel3.Text = "状态:";
            // 
            // progressStatus
            // 
            this.progressStatus.Name = "progressStatus";
            this.progressStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOpen,
            this.toolSave,
            this.toolSaveAs,
            this.toolCreate,
            this.toolPublish,
            this.toolStripExport,
            this.toolStripSeparator3,
            this.toolStripCut,
            this.toolCopy,
            this.toolPaste,
            this.toolDelete,
            this.toolAdd,
            this.toolEdit,
            this.toolStripSeparator4,
            this.toolClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1013, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolOpen
            // 
            this.toolOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolOpen.Image")));
            this.toolOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOpen.Name = "toolOpen";
            this.toolOpen.Size = new System.Drawing.Size(23, 22);
            this.toolOpen.Text = "加载工程";
            this.toolOpen.Click += new System.EventHandler(this.加载工程ToolStripMenuItem_Click);
            // 
            // toolSave
            // 
            this.toolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(23, 22);
            this.toolSave.Text = "保存工程";
            this.toolSave.Click += new System.EventHandler(this.保存工程ToolStripMenuItem_Click);
            // 
            // toolSaveAs
            // 
            this.toolSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("toolSaveAs.Image")));
            this.toolSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveAs.Name = "toolSaveAs";
            this.toolSaveAs.Size = new System.Drawing.Size(23, 22);
            this.toolSaveAs.Text = "另存为";
            this.toolSaveAs.Click += new System.EventHandler(this.toolStripMenuItem另存为_Click);
            // 
            // toolCreate
            // 
            this.toolCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCreate.Image = ((System.Drawing.Image)(resources.GetObject("toolCreate.Image")));
            this.toolCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCreate.Name = "toolCreate";
            this.toolCreate.Size = new System.Drawing.Size(23, 22);
            this.toolCreate.Text = "新建工程";
            this.toolCreate.Click += new System.EventHandler(this.新建工程ToolStripMenuItem_Click);
            // 
            // toolPublish
            // 
            this.toolPublish.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPublish.Image = ((System.Drawing.Image)(resources.GetObject("toolPublish.Image")));
            this.toolPublish.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPublish.Name = "toolPublish";
            this.toolPublish.Size = new System.Drawing.Size(23, 22);
            this.toolPublish.Text = "发布工程";
            this.toolPublish.Click += new System.EventHandler(this.发布工程toolStripMenuItem_Click);
            // 
            // toolStripExport
            // 
            this.toolStripExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripExport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripExport.Image")));
            this.toolStripExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExport.Name = "toolStripExport";
            this.toolStripExport.Size = new System.Drawing.Size(23, 22);
            this.toolStripExport.Text = "导出工程";
            this.toolStripExport.Click += new System.EventHandler(this.导出CSVToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripCut
            // 
            this.toolStripCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCut.Image")));
            this.toolStripCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCut.Name = "toolStripCut";
            this.toolStripCut.Size = new System.Drawing.Size(23, 22);
            this.toolStripCut.Text = "剪贴IO点";
            this.toolStripCut.Click += new System.EventHandler(this.剪贴ToolStripMenuItem_Click);
            // 
            // toolCopy
            // 
            this.toolCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolCopy.Image")));
            this.toolCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCopy.Name = "toolCopy";
            this.toolCopy.Size = new System.Drawing.Size(23, 22);
            this.toolCopy.Text = "复制IO点";
            this.toolCopy.Click += new System.EventHandler(this.复制toolStripMenuItem_Click);
            // 
            // toolPaste
            // 
            this.toolPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPaste.Image = ((System.Drawing.Image)(resources.GetObject("toolPaste.Image")));
            this.toolPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPaste.Name = "toolPaste";
            this.toolPaste.Size = new System.Drawing.Size(23, 22);
            this.toolPaste.Text = "粘贴IO点";
            this.toolPaste.Click += new System.EventHandler(this.粘贴ToolStripMenuItem_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(23, 22);
            this.toolDelete.Text = "删除IO点";
            this.toolDelete.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // toolAdd
            // 
            this.toolAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolAdd.Image")));
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(23, 22);
            this.toolAdd.Text = "增加IO点";
            this.toolAdd.Click += new System.EventHandler(this.创建ToolStripMenuItem_Click);
            // 
            // toolEdit
            // 
            this.toolEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolEdit.Image")));
            this.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEdit.Name = "toolEdit";
            this.toolEdit.Size = new System.Drawing.Size(23, 22);
            this.toolEdit.Text = "编辑IO点";
            this.toolEdit.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolClose
            // 
            this.toolClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolClose.Image = ((System.Drawing.Image)(resources.GetObject("toolClose.Image")));
            this.toolClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClose.Name = "toolClose";
            this.toolClose.Size = new System.Drawing.Size(23, 22);
            this.toolClose.Text = "退出系统";
            this.toolClose.Click += new System.EventHandler(this.退出系统ToolStripMenuItem_Click);
            // 
            // dockPanel
            // 
            this.dockPanel.ActiveAutoHideContent = null;
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanel.Location = new System.Drawing.Point(0, 50);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(1013, 402);
            this.dockPanel.TabIndex = 3;
            // 
            // IOMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 474);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IOMainForm";
            this.Text = "采集站工程管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IOMainForm_FormClosing);
            this.Load += new System.EventHandler(this.IOMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建工程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发布工程toolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 保存工程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem另存为;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 全选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消全选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 驱动管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 通讯驱动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我们ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolOpen;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolSaveAs;
        private System.Windows.Forms.ToolStripButton toolCreate;
        private System.Windows.Forms.ToolStripButton toolPublish;
        private System.Windows.Forms.ToolStripButton toolStripCut;
        private System.Windows.Forms.ToolStripButton toolCopy;
        private System.Windows.Forms.ToolStripButton toolPaste;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem 通讯通道ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加通道ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除通道ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改通道ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设备管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改设备ToolStripMenuItem;
        private  DockPanel dockPanel;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工程视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iO表视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日志视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolClose;
        private System.Windows.Forms.ToolStripStatusLabel toolDate;
        public System.Windows.Forms.ToolStripProgressBar progressBar;
        public System.Windows.Forms.ToolStripStatusLabel progressStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 导出CSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripExport;
        public System.Windows.Forms.ToolStripMenuItem 加载工程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 剪贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem 编辑点表ToolStripMenuItem;
    }
}

