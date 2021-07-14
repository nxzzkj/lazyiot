 
using Scada.Model;
using IOManager.Controls;
using IOManager.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;
using Scada.Kernel;

namespace IOManager.Dialogs
{
    public partial class IODeviceForm : BasicDialogForm
    {
        public IO_DEVICE Device = null;
        public IO_COMMUNICATION Communication = null;
        public IO_SERVER Server = null;
        public IODeviceForm()
        {
            InitializeComponent();
        }
        public    void InitForm()
        {
               FormManager.IODeviceDriveCombox(cb_Driver, Communication.IO_COMM_DRIVER_ID);
            if (Device == null)
            {
                Device = new IO_DEVICE();
                Device.IO_DEVICE_ID = GUIDTo16.GuidToLongID().ToString();
                IOCommunicationNode commNode = FormManager.mediator.IOTreeForm.IoTree.GetCommunicationNode(Server, Communication);
                if (commNode != null)
                {
                    int num = commNode.DeviceNumber;
                    Device.IO_DEVICE_NAME = "Device" + num;
                    Device.IO_DEVICE_LABLE = Device.IO_DEVICE_NAME;
                    Device.IO_DEVICE_OVERTIME = 120;
                    Device.IO_DEVICE_UPDATECYCLE = 120;
                    Device.IO_DEVICE_ADDRESS = num.ToString();
                }

                Device.IO_DEVICE_STATUS = 0;

            }
            Device.IO_COMM_ID = Communication.IO_COMM_ID;
            Device.IO_SERVER_ID = Server.SERVER_ID;

            this.txtID.Text = Device.IO_DEVICE_ID;
            this.txtLabel.Text = Device.IO_DEVICE_LABLE;
            this.txtName.Text = Device.IO_DEVICE_NAME;
            this.txtRemark.Text = Device.IO_DEVICE_REMARK;
            this.txtAddress.Text = Device.IO_DEVICE_ADDRESS;
            this.nd_timeout.Value = Device.IO_DEVICE_OVERTIME;
            this.nd_updatecycle.Value = Device.IO_DEVICE_UPDATECYCLE;
            for (int i = 0; i < this.cb_Driver.Items.Count; i++)
            {
                Scada.Model.SCADA_DEVICE_DRIVER driver = this.cb_Driver.Items[i] as Scada.Model.SCADA_DEVICE_DRIVER;
                if (driver.Id == Device.DEVICE_DRIVER_ID)
                {
                    this.cb_Driver.SelectedIndex = i;
                    break;
                }
            }
            if (this.cb_Driver.SelectedIndex <= 0 && this.cb_Driver.Items.Count > 0)
            {
                this.cb_Driver.SelectedIndex = 0;
            }

        }

        private   void wizardTabControl_ButtonOK(object sender, EventArgs e)
        {
            if (cb_Driver.SelectedItem == null)
            {
                MessageBox.Show("请选择设备驱动");
                return;
            }
            if (this.txtLabel.Text.Trim() == "")
            {
                MessageBox.Show("请输入中文标识");
                return;
            }
            if (this.txtName.Text.Trim() == "")
            {
                MessageBox.Show("请输入设备名称");
                return;
            }
            IOCommunicationNode commNode = FormManager.mediator.IOTreeForm.IoTree.GetCommunicationNode(Server, Communication);

            if(commNode!=null)
            {
                for(int i=0;i< commNode.Nodes.Count;i++)
                {
                    IODeviceNode deviceNode = commNode.Nodes[i] as IODeviceNode;
                    if(deviceNode.Device.IO_DEVICE_ADDRESS.Trim()==Device.IO_DEVICE_ADDRESS.Trim()&& deviceNode.Device!= Device)
                    {
                        MessageBox.Show("设备地址与"+ deviceNode.Device.IO_DEVICE_LABLE+" 的设备地址重复!");
                        return;
                    }
                }
            }
            if (DriverKernel != null)
            {
                ScadaResult res = DriverKernel.DeviceCtrl.IsValidParameter();
                if (res.Result)
                {
                    Scada.Model.SCADA_DEVICE_DRIVER driver = cb_Driver.SelectedItem as Scada.Model.SCADA_DEVICE_DRIVER;
                    Device.DEVICE_DRIVER_ID = driver.Id;
                    Device.IO_DEVICE_LABLE = this.txtLabel.Text.Trim();
                    Device.IO_DEVICE_NAME = this.txtName.Text.Trim();
                    Device.IO_DEVICE_REMARK = this.txtRemark.Text;
                    Device.IO_DEVICE_STATUS = 1;
                    Device.IO_DEVICE_ADDRESS = this.txtAddress.Text.Trim();
                    Device.IO_SERVER_ID = Server.SERVER_ID;
                    Device.IO_COMM_ID = Communication.IO_COMM_ID;
                    Device.IO_DEVICE_UPDATECYCLE = Convert.ToInt32(this.nd_updatecycle.Value);
                    Device.IO_DEVICE_OVERTIME = Convert.ToInt32(this.nd_timeout.Value);
                    Device.IO_DEVICE_PARASTRING = DriverKernel.DeviceCtrl.GetUIParameter();
                      FormManager.InsertIODeviceNode(this.Server, this.Communication,this.Device);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(res.Message);
                }

            }



            this.txtID.Text = Device.IO_DEVICE_ID;
            this.txtLabel.Text = Device.IO_DEVICE_LABLE;
            this.txtName.Text = Device.IO_DEVICE_NAME;
            this.txtRemark.Text = Device.IO_DEVICE_REMARK;
            this.nd_timeout.Value = Device.IO_DEVICE_OVERTIME;
            this.nd_updatecycle.Value = Device.IO_DEVICE_UPDATECYCLE;
        }

        private void wizardTabControl_ButtonCancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        public ScadaDeviceKernel DriverKernel = null;
        private   void IODeviceForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.wizardTabControl.InitWizard();
            }
            catch
            {

            }
            
          
        }

        private void cb_Driver_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Driver.SelectedItem != null)
            {
                try
                {


                    Scada.Model.SCADA_DEVICE_DRIVER driver = cb_Driver.SelectedItem as Scada.Model.SCADA_DEVICE_DRIVER;
                    DriverKernel = FormManager.CreateDeviceDrive(driver);
                    DriverKernel.IsCreateControl = true;
                    try
                    {
                        DriverKernel.InitKernel(Server, Communication, Device, null, driver);
                    }
                    catch (Exception emx)
                    {
                        FormManager.DisplayException(new Exception("设备驱动初始化InitDriver失败" + emx.Message));

                    }
                    try
                    {
                        if (DriverKernel.DeviceCtrl!=null)
                            DriverKernel.DeviceCtrl.SetUIParameter(Server, Device);
                    }
                    catch (Exception emx)
                    {
                        FormManager.DisplayException(new Exception("解析设备驱动参数失败(SetUIParameter)" + emx.Message));

                    }


                    this.tabPage2.Controls.Clear();
                    if(DriverKernel.DeviceCtrl!=null)
                    this.tabPage2.Controls.Add(DriverKernel.DeviceCtrl);
                }
                catch(Exception emx)
                {
                    FormManager.DisplayException(new Exception("加载设备驱动失败"+emx.Message));
                }
            }
        }
    }
}
