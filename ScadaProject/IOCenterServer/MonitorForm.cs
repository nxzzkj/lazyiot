
using Scada.Controls.Forms;
using ScadaCenterServer.Controls;
using ScadaCenterServer.Core;
using ScadaCenterServer.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;
using Scada.Model;

namespace ScadaCenterServer
{
    public partial class MonitorForm : FrmWithTitle
    {
 
        public event EventHandler StartClick;
        public event EventHandler CloseClick;
        public event EventHandler ContinueClick;
        public event EventHandler PauseClick;
        public MonitorForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

        }
        public IoServerTreeNode GetServerNode(string server_id)
        {
            if(this.IOTreeView.Nodes.Count>0)
            {
                TreeNode[] fNodes = this.IOTreeView.Nodes[0].Nodes.Find(server_id, false);
                if (fNodes.Length > 0)
                {
                    if (fNodes[0] is IoServerTreeNode)
                    {
                        return fNodes[0] as IoServerTreeNode;
                    }
                }

            }
           
            return null;
        }
        public   void InitIOTree()
        {
            if (this.IsHandleCreated&& IOTreeView.InvokeRequired)
            {
                IOTreeView.BeginInvoke(new EventHandler(delegate
                {
                    IOCenterManager.TCPServer.LoadIOProject(this.IOTreeView);
                }));
            }




        }
       

        private void ClientForm_Load(object sender, EventArgs e)
        {
           
             systimer.Start();
            labelIP.Text = LocalIp.GetLocalIp();
            computerInfoControl.Monitour();


        }
        public   void AddReeiveDevice(System.Net.EndPoint ep, string datetime, string server, string communication, string device, string msg, bool result)
        {
            if (IOCenterManager.IsBackRun)
                return;

            if (!ucReceive.Checked)
                return;
            ListViewItem lvi = new ListViewItem(ep.ToString());
            lvi.SubItems.Add(datetime);
            lvi.SubItems.Add(device);
            lvi.SubItems.Add(communication);
            lvi.SubItems.Add(server);
            if (msg.Length > 900)
            {
                lvi.SubItems.Add(msg.Substring(0, 900) + "......");
            }
            else
            {
                lvi.SubItems.Add(msg);
            }

            if (result)
            {
                lvi.SubItems.Add("入库成功");

            }
            else
            {
                lvi.SubItems.Add("入库失败");
            }
            if (listViewReceive.IsHandleCreated)
            {
                listViewReceive.BeginInvoke(new EventHandler(delegate
            {
                try
                {
                    this.listViewReceive.Items.Insert(0, lvi);
                    if (this.listViewReceive.Items.Count > int.Parse(cbReceiveSize.SelectedValue))
                    {
                        this.listViewReceive.Items.RemoveAt(this.listViewReceive.Items.Count - 1);
                    }
                }
                catch  
                {

                }

            }));
            }
        }


        public   void AddReeiveAlarm(System.Net.EndPoint ep, string server, string communication, string device,IO_PARAALARM alarm, bool result)
        {
            if (IOCenterManager.IsBackRun)
                return;
            //IP
            //            报警时间
            //IO参数
            //报警值
            //报警类型
            //报警等级
            //采集站
            //通道
            //设备
            //入库结果

            if (!ucEnableAlarm.Checked)
                return;
 
            ListViewItem lvi = new ListViewItem(ep.ToString());
            lvi.SubItems.Add(alarm.IO_ALARM_DATE);
            lvi.SubItems.Add(alarm.IO_LABEL+"["+ alarm.IO_NAME + "]");
            lvi.SubItems.Add(alarm.IO_ALARM_VALUE);
            lvi.SubItems.Add(alarm.IO_ALARM_TYPE);
            lvi.SubItems.Add(alarm.IO_ALARM_LEVEL);
            lvi.SubItems.Add(server);
        
            lvi.SubItems.Add(communication);
            lvi.SubItems.Add(device);
            if (result)
            lvi.SubItems.Add("入库成功");
            else
                lvi.SubItems.Add("入库失败");
            if (listViewAlarm.IsHandleCreated)
            {
                listViewAlarm.BeginInvoke(new EventHandler(delegate
            {
                try
                {
                    this.listViewAlarm.Items.Insert(0, lvi);
                    if (this.listViewAlarm.Items.Count > int.Parse(this.cbAlarmSize.SelectedValue))
                    {
                        this.listViewAlarm.Items.RemoveAt(this.listViewReceive.Items.Count - 1);
                    }
                }
                catch 
                {

                }

            }));
            }
        }


