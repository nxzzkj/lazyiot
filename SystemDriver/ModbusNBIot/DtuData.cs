
using Scada.Model;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ModbusNBIot
{
    public enum ByteTranscoding
    {
        HEX,
        ASCII,
        UTF8,
        Int16,
        Int32,
        Int64
    }
    /// <summary>
    /// 定义ModbusDTUClientHandel相关的事件
    /// </summary>
    /// <param name="client"></param>
    public delegate void ModbusDTUClientHandel(ZYBClient client);
    public enum DtuRegister
    {
        关闭注册包,
        每包数据加上IMEI注册包,
        每包数据加自定义注册包,
        第一次链接到服务器时发送一个IMEI注册包,
        第一次链接到服务器时发送一个自定义注册包

    }
    public enum DtuHeartbeat
    {
        开启心跳,
        禁用心跳
    }
    public enum ReceiveType
    {
        主动,
        被动
    }
    public class DtuConfig
    {
        /// <summary>
        /// 注册包
        /// </summary>
        public DtuRegister DtuRegister
        { set; get; }


        public int IdentificationCharLength = 15;
        //标识的转码方式,如果是字符串形式的就是UTF8,或者是ASCII码
        public ByteTranscoding DtuRegisterByteTranscoding = ByteTranscoding.UTF8;
        //16进制字符串
        /// <summary>
        /// 用户设置的心跳
        /// </summary>
        public string Heartbeat
        {
            set;get;
        }
        public DtuHeartbeat DtuHeartbeat
        { set; get; }
        /// <summary>
        /// 远程服务器的IP
        /// </summary>
        public string LocalIP
        { set; get; }
        /// <summary>
        /// 远程连接端口
        /// </summary>
        public int LocalPort
        {
            set; get;
        }
        public ReceiveType ReceiveType = ReceiveType.被动;

    }
    public class DtuData
    {
        public DtuData()
        {
          
            Identification = "";
            IP = "";
        }

        public byte[] _databuffer = new byte[0];
        private byte[] _databyte;
        private long _id;
        private bool _isonline;
        private DateTime _logintime=DateTime.Now;
        private DateTime _refreshtime=DateTime.Now;
        public Socket cliSock;
        public string IP;//定义当前数据包发送的IP地址
        public string Port;//当前数据包客户端端口号
        public string Identification;//当前客户端的唯一标识
        
        
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

        public long ID
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

    public class RealData
    {
        public string DEVICEID
        {
            set; get;
        }
        public IO_DEVICE Device = null;
        public string SlaveId
        {
            set;
            get;
        }

        public string Identification;//当前客户端的唯一标识
        public int IdentificationLength=0;//当前标识的字符数量

        public List<byte[]> ReadSendByte
        {

            set;
            get;
        }
        public ModbusFragmentStore Fragment = null;

        public Task Task
        {
            set;
            get;
        }
        public int StartAddress = 0;//当前数据的开始地址
        public int Addresslength = 100;//当前数据的结束地址
    }
    /// <summary>
    /// Modbus分段
    /// </summary>
    public class ModbusFragment
    {
        public ushort StartRegister = 1;
        //一次最小读取8个单元
        public ushort RegisterNum = 8;
        /// <summary>
        /// 命令
        /// </summary>
        public string Code = "03";
        public int StartIndex = 0;
        public int Length = 0;
    }
    /// <summary>
    /// modbus分段存储的方法
    /// </summary>
    public class ModbusFragmentStore
    {
        public string StoredCode = "";
        public List<ModbusFragment> Fragments = new List<ModbusFragment>();
        public List<ushort> Units = new List<ushort>();
        public void MakeFragment()
        {
            //先进行排序
            for (int i = 0; i < Units.Count; i++)
            {
                ushort temp = Units[i];
                int j = i;
                while ((j > 0) && (Units[j - 1] > temp))
                {
                    Units[j] = Units[j - 1];
                    --j;
                }
                Units[j] = temp;
            }
            int maxnum = 123;
            if (StoredCode == "03" || StoredCode == "04")
                maxnum = 123;
            else
                maxnum = 1999;
            Fragments = new List<ModbusFragment>();
            ModbusFragment fragment = null;
            bool iscreate = true;
            for (int i = 0; i < Units.Count; i++)
            {
                if (iscreate)
                {
                    fragment = new ModbusFragment();
                    fragment.Code = this.StoredCode;
                    fragment.StartRegister = Units[i];
                    Fragments.Add(fragment);
                    iscreate = false;
                }
                else
                {
                    ushort num = Convert.ToUInt16(Units[i] - fragment.StartRegister + 9);
                    ushort num2 = Convert.ToUInt16(Units[i - 1] - fragment.StartRegister + 9);
                    if (num >= maxnum)
                    {
                        if (num == maxnum)
                        {
                            fragment.RegisterNum = num;
                        }
                        else if (num2 <= maxnum)
                        {
                            fragment.RegisterNum = num2;
                            i--;

                        }
                        iscreate = true;
                    }
                    else
                    {
                        fragment.RegisterNum = num;
                        iscreate = false;
                    }

                }

            }
        }
 
    }

}

