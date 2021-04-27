namespace IOManager.Page
{
    partial class IOLogForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOLogForm));
            this.listBoxEx = new IOManager.Controls.ListBoxEx();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.导出TXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxEx
            // 
            this.listBoxEx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxEx.ContextMenuStrip = this.contextMenuStrip;
            this.listBoxEx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxEx.FormattingEnabled = true;
            this.listBoxEx.ItemHeight = 12;
            this.listBoxEx.Location = new System.Drawing.Point(0, 0);
            this.listBoxEx.Name = "listBoxEx";
            this.listBoxEx.Size = new System.Drawing.Size(284, 261);
            this.listBoxEx.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出TXTToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 48);
            // 
            // 导出TXTToolStripMenuItem
            // 
            this.导出TXTToolStripMenuItem.Name = "导出TXTToolStripMenuItem";
            this.导出TXTToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.导出TXTToolStripMenuItem.Text = "导出TXT";
            this.导出TXTToolStripMenuItem.Click += new System.EventHandler(this.导出TXTToolStripMenuItem_Click);
            // 
            // IOLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.listBoxEx);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IOLogForm";
            this.Text = "IOLogForm";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ListBoxEx listBoxEx;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 导出TXTToolStripMenuItem;
    }
}