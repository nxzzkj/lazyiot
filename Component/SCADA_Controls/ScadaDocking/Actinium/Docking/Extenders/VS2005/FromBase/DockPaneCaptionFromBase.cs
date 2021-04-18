using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;
namespace GraphicsUI.DockControl.Docking.Extenders.VS2005
{
	[ToolboxItem(false)]
	public class DockPaneCaptionFromBase : DockPaneCaptionBase
	{
		#region consts
		private const int _TextGapTop = 2;
		private const int _TextGapBottom = 0;
		private const int _TextGapLeft = 3;
		private const int _TextGapRight = 3;
		private const int _ButtonGapTop = 2;
		private const int _ButtonGapBottom = 1;
		private const int _ButtonGapBetween = 1;
		private const int _ButtonGapLeft = 1;
		private const int _ButtonGapRight = 2;
		private const string _ResourceImageCloseEnabled = "DockPaneCaption.CloseEnabled.bmp";
		private const string _ResourceImageCloseDisabled = "DockPaneCaption.CloseDisabled.bmp";
		private const string _ResourceImageAutoHideYes = "DockPaneCaption.AutoHideYes.bmp";
		private const string _ResourceImageAutoHideNo = "DockPaneCaption.AutoHideNo.bmp";
		private const string _ResourceToolTipClose = "DockPaneCaption.ToolTipClose";
		private const string _ResourceToolTipAutoHide = "DockPaneCaption.ToolTipAutoHide";
		#endregion

		private InertButton m_buttonClose;
		private InertButton m_buttonAutoHide;
		private InertButton m_buttonWhatIsIt;
		private LinearGradientBrush captionBrush;
		private Color darkColor = ColorMixer.DarkColor;//Color.SlateGray;
		private Color lightColor = Color.Silver;
		public Color DarkColor
		{
			get{return darkColor;}
			set
			{
				darkColor = value;
				SetBrush();
			}
		}
		public Color LightColor
		{
			get{return lightColor;}
			set
			{
				lightColor = value;
				SetBrush();
			}
		}
		public void SetBrush()
		{
			
			if(ClientRectangle==Rectangle.Empty) return;
			captionBrush = new LinearGradientBrush(ClientRectangle, darkColor, lightColor, LinearGradientMode.Horizontal);
//			if(bellShaped)
//				captionBrush.SetSigmaBellShape(bellCenter,bellFalloff);

//			darkBrush = new SolidBrush(darkColor);
//			roundingPen = new Pen(darkColor,1);
//			foreBrush = new SolidBrush(this.ForeColor);
//			unselectedForeBrush = new SolidBrush(unselectedForeColor);
//			unselectedEdgePen = new Pen(unselectedEdgeColor,1);			
//			unselectedTabBrush = new SolidBrush(UnselectedTabColor);
			Invalidate();
		}

		protected internal DockPaneCaptionFromBase(DockPane pane) : base(pane)
		{
			

			SuspendLayout();

			Font = SystemInformation.MenuFont;

			m_buttonClose = new InertButton(ImageCloseEnabled, ImageCloseDisabled);
			m_buttonAutoHide = new InertButton();

			m_buttonClose.ToolTipText = ToolTipClose;
			
			m_buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			m_buttonClose.Click += new EventHandler(this.Close_Click);

			m_buttonAutoHide.ToolTipText = ToolTipAutoHide;
			m_buttonAutoHide.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			m_buttonAutoHide.Click += new EventHandler(AutoHide_Click);

			m_buttonWhatIsIt = new InertButton();
			m_buttonWhatIsIt.BackColor = ColorMixer.LightColor;
			m_buttonWhatIsIt.ForeColor = ColorMixer.DarkColor;
			m_buttonWhatIsIt.ToolTipText = "What is this?";
			m_buttonWhatIsIt.Text = "?";
			m_buttonWhatIsIt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			m_buttonWhatIsIt.Click+=new EventHandler(m_buttonWhatIsIt_Click);


			Controls.AddRange(new Control[]	{	m_buttonWhatIsIt, m_buttonClose, m_buttonAutoHide });

			ResumeLayout();
		}

		#region Customizable Properties
		protected virtual int TextGapTop
		{
			get	{	return _TextGapTop;	}
		}

		protected virtual int TextGapBottom
		{
			get	{	return _TextGapBottom;	}
		}

		protected virtual int TextGapLeft
		{
			get	{	return _TextGapLeft;	}
		}

		protected virtual int TextGapRight
		{
			get	{	return _TextGapRight;	}
		}

		protected virtual int ButtonGapTop
		{
			get	{	return _ButtonGapTop;	}
		}

