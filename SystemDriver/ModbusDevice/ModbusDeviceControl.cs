using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeviceDriveBase;
using ZZSCADA.Model;

namespace ModbusDevice
{
    public partial class ModbusDeviceControl : IODeviceControl
    {
        public ModbusDeviceControl()
        {
            InitializeComponent();
            cbo_modbusType.SelectedIndex = 0;
            cbStored.SelectedIndex = 0;

        }

        private void ModbusDeviceControl_Load(object sender, EventArgs e)
        {
        
        }
        public override bool IsValidParameter()
        {
            if (cbo_modbusType.SelectedItem == null)
            {
                MessageBox.Show("请选择Modbus类型!");
                return false;
            }
            if (cbStored.SelectedItem == null)
            {
                MessageBox.Show("请选择存储方式!");
                return false;
            }
            return true;
        }
        public override string GetUIParameter()
        {
            if (cbStored.SelectedItem == null)
                cbStored.SelectedIndex = 0;
            if (cbo_modbusType.SelectedItem == null)
                cbo_modbusType.SelectedIndex = 0;
            this.ParaString = "Modbus类型:" + cbo_modbusType.SelectedItem.ToString() + ",字节存储:" + cbStored.SelectedItem.ToString();



            return this.ParaString;
        }
        public override void SetUIParameter(IO_SERVER server, IO_DEVICE device)
        {
            try
            {


                this.ParaString = device.IO_DEVICE_PARASTRING;
                string[] strs = this.ParaString.Split(new char[2] { ':', ',' });
                if (strs.Length == 4)
                {
                    for (int i = 0; i < cbo_modbusType.Items.Count; i++)
                    {
                        if (cbo_modbusType.Items[i].ToString() == strs[1])
                        {
                            cbo_modbusType.SelectedIndex = i;
                            break;
                        }
                    }
                    for (int i = 0; i < cbStored.Items.Count; i++)
                    {
                        if (cbStored.Items[i].ToString() == strs[3])
                        {
                            cbStored.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            catch
            {

            }

        }

    }
}
