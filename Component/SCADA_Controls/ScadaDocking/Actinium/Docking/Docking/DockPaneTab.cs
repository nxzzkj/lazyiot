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
using System.Drawing;

namespace Scada.Controls
{
	/// <include file='CodeDoc/DockPaneTab.xml' path='//CodeDoc/Class[@name="DockPaneTab"]/ClassDef/*'/>
	public class DockPaneTab : IDisposable
	{
		private DockContent m_content;

		/// <include file='CodeDoc/DockPaneTab.xml' path='//CodeDoc/Class[@name="DockPaneTab"]/Construct[@name="(DockContent)"]/*'/>
		public DockPaneTab(DockContent content)
		{
			m_content = content;
		}

		/// <exclude/>
		~DockPaneTab()
		{
			Dispose(false);
		}

		/// <include file='CodeDoc/DockPaneTab.xml' path='//CodeDoc/Class[@name="DockPaneTab"]/Property[@name="Content"]/*'/>
		public DockContent Content
		{
			get	{	return m_content;	}
		}

		/// <include file='CodeDoc/DockPaneTab.xml' path='//CodeDoc/Class[@name="DockPaneTab"]/Method[@name="Dispose"]/*'/>
		/// <include file='CodeDoc/DockPaneTab.xml' path='//CodeDoc/Class[@name="DockPaneTab"]/Method[@name="Dispose()"]/*'/>
		public void Dispose()
		{
			Dispose(true);
		}

		/// <include file='CodeDoc/DockPaneTab.xml' path='//CodeDoc/Class[@name="DockPaneTab"]/Method[@name="Dispose(bool)"]/*'/>
		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
