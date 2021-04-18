using AsyncTcp.Net;
using ScadaCenterServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScadaCenterServer
{
    /// <summary>
    /// 数据中心服务任务
    /// </summary>
    public class IOCenterServer
    {
        public CenterServerConfig IOConfig = null;
        public EventHandler MessageEvent;
        private  string GetLocalIp()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }
        AsyncTcpClient RemoteTcpClient = null;
        /// <summary>
        /// 数据中心服务
        /// </summary>
        /// <returns></returns>
        private async Task StartTask()
        {
            IOConfig = new CenterServerConfig();

           
            //////////监听端处理
            int port = 8888;//默认是8888端口
            int.TryParse(IOConfig.LocalPort, out port);
            var server = new AsyncTcpListener
            {
                //获取本机IP地址
                IPAddress = IPAddress.Parse(GetLocalIp()),
                Port = port,
                ClientConnectedCallback = tcpClient =>
                    new AsyncTcpClient
                    {
                        //获取或设置要使用的TcpClient。仅适用于接收
                        ServerTcpClient = tcpClient,
                        //连接服务器成功
                        ConnectedCallback = async (serverClient, isReconnected) =>
                        {
                            await Task.Delay(100);
                            if (MessageEvent != null)
                            {
                                MessageEvent(serverClient.IPAddress.ToString() + "连接成功: ", null);
                            }
                            //服务器连接成功
                        },
                        //接收客户端数据,并处理
                        ReceivedCallback = async (serverClient, count) =>
                        {
                         
                            byte[] bytes = serverClient.ByteBuffer.Dequeue(count);
                            string message = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                            if (MessageEvent != null)
                            {
                                MessageEvent(serverClient.IPAddress.ToString() + "SendData: " + message, null);
                            }
                            string[] infos = message.Split('-');
                            switch (infos[0])
                            {
                                case "SELECT"://查询sql语句
                                    break;
                                case "UPDATE"://更新sql语句
                                    break;
                                case "INSERT"://插入sql语句
                                    break;
                                case "DELETE"://删除sql语句
                                    break;
                                case "PUBLISH"://采集站发布
                                    break;

                            }
                            //发送数据或者执行操作
                            bytes = Encoding.UTF8.GetBytes("You said: " + message);
                            await serverClient.Send(new ArraySegment<byte>(bytes, 0, bytes.Length));
                            //断开连接,防止长时间被占用
                            serverClient.Disconnect();
                        }
                    }.RunAsync()
            };

            server.Message += (s, a) => {

                if (MessageEvent != null)
                {
                    MessageEvent("Server: " + a.Message, null);
                }

            };
            var serverTask = server.RunAsync();
            server.Stop(true);
            await serverTask;
        }

        public async Task SendDataTask(byte[] bytes)
        {
            // 用户要发送的数据
            if (!RemoteTcpClient.IsClosing)
            {


                if (bytes.Length <= 0)
                {
                    // Close the client connection
                    RemoteTcpClient.Disconnect();
                    return;
                }
                await RemoteTcpClient.Send(new ArraySegment<byte>(bytes, 0, bytes.Length));

                // Wait for server response or closed connection
                await RemoteTcpClient.ByteBuffer.WaitAsync();

            }
            else
            {
                if (MessageEvent != null)
                {
                    MessageEvent("发送数据失败: 远程主机已经关闭此连接", null);
                }
            }
        }
        
    }
}
