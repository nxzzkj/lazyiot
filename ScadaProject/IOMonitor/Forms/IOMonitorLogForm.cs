using IOMonitor.Core;
using Scada.Controls;
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

namespace IOMonitor.Forms
{
    public partial class IOMonitorLogForm : DockContent, ICobaltTab
    {
        public IOMonitorLogForm(Mediator m)
        {
            mediator = m;
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.HideOnClose = true;
            this.CloseButton = false;

        }
        public void AppendLogItem(string log)
        {
            if (IOMonitorManager.IsBackRun)
                return;
            if (uccbLog.Checked)
            {
                if (this.IsHandleCreated&& listViewLog.InvokeRequired)
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



        }

        private Mediator mediator = null;
        private string identifier;
        public TabTypes TabType
        {
            get
            {
                return TabTypes.IOLogbook;
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

        private void IOMonitorLogForm_Load(object sender, EventArgs e)
        {
            ControlHelper.FreezeControl(this, true);
        }
    }
}
