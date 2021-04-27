using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GraphicsUI.DockControl.Docking.Extenders.VS2005
{
	[ToolboxItem(false)]
	public class DockPaneStripOverride : DockPaneStripVS2003
	{
		protected internal DockPaneStripOverride(DockPane pane) : base(pane)
		{
			BackColor = SystemColors.ControlLight;
		}
	}
}