        public   void AddReport(System.Net.EndPoint ep, string msg)
        {
            if (IOCenterManager.IsBackRun)
                return;
            if (this.ucLog.Checked)
            {

                if (listViewReport.IsHandleCreated)
                {
                    listViewReport.BeginInvoke(new EventHandler(delegate
                {
                    try
                    {


                        ListViewItem lvi = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        if (ep != null)
                            lvi.SubItems.Add(ep.ToString() + "  " + msg);
                        else
                            lvi.SubItems.Add(msg);

                        this.listViewReport.Items.Insert(0, lvi);
                        if (this.listViewReport.Items.Count > int.Parse(this.cbLogSize.SelectedValue))
                        {
                            this.listViewReport.Items.RemoveAt(this.listViewReport.Items.Count - 1);
                        }
                    }
                    catch  
                    {

                    }
                }));
                }
            }

        }
        public   void AddCommand(System.Net.EndPoint ep,string server,string communication,string device,string para ,IO_COMMANDS command)
        {
            if (IOCenterManager.IsBackRun)
                return;
            if (ucbSendCommand.Checked)
            {
                if (listViewSendCommand.IsHandleCreated)
                {
                    listViewSendCommand.BeginInvoke(new EventHandler(delegate
                {
                    try
                    {


                        ListViewItem lvi = new ListViewItem(command.COMMAND_DATE);
                        lvi.SubItems.Add(server);
                        lvi.SubItems.Add(communication);
                        lvi.SubItems.Add(device);
                        lvi.SubItems.Add(para);
                        lvi.SubItems.Add(command.COMMAND_VALUE);
                        if (command.COMMAND_RESULT == "true")
                            lvi.SubItems.Add("成功");
                        else
                            lvi.SubItems.Add("失败");
                        lvi.SubItems.Add(command.COMMAND_USER);
                        this.listViewSendCommand.Items.Insert(0, lvi);
                        if (this.listViewSendCommand.Items.Count > int.Parse(this.cbSendCommandSize.SelectedValue))
                        {
                            this.listViewSendCommand.Items.RemoveAt(this.listViewSendCommand.Items.Count - 1);
                        }
                        Scada.Logger.Logger.GetInstance().Info(command.COMMAND_DATE + "   " + command.GetCommandString());
                    }
                    catch
                    {

                    }
                }));
                }
            }

        }
        /// <summary>
        /// 当前实时设备状态改变信息
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public void DeviceStatus(string IO_SERVER_ID, IO_DEVICE device, bool status)
        {
            if (this.IsHandleCreated&& IOTreeView.InvokeRequired)
            {
                IOTreeView.BeginInvoke(new EventHandler(delegate
            {
                if (this.IOTreeView.Nodes.Count < 0)
                    return;
                for (int i = 0; i < this.IOTreeView.Nodes[0].Nodes.Count; i++)
                {

                    TreeNode[] tn = this.IOTreeView.Nodes[0].Nodes.Find(device.IO_DEVICE_ID.ToString(), true);
                    for (int j = 0; j < tn.Length; j++)
                    {
                        if (tn.Length == 1 && tn[j] is Controls.IoDeviceTreeNode)
                        {

                            Controls.IoDeviceTreeNode deviceNode = tn[j] as Controls.IoDeviceTreeNode;
                            if (deviceNode != null && deviceNode.Device.IO_SERVER_ID == IO_SERVER_ID)
                            {
                                deviceNode.status = status;


                                if (deviceNode.status)
                                {
                                    deviceNode.ForeColor = Color.Green;
                                    deviceNode.Parent.ForeColor = Color.Green;
                                    deviceNode.Parent.Parent.ForeColor = Color.Green;
                                    deviceNode.SelectedImageIndex = 5;
                                    deviceNode.ImageIndex = 5;
                                    deviceNode.Tag = null;
                                }

                                else
                                {
                                    deviceNode.ForeColor = Color.Red;
                                    deviceNode.SelectedImageIndex = 4;
                                    deviceNode.ImageIndex = 4;
                                    deviceNode.Tag = DateTime.Now.ToString("yyyy-MM-dd");

                                }
                            }
                        }
                    }

                }
            }));
            }
             IOCenterManager.QueryFormManager.Mediator.IOTreeForm.DeviceStatus(IO_SERVER_ID,device, status);

        }
        public void  ServerStatus(EndPoint   clientEndPoint,IO_SERVER server, bool status, string mac)
        {
            if (this.IsHandleCreated&& IOTreeView.InvokeRequired)
            {
                IOTreeView.BeginInvoke(new EventHandler(delegate
            {
                if (this.IOTreeView.Nodes.Count < 0)
                    return;
                for (int i = 0; i < this.IOTreeView.Nodes.Count; i++)
                {

                    TreeNode[] tn = this.IOTreeView.Nodes[i].Nodes.Find(server.SERVER_ID.ToString(), false);
                    if (tn.Length == 1)
                    {
                        Controls.IoServerTreeNode serverNode = tn[0] as Controls.IoServerTreeNode;
                        if (serverNode != null)
                        {
                            serverNode.MAC = mac;
                            serverNode.ClientEndPoint = clientEndPoint;
                            if (status)
                            {
                                serverNode.ForeColor = Color.Green;
                                serverNode.Tag = null;
                                serverNode.ImageIndex = 2;
                                serverNode.StateImageIndex = 2;
                                serverNode.Text = clientEndPoint.ToString();
                            }
                            else
                            {
                                serverNode.ForeColor = Color.Red;
                                serverNode.Tag = DateTime.Now.ToString("yyyy-MM-dd");
                                serverNode.ImageIndex = 1;
                                serverNode.StateImageIndex = 1;
                                serverNode.Text = server.SERVER_NAME + "未上线";
                            }

                        }

                    }
                }
            }));
            }
             IOCenterManager.QueryFormManager.Mediator.IOTreeForm.ServerStatus(clientEndPoint,server, status);
        }

