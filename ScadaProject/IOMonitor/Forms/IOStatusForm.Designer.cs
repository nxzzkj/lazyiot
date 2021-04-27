

using IOMonitor.Controls;

namespace IOMonitor.Forms
{
    partial class IOStatusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOStatusForm));
            this.IoTreeStatus = new IOMonitor.Controls.IOTree();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControlExt1 = new Scada.Controls.Controls.TabControlExt();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.computerInfoControl = new Scada.Controls.Controls.ComputerInfoControl();
            this.tabControlExt1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // IoTreeStatus
            // 
            this.IoTreeStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IoTreeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IoTreeStatus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IoTreeStatus.FullRowSelect = true;
            this.IoTreeStatus.ImageIndex = 0;
            this.IoTreeStatus.ImageList = this.imageList1;
            this.IoTreeStatus.Location = new System.Drawing.Point(3, 3);
            this.IoTreeStatus.Name = "IoTreeStatus";
            this.IoTreeStatus.SelectedImageIndex = 0;
            this.IoTreeStatus.Size = new System.Drawing.Size(359, 466);
            this.IoTreeStatus.TabIndex = 0;
            this.IoTreeStatus.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.IoTreeStatus_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "My%20Accounts%20Folder.ico");
            this.imageList1.Images.SetKeyName(1, "network%20connections.ico");
            this.imageList1.Images.SetKeyName(2, "wifi.png");
            this.imageList1.Images.SetKeyName(3, "wifi2.png");
            // 
            // tabControlExt1
            // 
            this.tabControlExt1.Controls.Add(this.tabPage1);
            this.tabControlExt1.Controls.Add(this.tabPage2);
            this.tabControlExt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlExt1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlExt1.IsShowCloseBtn = false;
            this.tabControlExt1.ItemSize = new System.Drawing.Size(0, 30);
            this.tabControlExt1.Location = new System.Drawing.Point(0, 0);
            this.tabControlExt1.Name = "tabControlExt1";
            this.tabControlExt1.SelectedIndex = 0;
            this.tabControlExt1.Size = new System.Drawing.Size(257, 510);
            this.tabControlExt1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.IoTreeStatus);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(365, 472);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "IO树目录";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.computerInfoControl);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(249, 472);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "资源";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // computerInfoControl
            // 
            this.computerInfoControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.computerInfoControl.Location = new System.Drawing.Point(3, 3);
            this.computerInfoControl.Name = "computerInfoControl";
            this.computerInfoControl.Size = new System.Drawing.Size(243, 466);
            this.computerInfoControl.TabIndex = 0;
            // 
            // IOStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 510);
            this.Controls.Add(this.tabControlExt1);
            this.Name = "IOStatusForm";
            this.Text = "IOStatusForm";
            this.Load += new System.EventHandler(this.IOStatusForm_Load);
            this.tabControlExt1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        public IOTree IoTreeStatus;
        private Scada.Controls.Controls.TabControlExt tabControlExt1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Scada.Controls.Controls.ComputerInfoControl computerInfoControl;
    }
}