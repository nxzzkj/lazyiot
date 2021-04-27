namespace IOMonitor
{
    partial class MonitorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorForm));
            this.panControl = new System.Windows.Forms.Panel();
            this.dockPanel = new Scada.Controls.DockPanel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ServerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runBakcMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.隐藏窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最小化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最大化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.正常窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.退出服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.采集站编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动采集模拟器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.网络配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日志视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.监视视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iO树视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.技术支持ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打卡监视器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.采集工程管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runBackToolMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.网络配置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.采集站模拟器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.退出采集站ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panControl.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Image = ((System.Drawing.Image)(resources.GetObject("lblTitle.Image")));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 1);
            this.lblTitle.Size = new System.Drawing.Size(991, 35);
            this.lblTitle.Text = "采集监视器";
            this.lblTitle.DoubleClick += new System.EventHandler(this.lblTitle_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.Location = new System.Drawing.Point(963, 5);
            this.btnClose.Size = new System.Drawing.Size(28, 27);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btMin
            // 
            this.btMin.BackColor = System.Drawing.Color.White;
            this.btMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btMin.BackgroundImage")));
            this.btMin.Location = new System.Drawing.Point(931, 5);
            this.btMin.Click += new System.EventHandler(this.btMin_Click);
            // 
            // btMax
            // 
            this.btMax.BackColor = System.Drawing.Color.White;
            this.btMax.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btMax.BackgroundImage")));
            this.btMax.Location = new System.Drawing.Point(901, 5);
            this.btMax.Click += new System.EventHandler(this.btMax_Click);
            // 
            // panControl
            // 
            this.panControl.AutoScroll = true;
            this.panControl.Controls.Add(this.dockPanel);
            this.panControl.Controls.Add(this.statusStrip);
            this.panControl.Controls.Add(this.menuStrip1);
            this.panControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panControl.Location = new System.Drawing.Point(0, 36);
            this.panControl.Name = "panControl";
            this.panControl.Size = new System.Drawing.Size(991, 478);
            this.panControl.TabIndex = 11;
            // 
            // dockPanel
            // 
            this.dockPanel.ActiveAutoHideContent = null;
            this.dockPanel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.dockPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dockPanel.BackgroundImage")));
            this.dockPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanel.Location = new System.Drawing.Point(0, 28);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(991, 421);
            this.dockPanel.TabIndex = 11;
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.ServerStatus,
            this.toolStripStatusLabel5,
            this.ProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 449);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(991, 29);
            this.statusStrip.TabIndex = 8;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(173, 24);
            this.toolStripStatusLabel1.Text = "Lazy SCADA Monitor V2.0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(20, 24);
            this.toolStripStatusLabel2.Text = "   ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel3.Image")));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(208, 24);
            this.toolStripStatusLabel3.Text = "版权所有：宁夏众智科技有限公司 ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(20, 24);
            this.toolStripStatusLabel4.Text = "   ";
            // 
            // ServerStatus
            // 
            this.ServerStatus.AutoToolTip = true;
            this.ServerStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ServerStatus.Image = ((System.Drawing.Image)(resources.GetObject("ServerStatus.Image")));
            this.ServerStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ServerStatus.Name = "ServerStatus";
            this.ServerStatus.Size = new System.Drawing.Size(112, 24);
            this.ServerStatus.Text = "     采集服务停止中";
            this.ServerStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel5.Image")));
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(176, 24);
            this.toolStripStatusLabel5.Text = "2019-11-18  10时19分27秒";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(150, 23);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.视图ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(991, 28);
            this.menuStrip1.TabIndex = 8;
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.停止服务ToolStripMenuItem,
            this.启动服务ToolStripMenuItem,
            this.runBakcMenu,
            this.toolStripSeparator2,
            this.隐藏窗体ToolStripMenuItem,
            this.最小化ToolStripMenuItem,
            this.最大化ToolStripMenuItem,
            this.正常窗体ToolStripMenuItem,
            this.toolStripSeparator3,
            this.退出服务ToolStripMenuItem});
            this.文件ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("文件ToolStripMenuItem.Image")));
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.文件ToolStripMenuItem.Text = "系统";
            // 
            // 停止服务ToolStripMenuItem
            // 
            this.停止服务ToolStripMenuItem.Name = "停止服务ToolStripMenuItem";
            this.停止服务ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.停止服务ToolStripMenuItem.Text = "停止服务";
            this.停止服务ToolStripMenuItem.Click += new System.EventHandler(this.停止服务ToolStripMenuItem_Click);
            // 
            // 启动服务ToolStripMenuItem
            // 
            this.启动服务ToolStripMenuItem.Name = "启动服务ToolStripMenuItem";
            this.启动服务ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.启动服务ToolStripMenuItem.Text = "启动服务";
            this.启动服务ToolStripMenuItem.Click += new System.EventHandler(this.启动服务ToolStripMenuItem_Click);
            // 
            // runBakcMenu
            // 
            this.runBakcMenu.Checked = true;
            this.runBakcMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.runBakcMenu.Name = "runBakcMenu";
            this.runBakcMenu.Size = new System.Drawing.Size(180, 24);
            this.runBakcMenu.Text = "后台运行";
            this.runBakcMenu.Click += new System.EventHandler(this.runBakcMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // 隐藏窗体ToolStripMenuItem
            // 
            this.隐藏窗体ToolStripMenuItem.Name = "隐藏窗体ToolStripMenuItem";
            this.隐藏窗体ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.隐藏窗体ToolStripMenuItem.Text = "隐藏窗体";
            this.隐藏窗体ToolStripMenuItem.Click += new System.EventHandler(this.btMin_Click);
            // 
            // 最小化ToolStripMenuItem
            // 
            this.最小化ToolStripMenuItem.Name = "最小化ToolStripMenuItem";
            this.最小化ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.最小化ToolStripMenuItem.Text = "最小化";
            this.最小化ToolStripMenuItem.Click += new System.EventHandler(this.btMin_Click);
            // 
            // 最大化ToolStripMenuItem
            // 
            this.最大化ToolStripMenuItem.Name = "最大化ToolStripMenuItem";
            this.最大化ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.最大化ToolStripMenuItem.Text = "最大化";
            this.最大化ToolStripMenuItem.Click += new System.EventHandler(this.btMax_Click);
            // 
            // 正常窗体ToolStripMenuItem
            // 
            this.正常窗体ToolStripMenuItem.Name = "正常窗体ToolStripMenuItem";
            this.正常窗体ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.正常窗体ToolStripMenuItem.Text = "正常窗体";
            this.正常窗体ToolStripMenuItem.Click += new System.EventHandler(this.正常窗体ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // 退出服务ToolStripMenuItem
            // 
            this.退出服务ToolStripMenuItem.Name = "退出服务ToolStripMenuItem";
            this.退出服务ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.退出服务ToolStripMenuItem.Text = "退出系统";
            this.退出服务ToolStripMenuItem.Click += new System.EventHandler(this.退出采集站ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出日志ToolStripMenuItem,
            this.toolStripSeparator4,
            this.采集站编辑ToolStripMenuItem,
            this.启动采集模拟器ToolStripMenuItem,
            this.toolStripSeparator5,
            this.网络配置ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("编辑ToolStripMenuItem.Image")));
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.编辑ToolStripMenuItem.Text = "管理";
            // 
            // 导出日志ToolStripMenuItem
            // 
            this.导出日志ToolStripMenuItem.Name = "导出日志ToolStripMenuItem";
            this.导出日志ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.导出日志ToolStripMenuItem.Text = "日志查询";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // 采集站编辑ToolStripMenuItem
            // 
            this.采集站编辑ToolStripMenuItem.Name = "采集站编辑ToolStripMenuItem";
            this.采集站编辑ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.采集站编辑ToolStripMenuItem.Text = "采集站编辑";
            this.采集站编辑ToolStripMenuItem.Click += new System.EventHandler(this.采集站编辑ToolStripMenuItem_Click);
            // 
            // 启动采集模拟器ToolStripMenuItem
            // 
            this.启动采集模拟器ToolStripMenuItem.Name = "启动采集模拟器ToolStripMenuItem";
            this.启动采集模拟器ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.启动采集模拟器ToolStripMenuItem.Text = "采集模拟器";
            this.启动采集模拟器ToolStripMenuItem.Click += new System.EventHandler(this.采集站模拟器ToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(145, 6);
            // 
            // 网络配置ToolStripMenuItem
            // 
            this.网络配置ToolStripMenuItem.Name = "网络配置ToolStripMenuItem";
            this.网络配置ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.网络配置ToolStripMenuItem.Text = "网络配置";
            this.网络配置ToolStripMenuItem.Click += new System.EventHandler(this.网络配置ToolStripMenuItem_Click);
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.属性视图ToolStripMenuItem,
            this.日志视图ToolStripMenuItem,
            this.监视视图ToolStripMenuItem,
            this.iO树视图ToolStripMenuItem});
            this.视图ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("视图ToolStripMenuItem.Image")));
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.视图ToolStripMenuItem.Text = "视图";
            // 
            // 属性视图ToolStripMenuItem
            // 
            this.属性视图ToolStripMenuItem.Name = "属性视图ToolStripMenuItem";
            this.属性视图ToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.属性视图ToolStripMenuItem.Text = "属性视图";
            // 
            // 日志视图ToolStripMenuItem
            // 
            this.日志视图ToolStripMenuItem.Name = "日志视图ToolStripMenuItem";
            this.日志视图ToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.日志视图ToolStripMenuItem.Text = "日志视图";
            // 
            // 监视视图ToolStripMenuItem
            // 
            this.监视视图ToolStripMenuItem.Name = "监视视图ToolStripMenuItem";
            this.监视视图ToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.监视视图ToolStripMenuItem.Text = "监视视图";
            // 
            // iO树视图ToolStripMenuItem
            // 
            this.iO树视图ToolStripMenuItem.Name = "iO树视图ToolStripMenuItem";
            this.iO树视图ToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.iO树视图ToolStripMenuItem.Text = "IO树视图";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于我们ToolStripMenuItem,
            this.系统帮助ToolStripMenuItem,
            this.技术支持ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("帮助ToolStripMenuItem.Image")));
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于我们ToolStripMenuItem
            // 
            this.关于我们ToolStripMenuItem.Name = "关于我们ToolStripMenuItem";
            this.关于我们ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.关于我们ToolStripMenuItem.Text = "关于我们";
            // 
            // 系统帮助ToolStripMenuItem
            // 
            this.系统帮助ToolStripMenuItem.Name = "系统帮助ToolStripMenuItem";
            this.系统帮助ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.系统帮助ToolStripMenuItem.Text = "系统帮助";
            // 
            // 技术支持ToolStripMenuItem
            // 
            this.技术支持ToolStripMenuItem.Name = "技术支持ToolStripMenuItem";
            this.技术支持ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.技术支持ToolStripMenuItem.Text = "技术支持";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "network_xp.ico");
            this.imageList.Images.SetKeyName(1, "winzip.ico");
            this.imageList.Images.SetKeyName(2, "play.ico");
            this.imageList.Images.SetKeyName(3, "unavailable.ico");
            this.imageList.Images.SetKeyName(4, "notepad2.ico");
            this.imageList.Images.SetKeyName(5, "ultramon.ico");
            this.imageList.Images.SetKeyName(6, "sysmetrix_2.ico");
            this.imageList.Images.SetKeyName(7, "app2.jpg");
            this.imageList.Images.SetKeyName(8, "sound.ico");
            this.imageList.Images.SetKeyName(9, "question.ico");
            this.imageList.Images.SetKeyName(10, "MSN Favorites.ico");
            this.imageList.Images.SetKeyName(11, "pocketpc.ico");
            this.imageList.Images.SetKeyName(12, "woman.ico");
            this.imageList.Images.SetKeyName(13, "continue.png");
            this.imageList.Images.SetKeyName(14, "pause.png");
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "宁夏众智科技有限公司开发的云组态系列产品";
            this.notifyIcon.BalloonTipTitle = "ZZSCADA Monitor";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ZZSCADA Monitor V2.0";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打卡监视器ToolStripMenuItem,
            this.采集工程管理ToolStripMenuItem,
            this.runBackToolMenu,
            this.toolStripSeparator1,
            this.网络配置ToolStripMenuItem1,
            this.采集站模拟器ToolStripMenuItem,
            this.toolStripSeparator6,
            this.退出采集站ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(161, 148);
            // 
            // 打卡监视器ToolStripMenuItem
            // 
            this.打卡监视器ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打卡监视器ToolStripMenuItem.Image")));
            this.打卡监视器ToolStripMenuItem.Name = "打卡监视器ToolStripMenuItem";
            this.打卡监视器ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.打卡监视器ToolStripMenuItem.Text = "采集服务监视器";
            this.打卡监视器ToolStripMenuItem.Click += new System.EventHandler(this.打卡监视器ToolStripMenuItem_Click);
            // 
            // 采集工程管理ToolStripMenuItem
            // 
            this.采集工程管理ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("采集工程管理ToolStripMenuItem.Image")));
            this.采集工程管理ToolStripMenuItem.Name = "采集工程管理ToolStripMenuItem";
            this.采集工程管理ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.采集工程管理ToolStripMenuItem.Text = "采集站工程管理";
            this.采集工程管理ToolStripMenuItem.Click += new System.EventHandler(this.采集工程管理ToolStripMenuItem_Click);
            // 
            // runBackToolMenu
            // 
            this.runBackToolMenu.Checked = true;
            this.runBackToolMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.runBackToolMenu.Name = "runBackToolMenu";
            this.runBackToolMenu.Size = new System.Drawing.Size(160, 22);
            this.runBackToolMenu.Text = "后台运行";
            this.runBackToolMenu.Click += new System.EventHandler(this.runBackToolMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // 网络配置ToolStripMenuItem1
            // 
            this.网络配置ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("网络配置ToolStripMenuItem1.Image")));
            this.网络配置ToolStripMenuItem1.Name = "网络配置ToolStripMenuItem1";
            this.网络配置ToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.网络配置ToolStripMenuItem1.Text = "网络配置";
            this.网络配置ToolStripMenuItem1.Click += new System.EventHandler(this.网络配置ToolStripMenuItem_Click);
            // 
            // 采集站模拟器ToolStripMenuItem
            // 
            this.采集站模拟器ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("采集站模拟器ToolStripMenuItem.Image")));
            this.采集站模拟器ToolStripMenuItem.Name = "采集站模拟器ToolStripMenuItem";
            this.采集站模拟器ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.采集站模拟器ToolStripMenuItem.Text = "采集站模拟器";
            this.采集站模拟器ToolStripMenuItem.Click += new System.EventHandler(this.采集站模拟器ToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(157, 6);
            // 
            // 退出采集站ToolStripMenuItem
            // 
            this.退出采集站ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("退出采集站ToolStripMenuItem.Image")));
            this.退出采集站ToolStripMenuItem.Name = "退出采集站ToolStripMenuItem";
            this.退出采集站ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.退出采集站ToolStripMenuItem.Text = "退出采集站";
            this.退出采集站ToolStripMenuItem.Click += new System.EventHandler(this.退出采集站ToolStripMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 514);
            this.Controls.Add(this.panControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MonitorForm";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.Text = "采集监视器";
            this.Title = "采集监视器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MonitorForm_FormClosing);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.panControl, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btMin, 0);
            this.Controls.SetChildIndex(this.btMax, 0);
            this.panControl.ResumeLayout(false);
            this.panControl.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panControl;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 打卡监视器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出采集站ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 采集工程管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public Scada.Controls.DockPanel dockPanel;
        private System.Windows.Forms.Timer timer;
        public System.Windows.Forms.ToolStripStatusLabel ServerStatus;
        public System.Windows.Forms.ImageList imageList;
        public System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripMenuItem 采集站模拟器ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 隐藏窗体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最小化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最大化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 正常窗体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 退出服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 采集站编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动采集模拟器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日志视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 监视视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iO树视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我们ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 技术支持ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 网络配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 网络配置ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem runBakcMenu;
        private System.Windows.Forms.ToolStripMenuItem runBackToolMenu;
    }
}