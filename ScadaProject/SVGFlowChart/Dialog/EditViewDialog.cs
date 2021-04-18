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
    public partial class EditViewDialog : FrmWithOKCancel1
    {
        WorkForm mWork = null;
        public EditViewDialog(WorkForm work)
        {
            InitializeComponent();
            mWork = work;
            this.nubWidth.Value = Convert.ToDecimal(mWork.GraphControl.Abstract.MapWidth);
            this.nubHeight.Value = Convert.ToDecimal(mWork.GraphControl.Abstract.MapHeight);
            this.tbViewName.Text = mWork.GraphControl.Abstract.ViewTitle;
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
            if(PageWidth<=300)
            {
                FrmDialog.ShowDialog(this, "页面宽度不能小于300!");
                return;
            }
            if (PageHeight <= 300)
            {
                FrmDialog.ShowDialog(this, "页面高度不能小于300!");
                return;
            }
            mWork.GraphControl.Abstract.MapHeight = PageHeight;
            mWork.GraphControl.Abstract.MapWidth = PageWidth;
            mWork.GraphControl.Abstract.ViewTitle = ViewName;
            mWork.Text = ViewName;
            this.DialogResult = DialogResult.OK;
        }

    }
}
