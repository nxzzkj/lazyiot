namespace MQTTnet
{
    partial class GasIODeviceCtrl
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
            this.tb_devID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tb_MqttID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tb_subTopic = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tb_cmdSubTopic = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tbTimes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbRecieveType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tb_devID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 30);
            this.panel1.TabIndex = 1;
            // 
            // tb_devID
            // 
            this.tb_devID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_devID.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_devID.Location = new System.Drawing.Point(104, 0);
            this.tb_devID.Name = "tb_devID";
            this.tb_devID.ReadOnly = true;
            this.tb_devID.Size = new System.Drawing.Size(270, 26);
            this.tb_devID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备ID编码:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tb_MqttID);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 30);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(374, 30);
            this.panel5.TabIndex = 5;
            // 
            // tb_MqttID
            // 
            this.tb_MqttID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_MqttID.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_MqttID.Location = new System.Drawing.Point(104, 0);
            this.tb_MqttID.Name = "tb_MqttID";
            this.tb_MqttID.Size = new System.Drawing.Size(270, 26);
            this.tb_MqttID.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "MQTT连接ID:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tb_subTopic);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 60);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(374, 30);
            this.panel6.TabIndex = 6;
            // 
            // tb_subTopic
            // 
            this.tb_subTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_subTopic.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_subTopic.Location = new System.Drawing.Point(104, 0);
            this.tb_subTopic.Name = "tb_subTopic";
            this.tb_subTopic.Size = new System.Drawing.Size(270, 26);
            this.tb_subTopic.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 30);
            this.label6.TabIndex = 0;
            this.label6.Text = "数据订阅主题:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tb_cmdSubTopic);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 90);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(374, 30);
            this.panel7.TabIndex = 7;
            // 
            // tb_cmdSubTopic
            // 
            this.tb_cmdSubTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_cmdSubTopic.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_cmdSubTopic.Location = new System.Drawing.Point(104, 0);
            this.tb_cmdSubTopic.Name = "tb_cmdSubTopic";
            this.tb_cmdSubTopic.Size = new System.Drawing.Size(270, 26);
            this.tb_cmdSubTopic.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 30);
            this.label7.TabIndex = 0;
            this.label7.Text = "下置命令主题:";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.tbTimes);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 120);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(374, 30);
            this.panel8.TabIndex = 8;
            // 
            // tbTimes
            // 
            this.tbTimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTimes.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbTimes.Location = new System.Drawing.Point(104, 0);
            this.tbTimes.Name = "tbTimes";
            this.tbTimes.Size = new System.Drawing.Size(270, 26);
            this.tbTimes.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 30);
            this.label8.TabIndex = 0;
            this.label8.Text = "循环周期主题:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbRecieveType);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 150);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(374, 30);
            this.panel3.TabIndex = 10;
            // 
            // tbRecieveType
            // 
            this.tbRecieveType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRecieveType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRecieveType.Location = new System.Drawing.Point(104, 0);
            this.tbRecieveType.Name = "tbRecieveType";
            this.tbRecieveType.Size = new System.Drawing.Size(270, 26);
            this.tbRecieveType.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "主动请求主题:";
            // 
            // GasIODeviceCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Name = "GasIODeviceCtrl";
            this.Size = new System.Drawing.Size(374, 262);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_devID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tb_MqttID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox tb_subTopic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox tb_cmdSubTopic;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox tbTimes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRecieveType;
    }
}
