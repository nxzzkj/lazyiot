﻿using Scada.Controls.Forms;
using ScadaFlowDesign.Core;
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
    public partial class ProjectUpdatePasswordDialog : FrmWithOKCancel1
    {
        private FlowProject Project = null;
        public ProjectUpdatePasswordDialog(FlowProject project)
        {
            InitializeComponent();
            Project = project;
            tbProjectName.Text = Project.Title;

        }
        public string ProjectTitle
        {
            get { return tbProjectName.Text.Trim(); }
        }
        public string Password
        {
            get { return this.tbPassword.Text.Trim(); }
        }
       


        public override void btnOK_BtnClick(object sender, EventArgs e)
        {
            
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
 
              this.DialogResult = DialogResult.OK;

        }

       
    }
}
