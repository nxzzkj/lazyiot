using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sunny.UI
{
    [ToolboxItem(false)]
    public class LabelRotate : Control, IStyleInterface
    {
        private float m_textAngle = 0;
        private ContentAlignment m_rotatePointAlignment = ContentAlignment.MiddleCenter;
        private ContentAlignment m_textAlignment = ContentAlignment.MiddleLeft;

        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Refresh();
            }
        }

        public float TextAngle
        {
            get { return m_textAngle; }
            set
            {
                m_textAngle = value;
                Invalidate();
            }
        }

        public ContentAlignment TextAlign
        {
            get { return m_textAlignment; }
            set
            {
                m_textAlignment = value;
                Invalidate();
            }
        }

        public ContentAlignment RotatePointAlignment
        {
            get { return m_rotatePointAlignment; }
            set
            {
                m_rotatePointAlignment = value;
                Invalidate();
            }
        }

        private Color m_frameColor = UIColor.Blue;

        public Color FrameColor
        {
            get => m_frameColor;
            set
            {
                m_frameColor = value;
                Invalidate();
            }
        }

        public LabelRotate()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.Text = string.Empty;
            base.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            Version = UIGlobal.Version;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(BackColor, ClientRectangle);

            RectangleF lr = ClientRectangleF;
            UIColorUtil.DrawFrame(e.Graphics, lr, 6, m_frameColor);
            if (Text.Length > 0)
            {
                StringFormat format = new StringFormat();
                string alignment = TextAlign.ToString();

                if (((int)TextAlign & (int)(ContentAlignment.BottomLeft | ContentAlignment.MiddleLeft | ContentAlignment.TopLeft)) != 0)
                    format.Alignment = StringAlignment.Near;

                if (((int)TextAlign & (int)(ContentAlignment.BottomCenter | ContentAlignment.MiddleCenter | ContentAlignment.TopCenter)) != 0)
                    format.Alignment = StringAlignment.Center;

                if (((int)TextAlign & (int)(ContentAlignment.BottomRight | ContentAlignment.MiddleRight | ContentAlignment.TopRight)) != 0)
                    format.Alignment = StringAlignment.Far;

                if (((int)TextAlign & (int)(ContentAlignment.BottomLeft | ContentAlignment.BottomCenter | ContentAlignment.BottomRight)) != 0)
                    format.LineAlignment = StringAlignment.Far;

                if (((int)TextAlign & (int)(ContentAlignment.MiddleLeft | ContentAlignment.MiddleCenter | ContentAlignment.MiddleRight)) != 0)
                    format.LineAlignment = StringAlignment.Center;

                if (((int)TextAlign & (int)(ContentAlignment.TopLeft | ContentAlignment.TopCenter | ContentAlignment.TopRight)) != 0)
                    format.LineAlignment = StringAlignment.Near;

                Rectangle r = ClientRectangle;
                r.X += Padding.Left;
                r.Y += Padding.Top;
                r.Width -= Padding.Right;
                r.Height -= Padding.Bottom;

                using (SolidBrush b = new SolidBrush(ForeColor))
                {
                    if (TextAngle.EqualsFloat(0))
                    {
                        e.Graphics.DrawString(Text, Font, ForeColor, r, format);
                    }
                    else
                    {
                        PointF center = UIColorUtil.Center(ClientRectangle);
                        switch (RotatePointAlignment)
                        {
                            case ContentAlignment.TopLeft:
                                center.X = r.Left;
                                center.Y = r.Top;
                                break;

                            case ContentAlignment.TopCenter:
                                center.Y = r.Top;
                                break;

                            case ContentAlignment.TopRight:
                                center.X = r.Right;
                                center.Y = r.Top;
                                break;

                            case ContentAlignment.MiddleLeft:
                                center.X = r.Left;
                                break;

                            case ContentAlignment.MiddleCenter:
                                break;

                            case ContentAlignment.MiddleRight:
                                center.X = r.Right;
                                break;

                            case ContentAlignment.BottomLeft:
                                center.X = r.Left;
                                center.Y = r.Bottom;
                                break;

                            case ContentAlignment.BottomCenter:
                                center.Y = r.Bottom;
                                break;

                            case ContentAlignment.BottomRight:
                                center.X = r.Right;
                                center.Y = r.Bottom;
                                break;
                        }
                        center.X += Padding.Left;
                        center.Y += Padding.Top;
                        center.X -= Padding.Right;
                        center.Y -= Padding.Bottom;

                        e.Graphics.TranslateTransform(center.X, center.Y);
                        e.Graphics.RotateTransform(TextAngle);

                        e.Graphics.DrawString(Text, Font, b, new PointF(0, 0), format);
                        e.Graphics.ResetTransform();
                    }
                }
            }

            RaisePaintEvent(this, e);
        }

        protected RectangleF ClientRectangleF
        {
            get
            {
                RectangleF r = ClientRectangle;
                r.Width -= 1;
                r.Height -= 1;
                return r;
            }
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
        public virtual void SetStyleColor(UIBaseStyle uiColor)
        {
            if (uiColor.IsCustom()) return;
            FrameColor = uiColor.RectColor;
            ForeColor = uiColor.PanelForeColor;
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