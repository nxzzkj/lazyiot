namespace CM_DTUCommunication
{
    using System;
    using System.Net.Sockets;

    public class DtuData : ICloneable
    {
        public DtuData()
        {
            DtuID = "";
            PhoneNumber = "";
            IP = "";
        }

        public byte[] _databuffer = new byte[0];
        private byte[] _databyte;
        private string _id;
        private bool _isonline;
        private DateTime _logintime=DateTime.Now;
        private DateTime _refreshtime=DateTime.Now;
        public Socket cliSock;
        public string IP;
        public string PhoneNumber;
        public string DtuID
        {
            set;
            get;
        }

        public object Clone()
        {
            if (base.MemberwiseClone() == null)
                return null;
            DtuData data = base.MemberwiseClone() as DtuData;
            if (data != null)
            {
                data.IP = this.IP;
                data.PhoneNumber = this.PhoneNumber;
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

        public string ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
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
    public enum Mode
    {
        小数据包模式,
        大数据包模式,
        全透明模式
    }
}

