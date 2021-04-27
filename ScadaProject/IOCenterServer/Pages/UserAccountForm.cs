using Scada.Controls.Forms;
using ScadaCenterServer.Core;
using ScadaCenterServer.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScadaCenterServer.Pages
{
    public partial class UserAccountForm : PopBaseForm
    {
        public UserAccountForm()
        {
            InitializeComponent();
            this.Load += UserAccountForm_Load;
        }

        private void UserAccountForm_Load(object sender, EventArgs e)
        {
            this.tbUser.Text = IOCenterManager.IOProject.ServerConfig.User;
            this.tbPassword.Text = IOCenterManager.IOProject.ServerConfig.Password;
        }

        private void btnOK_BtnClick(object sender, EventArgs e)
        {
            if (this.tbPassword.Text.Trim()=="")
            {
                FrmDialog.ShowDialog(this, "请输入密码!");
                return;
            }
            if (this.tbPassword.Text.Trim() !=this.tbConfirm.Text.Trim())
            {
                FrmDialog.ShowDialog(this, "密码确认不正确!");
                return;
            }
            if (FrmDialog.ShowDialog(this, "请输入密码!","修改密码提醒",true,true,true,true) == DialogResult.OK)
            {


                IOCenterManager.IOProject.ServerConfig.User = this.tbUser.Text;
                IOCenterManager.IOProject.ServerConfig.Password = this.tbPassword.Text;
                IOCenterManager.IOProject.ServerConfig.WriteConfig();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_BtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
