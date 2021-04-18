// Copyright (c) 2018, Yves Goergen, https://unclassified.software
//
// Copying and distribution of this file, with or without modification, are permitted provided the
// copyright notice and this notice are preserved. This file is offered as-is, without any warranty.

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Scada.AsyncNetTcp.Util;
using System.Text;
using Scada.Model;
using System.Collections.Generic;

namespace Scada.AsyncNetTcp.Net
{
	/// <summary>
	/// Provides asynchronous client connections for TCP network services.
	/// </summary>
	/// <remarks>
	/// This class can be used directly when setting the relevant callback methods
	/// <see cref="ConnectedCallback"/>, <see cref="ClosedCallback"/> or
	/// <see cref="ReceivedCallback"/>. Alternatively, a class inheriting from
	/// <see cref="AsyncTcpClient"/> can implement the client logic by overriding the protected
	/// methods.
	/// </remarks>
	public class AsyncTcpClient : IDisposable
	{
  
        public event HeartBeatHandle OnHeartBeat;
        System.Threading.Timer HeartBeatTimer = null;
        /// <summary>
        /// 是否使用包的标识，如果启用，则在true，否则false,主要针对
        /// </summary>
        public bool UsedPackageIdentification = TcpPackConfig.UsedPackageIdentification;
    
        //是否启用心跳连接
        public bool UsedHeartBeat = true;
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

