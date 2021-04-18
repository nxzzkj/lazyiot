
using Scada.Controls.Forms;
using ScadaCenterServer.Core;
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

namespace ScadaCenterServer
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnOK_BtnClick(object sender, EventArgs e)
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
            if (IOCenterManager.IOProject.ServerConfig.User.Trim() == this.tbUser.Text.Trim()
               && IOCenterManager.IOProject.ServerConfig.Password.Trim() == this.tbPassword.Text.Trim())
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_BtnClick(object sender, EventArgs e)
        {
           
            Application.ExitThread();
            Application.Exit();
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
           
        }
 
    }
}
