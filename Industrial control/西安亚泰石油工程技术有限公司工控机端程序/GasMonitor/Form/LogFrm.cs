using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasMonitor
{
    public partial class LogFrm : UITitlePage
    {
        public LogFrm()
        {
            InitializeComponent();
        }
        public void AddLog(string msg)
        {
            if (this.IsHandleCreated && uiListBox.InvokeRequired)
            {
                uiListBox.BeginInvoke(new EventHandler(delegate
                {

                    this.uiListBox.Items.Insert(0,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + msg+"\r\n");
                    if(this.uiListBox.Items.Count >= 500)
                    {
                        this.uiListBox.Items.RemoveAt(this.uiListBox.Items.Count-1);


                    }
                }));
            }
        }

       
    }
}
