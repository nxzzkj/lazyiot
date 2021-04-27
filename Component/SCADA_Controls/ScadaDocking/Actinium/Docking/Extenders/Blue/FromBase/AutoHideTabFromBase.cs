
using System;
using System.Drawing;


namespace GraphicsUI.DockControl.Docking.Extenders.Blue
{
	internal class AutoHideTabFromBase : AutoHideTab
	{
		internal AutoHideTabFromBase(DockContent content) : base(content)
		{
		}

		private int m_tabX = 0;
		protected internal int TabX
		{
			get	{	return m_tabX;	}
			set	{	m_tabX = value;	}
		}

		private int m_tabWidth = 0;
		protected internal int TabWidth
		{
			get	{	return m_tabWidth;	}
			set	{	m_tabWidth = value;	}
		}

	}
}
