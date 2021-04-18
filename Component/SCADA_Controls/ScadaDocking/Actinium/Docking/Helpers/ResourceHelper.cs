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
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace Scada.Controls
{
	internal class ResourceHelper
	{
		private static ResourceManager m_resourceManager;

		static ResourceHelper()
		{
			m_resourceManager = new ResourceManager("Scada.Controls.ScadaDocking.Actinium.Docking.Strings", typeof(DockPanel).Assembly);
		}
	
		public static Bitmap LoadBitmap(string name)
		{
			Assembly assembly = typeof(ResourceHelper).Assembly;
			string fullNamePrefix = "Scada.Controls.ScadaDocking.Actinium.Docking.Resources.";
			return new Bitmap(assembly.GetManifestResourceStream(fullNamePrefix + name));
		}

		public static string GetString(string name)
		{
			return m_resourceManager.GetString( name);
		}
	}
}
