using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IScadaDriver;

namespace Modbus
{
    public partial class Modbus_TCP_Ctrl : CommunicationControl
    {
        public Modbus_TCP_Ctrl()
        {
            InitializeComponent();
        }
        public override bool IsValidParameter()
        {
            return true;
        }
        public override void SetUIParameter(string para)
        {
            base.SetUIParameter(para);
        }
        public override string GetUIParameter()
        {
            return base.GetUIParameter();
        }
    }
}
