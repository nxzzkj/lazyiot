using System;
using System.Net.Sockets;

namespace TcpNetworkBrige
{


    public class TCPData : ICloneable
    {
        public TCPData()
        {
            IP = "";
        }

        public byte[] _databuffer = new byte[0];
        private byte[] _databyte;
        private string _ADDRESS;
        private bool _isonline;
        private DateTime _logintime=DateTime.Now;
        private DateTime _refreshtime=DateTime.Now;
        public Socket cliSock;
        //设备包含的IP地址
        public string IP;
        //当前设备DTU编号
        public string DTUNO = "";
        

        public object Clone()
        {
            if (base.MemberwiseClone() == null)
                return null;
            TCPData data = base.MemberwiseClone() as TCPData;
            if (data != null)
            {
                data.IP = this.IP;
          
                if (this._databyte != null && _databyte.Length>0)
                {
                    data._databyte = new byte[this._databyte.Length];
                    Array.Copy(this._databyte, data._databyte, this._databyte.Length);
                }
                return data;
            }
            return null;
        }
        
        public byte[] DataByte
        {
            get
            {
                return this._databyte;
            }
            set
            {
                this._databyte = value;
            }
        }

        public string ADDRESS
        {
            get
            {
                return this._ADDRESS;
            }
            set
            {
                this._ADDRESS = value;
            }
        }

        public bool IsOnline
        {
            get
            {
                return this._isonline;
            }
            set
            {
                this._isonline = value;
            }
        }

        public DateTime LoginTime
        {
            get
            {
                return this._logintime;
            }
            set
            {
                this._logintime = value;
            }
        }

        public DateTime RefreshTime
        {
            get
            {
                return this._refreshtime;
            }
            set
            {
                this._refreshtime = value;
            }
        }
    }
    
}

