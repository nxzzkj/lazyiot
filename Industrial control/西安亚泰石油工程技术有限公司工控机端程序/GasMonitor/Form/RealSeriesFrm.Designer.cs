using System.Windows.Forms;

namespace GasMonitor
{
    partial class RealSeriesFrm
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
            this.flowLayoutPanel = new System.Windows.Forms.Panel();
            this.chanelSeries2 = new GasMonitor.ChanelSeries();
            this.chanelSeries3 = new GasMonitor.ChanelSeries();
            this.chanelSeries4 = new GasMonitor.ChanelSeries();
            this.chanelSeries5 = new GasMonitor.ChanelSeries();
            this.chanelSeries6 = new GasMonitor.ChanelSeries();
            this.chanelSeries1 = new GasMonitor.ChanelSeries();
            this.PagePanel.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.chanelSeries2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PagePanel
            // 
            this.PagePanel.Controls.Add(this.flowLayoutPanel);
            this.PagePanel.Size = new System.Drawing.Size(1167, 700);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Controls.Add(this.chanelSeries2);
            this.flowLayoutPanel.Controls.Add(this.chanelSeries3);
            this.flowLayoutPanel.Controls.Add(this.chanelSeries4);
            this.flowLayoutPanel.Controls.Add(this.chanelSeries5);
            this.flowLayoutPanel.Controls.Add(this.chanelSeries6);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1167, 700);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // chanelSeries2
            // 
            this.chanelSeries2.Controls.Add(this.chanelSeries1);
            this.chanelSeries2.Dock = System.Windows.Forms.DockStyle.Top;
            this.chanelSeries2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chanelSeries2.Location = new System.Drawing.Point(0, 1468);
            this.chanelSeries2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chanelSeries2.Name = "chanelSeries2";
            this.chanelSeries2.Size = new System.Drawing.Size(1150, 357);
            this.chanelSeries2.TabIndex = 1;
            this.chanelSeries2.Text = "chanelSeries2";
            // 
            // chanelSeries3
            // 
            this.chanelSeries3.Dock = System.Windows.Forms.DockStyle.Top;
            this.chanelSeries3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chanelSeries3.Location = new System.Drawing.Point(0, 1114);
            this.chanelSeries3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chanelSeries3.Name = "chanelSeries3";
            this.chanelSeries3.Size = new System.Drawing.Size(1150, 354);
            this.chanelSeries3.TabIndex = 2;
            this.chanelSeries3.Text = "chanelSeries3";
            // 
            // chanelSeries4
            // 
            this.chanelSeries4.Dock = System.Windows.Forms.DockStyle.Top;
            this.chanelSeries4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chanelSeries4.Location = new System.Drawing.Point(0, 750);
            this.chanelSeries4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chanelSeries4.Name = "chanelSeries4";
            this.chanelSeries4.Size = new System.Drawing.Size(1150, 364);
            this.chanelSeries4.TabIndex = 3;
            this.chanelSeries4.Text = "chanelSeries4";
            // 
            // chanelSeries5
            // 
            this.chanelSeries5.Dock = System.Windows.Forms.DockStyle.Top;
            this.chanelSeries5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.chanelSeries5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chanelSeries5.ForeColor = System.Drawing.Color.Silver;
            this.chanelSeries5.Location = new System.Drawing.Point(0, 386);
            this.chanelSeries5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chanelSeries5.Name = "chanelSeries5";
            this.chanelSeries5.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.chanelSeries5.Size = new System.Drawing.Size(1150, 364);
            this.chanelSeries5.Style = Sunny.UI.UIStyle.Black;
            this.chanelSeries5.TabIndex = 4;
            this.chanelSeries5.Text = "chanelSeries5";
            // 
            // chanelSeries6
            // 
            this.chanelSeries6.Dock = System.Windows.Forms.DockStyle.Top;
            this.chanelSeries6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.chanelSeries6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chanelSeries6.ForeColor = System.Drawing.Color.Silver;
            this.chanelSeries6.Location = new System.Drawing.Point(0, 0);
            this.chanelSeries6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chanelSeries6.Name = "chanelSeries6";
            this.chanelSeries6.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.chanelSeries6.Size = new System.Drawing.Size(1150, 386);
            this.chanelSeries6.Style = Sunny.UI.UIStyle.Black;
            this.chanelSeries6.TabIndex = 5;
            this.chanelSeries6.Text = "chanelSeries6";
            // 
            // chanelSeries1
            // 
            this.chanelSeries1.Dock = System.Windows.Forms.DockStyle.Top;
            this.chanelSeries1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chanelSeries1.Location = new System.Drawing.Point(0, 0);
            this.chanelSeries1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chanelSeries1.Name = "chanelSeries1";
            this.chanelSeries1.Size = new System.Drawing.Size(1150, 369);
            this.chanelSeries1.TabIndex = 101;
            this.chanelSeries1.Text = "chanelSeries1";
            // 
            // RealSeriesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 735);
            this.Name = "RealSeriesFrm";
            this.Text = "实时曲线";
            this.PagePanel.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.chanelSeries2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel flowLayoutPanel;
        private ChanelSeries chanelSeries2;
        private ChanelSeries chanelSeries3;
        private ChanelSeries chanelSeries4;
        private ChanelSeries chanelSeries5;
        private ChanelSeries chanelSeries6;
        private ChanelSeries chanelSeries1;
    }
}