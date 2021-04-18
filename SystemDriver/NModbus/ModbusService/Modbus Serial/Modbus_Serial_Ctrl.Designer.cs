namespace Modbus.ModbusService
{
    partial class Modbus_Serial_Ctrl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboSeriePort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCheck = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbRTSEnable = new System.Windows.Forms.CheckBox();
            this.nbSendAfterKeeyTime = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nbSendPreKeeyTime = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cbContinueCollect = new System.Windows.Forms.CheckBox();
            this.nbCollectNum = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nbPackSize = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.cbSixCmd = new System.Windows.Forms.CheckBox();
            this.cbSixteenCmd = new System.Windows.Forms.CheckBox();
            this.nbPackOffset = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.cbStopbits = new System.Windows.Forms.ComboBox();
            this.nbCollectInternal = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nbWriteTimeout = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.nbReadTimeout = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.cbModbusType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboSmSeriePort = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbSendAfterKeeyTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbSendPreKeeyTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbCollectNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbPackSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbPackOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbCollectInternal)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbWriteTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbReadTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // comboSeriePort
            // 
            this.comboSeriePort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSeriePort.FormattingEnabled = true;
            this.comboSeriePort.Location = new System.Drawing.Point(74, 22);
            this.comboSeriePort.Name = "comboSeriePort";
            this.comboSeriePort.Size = new System.Drawing.Size(160, 20);
            this.comboSeriePort.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率：";
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "50",
            "75",
            "100",
            "150",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400"});
            this.cbBaudRate.Location = new System.Drawing.Point(74, 52);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(160, 20);
            this.cbBaudRate.TabIndex = 3;
            this.cbBaudRate.Text = "19200";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "校验：";
            // 
            // cbCheck
            // 
            this.cbCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCheck.FormattingEnabled = true;
            this.cbCheck.Items.AddRange(new object[] {
            "无",
            "偶校验",
            "奇校验",
            "常1",
            "常0"});
            this.cbCheck.Location = new System.Drawing.Point(74, 82);
            this.cbCheck.Name = "cbCheck";
            this.cbCheck.Size = new System.Drawing.Size(160, 20);
            this.cbCheck.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "数据位：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "停止位：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbRTSEnable);
            this.groupBox1.Controls.Add(this.nbSendAfterKeeyTime);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.nbSendPreKeeyTime);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(251, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 84);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RTS   ";
            // 
            // cbRTSEnable
            // 
            this.cbRTSEnable.AutoSize = true;
            this.cbRTSEnable.Location = new System.Drawing.Point(28, 0);
            this.cbRTSEnable.Name = "cbRTSEnable";
            this.cbRTSEnable.Size = new System.Drawing.Size(15, 14);
            this.cbRTSEnable.TabIndex = 13;
            this.cbRTSEnable.UseVisualStyleBackColor = true;
            this.cbRTSEnable.CheckedChanged += new System.EventHandler(this.cbRTSEnable_CheckedChanged);
            // 
            // nbSendAfterKeeyTime
            // 
            this.nbSendAfterKeeyTime.Location = new System.Drawing.Point(165, 47);
            this.nbSendAfterKeeyTime.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nbSendAfterKeeyTime.Name = "nbSendAfterKeeyTime";
            this.nbSendAfterKeeyTime.Size = new System.Drawing.Size(51, 21);
            this.nbSendAfterKeeyTime.TabIndex = 12;
            this.nbSendAfterKeeyTime.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "发送后RTS保持时间(ms)：";
            // 
            // nbSendPreKeeyTime
            // 
            this.nbSendPreKeeyTime.Location = new System.Drawing.Point(165, 20);
            this.nbSendPreKeeyTime.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nbSendPreKeeyTime.Name = "nbSendPreKeeyTime";
            this.nbSendPreKeeyTime.Size = new System.Drawing.Size(51, 21);
            this.nbSendPreKeeyTime.TabIndex = 10;
            this.nbSendPreKeeyTime.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "发送前RTS保持时间(ms)：";
            // 
            // cbContinueCollect
            // 
            this.cbContinueCollect.AutoSize = true;
            this.cbContinueCollect.Location = new System.Drawing.Point(11, 185);
            this.cbContinueCollect.Name = "cbContinueCollect";
            this.cbContinueCollect.Size = new System.Drawing.Size(96, 16);
            this.cbContinueCollect.TabIndex = 12;
            this.cbContinueCollect.Text = "连续采集失败";
            this.cbContinueCollect.UseVisualStyleBackColor = true;
            // 
            // nbCollectNum
            // 
            this.nbCollectNum.Location = new System.Drawing.Point(106, 183);
            this.nbCollectNum.Name = "nbCollectNum";
            this.nbCollectNum.Size = new System.Drawing.Size(37, 21);
            this.nbCollectNum.TabIndex = 13;
            this.nbCollectNum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "失败后重新初始化串口";
            // 
            // nbPackSize
            // 
            this.nbPackSize.Location = new System.Drawing.Point(92, 240);
            this.nbPackSize.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nbPackSize.Name = "nbPackSize";
            this.nbPackSize.Size = new System.Drawing.Size(42, 21);
            this.nbPackSize.TabIndex = 16;
            this.nbPackSize.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "包最大长度：";
            // 
            // cbSixCmd
            // 
            this.cbSixCmd.AutoSize = true;
            this.cbSixCmd.Location = new System.Drawing.Point(251, 212);
            this.cbSixCmd.Name = "cbSixCmd";
            this.cbSixCmd.Size = new System.Drawing.Size(90, 16);
            this.cbSixCmd.TabIndex = 17;
            this.cbSixCmd.Text = "支持6号命令";
            this.cbSixCmd.UseVisualStyleBackColor = true;
            // 
            // cbSixteenCmd
            // 
            this.cbSixteenCmd.AutoSize = true;
            this.cbSixteenCmd.Location = new System.Drawing.Point(365, 212);
            this.cbSixteenCmd.Name = "cbSixteenCmd";
            this.cbSixteenCmd.Size = new System.Drawing.Size(96, 16);
            this.cbSixteenCmd.TabIndex = 18;
            this.cbSixteenCmd.Text = "支持16号命令";
            this.cbSixteenCmd.UseVisualStyleBackColor = true;
            // 
            // nbPackOffset
            // 
            this.nbPackOffset.Location = new System.Drawing.Point(207, 240);
            this.nbPackOffset.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nbPackOffset.Name = "nbPackOffset";
            this.nbPackOffset.Size = new System.Drawing.Size(42, 21);
            this.nbPackOffset.TabIndex = 20;
            this.nbPackOffset.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(143, 244);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "偏移间隔：";
            // 
            // cbDataBits
            // 
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cbDataBits.Location = new System.Drawing.Point(74, 114);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(160, 20);
            this.cbDataBits.TabIndex = 21;
            this.cbDataBits.Text = "8";
            // 
            // cbStopbits
            // 
            this.cbStopbits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStopbits.FormattingEnabled = true;
            this.cbStopbits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cbStopbits.Location = new System.Drawing.Point(72, 145);
            this.cbStopbits.Name = "cbStopbits";
            this.cbStopbits.Size = new System.Drawing.Size(160, 20);
            this.cbStopbits.TabIndex = 22;
            // 
            // nbCollectInternal
            // 
            this.nbCollectInternal.Location = new System.Drawing.Point(189, 184);
            this.nbCollectInternal.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nbCollectInternal.Name = "nbCollectInternal";
            this.nbCollectInternal.Size = new System.Drawing.Size(51, 21);
            this.nbCollectInternal.TabIndex = 23;
            this.nbCollectInternal.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(145, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 24;
            this.label11.Text = "次间隔";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nbWriteTimeout);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.nbReadTimeout);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(250, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 84);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // nbWriteTimeout
            // 
            this.nbWriteTimeout.Location = new System.Drawing.Point(124, 48);
            this.nbWriteTimeout.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nbWriteTimeout.Name = "nbWriteTimeout";
            this.nbWriteTimeout.Size = new System.Drawing.Size(79, 21);
            this.nbWriteTimeout.TabIndex = 12;
            this.nbWriteTimeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 12);
            this.label12.TabIndex = 11;
            this.label12.Text = "写超时时间(ms)：";
            // 
            // nbReadTimeout
            // 
            this.nbReadTimeout.Location = new System.Drawing.Point(124, 21);
            this.nbReadTimeout.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nbReadTimeout.Name = "nbReadTimeout";
            this.nbReadTimeout.Size = new System.Drawing.Size(79, 21);
            this.nbReadTimeout.TabIndex = 10;
            this.nbReadTimeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 12);
            this.label13.TabIndex = 9;
            this.label13.Text = "读超时时间(ms)：";
            // 
            // cbModbusType
            // 
            this.cbModbusType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModbusType.FormattingEnabled = true;
            this.cbModbusType.Items.AddRange(new object[] {
            "RTU",
            "ASCII"});
            this.cbModbusType.Location = new System.Drawing.Point(340, 236);
            this.cbModbusType.Name = "cbModbusType";
            this.cbModbusType.Size = new System.Drawing.Size(121, 20);
            this.cbModbusType.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(262, 239);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 12);
            this.label14.TabIndex = 27;
            this.label14.Text = "MODBUS 类型：";
            // 
            // comboSmSeriePort
            // 
            this.comboSmSeriePort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSmSeriePort.FormattingEnabled = true;
            this.comboSmSeriePort.Location = new System.Drawing.Point(92, 267);
            this.comboSmSeriePort.Name = "comboSmSeriePort";
            this.comboSmSeriePort.Size = new System.Drawing.Size(136, 20);
            this.comboSmSeriePort.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 270);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 29;
            this.label15.Text = "模拟器串口：";
            // 
            // Modbus_Serial_Ctrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboSmSeriePort);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cbModbusType);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nbCollectInternal);
            this.Controls.Add(this.cbStopbits);
            this.Controls.Add(this.cbDataBits);
            this.Controls.Add(this.nbPackOffset);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbSixteenCmd);
            this.Controls.Add(this.cbSixCmd);
            this.Controls.Add(this.nbPackSize);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nbCollectNum);
            this.Controls.Add(this.cbContinueCollect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCheck);
            this.Controls.Add(this.cbBaudRate);
            this.Controls.Add(this.comboSeriePort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Modbus_Serial_Ctrl";
            this.Size = new System.Drawing.Size(493, 362);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbSendAfterKeeyTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbSendPreKeeyTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbCollectNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbPackSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbPackOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbCollectInternal)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbWriteTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbReadTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboSeriePort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCheck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nbSendPreKeeyTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nbSendAfterKeeyTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbContinueCollect;
        private System.Windows.Forms.NumericUpDown nbCollectNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nbPackSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbSixCmd;
        private System.Windows.Forms.CheckBox cbSixteenCmd;
        private System.Windows.Forms.NumericUpDown nbPackOffset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.ComboBox cbStopbits;
        private System.Windows.Forms.CheckBox cbRTSEnable;
        private System.Windows.Forms.NumericUpDown nbCollectInternal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nbWriteTimeout;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nbReadTimeout;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbModbusType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboSmSeriePort;
        private System.Windows.Forms.Label label15;
    }
}
