namespace GasMonitor
{
    partial class AlarmSet
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
            this.ulbChannelName = new Sunny.UI.UILabel();
            this.uiLine6 = new Sunny.UI.UILine();
            this.uudCOLow = new Sunny.UI.UIIntegerUpDown();
            this.uudCOHigh = new Sunny.UI.UIIntegerUpDown();
            this.uudH2SHigh = new Sunny.UI.UIIntegerUpDown();
            this.uudH2SLow = new Sunny.UI.UIIntegerUpDown();
            this.uudO2High = new Sunny.UI.UIIntegerUpDown();
            this.uudO2Low = new Sunny.UI.UIIntegerUpDown();
            this.uudCO2High = new Sunny.UI.UIIntegerUpDown();
            this.uudCO2Low = new Sunny.UI.UIIntegerUpDown();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiLine2 = new Sunny.UI.UILine();
            this.ubtSave = new Sunny.UI.UIButton();
            this.uiSymbolLabel8 = new Sunny.UI.UISymbolLabel();
            this.uiSymbolLabel9 = new Sunny.UI.UISymbolLabel();
            this.uiSymbolLabel10 = new Sunny.UI.UISymbolLabel();
            this.uiSymbolLabel7 = new Sunny.UI.UISymbolLabel();
            this.ucbCOEnable = new Sunny.UI.UICheckBox();
            this.ucbH2SEnable = new Sunny.UI.UICheckBox();
            this.ucbO2Enable = new Sunny.UI.UICheckBox();
            this.ucbCO2Enable = new Sunny.UI.UICheckBox();
            this.SuspendLayout();
            // 
            // ulbChannelName
            // 
            this.ulbChannelName.AutoSize = true;
            this.ulbChannelName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ulbChannelName.ForeColor = System.Drawing.Color.Silver;
            this.ulbChannelName.Location = new System.Drawing.Point(13, 9);
            this.ulbChannelName.Name = "ulbChannelName";
            this.ulbChannelName.Size = new System.Drawing.Size(84, 27);
            this.ulbChannelName.Style = Sunny.UI.UIStyle.Black;
            this.ulbChannelName.TabIndex = 95;
            this.ulbChannelName.Text = "1号通道";
            this.ulbChannelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine6
            // 
            this.uiLine6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine6.ForeColor = System.Drawing.Color.Silver;
            this.uiLine6.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine6.Location = new System.Drawing.Point(5, 49);
            this.uiLine6.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine6.Name = "uiLine6";
            this.uiLine6.Size = new System.Drawing.Size(92, 20);
            this.uiLine6.Style = Sunny.UI.UIStyle.Black;
            this.uiLine6.TabIndex = 96;
            this.uiLine6.Text = "报警设置";
            this.uiLine6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uudCOLow
            // 
            this.uudCOLow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uudCOLow.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uudCOLow.ForeColor = System.Drawing.Color.White;
            this.uudCOLow.Location = new System.Drawing.Point(100, 72);
            this.uudCOLow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uudCOLow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.uudCOLow.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uudCOLow.MinimumSize = new System.Drawing.Size(100, 0);
            this.uudCOLow.Name = "uudCOLow";
            this.uudCOLow.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uudCOLow.Size = new System.Drawing.Size(127, 29);
            this.uudCOLow.Style = Sunny.UI.UIStyle.Custom;
            this.uudCOLow.TabIndex = 101;
            this.uudCOLow.Text = null;
            this.uudCOLow.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uudCOLow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uudCOLow_MouseDown);
            // 
            // uudCOHigh
            // 
            this.uudCOHigh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uudCOHigh.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uudCOHigh.ForeColor = System.Drawing.Color.White;
            this.uudCOHigh.Location = new System.Drawing.Point(246, 72);
            this.uudCOHigh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uudCOHigh.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.uudCOHigh.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uudCOHigh.MinimumSize = new System.Drawing.Size(100, 0);
            this.uudCOHigh.Name = "uudCOHigh";
            this.uudCOHigh.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uudCOHigh.Size = new System.Drawing.Size(127, 29);
            this.uudCOHigh.Style = Sunny.UI.UIStyle.Custom;
            this.uudCOHigh.TabIndex = 102;
            this.uudCOHigh.Text = null;
            this.uudCOHigh.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uudCOHigh.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uudCOLow_MouseDown);
            // 
            // uudH2SHigh
            // 
            this.uudH2SHigh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uudH2SHigh.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uudH2SHigh.ForeColor = System.Drawing.Color.White;
            this.uudH2SHigh.Location = new System.Drawing.Point(246, 114);
            this.uudH2SHigh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uudH2SHigh.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.uudH2SHigh.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uudH2SHigh.MinimumSize = new System.Drawing.Size(100, 0);
            this.uudH2SHigh.Name = "uudH2SHigh";
            this.uudH2SHigh.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uudH2SHigh.Size = new System.Drawing.Size(127, 29);
            this.uudH2SHigh.Style = Sunny.UI.UIStyle.Custom;
            this.uudH2SHigh.TabIndex = 104;
            this.uudH2SHigh.Text = null;
            this.uudH2SHigh.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uudH2SHigh.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uudCOLow_MouseDown);
            // 
            // uudH2SLow
            // 
            this.uudH2SLow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uudH2SLow.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uudH2SLow.ForeColor = System.Drawing.Color.White;
            this.uudH2SLow.Location = new System.Drawing.Point(100, 114);
            this.uudH2SLow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uudH2SLow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.uudH2SLow.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uudH2SLow.MinimumSize = new System.Drawing.Size(100, 0);
            this.uudH2SLow.Name = "uudH2SLow";
            this.uudH2SLow.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uudH2SLow.Size = new System.Drawing.Size(127, 29);
            this.uudH2SLow.Style = Sunny.UI.UIStyle.Custom;
            this.uudH2SLow.TabIndex = 103;
            this.uudH2SLow.Text = null;
            this.uudH2SLow.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uudH2SLow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uudCOLow_MouseDown);
            // 
            // uudO2High
            // 
            this.uudO2High.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uudO2High.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uudO2High.ForeColor = System.Drawing.Color.White;
            this.uudO2High.Location = new System.Drawing.Point(246, 155);
            this.uudO2High.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uudO2High.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.uudO2High.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uudO2High.MinimumSize = new System.Drawing.Size(100, 0);
            this.uudO2High.Name = "uudO2High";
            this.uudO2High.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uudO2High.Size = new System.Drawing.Size(127, 29);
            this.uudO2High.Style = Sunny.UI.UIStyle.Custom;
            this.uudO2High.TabIndex = 106;
            this.uudO2High.Text = null;
            this.uudO2High.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uudO2High.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uudCOLow_MouseDown);
            // 
            // uudO2Low
            // 
            this.uudO2Low.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uudO2Low.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uudO2Low.ForeColor = System.Drawing.Color.White;
            this.uudO2Low.Location = new System.Drawing.Point(100, 155);
            this.uudO2Low.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uudO2Low.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.uudO2Low.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uudO2Low.MinimumSize = new System.Drawing.Size(100, 0);
            this.uudO2Low.Name = "uudO2Low";
            this.uudO2Low.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uudO2Low.Size = new System.Drawing.Size(127, 29);
            this.uudO2Low.Style = Sunny.UI.UIStyle.Custom;
            this.uudO2Low.TabIndex = 105;
            this.uudO2Low.Text = null;
            this.uudO2Low.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uudO2Low.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uudCOLow_MouseDown);
            // 
            // uudCO2High
            // 
            this.uudCO2High.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uudCO2High.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uudCO2High.ForeColor = System.Drawing.Color.White;
            this.uudCO2High.Location = new System.Drawing.Point(246, 196);
            this.uudCO2High.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uudCO2High.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.uudCO2High.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uudCO2High.MinimumSize = new System.Drawing.Size(100, 0);
            this.uudCO2High.Name = "uudCO2High";
            this.uudCO2High.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uudCO2High.Size = new System.Drawing.Size(127, 29);
            this.uudCO2High.Style = Sunny.UI.UIStyle.Custom;
            this.uudCO2High.TabIndex = 108;
            this.uudCO2High.Text = null;
            this.uudCO2High.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uudCO2High.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uudCOLow_MouseDown);
            // 
            // uudCO2Low
            // 
            this.uudCO2Low.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uudCO2Low.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uudCO2Low.ForeColor = System.Drawing.Color.White;
            this.uudCO2Low.Location = new System.Drawing.Point(100, 196);
            this.uudCO2Low.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uudCO2Low.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.uudCO2Low.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uudCO2Low.MinimumSize = new System.Drawing.Size(100, 0);
            this.uudCO2Low.Name = "uudCO2Low";
            this.uudCO2Low.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uudCO2Low.Size = new System.Drawing.Size(127, 29);
            this.uudCO2Low.Style = Sunny.UI.UIStyle.Custom;
            this.uudCO2Low.TabIndex = 107;
            this.uudCO2Low.Text = null;
            this.uudCO2Low.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uudCO2Low.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uudCOLow_MouseDown);
            // 
            // uiLine1
            // 
            this.uiLine1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine1.ForeColor = System.Drawing.Color.Silver;
            this.uiLine1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine1.Location = new System.Drawing.Point(120, 49);
            this.uiLine1.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(97, 20);
            this.uiLine1.Style = Sunny.UI.UIStyle.Black;
            this.uiLine1.TabIndex = 109;
            this.uiLine1.Text = "低点报警";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine2
            // 
            this.uiLine2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine2.ForeColor = System.Drawing.Color.Silver;
            this.uiLine2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.uiLine2.Location = new System.Drawing.Point(258, 49);
            this.uiLine2.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(97, 20);
            this.uiLine2.Style = Sunny.UI.UIStyle.Black;
            this.uiLine2.TabIndex = 110;
            this.uiLine2.Text = "高点报警";
            this.uiLine2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ubtSave
            // 
            this.ubtSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ubtSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.ubtSave.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.ubtSave.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.ubtSave.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.ubtSave.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ubtSave.Location = new System.Drawing.Point(361, 9);
            this.ubtSave.Name = "ubtSave";
            this.ubtSave.Radius = 35;
            this.ubtSave.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.ubtSave.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.ubtSave.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.ubtSave.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.ubtSave.Size = new System.Drawing.Size(100, 35);
            this.ubtSave.Style = Sunny.UI.UIStyle.Green;
            this.ubtSave.StyleCustomMode = true;
            this.ubtSave.TabIndex = 111;
            this.ubtSave.Text = "保存";
            this.ubtSave.Click += new System.EventHandler(this.ubtSave_Click);
            // 
            // uiSymbolLabel8
            // 
            this.uiSymbolLabel8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiSymbolLabel8.ForeColor = System.Drawing.Color.Silver;
            this.uiSymbolLabel8.Location = new System.Drawing.Point(16, 198);
            this.uiSymbolLabel8.Name = "uiSymbolLabel8";
            this.uiSymbolLabel8.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.uiSymbolLabel8.Size = new System.Drawing.Size(77, 24);
            this.uiSymbolLabel8.Style = Sunny.UI.UIStyle.Black;
            this.uiSymbolLabel8.Symbol = 61977;
            this.uiSymbolLabel8.SymbolColor = System.Drawing.Color.Silver;
            this.uiSymbolLabel8.TabIndex = 115;
            this.uiSymbolLabel8.Text = "CO2";
            this.uiSymbolLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolLabel9
            // 
            this.uiSymbolLabel9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiSymbolLabel9.ForeColor = System.Drawing.Color.Silver;
            this.uiSymbolLabel9.Location = new System.Drawing.Point(16, 157);
            this.uiSymbolLabel9.Name = "uiSymbolLabel9";
            this.uiSymbolLabel9.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.uiSymbolLabel9.Size = new System.Drawing.Size(77, 24);
            this.uiSymbolLabel9.Style = Sunny.UI.UIStyle.Black;
            this.uiSymbolLabel9.Symbol = 62149;
            this.uiSymbolLabel9.SymbolColor = System.Drawing.Color.Silver;
            this.uiSymbolLabel9.TabIndex = 114;
            this.uiSymbolLabel9.Text = "O2";
            this.uiSymbolLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolLabel10
            // 
            this.uiSymbolLabel10.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiSymbolLabel10.ForeColor = System.Drawing.Color.Silver;
            this.uiSymbolLabel10.Location = new System.Drawing.Point(15, 116);
            this.uiSymbolLabel10.Name = "uiSymbolLabel10";
            this.uiSymbolLabel10.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.uiSymbolLabel10.Size = new System.Drawing.Size(78, 24);
            this.uiSymbolLabel10.Style = Sunny.UI.UIStyle.Black;
            this.uiSymbolLabel10.Symbol = 61830;
            this.uiSymbolLabel10.SymbolColor = System.Drawing.Color.Silver;
            this.uiSymbolLabel10.TabIndex = 113;
            this.uiSymbolLabel10.Text = "H2S";
            this.uiSymbolLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolLabel7
            // 
            this.uiSymbolLabel7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiSymbolLabel7.ForeColor = System.Drawing.Color.Silver;
            this.uiSymbolLabel7.Location = new System.Drawing.Point(18, 74);
            this.uiSymbolLabel7.Name = "uiSymbolLabel7";
            this.uiSymbolLabel7.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.uiSymbolLabel7.Size = new System.Drawing.Size(75, 24);
            this.uiSymbolLabel7.Style = Sunny.UI.UIStyle.Black;
            this.uiSymbolLabel7.Symbol = 61969;
            this.uiSymbolLabel7.SymbolColor = System.Drawing.Color.Silver;
            this.uiSymbolLabel7.TabIndex = 112;
            this.uiSymbolLabel7.Text = "CO";
            this.uiSymbolLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucbCOEnable
            // 
            this.ucbCOEnable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucbCOEnable.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucbCOEnable.ForeColor = System.Drawing.Color.Silver;
            this.ucbCOEnable.Location = new System.Drawing.Point(380, 72);
            this.ucbCOEnable.Name = "ucbCOEnable";
            this.ucbCOEnable.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ucbCOEnable.Size = new System.Drawing.Size(81, 29);
            this.ucbCOEnable.Style = Sunny.UI.UIStyle.Black;
            this.ucbCOEnable.TabIndex = 116;
            this.ucbCOEnable.Text = "启用";
            // 
            // ucbH2SEnable
            // 
            this.ucbH2SEnable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucbH2SEnable.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucbH2SEnable.ForeColor = System.Drawing.Color.Silver;
            this.ucbH2SEnable.Location = new System.Drawing.Point(380, 114);
            this.ucbH2SEnable.Name = "ucbH2SEnable";
            this.ucbH2SEnable.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ucbH2SEnable.Size = new System.Drawing.Size(81, 29);
            this.ucbH2SEnable.Style = Sunny.UI.UIStyle.Black;
            this.ucbH2SEnable.TabIndex = 117;
            this.ucbH2SEnable.Text = "启用";
            // 
            // ucbO2Enable
            // 
            this.ucbO2Enable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucbO2Enable.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucbO2Enable.ForeColor = System.Drawing.Color.Silver;
            this.ucbO2Enable.Location = new System.Drawing.Point(380, 156);
            this.ucbO2Enable.Name = "ucbO2Enable";
            this.ucbO2Enable.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ucbO2Enable.Size = new System.Drawing.Size(81, 29);
            this.ucbO2Enable.Style = Sunny.UI.UIStyle.Black;
            this.ucbO2Enable.TabIndex = 118;
            this.ucbO2Enable.Text = "启用";
            // 
            // ucbCO2Enable
            // 
            this.ucbCO2Enable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucbCO2Enable.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucbCO2Enable.ForeColor = System.Drawing.Color.Silver;
            this.ucbCO2Enable.Location = new System.Drawing.Point(380, 196);
            this.ucbCO2Enable.Name = "ucbCO2Enable";
            this.ucbCO2Enable.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ucbCO2Enable.Size = new System.Drawing.Size(81, 29);
            this.ucbCO2Enable.Style = Sunny.UI.UIStyle.Black;
            this.ucbCO2Enable.TabIndex = 119;
            this.ucbCO2Enable.Text = "启用";
            // 
            // AlarmSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucbCO2Enable);
            this.Controls.Add(this.ucbO2Enable);
            this.Controls.Add(this.ucbH2SEnable);
            this.Controls.Add(this.ucbCOEnable);
            this.Controls.Add(this.uiSymbolLabel8);
            this.Controls.Add(this.uiSymbolLabel9);
            this.Controls.Add(this.uiSymbolLabel10);
            this.Controls.Add(this.uiSymbolLabel7);
            this.Controls.Add(this.ubtSave);
            this.Controls.Add(this.uiLine2);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.uudCO2High);
            this.Controls.Add(this.uudCO2Low);
            this.Controls.Add(this.uudO2High);
            this.Controls.Add(this.uudO2Low);
            this.Controls.Add(this.uudH2SHigh);
            this.Controls.Add(this.uudH2SLow);
            this.Controls.Add(this.uudCOHigh);
            this.Controls.Add(this.uudCOLow);
            this.Controls.Add(this.uiLine6);
            this.Controls.Add(this.ulbChannelName);
            this.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ForeColor = System.Drawing.Color.Silver;
            this.Name = "AlarmSet";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.Size = new System.Drawing.Size(490, 234);
            this.Style = Sunny.UI.UIStyle.Black;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILabel ulbChannelName;
        private Sunny.UI.UILine uiLine6;
        private Sunny.UI.UIIntegerUpDown uudCOLow;
        private Sunny.UI.UIIntegerUpDown uudCOHigh;
        private Sunny.UI.UIIntegerUpDown uudH2SHigh;
        private Sunny.UI.UIIntegerUpDown uudH2SLow;
        private Sunny.UI.UIIntegerUpDown uudO2High;
        private Sunny.UI.UIIntegerUpDown uudO2Low;
        private Sunny.UI.UIIntegerUpDown uudCO2High;
        private Sunny.UI.UIIntegerUpDown uudCO2Low;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UIButton ubtSave;
        private Sunny.UI.UISymbolLabel uiSymbolLabel8;
        private Sunny.UI.UISymbolLabel uiSymbolLabel9;
        private Sunny.UI.UISymbolLabel uiSymbolLabel10;
        private Sunny.UI.UISymbolLabel uiSymbolLabel7;
        private Sunny.UI.UICheckBox ucbCOEnable;
        private Sunny.UI.UICheckBox ucbH2SEnable;
        private Sunny.UI.UICheckBox ucbO2Enable;
        private Sunny.UI.UICheckBox ucbCO2Enable;
    }
}
