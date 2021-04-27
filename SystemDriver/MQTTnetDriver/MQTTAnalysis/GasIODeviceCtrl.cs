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
    public partial class GasIODeviceCtrl : IODeviceKernelControl
    {
        public GasIODeviceCtrl()
        {
            InitializeComponent();
        }
        public override void SetUIParameter(IO_SERVER server, IO_DEVICE device)
        {
            base.SetUIParameter(server, device);
            ParaPack paraPack = new ParaPack(device.IO_DEVICE_PARASTRING);
            if (device.IO_DEVICE_PARASTRING!=null&&device.IO_DEVICE_PARASTRING != "")
            {
                paraPack.SetCtrlValue(tb_devID, paraPack.GetValue("设备ID编码"));
                paraPack.SetCtrlValue(tb_MqttID, paraPack.GetValue("MQTT连接ID号"));
                paraPack.SetCtrlValue(tb_subTopic, paraPack.GetValue("数据订阅主题"));
                paraPack.SetCtrlValue(tb_cmdSubTopic, paraPack.GetValue("下置命令主题"));
                paraPack.SetCtrlValue(this.tbTimes, paraPack.GetValue("循环周期主题"));
                paraPack.SetCtrlValue(this.tbRecieveType, paraPack.GetValue("主动请求主题"));

                
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
            para.AddItem("设备ID编码", this.Device.IO_DEVICE_ADDRESS);
            para.AddItem("MQTT连接ID号", this.tb_MqttID.Text.Trim());
            para.AddItem("数据订阅主题", this.tb_subTopic.Text.Trim());
            para.AddItem("下置命令主题", this.tb_cmdSubTopic.Text.Trim());
            para.AddItem("循环周期主题", this.tbTimes.Text.Trim());
            para.AddItem("主动请求主题", this.tbRecieveType.Text.Trim());
          
            return para.ToString();


        }
        public override ScadaResult IsValidParameter()
        {
      
            if (tb_devID.Text.Trim() == "")
                return new ScadaResult(false, "请输入MQTT连接ID号");
            if (tb_subTopic.Text.Trim() == "")
                return new ScadaResult(false, "请输入您的数据订阅主题");
            if (tb_cmdSubTopic.Text.Trim() == "")
                return new ScadaResult(false, "请输入您的下置命令主题");
          
            return new ScadaResult();
        }

        

       
    }
}