        public  async  void btStart_Click(object sender, EventArgs e)
        {
            if (FrmDialog.ShowDialog(this, "是否要采集服务,启动该服务后数据将正常采集", "提示", true, true, true, true) == DialogResult.OK)
            {
                try
                {


                  await  IOCenterManager.TCPServer.Start();
                    IOCenterManager.TCPServer.TcpServerStatus = TcpServerStatus.运行;
                    labelStatus.Text = "运行";
                    this.ucBtnStart.Enabled = false;
                    this.ucBtnStop.Enabled = true;
                    this.ucBtnPause.Enabled = true;
                    this.ucBtnContinue.Enabled = false;
                    ucAlarm.LampColor = new Color[2] { Color.Green, Color.Yellow };
                    AddReport(null, "用户启动数据服务成功!");
                    
                }
                catch (Exception ex)
                {

                    AddReport(null, "用户启动数据服失败" + ex.Message);
                }
                if (StartClick != null)
                {
                    StartClick(sender, e);
                }
            }


        }
        public void btPause_Click(object sender, EventArgs e)
        {

            IOCenterManager.TCPServer.TcpServerStatus = TcpServerStatus.暂停;
            labelStatus.Text = "暂停";
            this.ucBtnStart.Enabled = false;
            this.ucBtnStop.Enabled = true;
            this.ucBtnPause.Enabled = false;
            this.ucBtnContinue.Enabled = true;
            ucAlarm.LampColor = new Color[2] { Color.Blue, Color.Yellow };
            if (PauseClick != null)
            {
                PauseClick(sender, e);
            }

        }
        public void btContinue_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "运行";
            IOCenterManager.TCPServer.TcpServerStatus = TcpServerStatus.运行;
            this.ucBtnStart.Enabled = false;
            this.ucBtnStop.Enabled = true;
            this.ucBtnPause.Enabled = true;
            this.ucBtnContinue.Enabled = false;
            ucAlarm.LampColor = new Color[2] { Color.Green, Color.Yellow };
            if (ContinueClick != null)
            {
                ContinueClick(sender, e);
            }

        }
        public    async void btClose_Click(object sender, EventArgs e)
        {
            if (FrmDialog.ShowDialog(this, "是否要采集服务,启动该服务后数据将正常采集", "提示", true, true, true, true) == DialogResult.OK)
            {

                try
                {

                await    IOCenterManager.TCPServer.Stop();
                    IOCenterManager.TCPServer.TcpServerStatus = TcpServerStatus.停止;
                    ucAlarm.LampColor = new Color[2] { Color.Red, Color.Yellow };

                    labelStatus.Text = "停止";
                    this.ucBtnStart.Enabled = true;
                    this.ucBtnStop.Enabled = false;
                    this.ucBtnPause.Enabled = false;
                    this.ucBtnContinue.Enabled = false;
                    AddReport(null, "用户停止数据服务成功!");
                }
                catch (Exception ex)
                {

                    AddReport(null, "用户停止数据服失败" + ex.Message);
                }
                if (CloseClick != null)
                {
                    CloseClick(sender, e);
                }
            }
        }
        //主动下置命令

        private void btSend_Click(object sender, EventArgs e)
        {
            if(this.IOTreeView.SelectedNode==null)
            {
                FrmDialog.ShowDialog(this,"请在IO树中选择设备节点");
                return;
            }
            if(this.IOTreeView.SelectedNode is IoDeviceTreeNode)
            {
                IoDeviceTreeNode deviceNode = this.IOTreeView.SelectedNode as IoDeviceTreeNode;
                IoCommunicationTreeNode communicationTreeNode = this.IOTreeView.SelectedNode.Parent as IoCommunicationTreeNode;
                IoServerTreeNode serverNode = this.IOTreeView.SelectedNode.Parent.Parent as IoServerTreeNode;
                if (serverNode.ClientEndPoint == null)
                {
                    FrmDialog.ShowDialog(this, "采集站终端未上线");
                    return;
                }
                SendCommandForm sendCommandForm = new SendCommandForm();
                sendCommandForm.InitCommand(serverNode.Server, communicationTreeNode.Communication, deviceNode.Device);
                if(sendCommandForm.ShowDialog(this)==DialogResult.OK)
                {

                }

            }
            else
            {
                FrmDialog.ShowDialog(this, "请在IO树中选择设备节点");
                return;
            }
           
        }

        private void systimer_Tick(object sender, EventArgs e)
        {
          
            ucledDate.Value = DateTime.Now.ToString("HH:mm:ss");
            switch (IOCenterManager.TCPServer.TcpServerStatus)
            {
                case TcpServerStatus.停止:
              

                    labelStatus.Text = "停止";
                    this.ucBtnStart.Enabled = true;
                    this.ucBtnStop.Enabled = false;
                    this.ucBtnPause.Enabled = false;
                    this.ucBtnContinue.Enabled = false;
                    ucAlarm.LampColor = new Color[2] { Color.Red, Color.Yellow };
                    break;
                case TcpServerStatus.暂停:
                    labelStatus.Text = "暂停";
                    this.ucBtnStart.Enabled = false;
                    this.ucBtnStop.Enabled = true;
                    this.ucBtnPause.Enabled = false;
                    this.ucBtnContinue.Enabled = true;
                    ucAlarm.LampColor = new Color[2] { Color.Blue, Color.Yellow };
                    break;
                case TcpServerStatus.运行:
                    labelStatus.Text = "运行";
                    this.ucBtnStart.Enabled = false;
                    this.ucBtnStop.Enabled = true;
                    this.ucBtnPause.Enabled = true;
                    this.ucBtnContinue.Enabled = false;
                    ucAlarm.LampColor = new Color[2] { Color.Green, Color.Yellow };
                    break;
            }
           
         
        }

        private void MonitorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void btMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
    public delegate void SendMessageHandle(string ip,string msg);
}
