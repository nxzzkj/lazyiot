namespace ScadaCenterServer.Controls
{
    partial class HistoryAlarmSearch
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.ucAlarmLevel = new Scada.Controls.Controls.UCCombox();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.ucBtnSearch = new Scada.Controls.Controls.UCBtnExt();
            this.ucAlarmType = new Scada.Controls.Controls.UCCombox();
            this.hsComboBoxDevices = new ScadaCenterServer.Controls.HsComboBox(this.components);
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 6;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 304F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Controls.Add(this.dateStart, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.ucAlarmLevel, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.dateEnd, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.ucBtnSearch, 5, 0);
            this.tableLayoutPanel.Controls.Add(this.ucAlarmType, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.hsComboBoxDevices, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(958, 30);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // dateStart
            // 
            this.dateStart.CalendarFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateStart.CustomFormat = "yyyy-MM-dd HH时";
            this.dateStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStart.Location = new System.Drawing.Point(559, 3);
            this.dateStart.Name = "dateStart";
            this.dateStart.ShowUpDown = true;
            this.dateStart.Size = new System.Drawing.Size(124, 23);
            this.dateStart.TabIndex = 24;
            // 
            // ucAlarmLevel
            // 
            this.ucAlarmLevel.BackColor = System.Drawing.Color.Transparent;
            this.ucAlarmLevel.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucAlarmLevel.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ucAlarmLevel.ConerRadius = 5;
            this.ucAlarmLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAlarmLevel.DropPanelHeight = -1;
            this.ucAlarmLevel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucAlarmLevel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucAlarmLevel.IsRadius = true;
            this.ucAlarmLevel.IsShowRect = true;
            this.ucAlarmLevel.ItemWidth = 70;
            this.ucAlarmLevel.Location = new System.Drawing.Point(440, 5);
            this.ucAlarmLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucAlarmLevel.Name = "ucAlarmLevel";
            this.ucAlarmLevel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucAlarmLevel.RectWidth = 1;
            this.ucAlarmLevel.SelectedIndex = -1;
            this.ucAlarmLevel.SelectedValue = "";
            this.ucAlarmLevel.Size = new System.Drawing.Size(112, 20);
            this.ucAlarmLevel.Source = null;
            this.ucAlarmLevel.TabIndex = 21;
            this.ucAlarmLevel.TextValue = "报警级别";
            this.ucAlarmLevel.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // dateEnd
            // 
            this.dateEnd.CalendarFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateEnd.CustomFormat = "yyyy-MM-dd HH时";
            this.dateEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateEnd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd.Location = new System.Drawing.Point(689, 3);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.ShowUpDown = true;
            this.dateEnd.Size = new System.Drawing.Size(124, 23);
            this.dateEnd.TabIndex = 26;
            // 
            // ucBtnSearch
            // 
            this.ucBtnSearch.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnSearch.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnSearch.BtnFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnSearch.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnSearch.BtnText = "查询";
            this.ucBtnSearch.ConerRadius = 5;
            this.ucBtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucBtnSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.ucBtnSearch.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnSearch.ForeColor = System.Drawing.Color.White;
            this.ucBtnSearch.IsRadius = true;
            this.ucBtnSearch.IsShowRect = false;
            this.ucBtnSearch.IsShowTips = false;
            this.ucBtnSearch.Location = new System.Drawing.Point(816, 0);
            this.ucBtnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnSearch.Name = "ucBtnSearch";
            this.ucBtnSearch.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnSearch.RectWidth = 1;
            this.ucBtnSearch.Size = new System.Drawing.Size(47, 30);
            this.ucBtnSearch.TabIndex = 27;
            this.ucBtnSearch.TabStop = false;
            this.ucBtnSearch.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnSearch.TipsText = "";
            this.ucBtnSearch.BtnClick += new System.EventHandler(this.ucBtnExt13_BtnClick);
            // 
            // ucAlarmType
            // 
            this.ucAlarmType.BackColor = System.Drawing.Color.Transparent;
            this.ucAlarmType.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucAlarmType.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ucAlarmType.ConerRadius = 5;
            this.ucAlarmType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAlarmType.DropPanelHeight = -1;
            this.ucAlarmType.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucAlarmType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucAlarmType.IsRadius = true;
            this.ucAlarmType.IsShowRect = true;
            this.ucAlarmType.ItemWidth = 70;
            this.ucAlarmType.Location = new System.Drawing.Point(308, 5);
            this.ucAlarmType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucAlarmType.Name = "ucAlarmType";
            this.ucAlarmType.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucAlarmType.RectWidth = 1;
            this.ucAlarmType.SelectedIndex = -1;
            this.ucAlarmType.SelectedValue = "";
            this.ucAlarmType.Size = new System.Drawing.Size(124, 20);
            this.ucAlarmType.Source = null;
            this.ucAlarmType.TabIndex = 20;
            this.ucAlarmType.TextValue = "报警级别";
            this.ucAlarmType.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // hsComboBoxDevices
            // 
            this.hsComboBoxDevices.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.hsComboBoxDevices.CheckedListBox = null;
            this.hsComboBoxDevices.CtlType = ScadaCenterServer.Controls.HsComboBox.TypeC.TreeView;
            this.hsComboBoxDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hsComboBoxDevices.DropDownHeight = 1;
            this.hsComboBoxDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hsComboBoxDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hsComboBoxDevices.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hsComboBoxDevices.ForeColor = System.Drawing.SystemColors.WindowText;
            this.hsComboBoxDevices.FormattingEnabled = true;
            this.hsComboBoxDevices.IntegralHeight = false;
            this.hsComboBoxDevices.ItemHeight = 19;
            this.hsComboBoxDevices.Location = new System.Drawing.Point(3, 3);
            this.hsComboBoxDevices.Name = "hsComboBoxDevices";
            this.hsComboBoxDevices.Size = new System.Drawing.Size(298, 27);
            this.hsComboBoxDevices.TabIndex = 20;
            this.hsComboBoxDevices.SelectedIndexChanged += new System.EventHandler(this.hsComboBoxDevices_SelectedIndexChanged);
            // 
            // HistoryAlarmSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "HistoryAlarmSearch";
            this.Size = new System.Drawing.Size(1238, 30);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Scada.Controls.Controls.UCCombox ucAlarmLevel;
        private Scada.Controls.Controls.UCCombox ucAlarmType;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private Scada.Controls.Controls.UCBtnExt ucBtnSearch;
        private HsComboBox hsComboBoxDevices;
    }
}
