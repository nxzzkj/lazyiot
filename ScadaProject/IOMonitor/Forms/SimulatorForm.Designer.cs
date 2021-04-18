using Scada.Controls.Controls.List;

namespace IOMonitor.Forms
{
    partial class SimulatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulatorForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.computerInfoControl = new Scada.Controls.Controls.ComputerInfoControl();
            this.listView = new Scada.Controls.Controls.List.SCADAListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucPanelQuote1 = new Scada.Controls.Controls.UCPanelQuote();
            this.ucSwitch = new Scada.Controls.Controls.UCSwitch();
            this.uccbShowReport = new Scada.Controls.Controls.UCCheckBox();
            this.ucCheckAlert = new Scada.Controls.Controls.UCCheckBox();
            this.labelSecond = new System.Windows.Forms.Label();
            this.ucNumTextBoxTime = new Scada.Controls.Controls.UCNumTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.ucPanelQuote1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Image = ((System.Drawing.Image)(resources.GetObject("lblTitle.Image")));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 1);
            this.lblTitle.Size = new System.Drawing.Size(893, 26);
            this.lblTitle.Text = "SCADA采集站模拟器";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.Location = new System.Drawing.Point(865, 0);
            // 
            // btMin
            // 
            this.btMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btMin.BackgroundImage")));
            this.btMin.Location = new System.Drawing.Point(833, 0);
            // 
            // btMax
            // 
            this.btMax.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btMax.BackgroundImage")));
            this.btMax.Location = new System.Drawing.Point(803, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 58);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView);
            this.splitContainer1.Size = new System.Drawing.Size(893, 547);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.computerInfoControl);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(260, 547);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // computerInfoControl
            // 
            this.computerInfoControl.Location = new System.Drawing.Point(3, 3);
            this.computerInfoControl.Name = "computerInfoControl";
            this.computerInfoControl.Size = new System.Drawing.Size(232, 733);
            this.computerInfoControl.TabIndex = 0;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(629, 547);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 111;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "报告内容";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 454;
            // 
            // ucPanelQuote1
            // 
            this.ucPanelQuote1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.ucPanelQuote1.Controls.Add(this.ucSwitch);
            this.ucPanelQuote1.Controls.Add(this.uccbShowReport);
            this.ucPanelQuote1.Controls.Add(this.ucCheckAlert);
            this.ucPanelQuote1.Controls.Add(this.labelSecond);
            this.ucPanelQuote1.Controls.Add(this.ucNumTextBoxTime);
            this.ucPanelQuote1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucPanelQuote1.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.ucPanelQuote1.Location = new System.Drawing.Point(0, 27);
            this.ucPanelQuote1.Name = "ucPanelQuote1";
            this.ucPanelQuote1.Padding = new System.Windows.Forms.Padding(5, 1, 1, 1);
            this.ucPanelQuote1.Size = new System.Drawing.Size(893, 31);
            this.ucPanelQuote1.TabIndex = 10;
            // 
            // ucSwitch
            // 
            this.ucSwitch.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch.Checked = false;
            this.ucSwitch.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucSwitch.FalseColor = System.Drawing.Color.Red;
            this.ucSwitch.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucSwitch.ForeColor = System.Drawing.Color.Yellow;
            this.ucSwitch.Location = new System.Drawing.Point(490, 1);
            this.ucSwitch.Name = "ucSwitch";
            this.ucSwitch.Size = new System.Drawing.Size(141, 29);
            this.ucSwitch.SwitchType = Scada.Controls.Controls.SwitchType.Ellipse;
            this.ucSwitch.TabIndex = 0;
            this.ucSwitch.Texts = new string[] {
        "结束",
        "启动"};
            this.ucSwitch.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ucSwitch.Click += new System.EventHandler(this.ucSwitch_Click);
            // 
            // uccbShowReport
            // 
            this.uccbShowReport.BackColor = System.Drawing.Color.Transparent;
            this.uccbShowReport.Checked = false;
            this.uccbShowReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.uccbShowReport.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uccbShowReport.Location = new System.Drawing.Point(358, 1);
            this.uccbShowReport.Name = "uccbShowReport";
            this.uccbShowReport.Padding = new System.Windows.Forms.Padding(1);
            this.uccbShowReport.Size = new System.Drawing.Size(132, 29);
            this.uccbShowReport.TabIndex = 6;
            this.uccbShowReport.TextValue = "显示报告";
            // 
            // ucCheckAlert
            // 
            this.ucCheckAlert.BackColor = System.Drawing.Color.Transparent;
            this.ucCheckAlert.Checked = false;
            this.ucCheckAlert.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucCheckAlert.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucCheckAlert.Location = new System.Drawing.Point(213, 1);
            this.ucCheckAlert.Name = "ucCheckAlert";
            this.ucCheckAlert.Padding = new System.Windows.Forms.Padding(1);
            this.ucCheckAlert.Size = new System.Drawing.Size(145, 29);
            this.ucCheckAlert.TabIndex = 5;
            this.ucCheckAlert.TextValue = "开启模拟报警";
            // 
            // labelSecond
            // 
            this.labelSecond.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelSecond.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSecond.Location = new System.Drawing.Point(172, 1);
            this.labelSecond.Name = "labelSecond";
            this.labelSecond.Size = new System.Drawing.Size(41, 29);
            this.labelSecond.TabIndex = 2;
            this.labelSecond.Text = "秒";
            this.labelSecond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucNumTextBoxTime
            // 
            this.ucNumTextBoxTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucNumTextBoxTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ucNumTextBoxTime.InputType = Scada.Controls.TextInputType.Number;
            this.ucNumTextBoxTime.IsNumCanInput = true;
            this.ucNumTextBoxTime.KeyBoardType = Scada.Controls.Controls.KeyBoardType.UCKeyBorderNum;
            this.ucNumTextBoxTime.Location = new System.Drawing.Point(5, 1);
            this.ucNumTextBoxTime.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ucNumTextBoxTime.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ucNumTextBoxTime.Name = "ucNumTextBoxTime";
            this.ucNumTextBoxTime.Num = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ucNumTextBoxTime.Padding = new System.Windows.Forms.Padding(2);
            this.ucNumTextBoxTime.Size = new System.Drawing.Size(167, 29);
            this.ucNumTextBoxTime.TabIndex = 1;
            // 
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 605);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ucPanelQuote1);
            this.Name = "SimulatorForm";
            this.Text = "SCADA模拟器";
            this.Title = "SCADA采集站模拟器";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.ucPanelQuote1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btMin, 0);
            this.Controls.SetChildIndex(this.btMax, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ucPanelQuote1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Scada.Controls.Controls.UCPanelQuote ucPanelQuote1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Scada.Controls.Controls.UCNumTextBox ucNumTextBoxTime;
        private Scada.Controls.Controls.UCSwitch ucSwitch;
        private System.Windows.Forms.Label labelSecond;
        private Scada.Controls.Controls.UCCheckBox ucCheckAlert;
        private SCADAListView  listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private Scada.Controls.Controls.UCCheckBox uccbShowReport;
        private Scada.Controls.Controls.ComputerInfoControl computerInfoControl;
    }
}