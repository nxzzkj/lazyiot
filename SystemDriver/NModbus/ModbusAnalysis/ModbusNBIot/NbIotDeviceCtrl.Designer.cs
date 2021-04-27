namespace Modbus.ModbusAnalysis
{
    partial class NbIotDeviceCtrl
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
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBoxRetiry = new System.Windows.Forms.GroupBox();
            this.nbRetiresInternal = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.cbRetries = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ndRetiresNum = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ndWriteBufferSize = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.ndReadBuffSize = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nbWriteTimeout = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.nbReadTimeout = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbModbusType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbIdentification = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxFixUnit = new System.Windows.Forms.GroupBox();
            this.nudStartUnit = new System.Windows.Forms.NumericUpDown();
            this.nudUnitNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFixUnit = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel8.SuspendLayout();
            this.groupBoxRetiry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbRetiresInternal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndRetiresNum)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndWriteBufferSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndReadBuffSize)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbWriteTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbReadTimeout)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxFixUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitNum)).BeginInit();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.txtAddress);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 30);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(380, 30);
            this.panel8.TabIndex = 10;
            // 
            // txtAddress
            // 
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtAddress.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddress.Location = new System.Drawing.Point(90, 0);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(258, 26);
            this.txtAddress.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 28);
            this.label8.TabIndex = 0;
            this.label8.Text = "设备地址:";
            // 
            // groupBoxRetiry
            // 
            this.groupBoxRetiry.Controls.Add(this.nbRetiresInternal);
            this.groupBoxRetiry.Controls.Add(this.label14);
            this.groupBoxRetiry.Controls.Add(this.cbRetries);
            this.groupBoxRetiry.Controls.Add(this.label15);
            this.groupBoxRetiry.Controls.Add(this.ndRetiresNum);
            this.groupBoxRetiry.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxRetiry.Enabled = false;
            this.groupBoxRetiry.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxRetiry.Location = new System.Drawing.Point(0, 198);
            this.groupBoxRetiry.Name = "groupBoxRetiry";
            this.groupBoxRetiry.Size = new System.Drawing.Size(380, 59);
            this.groupBoxRetiry.TabIndex = 40;
            this.groupBoxRetiry.TabStop = false;
            this.groupBoxRetiry.Text = "失败重试";
            // 
            // nbRetiresInternal
            // 
            this.nbRetiresInternal.Location = new System.Drawing.Point(258, 23);
            this.nbRetiresInternal.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nbRetiresInternal.Name = "nbRetiresInternal";
            this.nbRetiresInternal.Size = new System.Drawing.Size(91, 26);
            this.nbRetiresInternal.TabIndex = 27;
            this.nbRetiresInternal.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 20);
            this.label14.TabIndex = 29;
            this.label14.Text = "重试次数：";
            // 
            // cbRetries
            // 
            this.cbRetries.AutoSize = true;
            this.cbRetries.Location = new System.Drawing.Point(73, 4);
            this.cbRetries.Name = "cbRetries";
            this.cbRetries.Size = new System.Drawing.Size(15, 14);
            this.cbRetries.TabIndex = 15;
            this.cbRetries.UseVisualStyleBackColor = true;
            this.cbRetries.CheckedChanged += new System.EventHandler(this.cbRetries_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(159, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 20);
            this.label15.TabIndex = 28;
            this.label15.Text = "重试间隔(ms)：";
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
            this.ndRetiresNum.Size = new System.Drawing.Size(51, 26);
            this.ndRetiresNum.TabIndex = 16;
            this.ndRetiresNum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ndWriteBufferSize);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.ndReadBuffSize);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(0, 138);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(380, 60);
            this.groupBox5.TabIndex = 41;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "缓存配置";
            // 
            // ndWriteBufferSize
            // 
            this.ndWriteBufferSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.ndWriteBufferSize.Location = new System.Drawing.Point(212, 22);
            this.ndWriteBufferSize.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.ndWriteBufferSize.Name = "ndWriteBufferSize";
            this.ndWriteBufferSize.Size = new System.Drawing.Size(79, 26);
            this.ndWriteBufferSize.TabIndex = 12;
            this.ndWriteBufferSize.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(147, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "写缓存：";
            // 
            // ndReadBuffSize
            // 
            this.ndReadBuffSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.ndReadBuffSize.Location = new System.Drawing.Point(68, 22);
            this.ndReadBuffSize.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.ndReadBuffSize.Name = "ndReadBuffSize";
            this.ndReadBuffSize.Size = new System.Drawing.Size(79, 26);
            this.ndReadBuffSize.TabIndex = 10;
            this.ndReadBuffSize.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(3, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "读缓存：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nbWriteTimeout);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.nbReadTimeout);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 48);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "读写超时";
            // 
            // nbWriteTimeout
            // 
            this.nbWriteTimeout.Dock = System.Windows.Forms.DockStyle.Left;
            this.nbWriteTimeout.Location = new System.Drawing.Point(270, 22);
            this.nbWriteTimeout.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nbWriteTimeout.Name = "nbWriteTimeout";
            this.nbWriteTimeout.Size = new System.Drawing.Size(79, 26);
            this.nbWriteTimeout.TabIndex = 12;
            this.nbWriteTimeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Location = new System.Drawing.Point(176, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 20);
            this.label16.TabIndex = 11;
            this.label16.Text = "写超时(ms)：";
            // 
            // nbReadTimeout
            // 
            this.nbReadTimeout.Dock = System.Windows.Forms.DockStyle.Left;
            this.nbReadTimeout.Location = new System.Drawing.Point(97, 22);
            this.nbReadTimeout.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nbReadTimeout.Name = "nbReadTimeout";
            this.nbReadTimeout.Size = new System.Drawing.Size(79, 26);
            this.nbReadTimeout.TabIndex = 10;
            this.nbReadTimeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Left;
            this.label17.Location = new System.Drawing.Point(3, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 20);
            this.label17.TabIndex = 9;
            this.label17.Text = "读超时(ms)：";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.cbModbusType);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(380, 30);
            this.panel4.TabIndex = 42;
            this.panel4.Visible = false;
            // 
            // cbModbusType
            // 
            this.cbModbusType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModbusType.FormattingEnabled = true;
            this.cbModbusType.Items.AddRange(new object[] {
            "RTU",
            "ASCII",
            "TCP"});
            this.cbModbusType.Location = new System.Drawing.Point(90, 5);
            this.cbModbusType.Name = "cbModbusType";
            this.cbModbusType.Size = new System.Drawing.Size(258, 20);
            this.cbModbusType.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 28);
            this.label11.TabIndex = 0;
            this.label11.Text = "Modbus类型:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbIdentification);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 30);
            this.panel1.TabIndex = 43;
            // 
            // tbIdentification
            // 
            this.tbIdentification.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbIdentification.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbIdentification.Location = new System.Drawing.Point(90, 0);
            this.tbIdentification.Name = "tbIdentification";
            this.tbIdentification.Size = new System.Drawing.Size(258, 26);
            this.tbIdentification.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "注册标识:";
            // 
            // groupBoxFixUnit
            // 
            this.groupBoxFixUnit.Controls.Add(this.nudStartUnit);
            this.groupBoxFixUnit.Controls.Add(this.nudUnitNum);
            this.groupBoxFixUnit.Controls.Add(this.label2);
            this.groupBoxFixUnit.Controls.Add(this.cbFixUnit);
            this.groupBoxFixUnit.Controls.Add(this.label3);
            this.groupBoxFixUnit.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxFixUnit.Enabled = false;
            this.groupBoxFixUnit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxFixUnit.Location = new System.Drawing.Point(0, 257);
            this.groupBoxFixUnit.Name = "groupBoxFixUnit";
            this.groupBoxFixUnit.Size = new System.Drawing.Size(380, 75);
            this.groupBoxFixUnit.TabIndex = 44;
            this.groupBoxFixUnit.TabStop = false;
            this.groupBoxFixUnit.Text = "固定地址范围";
            // 
            // nudStartUnit
            // 
            this.nudStartUnit.Location = new System.Drawing.Point(81, 32);
            this.nudStartUnit.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudStartUnit.Name = "nudStartUnit";
            this.nudStartUnit.Size = new System.Drawing.Size(123, 26);
            this.nudStartUnit.TabIndex = 16;
            this.nudStartUnit.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nudUnitNum
            // 
            this.nudUnitNum.Location = new System.Drawing.Point(296, 31);
            this.nudUnitNum.Maximum = new decimal(new int[] {
            123,
            0,
            0,
            0});
            this.nudUnitNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudUnitNum.Name = "nudUnitNum";
            this.nudUnitNum.Size = new System.Drawing.Size(60, 26);
            this.nudUnitNum.TabIndex = 27;
            this.nudUnitNum.Value = new decimal(new int[] {
            123,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "起始地址：";
            // 
            // cbFixUnit
            // 
            this.cbFixUnit.AutoSize = true;
            this.cbFixUnit.Location = new System.Drawing.Point(100, -1);
            this.cbFixUnit.Name = "cbFixUnit";
            this.cbFixUnit.Size = new System.Drawing.Size(126, 24);
            this.cbFixUnit.TabIndex = 15;
            this.cbFixUnit.Text = "指定寄存器范围";
            this.cbFixUnit.UseVisualStyleBackColor = true;
            this.cbFixUnit.CheckedChanged += new System.EventHandler(this.cbFixUnit_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "寄存器数量：";
            // 
            // NbIotDeviceCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxFixUnit);
            this.Controls.Add(this.groupBoxRetiry);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel1);
            this.Name = "NbIotDeviceCtrl";
            this.Size = new System.Drawing.Size(380, 346);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.groupBoxRetiry.ResumeLayout(false);
            this.groupBoxRetiry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbRetiresInternal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndRetiresNum)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndWriteBufferSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndReadBuffSize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbWriteTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbReadTimeout)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxFixUnit.ResumeLayout(false);
            this.groupBoxFixUnit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBoxRetiry;
        private System.Windows.Forms.NumericUpDown nbRetiresInternal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cbRetries;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown ndRetiresNum;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown ndWriteBufferSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown ndReadBuffSize;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nbWriteTimeout;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nbReadTimeout;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbModbusType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbIdentification;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxFixUnit;
        private System.Windows.Forms.NumericUpDown nudUnitNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbFixUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudStartUnit;
    }
}
