using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasMonitor
{
    public partial class SystenSetFrm : UITitlePage
    {
        public SystenSetFrm()
        {
            InitializeComponent();
            
         
        }

        private void SystenSetFrm_Load(object sender, EventArgs e)
        {
            
        }
        public void InitForms()
        {
            string[] ports = SystemUtily.GetSeriePort();
            this.ucbSeriePort.Items.Clear();
            ucbSeriePort.Items.AddRange(ports);
            ccbCheckBits.SelectedIndex = 0;
            ucbBaudRate.SelectedIndex = 0;
            ucbStopBits.SelectedIndex = 0;
            ucbDataBits.SelectedIndex = 0;
            this.ucbModbusType.SelectedIndex = 0;
            ucbDeviceAddress.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(GasMonitorManager.Config.SerialPort.Port))
            {
                for (int i = 0; i < this.ucbSeriePort.Items.Count; i++)
                {
                    if (this.ucbSeriePort.Items[i].ToString() == GasMonitorManager.Config.SerialPort.Port.Trim())
                    {
                        ucbSeriePort.SelectedIndex = i;
                    }
                }

            }
            //////////////////////////
            if (!string.IsNullOrEmpty(GasMonitorManager.Config.SerialPort.BaudRate))
            {
                for (int i = 0; i < this.ucbBaudRate.Items.Count; i++)
                {
                    if (this.ucbBaudRate.Items[i].ToString() == GasMonitorManager.Config.SerialPort.BaudRate.Trim())
                    {
                        ucbBaudRate.SelectedIndex = i;
                        break;
                    }
                }

            }
            if (!string.IsNullOrEmpty(GasMonitorManager.Config.SerialPort.CheckBit))
            {
                for (int i = 0; i < this.ccbCheckBits.Items.Count; i++)
                {
                    if (this.ccbCheckBits.Items[i].ToString() == GasMonitorManager.Config.SerialPort.CheckBit.Trim())
                    {
                        ccbCheckBits.SelectedIndex = i;
                        break;
                    }
                }

            }
            if (!string.IsNullOrEmpty(GasMonitorManager.Config.SerialPort.StopBit))
            {
                for (int i = 0; i < this.ucbStopBits.Items.Count; i++)
                {
                    if (this.ucbStopBits.Items[i].ToString() == GasMonitorManager.Config.SerialPort.StopBit.Trim())
                    {
                        ucbStopBits.SelectedIndex = i;
                        break;
                    }
                }

            }

            if (!string.IsNullOrEmpty(GasMonitorManager.Config.SerialPort.DataBits))
            {
                for (int i = 0; i < this.ucbDataBits.Items.Count; i++)
                {
                    if (this.ucbDataBits.Items[i].ToString() == GasMonitorManager.Config.SerialPort.DataBits.Trim())
                    {
                        ucbDataBits.SelectedIndex = i;
                        break;
                    }
                }

            }
            if (!string.IsNullOrEmpty(GasMonitorManager.Config.SerialPort.ModbusType))
            {
                for (int i = 0; i < this.ucbModbusType.Items.Count; i++)
                {
                    if (this.ucbModbusType.Items[i].ToString() == GasMonitorManager.Config.SerialPort.ModbusType.Trim())
                    {
                        ucbModbusType.SelectedIndex = i;
                        break;
                    }
                }

            }
            uddWriteTimeout.Value = string.IsNullOrEmpty(GasMonitorManager.Config.SerialPort.WriteTimeout) ? 1000 : int.Parse(GasMonitorManager.Config.SerialPort.WriteTimeout);
            uddReadTimeOut.Value = string.IsNullOrEmpty(GasMonitorManager.Config.SerialPort.ReadTimeout) ? 1000 : int.Parse(GasMonitorManager.Config.SerialPort.ReadTimeout);
            uddPackSize.Value = string.IsNullOrEmpty(GasMonitorManager.Config.SerialPort.PackMaxSize) ? 64 : int.Parse(GasMonitorManager.Config.SerialPort.PackMaxSize);
            uddCollectFaultsNumber.Value = string.IsNullOrEmpty(GasMonitorManager.Config.SerialPort.CollectFaultsNumber) ? 3 : int.Parse(GasMonitorManager.Config.SerialPort.CollectFaultsNumber);
            uddCollectFaultsInternal.Value = string.IsNullOrEmpty(GasMonitorManager.Config.SerialPort.CollectFaultsInternal) ? 3 : int.Parse(GasMonitorManager.Config.SerialPort.CollectFaultsInternal);
            uddOffsetInterval.Value = string.IsNullOrEmpty(GasMonitorManager.Config.SerialPort.OffsetInterval) ? 10 : int.Parse(GasMonitorManager.Config.SerialPort.OffsetInterval);
            ucbContinueCollect.Checked = string.IsNullOrEmpty(GasMonitorManager.Config.SerialPort.ContinueCollect)|| GasMonitorManager.Config.SerialPort.ContinueCollect=="0" ? false : true;
            ucbRTSEnable.Checked = string.IsNullOrEmpty(GasMonitorManager.Config.SerialPort.RTSEnable)|| GasMonitorManager.Config.SerialPort.RTSEnable=="0" ? false : true;


            ucbChannel.Items.Clear();
            foreach (ChannelElement channel in GasMonitorManager.Config.Channels)
            {
                ucbChannel.Items.Add(channel);

            }
         

            utbClientID.Text = GasMonitorManager.Config.MQTT.ClientID.Trim();
            utbAccount.Text = GasMonitorManager.Config.MQTT.Account.Trim();
            utbCommandSubTopic.Text = GasMonitorManager.Config.MQTT.CommandSubTopic.Trim();
            utbDataPublicTopic.Text = GasMonitorManager.Config.MQTT.DataPublicTopic.Trim();
            utbPassiveSubTopic.Text = GasMonitorManager.Config.MQTT.PassiveSubTopic.Trim();
            utbPassword.Text = GasMonitorManager.Config.MQTT.Password.Trim();
            utbPort.IntValue = string.IsNullOrEmpty(GasMonitorManager.Config.MQTT.Port) ? 1833 : int.Parse(GasMonitorManager.Config.MQTT.Port.Trim());
            if (GasMonitorManager.Config.MQTT.PublicType.Trim() == "主动")
            {
                uiRadioButton1.Checked = true;
                uiRadioButton2.Checked = false;
            }
            else
            {
                uiRadioButton1.Checked = false;
                uiRadioButton2.Checked = true;

            }
        
            utbServerIP.Text = GasMonitorManager.Config.MQTT.ServerIP.Trim();
            uddUpdateCycle.Value =string.IsNullOrEmpty(GasMonitorManager.Config.MQTT.UpdateCycle)? 5:int.Parse(GasMonitorManager.Config.MQTT.UpdateCycle);
            utbUpdateCycleSubTopic.Text = GasMonitorManager.Config.MQTT.UpdateCycleSubTopic.Trim();
        }

        private void uiTextBox2_Click(object sender, EventArgs e)
        {
            UITextBox uIIntegerUpDown = (UITextBox)sender;
            KeyBord keyBord = new KeyBord();
            keyBord.InputText = uIIntegerUpDown.Text;
            if (keyBord.ShowDialog(this) == DialogResult.OK)
            {
                uIIntegerUpDown.Text = keyBord.InputText;
            }
        }

        private void ubtNewGuid_Click(object sender, EventArgs e)
        {
            utbClientID.Text = SystemUtily.GuidToLongID().ToString();
        }

        private void ucbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ucbChannel.SelectedItem!=null)
            {
                ChannelElement channel = (ChannelElement)ucbChannel.SelectedItem;
                utbChannelName.Text = channel.Text;
                if(string.IsNullOrEmpty(channel.BindingArress.Trim()))
                {
                    ucbDeviceAddress.SelectedIndex = 0;
                }
                else
                {
                    for (int i = 0; i < ucbDeviceAddress.Items.Count; i++)
                    {
                        if (ucbDeviceAddress.Items[i].ToString() == channel.BindingArress.Trim())
                        {
                            ucbDeviceAddress.SelectedIndex = i;
                            break;

                        }
                    }


                }

            }
           
        }

        private void utbChannelName_TextChanged(object sender, EventArgs e)
        {
            if (ucbChannel.SelectedItem != null)
            {
                ChannelElement channel = (ChannelElement)ucbChannel.SelectedItem;
                channel.Text = utbChannelName.Text;
              

            }
        }

        private void ubtSave_Click(object sender, EventArgs e)
        {
            if(ucbSeriePort.SelectedItem==null)
            {
                this.ShowErrorTip(this, "请选择串口", 1000);
                return;
            }
            if(string.IsNullOrEmpty(utbClientID.Text.Trim()))
            {
                this.ShowErrorTip(this, "请分配客户端ID号", 1000);
                return;
            }
            if (string.IsNullOrEmpty(utbServerIP.Text.Trim()))
            {
                this.ShowErrorTip(this, "请输入MQTT服务器IP", 1000);
                return;
            }
            if (string.IsNullOrEmpty(utbPort.Text.Trim()))
            {
                this.ShowErrorTip(this, "请输入MQTT服务器端口号", 1000);
                return;
            }
            int port = 0;
            if (!int.TryParse(utbPort.Text.ToString(),out port))
            {
                this.ShowErrorTip(this, "请输入正确的端口号", 1000);
                return;
            }
            IPAddress ip = IPAddress.Any;
            if (!IPAddress.TryParse(utbServerIP.Text, out ip))
            {
                this.ShowErrorTip(this, "请输入正确的IP地址", 1000);
                return;
            }
             
            ///串口设置部分
            GasMonitorManager.Config.SerialPort.BaudRate = ucbBaudRate.SelectedItem.ToString();
            GasMonitorManager.Config.SerialPort.CheckBit = ccbCheckBits.SelectedItem.ToString();
            GasMonitorManager.Config.SerialPort.DataBits = ucbDataBits.SelectedItem.ToString();
            GasMonitorManager.Config.SerialPort.StopBit = ucbStopBits.SelectedItem.ToString();
            GasMonitorManager.Config.SerialPort.Port = ucbSeriePort.SelectedItem.ToString();
            GasMonitorManager.Config.SerialPort.WriteTimeout = uddWriteTimeout.Value.ToString();
            GasMonitorManager.Config.SerialPort.ReadTimeout = uddReadTimeOut.Value.ToString();
            GasMonitorManager.Config.SerialPort.PackMaxSize = uddPackSize.Value.ToString();
            GasMonitorManager.Config.SerialPort.CollectFaultsNumber = uddCollectFaultsNumber.Value.ToString();
            GasMonitorManager.Config.SerialPort.CollectFaultsInternal = uddCollectFaultsInternal.Value.ToString();
            GasMonitorManager.Config.SerialPort.OffsetInterval = uddOffsetInterval.Value.ToString();

            GasMonitorManager.Config.SerialPort.RTSEnable = Convert.ToInt32(ucbRTSEnable.Checked).ToString();
            GasMonitorManager.Config.SerialPort.ContinueCollect = Convert.ToInt32(ucbContinueCollect.Checked).ToString();
            
             GasMonitorManager.Config.SerialPort.ModbusType = this.ucbModbusType.SelectedItem.ToString();
            //MQTT设置部分
            GasMonitorManager.Config.MQTT.Account = utbAccount.Text.Trim();
            GasMonitorManager.Config.MQTT.ClientID = utbClientID.Text.Trim();
            GasMonitorManager.Config.MQTT.Password = utbPassword.Text.Trim();
            GasMonitorManager.Config.MQTT.Port = utbPort.Text.Trim();
            GasMonitorManager.Config.MQTT.ServerIP = utbServerIP.Text.Trim();
            GasMonitorManager.Config.MQTT.UpdateCycle = uddUpdateCycle.Value.ToString();
            GasMonitorManager.Config.MQTT.CommandSubTopic = utbCommandSubTopic.Text.Trim();
            GasMonitorManager.Config.MQTT.DataPublicTopic = utbDataPublicTopic.Text.Trim();
            GasMonitorManager.Config.MQTT.PassiveSubTopic = utbPassiveSubTopic.Text.Trim();
            GasMonitorManager.Config.MQTT.UpdateCycleSubTopic = utbUpdateCycleSubTopic.Text.Trim();
            if(GasMonitorManager.Config.WriterConfig())
            {
               
                this.ShowSuccessTip(this, "保存成功");
                GasMonitorManager.Config = new GasMonitorConfig();
                GasMonitorManager.InitMonitorManager(GasMonitorManager.MainForm);

            }
            else
            {
                this.ShowErrorTip(this, "保存失败");
            }
        }

        private void ucbDeviceAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ucbChannel.SelectedItem != null&& ucbDeviceAddress.SelectedItem!=null)
            {
                ChannelElement channel = (ChannelElement)ucbChannel.SelectedItem;
                channel.BindingArress = ucbDeviceAddress.SelectedItem.ToString()=="空"?"": ucbDeviceAddress.SelectedItem.ToString();


            }
        }

        private void uddWriteTimeout_Click(object sender, EventArgs e)
        {
            UIDoubleUpDown uIIntegerUpDown = (UIDoubleUpDown)sender;
            NumberBord numberBord = new NumberBord();
            numberBord.InputNumber = Convert.ToDecimal(uIIntegerUpDown.Value);
            if (numberBord.ShowDialog(this) == DialogResult.OK)
            {
                uIIntegerUpDown.Value = Convert.ToDouble(numberBord.InputNumber);
            }
        }

        private void uddWriteTimeout_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private async void uiButton1_Click(object sender, EventArgs e)
        {
           await GasMonitorManager.Close();

         
          await  GasMonitorManager.Start();
        }
    }
}
