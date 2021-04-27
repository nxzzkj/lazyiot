namespace Scada.DBUtility
{
    partial class IPAddressSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPAddressSelector));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbIPAddress = new System.Windows.Forms.ComboBox();
            this.btOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbIPAddress);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当前可用的网络连接";
            // 
            // cbIPAddress
            // 
            this.cbIPAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIPAddress.FormattingEnabled = true;
            this.cbIPAddress.Location = new System.Drawing.Point(6, 25);
            this.cbIPAddress.Name = "cbIPAddress";
            this.cbIPAddress.Size = new System.Drawing.Size(258, 28);
            this.cbIPAddress.TabIndex = 1;
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(171, 62);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(99, 32);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "确定";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // IPAddressSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 101);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btOK);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IPAddressSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "本地网络连接设置";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.ComboBox cbIPAddress;
    }
}