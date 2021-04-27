using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpNetworkBrige
{
    public enum DataStatus
    {
        ReadData, WriterData, UDP, None
    }
    /// <summary>
    /// 定义DTU数据结构
    /// </summary>
    public class TCP_Data : ICloneable
    {
        public TCP_Data()
        {
            Msg = "";
            ADDRESS = "";
         
            ParaID = "";
            ParaValue = "";
            DataStatus = DataStatus.ReadData;
       
        }
        /// <summary>
        /// 传递的消息
        /// </summary>
        public string Msg
        {
            set;
            get;
        }
        public string ADDRESS
        {
            set;
            get;
        }
        public byte[] datas
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
        public string BaseDeviceID
        {
            set;get;
        }
        /// <summary>
        /// 参数值
        /// </summary>
        public string ParaValue
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
        
    }
}
