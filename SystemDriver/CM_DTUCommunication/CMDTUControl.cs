using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommunicationBase;
using System.Net;

namespace CM_DTUCommunication
{
    public partial class CMDTUControl : CommunicationControl
    {

        private string GetLocalIp()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }
        public CMDTUControl()
        {
            InitializeComponent();
            this.Load += (s, e) => {
                this.tb_thiip.Text = GetLocalIp();
                comboModel.SelectedIndex = 0;
            };
        }
        public override string GetUIParameter()
        {
            string config = "Port:" + tb_port.Value + ",IP:" + tb_thiip.Text+",MODE:"+ comboModel.SelectedItem.ToString()+",TIMEOUT:"+this.txtTimeout.Value;
            this.ParameterString = config;
            return ParameterString;
        }
        public override void SetUIParameter(string para)
        {
            try
            {


                ParameterString = para;

                string[] paras = para.Split(',');
                if (paras.Length == 4)
                {
                    tb_port.Value = int.Parse(paras[0].Split(':')[1]);
                    tb_thiip.Text = paras[1].Split(':')[1];
                    comboModel.SelectedItem = paras[2].Split(':')[1];
                    txtTimeout.Value = int.Parse(paras[3].Split(':')[1]);
                }
            }
            catch
            {
             
            }
            
        }
        public override bool IsValidParameter()
        {
            if (tb_port.Text.Trim() == "")
            {
                MessageBox.Show("请输入端口");
                return false;
            }

            if (tb_thiip.Text.Trim() == "")
            {
                MessageBox.Show("请输入采集站IP");
                return false;
            }
            return true;
        }
    }
}
