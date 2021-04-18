// *****************************************************************************
// 
//  Copyright 2004, Weifen Luo
//  All rights reserved. The software and associated documentation 
//  supplied hereunder are the proprietary information of Weifen Luo
//  and are supplied subject to licence terms.
// 
//  WinFormsUI Library Version 1.0
// *****************************************************************************

using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
 
namespace Scada.Controls
{
	/// <include file='CodeDoc\DockWindow.xml' path='//CodeDoc/Class[@name="DockWindow"]/ClassDef/*'/>
	[ToolboxItem(false)]
    public class DockWindow : Panel, IDockListContainer
	{
		private DockPanel m_dockPanel;
		private DockState m_dockState;
		private DockWindowSplitter m_splitter;
		private DockList m_dockList;

		internal DockWindow(DockPanel dockPanel, DockState dockState)
		{
			m_dockList = new DockList(this);
			m_dockPanel = dockPanel;
			m_dockState = dockState;
			Visible = false;

			SuspendLayout();

			if (DockState == DockState.DockLeft || DockState == DockState.DockRight ||
				DockState == DockState.DockTop || DockState == DockState.DockBottom)
			{
				m_splitter = new DockWindowSplitter();
				Controls.Add(m_splitter);
			}

			if (DockState == DockState.DockLeft)
			{
				Dock = DockStyle.Left;
				m_splitter.Dock = DockStyle.Right;
			}
			else if (DockState == DockState.DockRight)
			{
				Dock = DockStyle.Right;
				m_splitter.Dock = DockStyle.Left;
			}
			else if (DockState == DockState.DockTop)
			{
				Dock = DockStyle.Top;
				m_splitter.Dock = DockStyle.Bottom;
			}
			else if (DockState == DockState.DockBottom)
			{
				Dock = DockStyle.Bottom;
				m_splitter.Dock = DockStyle.Top;
			}
			else if (DockState == DockState.Document)
				Dock = DockStyle.Fill;

			ResumeLayout();
		}

		/// <exclude/>
		protected override Size DefaultSize
		{
			// Set the default size to empty to reduce the screen flicker
			get	{	return Size.Empty;	}
		}

		/// <include file='CodeDoc\DockWindow.xml' path='//CodeDoc/Class[@name="DockWindow"]/Property[@name="DisplayingList"]/*'/>
		public DisplayingDockList DisplayingList
		{
			get	{	return DockList.DisplayingList;	}
		}

		/// <include file='CodeDoc\DockWindow.xml' path='//CodeDoc/Class[@name="DockWindow"]/Property[@name="DockList"]/*'/>
		public DockList DockList
		{
			get	{	return m_dockList;	}
		}

		/// <include file='CodeDoc\DockWindow.xml' path='//CodeDoc/Class[@name="DockWindow"]/Property[@name="DockPanel"]/*'/>
		public DockPanel DockPanel
		{
			get	{	return m_dockPanel;	}
		}

		/// <include file='CodeDoc\DockWindow.xml' path='//CodeDoc/Class[@name="DockWindow"]/Property[@name="DockState"]/*'/>
		public DockState DockState
		{
			get	{	return m_dockState;	}
		}

		/// <include file='CodeDoc\DockWindow.xml' path='//CodeDoc/Class[@name="DockWindow"]/Property[@name="IsFloat"]/*'/>
		public bool IsFloat
		{
			get	{	return DockState == DockState.Float;	}
		}

		internal DockPane DefaultPane
		{
			get	{	return DisplayingList.Count == 0 ? null : DisplayingList[0];	}
		}

		/// <include file='CodeDoc\DockWindow.xml' path='//CodeDoc/Class[@name="DockWindow"]/Property[@name="DisplayingRectangle"]/*'/>
		public virtual Rectangle DisplayingRectangle
		{
			get
			{
				Rectangle rect = ClientRectangle;
				// if DockWindow is document, exclude the border
				if (DockState == DockState.Document)
				{
					rect.X += 1;
					rect.Y += 1;
					rect.Width -= 2;
					rect.Height -= 2;
				}
				// exclude the splitter
				else if (DockState == DockState.DockLeft)
					rect.Width -= MeasureDockWindow.SplitterSize;
				else if (DockState == DockState.DockRight)
				{
					rect.X += MeasureDockWindow.SplitterSize;
					rect.Width -= MeasureDockWindow.SplitterSize;
				}
				else if (DockState == DockState.DockTop)
					rect.Height -= MeasureDockWindow.SplitterSize;
				else if (DockState == DockState.DockBottom)
				{
					rect.Y += MeasureDockWindow.SplitterSize;
					rect.Height -= MeasureDockWindow.SplitterSize;
				}

				return rect;
			}
		}

		/// <exclude/>
		protected override void OnPaint(PaintEventArgs e)
		{
			// if DockWindow is document, draw the border
			if (DockState == DockState.Document)
				e.Graphics.DrawRectangle(SystemPens.ControlDark, ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);

			base.OnPaint(e);
		}

		/// <exclude/>
		protected override void OnLayout(LayoutEventArgs levent)
		{
			DisplayingList.Refresh();
			if (DisplayingList.Count == 0)
			{
				Visible = false;
				base.OnLayout(levent);
				return;
			}

			if (!Visible)
			{
				SendToBack();
				Visible = true;
				DisplayingList.Refresh();
			}
			base.OnLayout (levent);
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DockWindow
            // 
            this.Font = new System.Drawing.Font("΢���ź�", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResumeLayout(false);

        }
    }
}
