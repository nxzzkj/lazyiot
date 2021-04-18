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

namespace ScadaFlowDesign.Dialog
{
    public partial class CreateProjectDialog : FrmWithOKCancel1
    {
        public CreateProjectDialog()
        {
            InitializeComponent();
        }
        public string ProjectTitle
        {
            get { return tbProjectName.Text.Trim(); }
        }
        public string Password
        {
            get { return this.tbPassword.Text.Trim(); }
        }
        public string FileFullName
        {
            get { return this.textBoxPath.Text; }
        }


        public override void btnOK_BtnClick(object sender, EventArgs e)
        {
            if(ProjectTitle.Trim()=="")
            {
                FrmDialog.ShowDialog(this, "请输入工程名称!");
                return;
            }
            if (Password.Trim() == "")
            {
                FrmDialog.ShowDialog(this, "请输入工程加密密码!");
                return;
            }
            if (Password.Trim() != this.tbConfirm.Text.Trim())
            {
                FrmDialog.ShowDialog(this, "密码和确认密码不一致!");
                return;
            }
            if (FileFullName=="")
            {
                FrmDialog.ShowDialog(this, "请选择存储位置!");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void ucBtnOpen_BtnClick(object sender, EventArgs e)
        {
            SaveFileDialog dig = new SaveFileDialog();
            dig.Filter = "流程图(*.flow)|*.flow";
            if (dig.ShowDialog()==DialogResult.OK)
            {
                this.textBoxPath.Text = dig.FileName;
            }
        }
    }
}
