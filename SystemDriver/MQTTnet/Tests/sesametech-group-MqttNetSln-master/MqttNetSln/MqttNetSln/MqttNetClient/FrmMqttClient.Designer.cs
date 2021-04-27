namespace MqttNetClient
{
    partial class FrmMqttClient
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnMultiDisConnect = new System.Windows.Forms.Button();
            this.BtnMultiConnect = new System.Windows.Forms.Button();
            this.TxbConnectCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnDisConnect = new System.Windows.Forms.Button();
            this.TxbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxbServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbSubMqttQuality = new System.Windows.Forms.ComboBox();
            this.txbSubscribe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnSubscribe = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbPubMqttQuality = new System.Windows.Forms.ComboBox();
            this.TxbTopic = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TxbPayload = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnSend = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnMultiDisConnect);
            this.panel2.Controls.Add(this.BtnMultiConnect);
            this.panel2.Controls.Add(this.TxbConnectCount);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.BtnDisConnect);
            this.panel2.Controls.Add(this.TxbPort);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.TxbServer);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BtnConnect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 34);
            this.panel2.TabIndex = 0;
            // 
            // BtnMultiDisConnect
            // 
            this.BtnMultiDisConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMultiDisConnect.Location = new System.Drawing.Point(717, 4);
            this.BtnMultiDisConnect.Name = "BtnMultiDisConnect";
            this.BtnMultiDisConnect.Size = new System.Drawing.Size(74, 26);
            this.BtnMultiDisConnect.TabIndex = 26;
            this.BtnMultiDisConnect.Text = "DisConnect";
            this.BtnMultiDisConnect.UseVisualStyleBackColor = true;
            this.BtnMultiDisConnect.Click += new System.EventHandler(this.BtnMultiDisConnect_Click);
            // 
            // BtnMultiConnect
            // 
            this.BtnMultiConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMultiConnect.Location = new System.Drawing.Point(628, 4);
            this.BtnMultiConnect.Name = "BtnMultiConnect";
            this.BtnMultiConnect.Size = new System.Drawing.Size(74, 26);
            this.BtnMultiConnect.TabIndex = 25;
            this.BtnMultiConnect.Text = "Connect";
            this.BtnMultiConnect.UseVisualStyleBackColor = true;
            this.BtnMultiConnect.Click += new System.EventHandler(this.BtnMultiConnect_Click);
            // 
            // TxbConnectCount
            // 
            this.TxbConnectCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxbConnectCount.Location = new System.Drawing.Point(522, 5);
            this.TxbConnectCount.Name = "TxbConnectCount";
            this.TxbConnectCount.Size = new System.Drawing.Size(100, 21);
            this.TxbConnectCount.TabIndex = 24;
            this.TxbConnectCount.Text = "10";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(463, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "连接数量";
            // 
            // BtnDisConnect
            // 
            this.BtnDisConnect.Location = new System.Drawing.Point(333, 4);
            this.BtnDisConnect.Name = "BtnDisConnect";
            this.BtnDisConnect.Size = new System.Drawing.Size(75, 28);
            this.BtnDisConnect.TabIndex = 5;
            this.BtnDisConnect.Text = "DisConnect";
            this.BtnDisConnect.UseVisualStyleBackColor = true;
            this.BtnDisConnect.Click += new System.EventHandler(this.BtnDisConnect_Click);
            // 
            // TxbPort
            // 
            this.TxbPort.Location = new System.Drawing.Point(191, 9);
            this.TxbPort.Name = "TxbPort";
            this.TxbPort.Size = new System.Drawing.Size(44, 21);
            this.TxbPort.TabIndex = 4;
            this.TxbPort.Text = "1883";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // TxbServer
            // 
            this.TxbServer.Location = new System.Drawing.Point(50, 9);
            this.TxbServer.Name = "TxbServer";
            this.TxbServer.Size = new System.Drawing.Size(100, 21);
            this.TxbServer.TabIndex = 2;
            this.TxbServer.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server";
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(252, 3);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(75, 28);
            this.BtnConnect.TabIndex = 0;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(3, 83);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(794, 284);
            this.listBox1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.CmbSubMqttQuality);
            this.panel3.Controls.Add(this.txbSubscribe);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.BtnSubscribe);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(794, 34);
            this.panel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "MqttQualityOfServiceLevel";
            // 
            // CmbSubMqttQuality
            // 
            this.CmbSubMqttQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSubMqttQuality.FormattingEnabled = true;
            this.CmbSubMqttQuality.Location = new System.Drawing.Point(628, 8);
            this.CmbSubMqttQuality.Name = "CmbSubMqttQuality";
            this.CmbSubMqttQuality.Size = new System.Drawing.Size(83, 20);
            this.CmbSubMqttQuality.TabIndex = 21;
            // 
            // txbSubscribe
            // 
            this.txbSubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSubscribe.Location = new System.Drawing.Point(42, 8);
            this.txbSubscribe.Name = "txbSubscribe";
            this.txbSubscribe.Size = new System.Drawing.Size(419, 21);
            this.txbSubscribe.TabIndex = 20;
            this.txbSubscribe.Text = "biobase/bsc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "TOPIC";
            // 
            // BtnSubscribe
            // 
            this.BtnSubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSubscribe.Location = new System.Drawing.Point(717, 4);
            this.BtnSubscribe.Name = "BtnSubscribe";
            this.BtnSubscribe.Size = new System.Drawing.Size(74, 26);
            this.BtnSubscribe.TabIndex = 18;
            this.BtnSubscribe.Text = "Subscribe";
            this.BtnSubscribe.UseVisualStyleBackColor = true;
            this.BtnSubscribe.Click += new System.EventHandler(this.BtnSubscribe_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.CmbPubMqttQuality);
            this.panel4.Controls.Add(this.TxbTopic);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 373);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(794, 34);
            this.panel4.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(547, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "MqttQualityOfServiceLevel";
            // 
            // CmbPubMqttQuality
            // 
            this.CmbPubMqttQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbPubMqttQuality.FormattingEnabled = true;
            this.CmbPubMqttQuality.Location = new System.Drawing.Point(708, 9);
            this.CmbPubMqttQuality.Name = "CmbPubMqttQuality";
            this.CmbPubMqttQuality.Size = new System.Drawing.Size(83, 20);
            this.CmbPubMqttQuality.TabIndex = 23;
            // 
            // TxbTopic
            // 
            this.TxbTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxbTopic.Location = new System.Drawing.Point(42, 8);
            this.TxbTopic.Name = "TxbTopic";
            this.TxbTopic.Size = new System.Drawing.Size(499, 21);
            this.TxbTopic.TabIndex = 17;
            this.TxbTopic.Text = "biobase/bsc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "TOPIC";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.TxbPayload);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.BtnSend);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 413);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(794, 34);
            this.panel5.TabIndex = 4;
            // 
            // TxbPayload
            // 
            this.TxbPayload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxbPayload.Location = new System.Drawing.Point(56, 7);
            this.TxbPayload.Name = "TxbPayload";
            this.TxbPayload.Size = new System.Drawing.Size(646, 21);
            this.TxbPayload.TabIndex = 22;
            this.TxbPayload.Text = "1883";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "Message";
            // 
            // BtnSend
            // 
            this.BtnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSend.Location = new System.Drawing.Point(717, 4);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(74, 26);
            this.BtnSend.TabIndex = 20;
            this.BtnSend.Text = "Send";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // FrmMqttClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMqttClient";
            this.Text = "Mqtt Client";
            this.Load += new System.EventHandler(this.FrmMqttClient_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnDisConnect;
        private System.Windows.Forms.TextBox TxbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxbServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BtnMultiDisConnect;
        private System.Windows.Forms.Button BtnMultiConnect;
        private System.Windows.Forms.TextBox TxbConnectCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txbSubscribe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnSubscribe;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox TxbTopic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox TxbPayload;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbSubMqttQuality;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CmbPubMqttQuality;
    }
}

