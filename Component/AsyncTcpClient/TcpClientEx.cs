using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Scada.Model;

namespace Scada.AsyncNetTcp
{
   public class TcpClientEx:TcpClient
    {
        //保存一些MAC关键字
        public string MACKey = "";
        /// <summary>
        /// 定义一个保存临时数据的变量
        /// </summary>
        public STATION_TCP_INFO LogUser = null;
        public TcpClientEx(AddressFamily add):base(add)
        {
            LogUser = null;
        }
        public TcpClientEx():base()
        {
            LogUser = null;

        }
        public TcpClientEx(TcpClient tc)
        {
           if (this.Client!=null)
            {
                this.Client.Close();
                this.Client.Dispose();
            
            }

            this.Client = tc.Client;
            this.LingerState = tc.LingerState;
            this.NoDelay = tc.NoDelay;
            this.ReceiveBufferSize = tc.ReceiveBufferSize;
            this.ReceiveTimeout = tc.ReceiveTimeout;
            this.SendBufferSize = tc.SendBufferSize;
            this.SendTimeout = tc.SendTimeout;

        

        }
        public TcpClientEx(IPEndPoint port):base(port)
        {
            LogUser = null;
        }
        public TcpClientEx(string hostname,int port) : base(hostname, port)
        {
            LogUser = null;
        }
    }
}
