using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Model;

namespace ScadaCenterServer.Controls
{
    public class IORealListViewItem : ListViewItem
    {
        public IORealListViewItem(IO_PARA para):base(para.IO_ID)
        {
            Para = para;
            this.SubItems.Add(para.IO_NAME);
            this.SubItems.Add(para.IO_LABEL);
            this.SubItems.Add(para.RealValue);
            this.SubItems.Add(para.RealDate);
            this.SubItems.Add(para.RealQualityStamp.ToString());
            this.SubItems.Add(para.IO_UNIT);
        }
        public IO_PARA Para = null;
        public void RefreshParaValue()
        {
          if(Para!=null)
            {
                try
                {


                    this.SubItems[3].Text = Para.RealValue;
                    this.SubItems[4].Text = Para.RealDate;
                    this.SubItems[5].Text = Para.RealQualityStamp.ToString();
                }
                catch
                {

                }
            }
         
        }
    }
}
