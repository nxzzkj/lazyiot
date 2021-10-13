using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace GasMonitor
{
    public partial class ChanelSeries : UIPanel
    {
        public ChannelElement Channel = null;
        public void SetChannel(ChannelElement c)
        {
            Channel = c;
            Channel.ShowOrHideChanged += Channel_ShowOrHideChanged;
            chart1.Titles[0].Text = string.IsNullOrEmpty(c.Text)?c.Name:c.Text;
        }
        public void SetReadSeries(ReceiveItem data, ReceiveItem alarm, ReceiveItem alarmtatus)
        {
            try
            {
              
               int index= this.chart1.Series["Series" + data.Name].Points.AddXY(ScadaHexByteOperator.GetDateTime(data.DateTime).Value.ToString("mm:ss"), data.Value);
                if (data.Value=="-9999")
                {
                    this.chart1.Series["Series" + data.Name].Points[index].IsEmpty = true;
                }
                if (this.chart1.Series["Series" + data.Name].Points.Count > 400)
                {
                    this.chart1.Series["Series" + data.Name].Points.RemoveAt(0);
                }
                if (this.chart1.Series["Series" + data.Name].Points.Count > 0)
                {
                    if (this.chart1.Series["Series" + data.Name].YAxisType == System.Windows.Forms.DataVisualization.Charting.AxisType.Primary)
                        this.chart1.ChartAreas[this.chart1.Series["Series" + data.Name].ChartArea].AxisY.Maximum = this.chart1.Series["Series" + data.Name].Points.FindMaxByValue().YValues[0] + this.chart1.Series["Series" + data.Name].Points.FindMaxByValue().YValues[0] / 10.0d;
                    else
                        this.chart1.ChartAreas[this.chart1.Series["Series" + data.Name].ChartArea].AxisY2.Maximum = this.chart1.Series["Series" + data.Name].Points.FindMaxByValue().YValues[0] + this.chart1.Series["Series" + data.Name].Points.FindMaxByValue().YValues[0] / 10.0d;

                }
            }
            catch
            {

            }

        }
        private void Channel_ShowOrHideChanged(bool res)
        {
            this.Visible = res;
        }
        public ChanelSeries()
        {
            InitializeComponent();
        }
    }
}
