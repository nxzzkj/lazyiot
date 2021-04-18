using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scada.Controls.Controls.FactoryControls.Meter
{
    public partial class UCMeterEx : UserControl
    {
        public UCMeterEx()
        {
            InitializeComponent();
        }
        public string Title
        {
            set { labelTitle.Text = value; }
            get { return labelTitle.Text; }
        }
    }
}
