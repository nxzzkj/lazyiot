namespace ScadaCenterServer.Controls
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.hsComboBoxDevices = new ScadaCenterServer.Controls.HsComboBox(this.components);
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.ucBtn_Search = new Scada.Controls.Controls.UCBtnImg();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel.Controls.Add(this.hsComboBoxDevices, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.dateEnd, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.dateStart, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.ucBtn_Search, 4, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(769, 32);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // hsComboBoxDevices
            // 
            this.hsComboBoxDevices.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.hsComboBoxDevices.CheckedListBox = null;
            this.tableLayoutPanel.SetColumnSpan(this.hsComboBoxDevices, 2);
            this.hsComboBoxDevices.CtlType = ScadaCenterServer.Controls.HsComboBox.TypeC.TreeView;
            this.hsComboBoxDevices.Dock = System.Windows.Forms.DockStyle.Left;
            this.hsComboBoxDevices.DropDownHeight = 1;
            this.hsComboBoxDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hsComboBoxDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hsComboBoxDevices.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hsComboBoxDevices.ForeColor = System.Drawing.SystemColors.WindowText;
            this.hsComboBoxDevices.FormattingEnabled = true;
            this.hsComboBoxDevices.IntegralHeight = false;
            this.hsComboBoxDevices.ItemHeight = 20;
            this.hsComboBoxDevices.Location = new System.Drawing.Point(3, 3);
            this.hsComboBoxDevices.Name = "hsComboBoxDevices";
            this.hsComboBoxDevices.Size = new System.Drawing.Size(301, 28);
            this.hsComboBoxDevices.TabIndex = 19;
            // 
            // dateEnd
            // 
            this.dateEnd.CalendarFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateEnd.CustomFormat = "yyyy-MM-dd HH时";
            this.dateEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateEnd.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd.Location = new System.Drawing.Point(456, 3);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.ShowUpDown = true;
            this.dateEnd.Size = new System.Drawing.Size(142, 25);
            this.dateEnd.TabIndex = 9;
            // 
            // dateStart
            // 
            this.dateStart.CalendarFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateStart.CustomFormat = "yyyy-MM-dd HH时";
            this.dateStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateStart.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStart.Location = new System.Drawing.Point(310, 3);
            this.dateStart.Name = "dateStart";
            this.dateStart.ShowUpDown = true;
            this.dateStart.Size = new System.Drawing.Size(140, 25);
            this.dateStart.TabIndex = 7;
            // 
            // ucBtn_Search
            // 
            this.ucBtn_Search.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ucBtn_Search.BtnBackColor = System.Drawing.SystemColors.ButtonFace;
            this.ucBtn_Search.BtnFont = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_Search.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ucBtn_Search.BtnText = "查询";
            this.ucBtn_Search.ConerRadius = 5;
            this.ucBtn_Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_Search.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucBtn_Search.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtn_Search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ucBtn_Search.Image = ((System.Drawing.Image)(resources.GetObject("ucBtn_Search.Image")));
            this.ucBtn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ucBtn_Search.ImageFontIcons = null;
            this.ucBtn_Search.IsRadius = true;
            this.ucBtn_Search.IsShowRect = true;
            this.ucBtn_Search.IsShowTips = false;
            this.ucBtn_Search.Location = new System.Drawing.Point(601, 0);
            this.ucBtn_Search.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_Search.Name = "ucBtn_Search";
            this.ucBtn_Search.RectColor = System.Drawing.SystemColors.ActiveCaption;
            this.ucBtn_Search.RectWidth = 1;
            this.ucBtn_Search.Size = new System.Drawing.Size(54, 32);
            this.ucBtn_Search.TabIndex = 12;
            this.ucBtn_Search.TabStop = false;
            this.ucBtn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucBtn_Search.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_Search.TipsText = "";
            this.ucBtn_Search.BtnClick += new System.EventHandler(this.ucBtn_Search_BtnClick);
            // 
            // Search
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "Search";
            this.Size = new System.Drawing.Size(802, 32);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private Scada.Controls.Controls.UCBtnImg ucBtn_Search;
        private HsComboBox hsComboBoxDevices;
    }
}
