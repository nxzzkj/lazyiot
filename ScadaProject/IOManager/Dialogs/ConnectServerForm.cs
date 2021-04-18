using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOManager.Dialogs
{
    public partial class ConnectServerForm : BasicDialogForm
    {
        public ConnectServerForm()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if(this.txtIP.Text.Trim()=="")
            {
                MessageBox.Show("请输入服务器IP");
                return;
            }
            if (this.txtPort.Text.Trim() == "")
            {
                MessageBox.Show("请输入服务器端口");
                return;
            }
            if (this.txtUser.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户名");
                return;
            }
            if (this.txtPwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码");
                return;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {

        }
    }
}
