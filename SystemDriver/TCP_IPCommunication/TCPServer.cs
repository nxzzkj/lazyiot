namespace TcpNetworkBrige
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;

    public class TCPServer
    {
        public static byte[] KeepaliveOptionValues;
        private readonly object locker;
        private readonly Dictionary<int, ClientConnection> mClientConnections;
        private Socket mListener;
        private int Port;
        private int totle_count;
     
        private int sendBufferSize = 1024*1024*1024;//发送字节缓存
        public int SendBufferSize
        {
            set { sendBufferSize = value; }
            get { return sendBufferSize; }
        }
        private int receiveBufferSize = 1024 * 1024 * 1024;//接收字节数组缓存
        public int ReceiveBufferSize
        {
            set { receiveBufferSize = value; }
            get { return receiveBufferSize; }
        }
        private int _receivetimeout = 1000;//接收超时时间ms
        public int ReceiveTimeout
        {
            set { _receivetimeout = value; }
            get { return _receivetimeout; }
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
        

        public event OnConnectedHandler mOnConnected;

        public event ClientErrorEvent mOnError;

        public event OnDataInHandler OnDataIn;

        public event OnDisconnectedHandler OnDisconnected;

        public TCPServer(int port)
            : this(port, true, 600000, 3000)
        {
            this.Port = port;
        }
      
        public TCPServer(int port, bool keepAliveEnable, int keepAliveIdle, int keepAliveInterval)
        {
            this.mClientConnections = new Dictionary<int, ClientConnection>();
            this.locker = new object();
            this.Port = port;
            KeepaliveOptionValues = GetKeepaliveOptionValues(keepAliveEnable, keepAliveIdle, keepAliveInterval);
        }

        public void Disconnect(int ConnectionId)
        {
            if (ConnectionId <= 0)
                return;
            try
            {
                 
                ClientConnection connection;
                lock (this.locker)
                {
                    if (!this.mClientConnections.ContainsKey(ConnectionId))
                    {
                        return;
                    }
                    connection = this.mClientConnections[ConnectionId];
                }
                if (connection != null)
                {
                   
                    connection.Socket.Close();
                    mClientConnections.Remove(ConnectionId);//马勇增加的，如果下线则删除对应的connect数据
                }
            }
            catch
            {

            }
        }

        private static byte[] GetKeepaliveOptionValues(bool keepAliveEnable, int keepAliveIdle, int keepAliveInterval)
        {
            try
            {
                uint structure = 0;
                byte[] array = new byte[Marshal.SizeOf(structure) * 3];
                if (array.Length<=0)
                    return new byte[0];
                BitConverter.GetBytes(keepAliveEnable ? 1 : 0).CopyTo(array, 0);
                BitConverter.GetBytes((uint)keepAliveIdle).CopyTo(array, Marshal.SizeOf(structure));
                BitConverter.GetBytes((uint)keepAliveInterval).CopyTo(array, (int)(Marshal.SizeOf(structure) * 2));
                return array;
            }
            catch
            {
                return new byte[0];
            }
        }

        private void HandleConnection(IAsyncResult parameter)
        {

            if (parameter == null)
                return;

            ClientConnection connection = null;
            try
            {
                Socket socket = this.mListener.EndAccept(parameter);

                socket.NoDelay = true;

                socket.SendBufferSize = this.sendBufferSize;
                socket.IOControl(IOControlCode.KeepAliveValues, KeepaliveOptionValues, null);
                connection = new ClientConnection(socket);


                Interlocked.Increment(ref this.totle_count);
                connection.ConnectionId = this.totle_count;
                ClearInvalid(connection);//每次创建链接的时候要删除无效链接
                lock (this.locker)
                {
                    this.mClientConnections.Add(connection.ConnectionId, connection);
                    connection.Connected();

                }
                if (this.mOnConnected != null)
                {
                    this.mOnConnected(this, new ZYBConnectedEventArgs(connection));
                }
                this.StartWaitingForData(connection);
            }
            catch (ObjectDisposedException)
            {
                this.RaiseDisconnectedEvent(connection);
            }
            catch (SocketException exception)
            {
                this.RaiseErrorEvent(connection, exception);
            }
            finally
            {
                try
                {
                    this.WaitForClient();
                }
                catch (Exception)
                {
                }
            }
        }

        private void HandleIncomingData(IAsyncResult parameter)
        {
            if (parameter == null)
                return;
            if (parameter.AsyncState == null)
                return;
           
            ClientConnection asyncState = (ClientConnection) parameter.AsyncState;
            if (asyncState.Socket == null)
            {
                Disconnect(asyncState.ConnectionId);
                return;

            }
         
            try
            {
                int length = asyncState.Socket.EndReceive(parameter);
                if (length == 0)
                {
                    this.RaiseDisconnectedEvent(asyncState);
                }
                else
                {
                    if (asyncState.Buffer.Length > 0)
                    {
                        byte[] destinationArray = new byte[length];
                        Array.Copy(asyncState.Buffer, 0, destinationArray, 0, length);
                        if (this.OnDataIn != null)
                        {
                            this.OnDataIn(this, new TCPDataInEventArgs(asyncState, destinationArray));
                        }
                        this.StartWaitingForData(asyncState);
                    }
                    else
                    {
                        this.RaiseDisconnectedEvent(asyncState);
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                this.RaiseDisconnectedEvent(asyncState);
            }
            catch (SocketException exception)
            {
                if (exception.ErrorCode == 0x2746)
                {
                    this.RaiseDisconnectedEvent(asyncState);
                }
                this.RaiseErrorEvent(asyncState, exception);
            }
        }

        private void HandleSendFinished(IAsyncResult parameter)
        {
            lock (this.locker)
            {
                if (parameter == null)
                    return;
                if (parameter.AsyncState == null)
                    return;

                ClientConnection asyncState = (ClientConnection)parameter.AsyncState;

                try
                {


                    asyncState.Socket.EndSend(parameter);
                    
                }
                catch (ObjectDisposedException)
                {
                    this.RaiseDisconnectedEvent(asyncState);
                }
                catch (SocketException exception)
                {
                    this.RaiseErrorEvent(asyncState, exception);
                }
                
            }
        }

        private void RaiseDisconnectedEvent(ClientConnection connection)
        {
            try
            {
                if (connection == null)
                    return;
             

                lock (this.locker)
                {
                    if (connection != null)
                    {

                        connection.Socket.Close();//关闭链接
                        connection.Socket.Dispose();
                        
                        this.mClientConnections.Remove(connection.ConnectionId);
                    }
                }
                if ((this.OnDisconnected != null) && (connection != null))
                {
                    this.OnDisconnected(this, new ZYBDisconnectedEventArgs(connection));
                }
            }
            catch
            {
            
            }
        }

        private void RaiseErrorEvent(ClientConnection connection, SocketException error)
        {
            if ((this.mOnError != null) && (connection != null))
            {
                this.mOnError(connection.EndPoint, error);
            }
        }

        public bool Send(int ConnectionId, byte[] buffer, out string error, bool IsAsync)
        {
            error = "";
            if (buffer.Length <= 0)
            {
                error = "要发送的数据字节为0";
                return false;
            }
            if (ConnectionId <= 0)
            {
                error = "要发送的数据的设备编号错误";
                return false;
            }
            ClientConnection connection;
            lock (this.locker)
            {
                if (!this.mClientConnections.ContainsKey(ConnectionId))
                {
                    error = "要发送的数据的设备不存在关键值不存在";
                    return false;
                }
                connection = this.mClientConnections[ConnectionId];
            }
            try
            {
                lock (this.locker)
                {
                    if (connection != null)
                    {

                        connection.Connected();
                        connection.Socket.NoDelay = true;                   
                        connection.Socket.SendTimeout = this.sendtimeout;
                        connection.Socket.IOControl(IOControlCode.KeepAliveValues, KeepaliveOptionValues, null);
                        SocketError sockerror = SocketError.Success;
                        if (connection.Socket.Poll(2000, SelectMode.SelectWrite))
                        {
                            if (IsAsync)
                            {
                                connection.Socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(this.HandleSendFinished), connection);
                            }
                            else
                            {
                                connection.Socket.Blocking = true;
                                connection.Socket.Send(buffer, 0, buffer.Length, SocketFlags.None, out sockerror);
                            }
                            error = sockerror.ToString();
                            return true;
                        }
                        else
                        {
                            error = sockerror.ToString();
                            return false;
                        }
                    }
                    else
                    {

                        error = "不存在connection";
                        return false;
                    }
                }
            }
            catch (ObjectDisposedException exception)
            {
             
                this.RaiseDisconnectedEvent(connection);
                error = exception.Message;
                return false;
            }
               
            catch (SocketException exception)
            {
           
                this.RaiseErrorEvent(connection, exception);
                error = exception.Message;
                return false;
            }
          
            catch (Exception emx)
            {
           
                error = emx.Message;
                return false;
            }
        }
        /// <summary>
        /// 删除链接无效的
        /// </summary>
        public void ClearInvalid(ClientConnection connection)
        {
          


          
            lock (this.locker)
            {
                bool exist = this.mClientConnections.ContainsValue(connection);
                if (exist)
                {
                    this.RaiseDisconnectedEvent(connection);//通知客户端有链接下线或者无效
                }
                
                   
            
            }

        }
        public void Shutdown()
        {
            try
            {
                List<ClientConnection> list = new List<ClientConnection>();
                lock (this.locker)
                {
                    foreach (ClientConnection connection in this.mClientConnections.Values)
                    {
                        list.Add(connection);
                    }
                }
                foreach (ClientConnection connection2 in list)
                {
                    connection2.Socket.Close();
                }
                lock (this.locker)
                {
                    this.mClientConnections.Clear();
                }
                this.mListener.Close();
            }
            catch
            {
               
            }
        }

        public void Start()
        { 
            this.mListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
          
            this.mListener.Bind(new IPEndPoint(IPAddress.Any, this.Port));
            this.mListener.NoDelay = true;
            this.mListener.Listen(0x186a0);
            this.WaitForClient();
       
        }
        

        private void StartWaitingForData(ClientConnection connection)
        {
            if (connection == null)
                return;
            if (connection.Buffer.Length <= 0)
                return;
            try
            {
               
                
                if (connection.Socket != null)
                {
                    connection.Connected();
                    connection.Socket.BeginReceive(connection.Buffer, 0, connection.Buffer.Length, SocketFlags.None, new AsyncCallback(this.HandleIncomingData), connection);
                }
            }
            catch
            {

            }
        }

        private void WaitForClient()
        {
            try
            {
                this.mListener.BeginAccept(new AsyncCallback(this.HandleConnection),null);
            }
            catch
            {

            }
        }
    }
}

