﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scada.Controls.Controls
{
    public class CrumbNavigationClickEventArgs : EventArgs
    {
        public int Index { get; set; }
        public CrumbNavigationItem Item { get; set; }
    }
}
