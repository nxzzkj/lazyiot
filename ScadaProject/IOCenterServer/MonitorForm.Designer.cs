using Scada.Controls.Controls;
using Scada.Controls.Controls.List;
using ScadaCenterServer.Controls;

namespace ScadaCenterServer
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelIP = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelStatus = new System.Windows.Forms.Label();
            this.ucAlarm = new Scada.Controls.Controls.UCAlarmLamp();
            this.ucledDate = new Scada.Controls.Controls.UCLEDNums();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ucBtnStart = new Scada.Controls.Controls.UCBtnExt();
            this.ucBtnCommand = new Scada.Controls.Controls.UCBtnExt();
            this.ucBtnStop = new Scada.Controls.Controls.UCBtnExt();
            this.ucBtnPause = new Scada.Controls.Controls.UCBtnExt();
            this.ucBtnContinue = new Scada.Controls.Controls.UCBtnExt();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControlExt = new Scada.Controls.Controls.TabControlExt();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.IOTreeView = new ScadaCenterServer.Controls.IOTree();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.computerInfoControl = new Scada.Controls.Controls.ComputerInfoControl();
            this.tabControlMonitor = new Scada.Controls.Controls.TabControlExt();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ucLog = new Scada.Controls.Controls.UCCheckBox();
            this.cbLogSize = new Scada.Controls.Controls.SCADAPageCombox();
            this.listViewReport = new Scada.Controls.Controls.List.SCADAListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucSplitLine_H4 = new Scada.Controls.Controls.UCSplitLine_H();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbReceiveSize = new Scada.Controls.Controls.SCADAPageCombox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ucReceive = new Scada.Controls.Controls.UCCheckBox();
            this.listViewReceive = new Scada.Controls.Controls.List.SCADAListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucSplitLine_H3 = new Scada.Controls.Controls.UCSplitLine_H();
            this.cbSendCommandSize = new Scada.Controls.Controls.SCADAPageCombox();
            this.ucbSendCommand = new Scada.Controls.Controls.UCCheckBox();
            this.listViewSendCommand = new Scada.Controls.Controls.List.SCADAListView();
            this.columnDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnserver = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columndevice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columniopara = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnvalue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnresult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnuser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucSplitLine_H2 = new Scada.Controls.Controls.UCSplitLine_H();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ucEnableAlarm = new Scada.Controls.Controls.UCCheckBox();
            this.listViewAlarm = new Scada.Controls.Controls.List.SCADAListView();
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucSplitLine_H5 = new Scada.Controls.Controls.UCSplitLine_H();
            this.cbAlarmSize = new Scada.Controls.Controls.SCADAPageCombox();
            this.label10 = new System.Windows.Forms.Label();
            this.systimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControlExt.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControlMonitor.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(0, 1);
            this.lblTitle.Size = new System.Drawing.Size(1101, 26);
            this.lblTitle.Text = "SCADA数据中心实时接收器";
            this.lblTitle.DoubleClick += new System.EventHandler(this.lblTitle_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1073, 0);
            // 
            // btMin
            // 
            this.btMin.Location = new System.Drawing.Point(1041, 0);
            this.btMin.Click += new System.EventHandler(this.btMin_Click);
            // 
            // btMax
            // 
            this.btMax.Location = new System.Drawing.Point(1011, 0);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(804, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "采集器采集接收数据:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "连接的客户端列表:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "本地IP:";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(327, 35);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(0, 17);
            this.labelIP.TabIndex = 15;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel1.Controls.Add(this.labelStatus);
            this.splitContainer1.Panel1.Controls.Add(this.ucAlarm);
            this.splitContainer1.Panel1.Controls.Add(this.ucledDate);
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1101, 545);
            this.splitContainer1.SplitterDistance = 39;
            this.splitContainer1.TabIndex = 16;
            // 
            // labelStatus
            // 
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelStatus.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStatus.Location = new System.Drawing.Point(684, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(55, 39);
            this.labelStatus.TabIndex = 49;
            this.labelStatus.Text = "停止";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucAlarm
            // 
            this.ucAlarm.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucAlarm.LampColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Yellow};
            this.ucAlarm.Lampstand = System.Drawing.Color.DarkGray;
            this.ucAlarm.Location = new System.Drawing.Point(739, 0);
            this.ucAlarm.Name = "ucAlarm";
            this.ucAlarm.Size = new System.Drawing.Size(44, 39);
            this.ucAlarm.TabIndex = 48;
            this.ucAlarm.TwinkleSpeed = 200;
            // 
            // ucledDate
            // 
            this.ucledDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucledDate.Font = new System.Drawing.Font("微软雅黑", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucledDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucledDate.LineWidth = 7;
            this.ucledDate.Location = new System.Drawing.Point(783, 0);
            this.ucledDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucledDate.Name = "ucledDate";
            this.ucledDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ucledDate.Size = new System.Drawing.Size(318, 39);
            this.ucledDate.TabIndex = 47;
            this.ucledDate.Value = "12:11:11";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.ucBtnStart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucBtnCommand, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucBtnStop, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucBtnPause, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucBtnContinue, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(555, 39);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // ucBtnStart
            // 
            this.ucBtnStart.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnStart.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnStart.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnStart.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnStart.BtnText = "启动服务";
            this.ucBtnStart.ConerRadius = 34;
            this.ucBtnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBtnStart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ucBtnStart.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnStart.ForeColor = System.Drawing.Color.White;
            this.ucBtnStart.IsRadius = true;
            this.ucBtnStart.IsShowRect = false;
            this.ucBtnStart.IsShowTips = false;
            this.ucBtnStart.Location = new System.Drawing.Point(0, 0);
            this.ucBtnStart.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnStart.Name = "ucBtnStart";
            this.ucBtnStart.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnStart.RectWidth = 1;
            this.ucBtnStart.Size = new System.Drawing.Size(111, 39);
            this.ucBtnStart.TabIndex = 16;
            this.ucBtnStart.TabStop = false;
            this.ucBtnStart.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnStart.TipsText = "";
            this.ucBtnStart.BtnClick += new System.EventHandler(this.btStart_Click);
            // 
            // ucBtnCommand
            // 
            this.ucBtnCommand.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnCommand.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnCommand.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnCommand.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnCommand.BtnText = "下置数据";
            this.ucBtnCommand.ConerRadius = 34;
            this.ucBtnCommand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBtnCommand.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ucBtnCommand.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnCommand.ForeColor = System.Drawing.Color.White;
            this.ucBtnCommand.IsRadius = true;
            this.ucBtnCommand.IsShowRect = false;
            this.ucBtnCommand.IsShowTips = false;
            this.ucBtnCommand.Location = new System.Drawing.Point(444, 0);
            this.ucBtnCommand.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnCommand.Name = "ucBtnCommand";
            this.ucBtnCommand.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnCommand.RectWidth = 1;
            this.ucBtnCommand.Size = new System.Drawing.Size(111, 39);
            this.ucBtnCommand.TabIndex = 20;
            this.ucBtnCommand.TabStop = false;
            this.ucBtnCommand.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnCommand.TipsText = "";
            this.ucBtnCommand.BtnClick += new System.EventHandler(this.btSend_Click);
            // 
            // ucBtnStop
            // 
            this.ucBtnStop.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnStop.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnStop.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnStop.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnStop.BtnText = "停止服务";
            this.ucBtnStop.ConerRadius = 34;
            this.ucBtnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBtnStop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.ucBtnStop.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnStop.ForeColor = System.Drawing.Color.White;
            this.ucBtnStop.IsRadius = true;
            this.ucBtnStop.IsShowRect = false;
            this.ucBtnStop.IsShowTips = false;
            this.ucBtnStop.Location = new System.Drawing.Point(333, 0);
            this.ucBtnStop.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnStop.Name = "ucBtnStop";
            this.ucBtnStop.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnStop.RectWidth = 1;
            this.ucBtnStop.Size = new System.Drawing.Size(111, 39);
            this.ucBtnStop.TabIndex = 17;
            this.ucBtnStop.TabStop = false;
            this.ucBtnStop.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnStop.TipsText = "";
            this.ucBtnStop.BtnClick += new System.EventHandler(this.btClose_Click);
            // 
            // ucBtnPause
            // 
            this.ucBtnPause.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnPause.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnPause.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnPause.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnPause.BtnText = "暂停服务";
            this.ucBtnPause.ConerRadius = 34;
            this.ucBtnPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnPause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBtnPause.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.ucBtnPause.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnPause.ForeColor = System.Drawing.Color.White;
            this.ucBtnPause.IsRadius = true;
            this.ucBtnPause.IsShowRect = false;
            this.ucBtnPause.IsShowTips = false;
            this.ucBtnPause.Location = new System.Drawing.Point(111, 0);
            this.ucBtnPause.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnPause.Name = "ucBtnPause";
            this.ucBtnPause.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnPause.RectWidth = 1;
            this.ucBtnPause.Size = new System.Drawing.Size(111, 39);
            this.ucBtnPause.TabIndex = 18;
            this.ucBtnPause.TabStop = false;
            this.ucBtnPause.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnPause.TipsText = "";
            this.ucBtnPause.BtnClick += new System.EventHandler(this.btPause_Click);
            // 
            // ucBtnContinue
            // 
            this.ucBtnContinue.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnContinue.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnContinue.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnContinue.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnContinue.BtnText = "继续服务";
            this.ucBtnContinue.ConerRadius = 34;
            this.ucBtnContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnContinue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBtnContinue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.ucBtnContinue.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnContinue.ForeColor = System.Drawing.Color.White;
            this.ucBtnContinue.IsRadius = true;
            this.ucBtnContinue.IsShowRect = false;
            this.ucBtnContinue.IsShowTips = false;
            this.ucBtnContinue.Location = new System.Drawing.Point(222, 0);
            this.ucBtnContinue.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnContinue.Name = "ucBtnContinue";
            this.ucBtnContinue.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnContinue.RectWidth = 1;
            this.ucBtnContinue.Size = new System.Drawing.Size(111, 39);
            this.ucBtnContinue.TabIndex = 19;
            this.ucBtnContinue.TabStop = false;
            this.ucBtnContinue.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnContinue.TipsText = "";
            this.ucBtnContinue.BtnClick += new System.EventHandler(this.btContinue_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabControlExt);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControlMonitor);
            this.splitContainer2.Size = new System.Drawing.Size(1101, 502);
            this.splitContainer2.SplitterDistance = 279;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabControlExt
            // 
            this.tabControlExt.Controls.Add(this.tabPage1);
            this.tabControlExt.Controls.Add(this.tabPage2);
            this.tabControlExt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlExt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlExt.IsShowCloseBtn = false;
            this.tabControlExt.ItemSize = new System.Drawing.Size(0, 30);
            this.tabControlExt.Location = new System.Drawing.Point(0, 0);
            this.tabControlExt.Name = "tabControlExt";
            this.tabControlExt.SelectedIndex = 0;
            this.tabControlExt.Size = new System.Drawing.Size(279, 502);
            this.tabControlExt.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.IOTreeView);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(271, 464);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "IO树";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // IOTreeView
            // 
            this.IOTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IOTreeView.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IOTreeView.ImageIndex = 0;
            this.IOTreeView.ImageList = this.imageList1;
            this.IOTreeView.Location = new System.Drawing.Point(3, 3);
            this.IOTreeView.Name = "IOTreeView";
            this.IOTreeView.SelectedImageIndex = 0;
            this.IOTreeView.Size = new System.Drawing.Size(265, 458);
            this.IOTreeView.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "network%20harddrive.ico");
            this.imageList1.Images.SetKeyName(1, "comm2.png");
            this.imageList1.Images.SetKeyName(2, "comm1.png");
            this.imageList1.Images.SetKeyName(3, "RAID.ico");
            this.imageList1.Images.SetKeyName(4, "wifi2.png");
            this.imageList1.Images.SetKeyName(5, "wifi.png");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flowLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(271, 464);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "资源";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.computerInfoControl);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(265, 458);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // computerInfoControl
            // 
            this.computerInfoControl.Location = new System.Drawing.Point(3, 3);
            this.computerInfoControl.Name = "computerInfoControl";
            this.computerInfoControl.Size = new System.Drawing.Size(232, 733);
            this.computerInfoControl.TabIndex = 0;
            // 
            // tabControlMonitor
            // 
            this.tabControlMonitor.Controls.Add(this.tabPage4);
            this.tabControlMonitor.Controls.Add(this.tabPage3);
            this.tabControlMonitor.Controls.Add(this.tabPage5);
            this.tabControlMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMonitor.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlMonitor.IsShowCloseBtn = false;
            this.tabControlMonitor.ItemSize = new System.Drawing.Size(0, 30);
            this.tabControlMonitor.Location = new System.Drawing.Point(0, 0);
            this.tabControlMonitor.Name = "tabControlMonitor";
            this.tabControlMonitor.SelectedIndex = 0;
            this.tabControlMonitor.Size = new System.Drawing.Size(818, 502);
            this.tabControlMonitor.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ucLog);
            this.tabPage4.Controls.Add(this.cbLogSize);
            this.tabPage4.Controls.Add(this.listViewReport);
            this.tabPage4.Controls.Add(this.ucSplitLine_H4);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(810, 464);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "系统报告";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ucLog
            // 
            this.ucLog.BackColor = System.Drawing.Color.Transparent;
            this.ucLog.Checked = true;
            this.ucLog.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ucLog.Location = new System.Drawing.Point(106, 3);
            this.ucLog.Name = "ucLog";
            this.ucLog.Padding = new System.Windows.Forms.Padding(1);
            this.ucLog.Size = new System.Drawing.Size(100, 22);
            this.ucLog.TabIndex = 19;
            this.ucLog.TextValue = "实时显示";
            // 
            // cbLogSize
            // 
            this.cbLogSize.BackColor = System.Drawing.Color.Transparent;
            this.cbLogSize.BackColorExt = System.Drawing.SystemColors.ControlLightLight;
            this.cbLogSize.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLogSize.ConerRadius = 5;
            this.cbLogSize.DropPanelHeight = -1;
            this.cbLogSize.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbLogSize.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbLogSize.IsRadius = true;
            this.cbLogSize.IsShowRect = true;
            this.cbLogSize.ItemWidth = 70;
            this.cbLogSize.Location = new System.Drawing.Point(215, 2);
            this.cbLogSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLogSize.Name = "cbLogSize";
            this.cbLogSize.RectColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbLogSize.RectWidth = 1;
            this.cbLogSize.SelectedIndex = 0;
            this.cbLogSize.SelectedValue = "100";
            this.cbLogSize.Size = new System.Drawing.Size(173, 23);
            this.cbLogSize.Source = ((System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>)(resources.GetObject("cbLogSize.Source")));
            this.cbLogSize.TabIndex = 25;
            this.cbLogSize.TextValue = "显示最近100条";
            this.cbLogSize.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // listViewReport
            // 
            this.listViewReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listViewReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewReport.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewReport.FullRowSelect = true;
            this.listViewReport.GridLines = true;
            this.listViewReport.Location = new System.Drawing.Point(3, 28);
            this.listViewReport.Name = "listViewReport";
            this.listViewReport.Size = new System.Drawing.Size(804, 433);
            this.listViewReport.TabIndex = 12;
            this.listViewReport.UseCompatibleStateImageBehavior = false;
            this.listViewReport.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "报告时间";
            this.columnHeader3.Width = 137;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "报告内容";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 415;
            // 
            // ucSplitLine_H4
            // 
            this.ucSplitLine_H4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ucSplitLine_H4.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSplitLine_H4.Location = new System.Drawing.Point(3, 27);
            this.ucSplitLine_H4.Name = "ucSplitLine_H4";
            this.ucSplitLine_H4.Size = new System.Drawing.Size(804, 1);
            this.ucSplitLine_H4.TabIndex = 14;
            this.ucSplitLine_H4.TabStop = false;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(804, 24);
            this.label7.TabIndex = 13;
            this.label7.Text = "系统事件日志:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbReceiveSize);
            this.tabPage3.Controls.Add(this.splitContainer3);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(810, 464);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "数据监视";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbReceiveSize
            // 
            this.cbReceiveSize.BackColor = System.Drawing.Color.Transparent;
            this.cbReceiveSize.BackColorExt = System.Drawing.SystemColors.ControlLightLight;
            this.cbReceiveSize.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReceiveSize.ConerRadius = 5;
            this.cbReceiveSize.DropPanelHeight = -1;
            this.cbReceiveSize.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbReceiveSize.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbReceiveSize.IsRadius = true;
            this.cbReceiveSize.IsShowRect = true;
            this.cbReceiveSize.ItemWidth = 70;
            this.cbReceiveSize.Location = new System.Drawing.Point(267, 3);
            this.cbReceiveSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbReceiveSize.Name = "cbReceiveSize";
            this.cbReceiveSize.RectColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbReceiveSize.RectWidth = 1;
            this.cbReceiveSize.SelectedIndex = 0;
            this.cbReceiveSize.SelectedValue = "100";
            this.cbReceiveSize.Size = new System.Drawing.Size(173, 23);
            this.cbReceiveSize.Source = ((System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>)(resources.GetObject("cbReceiveSize.Source")));
            this.cbReceiveSize.TabIndex = 21;
            this.cbReceiveSize.TextValue = "显示最近100条";
            this.cbReceiveSize.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.ucReceive);
            this.splitContainer3.Panel1.Controls.Add(this.listViewReceive);
            this.splitContainer3.Panel1.Controls.Add(this.ucSplitLine_H3);
            this.splitContainer3.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.cbSendCommandSize);
            this.splitContainer3.Panel2.Controls.Add(this.ucbSendCommand);
            this.splitContainer3.Panel2.Controls.Add(this.listViewSendCommand);
            this.splitContainer3.Panel2.Controls.Add(this.ucSplitLine_H2);
            this.splitContainer3.Panel2.Controls.Add(this.label5);
            this.splitContainer3.Size = new System.Drawing.Size(804, 458);
            this.splitContainer3.SplitterDistance = 277;
            this.splitContainer3.TabIndex = 0;
            // 
            // ucReceive
            // 
            this.ucReceive.BackColor = System.Drawing.Color.Transparent;
            this.ucReceive.Checked = true;
            this.ucReceive.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucReceive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ucReceive.Location = new System.Drawing.Point(163, 0);
            this.ucReceive.Name = "ucReceive";
            this.ucReceive.Padding = new System.Windows.Forms.Padding(1);
            this.ucReceive.Size = new System.Drawing.Size(100, 22);
            this.ucReceive.TabIndex = 18;
            this.ucReceive.TextValue = "实时显示";
            // 
            // listViewReceive
            // 
            this.listViewReceive.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewReceive.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader2,
            this.columnHeader11,
            this.columnHeader6,
            this.columnHeader13});
            this.listViewReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewReceive.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewReceive.FullRowSelect = true;
            this.listViewReceive.GridLines = true;
            this.listViewReceive.Location = new System.Drawing.Point(0, 25);
            this.listViewReceive.Name = "listViewReceive";
            this.listViewReceive.Size = new System.Drawing.Size(804, 252);
            this.listViewReceive.TabIndex = 12;
            this.listViewReceive.UseCompatibleStateImageBehavior = false;
            this.listViewReceive.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "采集站IP";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "采集时间";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "设备";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 144;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "通道";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 161;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "采集站";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "采集值";
            this.columnHeader6.Width = 305;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "入库结果";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ucSplitLine_H3
            // 
            this.ucSplitLine_H3.BackColor = System.Drawing.Color.Gray;
            this.ucSplitLine_H3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSplitLine_H3.Location = new System.Drawing.Point(0, 24);
            this.ucSplitLine_H3.Name = "ucSplitLine_H3";
            this.ucSplitLine_H3.Size = new System.Drawing.Size(804, 1);
            this.ucSplitLine_H3.TabIndex = 8;
            this.ucSplitLine_H3.TabStop = false;
            // 
            // cbSendCommandSize
            // 
            this.cbSendCommandSize.BackColor = System.Drawing.Color.Transparent;
            this.cbSendCommandSize.BackColorExt = System.Drawing.SystemColors.ControlLightLight;
            this.cbSendCommandSize.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSendCommandSize.ConerRadius = 5;
            this.cbSendCommandSize.DropPanelHeight = -1;
            this.cbSendCommandSize.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbSendCommandSize.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbSendCommandSize.IsRadius = true;
            this.cbSendCommandSize.IsShowRect = true;
            this.cbSendCommandSize.ItemWidth = 70;
            this.cbSendCommandSize.Location = new System.Drawing.Point(276, 0);
            this.cbSendCommandSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbSendCommandSize.Name = "cbSendCommandSize";
            this.cbSendCommandSize.RectColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbSendCommandSize.RectWidth = 1;
            this.cbSendCommandSize.SelectedIndex = 0;
            this.cbSendCommandSize.SelectedValue = "100";
            this.cbSendCommandSize.Size = new System.Drawing.Size(173, 23);
            this.cbSendCommandSize.Source = ((System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>)(resources.GetObject("cbSendCommandSize.Source")));
            this.cbSendCommandSize.TabIndex = 18;
            this.cbSendCommandSize.TextValue = "显示最近100条";
            this.cbSendCommandSize.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // ucbSendCommand
            // 
            this.ucbSendCommand.BackColor = System.Drawing.Color.Transparent;
            this.ucbSendCommand.Checked = true;
            this.ucbSendCommand.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucbSendCommand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ucbSendCommand.Location = new System.Drawing.Point(180, 0);
            this.ucbSendCommand.Name = "ucbSendCommand";
            this.ucbSendCommand.Padding = new System.Windows.Forms.Padding(1);
            this.ucbSendCommand.Size = new System.Drawing.Size(101, 22);
            this.ucbSendCommand.TabIndex = 17;
            this.ucbSendCommand.TextValue = "实时显示";
            // 
            // listViewSendCommand
            // 
            this.listViewSendCommand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewSendCommand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDateTime,
            this.columnserver,
            this.columnContent,
            this.columndevice,
            this.columniopara,
            this.columnvalue,
            this.columnresult,
            this.columnuser});
            this.listViewSendCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSendCommand.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewSendCommand.FullRowSelect = true;
            this.listViewSendCommand.GridLines = true;
            this.listViewSendCommand.Location = new System.Drawing.Point(0, 27);
            this.listViewSendCommand.Name = "listViewSendCommand";
            this.listViewSendCommand.Size = new System.Drawing.Size(804, 150);
            this.listViewSendCommand.TabIndex = 11;
            this.listViewSendCommand.UseCompatibleStateImageBehavior = false;
            this.listViewSendCommand.View = System.Windows.Forms.View.Details;
            // 
            // columnDateTime
            // 
            this.columnDateTime.Text = "下置时间";
            this.columnDateTime.Width = 137;
            // 
            // columnserver
            // 
            this.columnserver.Text = "采集站";
            this.columnserver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnserver.Width = 120;
            // 
            // columnContent
            // 
            this.columnContent.Text = "通道";
            this.columnContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnContent.Width = 100;
            // 
            // columndevice
            // 
            this.columndevice.Text = "设备";
            this.columndevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columndevice.Width = 99;
            // 
            // columniopara
            // 
            this.columniopara.Text = "IO参数";
            this.columniopara.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columniopara.Width = 102;
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
            // 
            // ucSplitLine_H2
            // 
            this.ucSplitLine_H2.BackColor = System.Drawing.Color.Gray;
            this.ucSplitLine_H2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSplitLine_H2.Location = new System.Drawing.Point(0, 26);
            this.ucSplitLine_H2.Name = "ucSplitLine_H2";
            this.ucSplitLine_H2.Size = new System.Drawing.Size(804, 1);
            this.ucSplitLine_H2.TabIndex = 10;
            this.ucSplitLine_H2.TabStop = false;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(804, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "SCADA下置命令发送日志:";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ucEnableAlarm);
            this.tabPage5.Controls.Add(this.listViewAlarm);
            this.tabPage5.Controls.Add(this.ucSplitLine_H5);
            this.tabPage5.Controls.Add(this.cbAlarmSize);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(810, 464);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "报警监视";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ucEnableAlarm
            // 
            this.ucEnableAlarm.BackColor = System.Drawing.Color.Transparent;
            this.ucEnableAlarm.Checked = true;
            this.ucEnableAlarm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucEnableAlarm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ucEnableAlarm.Location = new System.Drawing.Point(75, 0);
            this.ucEnableAlarm.Name = "ucEnableAlarm";
            this.ucEnableAlarm.Padding = new System.Windows.Forms.Padding(1);
            this.ucEnableAlarm.Size = new System.Drawing.Size(100, 22);
            this.ucEnableAlarm.TabIndex = 34;
            this.ucEnableAlarm.TextValue = "实时显示";
            // 
            // listViewAlarm
            // 
            this.listViewAlarm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewAlarm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader23,
            this.columnHeader14,
            this.columnHeader17,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader22});
            this.listViewAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAlarm.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewAlarm.FullRowSelect = true;
            this.listViewAlarm.GridLines = true;
            this.listViewAlarm.Location = new System.Drawing.Point(0, 25);
            this.listViewAlarm.Name = "listViewAlarm";
            this.listViewAlarm.Size = new System.Drawing.Size(810, 439);
            this.listViewAlarm.TabIndex = 12;
            this.listViewAlarm.UseCompatibleStateImageBehavior = false;
            this.listViewAlarm.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "数据IP";
            this.columnHeader23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "报警时间";
            this.columnHeader14.Width = 137;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "IO参数";
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader17.Width = 102;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "报警值";
            this.columnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader20.Width = 102;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "报警类型";
            this.columnHeader21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader21.Width = 102;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "报警等级";
            this.columnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader18.Width = 102;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "采集站";
            this.columnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader19.Width = 118;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "通道";
            this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader15.Width = 100;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "设备";
            this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader16.Width = 99;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "入库结果";
            this.columnHeader22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader22.Width = 102;
            // 
            // ucSplitLine_H5
            // 
            this.ucSplitLine_H5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ucSplitLine_H5.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSplitLine_H5.Location = new System.Drawing.Point(0, 24);
            this.ucSplitLine_H5.Name = "ucSplitLine_H5";
            this.ucSplitLine_H5.Size = new System.Drawing.Size(810, 1);
            this.ucSplitLine_H5.TabIndex = 33;
            this.ucSplitLine_H5.TabStop = false;
            // 
            // cbAlarmSize
            // 
            this.cbAlarmSize.BackColor = System.Drawing.Color.Transparent;
            this.cbAlarmSize.BackColorExt = System.Drawing.SystemColors.ControlLightLight;
            this.cbAlarmSize.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlarmSize.ConerRadius = 5;
            this.cbAlarmSize.DropPanelHeight = -1;
            this.cbAlarmSize.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbAlarmSize.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbAlarmSize.IsRadius = true;
            this.cbAlarmSize.IsShowRect = true;
            this.cbAlarmSize.ItemWidth = 70;
            this.cbAlarmSize.Location = new System.Drawing.Point(185, 0);
            this.cbAlarmSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAlarmSize.Name = "cbAlarmSize";
            this.cbAlarmSize.RectColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbAlarmSize.RectWidth = 1;
            this.cbAlarmSize.SelectedIndex = 0;
            this.cbAlarmSize.SelectedValue = "100";
            this.cbAlarmSize.Size = new System.Drawing.Size(173, 23);
            this.cbAlarmSize.Source = ((System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>)(resources.GetObject("cbAlarmSize.Source")));
            this.cbAlarmSize.TabIndex = 30;
            this.cbAlarmSize.TextValue = "显示最近100条";
            this.cbAlarmSize.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(810, 24);
            this.label10.TabIndex = 28;
            this.label10.Text = "报警监视:";
            // 
            // systimer
            // 
            this.systimer.Interval = 1000;
            this.systimer.Tick += new System.EventHandler(this.systimer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.ProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 572);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1101, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(152, 17);
            this.toolStripStatusLabel1.Text = "SCADA Center Server 1.0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(20, 17);
            this.toolStripStatusLabel2.Text = "   ";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(200, 16);
            // 
            // MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 594);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MonitorForm";
            this.Text = "SCADA数据中心实时接收器";
            this.Title = "SCADA数据中心实时接收器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MonitorForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.labelIP, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btMin, 0);
            this.Controls.SetChildIndex(this.btMax, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControlExt.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabControlMonitor.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label5;
        private Scada.Controls.Controls.UCSplitLine_H ucSplitLine_H3;
        private Scada.Controls.Controls.UCSplitLine_H ucSplitLine_H2;
        private Scada.Controls.Controls.UCBtnExt ucBtnStart;
        private Scada.Controls.Controls.UCBtnExt ucBtnStop;
        private Scada.Controls.Controls.UCBtnExt ucBtnPause;
        private Scada.Controls.Controls.UCBtnExt ucBtnContinue;
        private Scada.Controls.Controls.UCBtnExt ucBtnCommand;
        private Scada.Controls.Controls.TabControlExt tabControlExt;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnDateTime;
        private System.Windows.Forms.ColumnHeader columnContent;
        private Scada.Controls.Controls.TabControlExt tabControlMonitor;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columndevice;
        private System.Windows.Forms.ColumnHeader columniopara;
        private System.Windows.Forms.ColumnHeader columnvalue;
        private System.Windows.Forms.ColumnHeader columnresult;
        private Scada.Controls.Controls.UCLEDNums ucledDate;
        private System.Windows.Forms.Timer systimer;
        public SCADAListView listViewReceive;
        public SCADAListView listViewReport;
        public SCADAListView listViewSendCommand;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private Scada.Controls.Controls.UCAlarmLamp ucAlarm;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        public System.Windows.Forms.ToolStripProgressBar ProgressBar;
        public IOTree IOTreeView;
        private System.Windows.Forms.TabPage tabPage5;
        public SCADAListView listViewAlarm;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnserver;
        private System.Windows.Forms.ColumnHeader columnuser;
        private Scada.Controls.Controls.ComputerInfoControl computerInfoControl;
        private SCADAPageCombox  cbSendCommandSize;
        private Scada.Controls.Controls.UCCheckBox ucbSendCommand;
        private SCADAPageCombox cbReceiveSize;
        private System.Windows.Forms.Label label7;
        private SCADAPageCombox cbLogSize;
        private Scada.Controls.Controls.UCSplitLine_H ucSplitLine_H4;
        private Scada.Controls.Controls.UCSplitLine_H ucSplitLine_H5;
        private SCADAPageCombox cbAlarmSize;
        private System.Windows.Forms.Label label10;
        private UCCheckBox ucReceive;
        private UCCheckBox ucLog;
        private UCCheckBox ucEnableAlarm;
    }
}