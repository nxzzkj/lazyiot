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
	/// <include file='CodeDoc/AutoHideTab.xml' path='//CodeDoc/Class[@name="AutoHideTab"]/ClassDef/*'/>
	public class AutoHideTab : IDisposable
	{
		private DockContent m_content;

		/// <include file='CodeDoc/AutoHideTab.xml' path='//CodeDoc/Class[@name="AutoHideTab"]/Construct[@name="(DockContent)"]/*'/>
		public AutoHideTab(DockContent content)
		{
			m_content = content;
		}

		/// <exclude/>
		~AutoHideTab()
		{
			Dispose(false);
		}

		/// <include file='CodeDoc/AutoHideTab.xml' path='//CodeDoc/Class[@name="AutoHideTab"]/Property[@name="Content"]/*'/>
		public DockContent Content
		{
			get	{	return m_content;	}
		}

		/// <include file='CodeDoc/AutoHideTab.xml' path='//CodeDoc/Class[@name="AutoHideTab"]/Method[@name="Dispose"]/*'/>
		/// <include file='CodeDoc/AutoHideTab.xml' path='//CodeDoc/Class[@name="AutoHideTab"]/Method[@name="Dispose()"]/*'/>
		public void Dispose()
		{
			Dispose(true);
		}

		/// <include file='CodeDoc/AutoHideTab.xml' path='//CodeDoc/Class[@name="AutoHideTab"]/Method[@name="Dispose(bool)"]/*'/>
		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
