using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Scada.Controls.Accordion
{

 public enum ResizeBarVisualStyle {

 	Custom = -1,

 	ClassicSubtle = 0,

 	ClassicStrong = 1,

 	ClassicNone = 2,

 	ModernSubtle = 10,
	
 	ModernStrong = 11,

 	ModernNone = 12,
}

 public class ResizeBar : UserControl {

 	public bool ShowGrip { get; set; }

 	public ResizeBarVisualStyle VisualStyle { get; set; }

	private Renderer renderer = null;
	private TrackBarThumbState state = TrackBarThumbState.Normal;

	public ResizeBar() {
		ShowGrip = true;
		this.Cursor = Cursors.SizeNS;
		this.MinimumSize = new Size(0, 13);  		using (var g = Graphics.FromHwnd(IntPtr.Zero)) {
			float dpiY = g.DpiY;
			this.Size = new Size(0, Math.Max(13, (int) (13 * dpiY / 120)));
		}

		VisualStyle = ResizeBarVisualStyle.ModernStrong;  		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
		renderer = new Renderer(this);
	}

	private class Renderer {

		VisualStyleRenderer rGrip0 = null;
		VisualStyleRenderer rBar1 = null;
		VisualStyleRenderer rBarDisabled = null;
		SolidBrush brushDisabled = new SolidBrush(Color.FromArgb(231, 234, 234));
		SolidBrush brushNormal = new SolidBrush(Color.FromArgb(230, 230, 228));

		ResizeBar Owner { get; set; }
		bool renderWithVisualStyles = false;

		public Renderer(ResizeBar owner) {
			renderWithVisualStyles = (Application.RenderWithVisualStyles && VisualStyleRenderer.IsSupported && VisualStyleInformation.IsEnabledByUser);

			Owner = owner;
			if (renderWithVisualStyles) {
				rBarDisabled = new VisualStyleRenderer(VisualStyleElement.TrackBar.Track.Normal);
				rGrip0 = new VisualStyleRenderer(VisualStyleElement.Rebar.Gripper.Normal);
				rBar1 = new VisualStyleRenderer(VisualStyleElement.TrackBar.Thumb.Normal);
			}
		}

		public void Dispose() {
			brushNormal.Dispose();
			brushDisabled.Dispose();
		}

		public void Draw(Graphics g, Rectangle bounds, Rectangle grip, TrackBarThumbState state) {
			ResizeBarVisualStyle style = Owner.VisualStyle;
			if (!renderWithVisualStyles) {
				if (style == ResizeBarVisualStyle.ModernStrong)
					style = ResizeBarVisualStyle.ClassicStrong;
				else if (style == ResizeBarVisualStyle.ModernSubtle)
					style = ResizeBarVisualStyle.ClassicSubtle;
				else if (style == ResizeBarVisualStyle.ModernNone)
					style = ResizeBarVisualStyle.ClassicNone;
			}

			if (style == ResizeBarVisualStyle.ModernStrong || style == ResizeBarVisualStyle.ModernNone) {
				if (state == TrackBarThumbState.Disabled)
					rBarDisabled.DrawBackground(g, bounds);
				else {
					if (style == ResizeBarVisualStyle.ModernNone)
						rBar1.DrawBackground(g, bounds);
					else
						TrackBarRenderer.DrawHorizontalThumb(g, bounds, state);
				}

				if (Owner.ShowGrip)
					DrawGrip(g, grip);
			}
			else if (style == ResizeBarVisualStyle.ModernSubtle) {
				if (state == TrackBarThumbState.Disabled) {
					rBarDisabled.DrawBackground(g, bounds);
					if (Owner.ShowGrip) {
						rBarDisabled.DrawBackground(g, grip);
						DrawGrip(g, grip, -5);
					}
				}
				else {
					rBar1.DrawBackground(g, bounds);
					if (Owner.ShowGrip) {
						TrackBarRenderer.DrawHorizontalThumb(g, grip, state);
						DrawGrip(g, grip, -5);
					}
				}
			}
			else if (style == ResizeBarVisualStyle.ClassicStrong || style == ResizeBarVisualStyle.ClassicSubtle) {
				Brush bg = brushNormal;
				if (state == TrackBarThumbState.Disabled)
					bg = brushDisabled;
				else {
					if (style == ResizeBarVisualStyle.ClassicStrong) {
						if (state == TrackBarThumbState.Hot)
							bg = SystemBrushes.GradientInactiveCaption;
						else if (state == TrackBarThumbState.Pressed)
							bg = SystemBrushes.GradientActiveCaption;
					}
				}

				g.FillRectangle(bg, bounds);
				ControlPaint.DrawBorder(g, bounds, SystemColors.ActiveBorder , ButtonBorderStyle.Solid);

				if (Owner.ShowGrip) {
					var r = grip;
					if (style == ResizeBarVisualStyle.ClassicSubtle) {
						bg = (state == TrackBarThumbState.Disabled ? brushDisabled : brushNormal);
						if (state == TrackBarThumbState.Hot)
							bg = SystemBrushes.GradientInactiveCaption;
						else if (state == TrackBarThumbState.Pressed)
							bg = SystemBrushes.GradientActiveCaption;

						g.FillRectangle(bg, grip);
						ControlPaint.DrawBorder(g, grip, SystemColors.ActiveBorder , ButtonBorderStyle.Solid);

						r.Width -= r.Height;
						r.X += r.Height / 2;
					}

					int numLines = Math.Max(2, bounds.Height / 10);
					int h = 3 * numLines + (numLines - 1);
					int dy = (bounds.Height - h) / 2;

					for (int i = 0; i < numLines; i++) {
						g.DrawLine(SystemPens.ControlLight, r.X, r.Y + dy, r.X + r.Width, r.Y + dy);
						g.DrawLine(SystemPens.ControlDark, r.X, r.Y + dy + 2, r.X + r.Width, r.Y + dy + 2);
						dy += 4;
					}
				}
			}
			else if (style == ResizeBarVisualStyle.ClassicNone) {

                int x1 = bounds.X;
                int y1 = bounds.Y;
				int x2 = bounds.X + bounds.Width;
				int y2 = bounds.Y + bounds.Height;
 
				g.FillRectangle(SystemBrushes.Control, bounds);

 				g.DrawLine(SystemPens.ControlLight, x1-1, y1, x1-1, y2);
				g.DrawLine(SystemPens.ControlLightLight, x1, y1, x1, y2);

                g.DrawLine(SystemPens.ScrollBar, x1, y2-2, x2, y2-2);
				g.DrawLine(SystemPens.ControlDark, x1, y2-1, x2, y2-1);

				g.DrawLine(SystemPens.ControlLight, x1, y1, x2, y1);
				g.DrawLine(SystemPens.ControlLightLight, x1, y1+1, x2, y1+1);

				g.DrawLine(SystemPens.ScrollBar, x2-2, y1, x2-2, y2-2);
				g.DrawLine(SystemPens.ControlDark, x2-1, y1, x2-1, y2);
			}
		}

		private void DrawGrip(Graphics g, Rectangle grip, int adjustWidth = 0) {
			var r = grip;
			r.Y += 2;
			r.Height -= 4;
			r.Width += adjustWidth;

 			if (adjustWidth != 0) {
				if (r.Width % 5 == 4)
					r.X++;
				else if (r.Width % 5 == 3) {
					r.Width++;
					r.X++;
				}
				else
					r.X += 2;
			}
			else {
				if (r.Width % 5 == 3)
					r.Width++;
				else if (r.Width % 5 == 2)
					r.Width--;
			}

			if (r.Height % 4 == 2) {
				r.Y++;
				r.Height--;
			}
			else if (r.Height % 4 == 3) {
				r.Y--;
			}

			rGrip0.DrawBackground(g, r);
		}
	}

	protected override void OnMouseEnter(EventArgs e) {
		base.OnMouseEnter(e);
		state = TrackBarThumbState.Hot;
		Refresh();
	}

	protected override void OnMouseLeave(EventArgs e) {
		base.OnMouseLeave(e);
		state = TrackBarThumbState.Normal;
		Refresh();
	}

	protected override void OnMouseDown(MouseEventArgs e) {
		base.OnMouseDown(e);
		state = TrackBarThumbState.Pressed;
		Refresh();
	}

	protected override void OnMouseUp(MouseEventArgs e) {
		base.OnMouseUp(e);
		state = TrackBarThumbState.Hot;
		Refresh();
	}

	protected override void OnGotFocus(EventArgs e) {
		base.OnGotFocus(e);
		Refresh();
	}

	protected override void OnLostFocus(EventArgs e) {
		base.OnLostFocus(e);
		Refresh();
	}

	protected override void OnPaint(PaintEventArgs e) {
		base.OnPaint(e);
		if (renderer != null) {
			Size s = Size;
			var g = e.Graphics;
			Rectangle r = new Rectangle(Point.Empty, s);
			int handleLength = Math.Max(20, 3 * s.Height);
			Rectangle r2 = new Rectangle((s.Width - handleLength) / 2, 0, handleLength, s.Height);
			var st = state;
			if (!Enabled)
				st = TrackBarThumbState.Disabled;
			else if (Focused)
				st = TrackBarThumbState.Pressed;

			renderer.Draw(g, r, r2, st);
		}
	}

	protected override void Dispose(bool disposing) {
		base.Dispose(disposing);
		if (disposing) {
			if (renderer != null)
				renderer.Dispose();
			renderer = null;
		}
	}
}

}