namespace IOMonitor
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btConnect = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.rtbReceive = new System.Windows.Forms.RichTextBox();
            this.rtbSend = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(395, 10);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(75, 23);
            this.btConnect.TabIndex = 0;
            this.btConnect.Text = "连接服务器";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(58, 12);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(176, 21);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "192.168.1.6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "远程IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "远程端口";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(305, 12);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(75, 21);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "8888";
            // 
            // rtbReceive
            // 
            this.rtbReceive.Location = new System.Drawing.Point(13, 65);
            this.rtbReceive.Name = "rtbReceive";
            this.rtbReceive.ReadOnly = true;
            this.rtbReceive.Size = new System.Drawing.Size(593, 163);
            this.rtbReceive.TabIndex = 5;
            this.rtbReceive.Text = "";
            // 
            // rtbSend
            // 
            this.rtbSend.Location = new System.Drawing.Point(12, 266);
            this.rtbSend.Name = "rtbSend";
            this.rtbSend.Size = new System.Drawing.Size(593, 133);
            this.rtbSend.TabIndex = 6;
            this.rtbSend.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "接收到的数据:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "发送到的数据:";
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(521, 406);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 9;
            this.btSend.Text = "发送数据";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 441);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbSend);
            this.Controls.Add(this.rtbReceive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btConnect);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.RichTextBox rtbReceive;
        private System.Windows.Forms.RichTextBox rtbSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btSend;
    }
}