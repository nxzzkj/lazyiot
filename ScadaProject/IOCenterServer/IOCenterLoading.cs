using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Scada.Controls.Forms;

namespace ScadaCenterServer
{
    public partial class IOCenterLoading : FrmLoading
    {
        public IOCenterLoading()
        {
            InitializeComponent();
            
        }
        protected override void BindingProcessMsg(string strText, int intValue)
        {
            label1.Text = strText;
            this.ucProcessLineExt1.Value = intValue;
        }
        public void SetInfo(string txt)
        {
            labelInfo.Text = txt;
        }
    }
}
