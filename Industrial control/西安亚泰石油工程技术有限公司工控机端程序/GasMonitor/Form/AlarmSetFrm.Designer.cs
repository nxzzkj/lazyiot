namespace GasMonitor
{
    partial class AlarmSetFrm
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
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.alarmSet1 = new GasMonitor.AlarmSet();
            this.alarmSet2 = new GasMonitor.AlarmSet();
            this.alarmSet3 = new GasMonitor.AlarmSet();
            this.alarmSet4 = new GasMonitor.AlarmSet();
            this.alarmSet5 = new GasMonitor.AlarmSet();
            this.alarmSet6 = new GasMonitor.AlarmSet();
            this.PagePanel.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PagePanel
            // 
            this.PagePanel.Controls.Add(this.flowLayoutPanel);
            this.PagePanel.Size = new System.Drawing.Size(1146, 508);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Controls.Add(this.alarmSet1);
            this.flowLayoutPanel.Controls.Add(this.alarmSet2);
            this.flowLayoutPanel.Controls.Add(this.alarmSet3);
            this.flowLayoutPanel.Controls.Add(this.alarmSet4);
            this.flowLayoutPanel.Controls.Add(this.alarmSet5);
            this.flowLayoutPanel.Controls.Add(this.alarmSet6);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1146, 508);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // alarmSet1
            // 
            this.alarmSet1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.alarmSet1.Location = new System.Drawing.Point(4, 5);
            this.alarmSet1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.alarmSet1.Name = "alarmSet1";
            this.alarmSet1.Size = new System.Drawing.Size(384, 234);
            this.alarmSet1.TabIndex = 0;
            this.alarmSet1.Text = null;
            // 
            // alarmSet2
            // 
            this.alarmSet2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.alarmSet2.Location = new System.Drawing.Point(396, 5);
            this.alarmSet2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.alarmSet2.Name = "alarmSet2";
            this.alarmSet2.Size = new System.Drawing.Size(384, 234);
            this.alarmSet2.TabIndex = 1;
            this.alarmSet2.Text = null;
            // 
            // alarmSet3
            // 
            this.alarmSet3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.alarmSet3.Location = new System.Drawing.Point(4, 249);
            this.alarmSet3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.alarmSet3.Name = "alarmSet3";
            this.alarmSet3.Size = new System.Drawing.Size(384, 234);
            this.alarmSet3.TabIndex = 2;
            this.alarmSet3.Text = null;
            // 
            // alarmSet4
            // 
            this.alarmSet4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.alarmSet4.Location = new System.Drawing.Point(396, 249);
            this.alarmSet4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.alarmSet4.Name = "alarmSet4";
            this.alarmSet4.Size = new System.Drawing.Size(384, 234);
            this.alarmSet4.TabIndex = 3;
            this.alarmSet4.Text = null;
            // 
            // alarmSet5
            // 
            this.alarmSet5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.alarmSet5.Location = new System.Drawing.Point(4, 493);
            this.alarmSet5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.alarmSet5.Name = "alarmSet5";
            this.alarmSet5.Size = new System.Drawing.Size(384, 234);
            this.alarmSet5.TabIndex = 4;
            this.alarmSet5.Text = null;
            // 
            // alarmSet6
            // 
            this.alarmSet6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.alarmSet6.Location = new System.Drawing.Point(396, 493);
            this.alarmSet6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.alarmSet6.Name = "alarmSet6";
            this.alarmSet6.Size = new System.Drawing.Size(384, 234);
            this.alarmSet6.TabIndex = 5;
            this.alarmSet6.Text = null;
            // 
            // AlarmSetFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 543);
            this.ControlBox = false;
            this.Name = "AlarmSetFrm";
            this.Text = "报警配置";
            this.PagePanel.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private AlarmSet alarmSet1;
        private AlarmSet alarmSet2;
        private AlarmSet alarmSet3;
        private AlarmSet alarmSet4;
        private AlarmSet alarmSet5;
        private AlarmSet alarmSet6;
    }
}