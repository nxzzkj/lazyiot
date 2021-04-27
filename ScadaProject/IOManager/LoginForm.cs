using IOManager.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOManager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        

        private void ucBtLogin_BtnClick(object sender, EventArgs e)
        {
            if (this.tbUser.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入账户", "账户输入");
                return;
            }
            if (this.tbPassword.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入密码", "密码输入");
                return;
            }
            if (this.txtIP.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入服务器的IP地址", "IP提示");
                return;
            }
            SetInfo("正在尝试连接服务器....");
            IPAddress ip = IPAddress.Any;
            if (IPAddress.TryParse(this.txtIP.Text.Trim(), out ip))
            {
     
                FormManager.InitTcpClient(this.txtIP.Text);
                FormManager.TcpClient.OnConnectedServer += TcpClient_OnConnectedServer;
                FormManager.TcpClient.OnUserLogined += TcpClient_OnUserLogined;
                FormManager.TcpClient.OnConnectTimeout += TcpClient_OnConnectTimeout;
                FormManager.LoginManager(this.tbUser.Text.Trim(), this.tbPassword.Text.Trim());
            }
            else
            {
                MessageBox.Show(this, "请输入正确服务器的IP地址", "IP提示");
            }


        

         
        }

        private void TcpClient_OnConnectTimeout(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg)
        {
          
            return;
        }

        private void ucBtnClose_BtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        public string User
        {
            get {return  this.tbUser.Text.Trim(); }
        }
        public string Password
        {
            get { return this.tbPassword.Text.Trim(); }
        }

        private void SetInfo(string msg)
        {
            try
            {
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke(new EventHandler(delegate
                {
                    this.labelInfo.Text = msg;
                }));
                }
            }
            catch
            {

            }

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            FormManager.Config = new IOConfig();
            this.tbPassword.Text = FormManager.Config.Password;
            this.tbUser.Text = FormManager.Config.User;
            this.txtIP.Text = FormManager.Config.RemoteIP;
        }

        private void TcpClient_OnUserLogined(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg)
        {
            if (Convert.ToBoolean(sender))
            {
                FormManager.Config.User = this.tbUser.Text.Trim();
                FormManager.Config.Password = this.tbPassword.Text.Trim();
                FormManager.Config.RemoteIP = this.txtIP.Text.Trim();
 
                FormManager.Config.WriteConfig();//保存用户配置信息
                this.DialogResult = DialogResult.OK ;
            }
            else
            {
                SetInfo("登录服务器失败!" + msg);
              

            }
        

        }

        private void TcpClient_OnConnectedServer(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg)
        {
            SetInfo("与服务器连接成功!");
            Thread.Sleep(1000);
            SetInfo("正在验证登录.....");
            if (Convert.ToBoolean(sender))
            {
                if (FormManager.TcpClient.Client == client)
                {


                   FormManager.LoginManager(User, Password);
                }

            }
        }
    }
}
