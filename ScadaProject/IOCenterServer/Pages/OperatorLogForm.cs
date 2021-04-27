using Scada.Controls.Controls;
using ScadaCenterServer.Core;
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

namespace ScadaCenterServer.Pages
{
    public partial class OperatorLogForm : DockForm
    {
        public OperatorLogForm(Mediator m):base(m)
        {

            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.CloseButton = false;
            this.Load += OperatorLogForm_Load;
        }

        private void OperatorLogForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            listViewLog.Items.Clear();
        }
     
        public void AppendLogItem(string log)
        {
            if (IOCenterManager.IsBackRun)
                return;
            if (uccbLog.Checked&& listViewLog.InvokeRequired)
            {
                listViewLog.BeginInvoke(new EventHandler(delegate
                {
                  
                    ListViewItem lvi = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    lvi.SubItems.Add(log);
                    listViewLog.Items.Insert(0, lvi);
                    if (listViewLog.Items.Count > int.Parse(ucLateLogSIze.SelectedValue))
                    {
                        listViewLog.Items.RemoveAt(listViewLog.Items.Count - 1);
                    }


                }));
            }
          
          

        }

        public OperatorLogForm()
        {
            InitializeComponent();
            this.Load += OperatorLogForm_Load;
        }
        public override TabTypes TabType
        {
            get
            {
                return TabTypes.Logbook;
            }
        }
    }
}
