using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace Scada.Controls
{
    public class ListViewEx : ListView
    {
        private Color _rowBackColor1 = Color.White;
        private Color _rowBackColor2 = Color.FromArgb(254, 216, 249);
        private Color _selectedColor = Color.FromArgb(166, 222, 255);
        private Color _headColor = Color.FromArgb(166, 222, 255);

        private HeaderNativeWindow _headerNativeWindow;

        private const int LVM_FIRST = 0x1000;
        private const int LVM_GETHEADER = (LVM_FIRST + 31);

        private const int HDI_ORDER = 0x0080;
        private const int HDI_WIDTH = 0x0001;
        private const int HDI_HEIGHT = HDI_WIDTH;

        private const int HDM_FIRST = 0x1200;
        private const int HDM_GETITEMCOUNT = (HDM_FIRST + 0);
        private const int HDM_GETITEMA = (HDM_FIRST + 3);
        private const int HDM_GETITEMRECT = (HDM_FIRST + 7);

        public ListViewEx()
            : base()
        {
            base.OwnerDraw = true;
        }

        [DefaultValue(typeof(Color), "White")]
        public Color RowBackColor1
        {
            get { return _rowBackColor1; }
            set
            {
                _rowBackColor1 = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "254, 216, 249")]
        public Color RowBackColor2
        {
            get { return _rowBackColor2; }
            set
            {
                _rowBackColor2 = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "166, 222, 255")]
        public Color SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "166, 222, 255")]
        public Color HeadColor
        {
            get { return _headColor; }
            set
            {
                _headColor = value;
                base.Invalidate(true);
            }
        }

        private IntPtr HeaderWnd
        {
            get { return new IntPtr(SendMessage(base.Handle, LVM_GETHEADER, 0, 0)); }
        }

        private int ColumnCount
        {
            get { return SendMessage(HeaderWnd, HDM_GETITEMCOUNT, 0, 0); }
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(
            IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(
            IntPtr hwnd, int msg, int wParam, ref HDITEM lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(
            IntPtr hwnd, int msg, int wParam, ref RECT lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr handle);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr handle, IntPtr hdc);

        [DllImport("user32.dll")]
        private static extern int OffsetRect(ref RECT lpRect, int x, int y);

        [DllImport("user32.dll")]
        private static extern bool ValidateRect(IntPtr hWnd, ref RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        private struct HDITEM
        {
            internal int mask;
            internal int cxy;
            internal string pszText;
            internal IntPtr hbm;
            internal int cchTextMax;
            internal int fmt;
            internal IntPtr lParam;
            internal int iImage;
            internal int iOrder;
            internal uint type;
            internal IntPtr pvFilter;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            internal RECT(int X, int Y, int Width, int Height)
            {
                this.Left = X;
                this.Top = Y;
                this.Right = Width;
                this.Bottom = Height;
            }
            internal int Left;
            internal int Top;
            internal int Right;
            internal int Bottom;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (_headerNativeWindow == null)
            {
                if (HeaderWnd != IntPtr.Zero)
                {
                    _headerNativeWindow = new HeaderNativeWindow(this);
                }
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            if (_headerNativeWindow != null)
            {
                _headerNativeWindow.Dispose();
                _headerNativeWindow = null;
            }
        }

        protected override void OnDrawColumnHeader(
            DrawListViewColumnHeaderEventArgs e)
        {
            base.OnDrawColumnHeader(e);

            Graphics g = e.Graphics;
            Rectangle bounds = e.Bounds;

            Color baseColor = _headColor;
            Color borderColor = _headColor;
            Color innerBorderColor = Color.FromArgb(150, 255, 255, 255);

            RenderBackgroundInternal(
                g,
                bounds,
                baseColor,
                borderColor,
                innerBorderColor,
                0.45f,
                true,
                LinearGradientMode.Vertical);

            TextFormatFlags flags = GetFormatFlags(e.Header.TextAlign);
            Rectangle textRect = new Rectangle(
                       bounds.X + 3,
                       bounds.Y,
                       bounds.Width - 6,
                       bounds.Height); ;

            if (e.Header.ImageList != null)
            {
                Image image = e.Header.ImageIndex == -1 ?
                    null : e.Header.ImageList.Images[e.Header.ImageIndex];
                if (image != null)
                {
                    Rectangle imageRect = new Rectangle(
                        bounds.X + 3,
                        bounds.Y + 2,
                        bounds.Height - 4,
                        bounds.Height - 4);
                    g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    g.DrawImage(image, imageRect);

                    textRect.X = imageRect.Right + 3;
                    textRect.Width -= imageRect.Width;
                }
            }
            TextRenderer.DrawText(
                   g,
                   e.Header.Text,
                   e.Font,
                   textRect,
                   e.ForeColor,
                   flags);
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (View != View.Details)
            {
                e.DrawDefault = true;
            }
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            base.OnDrawSubItem(e);
            if (View != View.Details)
            {
                return;
            }
            if (e.ItemIndex == -1)
            {
                return;
            }

            Rectangle bounds = e.Bounds;
            ListViewItemStates itemState = e.ItemState;
            Graphics g = e.Graphics;
            if ((itemState & ListViewItemStates.Selected)
                == ListViewItemStates.Selected)
            {
                bounds.Height--;
                Color baseColor = _selectedColor;
                Color borderColor = _selectedColor;
                Color innerBorderColor = Color.FromArgb(150, 255, 255, 255);

                RenderBackgroundInternal(
                    g,
                    bounds,
                    baseColor,
                    borderColor,
                    innerBorderColor,
                    0.45f,
                    true,
                    LinearGradientMode.Vertical);
                bounds.Height++;
            }
            else
            {
                Color backColor = e.ItemIndex % 2 == 0 ?
                _rowBackColor1 : _rowBackColor2;

                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    g.FillRectangle(brush, bounds);
                }
            }

            TextFormatFlags flags = GetFormatFlags(e.Header.TextAlign);

            if (e.ColumnIndex == 0)
            {
                if (e.Item.ImageList == null)
                {
                    bounds.X += 3;
                    TextRenderer.DrawText(
                        g,
                        e.SubItem.Text,
                        e.SubItem.Font,
                        bounds,
                        e.Item.ForeColor,
                        flags);
                    return;
                }
                Image image = e.Item.ImageIndex == -1 ?
                    null : e.Item.ImageList.Images[e.Item.ImageIndex];
                if (image == null)
                {
                    bounds.X += 3;
                    TextRenderer.DrawText(
                        g,
                        e.SubItem.Text,
                        e.SubItem.Font,
                        bounds,
                        e.Item.ForeColor,
                        flags);
                    return;
                }
                Rectangle imageRect = new Rectangle(
                    bounds.X + 4,
                    bounds.Y + 2,
                    bounds.Height - 4,
                    bounds.Height - 4);
                g.DrawImage(image, imageRect);

                Rectangle textRect = new Rectangle(
                    imageRect.Right + 3,
                    bounds.Y,
                    bounds.Width - imageRect.Right - 3,
                    bounds.Height);
                TextRenderer.DrawText(
                    g,
                    e.SubItem.Text,
                    e.SubItem.Font,
                    textRect,
                    e.Item.ForeColor,
                    flags);
                return;
            }

            bounds.X += 3;
            TextRenderer.DrawText(
                g,
                e.SubItem.Text,
                e.SubItem.Font,
                bounds,
                e.Item.ForeColor,
                flags);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        protected TextFormatFlags GetFormatFlags(HorizontalAlignment align)
        {
            TextFormatFlags flags =
                    TextFormatFlags.EndEllipsis |
                    TextFormatFlags.VerticalCenter;

            switch (align)
            {
                case HorizontalAlignment.Center:
                    flags |= TextFormatFlags.HorizontalCenter;
                    break;
                case HorizontalAlignment.Right:
                    flags |= TextFormatFlags.Right;
                    break;
                case HorizontalAlignment.Left:
                    flags |= TextFormatFlags.Left;
                    break;
            }

            return flags;
        }

        internal void RenderBackgroundInternal(
          Graphics g,
          Rectangle rect,
          Color baseColor,
          Color borderColor,
          Color innerBorderColor,
          float basePosition,
          bool drawBorder,
          LinearGradientMode mode)
        {
            if (drawBorder)
            {
                rect.Width--;
                rect.Height--;
            }

            if (rect.Width <= 0 || rect.Height <= 0)
            {
                return;
            }

            using (LinearGradientBrush brush = new LinearGradientBrush(
               rect, Color.Transparent, Color.Transparent, mode))
            {
                Color[] colors = new Color[4];
                colors[0] = GetColor(baseColor, 0, 35, 24, 9);
                colors[1] = GetColor(baseColor, 0, 13, 8, 3);
                colors[2] = baseColor;
                colors[3] = GetColor(baseColor, 0, 68, 69, 54);

                ColorBlend blend = new ColorBlend();
                blend.Positions = new float[] { 0.0f, basePosition, basePosition + 0.05f, 1.0f };
                blend.Colors = colors;
                brush.InterpolationColors = blend;
                g.FillRectangle(brush, rect);
            }
            if (baseColor.A > 80)
            {
                Rectangle rectTop = rect;
                if (mode == LinearGradientMode.Vertical)
                {
                    rectTop.Height = (int)(rectTop.Height * basePosition);
                }
                else
                {
                    rectTop.Width = (int)(rect.Width * basePosition);
                }
                using (SolidBrush brushAlpha =
                    new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
                {
                    g.FillRectangle(brushAlpha, rectTop);
                }
            }

            if (drawBorder)
            {
                using (Pen pen = new Pen(borderColor))
                {
                    g.DrawRectangle(pen, rect);
                }

                rect.Inflate(-1, -1);
                using (Pen pen = new Pen(innerBorderColor))
                {
                    g.DrawRectangle(pen, rect);
                }
            }
        }

        private Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;

            if (a + a0 > 255) { a = 255; } else { a = Math.Max(a + a0, 0); }
            if (r + r0 > 255) { r = 255; } else { r = Math.Max(r + r0, 0); }
            if (g + g0 > 255) { g = 255; } else { g = Math.Max(g + g0, 0); }
            if (b + b0 > 255) { b = 255; } else { b = Math.Max(b + b0, 0); }

            return Color.FromArgb(a, r, g, b);
        }

        private int ColumnAtIndex(int column)
        {
            HDITEM hd = new HDITEM();
            hd.mask = HDI_ORDER;
            for (int i = 0; i < ColumnCount; i++)
            {
                if (SendMessage(HeaderWnd, HDM_GETITEMA, column, ref hd) != IntPtr.Zero)
                {
                    return hd.iOrder;
                }
            }
            return 0;
        }

        private Rectangle HeaderEndRect()
        {
            RECT rect = new RECT();
            IntPtr headerWnd = HeaderWnd;
            SendMessage(
                headerWnd, HDM_GETITEMRECT, ColumnAtIndex(ColumnCount - 1), ref rect);
            int left = rect.Right;
            GetWindowRect(headerWnd, ref rect);
            OffsetRect(ref rect, -rect.Left, -rect.Top);
            rect.Left = left;

            return Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }

        private class HeaderNativeWindow : NativeWindow, IDisposable
        {
            private ListViewEx _owner;

            public HeaderNativeWindow(ListViewEx owner)
                : base()
            {
                _owner = owner;
                base.AssignHandle(owner.HeaderWnd);
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg == 0xF || m.Msg == 0x47)
                {
                    IntPtr hdc = GetDC(m.HWnd);
                    try
                    {
                        using (Graphics g = Graphics.FromHdc(hdc))
                        {
                            Rectangle bounds = _owner.HeaderEndRect();
                            Color baseColor = _owner.HeadColor;
                            Color borderColor = _owner.HeadColor;
                            Color innerBorderColor = Color.FromArgb(150, 255, 255, 255);

                            _owner.RenderBackgroundInternal(
                                g,
                                bounds,
                                baseColor,
                                borderColor,
                                innerBorderColor,
                                0.45f,
                                true,
                                LinearGradientMode.Vertical);
                        }
                    }
                    finally
                    {
                        ReleaseDC(m.HWnd, hdc);
                    }
                }
            }

            #region IDisposable ³ÉÔ±

            public void Dispose()
            {
                ReleaseHandle();
                _owner = null;
            }

            #endregion
        }
    }
}
