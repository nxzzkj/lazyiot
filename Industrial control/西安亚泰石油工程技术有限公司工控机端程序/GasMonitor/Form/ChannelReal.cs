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
    public partial class ChannelReal : UIPanel
    {
        public ChannelReal()
        {
            InitializeComponent();
        }
        public ChannelElement Channel = null;
        public void SetChannel(ChannelElement c)
        {
            Channel = c;
            this.ulbChannelName.Text = string.IsNullOrEmpty(c.Text) ? c.Name : c.Text;
            Channel.ShowOrHideChanged += Channel_ShowOrHideChanged;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].GetType() == typeof(Sunny.UI.UILabel))
                {
                    UILabel label = (UILabel)this.Controls[i];
                    label.SetStyle(GasMonitorManager.MainForm.Style);
                    label.ForeColor = Color.White;
                }
                else if (this.Controls[i].GetType() == typeof(Sunny.UI.UILine))
                {
                    UILine line = (UILine)this.Controls[i];
                    line.SetStyle(GasMonitorManager.MainForm.Style);
                    line.ForeColor = Color.Red;
                }
                else if (this.Controls[i].GetType() == typeof(Sunny.UI.UISymbolLabel))
                {
                    UISymbolLabel line = (UISymbolLabel)this.Controls[i];
                    line.SetStyle(GasMonitorManager.MainForm.Style);
                    line.ForeColor = Color.White;
                    line.SymbolColor = Color.Green;
                }
            }
            //设置曲线
           
        }
        /// <summary>
        /// 传入读取的数据,data, 报警 alarm,报警状态 ,alarmstatus
        /// </summary>
        /// <param name="data"></param>
        /// <param name="alarm"></param>
        /// <param name="alarmStatu"></param>
        public void SetReadData(ReceiveItem data, ReceiveItem alarm, ReceiveItem alarmtatus)
        {
            ChannelAlarm channelAlarm = GasMonitorManager.Config.ChannelAlarms.Find(x => int.Parse(x.ChanelID) == int.Parse(this.Channel.Id));
            uledTime.Text = ScadaHexByteOperator.GetDateTime(data.DateTime).Value.ToString("HH:mm:ss");
            ///设置值
            switch (data.Name)
            {
                case "CO":
                    uledCO.Text = data.Value.ToString();
                    uslabCO.Text = data.Name + "/" + data.Unit;

                    //系统报警优先
                    if (alarmtatus.Value.ToString() == "0")//无报警
                    {
                        uledbubCO.Color = Color.Green;
                        uiLedAlarmCO.Text = "";



                    }
                    else if (alarmtatus.Value.ToString() == "1")//低报警
                    {
                        uledbubCO.Color = Color.Yellow;
                        uiLedAlarmCO.Text = alarm.Value.ToString();

                    }
                    else if (alarmtatus.Value.ToString() == "2")//高报警
                    {
                        uledbubCO.Color = Color.Red;
                        uiLedAlarmCO.Text = alarm.Value.ToString();
                    }
                    //设置曲线
                    if (channelAlarm != null)
                    {
                        ParaAlarm paraAlarm = channelAlarm.ParaAlarms.Find(x => x.Name.Trim().ToUpper() == "CO" && x.Enable == "1");
                        //表示系统报警开启
                        if (paraAlarm != null)
                        {
                            float high = Convert.ToSingle(paraAlarm.High);
                            float low = Convert.ToSingle(paraAlarm.Low);
                            float v = Convert.ToSingle(data.Value);
                            if (v <= low)
                            {
                                uledbubCO.Color = Color.Yellow;
                                uiLedAlarmCO.Text = alarm.Value.ToString();
                            }
                            else if (v >= high)
                            {
                                uledbubCO.Color = Color.Red;
                                uiLedAlarmCO.Text = alarm.Value.ToString();
                            }
                        }

                    }
                    break;
                case "EX":
                    uledEX.Text = data.Value.ToString();
                    uslabEX.Text = data.Name + "/" + data.Unit;
                    if (alarmtatus.Value.ToString() == "0")//无报警
                    {
                        uledbubEX.Color = Color.Green;
                        uiLedAlarmEX.Text = "";

                    }
                    else if (alarmtatus.Value.ToString() == "1")//低报警
                    {
                        uledbubEX.Color = Color.Yellow;
                        uiLedAlarmEX.Text = alarm.Value.ToString();
                    }
                    else if (alarmtatus.Value.ToString() == "2")//高报警
                    {
                        uledbubEX.Color = Color.Red;
                        uiLedAlarmEX.Text = alarm.Value.ToString();
                    }
                    if (channelAlarm != null)
                    {
                        ParaAlarm paraAlarm = channelAlarm.ParaAlarms.Find(x => x.Name.Trim().ToUpper() == "EX" && x.Enable == "1");
                        if (paraAlarm != null)
                        {
                            //表示系统报警开启
                            float high = Convert.ToSingle(paraAlarm.High);
                            float low = Convert.ToSingle(paraAlarm.Low);
                            float v = Convert.ToSingle(data.Value);
                            if (v <= low)
                            {
                                uledbubEX.Color = Color.Yellow;
                                uiLedAlarmEX.Text = alarm.Value.ToString();
                            }
                            else if (v >= high)
                            {
                                uledbubEX.Color = Color.Red;
                                uiLedAlarmEX.Text = alarm.Value.ToString();
                            }
                        }

                    }

                    break;
                case "H2S":
                    uledH2S.Text = data.Value.ToString();
                    uslabH2S.Text = data.Name + "/" + data.Unit;
                    if (alarmtatus.Value.ToString() == "0")//无报警
                    {
                        uledbubH2S.Color = Color.Green;
                        uiLedAlarmH2S.Text = "";

                    }
                    else if (alarmtatus.Value.ToString() == "1")//低报警
                    {
                        uledbubH2S.Color = Color.Yellow;
                        uiLedAlarmH2S.Text = alarm.Value.ToString();
                    }
                    else if (alarmtatus.Value.ToString() == "2")//高报警
                    {
                        uledbubH2S.Color = Color.Red;
                        uiLedAlarmH2S.Text = alarm.Value.ToString();
                    }
                    if (channelAlarm != null)
                    {
                        ParaAlarm paraAlarm = channelAlarm.ParaAlarms.Find(x => x.Name.Trim().ToUpper() == "H2S" && x.Enable == "1");
                        //表示系统报警开启
                        if (paraAlarm != null)
                        {
                            float high = Convert.ToSingle(paraAlarm.High);
                            float low = Convert.ToSingle(paraAlarm.Low);
                            float v = Convert.ToSingle(data.Value);
                            if (v <= low)
                            {
                                uledbubH2S.Color = Color.Yellow;
                                uiLedAlarmH2S.Text = alarm.Value.ToString();
                            }
                            else if (v >= high)
                            {
                                uledbubH2S.Color = Color.Red;
                                uiLedAlarmH2S.Text = alarm.Value.ToString();
                            }
                        }

                    }
                    break;
                case "O2":
                    uledO2.Text = data.Value.ToString();
                    uslabO2.Text = data.Name + "/" + data.Unit;
                    if (alarmtatus.Value.ToString() == "0")//无报警
                    {
                        uledbubO2.Color = Color.Green;
                        uiLedAlarmO2.Text = "";

                    }
                    else if (alarmtatus.Value.ToString() == "1")//低报警
                    {
                        uledbubO2.Color = Color.Yellow;
                        uiLedAlarmO2.Text = alarm.Value.ToString();
                    }
                    else if (alarmtatus.Value.ToString() == "2")//高报警
                    {
                        uledbubO2.Color = Color.Red;
                        uiLedAlarmO2.Text = alarm.Value.ToString();
                    }
                  
                    if (channelAlarm != null)
                    {
                        ParaAlarm paraAlarm = channelAlarm.ParaAlarms.Find(x => x.Name.Trim().ToUpper() == "H2S" && x.Enable == "1");
                        //表示系统报警开启
                        if (paraAlarm != null)
                        {
                            float high = Convert.ToSingle(paraAlarm.High);
                            float low = Convert.ToSingle(paraAlarm.Low);
                            float v = Convert.ToSingle(data.Value);
                            if (v <= low)
                            {
                                uledbubO2.Color = Color.Yellow;
                                uiLedAlarmO2.Text = alarm.Value.ToString();
                            }
                            else if (v >= high)
                            {
                                uledbubO2.Color = Color.Red;
                                uiLedAlarmO2.Text = alarm.Value.ToString();
                            }

                        }

                    }
                    break;
            }
            if (!string.IsNullOrEmpty(data.Value)&&data.Value != "-9999")
            {
                uiLedDeviceStatus.Color = Color.Green;
            }

            int index = this.chart1.Series["Series" + data.Name].Points.AddXY(ScadaHexByteOperator.GetDateTime(data.DateTime).Value.ToString("mm:ss"), data.Value);
            if (data.Value == "-9999")
            {
                this.chart1.Series["Series" + data.Name].Points[index].IsEmpty = true;
            }
            if (this.chart1.Series["Series" + data.Name].Points.Count > 200)
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
        public void SetChannelStatus()
        {

            uiLedDeviceStatus.Color = Color.Red;
        }
        private void Channel_ShowOrHideChanged(bool res)
        {
            this.Visible = res;
        }
    }
}
