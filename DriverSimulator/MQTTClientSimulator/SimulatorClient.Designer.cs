namespace MQTTClientSimulator
{
    partial class SimulatorClient
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewDevice = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btDeleteDevice = new System.Windows.Forms.Button();
            this.btEditDevice = new System.Windows.Forms.Button();
            this.btAddDevice = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewPara = new System.Windows.Forms.DataGridView();
            this.IOName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulatormax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulatormin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbClientIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPeried = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.cbAuto = new System.Windows.Forms.CheckBox();
            this.btOpen = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDataTopic = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCommandTopic = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbUpdateCycleTopic = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbDataPassiveTopic = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevice)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPara)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1236, 445);
            this.splitContainer1.SplitterDistance = 641;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewDevice);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(641, 402);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备管理";
            // 
            // dataGridViewDevice
            // 
            this.dataGridViewDevice.AllowUserToAddRows = false;
            this.dataGridViewDevice.AllowUserToDeleteRows = false;
            this.dataGridViewDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDevice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.ClientID});
            this.dataGridViewDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDevice.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewDevice.MultiSelect = false;
            this.dataGridViewDevice.Name = "dataGridViewDevice";
            this.dataGridViewDevice.RowTemplate.Height = 23;
            this.dataGridViewDevice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDevice.Size = new System.Drawing.Size(635, 382);
            this.dataGridViewDevice.TabIndex = 0;
            this.dataGridViewDevice.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewDevice_CellMouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btDeleteDevice);
            this.panel1.Controls.Add(this.btEditDevice);
            this.panel1.Controls.Add(this.btAddDevice);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 402);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 43);
            this.panel1.TabIndex = 2;
            // 
            // btDeleteDevice
            // 
            this.btDeleteDevice.Location = new System.Drawing.Point(152, 6);
            this.btDeleteDevice.Name = "btDeleteDevice";
            this.btDeleteDevice.Size = new System.Drawing.Size(66, 23);
            this.btDeleteDevice.TabIndex = 25;
            this.btDeleteDevice.Text = "删除";
            this.btDeleteDevice.UseVisualStyleBackColor = true;
            this.btDeleteDevice.Click += new System.EventHandler(this.btDeleteDevice_Click);
            // 
            // btEditDevice
            // 
            this.btEditDevice.Location = new System.Drawing.Point(80, 6);
            this.btEditDevice.Name = "btEditDevice";
            this.btEditDevice.Size = new System.Drawing.Size(66, 23);
            this.btEditDevice.TabIndex = 24;
            this.btEditDevice.Text = "修改";
            this.btEditDevice.UseVisualStyleBackColor = true;
            this.btEditDevice.Click += new System.EventHandler(this.btEditDevice_Click);
            // 
            // btAddDevice
            // 
            this.btAddDevice.Location = new System.Drawing.Point(8, 6);
            this.btAddDevice.Name = "btAddDevice";
            this.btAddDevice.Size = new System.Drawing.Size(66, 23);
            this.btAddDevice.TabIndex = 23;
            this.btAddDevice.Text = "增加";
            this.btAddDevice.UseVisualStyleBackColor = true;
            this.btAddDevice.Click += new System.EventHandler(this.btAddDevice_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewPara);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(591, 402);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "参数管理";
            // 
            // dataGridViewPara
            // 
            this.dataGridViewPara.AllowUserToAddRows = false;
            this.dataGridViewPara.AllowUserToDeleteRows = false;
            this.dataGridViewPara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPara.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IOName,
            this.simulatormax,
            this.simulatormin});
            this.dataGridViewPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPara.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewPara.MultiSelect = false;
            this.dataGridViewPara.Name = "dataGridViewPara";
            this.dataGridViewPara.RowTemplate.Height = 23;
            this.dataGridViewPara.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPara.Size = new System.Drawing.Size(585, 382);
            this.dataGridViewPara.TabIndex = 3;
            // 
            // IOName
            // 
            this.IOName.DataPropertyName = "name";
            this.IOName.HeaderText = "IO 名称";
            this.IOName.Name = "IOName";
            // 
            // simulatormax
            // 
            this.simulatormax.DataPropertyName = "SimulatorMax";
            this.simulatormax.HeaderText = "模拟最大值";
            this.simulatormax.Name = "simulatormax";
            // 
            // simulatormin
            // 
            this.simulatormin.DataPropertyName = "SimulatorMin";
            this.simulatormin.HeaderText = "模拟最小值";
            this.simulatormin.Name = "simulatormin";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 402);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(591, 43);
            this.panel2.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 220);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1250, 477);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1242, 451);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "参数管理";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBoxLog);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1242, 451);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "系统日志";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBoxLog
            // 
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 12;
            this.listBoxLog.Location = new System.Drawing.Point(3, 3);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(1236, 445);
            this.listBoxLog.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "MQTT服务器:";
            // 
            // tbClientIP
            // 
            this.tbClientIP.Location = new System.Drawing.Point(80, 13);
            this.tbClientIP.Name = "tbClientIP";
            this.tbClientIP.Size = new System.Drawing.Size(534, 21);
            this.tbClientIP.TabIndex = 1;
            this.tbClientIP.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "端口号:";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(80, 68);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(80, 21);
            this.tbPort.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "心跳周期:";
            // 
            // tbPeried
            // 
            this.tbPeried.Location = new System.Drawing.Point(230, 68);
            this.tbPeried.Name = "tbPeried";
            this.tbPeried.Size = new System.Drawing.Size(51, 21);
            this.tbPeried.TabIndex = 8;
            this.tbPeried.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "用户名:";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(384, 68);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(80, 21);
            this.tbUser.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(488, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "密码:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(526, 68);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(88, 21);
            this.tbPassword.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "ms";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(695, 12);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(66, 23);
            this.btStart.TabIndex = 14;
            this.btStart.Text = "启动客户端";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(695, 44);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(66, 23);
            this.btStop.TabIndex = 15;
            this.btStop.Text = "关闭客户端";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // cbAuto
            // 
            this.cbAuto.AutoSize = true;
            this.cbAuto.Location = new System.Drawing.Point(648, 71);
            this.cbAuto.Name = "cbAuto";
            this.cbAuto.Size = new System.Drawing.Size(96, 16);
            this.cbAuto.TabIndex = 16;
            this.cbAuto.Text = "被动上传数据";
            this.cbAuto.UseVisualStyleBackColor = true;
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(767, 12);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(66, 23);
            this.btOpen.TabIndex = 17;
            this.btOpen.Text = "打开文件";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(767, 44);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(66, 23);
            this.btSave.TabIndex = 18;
            this.btSave.Text = "保存文件";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "数据发布主题:";
            // 
            // tbDataTopic
            // 
            this.tbDataTopic.Location = new System.Drawing.Point(121, 98);
            this.tbDataTopic.Name = "tbDataTopic";
            this.tbDataTopic.Size = new System.Drawing.Size(712, 21);
            this.tbDataTopic.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "命令下置主题:";
            // 
            // tbCommandTopic
            // 
            this.tbCommandTopic.Location = new System.Drawing.Point(121, 125);
            this.tbCommandTopic.Name = "tbCommandTopic";
            this.tbCommandTopic.Size = new System.Drawing.Size(712, 21);
            this.tbCommandTopic.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "订阅采集周期主题:";
            // 
            // tbUpdateCycleTopic
            // 
            this.tbUpdateCycleTopic.Location = new System.Drawing.Point(121, 152);
            this.tbUpdateCycleTopic.Name = "tbUpdateCycleTopic";
            this.tbUpdateCycleTopic.Size = new System.Drawing.Size(712, 21);
            this.tbUpdateCycleTopic.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 12);
            this.label11.TabIndex = 25;
            this.label11.Text = "被动数据订阅主题:";
            // 
            // tbDataPassiveTopic
            // 
            this.tbDataPassiveTopic.Location = new System.Drawing.Point(120, 179);
            this.tbDataPassiveTopic.Name = "tbDataPassiveTopic";
            this.tbDataPassiveTopic.Size = new System.Drawing.Size(712, 21);
            this.tbDataPassiveTopic.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbDataPassiveTopic);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.tbUpdateCycleTopic);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.tbCommandTopic);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.tbDataTopic);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.btSave);
            this.panel3.Controls.Add(this.btOpen);
            this.panel3.Controls.Add(this.cbAuto);
            this.panel3.Controls.Add(this.btStop);
            this.panel3.Controls.Add(this.btStart);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.tbPassword);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.tbUser);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.tbPeried);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.tbPort);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.tbClientIP);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1250, 220);
            this.panel3.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "UID";
            this.Column1.HeaderText = "设备ID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name";
            this.Column2.HeaderText = "设备名称";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "UpdateCycle";
            this.Column3.HeaderText = "采集周期";
            this.Column3.Name = "Column3";
            // 
            // ClientID
            // 
            this.ClientID.DataPropertyName = "ClientID";
            this.ClientID.HeaderText = "MQTT客户端ID";
            this.ClientID.Name = "ClientID";
            // 
            // SimulatorClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 697);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel3);
            this.Name = "SimulatorClient";
            this.Text = "MQTT客户端数据模拟器";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevice)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPara)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewDevice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btDeleteDevice;
        private System.Windows.Forms.Button btEditDevice;
        private System.Windows.Forms.Button btAddDevice;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewPara;
        private System.Windows.Forms.DataGridViewTextBoxColumn IOName;
        private System.Windows.Forms.DataGridViewTextBoxColumn simulatormax;
        private System.Windows.Forms.DataGridViewTextBoxColumn simulatormin;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbClientIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPeried;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.CheckBox cbAuto;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbDataTopic;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbCommandTopic;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbUpdateCycleTopic;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbDataPassiveTopic;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientID;
    }
}

