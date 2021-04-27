using Scada.Controls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Model;

namespace ScadaFlowDesign.Dialog
{
    public partial class FlowUserManagerForm : FrmWithOKCancel1
    {
        public FlowUserManagerForm()
        {
            InitializeComponent();
         
        }
        private ScadaFlowUser _EditUser = null;
        /// <summary>
        /// 返回用户信息
        /// </summary>
        /// <returns></returns>
        public ScadaFlowUser EditUser
        {
            set { _EditUser = value;

                if(_EditUser!=null)
                {
                    this.tbNikeName.Text = _EditUser.Nickname;
                    this.tbUserName.Text = _EditUser.UserName;
                    this.tbPassword.Text = _EditUser.Password;
                    this.cbRead.Checked = _EditUser.Read == 1 ? true : false;
                    this.cbWrite.Checked = _EditUser.Write == 1 ? true : false;
                }
            }
            get { return _EditUser; }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
           
      
        }
        public override void btnOK_BtnClick(object sender, EventArgs e)
        {
            if (this.tbNikeName.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入用户昵称");
                return;
            }
            if (this.tbUserName.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入用户名称");
                return;
            }
            if (this.tbPassword.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入用户密码");
                return;
            }
            if (EditUser == null)
                EditUser = new ScadaFlowUser();
            EditUser.Nickname = this.tbNikeName.Text.Trim();
            EditUser.Password = this.tbPassword.Text.Trim();
            EditUser.UserName = this.tbUserName.Text.Trim();
            if (this.cbRead.Checked)
            {
                EditUser.Read = 1;
            }
            else
            {
                EditUser.Read = 0;
            }

            if (this.cbWrite.Checked)
            {
                EditUser.Write = 1;
            }
            else
            {
                EditUser.Write = 0;
            }
            this.DialogResult = DialogResult.OK;
        }

        
    }
}
