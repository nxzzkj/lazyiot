using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace Scada.IOStructure
{
    [Serializable]
    public enum BitStoreMode
    {
        高位字节在前,
        低位字节在前
    }
    [Serializable]
    public enum QualityStamp
    {
        NONE=1, GOOD=2, BAD=3
    }
 
    [Serializable]
    /// <summary>
    /// 定义数据类型
    /// </summary>
    public class IOData: ISerializable
    {
        public readonly int QualityStampValue = -9999;
        public IOData()
        {
            ParaName = "";
            ParaValue = "-9999";
            Date = DateTime.Now;
            ID = "";
            QualityStamp = QualityStamp.BAD;
            DataType = typeof(int);
            ParaString = "";
            BitStoreMode = BitStoreMode.低位字节在前;
        }
        #region  序列化和反序列化
      
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected IOData(SerializationInfo info, StreamingContext context)
        {

            #region 自定义属性
            this.ParaName = (string)info.GetValue("ParaName", typeof(string));
            this.ParaValue = (string)info.GetValue("ParaValue", typeof(string));
            this.Date = (DateTime?)info.GetValue("Date", typeof(DateTime?));
            this.ID = (string)info.GetValue("ID", typeof(string));
            this.QualityStamp = (QualityStamp)info.GetValue("QualityStamp", typeof(QualityStamp));
            this.ParaString = (string)info.GetValue("ParaString", typeof(string));
            this.BitStoreMode = (BitStoreMode)info.GetValue("BitStoreMode", typeof(BitStoreMode));
            #endregion

            DataType = typeof(int);



        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public   void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ParaName", this.ParaName);
            info.AddValue("ParaValue", this.ParaValue);
            info.AddValue("Date", this.Date);
            info.AddValue("ID", this.ID);
            info.AddValue("QualityStamp", this.QualityStamp);
            info.AddValue("ParaString", this.ParaString);
            info.AddValue("BitStoreMode", this.BitStoreMode);
            info.AddValue("End", this.End);
            
        }

        #endregion
        public BitStoreMode BitStoreMode
        {
            set;
            get;
        }
        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParaName
        {
            set;
            get;
        }
       
        /// <summary>
        /// 数据所在的设备id
        /// </summary>
        public string ID
        {
            set;
            get;
        }
        /// <summary>
        /// 采集站点ID
        /// </summary>
        public string ServerID
        {
            set;
            get;
        }
        /// <summary>
        /// 通讯通道ID
        /// </summary>
        public string CommunicationID
        {
            set;
            get;
        }
        /// <summary>
        /// 原始数据组
        /// </summary>
        public byte[] datas
        {
            set;
            get;
        }

        /// <summary>
        /// 接收数据的值
        /// </summary>
        public string ParaValue
        {
            set;
            get;
        }
        /// <summary>
        /// 接收数据的日期
        /// </summary>
        public DateTime? Date
        {
            set;
            get;
        }
        private QualityStamp mQualityStamp = QualityStamp.BAD;
        /// <summary>
        /// 数据质量戳
        /// </summary>
        public QualityStamp QualityStamp
        {
            set
            {
                mQualityStamp = value;
                if(mQualityStamp== QualityStamp.BAD)
                {
                    ParaValue = this.QualityStampValue.ToString();
                }
            }
            get { return mQualityStamp; }
        }

        /// <summary>
        /// 解析的数据类型
        /// </summary>
        public Type DataType
        {
            set;
            get;
        }
        /// <summary>
        /// 当前参数的链接字符串
        /// </summary>
        public string ParaString
        {
            set;
            get;
        }
     
        public bool End = true;
       
    }
}
