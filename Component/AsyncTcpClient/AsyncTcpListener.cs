// Copyright (c) 2018, Yves Goergen, https://unclassified.software
//
// Copying and distribution of this file, with or without modification, are permitted provided the
// copyright notice and this notice are preserved. This file is offered as-is, without any warranty.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scada.AsyncNetTcp.Net
{
    public delegate void  TCPExceptionHandle(Exception ex);
	/// <summary>
	/// Listens asynchronously for connections from TCP network clients.
	/// </summary>
	public class AsyncTcpListener
	{
        #region Private data
        /// <summary>
        /// 是否使用包的标识，如果启用，则在true，否则false
        /// </summary>
        /// <summary>
        /// 是否使用包的标识，如果启用，则在true，否则false,主要针对
        /// </summary>
        public bool UsedPackageIdentification = TcpPackConfig.UsedPackageIdentification;
        //心跳值，客户端不断与服务器端进定期握手
        public string HeartBeat = TcpPackConfig.HeartBeat;
        public int HeartBeatSize
        {
            get
            {
                byte[] bytes = Encoding.UTF8.GetBytes(HeartBeat);
                return bytes.Length;
            }


        }
        /// <summary>
        /// The buffer index of the first byte to dequeue.
        /// </summary>
        public byte[] HeartBeatBytes
        {

            get { return Encoding.UTF8.GetBytes(HeartBeat); }
        }

        //包开始字符串
        public string HeadPack = TcpPackConfig.HeadPack;
        public int HeadPackSize
        {
            get
            {
                byte[] bytes = Encoding.UTF8.GetBytes(HeadPack);
                return bytes.Length;
            }

        }
        /// <summary>
        /// The buffer index of the first byte to dequeue.
        /// </summary>
        public byte[] HeadPackBytes
        {

            get { return Encoding.UTF8.GetBytes(HeadPack); }
        }
        // 包的尾部结束字符
        public string TailPack = TcpPackConfig.TailPack;
        public int TailPackSize
        {
            get
            {
                byte[] bytes = Encoding.UTF8.GetBytes(TailPack);
                return bytes.Length;
            }

        }
        /// <summary>
        /// The buffer index of the first byte to dequeue.
        /// </summary>
        public byte[] TailPackBytes
        {

            get { return Encoding.UTF8.GetBytes(TailPack); }
        }
        public int PackInvalidSize
        {
            get { return HeadPackSize + TailPackSize + MACSize + ClientTypeSize; }
        }
        /// <summary>
        /// 获取网卡字节数组
        /// </summary>
        public byte[] MACBtyes
        {

            get { return Encoding.UTF8.GetBytes(TcpHostMAC.GetMAC()); }
        }
        /// <summary>
        /// MAC地址字节长度
        /// </summary>
        public int MACSize
        {

            get { return Encoding.UTF8.GetBytes(TcpHostMAC.GetMAC()).Length; }
        }
        /// <summary>
        /// 客户端标记
        /// </summary>
        public int ClientTypeSize
        {

            get { return 1; }
        }
        /// <summary>
        /// 标识客户端是属于那种类型的
        /// </summary>
        public ScadaClientType ScadaClientType = ScadaClientType.IoServer;
        /// <summary>
        /// 判断命令是否有效命令
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool IsOperator(byte op)
        {
            int Max = int.MinValue;
            int Min = int.MaxValue;
            foreach (int i in Enum.GetValues(typeof(ScadaTcpOperator)))
            {
                if (i > Max) Max = i;
                if (i < Min) Min = i;
            }
            if (op >= Min && Min <= Max)
                return true;
            else
                return false;


        }
        private TcpListener tcpListener;
		private volatile bool isStopped;
		private bool closeClients;
        public event TCPExceptionHandle TCPExceptionEvent;

        #endregion Private data

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="AsyncTcpListener"/> class.
        /// </summary>
        public AsyncTcpListener()
		{
			// Just for the documentation
		}

        #endregion Constructors

        #region Events

        /// <summary>
        /// Occurs when a trace message is available.
        /// </summary>
        public event EventHandler<AsyncTcpEventArgs> Message;

		#endregion Events

		#region Properties

		/// <summary>
		/// Gets or sets the local IP address to listen on. Default is all network interfaces.
		/// </summary>
		public IPAddress IPAddress { get; set; } = IPAddress.IPv6Any;

		/// <summary>
		/// Gets or sets the port on which to listen for incoming connection attempts.
		/// </summary>
		public int Port { get; set; }

        /// <summary>
        /// Called when a pending connection request was accepted. When this method completes, the
        /// client connection will be closed.
        /// </summary>
        /// <remarks>
        /// This callback method may not be called when the <see cref="OnClientConnected"/> method
        /// is overridden by a derived class.
        /// 在接受挂起的连接请求时调用。当此方法完成时
        /// 客户端连接将关闭。

        /// </remarks>
        public Func<TcpClientEx, Task> ClientConnectedCallback { get; set; }



        #endregion Properties

        #region Public methods
        ConcurrentDictionary<TcpClientEx, bool> clients = new ConcurrentDictionary<TcpClientEx, bool>();
        public ConcurrentDictionary<TcpClientEx, bool> Clients
        {
            get { return clients; }
        }
       
        /// <summary>
        /// Starts listening asynchronously for incoming connection requests.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task RunAsync()
		{
			if (tcpListener != null)
            {
                if(TCPExceptionEvent!=null)
                {
                    TCPExceptionEvent(new InvalidOperationException("ERROR10029侦听器已在运行"));
                }
                return;
            }
			
			if (Port <= 0 || Port > ushort.MaxValue)
            {

                if (TCPExceptionEvent != null)
                {
                    TCPExceptionEvent(new ArgumentOutOfRangeException(nameof(Port)));
                }
                return;
            }
		 

			isStopped = false;
			closeClients = false;

			tcpListener = new TcpListener(IPAddress, Port);
          

            tcpListener.Start();
			Message?.Invoke(this, new AsyncTcpEventArgs("等待连接"));

            clients = new ConcurrentDictionary<TcpClientEx, bool>();   // bool is dummy, never regarded
			var clientTasks = new List<Task>();
			try
			{
				while (true)
				{
                 
                    TcpClient tc;
                    TcpClientEx tcpClient = null; ;
                        try
                        {
                
                            tc = await tcpListener.AcceptTcpClientAsync();
                            tcpClient = new TcpClientEx(tc);

                            tcpClient.ReceiveTimeout = TcpPackConfig.ReceiveTimeout;
                            tcpClient.SendTimeout = TcpPackConfig.SendTimeout;
                            tcpClient.SendBufferSize = TcpPackConfig.SendBufferSize;
                            tcpClient.ReceiveBufferSize = TcpPackConfig.ReceiveBufferSize;
               

                      

                        }
                        catch (ObjectDisposedException) when (isStopped)
                        {
                            // Listener was stopped
                            break ;
                        }
                        var endpoint = tcpClient.Client.RemoteEndPoint;
                        Message?.Invoke(this, new AsyncTcpEventArgs("客户端连接来自 " + endpoint));
                        clients.TryAdd(tcpClient, true);
                        var clientTask = Task.Run(async () =>
                        {
                            await OnClientConnected(tcpClient);
                            tcpClient.Dispose();
                            Message?.Invoke(this, new AsyncTcpEventArgs("与客户端连接 " + endpoint + "已经断开"));
                            bool _value = false;
                            clients.TryRemove(tcpClient, out _value);
                        });
                        clientTasks.Add(clientTask);
                 
                   
				}
			}
            catch(Exception ex)
            {
                string str = ex.Message;
            }
			finally
			{
				if (closeClients)
				{
					Message?.Invoke(this, new AsyncTcpEventArgs("关闭，关闭所有客户端连接"));
					foreach (var tcpClient in clients.Keys)
					{
						tcpClient.Dispose();
					}
					await Task.WhenAll(clientTasks);
					Message?.Invoke(this, new AsyncTcpEventArgs("已完成所有客户端连接"));
				}
				else
				{
					Message?.Invoke(this, new AsyncTcpEventArgs("关闭时，客户端连接保持打开状态"));
				}
				clientTasks.Clear();
				tcpListener = null;
			}
		}
        //向客户端发送数据
        public   void Send(TcpClientEx tcpClient, ArraySegment<byte> datas)
        {
            if (tcpClient != null && tcpClient.Connected)
            {
                try
                {
                    NetworkStream stream = tcpClient.GetStream();
                    if (stream != null)
                    {

                        int num = 0;
                        while (!stream.CanWrite && tcpClient != null && tcpClient.Connected)
                        {
                            num++;
                            if (num > 10)
                            {
                                return;
                            }
                            Thread.Sleep(1000);
                            continue;
                        }
                        SplitPakeage splitPakeage = new SplitPakeage();
                        byte[] newData = splitPakeage.AssembleBytes(datas, this);
        
                          stream.WriteAsync(newData, 0, newData.Length);
                        stream.Flush();
                       
                        TcpPackConfig.SendDelayTime();

                    }

                }
                catch { }



            }
        }
        
        /// <summary>
        /// Closes the listener.
        /// </summary>
        /// <param name="closeClients">指定是否也应关闭接受的连接。</param>
        public void Stop(bool closeClients)
		{
			if (tcpListener == null)
            {

                if (TCPExceptionEvent != null)
                {
                    TCPExceptionEvent(new InvalidOperationException("ERROR10030 侦听器未启动."));
                }
                return;
            }
		 

			this.closeClients = closeClients;
			isStopped = true;
			tcpListener.Stop();
		}

		#endregion Public methods

		#region Protected virtual methods

		/// <summary>
		/// Called when a pending connection request was accepted. When this method completes, the
		/// client connection will be closed.
		/// </summary>
		/// <param name="tcpClient">The <see cref="TcpClient"/> that represents the accepted connection.</param>
		/// <returns>The task object representing the asynchronous operation.</returns>
		protected virtual Task OnClientConnected(TcpClientEx tcpClient)
		{
			if (ClientConnectedCallback != null)
			{
				return ClientConnectedCallback(tcpClient);
			}
			return Task.CompletedTask;
		}

		#endregion Protected virtual methods
	}

	/// <summary>
	/// Listens asynchronously for connections from TCP network clients.
	/// </summary>
	/// <typeparam name="TClient">The type to instantiate for accepted connection requests.</typeparam>
	public class AsyncTcpListener<TClient>
		: AsyncTcpListener
		where TClient : AsyncTcpClient, new()
	{
		#region Constructors

		/// <summary>
		/// Initialises a new instance of the <see cref="AsyncTcpListener{TClient}"/> class.
		/// </summary>
		public AsyncTcpListener()
		{
		}

		#endregion Constructors

		#region Overridden methods

		/// <summary>
		/// Instantiates a new <see cref="AsyncTcpClient"/> instance of the type
		/// <typeparamref name="TClient"/> that runs the accepted connection.
		/// </summary>
		/// <param name="tcpClient">The <see cref="TcpClient"/> that represents the accepted connection.</param>
		/// <returns>The task object representing the asynchronous operation.</returns>
		/// <remarks>
		/// This implementation does not call the <see cref="OnClientConnected"/> callback method.
		/// </remarks>
		protected override Task OnClientConnected(TcpClientEx tcpClient)
		{
			var client = new TClient
			{
				ServerTcpClient = tcpClient
			};
			return client.RunAsync();
		}

		#endregion Overridden methods
	}
}
