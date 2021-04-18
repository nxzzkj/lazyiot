using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Scada.Model
{
	/// <summary>
	/// SCADA_DRIVER:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public   class SCADA_DRIVER:ISerializable
	{
		public SCADA_DRIVER()
		{}
        public override string ToString()
        {
            return _title.ToString();
        }
        #region Model
        private string _id;
		private string _createtime;
		private string _updatetime;
		private string _communicationfullname;
		private string _communicationname;
		private string _devicename;
		private string _title;
		private string _description;
		private string _namespace;
		private string _anthor;
		private string _company;
		private string _devicefullname;
		private string _version;
		private string _fillname;
		private string _guid;
        private int _classifyid;
        private int _issystem;
        public int IsSystem
        {
            set
            {
                _issystem = value;


            }
            get { return _issystem; }
        }
        public int ClassifyId
        {
            set { _classifyid = value; }
            get { return _classifyid; }
        }


        #region  序列化和反序列化

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected SCADA_DRIVER(SerializationInfo info, StreamingContext context)
        {

            #region 自定义属性
            this._id = (string)info.GetValue("_id", typeof(string));
            this._createtime = (string)info.GetValue("_createtime", typeof(string));
            this._updatetime = (string)info.GetValue("_updatetime", typeof(string));
            this._communicationfullname = (string)info.GetValue("_description", typeof(string));
            this._communicationname = (string)info.GetValue("_communicationname", typeof(string));
            this._devicename = (string)info.GetValue("_devicename", typeof(string));
            this._title = (string)info.GetValue("_title", typeof(string));
            this._description = (string)info.GetValue("_description", typeof(string));
            this._namespace = (string)info.GetValue("_namespace", typeof(string));
            this._anthor = (string)info.GetValue("_anthor", typeof(string));
            this._company = (string)info.GetValue("_company", typeof(string));
            this._devicefullname = (string)info.GetValue("_devicefullname", typeof(string));
            this._version = (string)info.GetValue("_version", typeof(string));
            this._fillname = (string)info.GetValue("_fillname", typeof(string));
            this._guid = (string)info.GetValue("_guid", typeof(string));
            this._classifyid = (int)info.GetValue("_classifyid", typeof(int));
            this._issystem = (int)info.GetValue("_issystem", typeof(int));
            #endregion





        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_id", this._id);
            info.AddValue("_createtime", this._createtime);
            info.AddValue("_updatetime", this._updatetime);
            info.AddValue("_communicationfullname", this._communicationfullname);
            info.AddValue("_communicationname", this._communicationname);
            info.AddValue("_devicename", this._devicename);
            info.AddValue("_title", this._title);
            info.AddValue("_description", this._description);
            info.AddValue("_namespace", this._namespace);
            info.AddValue("_anthor", this._anthor);
            info.AddValue("_company", this._company);
            info.AddValue("_devicefullname", this._devicefullname);
            info.AddValue("_version", this._version);
            info.AddValue("_fillname", this._fillname);
            info.AddValue("_guid", this._guid);
            info.AddValue("_classifyid", this._classifyid);
            info.AddValue("_issystem", this._issystem);
            


        }

        #endregion
        public SCADA_DRIVER Copy()
        {
            SCADA_DRIVER driver = new SCADA_DRIVER()
            {
                _createtime = this._createtime,
                _id = this._id,
                _updatetime = this._updatetime,
                _communicationfullname = this._communicationfullname,
                _communicationname = this._communicationname,
                _devicename = this._devicename,
                _title = this._title,
                _description = this._description,
                _namespace = this._namespace,
                _anthor = this._anthor,
                _company = this._company,
                _devicefullname = this._devicefullname,
                _version = this._version,
                _fillname = this._fillname,
                _guid = this._guid,
                _classifyid = this._classifyid,
                _issystem = this._issystem


            };
            return driver;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CommunicationFullName
		{
			set{ _communicationfullname=value;}
			get{return _communicationfullname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CommunicationName
		{
			set{ _communicationname=value;}
			get{return _communicationname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeviceName
		{
			set{ _devicename=value;}
			get{return _devicename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Namespace
		{
			set{ _namespace=value;}
			get{return _namespace;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Anthor
		{
			set{ _anthor=value;}
			get{return _anthor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Company
		{
			set{ _company=value;}
			get{return _company;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeviceFullName
		{
			set{ _devicefullname=value;}
			get{return _devicefullname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Version
		{
			set{ _version=value;}
			get{return _version;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FillName
		{
			set{ _fillname=value;}
			get{return _fillname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GUID
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		#endregion Model
          
	}
}

