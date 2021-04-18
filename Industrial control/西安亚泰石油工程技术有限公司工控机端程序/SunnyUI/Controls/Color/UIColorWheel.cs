using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sunny.UI
{
    [ToolboxItem(false)]
    public sealed class UIColorWheel : Control, IStyleInterface
    {
        public event EventHandler SelectedColorChanged;

        private Color m_frameColor = UIColor.Blue;
        private HSLColor m_selectedColor = new HSLColor(Color.BlanchedAlmond);
        private PathGradientBrush m_brush;
        private readonly List<PointF> m_path = new List<PointF>();
        private readonly List<Color> m_colors = new List<Color>();
        private double m_wheelLightness = 0.5;

        public HSLColor SelectedHSLColor
        {
            get { return m_selectedColor; }
            set
            {
                if (m_selectedColor.Equals(value))
                    return;
                Invalidate(UIColorUtil.Rect(ColorSelectorRectangle));
                m_selectedColor = value;
                SelectedColorChanged?.Invoke(this, null);
                Refresh();//Invalidate(UIColorUtil.Rect(ColorSelectorRectangle));
            }
        }

        public void SetLightness(double lightness)
        {
            m_selectedColor.Lightness = lightness;
            Invalidate(UIColorUtil.Rect(ColorSelectorRectangle));
            SelectedColorChanged?.Invoke(this, null);
            Refresh();//Invalidate(UIColorUtil.Rect(ColorSelectorRectangle));
        }

        public Color SelectedColor
        {
            get { return m_selectedColor.Color; }
            set
            {
                if (m_selectedColor.Color != value)
                    SelectedHSLColor = new HSLColor(value);
            }
        }

        public Color FrameColor
        {
            get => m_frameColor;
            set
            {
                m_frameColor = value;
                Invalidate();
            }
        }

        public UIColorWheel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            Width = Height = 148;
            Version = UIGlobal.Version;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Width != Height)
            {
                Height = Width;
            }

            using (SolidBrush b = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(b, ClientRectangle);
            }

            RectangleF wheelRectangle = WheelRectangle;
            UIColorUtil.DrawFrame(e.Graphics, wheelRectangle, 6, m_frameColor);
            wheelRectangle = ColorWheelRectangle;
            PointF center = UIColorUtil.Center(wheelRectangle);
            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            if (m_brush == null)
            {
                m_brush = new PathGradientBrush(m_path.ToArray(), WrapMode.Clamp);
                m_brush.CenterPoint = center;
                m_brush.CenterColor = Color.White;
                m_brush.SurroundColors = m_colors.ToArray();
            }

            e.Graphics.FillPie(m_brush, UIColorUtil.Rect(wheelRectangle), 0, 360);
            e.Graphics.DrawEllipse(BackColor, wheelRectangle);

            DrawColorSelector(e.Graphics);

            if (Focused)
            {
                RectangleF r = WheelRectangle;
                r.Inflate(-2, -2);
                ControlPaint.DrawFocusRectangle(e.Graphics, UIColorUtil.Rect(r));
            }

            e.Graphics.Smooth(false);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            m_brush?.Dispose();
            m_brush = null;
            ReCalcWheelPoints();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            PointF mousePoint = new PointF(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
                SetColor(mousePoint);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
            PointF mousePoint = new PointF(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
                SetColor(mousePoint);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            HSLColor c = SelectedHSLColor;
            double hue = c.Hue;
            int step = 1;
            if ((keyData & Keys.Control) == Keys.Control) step = 5;
            if ((keyData & Keys.Up) == Keys.Up) hue += step;
            if ((keyData & Keys.Down) == Keys.Down) hue -= step;
            if (hue >= 360) hue = 0;
            if (hue < 0) hue = 359;

            if (hue != c.Hue)
            {
                c.Hue = hue;
                SelectedHSLColor = c;
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private RectangleF ColorSelectorRectangle
        {
            get
            {
                HSLColor color = m_selectedColor;
                double angleR = color.Hue * Math.PI / 180;
                PointF center = UIColorUtil.Center(ColorWheelRectangle);
                double radius = Radius(ColorWheelRectangle);
                radius *= color.Saturation;
                double x = center.X + Math.Cos(angleR) * radius;
                double y = center.Y - Math.Sin(angleR) * radius;
                Rectangle selectorRectangle = new Rectangle(new Point((int)x, (int)y), new Size(0, 0));
                selectorRectangle.Inflate(12, 12);
                return selectorRectangle;
            }
        }

        private void DrawColorSelector(Graphics dc)
        {
            Rectangle r = UIColorUtil.Rect(ColorSelectorRectangle);
            PointF center = UIColorUtil.Center(r);
            Image image = SelectorImages.Image(SelectorImages.eIndexes.Donut);
            dc.DrawImageUnscaled(image, (int)(center.X - image.Width / 2.0), (int)(center.Y - image.Height / 2.0));
        }

        private RectangleF WheelRectangle
        {
            get
            {
                Rectangle r = ClientRectangle;
                r.Width -= 1;
                r.Height -= 1;
                return r;
            }
        }

        private RectangleF ColorWheelRectangle
        {
            get
            {
                RectangleF r = WheelRectangle;
                r.Inflate(-5, -5);
                return r;
            }
        }

        private float Radius(RectangleF r)
        {
            return Math.Min((r.Width / 2), (r.Height / 2));
        }

        private void ReCalcWheelPoints()
        {
            m_path.Clear();
            m_colors.Clear();

            PointF center = UIColorUtil.Center(ColorWheelRectangle);
            float radius = Radius(ColorWheelRectangle);
            double angle = 0;
            double fullCircle = 360;
            double step = 5;
            while (angle < fullCircle)
            {
                double angleR = angle * (Math.PI / 180);
                double x = center.X + Math.Cos(angleR) * radius;
                double y = center.Y - Math.Sin(angleR) * radius;
                m_path.Add(new PointF((float)x, (float)y));
                m_colors.Add(new HSLColor(angle, 1, m_wheelLightness).Color);
                angle += step;
            }
        }

        private void SetColor(PointF mousePoint)
        {
            if (WheelRectangle.Contains(mousePoint) == false)
                return;

            PointF center = UIColorUtil.Center(ColorWheelRectangle);
            double radius = Radius(ColorWheelRectangle);
            double dx = Math.Abs(mousePoint.X - center.X);
            double dy = Math.Abs(mousePoint.Y - center.Y);
            double angle = Math.Atan(dy / dx) / Math.PI * 180;
            double dist = Math.Pow((Math.Pow(dx, 2) + (Math.Pow(dy, 2))), 0.5);
            double saturation = dist / radius;
            //if (dist > radius + 5) // give 5 pixels slack
            //	return;
            if (dist < 6)
                saturation = 0; // snap to center

            if (mousePoint.X < center.X)
                angle = 180 - angle;
            if (mousePoint.Y > center.Y)
                angle = 360 - angle;

            SelectedHSLColor = new HSLColor(angle, saturation, SelectedHSLColor.Lightness);
        }

        private UIStyle _style = UIStyle.Blue;

        /// <summary>
        /// ������ʽ
        /// </summary>
        [DefaultValue(UIStyle.Blue), Description("������ʽ"), Category("SunnyUI")]
        public UIStyle Style
        {
            get => _style;
            set => SetStyle(value);
        }

        /// <summary>
        /// ����������ʽ
        /// </summary>
        /// <param name="style">������ʽ</param>
        public void SetStyle(UIStyle style)
        {
            SetStyleColor(UIStyles.GetStyleColor(style));
            _style = style;
        }

        /// <summary>
        /// ����������ʽ��ɫ
        /// </summary>
        /// <param name="uiColor"></param>
        public void SetStyleColor(UIBaseStyle uiColor)
        {
            if (uiColor.IsCustom()) return;
            FrameColor = uiColor.RectColor;
            BackColor = uiColor.PlainColor;
            Invalidate();
        }

        /// <summary>
        /// �Զ���������
        /// </summary>
        [DefaultValue(false)]
        [Description("��ȡ�����ÿ����Զ���������"), Category("SunnyUI")]
        public bool StyleCustomMode { get; set; }

        public string Version { get; }

        /// <summary>
        /// Tag�ַ���
        /// </summary>
        [DefaultValue(null)]
        [Description("��ȡ�����ð����йؿؼ������ݵĶ����ַ���"), Category("SunnyUI")]
        public string TagString { get; set; }
    }
}