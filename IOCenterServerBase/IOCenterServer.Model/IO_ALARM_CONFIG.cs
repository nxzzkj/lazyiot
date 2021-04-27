using System;
using System.Runtime.Serialization;

namespace Scada.Model
{
	/// <summary>
	/// IO_ALARM_CONFIG:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class IO_ALARM_CONFIG: ISerializable
    {
       
        public IO_ALARM_CONFIG()
        {

            this.UPDATE_UID = "";
            this.UPDATE_DATE = "";
            this.UPDATE_RESULT = "";
         


        }
		#region Model
		private string _io_id="";
		private string _io_alarm_type = "";
		private string _io_alarm_level = "";
		private int? _io_enable_maxmax =0;
		private decimal? _io_maxmax_value = 0;
		private int? _io_enable_max = 0;
		private decimal? _io_max_value = 0;
		private int? _io_enable_min = 0;
		private decimal? _io_min_value = 0;
		private int? _io_enable_minmin = 0;
		private decimal? _io_minmin_value = 0;
		private string _io_maxmax_type = "";
		private string _io_max_type = "";
		private string _io_minmin_type = "";
		private string _io_condition = "";
		private string _io_comm_id = "";
		private string _io_device_id = "";
		private string _IO_SERVER_id = "";
		private int _io_alarm_number=0;
		private string _io_min_type="";
        private string _io_name = "";
        private string _io_label = "";
 
        public string IO_NAME
        {
            set { _io_name = value; }
            get { return _io_name; }
        }
        public string IO_LABEL
        {
            set { _io_label = value; }
            get { return _io_label; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_ID
		{
			set{ _io_id=value;}
			get{return _io_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IO_ALARM_TYPE
		{
			set{ _io_alarm_type=value;}
			get{return _io_alarm_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IO_ALARM_LEVEL
		{
			set{ _io_alarm_level=value;}
			get{return _io_alarm_level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IO_ENABLE_MAXMAX
		{
			set{ _io_enable_maxmax=value;}
			get{return _io_enable_maxmax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IO_MAXMAX_VALUE
		{
			set{ _io_maxmax_value=value;}
			get{return _io_maxmax_value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IO_ENABLE_MAX
		{
			set{ _io_enable_max=value;}
			get{return _io_enable_max;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IO_MAX_VALUE
		{
			set{ _io_max_value=value;}
			get{return _io_max_value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IO_ENABLE_MIN
		{
			set{ _io_enable_min=value;}
			get{return _io_enable_min;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IO_MIN_VALUE
		{
			set{ _io_min_value=value;}
			get{return _io_min_value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IO_ENABLE_MINMIN
		{
			set{ _io_enable_minmin=value;}
			get{return _io_enable_minmin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IO_MINMIN_VALUE
		{
			set{ _io_minmin_value=value;}
			get{return _io_minmin_value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IO_MAXMAX_TYPE
		{
			set{ _io_maxmax_type=value;}
			get{return _io_maxmax_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IO_MAX_TYPE
		{
			set{ _io_max_type=value;}
			get{return _io_max_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IO_MINMIN_TYPE
		{
			set{ _io_minmin_type=value;}
			get{return _io_minmin_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IO_CONDITION
		{
			set{ _io_condition=value;}
			get{return _io_condition;}
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
		public string IO_DEVICE_ID
		{
			set{ _io_device_id=value;}
			get{return _io_device_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IO_SERVER_ID
		{
			set{ _IO_SERVER_id=value;}
			get{return _IO_SERVER_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IO_ALARM_NUMBER
		{
			set{ _io_alarm_number=value;}
			get{return _io_alarm_number;}
		}
        private int status = 0;
        public int IO_ALARM_STATUS
        {
            set { status = value; }
            get { return status; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string IO_MIN_TYPE
		{
			set{ _io_min_type=value;}
			get{return _io_min_type;}
		}
        public string GetCommandString()
        {
            try
            {
                string str = "TABLE:IO_ALARM_CONFIG#IO_ALARM_LEVEL:" + IO_ALARM_LEVEL;
                str += "#IO_ALARM_NUMBER:" + IO_ALARM_NUMBER;
                str += "#IO_ALARM_TYPE:" + IO_ALARM_TYPE;
                str += "#IO_COMM_ID:" + IO_COMM_ID;
                str += "#IO_CONDITION:" + IO_CONDITION;
                str += "#IO_DEVICE_ID:" + IO_DEVICE_ID;
                str += "#IO_ENABLE_MAX:" + IO_ENABLE_MAX;
                str += "#IO_ENABLE_MAXMAX:" + IO_ENABLE_MAXMAX;
                str += "#IO_ENABLE_MIN:" + IO_ENABLE_MIN;
                str += "#IO_ENABLE_MINMIN:" + IO_ENABLE_MINMIN;
                str += "#IO_ID:" + IO_ID;
                str += "#IO_MAXMAX_TYPE:" + IO_MAXMAX_TYPE;
                str += "#IO_MAXMAX_VALUE:" + IO_MAXMAX_VALUE;
                str += "#IO_MAX_TYPE:" + IO_MAX_TYPE;
                str += "#IO_MAX_VALUE:" + IO_MAX_VALUE;
                str += "#IO_MINMIN_TYPE:" + IO_MINMIN_TYPE;
                str += "#IO_MINMIN_VALUE:" + IO_MINMIN_VALUE;
                str += "#IO_MIN_TYPE:" + IO_MIN_TYPE;
                str += "#IO_MIN_VALUE:" + IO_MIN_VALUE;
                str += "#IO_SERVER_ID:" + IO_SERVER_ID;
                return str;
            }
            catch
            {
                return "";
            }
        }
        public string GetCommandString2()
        {
            try
            {
                string str = "IO_ALARM_LEVEL:" + IO_ALARM_LEVEL;
                str += "#IO_ALARM_NUMBER:" + IO_ALARM_NUMBER;
                str += "#IO_ALARM_TYPE:" + IO_ALARM_TYPE;
                str += "#IO_COMM_ID:" + IO_COMM_ID;
                str += "#IO_CONDITION:" + IO_CONDITION;
                str += "#IO_DEVICE_ID:" + IO_DEVICE_ID;
                str += "#IO_ENABLE_MAX:" + IO_ENABLE_MAX;
                str += "#IO_ENABLE_MAXMAX:" + IO_ENABLE_MAXMAX;
                str += "#IO_ENABLE_MIN:" + IO_ENABLE_MIN;
                str += "#IO_ENABLE_MINMIN:" + IO_ENABLE_MINMIN;
                str += "#IO_ID:" + IO_ID;
                str += "#IO_MAXMAX_TYPE:" + IO_MAXMAX_TYPE;
                str += "#IO_MAXMAX_VALUE:" + IO_MAXMAX_VALUE;
                str += "#IO_MAX_TYPE:" + IO_MAX_TYPE;
                str += "#IO_MAX_VALUE:" + IO_MAX_VALUE;
                str += "#IO_MINMIN_TYPE:" + IO_MINMIN_TYPE;
                str += "#IO_MINMIN_VALUE:" + IO_MINMIN_VALUE;
                str += "#IO_MIN_TYPE:" + IO_MIN_TYPE;
                str += "#IO_MIN_VALUE:" + IO_MIN_VALUE;
                str += "#IO_SERVER_ID:" + IO_SERVER_ID;
                return str;
            }
            catch
            {
                return "";
            }
        }
        public IO_ALARM_CONFIG Clone()
        {
            IO_ALARM_CONFIG config = new IO_ALARM_CONFIG();
            config.IO_ALARM_LEVEL = this.IO_ALARM_LEVEL;
            config.IO_ALARM_NUMBER = this.IO_ALARM_NUMBER;
            config.IO_ALARM_TYPE = this.IO_ALARM_TYPE;
            config.IO_COMM_ID = this.IO_COMM_ID;
            config.IO_CONDITION = this.IO_CONDITION;
            config.IO_DEVICE_ID = this.IO_DEVICE_ID;
            config.IO_ENABLE_MAX = this.IO_ENABLE_MAX;
            config.IO_ENABLE_MAXMAX = this.IO_ENABLE_MAXMAX;
            config.IO_ENABLE_MIN = this.IO_ENABLE_MIN;
            config.IO_ENABLE_MINMIN = this.IO_ENABLE_MINMIN;
            config.IO_ID = this.IO_ID;
            config.IO_MAXMAX_TYPE = this.IO_MAXMAX_TYPE;
            config.IO_MAXMAX_VALUE = this.IO_MAXMAX_VALUE;
            config.IO_MAX_TYPE = this.IO_MAX_TYPE;
            config.IO_MAX_VALUE = this.IO_MAX_VALUE;
            config.IO_MINMIN_TYPE = this.IO_MINMIN_TYPE;
            config.IO_MINMIN_VALUE = this.IO_MINMIN_VALUE;
            config.IO_MIN_TYPE = this.IO_MIN_TYPE;
            config.IO_MIN_VALUE = this.IO_MIN_VALUE;
            config.IO_SERVER_ID = this.IO_SERVER_ID;
            config.UPDATE_UID = this.UPDATE_UID;
            config.UPDATE_DATE = this.UPDATE_DATE;
            config.UPDATE_RESULT ="true";
    
            return config;


        }

        #endregion Model
        #region 用户端设置报警配置信息后更新采集站
        private string _UPDATE_DATE = "";

        public string UPDATE_DATE
        {
            set { _UPDATE_DATE = value; }
            get { return _UPDATE_DATE; }
        }
        private string _UPDATE_UID = "";
        public string UPDATE_UID
        {
            set { _UPDATE_UID = value; }
            get { return _UPDATE_UID; }
        }
        private string _UPDATE_RESULT = "";
        public string UPDATE_RESULT
        {
            set { _UPDATE_RESULT = value; }
            get { return _UPDATE_RESULT; }
        }
        #endregion
        #region  序列化和反序列化

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected IO_ALARM_CONFIG(SerializationInfo info, StreamingContext context)
        {

            #region 自定义属性

            this._io_device_id = (string)info.GetValue("_io_device_id", typeof(string));
            this._IO_SERVER_id = (string)info.GetValue("_IO_SERVER_id", typeof(string));
            this._io_comm_id = (string)info.GetValue("_io_comm_id", typeof(string));
            this._io_alarm_level = (string)info.GetValue("_io_alarm_level", typeof(string));
            this.status = (int)info.GetValue("status", typeof(int));
            this._io_alarm_number = (int)info.GetValue("_io_alarm_number", typeof(int));
            this._io_alarm_type = (string)info.GetValue("_io_alarm_type", typeof(string));
            this._io_condition = (string)info.GetValue("_io_condition", typeof(string));
            this._io_enable_max = (int)info.GetValue("_io_enable_max", typeof(int));
            this._io_enable_maxmax = (int)info.GetValue("_io_enable_maxmax", typeof(int));
            this._io_enable_min = (int)info.GetValue("_io_enable_min", typeof(int));
            this._io_enable_minmin = (int)info.GetValue("_io_enable_minmin", typeof(int));
            this._io_id = (string)info.GetValue("_io_id", typeof(string));
            this._io_label = (string)info.GetValue("_io_label", typeof(string));
            this._io_maxmax_type = (string)info.GetValue("_io_maxmax_type", typeof(string));
            this._io_maxmax_value = (decimal)info.GetValue("_io_maxmax_value", typeof(decimal));
            this._io_max_type = (string)info.GetValue("_io_max_type", typeof(string));
            this._io_max_value = (decimal)info.GetValue("_io_max_value", typeof(decimal));
            this._io_minmin_type = (string)info.GetValue("_io_minmin_type", typeof(string));
            this._io_minmin_value = (decimal)info.GetValue("_io_minmin_value", typeof(decimal));
            this._io_min_type = (string)info.GetValue("_io_min_type", typeof(string));
            this._io_min_value = (decimal)info.GetValue("_io_min_value", typeof(decimal));
            this._io_name = (string)info.GetValue("_io_name", typeof(string));
            this._UPDATE_DATE = (string)info.GetValue("_UPDATE_DATE", typeof(string));
            this._UPDATE_RESULT = (string)info.GetValue("_UPDATE_RESULT", typeof(string));
            this._UPDATE_UID = (string)info.GetValue("_UPDATE_UID", typeof(string));

             
            #endregion





        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_io_device_id", this._io_device_id);
            info.AddValue("_IO_SERVER_id", this._IO_SERVER_id);
            info.AddValue("_io_comm_id", this._io_comm_id);
            info.AddValue("_io_alarm_level", this._io_alarm_level);
            info.AddValue("status", this.status);
            info.AddValue("_io_alarm_number", this._io_alarm_number);
            info.AddValue("_io_alarm_type", this._io_alarm_type);
            info.AddValue("_io_condition", this._io_condition);
            info.AddValue("_io_enable_max", this._io_enable_max);
            info.AddValue("_io_enable_maxmax", this._io_enable_maxmax);
            info.AddValue("_io_enable_min", this._io_enable_min);
            info.AddValue("_io_enable_minmin", this._io_enable_minmin);

            info.AddValue("_io_id", this._io_id);
            info.AddValue("_io_label", this._io_label);
            info.AddValue("_io_maxmax_type", this._io_maxmax_type);
            info.AddValue("_io_maxmax_value", this._io_maxmax_value);
            info.AddValue("_io_max_type", this._io_max_type);
            info.AddValue("_io_max_value", this._io_max_value);
            info.AddValue("_io_minmin_type", this._io_minmin_type);
            info.AddValue("_io_minmin_value", this._io_minmin_value);
            info.AddValue("_io_min_type", this._io_min_type);
            info.AddValue("_io_min_value", this._io_min_value);
            info.AddValue("_io_name", this._io_name);
            info.AddValue("_UPDATE_DATE", this._UPDATE_DATE);
            info.AddValue("_UPDATE_RESULT", this._UPDATE_RESULT);
            info.AddValue("_UPDATE_UID", this._UPDATE_UID);
        }

        #endregion
    }
}

