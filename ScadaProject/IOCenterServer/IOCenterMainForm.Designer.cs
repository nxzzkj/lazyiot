namespace ScadaCenterServer
{
    partial class IOCenterMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOCenterMainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.dockPanel = new Scada.Controls.DockPanel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.监视器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止服务toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runBackToolMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.系统管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模拟器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.账户管理toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.网络配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerDate = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.实时库配置toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.备份管理toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.网络设置toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.账户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runBackMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.关闭ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.实时数据查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史数据查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史报警查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下置命令查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.报警配置日志toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.统计汇总查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.流程图管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.消息队列配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iO树ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日志窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.技术支持ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Image = ((System.Drawing.Image)(resources.GetObject("lblTitle.Image")));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 1);
            this.lblTitle.Size = new System.Drawing.Size(783, 25);
            this.lblTitle.Text = "LAZY OS 数据中心";
            this.lblTitle.DoubleClick += new System.EventHandler(this.lblTitle_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(755, 0);
            // 
            // btMin
            // 
            this.btMin.Location = new System.Drawing.Point(723, 0);
            // 
            // btMax
            // 
            this.btMax.BackColor = System.Drawing.Color.Transparent;
            this.btMax.Location = new System.Drawing.Point(693, 0);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.labelDate,
            this.ProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 441);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(783, 22);
            this.statusStrip.TabIndex = 10;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(176, 17);
            this.toolStripStatusLabel1.Text = "SCADA Center Server V2.0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusLabel2.Text = " ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel3.Image")));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(429, 17);
            this.toolStripStatusLabel3.Text = "版权所有:宁夏众智科技有限公司 电话:18695221159  QQ:249250126        ";
            // 
            // labelDate
            // 
            this.labelDate.Image = ((System.Drawing.Image)(resources.GetObject("labelDate.Image")));
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(142, 17);
            this.labelDate.Text = "2019-11-18 10:54:19";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(180, 16);
            // 
            // dockPanel
            // 
            this.dockPanel.ActiveAutoHideContent = null;
            this.dockPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanel.Location = new System.Drawing.Point(0, 53);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(783, 388);
            this.dockPanel.TabIndex = 11;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "SCADA数据服务中心";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.监视器ToolStripMenuItem,
            this.启动服务ToolStripMenuItem,
            this.停止服务toolStripMenuItem,
            this.runBackToolMenu,
            this.toolStripSeparator2,
            this.系统管理ToolStripMenuItem,
            this.模拟器ToolStripMenuItem,
            this.toolStripSeparator1,
            this.账户管理toolStripMenuItem1,
            this.网络配置ToolStripMenuItem,
            this.toolStripSeparator5,
            this.退出系统ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(149, 220);
            // 
            // 监视器ToolStripMenuItem
            // 
            this.监视器ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("监视器ToolStripMenuItem.Image")));
            this.监视器ToolStripMenuItem.Name = "监视器ToolStripMenuItem";
            this.监视器ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.监视器ToolStripMenuItem.Text = "服务监视器";
            this.监视器ToolStripMenuItem.Click += new System.EventHandler(this.监视器ToolStripMenuItem_Click);
            // 
            // 启动服务ToolStripMenuItem
            // 
            this.启动服务ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("启动服务ToolStripMenuItem.Image")));
            this.启动服务ToolStripMenuItem.Name = "启动服务ToolStripMenuItem";
            this.启动服务ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.启动服务ToolStripMenuItem.Text = "启动服务";
            this.启动服务ToolStripMenuItem.Click += new System.EventHandler(this.启动服务ToolStripMenuItem_Click);
            // 
            // 停止服务toolStripMenuItem
            // 
            this.停止服务toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("停止服务toolStripMenuItem.Image")));
            this.停止服务toolStripMenuItem.Name = "停止服务toolStripMenuItem";
            this.停止服务toolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.停止服务toolStripMenuItem.Text = "停止服务";
            this.停止服务toolStripMenuItem.Click += new System.EventHandler(this.停止服务toolStripMenuItem_Click);
            // 
            // runBackToolMenu
            // 
            this.runBackToolMenu.Checked = true;
            this.runBackToolMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.runBackToolMenu.Name = "runBackToolMenu";
            this.runBackToolMenu.Size = new System.Drawing.Size(148, 22);
            this.runBackToolMenu.Text = "后台运行";
            this.runBackToolMenu.Click += new System.EventHandler(this.runBackToolMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // 系统管理ToolStripMenuItem
            // 
            this.系统管理ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("系统管理ToolStripMenuItem.Image")));
            this.系统管理ToolStripMenuItem.Name = "系统管理ToolStripMenuItem";
            this.系统管理ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.系统管理ToolStripMenuItem.Text = "数据查询管理";
            this.系统管理ToolStripMenuItem.Click += new System.EventHandler(this.系统管理ToolStripMenuItem_Click);
            // 
            // 模拟器ToolStripMenuItem
            // 
            this.模拟器ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("模拟器ToolStripMenuItem.Image")));
            this.模拟器ToolStripMenuItem.Name = "模拟器ToolStripMenuItem";
            this.模拟器ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.模拟器ToolStripMenuItem.Text = "写入模拟器";
            this.模拟器ToolStripMenuItem.Click += new System.EventHandler(this.模拟器ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // 账户管理toolStripMenuItem1
            // 
            this.账户管理toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("账户管理toolStripMenuItem1.Image")));
            this.账户管理toolStripMenuItem1.Name = "账户管理toolStripMenuItem1";
            this.账户管理toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.账户管理toolStripMenuItem1.Text = "账户管理";
            this.账户管理toolStripMenuItem1.Click += new System.EventHandler(this.账户管理ToolStripMenuItem_Click);
            // 
            // 网络配置ToolStripMenuItem
            // 
            this.网络配置ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("网络配置ToolStripMenuItem.Image")));
            this.网络配置ToolStripMenuItem.Name = "网络配置ToolStripMenuItem";
            this.网络配置ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.网络配置ToolStripMenuItem.Text = "网络设置";
            this.网络配置ToolStripMenuItem.Click += new System.EventHandler(this.网络设置toolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(145, 6);
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("退出系统ToolStripMenuItem.Image")));
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.退出系统ToolStripMenuItem.Text = "退出系统";
            this.退出系统ToolStripMenuItem.Click += new System.EventHandler(this.退出系统ToolStripMenuItem_Click);
            // 
            // timerDate
            // 
            this.timerDate.Interval = 1000;
            this.timerDate.Tick += new System.EventHandler(this.timerDate_Tick);
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.系统ToolStripMenuItem,
            this.视图ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 26);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(783, 27);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.实时库配置toolStripMenuItem,
            this.备份管理toolStripMenuItem,
            this.网络设置toolStripMenuItem,
            this.账户管理ToolStripMenuItem,
            this.runBackMenu,
            this.toolStripSeparator3,
            this.关闭ToolStripMenuItem1,
            this.退出系统ToolStripMenuItem1});
            this.文件ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("文件ToolStripMenuItem.Image")));
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(63, 23);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 实时库配置toolStripMenuItem
            // 
            this.实时库配置toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("实时库配置toolStripMenuItem.Image")));
            this.实时库配置toolStripMenuItem.Name = "实时库配置toolStripMenuItem";
            this.实时库配置toolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.实时库配置toolStripMenuItem.Text = "实时库配置";
            this.实时库配置toolStripMenuItem.Click += new System.EventHandler(this.实时库配置toolStripMenuItem_Click);
            // 
            // 备份管理toolStripMenuItem
            // 
            this.备份管理toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("备份管理toolStripMenuItem.Image")));
            this.备份管理toolStripMenuItem.Name = "备份管理toolStripMenuItem";
            this.备份管理toolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.备份管理toolStripMenuItem.Text = "备份管理";
            this.备份管理toolStripMenuItem.Click += new System.EventHandler(this.备份管理toolStripMenuItem_Click);
            // 
            // 网络设置toolStripMenuItem
            // 
            this.网络设置toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("网络设置toolStripMenuItem.Image")));
            this.网络设置toolStripMenuItem.Name = "网络设置toolStripMenuItem";
            this.网络设置toolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.网络设置toolStripMenuItem.Text = "网络设置";
            this.网络设置toolStripMenuItem.Click += new System.EventHandler(this.网络设置toolStripMenuItem_Click);
            // 
            // 账户管理ToolStripMenuItem
            // 
            this.账户管理ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("账户管理ToolStripMenuItem.Image")));
            this.账户管理ToolStripMenuItem.Name = "账户管理ToolStripMenuItem";
            this.账户管理ToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.账户管理ToolStripMenuItem.Text = "账户管理";
            this.账户管理ToolStripMenuItem.Click += new System.EventHandler(this.账户管理ToolStripMenuItem_Click);
            // 
            // runBackMenu
            // 
            this.runBackMenu.Checked = true;
            this.runBackMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.runBackMenu.Name = "runBackMenu";
            this.runBackMenu.Size = new System.Drawing.Size(156, 24);
            this.runBackMenu.Text = "后台运行";
            this.runBackMenu.Click += new System.EventHandler(this.runBackMenu_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(153, 6);
            // 
            // 关闭ToolStripMenuItem1
            // 
            this.关闭ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("关闭ToolStripMenuItem1.Image")));
            this.关闭ToolStripMenuItem1.Name = "关闭ToolStripMenuItem1";
            this.关闭ToolStripMenuItem1.Size = new System.Drawing.Size(156, 24);
            this.关闭ToolStripMenuItem1.Text = "关闭管理界面";
            this.关闭ToolStripMenuItem1.Click += new System.EventHandler(this.关闭ToolStripMenuItem1_Click);
            // 
            // 退出系统ToolStripMenuItem1
            // 
            this.退出系统ToolStripMenuItem1.Name = "退出系统ToolStripMenuItem1";
            this.退出系统ToolStripMenuItem1.Size = new System.Drawing.Size(156, 24);
            this.退出系统ToolStripMenuItem1.Text = "退出系统";
            this.退出系统ToolStripMenuItem1.Click += new System.EventHandler(this.退出系统ToolStripMenuItem1_Click);
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.实时数据查询ToolStripMenuItem,
            this.历史数据查询ToolStripMenuItem,
            this.历史报警查询ToolStripMenuItem,
            this.下置命令查询ToolStripMenuItem,
            this.报警配置日志toolStripMenuItem,
            this.统计汇总查询ToolStripMenuItem,
            this.toolStripSeparator4,
            this.流程图管理ToolStripMenuItem,
            this.toolStripSeparator6,
            this.消息队列配置ToolStripMenuItem});
            this.系统ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("系统ToolStripMenuItem.Image")));
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(63, 23);
            this.系统ToolStripMenuItem.Text = "系统";
            // 
            // 实时数据查询ToolStripMenuItem
            // 
            this.实时数据查询ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("实时数据查询ToolStripMenuItem.Image")));
            this.实时数据查询ToolStripMenuItem.Name = "实时数据查询ToolStripMenuItem";
            this.实时数据查询ToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.实时数据查询ToolStripMenuItem.Text = "实时数据查询";
            this.实时数据查询ToolStripMenuItem.Click += new System.EventHandler(this.实时数据查询ToolStripMenuItem_Click);
            // 
            // 历史数据查询ToolStripMenuItem
            // 
            this.历史数据查询ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("历史数据查询ToolStripMenuItem.Image")));
            this.历史数据查询ToolStripMenuItem.Name = "历史数据查询ToolStripMenuItem";
            this.历史数据查询ToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.历史数据查询ToolStripMenuItem.Text = "历史数据查询";
            this.历史数据查询ToolStripMenuItem.Click += new System.EventHandler(this.历史数据查询ToolStripMenuItem_Click);
            // 
            // 历史报警查询ToolStripMenuItem
            // 
            this.历史报警查询ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("历史报警查询ToolStripMenuItem.Image")));
            this.历史报警查询ToolStripMenuItem.Name = "历史报警查询ToolStripMenuItem";
            this.历史报警查询ToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.历史报警查询ToolStripMenuItem.Text = "历史报警查询";
            this.历史报警查询ToolStripMenuItem.Click += new System.EventHandler(this.历史报警查询ToolStripMenuItem_Click);
            // 
            // 下置命令查询ToolStripMenuItem
            // 
            this.下置命令查询ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("下置命令查询ToolStripMenuItem.Image")));
            this.下置命令查询ToolStripMenuItem.Name = "下置命令查询ToolStripMenuItem";
            this.下置命令查询ToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.下置命令查询ToolStripMenuItem.Text = "下置命令查询";
            this.下置命令查询ToolStripMenuItem.Click += new System.EventHandler(this.下置命令查询ToolStripMenuItem_Click);
            // 
            // 报警配置日志toolStripMenuItem
            // 
            this.报警配置日志toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("报警配置日志toolStripMenuItem.Image")));
            this.报警配置日志toolStripMenuItem.Name = "报警配置日志toolStripMenuItem";
            this.报警配置日志toolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.报警配置日志toolStripMenuItem.Text = "报警配置日志";
            this.报警配置日志toolStripMenuItem.Click += new System.EventHandler(this.报警配置日志toolStripMenuItem_Click);
            // 
            // 统计汇总查询ToolStripMenuItem
            // 
            this.统计汇总查询ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("统计汇总查询ToolStripMenuItem.Image")));
            this.统计汇总查询ToolStripMenuItem.Name = "统计汇总查询ToolStripMenuItem";
            this.统计汇总查询ToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.统计汇总查询ToolStripMenuItem.Text = "统计汇总查询";
            this.统计汇总查询ToolStripMenuItem.Click += new System.EventHandler(this.统计汇总查询ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(153, 6);
            // 
            // 流程图管理ToolStripMenuItem
            // 
            this.流程图管理ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("流程图管理ToolStripMenuItem.Image")));
            this.流程图管理ToolStripMenuItem.Name = "流程图管理ToolStripMenuItem";
            this.流程图管理ToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.流程图管理ToolStripMenuItem.Text = "采集站管理";
            this.流程图管理ToolStripMenuItem.Click += new System.EventHandler(this.流程图管理ToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(153, 6);
            // 
            // 消息队列配置ToolStripMenuItem
            // 
            this.消息队列配置ToolStripMenuItem.Name = "消息队列配置ToolStripMenuItem";
            this.消息队列配置ToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.消息队列配置ToolStripMenuItem.Text = "消息队列管理";
            this.消息队列配置ToolStripMenuItem.Click += new System.EventHandler(this.消息队列配置ToolStripMenuItem_Click);
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iO树ToolStripMenuItem,
            this.属性ToolStripMenuItem,
            this.日志窗体ToolStripMenuItem});
            this.视图ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("视图ToolStripMenuItem.Image")));
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(63, 23);
            this.视图ToolStripMenuItem.Text = "视图";
            // 
            // iO树ToolStripMenuItem
            // 
            this.iO树ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("iO树ToolStripMenuItem.Image")));
            this.iO树ToolStripMenuItem.Name = "iO树ToolStripMenuItem";
            this.iO树ToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.iO树ToolStripMenuItem.Text = "IO树窗体";
            this.iO树ToolStripMenuItem.Click += new System.EventHandler(this.iO树ToolStripMenuItem_Click);
            // 
            // 属性ToolStripMenuItem
            // 
            this.属性ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("属性ToolStripMenuItem.Image")));
            this.属性ToolStripMenuItem.Name = "属性ToolStripMenuItem";
            this.属性ToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.属性ToolStripMenuItem.Text = "属性窗体";
            this.属性ToolStripMenuItem.Click += new System.EventHandler(this.属性ToolStripMenuItem_Click);
            // 
            // 日志窗体ToolStripMenuItem
            // 
            this.日志窗体ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("日志窗体ToolStripMenuItem.Image")));
            this.日志窗体ToolStripMenuItem.Name = "日志窗体ToolStripMenuItem";
            this.日志窗体ToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.日志窗体ToolStripMenuItem.Text = "日志窗体";
            this.日志窗体ToolStripMenuItem.Click += new System.EventHandler(this.日志窗体ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于我们ToolStripMenuItem,
            this.技术支持ToolStripMenuItem,
            this.系统帮助ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("帮助ToolStripMenuItem.Image")));
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(63, 23);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于我们ToolStripMenuItem
            // 
            this.关于我们ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("关于我们ToolStripMenuItem.Image")));
            this.关于我们ToolStripMenuItem.Name = "关于我们ToolStripMenuItem";
            this.关于我们ToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.关于我们ToolStripMenuItem.Text = "关于我们";
            this.关于我们ToolStripMenuItem.Click += new System.EventHandler(this.关于我们ToolStripMenuItem_Click);
            // 
            // 技术支持ToolStripMenuItem
            // 
            this.技术支持ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("技术支持ToolStripMenuItem.Image")));
            this.技术支持ToolStripMenuItem.Name = "技术支持ToolStripMenuItem";
            this.技术支持ToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.技术支持ToolStripMenuItem.Text = "技术支持";
            // 
            // 系统帮助ToolStripMenuItem
            // 
            this.系统帮助ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("系统帮助ToolStripMenuItem.Image")));
            this.系统帮助ToolStripMenuItem.Name = "系统帮助ToolStripMenuItem";
            this.系统帮助ToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.系统帮助ToolStripMenuItem.Text = "系统帮助";
            // 
            // IOCenterMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyleType = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.ClientSize = new System.Drawing.Size(783, 463);
            this.ControlBox = false;
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "IOCenterMainForm";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.Text = "LAZY OS数据管理中心";
            this.Title = "LAZY OS 数据中心";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IOCenterMainForm_FormClosing);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.statusStrip, 0);
            this.Controls.SetChildIndex(this.btMax, 0);
            this.Controls.SetChildIndex(this.btMin, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.menuStrip, 0);
            this.Controls.SetChildIndex(this.dockPanel, 0);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel labelDate;
        public Scada.Controls.DockPanel dockPanel;
        public System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 系统管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模拟器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 停止服务toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 监视器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Timer timerDate;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 实时库配置toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 备份管理toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 网络设置toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 账户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 实时数据查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史数据查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史报警查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下置命令查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 流程图管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iO树ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日志窗体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我们ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 技术支持ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 报警配置日志toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 统计汇总查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 账户管理toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 网络配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem 消息队列配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem runBackMenu;
        private System.Windows.Forms.ToolStripMenuItem runBackToolMenu;
    }
}

