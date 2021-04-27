using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scada.DBUtility
{
    public partial class IPAddressSelector : Form
    {
        public IPAddressSelector()
        {
            InitializeComponent();
            this.Load += IPAddressSelector_Load;
        }
        private static IPAddressSelector addressSelector = null;
        public static IPAddressSelector Instance()
        {
            if (addressSelector == null)
            {
                addressSelector = new IPAddressSelector();

            }
        
            return addressSelector;
        }
        public  string AddressIP = "127.0.0.1";
        private void IPAddressSelector_Load(object sender, EventArgs e)
        {
            cbIPAddress.Items.Clear();
            ///获取本地的IP地址
       
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    cbIPAddress.Items.Add(_IPAddress.ToString());
             
                }
            }
            if (cbIPAddress.Items.Count>0 && cbIPAddress.Items.Count==1)
            {
                //如果只有一个连接的时候则,自动选择
                AddressIP = cbIPAddress.Items[0].ToString();
                this.DialogResult = DialogResult.OK;
            }
         
  
        }
        private void btOK_Click(object sender, EventArgs e)
        {
            if(cbIPAddress.SelectedItem==null)
            {
                MessageBox.Show("请选择合适的网络");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
