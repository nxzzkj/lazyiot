using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Modbus.ModbusService
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
            _data = new DtuData();
            this._data.IP = dtu.IP;
            this._data.DataByte = dtu.DataByte;
            this._data.cliSock = dtu.cliSock;
            this._data.ID = dtu.ID;
            this._data.Identification = dtu.Identification;
            this._data.IP = dtu.IP;
            this._data.IsOnline = dtu.IsOnline;
            this._data.RefreshTime = dtu.RefreshTime;
            this._data.LoginTime = dtu.LoginTime;
          
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
