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
	internal class AutoHideWindowSplitter : SplitterBase
	{
		protected override int SplitterSize
		{
			get	{	return MeasureAutoHideWindow.SplitterSize;	}
		}

		protected override void StartDrag()
		{
			AutoHideWindow window = Parent as AutoHideWindow;
			if (window == null)
				return;

			window.DockPanel.DragHandler.BeginDragAutoHideWindowSplitter(window, this.Location);
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AutoHideWindowSplitter
            // 
            this.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResumeLayout(false);

        }
    }
}
