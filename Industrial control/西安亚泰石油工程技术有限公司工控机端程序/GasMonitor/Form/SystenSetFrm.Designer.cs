namespace GasMonitor
{
    partial class SystenSetFrm
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
            this.uiLine7 = new Sunny.UI.UILine();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiLine2 = new Sunny.UI.UILine();
            this.uiLine3 = new Sunny.UI.UILine();
            this.uiLine4 = new Sunny.UI.UILine();
            this.uiLine11 = new Sunny.UI.UILine();
            this.uiLine5 = new Sunny.UI.UILine();
            this.uiLine6 = new Sunny.UI.UILine();
            this.utbChannelName = new Sunny.UI.UITextBox();
            this.uiLine8 = new Sunny.UI.UILine();
            this.uiLine9 = new Sunny.UI.UILine();
            this.utbClientID = new Sunny.UI.UITextBox();
            this.uiLine10 = new Sunny.UI.UILine();
            this.ubtNewGuid = new Sunny.UI.UIButton();
            this.utbDataPublicTopic = new Sunny.UI.UITextBox();
            this.uiLine12 = new Sunny.UI.UILine();
            this.utbCommandSubTopic = new Sunny.UI.UITextBox();
            this.uiLine13 = new Sunny.UI.UILine();
            this.utbUpdateCycleSubTopic = new Sunny.UI.UITextBox();
            this.uiLine14 = new Sunny.UI.UILine();
            this.utbPassiveSubTopic = new Sunny.UI.UITextBox();
            this.uiLine15 = new Sunny.UI.UILine();
            this.uiRadioButton2 = new Sunny.UI.UIRadioButton();
            this.uiRadioButton1 = new Sunny.UI.UIRadioButton();
            this.uiLine16 = new Sunny.UI.UILine();
            this.uddUpdateCycle = new Sunny.UI.UIDoubleUpDown();
            this.uiLine17 = new Sunny.UI.UILine();
            this.utbServerIP = new Sunny.UI.UITextBox();
            this.uiLine18 = new Sunny.UI.UILine();
            this.utbPassword = new Sunny.UI.UITextBox();
            this.uiLine19 = new Sunny.UI.UILine();
            this.ubtSave = new Sunny.UI.UIButton();
            this.utbPort = new Sunny.UI.UITextBox();
            this.uiLine20 = new Sunny.UI.UILine();
            this.utbAccount = new Sunny.UI.UITextBox();
            this.uiLine21 = new Sunny.UI.UILine();
            this.ucbSeriePort = new Sunny.UI.UIComboBox();
            this.ucbChannel = new Sunny.UI.UIComboBox();
            this.ccbCheckBits = new Sunny.UI.UIComboBox();
            this.ucbBaudRate = new Sunny.UI.UIComboBox();
            this.ucbStopBits = new Sunny.UI.UIComboBox();
            this.ucbDataBits = new Sunny.UI.UIComboBox();
            this.ucbDeviceAddress = new Sunny.UI.UIComboBox();
            this.uiLine22 = new Sunny.UI.UILine();
            this.uddWriteTimeout = new Sunny.UI.UIDoubleUpDown();
            this.uddReadTimeOut = new Sunny.UI.UIDoubleUpDown();
            this.uiLine23 = new Sunny.UI.UILine();
            this.uddPackSize = new Sunny.UI.UIDoubleUpDown();
            this.uiLine24 = new Sunny.UI.UILine();
            this.uddCollectFaultsInternal = new Sunny.UI.UIDoubleUpDown();
            this.uiLine25 = new Sunny.UI.UILine();
            this.uddCollectFaultsNumber = new Sunny.UI.UIDoubleUpDown();
            this.uiLine26 = new Sunny.UI.UILine();
            this.uiLine27 = new Sunny.UI.UILine();
            this.ucbContinueCollect = new Sunny.UI.UICheckBox();
            this.uddOffsetInterval = new Sunny.UI.UIDoubleUpDown();
            this.uiLine28 = new Sunny.UI.UILine();
            this.ucbRTSEnable = new Sunny.UI.UICheckBox();
            this.uiLine29 = new Sunny.UI.UILine();
            this.ucbModbusType = new Sunny.UI.UIComboBox();
            this.uiLine30 = new Sunny.UI.UILine();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.PagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PagePanel
            // 
            this.PagePanel.AutoScroll = true;
            this.PagePanel.Controls.Add(this.uiButton1);
            this.PagePanel.Controls.Add(this.ucbModbusType);
            this.PagePanel.Controls.Add(this.uiLine30);
            this.PagePanel.Controls.Add(this.ucbRTSEnable);
            this.PagePanel.Controls.Add(this.uiLine29);
            this.PagePanel.Controls.Add(this.uddOffsetInterval);
            this.PagePanel.Controls.Add(this.uiLine28);
            this.PagePanel.Controls.Add(this.ucbContinueCollect);
            this.PagePanel.Controls.Add(this.uddCollectFaultsInternal);
            this.PagePanel.Controls.Add(this.uiLine25);
            this.PagePanel.Controls.Add(this.uddCollectFaultsNumber);
            this.PagePanel.Controls.Add(this.uiLine26);
            this.PagePanel.Controls.Add(this.uiLine27);
            this.PagePanel.Controls.Add(this.uddPackSize);
            this.PagePanel.Controls.Add(this.uiLine24);
            this.PagePanel.Controls.Add(this.uddReadTimeOut);
            this.PagePanel.Controls.Add(this.uiLine23);
            this.PagePanel.Controls.Add(this.uddWriteTimeout);
            this.PagePanel.Controls.Add(this.uiLine22);
            this.PagePanel.Controls.Add(this.ucbDeviceAddress);
            this.PagePanel.Controls.Add(this.ucbDataBits);
            this.PagePanel.Controls.Add(this.ucbStopBits);
            this.PagePanel.Controls.Add(this.ucbBaudRate);
            this.PagePanel.Controls.Add(this.ccbCheckBits);
            this.PagePanel.Controls.Add(this.ucbChannel);
            this.PagePanel.Controls.Add(this.ucbSeriePort);
            this.PagePanel.Controls.Add(this.utbAccount);
            this.PagePanel.Controls.Add(this.uiLine21);
            this.PagePanel.Controls.Add(this.utbPort);
            this.PagePanel.Controls.Add(this.uiLine20);
            this.PagePanel.Controls.Add(this.ubtSave);
            this.PagePanel.Controls.Add(this.utbPassword);
            this.PagePanel.Controls.Add(this.uiLine19);
            this.PagePanel.Controls.Add(this.utbServerIP);
            this.PagePanel.Controls.Add(this.uiLine18);
            this.PagePanel.Controls.Add(this.uiLine17);
            this.PagePanel.Controls.Add(this.uddUpdateCycle);
            this.PagePanel.Controls.Add(this.uiLine16);
            this.PagePanel.Controls.Add(this.uiRadioButton2);
            this.PagePanel.Controls.Add(this.uiRadioButton1);
            this.PagePanel.Controls.Add(this.utbPassiveSubTopic);
            this.PagePanel.Controls.Add(this.uiLine15);
            this.PagePanel.Controls.Add(this.utbUpdateCycleSubTopic);
            this.PagePanel.Controls.Add(this.uiLine14);
            this.PagePanel.Controls.Add(this.utbCommandSubTopic);
            this.PagePanel.Controls.Add(this.uiLine13);
            this.PagePanel.Controls.Add(this.utbDataPublicTopic);
            this.PagePanel.Controls.Add(this.uiLine12);
            this.PagePanel.Controls.Add(this.ubtNewGuid);
            this.PagePanel.Controls.Add(this.utbClientID);
            this.PagePanel.Controls.Add(this.uiLine10);
            this.PagePanel.Controls.Add(this.uiLine9);
            this.PagePanel.Controls.Add(this.uiLine8);
            this.PagePanel.Controls.Add(this.utbChannelName);
            this.PagePanel.Controls.Add(this.uiLine6);
            this.PagePanel.Controls.Add(this.uiLine5);
            this.PagePanel.Controls.Add(this.uiLine4);
            this.PagePanel.Controls.Add(this.uiLine3);
            this.PagePanel.Controls.Add(this.uiLine2);
            this.PagePanel.Controls.Add(this.uiLine1);
            this.PagePanel.Controls.Add(this.uiLine7);
            this.PagePanel.Controls.Add(this.uiLine11);
            this.PagePanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.PagePanel.ForeColor = System.Drawing.Color.Silver;
            this.PagePanel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.PagePanel.Size = new System.Drawing.Size(1109, 507);
            this.PagePanel.Style = Sunny.UI.UIStyle.Black;
            // 
            // uiLine7
            // 
            this.uiLine7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine7.ForeColor = System.Drawing.Color.Silver;
            this.uiLine7.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine7.Location = new System.Drawing.Point(12, 13);
            this.uiLine7.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine7.Name = "uiLine7";
            this.uiLine7.Size = new System.Drawing.Size(348, 20);
            this.uiLine7.Style = Sunny.UI.UIStyle.Black;
            this.uiLine7.TabIndex = 41;
            this.uiLine7.Text = "串口设置";
            this.uiLine7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine1
            // 
            this.uiLine1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine1.ForeColor = System.Drawing.Color.Silver;
            this.uiLine1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine1.Location = new System.Drawing.Point(185, 61);
            this.uiLine1.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(175, 20);
            this.uiLine1.Style = Sunny.UI.UIStyle.Black;
            this.uiLine1.TabIndex = 43;
            this.uiLine1.Text = "波特率";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine2
            // 
            this.uiLine2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine2.ForeColor = System.Drawing.Color.Silver;
            this.uiLine2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine2.Location = new System.Drawing.Point(12, 61);
            this.uiLine2.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(150, 20);
            this.uiLine2.Style = Sunny.UI.UIStyle.Black;
            this.uiLine2.TabIndex = 45;
            this.uiLine2.Text = "校验位";
            this.uiLine2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine3
            // 
            this.uiLine3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine3.ForeColor = System.Drawing.Color.Silver;
            this.uiLine3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine3.Location = new System.Drawing.Point(185, 111);
            this.uiLine3.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(175, 20);
            this.uiLine3.Style = Sunny.UI.UIStyle.Black;
            this.uiLine3.TabIndex = 47;
            this.uiLine3.Text = "数据位";
            this.uiLine3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine4
            // 
            this.uiLine4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine4.ForeColor = System.Drawing.Color.Silver;
            this.uiLine4.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine4.Location = new System.Drawing.Point(12, 110);
            this.uiLine4.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Size = new System.Drawing.Size(150, 20);
            this.uiLine4.Style = Sunny.UI.UIStyle.Black;
            this.uiLine4.TabIndex = 49;
            this.uiLine4.Text = "停止位";
            this.uiLine4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine11
            // 
            this.uiLine11.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.uiLine11.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine11.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine11.ForeColor = System.Drawing.Color.Silver;
            this.uiLine11.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine11.LineSize = 2;
            this.uiLine11.Location = new System.Drawing.Point(339, 19);
            this.uiLine11.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine11.Name = "uiLine11";
            this.uiLine11.Size = new System.Drawing.Size(51, 148);
            this.uiLine11.Style = Sunny.UI.UIStyle.Black;
            this.uiLine11.TabIndex = 52;
            this.uiLine11.Text = "uiLine11";
            this.uiLine11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine5
            // 
            this.uiLine5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine5.ForeColor = System.Drawing.Color.Silver;
            this.uiLine5.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine5.Location = new System.Drawing.Point(366, 13);
            this.uiLine5.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine5.Name = "uiLine5";
            this.uiLine5.Size = new System.Drawing.Size(198, 20);
            this.uiLine5.Style = Sunny.UI.UIStyle.Black;
            this.uiLine5.TabIndex = 53;
            this.uiLine5.Text = "通道选择";
            this.uiLine5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine6
            // 
            this.uiLine6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine6.ForeColor = System.Drawing.Color.Silver;
            this.uiLine6.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine6.Location = new System.Drawing.Point(366, 61);
            this.uiLine6.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine6.Name = "uiLine6";
            this.uiLine6.Size = new System.Drawing.Size(198, 20);
            this.uiLine6.Style = Sunny.UI.UIStyle.Black;
            this.uiLine6.TabIndex = 55;
            this.uiLine6.Text = "通道名称";
            this.uiLine6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // utbChannelName
            // 
            this.utbChannelName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.utbChannelName.FillColor = System.Drawing.Color.White;
            this.utbChannelName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.utbChannelName.Location = new System.Drawing.Point(372, 84);
            this.utbChannelName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.utbChannelName.Maximum = 2147483647D;
            this.utbChannelName.Minimum = -2147483648D;
            this.utbChannelName.Name = "utbChannelName";
            this.utbChannelName.Padding = new System.Windows.Forms.Padding(5);
            this.utbChannelName.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.utbChannelName.Size = new System.Drawing.Size(192, 29);
            this.utbChannelName.Style = Sunny.UI.UIStyle.Black;
            this.utbChannelName.TabIndex = 56;
            this.utbChannelName.Watermark = "";
            this.utbChannelName.Click += new System.EventHandler(this.uiTextBox2_Click);
            this.utbChannelName.TextChanged += new System.EventHandler(this.utbChannelName_TextChanged);
            // 
            // uiLine8
            // 
            this.uiLine8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine8.ForeColor = System.Drawing.Color.Silver;
            this.uiLine8.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine8.Location = new System.Drawing.Point(366, 111);
            this.uiLine8.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine8.Name = "uiLine8";
            this.uiLine8.Size = new System.Drawing.Size(198, 20);
            this.uiLine8.Style = Sunny.UI.UIStyle.Black;
            this.uiLine8.TabIndex = 57;
            this.uiLine8.Text = "设备地址";
            this.uiLine8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine9
            // 
            this.uiLine9.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine9.ForeColor = System.Drawing.Color.Silver;
            this.uiLine9.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine9.Location = new System.Drawing.Point(12, 169);
            this.uiLine9.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine9.Name = "uiLine9";
            this.uiLine9.Size = new System.Drawing.Size(1097, 20);
            this.uiLine9.Style = Sunny.UI.UIStyle.Black;
            this.uiLine9.TabIndex = 59;
            this.uiLine9.Text = "MQTT通讯协议设置";
            this.uiLine9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // utbClientID
            // 
            this.utbClientID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.utbClientID.FillColor = System.Drawing.Color.White;
            this.utbClientID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.utbClientID.Location = new System.Drawing.Point(14, 212);
            this.utbClientID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.utbClientID.Maximum = 2147483647D;
            this.utbClientID.Minimum = -2147483648D;
            this.utbClientID.Name = "utbClientID";
            this.utbClientID.Padding = new System.Windows.Forms.Padding(5);
            this.utbClientID.ReadOnly = true;
            this.utbClientID.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.utbClientID.Size = new System.Drawing.Size(257, 29);
            this.utbClientID.Style = Sunny.UI.UIStyle.Black;
            this.utbClientID.TabIndex = 61;
            this.utbClientID.Watermark = "";
            // 
            // uiLine10
            // 
            this.uiLine10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine10.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine10.ForeColor = System.Drawing.Color.Silver;
            this.uiLine10.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine10.Location = new System.Drawing.Point(12, 188);
            this.uiLine10.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine10.Name = "uiLine10";
            this.uiLine10.Size = new System.Drawing.Size(348, 20);
            this.uiLine10.Style = Sunny.UI.UIStyle.Black;
            this.uiLine10.TabIndex = 60;
            this.uiLine10.Text = "客户端ID";
            this.uiLine10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ubtNewGuid
            // 
            this.ubtNewGuid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ubtNewGuid.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.ubtNewGuid.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.ubtNewGuid.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.ubtNewGuid.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.ubtNewGuid.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ubtNewGuid.Location = new System.Drawing.Point(278, 207);
            this.ubtNewGuid.Name = "ubtNewGuid";
            this.ubtNewGuid.Radius = 35;
            this.ubtNewGuid.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.ubtNewGuid.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.ubtNewGuid.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.ubtNewGuid.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.ubtNewGuid.Size = new System.Drawing.Size(82, 35);
            this.ubtNewGuid.Style = Sunny.UI.UIStyle.Green;
            this.ubtNewGuid.StyleCustomMode = true;
            this.ubtNewGuid.TabIndex = 62;
            this.ubtNewGuid.Text = "生成";
            this.ubtNewGuid.Click += new System.EventHandler(this.ubtNewGuid_Click);
            // 
            // utbDataPublicTopic
            // 
            this.utbDataPublicTopic.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.utbDataPublicTopic.FillColor = System.Drawing.Color.White;
            this.utbDataPublicTopic.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.utbDataPublicTopic.Location = new System.Drawing.Point(14, 270);
            this.utbDataPublicTopic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.utbDataPublicTopic.Maximum = 2147483647D;
            this.utbDataPublicTopic.Minimum = -2147483648D;
            this.utbDataPublicTopic.Name = "utbDataPublicTopic";
            this.utbDataPublicTopic.Padding = new System.Windows.Forms.Padding(5);
            this.utbDataPublicTopic.ReadOnly = true;
            this.utbDataPublicTopic.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.utbDataPublicTopic.Size = new System.Drawing.Size(700, 29);
            this.utbDataPublicTopic.Style = Sunny.UI.UIStyle.Black;
            this.utbDataPublicTopic.TabIndex = 64;
            this.utbDataPublicTopic.Watermark = "";
            this.utbDataPublicTopic.Click += new System.EventHandler(this.uiTextBox2_Click);
            // 
            // uiLine12
            // 
            this.uiLine12.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine12.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine12.ForeColor = System.Drawing.Color.Silver;
            this.uiLine12.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine12.Location = new System.Drawing.Point(12, 246);
            this.uiLine12.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine12.Name = "uiLine12";
            this.uiLine12.Size = new System.Drawing.Size(348, 20);
            this.uiLine12.Style = Sunny.UI.UIStyle.Black;
            this.uiLine12.TabIndex = 63;
            this.uiLine12.Text = "数据发布主题";
            this.uiLine12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // utbCommandSubTopic
            // 
            this.utbCommandSubTopic.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.utbCommandSubTopic.FillColor = System.Drawing.Color.White;
            this.utbCommandSubTopic.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.utbCommandSubTopic.Location = new System.Drawing.Point(14, 333);
            this.utbCommandSubTopic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.utbCommandSubTopic.Maximum = 2147483647D;
            this.utbCommandSubTopic.Minimum = -2147483648D;
            this.utbCommandSubTopic.Name = "utbCommandSubTopic";
            this.utbCommandSubTopic.Padding = new System.Windows.Forms.Padding(5);
            this.utbCommandSubTopic.ReadOnly = true;
            this.utbCommandSubTopic.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.utbCommandSubTopic.Size = new System.Drawing.Size(700, 29);
            this.utbCommandSubTopic.Style = Sunny.UI.UIStyle.Black;
            this.utbCommandSubTopic.TabIndex = 66;
            this.utbCommandSubTopic.Watermark = "";
            this.utbCommandSubTopic.Click += new System.EventHandler(this.uiTextBox2_Click);
            // 
            // uiLine13
            // 
            this.uiLine13.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine13.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine13.ForeColor = System.Drawing.Color.Silver;
            this.uiLine13.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine13.Location = new System.Drawing.Point(12, 305);
            this.uiLine13.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine13.Name = "uiLine13";
            this.uiLine13.Size = new System.Drawing.Size(348, 20);
            this.uiLine13.Style = Sunny.UI.UIStyle.Black;
            this.uiLine13.TabIndex = 65;
            this.uiLine13.Text = "命令下置订阅主题";
            this.uiLine13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // utbUpdateCycleSubTopic
            // 
            this.utbUpdateCycleSubTopic.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.utbUpdateCycleSubTopic.FillColor = System.Drawing.Color.White;
            this.utbUpdateCycleSubTopic.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.utbUpdateCycleSubTopic.Location = new System.Drawing.Point(12, 398);
            this.utbUpdateCycleSubTopic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.utbUpdateCycleSubTopic.Maximum = 2147483647D;
            this.utbUpdateCycleSubTopic.Minimum = -2147483648D;
            this.utbUpdateCycleSubTopic.Name = "utbUpdateCycleSubTopic";
            this.utbUpdateCycleSubTopic.Padding = new System.Windows.Forms.Padding(5);
            this.utbUpdateCycleSubTopic.ReadOnly = true;
            this.utbUpdateCycleSubTopic.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.utbUpdateCycleSubTopic.Size = new System.Drawing.Size(700, 29);
            this.utbUpdateCycleSubTopic.Style = Sunny.UI.UIStyle.Black;
            this.utbUpdateCycleSubTopic.TabIndex = 68;
            this.utbUpdateCycleSubTopic.Watermark = "";
            this.utbUpdateCycleSubTopic.Click += new System.EventHandler(this.uiTextBox2_Click);
            // 
            // uiLine14
            // 
            this.uiLine14.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine14.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine14.ForeColor = System.Drawing.Color.Silver;
            this.uiLine14.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine14.Location = new System.Drawing.Point(10, 370);
            this.uiLine14.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine14.Name = "uiLine14";
            this.uiLine14.Size = new System.Drawing.Size(348, 20);
            this.uiLine14.Style = Sunny.UI.UIStyle.Black;
            this.uiLine14.TabIndex = 67;
            this.uiLine14.Text = "服务器周期订阅主题(服务器端主动订阅而发布的订周期主题)";
            this.uiLine14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // utbPassiveSubTopic
            // 
            this.utbPassiveSubTopic.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.utbPassiveSubTopic.FillColor = System.Drawing.Color.White;
            this.utbPassiveSubTopic.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.utbPassiveSubTopic.Location = new System.Drawing.Point(10, 463);
            this.utbPassiveSubTopic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.utbPassiveSubTopic.Maximum = 2147483647D;
            this.utbPassiveSubTopic.Minimum = -2147483648D;
            this.utbPassiveSubTopic.Name = "utbPassiveSubTopic";
            this.utbPassiveSubTopic.Padding = new System.Windows.Forms.Padding(5);
            this.utbPassiveSubTopic.ReadOnly = true;
            this.utbPassiveSubTopic.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.utbPassiveSubTopic.Size = new System.Drawing.Size(700, 29);
            this.utbPassiveSubTopic.Style = Sunny.UI.UIStyle.Black;
            this.utbPassiveSubTopic.TabIndex = 70;
            this.utbPassiveSubTopic.Watermark = "";
            this.utbPassiveSubTopic.Click += new System.EventHandler(this.uiTextBox2_Click);
            // 
            // uiLine15
            // 
            this.uiLine15.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine15.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine15.ForeColor = System.Drawing.Color.Silver;
            this.uiLine15.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine15.Location = new System.Drawing.Point(8, 435);
            this.uiLine15.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine15.Name = "uiLine15";
            this.uiLine15.Size = new System.Drawing.Size(348, 20);
            this.uiLine15.Style = Sunny.UI.UIStyle.Black;
            this.uiLine15.TabIndex = 69;
            this.uiLine15.Text = "被动数据订阅主题";
            this.uiLine15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiRadioButton2
            // 
            this.uiRadioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiRadioButton2.ForeColor = System.Drawing.Color.Silver;
            this.uiRadioButton2.Location = new System.Drawing.Point(833, 393);
            this.uiRadioButton2.Name = "uiRadioButton2";
            this.uiRadioButton2.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiRadioButton2.Size = new System.Drawing.Size(102, 35);
            this.uiRadioButton2.Style = Sunny.UI.UIStyle.Black;
            this.uiRadioButton2.TabIndex = 72;
            this.uiRadioButton2.Text = "被动发布";
            // 
            // uiRadioButton1
            // 
            this.uiRadioButton1.Checked = true;
            this.uiRadioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiRadioButton1.ForeColor = System.Drawing.Color.Silver;
            this.uiRadioButton1.Location = new System.Drawing.Point(728, 393);
            this.uiRadioButton1.Name = "uiRadioButton1";
            this.uiRadioButton1.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiRadioButton1.Size = new System.Drawing.Size(150, 35);
            this.uiRadioButton1.Style = Sunny.UI.UIStyle.Black;
            this.uiRadioButton1.TabIndex = 71;
            this.uiRadioButton1.Text = "主动发布";
            // 
            // uiLine16
            // 
            this.uiLine16.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine16.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine16.ForeColor = System.Drawing.Color.Silver;
            this.uiLine16.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine16.Location = new System.Drawing.Point(728, 306);
            this.uiLine16.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine16.Name = "uiLine16";
            this.uiLine16.Size = new System.Drawing.Size(207, 20);
            this.uiLine16.Style = Sunny.UI.UIStyle.Black;
            this.uiLine16.TabIndex = 73;
            this.uiLine16.Text = "数据订阅周期(秒)";
            this.uiLine16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uddUpdateCycle
            // 
            this.uddUpdateCycle.Decimal = 0;
            this.uddUpdateCycle.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uddUpdateCycle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uddUpdateCycle.ForeColor = System.Drawing.Color.Silver;
            this.uddUpdateCycle.Location = new System.Drawing.Point(726, 334);
            this.uddUpdateCycle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uddUpdateCycle.MinimumSize = new System.Drawing.Size(100, 0);
            this.uddUpdateCycle.Name = "uddUpdateCycle";
            this.uddUpdateCycle.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uddUpdateCycle.Size = new System.Drawing.Size(207, 29);
            this.uddUpdateCycle.Step = 1D;
            this.uddUpdateCycle.Style = Sunny.UI.UIStyle.Black;
            this.uddUpdateCycle.TabIndex = 74;
            this.uddUpdateCycle.Text = null;
            this.uddUpdateCycle.Value = 5D;
            // 
            // uiLine17
            // 
            this.uiLine17.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine17.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine17.ForeColor = System.Drawing.Color.Silver;
            this.uiLine17.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine17.Location = new System.Drawing.Point(726, 371);
            this.uiLine17.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine17.Name = "uiLine17";
            this.uiLine17.Size = new System.Drawing.Size(209, 20);
            this.uiLine17.Style = Sunny.UI.UIStyle.Black;
            this.uiLine17.TabIndex = 75;
            this.uiLine17.Text = "发布方式";
            this.uiLine17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // utbServerIP
            // 
            this.utbServerIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.utbServerIP.FillColor = System.Drawing.Color.White;
            this.utbServerIP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.utbServerIP.Location = new System.Drawing.Point(730, 211);
            this.utbServerIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.utbServerIP.Maximum = 2147483647D;
            this.utbServerIP.Minimum = -2147483648D;
            this.utbServerIP.Name = "utbServerIP";
            this.utbServerIP.Padding = new System.Windows.Forms.Padding(5);
            this.utbServerIP.ReadOnly = true;
            this.utbServerIP.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.utbServerIP.Size = new System.Drawing.Size(205, 29);
            this.utbServerIP.Style = Sunny.UI.UIStyle.Black;
            this.utbServerIP.TabIndex = 77;
            this.utbServerIP.Watermark = "";
            this.utbServerIP.Click += new System.EventHandler(this.uiTextBox2_Click);
            // 
            // uiLine18
            // 
            this.uiLine18.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine18.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine18.ForeColor = System.Drawing.Color.Silver;
            this.uiLine18.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine18.Location = new System.Drawing.Point(728, 188);
            this.uiLine18.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine18.Name = "uiLine18";
            this.uiLine18.Size = new System.Drawing.Size(207, 20);
            this.uiLine18.Style = Sunny.UI.UIStyle.Black;
            this.uiLine18.TabIndex = 76;
            this.uiLine18.Text = "服务器IP";
            this.uiLine18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // utbPassword
            // 
            this.utbPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.utbPassword.FillColor = System.Drawing.Color.White;
            this.utbPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.utbPassword.Location = new System.Drawing.Point(550, 212);
            this.utbPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.utbPassword.Maximum = 2147483647D;
            this.utbPassword.Minimum = -2147483648D;
            this.utbPassword.Name = "utbPassword";
            this.utbPassword.Padding = new System.Windows.Forms.Padding(5);
            this.utbPassword.ReadOnly = true;
            this.utbPassword.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.utbPassword.Size = new System.Drawing.Size(164, 29);
            this.utbPassword.Style = Sunny.UI.UIStyle.Black;
            this.utbPassword.TabIndex = 79;
            this.utbPassword.Watermark = "";
            this.utbPassword.Click += new System.EventHandler(this.uiTextBox2_Click);
            // 
            // uiLine19
            // 
            this.uiLine19.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine19.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine19.ForeColor = System.Drawing.Color.Silver;
            this.uiLine19.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine19.Location = new System.Drawing.Point(548, 189);
            this.uiLine19.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine19.Name = "uiLine19";
            this.uiLine19.Size = new System.Drawing.Size(166, 20);
            this.uiLine19.Style = Sunny.UI.UIStyle.Black;
            this.uiLine19.TabIndex = 78;
            this.uiLine19.Text = "密码";
            this.uiLine19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ubtSave
            // 
            this.ubtSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ubtSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.ubtSave.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.ubtSave.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.ubtSave.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.ubtSave.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ubtSave.Location = new System.Drawing.Point(857, 435);
            this.ubtSave.Name = "ubtSave";
            this.ubtSave.Radius = 35;
            this.ubtSave.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.ubtSave.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.ubtSave.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.ubtSave.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.ubtSave.Size = new System.Drawing.Size(100, 35);
            this.ubtSave.Style = Sunny.UI.UIStyle.Green;
            this.ubtSave.StyleCustomMode = true;
            this.ubtSave.TabIndex = 80;
            this.ubtSave.Text = "提交保存";
            this.ubtSave.Click += new System.EventHandler(this.ubtSave_Click);
            // 
            // utbPort
            // 
            this.utbPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.utbPort.DoubleValue = 1883D;
            this.utbPort.FillColor = System.Drawing.Color.White;
            this.utbPort.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.utbPort.IntValue = 1883;
            this.utbPort.Location = new System.Drawing.Point(728, 270);
            this.utbPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.utbPort.Maximum = 2147483647D;
            this.utbPort.Minimum = -2147483648D;
            this.utbPort.Name = "utbPort";
            this.utbPort.Padding = new System.Windows.Forms.Padding(5);
            this.utbPort.ReadOnly = true;
            this.utbPort.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.utbPort.Size = new System.Drawing.Size(207, 29);
            this.utbPort.Style = Sunny.UI.UIStyle.Black;
            this.utbPort.TabIndex = 82;
            this.utbPort.Text = "1883";
            this.utbPort.Watermark = "";
            this.utbPort.Click += new System.EventHandler(this.uiTextBox2_Click);
            // 
            // uiLine20
            // 
            this.uiLine20.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine20.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine20.ForeColor = System.Drawing.Color.Silver;
            this.uiLine20.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine20.Location = new System.Drawing.Point(726, 246);
            this.uiLine20.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine20.Name = "uiLine20";
            this.uiLine20.Size = new System.Drawing.Size(209, 20);
            this.uiLine20.Style = Sunny.UI.UIStyle.Black;
            this.uiLine20.TabIndex = 81;
            this.uiLine20.Text = "端口号";
            this.uiLine20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // utbAccount
            // 
            this.utbAccount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.utbAccount.FillColor = System.Drawing.Color.White;
            this.utbAccount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.utbAccount.Location = new System.Drawing.Point(368, 213);
            this.utbAccount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.utbAccount.Maximum = 2147483647D;
            this.utbAccount.Minimum = -2147483648D;
            this.utbAccount.Name = "utbAccount";
            this.utbAccount.Padding = new System.Windows.Forms.Padding(5);
            this.utbAccount.ReadOnly = true;
            this.utbAccount.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.utbAccount.Size = new System.Drawing.Size(164, 29);
            this.utbAccount.Style = Sunny.UI.UIStyle.Black;
            this.utbAccount.TabIndex = 84;
            this.utbAccount.Watermark = "";
            this.utbAccount.Click += new System.EventHandler(this.uiTextBox2_Click);
            // 
            // uiLine21
            // 
            this.uiLine21.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine21.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine21.ForeColor = System.Drawing.Color.Silver;
            this.uiLine21.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine21.Location = new System.Drawing.Point(366, 190);
            this.uiLine21.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine21.Name = "uiLine21";
            this.uiLine21.Size = new System.Drawing.Size(166, 20);
            this.uiLine21.Style = Sunny.UI.UIStyle.Black;
            this.uiLine21.TabIndex = 83;
            this.uiLine21.Text = "账号";
            this.uiLine21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucbSeriePort
            // 
            this.ucbSeriePort.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.ucbSeriePort.FillColor = System.Drawing.Color.White;
            this.ucbSeriePort.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucbSeriePort.Location = new System.Drawing.Point(14, 33);
            this.ucbSeriePort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucbSeriePort.MinimumSize = new System.Drawing.Size(63, 0);
            this.ucbSeriePort.Name = "ucbSeriePort";
            this.ucbSeriePort.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.ucbSeriePort.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.ucbSeriePort.Size = new System.Drawing.Size(344, 29);
            this.ucbSeriePort.Style = Sunny.UI.UIStyle.Black;
            this.ucbSeriePort.TabIndex = 85;
            this.ucbSeriePort.Text = "数据串口";
            this.ucbSeriePort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucbChannel
            // 
            this.ucbChannel.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.ucbChannel.FillColor = System.Drawing.Color.White;
            this.ucbChannel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucbChannel.Items.AddRange(new object[] {
            "1号通道",
            "2号通道",
            "3号通道",
            "4号通道",
            "5号通道",
            "6号通道"});
            this.ucbChannel.Location = new System.Drawing.Point(372, 33);
            this.ucbChannel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucbChannel.MinimumSize = new System.Drawing.Size(63, 0);
            this.ucbChannel.Name = "ucbChannel";
            this.ucbChannel.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.ucbChannel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.ucbChannel.Size = new System.Drawing.Size(194, 29);
            this.ucbChannel.Style = Sunny.UI.UIStyle.Black;
            this.ucbChannel.TabIndex = 86;
            this.ucbChannel.Text = "数据通道";
            this.ucbChannel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucbChannel.SelectedIndexChanged += new System.EventHandler(this.ucbChannel_SelectedIndexChanged);
            // 
            // ccbCheckBits
            // 
            this.ccbCheckBits.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.ccbCheckBits.FillColor = System.Drawing.Color.White;
            this.ccbCheckBits.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ccbCheckBits.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.ccbCheckBits.Location = new System.Drawing.Point(16, 82);
            this.ccbCheckBits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ccbCheckBits.MinimumSize = new System.Drawing.Size(63, 0);
            this.ccbCheckBits.Name = "ccbCheckBits";
            this.ccbCheckBits.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.ccbCheckBits.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.ccbCheckBits.Size = new System.Drawing.Size(161, 29);
            this.ccbCheckBits.Style = Sunny.UI.UIStyle.Black;
            this.ccbCheckBits.TabIndex = 87;
            this.ccbCheckBits.Text = "校验位";
            this.ccbCheckBits.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucbBaudRate
            // 
            this.ucbBaudRate.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.ucbBaudRate.FillColor = System.Drawing.Color.White;
            this.ucbBaudRate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucbBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.ucbBaudRate.Location = new System.Drawing.Point(185, 82);
            this.ucbBaudRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucbBaudRate.MinimumSize = new System.Drawing.Size(63, 0);
            this.ucbBaudRate.Name = "ucbBaudRate";
            this.ucbBaudRate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.ucbBaudRate.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.ucbBaudRate.Size = new System.Drawing.Size(173, 29);
            this.ucbBaudRate.Style = Sunny.UI.UIStyle.Black;
            this.ucbBaudRate.TabIndex = 88;
            this.ucbBaudRate.Text = "波特率";
            this.ucbBaudRate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucbStopBits
            // 
            this.ucbStopBits.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.ucbStopBits.FillColor = System.Drawing.Color.White;
            this.ucbStopBits.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucbStopBits.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "1.5"});
            this.ucbStopBits.Location = new System.Drawing.Point(16, 132);
            this.ucbStopBits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucbStopBits.MinimumSize = new System.Drawing.Size(63, 0);
            this.ucbStopBits.Name = "ucbStopBits";
            this.ucbStopBits.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.ucbStopBits.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.ucbStopBits.Size = new System.Drawing.Size(161, 29);
            this.ucbStopBits.Style = Sunny.UI.UIStyle.Black;
            this.ucbStopBits.TabIndex = 89;
            this.ucbStopBits.Text = "停止位";
            this.ucbStopBits.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucbDataBits
            // 
            this.ucbDataBits.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.ucbDataBits.FillColor = System.Drawing.Color.White;
            this.ucbDataBits.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucbDataBits.Items.AddRange(new object[] {
            "7",
            "8",
            "6",
            "5"});
            this.ucbDataBits.Location = new System.Drawing.Point(185, 132);
            this.ucbDataBits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucbDataBits.MinimumSize = new System.Drawing.Size(63, 0);
            this.ucbDataBits.Name = "ucbDataBits";
            this.ucbDataBits.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.ucbDataBits.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.ucbDataBits.Size = new System.Drawing.Size(173, 29);
            this.ucbDataBits.Style = Sunny.UI.UIStyle.Black;
            this.ucbDataBits.TabIndex = 90;
            this.ucbDataBits.Text = "数据位";
            this.ucbDataBits.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucbDeviceAddress
            // 
            this.ucbDeviceAddress.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.ucbDeviceAddress.FillColor = System.Drawing.Color.White;
            this.ucbDeviceAddress.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucbDeviceAddress.Items.AddRange(new object[] {
            "空",
            "001",
            "002",
            "003",
            "004",
            "005",
            "006",
            "007",
            "008",
            "009",
            "010",
            "011",
            "012"});
            this.ucbDeviceAddress.Location = new System.Drawing.Point(372, 132);
            this.ucbDeviceAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucbDeviceAddress.MinimumSize = new System.Drawing.Size(63, 0);
            this.ucbDeviceAddress.Name = "ucbDeviceAddress";
            this.ucbDeviceAddress.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.ucbDeviceAddress.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.ucbDeviceAddress.Size = new System.Drawing.Size(190, 29);
            this.ucbDeviceAddress.Style = Sunny.UI.UIStyle.Black;
            this.ucbDeviceAddress.TabIndex = 91;
            this.ucbDeviceAddress.Text = "设备地址";
            this.ucbDeviceAddress.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucbDeviceAddress.SelectedIndexChanged += new System.EventHandler(this.ucbDeviceAddress_SelectedIndexChanged);
            // 
            // uiLine22
            // 
            this.uiLine22.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine22.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine22.ForeColor = System.Drawing.Color.Silver;
            this.uiLine22.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine22.Location = new System.Drawing.Point(570, 13);
            this.uiLine22.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine22.Name = "uiLine22";
            this.uiLine22.Size = new System.Drawing.Size(161, 20);
            this.uiLine22.Style = Sunny.UI.UIStyle.Black;
            this.uiLine22.TabIndex = 92;
            this.uiLine22.Text = "写超时时间(毫秒)";
            this.uiLine22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uddWriteTimeout
            // 
            this.uddWriteTimeout.Decimal = 0;
            this.uddWriteTimeout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uddWriteTimeout.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uddWriteTimeout.ForeColor = System.Drawing.Color.Silver;
            this.uddWriteTimeout.Location = new System.Drawing.Point(574, 33);
            this.uddWriteTimeout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uddWriteTimeout.MinimumSize = new System.Drawing.Size(100, 0);
            this.uddWriteTimeout.Name = "uddWriteTimeout";
            this.uddWriteTimeout.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uddWriteTimeout.Size = new System.Drawing.Size(157, 29);
            this.uddWriteTimeout.Step = 1D;
            this.uddWriteTimeout.Style = Sunny.UI.UIStyle.Black;
            this.uddWriteTimeout.TabIndex = 93;
            this.uddWriteTimeout.Text = null;
            this.uddWriteTimeout.Value = 1000D;
            // 
            // uddReadTimeOut
            // 
            this.uddReadTimeOut.Decimal = 0;
            this.uddReadTimeOut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uddReadTimeOut.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uddReadTimeOut.ForeColor = System.Drawing.Color.Silver;
            this.uddReadTimeOut.Location = new System.Drawing.Point(574, 84);
            this.uddReadTimeOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uddReadTimeOut.MinimumSize = new System.Drawing.Size(100, 0);
            this.uddReadTimeOut.Name = "uddReadTimeOut";
            this.uddReadTimeOut.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uddReadTimeOut.Size = new System.Drawing.Size(157, 29);
            this.uddReadTimeOut.Step = 1D;
            this.uddReadTimeOut.Style = Sunny.UI.UIStyle.Black;
            this.uddReadTimeOut.TabIndex = 95;
            this.uddReadTimeOut.Text = null;
            this.uddReadTimeOut.Value = 1000D;
            // 
            // uiLine23
            // 
            this.uiLine23.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine23.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine23.ForeColor = System.Drawing.Color.Silver;
            this.uiLine23.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine23.Location = new System.Drawing.Point(570, 64);
            this.uiLine23.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine23.Name = "uiLine23";
            this.uiLine23.Size = new System.Drawing.Size(161, 20);
            this.uiLine23.Style = Sunny.UI.UIStyle.Black;
            this.uiLine23.TabIndex = 94;
            this.uiLine23.Text = "读超时时间(毫秒)";
            this.uiLine23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uddPackSize
            // 
            this.uddPackSize.Decimal = 0;
            this.uddPackSize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uddPackSize.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uddPackSize.ForeColor = System.Drawing.Color.Silver;
            this.uddPackSize.Location = new System.Drawing.Point(574, 132);
            this.uddPackSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uddPackSize.Maximum = 64D;
            this.uddPackSize.Minimum = 1D;
            this.uddPackSize.MinimumSize = new System.Drawing.Size(100, 0);
            this.uddPackSize.Name = "uddPackSize";
            this.uddPackSize.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uddPackSize.Size = new System.Drawing.Size(157, 29);
            this.uddPackSize.Step = 1D;
            this.uddPackSize.Style = Sunny.UI.UIStyle.Black;
            this.uddPackSize.TabIndex = 97;
            this.uddPackSize.Text = null;
            this.uddPackSize.Value = 2048D;
            // 
            // uiLine24
            // 
            this.uiLine24.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine24.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine24.ForeColor = System.Drawing.Color.Silver;
            this.uiLine24.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine24.Location = new System.Drawing.Point(570, 112);
            this.uiLine24.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine24.Name = "uiLine24";
            this.uiLine24.Size = new System.Drawing.Size(161, 20);
            this.uiLine24.Style = Sunny.UI.UIStyle.Black;
            this.uiLine24.TabIndex = 96;
            this.uiLine24.Text = "包最大长度(byte)";
            this.uiLine24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uddCollectFaultsInternal
            // 
            this.uddCollectFaultsInternal.Decimal = 0;
            this.uddCollectFaultsInternal.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uddCollectFaultsInternal.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uddCollectFaultsInternal.ForeColor = System.Drawing.Color.Silver;
            this.uddCollectFaultsInternal.Location = new System.Drawing.Point(765, 132);
            this.uddCollectFaultsInternal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uddCollectFaultsInternal.MinimumSize = new System.Drawing.Size(100, 0);
            this.uddCollectFaultsInternal.Name = "uddCollectFaultsInternal";
            this.uddCollectFaultsInternal.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uddCollectFaultsInternal.Size = new System.Drawing.Size(155, 29);
            this.uddCollectFaultsInternal.Step = 1D;
            this.uddCollectFaultsInternal.Style = Sunny.UI.UIStyle.Black;
            this.uddCollectFaultsInternal.TabIndex = 103;
            this.uddCollectFaultsInternal.Text = null;
            this.uddCollectFaultsInternal.Value = 15D;
            // 
            // uiLine25
            // 
            this.uiLine25.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine25.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine25.ForeColor = System.Drawing.Color.Silver;
            this.uiLine25.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine25.Location = new System.Drawing.Point(761, 112);
            this.uiLine25.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine25.Name = "uiLine25";
            this.uiLine25.Size = new System.Drawing.Size(159, 20);
            this.uiLine25.Style = Sunny.UI.UIStyle.Black;
            this.uiLine25.TabIndex = 102;
            this.uiLine25.Text = "重试间隔(毫秒)";
            this.uiLine25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uddCollectFaultsNumber
            // 
            this.uddCollectFaultsNumber.Decimal = 0;
            this.uddCollectFaultsNumber.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uddCollectFaultsNumber.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uddCollectFaultsNumber.ForeColor = System.Drawing.Color.Silver;
            this.uddCollectFaultsNumber.Location = new System.Drawing.Point(765, 84);
            this.uddCollectFaultsNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uddCollectFaultsNumber.MinimumSize = new System.Drawing.Size(100, 0);
            this.uddCollectFaultsNumber.Name = "uddCollectFaultsNumber";
            this.uddCollectFaultsNumber.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uddCollectFaultsNumber.Size = new System.Drawing.Size(155, 29);
            this.uddCollectFaultsNumber.Step = 1D;
            this.uddCollectFaultsNumber.Style = Sunny.UI.UIStyle.Black;
            this.uddCollectFaultsNumber.TabIndex = 101;
            this.uddCollectFaultsNumber.Text = null;
            this.uddCollectFaultsNumber.Value = 3D;
            // 
            // uiLine26
            // 
            this.uiLine26.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine26.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine26.ForeColor = System.Drawing.Color.Silver;
            this.uiLine26.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine26.Location = new System.Drawing.Point(761, 64);
            this.uiLine26.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine26.Name = "uiLine26";
            this.uiLine26.Size = new System.Drawing.Size(159, 20);
            this.uiLine26.Style = Sunny.UI.UIStyle.Black;
            this.uiLine26.TabIndex = 100;
            this.uiLine26.Text = "重试次数";
            this.uiLine26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine27
            // 
            this.uiLine27.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine27.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine27.ForeColor = System.Drawing.Color.Silver;
            this.uiLine27.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine27.Location = new System.Drawing.Point(761, 13);
            this.uiLine27.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine27.Name = "uiLine27";
            this.uiLine27.Size = new System.Drawing.Size(154, 20);
            this.uiLine27.Style = Sunny.UI.UIStyle.Black;
            this.uiLine27.TabIndex = 98;
            this.uiLine27.Text = "是否连续采集";
            this.uiLine27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucbContinueCollect
            // 
            this.ucbContinueCollect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucbContinueCollect.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucbContinueCollect.ForeColor = System.Drawing.Color.Silver;
            this.ucbContinueCollect.Location = new System.Drawing.Point(765, 36);
            this.ucbContinueCollect.Name = "ucbContinueCollect";
            this.ucbContinueCollect.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ucbContinueCollect.Size = new System.Drawing.Size(150, 29);
            this.ucbContinueCollect.Style = Sunny.UI.UIStyle.Black;
            this.ucbContinueCollect.TabIndex = 104;
            this.ucbContinueCollect.Text = "启用连续采集";
            // 
            // uddOffsetInterval
            // 
            this.uddOffsetInterval.Decimal = 0;
            this.uddOffsetInterval.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uddOffsetInterval.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uddOffsetInterval.ForeColor = System.Drawing.Color.Silver;
            this.uddOffsetInterval.Location = new System.Drawing.Point(935, 33);
            this.uddOffsetInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uddOffsetInterval.MinimumSize = new System.Drawing.Size(100, 0);
            this.uddOffsetInterval.Name = "uddOffsetInterval";
            this.uddOffsetInterval.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uddOffsetInterval.Size = new System.Drawing.Size(161, 29);
            this.uddOffsetInterval.Step = 1D;
            this.uddOffsetInterval.Style = Sunny.UI.UIStyle.Black;
            this.uddOffsetInterval.TabIndex = 106;
            this.uddOffsetInterval.Text = null;
            this.uddOffsetInterval.Value = 10D;
            // 
            // uiLine28
            // 
            this.uiLine28.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine28.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine28.ForeColor = System.Drawing.Color.Silver;
            this.uiLine28.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine28.Location = new System.Drawing.Point(931, 13);
            this.uiLine28.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine28.Name = "uiLine28";
            this.uiLine28.Size = new System.Drawing.Size(161, 20);
            this.uiLine28.Style = Sunny.UI.UIStyle.Black;
            this.uiLine28.TabIndex = 105;
            this.uiLine28.Text = "包偏移间隔";
            this.uiLine28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucbRTSEnable
            // 
            this.ucbRTSEnable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucbRTSEnable.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucbRTSEnable.ForeColor = System.Drawing.Color.Silver;
            this.ucbRTSEnable.Location = new System.Drawing.Point(937, 89);
            this.ucbRTSEnable.Name = "ucbRTSEnable";
            this.ucbRTSEnable.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ucbRTSEnable.Size = new System.Drawing.Size(150, 29);
            this.ucbRTSEnable.Style = Sunny.UI.UIStyle.Black;
            this.ucbRTSEnable.TabIndex = 108;
            this.ucbRTSEnable.Text = "启用RTS";
            // 
            // uiLine29
            // 
            this.uiLine29.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine29.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine29.ForeColor = System.Drawing.Color.Silver;
            this.uiLine29.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine29.Location = new System.Drawing.Point(933, 66);
            this.uiLine29.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine29.Name = "uiLine29";
            this.uiLine29.Size = new System.Drawing.Size(163, 20);
            this.uiLine29.Style = Sunny.UI.UIStyle.Black;
            this.uiLine29.TabIndex = 107;
            this.uiLine29.Text = "开启RTS";
            this.uiLine29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucbModbusType
            // 
            this.ucbModbusType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.ucbModbusType.FillColor = System.Drawing.Color.White;
            this.ucbModbusType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucbModbusType.Items.AddRange(new object[] {
            "ASCII",
            "RTU"});
            this.ucbModbusType.Location = new System.Drawing.Point(942, 133);
            this.ucbModbusType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucbModbusType.MinimumSize = new System.Drawing.Size(63, 0);
            this.ucbModbusType.Name = "ucbModbusType";
            this.ucbModbusType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.ucbModbusType.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.ucbModbusType.Size = new System.Drawing.Size(150, 29);
            this.ucbModbusType.Style = Sunny.UI.UIStyle.Black;
            this.ucbModbusType.TabIndex = 110;
            this.ucbModbusType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine30
            // 
            this.uiLine30.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine30.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine30.ForeColor = System.Drawing.Color.Silver;
            this.uiLine30.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine30.Location = new System.Drawing.Point(936, 112);
            this.uiLine30.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine30.Name = "uiLine30";
            this.uiLine30.Size = new System.Drawing.Size(154, 20);
            this.uiLine30.Style = Sunny.UI.UIStyle.Black;
            this.uiLine30.TabIndex = 109;
            this.uiLine30.Text = "Modbus Type";
            this.uiLine30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.uiButton1.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.uiButton1.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.uiButton1.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton1.Location = new System.Drawing.Point(987, 435);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Radius = 35;
            this.uiButton1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.uiButton1.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.uiButton1.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.uiButton1.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.uiButton1.Size = new System.Drawing.Size(100, 35);
            this.uiButton1.Style = Sunny.UI.UIStyle.Green;
            this.uiButton1.StyleCustomMode = true;
            this.uiButton1.TabIndex = 111;
            this.uiButton1.Text = "启动调试";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // SystenSetFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 542);
            this.Name = "SystenSetFrm";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.Style = Sunny.UI.UIStyle.Black;
            this.Text = "系统配置";
            this.PagePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UILine uiLine7;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UILine uiLine4;
        private Sunny.UI.UILine uiLine5;
        private Sunny.UI.UILine uiLine11;
        private Sunny.UI.UILine uiLine6;
        private Sunny.UI.UILine uiLine8;
        private Sunny.UI.UITextBox utbChannelName;
        private Sunny.UI.UILine uiLine9;
        private Sunny.UI.UITextBox utbClientID;
        private Sunny.UI.UILine uiLine10;
        private Sunny.UI.UIButton ubtNewGuid;
        private Sunny.UI.UITextBox utbDataPublicTopic;
        private Sunny.UI.UILine uiLine12;
        private Sunny.UI.UITextBox utbCommandSubTopic;
        private Sunny.UI.UILine uiLine13;
        private Sunny.UI.UITextBox utbUpdateCycleSubTopic;
        private Sunny.UI.UILine uiLine14;
        private Sunny.UI.UITextBox utbPassiveSubTopic;
        private Sunny.UI.UILine uiLine15;
        private Sunny.UI.UIRadioButton uiRadioButton2;
        private Sunny.UI.UIRadioButton uiRadioButton1;
        private Sunny.UI.UILine uiLine16;
        private Sunny.UI.UILine uiLine17;
        private Sunny.UI.UIDoubleUpDown uddUpdateCycle;
        private Sunny.UI.UITextBox utbPassword;
        private Sunny.UI.UILine uiLine19;
        private Sunny.UI.UITextBox utbServerIP;
        private Sunny.UI.UILine uiLine18;
        private Sunny.UI.UIButton ubtSave;
        private Sunny.UI.UITextBox utbPort;
        private Sunny.UI.UILine uiLine20;
        private Sunny.UI.UITextBox utbAccount;
        private Sunny.UI.UILine uiLine21;
        private Sunny.UI.UIComboBox ucbChannel;
        private Sunny.UI.UIComboBox ucbSeriePort;
        private Sunny.UI.UIComboBox ucbDeviceAddress;
        private Sunny.UI.UIComboBox ucbDataBits;
        private Sunny.UI.UIComboBox ucbStopBits;
        private Sunny.UI.UIComboBox ucbBaudRate;
        private Sunny.UI.UIComboBox ccbCheckBits;
        private Sunny.UI.UILine uiLine22;
        private Sunny.UI.UIDoubleUpDown uddWriteTimeout;
        private Sunny.UI.UIDoubleUpDown uddReadTimeOut;
        private Sunny.UI.UILine uiLine23;
        private Sunny.UI.UIDoubleUpDown uddPackSize;
        private Sunny.UI.UILine uiLine24;
        private Sunny.UI.UIDoubleUpDown uddCollectFaultsInternal;
        private Sunny.UI.UILine uiLine25;
        private Sunny.UI.UIDoubleUpDown uddCollectFaultsNumber;
        private Sunny.UI.UILine uiLine26;
        private Sunny.UI.UILine uiLine27;
        private Sunny.UI.UICheckBox ucbContinueCollect;
        private Sunny.UI.UIDoubleUpDown uddOffsetInterval;
        private Sunny.UI.UILine uiLine28;
        private Sunny.UI.UICheckBox ucbRTSEnable;
        private Sunny.UI.UILine uiLine29;
        private Sunny.UI.UIComboBox ucbModbusType;
        private Sunny.UI.UILine uiLine30;
        private Sunny.UI.UIButton uiButton1;
    }
}