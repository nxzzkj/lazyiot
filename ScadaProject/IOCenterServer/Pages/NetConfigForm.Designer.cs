namespace ScadaCenterServer.Pages
{
    partial class NetConfigForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.ucDelayTime = new Scada.Controls.Controls.UCTextBoxEx();
            this.label16 = new System.Windows.Forms.Label();
            this.ucLocalPort = new Scada.Controls.Controls.UCTextBoxEx();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbHeart = new System.Windows.Forms.TextBox();
            this.tbTail = new System.Windows.Forms.TextBox();
            this.tbHead = new System.Windows.Forms.TextBox();
            this.lbHeart = new System.Windows.Forms.Label();
            this.lbTail = new System.Windows.Forms.Label();
            this.lbHead = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ucSendTimeout = new Scada.Controls.Controls.UCTextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.ucSendBufferSize = new Scada.Controls.Controls.UCTextBoxEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ucReceiveTimeout = new Scada.Controls.Controls.UCTextBoxEx();
            this.label8 = new System.Windows.Forms.Label();
            this.ucReceiveBufferSize = new Scada.Controls.Controls.UCTextBoxEx();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Size = new System.Drawing.Size(602, 369);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 396);
            this.panel2.Size = new System.Drawing.Size(602, 42);
            // 
            // btnOK
            // 
            this.btnOK.BtnClick += new System.EventHandler(this.btnOK_BtnClick);
            // 
            // btnCancel
            // 
            this.btnCancel.BtnClick += new System.EventHandler(this.btnCancel_BtnClick);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(602, 26);
            this.lblTitle.Text = "网络通信设置";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(574, 0);
            // 
            // btMin
            // 
            this.btMin.Location = new System.Drawing.Point(542, 0);
            this.btMin.Visible = false;
            // 
            // btMax
            // 
            this.btMax.Location = new System.Drawing.Point(512, 0);
            this.btMax.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 369);
            this.panel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.ucDelayTime);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.ucLocalPort);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(0, 296);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(602, 68);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "端口定义";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(507, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 17);
            this.label17.TabIndex = 25;
            this.label17.Text = "毫秒";
            // 
            // ucDelayTime
            // 
            this.ucDelayTime.BackColor = System.Drawing.Color.Transparent;
            this.ucDelayTime.ConerRadius = 5;
            this.ucDelayTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ucDelayTime.DecLength = 2;
            this.ucDelayTime.FillColor = System.Drawing.Color.Empty;
            this.ucDelayTime.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucDelayTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucDelayTime.InputText = "100";
            this.ucDelayTime.InputType = Scada.Controls.TextInputType.Number;
            this.ucDelayTime.IsFocusColor = true;
            this.ucDelayTime.IsRadius = true;
            this.ucDelayTime.IsShowClearBtn = true;
            this.ucDelayTime.IsShowKeyboard = false;
            this.ucDelayTime.IsShowRect = true;
            this.ucDelayTime.IsShowSearchBtn = false;
            this.ucDelayTime.KeyBoardType = Scada.Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.ucDelayTime.Location = new System.Drawing.Point(373, 27);
            this.ucDelayTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucDelayTime.MaxValue = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.ucDelayTime.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ucDelayTime.Name = "ucDelayTime";
            this.ucDelayTime.Padding = new System.Windows.Forms.Padding(5);
            this.ucDelayTime.PromptColor = System.Drawing.Color.Gray;
            this.ucDelayTime.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucDelayTime.PromptText = "";
            this.ucDelayTime.ReadOnly = false;
            this.ucDelayTime.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucDelayTime.RectWidth = 1;
            this.ucDelayTime.RegexPattern = "";
            this.ucDelayTime.Size = new System.Drawing.Size(127, 30);
            this.ucDelayTime.TabIndex = 24;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(302, 34);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 17);
            this.label16.TabIndex = 23;
            this.label16.Text = "发送延迟:";
            // 
            // ucLocalPort
            // 
            this.ucLocalPort.BackColor = System.Drawing.Color.Transparent;
            this.ucLocalPort.ConerRadius = 5;
            this.ucLocalPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ucLocalPort.DecLength = 2;
            this.ucLocalPort.FillColor = System.Drawing.Color.Empty;
            this.ucLocalPort.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucLocalPort.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucLocalPort.InputText = "8808";
            this.ucLocalPort.InputType = Scada.Controls.TextInputType.Number;
            this.ucLocalPort.IsFocusColor = true;
            this.ucLocalPort.IsRadius = true;
            this.ucLocalPort.IsShowClearBtn = true;
            this.ucLocalPort.IsShowKeyboard = false;
            this.ucLocalPort.IsShowRect = true;
            this.ucLocalPort.IsShowSearchBtn = false;
            this.ucLocalPort.KeyBoardType = Scada.Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.ucLocalPort.Location = new System.Drawing.Point(116, 28);
            this.ucLocalPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucLocalPort.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ucLocalPort.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ucLocalPort.Name = "ucLocalPort";
            this.ucLocalPort.Padding = new System.Windows.Forms.Padding(5);
            this.ucLocalPort.PromptColor = System.Drawing.Color.Gray;
            this.ucLocalPort.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucLocalPort.PromptText = "";
            this.ucLocalPort.ReadOnly = false;
            this.ucLocalPort.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucLocalPort.RectWidth = 1;
            this.ucLocalPort.RegexPattern = "";
            this.ucLocalPort.Size = new System.Drawing.Size(154, 30);
            this.ucLocalPort.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 17);
            this.label14.TabIndex = 14;
            this.label14.Text = "本地监听端口:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbHeart);
            this.groupBox3.Controls.Add(this.tbTail);
            this.groupBox3.Controls.Add(this.tbHead);
            this.groupBox3.Controls.Add(this.lbHeart);
            this.groupBox3.Controls.Add(this.lbTail);
            this.groupBox3.Controls.Add(this.lbHead);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(0, 162);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(602, 134);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据包定义";
            // 
            // tbHeart
            // 
            this.tbHeart.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbHeart.Location = new System.Drawing.Point(128, 101);
            this.tbHeart.Name = "tbHeart";
            this.tbHeart.Size = new System.Drawing.Size(142, 26);
            this.tbHeart.TabIndex = 22;
            this.tbHeart.TextChanged += new System.EventHandler(this.tbHeart_TextChanged);
            // 
            // tbTail
            // 
            this.tbTail.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbTail.Location = new System.Drawing.Point(408, 24);
            this.tbTail.Name = "tbTail";
            this.tbTail.Size = new System.Drawing.Size(142, 26);
            this.tbTail.TabIndex = 21;
            this.tbTail.TextChanged += new System.EventHandler(this.tbTail_TextChanged);
            // 
            // tbHead
            // 
            this.tbHead.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbHead.Location = new System.Drawing.Point(128, 27);
            this.tbHead.Name = "tbHead";
            this.tbHead.Size = new System.Drawing.Size(142, 26);
            this.tbHead.TabIndex = 20;
            this.tbHead.TextChanged += new System.EventHandler(this.tbHead_TextChanged);
            // 
            // lbHeart
            // 
            this.lbHeart.AutoSize = true;
            this.lbHeart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbHeart.Location = new System.Drawing.Point(387, 101);
            this.lbHeart.Name = "lbHeart";
            this.lbHeart.Size = new System.Drawing.Size(0, 17);
            this.lbHeart.TabIndex = 19;
            // 
            // lbTail
            // 
            this.lbTail.AutoSize = true;
            this.lbTail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbTail.Location = new System.Drawing.Point(408, 66);
            this.lbTail.Name = "lbTail";
            this.lbTail.Size = new System.Drawing.Size(0, 17);
            this.lbTail.TabIndex = 18;
            // 
            // lbHead
            // 
            this.lbHead.AutoSize = true;
            this.lbHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbHead.Location = new System.Drawing.Point(127, 66);
            this.lbHead.Name = "lbHead";
            this.lbHead.Size = new System.Drawing.Size(0, 17);
            this.lbHead.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(322, 101);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 17);
            this.label15.TabIndex = 16;
            this.label15.Text = "字节编码:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(343, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 17);
            this.label13.TabIndex = 15;
            this.label13.Text = "字节编码:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(62, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 17);
            this.label12.TabIndex = 14;
            this.label12.Text = "字节编码:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 17);
            this.label11.TabIndex = 10;
            this.label11.Text = "心跳包开始字节:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(307, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "数据包结束字符:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "数据包开始字符:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ucSendTimeout);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ucSendBufferSize);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网络发送配置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(507, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "毫秒";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "字节";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "发送超时:";
            // 
            // ucSendTimeout
            // 
            this.ucSendTimeout.BackColor = System.Drawing.Color.Transparent;
            this.ucSendTimeout.ConerRadius = 5;
            this.ucSendTimeout.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ucSendTimeout.DecLength = 2;
            this.ucSendTimeout.FillColor = System.Drawing.Color.Empty;
            this.ucSendTimeout.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucSendTimeout.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucSendTimeout.InputText = "1024";
            this.ucSendTimeout.InputType = Scada.Controls.TextInputType.Number;
            this.ucSendTimeout.IsFocusColor = true;
            this.ucSendTimeout.IsRadius = true;
            this.ucSendTimeout.IsShowClearBtn = true;
            this.ucSendTimeout.IsShowKeyboard = false;
            this.ucSendTimeout.IsShowRect = true;
            this.ucSendTimeout.IsShowSearchBtn = false;
            this.ucSendTimeout.KeyBoardType = Scada.Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.ucSendTimeout.Location = new System.Drawing.Point(373, 32);
            this.ucSendTimeout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucSendTimeout.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ucSendTimeout.MinValue = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.ucSendTimeout.Name = "ucSendTimeout";
            this.ucSendTimeout.Padding = new System.Windows.Forms.Padding(5);
            this.ucSendTimeout.PromptColor = System.Drawing.Color.Gray;
            this.ucSendTimeout.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucSendTimeout.PromptText = "";
            this.ucSendTimeout.ReadOnly = false;
            this.ucSendTimeout.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucSendTimeout.RectWidth = 1;
            this.ucSendTimeout.RegexPattern = "";
            this.ucSendTimeout.Size = new System.Drawing.Size(127, 30);
            this.ucSendTimeout.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "发送缓存字节:";
            // 
            // ucSendBufferSize
            // 
            this.ucSendBufferSize.BackColor = System.Drawing.Color.Transparent;
            this.ucSendBufferSize.ConerRadius = 5;
            this.ucSendBufferSize.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ucSendBufferSize.DecLength = 2;
            this.ucSendBufferSize.FillColor = System.Drawing.Color.Empty;
            this.ucSendBufferSize.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucSendBufferSize.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucSendBufferSize.InputText = "1024";
            this.ucSendBufferSize.InputType = Scada.Controls.TextInputType.Number;
            this.ucSendBufferSize.IsFocusColor = true;
            this.ucSendBufferSize.IsRadius = true;
            this.ucSendBufferSize.IsShowClearBtn = true;
            this.ucSendBufferSize.IsShowKeyboard = false;
            this.ucSendBufferSize.IsShowRect = true;
            this.ucSendBufferSize.IsShowSearchBtn = false;
            this.ucSendBufferSize.KeyBoardType = Scada.Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.ucSendBufferSize.Location = new System.Drawing.Point(116, 32);
            this.ucSendBufferSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucSendBufferSize.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ucSendBufferSize.MinValue = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.ucSendBufferSize.Name = "ucSendBufferSize";
            this.ucSendBufferSize.Padding = new System.Windows.Forms.Padding(5);
            this.ucSendBufferSize.PromptColor = System.Drawing.Color.Gray;
            this.ucSendBufferSize.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucSendBufferSize.PromptText = "";
            this.ucSendBufferSize.ReadOnly = false;
            this.ucSendBufferSize.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucSendBufferSize.RectWidth = 1;
            this.ucSendBufferSize.RegexPattern = "";
            this.ucSendBufferSize.Size = new System.Drawing.Size(127, 30);
            this.ucSendBufferSize.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.ucReceiveTimeout);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.ucReceiveBufferSize);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 82);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "网络接收配置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(507, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "毫秒";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(250, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "字节";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(307, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "接收超时:";
            // 
            // ucReceiveTimeout
            // 
            this.ucReceiveTimeout.BackColor = System.Drawing.Color.Transparent;
            this.ucReceiveTimeout.ConerRadius = 5;
            this.ucReceiveTimeout.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ucReceiveTimeout.DecLength = 2;
            this.ucReceiveTimeout.FillColor = System.Drawing.Color.Empty;
            this.ucReceiveTimeout.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucReceiveTimeout.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucReceiveTimeout.InputText = "1024";
            this.ucReceiveTimeout.InputType = Scada.Controls.TextInputType.Number;
            this.ucReceiveTimeout.IsFocusColor = true;
            this.ucReceiveTimeout.IsRadius = true;
            this.ucReceiveTimeout.IsShowClearBtn = true;
            this.ucReceiveTimeout.IsShowKeyboard = false;
            this.ucReceiveTimeout.IsShowRect = true;
            this.ucReceiveTimeout.IsShowSearchBtn = false;
            this.ucReceiveTimeout.KeyBoardType = Scada.Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.ucReceiveTimeout.Location = new System.Drawing.Point(373, 34);
            this.ucReceiveTimeout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucReceiveTimeout.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ucReceiveTimeout.MinValue = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.ucReceiveTimeout.Name = "ucReceiveTimeout";
            this.ucReceiveTimeout.Padding = new System.Windows.Forms.Padding(5);
            this.ucReceiveTimeout.PromptColor = System.Drawing.Color.Gray;
            this.ucReceiveTimeout.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucReceiveTimeout.PromptText = "";
            this.ucReceiveTimeout.ReadOnly = false;
            this.ucReceiveTimeout.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucReceiveTimeout.RectWidth = 1;
            this.ucReceiveTimeout.RegexPattern = "";
            this.ucReceiveTimeout.Size = new System.Drawing.Size(127, 30);
            this.ucReceiveTimeout.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "接收缓存字节:";
            // 
            // ucReceiveBufferSize
            // 
            this.ucReceiveBufferSize.BackColor = System.Drawing.Color.Transparent;
            this.ucReceiveBufferSize.ConerRadius = 5;
            this.ucReceiveBufferSize.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ucReceiveBufferSize.DecLength = 2;
            this.ucReceiveBufferSize.FillColor = System.Drawing.Color.Empty;
            this.ucReceiveBufferSize.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucReceiveBufferSize.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucReceiveBufferSize.InputText = "1024";
            this.ucReceiveBufferSize.InputType = Scada.Controls.TextInputType.Number;
            this.ucReceiveBufferSize.IsFocusColor = true;
            this.ucReceiveBufferSize.IsRadius = true;
            this.ucReceiveBufferSize.IsShowClearBtn = true;
            this.ucReceiveBufferSize.IsShowKeyboard = false;
            this.ucReceiveBufferSize.IsShowRect = true;
            this.ucReceiveBufferSize.IsShowSearchBtn = false;
            this.ucReceiveBufferSize.KeyBoardType = Scada.Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.ucReceiveBufferSize.Location = new System.Drawing.Point(116, 34);
            this.ucReceiveBufferSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucReceiveBufferSize.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ucReceiveBufferSize.MinValue = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.ucReceiveBufferSize.Name = "ucReceiveBufferSize";
            this.ucReceiveBufferSize.Padding = new System.Windows.Forms.Padding(5);
            this.ucReceiveBufferSize.PromptColor = System.Drawing.Color.Gray;
            this.ucReceiveBufferSize.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucReceiveBufferSize.PromptText = "";
            this.ucReceiveBufferSize.ReadOnly = false;
            this.ucReceiveBufferSize.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucReceiveBufferSize.RectWidth = 1;
            this.ucReceiveBufferSize.RegexPattern = "";
            this.ucReceiveBufferSize.Size = new System.Drawing.Size(127, 30);
            this.ucReceiveBufferSize.TabIndex = 6;
            // 
            // NetConfigForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(602, 439);
            this.Controls.Add(this.panel1);
            this.Name = "NetConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "网络配置";
            this.Title = "网络通信设置";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btMin, 0);
            this.Controls.SetChildIndex(this.btMax, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private Scada.Controls.Controls.UCTextBoxEx ucSendBufferSize;
        private System.Windows.Forms.Label label2;
        private Scada.Controls.Controls.UCTextBoxEx ucSendTimeout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Scada.Controls.Controls.UCTextBoxEx ucReceiveTimeout;
        private System.Windows.Forms.Label label8;
        private Scada.Controls.Controls.UCTextBoxEx ucReceiveBufferSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private Scada.Controls.Controls.UCTextBoxEx ucLocalPort;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbTail;
        private System.Windows.Forms.Label lbHead;
        private System.Windows.Forms.Label lbHeart;
        private System.Windows.Forms.TextBox tbHeart;
        private System.Windows.Forms.TextBox tbTail;
        private System.Windows.Forms.TextBox tbHead;
        private System.Windows.Forms.Label label16;
        private Scada.Controls.Controls.UCTextBoxEx ucDelayTime;
        private System.Windows.Forms.Label label17;
    }
}