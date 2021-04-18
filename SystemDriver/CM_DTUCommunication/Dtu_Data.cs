using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM_DTUCommunication
{
    public enum DataStatus
    {
        ReadData, WriterData, UDP, None
    }
    /// <summary>
    /// 定义DTU数据结构
    /// </summary>
    public class Dtu_Data : ICloneable
    {
        public Dtu_Data()
        {
            Msg = "";
            ID = "";
            DeviceID = "";
            ParaID = "";
            ParaValue = "";
            IP = "";
            PhoneNumber = "";
            DataStatus = DataStatus.ReadData;
            DtuID = "";
        }
        /// <summary>
        /// 传递的消息
        /// </summary>
        public string Msg
        {
            set;
            get;
        }
        public string ID
        {
            set;
            get;
        }
        public byte[] datas
        {
            set;
            get;
        }
        public string DeviceID
        {
            set;
            get;
        }
        /// <summary>
        /// 参数ID
        /// </summary>
        public string ParaID
        {
            set;
            get;
        }
        /// <summary>
        /// 参数值
        /// </summary>
        public string ParaValue
        {
            set;
            get;
        }
        /// <summary>
        /// 定义的DUT的动态和静态IP
        /// </summary>
        public string IP
        {
            set;
            get;
        }
        public string PhoneNumber
        {
            set;
            get;
        }

        public bool IsOnline { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime RefreshTime { get; set; }



        /// <summary>
        /// 该数据是通过什么方式获取的数据
        /// </summary>
        public DataStatus DataStatus
        {
            set;
            get;
        }

        public object Clone()
        {
            return null;
        }
        public string DtuID
        {
            set;
            get;
        }
    }
}
