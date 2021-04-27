using IOManager.Core;
using Scada.Controls;
 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOManager.Page
{
    public partial class IOLogForm : DockContent, ICobaltTab
    {
        public IOLogForm(Mediator m)
        {
            InitializeComponent();
            mediator = m;
        
        }
        //异步调用
        public   void AppendText(string text)
        {
            if (this.IsHandleCreated)
            {
                listBoxEx.BeginInvoke(new EventHandler(delegate
                {

                    listBoxEx.Items.Insert(0, text + " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (listBoxEx.Items.Count > 100)
                    {
                        listBoxEx.Items.RemoveAt(listBoxEx.Items.Count - 1);
                    }

                }));
            }
           
        }
        private Mediator mediator = null;
        private string identifier;
        public TabTypes TabType
        {
            get
            {
                return TabTypes.Logbook;
            }
        }
        public string TabIdentifier
        {
            get
            {
                return identifier;
            }
            set
            {
                identifier = value;
            }
        }
        public List<string> GetLogContent()
        {
            List<string> sb = new List<string>();
            for(int i=0;i< this.listBoxEx.Items.Count;i++)
            {
                sb.Add(this.listBoxEx.Items[i].ToString());
            }
            return sb;
        }

        private  void 导出TXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
             FormManager.ExportLog();
        }
    }
}
