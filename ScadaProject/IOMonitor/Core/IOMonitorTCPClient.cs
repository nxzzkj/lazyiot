using Scada.AsyncNetTcp;
using Scada.AsyncNetTcp.Net;
 
using System;

using System.Net;
using System.Text;

using System.Threading.Tasks;
using Scada.DBUtility;
using Scada.Model;
using Scada.Kernel;

namespace IOMonitor.Core
{



    public  class IOMonitorTCPClient : ScadaTask
    {
      
        public bool IsClientConnected
        {
            get {

                if(Client!=null)
                {
                    if (Client.IsClosing)
                        return false;
                    else
                        return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 是否关闭
        /// </summary>
        public bool IsClosed
        {
            get
            {

                if (Client != null)
                {
                    if (Client.IsClosing)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public  IOConfig ClientConfig = null;
         public AsyncTcpClient Client = null;
      
        /// <summary>
        /// 用户登录后反馈事件
        /// </summary>
        public  event TcpClientEventHandle OnUserLogined;
        /// <summary>
        /// 客户端连接到服务器的事件
        /// </summary>
        public event  TcpClientEventHandle OnConnectedServer;
        /// <summary>
        /// 端口连接的事件
        /// </summary>
        public event  TcpClientEventHandle OnDisConnectedServer;


        public event MonitorException OnExceptionHanped;
        public event MonitorLog OnTCPClientLoged;



        #region 异常处理，统一都输出到主任何界面
        private   void AddLogToMainLog(string msg)
        {
            if (OnTCPClientLoged != null)
            {
                OnTCPClientLoged(msg);
            }

        }
        /// <summary>
        /// 异常信息在日志端显示
        /// </summary>
        /// <param name="ex"></param>
        private void ThrowExceptionToMain(Exception ex)
        {
            if(OnExceptionHanped!=null)
            {
                OnExceptionHanped(ex);
            }
          
        }


        #endregion
        /// <summary>
        /// 通过将类直接与回调方法一起使用来演示客户端和服务器。IPAddress.IPv6Loopback
        /// </summary>
        /// <returns></returns>
        private async Task RunAsync(int port, IPAddress remoteIp)
        {

            Client = new AsyncTcpClient
            {
                IPAddress = remoteIp,
                Port = port,
                 ScadaClientType= ScadaClientType.IoMonitor,
                AutoReconnect = true,
                ConnectedCallback = async (c, isReconnected) =>
                {
                    if (!c.IsClosing)
                    {
                        if (OnConnectedServer != null)
                        {
                            OnConnectedServer(c, true, "连接服务器成功");
                        }
                        await c.WaitAsync();   // 等待服务器
                                               //连接到服务器后向服务器发送心跳握手数据               


                    }
                },
                ClosedCallback = (c, isReconnected) =>
                {
                    if (c.IsClosing)
                    {
                        if (OnDisConnectedServer != null)
                        {
                            OnDisConnectedServer(c, true, "与服务器连接断开!");
                            
                        }

                    }
                },
                ReceivedCallback = (c, count) =>
                {
                    #region
                    ///原始数据包，有可能是粘包在一起，所以要单独处理
                    byte[] receivebytes = c.ByteBuffer.Dequeue(count);
                    //如果获取的是空数据，则结束任务
                    if (receivebytes.Length <= 0)
                        return Task.CompletedTask;
                    if (c.UsedPackageIdentification)
                    {
                        string MAC = "";
                        string msg = "";
                        SplitPakeage splitPakeage = new SplitPakeage();
                        byte[] realbytes = splitPakeage.RemoveIdentificationBytes(receivebytes, c, out MAC,out msg);

                        //获取解析后的数据体如果为0，则不做任何处理
                        if (realbytes.Length <= 0)
                            return Task.CompletedTask;
                        if (realbytes.Length <= 0)
                            return Task.CompletedTask;

                        try
                        {
                            Task.Run(() =>
                            {
                                //处理数据体
                                SplitReceivePack(realbytes, realbytes.Length, c);
                            });

                        }
                        catch (Exception ex)
                        {
                            ThrowExceptionToMain(new Exception("ERR10025" + ex.Message));
                        }

                    }
                    #endregion
                    return Task.CompletedTask;

                }
            };
            Client.Message += Client_Message;
            Client.TCPExceptionEvent += Client_TCPExceptionEvent;
            var clientTask = Client.RunAsync();
            TaskManager.Add(clientTask);
        }
        Scada.Business.IO_ALARM_CONFIG alarmconfigBll = new Scada.Business.IO_ALARM_CONFIG();
        /// <summary>
        /// 传入的是实际的数据包，并不包含头标识和尾标识
        /// </summary>
        /// <param name="receivebytes"></param>
        /// <param name="count"></param>
        /// <param name="c"></param>
        private void SplitReceivePack(byte[] receivebytes, int count, AsyncTcpClient c)
        {

            //将实际字节转化成字符串
            string message = Encoding.UTF8.GetString(receivebytes);
            //心跳包，不做处理
            if (message == c.HeartBeat)
            {
                return;
            }
            #region 处理实际数据体


            byte opeartor = receivebytes[0];


            ScadaTcpOperator operatorEnum = (ScadaTcpOperator)opeartor;
            if (c.IsOperator(opeartor))
            {
                switch (operatorEnum)
                {
                    case ScadaTcpOperator.登录反馈:
                        {
                            try
                            {
                                #region 处理采集器端登录
                                TcpData tcpData = new TcpData();
                                byte[] narra = new byte[count - 1];

                                System.Array.Copy(receivebytes, 1, narra, 0, count - 1);
                                tcpData.BytesToTcpItem(narra);
                                if (tcpData == null)
                                {
                                    if (OnUserLogined != null)
                                    {
                                        OnUserLogined(c, false, "登录失败");
                                    }
                                    return;
                                }
                                STATION_TCP_INFO loginInfo = new STATION_TCP_INFO();
                                try
                                {
                                    loginInfo.IO_SERVER_ID = tcpData.GetItemValue("IO_SERVER_ID");
                                    loginInfo.IO_SERVER_IP = tcpData.GetItemValue("IO_SERVER_IP");
                                    loginInfo.PASSWROD = tcpData.GetItemValue("PASSWROD");
                                    loginInfo.USER = tcpData.GetItemValue("USER");
                                    loginInfo.RESULT = tcpData.GetItemValue("RESULT");
                                    loginInfo.MSG = tcpData.GetItemValue("MSG");
                                    loginInfo.FUNCTION = tcpData.GetItemValue("FUNCTION");
                                    
                                    //判断是否已经存在有发布的采集站工程

                                    if (loginInfo.RESULT == "true")
                                    {
                                        if (OnUserLogined != null)
                                        {
                                            OnUserLogined(c, true, loginInfo.MSG);
                                        }
                                    }
                                    else
                                    {
                                       
                                        if (OnUserLogined != null)
                                        {
                                            OnUserLogined(c, false, loginInfo.MSG);
                                        }
                                    }
                                }
                                catch
                                {
                                    if (OnUserLogined != null)
                                    {
                                        OnUserLogined(c, false, "登录失败");
                                    }
                                    return;
                                }
                                
                                tcpData.Dispose();
                                #endregion
                            }
                            catch (Exception ex)
                            {
                                ThrowExceptionToMain(new Exception("ERR10024" + ex.Message));
                            }
                        }
                        break;
                    case ScadaTcpOperator.更新采集站报警://接收到服务器端更新采集站中报警配置通知
                        {
                            try
                            {
                                #region 更新采集站报警
                                TcpData tcpData = new TcpData();
                                byte[] narra = new byte[count - 1];

                                System.Array.Copy(receivebytes, 1, narra, 0, count - 1);
                                tcpData.BytesToTcpItem(narra);
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
                                    alarmConfig.UPDATE_DATE = "";
                                    alarmConfig.UPDATE_RESULT = "";
                                    alarmConfig.UPDATE_UID = "";
                                }
                                catch (Exception ex)
                                {
                                    ThrowExceptionToMain(new Exception("ERROR20102  " + ex.Message));
                                    alarmConfig = null;
                                }

                                if (alarmConfig != null)
                                {
                                    if (alarmconfigBll.Update(alarmConfig))
                                    {

                                        byte[] sendbytes = tcpData.StringToTcpByte(tcpData.TcpItemToString(), ScadaTcpOperator.更新采集站报警反馈);
                                        this.Send(new ArraySegment<byte>(sendbytes));
                                        IO_DEVICE device = MonitorDataBaseModel.IODevices.Find(x => x.IO_DEVICE_ID == alarmConfig.IO_DEVICE_ID);
                                        if (device != null)
                                        {
                                            IO_PARA para = device.IOParas.Find(x => x.IO_ID == alarmConfig.IO_ID);
                                            if (para != null)
                                            {
                                                para.AlarmConfig = alarmConfig;
                                                AddLogToMainLog("管理员更新" + device.IO_DEVICE_NAME + "[" + device.IO_DEVICE_LABLE + "]//" + para.IO_NAME + "[" + para.IO_LABEL + "]" + "报警配置成功! ");
                                            }
                                        }
                                    }
                                    else
                                    {

                                        AddLogToMainLog("管理员更新" + alarmConfig.IO_ID + "报警配置失败! ");

                                    }



                                }



                                tcpData.Dispose();
                                #endregion
                            }
                            catch (Exception ex)
                            {
                                ThrowExceptionToMain(new Exception("ERR10029" + ex.Message));
                            }
                        }
                        break;
                    case ScadaTcpOperator.下置命令://接收到用户要下置命令
                        {
                            try
                            {
                                byte[] contentbytes = new byte[receivebytes.Length - 1];
                                System.Array.Copy(receivebytes, 1, contentbytes, 0, receivebytes.Length - 1);
                                TcpData tcpData = new TcpData();
                                tcpData.BytesToTcpItem(contentbytes);
                                IO_COMMANDS command = new IO_COMMANDS()
                                {
                                    COMMAND_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                    COMMAND_ID = tcpData.GetItemValue("COMMAND_ID"),
                                    COMMAND_RESULT = tcpData.GetItemValue("COMMAND_RESULT"),
                                    COMMAND_USER = tcpData.GetItemValue("COMMAND_USER"),
                                    COMMAND_VALUE = tcpData.GetItemValue("COMMAND_VALUE"),
                                    IO_COMM_ID = tcpData.GetItemValue("IO_COMM_ID"),
                                    IO_DEVICE_ID = tcpData.GetItemValue("IO_DEVICE_ID"),
                                    IO_ID = tcpData.GetItemValue("IO_ID"),
                                    IO_LABEL = tcpData.GetItemValue("IO_LABEL"),
                                    IO_NAME = tcpData.GetItemValue("IO_NAME"),
                                    IO_SERVER_ID = tcpData.GetItemValue("IO_SERVER_ID")
                                };


                                Scada.Model.IO_COMMUNICATION _COMMUNICATION = MonitorDataBaseModel.IOCommunications.Find(x => x.IO_COMM_ID == command.IO_COMM_ID && command.IO_SERVER_ID == x.IO_SERVER_ID);
                                Scada.Model.IO_DEVICE device = MonitorDataBaseModel.IODevices.Find(x => x.IO_COMM_ID == command.IO_COMM_ID && command.IO_SERVER_ID == x.IO_SERVER_ID && x.IO_DEVICE_ID == command.IO_DEVICE_ID);
                               
                                if (_COMMUNICATION != null&& device!=null)
                                {
                                    Scada.Model.IO_PARA para = device.IOParas.Find(x => x.IO_COMM_ID == command.IO_COMM_ID && command.IO_SERVER_ID == x.IO_SERVER_ID && x.IO_DEVICE_ID == command.IO_DEVICE_ID && x.IO_ID == command.IO_ID);
                                    if(para==null)
                                    {
                                        AddLogToMainLog(device.IO_DEVICE_NAME+"["+ device.IO_DEVICE_LABLE + "] 设备下参数 "+para.IO_ID+" "+ para.IO_LABEL+" "+ para.IO_NAME+" 参数不存在");
                                        return;
                                    }
                                    if (_COMMUNICATION.DriverInfo == null)
                                    {
                                        AddLogToMainLog("请在采集站中设置该通讯通道驱动!");
                                        return;
                                    }
                                    try
                                    {
                                        if (_COMMUNICATION.CommunicateDriver == null)
                                        {
                                            AddLogToMainLog("请在采集站中设置该通讯通道驱动!");
                                            return;
                                        }
                                        else
                                            ((ScadaCommunicateKernel)_COMMUNICATION.CommunicateDriver).IsCreateControl = false;

                                        ScadaCommunicateKernel driverDll = (ScadaCommunicateKernel)_COMMUNICATION.CommunicateDriver;
                                        driverDll.SetUIParameter(_COMMUNICATION.IO_COMM_PARASTRING);
                                        driverDll.IsCreateControl = false;
                                        driverDll.InitKernel(MonitorDataBaseModel.IOServer, _COMMUNICATION, _COMMUNICATION.Devices, _COMMUNICATION.DriverInfo);
                                        try
                                        {
                                            driverDll.SendCommand(MonitorDataBaseModel.IOServer, _COMMUNICATION, device, para, command.COMMAND_VALUE);
                                            AddLogToMainLog(device.IO_DEVICE_NAME + "[" + device.IO_DEVICE_LABLE + "] 设备下参数 " + para.IO_ID + " " + para.IO_LABEL + " " + para.IO_NAME + " 已经下置成功,下置值" + command.COMMAND_VALUE);
                                        }
                                        catch(Exception ex)
                                        {
                                            ThrowExceptionToMain(new Exception("ERROR600002" + ex.Message));
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        ThrowExceptionToMain(new Exception("ERROR600001" + ex.Message));
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                ThrowExceptionToMain(new Exception("ERR10030" + ex.Message));
                            }
                        }
                        break;
                    case ScadaTcpOperator.重新启动:
                        break;
                }

            }
            #endregion

        }
     
        public    void Send(ArraySegment<byte> data)
        {
          
                 Client.Send(data);
            
        }
        public    void Send(string msg)
        {
            byte[] datas = Encoding.UTF8.GetBytes(msg);
              Client.Send(new ArraySegment<byte>(datas));
          
        }
        public   void Send(string msg, ScadaTcpOperator op)
        {
            byte[] datas = Encoding.UTF8.GetBytes(msg);
            byte[] senddatas = new byte[datas.Length + 1];
            senddatas[0] = (byte)op;
            System.Array.Copy(datas,0, senddatas,1, datas.Length);
              Client.Send(new ArraySegment<byte>(senddatas));
         
        }
        /// <summary>
        /// 停止
        /// </summary>
        public  async void Stop()
        {
            if (Client != null)
            {
                await Task.Delay(2 * 1000);
                Client.Disconnect();
                Task.WaitAll(TaskManager.ToArray());
                Client.Dispose();
                Client = null;
                GC.Collect();
            }

        }
        /// <summary>
        /// 启动
        /// </summary>
        public  async void Start()
        {
           
                await RunAsync(int.Parse(ClientConfig.RemotePort), IPAddress.Parse(ClientConfig.RemoteIP));
           
        }
        /// <summary>
        /// 指定连接启动
        /// </summary>
        public  async void Start(string IP)
        {
            await RunAsync(int.Parse(ClientConfig.RemotePort), IPAddress.Parse(IP));

        }
        

        private  void ClientForm_SendMessage(string msg)
        {
            AddLogToMainLog(msg);
        }

        private  void Client_TCPExceptionEvent(Exception ex)
        {
            ThrowExceptionToMain(ex);
        }

        private  void Client_Message(object sender, AsyncTcpEventArgs e)
        {
            AddLogToMainLog(e.Message);
        }
    }
}
