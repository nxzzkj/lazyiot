using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOMonitor.Controls
{
    public class IOTree : TreeView
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        protected override void WndProc(ref Message m)
        {

            if (m.Msg == 0x0014) // 禁掉清除背景消息WM_ERASEBKGND

                return;

            base.WndProc(ref m);

        }
        public IOTree():base()
        {
            
            SetStyle(ControlStyles.DoubleBuffer |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }
    }
}
