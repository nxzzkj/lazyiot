using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Scada.Model
{
	/// <summary>
	/// IO_COMMUNICATION:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class IO_COMMUNICATION:ISerializable
    {
		public IO_COMMUNICATION()
		{ mDevices = new List<IO_DEVICE>(); }
		#region Model
		private string _io_comm_id="";
		private string _io_comm_name = "";
		private string _io_comm_label = "";
		private string _io_comm_remark = "";
		private int _io_comm_status=1;
		private string _io_comm_driver_id = "";
		private string _IO_SERVER_id = "";
        private string _io_comm_parastring = "";
        #region  序列化和反序列化

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected IO_COMMUNICATION(SerializationInfo info, StreamingContext context)
        {

            #region 自定义属性

            this._io_comm_id = (string)info.GetValue("_io_comm_id", typeof(string));
            this._io_comm_name = (string)info.GetValue("_io_comm_name", typeof(string));
            this._io_comm_label = (string)info.GetValue("_io_comm_label", typeof(string));
            this._io_comm_remark = (string)info.GetValue("_io_comm_remark", typeof(string));
            this._io_comm_status = (int)info.GetValue("_io_comm_status", typeof(int));
            this._io_comm_driver_id = (string)info.GetValue("_io_comm_driver_id", typeof(string));
            this._IO_SERVER_id = (string)info.GetValue("_IO_SERVER_id", typeof(string));
            this._io_comm_parastring = (string)info.GetValue("_io_comm_parastring", typeof(string));
          //  this.mDevices = (List<IO_DEVICE>)info.GetValue("mDevices", typeof(List<IO_DEVICE>));
            
            #endregion





        }

   
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_io_comm_id", this._io_comm_id);
            info.AddValue("_io_comm_name", this._io_comm_name);
            info.AddValue("_io_comm_label", this._io_comm_label);
            info.AddValue("_io_comm_remark", this._io_comm_remark);
            info.AddValue("_io_comm_status", this._io_comm_status);
            info.AddValue("_io_comm_driver_id", this._io_comm_driver_id);
            info.AddValue("_IO_SERVER_id", this._IO_SERVER_id);
            info.AddValue("_io_comm_parastring", this._io_comm_parastring);
          //  info.AddValue("mDevices", this.mDevices);
         
        }

        #endregion
        [NonSerialized]
        public SCADA_DRIVER DriverInfo = null;
        public IO_COMMUNICATION Copy()
        {
            IO_COMMUNICATION comm = new IO_COMMUNICATION() {
                  DriverInfo=this.DriverInfo==null?null: this.DriverInfo.Copy(),
                 IO_COMM_DRIVER_ID=this.IO_COMM_DRIVER_ID,
                 IO_COMM_ID = this.IO_COMM_ID,
                 IO_COMM_LABEL = this.IO_COMM_LABEL,
                 IO_COMM_NAME = this.IO_COMM_NAME,
                 IO_COMM_PARASTRING = this.IO_COMM_PARASTRING,
                 IO_COMM_REMARK = this.IO_COMM_REMARK,
                 IO_COMM_STATUS = this.IO_COMM_STATUS,
                 IO_SERVER_ID = this.IO_SERVER_ID,
                 Devices=null
            };
            return comm;
        }
        public string GetCommandString()
        {
            string str = "TABLE:IO_COMMUNICATION#IO_COMM_DRIVER_ID:" + IO_COMM_DRIVER_ID;
            str += "#IO_COMM_ID:" + IO_COMM_ID;
            str += "#IO_COMM_LABEL:" + IO_COMM_LABEL;
            str += "#IO_COMM_NAME:" + IO_COMM_NAME;
            str += "#IO_COMM_PARASTRING:" + IO_COMM_PARASTRING.Replace("#", "//").Replace(":", "\\") ;
            str += "#IO_COMM_REMARK:" + IO_COMM_REMARK.Replace("#", "//").Replace(":", "\\"); ;
            str += "#IO_COMM_STATUS:" + IO_COMM_STATUS;
            str += "#IO_SERVER_ID:" + IO_SERVER_ID;
           
            return str;
        }
        public string IO_COMM_PARASTRING
        {
            set { _io_comm_parastring = value; }
            get { return _io_comm_parastring; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_COMM_ID
		{
			set{ _io_comm_id=value;}
			get{return _io_comm_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IO_COMM_NAME
		{
			set{ _io_comm_name=value;}
			get{return _io_comm_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IO_COMM_LABEL
		{
			set{ _io_comm_label=value;}
			get{return _io_comm_label;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IO_COMM_REMARK
		{
			set{ _io_comm_remark=value;}
			get{return _io_comm_remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IO_COMM_STATUS
		{
			set{ _io_comm_status=value;}
			get{return _io_comm_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IO_COMM_DRIVER_ID
		{
			set{ _io_comm_driver_id=value;}
			get{return _io_comm_driver_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IO_SERVER_ID
		{
			set{ _IO_SERVER_id=value;}
			get{return _IO_SERVER_id;}
		}
        #endregion Model



        #region 当前通道的驱动
        [NonSerialized]
        public object CommunicateDriver = null;

        #endregion
  
        private List<IO_DEVICE> mDevices = new List<IO_DEVICE>();
        //存储的设备列表
        public List<IO_DEVICE> Devices
        {
            get { return mDevices; }
            set { mDevices = value; }
        }
        public override string ToString()
        {
            return this.IO_COMM_NAME + "[" + this.IO_COMM_LABEL + "]";
        }

    }
}

