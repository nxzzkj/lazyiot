using Scada.AsyncNetTcp;
using Scada.AsyncNetTcp.Net;
using Temporal.Net.InfluxDb.Models.Responses;
using Temporal.DbAPI;
using Scada.IOStructure;
using Scada.Controls.Forms;
using ScadaCenterServer.Controls;
using ScadaCenterServer.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Scada.DBUtility;
using Scada.Model;

namespace ScadaCenterServer.Core
{
    public enum TcpServerStatus
    {
        停止,
        运行,
        暂停
    }
 
    public  class ScadaCommunicate
    {
        public TcpServerStatus TcpServerStatus = TcpServerStatus.停止;
        public   AsyncTcpListener Server = null;
        public   MonitorForm ServerForm = null;

        public  ScadaCommunicate()
        {
            //数据读写缓存
            RealCache = new ReceiveRealCache();
            ///批量写入实时数据库每次最多3000条
            RealCache.InsertInfluxdb = (List<ReceiveCacheObject> result) =>
            {
                try
                {
                    //定时从缓存区上传数据
                    var analysisTask = Task.Run(async () =>
                    {
                        ///批量执行influxdb的写入，一次写入1000条数据
                        List<IO_DEVICE> devices = new List<IO_DEVICE>();
                        result.ForEach(delegate (ReceiveCacheObject p)
                        {

                            devices.Add(p.device);
                        });
                        if (devices.Count > 0)
                        {
                            await IOCenterManager.InfluxDbManager.DbWrite_RealPoints(devices);
                        }

                        devices.Clear();
                        devices = null;
                        result.Clear();
                        result = null;

                    });
                    return analysisTask;



                }
                catch (Exception ex)
                {


                    DisplayException(new Exception("" + ex.Message));

                    return null;
                }

            };

            //批量写入报警数据
            RealCache.InsertAlarmInfluxdb = (List<AlarmCacheObject> result) =>
            {
                try
                {
                    //定时从缓存区上传数据
                    var analysisTask = Task.Run(async () =>
                    {
                        ///批量执行influxdb的写入，一次写入1000条数据
                        List<IO_PARAALARM> alarms = new List<IO_PARAALARM>();
                        result.ForEach(delegate (AlarmCacheObject p)
                        {
                            if (p.Alarm != null)
                            {
                                alarms.Add(p.Alarm);
                            }
                        });
                        if (alarms.Count > 0)
                        {
                            await IOCenterManager.InfluxDbManager.DbWrite_AlarmPoints(alarms);
                        }

                        alarms.Clear();
                        alarms = null;

                        result.Clear();
                        result = null;

                    });
                    return analysisTask;



                }
                catch (Exception ex)
                {
                    DisplayException(new Exception("" + ex.Message));
                    return null;
                }

            };

            RealCache.Read();
        }
        /// <summary>
        /// 定义一个数据存储和接收的缓存，influxdb用于批量插入
        /// </summary>
        public   ReceiveRealCache RealCache = null;

        public void  InitMonitorForm()
        {
            if (ServerForm == null|| ServerForm.IsDisposed)
            {
                ServerForm = new MonitorForm();
                ServerForm.Show();
             
              
                ServerForm.StartClick += ServerForm_StartClick;
                ServerForm.CloseClick += ServerForm_CloseClick;
            
            }
           
        }
       

        public void SetMonitorForm(MonitorForm form)
        {

            ServerForm = form;
        
            ServerForm.StartClick += ServerForm_StartClick;
            ServerForm.CloseClick += ServerForm_CloseClick;


        }
        public   void InitTree()
        {
           if(ServerForm!=null)
            {
                ServerForm.InitIOTree();
            }
        }
        /// <summary>
        /// 在系统增加日志
        /// </summary>
        /// <param name="msg"></param>
        public void AddLog(string msg)
        {
            if (ServerForm != null && !ServerForm.IsDisposed)
            {
                if (ServerForm.IsHandleCreated)
                {
                    ServerForm.listViewReport.BeginInvoke(new EventHandler(delegate
                {
                    ListViewItem liv = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    liv.SubItems.Add(msg);
                    ServerForm.listViewReport.Items.Insert(0, liv);
                    if (ServerForm.listViewReport.Items.Count >= 100)
                    {
                        ServerForm.listViewReport.Items.RemoveAt(ServerForm.listViewReport.Items.Count - 1);
                    }
                }));
                }
            }
            Scada.Logger.Logger.GetInstance().Info(msg);
        }
        public void DisplayException(Exception ex)
        {
            if (ServerForm != null&& !ServerForm.IsDisposed)
            {
                if (ServerForm.IsHandleCreated)
                {
                    ServerForm.listViewReport.BeginInvoke(new EventHandler(delegate
                {
                    ListViewItem liv = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    liv.SubItems.Add(ex.Message);
                    ServerForm.listViewReport.Items.Insert(0, liv);
                    if (ServerForm.listViewReport.Items.Count >= 100)
                    {
                        ServerForm.listViewReport.Items.RemoveAt(ServerForm.listViewReport.Items.Count - 1);
                    }
                }));
                }

            }

            Scada.Logger.Logger.GetInstance().Debug(ex.Message);
        

        }
        #region 监视窗体相关
        public void LoadIOProject()
        {
            if (ServerForm != null && !ServerForm.IsDisposed)
            {
               LoadIOProject(ServerForm.IOTreeView);
            }
        }
        public void LoadIOProject(TreeView tree)
        {
            Task.Run(() =>
            {
                if (ServerForm != null && !ServerForm.IsDisposed)
                {
                    if (tree.Parent.IsHandleCreated)
                    {
                        tree.BeginInvoke(new EventHandler(delegate
                    {

                        tree.Nodes.Clear();
                        try
                        {

                            tree.Nodes.Clear();

                            int num = IOCenterManager.IOProject.Servers.Count + IOCenterManager.IOProject.Communications.Count + IOCenterManager.IOProject.Devices.Count;
                            InitProgress(num);
                            TreeNode mainNode = new TreeNode();
                            mainNode.ImageIndex = 0;
                            mainNode.SelectedImageIndex = 0;
                            mainNode.Text = PubConstant.Product;

                        ///加载采集站
                        for (int i = 0; i < IOCenterManager.IOProject.Servers.Count; i++)
                            {

                                IoServerTreeNode serverNode = new IoServerTreeNode();
                                serverNode.Server = IOCenterManager.IOProject.Servers[i];
                                serverNode.InitNode();
                                serverNode.ForeColor = System.Drawing.Color.Red;
                                List<Scada.Model.IO_COMMUNICATION> serverComms = IOCenterManager.IOProject.Communications.FindAll(x => x.IO_SERVER_ID == IOCenterManager.IOProject.Servers[i].SERVER_ID);
                                for (int c = 0; c < serverComms.Count; c++)//通道
                            {
                                    IoCommunicationTreeNode commNode = new IoCommunicationTreeNode();
                                    commNode.Communication = serverComms[c];
                                    commNode.Server = IOCenterManager.IOProject.Servers[i];
                                    commNode.InitNode();
                                    commNode.ForeColor = System.Drawing.Color.Red;
                                    List<Scada.Model.IO_DEVICE> commDevices = IOCenterManager.IOProject.Devices.FindAll(x => x.IO_SERVER_ID == IOCenterManager.IOProject.Servers[i].SERVER_ID && x.IO_COMM_ID == serverComms[c].IO_COMM_ID);
                                    for (int d = 0; d < commDevices.Count; d++)//设备
                                {
                                        IoDeviceTreeNode deviceNode = new IoDeviceTreeNode();
                                        deviceNode.Device = commDevices[d];
                                        deviceNode.Server = IOCenterManager.IOProject.Servers[i];
                                        deviceNode.Communication = serverComms[c];

                                        deviceNode.ContextMenuStrip = null;
                                        deviceNode.InitNode();
                                        deviceNode.ForeColor = System.Drawing.Color.Red;
                                        commNode.Nodes.Add(deviceNode);

                                        SetProgress();
                                    }
                                    commNode.Collapse();
                                    serverNode.Nodes.Add(commNode);
                                }

                                serverNode.Expand();
                                mainNode.Nodes.Add(serverNode);

                            }

                            tree.Nodes.Add(mainNode);

                            EndProgress();
                        }
                        catch (Exception exm)
                        {
                            EndProgress();
                            DisplayException(new Exception("ERR10018" + exm.Message));
                            FrmDialog.ShowDialog(this.ServerForm, exm.Message);

                        }


                    }));
                    }
                }
            });

        }
        private async  void ServerForm_CloseClick(object sender, EventArgs e)
        {
         await   Stop();
        }

        private async  void ServerForm_StartClick(object sender, EventArgs e)
        {
          await  Start();
        }


        #endregion

