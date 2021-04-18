namespace Modbus.ModbusService
{
    partial class Modbus_TCP_Ctrl
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
            this.ndSMPort = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSMDeviceIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ndRetiresNum = new System.Windows.Forms.NumericUpDown();
            this.cbRetries = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nbWriteTimeout = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.nbReadTimeout = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nbRetiresInternal = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ndLocalPort = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLocalIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ndWriteBufferSize = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.ndReadBuffSize = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ndSMPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndRetiresNum)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbWriteTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbReadTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbRetiresInternal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndLocalPort)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndWriteBufferSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndReadBuffSize)).BeginInit();
            this.SuspendLayout();
            // 
            // ndSMPort
            // 
            this.ndSMPort.Enabled = false;
            this.ndSMPort.Location = new System.Drawing.Point(76, 46);
            this.ndSMPort.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.ndSMPort.Name = "ndSMPort";
            this.ndSMPort.Size = new System.Drawing.Size(159, 21);
            this.ndSMPort.TabIndex = 10;
            this.ndSMPort.Value = new decimal(new int[] {
            5002,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(20, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "端口号：";
            // 
            // tbSMDeviceIP
            // 
            this.tbSMDeviceIP.Enabled = false;
            this.tbSMDeviceIP.Location = new System.Drawing.Point(76, 19);
            this.tbSMDeviceIP.Name = "tbSMDeviceIP";
            this.tbSMDeviceIP.Size = new System.Drawing.Size(159, 21);
            this.tbSMDeviceIP.TabIndex = 11;
            this.tbSMDeviceIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "设备IP：";
            // 
            // ndRetiresNum
            // 
            this.ndRetiresNum.Location = new System.Drawing.Point(94, 22);
            this.ndRetiresNum.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.ndRetiresNum.Name = "ndRetiresNum";
            this.ndRetiresNum.Size = new System.Drawing.Size(51, 21);
            this.ndRetiresNum.TabIndex = 16;
            this.ndRetiresNum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // cbRetries
            // 
            this.cbRetries.AutoSize = true;
            this.cbRetries.Location = new System.Drawing.Point(35, 0);
            this.cbRetries.Name = "cbRetries";
            this.cbRetries.Size = new System.Drawing.Size(15, 14);
            this.cbRetries.TabIndex = 15;
            this.cbRetries.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nbWriteTimeout);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.nbReadTimeout);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(253, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 75);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            // 
            // nbWriteTimeout
            // 
            this.nbWriteTimeout.Location = new System.Drawing.Point(124, 41);
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
            this.label12.Location = new System.Drawing.Point(16, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 12);
            this.label12.TabIndex = 11;
            this.label12.Text = "写入超时时间(ms)：";
            // 
            // nbReadTimeout
            // 
            this.nbReadTimeout.Location = new System.Drawing.Point(124, 14);
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
            this.label13.Location = new System.Drawing.Point(16, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 12);
            this.label13.TabIndex = 9;
            this.label13.Text = "读取超时时间(ms)：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 28;
            this.label11.Text = "重试间隔(ms)：";
            // 
            // nbRetiresInternal
            // 
            this.nbRetiresInternal.Location = new System.Drawing.Point(94, 49);
            this.nbRetiresInternal.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nbRetiresInternal.Name = "nbRetiresInternal";
            this.nbRetiresInternal.Size = new System.Drawing.Size(111, 21);
            this.nbRetiresInternal.TabIndex = 27;
            this.nbRetiresInternal.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nbRetiresInternal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbRetries);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.ndRetiresNum);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(3, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 75);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "重试    ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "重试次数：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ndSMPort);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tbSMDeviceIP);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(0, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(247, 68);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "模拟器";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ndLocalPort);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.tbLocalIP);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(247, 68);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "本地网络";
            // 
            // ndLocalPort
            // 
            this.ndLocalPort.Enabled = false;
            this.ndLocalPort.Location = new System.Drawing.Point(76, 44);
            this.ndLocalPort.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.ndLocalPort.Name = "ndLocalPort";
            this.ndLocalPort.Size = new System.Drawing.Size(159, 21);
            this.ndLocalPort.TabIndex = 10;
            this.ndLocalPort.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(20, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "端口号：";
            // 
            // tbLocalIP
            // 
            this.tbLocalIP.Enabled = false;
            this.tbLocalIP.Location = new System.Drawing.Point(76, 17);
            this.tbLocalIP.Name = "tbLocalIP";
            this.tbLocalIP.Size = new System.Drawing.Size(159, 21);
            this.tbLocalIP.TabIndex = 11;
            this.tbLocalIP.Text = "127.0.0.1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(20, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "设备IP：";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ndWriteBufferSize);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.ndReadBuffSize);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(256, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(206, 66);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "缓存配置";
            // 
            // ndWriteBufferSize
            // 
            this.ndWriteBufferSize.Location = new System.Drawing.Point(75, 39);
            this.ndWriteBufferSize.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.ndWriteBufferSize.Name = "ndWriteBufferSize";
            this.ndWriteBufferSize.Size = new System.Drawing.Size(79, 21);
            this.ndWriteBufferSize.TabIndex = 12;
            this.ndWriteBufferSize.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "写缓存：";
            // 
            // ndReadBuffSize
            // 
            this.ndReadBuffSize.Location = new System.Drawing.Point(75, 14);
            this.ndReadBuffSize.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.ndReadBuffSize.Name = "ndReadBuffSize";
            this.ndReadBuffSize.Size = new System.Drawing.Size(79, 21);
            this.ndReadBuffSize.TabIndex = 10;
            this.ndReadBuffSize.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "读缓存：";
            // 
            // Modbus_TCP_Ctrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Modbus_TCP_Ctrl";
            this.Size = new System.Drawing.Size(468, 256);
            ((System.ComponentModel.ISupportInitialize)(this.ndSMPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndRetiresNum)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbWriteTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbReadTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbRetiresInternal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndLocalPort)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndWriteBufferSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndReadBuffSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ndSMPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSMDeviceIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ndRetiresNum;
        private System.Windows.Forms.CheckBox cbRetries;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nbWriteTimeout;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nbReadTimeout;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nbRetiresInternal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown ndLocalPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLocalIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown ndWriteBufferSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ndReadBuffSize;
        private System.Windows.Forms.Label label7;
    }
}
