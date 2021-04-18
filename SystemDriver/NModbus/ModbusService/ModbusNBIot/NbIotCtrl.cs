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
using System.Net;

namespace Modbus.ModbusService
{
    public partial class NbIotCtrl : CommunicationKernelControl
    {
        public NbIotCtrl()
        {
            InitializeComponent();
            
        }
        public override ScadaResult IsValidParameter()
        {
            if(txtIP.Text.Trim()=="")
            {
                MessageBox.Show(this, "请输入IP地址");
                return new ScadaResult(false, "请输入IP地址");
            }
            IPAddress address = IPAddress.Any;
            if (!IPAddress.TryParse(txtIP.Text.Trim(),out address))
            {
                MessageBox.Show(this, "请输入正确的IP地址");
                return new ScadaResult(false, "请输入正确的IP地址");
            }

            if(nudPort.Value<=0)
            {
                MessageBox.Show(this, "请输入服务端口号");
                return new ScadaResult(false, "请输入服务端口号");
            }
            if(cbRegisterType.SelectedItem==null)
            {
                MessageBox.Show(this, "请选择注册包类型");
                return new ScadaResult(false, "请选择注册包类型");
            }
            if (cbIdStoredType.SelectedItem == null)
            {
                MessageBox.Show(this, "请选择标识存储方式");
                return new ScadaResult(false, "请选择标识存储方式");
            }
            if (cbReceiveType.SelectedItem == null)
            {
                MessageBox.Show(this, "请选择数据接收方式");
                return new ScadaResult(false, "请选择数据接收方式");
            }
            if (cbHeart.SelectedItem == null)
            {
                MessageBox.Show(this, "请选择是否开启心跳");
                return new ScadaResult(false, "请选择是否开启心跳");
            }
            
            if (tbHeartbear.Text == null)
            {
                MessageBox.Show(this, "请设置心跳字节");
                return new ScadaResult(false, "请设置心跳字节");
            }
            return new  ScadaResult();
        }
        public override void SetUIParameter(string para)
        {
            ParaPack paraPack = new ParaPack(para);
            paraPack.SetCtrlValue(txtIP, paraPack.GetValue("本机IP"));
            paraPack.SetCtrlValue(nudPort, paraPack.GetValue("本机端口"));
            paraPack.SetCtrlValue(cbRegisterType, paraPack.GetValue("注册包"));
            paraPack.SetCtrlValue(nudIdLength, paraPack.GetValue("标识长度"));
            paraPack.SetCtrlValue(cbIdStoredType, paraPack.GetValue("存储方式"));
            paraPack.SetCtrlValue(cbReceiveType, paraPack.GetValue("接收方式"));
            paraPack.SetCtrlValue(tbHeartbear, paraPack.GetValue("心跳字节"));
            paraPack.SetCtrlValue(cbHeart, paraPack.GetValue("开启心跳"));
            paraPack.SetCtrlValue(nudTimeout, paraPack.GetValue("连接超时"));

            
        }
        public override string GetUIParameter()
        {
            ParaPack paraPack = new ParaPack();
            paraPack.AddItem("本机IP", txtIP);
            paraPack.AddItem("本机端口", nudPort);
            paraPack.AddItem("注册包", cbRegisterType);
            paraPack.AddItem("标识长度", nudIdLength);
            paraPack.AddItem("存储方式", cbIdStoredType);
            paraPack.AddItem("接收方式", cbReceiveType);
            paraPack.AddItem("心跳字节", tbHeartbear);
            paraPack.AddItem("开启心跳", cbHeart);
            paraPack.AddItem("连接超时", nudTimeout);
            return paraPack.ToString();
        }

    }
}
