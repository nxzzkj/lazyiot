using Scada.Model;
using Scada.Controls.Controls;
using Scada.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Controls;
using IOMonitor.Core;
using Scada.DBUtility;

namespace IOMonitor.Forms
{
    public partial class IOMonitorForm : DockContent, ICobaltTab
    {
        public IOMonitorForm(Mediator m)
        {
            mediator = m;
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.HideOnClose = true;
            this.CloseButton = false;


        }

        private Mediator mediator = null;
        private string identifier;

      
        public IO_DEVICE Device = null;
        public IO_COMMUNICATION Communication = null;
        IO_SERVER Server = null;
        #region 显示用户选择的设备的值

        public void ChangedBinds(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device)
        {
            if (IOMonitorManager.IsBackRun)
                return;
            if (this.IsHandleCreated)
            {
                listView.BeginInvoke(new EventHandler(delegate
            {
                if (device != null)
                {
                 
                    ucRollText.Text = "IO路径:  /" + server.SERVER_NAME + "/" + comm.IO_COMM_NAME + "[" + comm.IO_COMM_LABEL + "]/" + device.IO_DEVICE_NAME + "[" + device.IO_DEVICE_LABLE + "]";

                    this.listView.Items.Clear();

                    foreach (IO_PARA para in device.IOParas)
                    {

                        ListViewItem lvItem = new ListViewItem(para.IO_ID);
                        lvItem.Text = para.IO_ID;
                        lvItem.Tag = para;
                        lvItem.SubItems.Add(para.IO_NAME);
                        lvItem.SubItems.Add(para.IO_LABEL);
                        lvItem.SubItems.Add(para.RealValue);
                        lvItem.SubItems.Add(para.IO_UNIT);
                        lvItem.SubItems.Add(para.RealDate);
                        lvItem.SubItems.Add(para.RealQualityStamp.ToString());
                        lvItem.SubItems.Add(para.IO_POINTTYPE.ToString());
                        this.listView.Items.Add(lvItem);
                    }


                }
            }));
            }
        }
        /// <summary>
        /// 设置采集点的采集值
        /// </summary>
        /// <returns></returns>
        public   void SetIOValue(Scada.Model.IO_SERVER server, Scada.Model.IO_COMMUNICATION comm, Scada.Model.IO_DEVICE device)
        {
            try
            {


              
                    ChangedBinds(server, comm, device.Copy());
               
            }
            catch (Exception ex)
            {
                MonitorFormManager.DisplyException(ex);
            }
        }

        #endregion
        public TabTypes TabType
        {
            get
            {
                return TabTypes.IOMonitoring;
            }
        }
        public string TabIdentifier
        {
            get
            {
                return identifier;
            }
            set
            {
                identifier = value;
            }
        }

        private void IOMonitorForm_Load(object sender, EventArgs e)
        {
            ControlHelper.FreezeControl(this, true);
            ucLateAlarmSIze.SelectedIndex = 0;
            ucLateReceiveSize.SelectedIndex = 0;
            ucLateCommandSize.SelectedIndex = 0;
        }

        

        

