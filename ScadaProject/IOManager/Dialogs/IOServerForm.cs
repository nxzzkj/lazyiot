using Scada.Model;
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
    public partial class IOServerForm : BasicDialogForm
    {
        public IO_SERVER Server = null;
        public IOServerForm()
        {
            InitializeComponent();
            this.Load += (s, e) =>
              {
                  this.txtIP.Text = Server.SERVER_IP;
                  this.txtName.Text = Server.SERVER_NAME;
                  this.txtRemark.Text = Server.SERVER_REMARK;
                  this.txtServerID.Text = Server.SERVER_ID;

              };
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请输入站点名称");
                return;
            }

            if (MessageBox.Show(this,"是否要保存站点信息","编辑提醒",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {


                Server.SERVER_NAME = this.txtName.Text;
                Server.SERVER_REMARK = this.txtRemark.Text;
                Server.SERVER_ID = this.txtServerID.Text;
                Server.SERVER_CREATEDATE = DateTime.Today.ToString("yyyy-MM-dd");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
