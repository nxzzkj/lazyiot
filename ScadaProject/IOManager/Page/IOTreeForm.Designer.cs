namespace IOManager.Page
{
    partial class IOTreeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOTreeForm));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.IoTree = new IOManager.Controls.IOTree();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Server");
            this.imageList.Images.SetKeyName(1, "Communication");
            this.imageList.Images.SetKeyName(2, "Device");
            this.imageList.Images.SetKeyName(3, "IO");
            // 
            // IoTree
            // 
            this.IoTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IoTree.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IoTree.ImageIndex = 0;
            this.IoTree.ImageList = this.imageList;
            this.IoTree.ItemHeight = 28;
            this.IoTree.Location = new System.Drawing.Point(0, 0);
            this.IoTree.Name = "IoTree";
            this.IoTree.SelectedImageIndex = 0;
            this.IoTree.Size = new System.Drawing.Size(198, 489);
            this.IoTree.TabIndex = 1;
            // 
            // IOTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 489);
            this.Controls.Add(this.IoTree);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IOTreeForm";
            this.Text = "IOTreeForm";
            this.ResumeLayout(false);

        }

        #endregion

        public Controls.IOTree IoTree;
        private System.Windows.Forms.ImageList imageList;
    }
}