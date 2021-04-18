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
    public partial class NbIotDeviceCtrl : IODeviceKernelControl
    {
        public NbIotDeviceCtrl()
        {
            InitializeComponent();
        }
        public override void SetUIParameter(IO_SERVER server, IO_DEVICE device)
        {
            ParaPack paraPack = new ParaPack(device.IO_DEVICE_PARASTRING);
            paraPack.SetCtrlValue(tbIdentification, paraPack.GetValue("注册标识"));
            paraPack.SetCtrlValue(txtAddress, device.IO_DEVICE_ADDRESS);
            paraPack.SetCtrlValue(cbModbusType, paraPack.GetValue("Modbus类型"));
            paraPack.SetCtrlValue(nbReadTimeout, paraPack.GetValue("读超时"));
            paraPack.SetCtrlValue(nbWriteTimeout, paraPack.GetValue("写超时"));
            paraPack.SetCtrlValue(ndReadBuffSize, paraPack.GetValue("读缓存"));
            paraPack.SetCtrlValue(ndWriteBufferSize, paraPack.GetValue("写缓存"));
            paraPack.SetCtrlValue(cbRetries, paraPack.GetValue("失败重试"));
            paraPack.SetCtrlValue(ndRetiresNum, paraPack.GetValue("重试次数"));
            paraPack.SetCtrlValue(nbRetiresInternal, paraPack.GetValue("重试间隔"));
            paraPack.SetCtrlValue(cbFixUnit, paraPack.GetValue("指定寄存器范围"));
            paraPack.SetCtrlValue(nudStartUnit, paraPack.GetValue("起始地址"));
            paraPack.SetCtrlValue(nudUnitNum, paraPack.GetValue("寄存器数量"));

        }
        public override string GetUIParameter()
        {
            ParaPack paraPack = new ParaPack();
            paraPack.AddItem("注册标识",tbIdentification);
            paraPack.AddItem("设备地址", txtAddress);
            paraPack.AddItem("Modbus类型", cbModbusType);
            paraPack.AddItem("读超时", nbReadTimeout);
            paraPack.AddItem("写超时", nbWriteTimeout);
            paraPack.AddItem("读缓存", ndReadBuffSize);
            paraPack.AddItem("写缓存", ndWriteBufferSize);
            paraPack.AddItem("失败重试", cbRetries);
            paraPack.AddItem("重试次数", ndRetiresNum);
            paraPack.AddItem("重试间隔", nbRetiresInternal);
            paraPack.AddItem("指定寄存器范围", cbFixUnit);
            paraPack.AddItem("起始地址", nudStartUnit);
            paraPack.AddItem("寄存器数量", nudUnitNum);
            return base.GetUIParameter();
        }
        public override ScadaResult IsValidParameter()
        {
            if(tbIdentification.Text.Trim()=="")
            {
                MessageBox.Show("请设置4G或NB卡标识");
                return new ScadaResult(false, "请设置4G或NB卡标识") ;
            }
            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("请设置Modbus设备地址");
                return new ScadaResult(false, "请设置Modbus设备地址");
            }
            return new ScadaResult();
        }

        private void cbRetries_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxRetiry.Enabled = cbRetries.Checked;
        }

        private void cbFixUnit_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxFixUnit.Enabled = cbFixUnit.Checked;
        }
    }
}
