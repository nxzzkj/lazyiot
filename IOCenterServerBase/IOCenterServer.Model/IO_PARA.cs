using Scada.IOStructure;
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Scada.Model
{
    /// <summary>
    /// IO_PARA:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class IO_PARA:ISerializable
    {
        public IO_PARA()
        {
          mAlarmConfig = new IO_ALARM_CONFIG();
        
        }
        #region Model
        private string _io_id = "";
        private string _IO_SERVER_id = "";
        private string _io_comm_id = "";
        private string _io_device_id = "";
        private string _io_name = "";
        private string _io_label = "";
        private string _io_parastring = "";
        private int? _io_alert_enable = 0;
        private string _io_datatype = "";
        private string _io_initalvalue = "";
        private string _io_maxvalue = "";
        private string _io_minvalue = "";
        private int? _io_enablerangeconversion = 0;
        private string _io_rangemin = "";
        private string _io_rangemax = "";
        private string _io_outlies = "";
        private string _io_pointtype = "";
        private string _io_zero = "";
        private string _io_one = "";
        private string _io_unit = "";
        private int? _io_history = 1;
        private string _io_address = "";
        private int? _io_enablealarm = 0;
        private int? _io_system = 0;
        private int status = 0;
        private string _IO_FORMULA = "";
        private string _IO_DATASOURCE = "";
        
        public string IO_DATASOURCE
        {
            set { _IO_DATASOURCE = value; }
            get { return _IO_DATASOURCE; }
        }
        /// <summary>
        /// 定义公式
        /// </summary>
        public string IO_FORMULA
        {
            set { _IO_FORMULA = value; }
            get { return _IO_FORMULA; }
        }
        public int IO_STATUS
        {
            set { status = value; }
            get { return status; }
        }
        /// <summary>
        /// 获取当前数据定义的类型
        /// </summary>
        /// <returns></returns>
        public Type GetParaValueType()
        {
           switch(this._io_datatype)
            {
                case "8位整数":
                    return typeof(sbyte);
 
                case "8位无符号整数":
                    return typeof(byte);
                case "16位整数":
                    return typeof(short);
                case "16位无符号整数":
                    return typeof(ushort);
                case "32位整数":
                    return typeof(int);
                case "32位无符号整数":
                    return typeof(uint);
                case "单精度浮点数":
                    return typeof(float);
                case "双精度浮点数":
                    return typeof(double);
                default:
                    return typeof(string);







            }
        }
        /// <su
        public string GetCommandString()
        {
            try
            {
                string str = "TABLE:IO_PARA#IO_ADDRESS:" + IO_ADDRESS;

                str += "#IO_ALERT_ENABLE:" + IO_ALERT_ENABLE;
                str += "#IO_COMM_ID:" + IO_COMM_ID;
                str += "#IO_DATATYPE:" + IO_DATATYPE;
                str += "#IO_DEVICE_ID:" + IO_DEVICE_ID;
                str += "#IO_ENABLEALARM:" + IO_ENABLEALARM;
                str += "#IO_ENABLERANGECONVERSION:" + IO_ENABLERANGECONVERSION;
                str += "#IO_HISTORY:" + IO_HISTORY;
                str += "#IO_ID:" + IO_ID;
                str += "#IO_INITALVALUE:" + IO_INITALVALUE;
                str += "#IO_LABEL:" + IO_LABEL;
                str += "#IO_MAXVALUE:" + IO_MAXVALUE;
                str += "#IO_MINVALUE:" + IO_MINVALUE;
                str += "#IO_NAME:" + IO_NAME;
                str += "#IO_ONE:" + IO_ONE;
                str += "#IO_OUTLIES:" + IO_OUTLIES;
                str += "#IO_PARASTRING:" + IO_PARASTRING.Replace("#", "//").Replace(":", "\\");
                str += "#IO_POINTTYPE:" + IO_POINTTYPE;
                str += "#IO_RANGEMAX:" + IO_RANGEMAX;
                str += "#IO_RANGEMIN:" + IO_RANGEMIN;
                str += "#IO_SERVER_ID:" + IO_SERVER_ID;
                str += "#IO_SYSTEM:" + IO_SYSTEM;
                str += "#IO_UNIT:" + IO_UNIT;
                str += "#IO_ZERO:" + IO_ZERO;
                str += "#IO_FORMULA:"+ IO_FORMULA;
                str += "#IO_DATASOURCE:" + this.IO_DATASOURCE;
                //增加报警信息的配置
                str += "#" + AlarmConfig.GetCommandString2();//把报警信息一并传过来
               
                return str;
            }
            catch
            {
                return "";
            }
        }
        public IO_PARA Copy()
        {

            IO_PARA para= new IO_PARA() {

                
                 IO_ADDRESS= this.IO_ADDRESS,
                IO_ALERT_ENABLE = this.IO_ALERT_ENABLE,
                IO_COMM_ID = this.IO_COMM_ID,
                IO_DATATYPE = this.IO_DATATYPE,
                IO_DEVICE_ID = this.IO_DEVICE_ID,
                IO_ENABLEALARM = this.IO_ENABLEALARM,
                IO_ENABLERANGECONVERSION = this.IO_ENABLERANGECONVERSION,
                IO_HISTORY = this.IO_HISTORY,
                IO_ID = this.IO_ID,
                IO_INITALVALUE = this.IO_INITALVALUE,
                IO_LABEL = this.IO_LABEL,
                IO_MAXVALUE = this.IO_MAXVALUE,
                IO_MINVALUE = this.IO_MINVALUE,
                IO_NAME = this.IO_NAME,
                IO_ONE = this.IO_ONE,
                IO_OUTLIES = this.IO_OUTLIES,
                IO_PARASTRING = this.IO_PARASTRING,
                IO_POINTTYPE = this.IO_POINTTYPE,
                IO_RANGEMAX = this.IO_RANGEMAX,
                IO_RANGEMIN = this.IO_RANGEMIN,
                IO_SERVER_ID = this.IO_SERVER_ID,
                IO_SYSTEM = this.IO_SYSTEM,
                IO_UNIT = this.IO_UNIT,
                IO_ZERO = this.IO_ZERO,
                IO_FORMULA = this.IO_FORMULA,
                IO_DATASOURCE=this.IO_DATASOURCE


            };

          
          if (  this.IORealData!=null)
            {
                para.IORealData = new IOData()
                {

                    BitStoreMode = this.IORealData.BitStoreMode,
                    CommunicationID = this.IORealData.CommunicationID,
                    datas = this.IORealData.datas,
                    DataType = this.IORealData.DataType,
                    Date = this.IORealData.Date,
                    End = this.IORealData.End,
                    ID = this.IORealData.ID,
                    ParaName = this.IORealData.ParaName,
                    ParaString = this.IORealData.ParaString,
                    ParaValue = this.IORealData.ParaValue,
                    QualityStamp = this.IORealData.QualityStamp,
                    ServerID = this.IORealData.ServerID
                };
            }
            if (this.AlarmConfig != null)
            {
                para.AlarmConfig = new IO_ALARM_CONFIG()
                {
                    IO_ALARM_LEVEL = this.AlarmConfig.IO_ALARM_LEVEL,
                    IO_ALARM_NUMBER = this.AlarmConfig.IO_ALARM_NUMBER,
                    IO_ALARM_TYPE = this.AlarmConfig.IO_ALARM_TYPE,
                    IO_COMM_ID = this.AlarmConfig.IO_COMM_ID,
                    IO_CONDITION = this.AlarmConfig.IO_CONDITION,
                    IO_DEVICE_ID = this.AlarmConfig.IO_DEVICE_ID,
                    IO_ENABLE_MAX = this.AlarmConfig.IO_ENABLE_MAX,
                    IO_ENABLE_MAXMAX = this.AlarmConfig.IO_ENABLE_MAXMAX,
                    IO_ENABLE_MIN = this.AlarmConfig.IO_ENABLE_MIN,
                    IO_ENABLE_MINMIN = this.AlarmConfig.IO_ENABLE_MINMIN,

                    IO_ID = this.AlarmConfig.IO_ID,
                    IO_MAXMAX_TYPE = this.AlarmConfig.IO_MAXMAX_TYPE,
                    IO_MAXMAX_VALUE = this.AlarmConfig.IO_MAXMAX_VALUE,
                    IO_MAX_TYPE = this.AlarmConfig.IO_MAX_TYPE,
                    IO_MAX_VALUE = this.AlarmConfig.IO_MAX_VALUE,
                    IO_MINMIN_TYPE = this.AlarmConfig.IO_MINMIN_TYPE,
                    IO_MINMIN_VALUE = this.AlarmConfig.IO_MINMIN_VALUE,
                    IO_MIN_TYPE = this.AlarmConfig.IO_MIN_TYPE,
                    IO_MIN_VALUE = this.AlarmConfig.IO_MIN_VALUE,
                    IO_SERVER_ID = this.AlarmConfig.IO_SERVER_ID
                };

             }
            return para;
        }
        private IO_ALARM_CONFIG mAlarmConfig = null;
      
        /// <summary>
        /// 报警配置信息
        /// </summary>
        public IO_ALARM_CONFIG AlarmConfig
        {
            get { return mAlarmConfig; }
            set { mAlarmConfig = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_ID
        {
            set {
                _io_id = value;
                if (AlarmConfig != null)
                    AlarmConfig.IO_ID = value;

            }
            get { return _io_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_SERVER_ID
        {
            set { _IO_SERVER_id = value;
                if (AlarmConfig != null)
                    AlarmConfig.IO_SERVER_ID = value;
            }
            get { return _IO_SERVER_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_COMM_ID
        {
            set { _io_comm_id = value;
                if (AlarmConfig != null)
                    AlarmConfig.IO_COMM_ID = value;
            }
            get { return _io_comm_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_DEVICE_ID
        {
            set { _io_device_id = value;

                if (AlarmConfig != null)
                    AlarmConfig.IO_DEVICE_ID = value;
            }
            get { return _io_device_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_NAME
        {
            set { _io_name = value; }
            get { return _io_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_LABEL
        {
            set { _io_label = value; }
            get { return _io_label; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_PARASTRING
        {
            set { _io_parastring = value; }
            get { return _io_parastring; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IO_ALERT_ENABLE
        {
            set { _io_alert_enable = value; }
            get { return _io_alert_enable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_DATATYPE
        {
            set { _io_datatype = value; }
            get { return _io_datatype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_INITALVALUE
        {
            set { _io_initalvalue = value; }
            get { return _io_initalvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_MAXVALUE
        {
            set { _io_maxvalue = value; }
            get { return _io_maxvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_MINVALUE
        {
            set { _io_minvalue = value; }
            get { return _io_minvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IO_ENABLERANGECONVERSION
        {
            set { _io_enablerangeconversion = value; }
            get { return _io_enablerangeconversion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_RANGEMIN
        {
            set { _io_rangemin = value; }
            get { return _io_rangemin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_RANGEMAX
        {
            set { _io_rangemax = value; }
            get { return _io_rangemax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_OUTLIES
        {
            set { _io_outlies = value; }
            get { return _io_outlies; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_POINTTYPE
        {
            set { _io_pointtype = value; }
            get { return _io_pointtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_ZERO
        {
            set { _io_zero = value; }
            get { return _io_zero; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_ONE
        {
            set { _io_one = value; }
            get { return _io_one; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_UNIT
        {
            set { _io_unit = value; }
            get { return _io_unit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IO_HISTORY
        {
            set { _io_history = value; }
            get { return _io_history; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_ADDRESS
        {
            set { _io_address = value; }
            get { return _io_address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IO_ENABLEALARM
        {
            set {


                _io_enablealarm = value;
               

            }
            get { return _io_enablealarm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IO_SYSTEM
        {
            set { _io_system = value; }
            get { return _io_system; }
        }

        public override string ToString()
        {
            return this. _io_name + "["+this._io_label + "]";
        }
        #endregion Model

        #region 定义用户实时读取的数据属性，与数据库字段无关
        private IOData mIORealData = new IOData();
        public IOData IORealData
        {
            get { return mIORealData; }
            set {   mIORealData=value; }
        }
 
        /// <summary>
        /// 接收数据的值
        /// </summary>
        public string RealValue
        {

            get
            {
                if (IORealData != null)
                    return IORealData.ParaValue;
                else
                  return  "";

            }
        }
    
        /// <summary>
        /// 接收数据的日期
        /// </summary>
        public string RealDate
        {
           get {

                if (IORealData != null)
                    return IORealData.Date==null?"":IORealData.Date.Value.ToString("yyyy-MM-dd HH:mm:ss");
                else
                    return "";
            }
        }
        /// <summary>
        /// 数据质量戳
        /// </summary>
        public QualityStamp RealQualityStamp
        {
            get
            {

                if (IORealData != null)
                    return IORealData.QualityStamp;
                else
                    return QualityStamp.NONE;
            }
        }
        #endregion
        #region  序列化和反序列化

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected IO_PARA(SerializationInfo info, StreamingContext context)
        {

            #region 自定义属性
            this.mAlarmConfig = (IO_ALARM_CONFIG)info.GetValue("mAlarmConfig", typeof(IO_ALARM_CONFIG));
           // this.mIORealData = (IOData)info.GetValue("mIORealData", typeof(IOData));
            this.status = (int)info.GetValue("status", typeof(int));
            this._io_address = (string)info.GetValue("_io_address", typeof(string));
            this._io_alert_enable =(int)info.GetValue("_io_alert_enable", typeof(int));
            this._io_comm_id = (string)info.GetValue("_io_comm_id", typeof(string));
            this._io_datatype = (string)info.GetValue("_io_datatype", typeof(string));
            this._io_device_id = (string)info.GetValue("_io_device_id", typeof(string));
            this._io_enablealarm = (int)info.GetValue("_io_enablealarm", typeof(int));
            this._io_enablerangeconversion = (int)info.GetValue("_io_enablerangeconversion", typeof(int));
            this._io_history = (int)info.GetValue("_io_history", typeof(int));
            this._io_id = (string)info.GetValue("_io_id", typeof(string));
            this._io_initalvalue = (string)info.GetValue("_io_initalvalue", typeof(string));
            this._io_label = (string)info.GetValue("_io_label", typeof(string));
            this._io_maxvalue = (string)info.GetValue("_io_maxvalue", typeof(string));
            this._io_minvalue = (string)info.GetValue("_io_minvalue", typeof(string));
            this._io_name = (string)info.GetValue("_io_name", typeof(string));
            this._io_one = (string)info.GetValue("_io_one", typeof(string));
            this._io_outlies = (string)info.GetValue("_io_outlies", typeof(string));
            this._io_parastring = (string)info.GetValue("_io_parastring", typeof(string));
            this._io_pointtype = (string)info.GetValue("_io_pointtype", typeof(string));
            this._io_rangemax = (string)info.GetValue("_io_rangemax", typeof(string));
            this._io_rangemin = (string)info.GetValue("_io_rangemin", typeof(string));
            this._IO_SERVER_id = (string)info.GetValue("_IO_SERVER_id", typeof(string));
            this._io_system = (int)info.GetValue("_io_system", typeof(int));
            this._io_unit = (string)info.GetValue("_io_unit", typeof(string));
            this._io_zero = (string)info.GetValue("_io_zero", typeof(string));
            this._IO_FORMULA = (string)info.GetValue("_IO_FORMULA", typeof(string));
            this._IO_DATASOURCE = (string)info.GetValue("_IO_DATASOURCE", typeof(string));
            

            #endregion
        }

 
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("mAlarmConfig", this.mAlarmConfig);
           // info.AddValue("mIORealData", this.mIORealData);
            info.AddValue("status", this.status);
            info.AddValue("_io_address", this._io_address);
            info.AddValue("_io_alert_enable", this._io_alert_enable);
            info.AddValue("_io_comm_id", this._io_comm_id);
            info.AddValue("_io_datatype", this._io_datatype);
            info.AddValue("_io_device_id", this._io_device_id);
            info.AddValue("_io_enablealarm", this._io_enablealarm);
            info.AddValue("_io_enablerangeconversion", this._io_enablerangeconversion);
            info.AddValue("_io_history", this._io_history);
            info.AddValue("_io_id", this._io_id);
            info.AddValue("_io_initalvalue", this._io_initalvalue);
            info.AddValue("_io_label", this._io_label);
            info.AddValue("_io_maxvalue", this._io_maxvalue);
            info.AddValue("_io_minvalue", this._io_minvalue);
            info.AddValue("_io_name", this._io_name);
            info.AddValue("_io_one", this._io_one);
            info.AddValue("_io_outlies", this._io_outlies);
            info.AddValue("_io_parastring", this._io_parastring);
            info.AddValue("_io_pointtype", this._io_pointtype);
            info.AddValue("_io_rangemax", this._io_rangemax);
            info.AddValue("_io_rangemin", this._io_rangemin);
            info.AddValue("_IO_SERVER_id", this._IO_SERVER_id);
            info.AddValue("_io_system", this._io_system);
            info.AddValue("_io_unit", this._io_unit);
            info.AddValue("_io_zero", this._io_zero);
            info.AddValue("_IO_FORMULA", this._IO_FORMULA);
            info.AddValue("_IO_DATASOURCE", this._IO_DATASOURCE);


            
        }

        #endregion


    }
}

