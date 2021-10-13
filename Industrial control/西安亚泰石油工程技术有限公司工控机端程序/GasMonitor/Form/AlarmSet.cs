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
    public partial class AlarmSet : UIPanel
    {
        public AlarmSet()
        {
            InitializeComponent();
        }
        public ChannelElement Channel = null;
        public ChannelAlarm ChannelAlarm = null;
        public void SetChannel(ChannelElement c, ChannelAlarm channelAlarm)
        {
            ChannelAlarm = channelAlarm;
               Channel = c;
            Channel.ShowOrHideChanged += Channel_ShowOrHideChanged;
            this.ulbChannelName.Text = string.IsNullOrEmpty(c.Text) ? c.Name : c.Text;
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
            //配置报价参数
            if (channelAlarm!=null)
            {
                ParaAlarm O2Alarm = channelAlarm.ParaAlarms.Find(x => x.Name == "O2");
                ParaAlarm COAlarm = channelAlarm.ParaAlarms.Find(x => x.Name == "CO");
                ParaAlarm CO2Alarm = channelAlarm.ParaAlarms.Find(x => x.Name == "CO2");
                ParaAlarm H2SAlarm = channelAlarm.ParaAlarms.Find(x => x.Name == "H2S");
                this.ucbO2Enable.Checked = O2Alarm != null && O2Alarm.Enable == "1" ? true : false;
                this.ucbCO2Enable.Checked = CO2Alarm != null && CO2Alarm.Enable == "1" ? true : false;
                this.ucbCOEnable.Checked = COAlarm != null && COAlarm.Enable == "1" ? true : false;
                this.ucbH2SEnable.Checked = H2SAlarm != null && H2SAlarm.Enable == "1" ? true : false;
                decimal Low = 0;
                decimal High = 0;
                uudCOLow.Value = decimal.TryParse(COAlarm.Low, out Low) ? Low : 0;
                uudCOHigh.Value = decimal.TryParse(COAlarm.High, out High) ? High : 0;

                uudCO2Low.Value = decimal.TryParse(CO2Alarm.Low, out Low) ? Low : 0;
                uudCO2High.Value = decimal.TryParse(CO2Alarm.High, out High) ? High : 0;

                uudH2SLow.Value = decimal.TryParse(H2SAlarm.Low, out Low) ? Low : 0;
                uudH2SHigh.Value = decimal.TryParse(H2SAlarm.High, out High) ? High : 0;

                uudO2Low.Value = decimal.TryParse(O2Alarm.Low, out Low) ? Low : 0;
                uudO2High.Value = decimal.TryParse(O2Alarm.High, out High) ? High : 0;
            }
        }

        private void Channel_ShowOrHideChanged(bool res)
        {
            this.Visible = res;
        }

        private void uiIntegerUpDown1_Click(object sender, EventArgs e)
        {
            UIIntegerUpDown uIIntegerUpDown =(UIIntegerUpDown) sender;
            NumberBord numberBord = new NumberBord();
            numberBord.InputNumber = uIIntegerUpDown.Value;
            if(numberBord.ShowDialog(this)==DialogResult.OK)
            {
                uIIntegerUpDown.Value = numberBord.InputNumber;
            }
        }

        private void ubtSave_Click(object sender, EventArgs e)
        { 

            ParaAlarm O2Alarm = ChannelAlarm.ParaAlarms.Find(x => x.Name == "O2");
            ParaAlarm COAlarm = ChannelAlarm.ParaAlarms.Find(x => x.Name == "CO");
            ParaAlarm CO2Alarm = ChannelAlarm.ParaAlarms.Find(x => x.Name == "CO2");
            ParaAlarm H2SAlarm = ChannelAlarm.ParaAlarms.Find(x => x.Name == "H2S");

            O2Alarm.Enable = Convert.ToInt32(this.ucbO2Enable.Checked).ToString();
            COAlarm.Enable = Convert.ToInt32(this.ucbO2Enable.Checked).ToString();
            CO2Alarm.Enable = Convert.ToInt32(this.ucbO2Enable.Checked).ToString();
            H2SAlarm.Enable = Convert.ToInt32(this.ucbO2Enable.Checked).ToString();

            H2SAlarm.Low = uudH2SLow.Value.ToString();
            H2SAlarm.High = uudH2SHigh.Value.ToString();

            O2Alarm.Low = uudO2Low.Value.ToString();
            O2Alarm.High = uudO2High.Value.ToString();

            COAlarm.Low = uudCOLow.Value.ToString();
            COAlarm.High = uudCOHigh.Value.ToString();

            CO2Alarm.Low = uudCO2Low.Value.ToString();
            CO2Alarm.High = uudCO2High.Value.ToString();


            if (GasMonitorManager.Config.WriterConfig())
            {
                GasMonitorManager.alarmSetFrm.ShowSuccessTip(GasMonitorManager.alarmSetFrm, "保存成功");
            }
            else
            {
                GasMonitorManager.alarmSetFrm.ShowSuccessTip(GasMonitorManager.alarmSetFrm, "保存失败");
            }

        }

        private void uudCOLow_MouseClick(object sender, MouseEventArgs e)
        {
            UIIntegerUpDown uIIntegerUpDown = (UIIntegerUpDown)sender;
            NumberBord numberBord = new NumberBord();
            numberBord.InputNumber = uIIntegerUpDown.Value;
            if (numberBord.ShowDialog(this) == DialogResult.OK)
            {
                uIIntegerUpDown.Value = numberBord.InputNumber;
            }
        }

        private void uudCOLow_MouseDown(object sender, MouseEventArgs e)
        {
            UIDoubleUpDown uIIntegerUpDown = (UIDoubleUpDown)sender;
            NumberBord numberBord = new NumberBord();
            numberBord.InputNumber = Convert.ToDecimal(uIIntegerUpDown.Value);
            if (numberBord.ShowDialog(this) == DialogResult.OK)
            {
                uIIntegerUpDown.Value = Convert.ToDouble(numberBord.InputNumber);
            }
        }
    }
}
