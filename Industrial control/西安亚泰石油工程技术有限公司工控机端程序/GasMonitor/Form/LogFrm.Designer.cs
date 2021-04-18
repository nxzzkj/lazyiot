namespace GasMonitor
{
    partial class LogFrm
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
            this.uiListBox = new Sunny.UI.UIListBox();
            this.PagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PagePanel
            // 
            this.PagePanel.Controls.Add(this.uiListBox);
            // 
            // uiListBox
            // 
            this.uiListBox.BackColor = System.Drawing.Color.Black;
            this.uiListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiListBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiListBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiListBox.ForeColor = System.Drawing.Color.White;
            this.uiListBox.HoverColor = System.Drawing.Color.Silver;
            this.uiListBox.ItemSelectBackColor = System.Drawing.Color.Yellow;
            this.uiListBox.ItemSelectForeColor = System.Drawing.Color.Red;
            this.uiListBox.Location = new System.Drawing.Point(0, 0);
            this.uiListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiListBox.Name = "uiListBox";
            this.uiListBox.Padding = new System.Windows.Forms.Padding(2);
            this.uiListBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiListBox.Size = new System.Drawing.Size(800, 415);
            this.uiListBox.Style = Sunny.UI.UIStyle.Custom;
            this.uiListBox.TabIndex = 0;
            this.uiListBox.Text = "uiListBox";
            this.uiListBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "LogFrm";
            this.Text = "系统日志";
            this.PagePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIListBox uiListBox;
    }
}