        /// <summary>
        /// 向指定客户端发送数据
        /// </summary>
        /// <param name="client"></param>
        /// <param name="datas"></param>
        private bool SendData(EndPoint clientEndPoint, byte[] datas)
        {
            try
            {
                foreach (var tcpClient in Server.Clients)
                {
                    if (clientEndPoint == tcpClient.Key.Client.RemoteEndPoint)
                    {
                        if (tcpClient.Key != null && tcpClient.Key.Connected)
                        {
                            Server.Send(tcpClient.Key, new ArraySegment<byte>(datas));

                        }

                    }

                }
                return true;
            }
            catch
            {
                return false;

            }
        }
        /// <summary>
        /// 向指定客户端发送数据
        /// </summary>
        /// <param name="client"></param>
        /// <param name="msg"></param>
        public   bool SendData(EndPoint clientEndPoint, string msg, ScadaTcpOperator op)
        {
            try
            {
                if (this.Server.UsedPackageIdentification)
                {
                    //构造包含头标识和尾标识的字节
                    byte[] datas = Encoding.UTF8.GetBytes(msg);
                    byte[] newdatas = new byte[1 + datas.Length];

                    newdatas[0] = (byte)op;
                    System.Array.Copy(datas, 0, newdatas, 1, datas.Length);

                    SendData(clientEndPoint, newdatas);
                 
                }
                else
                {
                    byte[] datas = Encoding.UTF8.GetBytes(msg);
                    byte[] newdatas = new byte[1 + datas.Length];
                    SendData(clientEndPoint, newdatas);
                }
                return true;
            }
            catch(Exception emx)
            {
                DisplayException(new Exception("ERROR50010  "+emx.Message));
                return false;
            }

       
        }
        public   void RefreshServerStatus(AsyncTcpClient serverClient,int status,bool writemsg=false)
        {
            IO_SERVER server = IOCenterManager.IOProject.Servers.Find(x => x.SERVER_ID.Trim() == serverClient.MAC);
            if (server != null)
            {
          
                server.SERVER_STATUS = 0;
                IPAddress ip = ((IPEndPoint)serverClient.ServerTcpClient.Client.RemoteEndPoint).Address;
                if (serverClient.ScadaClientType == ScadaClientType.IoMonitor)
                {
                    server.SERVER_IP = ip.ToString();
                    Scada.Business.IO_SERVER serverBll = new Scada.Business.IO_SERVER();
                    serverBll.Update(server);
                    server.SERVER_STATUS = status;
                    server.MonitorEndPoint = serverClient.ServerTcpClient.Client.RemoteEndPoint;
                }



            }
            if (ServerForm != null && !ServerForm.IsDisposed)
            {
                string connStr = status == 0 ? "断开" : "连接";
                string clientMsg = "";
                if (serverClient.ScadaClientType == ScadaClientType.IoMonitor)
                {
                    clientMsg = "有采集站"+ connStr + "数据中心";
                }
                else if (serverClient.ScadaClientType == ScadaClientType.FlowDesign)
                {
                    clientMsg = "有采集站流程设计器" + connStr + "数据中心";
                }
                else if (serverClient.ScadaClientType == ScadaClientType.IoManager)
                {
                    clientMsg = "有采集站IO工程管理器" + connStr + "数据中心";
                }
                else if (serverClient.ScadaClientType == ScadaClientType.WebSystem)
                {
                    clientMsg = "WebScada" + connStr + "数据中心";
                }
                if(writemsg)
                ServerForm.AddReport(serverClient.ServerTcpClient.Client.RemoteEndPoint, clientMsg);
            }

            if (ServerForm != null && !ServerForm.IsDisposed && server != null && serverClient.ScadaClientType == ScadaClientType.IoMonitor)
            {
                  ServerForm.ServerStatus(serverClient.ServerTcpClient.Client.RemoteEndPoint, server, status==0?false:true, server.SERVER_ID);

            }
        }
        /// <summary>
        /// Demonstrates the client and server with derived classes.
        /// </summary>
        /// <returns></returns>
        private async Task RunAsync(int port)
        {

            int Port = port;

            Server = new AsyncTcpListener
            {
                IPAddress = IPAddress.Parse(LocalIp.GetLocalIp()),
                Port = port,
                 ScadaClientType= ScadaClientType.IoServer,
                ClientConnectedCallback = tcpClient =>
                    new AsyncTcpClient
                    {
                        ServerTcpClient = tcpClient,
                        ConnectedCallback = async (serverClient, isReconnected) =>
                        {
                            try
                            {
                                serverClient.TemporaryByteBuffer = new List<byte[]>();
                                serverClient.TemporaryByteRun = false;
                                serverClient.TemporaryBytesCount = 0;
                                serverClient.TemporaryBytesKey = "";
                                if (TcpServerStatus != TcpServerStatus.运行)
                                    return;

                                //刷新服务端IO节点的状态
                                RefreshServerStatus(serverClient,1,true);
                            }
                            catch (Exception emx)
                            {
                                DisplayException(new Exception("ERR30038" + emx.Message));
                            }

                        },
                        ClosedCallback = async (serverClient, isReconnected) =>
                        {
                            try
                            {
                                serverClient.TemporaryByteBuffer = new List<byte[]>();
                                serverClient.TemporaryByteRun = false;
                                serverClient.TemporaryBytesCount = 0;
                                serverClient.TemporaryBytesKey = "";
                                RefreshServerStatus(serverClient, 0,true);
                            }
                            catch(Exception emx)
                            {
                                DisplayException(new Exception("ERR30037" + emx.Message));
                            }
                         },
                        ReceivedCallback = async (serverClient, count) =>//由于是异步事件需要对大文件进行单独处理
                        {
                            try
                            {
                                #region
                                ///原始数据包，有可能是粘包在一起，所以要单独处理
                                byte[] receivebytes = serverClient.ByteBuffer.Dequeue(count);
                                //如果获取的是空数据，则结束任务
                                if (receivebytes.Length <= 0)
                                    return;
                                if (serverClient.UsedPackageIdentification)
                                {
                                    string MAC = "";
                                    SplitPakeage splitPakeage = new SplitPakeage();
                                    string msg = "";
                         
                                    byte[] realbytes = splitPakeage.RemoveIdentificationBytes(receivebytes, serverClient, out MAC,out msg);
                        
                                    //获取解析后的数据体如果为0，则不做任何处理
                                    if (realbytes.Length <= 0)
                                        return;
                                    //根据MAC地址判断是否采集站上线
                                    RefreshServerStatus(serverClient, 1,false);
                                    try
                                    {
                                       
                                        await Task.Factory.StartNew(a =>
                                          {
                                            //分包处理
                                            SplitReceivePack(realbytes, realbytes.Length, serverClient.ServerTcpClient.Client.RemoteEndPoint, serverClient.IPAddress, serverClient, MAC);
                                          }, serverClient);
                                    }
                                    catch (Exception ex)
                                    {
                                        DisplayException(new Exception("ERR30025" + ex.Message));
                                    }


                                }

                                #endregion
                            }
                            catch
                            {

                            }

                        }

                    }.RunAsync()
            };

            Server.Message += Server_Message;
            Server.TCPExceptionEvent += Server_TCPExceptionEvent;
            var serverTask = Server.RunAsync();
            //更新采集站端的报警配置，没30秒查询一次
           

        }
 
