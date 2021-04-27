using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IScadaDriver;
using System.IO.Ports;
namespace Modbus
{
    public partial class Modbus_Serial_Ctrl : CommunicationControl
    {
        public Modbus_Serial_Ctrl()
        {
            InitializeComponent();
            
        }

     

        public override bool IsValidParameter()
        {
            return true;
        }
        public override void SetUIParameter(string para)
        {
            //初始化
            comboSeriePort.Items.Clear();
            foreach (string vPortName in SerialPort.GetPortNames())
            {
                comboSeriePort.Items.Add(vPortName);
            }
            if (comboSeriePort.Items.Count > 0)
                comboSeriePort.SelectedIndex = 0;
            cbCheck.SelectedIndex = 0;

            base.SetUIParameter(para);
        }
        public override string GetUIParameter()
        {
            return base.GetUIParameter();
        }

        private void cbRTSEnable_CheckedChanged(object sender, EventArgs e)
        {
            this.nbSendAfterKeeyTime.Enabled = cbRTSEnable.Checked;
            this.nbSendPreKeeyTime.Enabled = cbRTSEnable.Checked;
        }
    }
}
