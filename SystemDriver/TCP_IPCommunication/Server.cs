namespace TcpNetworkBrige
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Timers;

    public class Server
    {
    
        private readonly Dictionary<int, TCPData> _hsable;
        private readonly Dictionary<string, int> _hsable_id_innerid;
        private int sendBufferSize = 1024;//发送字节缓存
        public int SendBufferSize
        {
            set { sendBufferSize = value; }
            get { return sendBufferSize; }
        }
        private int receiveBufferSize = 1024;//接收字节数组缓存
        public int ReceiveBufferSize
        {
            set { receiveBufferSize = value; }
            get { return receiveBufferSize; }
        }

        private int receivetimeout = 1000;//接收超时时间ms
        public int ReceiveTimeout
        {
            set { receivetimeout = value; }
            get { return receivetimeout; }
        }
        private int sendtimeout = 1000;//发送超时时间ms
        public int SendTimeout
        {
            set { sendtimeout = value; }
            get { return sendtimeout; }
        }

        private int hearttime = 1000;//心跳时间
        public int HeartTime
        {
            set { hearttime = value; }
            get { return hearttime; }
        }
        private byte heartident = 255;//心跳标识
        public byte HeartIdent
        {
            set { heartident = value; }
            get { return heartident; }
        }
       
        private int deviceidsize = 8;//设备地址编号的长度
        public int DeviceidSize
        {
            set { deviceidsize = value; }
            get { return deviceidsize; }
        }
        private int deviceidstart = 1;//设备地址开始字节
        public int DeviceidStart
        {
            set { deviceidstart = value; }
            get { return deviceidstart; }
        }
       
        private readonly object locker = new object();
        private readonly Timer RefreshTimer;
        private TCPServer svr;
        public event TCPEvent ClientClose;

        public event TCPEvent ClientConnect;

        public event TCPEvent ReceiveData;

        public Server( int port, int msendtimeout, int mrectimeout, int mupdatecycle, int msendbuffersize, int mreceivebuffersize, int mdeviceidsize, int mdeviceidstart, byte mheartident, int mhearttime)
        {
 
            this.sendtimeout = msendtimeout;//数据的延时周期
            this.receivetimeout = mrectimeout;//数据接收延时周期
            this.heartident = mheartident;
            this.hearttime = mhearttime;
            this.heartident = mheartident;
            this.receiveBufferSize = mreceivebuffersize;
            this.sendBufferSize = msendbuffersize;
            this.deviceidsize = mdeviceidsize;
            this.deviceidstart = mdeviceidstart;
        
            this.RefreshTimer = new Timer(mupdatecycle * 1000);
            this.RefreshTimer.SynchronizingObject = null;
            this.RefreshTimer.Elapsed += new ElapsedEventHandler(this.RefreshTimer_Elapsed);
            this._hsable = new Dictionary<int, TCPData>();
            this._hsable_id_innerid = new Dictionary<string, int>();
            this.svr = new TCPServer(port);
            this.svr.SendBufferSize = this.sendBufferSize;
            this.svr.ReceiveBufferSize = this.receiveBufferSize;
            this.svr.SendTimeout = this.sendtimeout * 1000;
            this.svr.ReceiveTimeout = this.receivetimeout * 1000;
            this.svr.DeviceidSize = this.deviceidsize;
            this.svr.DeviceidStart = this.deviceidstart;
            this.svr.HeartIdent = this.heartident;
            this.svr.HeartTime = this.hearttime;
            this.svr.OnDataIn += new OnDataInHandler(this.svr_OnDataIn);
            this.svr.OnDisconnected += new OnDisconnectedHandler(this.svr_OnDisconnected);
        }

        private byte[] ByteAdd(byte[] by1, byte[] by2)
        {
            int length = by1.Length;
            int num2 = by2.Length;
            byte[] buffer = new byte[length + num2];
            for (int i = 0; i < length; i++)
            {
                buffer[i] = by1[i];
            }
            for (int j = 0; j < num2; j++)
            {
                buffer[j + length] = by2[j];
            }
            return buffer;
        }

        private byte[] ConertDataByte(byte[] data)
        {
            if (data==null||data.Length < 0)
                return null;
          
            int length = data.Length;
            byte[] buffer = new byte[length + 1];
            byte[] buffer2 = new byte[length + 1];
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            byte num5 = Convert.ToByte("fe", 0x10);
            byte num6 = Convert.ToByte("fd", 0x10);
            byte num7 = Convert.ToByte("ed", 0x10);
            byte num8 = Convert.ToByte("ee", 0x10);
            for (int i = 0; i < length; i++)
            {
                if (data[i] != num5)
                {
                    buffer[num2++] = data[i];
                }
            }
            for (int j = 0; j < num2; j++)
            {
                if ((buffer[j] == num6) && (buffer[j + 1] == num7))
                {
                    buffer2[num3++] = num6;
                    j++;
                }
                else
                {
                    buffer2[num3++] = buffer[j];
                }
            }
            for (int k = 0; k < num3; k++)
            {
                if ((buffer2[k] == num6) && (buffer2[k + 1] == num8))
                {
                    buffer[num4++] = num5;
                    k++;
                }
                else
                {
                    buffer[num4++] = buffer2[k];
                }
            }
            byte[] buffer3 = new byte[num4];
            for (int m = 0; m < num4; m++)
            {
                buffer3[m] = buffer[m];
            }
            return buffer3;
        }

 

        public bool Disconnect(string ID)
        {
            ID = ID.Trim();
            int connectionId = this.IdToInnerid(ID);
            if (connectionId == -1)
            {
                return false;
            }
            try
            {
                this.svr.Disconnect(connectionId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private byte[] GetBigData(byte[] data)
        {
            if (data==null||data.Length <= 5)
                return null;
            int num = data.Length - 5;
            byte[] buffer = new byte[num];
            for (int i = 0; i < num; i++)
            {
                buffer[i] = data[i + 4];
            }
            return buffer;
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
                   TCPData data;
                    if (!this._hsable.TryGetValue(innerid, out data))
                    {
                        return "";
                    }
                    return data.ADDRESS;
                }
            }
            catch
            {
                return "";
            }
        }

        private bool isheart(byte[] s)
        {
            if (s==null||s.Length < 0)
                return false;
            try
            {
                
                return ((((s.Length == 5) && (Convert.ToInt32(s[0]) == 2)) && ((Convert.ToInt32(s[1]) == 1) && (Convert.ToInt32(s[2]) == 0))) && ((Convert.ToInt32(s[3]) == 0xfe) && (Convert.ToInt32(s[4]) == 3)));
            }
            catch
            {
                return false;
            }
        }

        private bool IsLast(byte[] data)
        {
            if (data == null || data.Length < 0)
                return false;
            try
            {
                if (Convert.ToInt32(data[3]) == 0x4d)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool isregst(byte[] by)
        {
            if (by == null || by.Length < 0)
                return false;
            try
            {
                int num;
                if (by.Length != 0x15)
                {
                    return false;
                }
                if (by.Length <= 20)
                    return false;
                for (num = 0; num < 4; num++)
                {
                    int num2 = Convert.ToInt32(by[num]);
                    if ((num2 < 0) || (num2 > 0xff))
                    {
                        return false;
                    }
                }
                for (num = 0x10; num < 20; num++)
                {
                    int num3 = Convert.ToInt32(by[num]);
                    if ((num3 < 0) || (num3 > 0xff))
                    {
                        return false;
                    }
                }
                for (num = 4; num < 15; num++)
                {
                    int num4 = Convert.ToInt32(by[num]);
                    if ((num4 < 0x30) || (num4 > 0x39))
                    {
                        return false;
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
        /// 刷新操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                List<TCPData> list = new List<TCPData>();
                lock (this.locker)
                {
                    foreach (int num in this._hsable.Keys)
                    {
                        try
                        {
                            TCPData item = this._hsable[num];
                            if (item != null && item.RefreshTime != null)
                            {
                                if (item.IsOnline && item.RefreshTime!=null)
                                {
                                     
                                        TimeSpan span = (TimeSpan)(DateTime.Now - item.RefreshTime);
                                        if (span.TotalSeconds > this.receivetimeout)//接收数据的超时时间
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
                   
                    list.Clear();
                    list = null;
                }
               
            }
            catch  
            {
                 
            }
        }
        /// <summary>
        /// 向用户发送数据
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public bool Send(string ID, byte[] Data, out string error, bool IsAsync)
        {
            error = "";
            ID = ID.Trim();
            int connectionId = this.IdToInnerid(ID);

            if (connectionId == -1)
            {
                error = "connectionId 不存在";
                return false;
            }
            try
            {
                if (svr!=null&&Data.Length > 0)
                {
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
        public bool SendTest(string ID, byte[] Data,out string msg,out string error,bool IsAsync)
        {
            error = "";
            ID = ID.Trim();
            int connectionId = this.IdToInnerid(ID);
            msg = " ID=" + ID + " connectionId=" + connectionId;
            if (connectionId == -1)
            {
                return false;
            }
            try
            {
                if (svr != null && Data.Length > 0)
                {
                    this.svr.Send(connectionId, Data, out error, IsAsync);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 启动服务
        /// </summary>
        public void Start()
        {
            try
            {
                this.svr.Start();
                this.RefreshTimer.Start();
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop()
        {
            try
            {
                this._hsable.Clear();
                this._hsable_id_innerid.Clear();
                this.RefreshTimer.Stop();
                this.svr.Shutdown();
            }
            catch
            {

            }
        }


        /// <summary>
        /// 数据事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void svr_OnDataIn(object sender, TCPDataInEventArgs e)
        {
            if (((sender != null) && (e != null)) && ((e.Data != null) && (e.Data.Length >= 0)))
            {
                try
                {
                  

                    bool flag;
                    TCPData data;
                    int connectionId = e.ConnectionId;
                    byte[] s = (byte[])e.Data.Clone();
                    string tcpdataid = this.InneridToId(connectionId);

                    DateTime now = DateTime.Now;
                    lock (this.locker)
                    {
                        flag = this._hsable.TryGetValue(connectionId, out data);
                    }
                    if (data != null)
                    {
                        data.ADDRESS = tcpdataid;
                    }

                    if (flag)//如果已经存在了这个设备连接,则要求用户要替换
                    {
                        data.RefreshTime = now;
                        if (!data.IsOnline)
                        {
                            data.IsOnline = true;
                            if (this.ClientConnect != null)//通知用户重新上线
                            {
                                this.ClientConnect(this, new TCPEventArgs(data, "这种情况是数据连接超时导致重新连接"));
                            }
                        }
                        data.DataByte = e.Data;
                        if (this.ReceiveData != null)
                        {
                            this.ReceiveData(this, new TCPEventArgs(data, "数据正常接收"));
                        }

                        lock (this.locker)
                        {
                            this._hsable.Remove(connectionId);//删除原来的
                            _hsable_id_innerid.Remove(data.ADDRESS);//删除原来的

                            this._hsable.Add(connectionId, data);
                            this._hsable_id_innerid.Add(data.ADDRESS, connectionId);//--原来的

                        }

                    }
                    else//如果不存在这个连接，则要进行注册
                    {
                        data = new TCPData();
                        data.ADDRESS = "";
                        data.IP = e.socket.RemoteEndPoint.ToString();
                        data.DataByte = s;
                        data.LoginTime = now;
                        data.RefreshTime = now;
                        if (this.isregst(s))
                        {
                            data.IsOnline = true;
                        }
                        lock (this.locker)
                        {
                            this._hsable.Remove(connectionId);//删除原来的
                            _hsable_id_innerid.Remove(data.ADDRESS);//删除原来的
                            this._hsable.Add(connectionId, data);
                            this._hsable_id_innerid.Add(data.ADDRESS, connectionId);//--原来的

                        }
                        if (this.ClientConnect != null)
                        {
                            this.ClientConnect(this, new TCPEventArgs(data, "重连数据"));
                        }
                        if (this.ReceiveData != null)
                        {

                            this.ReceiveData(this, new TCPEventArgs(data, "发送到正常数据"));
                        }
                    }
                    if (this.isregst(s))
                    {
                        int num2;
                        string iD = e.socket.RemoteEndPoint.ToString();
                        bool flag2 = false;
                        lock (this.locker)
                        {
                            if (this._hsable_id_innerid.TryGetValue(iD, out num2))
                            {
                                flag2 = true;
                                this._hsable.Remove(num2);
                                this._hsable_id_innerid.Remove(iD);
                            }
                        }
                        if (flag2)
                        {
                            this.svr.Disconnect(num2);
                        }

                        data = new TCPData
                        {
                            ADDRESS = iD,
                            IP= iD,
                            LoginTime = now,
                            RefreshTime = now,
                            IsOnline = true
                        };
                        lock (this.locker)
                        {
                            this._hsable.Add(connectionId, data);
                            this._hsable_id_innerid.Add(iD, connectionId);
                        }
                        if (this.ClientConnect != null)
                        {
                            this.ClientConnect(this, new TCPEventArgs(data, "非正常链接，则取消"));
                        }
                    }
                    else if (this.isheart(s))//表示心跳数据
                    {
                    }
                    else
                    {
                        this.svr.Disconnect(connectionId);
                        //马勇增加用来判断为什么不自动重新连
                        if (this.ClientClose != null)
                        {
                            this.ClientClose(this, new TCPEventArgs(data, "接收到非正常数据，连接退出"));
                        }
                    }
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
                TCPData data;
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
                        this._hsable_id_innerid.Remove(data.ADDRESS);
                        this._hsable.Remove(connectionId);
                    }
                    data.IsOnline = false;
                    if (this.ClientClose != null)
                    {
                        this.ClientClose(this, new TCPEventArgs(data,"设备链接超时导致下线"));
                    }
                  
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
                        TCPData data = this._hsable[num2];
                        if (data.IsOnline)
                        {
                            num++;
                        }
                    }
                }
                return num;
            }
        }
        
        public delegate void TCPEvent(object sender, TCPEventArgs e);

        public delegate void TCPEventN();
    }
}

