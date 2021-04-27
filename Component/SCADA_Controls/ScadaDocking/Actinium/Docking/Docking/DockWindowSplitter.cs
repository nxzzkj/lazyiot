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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Scada.Controls
{
	internal class DockWindowSplitter : SplitterBase
	{
		protected override int SplitterSize
		{
			get	{	return MeasureDockWindow.SplitterSize;	}
		}

		protected override void StartDrag()
		{
			DockWindow window = Parent as DockWindow;
			if (window == null)
				return;

			window.DockPanel.DragHandler.BeginDragDockWindowSplitter(window, this.Location);
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DockWindowSplitter
            // 
            this.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResumeLayout(false);

        }
    }
}
