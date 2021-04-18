using System;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace GraphicsUI.DockControl
{
	/// <summary>
	/// Summary description for DrawUtil.
	/// </summary>
	public class DrawUtil
	{
		public static int bshift = 16;
		
		public static void DrawTab(Graphics g, Rectangle r, Corners corner, GradientType gradient, Color darkColor, Color lightColor, Color edgeColor, bool closed )
		{
			//dims
			Point[] points;
			GraphicsPath path;
			Region region;
			LinearGradientBrush linearBrush;
			
			Brush brush = null;
			Pen pen;
			//set brushes
			switch(gradient)
			{
				case GradientType.Flat:
					brush = new SolidBrush(darkColor);
					break;
				case GradientType.Linear:
					brush = new LinearGradientBrush(r,darkColor,lightColor,LinearGradientMode.Vertical);
					break;
				case GradientType.Bell:
					linearBrush = new LinearGradientBrush(r,darkColor,lightColor,LinearGradientMode.Vertical);
					linearBrush.SetSigmaBellShape(0.17F,0.67F);
					brush = linearBrush;
					break;
			}
			pen = new Pen(edgeColor,1);
			//generic points
			points = new Point[12]
								{
									new Point(r.Left,r.Bottom), //0
									new Point(r.Left, r.Bottom-bshift), //1
									new Point(r.Left,r.Top+bshift), //2
									new Point(r.Left,r.Top), //3
									new Point(r.Left+bshift,r.Top), //4
									new Point(r.Right-bshift,r.Top), //5
									new Point(r.Right,r.Top), //6
									new Point(r.Right,r.Top+bshift), //7
									new Point(r.Right,r.Bottom-bshift), //8
									new Point(r.Right,r.Bottom), //9
									new Point(r.Right-bshift,r.Bottom), //10									  
									new Point(r.Left+bshift,r.Bottom) //10
								};
			path = new GraphicsPath();
			switch(corner)
			{
				case Corners.LB:

					path.AddLine(points[3],points[1]);
					path.AddBezier(points[1],points[0],points[0],points[11]);	
					path.AddLine(points[11],points[9]);					
					path.AddLine(points[9],points[6]);
					path.AddLine(points[6],points[3]);
					region = new Region(path);
					g.FillRegion(brush,region);

					g.DrawLine(pen,points[3],points[1]);
					g.DrawBezier(pen,points[1],points[0],points[0],points[11]);	
					g.DrawLine(pen,points[11],points[9]);					
					g.DrawLine(pen,points[9],points[6]);
					if(closed)
						g.DrawLine(pen,points[6],points[3]);
					break;
				case Corners.LT:
					path.AddLine(points[0],points[2]);
					path.AddBezier(points[2],points[3],points[3],points[4]);
					path.AddLine(points[4],points[6]);						
					path.AddLine(points[6],points[9]);
					path.AddLine(points[9],points[0]);
					region = new Region(path);
					g.FillRegion(brush,region);

					g.DrawLine(pen,points[0],points[2]);
					g.DrawBezier(pen,points[2],points[3],points[3],points[4]);	
					g.DrawLine(pen,points[4],points[6]);					
					g.DrawLine(pen,points[6],points[9]);
					if(closed)
						g.DrawLine(pen,points[9],points[0]);
					break;
				case Corners.RB:
					path.AddLine(points[3],points[0]);
					path.AddLine(points[0],points[10]);
					path.AddBezier(points[10],points[9],points[9],points[8]);	
					path.AddLine(points[8],points[6]);
					path.AddLine(points[6],points[3]);
					region = new Region(path);
					g.FillRegion(brush,region);

					g.DrawLine(pen,points[3],points[0]);
					g.DrawLine(pen,points[0],points[10]);
					g.DrawBezier(pen,points[10],points[9],points[9],points[8]);	
					g.DrawLine(pen,points[8],points[6]);
					if(closed)
						g.DrawLine(pen,points[6],points[3]);
					break;
				case Corners.RT:
					path.AddLine(points[0],points[3]);
					path.AddLine(points[3],points[5]);
					path.AddBezier(points[5],points[6],points[6],points[7]);	
					path.AddLine(points[7],points[9]);
					path.AddLine(points[9],points[0]);
					region = new Region(path);
					g.FillRegion(brush,region);

					g.DrawLine(pen,points[0],points[3]);
					g.DrawLine(pen,points[3],points[5]);
					g.DrawBezier(pen,points[5],points[6],points[6],points[7]);	
					g.DrawLine(pen,points[7],points[9]);
					if(closed)
						g.DrawLine(pen,points[9],points[0]);
					break;
			}
		}

	

		public static void DrawVSTab(Graphics g, Rectangle r, Color backColor, Color edgeColor, bool closed )
		{
			//dims
		
			GraphicsPath path;
			Region region;
			
			
			Brush brush = null;
			Pen pen;
			//set brushes

			brush = new SolidBrush(backColor);

			pen = new Pen(edgeColor,1F);

			//generic points
//			points = new Point[12]
//								{
//									new Point(r.Left,r.Bottom), //0
//									new Point(r.Left, r.Bottom-bshift), //1
//									new Point(r.Left,r.Top+bshift), //2
//									new Point(r.Left,r.Top), //3
//									new Point(r.Left+bshift,r.Top), //4
//									new Point(r.Right-bshift,r.Top), //5
//									new Point(r.Right,r.Top), //6
//									new Point(r.Right,r.Top+bshift), //7
//									new Point(r.Right,r.Bottom-bshift), //8
//									new Point(r.Right,r.Bottom), //9
//									new Point(r.Right-bshift,r.Bottom), //10									  
//									new Point(r.Left+bshift,r.Bottom) //10
//								};
			path = new GraphicsPath();			
			//			path.AddArc(r.X, r.Y, 20, 20, -180, 90);			
			path.AddLine(r.X, r.Y, r.Right - 10, r.Y);			
			path.AddArc(r.Right - 10, r.Top, 10, 10, -90, 90);			
			path.AddLine(r.Right, r.Y + 10, r.Right, r.Bottom);			
			//			path.AddArc(r.X + r.Width - 20, r.Y + r.Height - 20, 20, 20, 0, 90);			
			path.AddLine(r.Right, r.Bottom, r.Left-10, r.Bottom);			
			//path.AddArc(r.X, r.Y + r.Height - 20, 20, 20, 90, 90);			
			path.AddLine(r.X-10, r.Y + r.Height , r.X, r.Y );			
			
			 region = new Region(path);
			

			g.FillRegion(brush, region);

			g.DrawPath(pen, path);

			
		}
	}
	public enum Corners
	{
		RT,
		LT,
		LB,
		RB
	}

	public enum GradientType
	{
		Flat,
		Linear,
		Bell
	}
}
