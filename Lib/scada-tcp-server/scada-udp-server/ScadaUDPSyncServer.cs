using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace scada_udp_server
{
    /// <summary>
    ///  同步的UDP Server
    /// </summary>
    public class ScadaUDPSyncServer
    {
        #region Fields  

        public UDPServerType ServerType { get; set; } = UDPServerType.ASCII;

        /// <summary>  
        /// 当前的连接的客户端数  
        /// </summary>  
        //private int _clientCount;  

        /// <summary>  
        /// 服务器使用的异步UdpClient  
        /// </summary>  
        private UdpClient _server;

        /// <summary>  
        /// 客户端会话列表  
        /// </summary>  
        //private List<AsyncUDPState> _clients;  

        private bool disposed = false;

        #endregion

        #region Properties  
        public int ReceiveBufferSize { get; set; } = 1024;
        /// <summary>  
        /// 服务器是否正在运行  
        /// </summary>  
        public bool IsRunning { get; private set; }
        /// <summary>  
        /// 监听的IP地址  
        /// </summary>  
        public IPAddress Address { get; private set; }
        /// <summary>  
        /// 监听的端口  
        /// </summary>  
        public int Port { get; private set; }
        /// <summary>  
        /// 通信使用的编码  
        /// </summary>  
        public Encoding Encoding { get; set; }

        public string Name { get; set; }

        #endregion

        #region 构造函数  

        /// <summary>  
        /// 同步UdpClient UDP服务器  
        /// </summary>  
        /// <param name="listenPort">监听的端口</param>  
        public ScadaUDPSyncServer(int listenPort)  
            : this(IPAddress.Any, listenPort,1024)  
        {
        }

        /// <summary>  
        /// 同步UdpClient UDP服务器  
        /// </summary>  
        /// <param name="localEP">监听的终结点</param>  
        public ScadaUDPSyncServer(IPEndPoint localEP)  
            : this(localEP.Address, localEP.Port,1024)  
        {
        }

        /// <summary>  
        /// 同步UdpClient UDP服务器  
        /// </summary>  
        /// <param name="localIPAddress">监听的IP地址</param>  
        /// <param name="listenPort">监听的端口</param>  
        /// <param name="maxClient">最大客户端数量</param>  
        public ScadaUDPSyncServer(IPAddress localIPAddress, int listenPort, int maxClient)
        {
            this.Address = localIPAddress;
            this.Port = listenPort;
            this.Encoding = Encoding.Default;

            //_clients = new List<AsyncUDPSocketState>();  
            _server = new UdpClient(new IPEndPoint(this.Address, this.Port));
            _server.Client.ReceiveBufferSize = ReceiveBufferSize;
        }

        #endregion

        #region Method  
        /// <summary>  
        /// 启动服务器  
        /// </summary>  
        /// <returns>异步TCP服务器</returns>  
        public void Start()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                _server.EnableBroadcast = true;
                new Thread(ReceiveData).Start();
            }
        }

        /// <summary>  
        /// 停止服务器  
        /// </summary>  
        public void Stop()
        {
            if (IsRunning)
            {
                IsRunning = false;
                _server.Close();
            }
        }
        /// <summary>  
        /// 触发网络错误事件  
        /// </summary>  
        /// <param name="state"></param>  
        private void RaiseNetError(AsyncUDPState state, Exception exception)
        {
            NetError?.Invoke(this, new ScadaUDPEventArgs(exception, state));
        }

        /// <summary>  
        /// 同步接收数据的方法  
        /// </summary>  
        /// <param name="ar"></param>  
        private void ReceiveData()
        {
            IPEndPoint remote = null;
            while (true)
            {
                byte[] buffer = null;
                try
                {
                    buffer = _server.Receive(ref remote);
                }
                catch (Exception e)
                {
                    RaiseNetError(null, e);
                    return;
                }
                if (buffer == null || buffer.Length == 0) return;

                AsyncUDPState udpReceiveState = new AsyncUDPState();
                udpReceiveState.remote = remote;
                udpReceiveState.udpClient = _server;
                RaiseDataReceived(udpReceiveState,buffer);
            }
        }

        /// <summary>  
        /// 同步发送数据  
        /// </summary>  
        /// <param name="msg"></param>  
        /// <param name="remote"></param>  
        public void Send(string msg, IPEndPoint remote)
        {
            byte[] data = Encoding.Default.GetBytes(msg);
            try
            {
                _server.Send(data, data.Length, remote);
            }
            catch (Exception e)
            {
                RaiseOtherException(null,e);
            }
        }

        public void Send(IPEndPoint remote, byte[] bits)
        {
            try
            {
                _server.Send(bits, bits.Length, remote);
            }
            catch (Exception e)
            {
                RaiseOtherException(null,e);
            }
        }

        public void Send(IPEndPoint remote, ScadaUDPBody body)
        {
            Send(remote, body.BodyBytes);
        }

        public void Send(IPEndPoint remote, string msg)
        {
            Send(remote, Encoding.ASCII.GetBytes(msg));
        }

        public void Send(string ip, int port, string msg)
        {
            IPEndPoint remote = new IPEndPoint(IPAddress.Parse(ip), port);
            Send(remote, Encoding.ASCII.GetBytes(msg));
        }

        public void Send(string ip, int port, byte[] bits)
        {
            IPEndPoint remote = new IPEndPoint(IPAddress.Parse(ip), port);
            Send(remote, bits);
        }

        #endregion

        #region 事件  
        /// <summary>  
        /// 接收到数据事件  
        /// </summary>  
        public event EventHandler<ScadaUDPEventArgs> DataReceived;

        private void RaiseDataReceived(AsyncUDPState state, byte[] buffer)
        {
            DataReceived?.Invoke(this,
                ServerType == UDPServerType.ASCII
                    ? new ScadaUDPEventArgs(new ScadaStrBody(buffer,state.remote), state)
                    : new ScadaUDPEventArgs(new ScadaUDPBody(buffer,state.remote), state));
        }

        /// <summary>  
        /// 数据发送完毕事件  
        /// </summary>  
        public event EventHandler<ScadaUDPEventArgs> CompletedSend;

        /// <summary>  
        /// 触发数据发送完毕的事件  
        /// </summary>  
        /// <param name="state"></param>  
        private void RaiseCompletedSend(AsyncUDPState state)
        {
            if (CompletedSend != null)
            {
                CompletedSend(this, new ScadaUDPEventArgs(state));
            }
        }

        /// <summary>  
        /// 网络错误事件  
        /// </summary>  
        public event EventHandler<ScadaUDPEventArgs> NetError;
        /// <summary>  
        /// 触发网络错误事件  
        /// </summary>  
        /// <param name="state"></param>  
        private void RaiseNetError(AsyncUDPState state)
        {
            if (NetError != null)
            {
                NetError(this, new ScadaUDPEventArgs(state));
            }
        }

        /// <summary>  
        /// 异常事件  
        /// </summary>  
        public event EventHandler<ScadaUDPEventArgs> OtherException;
        /// <summary>  
        /// 触发异常事件  
        /// </summary>  
        /// <param name="state"></param>  
        private void RaiseOtherException(AsyncUDPState state, Exception exception)
        {
            OtherException?.Invoke(this, new ScadaUDPEventArgs(exception, state));
        }
        #endregion

        #region Close  
        /// <summary>  
        /// 关闭一个与客户端之间的会话  
        /// </summary>  
        /// <param name="state">需要关闭的客户端会话对象</param>  
        public void Close(AsyncUDPState state)
        {
            if (state != null)
            {
                //_clients.Remove(state);  
                //_clientCount--;  
            }
        }
        /// <summary>  
        /// 关闭所有的客户端会话,与所有的客户端连接会断开  
        /// </summary>  
        public void CloseAllClient()
        {
            //foreach (AsyncUDPSocketState client in _clients)  
            //{  
            //    Close(client);  
            //}  
            //_clientCount = 0;  
            //_clients.Clear();  
        }

        #endregion

        #region 释放  
        /// <summary>  
        /// Performs application-defined tasks associated with freeing,   
        /// releasing, or resetting unmanaged resources.  
        /// </summary>  
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>  
        /// Releases unmanaged and - optionally - managed resources  
        /// </summary>  
        /// <param name="disposing"><c>true</c> to release   
        /// both managed and unmanaged resources; <c>false</c>   
        /// to release only unmanaged resources.</param>  
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    try
                    {
                        Stop();
                        if (_server != null)
                        {
                            _server = null;
                        }
                    }
                    catch (SocketException e)
                    {
                        RaiseOtherException(null,e);
                    }
                }
                disposed = true;
            }
        }
        #endregion
    }
}
