using Scada.Controls.Forms;
using ScadaCenterServer.Controls;
using ScadaCenterServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;
using Scada.Model;

namespace ScadaCenterServer.Dialogs
{
    public partial class SendCommandForm : PopBaseForm
    {

        public SendCommandForm()
        {
            InitializeComponent();
            //用户发送命令后客户都返回时间

        }



        private IO_SERVER Server = null;
        IO_COMMUNICATION Communication = null;
        IO_DEVICE Device = null;
        public IO_COMMANDS Command = null;
        public void InitCommand(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device)
        {

            ucStep.StepIndex = 0;

            Server = server;
            Communication = communication;
            Device = device;
            textBoxServer.Text = server.SERVER_IP + "[" + server.SERVER_NAME + "]";
            textBoxCommunication.Text = communication.IO_COMM_LABEL + "[" + communication.IO_COMM_NAME + "]";
            textBoxDevice.Text = device.IO_DEVICE_LABLE + "[" + device.IO_DEVICE_NAME + "]";
            comboIOPara.Items.Clear();


            for (int i = 0; i < device.IOParas.Count; i++)
            {
                if (device.IOParas[i].IO_POINTTYPE == "模拟量" || device.IOParas[i].IO_POINTTYPE == "开关量")
                {
                    comboIOPara.Items.Add(device.IOParas[i]);

                }

            }

        }
        private void SendCommandForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_BtnClick(object sender, EventArgs e)
        {

            Server = null;
            Communication = null;
            Device = null;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_BtnClick(object sender, EventArgs e)
        {

            Server = null;
            Communication = null;
            Device = null;

            this.DialogResult = DialogResult.Cancel;
        }
        public void SetUCStep(int index)
        {
            this.ucStep.StepIndex = index;
        }
        public void CloseForm()
        {

            Server = null;
            Communication = null;
            Device = null;

            this.DialogResult = DialogResult.Cancel;
        }
        private void ucBtnSend_BtnClick(object sender, EventArgs e)
        {
            if (comboIOPara.SelectedItem == null)
            {
                FrmDialog.ShowDialog(this, "请选择要设置的参数");
                return;

            }
            double dvalue = 0;

            if (tbValue.Text.Trim() == "")
            {
                FrmDialog.ShowDialog(this, "请输入下置的值");
                return;
            }
            if (!double.TryParse(tbValue.Text.Trim(), out dvalue))
            {

                FrmDialog.ShowDialog(this, "请输入下置的数值，不能是文本");
                return;
            }
            if (FrmDialog.ShowDialog(this, "您确定要下置命令吗?", "提醒", true, true, true, true) == DialogResult.OK)
            {
                IO_COMMANDS cmmd = new IO_COMMANDS();
                cmmd.COMMAND_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                cmmd.COMMAND_ID = GUIDTo16.GuidToLongID().ToString();
                cmmd.COMMAND_RESULT = "false";
                cmmd.COMMAND_USER = IOCenterManager.IOProject.ServerConfig.User;
                cmmd.COMMAND_VALUE = tbValue.Text.Trim();
                cmmd.IO_COMM_ID = Communication.IO_COMM_ID;
                cmmd.IO_DEVICE_ID = Device.IO_DEVICE_ID;
                cmmd.IO_SERVER_ID = Server.SERVER_ID;
                cmmd.IO_LABEL = ((IO_PARA)comboIOPara.SelectedItem).IO_LABEL;
                cmmd.IO_NAME = ((IO_PARA)comboIOPara.SelectedItem).IO_NAME;
                cmmd.IO_ID = ((IO_PARA)comboIOPara.SelectedItem).IO_ID;

                Command = cmmd;
                this.ucStep.StepIndex = 0;
                try
                {
                    Scada.AsyncNetTcp.TcpData tcpData = new Scada.AsyncNetTcp.TcpData();
                    byte[] datas = tcpData.StringToTcpByte(cmmd.GetCommandString(), Scada.AsyncNetTcp.ScadaTcpOperator.下置命令);
                    this.ucStep.StepIndex = 1;
                
                }
                catch (Exception ex)
                {
                    FrmDialog.ShowDialog(this, ex.Message);
                }

            }

        }
    }
}
