using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace scada_udp_server
{
    public class ScadaUDPEventArgs : EventArgs
    {
        public ScadaUDPBody UdpBody;

        public Exception Exception;
        /// <summary>  
        /// 客户端状态封装类  
        /// </summary>  
        public AsyncUDPState State;

        /// <summary>  
        /// 是否已经处理过了  
        /// </summary>  
        public bool IsHandled { get; set; }

        public ScadaUDPEventArgs(ScadaUDPBody msg)
        {
            this.UdpBody = msg;
            IsHandled = false;
        }
        public ScadaUDPEventArgs(AsyncUDPState state)
        {
            this.State = state;
            IsHandled = false;
        }
        public ScadaUDPEventArgs(ScadaUDPBody msg, AsyncUDPState state)
        {
            this.UdpBody = msg;
            this.State = state;
            IsHandled = false;
        }

        public ScadaUDPEventArgs(Exception exception, AsyncUDPState state)
        {
            Exception = exception;
            State = state;
        }
    }

    public class AsyncUDPState
    {
        // Client   socket.  
        public UdpClient udpClient = null;

        public IPEndPoint remote;
    }
}
