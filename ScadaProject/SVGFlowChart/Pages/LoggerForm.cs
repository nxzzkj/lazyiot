using Scada.Controls;
using ScadaFlowDesign;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScadaFlowDesign
{
    public partial class LoggerForm : DockContent, ICobaltTab
    {
      
        public LoggerForm(Mediator m )
        {
            InitializeComponent();
            mediator = m;
            this.HideOnClose = true;
        }
        private Mediator mediator = null;
        private string identifier;
        public async void  AppendLogItem(string log)
        {
         await   Task.Run(()=>{
            if (uccbLog.Checked)
            {
                if (this.IsHandleCreated&&  listViewLog.IsHandleCreated)
                {
                    listViewLog.BeginInvoke(new Action(delegate
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
            });


        }
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
    }
}
