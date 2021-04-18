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
    public partial class CreateViewDialog : FrmWithOKCancel1
    {
        public CreateViewDialog()
        {
            InitializeComponent();
            comboBoxShowModel.SelectedIndex = 0;
        }
        public int PageWidth
        {
            get { return Convert.ToInt32(this.nubWidth.Value); }
        }
        public int PageHeight
        {
            get { return Convert.ToInt32(this.nubHeight.Value); }
        }
        public string ViewName
        {
            get { return this.tbViewName.Text.Trim(); }
        }
        public override void btnOK_BtnClick(object sender, EventArgs e)
        {
            if(ViewName.Trim()=="")
            {
                FrmDialog.ShowDialog(this, "请输入视图名称!");
                return;
            }
            if (PageWidth <= 300)
            {
                FrmDialog.ShowDialog(this, "页面宽度不能小于300!");
                return;
            }
            if (PageHeight <= 300)
            {
                FrmDialog.ShowDialog(this, "页面高度不能小于300!");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void comboBoxShowModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxBL.Items.Clear();
            if (comboBoxShowModel.SelectedIndex==0)
            {
                comboBoxBL.Items.Clear();
                comboBoxBL.Items.Add("16:9");
                comboBoxBL.Items.Add("4:3");
                comboBoxBL.Items.Add("3:2");
                
            }
            else
            {
                comboBoxBL.Items.Add("16:9");
                comboBoxBL.Items.Add("18:9");
                comboBoxBL.Items.Add("3:2");
                comboBoxBL.Items.Add("16:10");
                comboBoxBL.Items.Add("15:9");
            }
        }

        private void comboBoxBL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxShowModel.SelectedIndex>=0)
            {
                string str = comboBoxBL.SelectedItem.ToString();
                int w =int.Parse( str.Split(':')[0]);
                int h = int.Parse(str.Split(':')[1]);
                switch (comboBoxShowModel.SelectedIndex)
                {
                    case 0:
                        {
                            this.nubWidth.Value = 2400;
                            this.nubHeight.Value = 2400 * h / (w + h);
                        }
                        break;
                    case 1:
                        this.nubHeight.Value = 1920;
                        this.nubWidth.Value = 1920 * h / (w + h);
                        break;
                }
            }

        }
    }
}
