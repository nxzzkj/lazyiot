using Scada.AsyncNetTcp;
using Scada.AsyncNetTcp.Net;
 
using IOManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Scada.DBUtility;
using Scada.Model;

namespace IOManager.Core
{
    public delegate void TcpClientEventHandle(AsyncTcpClient client, object sender,string msg);
    public delegate void ExceptionHanped(Exception ex);
    public delegate void TCPClientLoged(string msg);


    public  class IOManagerTCPClient : ScadaTask
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
        Scada.Business.IO_ALARM_CONFIG alarmconfigBll = new Scada.Business.IO_ALARM_CONFIG();
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
        //发布工程的事件
        public event  TcpClientEventHandle OnPublishProject;
        public event TcpClientEventHandle OnPublishing;//数据接收发布中
        public event TcpClientEventHandle OnPublishProjectSuccess;//发布工程成功
        public event TcpClientEventHandle OnPublishProjectFault;//发布工程失败

        public event ExceptionHanped OnExceptionHanped;
        public event TCPClientLoged OnTCPClientLoged;
        public event TcpClientEventHandle OnConnectTimeout;

        public    void AddLog(string msg)
        {
            if(OnTCPClientLoged!=null)
            {
                OnTCPClientLoged(msg);
            }
            Scada.Logger.Logger.GetInstance().Info(msg);
        }
        #region 异常处理
        /// <summary>
        /// 异常信息在日志端显示
        /// </summary>
        /// <param name="ex"></param>
        public  void DisplayException(Exception ex)
        {
            if(OnExceptionHanped!=null)
            {
                OnExceptionHanped(ex);
            }
            Scada.Logger.Logger.GetInstance().Debug(ex.Message);
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
                AutoReconnect = true,
                 ScadaClientType= ScadaClientType.IoManager,
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
                 ConnectedTimeoutCallback = (c, isReconnected) =>
                 {
                     if(OnConnectTimeout!=null)
                     {
                         OnConnectTimeout(c, isReconnected, "与服务器连接超时");
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
                   if(realbytes.Length>0)
                        {
                            try
                            {
                                //处理数据体
                                SplitReceivePack(realbytes, realbytes.Length, c);

                            }
                            catch (Exception ex)
                            {
                                DisplayException(new Exception("ERR10025" + ex.Message));
                            }
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
        private async Task RunAsync(int port, int remoteport,IPAddress remoteIp)
        {

            Client = new AsyncTcpClient
            {
                IPAddress = remoteIp,
                Port = port,
                AutoReconnect = true,
                ConnectedCallback = async (c, isReconnected) =>
                {
                    c.TemporaryByteBuffer = new List<byte[]>();
                    c.TemporaryByteRun = false;
                    c.TemporaryBytesCount = 0;
                    c.TemporaryBytesKey = "";
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
                    c.TemporaryByteBuffer = new List<byte[]>();
                    c.TemporaryByteRun = false;
                    c.TemporaryBytesCount = 0;
                    c.TemporaryBytesKey = "";
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
                    ///原始数据包，有可能是粘包在一起，所以要单独处理
                    byte[] receivebytes = c.ByteBuffer.Dequeue(count);
                    //如果获取的是空数据，则结束任务
                    if (receivebytes.Length <= 0)
                        return Task.CompletedTask;
                    //if (count != TcpPackConfig.NormalPackSize)//接收的包必须是5120
                    //    return Task.CompletedTask;
                    if (c.UsedPackageIdentification)
                    {
                        //准备分隔数据包，由于本系统全部将字符串转换为字节，所以需要通过字符串来分隔
                        byte[] headbytes = new byte[c.HeadPackSize];//头标识字节
                        byte[] macbytes = new byte[c.MACSize];//MAC地址
                        byte[] reallengthbytes = new byte[4];//MAC地址
                        byte[] tailbytes = new byte[c.TailPackSize];//获取尾标识
                        System.Array.Copy(receivebytes, 0, headbytes, 0, headbytes.Length);
                        System.Array.Copy(receivebytes, headbytes.Length, macbytes, 0, macbytes.Length);
                        System.Array.Copy(receivebytes, headbytes.Length + macbytes.Length, reallengthbytes, 0, reallengthbytes.Length);

                        string receive_head = Encoding.UTF8.GetString(headbytes);
                        string receive_mac = Encoding.UTF8.GetString(macbytes);
                        string receive_length = BitConverter.ToInt32(macbytes, 0).ToString();

                        System.Array.Copy(receivebytes, headbytes.Length + macbytes.Length + 4 + int.Parse(receive_length), tailbytes, 0, tailbytes.Length);
                        string receive_tail = Encoding.UTF8.GetString(tailbytes);
                        //反回去获取分隔字节
                        if (receive_head != c.HeadPack || receive_tail != c.TailPack)
                            return Task.CompletedTask;


                        string MAC = receive_mac;
                        string msg = "";
                        SplitPakeage splitPakeage = new SplitPakeage();
                        byte[] realbytes = splitPakeage.RemoveIdentificationBytes(receivebytes, c, out MAC,out msg);
                        if (realbytes.Length <= 0)
                            return Task.CompletedTask;

                        try
                        {//分包处理
                            SplitReceivePack(realbytes, realbytes.Length, c);

                        }
                        catch (Exception ex)
                        {
                            DisplayException(new Exception("ERR10025" + ex.Message));
                        }


                    }



                    return Task.CompletedTask;
                }
            };
            Client.Message += Client_Message;
            Client.TCPExceptionEvent += Client_TCPExceptionEvent;
            var clientTask = Client.RunAsync();
            TaskManager.Add(clientTask);
        }
       
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
                    case ScadaTcpOperator.采集站登录反馈:
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
                                DisplayException(new Exception("ERR80014" + ex.Message));
                            }
                        }


                        break;
                    case ScadaTcpOperator.发布工程请求反馈:
                        {
                            try
                            {
                                #region 发布工程反馈
                                TcpData tcpData = new TcpData();
                                byte[] narra = new byte[count - 1];

                                System.Array.Copy(receivebytes, 1, narra, 0, count - 1);
                                tcpData.BytesToTcpItem(narra);
                                if (tcpData == null)
                                {
                                    if (OnPublishProject != null)
                                    {
                                        OnPublishProject(c, false, "发布失败");
                                    }
                                    return;
                                }

                                try
                                {
                                    string IO_SERVER_ID = tcpData.GetItemValue("IO_SERVER_ID");
                                    string RESULT = tcpData.GetItemValue("RESULT");
                                    string MSG = tcpData.GetItemValue("MSG");
                                    //判断是否已经存在有发布的采集站工程

                                    if (RESULT == "true")
                                    {
                                        if (OnPublishProject != null)
                                        {
                                            OnPublishProject(c, true, MSG);
                                        }
                                    }
                                    else
                                    {

                                        if (OnUserLogined != null)
                                        {
                                            OnPublishProject(c, false, MSG);
                                        }
                                    }
                                }
                                catch
                                {
                                    if (OnPublishProject != null)
                                    {
                                        OnPublishProject(c, false, "发布失败");
                                    }
                                    return;
                                }

                                tcpData.Dispose();
                                #endregion
                            }
                            catch (Exception ex)
                            {
                                DisplayException(new Exception("ERR70034" + ex.Message));
                            }

                        }
                        break;
                    case ScadaTcpOperator.发布工程失败://接收到服务器端更新采集站中报警配置通知
                        {
                            TcpData tcpData = new TcpData();
                            byte[] narra = new byte[count - 1];

                            System.Array.Copy(receivebytes, 1, narra, 0, count - 1);
                            tcpData.BytesToTcpItem(narra);
                            
                            if (OnPublishProjectFault != null)
                            {
                                OnPublishProjectFault(c, false, tcpData.GetItemValue("MSG"));
                            }

                        }
                        break;
                    case ScadaTcpOperator.发布工程成功://接收到服务器端更新采集站中报警配置通知
                        {
                            AddLog("发布采集站工程成功,请重新启动采集服务!");
                            TcpData tcpData = new TcpData();
                            byte[] narra = new byte[count - 1];

                            System.Array.Copy(receivebytes, 1, narra, 0, count - 1);
                            tcpData.BytesToTcpItem(narra);
                            
                            if (this.OnPublishProjectSuccess != null)
                            {
                                OnPublishProjectSuccess(c, true, "发布采集站工程成功,请重新启动采集服务");
                            }

                        }
                        break;

                    case ScadaTcpOperator.发布工程进度:
                        {

                            
                                   TcpData tcpData = new TcpData();
                            byte[] narra = new byte[count - 1];

                            System.Array.Copy(receivebytes, 1, narra, 0, count - 1);
                            tcpData.BytesToTcpItem(narra);
                            if (tcpData == null)
                            {
                                return;
                            }
                            //显示服务器端更新进度
                            AddLog(tcpData.GetItemValue("MSG") + "  " + tcpData.GetItemValue("PROCESS"));
                        }
                        break;
                    case ScadaTcpOperator.发布工程数据传输进度:
                        {


                            TcpData tcpData = new TcpData();
                            byte[] narra = new byte[count - 1];

                            System.Array.Copy(receivebytes, 1, narra, 0, count - 1);
                            tcpData.BytesToTcpItem(narra);
                            if (tcpData == null)
                            {
                                return;
                            }
                            int index = int.Parse(tcpData.GetItemValue("PROCESS"));//请求的数据
                            //显示服务器端更新进度
                            AddLog(tcpData.GetItemValue("MSG") + "  正在发送第" + tcpData.GetItemValue("PROCESS") + "条数据");
                            if (OnPublishing != null)
                            {
                                OnPublishing(c, index, tcpData.GetItemValue("MSG"));
                            }
                        }
                        break;
                    case ScadaTcpOperator.重新启动:
                        break;
                }

            }
            #endregion

        }
        public   void Send(ArraySegment<byte> data)
        {
          
               Client.Send(data);
        
        }
        public   void Send(ArraySegment<byte> datas, ScadaTcpOperator op)
        {
            byte[] senddatas = new byte[datas.Count + 1];
            senddatas[0] = (byte)op;
            System.Array.Copy(datas.Array,0, senddatas, 1, datas.Count);
             Client.Send(new ArraySegment<byte>(senddatas));
         
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
            //发送一条数据后等待200毫秒，怕粘包和数据丢失
            
              
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
            await RunAsync(int.Parse(FormManager.Config.RemotePort), IPAddress.Parse(IP));

        }
        private  void ClientForm_ConnectedServer(object sender, EventArgs e)
        {
            if (Client == null || Client.IsClosing)
            {
                Start();
            }
        }

        private  void ClientForm_SendMessage(string msg)
        {
            AddLog(msg);
        }

        private  void Client_TCPExceptionEvent(Exception ex)
        {
            DisplayException(ex);
        }

        private  void Client_Message(object sender, AsyncTcpEventArgs e)
        {
            AddLog(e.Message);
        }
    }
}
