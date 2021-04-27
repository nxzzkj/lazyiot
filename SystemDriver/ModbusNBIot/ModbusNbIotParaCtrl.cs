using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DriveInterface;
using Scada.Model;

namespace ModbusNBIot
{
    public partial class ModbusNbIotParaCtrl : IOParaControl
    {
        public ModbusNbIotParaCtrl()
        {
            InitializeComponent();
        }
        public override void SetUIParameter(IO_SERVER server, IO_DEVICE device, IO_PARA para)
        {
            ParaPack paraPack = new ParaPack(device.IO_DEVICE_PARASTRING);
            paraPack.SetCtrlValue(cbo_functioncode, paraPack.GetValue("内存区"));
            paraPack.SetCtrlValue(ndOffset, paraPack.GetValue("偏置"));
            paraPack.SetCtrlValue(cbo_StoreType, paraPack.GetValue("数据类型"));
            paraPack.SetCtrlValue(cbo_datatype, paraPack.GetValue("存储位置"));
            paraPack.SetCtrlValue(ndCharSize, paraPack.GetValue("字节长度"));
            paraPack.SetCtrlValue(cbPosition, paraPack.GetValue("按位存取"));
            paraPack.SetCtrlValue(ndPosition, paraPack.GetValue("数据位"));
            if (paraPack.GetValue("读写状态") == "可读可写")
                paraPack.SetCtrlValue(rb_rw, "1");
            if (paraPack.GetValue("读写状态") == "可读")
                paraPack.SetCtrlValue(rb_r, 1);
            if (paraPack.GetValue("读写状态") == "可写")
                paraPack.SetCtrlValue(rb_w, 1);
        }
        public override string GetUIParameter()
        {
            ParaPack paraPack = new ParaPack();
            paraPack.AddItem("内存区", cbo_functioncode);
            paraPack.AddItem("偏置", ndOffset);
            paraPack.AddItem("数据类型", cbo_StoreType);
            paraPack.AddItem("存储位置", cbo_datatype);
            paraPack.AddItem("字节长度", ndCharSize);
            paraPack.AddItem("按位存取", cbPosition);
            paraPack.AddItem("数据位", ndPosition);
            if(rb_rw.Checked)
            paraPack.AddItem("读写状态", "可读可写");
            if (rb_r.Checked)
                paraPack.AddItem("读写状态", "可读");
            if (rb_w.Checked)
                paraPack.AddItem("读写状态", "可写");
            return paraPack.ToString();
        }
        public override ScadaResult IsValidParameter()
        {
            if(cbo_functioncode.SelectedItem==null)
            {
                MessageBox.Show(this,"请选择内存区");
                return new ScadaResult(false, "请选择内存区");
            }
            if (cbo_StoreType.SelectedItem == null)
            {
                MessageBox.Show(this, "请选择数据类型");
                return new ScadaResult(false, "请选择数据类型");
            }
            if (cbo_datatype.SelectedItem == null)
            {
                MessageBox.Show(this, "请选择存储位置");
                return new ScadaResult(false, "请选择存储位置");
            }
            return base.IsValidParameter();
        }
    }
}
