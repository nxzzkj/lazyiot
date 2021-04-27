namespace ScadaCenterServer.Pages
{
    partial class InfluxDBBackupForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel = new System.Windows.Forms.Panel();
            this.ucBtnRefresh = new Scada.Controls.Controls.UCBtnExt();
            this.ucbtSave = new Scada.Controls.Controls.UCBtnExt();
            this.ucSplitLine_V1 = new Scada.Controls.Controls.UCSplitLine_V();
            this.ucBtnStop = new Scada.Controls.Controls.UCBtnExt();
            this.ucBtnStart = new Scada.Controls.Controls.UCBtnExt();
            this.ucCBackupEnable = new Scada.Controls.Controls.UCCheckBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ucBackupCryle = new Scada.Controls.Controls.UCCombox();
            this.ucBtnPath = new Scada.Controls.Controls.UCBtnExt();
            this.labelPath = new System.Windows.Forms.Label();
            this.txtPath = new Scada.Controls.Controls.TextBoxEx();
            this.ucSplitLine_H1 = new Scada.Controls.Controls.UCSplitLine_H();
            this.listView = new Scada.Controls.Controls.List.SCADAListView();
            this.columnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnBackupDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BackUpPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnBackupResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucPagerControl = new Scada.Controls.Controls.Page.SCADAPager();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView);
            this.splitContainer1.Panel2.Controls.Add(this.ucPagerControl);
            this.splitContainer1.Size = new System.Drawing.Size(932, 507);
            this.splitContainer1.SplitterDistance = 82;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel.Controls.Add(this.ucBtnRefresh);
            this.panel.Controls.Add(this.ucbtSave);
            this.panel.Controls.Add(this.ucSplitLine_V1);
            this.panel.Controls.Add(this.ucBtnStop);
            this.panel.Controls.Add(this.ucBtnStart);
            this.panel.Controls.Add(this.ucCBackupEnable);
            this.panel.Controls.Add(this.dateTimePicker);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.ucBackupCryle);
            this.panel.Controls.Add(this.ucBtnPath);
            this.panel.Controls.Add(this.labelPath);
            this.panel.Controls.Add(this.txtPath);
            this.panel.Controls.Add(this.ucSplitLine_H1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(932, 82);
            this.panel.TabIndex = 0;
            // 
            // ucBtnRefresh
            // 
            this.ucBtnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnRefresh.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnRefresh.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnRefresh.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnRefresh.BtnText = "刷新";
            this.ucBtnRefresh.ConerRadius = 10;
            this.ucBtnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ucBtnRefresh.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnRefresh.ForeColor = System.Drawing.Color.White;
            this.ucBtnRefresh.IsRadius = true;
            this.ucBtnRefresh.IsShowRect = false;
            this.ucBtnRefresh.IsShowTips = false;
            this.ucBtnRefresh.Location = new System.Drawing.Point(530, 47);
            this.ucBtnRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnRefresh.Name = "ucBtnRefresh";
            this.ucBtnRefresh.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnRefresh.RectWidth = 1;
            this.ucBtnRefresh.Size = new System.Drawing.Size(113, 32);
            this.ucBtnRefresh.TabIndex = 27;
            this.ucBtnRefresh.TabStop = false;
            this.ucBtnRefresh.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnRefresh.TipsText = "";
            this.ucBtnRefresh.BtnClick += new System.EventHandler(this.ucBtnRefresh_BtnClick);
            // 
            // ucbtSave
            // 
            this.ucbtSave.BackColor = System.Drawing.Color.Transparent;
            this.ucbtSave.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucbtSave.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucbtSave.BtnForeColor = System.Drawing.Color.White;
            this.ucbtSave.BtnText = "保存配置";
            this.ucbtSave.ConerRadius = 10;
            this.ucbtSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucbtSave.FillColor = System.Drawing.Color.Green;
            this.ucbtSave.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucbtSave.ForeColor = System.Drawing.Color.White;
            this.ucbtSave.IsRadius = true;
            this.ucbtSave.IsShowRect = false;
            this.ucbtSave.IsShowTips = false;
            this.ucbtSave.Location = new System.Drawing.Point(530, 11);
            this.ucbtSave.Margin = new System.Windows.Forms.Padding(0);
            this.ucbtSave.Name = "ucbtSave";
            this.ucbtSave.RectColor = System.Drawing.Color.Gainsboro;
            this.ucbtSave.RectWidth = 1;
            this.ucbtSave.Size = new System.Drawing.Size(113, 32);
            this.ucbtSave.TabIndex = 26;
            this.ucbtSave.TabStop = false;
            this.ucbtSave.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucbtSave.TipsText = "";
            this.ucbtSave.BtnClick += new System.EventHandler(this.ucbtSave_BtnClick);
            // 
            // ucSplitLine_V1
            // 
            this.ucSplitLine_V1.BackColor = System.Drawing.Color.Red;
            this.ucSplitLine_V1.Location = new System.Drawing.Point(650, -16);
            this.ucSplitLine_V1.Name = "ucSplitLine_V1";
            this.ucSplitLine_V1.Size = new System.Drawing.Size(1, 100);
            this.ucSplitLine_V1.TabIndex = 25;
            this.ucSplitLine_V1.TabStop = false;
            // 
            // ucBtnStop
            // 
            this.ucBtnStop.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnStop.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnStop.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnStop.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnStop.BtnText = "停止备份";
            this.ucBtnStop.ConerRadius = 10;
            this.ucBtnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnStop.FillColor = System.Drawing.Color.Red;
            this.ucBtnStop.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnStop.ForeColor = System.Drawing.Color.White;
            this.ucBtnStop.IsRadius = true;
            this.ucBtnStop.IsShowRect = false;
            this.ucBtnStop.IsShowTips = false;
            this.ucBtnStop.Location = new System.Drawing.Point(657, 47);
            this.ucBtnStop.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnStop.Name = "ucBtnStop";
            this.ucBtnStop.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnStop.RectWidth = 1;
            this.ucBtnStop.Size = new System.Drawing.Size(94, 32);
            this.ucBtnStop.TabIndex = 24;
            this.ucBtnStop.TabStop = false;
            this.ucBtnStop.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnStop.TipsText = "";
            this.ucBtnStop.BtnClick += new System.EventHandler(this.ucBtnStop_BtnClick);
            // 
            // ucBtnStart
            // 
            this.ucBtnStart.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnStart.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnStart.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnStart.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnStart.BtnText = "启动备份";
            this.ucBtnStart.ConerRadius = 10;
            this.ucBtnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnStart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ucBtnStart.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnStart.ForeColor = System.Drawing.Color.White;
            this.ucBtnStart.IsRadius = true;
            this.ucBtnStart.IsShowRect = false;
            this.ucBtnStart.IsShowTips = false;
            this.ucBtnStart.Location = new System.Drawing.Point(657, 10);
            this.ucBtnStart.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnStart.Name = "ucBtnStart";
            this.ucBtnStart.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnStart.RectWidth = 1;
            this.ucBtnStart.Size = new System.Drawing.Size(94, 32);
            this.ucBtnStart.TabIndex = 23;
            this.ucBtnStart.TabStop = false;
            this.ucBtnStart.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnStart.TipsText = "";
            this.ucBtnStart.BtnClick += new System.EventHandler(this.ucBtnStart_BtnClick);
            // 
            // ucCBackupEnable
            // 
            this.ucCBackupEnable.BackColor = System.Drawing.Color.Transparent;
            this.ucCBackupEnable.Checked = false;
            this.ucCBackupEnable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucCBackupEnable.Location = new System.Drawing.Point(420, 44);
            this.ucCBackupEnable.Name = "ucCBackupEnable";
            this.ucCBackupEnable.Padding = new System.Windows.Forms.Padding(1);
            this.ucCBackupEnable.Size = new System.Drawing.Size(92, 30);
            this.ucCBackupEnable.TabIndex = 22;
            this.ucCBackupEnable.TextValue = "开机启动";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "HH:mm:ss";
            this.dateTimePicker.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(316, 45);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(98, 26);
            this.dateTimePicker.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(241, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "备份时间:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(26, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "备份周期:";
            // 
            // ucBackupCryle
            // 
            this.ucBackupCryle.BackColor = System.Drawing.Color.Transparent;
            this.ucBackupCryle.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucBackupCryle.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ucBackupCryle.ConerRadius = 5;
            this.ucBackupCryle.DropPanelHeight = -1;
            this.ucBackupCryle.FillColor = System.Drawing.Color.White;
            this.ucBackupCryle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBackupCryle.IsRadius = true;
            this.ucBackupCryle.IsShowRect = true;
            this.ucBackupCryle.ItemWidth = 70;
            this.ucBackupCryle.Location = new System.Drawing.Point(100, 45);
            this.ucBackupCryle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucBackupCryle.Name = "ucBackupCryle";
            this.ucBackupCryle.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucBackupCryle.RectWidth = 1;
            this.ucBackupCryle.SelectedIndex = -1;
            this.ucBackupCryle.SelectedValue = "";
            this.ucBackupCryle.Size = new System.Drawing.Size(137, 28);
            this.ucBackupCryle.Source = null;
            this.ucBackupCryle.TabIndex = 18;
            this.ucBackupCryle.TextValue = null;
            this.ucBackupCryle.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // ucBtnPath
            // 
            this.ucBtnPath.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnPath.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnPath.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnPath.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnPath.BtnText = "选择";
            this.ucBtnPath.ConerRadius = 10;
            this.ucBtnPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnPath.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ucBtnPath.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnPath.ForeColor = System.Drawing.Color.White;
            this.ucBtnPath.IsRadius = true;
            this.ucBtnPath.IsShowRect = false;
            this.ucBtnPath.IsShowTips = false;
            this.ucBtnPath.Location = new System.Drawing.Point(381, 12);
            this.ucBtnPath.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnPath.Name = "ucBtnPath";
            this.ucBtnPath.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnPath.RectWidth = 1;
            this.ucBtnPath.Size = new System.Drawing.Size(47, 26);
            this.ucBtnPath.TabIndex = 17;
            this.ucBtnPath.TabStop = false;
            this.ucBtnPath.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnPath.TipsText = "";
            this.ucBtnPath.BtnClick += new System.EventHandler(this.ucBtnPath_BtnClick);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPath.Location = new System.Drawing.Point(26, 14);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(68, 20);
            this.labelPath.TabIndex = 2;
            this.labelPath.Text = "备份路径:";
            // 
            // txtPath
            // 
            this.txtPath.DecLength = 2;
            this.txtPath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPath.InputType = Scada.Controls.TextInputType.NotControl;
            this.txtPath.Location = new System.Drawing.Point(100, 12);
            this.txtPath.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtPath.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.txtPath.MyRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtPath.Name = "txtPath";
            this.txtPath.OldText = null;
            this.txtPath.PromptColor = System.Drawing.Color.Gray;
            this.txtPath.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPath.PromptText = "";
            this.txtPath.ReadOnly = true;
            this.txtPath.RegexPattern = "";
            this.txtPath.Size = new System.Drawing.Size(278, 26);
            this.txtPath.TabIndex = 1;
            // 
            // ucSplitLine_H1
            // 
            this.ucSplitLine_H1.BackColor = System.Drawing.Color.Red;
            this.ucSplitLine_H1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucSplitLine_H1.Location = new System.Drawing.Point(0, 81);
            this.ucSplitLine_H1.Name = "ucSplitLine_H1";
            this.ucSplitLine_H1.Size = new System.Drawing.Size(932, 1);
            this.ucSplitLine_H1.TabIndex = 0;
            this.ucSplitLine_H1.TabStop = false;
            // 
            // listView
            // 
            this.listView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView.AllowDrop = true;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnID,
            this.columnBackupDate,
            this.BackUpPath,
            this.columnFileName,
            this.columnBackupResult});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView.ForeColor = System.Drawing.SystemColors.MenuText;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(932, 392);
            this.listView.TabIndex = 8;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnID
            // 
            this.columnID.Text = "编号";
            this.columnID.Width = 64;
            // 
            // columnBackupDate
            // 
            this.columnBackupDate.Text = "备份时间";
            this.columnBackupDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnBackupDate.Width = 135;
            // 
            // BackUpPath
            // 
            this.BackUpPath.Text = "备份路径";
            this.BackUpPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BackUpPath.Width = 230;
            // 
            // columnFileName
            // 
            this.columnFileName.Text = "文件名";
            this.columnFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnFileName.Width = 281;
            // 
            // columnBackupResult
            // 
            this.columnBackupResult.Text = "备份结果";
            this.columnBackupResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnBackupResult.Width = 133;
            // 
            // ucPagerControl
            // 
            this.ucPagerControl.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ucPagerControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPagerControl.Location = new System.Drawing.Point(0, 392);
            this.ucPagerControl.Name = "ucPagerControl";
            this.ucPagerControl.PageCount = 0;
            this.ucPagerControl.PageIndex = 1;
            this.ucPagerControl.PageSize = 100;
            this.ucPagerControl.RecordCount = 0;
            this.ucPagerControl.Size = new System.Drawing.Size(932, 29);
            this.ucPagerControl.TabIndex = 9;
            // 
            // InfluxDBBackupForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(932, 507);
            this.Controls.Add(this.splitContainer1);
            this.Name = "InfluxDBBackupForm";
            this.Text = "InfluxDBBackupForm";
            this.Load += new System.EventHandler(this.InfluxDBBackupForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label labelPath;
        private Scada.Controls.Controls.TextBoxEx txtPath;
        private Scada.Controls.Controls.UCSplitLine_H ucSplitLine_H1;
        private Scada.Controls.Controls.List.SCADAListView listView;
        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnBackupDate;
        private System.Windows.Forms.ColumnHeader BackUpPath;
        private System.Windows.Forms.ColumnHeader columnFileName;
        private System.Windows.Forms.ColumnHeader columnBackupResult;
        private System.Windows.Forms.Label label1;
        private Scada.Controls.Controls.UCCombox ucBackupCryle;
        private Scada.Controls.Controls.UCBtnExt ucBtnPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private Scada.Controls.Controls.UCCheckBox ucCBackupEnable;
        private Scada.Controls.Controls.UCBtnExt ucBtnStop;
        private Scada.Controls.Controls.UCBtnExt ucBtnStart;
        private Scada.Controls.Controls.UCBtnExt ucbtSave;
        private Scada.Controls.Controls.UCSplitLine_V ucSplitLine_V1;
        private Scada.Controls.Controls.Page.SCADAPager ucPagerControl;
        private Scada.Controls.Controls.UCBtnExt ucBtnRefresh;
    }
}