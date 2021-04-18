using Scada.DriveInterface;
using Scada.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ModbusNBIot
{
    public delegate void ZYBEvent(object sender, ZYBEventArgs e);

    public delegate void ZYBEventN();

    /// <summary>
    /// 实现IOT TCP
    /// </summary>
    public class Nb_IotModbusServer: ScadaCommunicateDriver
    {
        public override string GUID => "2F201A38-2768-4677-AF14-30F52A340143";
        public override string Title
        {
            get => base.Title; set { base.Title = "Nb-iot 或4G网络下Modbus数据传输"; }
        }
        private   Dictionary<int, DtuData> _hsable;
        private   Dictionary<string, int> _hsable_id_innerid;
        private int _timeout;
        private readonly object locker = new object();
        private   Timer RefreshTimer;
        private ZYBServer svr;
        private DtuConfig dtuConfig = null;
        List<RealData> RealDevices = new List<RealData>();
        protected override bool InitCommunicateDriver(IO_SERVER server, IO_COMMUNICATION communication, List<IO_DEVICE> ioDevices, SCADA_DRIVER driver)
        {
            if (IsCreateControl)
            {
                CommunicationControl = new NbIotCtrl();
                if (communication != null)
                    CommunicationControl.SetUIParameter(communication.IO_COMM_PARASTRING);
            }
            RealDevices.Clear();
            if (communication != null)
            {
                dtuConfig = new DtuConfig();

                ParaPack TcpParaPack = new ParaPack(communication.IO_COMM_PARASTRING);
                dtuConfig.DtuHeartbeat = TcpParaPack.GetValue("开启心跳")== "开启心跳"? DtuHeartbeat.开启心跳: DtuHeartbeat.禁用心跳;
                switch(TcpParaPack.GetValue("注册包").Trim())
                {
                    case "关闭注册包":
                        dtuConfig.DtuRegister = DtuRegister.关闭注册包;
                        break;
                    case "每包数据加上IMEI注册包":
                        dtuConfig.DtuRegister = DtuRegister.每包数据加上IMEI注册包;
                        break;
                    case "每包数据加自定义注册包":
                        dtuConfig.DtuRegister = DtuRegister.每包数据加自定义注册包;
                        break;
                    case "第一次链接到服务器时发送一个IMEI注册包":
                        dtuConfig.DtuRegister = DtuRegister.第一次链接到服务器时发送一个IMEI注册包;
                        break;
                    case "第一次链接到服务器时发送一个自定义注册包":
                        dtuConfig.DtuRegister = DtuRegister.第一次链接到服务器时发送一个自定义注册包;
                        break;
                }
                switch (TcpParaPack.GetValue("存储方式").Trim().ToUpper())
                {
                    case "HEX":
                        dtuConfig.DtuRegisterByteTranscoding =  ByteTranscoding.HEX;
                        break;
                    case "ASCII":
                        dtuConfig.DtuRegisterByteTranscoding = ByteTranscoding.ASCII;
                        break;
                    case "INT16":
                        dtuConfig.DtuRegisterByteTranscoding = ByteTranscoding.Int16;
                        break;
                    case "INT32":
                        dtuConfig.DtuRegisterByteTranscoding = ByteTranscoding.Int32;
                        break;
                    case "INT64":
                        dtuConfig.DtuRegisterByteTranscoding = ByteTranscoding.Int64;
                        break;
                    case "UTF8":
                        dtuConfig.DtuRegisterByteTranscoding = ByteTranscoding.UTF8;
                        break;
                }
                //标识长度
                dtuConfig.IdentificationCharLength = int.Parse(TcpParaPack.GetValue("标识长度"));
                dtuConfig.Heartbeat = TcpParaPack.GetValue("心跳字节");
                dtuConfig.ReceiveType = TcpParaPack.GetValue("接收方式") == "被动" ? ReceiveType.被动 : ReceiveType.主动;
                dtuConfig.LocalIP= TcpParaPack.GetValue("本机IP");
                dtuConfig.LocalPort = int.Parse(TcpParaPack.GetValue("本机端口"));
                initServer(dtuConfig);
                //构造获取数据命令的字节数组,Modbus
                for (int i = 0; i < this.IODevices.Count; i++)
                {
                    ParaPack devicePack = new ParaPack(this.IODevices[i].IO_DEVICE_PARASTRING);
                    object fragment = new ModbusFragmentStore();
                    RealData mRealData = new RealData();
                    mRealData.Device = this.IODevices[i];
                    mRealData.Identification = devicePack.GetValue("注册标识");
                    mRealData.IdentificationLength = int.Parse(devicePack.GetValue("注册标识"));
                    ScadaDeviceDrive driverDll = DeviceDrives.Find(x => x.DeviceDriverID == this.IODevices[i].DEVICE_DRIVER_ID);
                    if (driverDll != null)
                    {
                        driverDll.InitDrive(IOServer, IOCommunication, this.IODevices[i], null, this.IODevices[i].DriverInfo);
                        //IO_DEVICE_ADDRESS中存储的是DTU编号
                        mRealData.SlaveId = this.IODevices[i].IO_DEVICE_ADDRESS;//从机地址
                        //数据库中系统编号
                        mRealData.DEVICEID = this.IODevices[i].IO_DEVICE_ID;
                        mRealData.Device = this.IODevices[i];
                    }
                    mRealData.Fragment = (ModbusFragmentStore)fragment;
                    RealDevices.Add(mRealData);


                }
            }

            return true;
        }
        protected override ScadaResult IOSendCommand(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, IO_PARA para, string value)
        {
            return new ScadaResult(false,"未进行设置");
        }
        private void initServer(DtuConfig config)
        {
       
            dtuConfig = config;
            this.RefreshTimer = new Timer(10000);
            this.RefreshTimer.SynchronizingObject = null;
            this.RefreshTimer.Elapsed += new ElapsedEventHandler(this.RefreshTimer_Elapsed);
            this._hsable = new Dictionary<int, DtuData>();
            this._hsable_id_innerid = new Dictionary<string, int>();
            this.svr = new ZYBServer(dtuConfig.LocalPort);
            this.svr.OnDataIn += new OnDataInHandler(this.svr_OnDataIn);
            this.svr.OnDisconnected += new OnDisconnectedHandler(this.svr_OnDisconnected);
            this.svr.OnConnected += Svr_OnConnected;
            this.svr.OnError += Svr_OnError;
        }

        /// <summary>
        /// 服务器端错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="error"></param>
        private void Svr_OnError(object sender, System.Net.Sockets.SocketException error)
        {
           
        }
        /// <summary>
        /// 当有一个连接的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Svr_OnConnected(object sender, ZYBConnectedEventArgs e)
        {
       
        }

        /// <summary>
        /// 设备ID转内部ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int IdToInnerid(string id)
        {
            int num=-1;
            lock (this.locker)
            {
                if (!this._hsable_id_innerid.TryGetValue(id, out num))
                {
                    num = -1;
                }
            }
            return num;
        }
 
        /// <summary>
        /// 内部ID转设备ID
        /// </summary>
        /// <param name="innerid"></param>
        /// <returns></returns>
        public string InneridToId(int innerid)
        {
            try
            {
                lock (this.locker)
                {
                    DtuData data;
                    if (!this._hsable.TryGetValue(innerid, out data))
                    {
                        return "";
                    }
                    return data.Identification;
                }
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 判断是否心跳
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool isheart(byte[] s)
        {
            if (s==null||s.Length < 0)
                return false;
            try
            {
                
                    return ((s.Length == 1) && (Convert.ToInt32(s[0]) == 0xfe));

            }
            catch
            {
                return false;
            }
        }
        private static string ByteToHexStr(byte[] da)
        {
            string str = " ";
            for (int i = 0; i < da.Length; i++)
            {
                str = str + Convert.ToString(da[i], 10);
            }
            return str;
        }

        public static byte[] StrToHexByte(string da)
        {
            string str = da;
            str = str.Replace(" ", "").Replace("\n", "").Replace("\r", "");
            int num = str.Length / 2;
            byte[] buffer = new byte[num];
            for (int i = 0; i < num; i++)
            {
                buffer[i] = Convert.ToByte(str.Substring(i * 2, 2), 10);
            }
            return buffer;
        }
        //获取实际数据体
        private byte[] getrealbytes(byte[] by, ref string Identification, bool flag)
        {
            Identification = "";
            byte[] idfbytes = new byte[dtuConfig.IdentificationCharLength];
            Byte[] reals = new byte[0];
            switch (dtuConfig.DtuRegister)
            {
                case DtuRegister.关闭注册包:
                    {
                        reals= by;
                        break;
                    }
                default:
                    {
                        if (flag)//标识并不是第一次
                        {
                            switch (dtuConfig.DtuRegister)
                            {
                    
                                case DtuRegister.每包数据加上IMEI注册包:
                                    {
                                        idfbytes = new byte[dtuConfig.IdentificationCharLength];
                                        Array.Copy(by, 0, idfbytes, 0, dtuConfig.IdentificationCharLength);
                                        reals = new byte[by.Length - dtuConfig.IdentificationCharLength];
                                        Array.Copy(by, dtuConfig.IdentificationCharLength, idfbytes, 0, reals.Length);
                                        break;
                                    }
                                case DtuRegister.每包数据加自定义注册包:
                                    {
                                        idfbytes = new byte[dtuConfig.IdentificationCharLength];
                                        Array.Copy(by, 0, idfbytes, 0, dtuConfig.IdentificationCharLength);
                                        reals = new byte[by.Length - dtuConfig.IdentificationCharLength];
                                        Array.Copy(by, dtuConfig.IdentificationCharLength, idfbytes, 0, reals.Length);
                                        break;
                                    }
                                default:
                                    reals= by;
                                    break;
                                 
                            }
                        }
                        else//标识第一次
                        {
                            idfbytes = new byte[dtuConfig.IdentificationCharLength];
                            Array.Copy(by, 0, idfbytes, 0, dtuConfig.IdentificationCharLength);
                            reals = new byte[by.Length - dtuConfig.IdentificationCharLength];
                            Array.Copy(by, dtuConfig.IdentificationCharLength, idfbytes, 0, reals.Length);
                            return reals;
                        }
                        if (idfbytes.Length > 0)
                        {
                            switch (dtuConfig.DtuRegisterByteTranscoding)
                            {
                                case ByteTranscoding.ASCII:
                                    Identification = ASCIIEncoding.ASCII.GetString(idfbytes);
                                    break;
                                case ByteTranscoding.HEX:
                                    Identification = ByteToHexStr(idfbytes);
                                    break;
                                case ByteTranscoding.UTF8:
                                    Identification = ASCIIEncoding.UTF8.GetString(idfbytes);
                                    break;
                                case ByteTranscoding.Int16:
                                    Identification = BitConverter.ToInt16(idfbytes, 0).ToString();
                                    break;
                                case ByteTranscoding.Int32:
                                    Identification = BitConverter.ToInt32(idfbytes, 0).ToString();
                                    break;
                                case ByteTranscoding.Int64:
                                    Identification = BitConverter.ToInt64(idfbytes, 0).ToString();
                                    break;
                            }
                        }
                        break;

                    }
            }

            return reals;


        }
        /// <summary>
        /// 刷新操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                List<DtuData> list = new List<DtuData>();
                lock (this.locker)
                {
                    foreach (int num in this._hsable.Keys)
                    {
                        try
                        {
                            DtuData item = this._hsable[num];
                            if (item != null && item.RefreshTime != null)
                            {
                                if (item.IsOnline && item.RefreshTime != null)
                                {
                                    TimeSpan span = (TimeSpan)(DateTime.Now - item.RefreshTime);
                                    if (span.TotalSeconds > this._timeout)
                                    {
                                        list.Add(item);
                                    }

                                }
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    foreach (DtuData data2 in list)//此处要实现重新连接
                    {
                        if (data2 != null)
                        {
                          svr.Disconnect(data2.ID);

                        }
                    }
                    list.Clear();
                    list = null;
                }
               
            }
            catch  
            {
                 
            }
        }
        /// <summary>
        /// 向用户发送数据,标识
        /// </summary>
        /// <param name="Identification"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public bool Send(string Identification, byte[] Data, out string error, bool IsAsync)
        {
            error = "";
 
            int connectionId = this.IdToInnerid(Identification);

            if (connectionId == -1)
            {
                error = "connectionId 不存在";
                return false;
            }
            try
            {
                if (svr!=null&&Data.Length > 0)
                {
                    //此处处理符合要求的数据发送到客户端
                    return this.svr.Send(connectionId, Data, out error, IsAsync);
                }
                else
                {
                    error = "服务不存在";
                    return false;
                }
            }
            catch (Exception emx)
            {
                error = emx.Message;
                return false;
            }
       
        }

   
        /// <summary>
        /// 启动服务
        /// </summary>
        protected override void Start()
        {
            try
            {
        
                this.svr.Start();
                this.RefreshTimer.Start();
                this.svr.ServerIsSuspend = this.ServerIsSuspend;
                if(this.dtuConfig.ReceiveType== ReceiveType.主动)
                {
                    for (int i = 0; i < RealDevices.Count; i++)
                    {

                        RealDevices[i].Task = Task.Run(() => {
                            this.Send()
                        });

                    }
                }
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// 停止服务
        /// </summary>
        protected override void Stop()
        {
            try
            {
                this._hsable.Clear();
                this._hsable_id_innerid.Clear();
                this.RefreshTimer.Stop();
                this.svr.Shutdown();
                this.svr.ServerIsSuspend = this.ServerIsSuspend;
            }
            catch
            {
                return;
            }
        }
        protected override void Pause()
        {
            this.svr.ServerIsSuspend = this.ServerIsSuspend;
        }
        protected override void Continue()
        {
            this.svr.ServerIsSuspend = this.ServerIsSuspend;
        }
        protected override void Close()
        {
            this.svr.ServerIsSuspend = this.ServerIsSuspend;
            Stop();

        }

        /// <summary>
        /// 数据事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void svr_OnDataIn(object sender, ZYBDataInEventArgs e)
        {
            if (((sender != null) && (e != null)) && ((e.Data != null) && (e.Data.Length >= 0)))
            {
                try
                {
                    bool flag;
                    DtuData data;
                    int connectionId = e.ConnectionId;
                    //获取自动分配的ID号
                    DateTime now = DateTime.Now;
                    lock (this.locker)
                    {
                        flag = this._hsable.TryGetValue(connectionId, out data);
                    }
                    string Identification = "";
                    byte[] s = getrealbytes(e.Data, ref Identification, flag);
                    if(flag)
                    {
                        Identification = data.Identification;
                    }
                    if (data!=null)
                    {
                        data.ID = connectionId;
                        data.Identification = Identification;
                        data.IP = e.socket.RemoteEndPoint.ToString();
                        data.IsOnline = true;
                        data.RefreshTime = DateTime.Now;
                        data.DataByte = s;
                        data.cliSock = e.socket;
                    }
                   
                    if (flag)
                    {
                        //如果数据显示没有上线,则处理上线
                        if (!data.IsOnline)
                        {
                            data.IsOnline = true;
                            //处理客户端连接事件
                        } 
                    }
                    else //将一个新的连接加入到服务器
                    {
             
                        bool flag2 = false;
                        int existId;
                        lock (this.locker)
                        {
                            if (this._hsable_id_innerid.TryGetValue(Identification, out existId))
                            {
                                flag2 = true;
                                this._hsable.Remove(existId);
                                this._hsable_id_innerid.Remove(Identification);
                            }
                        }
                        if (flag2)
                        {
                            this.svr.Disconnect(existId);
                        }

                        data = new DtuData
                        {
                            ID = e.ConnectionId,
                            LoginTime = now,
                            RefreshTime = now,
                            IP = e.socket.RemoteEndPoint.ToString(),
                            Identification = Identification,
                            IsOnline = true,
                            cliSock = e.socket,
                            DataByte = s
                        };
                        lock (this.locker)
                        {
                            this._hsable.Add(connectionId, data);
                            this._hsable_id_innerid.Add(Identification, connectionId);
                        }
                        //处理客户端连接事件
                        return;
                    }
                    //判断数据是不是心跳数据
                    if (!this.isheart(s))
                    {
                        //向用户发送数据
                       // this.ReceiveData?.Invoke(this, new ZYBEventArgs(data, "数据正常接收"));
                        return;
                    }
                    this.svr.Disconnect(connectionId);
                }
                catch
                {
                }
            }
        }
        
        private void svr_OnDisconnected(object sender, ZYBDisconnectedEventArgs e)
        {
            if (sender == null || e == null)
                return;
            
            try
            {
                DtuData data;
                int connectionId = e.ConnectionId;
                bool flag = false;
                lock (this.locker)
                {
                    if (this._hsable.TryGetValue(connectionId, out data) && data.IsOnline)
                    {
                        flag = true;
                    }
                    
                }
                if (flag)
                {
                    lock (this.locker)
                    {
                        this._hsable_id_innerid.Remove(data.Identification);
                        this._hsable.Remove(connectionId);
                    }
                    data.IsOnline = false;
                    //处理客户端上线事件
                }
            }
            catch
            {

            }
        }

        public int Count
        {
            get
            {
                int num = 0;
                lock (this.locker)
                {
                    foreach (int num2 in this._hsable.Keys)
                    {
                        DtuData data = this._hsable[num2];
                        if (data.IsOnline)
                        {
                            num++;
                        }
                    }
                }
                return num;
            }
        }
        
      
    }
}

