using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Kernel;
using Scada.Model;

namespace Modbus.ModbusAnalysis
{
    public partial class IODeviceCtrl : IODeviceKernelControl
    {
        public IODeviceCtrl()
        {
            InitializeComponent();
        }
        public override void SetUIParameter(IO_SERVER server, IO_DEVICE device)
        {
            base.SetUIParameter(server, device);
        }
        public override string GetUIParameter()
        {
            return base.GetUIParameter();
        }
        public override ScadaResult IsValidParameter()
        {
            return new ScadaResult();
        }
    }
}
