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
    /// <summary>
    /// 实时数据显示页面
    /// </summary>
    public partial class RealDataFrm : UITitlePage
    {
        public RealDataFrm()
        {
            InitializeComponent();
        }
        public void InitForms()
        {
            flowLayoutPanel.Controls.Clear();
            for (int i = 0; i < GasMonitorManager.Chanels.Count; i++)
            {
                ChannelReal channelReal = new ChannelReal();
                channelReal.SetChannel(GasMonitorManager.Chanels[i]);
                channelReal.SetStyle(GasMonitorManager.MainForm.Style);
                flowLayoutPanel.Controls.Add(channelReal);
            }
        }
        public void SetReadData(ReceiveItem data, ReceiveItem alarm, ReceiveItem alarmtatus)
        {
            ///设置值
          for(int i=0;i<this.flowLayoutPanel.Controls.Count;i++)
            {
                if(this.flowLayoutPanel.Controls[i].GetType()==typeof(ChannelReal))
                {
                    ChannelReal channelReal = (ChannelReal)this.flowLayoutPanel.Controls[i];

                    if(!string.IsNullOrEmpty(channelReal.Channel.BindingArress)&&channelReal.Channel.BindingArress== data.Address)
                    {
                        channelReal.SetReadData(data, alarm, alarmtatus);
                    }
                    else
                    {
                       
                    }
       
                }
            }

        }
        public void SetChannelStatus()
        {
            ///设置值
            for (int i = 0; i < this.flowLayoutPanel.Controls.Count; i++)
            {
                if (this.flowLayoutPanel.Controls[i].GetType() == typeof(ChannelReal))
                {
                    ChannelReal channelReal = (ChannelReal)this.flowLayoutPanel.Controls[i];
                    channelReal.SetChannelStatus();

                }
            }

        }

    }
}
