namespace MQTTnet
{
    partial class MQTTServerCtrl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbEnableUser = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tbHeart = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbWill = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbMessage = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbDataType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbClientIDEnable = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cbCode = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cbReceiveMethod = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nudPort);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtIp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 30);
            this.panel1.TabIndex = 0;
            // 
            // nudPort
            // 
            this.nudPort.Dock = System.Windows.Forms.DockStyle.Left;
            this.nudPort.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudPort.Location = new System.Drawing.Point(306, 0);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(103, 26);
            this.nudPort.TabIndex = 3;
            this.nudPort.Value = new decimal(new int[] {
            1883,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(245, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口号:";
            // 
            // txtIp
            // 
            this.txtIp.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtIp.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIp.Location = new System.Drawing.Point(85, 0);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(160, 26);
            this.txtIp.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器IP:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbPwd);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbUser);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 30);
            this.panel2.TabIndex = 1;
            // 
            // tbPwd
            // 
            this.tbPwd.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbPwd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPwd.Location = new System.Drawing.Point(306, 0);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.Size = new System.Drawing.Size(160, 26);
            this.tbPwd.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(245, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "密   码:";
            // 
            // tbUser
            // 
            this.tbUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbUser.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbUser.Location = new System.Drawing.Point(85, 0);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(160, 26);
            this.tbUser.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "用 户 名:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbEnableUser);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(484, 30);
            this.panel3.TabIndex = 2;
            // 
            // cbEnableUser
            // 
            this.cbEnableUser.AutoSize = true;
            this.cbEnableUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbEnableUser.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbEnableUser.Location = new System.Drawing.Point(85, 0);
            this.cbEnableUser.Name = "cbEnableUser";
            this.cbEnableUser.Size = new System.Drawing.Size(112, 30);
            this.cbEnableUser.TabIndex = 1;
            this.cbEnableUser.Text = "启用用户验证";
            this.cbEnableUser.UseVisualStyleBackColor = true;
            this.cbEnableUser.CheckedChanged += new System.EventHandler(this.cbEnableUser_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 30);
            this.label6.TabIndex = 0;
            this.label6.Text = "            ";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.tbHeart);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 90);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(484, 30);
            this.panel4.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(245, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 30);
            this.label5.TabIndex = 2;
            this.label5.Text = "(m)";
            // 
            // tbHeart
            // 
            this.tbHeart.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbHeart.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbHeart.Location = new System.Drawing.Point(85, 0);
            this.tbHeart.Name = "tbHeart";
            this.tbHeart.Size = new System.Drawing.Size(160, 26);
            this.tbHeart.TabIndex = 1;
            this.tbHeart.Text = "60";
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 30);
            this.label7.TabIndex = 0;
            this.label7.Text = "心跳时间:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cbWill);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.cbMessage);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 120);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(484, 30);
            this.panel5.TabIndex = 4;
            // 
            // cbWill
            // 
            this.cbWill.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbWill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWill.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbWill.FormattingEnabled = true;
            this.cbWill.Items.AddRange(new object[] {
            "Will Flag",
            "Will QoS",
            "Will Retain Flag"});
            this.cbWill.Location = new System.Drawing.Point(330, 0);
            this.cbWill.Name = "cbWill";
            this.cbWill.Size = new System.Drawing.Size(136, 28);
            this.cbWill.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(245, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 30);
            this.label8.TabIndex = 2;
            this.label8.Text = "遗愿标志:";
            // 
            // cbMessage
            // 
            this.cbMessage.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbMessage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMessage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbMessage.FormattingEnabled = true;
            this.cbMessage.Items.AddRange(new object[] {
            "QoS 0 最多分发一次",
            "QoS 1 至少分发一次",
            "QoS 2 只分发一次"});
            this.cbMessage.Location = new System.Drawing.Point(85, 0);
            this.cbMessage.Name = "cbMessage";
            this.cbMessage.Size = new System.Drawing.Size(160, 28);
            this.cbMessage.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 30);
            this.label9.TabIndex = 0;
            this.label9.Text = "消息质量:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cbDataType);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 150);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(484, 30);
            this.panel6.TabIndex = 5;
            // 
            // cbDataType
            // 
            this.cbDataType.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDataType.FormattingEnabled = true;
            this.cbDataType.Items.AddRange(new object[] {
            "江苏协昌环保股份有限公司",
            "通用MQTT解析"});
            this.cbDataType.Location = new System.Drawing.Point(85, 0);
            this.cbDataType.Name = "cbDataType";
            this.cbDataType.Size = new System.Drawing.Size(381, 28);
            this.cbDataType.TabIndex = 2;
            this.cbDataType.SelectedIndexChanged += new System.EventHandler(this.cbDataType_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 30);
            this.label11.TabIndex = 0;
            this.label11.Text = "数据格式:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cbClientIDEnable);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 180);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(484, 30);
            this.panel7.TabIndex = 6;
            // 
            // cbClientIDEnable
            // 
            this.cbClientIDEnable.AutoSize = true;
            this.cbClientIDEnable.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbClientIDEnable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbClientIDEnable.Location = new System.Drawing.Point(85, 0);
            this.cbClientIDEnable.Name = "cbClientIDEnable";
            this.cbClientIDEnable.Size = new System.Drawing.Size(159, 30);
            this.cbClientIDEnable.TabIndex = 1;
            this.cbClientIDEnable.Text = "开启Mqtt客户端识别";
            this.cbClientIDEnable.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 30);
            this.label10.TabIndex = 0;
            this.label10.Text = "            ";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.cbCode);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 210);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(484, 30);
            this.panel8.TabIndex = 7;
            // 
            // cbCode
            // 
            this.cbCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCode.FormattingEnabled = true;
            this.cbCode.Items.AddRange(new object[] {
            "UTF8"});
            this.cbCode.Location = new System.Drawing.Point(85, 0);
            this.cbCode.Name = "cbCode";
            this.cbCode.Size = new System.Drawing.Size(381, 28);
            this.cbCode.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 30);
            this.label12.TabIndex = 0;
            this.label12.Text = "数据编码:   ";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.cbReceiveMethod);
            this.panel9.Controls.Add(this.label13);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 240);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(484, 30);
            this.panel9.TabIndex = 8;
            // 
            // cbReceiveMethod
            // 
            this.cbReceiveMethod.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbReceiveMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReceiveMethod.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbReceiveMethod.FormattingEnabled = true;
            this.cbReceiveMethod.Items.AddRange(new object[] {
            "主动",
            "被动"});
            this.cbReceiveMethod.Location = new System.Drawing.Point(85, 0);
            this.cbReceiveMethod.Name = "cbReceiveMethod";
            this.cbReceiveMethod.Size = new System.Drawing.Size(381, 28);
            this.cbReceiveMethod.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 30);
            this.label13.TabIndex = 0;
            this.label13.Text = "接收方式:   ";
            // 
            // MQTTServerCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MQTTServerCtrl";
            this.Size = new System.Drawing.Size(484, 336);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbEnableUser;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbHeart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbMessage;
        private System.Windows.Forms.ComboBox cbWill;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbDataType;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox cbClientIDEnable;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbCode;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ComboBox cbReceiveMethod;
        private System.Windows.Forms.Label label13;
    }
}
