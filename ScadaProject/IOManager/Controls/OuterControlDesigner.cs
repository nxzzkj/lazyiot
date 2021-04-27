using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;

using System.Windows.Forms.Design;

namespace IOManager.Controls
{
    public class OuterControlDesigner : ControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            this.EnableDesignMode(((WizardTabControl)this.Control).TabControl, "TabControl");
        }
    }
    public class ListViewControlDesigner : ControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            this.EnableDesignMode(((IOListView)this.Control).ListView, "ListVIew");
        }
    }
}
