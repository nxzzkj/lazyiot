using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Scada.Controls
{
    [ToolboxItem(true)]
    [Description("颜色选择美化控件")]
    [DefaultProperty("ColorPicker")]
    [Designer(typeof(ColorExtDesigner))]
    public class ColorExtCtrl : Control
    {
        #region 停用事件

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler PaddingChanged
        {
            add { base.PaddingChanged += value; }
            remove { base.PaddingChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TextChanged
        {
            add { base.TextChanged += value; }
            remove { base.TextChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler RightToLeftChanged
        {
            add { base.RightToLeftChanged += value; }
            remove { base.RightToLeftChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ImeModeChanged
        {
            add { base.ImeModeChanged += value; }
            remove { base.ImeModeChanged -= value; }
        }

        #endregion

        #region 新增属性

        private bool readOnly = false;
        [DefaultValue(false)]
        [Description("是否只读")]
        public bool ReadOnly
        {
            get { return this.readOnly; }
            set
            {
                if (this.readOnly == value)
                    return;
                this.readOnly = value;
            }
        }

        private bool borderShow = true;
        [DefaultValue(true)]
        [Description("是否显示边框")]
        public bool BorderShow
        {
            get { return this.borderShow; }
            set
            {
                if (this.borderShow == value)
                    return;
                this.borderShow = value;
                this.Invalidate();
            }
        }

        private Color borderColor = Color.FromArgb(192, 192, 192);
        [DefaultValue(typeof(Color), "192, 192, 192")]
        [Description("边框颜色")]
        public Color BorderColor
        {
            get { return this.borderColor; }
            set
            {
                if (this.borderColor == value)
                    return;
                this.borderColor = value;
                this.Invalidate();
            }
        }

        private ColorImageAligns colorImageAlign = ColorImageAligns.Right;
        [DefaultValue(ColorImageAligns.Right)]
        [Description("颜色图片位置")]
        public ColorImageAligns ColorImageAlign
        {
            get { return this.colorImageAlign; }
            set
            {
                if (this.colorImageAlign == value)
                    return;
                this.colorImageAlign = value;
                this.Invalidate();
                this.UpdateLocationSize();
            }
        }

        private ColorTextAligns colorTextAlign = ColorTextAligns.Right;
        [DefaultValue(ColorTextAligns.Right)]
        [Description("颜色文本位置")]
        public ColorTextAligns ColorTextAlign
        {
            get { return this.colorTextAlign; }
            set
            {
                if (this.colorTextAlign == value)
                    return;
                this.colorTextAlign = value;
                this.colorTextBox.TextAlign = (value == ColorTextAligns.Left) ? HorizontalAlignment.Left : HorizontalAlignment.Right;
                if (this.ColorStyle == ColorStyles.ColorPanel)
                {
                    this.Invalidate();
                }
            }
        }

        private ColorStyles colorStyle = ColorStyles.Editor;
        [DefaultValue(ColorStyles.Editor)]
        [Description("颜色输入框类型")]
        public ColorStyles ColorStyle
        {
            get { return this.colorStyle; }
            set
            {
                if (this.colorStyle == value)
                    return;
                this.colorStyle = value;
                this.UpdateColorStyle();
                this.Invalidate();
                this.UpdateLocationSize();
            }
        }

        private ColorPickerExt colorPicker = null;
        [Browsable(true)]
        [Description("颜色选择面板")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorPickerExt ColorPicker
        {
            get { return this.colorPicker; }
            set { this.colorPicker = value; }
        }

        #endregion

        #region 重写属性

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new bool DesignMode
        {
            get
            {
                if (this.GetService(typeof(IDesignerHost)) != null || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [DefaultValue(typeof(Color), "255,255,255")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                this.colorTextBox.BackColor = value;
                this.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "105, 105, 105")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                this.colorTextBox.ForeColor = value;
                this.Invalidate();
            }
        }

        protected override Cursor DefaultCursor
        {
            get
            {
                return Cursors.Default;
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(130, 24);
            }
        }

        protected override ImeMode DefaultImeMode
        {
            get
            {
                return System.Windows.Forms.ImeMode.Disable;
            }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get
            {
                return base.Padding;
            }
            set
            {
                base.Padding = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode
        {
            get
            {
                return base.ImeMode;
            }
            set
            {
                base.ImeMode = value;
            }
        }

        #endregion

        #region 字段

        protected bool activatedState = false;



        private bool displayStatus = false;

        private ToolStripDropDown tsdd = null;

        private ToolStripControlHost tsch = null;

        private ColorTextBox colorTextBox = new ColorTextBox();

        private int image_width = 18;

        private int image_height = 18;

        private int image_padding = 2;

        private int border = 1;

        private string colorstr = null;

        private Rectangle image_rect = Rectangle.Empty;
        private Rectangle color_rect = Rectangle.Empty;
        #endregion

        public ColorExtCtrl()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ContainerControl, true);

            this.BackColor = Color.FromArgb(255, 255, 255);
            this.ForeColor = Color.FromArgb(105, 105, 105);
            this.Font = new Font("微软雅黑", 9);

            this.ColorPicker = new ColorPickerExt();

            this.tsdd = new ToolStripDropDown() { Padding = Padding.Empty };
            this.tsch = new ToolStripControlHost(this.ColorPicker) { Margin = Padding.Empty, Padding = Padding.Empty };
            tsdd.Items.Add(this.tsch);

            this.tsdd.Closed += new ToolStripDropDownClosedEventHandler(this.tsdd_Closed);
            this.ColorPicker.BottomBarConfirmClick += new ColorPickerExt.BottomBarIiemClickEventHandler(this.ColorPicker_ConfirmClick);
            this.ColorPicker.BottomBarClearClick += new ColorPickerExt.BottomBarIiemClickEventHandler(this.ColorPicker_ClearClick);
            this.ColorPicker.ColorValueChanged += new ColorPickerExt.ColorValueChangedEventHandler(this.ColorPicker_ValueChanged);

            this.colorTextBox.LostFocus += new EventHandler(this.colorTextBox_LostFocus);
            this.colorTextBox.TextChanged += new EventHandler(this.colorTextBox_TextChanged);
            this.Controls.Add(this.colorTextBox);

            this.UpdateLocationSize();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            #region 控件激活状态虚线框
            if (this.ColorStyle == ColorStyles.ColorPanel && this.activatedState)
            {
                Pen backborder_pen = new Pen(this.BorderColor, 1);
                backborder_pen.DashStyle = DashStyle.Dash;
                Rectangle rect = new Rectangle(this.ClientRectangle.X + 2, this.ClientRectangle.Y + 2, this.ClientRectangle.Width - 4 - this.border, this.ClientRectangle.Height - 4 - this.border);
                g.DrawRectangle(backborder_pen, rect);
                backborder_pen.Dispose();
            }
            #endregion

            #region 图片、文本


            SolidBrush argb_sb = new SolidBrush(this.ColorPicker.ColorValue);
            g.FillRectangle(argb_sb, image_rect);
            argb_sb.Dispose();


            if (this.ColorStyle == ColorStyles.ColorPanel)
            {
                string argb_format = this.colorstr;
                SolidBrush color_sb = new SolidBrush(this.ForeColor);
                StringFormat color_sf = new StringFormat() { Alignment = (this.ColorTextAlign == ColorTextAligns.Left ? StringAlignment.Near : StringAlignment.Far), LineAlignment = StringAlignment.Center, Trimming = StringTrimming.None, FormatFlags = StringFormatFlags.NoWrap };
                g.DrawString(argb_format, this.Font, color_sb, new Rectangle(color_rect.X, color_rect.Y, color_rect.Width - 2, color_rect.Height), color_sf);
                color_sb.Dispose();
                color_sf.Dispose();
            }
            #endregion

            #region 边框
            if (this.BorderShow)
            {
                Pen backborder_pen = new Pen(this.BorderColor, 1);
                g.DrawRectangle(backborder_pen, new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1));
                backborder_pen.Dispose();
            }
            #endregion

        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            this.activatedState = true;
            if (this.ColorStyle == ColorStyles.ColorPanel)
            {
                this.Invalidate();
            }
            else
            {
                this.colorTextBox.Select();
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            this.activatedState = false;
            if (this.ColorStyle == ColorStyles.ColorPanel)
            {
                this.Invalidate();
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            this.activatedState = true;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            this.activatedState = false;
            if (this.displayStatus == true)
            {
                this.tsdd.Close();
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.DesignMode)
            {
                return base.ProcessDialogKey(keyData);
            }

            if (this.ReadOnly)
                return true;

            if (this.activatedState)
            {
                #region Enter
                if (keyData == Keys.Enter)
                {
                    this.OnMouseClick(new MouseEventArgs(MouseButtons.Left, 1, this.Location.X + this.Width / 2, this.Location.Y + this.Height / 2, 0));
                    return false;
                }
                #endregion
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            if (this.ColorStyle == ColorStyles.Editor)
            {
                Point point = this.PointToClient(Control.MousePosition);
                if (this.image_rect.Contains(point))
                {
                    if (this.Cursor != Cursors.Hand)
                        this.Cursor = Cursors.Hand;
                }
                else
                {
                    if (this.Cursor != Cursors.Default)
                        this.Cursor = Cursors.Default;
                }
            }
            else
            {
                if (this.Cursor != Cursors.Hand)
                    this.Cursor = Cursors.Hand;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            if (this.ColorStyle == ColorStyles.Editor)
            {
                Point point = this.PointToClient(Control.MousePosition);
                if (this.image_rect.Contains(point))
                {
                    if (this.Cursor != Cursors.Hand)
                        this.Cursor = Cursors.Hand;
                }
                else
                {
                    if (this.Cursor != Cursors.Default)
                        this.Cursor = Cursors.Default;
                }
            }
            else
            {
                if (this.Cursor != Cursors.Hand)
                    this.Cursor = Cursors.Hand;
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            this.Select();

            if (e.Button == MouseButtons.Left)
            {
                if (!this.displayStatus)
                {
                    tsdd.Show(this.PointToScreen(new Point(0, this.Height + 2)));
                    this.ColorPicker.InitializeColor();
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.UpdateLocationSize();
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, this.DefaultSize.Height, specified);
            this.Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.ColorPicker != null)
                    this.ColorPicker.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 私有方法

        #region 颜色面板事件

        private void ColorPicker_ClearClick(object sender, EventArgs e)
        {
            this.SetLocalColorByColorPicker(this.ColorPicker.ColorValue);
            this.Select();
            this.tsdd.Close();
        }

        private void ColorPicker_ConfirmClick(object sender, EventArgs e)
        {
            this.SetLocalColorByColorPicker(this.ColorPicker.ColorValue);
            this.Select();
            this.tsdd.Close();
        }

        private void ColorPicker_ValueChanged(object sender, EventArgs e)
        {
            this.SetLocalColorByColorPicker(this.ColorPicker.ColorValue);
            this.UpdateLocalColorUI();
        }

        private void tsdd_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.displayStatus = false;
            this.Invalidate();
        }

        #endregion

        #region 日期输入框 事件

        private void colorTextBox_LostFocus(object sender, EventArgs e)
        {
            Color? color = this.ColorPicker.ValidColor(this.colorTextBox.Text);
            if (color.HasValue)
            {
                this.ColorPicker.UpdateDateValueNotInvalidate(color.Value);
            }
            else
            {
                this.SetLocalColorByColorPicker(this.ColorPicker.ColorValue);
                this.UpdateLocalColorUI();
            }
        }

        private void colorTextBox_TextChanged(object sender, EventArgs e)
        {
            Color? color = this.ColorPicker.ValidColor(this.colorTextBox.Text);
            if (color.HasValue)
            {
                this.ColorPicker.UpdateDateValueNotInvalidate(color.Value);
            }
        }

        #endregion

        private void UpdateLocationSize()
        {
            this.colorTextBox.Height = this.DefaultSize.Height - 6;
            this.colorTextBox.Width = this.Width - this.image_width - this.image_padding * 2 - this.border * 2 - 2;
            this.colorTextBox.Location = this.ColorImageAlign == ColorImageAligns.Left ? new Point(this.image_width + this.image_padding * 2 + this.border * 2, 3) : new Point(this.border + 2, 3);

            if (this.ColorImageAlign == ColorImageAligns.Right)
            {
                this.image_rect = new Rectangle(this.ClientRectangle.Right - this.image_width - this.image_padding * 2, this.ClientRectangle.Y + (this.ClientRectangle.Height - this.image_height) / 2, this.image_width, this.image_height);
                this.color_rect = new Rectangle(this.ClientRectangle.X + this.border, this.ClientRectangle.Y, this.ClientRectangle.Width - this.image_width - this.image_padding * 2 - this.border * 2, this.ClientRectangle.Height);

            }
            else
            {
                this.image_rect = new Rectangle(this.ClientRectangle.X + this.image_padding + this.border, this.ClientRectangle.Y + (this.ClientRectangle.Height - this.image_height) / 2, this.image_width, this.image_height);
                this.color_rect = new Rectangle(this.ClientRectangle.X + this.image_width + this.image_padding * 2, this.ClientRectangle.Y, this.ClientRectangle.Width - this.image_width - this.image_padding * 2 - this.border * 2, this.ClientRectangle.Height);
            }
        }

        private void UpdateColorStyle()
        {
            if (this.ColorStyle == ColorStyles.Editor)
            {
                this.colorTextBox.Enabled = true;
                this.colorTextBox.Visible = true;
            }
            else
            {
                this.colorTextBox.Enabled = false;
                this.colorTextBox.Visible = false;
            }

        }

        private void SetLocalColorByColorPicker(Color? color)
        {
            this.colorstr = String.Format("{0},{1},{2},{3}", color.Value.A, color.Value.R, color.Value.G, color.Value.B);
        }

        private void UpdateLocalColorUI()
        {
            this.colorTextBox.Text = this.colorstr;

            this.Invalidate();
        }

        #endregion

        #region 枚举

        [Description("颜色图片位置")]
        public enum ColorImageAligns
        {
            Left,
            Right
        }

        [Description("颜色文本位置")]
        public enum ColorTextAligns
        {
            Left,
            Right
        }

        [Description("颜色输入框类型")]
        public enum ColorStyles
        {
            Editor,
            ColorPanel
        }

        #endregion
    }

    [ToolboxItem(true)]
    [Description("颜色面板美化控件")]
    [DefaultProperty("ColorValue")]
    [DefaultEvent("BottomBarConfirmClick")]
    [Designer(typeof(ColorPickerExtDesigner))]
    [TypeConverter(typeof(EmptyConverter))]
    public class ColorPickerExt : Control
    {
        #region 新增事件

        public delegate void ColorValueChangedEventHandler(object sender, ColorValueChangedEventArgs e);

        private event ColorValueChangedEventHandler colorValueChanged;
        [Description("颜色值更改事件")]
        public event ColorValueChangedEventHandler ColorValueChanged
        {
            add { this.colorValueChanged += value; }
            remove { this.colorValueChanged -= value; }
        }

        public delegate void HtmlColorItemClickEventHandler(object sender, HtmlColorItemClickEventArgs e);

        private event HtmlColorItemClickEventHandler htmlColorItemClick;
        [Description("html颜色面板选项单击事件")]
        public event HtmlColorItemClickEventHandler HtmlColorItemClick
        {
            add { this.htmlColorItemClick += value; }
            remove { this.htmlColorItemClick -= value; }
        }

        public delegate void ColorItemClickEventHandler(object sender, ColorItemClickEventArgs e);

        private event ColorItemClickEventHandler themeColorItemClick;
        [Description("主题颜色面板选项单击事件")]
        public event ColorItemClickEventHandler ThemeColorItemClick
        {
            add { this.themeColorItemClick += value; }
            remove { this.themeColorItemClick -= value; }
        }

        private event ColorItemClickEventHandler standardColorItemClick;
        [Description("标准颜色面板选项单击事件")]
        public event ColorItemClickEventHandler StandardColorItemClick
        {
            add { this.standardColorItemClick += value; }
            remove { this.standardColorItemClick -= value; }
        }

        private event ColorItemClickEventHandler customColorItemClick;
        [Description("自定义颜色面板选项单击事件")]
        public event ColorItemClickEventHandler CustomColorItemClick
        {
            add { this.customColorItemClick += value; }
            remove { this.customColorItemClick -= value; }
        }

        #region 底部选项

        public delegate void BottomBarIiemClickEventHandler(object sender, BottomBarIiemClickEventArgs e);

        private event BottomBarIiemClickEventHandler bottomBarCustomClick;
        [Description("自定义颜色单击事件")]
        public event BottomBarIiemClickEventHandler BottomBarCustomClick
        {
            add { this.bottomBarCustomClick += value; }
            remove { this.bottomBarCustomClick -= value; }
        }

        private event BottomBarIiemClickEventHandler bottomBarClearClick;
        [Description("清除单击事件")]
        public event BottomBarIiemClickEventHandler BottomBarClearClick
        {
            add { this.bottomBarClearClick += value; }
            remove { this.bottomBarClearClick -= value; }
        }

        private event BottomBarIiemClickEventHandler bottomBarConfirmClick;
        [Description("确认单击事件")]
        public event BottomBarIiemClickEventHandler BottomBarConfirmClick
        {
            add { this.bottomBarConfirmClick += value; }
            remove { this.bottomBarConfirmClick -= value; }
        }
        #endregion

        #endregion



        #region 新增属性

        private bool colorReadOnly = false;
        [DefaultValue(false)]
        [Description("颜色面板是否只读")]
        public bool ColorReadOnly
        {
            get { return this.colorReadOnly; }
            set
            {
                if (this.colorReadOnly == value)
                    return;
                this.colorReadOnly = value;
                this.Invalidate();
            }
        }

        private bool colorInput = true;
        [DefaultValue(true)]
        [Description("是否允许颜色输入框输入")]
        public bool ColorInput
        {
            get { return this.colorInput; }
            set
            {
                if (this.colorInput == value)
                    return;
                this.colorInput = value;
                this.colorTextBox.Enabled = value;
            }
        }

        private colorTypes colorType = colorTypes.Default;
        [DefaultValue(colorTypes.Default)]
        [Description("颜色面板选中类型")]
        public colorTypes ColorType
        {
            get { return this.colorType; }
            set
            {
                if (this.colorType == value)
                    return;
                this.colorType = value;
                this.Invalidate();
            }
        }

        private Color topBarBtnForeColor = Color.FromArgb(158, 158, 158);
        [DefaultValue(typeof(Color), "158, 158, 158")]
        [Description("顶部按钮字体颜色(正常)")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TopBarBtnForeColor
        {
            get { return this.topBarBtnForeColor; }
            set
            {
                if (this.topBarBtnForeColor == value)
                    return;
                this.topBarBtnForeColor = value;
                this.Invalidate();
            }
        }

        private Color topBarBtnForeSelectColor = Color.FromArgb(153, 204, 204);
        [DefaultValue(typeof(Color), "153, 204, 204")]
        [Description("顶部按钮字体颜色(选中)")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TopBarBtnForeSelectColor
        {
            get { return this.topBarBtnForeSelectColor; }
            set
            {
                if (this.topBarBtnForeSelectColor == value)
                    return;
                this.topBarBtnForeSelectColor = value;
                this.Invalidate();
            }
        }

        private Color themeTitleForeColor = Color.FromArgb(153, 204, 204);
        [DefaultValue(typeof(Color), "153, 204, 204")]
        [Description("主题颜色标题字体颜色")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color ThemeTitleForeColor
        {
            get { return this.themeTitleForeColor; }
            set
            {
                if (this.themeTitleForeColor == value)
                    return;
                this.themeTitleForeColor = value;
                this.Invalidate();
            }
        }

        private Color standardTitleForeColor = Color.FromArgb(153, 204, 204);
        [DefaultValue(typeof(Color), "153, 204, 204")]
        [Description("标准颜色标题字体颜色")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color StandardTitleForeColor
        {
            get { return this.standardTitleForeColor; }
            set
            {
                if (this.standardTitleForeColor == value)
                    return;
                this.standardTitleForeColor = value;
                this.Invalidate();
            }
        }

        private Color customTitleForeColor = Color.FromArgb(153, 204, 204);
        [DefaultValue(typeof(Color), "153, 204, 204")]
        [Description("自定义颜色标题字体颜色")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color CustomTitleForeColor
        {
            get { return this.customTitleForeColor; }
            set
            {
                if (this.customTitleForeColor == value)
                    return;
                this.customTitleForeColor = value;
                this.Invalidate();
            }
        }

        private Color customSelectLineColor = Color.FromArgb(107, 142, 35);
        [DefaultValue(typeof(Color), "107, 142, 35")]
        [Description("自定义颜色选中颜色")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color CustomSelectLineColor
        {
            get { return this.customSelectLineColor; }
            set
            {
                if (this.customSelectLineColor == value)
                    return;
                this.customSelectLineColor = value;
                this.Invalidate();
            }
        }

        private Color currentTextForeColor = Color.FromArgb(105, 105, 105);
        [DefaultValue(typeof(Color), "105, 105, 105")]
        [Description("当前颜色字体颜色")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color CurrentTextForeColor
        {
            get { return this.currentTextForeColor; }
            set
            {
                if (this.currentTextForeColor == value)
                    return;
                this.currentTextForeColor = value;
                this.Invalidate();
            }
        }

        #region 底部按钮
        private Color bottomBarBtnBackColor = Color.FromArgb(153, 204, 204);
        [DefaultValue(typeof(Color), "153, 204, 204")]
        [Description("底部按钮背景颜色(正常)")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color BottomBarBtnBackColor
        {
            get { return this.bottomBarBtnBackColor; }
            set
            {
                if (this.bottomBarBtnBackColor == value)
                    return;
                this.bottomBarBtnBackColor = value;
                this.Invalidate();
            }
        }

        private Color bottomBarBtnForeColor = Color.FromArgb(255, 255, 255);
        [DefaultValue(typeof(Color), "255,255,255")]
        [Description("底部按钮字体颜色(正常)")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color BottomBarBtnForeColor
        {
            get { return this.bottomBarBtnForeColor; }
            set
            {
                if (this.bottomBarBtnForeColor == value)
                    return;
                this.bottomBarBtnForeColor = value;
                this.Invalidate();
            }
        }

        private Color bottomBarBtnBackDisabledColor = Color.FromArgb(170, 192, 192, 192);
        [DefaultValue(typeof(Color), "170, 192, 192, 192")]
        [Description("底部按钮背景颜色(禁用)")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color BottomBarBtnBackDisabledColor
        {
            get { return this.bottomBarBtnBackDisabledColor; }
            set
            {
                if (this.bottomBarBtnBackDisabledColor == value)
                    return;
                this.bottomBarBtnBackDisabledColor = value;
                this.Invalidate();
            }
        }

        private Color bottomBarBtnForeDisabledColor = Color.FromArgb(170, 255, 255, 255);
        [DefaultValue(typeof(Color), "170, 255, 255, 255")]
        [Description("底部按钮字体颜色(禁用)")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color BottomBarBtnForeDisabledColor
        {
            get { return this.bottomBarBtnForeDisabledColor; }
            set
            {
                if (this.bottomBarBtnForeDisabledColor == value)
                    return;
                this.bottomBarBtnForeDisabledColor = value;
                this.Invalidate();
            }
        }

        private Color bottomBarBtnBackEnterColor = Color.FromArgb(200, 153, 204, 204);
        [DefaultValue(typeof(Color), "200, 153, 204, 204")]
        [Description("底部按钮背景颜色(鼠标进入)")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color BottomBarBtnBackEnterColor
        {
            get { return this.bottomBarBtnBackEnterColor; }
            set
            {
                if (this.bottomBarBtnBackEnterColor == value)
                    return;
                this.bottomBarBtnBackEnterColor = value;
                this.Invalidate();
            }
        }

        private Color bottomBarBtnForeEnterColor = Color.FromArgb(200, 255, 255, 255);
        [DefaultValue(typeof(Color), "200,255,255,255")]
        [Description("底部按钮字体颜色(鼠标进入)")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color BottomBarBtnForeEnterColor
        {
            get { return this.bottomBarBtnForeEnterColor; }
            set
            {
                if (this.bottomBarBtnForeEnterColor == value)
                    return;
                this.bottomBarBtnForeEnterColor = value;
                this.Invalidate();
            }
        }

        #endregion

        private Color colorValue = Color.Empty;
        [DefaultValue(typeof(Color), "Empty")]
        [Description("颜色")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color ColorValue
        {
            get { return this.colorValue; }
            set
            {
                if (this.colorValue == value)
                    return;
                currentValue = value;
                ColorValueChangedEventArgs arg = new ColorValueChangedEventArgs() { OldColorValue = this.colorValue, NewColorValue = value };

                this.colorValue = value;

                this.OnColorValueChanged(arg);
            }
        }

        #endregion

        #region  重写属性

        protected new bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
                this.Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new bool DesignMode
        {
            get
            {
                if (this.GetService(typeof(IDesignerHost)) != null || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [DefaultValue(typeof(Color), "255, 255, 255")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        [DefaultValue(typeof(Padding), "5,5,5,5")]
        [Description("控件默认内边距")]
        protected override Padding DefaultPadding
        {
            get
            {
                return new Padding(5, 5, 5, 5);
            }
        }

        [DefaultValue(typeof(Size), "465, 285")]
        [Description("控件默认大小")]
        protected override Size DefaultSize
        {
            get
            {
                return new Size(465, 330);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ImeMode DefaultImeMode
        {
            get
            {
                return System.Windows.Forms.ImeMode.Disable;
            }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int TabIndex
        {
            get { return 0; }
            set { base.TabIndex = 0; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool TabStop
        {
            get { return false; }
            set { base.TabStop = false; }
        }

        [DefaultValue(DockStyle.None)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override DockStyle Dock
        {
            get
            {
                return DockStyle.None;
            }
            set
            {
                base.Dock = DockStyle.None;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Size MinimumSize
        {
            get
            {
                return base.MinimumSize;
            }
            set
            {
                base.MinimumSize = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Size MaximumSize
        {
            get
            {
                return base.MaximumSize;
            }
            set
            {
                base.MaximumSize = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode
        {
            get
            {
                return base.ImeMode;
            }
            set
            {
                base.ImeMode = value;
            }
        }

        #endregion

        #region 字段


        private Color border_slide_back_color;
        private Color gradual_color;
        private Color defaultColorValue = Color.Empty;
        private Color currentValue = Color.Empty;
        private Bitmap gradual_bmp;
        private Bitmap gradual_bar_bmp;
        private ColorMoveStatuss colorMoveStatus = ColorMoveStatuss.Normal;
        private ColorClass ColorObject;
        private int custom_select_row_index = 0;
        private int custom_select_cel_index = 0;

        private static readonly StringFormat text_left_sf = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip };
        private static readonly StringFormat text_center_sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip };
        private static readonly StringFormat text_right_sf = new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip };

        private int colorTextWidth = 100;

        private ColorTextBox colorTextBox = new ColorTextBox();

        private SolidBrushManage SolidBrushManageObject;

        #endregion

        public ColorPickerExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ContainerControl, true);

            this.BackColor = Color.FromArgb(255, 255, 255);
            this.border_slide_back_color = Color.FromArgb(200, 255, 255, 255);

            this.ColorObject = new ColorClass(this);
            this.InitializeControlRectangle();

            this.SolidBrushManageObject = new SolidBrushManage(this);

            this.gradual_bmp = new Bitmap(this.ColorObject.GradualRect.Width, this.ColorObject.GradualRect.Height);
            this.gradual_bar_bmp = new Bitmap(this.ColorObject.GradualBarRect.Width, this.ColorObject.GradualBarRect.Height);

            this.Update_GradualBar_Image();

            this.colorTextBox.TextAlign = HorizontalAlignment.Left;
            this.colorTextBox.LostFocus += new EventHandler(this.colorTextBox_LostFocus);
            this.colorTextBox.TextChanged += new EventHandler(this.colorTextBox_TextChanged);
            this.Controls.Add(this.colorTextBox);
            this.UpdateLocationSize();

            this.InitializeColor();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            #region 背景
            this.SolidBrushManageObject.common_sb.Color = this.BackColor;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, g.ClipBounds);
            #endregion

            #region 顶部按钮
            Color top_defaultcolorbtn_fore_color = (this.ColorType == colorTypes.Default) ? this.TopBarBtnForeSelectColor : this.TopBarBtnForeColor;
            this.SolidBrushManageObject.common_sb.Color = top_defaultcolorbtn_fore_color;
            g.DrawString(this.ColorObject.DefaultColorBtn.Text, this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.DefaultColorBtn.Rect, text_center_sf);
            if (this.ColorType == colorTypes.Default)
            {
                g.DrawLines(this.SolidBrushManageObject.border_pen, new Point[] {
                new Point(this.ColorObject.ColorRect.X, this.ColorObject.DefaultColorBtn.Rect.Bottom),
                new Point(this.ColorObject.DefaultColorBtn.Rect.Left, this.ColorObject.DefaultColorBtn.Rect.Bottom),
                new Point(this.ColorObject.DefaultColorBtn.Rect.Left, this.ColorObject.DefaultColorBtn.Rect.Top),
                new Point(this.ColorObject.DefaultColorBtn.Rect.Right, this.ColorObject.DefaultColorBtn.Rect.Top),
                new Point(this.ColorObject.DefaultColorBtn.Rect.Right, this.ColorObject.DefaultColorBtn.Rect.Bottom),
                new Point(this.ColorObject.ColorRect.Right, this.ColorObject.DefaultColorBtn.Rect.Bottom)});
            }

            Color top_htmlcolorbtn_fore_color = (this.ColorType == colorTypes.Html) ? this.TopBarBtnForeSelectColor : this.TopBarBtnForeColor;
            this.SolidBrushManageObject.common_sb.Color = top_htmlcolorbtn_fore_color;
            g.DrawString(this.ColorObject.HtmlColorBtn.Text, this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.HtmlColorBtn.Rect, text_center_sf);
            if (this.ColorType == colorTypes.Html)
            {
                g.DrawLines(this.SolidBrushManageObject.border_pen, new Point[] {
                new Point(this.ColorObject.ColorRect.X, this.ColorObject.HtmlColorBtn.Rect.Bottom),
                new Point(this.ColorObject.HtmlColorBtn.Rect.Left, this.ColorObject.HtmlColorBtn.Rect.Bottom),
                new Point(this.ColorObject.HtmlColorBtn.Rect.Left, this.ColorObject.HtmlColorBtn.Rect.Top),
                new Point(this.ColorObject.HtmlColorBtn.Rect.Right, this.ColorObject.HtmlColorBtn.Rect.Top),
                new Point(this.ColorObject.HtmlColorBtn.Rect.Right, this.ColorObject.HtmlColorBtn.Rect.Bottom),
                new Point(this.ColorObject.ColorRect.Right, this.ColorObject.HtmlColorBtn.Rect.Bottom)});
            }
            #endregion

            #region 颜色面板
            if (this.ColorType == colorTypes.Default)
            {
                #region 主题颜色
                this.SolidBrushManageObject.common_sb.Color = this.ThemeTitleForeColor;
                g.DrawString("主题颜色", this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.ThemeTitleRect, text_left_sf);
                ColorItemClass theme_colors_item_enter = null;
                for (int i = 0; i < this.ColorObject.ThemeColorsItem.GetLength(0); i++)
                {
                    for (int j = 0; j < this.ColorObject.ThemeColorsItem.GetLength(1); j++)
                    {
                        this.SolidBrushManageObject.common_sb.Color = ColorManage.ThemeColors[i, j];
                        g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.ThemeColorsItem[i, j].Rect);
                        if (this.ColorObject.ThemeColorsItem[i, j].MoveStatus == ColorItemMoveStatuss.Enter)
                        {
                            theme_colors_item_enter = this.ColorObject.ThemeColorsItem[i, j];
                        }
                    }
                }
                if (theme_colors_item_enter != null)
                {
                    Rectangle rect = new Rectangle(theme_colors_item_enter.Rect.X - 1, theme_colors_item_enter.Rect.Y - 1, theme_colors_item_enter.Rect.Width + 1, theme_colors_item_enter.Rect.Height + 1);
                    g.DrawRectangle(this.SolidBrushManageObject.border_ts_pen, rect);
                }
                #endregion

                #region 标准颜色
                this.SolidBrushManageObject.common_sb.Color = this.StandardTitleForeColor;
                g.DrawString("标准颜色", this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.StandardTitleRect, text_left_sf);
                for (int i = 0; i < this.ColorObject.StandardColorsItem.GetLength(0); i++)
                {
                    for (int j = 0; j < this.ColorObject.StandardColorsItem.GetLength(1); j++)
                    {
                        this.SolidBrushManageObject.common_sb.Color = ColorManage.StandardColors[i, j];
                        g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.StandardColorsItem[i, j].Rect);
                        if (this.ColorObject.StandardColorsItem[i, j].MoveStatus == ColorItemMoveStatuss.Enter)
                        {
                            Rectangle rect = new Rectangle(this.ColorObject.StandardColorsItem[i, j].Rect.X - 1, this.ColorObject.StandardColorsItem[i, j].Rect.Y - 1, this.ColorObject.StandardColorsItem[i, j].Rect.Width + 1, this.ColorObject.StandardColorsItem[i, j].Rect.Height + 1);
                            g.DrawRectangle(this.SolidBrushManageObject.border_ts_pen, rect);
                        }
                    }
                }
                #endregion
            }
            else if (this.ColorType == colorTypes.Html)
            {
                #region html颜色
                for (int i = 0; i < this.ColorObject.HtmlColorsItem.Count; i++)
                {
                    for (int j = 0; j < this.ColorObject.HtmlColorsItem[i].ColorsRects.Count; j++)
                    {
                        this.SolidBrushManageObject.common_sb.Color = ColorManage.HtmlColors[i].Colors[j];
                        g.FillPolygon(this.SolidBrushManageObject.common_sb, this.ColorObject.HtmlColorsItem[i].ColorsRects[j].pointfs);
                    }
                }
                #endregion
            }
            #endregion

            #region 自定义颜色
            this.SolidBrushManageObject.common_sb.Color = this.CustomTitleForeColor;
            g.DrawString("自定义颜色", this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.CustomTitleRect, text_left_sf);
            for (int i = 0; i < this.ColorObject.CustomColorsItem.GetLength(0); i++)
            {
                for (int j = 0; j < this.ColorObject.CustomColorsItem.GetLength(1); j++)
                {

                    this.SolidBrushManageObject.common_sb.Color = ColorManage.CustomColors[i, j];
                    g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.CustomColorsItem[i, j].Rect);

                    Rectangle rect = new Rectangle(this.ColorObject.CustomColorsItem[i, j].Rect.X, this.ColorObject.CustomColorsItem[i, j].Rect.Y, this.ColorObject.CustomColorsItem[i, j].Rect.Width - 1, this.ColorObject.CustomColorsItem[i, j].Rect.Height - 1);
                    g.DrawRectangle((this.ColorObject.CustomColorsItem[i, j].MoveStatus == ColorItemMoveStatuss.Enter) ? this.SolidBrushManageObject.border_ts_pen : this.SolidBrushManageObject.border_pen, rect);

                    if (this.custom_select_row_index == i && this.custom_select_cel_index == j)
                    {
                        this.SolidBrushManageObject.common_pen.Color = this.CustomSelectLineColor;
                        float w = this.SolidBrushManageObject.common_pen.Width;
                        this.SolidBrushManageObject.common_pen.Width = 2;
                        g.DrawLine(this.SolidBrushManageObject.common_pen, new Point(this.ColorObject.CustomColorsItem[i, j].Rect.Left, this.ColorObject.CustomColorsItem[i, j].Rect.Bottom + 3), new Point(this.ColorObject.CustomColorsItem[i, j].Rect.Right, this.ColorObject.CustomColorsItem[i, j].Rect.Bottom + 3));
                        this.SolidBrushManageObject.common_pen.Width = w;
                    }
                }
            }
            #endregion

            #region Gradual
            Rectangle gradual_border_rect = new Rectangle(this.ColorObject.GradualRect.X - 1, this.ColorObject.GradualRect.Y - 1, this.ColorObject.GradualRect.Width + 1, this.ColorObject.GradualRect.Height + 1);
            g.DrawRectangle(this.SolidBrushManageObject.border_pen, gradual_border_rect);

            g.DrawImage(this.gradual_bmp, this.ColorObject.GradualRect);

            if (this.ColorObject.GradualSelectPoint != Point.Empty)
            {
                Rectangle point_rect_in = new Rectangle(this.ColorObject.GradualRect.X + this.ColorObject.GradualSelectPoint.X - 2, this.ColorObject.GradualRect.Y + this.ColorObject.GradualSelectPoint.Y - 2, 4, 4);
                Rectangle point_rect_out = new Rectangle(this.ColorObject.GradualRect.X + this.ColorObject.GradualSelectPoint.X - 3, this.ColorObject.GradualRect.Y + this.ColorObject.GradualSelectPoint.Y - 3, 6, 6);
                this.SolidBrushManageObject.common_pen.Color = Color.Black;
                g.DrawEllipse(this.SolidBrushManageObject.common_pen, point_rect_in);
                this.SolidBrushManageObject.common_pen.Color = Color.White;
                g.DrawEllipse(this.SolidBrushManageObject.common_pen, point_rect_out);
            }
            #endregion

            #region GradualBar
            g.DrawImage(this.gradual_bar_bmp, this.ColorObject.GradualBarRect);
            g.DrawRectangle(this.SolidBrushManageObject.border_pen, this.ColorObject.GradualBarRect);
            this.SolidBrushManageObject.common_sb.Color = this.border_slide_back_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.GradualBarSlideRect);
            g.DrawRectangle(this.SolidBrushManageObject.border_slide_pen, this.ColorObject.GradualBarSlideRect);
            #endregion

            #region A
            this.SolidBrushManageObject.argb_lgb.LinearColors = new Color[] { Color.Transparent, Color.FromArgb(byte.MaxValue, this.currentValue) };
            g.FillRectangle(this.SolidBrushManageObject.argb_lgb, this.ColorObject.CurrentValue_A_Rect);
            g.DrawRectangle(this.SolidBrushManageObject.border_pen, this.ColorObject.CurrentValue_A_Rect);
            this.SolidBrushManageObject.common_sb.Color = this.border_slide_back_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.CurrentValue_A_SlideRect);
            g.DrawRectangle(this.SolidBrushManageObject.border_slide_pen, this.ColorObject.CurrentValue_A_SlideRect);
            this.SolidBrushManageObject.common_sb.Color = this.CurrentTextForeColor;
            Rectangle a_rect = new Rectangle(this.ColorObject.CurrentValue_A_Rect.Right, this.ColorObject.CurrentValue_A_Rect.Y, 20, this.ColorObject.CurrentValue_A_Rect.Height);
            g.DrawString("A", this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, a_rect, text_right_sf);
            #endregion

            #region R
            this.SolidBrushManageObject.argb_lgb.LinearColors = new Color[] { Color.Transparent, Color.Red };
            g.FillRectangle(this.SolidBrushManageObject.argb_lgb, this.ColorObject.CurrentValue_R_Rect);
            g.DrawRectangle(this.SolidBrushManageObject.border_pen, this.ColorObject.CurrentValue_R_Rect);
            this.SolidBrushManageObject.common_sb.Color = this.border_slide_back_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.CurrentValue_R_SlideRect);
            g.DrawRectangle(this.SolidBrushManageObject.border_slide_pen, this.ColorObject.CurrentValue_R_SlideRect);
            this.SolidBrushManageObject.common_sb.Color = this.CurrentTextForeColor;
            Rectangle r_rect = new Rectangle(this.ColorObject.CurrentValue_R_Rect.Right, this.ColorObject.CurrentValue_R_Rect.Y, 20, this.ColorObject.CurrentValue_R_Rect.Height);
            g.DrawString("R", this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, r_rect, text_right_sf);
            #endregion

            #region G
            this.SolidBrushManageObject.argb_lgb.LinearColors = new Color[] { Color.Transparent, Color.Green };
            g.FillRectangle(this.SolidBrushManageObject.argb_lgb, this.ColorObject.CurrentValue_G_Rect);
            g.DrawRectangle(this.SolidBrushManageObject.border_pen, this.ColorObject.CurrentValue_G_Rect);
            this.SolidBrushManageObject.common_sb.Color = this.border_slide_back_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.CurrentValue_G_SlideRect);
            g.DrawRectangle(this.SolidBrushManageObject.border_slide_pen, this.ColorObject.CurrentValue_G_SlideRect);
            this.SolidBrushManageObject.common_sb.Color = this.CurrentTextForeColor;
            Rectangle g_rect = new Rectangle(this.ColorObject.CurrentValue_G_Rect.Right, this.ColorObject.CurrentValue_G_Rect.Y, 20, this.ColorObject.CurrentValue_G_Rect.Height);
            g.DrawString("G", this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, g_rect, text_right_sf);
            #endregion

            #region B
            this.SolidBrushManageObject.argb_lgb.LinearColors = new Color[] { Color.Transparent, Color.Blue };
            g.FillRectangle(this.SolidBrushManageObject.argb_lgb, this.ColorObject.CurrentValue_B_Rect);
            g.DrawRectangle(this.SolidBrushManageObject.border_pen, this.ColorObject.CurrentValue_B_Rect);
            this.SolidBrushManageObject.common_sb.Color = this.border_slide_back_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.CurrentValue_B_SlideRect);
            g.DrawRectangle(this.SolidBrushManageObject.border_slide_pen, this.ColorObject.CurrentValue_B_SlideRect);
            this.SolidBrushManageObject.common_sb.Color = this.CurrentTextForeColor;
            Rectangle b_rect = new Rectangle(this.ColorObject.CurrentValue_B_Rect.Right, this.ColorObject.CurrentValue_B_Rect.Y, 20, this.ColorObject.CurrentValue_B_Rect.Height);
            g.DrawString("B", this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, b_rect, text_right_sf);
            #endregion

            #region 当前颜色值
            this.SolidBrushManageObject.common_sb.Color = this.CurrentTextForeColor;
            string newcolor_str = "当前颜色:";
            g.DrawString(newcolor_str, this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.CurrentColorTextRect, text_left_sf);
            Pen colortext_border_pen = new Pen(Color.FromArgb(192, 192, 192), 1);
            g.DrawRectangle(colortext_border_pen, new Rectangle(this.colorTextBox.Location.X - 3, this.colorTextBox.Location.Y - 4, this.colorTextBox.Size.Width + 4, this.colorTextBox.Height + 5));
            colortext_border_pen.Dispose();


            if (this.currentValue != Color.Empty)
            {
                this.SolidBrushManageObject.common_sb.Color = Color.FromArgb(byte.MaxValue, this.currentValue);
                g.FillRectangle(this.SolidBrushManageObject.common_sb, new Rectangle(this.ColorObject.CurrentColorRect.X, this.ColorObject.CurrentColorRect.Y, this.ColorObject.CurrentColorRect.Width / 2, this.ColorObject.CurrentColorRect.Height));
                this.SolidBrushManageObject.common_sb.Color = this.currentValue;
                g.FillRectangle(this.SolidBrushManageObject.common_sb, new Rectangle(this.ColorObject.CurrentColorRect.X + this.ColorObject.CurrentColorRect.Width / 2, this.ColorObject.CurrentColorRect.Y, this.ColorObject.CurrentColorRect.Width / 2, this.ColorObject.CurrentColorRect.Height));
            }

            g.DrawRectangle(this.SolidBrushManageObject.border_pen, this.ColorObject.CurrentColorRect);
            g.DrawLine(this.SolidBrushManageObject.border_pen, new Point(this.ColorObject.CurrentColorRect.X + this.ColorObject.CurrentColorRect.Width / 2, this.ColorObject.CurrentColorRect.Y), new Point(this.ColorObject.CurrentColorRect.X + this.ColorObject.CurrentColorRect.Width / 2, this.ColorObject.CurrentColorRect.Bottom));
            #endregion

            #region 原始颜色值
            this.SolidBrushManageObject.common_sb.Color = this.CurrentTextForeColor;
            string oldcolor_str = this.ColorValue == Color.Empty ? "原始颜色:" : String.Format("原始颜色: {0},{1},{2},{3}", this.ColorValue.A, this.ColorValue.R, this.ColorValue.G, this.ColorValue.B);
            g.DrawString(oldcolor_str, this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.OriginalColorTextRect, text_left_sf);


            if (this.ColorValue != Color.Empty)
            {
                this.SolidBrushManageObject.common_sb.Color = Color.FromArgb(byte.MaxValue, this.ColorValue);
                g.FillRectangle(this.SolidBrushManageObject.common_sb, new Rectangle(this.ColorObject.OriginalColorRect.X, this.ColorObject.OriginalColorRect.Y, this.ColorObject.OriginalColorRect.Width / 2, this.ColorObject.OriginalColorRect.Height));
                this.SolidBrushManageObject.common_sb.Color = this.ColorValue;
                g.FillRectangle(this.SolidBrushManageObject.common_sb, new Rectangle(this.ColorObject.OriginalColorRect.X + this.ColorObject.OriginalColorRect.Width / 2, this.ColorObject.OriginalColorRect.Y, this.ColorObject.OriginalColorRect.Width / 2, this.ColorObject.OriginalColorRect.Height));
            }

            g.DrawRectangle(this.SolidBrushManageObject.border_pen, this.ColorObject.OriginalColorRect);
            g.DrawLine(this.SolidBrushManageObject.border_pen, new Point(this.ColorObject.OriginalColorRect.X + this.ColorObject.OriginalColorRect.Width / 2, this.ColorObject.OriginalColorRect.Y), new Point(this.ColorObject.OriginalColorRect.X + this.ColorObject.OriginalColorRect.Width / 2, this.ColorObject.OriginalColorRect.Bottom));
            #endregion

            #region 底部按钮
            Color bottom_custom_back_color = (this.ColorReadOnly || !this.Enabled) ? this.BottomBarBtnBackDisabledColor : (this.ColorObject.CustomBtn.MoveStatus == ColorItemMoveStatuss.Enter ? this.BottomBarBtnBackEnterColor : this.BottomBarBtnBackColor);
            Color bottom_custom_fore_color = (this.ColorReadOnly || !this.Enabled) ? this.BottomBarBtnForeDisabledColor : (this.ColorObject.CustomBtn.MoveStatus == ColorItemMoveStatuss.Enter ? this.BottomBarBtnForeEnterColor : this.BottomBarBtnForeColor);
            this.SolidBrushManageObject.common_sb.Color = bottom_custom_back_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.CustomBtn.Rect);
            this.SolidBrushManageObject.common_sb.Color = bottom_custom_fore_color;
            g.DrawString(this.ColorObject.CustomBtn.Text, this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.CustomBtn.Rect, text_center_sf);

            Color bottom_clear_back_color = (this.ColorReadOnly || !this.Enabled) ? this.BottomBarBtnBackDisabledColor : (this.ColorObject.ClearBtn.MoveStatus == ColorItemMoveStatuss.Enter ? this.BottomBarBtnBackEnterColor : this.BottomBarBtnBackColor);
            Color bottom_clear_fore_color = (this.ColorReadOnly || !this.Enabled) ? this.BottomBarBtnForeDisabledColor : (this.ColorObject.ClearBtn.MoveStatus == ColorItemMoveStatuss.Enter ? this.BottomBarBtnForeEnterColor : this.BottomBarBtnForeColor);
            this.SolidBrushManageObject.common_sb.Color = bottom_clear_back_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.ClearBtn.Rect);
            this.SolidBrushManageObject.common_sb.Color = bottom_clear_fore_color;
            g.DrawString(this.ColorObject.ClearBtn.Text, this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.ClearBtn.Rect, text_center_sf);

            Color bottom_confirm_back_color = (this.ColorReadOnly || !this.Enabled) ? this.BottomBarBtnBackDisabledColor : (this.ColorObject.ConfirmBtn.MoveStatus == ColorItemMoveStatuss.Enter ? this.BottomBarBtnBackEnterColor : this.BottomBarBtnBackColor);
            Color bottom_confirm_fore_color = (this.ColorReadOnly || !this.Enabled) ? this.BottomBarBtnForeDisabledColor : (this.ColorObject.ConfirmBtn.MoveStatus == ColorItemMoveStatuss.Enter ? this.BottomBarBtnForeEnterColor : this.BottomBarBtnForeColor);
            this.SolidBrushManageObject.common_sb.Color = bottom_confirm_back_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.ConfirmBtn.Rect);
            this.SolidBrushManageObject.common_sb.Color = bottom_confirm_fore_color;
            g.DrawString(this.ColorObject.ConfirmBtn.Text, this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.ConfirmBtn.Rect, text_center_sf);
            #endregion

        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (this.DesignMode)
                return;

            if (this.SolidBrushManageObject != null)
                this.SolidBrushManageObject.ReleaseSolidBrushs();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (this.DesignMode)
                return;

            if (this.ColorReadOnly)
                return;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Focus();

                Point point = this.PointToClient(Control.MousePosition);

                #region 顶部按钮
                if (this.ColorObject.DefaultColorBtn.Rect.Contains(point) && this.ColorType != colorTypes.Default)
                {
                    this.ColorType = colorTypes.Default;
                    this.Invalidate();
                }
                else if (this.ColorObject.HtmlColorBtn.Rect.Contains(point) && this.ColorType != colorTypes.Html)
                {
                    this.ColorType = colorTypes.Html;
                    this.Invalidate();
                }
                #endregion
                #region Theme
                if (this.colorMoveStatus == ColorMoveStatuss.ThemeDown)
                {
                    if (this.ColorObject.ThemeRect.Contains(point))
                    {
                        for (int i = 0; i < this.ColorObject.ThemeColorsItem.GetLength(0); i++)
                        {
                            for (int j = 0; j < this.ColorObject.ThemeColorsItem.GetLength(1); j++)
                            {
                                if (this.ColorObject.ThemeColorsItem[i, j].Rect.Contains(point))
                                {
                                    if (this.ColorObject.CurrentValue_A_SlideValue == 0)
                                    {
                                        this.ColorObject.CurrentValue_A_SlideValue = 255;
                                        this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
                                    }

                                    this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, ColorManage.ThemeColors[this.ColorObject.ThemeColorsItem[i, j].ColorRowIndex, this.ColorObject.ThemeColorsItem[i, j].ColorColIndex]);
                                    this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
                                    this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
                                    this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;
                                    this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                                    this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                                    this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

                                    this.UpdateColorText();

                                    this.gradual_color = ColorManage.ThemeColors[this.ColorObject.ThemeColorsItem[i, j].ColorRowIndex, this.ColorObject.ThemeColorsItem[i, j].ColorColIndex];
                                    this.ColorObject.GradualSelectPoint = Point.Empty;
                                    this.Update_Gradual_Image();

                                    this.OnThemeColorItemClick(new ColorItemClickEventArgs() { Item = this.ColorObject.ThemeColorsItem[i, j] });

                                    this.Invalidate();
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Standard
                if (this.colorMoveStatus == ColorMoveStatuss.StandardDown)
                {
                    if (this.ColorObject.StandardRect.Contains(point))
                    {
                        for (int i = 0; i < this.ColorObject.StandardColorsItem.GetLength(0); i++)
                        {
                            for (int j = 0; j < this.ColorObject.StandardColorsItem.GetLength(1); j++)
                            {
                                if (this.ColorObject.StandardColorsItem[i, j].Rect.Contains(point))
                                {
                                    if (this.ColorObject.CurrentValue_A_SlideValue == 0)
                                    {
                                        this.ColorObject.CurrentValue_A_SlideValue = 255;
                                        this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
                                    }

                                    this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, ColorManage.StandardColors[this.ColorObject.StandardColorsItem[i, j].ColorRowIndex, this.ColorObject.StandardColorsItem[i, j].ColorColIndex]);
                                    this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
                                    this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
                                    this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;
                                    this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                                    this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                                    this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

                                    this.UpdateColorText();

                                    this.gradual_color = ColorManage.StandardColors[this.ColorObject.StandardColorsItem[i, j].ColorRowIndex, this.ColorObject.StandardColorsItem[i, j].ColorColIndex];
                                    this.ColorObject.GradualSelectPoint = Point.Empty;
                                    this.Update_Gradual_Image();

                                    this.OnStandardColorItemClick(new ColorItemClickEventArgs() { Item = this.ColorObject.StandardColorsItem[i, j] });

                                    this.Invalidate();
                                }
                            }
                        }
                    }
                }
                #endregion
                #region html
                if (this.colorMoveStatus == ColorMoveStatuss.HtmlDown)
                {
                    GraphicsPath html_gp = new GraphicsPath();
                    Region html_r = new Region();
                    for (int i = 0; i < this.ColorObject.HtmlColorsItem.Count; i++)
                    {
                        for (int j = 0; j < this.ColorObject.HtmlColorsItem[i].ColorsRects.Count; j++)
                        {
                            bool isselect = false;
                            html_gp.Reset();
                            html_gp.AddPolygon(this.ColorObject.HtmlColorsItem[i].ColorsRects[j].pointfs);
                            html_r.MakeEmpty();
                            html_r.Union(html_gp);
                            if (html_r.IsVisible(point))
                            {
                                if (this.ColorObject.CurrentValue_A_SlideValue == 0)
                                {
                                    this.ColorObject.CurrentValue_A_SlideValue = 255;
                                    this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
                                }

                                this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, ColorManage.HtmlColors[i].Colors[j]);
                                this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
                                this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
                                this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;
                                this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                                this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                                this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

                                this.UpdateColorText();

                                this.gradual_color = ColorManage.HtmlColors[i].Colors[j];
                                this.ColorObject.GradualSelectPoint = Point.Empty;
                                this.Update_Gradual_Image();

                                this.OnHtmlColorItemClick(new HtmlColorItemClickEventArgs() { Item = this.ColorObject.HtmlColorsItem[i].ColorsRects[j] });

                                this.Invalidate();
                                isselect = true;
                                break;
                            }
                            if (isselect)
                            {
                                break;
                            }
                        }
                    }
                    html_gp.Dispose();
                    html_r.Dispose();
                }
                #endregion
                #region Custom
                if (this.colorMoveStatus == ColorMoveStatuss.CustomDown)
                {
                    if (this.ColorObject.CustomRect.Contains(point))
                    {
                        for (int i = 0; i < this.ColorObject.CustomColorsItem.GetLength(0); i++)
                        {
                            for (int j = 0; j < this.ColorObject.CustomColorsItem.GetLength(1); j++)
                            {
                                if (this.ColorObject.CustomColorsItem[i, j].Rect.Contains(point))
                                {
                                    this.custom_select_row_index = i;
                                    this.custom_select_cel_index = j;

                                    if (this.ColorObject.CurrentValue_A_SlideValue == 0)
                                    {
                                        this.ColorObject.CurrentValue_A_SlideValue = 255;
                                        this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
                                    }

                                    this.currentValue = ColorManage.CustomColors[this.ColorObject.CustomColorsItem[i, j].ColorRowIndex, this.ColorObject.CustomColorsItem[i, j].ColorColIndex];
                                    this.ColorObject.CurrentValue_A_SlideValue = this.currentValue.A;
                                    this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
                                    this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
                                    this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;
                                    this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
                                    this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                                    this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                                    this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

                                    this.UpdateColorText();

                                    this.gradual_color = ColorManage.CustomColors[this.ColorObject.CustomColorsItem[i, j].ColorRowIndex, this.ColorObject.CustomColorsItem[i, j].ColorColIndex];
                                    this.ColorObject.GradualSelectPoint = Point.Empty;
                                    this.Update_Gradual_Image();

                                    this.OnCustomColorItemClick(new ColorItemClickEventArgs() { Item = this.ColorObject.CustomColorsItem[i, j] });

                                    this.Invalidate();
                                }
                            }
                        }
                    }
                }
                #endregion
                #region CustomBtn
                if (this.colorMoveStatus == ColorMoveStatuss.CustomDown)
                {
                    if (this.ColorObject.CustomBtn.Rect.Contains(point))
                    {
                        this.OnCustomClick(new BottomBarIiemClickEventArgs() { Item = this.ColorObject.CustomBtn });
                    }
                }
                #endregion
                #region ClearBtn
                if (this.colorMoveStatus == ColorMoveStatuss.ClearDown)
                {
                    if (this.ColorObject.ClearBtn.Rect.Contains(point))
                    {
                        this.OnClearClick(new BottomBarIiemClickEventArgs() { Item = this.ColorObject.ClearBtn });
                    }
                }
                #endregion
                #region ConfirmBtn
                if (this.colorMoveStatus == ColorMoveStatuss.ConfirmDown)
                {
                    if (this.ColorObject.ConfirmBtn.Rect.Contains(point))
                    {
                        this.OnConfirmClick(new BottomBarIiemClickEventArgs() { Item = this.ColorObject.ConfirmBtn });
                    }
                }
                #endregion
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.DesignMode)
                return;

            if (this.ColorReadOnly)
                return;

            if (this.ColorObject.ColorRect.Contains(e.Location))
            {
                if (this.ColorType == colorTypes.Default)
                {
                    #region Theme
                    if (this.ColorObject.ThemeRect.Contains(e.Location))
                    {
                        this.colorMoveStatus = ColorMoveStatuss.ThemeDown;
                    }
                    #endregion
                    #region Standard
                    else if (this.ColorObject.StandardRect.Contains(e.Location))
                    {
                        this.colorMoveStatus = ColorMoveStatuss.StandardDown;
                    }
                    #endregion
                }
                else if (this.ColorType == colorTypes.Html)
                {
                    #region html
                    this.colorMoveStatus = ColorMoveStatuss.HtmlDown;
                    #endregion
                }
            }
            #region Custom
            else if (this.ColorObject.CustomRect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.CustomDown;
                for (int i = 0; i < this.ColorObject.CustomColorsItem.GetLength(0); i++)
                {
                    for (int j = 0; j < this.ColorObject.CustomColorsItem.GetLength(1); j++)
                    {
                        if (this.ColorObject.CustomColorsItem[i, j].Rect.Contains(e.Location))
                        {
                            this.custom_select_row_index = i;
                            this.custom_select_cel_index = j;
                        }
                    }
                }
            }
            #endregion
            #region Gradual
            else if (this.ColorObject.GradualRect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.GradualDown;
                this.Calculate_GradualSelectPoint_Value(e.Location);

                if (this.ColorObject.CurrentValue_A_SlideValue == 0)
                {
                    this.ColorObject.CurrentValue_A_SlideValue = 255;
                    this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
                }

                this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, this.gradual_bmp.GetPixel(this.ColorObject.GradualSelectPoint.X, this.ColorObject.GradualSelectPoint.Y));
                this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
                this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
                this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;

                this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);
                this.Invalidate();
            }
            #endregion
            #region GradualBar
            else if (this.ColorObject.GradualBarRect.Contains(e.Location) || this.ColorObject.GradualBarSlideRect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.GradualBarDown;
                this.Calculate_GradualBar_Value(e.Location);
                Color color = this.gradual_bar_bmp.GetPixel(this.ColorObject.GradualBarRect.Width / 2, this.ColorObject.GradualBarSlideValue);

                if (this.ColorObject.CurrentValue_A_SlideValue == 0)
                {
                    this.ColorObject.CurrentValue_A_SlideValue = 255;
                    this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
                }

                this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, color);
                this.gradual_color = color;
                this.ColorObject.GradualSelectPoint = Point.Empty;
                this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
                this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
                this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;

                this.Update_GradualBar_Rect(this.ColorObject.GradualBarSlideValue);
                this.Update_Gradual_Image();
                this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);
                this.Invalidate();
            }
            #endregion
            #region A
            else if (this.ColorObject.CurrentValue_A_Rect.Contains(e.Location) || this.ColorObject.CurrentValue_A_SlideRect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.ADown;
                this.Calculate_A_Value(e.Location);
                this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, this.currentValue);
                this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
                this.Invalidate();
            }
            #endregion
            #region R
            else if (this.ColorObject.CurrentValue_R_Rect.Contains(e.Location) || this.ColorObject.CurrentValue_R_SlideRect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.RDown;
                this.Calculate_R_Value(e.Location);
                this.currentValue = Color.FromArgb(this.currentValue.A, this.ColorObject.CurrentValue_R_SlideValue, this.currentValue.G, this.currentValue.B);
                this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                this.Invalidate();
            }
            #endregion
            #region G
            else if (this.ColorObject.CurrentValue_G_Rect.Contains(e.Location) || this.ColorObject.CurrentValue_G_SlideRect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.GDown;
                this.Calculate_G_Value(e.Location);
                this.currentValue = Color.FromArgb(this.currentValue.A, this.currentValue.R, this.ColorObject.CurrentValue_G_SlideValue, this.currentValue.B);
                this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                this.Invalidate();
            }
            #endregion
            #region B
            else if (this.ColorObject.CurrentValue_B_Rect.Contains(e.Location) || this.ColorObject.CurrentValue_B_SlideRect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.BDown;
                this.Calculate_B_Value(e.Location);
                this.currentValue = Color.FromArgb(this.currentValue.A, this.currentValue.R, this.currentValue.G, this.ColorObject.CurrentValue_B_SlideValue);
                this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);
                this.Invalidate();
            }
            #endregion
            #region CustomBtn
            else if (this.ColorObject.CustomBtn.Rect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.CustomDown;
            }
            #endregion
            #region ClearBtn
            else if (this.ColorObject.ClearBtn.Rect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.ClearDown;
            }
            #endregion
            #region ConfirmBtn
            else if (this.ColorObject.ConfirmBtn.Rect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.ConfirmDown;
            }
            #endregion
            #region
            else
            {
                this.colorMoveStatus = ColorMoveStatuss.Normal;
            }
            #endregion

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            base.OnMouseDown(e);

            if (this.ColorReadOnly)
                return;

            this.colorMoveStatus = ColorMoveStatuss.Normal;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            base.OnMouseDown(e);

            if (this.ColorReadOnly)
                return;

            if (this.colorMoveStatus == ColorMoveStatuss.Normal)
            {
                bool isenter = false;
                #region 顶部按钮
                if (this.ColorObject.DefaultColorBtn.Rect.Contains(e.Location) || this.ColorObject.HtmlColorBtn.Rect.Contains(e.Location))
                {
                    isenter = true;
                }
                #endregion
                if (this.ColorType == colorTypes.Default)
                {
                    #region Theme
                    if (this.ColorObject.ThemeRect.Contains(e.Location))
                    {
                        for (int i = 0; i < this.ColorObject.ThemeColorsItem.GetLength(0); i++)
                        {
                            for (int j = 0; j < this.ColorObject.ThemeColorsItem.GetLength(1); j++)
                            {
                                if (this.ColorObject.ThemeColorsItem[i, j].Rect.Contains(e.Location))
                                {
                                    this.ColorObject.ThemeColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Enter;
                                }
                                else
                                {
                                    this.ColorObject.ThemeColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < this.ColorObject.ThemeColorsItem.GetLength(0); i++)
                        {
                            for (int j = 0; j < this.ColorObject.ThemeColorsItem.GetLength(1); j++)
                            {
                                this.ColorObject.ThemeColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                            }
                        }
                    }
                    #endregion
                    #region Standard
                    if (this.ColorObject.StandardRect.Contains(e.Location))
                    {
                        for (int i = 0; i < this.ColorObject.StandardColorsItem.GetLength(0); i++)
                        {
                            for (int j = 0; j < this.ColorObject.StandardColorsItem.GetLength(1); j++)
                            {
                                if (this.ColorObject.StandardColorsItem[i, j].Rect.Contains(e.Location))
                                {
                                    this.ColorObject.StandardColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Enter;
                                }
                                else
                                {
                                    this.ColorObject.StandardColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < this.ColorObject.StandardColorsItem.GetLength(0); i++)
                        {
                            for (int j = 0; j < this.ColorObject.StandardColorsItem.GetLength(1); j++)
                            {
                                this.ColorObject.StandardColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                            }
                        }
                    }
                    #endregion
                }
                #region Custom
                if (this.ColorObject.CustomRect.Contains(e.Location))
                {
                    for (int i = 0; i < this.ColorObject.CustomColorsItem.GetLength(0); i++)
                    {
                        for (int j = 0; j < this.ColorObject.CustomColorsItem.GetLength(1); j++)
                        {
                            if (this.ColorObject.CustomColorsItem[i, j].Rect.Contains(e.Location))
                            {
                                this.ColorObject.CustomColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Enter;
                            }
                            else
                            {
                                this.ColorObject.CustomColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < this.ColorObject.CustomColorsItem.GetLength(0); i++)
                    {
                        for (int j = 0; j < this.ColorObject.CustomColorsItem.GetLength(1); j++)
                        {
                            this.ColorObject.CustomColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                        }
                    }
                }
                #endregion
                #region CustomBtn
                if (this.ColorObject.CustomBtn.Rect.Contains(e.Location))
                {
                    this.ColorObject.CustomBtn.MoveStatus = ColorItemMoveStatuss.Enter;
                    isenter = true;
                }
                else
                {
                    this.ColorObject.CustomBtn.MoveStatus = ColorItemMoveStatuss.Normal;
                }
                #endregion
                #region ClearBtn
                if (this.ColorObject.ClearBtn.Rect.Contains(e.Location))
                {
                    this.ColorObject.ClearBtn.MoveStatus = ColorItemMoveStatuss.Enter;
                    isenter = true;
                }
                else
                {
                    this.ColorObject.ClearBtn.MoveStatus = ColorItemMoveStatuss.Normal;
                }
                #endregion
                #region ConfirmBtn
                if (this.ColorObject.ConfirmBtn.Rect.Contains(e.Location))
                {
                    this.ColorObject.ConfirmBtn.MoveStatus = ColorItemMoveStatuss.Enter;
                    isenter = true;
                }
                else
                {
                    this.ColorObject.ConfirmBtn.MoveStatus = ColorItemMoveStatuss.Normal;
                }
                #endregion
                this.Cursor = isenter ? Cursors.Hand : Cursors.Default;
            }
            #region Gradual
            else if (this.colorMoveStatus == ColorMoveStatuss.GradualDown)
            {
                this.Calculate_GradualSelectPoint_Value(e.Location);
                this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, this.gradual_bmp.GetPixel(this.ColorObject.GradualSelectPoint.X, this.ColorObject.GradualSelectPoint.Y));
                this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
                this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
                this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;

                this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

                this.UpdateColorText();

                this.Invalidate();
            }
            #endregion
            #region GradualBar
            else if (this.colorMoveStatus == ColorMoveStatuss.GradualBarDown)
            {
                this.Calculate_GradualBar_Value(e.Location);
                Color color = this.gradual_bar_bmp.GetPixel(this.ColorObject.GradualBarRect.Width / 2, this.ColorObject.GradualBarSlideValue);
                this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, color);
                this.gradual_color = color;
                this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
                this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
                this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;

                this.Update_GradualBar_Rect(this.ColorObject.GradualBarSlideValue);
                this.Update_Gradual_Image();
                this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

                this.UpdateColorText();

                this.Invalidate();
            }
            #endregion
            #region A
            else if (this.colorMoveStatus == ColorMoveStatuss.ADown)
            {
                this.Calculate_A_Value(e.Location);
                this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, this.currentValue);
                this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);

                this.UpdateColorText();

                this.Invalidate();
            }
            #endregion
            #region R
            else if (this.colorMoveStatus == ColorMoveStatuss.RDown)
            {
                this.Calculate_R_Value(e.Location);
                this.currentValue = Color.FromArgb(this.currentValue.A, this.ColorObject.CurrentValue_R_SlideValue, this.currentValue.G, this.currentValue.B);
                this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);

                this.UpdateColorText();

                this.Invalidate();
            }
            #endregion
            #region G
            else if (this.colorMoveStatus == ColorMoveStatuss.GDown)
            {
                this.Calculate_G_Value(e.Location);
                this.currentValue = Color.FromArgb(this.currentValue.A, this.currentValue.R, this.ColorObject.CurrentValue_G_SlideValue, this.currentValue.B);
                this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);

                this.UpdateColorText();

                this.Invalidate();
            }
            #endregion
            #region B
            else if (this.colorMoveStatus == ColorMoveStatuss.BDown)
            {
                this.Calculate_B_Value(e.Location);
                this.currentValue = Color.FromArgb(this.currentValue.A, this.currentValue.R, this.currentValue.G, this.ColorObject.CurrentValue_B_SlideValue);
                this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

                this.UpdateColorText();

                this.Invalidate();
            }
            #endregion

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.InitializeControlRectangle();
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, DefaultSize.Width, this.DefaultSize.Height, specified);
            this.Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.SolidBrushManageObject != null)
                    this.SolidBrushManageObject.ReleaseSolidBrushs();
                if (this.gradual_bmp != null)
                    this.gradual_bmp.Dispose();
                if (this.gradual_bar_bmp != null)
                    this.gradual_bar_bmp.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 虚方法

        protected virtual void OnColorValueChanged(ColorValueChangedEventArgs e)
        {
            if (this.colorValueChanged != null)
            {
                this.colorValueChanged(this, e);
            }
        }

        protected virtual void OnHtmlColorItemClick(HtmlColorItemClickEventArgs e)
        {
            if (this.htmlColorItemClick != null)
            {
                this.htmlColorItemClick(this, e);
            }
        }

        protected virtual void OnThemeColorItemClick(ColorItemClickEventArgs e)
        {
            if (this.themeColorItemClick != null)
            {
                this.themeColorItemClick(this, e);
            }
        }

        protected virtual void OnStandardColorItemClick(ColorItemClickEventArgs e)
        {
            if (this.standardColorItemClick != null)
            {
                this.standardColorItemClick(this, e);
            }
        }

        protected virtual void OnCustomColorItemClick(ColorItemClickEventArgs e)
        {
            if (this.customColorItemClick != null)
            {
                this.customColorItemClick(this, e);
            }
        }

        protected virtual void OnCustomClick(BottomBarIiemClickEventArgs e)
        {
            ColorManage.CustomColors[this.custom_select_row_index, this.custom_select_cel_index] = this.currentValue;
            int row = ColorManage.CustomColors.GetLength(0);
            int cel = ColorManage.CustomColors.GetLength(1);

            if (this.custom_select_cel_index < cel - 1)
            {
                this.custom_select_cel_index += 1;
            }
            else if (this.custom_select_row_index == 0)
            {
                this.custom_select_row_index = 1;
                this.custom_select_cel_index = 0;
            }
            else if (this.custom_select_row_index == 1)
            {
                this.custom_select_row_index = 0;
                this.custom_select_cel_index = 0;
            }
            this.Invalidate();

            if (this.bottomBarCustomClick != null)
            {
                this.bottomBarCustomClick(this, e);
            }
        }

        protected virtual void OnClearClick(BottomBarIiemClickEventArgs e)
        {
            this.ColorValue = Color.Empty;

            if (this.bottomBarClearClick != null)
            {
                this.bottomBarClearClick(this, e);
            }
        }

        protected virtual void OnConfirmClick(BottomBarIiemClickEventArgs e)
        {
            this.ColorValue = this.currentValue;

            if (this.bottomBarConfirmClick != null)
            {
                this.bottomBarConfirmClick(this, e);
            }
        }

        #endregion

        #region 私有方法

        #region 颜色输入框事件

        private void colorTextBox_LostFocus(object sender, EventArgs e)
        {
            Color? color = this.ValidColor(this.colorTextBox.Text);
            if (!color.HasValue)
            {
                this.UpdateColorText();
            }
        }

        private void colorTextBox_TextChanged(object sender, EventArgs e)
        {
            Color? color = this.ValidColor(this.colorTextBox.Text);
            if (color.HasValue)
            {
                this.UpdateColorInputValue(color.Value);
            }
        }

        #endregion

        private void InitializeControlRectangle()
        {
            #region

            int color_width = 203; int color_height = 212;
            int top_btn_width = 70; int top_btn_height = 20;
            int theme_title_height = 30; int theme_item_width = 14; int theme_item_height = 14;
            int standard_title_height = 30; int standard_item_width = 14; int standard_item_height = 14;
            int html_item_side = 8;
            int custom_title_height = 30; int custom_item_width = 14; int custom_item_height = 14;
            int gradual_width = 200; int gradual_height = 135;
            int gradualbar_width = 30; int gradualbar_height = 220; int gradualbar_slide_height = 6;
            int argb_width = 180; int argb_height = 12; int argb_slide_width = 6;
            int current_text_height = 20;
            int bottom_btn_width = 50; int bottom_btn_height = 30;
            #endregion

            this.ColorObject.ColorRect = new Rectangle(this.ClientRectangle.X + this.Padding.Left, this.ClientRectangle.Y + this.Padding.Top, color_width, color_height);

            this.ColorObject.DefaultColorBtn.Rect = new Rectangle(this.ColorObject.ColorRect.Left + 10, this.ClientRectangle.Y + this.Padding.Top, top_btn_width, top_btn_height);
            this.ColorObject.HtmlColorBtn.Rect = new Rectangle(this.ColorObject.DefaultColorBtn.Rect.Right, this.ClientRectangle.Y + this.Padding.Top, top_btn_width, top_btn_height);

            int theme_color_rect_width = theme_item_width * this.ColorObject.ThemeColorsItem.GetLength(0) + (theme_item_width / 2 * (this.ColorObject.ThemeColorsItem.GetLength(0) - 1));
            int theme_color_rect_height = theme_item_height * this.ColorObject.ThemeColorsItem.GetLength(1) + theme_item_height / 2;
            this.ColorObject.ThemeTitleRect = new Rectangle(this.ClientRectangle.X + this.Padding.Left, this.ClientRectangle.Y + this.Padding.Top + top_btn_height, theme_color_rect_width, theme_title_height);
            this.ColorObject.ThemeRect = new Rectangle(this.ClientRectangle.X + this.Padding.Left, this.ColorObject.ThemeTitleRect.Bottom, theme_color_rect_width, theme_color_rect_height);
            for (int i = 0; i < this.ColorObject.ThemeColorsItem.GetLength(0); i++)
            {
                for (int j = 0; j < this.ColorObject.ThemeColorsItem.GetLength(1); j++)
                {
                    int x = this.ColorObject.ThemeRect.X + (theme_item_width / 2 + theme_item_width) * i;
                    int y = this.ColorObject.ThemeTitleRect.Bottom + theme_item_height * j + (j > 0 ? theme_item_height / 2 : 0);
                    this.ColorObject.ThemeColorsItem[i, j].Rect = new Rectangle(x, y, theme_item_width, theme_item_height);
                    this.ColorObject.ThemeColorsItem[i, j].ColorRowIndex = i;
                    this.ColorObject.ThemeColorsItem[i, j].ColorColIndex = j;
                    this.ColorObject.ThemeColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                }
            }

            int tandard_color_rect_width = standard_item_width * this.ColorObject.StandardColorsItem.GetLength(1) + (standard_item_width / 2 * (this.ColorObject.StandardColorsItem.GetLength(1) - 1));
            int tandard_color_rect_height = standard_item_height * this.ColorObject.StandardColorsItem.GetLength(0) + (standard_item_height / 2 * (this.ColorObject.StandardColorsItem.GetLength(0) - 1));
            this.ColorObject.StandardTitleRect = new Rectangle(this.ClientRectangle.X + this.Padding.Left, this.ColorObject.ThemeRect.Bottom, tandard_color_rect_width, standard_title_height);
            this.ColorObject.StandardRect = new Rectangle(this.ClientRectangle.X + this.Padding.Left, this.ColorObject.StandardTitleRect.Bottom, tandard_color_rect_width, tandard_color_rect_height);
            for (int i = 0; i < this.ColorObject.StandardColorsItem.GetLength(0); i++)
            {
                for (int j = 0; j < this.ColorObject.StandardColorsItem.GetLength(1); j++)
                {
                    int x = this.ColorObject.ThemeRect.X + (theme_item_width / 2 + theme_item_width) * j;
                    int y = this.ColorObject.StandardTitleRect.Bottom + theme_item_height * i + (i > 0 ? theme_item_height / 2 : 0);
                    this.ColorObject.StandardColorsItem[i, j].Rect = new Rectangle(x, y, theme_item_width, theme_item_height);
                    this.ColorObject.StandardColorsItem[i, j].ColorRowIndex = i;
                    this.ColorObject.StandardColorsItem[i, j].ColorColIndex = j;
                    this.ColorObject.StandardColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                }
            }

            int custom_color_rect_width = custom_item_width * this.ColorObject.CustomColorsItem.GetLength(1) + (custom_item_width / 2 * (this.ColorObject.CustomColorsItem.GetLength(1) - 1));
            int custom_color_rect_height = custom_item_height * this.ColorObject.CustomColorsItem.GetLength(0) + (custom_item_height / 2 * (this.ColorObject.CustomColorsItem.GetLength(0) - 1));
            this.ColorObject.CustomTitleRect = new Rectangle(this.ClientRectangle.X + this.Padding.Left, this.ColorObject.StandardRect.Bottom, tandard_color_rect_width, custom_title_height);
            this.ColorObject.CustomRect = new Rectangle(this.ClientRectangle.X + this.Padding.Left, this.ColorObject.CustomTitleRect.Bottom, tandard_color_rect_width, tandard_color_rect_height);
            for (int i = 0; i < this.ColorObject.CustomColorsItem.GetLength(0); i++)
            {
                for (int j = 0; j < this.ColorObject.CustomColorsItem.GetLength(1); j++)
                {
                    int x = this.ColorObject.ThemeRect.X + (theme_item_width / 2 + theme_item_width) * j;
                    int y = this.ColorObject.CustomTitleRect.Bottom + theme_item_height * i + (i > 0 ? theme_item_height / 2 : 0);
                    this.ColorObject.CustomColorsItem[i, j].Rect = new Rectangle(x, y, theme_item_width, theme_item_height);
                    this.ColorObject.CustomColorsItem[i, j].ColorRowIndex = i;
                    this.ColorObject.CustomColorsItem[i, j].ColorColIndex = j;
                    this.ColorObject.CustomColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                }
            }

            double html_w = html_item_side * Math.Cos(2 * Math.PI / 360 * 30);
            double html_h = html_item_side * Math.Sin(2 * Math.PI / 360 * 30);
            double html_top = 10;
            double html_left = (this.ColorObject.ColorRect.Width - (this.ColorObject.HtmlColorsItem[this.ColorObject.HtmlColorsItem.Count / 2].ColorsRects.Count * html_w * 2)) / 2;
            for (int i = 0; i < this.ColorObject.HtmlColorsItem.Count; i++)
            {
                int num = Math.Abs(this.ColorObject.HtmlColorsItem.Count / 2 - i);
                for (int j = 0; j < this.ColorObject.HtmlColorsItem[i].ColorsRects.Count; j++)
                {
                    this.ColorObject.HtmlColorsItem[i].ColorsRects[j].pointfs[0] = new PointF((float)(this.ClientRectangle.Left + html_left + num * html_w + j * html_w * 2 + html_w), (float)(this.ColorObject.DefaultColorBtn.Rect.Bottom + html_top + i * (html_h + html_item_side)));
                    this.ColorObject.HtmlColorsItem[i].ColorsRects[j].pointfs[1] = new PointF((float)(this.ClientRectangle.Left + html_left + num * html_w + j * html_w * 2 + html_w + html_w), (float)(this.ColorObject.DefaultColorBtn.Rect.Bottom + html_top + i * (html_h + html_item_side) + html_h));
                    this.ColorObject.HtmlColorsItem[i].ColorsRects[j].pointfs[2] = new PointF((float)(this.ClientRectangle.Left + html_left + num * html_w + j * html_w * 2 + html_w + html_w), (float)(this.ColorObject.DefaultColorBtn.Rect.Bottom + html_top + i * (html_h + html_item_side) + html_h + html_item_side));
                    this.ColorObject.HtmlColorsItem[i].ColorsRects[j].pointfs[3] = new PointF((float)(this.ClientRectangle.Left + html_left + num * html_w + j * html_w * 2 + html_w), (float)(this.ColorObject.DefaultColorBtn.Rect.Bottom + html_top + i * (html_h + html_item_side) + html_h + html_item_side + html_h));
                    this.ColorObject.HtmlColorsItem[i].ColorsRects[j].pointfs[4] = new PointF((float)(this.ClientRectangle.Left + html_left + num * html_w + j * html_w * 2), (float)(this.ColorObject.DefaultColorBtn.Rect.Bottom + html_top + i * (html_h + html_item_side) + html_h + html_item_side));
                    this.ColorObject.HtmlColorsItem[i].ColorsRects[j].pointfs[5] = new PointF((float)(this.ClientRectangle.Left + html_left + num * html_w + j * html_w * 2), (float)(this.ColorObject.DefaultColorBtn.Rect.Bottom + html_top + i * (html_h + html_item_side) + html_h));
                }
            }

            this.ColorObject.GradualRect = new Rectangle(this.ColorObject.ThemeRect.Right + 10, this.ClientRectangle.Y + this.Padding.Top + 5, gradual_width, gradual_height);
            this.ColorObject.GradualBarRect = new Rectangle(this.ColorObject.GradualRect.Right + 10, this.ClientRectangle.Y + this.Padding.Top + 5, gradualbar_width, gradualbar_height);
            this.ColorObject.GradualBarSlideRect = new Rectangle(this.ColorObject.GradualBarRect.X, this.ColorObject.GradualBarRect.Y + gradualbar_slide_height / 2, this.ColorObject.GradualBarRect.Width, gradualbar_slide_height);

            this.ColorObject.CurrentValue_A_Rect = new Rectangle(this.ColorObject.GradualRect.X, this.ColorObject.GradualRect.Bottom + 10, argb_width, argb_height);
            this.ColorObject.CurrentValue_A_SlideRect = new Rectangle(this.ColorObject.CurrentValue_A_Rect.Right - argb_slide_width / 2, this.ColorObject.CurrentValue_A_Rect.Y, argb_slide_width, this.ColorObject.CurrentValue_A_Rect.Height);

            this.ColorObject.CurrentValue_R_Rect = new Rectangle(this.ColorObject.GradualRect.X, this.ColorObject.CurrentValue_A_Rect.Bottom + 10, argb_width, argb_height);
            this.ColorObject.CurrentValue_R_SlideRect = new Rectangle(this.ColorObject.CurrentValue_R_Rect.Right - argb_slide_width / 2, this.ColorObject.CurrentValue_R_Rect.Y, argb_slide_width, this.ColorObject.CurrentValue_R_Rect.Height);

            this.ColorObject.CurrentValue_G_Rect = new Rectangle(this.ColorObject.GradualRect.X, this.ColorObject.CurrentValue_R_Rect.Bottom + 10, argb_width, argb_height);
            this.ColorObject.CurrentValue_G_SlideRect = new Rectangle(this.ColorObject.CurrentValue_G_Rect.Right - argb_slide_width / 2, this.ColorObject.CurrentValue_G_Rect.Y, argb_slide_width, this.ColorObject.CurrentValue_G_Rect.Height);

            this.ColorObject.CurrentValue_B_Rect = new Rectangle(this.ColorObject.GradualRect.X, this.ColorObject.CurrentValue_G_Rect.Bottom + 10, argb_width, argb_height);
            this.ColorObject.CurrentValue_B_SlideRect = new Rectangle(this.ColorObject.CurrentValue_B_Rect.Right - argb_slide_width / 2, this.ColorObject.CurrentValue_B_Rect.Y, argb_slide_width, this.ColorObject.CurrentValue_B_Rect.Height);

            this.ColorObject.CurrentColorRect = new Rectangle(this.ColorObject.GradualRect.X, this.ColorObject.CurrentValue_B_SlideRect.Bottom + 10, current_text_height * 2, current_text_height);
            this.ColorObject.CurrentColorTextRect = new Rectangle(this.ColorObject.CurrentColorRect.Right, this.ColorObject.CurrentValue_B_SlideRect.Bottom + 10, tandard_color_rect_width, current_text_height);

            this.ColorObject.OriginalColorRect = new Rectangle(this.ColorObject.GradualRect.X, this.ColorObject.CurrentColorRect.Bottom + 5, current_text_height * 2, current_text_height);
            this.ColorObject.OriginalColorTextRect = new Rectangle(this.ColorObject.CurrentColorRect.Right, this.ColorObject.CurrentColorRect.Bottom + 5, tandard_color_rect_width, current_text_height);

            this.ColorObject.ConfirmBtn.Rect = new Rectangle(this.ClientRectangle.Right - bottom_btn_width - 5, this.ClientRectangle.Bottom - bottom_btn_height - 5, bottom_btn_width, bottom_btn_height);
            this.ColorObject.ClearBtn.Rect = new Rectangle(this.ColorObject.ConfirmBtn.Rect.X - 5 - bottom_btn_width, this.ClientRectangle.Bottom - bottom_btn_height - 5, bottom_btn_width, bottom_btn_height);
            this.ColorObject.CustomBtn.Rect = new Rectangle(this.ColorObject.ClearBtn.Rect.X - 5 - 20 - bottom_btn_width, this.ClientRectangle.Bottom - bottom_btn_height - 5, bottom_btn_width + 20, bottom_btn_height);

        }

        private void Calculate_GradualSelectPoint_Value(Point point)
        {
            int x = point.X - this.ColorObject.GradualRect.X;
            if (x < 0)
                x = 0;
            if (x > this.ColorObject.GradualRect.Width - 1)
                x = this.ColorObject.GradualRect.Width - 1;
            int y = point.Y - this.ColorObject.GradualRect.Y;
            if (y < 0)
                y = 0;
            if (y > this.ColorObject.GradualRect.Height - 1)
                y = this.ColorObject.GradualRect.Height - 1;
            this.ColorObject.GradualSelectPoint = new Point(x, y);
        }
        private void Calculate_GradualBar_Value(Point point)
        {
            int sum = this.ColorObject.GradualBarRect.Height - 1;
            int s = (int)(sum * (point.Y - this.ColorObject.GradualBarRect.Y) / (float)this.ColorObject.GradualBarRect.Height);
            if (s < 0)
                s = 0;
            if (s > sum)
                s = sum;
            this.ColorObject.GradualBarSlideValue = s;
        }

        private void Calculate_A_Value(Point point)
        {
            int a = (int)(255 * (point.X - this.ColorObject.CurrentValue_A_Rect.X) / (float)this.ColorObject.CurrentValue_A_Rect.Width);
            if (a < byte.MinValue)
                a = byte.MinValue;
            if (a > byte.MaxValue)
                a = byte.MaxValue;
            this.ColorObject.CurrentValue_A_SlideValue = a;
        }
        private void Calculate_R_Value(Point point)
        {
            int r = (int)(255 * (point.X - this.ColorObject.CurrentValue_R_Rect.X) / (float)this.ColorObject.CurrentValue_R_Rect.Width);
            if (r < byte.MinValue)
                r = byte.MinValue;
            if (r > byte.MaxValue)
                r = byte.MaxValue;
            this.ColorObject.CurrentValue_R_SlideValue = r;
        }
        private void Calculate_G_Value(Point point)
        {
            int g = (int)(255 * (point.X - this.ColorObject.CurrentValue_G_Rect.X) / (float)this.ColorObject.CurrentValue_G_Rect.Width);
            if (g < byte.MinValue)
                g = byte.MinValue;
            if (g > byte.MaxValue)
                g = byte.MaxValue;
            this.ColorObject.CurrentValue_G_SlideValue = g;
        }
        private void Calculate_B_Value(Point point)
        {
            int b = (int)(255 * (point.X - this.ColorObject.CurrentValue_B_Rect.X) / (float)this.ColorObject.CurrentValue_B_Rect.Width);
            if (b < byte.MinValue)
                b = byte.MinValue;
            if (b > byte.MaxValue)
                b = byte.MaxValue;
            this.ColorObject.CurrentValue_B_SlideValue = b;
        }

        private void Update_GradualBar_Rect(int s)
        {
            float sum = this.ColorObject.GradualBarRect.Height - 1;
            this.ColorObject.GradualBarSlideRect.Y = (int)(this.ColorObject.GradualBarRect.Y + (this.ColorObject.GradualBarRect.Height * s / sum) - this.ColorObject.GradualBarSlideRect.Height / 2);
        }
        private void Update_A_Rect(int a)
        {
            this.ColorObject.CurrentValue_A_SlideRect.X = (int)(this.ColorObject.CurrentValue_A_Rect.X + (this.ColorObject.CurrentValue_A_Rect.Width * a / 255f) - this.ColorObject.CurrentValue_A_SlideRect.Width / 2);
        }
        private void Update_R_Rect(int r)
        {
            this.ColorObject.CurrentValue_R_SlideRect.X = (int)(this.ColorObject.CurrentValue_R_Rect.X + (this.ColorObject.CurrentValue_R_Rect.Width * r / 255f) - this.ColorObject.CurrentValue_R_SlideRect.Width / 2);
        }
        private void Update_G_Rect(int g)
        {
            this.ColorObject.CurrentValue_G_SlideRect.X = (int)(this.ColorObject.CurrentValue_G_Rect.X + (this.ColorObject.CurrentValue_G_Rect.Width * g / 255f) - this.ColorObject.CurrentValue_G_SlideRect.Width / 2);
        }
        private void Update_B_Rect(int b)
        {
            this.ColorObject.CurrentValue_B_SlideRect.X = (int)(this.ColorObject.CurrentValue_B_Rect.X + (this.ColorObject.CurrentValue_B_Rect.Width * b / 255f) - this.ColorObject.CurrentValue_B_SlideRect.Width / 2);
        }

        private void Update_Gradual_Image()
        {
            Rectangle bmp_rect = new Rectangle(0, 0, this.gradual_bmp.Width, this.gradual_bmp.Height);
            Graphics g = Graphics.FromImage(this.gradual_bmp);

            this.SolidBrushManageObject.common_sb.Color = this.gradual_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, bmp_rect);

            g.FillRectangle(this.SolidBrushManageObject.gradual_h_lgb, bmp_rect);
            g.FillRectangle(this.SolidBrushManageObject.gradual_v_lgb, bmp_rect);

            g.Dispose();
        }

        private void Update_GradualBar_Image()
        {
            Rectangle barbmp_rect = new Rectangle(0, 0, this.gradual_bar_bmp.Width, this.gradual_bar_bmp.Height);
            Graphics g = Graphics.FromImage(this.gradual_bar_bmp);
            LinearGradientBrush gradualbar_lgb = new LinearGradientBrush(this.ColorObject.GradualBarRect, Color.Transparent, Color.Transparent, 90) { InterpolationColors = new ColorBlend() { Colors = ColorManage.GradualBarcolors, Positions = ColorManage.GradualBarInterval } };
            g.FillRectangle(gradualbar_lgb, barbmp_rect);
            gradualbar_lgb.Dispose();
            g.Dispose();
        }

        private void UpdateLocationSize()
        {
            this.colorTextBox.Width = colorTextWidth;
            this.colorTextBox.Height = this.ColorObject.CurrentColorTextRect.Height;
            this.colorTextBox.Location = new Point(this.ColorObject.CurrentColorTextRect.X + 60, this.ColorObject.CurrentColorTextRect.Y + 3);
        }

        private void UpdateColorText()
        {
            this.colorTextBox.Text = String.Format("{0},{1},{2},{3}", this.ColorObject.CurrentValue_A_SlideValue, this.ColorObject.CurrentValue_R_SlideValue, this.ColorObject.CurrentValue_G_SlideValue, this.ColorObject.CurrentValue_B_SlideValue);
        }

        private void UpdateColorInputValue(Color color)
        {
            this.ColorObject.CurrentValue_A_SlideValue = color.A;
            this.ColorObject.CurrentValue_R_SlideValue = color.R;
            this.ColorObject.CurrentValue_G_SlideValue = color.G;
            this.ColorObject.CurrentValue_B_SlideValue = color.B;

            this.Update_R_Rect(this.ColorObject.CurrentValue_A_SlideValue);
            this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
            this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
            this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

            this.gradual_color = color;
            this.ColorObject.GradualSelectPoint = Point.Empty;
            this.Update_Gradual_Image();

            this.Invalidate();
        }

        #endregion

        #region 公开方法

        public void InitializeColor()
        {
            this.currentValue = this.ColorValue;
            this.defaultColorValue = this.ColorValue;

            this.ColorObject.CurrentValue_A_SlideValue = this.currentValue.A;
            this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
            this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
            this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;
            this.gradual_color = Color.FromArgb(byte.MaxValue, this.currentValue);
            this.ColorObject.GradualSelectPoint = Point.Empty;
            this.Update_Gradual_Image();
            this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
            this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
            this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
            this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

            this.UpdateColorText();
        }

        public Color? ValidColor(string color)
        {
            color = color.Replace(" ", "");
            Color? color_tmp = null;
            string argb_reg = @"^((2[0-4][0-9]|25[0-5]|[01]?[0-9][0-9]?),){2}((2[0-4][0-9]|25[0-5]|[01]?[0-9][0-9]?),)?(2[0-4][0-9]|25[0-5]|[01]?[0-9][0-9]?)$"; string h16_reg = @"^#([0-9a-fA-F]{6}[0-9a-fA-F]{8}|[0-9a-fA-F]{3}|[0-9a-fA-F]{4})$"; if (Regex.IsMatch(color, argb_reg))
            {
                string[] color_arr = color.Split(',');
                if (color_arr.Length == 3)
                {
                    color_tmp = Color.FromArgb(255, int.Parse(color_arr[0]), int.Parse(color_arr[1]), int.Parse(color_arr[2]));
                }
                else if (color_arr.Length == 4)
                {
                    color_tmp = Color.FromArgb(int.Parse(color_arr[0]), int.Parse(color_arr[1]), int.Parse(color_arr[2]), int.Parse(color_arr[3]));
                }
            }
            else if (Regex.IsMatch(color, h16_reg))
            {
                color_tmp = ColorTranslator.FromHtml(color);
            }
            return color_tmp;
        }

        public void UpdateDateValueNotInvalidate(Color color)
        {
            if (this.colorValue == color)
                return;

            ColorValueChangedEventArgs arg = new ColorValueChangedEventArgs() { OldColorValue = this.colorValue, NewColorValue = color };
            this.colorValue = color;

            this.OnColorValueChanged(arg);
        }

        #endregion

        #region  类

        [Description("顶部选项")]
        public class TopBarItemClass
        {
            public ColorPickerExt parent;
            public ColorClass ower;

            public TopBarItemClass(ColorPickerExt parent, ColorClass ower)
            {
                this.parent = parent;
                this.ower = ower;
            }

            public Rectangle Rect;

            public string Text;

        }

        [Description("底部选项")]
        public class BottomBarItemClass
        {
            public ColorPickerExt parent;
            public ColorClass ower;

            public BottomBarItemClass(ColorPickerExt parent, ColorClass ower)
            {
                this.parent = parent;
                this.ower = ower;
            }

            public Rectangle Rect;

            public string Text;

            private ColorItemMoveStatuss moveStatus = ColorItemMoveStatuss.Normal;
            [DefaultValue(ColorItemMoveStatuss.Normal)]
            [Description("底部选项鼠标状态")]
            public ColorItemMoveStatuss MoveStatus
            {
                get { return this.moveStatus; }
                set
                {
                    if (this.moveStatus == value)
                        return;
                    this.moveStatus = value;
                    if (this.parent != null)
                    {
                        this.parent.Invalidate();
                    }
                }
            }

        }

        [Description("颜色面板")]
        public class ColorClass
        {
            public ColorPickerExt parent;

            public ColorClass(ColorPickerExt parent)
            {
                this.parent = parent;

                this.DefaultColorBtn = new TopBarItemClass(parent, this) { Text = "默认颜色" };
                this.HtmlColorBtn = new TopBarItemClass(parent, this) { Text = "Html颜色" };

                this.ThemeColorsItem = new ColorItemClass[ColorManage.ThemeColors.GetLength(0), ColorManage.ThemeColors.GetLength(1)];
                for (int i = 0; i < ColorManage.ThemeColors.GetLength(0); i++)
                {
                    for (int j = 0; j < ColorManage.ThemeColors.GetLength(1); j++)
                    {
                        this.ThemeColorsItem[i, j] = new ColorItemClass(parent, this);
                    }
                }
                this.StandardColorsItem = new ColorItemClass[ColorManage.StandardColors.GetLength(0), ColorManage.StandardColors.GetLength(1)];
                for (int i = 0; i < ColorManage.StandardColors.GetLength(0); i++)
                {
                    for (int j = 0; j < ColorManage.StandardColors.GetLength(1); j++)
                    {
                        this.StandardColorsItem[i, j] = new ColorItemClass(parent, this);
                    }
                }

                this.HtmlColorsItem = new List<HtmlColorsRectItem>();
                for (int i = 0; i < ColorManage.HtmlColors.Count; i++)
                {
                    HtmlColorsRectItem RectItem = new HtmlColorsRectItem();
                    for (int j = 0; j < ColorManage.HtmlColors[i].Colors.Count; j++)
                    {
                        RectItem.ColorsRects.Add(new HtmlColorsRectPointItem() { pointfs = new PointF[6] });
                    }
                    HtmlColorsItem.Add(RectItem);
                }

                this.CustomColorsItem = new ColorItemClass[ColorManage.CustomColors.GetLength(0), ColorManage.CustomColors.GetLength(1)];
                for (int i = 0; i < ColorManage.CustomColors.GetLength(0); i++)
                {
                    for (int j = 0; j < ColorManage.CustomColors.GetLength(1); j++)
                    {
                        this.CustomColorsItem[i, j] = new ColorItemClass(parent, this);
                    }
                }

                this.CustomBtn = new BottomBarItemClass(parent, this) { Text = "自定义颜色", MoveStatus = ColorItemMoveStatuss.Normal };
                this.ClearBtn = new BottomBarItemClass(parent, this) { Text = "清除", MoveStatus = ColorItemMoveStatuss.Normal };
                this.ConfirmBtn = new BottomBarItemClass(parent, this) { Text = "确定", MoveStatus = ColorItemMoveStatuss.Normal };
            }

            public TopBarItemClass DefaultColorBtn;
            public TopBarItemClass HtmlColorBtn;

            public Rectangle ColorRect;

            public Rectangle ThemeTitleRect;
            public Rectangle ThemeRect;
            public ColorItemClass[,] ThemeColorsItem;

            public Rectangle StandardTitleRect;
            public Rectangle StandardRect;
            public ColorItemClass[,] StandardColorsItem;

            public List<HtmlColorsRectItem> HtmlColorsItem;

            public Rectangle CustomTitleRect;
            public Rectangle CustomRect;
            public ColorItemClass[,] CustomColorsItem;

            public Rectangle CurrentColorTextRect;
            public Rectangle CurrentColorRect;
            public Rectangle OriginalColorTextRect;
            public Rectangle OriginalColorRect;

            public Rectangle GradualRect;
            public Point GradualSelectPoint = Point.Empty;
            public Rectangle GradualBarRect;
            public Rectangle GradualBarSlideRect;
            public int GradualBarSlideValue;

            public Rectangle CurrentValue_A_Rect;
            public Rectangle CurrentValue_A_SlideRect;
            public int CurrentValue_A_SlideValue;
            public Rectangle CurrentValue_R_Rect;
            public Rectangle CurrentValue_R_SlideRect;
            public int CurrentValue_R_SlideValue;
            public Rectangle CurrentValue_G_Rect;
            public Rectangle CurrentValue_G_SlideRect;
            public int CurrentValue_G_SlideValue;
            public Rectangle CurrentValue_B_Rect;
            public Rectangle CurrentValue_B_SlideRect;
            public int CurrentValue_B_SlideValue;

            public BottomBarItemClass CustomBtn;
            public BottomBarItemClass ClearBtn;
            public BottomBarItemClass ConfirmBtn;
        }

        [Description("颜色面板选项")]
        public class ColorItemClass
        {
            public ColorPickerExt parent;
            public ColorClass ower;

            public ColorItemClass(ColorPickerExt parent, ColorClass ower)
            {
                this.parent = parent;
                this.ower = ower;
            }

            public Rectangle Rect;
            public int ColorRowIndex;
            public int ColorColIndex;

            private ColorItemMoveStatuss moveStatus = ColorItemMoveStatuss.Normal;
            [DefaultValue(ColorItemMoveStatuss.Normal)]
            [Description("选项鼠标状态")]
            public ColorItemMoveStatuss MoveStatus
            {
                get { return this.moveStatus; }
                set
                {
                    if (this.moveStatus == value)
                        return;
                    this.moveStatus = value;
                    if (this.parent != null)
                    {
                        this.parent.Invalidate();
                    }
                }
            }
        }

        [Description("html颜色集合")]
        public class HtmlColorsItem
        {
            public List<Color> Colors = new List<Color>();
        }

        [Description("html颜色选项集合")]
        public class HtmlColorsRectItem
        {
            public List<HtmlColorsRectPointItem> ColorsRects = new List<HtmlColorsRectPointItem>();
        }

        [Description("html颜色选项")]
        public class HtmlColorsRectPointItem
        {
            public PointF[] pointfs;
        }

        [Description("画笔管理")]
        public class SolidBrushManage
        {
            private ColorPickerExt ower;

            public SolidBrushManage(ColorPickerExt ower)
            {
                this.ower = ower;
            }

            private Rectangle gradual_rect
            {
                get { return new Rectangle(0, 0, this.ower.ColorObject.GradualRect.Width - 1, this.ower.ColorObject.GradualRect.Height - 1); }
            }

            private Rectangle argb_lgb_rect
            {
                get { return new Rectangle(this.ower.ColorObject.CurrentValue_A_Rect.X - 1, 0, this.ower.ColorObject.CurrentValue_A_Rect.Width, this.ower.ColorObject.CurrentValue_A_Rect.Height); }
            }

            #region

            private ImageAttributes _back_image_ia = null;
            public ImageAttributes back_image_ia
            {
                get
                {
                    if (this._back_image_ia == null)
                    {
                        this._back_image_ia = new ImageAttributes();
                        this.back_image_ia.SetWrapMode(WrapMode.Tile);
                    }
                    return this._back_image_ia;
                }
            }

            private LinearGradientBrush _gradual_h_lgb = null;
            public LinearGradientBrush gradual_h_lgb
            {
                get
                {
                    if (this._gradual_h_lgb == null)
                        this._gradual_h_lgb = new LinearGradientBrush(this.gradual_rect, Color.White, Color.Transparent, 0f);
                    return this._gradual_h_lgb;
                }
            }

            private LinearGradientBrush _gradual_v_lgb = null;
            public LinearGradientBrush gradual_v_lgb
            {
                get
                {
                    if (this._gradual_v_lgb == null)
                        this._gradual_v_lgb = new LinearGradientBrush(this.gradual_rect, Color.Transparent, Color.Black, 90f);
                    return this._gradual_v_lgb;
                }
            }

            private LinearGradientBrush _argb_lgb = null;
            public LinearGradientBrush argb_lgb
            {
                get
                {
                    if (this._argb_lgb == null)
                        this._argb_lgb = new LinearGradientBrush(this.argb_lgb_rect, Color.Transparent, Color.Yellow, 0f);
                    return this._argb_lgb;
                }
            }

            private Pen _border_pen = null;
            public Pen border_pen
            {
                get
                {
                    if (this._border_pen == null)
                        this._border_pen = new Pen(Color.FromArgb(100, 102, 102, 102), 1);
                    return this._border_pen;
                }
            }

            private Pen _border_ts_pen = null;
            public Pen border_ts_pen
            {
                get
                {
                    if (this._border_ts_pen == null)
                        this._border_ts_pen = new Pen(Color.FromArgb(255, 193, 7), 1);
                    return this._border_ts_pen;
                }
            }

            private Pen _border_slide_pen = null;
            public Pen border_slide_pen
            {
                get
                {
                    if (this._border_slide_pen == null)
                        this._border_slide_pen = new Pen(Color.FromArgb(200, 105, 105, 105), 1);
                    return this._border_slide_pen;
                }
            }

            private SolidBrush _common_sb = null;
            public SolidBrush common_sb
            {
                get
                {
                    if (this._common_sb == null)
                        this._common_sb = new SolidBrush(Color.White);
                    return this._common_sb;
                }
            }

            private Pen _common_pen = null;
            public Pen common_pen
            {
                get
                {
                    if (this._common_pen == null)
                        this._common_pen = new Pen(Color.White, 1);
                    return this._common_pen;
                }
            }

            #endregion

            #region 字体

            private Font _text_font = null;
            public Font text_font
            {
                get
                {
                    if (this._text_font == null)
                        this._text_font = new Font("微软雅黑", 9);
                    return this._text_font;
                }
            }

            #endregion


            public void ReleaseSolidBrushs()
            {
                #region
                if (this._back_image_ia != null)
                {
                    this._back_image_ia.Dispose();
                    this._back_image_ia = null;
                }
                if (this.gradual_h_lgb != null)
                {
                    this._gradual_h_lgb.Dispose();
                    this._gradual_h_lgb = null;
                }
                if (this.gradual_v_lgb != null)
                {
                    this._gradual_v_lgb.Dispose();
                    this._gradual_v_lgb = null;
                }
                if (this.argb_lgb != null)
                {
                    this._argb_lgb.Dispose();
                    this._argb_lgb = null;
                }
                if (this.border_pen != null)
                {
                    this._border_pen.Dispose();
                    this._border_pen = null;
                }
                if (this.border_ts_pen != null)
                {
                    this._border_ts_pen.Dispose();
                    this._border_ts_pen = null;
                }
                if (this.border_slide_pen != null)
                {
                    this._border_slide_pen.Dispose();
                    this._border_slide_pen = null;
                }
                if (this.common_sb != null)
                {
                    this._common_sb.Dispose();
                    this._common_sb = null;
                }
                if (this.common_pen != null)
                {
                    this._common_pen.Dispose();
                    this._common_pen = null;
                }
                #endregion

                #region 字体
                if (this.text_font != null)
                {
                    this._text_font.Dispose();
                    this._text_font = null;
                }
                #endregion
            }
        }

        [Description("颜色表管理")]
        public static class ColorManage
        {
            public static readonly Color[,] ThemeColors = new Color[10, 6] {
         { Color.FromArgb(255, 255, 255), Color.FromArgb(242, 242, 242), Color.FromArgb(216, 216, 216), Color.FromArgb(191, 191, 191), Color.FromArgb(165, 165, 165), Color.FromArgb(127, 127, 127) },
         { Color.FromArgb(0, 0, 0), Color.FromArgb(127, 127, 127), Color.FromArgb(89, 89, 89), Color.FromArgb(63, 63, 63), Color.FromArgb(38, 38, 38), Color.FromArgb(12, 12, 12) },
         { Color.FromArgb(238, 236, 225), Color.FromArgb(221, 217, 195), Color.FromArgb(196, 189, 151), Color.FromArgb(147, 137, 83), Color.FromArgb(73, 68, 41), Color.FromArgb(29, 27, 16) },
         { Color.FromArgb(31, 73, 125), Color.FromArgb(198, 217, 240), Color.FromArgb(141, 179, 226), Color.FromArgb(84, 141, 212), Color.FromArgb(23, 54, 93), Color.FromArgb(15, 36, 62) },
         { Color.FromArgb(79, 129, 189), Color.FromArgb(219, 229, 241), Color.FromArgb(184, 204, 228), Color.FromArgb(149, 179, 215), Color.FromArgb(54, 96, 146), Color.FromArgb(36, 64, 97) },
         { Color.FromArgb(192, 80, 77), Color.FromArgb(242, 220, 219), Color.FromArgb(229, 185, 183), Color.FromArgb(217, 150, 148), Color.FromArgb(149, 55, 52), Color.FromArgb(99, 36, 35) },
         { Color.FromArgb(155, 187, 89), Color.FromArgb(235, 241, 221), Color.FromArgb(215, 227, 188), Color.FromArgb(195, 214, 155), Color.FromArgb(118, 146, 60), Color.FromArgb(79, 97, 40) },
         { Color.FromArgb(128, 100, 162), Color.FromArgb(229, 224, 236), Color.FromArgb(204, 193, 217), Color.FromArgb(178, 162, 199), Color.FromArgb(95, 73, 122), Color.FromArgb(63, 49, 81) },
         { Color.FromArgb(75, 172, 198), Color.FromArgb(219, 238, 243), Color.FromArgb(183, 221, 232), Color.FromArgb(146, 205, 220), Color.FromArgb(49, 133, 155), Color.FromArgb(32, 88, 103) },
         { Color.FromArgb(247, 150, 70), Color.FromArgb(253, 234, 218), Color.FromArgb(251, 213, 181), Color.FromArgb(250, 192, 143), Color.FromArgb(227, 108, 9), Color.FromArgb(151, 72, 6) },
         };

            public static readonly Color[,] StandardColors = new Color[2, 10] {
         { Color.FromArgb(244, 67, 54), Color.FromArgb(233, 30, 99),Color.FromArgb(160, 115, 232), Color.FromArgb(156, 39, 176), Color.FromArgb(103, 58, 183), Color.FromArgb(63, 81, 181), Color.FromArgb(33, 150, 243), Color.FromArgb(33, 150, 243), Color.FromArgb(0, 188, 212),Color.FromArgb(158, 158, 158) },
         {Color.FromArgb(1, 255, 255), Color.FromArgb(0, 150, 136), Color.FromArgb(76, 175, 80), Color.FromArgb(139, 195, 74), Color.FromArgb(205, 220, 57), Color.FromArgb(255, 235, 59), Color.FromArgb(255, 193, 7), Color.FromArgb(255, 152, 0), Color.FromArgb(255, 87, 34),Color.FromArgb(121, 85, 72) }
         };

            public static Color[,] CustomColors = new Color[2, 10] {
         { Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0)},
         { Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0)}
         };

            public static readonly Color[] GradualBarcolors = new Color[7] { Color.FromArgb(255, 0, 0), Color.FromArgb(255, 255, 0), Color.FromArgb(0, 255, 0), Color.FromArgb(0, 255, 255), Color.FromArgb(0, 0, 255), Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 0) };
            public static readonly float[] GradualBarInterval = new float[7] { 0.0f, 0.17f, 0.33f, 0.50f, 0.67f, 0.83f, 1.0f };

            public static List<HtmlColorsItem> HtmlColors = new List<HtmlColorsItem>() {
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#003366"),ColorTranslator.FromHtml("#336699"),ColorTranslator.FromHtml("#3366cc"),ColorTranslator.FromHtml("#003399"),ColorTranslator.FromHtml("#000099"),ColorTranslator.FromHtml("#0000cc"),ColorTranslator.FromHtml("#000066")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#006666"),ColorTranslator.FromHtml("#006699"),ColorTranslator.FromHtml("#0099cc"),ColorTranslator.FromHtml("#0066cc"),ColorTranslator.FromHtml("#0033cc"),ColorTranslator.FromHtml("#0000ff"),ColorTranslator.FromHtml("#3333ff"),ColorTranslator.FromHtml("#333399") }},
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#669999"),ColorTranslator.FromHtml("#009999"),ColorTranslator.FromHtml("#33cccc"),ColorTranslator.FromHtml("#00ccff"),ColorTranslator.FromHtml("#0099ff"),ColorTranslator.FromHtml("#0066ff"),ColorTranslator.FromHtml("#3366ff"),ColorTranslator.FromHtml("#3333cc"),ColorTranslator.FromHtml("#666699")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#339966"),ColorTranslator.FromHtml("#00cc99"),ColorTranslator.FromHtml("#00ffcc"),ColorTranslator.FromHtml("#00ffff"),ColorTranslator.FromHtml("#33ccff"),ColorTranslator.FromHtml("#3399ff"),ColorTranslator.FromHtml("#6699ff"),ColorTranslator.FromHtml("#6666ff"),ColorTranslator.FromHtml("#6600ff"),ColorTranslator.FromHtml("#6600cc")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#339933"),ColorTranslator.FromHtml("#00cc66"),ColorTranslator.FromHtml("#00ff99"),ColorTranslator.FromHtml("#66ffcc"),ColorTranslator.FromHtml("#66ffff"),ColorTranslator.FromHtml("#66ccff"),ColorTranslator.FromHtml("#99ccff"),ColorTranslator.FromHtml("#9999ff"),ColorTranslator.FromHtml("#9966ff"),ColorTranslator.FromHtml("#9933ff"),ColorTranslator.FromHtml("#9900ff")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#006600"),ColorTranslator.FromHtml("#00cc00"),ColorTranslator.FromHtml("#00ff00"),ColorTranslator.FromHtml("#66ff99"),ColorTranslator.FromHtml("#99ffcc"),ColorTranslator.FromHtml("#ccffff"),ColorTranslator.FromHtml("#ccccff"),ColorTranslator.FromHtml("#cc99ff"),ColorTranslator.FromHtml("#cc66ff"),ColorTranslator.FromHtml("#cc33ff"),ColorTranslator.FromHtml("#cc00ff"),ColorTranslator.FromHtml("#9900cc")}},
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#003300"),ColorTranslator.FromHtml("#009933"),ColorTranslator.FromHtml("#33cc33"),ColorTranslator.FromHtml("#66ff66"),ColorTranslator.FromHtml("#99ff99"),ColorTranslator.FromHtml("#ccffcc"),ColorTranslator.FromHtml("#ffffff"),ColorTranslator.FromHtml("#ffccff"),ColorTranslator.FromHtml("#ff99ff"),ColorTranslator.FromHtml("#ff66ff"),ColorTranslator.FromHtml("#ff00ff"),ColorTranslator.FromHtml("#cc00cc"),ColorTranslator.FromHtml("#660066")} },
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#333300"),ColorTranslator.FromHtml("#009900"),ColorTranslator.FromHtml("#66ff33"),ColorTranslator.FromHtml("#99ff66"),ColorTranslator.FromHtml("#ccff99"),ColorTranslator.FromHtml("#ffffcc"),ColorTranslator.FromHtml("#ffcccc"),ColorTranslator.FromHtml("#ff99cc"),ColorTranslator.FromHtml("#ff66cc"),ColorTranslator.FromHtml("#ff33cc"),ColorTranslator.FromHtml("#cc0099"),ColorTranslator.FromHtml("#993399")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#336600"),ColorTranslator.FromHtml("#669900"),ColorTranslator.FromHtml("#99ff33"),ColorTranslator.FromHtml("#ccff66"),ColorTranslator.FromHtml("#ffff99"),ColorTranslator.FromHtml("#ffcc99"),ColorTranslator.FromHtml("#ff9999"),ColorTranslator.FromHtml("#ff6699"),ColorTranslator.FromHtml("#ff3399"),ColorTranslator.FromHtml("#cc3399"),ColorTranslator.FromHtml("#990099")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#666633"),ColorTranslator.FromHtml("#99cc00"),ColorTranslator.FromHtml("#ccff33"),ColorTranslator.FromHtml("#ffff66"),ColorTranslator.FromHtml("#ffcc66"),ColorTranslator.FromHtml("#ff9966"),ColorTranslator.FromHtml("#ff6666"),ColorTranslator.FromHtml("#ff0066"),ColorTranslator.FromHtml("#d60094"),ColorTranslator.FromHtml("#993366")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#a58800"),ColorTranslator.FromHtml("#cccc00"),ColorTranslator.FromHtml("#ffff00"),ColorTranslator.FromHtml("#ffcc00"),ColorTranslator.FromHtml("#ff9933"),ColorTranslator.FromHtml("#ff6600"),ColorTranslator.FromHtml("#ff0033"),ColorTranslator.FromHtml("#cc0066"),ColorTranslator.FromHtml("#660033")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#996633"),ColorTranslator.FromHtml("#cc9900"),ColorTranslator.FromHtml("#ff9900"),ColorTranslator.FromHtml("#cc6600"),ColorTranslator.FromHtml("#ff3300"),ColorTranslator.FromHtml("#ff0000"),ColorTranslator.FromHtml("#cc0000"),ColorTranslator.FromHtml("#990033")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#663300"),ColorTranslator.FromHtml("#996600"),ColorTranslator.FromHtml("#cc3300"),ColorTranslator.FromHtml("#993300"),ColorTranslator.FromHtml("#990000"),ColorTranslator.FromHtml("#800000"),ColorTranslator.FromHtml("#993333")}}
                };

        }

        [Description("颜色值更改事件参数")]
        public class ColorValueChangedEventArgs : EventArgs
        {
            [Description("更改前颜色")]
            public Color OldColorValue { get; set; }
            [Description("更改后颜色")]
            public Color NewColorValue { get; set; }
        }

        [Description("html选项单击事件参数")]
        public class HtmlColorItemClickEventArgs : EventArgs
        {
            [Description("html颜色面板选项")]
            public HtmlColorsRectPointItem Item { get; set; }
        }

        [Description("颜色选项单击事件参数")]
        public class ColorItemClickEventArgs : EventArgs
        {
            [Description("颜色面板选项")]
            public ColorItemClass Item { get; set; }
        }

        [Description("底部选项单击事件参数")]
        public class BottomBarIiemClickEventArgs : EventArgs
        {
            [Description("底部选项")]
            public BottomBarItemClass Item { get; set; }
        }

        #endregion

        #region 枚举

        [Description("鼠标在选项上状态")]
        public enum ColorItemMoveStatuss
        {
            Normal,
            Enter
        }

        [Description("鼠标状态")]
        public enum ColorMoveStatuss
        {
            Normal,
            HtmlDown,
            ThemeDown,
            StandardDown,
            GradualDown,
            GradualBarDown,
            ADown,
            RDown,
            GDown,
            BDown,
            CustomDown,
            ClearDown,
            ConfirmDown
        }

        [Description("颜色面板选中类型")]
        public enum colorTypes
        {
            Default,
            Html
        }

        #endregion
    }

    [ToolboxItem(false)]
    [Description("颜色文本输入框")]
    public class ColorTextBox : TextBox
    {
        #region 重写属性

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new bool DesignMode
        {
            get
            {
                if (this.GetService(typeof(IDesignerHost)) != null || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region 扩展

        private const int WM_RBUTTONDOWN = 0x0204;

        #endregion

        public ColorTextBox()
        {
            this.ImeMode = ImeMode.Off;
            this.TextAlign = HorizontalAlignment.Right;
            this.TabStop = false;
            this.Cursor = Cursors.Default;
            this.BorderStyle = BorderStyle.None;
            this.ForeColor = Color.FromArgb(105, 105, 105);
        }

        #region 重写

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            switch (e.KeyCode)
            {
                #region Number
                case Keys.D0:
                case Keys.NumPad0:
                case Keys.D1:
                case Keys.NumPad1:
                case Keys.D2:
                case Keys.NumPad2:
                case Keys.D3:
                case Keys.NumPad3:
                case Keys.D4:
                case Keys.NumPad4:
                case Keys.D5:
                case Keys.NumPad5:
                case Keys.D6:
                case Keys.NumPad6:
                case Keys.D7:
                case Keys.NumPad7:
                case Keys.D8:
                case Keys.NumPad8:
                case Keys.D9:
                case Keys.NumPad9:
                case Keys.Oemcomma:
                case Keys.Left:
                case Keys.Right:
                case Keys.Back:
                case Keys.Control:
                case Keys.ControlKey:
                    {
                        e.SuppressKeyPress = false;
                        break;
                    }
                case Keys.A:
                case Keys.V:
                    {
                        if (e.Control)
                            e.SuppressKeyPress = false;
                        else
                            e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.C:
                    {
                        if (e.Control)
                        {
                            this.SelectAll();
                            e.SuppressKeyPress = false;
                        }
                        else
                            e.SuppressKeyPress = true;
                        break;
                    }
                #endregion
                default:
                    {
                        e.SuppressKeyPress = true;
                        break;
                    }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_RBUTTONDOWN) return;
            base.WndProc(ref m);
        }

        #endregion
    }
}
