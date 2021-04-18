/*
 * NPlot - A charting library for .NET
 * 
 * HistogramPlot.cs
 * Copyright (C) 2003-2006 Matt Howlett and others.
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without modification,
 * are permitted provided that the following conditions are met:
 * 
 * 1. Redistributions of source code must retain the above copyright notice, this
 *    list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 *    this list of conditions and the following disclaimer in the documentation
 *    and/or other materials provided with the distribution.
 * 3. Neither the name of NPlot nor the names of its contributors may
 *    be used to endorse or promote products derived from this software without
 *    specific prior written permission.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 * IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
 * BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 * DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
 * LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
 * OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
 * OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;

namespace NPlot
{

	/// <summary>
	/// Provides ability to draw histogram plots.
	/// </summary>
	public class HistogramPlot : BaseSequencePlot, IPlot, ISequencePlot
	{

		/// <summary>
		/// Set/Get the brush to use if the histogram is filled.
		/// </summary>
		public IRectangleBrush RectangleBrush
		{
			get
			{
				return rectangleBrush_;
			}
			set
			{
				rectangleBrush_ = value;
			}

		}
		private IRectangleBrush rectangleBrush_ = new RectangleBrushes.Solid( Color.Black );


		/// <summary>
		/// Constructor
		/// </summary>
		public HistogramPlot()
		{
		}


		/// <summary>
		/// Renders the histogram.
		/// </summary>
		/// <param name="g">The Graphics surface on which to draw</param>
		/// <param name="xAxis">The X-Axis to draw against.</param>
		/// <param name="yAxis">The Y-Axis to draw against.</param>
		public void Draw( Graphics g, PhysicalAxis xAxis, PhysicalAxis yAxis )
		{
			SequenceAdapter data = 
				new SequenceAdapter( this.DataSource, this.DataMember, this.OrdinateData, this.AbscissaData );

			float yoff;

			for ( int i=0; i<data.Count; ++i )
			{

				// (1) determine the top left hand point of the bar (assuming not centered)
				PointD p1 = data[i];
				if ( double.IsNaN(p1.X) || double.IsNaN(p1.Y) )
					continue;
				
				// (2) determine the top right hand point of the bar (assuming not centered)
				PointD p2;
				if (i+1 != data.Count)
				{
					p2 = data[i+1];
					if ( double.IsNaN(p2.X) || double.IsNaN(p2.Y) )
						continue;
					p2.Y = p1.Y;
				}
				else if (i != 0)
				{
					p2 = data[i-1];
					if ( double.IsNaN(p2.X) || double.IsNaN(p2.Y) )
						continue;
					double offset = p1.X - p2.X;
					p2.X = p1.X + offset;
					p2.Y = p1.Y;
				}
				else
				{
					double offset = 1.0f;
					p2.X = p1.X + offset;
					p2.Y = p1.Y;
				}

				// (3) now account for plots this may be stacked on top of.
				HistogramPlot currentPlot = this;
				yoff = 0.0f;
				double yval = 0.0f;
				while (currentPlot.isStacked_)
				{
					SequenceAdapter stackedToData = new SequenceAdapter(
						currentPlot.stackedTo_.DataSource, 
						currentPlot.stackedTo_.DataMember,
						currentPlot.stackedTo_.OrdinateData, 
						currentPlot.stackedTo_.AbscissaData );

					yval += stackedToData[i].Y;
					yoff = yAxis.WorldToPhysical( yval, false ).Y;
					p1.Y += stackedToData[i].Y;
					p2.Y += stackedToData[i].Y;
					currentPlot = currentPlot.stackedTo_;
				}

				// (4) now account for centering
				if ( center_ )
				{
					double offset = ( p2.X - p1.X ) / 2.0f;
					p1.X -= offset;
					p2.X -= offset;
				}

				// (5) now account for BaseOffset (shift of bar sideways).
                p1.X += baseOffset_;
                p2.X += baseOffset_;

				// (6) now get physical coordinates of top two points.
                PointF xPos1 = xAxis.WorldToPhysical( p1.X, false );
				PointF yPos1 = yAxis.WorldToPhysical( p1.Y, false );
				PointF xPos2 = xAxis.WorldToPhysical( p2.X, false );
				PointF yPos2 = yAxis.WorldToPhysical( p2.Y, false );

				if (isStacked_)
				{
					currentPlot = this;
					while (currentPlot.isStacked_)
					{
						currentPlot = currentPlot.stackedTo_;
					}
					this.baseWidth_ = currentPlot.baseWidth_;
				}

				float width = xPos2.X - xPos1.X;
				float height;
				if (isStacked_)
				{
					height = -yPos1.Y+yoff;
				}
				else
				{
					height = -yPos1.Y+yAxis.PhysicalMin.Y;
				}

				float xoff = (1.0f - baseWidth_)/2.0f*width;
				Rectangle r = new Rectangle( (int)(xPos1.X+xoff), (int)yPos1.Y, (int)(width-2*xoff), (int)height );

				if (this.Filled)
				{
					if (r.Height != 0 && r.Width != 0)
					{
						// room for optimization maybe.
						g.FillRectangle( rectangleBrush_.Get(r), r );
					}
				}

				g.DrawRectangle( Pen, r.X, r.Y, r.Width, r.Height );
				
			}
		}


		/// <summary>
		/// Whether or not the histogram columns will be filled.
		/// </summary>
		public bool Filled
		{
			get 
			{
				return filled_;
			}
			set
			{
				filled_ = value;
			}
		}
		private bool filled_ = false;


		private float baseWidth_ = 1.0f;
        /// <summary>
        /// The width of the histogram bar as a proportion of the data spacing 
        /// (in range 0.0 - 1.0).
        /// </summary>
		public float BaseWidth
		{
			get
			{
				return baseWidth_;
			}
			set
			{
				if (value > 0.0 && value <= 1.0)
				{
					baseWidth_ = value;
				}
				else
				{
					throw new NPlotException( "Base width must be between 0.0 and 1.0" );
				}
			}
		}


		/// <summary>
		/// Returns an x-axis that is suitable for drawing this plot.
		/// </summary>
		/// <returns>A suitable x-axis.</returns>
		public Axis SuggestXAxis()
		{
			SequenceAdapter data = 
				new SequenceAdapter( this.DataSource, this.DataMember, this.OrdinateData, this.AbscissaData );

			Axis a = data.SuggestXAxis();
			if (data.Count==0)
			{
				return a;
			}

			PointD p1;
			PointD p2;
			PointD p3;
			PointD p4;
			if (data.Count < 2)
			{
				p1 = data[0];
				p1.X -= 1.0;
				p2 = data[0];
				p3 = p1;
				p4 = p2;
			}
			else
			{
				p1 = data[0];
				p2 = data[1];
				p3 = data[data.Count-2];
				p4 = data[data.Count-1];
			}

			double offset1;
			double offset2;

			if (!center_)
			{
				offset1 = 0.0f;
				offset2 = p4.X - p3.X;
			}
			else
			{
				offset1 = (p2.X - p1.X)/2.0f;
				offset2 = (p4.X - p3.X)/2.0f;
			}

			a.WorldMin -= offset1;
			a.WorldMax += offset2;

			return a;
		}


		/// <summary>
		/// Returns a y-axis that is suitable for drawing this plot.
		/// </summary>
		/// <returns>A suitable y-axis.</returns>
		public Axis SuggestYAxis()
		{

			if ( this.isStacked_ )
			{
				double tmpMax = 0.0f;
				ArrayList adapterList = new ArrayList();

				HistogramPlot currentPlot = this;
				do
				{
					adapterList.Add( new SequenceAdapter( 
						currentPlot.DataSource,
						currentPlot.DataMember,
						currentPlot.OrdinateData, 
						currentPlot.AbscissaData )
					);
				} while ((currentPlot = currentPlot.stackedTo_) != null);
				
				SequenceAdapter[] adapters =
					(SequenceAdapter[])adapterList.ToArray(typeof(SequenceAdapter));
				
				for (int i=0; i<adapters[0].Count; ++i)
				{
					double tmpHeight = 0.0f;
					for (int j=0; j<adapters.Length; ++j)
					{
						tmpHeight += adapters[j][i].Y;
					}
					tmpMax = Math.Max(tmpMax, tmpHeight);
				}

				Axis a = new LinearAxis(0.0f,tmpMax);
				// TODO make 0.08 a parameter.
				a.IncreaseRange( 0.08 );
				return a;
			}
			else
			{
				SequenceAdapter data = 
					new SequenceAdapter( this.DataSource, this.DataMember, this.OrdinateData, this.AbscissaData );

				return data.SuggestYAxis();
			}
		}


		/*
		private double centerLine_ = 0.0;
		/// <summary>
		/// Histogram bars extend from the data value to this value. Default value is 0.
		/// </summary>
		public double CenterLine
		{
			get
			{
				return centerLine_;
			}
			set
			{
				centerLine_ = value;
			}
		}
		*/


		private bool center_ = true;
		/// <summary>
		/// If true, each histogram column will be centered on the associated abscissa value.
		/// If false, each histogram colum will be drawn between the associated abscissa value, and the next abscissa value.
		/// Default value is true.
		/// </summary>
		public bool Center
		{
			set
			{
				center_ = value;
			}
			get
			{
				return center_;
			}
		}


		/// <summary>
		/// If this histogram plot has another stacked on top, this will be true. Else false.
		/// </summary>
		public bool IsStacked
		{
			get
			{
				return isStacked_;
			}
		}
		private bool isStacked_;


		private HistogramPlot stackedTo_;
		/// <summary>
		/// Stack the histogram to another HistogramPlot.
		/// </summary>
		public void StackedTo(HistogramPlot hp)
		{
			SequenceAdapter data = 
				new SequenceAdapter( this.DataSource, this.DataMember, this.OrdinateData, this.AbscissaData );

			SequenceAdapter hpData = 
				new SequenceAdapter( hp.DataSource, hp.DataMember, hp.OrdinateData, hp.AbscissaData );

				if ( hp != null )
				{
					isStacked_ = true;
					if ( hpData.Count != data.Count )
					{
						throw new NPlotException("Can stack HistogramPlot data only with the same number of datapoints.");
					}
					for ( int i=0; i < data.Count; ++i )
					{
						if ( data[i].X != hpData[i].X )
						{
							throw new NPlotException("Can stack HistogramPlot data only with the same X coordinates.");
						}
						if ( hpData[i].Y < 0.0f)
						{
							throw new NPlotException("Can stack HistogramPlot data only with positive Y coordinates.");
						}
					}
				}
				stackedTo_ = hp;
		}


		/// <summary>
		/// Draws a representation of this plot in the legend.
		/// </summary>
		/// <param name="g">The graphics surface on which to draw.</param>
		/// <param name="startEnd">A rectangle specifying the bounds of the area in the legend set aside for drawing.</param>
		public void DrawInLegend( Graphics g, Rectangle startEnd )
		{
	
			if (Filled)
			{
				g.FillRectangle( rectangleBrush_.Get(startEnd), startEnd );
			}

			g.DrawRectangle( Pen, startEnd.X, startEnd.Y, startEnd.Width, startEnd.Height );

		}


        /// <summary>
        /// The pen used to draw the plot
        /// </summary>
        public System.Drawing.Pen Pen
        {
            get
            {
                return pen_;
            }
            set
            {
                pen_ = value;
            }
        }
        private System.Drawing.Pen pen_ = new Pen(Color.Black);


        /// <summary>
        /// The color of the pen used to draw lines in this plot.
        /// </summary>
        public System.Drawing.Color Color
        {
            set
            {
                if (pen_ != null)
                {
                    pen_.Color = value;
                }
                else
                {
                    pen_ = new Pen(value);
                }
            }
            get
            {
                return pen_.Color;
            }
        }


        /// <summary>
        /// Horizontal position of histogram columns is offset by this much (in world coordinates).
        /// </summary>
        public double BaseOffset
        {
            set
            {
                baseOffset_ = value;
            }
            get
            {
                return baseOffset_;
            }
        }
        private double baseOffset_;


    }
}
