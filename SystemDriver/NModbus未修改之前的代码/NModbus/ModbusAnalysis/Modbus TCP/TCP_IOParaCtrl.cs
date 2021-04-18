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
using ZZSCADA.Model;

namespace Modbus
{
    public partial class TCP_IOParaCtrl : IOParaControl
    {
        public TCP_IOParaCtrl()
        {
            InitializeComponent();
        }
        public override void SetUIParameter(IO_SERVER server, IO_DEVICE device, IO_PARA para)
        {
            base.SetUIParameter(server, device, para);
        }
        public override string GetUIParameter()
        {
            return base.GetUIParameter();
        }
        public override bool IsValidParameter()
        {
            return true;
        }

        private void cbo_StoreType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_StoreType.SelectedIndex == 2 || cbo_StoreType.SelectedIndex == 3)
            {
                groupData.Visible = true;
                groupposition.Visible = true;
            }
            else
            {
                groupData.Visible = false;
                groupposition.Visible = false;
            }
        }
    }
}
