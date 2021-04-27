using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scada.Controls.Controls.Page
{
   
    public partial class SCADAPager : UserControl
    {
        public event PageChanged OnPageIndexed;
        public SCADAPager()
        {
            InitializeComponent();
        }
        private int mPageIndex = 1;
        private int mPageSize = 1000;
        private int mPageCount = 0;
        private int mRecordCount = 0;
        public int PageIndex
        {
            get { return mPageIndex; }
            set { mPageIndex = value; }
        }

        public int PageSize
        {
            get { return mPageSize; }
            set { mPageSize = value; }
        }
        public int PageCount
        {
            get { return mPageCount; }
            set { mPageCount = value; }
        }
        public int RecordCount
        {
            get { return mRecordCount; }
            set { mRecordCount = value; }
        }

        private void ucBtnFirst_BtnClick(object sender, EventArgs e)
        {
            if (mPageCount != 0)
            {
                mPageIndex = 1;
                if (OnPageIndexed != null)
                {
                    OnPageIndexed(mPageIndex);
                }
            }

        }

        private void ucBtnEnd_BtnClick(object sender, EventArgs e)
        {
            if (mPageCount != 0)
            {
                mPageIndex = mPageCount;
                if (OnPageIndexed != null)
                {
                    this.labelPageInfo.Text = "共计" + this.RecordCount + "条,当前" + PageIndex + "/" + PageCount + "页,每页" + this.PageSize;
                    OnPageIndexed(mPageIndex);
                }
            }

        }

        private void ucBtnNext_BtnClick(object sender, EventArgs e)
        {
            if (mPageCount != 0)
            {
                mPageIndex++;
                if (mPageIndex >= mPageCount)
                {
                    mPageIndex = mPageCount;
                }
                if (OnPageIndexed != null)
                {
                    this.labelPageInfo.Text = "共计"+this.RecordCount+"条,当前"+PageIndex+"/"+PageCount+"页,每页"+this.PageSize;
                    OnPageIndexed(mPageIndex);
                }
            }
        }

        private void ucBtnPreview_BtnClick(object sender, EventArgs e)
        {
            if (mPageCount != 0)
            {
                mPageIndex--;
                if (mPageIndex <= 0)
                {
                    mPageIndex = 0;
                }
                if (OnPageIndexed != null)
                {
                    this.labelPageInfo.Text = "共计" + this.RecordCount + "条,当前" + PageIndex + "/" + PageCount + "页,每页" + this.PageSize;
                    OnPageIndexed(mPageIndex);
                }
            }
        }
        public void SetPageItems(List<PageSizeItem> items, int selectIndex)
        {

            comboBoxPage.Items.Clear();
            comboBoxPage.Items.AddRange(items.ToArray());
            comboBoxPage.SelectedIndex = selectIndex;
        }

        private void comboBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPage.SelectedItem != null)
            {

                PageSize = (comboBoxPage.SelectedItem as PageSizeItem).PageSize;
                if (mPageCount != 0)
                {
                    mPageIndex = 1;
                    if (mPageIndex <= 0)
                    {
                        mPageIndex = 0;
                    }
                    if (OnPageIndexed != null)
                    {
                        this.labelPageInfo.Text = "共计" + this.RecordCount + "条,当前" + PageIndex + "/" + PageCount + "页,每页" + this.PageSize;
                        OnPageIndexed(mPageIndex);
                    }
                }
            }
        }
    }

}
