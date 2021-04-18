﻿/******************************************************************************
 * SunnyUI 开源控件库、工具类库、扩展类库、多页面开发框架。
 * CopyRight (C) 2012-2020 ShenYongHua(沈永华).
 * QQ群：56829229 QQ：17612584 EMail：SunnyUI@qq.com
 *
 * Blog:   https://www.cnblogs.com/yhuse
 * Gitee:  https://gitee.com/yhuse/SunnyUI
 * GitHub: https://github.com/yhuse/SunnyUI
 *
 * SunnyUI can be used for free under the GPL-3.0 license.
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 文件名称: UILedBulb.cs
 * 文件说明: LED灯
 * 文件作者: Steve Marsh
 * 开源协议: CPOL
 * 引用地址: https://www.codeproject.com/Articles/114122/A-Simple-Vector-Based-LED-User-Control
******************************************************************************/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#pragma warning disable 1591

namespace Sunny.UI
{
    /// <summary>
    /// The LEDBulb is a .Net control for Windows Forms that emulates an
    /// LED light with two states On and Off.  The purpose of the control is to
    /// provide a sleek looking representation of an LED light that is sizable,
    /// has a transparent background and can be set to different colors.
    /// </summary>
    public class UILedBulb : Control
    {
        #region Public and Private Members

        private Color _color;
        private bool _on = true;
        private readonly Color _reflectionColor = Color.FromArgb(180, 255, 255, 255);
        private readonly Color[] _surroundColor = new Color[] { Color.FromArgb(0, 255, 255, 255) };
        private readonly Timer _timer = new Timer();

        /// <summary>
        /// Gets or Sets the color of the LED light
        /// </summary>
        [DefaultValue(typeof(Color), "192, 255, 192")]
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                DarkColor = ControlPaint.Dark(_color);
                DarkDarkColor = ControlPaint.DarkDark(_color);
                Invalidate();  // Redraw the control
            }
        }

        /// <summary>
        /// Dark shade of the LED color used for gradient
        /// </summary>
        [Browsable(false)]
        public Color DarkColor { get; protected set; }

        /// <summary>
        /// Very dark shade of the LED color used for gradient
        /// </summary>
        [Browsable(false)]
        public Color DarkDarkColor { get; protected set; }

        /// <summary>
        /// Gets or Sets whether the light is turned on
        /// </summary>
        [DefaultValue(true)]
        public bool On
        {
            get { return _on; }
            set
            {
                _on = value;
                Invalidate();
            }
        }

        #endregion Public and Private Members

        #region Constructor

        public UILedBulb()
        {
            SetStyle(ControlStyles.DoubleBuffer
            | ControlStyles.AllPaintingInWmPaint
            | ControlStyles.ResizeRedraw
            | ControlStyles.UserPaint
            | ControlStyles.SupportsTransparentBackColor, true);

            Width = Height = 32;
            Color = Color.FromArgb(192, 255, 192);
            _timer.Tick += (sender, e) => { On = !On; };
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Handles the Paint event for this UserControl
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Create an offscreen graphics object for double buffering
            Bitmap offScreenBmp = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            using (var g = Graphics.FromImage(offScreenBmp))
            {
                g.SetHighQuality();
                // Draw the control
                drawControl(g, On);
                // Draw the image to the screen
                e.Graphics.DrawImageUnscaled(offScreenBmp, 0, 0);
            }
        }

        /// <summary>
        /// Renders the control to an image
        /// </summary>
        private void drawControl(Graphics g, bool on)
        {
  // Is the bulb on or off
            Color lightColor = (on) ? Color : Color.FromArgb(150, DarkColor);
            Color darkColor = (on) ? DarkColor : DarkDarkColor;

            // Calculate the dimensions of the bulb
            int width = Width - (Padding.Left + Padding.Right);
            int height = Height - (Padding.Top + Padding.Bottom);
            // Diameter is the lesser of width and height
            int diameter = Math.Min(width, height);
            // Subtract 1 pixel so ellipse doesn't get cut off
            diameter = Math.Max(diameter - 1, 1);

            // Draw the background ellipse
            var rectangle = new Rectangle(Padding.Left, Padding.Top, diameter, diameter);
            g.FillEllipse(darkColor, rectangle,true);

            // Draw the glow gradient
            var path = new GraphicsPath();
            path.AddEllipse(rectangle);
            var pathBrush = new PathGradientBrush(path);
            pathBrush.CenterColor = lightColor;
            pathBrush.SurroundColors = new[] { Color.FromArgb(0, lightColor) };
            g.SetHighQuality();
            g.FillEllipse(pathBrush, rectangle);
            pathBrush.Dispose();

            // Draw the white reflection gradient
            var offset = Convert.ToInt32(diameter * .15F);
            var diameter1 = Convert.ToInt32(rectangle.Width * .8F);
            var whiteRect = new Rectangle(rectangle.X - offset, rectangle.Y - offset, diameter1, diameter1);
            var path1 = new GraphicsPath();
            path1.AddEllipse(whiteRect);
            var pathBrush1 = new PathGradientBrush(path);
            pathBrush1.CenterColor = _reflectionColor;
            pathBrush1.SurroundColors = _surroundColor;
            g.SetHighQuality();
            g.FillEllipse(pathBrush1, whiteRect);
            pathBrush1.Dispose();

            // Draw the border
            g.SetClip(ClientRectangle);
            g.SetHighQuality();

            if (On)
            {
                using (Pen pn = new Pen(Color.FromArgb(85, Color.Black), 1F))
                {
                    g.DrawEllipse(pn, rectangle);
                }
            }

            g.SetDefaultQuality();
        }

        private int blinkInterval = 1000;

        [DefaultValue(1000)]
        public int BlinkInterval
        {
            get => blinkInterval;
            set
            {
                blinkInterval = Math.Max(100, value);
                bool isBlink = Blink;
                if (isBlink) _timer.Stop();
                _timer.Interval = blinkInterval;
                _timer.Enabled = isBlink;
            }
        }

        [DefaultValue(false)]
        public bool Blink
        {
            get => _timer.Enabled;
            set
            {
                On = true;
                _timer.Stop();
                _timer.Interval = BlinkInterval;
                _timer.Enabled = value;
            }
        }

        #endregion Methods
    }
}