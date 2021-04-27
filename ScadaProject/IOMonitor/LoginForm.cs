using Scada.Controls.Forms;

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

namespace IOMonitor
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Load += LoginForm_Load;
        }
        private bool isAuto = false;
        public LoginForm(string user,string password)
        {
            InitializeComponent();
            this.Load += LoginForm_Load;
            this.tbUser.Text = user;
            this.tbPassword.Text = password;
            isAuto = true;//自动登录
    }
    public int Port
        {
            get { return int.Parse(Core.IOMonitorManager.Config.RemotePort); }
        }
        public string  IP
        {
            get { return this.txtIP.Text; }
        }
        public string User
        {
            get {
                return this.tbUser.Text.Trim();
            }
        }
        public string Password
        {
            get
            {
                return this.tbPassword.Text.Trim();
            }
        }
        private   void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                  Core.IOMonitorManager.CreateConfig();
            }
            catch
            {
            
                return;
            }
              
            this.txtIP.Text = Core.IOMonitorManager.Config.RemoteIP;
            if (isAuto)
            {
                btnOK_BtnClick(sender, e);//自动执行登录
            }
        }
        public void SetShowInfo(string msg)
        {
            try
            {
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke(new EventHandler(delegate
                {
                    labelInfo.Text = msg;
                }));
                }
            }
            catch
            {

            }
        }

        private   void btnOK_BtnClick(object sender, EventArgs e)
        {
           
            if (this.tbUser.Text.Trim() == "")
            {
                FrmDialog.ShowDialog(this, "请输入账户", "账户输入");
                return;
            }
            if (this.tbPassword.Text.Trim() == "")
            {
                FrmDialog.ShowDialog(this, "请输入密码", "密码输入");
                return;
            }
            if (this.txtIP.Text.Trim() == "")
            {
                FrmDialog.ShowDialog(this, "请输入服务器的IP地址", "IP提示");
                return;
            }

          
            if(Core.IOMonitorManager.TcpClient!=null&& !Core.IOMonitorManager.TcpClient.Client.IsClosing)
            {
              
                SetShowInfo("登录验证中....");
                 Core.IOMonitorManager.UserLogin(User, Password);
            }
            else
            {
                IPAddress ip = IPAddress.Any;
                if (IPAddress.TryParse(this.txtIP.Text.Trim(), out ip))
                {
                   
                      Core.IOMonitorManager.CreateTCPServer(this.txtIP.Text.Trim());
                   Core.IOMonitorManager.TcpClient.OnConnectedServer += TcpClient_OnConnectedServer;
                    Core.IOMonitorManager.TcpClient.OnUserLogined += TcpClient_OnUserLogined;
                  
                   
                }
                else
                {
                    FrmDialog.ShowDialog(this, "请输入正确服务器的IP地址", "IP提示");
                }
         
              
            }
        }

        private   void TcpClient_OnConnectedServer(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg)
        {
            if (Convert.ToBoolean(sender)& Core.IOMonitorManager.TcpClient!=null)
            {
                if (Core.IOMonitorManager.TcpClient.Client == client)
                {
                     Core.IOMonitorManager.UserLogin(User, Password);
                }

            }
        }

        private   void TcpClient_OnUserLogined(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg)
        {
            if (Convert.ToBoolean(sender))
            {
          
                Core.IOMonitorManager.Config.User = this.tbUser.Text.Trim();
                Core.IOMonitorManager.Config.Password = this.tbPassword.Text.Trim();
                Core.IOMonitorManager.Config.RemoteIP = this.txtIP.Text.Trim();
                Core.IOMonitorManager.Config.WriteConfig();//保存用户配置信息
         
               
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                SetShowInfo("登录服务器失败!" + msg);
         
          
            }
        }

        private   void btnCancel_BtnClick(object sender, EventArgs e)
        {
     
            Application.ExitThread();
            Application.Exit();
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
