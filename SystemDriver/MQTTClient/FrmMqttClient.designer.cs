﻿namespace MqttNetClient
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
            this.BtnDisConnect = new System.Windows.Forms.Button();
            this.TxbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxbServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tbClientID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDeviceID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbClientNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1154, 578);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1154, 578);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbClientNum);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.tbDeviceID);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbClientID);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.BtnDisConnect);
            this.panel2.Controls.Add(this.TxbPort);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.TxbServer);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BtnConnect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1148, 34);
            this.panel2.TabIndex = 0;
            // 
            // BtnDisConnect
            // 
            this.BtnDisConnect.Location = new System.Drawing.Point(928, 3);
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
            this.BtnConnect.Location = new System.Drawing.Point(847, 2);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(75, 28);
            this.BtnConnect.TabIndex = 0;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 83);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1148, 412);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // tbClientID
            // 
            this.tbClientID.Location = new System.Drawing.Point(347, 8);
            this.tbClientID.Name = "tbClientID";
            this.tbClientID.Size = new System.Drawing.Size(44, 21);
            this.tbClientID.TabIndex = 7;
            this.tbClientID.Text = "1001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "客户端开始编号:";
            // 
            // tbDeviceID
            // 
            this.tbDeviceID.Location = new System.Drawing.Point(502, 8);
            this.tbDeviceID.Name = "tbDeviceID";
            this.tbDeviceID.Size = new System.Drawing.Size(158, 21);
            this.tbDeviceID.TabIndex = 9;
            this.tbDeviceID.Text = "1000210021";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "设备开始编号:";
            // 
            // tbClientNum
            // 
            this.tbClientNum.Location = new System.Drawing.Point(765, 9);
            this.tbClientNum.Name = "tbClientNum";
            this.tbClientNum.Size = new System.Drawing.Size(44, 21);
            this.tbClientNum.TabIndex = 11;
            this.tbClientNum.Text = "50";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(673, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "客户端数量:";
            // 
            // FrmMqttClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 578);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMqttClient";
            this.Text = "Mqtt Client";
            this.Load += new System.EventHandler(this.FrmMqttClient_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox tbClientID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDeviceID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbClientNum;
        private System.Windows.Forms.Label label5;
    }
}

