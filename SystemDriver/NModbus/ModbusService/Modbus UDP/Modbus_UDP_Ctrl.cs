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
using Modbus.Utility;

namespace Modbus.ModbusService
{
    public partial class Modbus_UDP_Ctrl : CommunicationKernelControl
    {
        public Modbus_UDP_Ctrl()
        {
            InitializeComponent();
            this.tbLocalIP.Text = ModbusUtility.GetIpAddress();
            this.tbSMDeviceIP.Text = ModbusUtility.GetIpAddress();
        }
        public override ScadaResult IsValidParameter()
        {
            if (tbSMDeviceIP.Text == "")
            {
                MessageBox.Show(this.FindForm(), "请配置设备IP地址");
                return new ScadaResult(false, "请配置设备IP地址") ;
            }


            return new ScadaResult();
        }
        public override void SetUIParameter(string para)
        {
            //初始化

            base.SetUIParameter(para);
            ParaPack paraPack = new ParaPack(para);
            //波特率
            tbSMDeviceIP.Text = paraPack.GetValue("模拟设备IP");
            ndSMPort.Text = paraPack.GetValue("模拟设备端口");
            tbLocalIP.Text = paraPack.GetValue("本地IP");
            ndLocalPort.Text = paraPack.GetValue("本地端口");
            cbRetries.Checked = paraPack.GetValue("重试") == "1" ? true : false;
            ndRetiresNum.Text = paraPack.GetValue("重试次数");
            nbRetiresInternal.Text = paraPack.GetValue("重试间隔");
            nbWriteTimeout.Value = Convert.ToDecimal(paraPack.GetValue("写超时时间"));
            nbReadTimeout.Value = Convert.ToDecimal(paraPack.GetValue("读超时时间"));
            ndReadBuffSize.Value = Convert.ToDecimal(paraPack.GetValue("读缓存"));
            ndWriteBufferSize.Value = Convert.ToDecimal(paraPack.GetValue("写缓存"));
        }
        public override string GetUIParameter()
        {
            ParaPack paraPack = new ParaPack();
            paraPack.AddItem("模拟设备IP", tbSMDeviceIP.Text);
            paraPack.AddItem("模拟设备端口", ndSMPort.Text);
            paraPack.AddItem("本地IP", tbLocalIP.Text);
            paraPack.AddItem("本地端口", ndLocalPort.Text);
            paraPack.AddItem("重试", cbRetries.Checked ? "1" : "0");
            paraPack.AddItem("重试次数", ndRetiresNum.Text);
            paraPack.AddItem("重试间隔", nbRetiresInternal.Text.ToString());
            paraPack.AddItem("写超时时间", nbWriteTimeout.Text);
            paraPack.AddItem("读超时时间", nbReadTimeout.Text);
            paraPack.AddItem("读缓存", ndReadBuffSize.Text);
            paraPack.AddItem("写缓存", ndWriteBufferSize.Text);
            return paraPack.ToString();
        }
    }
}