		protected virtual int ButtonGapBottom
		{
			get	{	return _ButtonGapBottom;	}
		}

		protected virtual int ButtonGapLeft
		{
			get	{	return _ButtonGapLeft;	}
		}

		protected virtual int ButtonGapRight
		{
			get	{	return _ButtonGapRight;	}
		}

		protected virtual int ButtonGapBetween
		{
			get	{	return _ButtonGapBetween;	}
		}

		private static Image _imageCloseEnabled = null;
		protected virtual Image ImageCloseEnabled
		{
			get
			{	
				if (_imageCloseEnabled == null)
					_imageCloseEnabled = ResourceHelper.LoadBitmap(_ResourceImageCloseEnabled);
				return _imageCloseEnabled;
			}
		}

		private static Image _imageCloseDisabled = null;
		protected virtual Image ImageCloseDisabled
		{
			get
			{	
				if (_imageCloseDisabled == null)
					_imageCloseDisabled = ResourceHelper.LoadBitmap(_ResourceImageCloseDisabled);
				return _imageCloseDisabled;
			}
		}

		private static Image _imageAutoHideYes = null;
		protected virtual Image ImageAutoHideYes
		{
			get
			{	
				if (_imageAutoHideYes == null)
					_imageAutoHideYes = ResourceHelper.LoadBitmap(_ResourceImageAutoHideYes);
				return _imageAutoHideYes;
			}
		}

		private static Image _imageAutoHideNo = null;
		protected virtual Image ImageAutoHideNo
		{
			get
			{	
				if (_imageAutoHideNo == null)
					_imageAutoHideNo = ResourceHelper.LoadBitmap(_ResourceImageAutoHideNo);
				return _imageAutoHideNo;
			}
		}

		private static string _toolTipClose = null;
		protected virtual string ToolTipClose
		{
			get
			{	
				if (_toolTipClose == null)
					_toolTipClose = ResourceHelper.GetString(_ResourceToolTipClose);
				return _toolTipClose;
			}
		}

		private static string _toolTipAutoHide = null;
		protected virtual string ToolTipAutoHide
		{
			get
			{	
				if (_toolTipAutoHide == null)
					_toolTipAutoHide = ResourceHelper.GetString(_ResourceToolTipAutoHide);
				return _toolTipAutoHide;
			}
		}

		protected virtual Color ActiveBackColor
		{
			get	{	return SystemColors.ActiveCaption;	}
		}

		protected virtual Color InactiveBackColor
		{
			get	{	return SystemColors.Control;	}
		}

		protected virtual Color ActiveTextColor
		{
			get	{	return SystemColors.ActiveCaptionText;	}
		}

		protected virtual Color InactiveTextColor
		{
			get	{	return SystemColors.ControlText;	}
		}

		protected virtual Color InactiveBorderColor
		{
			get	{	return SystemColors.GrayText; }
		}

		protected virtual Color ActiveButtonBorderColor
		{
			get	{	return ActiveTextColor;	}
		}

		protected virtual Color InactiveButtonBorderColor
		{
			get	{	return Color.Empty;	}
		}

		private static StringFormat _textStringFormat = null;
		protected virtual StringFormat TextStringFormat
		{
			get
			{	
				if (_textStringFormat == null)
				{
					_textStringFormat = new StringFormat();
					_textStringFormat.Trimming = StringTrimming.EllipsisCharacter;
					_textStringFormat.LineAlignment = StringAlignment.Center;
					_textStringFormat.FormatFlags = StringFormatFlags.NoWrap;
				}
				return _textStringFormat;
			}
		}

		#endregion

		protected internal override int MeasureHeight()
		{
			int height = Font.Height + TextGapTop + TextGapBottom;

			if (height < ImageCloseEnabled.Height + ButtonGapTop + ButtonGapBottom)
				height = ImageCloseEnabled.Height + ButtonGapTop + ButtonGapBottom;

			return height;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);
			if (DockPane.IsActivated)
			{
				using (captionBrush = new LinearGradientBrush(ClientRectangle, ColorMixer.DarkColor, ColorMixer.LightColor, LinearGradientMode.Horizontal))
				{
					e.Graphics.FillRectangle(captionBrush, ClientRectangle);
				}
			}
				   
			DrawCaption(e.Graphics);
		}

