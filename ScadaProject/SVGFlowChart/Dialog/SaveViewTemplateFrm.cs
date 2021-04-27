using Scada.Controls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScadaFlowDesign.Dialog
{
    public partial class SaveViewTemplateFrm : FrmWithOKCancel1
    {
        public SaveViewTemplateFrm()
        {
            InitializeComponent();
        }

    
        public string TemplateName
        {
            get { return tbName.Text.Trim(); }
            set { tbName.Text = value; }
        }
        public string TemplateClassic
        {
            get { return cbClassic.Text.Trim(); }
            set { cbClassic.Text = value; }
        }
 
        public override void btnOK_BtnClick(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入名称");
                return;
            }
            if (cbClassic.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入或者选择换一个分类");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
        public override void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SaveViewTemplateFrm_Load(object sender, EventArgs e)
        {
            this.cbClassic.Items.Clear();
            string[] folds = System.IO.Directory.GetDirectories(Application.StartupPath + "/ScadaTemplate/TemplateViews/");


            for (int i = 0; i < folds.Length; i++)
            {

                this.cbClassic.Items.Add(Path.GetFileName(folds[i]));
            }
        }
    }
}
