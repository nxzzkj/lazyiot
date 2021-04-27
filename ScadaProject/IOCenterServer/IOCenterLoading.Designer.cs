namespace ScadaCenterServer
{
    partial class IOCenterLoading
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
            this.ucProcessLineExt1 = new Scada.Controls.Controls.UCProcessLineExt();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucProcessLineExt1
            // 
            this.ucProcessLineExt1.BackColor = System.Drawing.Color.Transparent;
            this.ucProcessLineExt1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.ucProcessLineExt1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucProcessLineExt1.Location = new System.Drawing.Point(27, 87);
            this.ucProcessLineExt1.MaxValue = 100;
            this.ucProcessLineExt1.Name = "ucProcessLineExt1";
            this.ucProcessLineExt1.Size = new System.Drawing.Size(434, 50);
            this.ucProcessLineExt1.TabIndex = 0;
            this.ucProcessLineExt1.Value = 0;
            this.ucProcessLineExt1.ValueBGColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.ucProcessLineExt1.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(45, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 30);
            this.label1.TabIndex = 1;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(45, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(397, 41);
            this.label2.TabIndex = 1;
            this.label2.Text = "SCADA数据中心正在加载资源";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelInfo
            // 
            this.labelInfo.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelInfo.ForeColor = System.Drawing.Color.Silver;
            this.labelInfo.Location = new System.Drawing.Point(45, 187);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(397, 29);
            this.labelInfo.TabIndex = 2;
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IOCenterLoading
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(489, 225);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucProcessLineExt1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IsShowRegion = true;
            this.Name = "IOCenterLoading";
            this.ProgressNum = 32;
            this.Redraw = true;
            this.ShowInTaskbar = false;
            this.Text = "系统资源加载中";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Scada.Controls.Controls.UCProcessLineExt ucProcessLineExt1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelInfo;
    }
}