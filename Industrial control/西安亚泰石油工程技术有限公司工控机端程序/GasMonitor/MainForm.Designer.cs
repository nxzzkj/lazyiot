namespace GasMonitor
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("全部通道", 97, 97);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("1号通道", 59, 59);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("2号通道", 61, 61);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("3号通道", 72, 72);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("4号通道", 98, 98);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("5号通道", 44, 44);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("6号通道", 17, 17);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("监控通道", 13, 13, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("实时监控", 10, 10);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("实时曲线", 59, 59);
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("报警配置", 5, 5);
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("系统配置", 60, 60);
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("系统日志");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StyleManager = new Sunny.UI.UIStyleManager(this.components);
            this.uiAvatar = new Sunny.UI.UIAvatar();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.uiAvatar2 = new Sunny.UI.UIAvatar();
            this.Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // Aside
            // 
            this.Aside.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Aside.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Aside.ImageIndex = 0;
            this.Aside.ImageList = this.imageList;
            this.Aside.LineColor = System.Drawing.Color.Black;
            this.Aside.Location = new System.Drawing.Point(2, 45);
            this.Aside.MenuStyle = Sunny.UI.UIMenuStyle.Black;
            treeNode1.ImageIndex = 97;
            treeNode1.Name = "节点7";
            treeNode1.SelectedImageIndex = 97;
            treeNode1.Text = "全部通道";
            treeNode2.ImageIndex = 59;
            treeNode2.Name = "节点1";
            treeNode2.SelectedImageIndex = 59;
            treeNode2.Text = "1号通道";
            treeNode3.ImageIndex = 61;
            treeNode3.Name = "节点2";
            treeNode3.SelectedImageIndex = 61;
            treeNode3.Text = "2号通道";
            treeNode4.ImageIndex = 72;
            treeNode4.Name = "节点3";
            treeNode4.SelectedImageIndex = 72;
            treeNode4.Text = "3号通道";
            treeNode5.ImageIndex = 98;
            treeNode5.Name = "节点4";
            treeNode5.SelectedImageIndex = 98;
            treeNode5.Text = "4号通道";
            treeNode6.ImageIndex = 44;
            treeNode6.Name = "节点5";
            treeNode6.SelectedImageIndex = 44;
            treeNode6.Text = "5号通道";
            treeNode7.ImageIndex = 17;
            treeNode7.Name = "节点6";
            treeNode7.SelectedImageIndex = 17;
            treeNode7.Text = "6号通道";
            treeNode8.Checked = true;
            treeNode8.ImageIndex = 13;
            treeNode8.Name = "节点0";
            treeNode8.SelectedImageIndex = 13;
            treeNode8.Text = "监控通道";
            this.Aside.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8});
            this.Aside.SelectedImageIndex = 0;
            this.Aside.Size = new System.Drawing.Size(171, 658);
            this.Aside.Style = Sunny.UI.UIStyle.Custom;
            this.Aside.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Aside.MenuItemClick += new Sunny.UI.UINavMenu.OnMenuItemClick(this.Aside_MenuItemClick);
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Header.Controls.Add(this.uiAvatar2);
            this.Header.Controls.Add(this.uiAvatar);
            this.Header.DropMenuImageList = this.imageList;
            this.Header.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Header.ImageList = this.imageList;
            this.Header.Location = new System.Drawing.Point(2, 0);
            this.Header.MenuHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.Header.MenuStyle = Sunny.UI.UIMenuStyle.Black;
            this.Header.NodeAlignment = System.Drawing.StringAlignment.Center;
            treeNode9.Checked = true;
            treeNode9.ImageIndex = 10;
            treeNode9.Name = "节点0";
            treeNode9.SelectedImageIndex = 10;
            treeNode9.Text = "实时监控";
            treeNode10.ImageIndex = 59;
            treeNode10.Name = "节点1";
            treeNode10.SelectedImageIndex = 59;
            treeNode10.Text = "实时曲线";
            treeNode11.ImageIndex = 5;
            treeNode11.Name = "节点0";
            treeNode11.SelectedImageIndex = 5;
            treeNode11.Text = "报警配置";
            treeNode12.ImageIndex = 60;
            treeNode12.Name = "节点2";
            treeNode12.SelectedImageIndex = 60;
            treeNode12.Text = "系统配置";
            treeNode13.Name = "节点1";
            treeNode13.Text = "系统日志";
            this.Header.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
            this.Header.Size = new System.Drawing.Size(1284, 45);
            this.Header.Style = Sunny.UI.UIStyle.Custom;
            this.Header.MenuItemClick += new Sunny.UI.UINavBar.OnMenuItemClick(this.Header_MenuItemClick);
            // 
            // StyleManager
            // 
            this.StyleManager.Style = Sunny.UI.UIStyle.Black;
            // 
            // uiAvatar
            // 
            this.uiAvatar.AvatarSize = 45;
            this.uiAvatar.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiAvatar.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiAvatar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiAvatar.Location = new System.Drawing.Point(1237, 0);
            this.uiAvatar.Name = "uiAvatar";
            this.uiAvatar.Shape = Sunny.UI.UIShape.Square;
            this.uiAvatar.Size = new System.Drawing.Size(47, 45);
            this.uiAvatar.Style = Sunny.UI.UIStyle.Custom;
            this.uiAvatar.SymbolSize = 32;
            this.uiAvatar.TabIndex = 5;
            this.uiAvatar.Text = "退出系统";
            this.uiAvatar.Click += new System.EventHandler(this.uiAvatar_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "MediaCenter.ico");
            this.imageList.Images.SetKeyName(1, "memorystick.ico");
            this.imageList.Images.SetKeyName(2, "MovieMaker.ico");
            this.imageList.Images.SetKeyName(3, "MSN Favorites.ico");
            this.imageList.Images.SetKeyName(4, "MSN%20Calendar.ico");
            this.imageList.Images.SetKeyName(5, "My Music.ico");
            this.imageList.Images.SetKeyName(6, "My Pictures3.ico");
            this.imageList.Images.SetKeyName(7, "My%20Accounts%20Folder.ico");
            this.imageList.Images.SetKeyName(8, "MyNetPlaces.ico");
            this.imageList.Images.SetKeyName(9, "MyNetPlaces2.ico");
            this.imageList.Images.SetKeyName(10, "narrator.ico");
            this.imageList.Images.SetKeyName(11, "network%20connections.ico");
            this.imageList.Images.SetKeyName(12, "network%20harddrive.ico");
            this.imageList.Images.SetKeyName(13, "network_xp.ico");
            this.imageList.Images.SetKeyName(14, "Networked%20Printer_default.ico");
            this.imageList.Images.SetKeyName(15, "notepad2.ico");
            this.imageList.Images.SetKeyName(16, "nvidia_logo.ico");
            this.imageList.Images.SetKeyName(17, "Paint.ico");
            this.imageList.Images.SetKeyName(18, "paintbrush.ico");
            this.imageList.Images.SetKeyName(19, "PCMCIA.ico");
            this.imageList.Images.SetKeyName(20, "photoweb.ico");
            this.imageList.Images.SetKeyName(21, "play.ico");
            this.imageList.Images.SetKeyName(22, "pocketpc.ico");
            this.imageList.Images.SetKeyName(23, "Program Folder.ico");
            this.imageList.Images.SetKeyName(24, "question.ico");
            this.imageList.Images.SetKeyName(25, "RAID.ico");
            this.imageList.Images.SetKeyName(26, "regional options.ico");
            this.imageList.Images.SetKeyName(27, "remote.ico");
            this.imageList.Images.SetKeyName(28, "remote_desktop.ico");
            this.imageList.Images.SetKeyName(29, "scanner.ico");
            this.imageList.Images.SetKeyName(30, "scanner_camera.ico");
            this.imageList.Images.SetKeyName(31, "scanners%20and%20cameras.ico");
            this.imageList.Images.SetKeyName(32, "security2.ico");
            this.imageList.Images.SetKeyName(33, "server.ico");
            this.imageList.Images.SetKeyName(34, "set%20prog%20access%20and%20defaults.ico");
            this.imageList.Images.SetKeyName(35, "smart media.ico");
            this.imageList.Images.SetKeyName(36, "solitaire.ico");
            this.imageList.Images.SetKeyName(37, "sound.ico");
            this.imageList.Images.SetKeyName(38, "Sticky%20Notes.ico");
            this.imageList.Images.SetKeyName(39, "stopwatch.ico");
            this.imageList.Images.SetKeyName(40, "Stuffit%20File.ico");
            this.imageList.Images.SetKeyName(41, "sysmetrix_2.ico");
            this.imageList.Images.SetKeyName(42, "System%20Properties.ico");
            this.imageList.Images.SetKeyName(43, "system%20restore.ico");
            this.imageList.Images.SetKeyName(44, "thunderbird.ico");
            this.imageList.Images.SetKeyName(45, "tour.ico");
            this.imageList.Images.SetKeyName(46, "trash_design.ico");
            this.imageList.Images.SetKeyName(47, "ultimatezip.ico");
            this.imageList.Images.SetKeyName(48, "ultramon.ico");
            this.imageList.Images.SetKeyName(49, "unavailable.ico");
            this.imageList.Images.SetKeyName(50, "UT2k3.ico");
            this.imageList.Images.SetKeyName(51, "Videos%20Folder.ico");
            this.imageList.Images.SetKeyName(52, "Vista.ico");
            this.imageList.Images.SetKeyName(53, "Watercolor folder ergonomic.ico");
            this.imageList.Images.SetKeyName(54, "webprinter.ico");
            this.imageList.Images.SetKeyName(55, "webShots.ico");
            this.imageList.Images.SetKeyName(56, "winupdate.ico");
            this.imageList.Images.SetKeyName(57, "winXPflag.ico");
            this.imageList.Images.SetKeyName(58, "winzip.ico");
            this.imageList.Images.SetKeyName(59, "WMP_Performance.ico");
            this.imageList.Images.SetKeyName(60, "woman.ico");
            this.imageList.Images.SetKeyName(61, "workgroup.ico");
            this.imageList.Images.SetKeyName(62, "BackFill.png");
            this.imageList.Images.SetKeyName(63, "Connection.png");
            this.imageList.Images.SetKeyName(64, "ContinuousQuery.png");
            this.imageList.Images.SetKeyName(65, "CreateConnection.png");
            this.imageList.Images.SetKeyName(66, "CreateContinuousQuery.png");
            this.imageList.Images.SetKeyName(67, "CreateDatabase.png");
            this.imageList.Images.SetKeyName(68, "CreateRetentionPolicy.png");
            this.imageList.Images.SetKeyName(69, "CreateUser.png");
            this.imageList.Images.SetKeyName(70, "Database.png");
            this.imageList.Images.SetKeyName(71, "Date.png");
            this.imageList.Images.SetKeyName(72, "Diagnostics.png");
            this.imageList.Images.SetKeyName(73, "Disconnect.png");
            this.imageList.Images.SetKeyName(74, "DropContinuousQuery.png");
            this.imageList.Images.SetKeyName(75, "DropDatabase.png");
            this.imageList.Images.SetKeyName(76, "DropMeasurement.png");
            this.imageList.Images.SetKeyName(77, "DropRetentionPolicy.png");
            this.imageList.Images.SetKeyName(78, "DropSeries.png");
            this.imageList.Images.SetKeyName(79, "DropUser.png");
            this.imageList.Images.SetKeyName(80, "EditConnection.png");
            this.imageList.Images.SetKeyName(81, "EditPrivilege.png");
            this.imageList.Images.SetKeyName(82, "EditRetentionPolicy.png");
            this.imageList.Images.SetKeyName(83, "EditUser.png");
            this.imageList.Images.SetKeyName(84, "FieldKeys.png");
            this.imageList.Images.SetKeyName(85, "GrantPrivilege.png");
            this.imageList.Images.SetKeyName(86, "Info.png");
            this.imageList.Images.SetKeyName(87, "KillQuery.png");
            this.imageList.Images.SetKeyName(88, "Measurement.png");
            this.imageList.Images.SetKeyName(89, "NewQuery.png");
            this.imageList.Images.SetKeyName(90, "Password.png");
            this.imageList.Images.SetKeyName(91, "Refresh.png");
            this.imageList.Images.SetKeyName(92, "RetentionPolicy.png");
            this.imageList.Images.SetKeyName(93, "RunQuery.png");
            this.imageList.Images.SetKeyName(94, "Series.png");
            this.imageList.Images.SetKeyName(95, "ShowQueries.png");
            this.imageList.Images.SetKeyName(96, "ShowSeries.png");
            this.imageList.Images.SetKeyName(97, "Stats.png");
            this.imageList.Images.SetKeyName(98, "TagKeys.png");
            this.imageList.Images.SetKeyName(99, "TagValues.png");
            this.imageList.Images.SetKeyName(100, "Time.png");
            this.imageList.Images.SetKeyName(101, "Users.png");
            // 
            // uiAvatar2
            // 
            this.uiAvatar2.AvatarSize = 55;
            this.uiAvatar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiAvatar2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiAvatar2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiAvatar2.Icon = Sunny.UI.UIAvatar.UIIcon.Image;
            this.uiAvatar2.Image = ((System.Drawing.Image)(resources.GetObject("uiAvatar2.Image")));
            this.uiAvatar2.Location = new System.Drawing.Point(0, 0);
            this.uiAvatar2.Name = "uiAvatar2";
            this.uiAvatar2.Size = new System.Drawing.Size(48, 45);
            this.uiAvatar2.Style = Sunny.UI.UIStyle.Custom;
            this.uiAvatar2.Symbol = 57609;
            this.uiAvatar2.TabIndex = 6;
            this.uiAvatar2.Text = "uiAvatar2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 705);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.ShowDragStretch = true;
            this.ShowIcon = true;
            this.ShowRadius = false;
            this.ShowTitle = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "气体检测系统";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.TopMost = true;
            this.Header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIStyleManager StyleManager;
        private Sunny.UI.UIAvatar uiAvatar;
        private System.Windows.Forms.ImageList imageList;
        private Sunny.UI.UIAvatar uiAvatar2;
    }
}

