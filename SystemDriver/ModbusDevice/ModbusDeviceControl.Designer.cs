namespace ModbusDevice
{
    partial class ModbusDeviceControl
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
            this.cbo_modbusType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbStored = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbo_modbusType
            // 
            this.cbo_modbusType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_modbusType.FormattingEnabled = true;
            this.cbo_modbusType.Items.AddRange(new object[] {
            "ASCII",
            "RTU",
            "Serial"});
            this.cbo_modbusType.Location = new System.Drawing.Point(88, 35);
            this.cbo_modbusType.Name = "cbo_modbusType";
            this.cbo_modbusType.Size = new System.Drawing.Size(248, 20);
            this.cbo_modbusType.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(25, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(358, 27);
            this.label6.TabIndex = 17;
            this.label6.Text = "通过DTU接收的数据一般是透明传输，modbus类型是前端接收数据时候的类型";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo_modbusType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbStored);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 106);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modbus配置";
            // 
            // cbStored
            // 
            this.cbStored.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStored.FormattingEnabled = true;
            this.cbStored.Items.AddRange(new object[] {
            "高位字节在前",
            "低位字节在前"});
            this.cbStored.Location = new System.Drawing.Point(87, 61);
            this.cbStored.Name = "cbStored";
            this.cbStored.Size = new System.Drawing.Size(248, 20);
            this.cbStored.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "字节存储：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "Modbus类型：";
            // 
            // ModbusDeviceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Name = "ModbusDeviceControl";
            this.Size = new System.Drawing.Size(386, 145);
            this.Load += new System.EventHandler(this.ModbusDeviceControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_modbusType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbStored;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
