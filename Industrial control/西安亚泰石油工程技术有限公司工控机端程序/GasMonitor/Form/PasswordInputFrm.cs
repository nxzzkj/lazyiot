using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasMonitor
{
    public partial class PasswordInputFrm : UILoginForm
    {
        public PasswordInputFrm()
        {
            InitializeComponent();
        }

        private bool PasswordInputFrm_OnLogin(string userName, string password)
        {
            string u = GasMonitorManager.Config.AdminUser.UserName;
            string p = GasMonitorManager.Config.AdminUser.Password;
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password) && u.Trim() == userName.Trim() && p.Trim() == password.Trim())
            {
                return true;
            }
            return false;
        }
        private void PasswordInputFrm_ButtonLoginClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }

        private void PasswordInputFrm_ButtonCancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