         Scada.Business.IO_ALARM_CONFIG alarmconfigBll = new Scada.Business.IO_ALARM_CONFIG();
        /// <summary>
        /// 更新用户采集站工程下的报警配置信息
        /// </summary>
        /// <returns></returns>
        private  async Task UpdateIOAlarmConfig()
        {
            try
            {
                await Task.Run(() =>
                {


                    while (TcpServerStatus != TcpServerStatus.停止)
                    {


                        List<IO_ALARM_CONFIG> alarmconfigs = alarmconfigBll.GetModelList(" UPDATE_DATE is not null and UPDATE_DATE>'" + DateTime.Now.AddSeconds(-61).ToString("yyyy-MM-dd HH:mm:ss") + "' and (UPDATE_RESULT='false' or UPDATE_RESULT is null )");
                        for (int i = 0; i < alarmconfigs.Count; i++)
                        {
                            IO_ALARM_CONFIG item = alarmconfigs[i];

                            if (item.UPDATE_DATE != "" && (item.UPDATE_RESULT == null || item.UPDATE_RESULT == ""))
                            {
                                item.UPDATE_RESULT = "false";
                            }
                            if (item.UPDATE_UID == null || item.UPDATE_UID == "")
                            {
                                item.UPDATE_UID = "NONE";

                            }
                            string str = "IO_SERVER_ID:" + item.IO_SERVER_ID;
                            str += "#IO_ALARM_LEVEL:" + item.IO_ALARM_LEVEL;
                            str += "#IO_ALARM_NUMBER:" + item.IO_ALARM_NUMBER;
                            str += "#IO_ALARM_TYPE:" + item.IO_ALARM_TYPE;
                            str += "#IO_COMM_ID:" + item.IO_COMM_ID;
                            str += "#IO_CONDITION:" + item.IO_CONDITION;
                            str += "#IO_DEVICE_ID:" + item.IO_DEVICE_ID;
                            str += "#IO_ENABLE_MAX:" + item.IO_ENABLE_MAX;
                            str += "#IO_ENABLE_MAXMAX:" + item.IO_ENABLE_MAXMAX;
                            str += "#IO_ENABLE_MIN:" + item.IO_ENABLE_MIN;
                            str += "#IO_ENABLE_MINMIN:" + item.IO_ENABLE_MINMIN;
                            str += "#IO_ID:" + item.IO_ID;
                            str += "#IO_MAXMAX_TYPE:" + item.IO_MAXMAX_TYPE;
                            str += "#IO_MAXMAX_VALUE:" + item.IO_MAXMAX_VALUE;
                            str += "#IO_MAX_TYPE:" + item.IO_MAX_TYPE;
                            str += "#IO_MAX_VALUE:" + item.IO_MAX_VALUE;
                            str += "#IO_MINMIN_TYPE:" + item.IO_MINMIN_TYPE;
                            str += "#IO_MINMIN_VALUE:" + item.IO_MINMIN_VALUE;
                            str += "#IO_MIN_TYPE:" + item.IO_MIN_TYPE;
                            str += "#IO_MIN_VALUE:" + item.IO_MIN_VALUE;
                            str += "#UPDATE_DATE:" + item.UPDATE_DATE;
                            str += "#UPDATE_RESULT:" + item.UPDATE_RESULT;
                            str += "#UPDATE_UID:" + item.UPDATE_UID;
                            if (item.IO_SERVER_ID != "")
                            {
                                if (this.ServerForm != null && !this.ServerForm.IsDisposed)
                                {
                                    IoServerTreeNode serverNode = this.ServerForm.GetServerNode(item.IO_SERVER_ID);
                                    if (serverNode != null)
                                    {
                                        this.SendData(serverNode.ClientEndPoint, str, ScadaTcpOperator.更新采集站报警);
                                        this.ServerForm.AddReport(serverNode.ClientEndPoint, "更新采集站端的报警配置信息");
                                    }

                                }


                            }

                        }
                        //更新报警配置信息，每60秒从数据库中读取一次
                        Thread.Sleep(60000);
                    }
                });
            }
            catch
            {

            }
        }
        /// <summary>
        /// 处理粘包
        /// </summary>
        /// <param name="sourcebytes"></param>
        /// <param name="headbytes"></param>
        /// <param name="count"></param>
        /// <param name="headstr"></param>
        /// <param name="endPoint"></param>
        /// <param name="address"></param>
        /// <param name="serverClient"></param>
        /// <returns></returns>
        private async void SplitReceivePack(byte[] sourcebytes, int count, EndPoint endPoint, IPAddress address, AsyncTcpClient serverClient, string MAC)
        {
            try
            {


                //为了通用性，在开始判断的时候不要将字节数组转换成字符串进行比较，方式出现错误
                //根据MAC地址判断是否采集站上线
                if (ServerForm != null && !ServerForm.IsDisposed)
                {
                    if (serverClient.LogUser != null && serverClient.LogUser.FUNCTION == "IOMonitor")
                    {
                        STATION_TCP_INFO loginer = serverClient.LogUser;
                        if (loginer.FUNCTION == "IOMonitor")//保证只获取的是监视器的远程终端信息
                        {
                            IO_SERVER server = IOCenterManager.IOProject.Servers.Find(x => x.SERVER_ID.Trim() == MAC);
                            if (server != null)
                            {
                                  ServerForm.ServerStatus(serverClient.ServerTcpClient.Client.RemoteEndPoint, server, true, MAC);
                            }

                        }

                    }

                }
                SplitPakeage splitPakeage = new SplitPakeage();
                if (splitPakeage.CompareArray(sourcebytes, serverClient.HeartBeatBytes))
                {
                    //标识心跳包，跳过执行
                    return;
                }
                // 单独处理每个分包数据
                #region 处理采集器端传递的实时值

                byte[] narra = sourcebytes;
                if (narra.Length > 0)
                {
                    if (TcpServerStatus == TcpServerStatus.运行)
                    {
                        //第一个字节是操作命令字节
                        byte opbyte = narra[0];

                        //在指定操作命令内
                        if (serverClient.IsOperator(opbyte))
                        {
                            try
                            {
                                ScadaTcpOperator operatorEnum = (ScadaTcpOperator)opbyte;
                                switch (operatorEnum)
                                {
                                    case ScadaTcpOperator.登录:
                                        {
                                            try
                                            {
                                                serverClient.LogUser = null;
                                                #region 处理采集器端登录
                                                TcpData tcpData = new TcpData();
                                                byte[] contentbytes = new byte[narra.Length - 1];
                                                System.Array.Copy(narra, 1, contentbytes, 0, narra.Length - 1);
                                                tcpData.BytesToTcpItem(contentbytes);
                                                if (!tcpData.IsInvalid)
                                                    return;
                                                STATION_TCP_INFO loginInfo = new STATION_TCP_INFO();
                                                try
                                                {

                                                    loginInfo.IO_SERVER_ID = tcpData.GetItemValue("IO_SERVER_ID");
                                                    loginInfo.IO_SERVER_IP = serverClient.ServerTcpClient.Client.RemoteEndPoint.ToString().Split(':')[0];
                                                    loginInfo.PASSWROD = tcpData.GetItemValue("PASSWROD");
                                                    loginInfo.USER = tcpData.GetItemValue("USER");
                                                    loginInfo.RESULT = tcpData.GetItemValue("RESULT");
                                                    loginInfo.FUNCTION = tcpData.GetItemValue("FUNCTION");
                                                    if (loginInfo.USER.Trim() == IOCenterManager.IOProject.ServerConfig.User && loginInfo.PASSWROD.Trim() == IOCenterManager.IOProject.ServerConfig.Password)
                                                    {
                                                        if (IOCenterManager.IOProject.Servers.Exists(x => x.SERVER_ID.Trim() == loginInfo.IO_SERVER_ID.Trim()))
                                                        {
                                                            loginInfo.RESULT = "true";
                                                            loginInfo.MSG = "登录成功";

                                                            serverClient.LogUser = loginInfo;
                                                        }
                                                        else
                                                        {
                                                            loginInfo.RESULT = "false";
                                                            loginInfo.MSG = "登录失败，您还没有发布采集站工程，无法登录监控系统";


                                                        }


                                                    }
                                                    else
                                                    {
                                                        loginInfo.RESULT = "false";
                                                        loginInfo.MSG = "登录失败,账户或者密码不能为空 账户密码不正确";
                                                        serverClient.LogUser = null;
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    loginInfo.RESULT = "false";
                                                    loginInfo.MSG = "登录失败 " + ex.Message;
                                                    serverClient.LogUser = null;

                                                }


                                                if (loginInfo != null)
                                                {
                                                    byte[] resultbyte = tcpData.StringToTcpByte(loginInfo.GetCommandString(), ScadaTcpOperator.登录反馈);
                                                    this.SendData(serverClient.ServerTcpClient.Client.RemoteEndPoint, resultbyte);
                                                }


                                                tcpData.Dispose();
                                                #endregion
                                            }
                                            catch (Exception ex)
                                            {
                                                DisplayException(new Exception("ERR10021" + ex.Message));
                                            }
                                        }
                                        break;
                                    case ScadaTcpOperator.采集站登录:
                                        {
                                            try
                                            {
                                                serverClient.LogUser = null;
                                                #region 处理采集站工程管理端登录
                                                TcpData tcpData = new TcpData();
                                                byte[] contentbytes = new byte[narra.Length - 1];
                                                System.Array.Copy(narra, 1, contentbytes, 0, narra.Length - 1);
                                                tcpData.BytesToTcpItem(contentbytes);
                                                if (!tcpData.IsInvalid)
                                                    return;
                                                STATION_TCP_INFO loginInfo = new STATION_TCP_INFO();
                                                try
                                                {

                                                    loginInfo.IO_SERVER_ID = tcpData.GetItemValue("IO_SERVER_ID");
                                                    //保存本地的IP
                                                    loginInfo.IO_SERVER_IP = serverClient.ServerTcpClient.Client.RemoteEndPoint.ToString();
                                                    loginInfo.PASSWROD = tcpData.GetItemValue("PASSWROD");
                                                    loginInfo.USER = tcpData.GetItemValue("USER");
                                                    loginInfo.RESULT = tcpData.GetItemValue("RESULT");
                                                    loginInfo.FUNCTION = tcpData.GetItemValue("FUNCTION");
                                                    if (loginInfo.USER.Trim() == IOCenterManager.IOProject.ServerConfig.User && loginInfo.PASSWROD.Trim() == IOCenterManager.IOProject.ServerConfig.Password)
                                                    {
                                                        if (IOCenterManager.IOProject.Servers.Exists(x => x.SERVER_ID.Trim() == loginInfo.IO_SERVER_ID.Trim()))
                                                        {
                                                            loginInfo.RESULT = "true";
                                                            loginInfo.MSG = "登录成功";


                                                        }
                                                        else
                                                        {
                                                            loginInfo.RESULT = "true";
                                                            loginInfo.MSG = "登录成功，您还没有发布采集站工程！";


                                                        }
                                                        serverClient.LogUser = loginInfo;

                                                    }
                                                    else
                                                    {
                                                        loginInfo.RESULT = "false";
                                                        loginInfo.MSG = "登录失败,账户或者密码不能为空 账户密码不正确";
                                                        serverClient.LogUser = null;
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    loginInfo.RESULT = "false";
                                                    loginInfo.MSG = "登录失败 " + ex.Message;
                                                    serverClient.LogUser = null;

                                                }


                                                if (loginInfo != null)
                                                {
                                                    byte[] resultbyte = tcpData.StringToTcpByte(loginInfo.GetCommandString(), ScadaTcpOperator.采集站登录反馈);
                                                    this.SendData(serverClient.ServerTcpClient.Client.RemoteEndPoint, resultbyte);
                                                }


                                                tcpData.Dispose();
                                                #endregion
                                            }
                                            catch (Exception ex)
                                            {
                                                DisplayException(new Exception("ERR10021" + ex.Message));
                                            }
                                        }
                                        break;
                                    case ScadaTcpOperator.发布工程请求:
                                        {
                                            try
                                            {
                                                serverClient.LogUser = null;
                                                serverClient.TemporaryByteBuffer.Clear();
                                                #region 发布工程反馈
                                                TcpData tcpData = new TcpData();
                                                byte[] contentbytes = new byte[narra.Length - 1];
                                                System.Array.Copy(narra, 1, contentbytes, 0, narra.Length - 1);
                                                tcpData.BytesToTcpItem(contentbytes);
                                                if (!tcpData.IsInvalid)
                                                    return;

                                                try
                                                {
                                                    string IO_SERVER_ID = tcpData.GetItemValue("IO_SERVER_ID");
                                                    string RESULT = tcpData.GetItemValue("RESULT");
                                                    string MSG = tcpData.GetItemValue("MSG");
                                                    if (IO_SERVER_ID != "" && IO_SERVER_ID == MAC)//发布的工程和网卡是一致的
                                                    {
                                                        tcpData.GetItem("RESULT").Value = "true";
                                                    }
                                                    else
                                                    {
                                                        tcpData.GetItem("RESULT").Value = "false";
                                                        tcpData.GetItem("MSG").Value = "发布的工程只能在对应的采集站发布";
                                                    }

                                                }
                                                catch 
                                                {
                                                    tcpData.GetItem("RESULT").Value = "false";
                                                    tcpData.GetItem("MSG").Value = "发布的工程只能在对应的采集站发布";


                                                }


                                                if (tcpData != null)
                                                {
                                                    byte[] resultbyte = tcpData.StringToTcpByte(tcpData.TcpItemToString(), ScadaTcpOperator.发布工程请求反馈);
                                                    this.SendData(serverClient.ServerTcpClient.Client.RemoteEndPoint, resultbyte);
                                                }


                                                tcpData.Dispose();
                                                #endregion
                                            }
                                            catch (Exception ex)
                                            {
                                                DisplayException(new Exception("ERR10021" + ex.Message));
                                            }
                                        }
                                        break;
                                    case ScadaTcpOperator.更新采集站报警反馈:
                                        {
                                            //必须保证采集站已经是发布的，否则不能接收传递的数据
                                            if (serverClient.LogUser == null)
                                                return;

                                            #region 更新采集站报警反馈
                                            TcpData tcpData = new TcpData();

                                            byte[] receivebytes = new byte[narra.Length - 1];
                                            System.Array.Copy(narra, 1, receivebytes, 0, receivebytes.Length);
                                            tcpData.BytesToTcpItem(receivebytes);
                                            if (tcpData == null)
                                            {
                                                //解析字符串失败
                                                return;
                                            }
                                            IO_ALARM_CONFIG alarmConfig = new IO_ALARM_CONFIG();
                                            try
                                            {
                                                alarmConfig.IO_ALARM_LEVEL = tcpData.GetItemValue("IO_ALARM_LEVEL");
                                                alarmConfig.IO_ALARM_NUMBER = int.Parse(tcpData.GetItemValue("IO_ALARM_NUMBER"));
                                                alarmConfig.IO_ALARM_TYPE = tcpData.GetItemValue("IO_ALARM_TYPE");
                                                alarmConfig.IO_COMM_ID = tcpData.GetItemValue("IO_COMM_ID");
                                                alarmConfig.IO_CONDITION = tcpData.GetItemValue("IO_CONDITION");
                                                alarmConfig.IO_DEVICE_ID = tcpData.GetItemValue("IO_DEVICE_ID");
                                                alarmConfig.IO_ENABLE_MAX = int.Parse(tcpData.GetItemValue("IO_ENABLE_MAX"));
                                                alarmConfig.IO_ENABLE_MAXMAX = int.Parse(tcpData.GetItemValue("IO_ENABLE_MAXMAX"));
                                                alarmConfig.IO_ENABLE_MIN = int.Parse(tcpData.GetItemValue("IO_ENABLE_MIN"));
                                                alarmConfig.IO_ENABLE_MINMIN = int.Parse(tcpData.GetItemValue("IO_ENABLE_MINMIN"));
                                                alarmConfig.IO_ID = tcpData.GetItemValue("IO_ID");
                                                alarmConfig.IO_MAXMAX_TYPE = tcpData.GetItemValue("IO_MAXMAX_TYPE");
                                                alarmConfig.IO_MAXMAX_VALUE = int.Parse(tcpData.GetItemValue("IO_MAXMAX_VALUE"));
                                                alarmConfig.IO_MAX_TYPE = tcpData.GetItemValue("IO_MAX_TYPE");
                                                alarmConfig.IO_MAX_VALUE = int.Parse(tcpData.GetItemValue("IO_MAX_VALUE"));
                                                alarmConfig.IO_MINMIN_TYPE = tcpData.GetItemValue("IO_MINMIN_TYPE");
                                                alarmConfig.IO_MINMIN_VALUE = int.Parse(tcpData.GetItemValue("IO_MINMIN_VALUE"));
                                                alarmConfig.IO_MIN_TYPE = tcpData.GetItemValue("IO_MIN_TYPE");
                                                alarmConfig.IO_MIN_VALUE = int.Parse(tcpData.GetItemValue("IO_MIN_VALUE"));
                                                alarmConfig.IO_SERVER_ID = tcpData.GetItemValue("IO_SERVER_ID");
                                                alarmConfig.UPDATE_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                alarmConfig.UPDATE_RESULT = "true";
                                                alarmConfig.UPDATE_UID = "";
                                            }
                                            catch (Exception ex)
                                            {
                                                DisplayException(new Exception("ERROR30102  " + ex.Message));
                                                alarmConfig = null;
                                            }
                                            try
                                            {
                                                if (alarmConfig != null)
                                                {
                                                    IO_COMMUNICATION communication = null;
                                                    IO_DEVICE device = null;
                                                    IO_PARA para = null;
                                                    IO_SERVER server = IOCenterManager.IOProject.Servers.Find(x => x.SERVER_ID.Trim() == alarmConfig.IO_SERVER_ID);
                                                    if (server != null)
                                                        communication = IOCenterManager.IOProject.Communications.Find(x => x.IO_COMM_ID.Trim() == alarmConfig.IO_COMM_ID.Trim());
                                                    if (communication != null)
                                                        device = communication.Devices.Find(x => x.IO_DEVICE_ID.Trim() == alarmConfig.IO_DEVICE_ID.Trim());
                                                    if (device != null)
                                                        para = device.IOParas.Find(x => x.IO_ID.Trim() == alarmConfig.IO_ID.Trim());
                                                    if (alarmconfigBll.UserResultUpdate(alarmConfig))
                                                    {

                                                        await Task.Factory.StartNew(async a =>
                                                        {

                                                            try
                                                            {


                                                                await IOCenterManager.InfluxDbManager.DbWrite_AlarmConfigPoints(alarmConfig.IO_SERVER_ID, alarmConfig.IO_COMM_ID, alarmConfig, DateTime.Now);
                                                                AddLog("管理员更新 IO ID " + alarmConfig.IO_ID + "报警配置成功! ");

                                                                alarmConfig = null;
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                DisplayException(new Exception("ERR12134" + ex.Message));
                                                            }

                                                        }, alarmConfig);

                                                    }
                                                    else
                                                    {

                                                        AddLog("管理员更新 IO ID " + alarmConfig.IO_ID + "报警配置失败! ");
                                                        alarmConfig = null;
                                                    }



                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                DisplayException(new Exception("ERROR40105  " + ex.Message));
                                                alarmConfig = null;
                                            }


                                            tcpData.Dispose();
                                            #endregion
                                        }
                                        break;
                                    case ScadaTcpOperator.实时值:
                                        {
                                            //必须保证采集站已经是发布的，否则不能接收传递的数据
                                            if (serverClient.LogUser == null)
                                                return;
                                            byte[] contentbytes = new byte[narra.Length - 1];
                                            System.Array.Copy(narra, 1, contentbytes, 0, narra.Length - 1);
                                            RealTransform(contentbytes, contentbytes.Length, serverClient.ServerTcpClient.Client.RemoteEndPoint, serverClient.IPAddress);
                                            break;
                                        }
                                    case ScadaTcpOperator.报警值:
                                        {
                                            //必须保证采集站已经是发布的，否则不能接收传递的数据
                                            if (serverClient.LogUser == null)
                                                return;
                                            byte[] contentbytes = new byte[narra.Length - 1];
                                            System.Array.Copy(narra, 1, contentbytes, 0, narra.Length - 1);
                                            AlarmTransform(contentbytes, contentbytes.Length, serverClient.ServerTcpClient.Client.RemoteEndPoint, serverClient.IPAddress);

                                        }
                                        break;
                                    case ScadaTcpOperator.上传数据:
                                        {
                                            string IO_SERVER_ID = serverClient.TemporaryBytesKey;
                                            if (IO_SERVER_ID == "")
                                            {
                                                AddLog("发布工程失败,采集站节点不明确");

                                                TcpData sendData = new TcpData();
                                                sendData.Items.Add(new TcpDataItem() { Key = "RELUST", Value = "false" });
                                                sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "IO_SERVER_ID 不能为空" });
                                                sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = IO_SERVER_ID });

                                                this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.发布工程失败);
                                                serverClient.TemporaryByteBuffer = new List<byte[]>();
                                                serverClient.TemporaryBytesCount = 0;
                                                serverClient.TemporaryBytesKey = "";
                                                serverClient.TemporaryByteRun = false;
                                                return;

                                            }
                                            #region 接收客户度上传的数据 

                                            if (serverClient.TemporaryBytesCount > 0 && serverClient.TemporaryByteBuffer.Count < serverClient.TemporaryBytesCount)
                                            {

                                                lock (serverClient.TemporaryByteBuffer)
                                                {


                                                    byte[] contentbytes = new byte[narra.Length - 1];//存储的实际数据
                                                    System.Array.Copy(narra, 1, contentbytes, 0, narra.Length - 1);
                                                    serverClient.TemporaryByteBuffer.Add(contentbytes);//实际要存储的数据
                                                    AddLog("已经接收采集站 " + endPoint.ToString() + " 第" + (serverClient.TemporaryByteBuffer.Count) + "条数据");

                                                    TcpData sendData = new TcpData();
                                                    sendData.Items.Add(new TcpDataItem() { Key = "PROCESS", Value = (serverClient.TemporaryByteBuffer.Count + 1).ToString() });//请求接收的
                                                    sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "正在接请求接收第" + (serverClient.TemporaryByteBuffer.Count + 1).ToString() + "条数据，请耐心等待......" });
                                                    sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = "" });
                                                    this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.发布工程数据传输进度);

                                                }

                                            }

                                            //并列执行
                                            if (serverClient.TemporaryBytesCount > 0 && serverClient.TemporaryByteBuffer.Count == serverClient.TemporaryBytesCount)
                                            {
                                                serverClient.TemporaryByteRun = false;
                                                AddLog("已经全部接收采集站 " + endPoint.ToString() + "  " + serverClient.TemporaryByteBuffer.Count + "条数据,");
                                                TcpData sendData = new TcpData();
                                                sendData.Items.Add(new TcpDataItem() { Key = "PROCESS", Value = "服务器已经全部接收采" + serverClient.TemporaryByteBuffer.Count.ToString() });
                                                sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "数据中心正在解析发布数据，请耐心等待....." });
                                                sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = "" });
                                                this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.上传数据完成);

                                                Scada.Business.PublishServer mPublishServer = new Scada.Business.PublishServer();
                                                await Task.Factory.StartNew(a =>
                                             {

                                                 #region 读取字节数据，并做转换处理


                                                 AddLog("正在执行发布更新中.....");
                                                 //备份数据
                                                 List<IO_SERVER> Servers = new List<Scada.Model.IO_SERVER>();
                                                 List<IO_DEVICE> Devices = new List<Scada.Model.IO_DEVICE>();
                                                 List<IO_COMMUNICATION> Communications = new List<Scada.Model.IO_COMMUNICATION>();
                                                 List<IO_PARA> Paras = new List<Scada.Model.IO_PARA>();
                                                 List<IO_ALARM_CONFIG> ParasConfigs = new List<Scada.Model.IO_ALARM_CONFIG>();
                                                 for (int i = 0; i < serverClient.TemporaryByteBuffer.Count; i++)
                                                 {

                                                     try
                                                     {

                                                         #region 反序列化IO表参数

                                                         object receiveObject = ObjectSerialize.BytesToObjectBinaryFormatter(serverClient.TemporaryByteBuffer[i]);

                                                         if (receiveObject != null)
                                                         {
                                                             if (receiveObject is IO_SERVER)
                                                             {
                                                                 IO_SERVER server = receiveObject as IO_SERVER;
                                                                 server.SERVER_ID = IO_SERVER_ID;
                                                                 //保证采集站不能重复
                                                                 if (!Servers.Exists(x => x.SERVER_ID.Trim() == server.SERVER_ID.Trim()))
                                                                     Servers.Add(server);

                                                             }
                                                             else if (receiveObject is IO_COMMUNICATION)
                                                             {
                                                                 IO_COMMUNICATION comm = receiveObject as IO_COMMUNICATION;
                                                                 comm.IO_SERVER_ID = IO_SERVER_ID;
                                                                 //保证通讯通道不能重复
                                                                 if (!Communications.Exists(x => x.IO_COMM_ID.Trim() == comm.IO_COMM_ID.Trim() && x.IO_SERVER_ID.Trim() == comm.IO_SERVER_ID.Trim()))
                                                                     Communications.Add(comm);
                                                             }
                                                             else if (receiveObject is IO_DEVICE)
                                                             {
                                                                 IO_DEVICE device = receiveObject as IO_DEVICE;
                                                                 device.IO_SERVER_ID = IO_SERVER_ID;
                                                                 if (!Devices.Exists(x => x.IO_DEVICE_ID.Trim() == device.IO_DEVICE_ID.Trim() && x.IO_COMM_ID.Trim() == device.IO_COMM_ID.Trim() && x.IO_SERVER_ID.Trim() == device.IO_SERVER_ID.Trim()))
                                                                 {
                                                                     Devices.Add(device);

                                                                     foreach (IO_PARA c in device.IOParas)
                                                                     {
                                                                         if (!Paras.Exists(x => x.IO_DEVICE_ID.Trim() == c.IO_DEVICE_ID.Trim() && x.IO_COMM_ID.Trim() == c.IO_COMM_ID.Trim() && x.IO_SERVER_ID.Trim() == c.IO_SERVER_ID.Trim() && x.IO_ID.Trim() == c.IO_SERVER_ID.Trim()))
                                                                         {
                                                                             Paras.Add(c);

                                                                         }
                                                                         if (!ParasConfigs.Exists(x => x.IO_DEVICE_ID.Trim() == c.IO_DEVICE_ID.Trim() && x.IO_COMM_ID.Trim() == c.IO_COMM_ID.Trim() && x.IO_SERVER_ID.Trim() == c.IO_SERVER_ID.Trim() && x.IO_ID.Trim() == c.IO_SERVER_ID.Trim()))
                                                                         {
                                                                             ParasConfigs.Add(c.AlarmConfig);

                                                                         }



                                                                     }

                                                                 }

                                                             }
                                                         }
                                                         else
                                                         {
                                                             AddLog("发布工程失败,数据对象类型转换失败");

                                                             sendData = new TcpData();
                                                             sendData.Items.Add(new TcpDataItem() { Key = "RELUST", Value = "false" });
                                                             sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "服务器更新工程失败" });
                                                             sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = IO_SERVER_ID });

                                                             this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.发布工程失败);
                                                             serverClient.TemporaryByteBuffer = new List<byte[]>();
                                                             serverClient.TemporaryBytesCount = 0;
                                                             serverClient.TemporaryBytesKey = "";
                                                             serverClient.TemporaryByteRun = false;
                                                             return;
                                                         }
                                                         #endregion


                                                         //通知客户端已经接收数据了
                                                         AddLog("正在执行发布更新中.....更新进度" + (i + 1).ToString());
                                                         sendData = new TcpData();
                                                         sendData.Items.Add(new TcpDataItem() { Key = "PROCESS", Value = Convert.ToDecimal((i + 1) * 1.0 / serverClient.TemporaryByteBuffer.Count * 100).ToString("0.0") + "%" });
                                                         sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "正在更新采集站工程，请耐心等待......" });
                                                         sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = IO_SERVER_ID });

                                                         this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.发布工程进度);

                                                     }
                                                     catch (Exception ex)
                                                     {
                                                         DisplayException(new Exception("发布工程失败 ERR33022" + ex.Message));

                                                         sendData = new TcpData();
                                                         sendData.Items.Add(new TcpDataItem() { Key = "RELUST", Value = "false" });
                                                         sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "服务器更新工程失败" });
                                                         sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = IO_SERVER_ID });

                                                         this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.发布工程失败);
                                                         serverClient.TemporaryByteBuffer = new List<byte[]>();
                                                         serverClient.TemporaryBytesCount = 0;
                                                         serverClient.TemporaryBytesKey = "";
                                                         serverClient.TemporaryByteRun = false;
                                                         return;
                                                     }

                                                 }
                                                 #endregion
                                                 #region 清理缓存
                                                 serverClient.TemporaryByteBuffer = new List<byte[]>();
                                                 serverClient.TemporaryBytesCount = 0;
                                                 serverClient.TemporaryBytesKey = "";
                                                 serverClient.TemporaryByteRun = false;

                                                 #endregion
                                                 #region 初始化服务器
                                                 try
                                                 {
                                                     if (Servers.Count > 0)
                                                     {
                                                         mPublishServer.ClearServers(Servers[0].SERVER_ID);

                                                     }



                                                     if (serverBll.Add(Servers[0]))
                                                     {
                                                         //发布成功后删除旧数据
                                                         AddLog("正在清理旧的IO表信息......");

                                                         AddLog("等待更新通讯通道......");
                                                         communicationBll.Add(Communications);
                                                         AddLog("通讯更新完成!");
                                                         AddLog("等待更新设备信息......");
                                                         deviceBll.Add(Devices);
                                                         AddLog("更新设备信息完成!");

                                                         AddLog("等待更新IO表及其预警配置信息......");
                                                         paraBll.Add(Paras, ParasConfigs);
                                                         AddLog("更新IO报警配置完成!");
                                                         AddLog("正在释放相关内存空间......");
                                                         Servers.Clear();
                                                         Communications.Clear();
                                                         Devices.Clear();
                                                         Paras.Clear();

                                                         DbHelperSQLite.Compress();//释放数据库空间
                                                         AddLog("释放相关内存空间完成");
                                                         AddLog("采集站工程发布成功，准备重新启动服务器!");

                                                         serverClient.TemporaryByteBuffer = new List<byte[]>();
                                                         serverClient.TemporaryBytesCount = 0;
                                                         serverClient.TemporaryBytesKey = "";
                                                         serverClient.TemporaryResultBytesCount = 0;
                                                         AddLog("重新初始化服务器!");

                                                         sendData = new TcpData();
                                                         sendData.Items.Add(new TcpDataItem() { Key = "RELUST", Value = "true" });
                                                         sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "服务器更新工程工程成功" });
                                                         sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = IO_SERVER_ID });
                                                         this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.发布工程成功);
                                                         //重新加载指定的工程
                                                         IOCenterManager.ReloadProject(IO_SERVER_ID, serverClient.ServerTcpClient.Client.RemoteEndPoint);
                                                         AddLog("服务器更新成功!");
                                                         return;

                                                     }
                                                     else
                                                     {

                                                         sendData = new TcpData();
                                                         sendData.Items.Add(new TcpDataItem() { Key = "RELUST", Value = "false" });
                                                         sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "服务器更新工程失败" });
                                                         sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = IO_SERVER_ID });

                                                         this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.发布工程失败);
                                                         serverClient.TemporaryByteBuffer = new List<byte[]>();
                                                         serverClient.TemporaryBytesCount = 0;
                                                         serverClient.TemporaryBytesKey = "";
                                                         serverClient.TemporaryByteRun = false;
                                                         return;
                                                     }



                                                 }
                                                 catch (Exception ex)
                                                 {

                                                     DisplayException(new Exception("发布工程失败 ERR33022" + ex.Message));

                                                     sendData = new TcpData();
                                                     sendData.Items.Add(new TcpDataItem() { Key = "RELUST", Value = "false" });
                                                     sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "服务器更新工程失败" });
                                                     sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = IO_SERVER_ID });

                                                     this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.发布工程失败);
                                                     serverClient.TemporaryByteBuffer = new List<byte[]>();
                                                     serverClient.TemporaryBytesCount = 0;
                                                     serverClient.TemporaryBytesKey = "";
                                                     serverClient.TemporaryByteRun = false;
                                                     return;
                                                 }

                                                 #endregion

                                             }, mPublishServer);
                                            }



                                            #endregion
                                        }
                                        break;

                                    case ScadaTcpOperator.上传数据失败:
                                        {
                                            #region 上传数据失败
                                            serverClient.TemporaryByteBuffer = new List<byte[]>();
                                            serverClient.TemporaryBytesCount = 0;
                                            serverClient.TemporaryBytesKey = "";
                                            serverClient.TemporaryByteRun = false;

                                            #endregion
                                        }
                                        break;
                                    case ScadaTcpOperator.上传数据成功:
                                        {
                                            #region 上传数据成功
                                            AddLog("采集站数据已经全部发送完毕!");

                                            #endregion
                                        }
                                        break;
                                    case ScadaTcpOperator.上传数据开始:
                                        {
                                            #region 上传数据开始
                                            TcpData sendData = new TcpData();
                                            TcpData tcpData = new TcpData();
                                            byte[] receivebytes = new byte[narra.Length - 1];
                                            System.Array.Copy(narra, 1, receivebytes, 0, receivebytes.Length);
                                            tcpData.BytesToTcpItem(receivebytes);
                                            if (tcpData == null)
                                            {
                                                sendData = new TcpData();
                                                sendData.Items.Add(new TcpDataItem() { Key = "RELUST", Value = "false" });
                                                sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "采集站工程发布失败，未上传工程ID，无法更新工程" });
                                                sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = "" });
                                                AddLog("采集站工程发布失败，客户度未上传工程ID，无法更新工程");
                                                this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.发布工程失败);
                                                serverClient.TemporaryByteBuffer = new List<byte[]>();
                                                serverClient.TemporaryBytesCount = 0;
                                                serverClient.TemporaryBytesKey = "";
                                                serverClient.TemporaryByteRun = false;
                                                //解析字符串失败
                                                return;
                                            }

                                            string IO_SERVER_ID = tcpData.GetItemValue("IO_SERVER_ID");
                                            string NUMBER = tcpData.GetItemValue("NUMBER");

                                            serverClient.TemporaryByteBuffer = new List<byte[]>();
                                            serverClient.TemporaryBytesCount = int.Parse(NUMBER);
                                            serverClient.TemporaryBytesKey = IO_SERVER_ID;
                                            serverClient.TemporaryByteRun = true;

                                            //下发服务器等待接收的命令
                                            sendData = new TcpData();
                                            sendData.Items.Add(new TcpDataItem() { Key = "PROCESS", Value = (serverClient.TemporaryByteBuffer.Count + 1).ToString() });//请求接收的
                                            sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "正在接收工程，请耐心等待......" });
                                            sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = "" });
                                            this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.发布工程数据传输进度);
                                            #endregion
                                        }
                                        break;
                                    case ScadaTcpOperator.流程设计器登录:
                                        {
                                            try
                                            {
                                                serverClient.LogUser = null;
                                                #region 流程设计器登录
                                                TcpData tcpData = new TcpData();
                                                byte[] contentbytes = new byte[narra.Length - 1];
                                                System.Array.Copy(narra, 1, contentbytes, 0, narra.Length - 1);
                                                tcpData.BytesToTcpItem(contentbytes);
                                                if (!tcpData.IsInvalid)
                                                    return;
                                                STATION_TCP_INFO loginInfo = new STATION_TCP_INFO();
                                                try
                                                {

                                                    loginInfo.IO_SERVER_ID = tcpData.GetItemValue("IO_SERVER_ID");
                                                    //保存本地的IP
                                                    loginInfo.IO_SERVER_IP = serverClient.ServerTcpClient.Client.RemoteEndPoint.ToString();
                                                    loginInfo.PASSWROD = tcpData.GetItemValue("PASSWROD");
                                                    loginInfo.USER = tcpData.GetItemValue("USER");
                                                    loginInfo.RESULT = tcpData.GetItemValue("RESULT");
                                                    loginInfo.FUNCTION = tcpData.GetItemValue("FUNCTION");
                                                    if (loginInfo.USER.Trim() == IOCenterManager.IOProject.ServerConfig.User && loginInfo.PASSWROD.Trim() == IOCenterManager.IOProject.ServerConfig.Password)
                                                    {
                                                        if (IOCenterManager.IOProject.Servers.Exists(x => x.SERVER_ID.Trim() == loginInfo.IO_SERVER_ID.Trim()))
                                                        {
                                                            loginInfo.RESULT = "true";
                                                            loginInfo.MSG = "登录成功";


                                                        }
                                                        else
                                                        {
                                                            loginInfo.RESULT = "true";
                                                            loginInfo.MSG = "登录成功，您还没有发布采集站工程，请尽快发布工程吧！";


                                                        }
                                                        serverClient.LogUser = loginInfo;

                                                    }
                                                    else
                                                    {
                                                        loginInfo.RESULT = "false";
                                                        loginInfo.MSG = "登录失败,账户或者密码不能为空 账户密码不正确";
                                                        serverClient.LogUser = null;
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    loginInfo.RESULT = "false";
                                                    loginInfo.MSG = "登录失败 " + ex.Message;
                                                    serverClient.LogUser = null;

                                                }


                                                if (loginInfo != null)
                                                {
                                                    byte[] resultbyte = tcpData.StringToTcpByte(loginInfo.GetCommandString(), ScadaTcpOperator.流程设计器登录反馈);
                                                    this.SendData(serverClient.ServerTcpClient.Client.RemoteEndPoint, resultbyte);
                                                }


                                                tcpData.Dispose();
                                                #endregion
                                            }
                                            catch (Exception ex)
                                            {
                                                DisplayException(new Exception("ERR10021" + ex.Message));
                                            }
                                        }
                                        break;
                                    case ScadaTcpOperator.流程发布请求:
                                        {
                                            try
                                            {
                                                serverClient.LogUser = null;
                                                serverClient.TemporaryByteBuffer.Clear();
                                                #region 流程发布请求反馈
                                                TcpData tcpData = new TcpData();
                                                byte[] contentbytes = new byte[narra.Length - 1];
                                                System.Array.Copy(narra, 1, contentbytes, 0, narra.Length - 1);
                                                tcpData.BytesToTcpItem(contentbytes);
                                                if (!tcpData.IsInvalid)
                                                    return;

                                                try
                                                {
                                                    string IO_SERVER_ID = tcpData.GetItemValue("IO_SERVER_ID");
                                                    string PROJECTID = tcpData.GetItemValue("PROJECTID");


                                                    string RESULT = tcpData.GetItemValue("RESULT");
                                                    string MSG = tcpData.GetItemValue("MSG");
                                                    if (IO_SERVER_ID != "" && IO_SERVER_ID == MAC)
                                                    {
                                                        tcpData.GetItem("RESULT").Value = "true";
                                                        tcpData.GetItem("MSG").Value = "数据中心允许发布流程，请进一步操作";
                                                    }
                                                    else
                                                    {
                                                        tcpData.GetItem("RESULT").Value = "false";
                                                        tcpData.GetItem("MSG").Value = "发布的流程设计器工程只能在对应的采集站发布";
                                                    }

                                                }
                                                catch
                                                {
                                                    tcpData.GetItem("RESULT").Value = "false";
                                                    tcpData.GetItem("MSG").Value = "发布的流程设计器工程只能在对应的采集站发布";


                                                }


                                                if (tcpData != null)
                                                {
                                                    byte[] resultbyte = tcpData.StringToTcpByte(tcpData.TcpItemToString(), ScadaTcpOperator.流程发布请求反馈);
                                                    this.SendData(serverClient.ServerTcpClient.Client.RemoteEndPoint, resultbyte);
                                                }


                                                tcpData.Dispose();
                                                #endregion
                                            }
                                            catch (Exception ex)
                                            {
                                                DisplayException(new Exception("ERR10021" + ex.Message));
                                            }
                                        }
                                        break;
                                    case ScadaTcpOperator.流程发布准备:
                                        {
                                            #region 上传数据开始
                                            TcpData sendData = new TcpData();
                                            TcpData tcpData = new TcpData();
                                            byte[] receivebytes = new byte[narra.Length - 1];
                                            System.Array.Copy(narra, 1, receivebytes, 0, receivebytes.Length);
                                            tcpData.BytesToTcpItem(receivebytes);
                                            if (tcpData == null)
                                            {
                                                sendData = new TcpData();
                                                sendData.Items.Add(new TcpDataItem() { Key = "RELUST", Value = "false" });
                                                sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "流程发布失败，未上传工程ID，无法发布流程" });
                                                sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = "" });
                                                AddLog("流程发布失败，客户度未上传工程ID，无法更新工程");
                                                this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.流程发布失败);
                                                serverClient.TemporaryByteBuffer = new List<byte[]>();
                                                serverClient.TemporaryBytesCount = 0;
                                                serverClient.TemporaryBytesKey = "";
                                                serverClient.TemporaryByteRun = false;
                                                serverClient.TemporaryResultBytesCount = 0;
                                                //解析字符串失败
                                                return;
                                            }

                                            string IO_SERVER_ID = tcpData.GetItemValue("IO_SERVER_ID");
                                            string NUMBER = tcpData.GetItemValue("NUMBER");
                                            string BYTENUMBER = tcpData.GetItemValue("BYTENUMBER");
                                            serverClient.TemporaryByteBuffer = new List<byte[]>();
                                            serverClient.TemporaryBytesCount = int.Parse(NUMBER);
                                            serverClient.TemporaryResultBytesCount = int.Parse(BYTENUMBER);
                                            serverClient.TemporaryBytesKey = IO_SERVER_ID;
                                            serverClient.TemporaryByteRun = true;
                                            //下发命令获取第一组数据
                                            sendData = new TcpData();
                                            sendData.Items.Add(new TcpDataItem() { Key = "PROCESS", Value = (1).ToString() });//请求接收的
                                            sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "正在接收客户端流程图工程，请耐心等待......" });
                                            sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = "" });
                                            this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.流程发布传输进度);
                                            #endregion
                                        }
                                        break;
                                    case ScadaTcpOperator.流程发布成功:
                                        {
                                            #region 上传数据失败
                                            AddLog("采集站流程图已经全部发送完毕!");

                                            #endregion
                                        }
                                        break;
                                    case ScadaTcpOperator.流程发布失败:
                                        {
                                            #region 上传数据失败
                                            #region 上传数据失败
                                            serverClient.TemporaryByteBuffer = new List<byte[]>();
                                            serverClient.TemporaryBytesCount = 0;
                                            serverClient.TemporaryBytesKey = "";
                                            serverClient.TemporaryByteRun = false;

                                            #endregion
                                            AddLog("采集站流程图上传失败!");

                                            #endregion
                                        }
                                        break;
                                    case ScadaTcpOperator.流程发布数据:
                                        {
                                            string IO_SERVER_ID = serverClient.TemporaryBytesKey;
                                            if (IO_SERVER_ID == "")
                                            {
                                                AddLog("发布工程失败,采集站节点不明确");

                                                TcpData sendData = new TcpData();
                                                sendData.Items.Add(new TcpDataItem() { Key = "RELUST", Value = "false" });
                                                sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "IO_SERVER_ID 不能为空" });
                                                sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = IO_SERVER_ID });

                                                this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.流程发布失败);
                                                serverClient.TemporaryByteBuffer = new List<byte[]>();
                                                serverClient.TemporaryBytesCount = 0;
                                                serverClient.TemporaryBytesKey = "";
                                                serverClient.TemporaryByteRun = false;
                                                return;

                                            }
                                            #region 接收客户度上传的数据 

                                            if (serverClient.TemporaryBytesCount > 0 && serverClient.TemporaryByteBuffer.Count < serverClient.TemporaryBytesCount)
                                            {

                                                lock (serverClient.TemporaryByteBuffer)
                                                {


                                                    byte[] contentbytes = new byte[narra.Length - 1];//存储的实际数据
                                                    System.Array.Copy(narra, 1, contentbytes, 0, narra.Length - 1);
                                                    serverClient.TemporaryByteBuffer.Add(contentbytes);//实际要存储的数据
                                                    AddLog("接收采集站流程图 " + endPoint.ToString() + " 第" + ((serverClient.TemporaryByteBuffer.Count + 1)) + "条数据");

                                                    TcpData sendData = new TcpData();
                                                    sendData.Items.Add(new TcpDataItem() { Key = "PROCESS", Value = ((serverClient.TemporaryByteBuffer.Count + 1)).ToString() });//请求接收的
                                                    sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "正在接收客户端流程图工程，请耐心等待......" });
                                                    sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = "" });
                                                    this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.流程发布传输进度);
                                                }

                                            }

                                            //并列执行
                                            if (serverClient.TemporaryBytesCount > 0 && serverClient.TemporaryByteBuffer.Count == serverClient.TemporaryBytesCount)
                                            {
                                                TcpData sendData = new TcpData();
                                                sendData.Items.Add(new TcpDataItem() { Key = "PROCESS", Value = "服务器已经全部接收流程图" + serverClient.TemporaryByteBuffer.Count.ToString() });
                                                sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "流程图正在解析发布，请耐心等待....." });
                                                sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = "" });
                                                List<byte> allbytes = new List<byte>();
                                                for (int i = 0; i < serverClient.TemporaryByteBuffer.Count; i++)
                                                {
                                                    allbytes.AddRange(serverClient.TemporaryByteBuffer[i]);
                                                }
                                                if (allbytes.Count < serverClient.TemporaryResultBytesCount)
                                                {
                                                    AddLog("数据接收不完整，发布失败 应接收  " + serverClient.TemporaryResultBytesCount + "个字节，实际接收" + allbytes.Count + "字节,");
                                                    this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.流程发布失败);
                                                    return;
                                                }
                                                serverClient.TemporaryByteRun = false;
                                                AddLog("已经接收采集站流程图 " + endPoint.ToString() + "  " + serverClient.TemporaryByteBuffer.Count + "条数据,");

                                                await Task.Run(() =>
                                                {


                                                    try
                                                    {
                                                        long tempid = GUIDTo16.GuidToLongID();
                                                        StreamWriter sw = new StreamWriter(Application.StartupPath + "/temp/flowtemp" + tempid + ".svg", true, Encoding.UTF8);
                                                        sw.Write(System.Text.Encoding.Default.GetString(allbytes.ToArray()));
                                                        sw.Close();
                                                        ScadaFlowProject projectModel = null;
                                                        List<ScadaFlowView> Views = new List<ScadaFlowView>();
                                                        ScadaFlowView view = null;
                                                        StringBuilder viewSvg = new StringBuilder();
                                                        StreamReader sr = new StreamReader(Application.StartupPath + "/temp/flowtemp" + tempid + ".svg", Encoding.UTF8);
                                                        while (!sr.EndOfStream)
                                                        {
                                                            var strLine = sr.ReadLine().Trim();
                                                            if (strLine == "")
                                                                continue;
                                                            if (strLine.IndexOf("--PROJ") == 0)
                                                            {
                                                                projectModel = new ScadaFlowProject();
                                                                projectModel.CreateDate = DateTime.Now.ToString("yyyy-MM-dd");
                                                                projectModel.ServerID = MAC;
                                                                projectModel.Title = strLine.Split('#')[2];
                                                                projectModel.ProjectId = strLine.Split('#')[1];
                                                                Views = new List<ScadaFlowView>();
                                                            }
                                                            else if (strLine.IndexOf("--VIEW") == 0)
                                                            {
                                                                if (projectModel != null)
                                                                {
                                                                    view = new ScadaFlowView();
                                                                    view.ViewSb = new StringBuilder();
                                                                    view.ProjectId = projectModel.ProjectId.Trim();
                                                                    view.IsIndex = strLine.Split('#')[3].Trim();
                                                                    view.ViewTitle = strLine.Split('#')[2].Trim();
                                                                    view.ViewId = strLine.Split('#')[1].Trim();
                                                                    view.ViewSVG = "";
                                                                    Views.Add(view);
                                                                }

                                                            }
                                                            else if (strLine.IndexOf("--ENDVIEW") == 0)
                                                            {
                                                                if (projectModel != null && view != null)
                                                                {
                                                                    view.ViewSVG = view.ViewSb.ToString();
                                                                    view = new ScadaFlowView();
                                                                }

                                                            }
                                                            else if (strLine.IndexOf("--USER") == 0)//获取用户工程中的USER
                                                            {
                                                                if (projectModel != null)
                                                                {
                                                                    //对用户密码进行加密
                                                                    string nikename = strLine.Split('#')[1].Trim();
                                                                    string username = strLine.Split('#')[2].Trim();
                                                                    string password = strLine.Split('#')[3].Trim();
                                                                    string read = strLine.Split('#')[4].Trim();
                                                                    string write = strLine.Split('#')[5].Trim();
                                                                    string str = "{nikename:'" + nikename + "',username:'" + username + "',password:'" + DESEncrypt.Encrypt(password) + "',read:'" + read + "',write:'" + write + "'}";
                                                                    projectModel.FlowUser += projectModel.FlowUser == "" ? str : "," + str;

                                                                }

                                                            }
                                                            else if (strLine.IndexOf("--ENDUSER") == 0)
                                                            {
                                                                if (projectModel != null && view != null)
                                                                {
                                                                    view.ViewSVG = view.ViewSb.ToString();
                                                                    view = new ScadaFlowView();
                                                                }

                                                            }
                                                            else
                                                            {
                                                                view.ViewSb.AppendLine(strLine);
                                                            }

                                                        }
                                                        sr.Close();


                                                        Scada.Business.ScadaFlowProject projectBll = new Scada.Business.ScadaFlowProject();
                                                        Scada.Business.ScadaFlowView viewBll = new Scada.Business.ScadaFlowView();
                                                        bool res = false;
                                                        if (Views.Count > 0)
                                                        {
                                                            if (projectBll.Exists(projectModel.ProjectId.Trim()))
                                                            {
                                                                res = projectBll.UpdateFromProjectId(projectModel);
                                                            }
                                                            else
                                                            {
                                                                res = projectBll.Add(projectModel) > 0 ? true : false;
                                                            }
                                                            if (res)
                                                            {
                                                                viewBll.Delete(projectModel.ProjectId.Trim());
                                                                for (int i = 0; i < Views.Count; i++)
                                                                {
                                                                    if (Views[i].ViewSVG.Trim() != "")
                                                                        viewBll.Add(Views[i]);
                                                                }
                                                            }
                                                            AddLog("流程图发布完毕 " + endPoint.ToString() + " ");
                                                            this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.流程发布成功);

                                                        }
                                                        else
                                                        {
                                                            AddLog("流程图发布失败 " + endPoint.ToString() + " 没有要发布的视图");
                                                            sendData.GetItem("MSG").Value = "没有要发布的视图";
                                                            this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.流程发布失败);

                                                        }

                                                    }
                                                    catch (Exception emx)
                                                    {
                                                        AddLog("流程图发布失败 " + endPoint.ToString() + " " + emx.Message);
                                                        sendData.GetItem("MSG").Value = emx.Message;
                                                        this.SendData(endPoint, sendData.TcpItemToString(), ScadaTcpOperator.流程发布失败);

                                                    }
                                                });
                                            }



                                            #endregion
                                        }
                                        break;
                                    case ScadaTcpOperator.下置命令://接收到Web端下置命令
                                        {
                                            #region 下置命令
                                            try
                                            {
                                                byte[] contentbytes = new byte[narra.Length - 1];
                                                System.Array.Copy(narra, 1, contentbytes, 0, narra.Length - 1);
                                                TcpData tcpData = new TcpData();
                                                tcpData.BytesToTcpItem(contentbytes);
                                                string serverId = tcpData.GetItemValue("IO_SERVER_ID");
                                                IO_SERVER server = IOCenterManager.IOProject.Servers.Find(x => x.SERVER_ID.Trim().ToLower() == serverId.Trim().ToLower());
                                               
                                                if (server != null && server.MonitorEndPoint != null)
                                                {
                                                    bool res = this.SendData(server.MonitorEndPoint, contentbytes);
                                                    AddLog("Web端向采集站" + server.SERVER_IP + "发送下置命令" + tcpData.TcpItemToString());
                                                    if (ServerForm != null && !ServerForm.IsDisposed)
                                                    {
                                                        IO_COMMANDS command = new IO_COMMANDS()
                                                        {
                                                            COMMAND_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                                            COMMAND_ID = tcpData.GetItemValue("COMMAND_ID"),
                                                            COMMAND_RESULT = res.ToString().ToLower(),
                                                            COMMAND_USER = tcpData.GetItemValue("COMMAND_USER"),
                                                            COMMAND_VALUE = tcpData.GetItemValue("COMMAND_VALUE"),
                                                            IO_COMM_ID = tcpData.GetItemValue("IO_COMM_ID"),
                                                            IO_DEVICE_ID = tcpData.GetItemValue("IO_DEVICE_ID"),
                                                            IO_ID = tcpData.GetItemValue("IO_ID"),
                                                            IO_LABEL = tcpData.GetItemValue("IO_LABEL"),
                                                            IO_NAME = tcpData.GetItemValue("IO_NAME"),
                                                            IO_SERVER_ID = tcpData.GetItemValue("IO_SERVER_ID")
                                                        };
                                                        IO_COMMUNICATION common = IOCenterManager.IOProject.Communications.Find(x => x.IO_SERVER_ID.Trim().ToLower() == serverId.Trim().ToLower() && x.IO_COMM_ID== command.IO_COMM_ID);
                                                        IO_DEVICE device = IOCenterManager.IOProject.Devices.Find(x => x.IO_SERVER_ID.Trim().ToLower() == serverId.Trim().ToLower() && x.IO_COMM_ID == command.IO_COMM_ID && x.IO_DEVICE_ID == command.IO_DEVICE_ID);
                                                        if (common != null && device != null)
                                                        {
                                                       //由于真是的IoMonitor的终端连接是绑定在监视器的TreeView TreeNode 上,后期可以改到
                                                        ServerForm.AddCommand(server.MonitorEndPoint, command.IO_SERVER_ID, common.IO_COMM_NAME + "[" + common.IO_COMM_LABEL + "]", device.IO_DEVICE_NAME + "[" + device.IO_DEVICE_LABLE + "]", command.IO_NAME + "[" + command.IO_LABEL + "]", command);
                                                        }
                                                       
                                                    }
                                                }
                                            }
                                            catch (Exception emx)
                                            {
                                                DisplayException(emx);
                                            }
                                            #endregion

                                        }
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                DisplayException(new Exception("ERR10022" + ex.Message));
                            }
                        }
                    }

                }

                #endregion
            }
            catch
            {
            }
        }

        Scada.Business.IO_ALARM_CONFIG alarmConfigBll = new Scada.Business.IO_ALARM_CONFIG();
        Scada.Business.IO_COMMUNICATION communicationBll = new Scada.Business.IO_COMMUNICATION();
        Scada.Business.IO_DEVICE deviceBll = new Scada.Business.IO_DEVICE();
        Scada.Business.IO_PARA paraBll = new Scada.Business.IO_PARA();
        Scada.Business.IO_SERVER serverBll = new Scada.Business.IO_SERVER();

        private async void RealTransform(byte[] sourcebytes, int count, EndPoint endPoint, IPAddress address)
        {
            try
            {
                // 单独处理每个分包数据
                #region 处理采集器端传递的实时值

                string allString = Encoding.UTF8.GetString(sourcebytes, 0, sourcebytes.Length);
                if (allString.Trim() == "")
                    return;

                List<string> recSources = allString.Split(new char[1] { '^' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (recSources.Count <= 0)
                {
                    return;
                }
                recSources.ForEach(delegate (string source)
                {
                    TcpData tcpData = new TcpData();
                    byte[] narra = Encoding.UTF8.GetBytes(source);
                    tcpData.BytesToTcpItem(narra);
                    string TcpDataString = "";
                    bool IsInvalid = false;
                    if (tcpData != null)
                    {
                        IsInvalid = tcpData.IsInvalid;
                        TcpDataString = tcpData.TcpDataString;
                    }
                    if (IsInvalid == false)
                    {
                        AddLog("数据单元无效，无法入库");
                        if (tcpData != null)
                        {
                            tcpData.Dispose();
                        }

                        return;
                    }
                    //处理实时值并将数据写入influx
                    string server_id = tcpData.GetItemValue("IO_SERVER_ID");
                    string communication_id = tcpData.GetItemValue("IO_COMM_ID");
                    string device_id = tcpData.GetItemValue("IO_DEVICE_ID");
                    //传递是unix时间戳
                    if (server_id == "" || communication_id == "" || device_id == "")
                        return;
                    string date = tcpData.GetItemValue("DATE");
                    long dateunix = 0;
                    DateTime? device_date = null;
                    try
                    {
                        if (date != "" && long.TryParse(date, out dateunix))
                        {
                            device_date = UnixDateTimeConvert.ConvertIntDateTime(long.Parse(date));
                        }
                        else
                        {
                            device_date = DateTime.Now;
                        }
                    }
                    catch (Exception ex)
                    {
                        device_date = null;
                        DisplayException(new Exception("ERR10023" + ex.Message));
                    }

                    if (server_id != "ERROR" && communication_id != "ERROR" && device_id != "ERROR")
                    {
                        #region 构造同样的三个类，主要防止多线程对原来数据修改导致错误
                        IO_SERVER server = null;
                        IO_DEVICE device = null;
                        IO_COMMUNICATION communication = null;
                        lock (server_id)
                        {
                            IO_SERVER exserver = IOCenterManager.IOProject.Servers.Find(x => x.SERVER_ID.Trim() == server_id.Trim());
                            IO_COMMUNICATION excommunication = IOCenterManager.IOProject.Communications.Find(x => x.IO_COMM_ID.Trim() == communication_id.Trim());
                            if (excommunication == null)
                                return;
                            IO_DEVICE exdevice = excommunication.Devices.Find(x => x.IO_DEVICE_ID == device_id);
                            if (exserver == null)
                                return;
                            if (exdevice == null)
                                return;
                            server = exserver.Copy();
                            communication = excommunication.Copy();
                            device = exdevice.Copy();
                        }
                        #endregion
                        if (device != null && device.IOParas != null && device.IOParas.Count > 0)
                        {



                            device.GetedValueDate = device_date;
                            for (int i = 0; i < device.IOParas.Count; i++)
                            {
                                string itemValue = tcpData.GetItemValue(device.IOParas[i].IO_NAME);
                                if (itemValue != null && itemValue != "" && itemValue != "ERROR")
                                {
                                    if (device != null)
                                    {
                                        string[] vs = itemValue.Split('|');
                                        device.IOParas[i].IORealData = new Scada.IOStructure.IOData();


                                        if (vs.Length > 0)
                                            device.IOParas[i].IORealData.ID = itemValue.Split('|')[0];
                                        else
                                            device.IOParas[i].IORealData.ID = device.IOParas[i].IO_ID;

                                        device.IOParas[i].IORealData.ServerID = device.IO_SERVER_ID;
                                        device.IOParas[i].IORealData.Date = device_date;
                                        device.IOParas[i].IORealData.ParaName = device.IOParas[i].IO_NAME;

                                        if (vs.Length > 1)
                                            device.IOParas[i].IORealData.ParaValue = itemValue.Split('|')[1];
                                        else
                                            device.IOParas[i].IORealData.ParaValue = "-9999";

                                        if (device.IOParas[i].IORealData.ParaValue.Trim() == "")
                                            device.IOParas[i].IORealData.ParaValue = "-9999";
                                        QualityStamp qs = QualityStamp.BAD;

                                        if (vs.Length > 2)
                                        {
                                            if (Enum.TryParse(itemValue.Split('|')[2], out qs))
                                                device.IOParas[i].IORealData.QualityStamp = qs;
                                            else
                                                device.IOParas[i].IORealData.QualityStamp = QualityStamp.BAD;
                                        }
                                        else
                                            device.IOParas[i].IORealData.QualityStamp = QualityStamp.BAD;
                                        if (device.IOParas[i].IORealData.ParaValue.Trim() == "-9999")
                                            device.IOParas[i].IORealData.QualityStamp = QualityStamp.BAD;
                                    }
                                }



                            }

                            try
                            {
                                if (device != null && communication != null && server != null)
                                {
                                    if (RealCache != null)
                                    {
                                        //将接收到的数据保存到缓存,通过缓存定时批量写入，每次写入不超过1000条的数据，主要为了提高效率
                                        RealCache.Push(new ReceiveCacheObject()
                                        {
                                            communication = communication,
                                            device = device,
                                            RealDate = device_date,
                                        });
                                    }
                                    if (ServerForm != null && !ServerForm.IsDisposed)
                                    {
                                        ServerForm.AddReeiveDevice(endPoint, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), server.SERVER_NAME, communication.IO_COMM_NAME, device.IO_DEVICE_NAME, TcpDataString, true);
                                    }


                                }

                            }
                            catch (Exception ex)
                            {
                                if (ServerForm != null && !ServerForm.IsDisposed)
                                {
                                    ServerForm.AddReeiveDevice(endPoint, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), server.SERVER_NAME, communication.IO_COMM_NAME, device.IO_DEVICE_NAME, TcpDataString, false);
                                    ServerForm.AddReport(endPoint, "ERROR10014" + ex.Message);
                                }



                            }

                            try
                            {

                                if (ServerForm != null && !ServerForm.IsDisposed)
                                {
                                   
                                        ServerForm.DeviceStatus(server.SERVER_ID, device, true);

                                    
                                }
                            }
                            catch (Exception ex)
                            {
                                 
                                    DisplayException(new Exception("ERR10015" + ex.Message));
                              
                            }
                        }



                    }
                });
                #endregion
            }
            catch
            {

            }

        }
        private async void AlarmTransform(byte[] sourcebytes, int count, EndPoint endPoint, IPAddress address)
        {
            try
            {

                // 单独处理每个分包数据
                #region 处理采集器端传递的实时值



                string allString = Encoding.UTF8.GetString(sourcebytes, 0, sourcebytes.Length);
                if (string.IsNullOrEmpty(allString))
                {
                    return;
                }

                List<string> resStrings = allString.Split(new char[1] { '^' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                resStrings.ForEach(delegate (string source)
                {
                    TcpData tcpData = new TcpData();
                    byte[] narra = Encoding.UTF8.GetBytes(source);
                    tcpData.BytesToTcpItem(narra);
                    string TcpDataString = "";
                    bool IsInvalid = false;
                    if (tcpData != null)
                    {
                        IsInvalid = tcpData.IsInvalid;
                        TcpDataString = tcpData.TcpDataString;
                    }
                    if (IsInvalid == false)
                    {
                        AddLog("报警数据单元无效，无法入库");
                        if (tcpData != null)
                        {
                            tcpData.Dispose();
                        }

                        return;
                    }
                    //处理实时值并将数据写入influx
                    string server_id = tcpData.GetItemValue("IO_SERVER_ID");
                    string communication_id = tcpData.GetItemValue("IO_COMM_ID");
                    string device_id = tcpData.GetItemValue("IO_DEVICE_ID");
                    if (server_id == "" || communication_id == "" || device_id == "")
                        return;
                    IO_PARAALARM paraAlarm = null;
                    try
                    {
                        paraAlarm = new IO_PARAALARM();
                        paraAlarm.IO_ALARM_DATE = tcpData.GetItemValue("IO_ALARM_DATE").Replace("//", "#").Replace("\\", ":");
                        paraAlarm.IO_COMM_ID = tcpData.GetItemValue("IO_COMM_ID");
                        paraAlarm.IO_DEVICE_ID = tcpData.GetItemValue("IO_DEVICE_ID");
                        paraAlarm.IO_ID = tcpData.GetItemValue("IO_ID");

                        paraAlarm.IO_ALARM_LEVEL = tcpData.GetItemValue("IO_ALARM_LEVEL");
                        paraAlarm.IO_ALARM_VALUE = tcpData.GetItemValue("IO_ALARM_VALUE");
                        paraAlarm.IO_ALARM_TYPE = tcpData.GetItemValue("IO_ALARM_TYPE");
                        paraAlarm.IO_LABEL = tcpData.GetItemValue("IO_LABEL");
                        paraAlarm.IO_NAME = tcpData.GetItemValue("IO_NAME");

                    }
                    catch (Exception ex)
                    {

                        DisplayException(new Exception("ERR20015" + ex.Message));
                        return;
                    }
                    if (paraAlarm == null)
                        return;
                    if (server_id != "ERROR" && communication_id != "ERROR" && device_id != "ERROR")
                    {
                        IO_SERVER exserver = IOCenterManager.IOProject.Servers.Find(x => x.SERVER_ID.Trim() == server_id.Trim());
                        if (exserver == null)
                            return;
                        IO_SERVER server = exserver.Copy();
                        #region 构造同样的三个类，主要防止多线程对原来数据修改导致错误

                        IO_COMMUNICATION excommunication = IOCenterManager.IOProject.Communications.Find(x => x.IO_COMM_ID.Trim() == communication_id.Trim());
                        if (excommunication == null)
                            return;
                        IO_COMMUNICATION communication = excommunication.Copy();
                        //由于设备比较多，应该构造一个Device ,提高效率\
                        IO_DEVICE existdevice = excommunication.Devices.Find(x => x.IO_DEVICE_ID == device_id);
                        if (existdevice == null)
                            return;
                        IO_DEVICE device = existdevice.Copy();
                        try
                        {
                            if (device != null && communication != null && server != null)
                            {
                                paraAlarm.DEVICE_NAME = device.IO_DEVICE_NAME;

                                if (RealCache != null && !string.IsNullOrEmpty(paraAlarm.IO_ALARM_DATE))
                                {
                                    //将接收到的数据保存到缓存,通过缓存定时批量写入，每次写入不超过1000条的数据，主要为了提高效率
                                    RealCache.Push(new AlarmCacheObject()
                                    {
                                        communication = communication,
                                        device = device,
                                        Alarm = paraAlarm

                                    });
                                }
                                IOCenterManager.TCPServer.ServerForm.AddReeiveAlarm(endPoint, server.SERVER_NAME, communication.IO_COMM_NAME, device.IO_DEVICE_NAME, paraAlarm, true);

                            }

                        }
                        catch (Exception ex)
                        {
                            if (ServerForm != null && !ServerForm.IsDisposed)
                            {
                                ServerForm.AddReeiveAlarm(endPoint, server.SERVER_NAME, communication.IO_COMM_NAME, device.IO_DEVICE_NAME, paraAlarm, false);
                                ServerForm.AddReport(endPoint, "ERROR20014" + ex.Message);
                            }
                        }

                        try
                        {
                            if (ServerForm != null && !ServerForm.IsDisposed)
                            {
                                if (device != null)
                                {
                                    ServerForm.DeviceStatus(server.SERVER_ID, device, true);

                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            DisplayException(new Exception("ERR20015" + ex.Message));

                        }




                        #endregion
                    }
                });
                #endregion
            }
            catch
            {

            }

        }

        private void InfluxDb_InfluxException(Exception ex)
        {
            DisplayException(new Exception("ERR20001" + ex.Message));
        }

        /// <summary>
        /// 停止
        /// </summary>
        public   async Task Stop()
        {
            
                if (TcpServerStatus == TcpServerStatus.运行)
                {
                    try
                    {
                        if (Server != null)
                        {
                            await Task.Delay(2 * 1000);
                            Server.Stop(true);
                            Server = null;
                            GC.Collect();
                        }
                        TcpServerStatus = TcpServerStatus.停止;
                    }
                    catch (Exception ex)
                    {
                        AddLog("ERROR10016  停止服务失败 " + ex.Message);
                    }
                }
            

        }
        /// <summary>
        /// 启动
        /// </summary>
        public async Task Start()
        {
            if (TcpServerStatus == TcpServerStatus.停止)
            {
                try
                {

                    await RunAsync(int.Parse(IOCenterManager.IOProject.ServerConfig.LocalPort));
                    TcpServerStatus = TcpServerStatus.运行;
                     await UpdateIOAlarmConfig();
                    AddLog("启动服务成功");

                  

                }
                catch (Exception ex)
                {
                    DisplayException(new Exception("ERR10017" + ex.Message));
                }
            }


            if (ServerForm != null && !ServerForm.IsDisposed)
            {
                if (ServerForm.Visible == false)
                    ServerForm.Visible = true;
                //启动服务
                
            }
            else
            {
                MonitorForm form = new MonitorForm();
                SetMonitorForm(form);
                form.Show();
                await Task.Run(() =>
                {
                    form.InitIOTree();
                });
          
            }



        }
        public void Pause()
        {
            TcpServerStatus = TcpServerStatus.暂停;
        }
        public void Continue()
        {
            TcpServerStatus = TcpServerStatus.运行;
        }

        private   void Server_TCPExceptionEvent(Exception ex)
        {
            DisplayException(ex);
        }

        private   void Server_Message(object sender, AsyncTcpEventArgs e)
        {
            AddLog(e.Message);
        }
        #region 主窗体进度条
        /// <summary>
        /// 初始化进度条
        /// </summary>
        /// <param name="MaxValue"></param>
        public void InitProgress(int MaxValue)
        {
            if(ServerForm!=null&& !ServerForm.IsDisposed)
            {
                ServerForm.ProgressBar.Value = 0;
                ServerForm.ProgressBar.Maximum = MaxValue;
                ServerForm.ProgressBar.Text = "";
            }

          
        }
        public void EndProgress()
        {
            if (ServerForm != null && !ServerForm.IsDisposed)
            {
                ServerForm.ProgressBar.Value = 0;
                ServerForm.ProgressBar.Maximum = 100;
                ServerForm.ProgressBar.Text = "";
            }

       
        }
        /// <summary>
        /// 进度
        /// </summary>
        public void SetProgress()
        {
            if (ServerForm != null && !ServerForm.IsDisposed)
            {

                if (ServerForm.ProgressBar.Value + 1 == ServerForm.ProgressBar.Maximum)
                {
                    ServerForm.ProgressBar.Value++;
                    EndProgress();
                    ServerForm.ProgressBar.Text = "任务完成";
                }
                else
                {
                    ServerForm.ProgressBar.Value++;
                    ServerForm.ProgressBar.Text = (ServerForm.ProgressBar.Value * 100.0f / ServerForm.ProgressBar.Maximum).ToString("0.0");
                }
            }

        }
        #endregion
    }
}
