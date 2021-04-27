namespace ScadaCenterServer.Pages
{
    partial class SeriesWorkForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeriesWorkForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.search = new ScadaCenterServer.Controls.Search();
            this.ucPagerControl = new Scada.Controls.Controls.UCPagerControl2();
 
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.search);
            // 
            // splitContainer.Panel2
            // 
  
            this.splitContainer.Panel2.Controls.Add(this.ucPagerControl);
            this.splitContainer.Size = new System.Drawing.Size(796, 492);
            this.splitContainer.SplitterDistance = 28;
            this.splitContainer.TabIndex = 1;
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.search.Location = new System.Drawing.Point(0, 0);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(796, 28);
            this.search.TabIndex = 0;
            // 
            // ucPagerControl
            // 
            this.ucPagerControl.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ucPagerControl.DataSource = ((System.Collections.Generic.List<object>)(resources.GetObject("ucPagerControl.DataSource")));
            this.ucPagerControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPagerControl.Location = new System.Drawing.Point(0, 425);
            this.ucPagerControl.Name = "ucPagerControl";
            this.ucPagerControl.PageCount = 0;
            this.ucPagerControl.PageIndex = 1;
            this.ucPagerControl.PageModel = Scada.Controls.Controls.PageModel.Soure;
            this.ucPagerControl.PageSize = 100;
            this.ucPagerControl.Size = new System.Drawing.Size(796, 35);
            this.ucPagerControl.StartIndex = 0;
            this.ucPagerControl.TabIndex = 6;
           
            // SeriesWorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 492);
            this.Controls.Add(this.splitContainer);
            this.Name = "SeriesWorkForm";
            this.Text = "曲线查询";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private Controls.Search search;
        private Scada.Controls.Controls.UCPagerControl2 ucPagerControl;
    
    }
}