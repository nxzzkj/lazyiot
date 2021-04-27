using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace CM_DTUCommunication
{

    public delegate void ClientOnDataInHandler(object sender, byte[] data);
    public delegate void ClientEvent(object sender);
    public delegate void ClientErrorEvent(object sender, SocketException error);
    public delegate void OnConnectedHandler(object sender, ZYBConnectedEventArgs e);
    public delegate void OnDataInHandler(object sender, ZYBDataInEventArgs e);
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
    public class ZYBDataInEventArgs
    {
        public int ConnectionId;
        public byte[] Data;
        public Socket socket;

        public ZYBDataInEventArgs(ClientConnection connection, byte[] datain)
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
    public class ZYBEventArgs : EventArgs
    {
        private DtuData _data;

        public ZYBEventArgs(DtuData dtu, string msg)
        {
            if (dtu == null)
            {
                return;
            }
            Msg = msg;
            this._data = dtu.Clone() as DtuData;
            this._data.IP = dtu.IP;
            this._data.PhoneNumber = dtu.PhoneNumber;
        }

        public DtuData DTU
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
