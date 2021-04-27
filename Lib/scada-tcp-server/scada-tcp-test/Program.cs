using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using scada_tcp_server;

namespace scada_tcp_test
{
    class Program
    {
        private static log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            if ("0".Equals(args[0]))
            {
                TestClient();
            }
            else
            {
                CreateServer(); 
            }
        }

        private static void CreateServer()
        {
            //创建一个Server，二个参数：
            // name：用于区别多个server的标志。
            // createHeader：实例化你用到的Header继承于ScadaHeader
            ScadaLogManager.Logger = new MyLogger();
            ScadaTCPAsyncServer server = ScadaTCPServer.CreateServer("test1", CreateHeader);
            server.PrintReceiveHex = true; //开启打印接收到数据的Hex
            server.PrintSendHex = true; //开启打印发送数据的Hex
            server.HeaderLength = 8; // 协议中消息头的长度。这个必须设置
            server.MainNotify += MainHandler; //一个消息接收完之后的事件处理。
            server.Start(8001);
        }

        private static void TestClient()
        {
            TcpClient tcpClient = new TcpClient("127.0.0.1",8001);
            NetworkStream ns = tcpClient.GetStream();

            while (true)
            {
                Console.Write("Enter name: ");
                string msginput = Console.ReadLine();

                //构造一个返回的消息
                TestHeader header = new TestHeader();
                header.msgId = 2;
                TestBody body = new TestBody();
                body.testVal1 = 110;
                body.testVal2 = msginput;
                ScadaTCPMsg msg = new ScadaTCPMsg(header, body);
                ns.Write(msg.MsgBytes,0,msg.MsgBytes.Length);

                header.bytes = new byte[8];
                int data = ns.Read(header.bytes, 0, 8);
                if (data > 0)
                {
                    header.Decode();
                    PrintUtils.PrintHex(header.bytes);
                    body.BodyBytes = new byte[header.bodyLength];
                    int bodyLen = ns.Read(body.BodyBytes, 0, header.bodyLength);
                    if (bodyLen > 0)
                    {
                        PrintUtils.PrintHex(body.BodyBytes);
                    }
                }

            }
        }

        private static void MainHandler(ScadaTCPHeader header, ScadaTCPBody body)
        {
            //这里一般在header中可能有消息ID。可以在这里进行区分
            TestBody test = (TestBody)body;
            TestHeader testHeader = (TestHeader)header;
            LOG.Info("我去，这里竟然回调了" + test.testVal1 + "," + test.testVal2);
            LOG.InfoFormat("回调的MsgId:{0},bodyLen:{1},from:{2}", testHeader.msgId, testHeader.bodyLength + ",", testHeader.RemoteSocket.RemoteEndPoint);
        }

        private static ScadaTCPHeader CreateHeader()
        {
            return new TestHeader();
        }
    }

    /// <summary>
    /// 消息体，继承ScadaBody,接收到消息会自动调用Decode方法，发送时会自动调用Encode方法
    /// </summary>
    public class TestBody : ScadaTCPBody
    {
        private static log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int testVal1;
        public string testVal2;

        public override void Debug()
        {
            LOG.Debug("BODY 打印了DEBUG");
        }

        public override void Info()
        {
            LOG.Info("BODY 打印了INFO");
        }

        public override void Decode()
        {
            testVal1 = ReadSmallInt();
            testVal2 = ReadStringToEnd();
        }

        //这里不是必须重写，如果重写了，服务器处理完消息后，会将此消息再发送给客户端，
        //也可以手动调用AsyncServer 的Send方法来发送消息
        public override ScadaTCPMsg GetSendMsg()
        {
            //构造一个返回的消息
            TestHeader header = new TestHeader();
            header.msgId = 2;
            TestBody body = new TestBody();
            body.testVal1 = 110;
            body.testVal2 = "Hello，"+testVal2;
            ScadaTCPMsg msg = new ScadaTCPMsg(header, body);
            msg.CloseClient = false;
            return msg;
        }

        public override void Encode()
        {
            WriteBytes(BitConverter.GetBytes(testVal1));
            WriteBytes(Encoding.ASCII.GetBytes(testVal2));
        }
    }

    /// <summary>
    /// 消息头，继承ScadaHeader,接收到消息会自动调用Decode方法，发送时会自动调用Encode方法
    /// </summary>
    public class TestHeader : ScadaTCPHeader
    {
        private static log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int msgId { get; set; }
        public override void Encode()
        {
            WriteBytes(BitConverter.GetBytes(msgId));
            WriteBytes(BitConverter.GetBytes(bodyLength));
        }


        public override void Decode()
        {
            msgId = ReadSmallInt();
            bodyLength = ReadSmallInt();
        }

        public override void Debug()
        {
            LOG.Debug("Header 打印了DEBUG");
        }

        public override void Info()
        {
            LOG.Info("Header 打印了INFO");
        }

        /// <summary>
        /// 根据当前的消息头创建一个对应的消息体
        /// </summary>
        /// <returns></returns>
        public override ScadaTCPBody InstanceBody()
        {
            return new TestBody();
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