		private void DrawCaption(Graphics g)
		{
			BackColor = DockPane.IsActivated ? ActiveBackColor : InactiveBackColor;

			Rectangle rectCaption = ClientRectangle;

			if (!DockPane.IsActivated)
			{
				using (Pen pen = new Pen(InactiveBorderColor))
				{
					g.DrawLine(pen, rectCaption.X + 1, rectCaption.Y, rectCaption.X + rectCaption.Width - 2, rectCaption.Y);
					g.DrawLine(pen, rectCaption.X + 1, rectCaption.Y + rectCaption.Height - 1, rectCaption.X + rectCaption.Width - 2, rectCaption.Y + rectCaption.Height - 1);
					g.DrawLine(pen, rectCaption.X, rectCaption.Y + 1, rectCaption.X, rectCaption.Y + rectCaption.Height - 2);
					g.DrawLine(pen, rectCaption.X + rectCaption.Width - 1, rectCaption.Y + 1, rectCaption.X + rectCaption.Width - 1, rectCaption.Y + rectCaption.Height - 2);
				}
			}

			m_buttonClose.ForeColor = m_buttonAutoHide.ForeColor = (DockPane.IsActivated ? ColorMixer.DarkColor : InactiveTextColor);
			m_buttonClose.BorderColor = m_buttonAutoHide.BorderColor = (DockPane.IsActivated ? ColorMixer.DarkColor : InactiveButtonBorderColor);
			m_buttonClose.BackColor = m_buttonAutoHide.BackColor = (DockPane.IsActivated ? ColorMixer.LightColor : InactiveButtonBorderColor);

			Rectangle rectCaptionText = rectCaption;
			rectCaptionText.X += TextGapLeft;
			rectCaptionText.Width = rectCaption.Width - ButtonGapRight
				- ButtonGapLeft
				- ButtonGapBetween - 2 * m_buttonClose.Width
				- TextGapLeft - TextGapRight;
			rectCaptionText.Y += TextGapTop;
			rectCaptionText.Height -= TextGapTop + TextGapBottom;
			using (Brush brush = new SolidBrush(DockPane.IsActivated ? ColorMixer.TabSelectedTextColor : InactiveTextColor))
			{
				g.DrawString(DockPane.CaptionText, Font, brush, rectCaptionText, TextStringFormat);
			}
		}

		protected override void OnLayout(LayoutEventArgs levent)
		{
			//SetBrush();
			// set the size and location for close and auto-hide buttons
			Rectangle rectCaption = ClientRectangle;
			int buttonWidth = ImageCloseEnabled.Width;
			int buttonHeight = ImageCloseEnabled.Height;
			int height = rectCaption.Height - ButtonGapTop - ButtonGapBottom;
			if (buttonHeight < height)
			{
				buttonWidth = buttonWidth * (height / buttonHeight);
				buttonHeight = height;
			}
			m_buttonClose.SuspendLayout();
			m_buttonAutoHide.SuspendLayout();
			m_buttonWhatIsIt.SuspendLayout();
			Size buttonSize = new Size(buttonWidth, buttonHeight);
			m_buttonClose.Size = m_buttonAutoHide.Size = m_buttonWhatIsIt.Size = buttonSize;
		
			int x = rectCaption.X + rectCaption.Width - 1 - ButtonGapRight - m_buttonClose.Width;
			int y = rectCaption.Y + ButtonGapTop;
			Point point = m_buttonClose.Location = new Point(x, y);
			point.Offset(-(m_buttonAutoHide.Width + ButtonGapBetween), 0);
			m_buttonAutoHide.Location = point;
			point.Offset(-(m_buttonWhatIsIt.Width + ButtonGapBetween), 0);
			m_buttonWhatIsIt.Location = point;
			m_buttonClose.ResumeLayout();
			m_buttonAutoHide.ResumeLayout();

			base.OnLayout (levent);
		}

		protected override void OnRefreshChanges()
		{
			SetButtons();
			Invalidate();
		}

		private void SetButtons()
		{
			m_buttonClose.Enabled = (DockPane.ActiveContent != null)? DockPane.ActiveContent.CloseButton : false;
			m_buttonAutoHide.Visible = !DockPane.IsFloat;
			m_buttonAutoHide.ImageEnabled = DockPane.IsAutoHide ? ImageAutoHideYes : ImageAutoHideNo;
		}

		private void Close_Click(object sender, EventArgs e)
		{
			DockPane.CloseActiveContent();
		}

		private void AutoHide_Click(object sender, EventArgs e)
		{
			DockPane.DockState = DockHelper.ToggleAutoHideState(DockPane.DockState);
			if (!DockPane.IsAutoHide)
				DockPane.Activate();
		}

		private void m_buttonWhatIsIt_Click(object sender, EventArgs e)
		{
			if( DockPane.ActiveContent != null && DockPane.ActiveContent.AccessibleDescription !=null)
				MessageBox.Show(DockPane.ActiveContent.AccessibleDescription,"What is this?", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