        private    void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count < 0)
                return;
            try
            {


                IO_PARA para = listView.SelectedItems[0].Tag as IO_PARA;
                  MonitorFormManager.SetIOPara(this.Server, this.Communication, this.Device, para);
            }
            catch (Exception ex)
            {
                MonitorFormManager.DisplyException(ex);
            }
        }
        /// <summary>
        /// 将读取的数据上传值服务器端后并未在上传日志中显示
        /// </summary>
        /// <param name="server"></param>
        /// <param name="communication"></param>
        /// <param name="device"></param>
        public    void ShowMonitorUploadListView(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device,string uploadresult)
        {
            if (IOMonitorManager.IsBackRun)
                return;
            if (ucbReceive.Checked)
            {
                if (this.IsHandleCreated&& listViewReceive.InvokeRequired)
                {
                    listViewReceive.BeginInvoke(new EventHandler(delegate
                    {

                        ListViewItem lvi = new ListViewItem(device.GetedValueDate.ToString());
                        lvi.SubItems.Add(server.SERVER_NAME);
                        lvi.SubItems.Add(communication.IO_COMM_NAME + "[" + communication.IO_COMM_LABEL + "]");
                        lvi.SubItems.Add(device.IO_DEVICE_NAME + "[" + device.IO_DEVICE_LABLE + "]");
                        lvi.SubItems.Add(uploadresult);
                        if (device.ReceiveBytes.Length > 0)
                        {
                            //将接收的数据转为16字节进行显示
                            lvi.SubItems.Add(CVT.ByteToHexStr(device.ReceiveBytes));
                        }
                        else
                        {
                            lvi.SubItems.Add("  ");
                        }


                        listViewReceive.Items.Insert(0, lvi);

                        if (this.ucLateReceiveSize.SelectedValue!=null&& this.ucLateReceiveSize.SelectedValue!="")
                        {
                        
                            if (listViewReceive.Items.Count > int.Parse(this.ucLateReceiveSize.SelectedValue))
                            {
                                listViewReceive.Items.RemoveAt(listViewReceive.Items.Count - 1);
                               
                            }

                        }
                        

                    }));
                }
            }
           
        }
        /// <summary>
        /// 在ListView中显示下置命令
        /// </summary>
        /// <param name="server"></param>
        /// <param name="communication"></param>
        /// <param name="device"></param>
        /// <param name="para"></param>
        /// <param name="command"></param>
        public   void InsertMonitorCommandListView(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device,IO_PARA para, IO_COMMANDS command)
        {
            if (IOMonitorManager.IsBackRun)
                return;
            if (ucbSendCommand.Checked)
            {
                if (this.IsHandleCreated&& listViewSendCommand.InvokeRequired)
                {
                    listViewSendCommand.BeginInvoke(new EventHandler(delegate
                    {

                        ListViewItem lvi = new ListViewItem(command.COMMAND_DATE);
                        lvi.SubItems.Add(command.COMMAND_RESULT);
                        lvi.SubItems.Add(command.COMMAND_VALUE);
                        lvi.SubItems.Add(server.SERVER_NAME);
                        lvi.SubItems.Add(communication.IO_COMM_NAME + "[" + communication.IO_COMM_LABEL + "]");
                        lvi.SubItems.Add(device.IO_DEVICE_NAME + "[" + device.IO_DEVICE_LABLE + "]");
                        if (para != null)
                            lvi.SubItems.Add(para.IO_NAME + "[" + para.IO_LABEL + "]");
                        else
                        {
                            lvi.SubItems.Add("未知IO参数");
                        }




                        listViewSendCommand.Items.Insert(0, lvi);
                        if (this.ucLateCommandSize.SelectedValue == "")
                            this.ucLateCommandSize.SelectedValue = "100";
                        if (listViewSendCommand.Items.Count > int.Parse(this.ucLateCommandSize.SelectedValue))
                        {
                            listViewSendCommand.Items.RemoveAt(listViewSendCommand.Items.Count - 1);
                        }

                    }));
                }
            }

        }
        /// <summary>
        /// 报警生产的显示
        /// </summary>
        /// <param name="server"></param>
        /// <param name="communication"></param>
        /// <param name="device"></param>
        /// <param name="alarm"></param>
        /// <param name="uploadresult"></param>
        public   void InsertMonitorAlarmListView(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device,IO_PARAALARM alarm,string uploadresult)
        {
            if (IOMonitorManager.IsBackRun)
                return;
            if (uccbRealAlarm.Checked)
            {
                if (listViewAlarm.IsHandleCreated)
                {
                    listViewAlarm.BeginInvoke(new EventHandler(delegate
                    {

                        ListViewItem lvi = new ListViewItem(alarm.IO_ALARM_ID);
                        lvi.SubItems.Add(alarm.IO_ALARM_DATE);
                        lvi.SubItems.Add(alarm.IO_NAME + "[" + alarm.IO_LABEL + "]");
                        lvi.SubItems.Add(alarm.IO_ALARM_VALUE);
                        lvi.SubItems.Add(alarm.IO_ALARM_TYPE);
                        lvi.SubItems.Add(alarm.IO_ALARM_LEVEL);
                        lvi.SubItems.Add(server.SERVER_NAME);
                        lvi.SubItems.Add(communication.IO_COMM_NAME + "[" + communication.IO_COMM_LABEL + "]");
                        lvi.SubItems.Add(device.IO_DEVICE_NAME + "[" + device.IO_DEVICE_LABLE + "]");
                        lvi.SubItems.Add(uploadresult);




                        listViewAlarm.Items.Insert(0, lvi);
                        if (listViewAlarm.Items.Count > int.Parse(this.ucLateAlarmSIze.SelectedValue))
                        {
                            listViewAlarm.Items.RemoveAt(listViewAlarm.Items.Count - 1);
                        }

                    }));
                }
            }

        }
    }
}
