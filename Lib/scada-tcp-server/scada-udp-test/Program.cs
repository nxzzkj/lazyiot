using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using scada_udp_server;

namespace scada_udp_test
{
    class Program
    {
        static ScadaUDPAsyncServer server;
        static void Main(string[] args)
        {

            ScadaLogManager.Logger = new MyLogger();
            server = ScadaUDPServer.CreateUDPServer("wiker", 8002);
            //下面的事件都是可以用的
            //server.CompletedSend += 发送完成事件
            //server.PrepareSend += 发送数据之前的事件
            //server.NetError += 网络接收错误事件
            //server.OtherException += 其它异常事件
            server.ReceiveBufferSize += 1024;
            int cnt = 0;

            server.DataReceived += (asyncServer, arg) =>
            {
                ScadaStrBody strBody = (ScadaStrBody)arg.UdpBody;
                cnt++;
                Console.WriteLine("Server 接收："+strBody.Content+",CNT="+cnt);
                asyncServer.Send(arg.State.remote, "Hello client,Server time:"+DateTime.Now);
            };
            server.Start();
            Thread t = new Thread(SendTest);
            t.Start();
            Thread.Sleep(1000000);

        }
        static void SendTest()
        {
            for(int i = 0; i < 10; i++)
            {
                server.Send(new IPEndPoint(IPAddress.Parse("10.10.10.10"), 6070), "test");
                Thread.Sleep(10);
            }
            System.Environment.Exit(0);
        }
    }

    public class MyLogger : ScadaLogger
    {
        public ScadaLogManager CreateLogManager(Type type)
        {
            return new LogManager();
        }
    }
}
