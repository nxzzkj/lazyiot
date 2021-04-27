namespace MqttNetServer
{
    partial class FrmMqttServer
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnStop = new System.Windows.Forms.Button();
            this.TxbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxbServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnStart = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbSubMqttQuality = new System.Windows.Forms.ComboBox();
            this.txbSubscribe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnSubscribe = new System.Windows.Forms.Button();
            this.BtnSend = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.BtnSend, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.BtnStop);
            this.panel2.Controls.Add(this.TxbPort);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.TxbServer);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BtnStart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 34);
            this.panel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(593, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Port";
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(333, 4);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(75, 28);
            this.BtnStop.TabIndex = 5;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
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
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(252, 3);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 28);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(3, 53);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(794, 328);
            this.listBox1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.CmbSubMqttQuality);
            this.panel3.Controls.Add(this.txbSubscribe);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.BtnSubscribe);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 387);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(794, 31);
            this.panel3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(467, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "MqttQualityOfServiceLevel";
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
            // BtnSend
            // 
            this.BtnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSend.Location = new System.Drawing.Point(723, 424);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(74, 23);
            this.BtnSend.TabIndex = 21;
            this.BtnSend.Text = "Send";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // FrmMqttServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMqttServer";
            this.Text = "MqttServer";
            this.Load += new System.EventHandler(this.FrmMqttServer_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TxbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxbServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbSubMqttQuality;
        private System.Windows.Forms.TextBox txbSubscribe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnSubscribe;
        private System.Windows.Forms.Button BtnSend;
    }
}