            get { return MACBtyes.Length; }
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
        public ScadaClientType ScadaClientType = ScadaClientType.IoMonitor;
        public string MAC
        {
            get { return TcpHostMAC.GetMAC(); }
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
        //系统加入的包数据的总共字节数
        public int PackInvalidSize
        {
            get { return HeadPackSize + TailPackSize+MACSize+ ClientTypeSize; }
        }
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
      
        public event TCPExceptionHandle TCPExceptionEvent;
        #region Private data

        private TcpClientEx tcpClient;
		private NetworkStream stream;
		private TaskCompletionSource<bool> closedTcs = new TaskCompletionSource<bool>();

        #endregion Private data

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="AsyncTcpClient"/> class.
        /// </summary>
        public   AsyncTcpClient()
        {
            closedTcs.SetResult(true);
            //心跳设置
            HeartBeatTimer = new Timer(delegate
            {
                if (tcpClient != null && tcpClient.Connected && UsedHeartBeat)
                {
                    try
                    {
                         Send(new ArraySegment<byte>(Encoding.UTF8.GetBytes(this.HeartBeat)));
                        if (OnHeartBeat != null)
                        {
                            OnHeartBeat(this, tcpClient.Connected);
                        }
                    }
                    catch
                    {
                        
                    }
                }

            }, null, 1000, 1000 * 30);//每10秒发送一次心跳包，保证连接正常

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
        /// Gets or sets the <see cref="TcpClient"/> to use. Only for client connections that were
        /// accepted by an <see cref="AsyncTcpListener"/>.
        /// 获取或设置要使用的TcpClient。仅适用于接收
        /// </summary>
        public TcpClientEx ServerTcpClient { get; set; }
        public STATION_TCP_INFO LogUser
        {
            get {
                if(ServerTcpClient!=null)
                return ServerTcpClient.LogUser;
                else
                return null;


            }

            set {


             if(ServerTcpClient!=null)
                    ServerTcpClient.LogUser = value; }
        }

        ///<摘要>
        ///获取或设置<see cref=“AsyncTcpClient”/>等待连接的时间量
        ///一旦启动连接操作。
        /// </summary>
        public TimeSpan ConnectTimeout { get; set; } = TimeSpan.FromSeconds(5);

        /// <summary>
        ///获取或设置一个最大的时间量：“参见CREF＝“AsicCTCPclipse”/>将等待
        ///启动重复连接操作后连接。实际连接
        ///建立连接时，每次尝试和重置都会增加超时。
        /// </summary>
        public TimeSpan MaxConnectTimeout { get; set; } = TimeSpan.FromMinutes(1);

        ///<摘要>

        ///获取或设置一个值，该值指示客户端是连接关闭后重新再连接。
        ///</摘要>
        public bool AutoReconnect { get; set; }

		/// <summary>
		/// Gets or sets the name of the host to connect to.
		/// </summary>
		public string HostName { get; set; }

		/// <summary>
		/// Gets or sets the IP address of the host to connect to.
		/// Only regarded if <see cref="HostName"/> is null or empty.
		/// </summary>
		public IPAddress IPAddress { get; set; }

		/// <summary>
		/// Gets or sets the port number of the remote host.
		/// </summary>
		public int Port { get; set; }
    

        /// <summary>
        /// Gets the buffer of data that was received from the remote host.
        /// 获取从远程主机接收的数据缓冲区。
        /// </summary>
        public ByteBuffer ByteBuffer { get; private set; } = new ByteBuffer();

        /// <summary>
        ///A可以等待关闭连接的<see cref=“Task”/>。此任务将
        ///远程关闭连接时完成
        /// </summary>
        public Task ClosedTask => closedTcs.Task;

		/// <summary>
		/// Gets a value indicating whether the <see cref="ClosedTask"/> has completed.
		/// </summary>
		public bool IsClosing => ClosedTask.IsCompleted;

        ///<摘要>
        ///当客户端连接到远程主机时调用。此方法可以实现
        ///建立连接时要执行的通信逻辑。连接将
        ///在此方法完成之前不关闭。
        ///</摘要>
        ///<备注>
        ///当<see cref=“OnConnectedAsync”/>方法
        ///被派生类重写。
        ///</备注>
        public Func<AsyncTcpClient, bool, Task> ConnectedCallback { get; set; }

        ///<摘要>
        ///连接关闭时调用。参数指定连接是否
       ///已被远程主机关闭。
       ///</摘要>
        ///<备注>
        ///当<see cref=“OnClosed”/>方法
        ///被派生类重写。
        ///</备注>
        public Action<AsyncTcpClient, bool> ClosedCallback { get; set; }
        /// <summary>
        /// 连接超时返回的任务
        /// </summary>
        public Action<AsyncTcpClient, bool> ConnectedTimeoutCallback { get; set; }
        ///<摘要>
        ///从远程主机接收数据时调用。参数指定数字
        ///已接收的字节数。此方法可以实现
        ///每次收到数据时执行。在此方法之前不会接收新数据
        ///完成。
        ///当<see cref=“OnReceivedAsync”/>方法
        ///被派生类重写。
        ///</摘要>
        public Func<AsyncTcpClient, int, Task> ReceivedCallback { get; set; }

        #endregion


        #region Public methods

        /// <summary>
        /// Runs the client connection asynchronously.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task RunAsync()
		{
            ///尝试重新连接
			bool isReconnected = true;
			int reconnectTry = -1;
			do
			{
               
                reconnectTry++;
				ByteBuffer = new ByteBuffer();
				if (ServerTcpClient != null)
				{
					// Take accepted connection from listener
					tcpClient = ServerTcpClient;
          
                }
				else
				{
					// Try to connect to remote host
					var connectTimeout = TimeSpan.FromTicks(ConnectTimeout.Ticks + (MaxConnectTimeout.Ticks - ConnectTimeout.Ticks) / 20 * Math.Min(reconnectTry, 20));
					tcpClient = new TcpClientEx(AddressFamily.InterNetwork);
                    tcpClient.ReceiveTimeout = TcpPackConfig.ReceiveTimeout;
                    tcpClient.SendTimeout = TcpPackConfig.SendTimeout;
                    tcpClient.SendBufferSize = TcpPackConfig.SendBufferSize;
                    tcpClient.ReceiveBufferSize = TcpPackConfig.ReceiveBufferSize;
                 

                    Message?.Invoke(this, new AsyncTcpEventArgs("准备连接到服务器"+ IPAddress.ToString()));
					Task connectTask;
					if (!string.IsNullOrWhiteSpace(HostName))
					{
						connectTask = tcpClient.ConnectAsync(HostName, Port);
					}
					else
					{
         
                        connectTask = tcpClient.ConnectAsync(IPAddress, Port);
					}
					var timeoutTask = Task.Delay(connectTimeout);
					if (await Task.WhenAny(connectTask, timeoutTask) == timeoutTask)
					{
                        //此处增加一个连接超时的任务
						Message?.Invoke(this, new AsyncTcpEventArgs("连接超时"));
                        OnConnectedTimeout(isReconnected);//连接超时的返回

                        continue;
					}
					try
					{
						await connectTask;
					}
					catch (Exception ex)
					{
						Message?.Invoke(this, new AsyncTcpEventArgs("连接到远程主机时出错", ex));
						await timeoutTask;
						continue;
					}

          

				}
				reconnectTry = -1;
				stream = tcpClient.GetStream();


                 // 读取直到连接关闭。
                 //只有在读取时才能检测到闭合连接，因此我们需要读取
                 //永久地，不仅仅是当我们可能使用接收到的数据时。
				var networkReadTask = Task.Run(async () =>
				{
					// 10 KiB should be enough for every Ethernet packet
					byte[] buffer = new byte[TcpPackConfig.ByteBufferCapacity];
					while (true)
                    {
                        

                            int readLength;


                            try
                            {
                                //异步读取有问题
                                readLength = await stream.ReadAsync(buffer, 0, buffer.Length);
                            }
                            catch (IOException ex) when ((ex.InnerException as SocketException)?.ErrorCode == (int)SocketError.OperationAborted)
                            {
                                // Warning: This error code number (995) may change
                                Message?.Invoke(this, new AsyncTcpEventArgs("本地关闭连接", ex));
                                readLength = -1;
                            }
                            catch (IOException ex) when ((ex.InnerException as SocketException)?.ErrorCode == (int)SocketError.ConnectionAborted)
                            {
                                Message?.Invoke(this, new AsyncTcpEventArgs("连接失败", ex));
                                readLength = -1;
                            }
                            catch (IOException ex) when ((ex.InnerException as SocketException)?.ErrorCode == (int)SocketError.ConnectionReset)
                            {
                                Message?.Invoke(this, new AsyncTcpEventArgs("远程重置连接", ex));
                                readLength = -2;
                            }
                            if (readLength <= 0)
                            {
                                if (readLength == 0)
                                {
                                    Message?.Invoke(this, new AsyncTcpEventArgs("远程关闭连接"));
                                }
                                closedTcs.TrySetResult(true);
                                OnClosed(readLength != -1);
                                return;
                            }
                            //此处做处理，数据包要达到
                            var segment = new ArraySegment<byte>(buffer, 0, readLength);
                            ByteBuffer.Enqueue(segment);
                            await OnReceivedAsync(readLength);
                     
                    }
					 
				});

				closedTcs = new TaskCompletionSource<bool>();
				await OnConnectedAsync(isReconnected);

				// Wait for closed connection
				await networkReadTask;
				tcpClient.Close();

				isReconnected = true;
			}
			while (AutoReconnect && ServerTcpClient == null);
		}

        /// <summary>
        /// 常关闭插座连接。这不会释放
        /// <see cref="AsyncTcpClient"/>.
        /// </summary>
        public void Disconnect()
		{
            try
            {
                if(tcpClient!=null&& tcpClient.Connected)
                tcpClient.Client.Disconnect(false);
            }
            catch
            {

            }
		}
        /// <summary>
        /// 定义一个临时缓存，用来存储连续字节
        /// </summary>
        public List<byte[]> TemporaryByteBuffer = new List<byte[]>();
        /// <summary>
        /// 临时缓存的字节数组的总数量
        /// </summary>
        public int TemporaryBytesCount = 0;
        public int TemporaryResultBytesCount = 0;
        public string TemporaryBytesKey = "";
        public bool TemporaryByteRun = false;
        /// <summary>
        /// 计数器，接收某个数据达到指定次数认为失败
        /// </summary>
        public int TemporaryCounter = 0;
        
        /// <summary>
        /// Releases the managed and unmanaged resources used by the <see cref="AsyncTcpClient"/>.
        /// Closes the connection to the remote host and disabled automatic reconnecting.
        /// </summary>
        public void Dispose()
		{
			AutoReconnect = false;
			tcpClient?.Dispose();
            HeartBeatTimer?.Dispose();
            stream = null;
		}

        ///<摘要>
        ///异步等待，直到接收到的数据在缓冲区中可用。
        ///</摘要>
        ///<param name=“cancellation token”>用于传播应取消此操作的通知的取消令牌。</param>
        ///<returns>true，如果数据可用；false，如果连接正在关闭。</returns>
        ///<exception cref=“OperationCanceledException”>已取消<paramref name=“cancellationToken”/>。</exception>
        public async Task<bool> WaitAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return await Task.WhenAny(ByteBuffer.WaitAsync(cancellationToken), closedTcs.Task) != closedTcs.Task;
		}

        //<摘要>
        ///向远程主机发送数据。
        ///</摘要>
        ///<param name=“data”>要发送的数据。</param>
        ///<returns>表示异步操作的任务对象。</returns>
        public   void  Send(ArraySegment<byte> data)
        {
            if (tcpClient != null && tcpClient.Connected )
            {

                if (stream != null)
                {
                    int num = 0;
                    while (!stream.CanWrite && tcpClient != null && tcpClient.Connected)
                    {
                        num++;
                        if(num>10)
                        {
                            return;
                        }

                        Thread.Sleep(1000);
                        continue;
                    }
                    SplitPakeage splitPakeage = new SplitPakeage();
                    byte[] newData = splitPakeage.AssembleBytes(data, this);

                    //构造新包
                   stream.WriteAsync(newData, 0, newData.Length);
             
                    stream.Flush();
                    TcpPackConfig.SendDelayTime();

                }
         

            }
        }
 
 

        #endregion Public methods

        #region Protected virtual methods

        /// <summary>
        /// Called when the client has connected to the remote host. This method can implement the
        /// communication logic to execute when the connection was established. The connection will
        /// not be closed before this method completes.
        /// </summary>
        /// <param name="isReconnected">true, if the connection was closed and automatically reopened;
        ///   false, if this is the first established connection for this client instance.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        protected virtual Task OnConnectedAsync(bool isReconnected)
		{
			if (ConnectedCallback != null)
			{
				return ConnectedCallback(this, isReconnected);
			}
			return Task.CompletedTask;
		}
        protected   void OnConnectedTimeout(bool remote)
        {
       
            ConnectedTimeoutCallback?.Invoke(this, remote);
        }
        

        /// <summary>
        /// Called when the connection was closed.
        /// </summary>
        /// <param name="remote">true, if the connection was closed by the remote host; false, if
        ///   the connection was closed locally.</param>
        protected virtual void OnClosed(bool remote)
		{
			ClosedCallback?.Invoke(this, remote);
		}

		/// <summary>
		/// Called when data was received from the remote host. This method can implement the
		/// communication logic to execute every time data was received. New data will not be
		/// received before this method completes.
		/// </summary>
		/// <param name="count">The number of bytes that were received. The actual data is available
		///   through the <see cref="ByteBuffer"/>.</param>
		/// <returns>The task object representing the asynchronous operation.</returns>
		protected virtual Task OnReceivedAsync(int count)
		{
			if (ReceivedCallback != null)
			{
				return ReceivedCallback(this, count);
			}
			return Task.CompletedTask;
		}

		#endregion Protected virtual methods
	}

	/// <summary>
	/// Provides data for the <see cref="AsyncTcpClient.Message"/> event.
	/// </summary>
	public class AsyncTcpEventArgs : EventArgs
	{
		/// <summary>
		/// Initialises a new instance of the <see cref="AsyncTcpEventArgs"/> class.
		/// </summary>
		/// <param name="message">The trace message.</param>
		/// <param name="exception">The exception that was thrown, if any.</param>
		public AsyncTcpEventArgs(string message, Exception exception = null)
		{
			Message = message;
			Exception = exception;
		}

		/// <summary>
		/// Gets the trace message.
		/// </summary>
		public string Message { get; }

		/// <summary>
		/// Gets the exception that was thrown, if any.
		/// </summary>
		public Exception Exception { get; }
	}
}
