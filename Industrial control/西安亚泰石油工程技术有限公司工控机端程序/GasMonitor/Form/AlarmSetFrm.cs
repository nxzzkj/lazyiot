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
    public partial class AlarmSetFrm : UITitlePage
    {
        public AlarmSetFrm()
        {
            InitializeComponent();
        }
        public void InitForms()
        {
            flowLayoutPanel.Controls.Clear();
            for (int i = 0; i < GasMonitorManager.Chanels.Count; i++)
            {
                AlarmSet alarmSet = new AlarmSet();
                alarmSet.SetChannel(GasMonitorManager.Chanels[i], GasMonitorManager.Config.ChannelAlarms.Find(x=>x.ChanelID== GasMonitorManager.Chanels[i].Id));
                alarmSet.SetStyle(GasMonitorManager.MainForm.Style);
                flowLayoutPanel.Controls.Add(alarmSet);
            }
        }
    }
}
