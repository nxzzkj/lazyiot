namespace IOManager.Controls
{
    partial class WizardTabControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mTabControl = new System.Windows.Forms.TabControl();
            this.btNext = new System.Windows.Forms.Button();
            this.btPre = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mTabControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btPre);
            this.splitContainer1.Panel2.Controls.Add(this.btNext);
            this.splitContainer1.Panel2.Controls.Add(this.btOK);
            this.splitContainer1.Panel2.Controls.Add(this.btCancel);
            this.splitContainer1.Size = new System.Drawing.Size(542, 486);
            this.splitContainer1.SplitterDistance = 460;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // mTabControl
            // 
            this.mTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTabControl.Location = new System.Drawing.Point(0, 0);
            this.mTabControl.Name = "mTabControl";
            this.mTabControl.SelectedIndex = 0;
            this.mTabControl.Size = new System.Drawing.Size(542, 460);
            this.mTabControl.TabIndex = 0;
            // 
            // btNext
            // 
            this.btNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btNext.Location = new System.Drawing.Point(334, 0);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(71, 25);
            this.btNext.TabIndex = 2;
            this.btNext.Text = "下一步";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Visible = false;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btPre
            // 
            this.btPre.Dock = System.Windows.Forms.DockStyle.Right;
            this.btPre.Location = new System.Drawing.Point(265, 0);
            this.btPre.Name = "btPre";
            this.btPre.Size = new System.Drawing.Size(69, 25);
            this.btPre.TabIndex = 1;
            this.btPre.Text = "上一步";
            this.btPre.UseVisualStyleBackColor = true;
            this.btPre.Visible = false;
            this.btPre.Click += new System.EventHandler(this.btPre_Click);
            // 
            // btOK
            // 
            this.btOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btOK.Location = new System.Drawing.Point(405, 0);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(69, 25);
            this.btOK.TabIndex = 3;
            this.btOK.Text = "完成";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Visible = false;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btCancel.Location = new System.Drawing.Point(474, 0);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(68, 25);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // WizardTabControl
            // 
            this.Controls.Add(this.splitContainer1);
            this.Name = "WizardTabControl";
            this.Size = new System.Drawing.Size(542, 486);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btPre;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.TabControl mTabControl;
    }
}
