using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Kernel;
using Scada.Model;

namespace MQTTnet
{
    public partial class IODeviceCtrl : IODeviceKernelControl
    {
        public IODeviceCtrl()
        {
            InitializeComponent();
        }
        public override void SetUIParameter(IO_SERVER server, IO_DEVICE device)
        {
            base.SetUIParameter(server,device);
            ParaPack paraPack = new ParaPack(device.IO_DEVICE_PARASTRING);
            if (device.IO_DEVICE_PARASTRING != null && device.IO_DEVICE_PARASTRING != "")
            {
            
                paraPack.SetCtrlValue(tb_devID, device.IO_DEVICE_ADDRESS);
                paraPack.SetCtrlValue(tb_devVersion, paraPack.GetValue("版本号"));
                paraPack.SetCtrlValue(tb_devSoftVision, paraPack.GetValue("软件版本"));
                paraPack.SetCtrlValue(tb_devHardVersion, paraPack.GetValue("硬件版本"));
                paraPack.SetCtrlValue(tb_MqttID, paraPack.GetValue("MQTT连接ID号"));
                paraPack.SetCtrlValue(tb_subTopic, paraPack.GetValue("订阅主题"));
                paraPack.SetCtrlValue(tb_cmdSubTopic, paraPack.GetValue("命令主题"));
                paraPack.SetCtrlValue(this.tbTimes, paraPack.GetValue("时间主题"));
            }
            else
            {
                paraPack.SetCtrlValue(tb_devID, device.IO_DEVICE_ADDRESS);
            }


            this.ParaString = device.IO_DEVICE_PARASTRING;
        }
        public override string GetUIParameter()
        {
            return GetParament();
        }
        private string GetParament()
        {

            ParaPack para = new ParaPack();
            para.AddItem("设备识别号",this.Device.IO_DEVICE_ADDRESS);
            para.AddItem("版本号", this.tb_devVersion.Text);
            para.AddItem("软件版本", this.tb_devSoftVision.Text);
            para.AddItem("硬件版本", this.tb_devHardVersion.Text);
            para.AddItem("MQTT连接ID号", this.tb_MqttID.Text);
            para.AddItem("订阅主题", this.tb_subTopic.Text);
            para.AddItem("命令主题", this.tb_cmdSubTopic.Text);
            para.AddItem("时间主题", this.tbTimes.Text);
            return para.ToString();


        }
        public override ScadaResult IsValidParameter()
        {
      
            if (tb_devID.Text.Trim() == null)
                return new ScadaResult(false, "请输入MQTT连接ID号");
            if (tb_subTopic.Text.Trim() == null)
                return new ScadaResult(false, "请输入您的订阅主题");
            if (tb_cmdSubTopic.Text.Trim() == null)
                return new ScadaResult(false, "请输入您的命令主题");
            return new ScadaResult();
        }
    }
}
