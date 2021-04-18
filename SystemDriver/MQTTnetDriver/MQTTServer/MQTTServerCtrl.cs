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

namespace MQTTnet
{
    public partial class MQTTServerCtrl : CommunicationKernelControl
    {
        public MQTTServerCtrl()
        {
            InitializeComponent();
          
        }
        public override void SetUIParameter(string para)
        {
            cbReceiveMethod.SelectedIndex = 0;
            cbMessage.SelectedIndex = 0;
            cbWill.SelectedIndex = 0;
            cbDataType.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(para))
            {
                ParaPack paraPack = new ParaPack(para);
                paraPack.SetCtrlValue(txtIp, paraPack.GetValue("服务器IP"));
                paraPack.SetCtrlValue(nudPort, paraPack.GetValue("端口号"));
                paraPack.SetCtrlValue(tbUser, paraPack.GetValue("用户名"));
                paraPack.SetCtrlValue(tbPwd, paraPack.GetValue("密码"));
                paraPack.SetCtrlValue(cbEnableUser, paraPack.GetValue("开启匿名验证"));
                paraPack.SetCtrlValue(tbHeart, paraPack.GetValue("心跳时间"));
                paraPack.SetCtrlValue(cbMessage, paraPack.GetValue("消息质量"));
                paraPack.SetCtrlValue(cbWill, paraPack.GetValue("遗愿标志"));
                paraPack.SetCtrlValue(cbDataType, paraPack.GetValue("数据格式"));
                paraPack.SetCtrlValue(cbClientIDEnable, paraPack.GetValue("开启Mqtt客户端识别"));
                paraPack.SetCtrlValue(cbReceiveMethod, paraPack.GetValue("接收方式"));
            }
            else
            {
                string AddressIP = "127.0.0.1";
                foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                    {
                        AddressIP = _IPAddress.ToString();
                    }
                }
             
                txtIp.Text = AddressIP;
            }
           
            
        }
        private string GetParament()
        {

            ParaPack para = new ParaPack();
            para.AddItem("服务器IP", txtIp.Text);
            para.AddItem("端口号", nudPort.Value.ToString("0"));
            para.AddItem("用户名", tbUser.Text);
            para.AddItem("密码", tbPwd.Text);
            para.AddItem("开启匿名验证", cbEnableUser.Checked.ToString());
            para.AddItem("心跳时间", tbHeart.Text.ToString());
            para.AddItem("消息质量", cbMessage.SelectedItem.ToString());
            para.AddItem("遗愿标志", cbWill.SelectedItem.ToString());
            para.AddItem("数据格式", cbDataType.SelectedItem.ToString());
            para.AddItem("开启Mqtt客户端识别", cbClientIDEnable.Checked.ToString());
            para.AddItem("接收方式", cbReceiveMethod.SelectedItem.ToString());
            return para.ToString();


        }
        public override string GetUIParameter()
        {
            return GetParament();
        }
        public override ScadaResult IsValidParameter()
        {
            IPAddress ip  ;
            if(!IPAddress.TryParse(txtIp.Text,out ip))
            {
                return new ScadaResult(false, "服务器IP地址不正确");
            }
            if (cbMessage.SelectedItem==null)
            {
                return new ScadaResult(false, "请选择消息质量类型");
            }
            if (cbWill.SelectedItem == null)
            {
                return new ScadaResult(false, "请选择遗愿标志");
            }
            if (cbDataType.SelectedItem == null)
            {
                return new ScadaResult(false, "请选择数据格式");
            }
            if (cbReceiveMethod.SelectedItem == null)
            {
                return new ScadaResult(false, "请选择接收方式");
            }
            if (cbDataType.SelectedIndex==1)
            {
                if (cbReceiveMethod.SelectedItem == null)
                {
                    return new ScadaResult(false, "请选择数据接收方式");
                }
            }
         
            
            return new ScadaResult();
        }

        private void cbEnableUser_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Enabled = cbEnableUser.Checked;
        }

        private void cbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbDataType.SelectedIndex==1)
            {
                panel9.Visible = true;
            }
            else
            {
                panel9.Visible = false;
            }
        }
    }
}
