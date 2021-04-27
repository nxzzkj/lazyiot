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
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

using System.IO;
using System.Text;
using System.Xml;
using System.Globalization;

namespace Scada.Controls
{
	internal class DockPanelPersist
	{
		private const string ConfigFileVersion = "0.9.3";

		private class DummyContent : DockContent
		{
		}

		private struct DockPanelStruct
		{
			private double m_dockLeftPortion;
			public double DockLeftPortion
			{
				get	{	return m_dockLeftPortion;	}
				set	{	m_dockLeftPortion = value;	}
			}

			private double m_dockRightPortion;
			public double DockRightPortion
			{
				get	{	return m_dockRightPortion;	}
				set	{	m_dockRightPortion = value;	}
			}

			private double m_dockTopPortion;
			public double DockTopPortion
			{
				get	{	return m_dockTopPortion;	}
				set	{	m_dockTopPortion = value;	}
			}

			private double m_dockBottomPortion;
			public double DockBottomPortion
			{
				get	{	return m_dockBottomPortion;	}
				set	{	m_dockBottomPortion = value;	}
			}

			private int m_indexActiveDocumentPane;
			public int IndexActiveDocumentPane
			{
				get	{	return m_indexActiveDocumentPane;	}
				set	{	m_indexActiveDocumentPane = value;	}
			}

			private int m_indexActivePane;
			public int IndexActivePane
			{
				get	{	return m_indexActivePane;	}
				set	{	m_indexActivePane = value;	}
			}
		}

		private struct ContentStruct
		{
			private string m_persistString;
			public string PersistString
			{
				get	{	return m_persistString;	}
				set	{	m_persistString = value;	}
			}

			private double m_autoHidePortion;
			public double AutoHidePortion
			{
				get	{	return m_autoHidePortion;	}
				set	{	m_autoHidePortion = value;	}
			}

			private bool m_isHidden;
			public bool IsHidden
			{
				get	{	return m_isHidden;	}
				set	{	m_isHidden = value;	}
			}

			private bool m_isFloat;
			public bool IsFloat
			{
				get	{	return m_isFloat;	}
				set	{	m_isFloat = value;	}
			}
		}

		private struct PaneStruct
		{
			private DockState m_dockState;
			public DockState DockState
			{
				get	{	return m_dockState;	}
				set	{	m_dockState = value;	}
			}

			private int m_indexActiveContent;
			public int IndexActiveContent
			{
				get	{	return m_indexActiveContent;	}
				set	{	m_indexActiveContent = value;	}
			}

			private int[] m_indexContents;
			public int[] IndexContents
			{
				get	{	return m_indexContents;	}
				set	{	m_indexContents = value;	}
			}

			private int m_zOrderIndex;
			public int ZOrderIndex
			{
				get	{	return m_zOrderIndex;	}
				set	{	m_zOrderIndex = value;	}
			}
		}

		private struct DockListItem
		{
			private int m_indexPane;
			public int IndexPane
			{
				get	{	return m_indexPane;	}
				set	{	m_indexPane = value;	}
			}

			private int m_indexPrevPane;
			public int IndexPrevPane
			{
				get	{	return m_indexPrevPane;	}
				set	{	m_indexPrevPane = value;	}
			}

			private DockAlignment m_alignment;
			public DockAlignment Alignment
			{
				get	{	return m_alignment;	}
				set	{	m_alignment = value;	}
			}

			private double m_proportion;
			public double Proportion
			{
				get	{	return m_proportion;	}
				set	{	m_proportion = value;	}
			}
		}

		private struct DockWindowStruct
		{
			private DockState m_dockState;
			public DockState DockState
			{
				get	{	return m_dockState;	}
				set	{	m_dockState = value;	}
			}

			private int m_zOrderIndex;
			public int ZOrderIndex
			{
				get	{	return m_zOrderIndex;	}
				set	{	m_zOrderIndex = value;	}
			}

			private DockListItem[] m_dockList;
			public DockListItem[] DockList
			{
				get	{	return m_dockList;	}
				set	{	m_dockList = value;	}
			}
		}

		private struct FloatWindowStruct
		{
			private Rectangle m_bounds;
			public Rectangle Bounds
			{
				get	{	return m_bounds;	}
				set	{	m_bounds = value;	}
			}
			
			private bool m_allowRedocking;
			public bool AllowRedocking
			{
				get	{	return m_allowRedocking;	}
				set	{	m_allowRedocking = value;	}
			}

			private int m_zOrderIndex;
			public int ZOrderIndex
			{
				get	{	return m_zOrderIndex;	}
				set	{	m_zOrderIndex = value;	}
			}

			private DockListItem[] m_dockList;
			public DockListItem[] DockList
			{
				get	{	return m_dockList;	}
				set	{	m_dockList = value;	}
			}
		}

		public DockPanelPersist()
		{
		}

		public static void SaveAsXml(DockPanel dockPanel, string filename)
		{
			
		}

		public static void SaveAsXml(DockPanel dockPanel, string filename, Encoding encoding)
		{
			
		}

		public static void SaveAsXml(DockPanel dockPanel, Stream stream, Encoding encoding)
		{
		}

		public static void LoadFromXml(DockPanel dockPanel, string filename, DeserializeDockContent deserializeContent)
		{
			
		}

		public static void LoadFromXml(DockPanel dockPanel, Stream stream, DeserializeDockContent deserializeContent)
		{

			
		}

		private static void MoveToNextElement(XmlTextReader xmlIn)
		{
			xmlIn.Read();
			while (xmlIn.NodeType == XmlNodeType.EndElement)
				xmlIn.Read();
		}
	}
}
