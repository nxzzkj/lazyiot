using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace TcpNetworkBrige
{

    public delegate void ClientOnDataInHandler(object sender, byte[] data);
    public delegate void ClientEvent(object sender);
    public delegate void ClientErrorEvent(object sender, SocketException error);
    public delegate void OnConnectedHandler(object sender, ZYBConnectedEventArgs e);
    public delegate void OnDataInHandler(object sender, TCPDataInEventArgs e);
    public delegate void OnDisconnectedHandler(object sender, ZYBDisconnectedEventArgs e);
    public class ZYBConnectedEventArgs
    {
        public int ConnectionId;
        public Socket socket;


        public ZYBConnectedEventArgs(ClientConnection connection)
        {
            this.ConnectionId = connection.ConnectionId;
            this.socket = connection.Socket;
        }
    }
    public class TCPDataInEventArgs
    {
        public int ConnectionId;
        public byte[] Data;
        public Socket socket;

        public TCPDataInEventArgs(ClientConnection connection, byte[] datain)
        {
            if (connection == null)
                return;
            if (connection.Socket == null)
                return;
            this.ConnectionId = connection.ConnectionId;
            this.socket = connection.Socket;
            this.Data = datain;
        }
    }
    public class ZYBDisconnectedEventArgs
    {
        public int ConnectionId;
        public Socket socket;

        public ZYBDisconnectedEventArgs(ClientConnection connection)
        {
            if (connection == null)
                return;
            if (connection.Socket == null)
                return;
            this.ConnectionId = connection.ConnectionId;
            this.socket = connection.Socket;
        }
    }
    public class TCPEventArgs : EventArgs
    {
        private TCPData _data;

        public TCPEventArgs(TCPData dtu, string msg)
        {
            if (dtu == null)
            {
                return;
            }
            Msg = msg;
            this._data = dtu.Clone() as TCPData;
            this._data.IP = dtu.IP;
 
        }
        /// <summary>
        /// 接收的数据单元包
        /// </summary>

        public TCPData TCPBag
        {
            get
            {
                return this._data;
            }
        }
        public string Msg
        {
            set;
            get;
        }
    }
}
