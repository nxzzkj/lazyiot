
using ScadaFlowDesign.Core;
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

namespace ScadaFlowDesign
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

                FlowManager.InitTcpClient(this.txtIP.Text);
                FlowManager.TcpClient.OnConnectedServer += TcpClient_OnConnectedServer;
                FlowManager.TcpClient.OnUserLogined += TcpClient_OnUserLogined;
                FlowManager.TcpClient.OnConnectTimeout += TcpClient_OnConnectTimeout;
                FlowManager.LoginManager(this.tbUser.Text.Trim(), this.tbPassword.Text.Trim());
            }
            else
            {
                MessageBox.Show(this, "请输入正确服务器的IP地址", "IP提示");
            }


        

         
        }

        private void TcpClient_OnConnectTimeout(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg, string projectid)
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
            FlowManager.Config = new IOConfig();
            this.tbPassword.Text = FlowManager.Config.Password;
            this.tbUser.Text = FlowManager.Config.User;
            this.txtIP.Text = FlowManager.Config.RemoteIP;
        }

        private void TcpClient_OnUserLogined(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg, string projectid)
        {
            if (Convert.ToBoolean(sender))
            {
                FlowManager.Config.User = this.tbUser.Text.Trim();
                FlowManager.Config.Password = this.tbPassword.Text.Trim();
                FlowManager.Config.RemoteIP = this.txtIP.Text.Trim();

                FlowManager.Config.WriteConfig();//保存用户配置信息
                this.DialogResult = DialogResult.OK ;
            }
            else
            {
                SetInfo("登录服务器失败!" + msg);
              

            }
        

        }

        private void TcpClient_OnConnectedServer(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg,string projectid)
        {
            SetInfo("与服务器连接成功!");
            Thread.Sleep(1000);
            SetInfo("正在验证登录.....");
            if (Convert.ToBoolean(sender))
            {
                if (FlowManager.TcpClient.Client == client)
                {


                    FlowManager.LoginManager(User, Password);
                }

            }
        }
    }
}
