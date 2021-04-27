using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Scada.Model
{
	/// <summary>
	/// Classify_DRIVER:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public   class Classify_DRIVER: ISerializable
    {
		public Classify_DRIVER()
		{}
		#region Model
		private int _id;
		private string _classifyname;
		private string _createtime;
		private string _updatetime;
		private string _description;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ClassifyName
		{
			set{ _classifyname=value;}
			get{return _classifyname;}
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
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}

        #region  序列化和反序列化

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected Classify_DRIVER(SerializationInfo info, StreamingContext context)
        {

            #region 自定义属性
            this._id = (int)info.GetValue("_id", typeof(int));
            this._classifyname = (string)info.GetValue("_classifyname", typeof(string));
            this._createtime = (string)info.GetValue("_createtime", typeof(string));
            this._description = (string)info.GetValue("_description", typeof(string));
            this._updatetime = (string)info.GetValue("_updatetime", typeof(string));
            this._description = (string)info.GetValue("_description", typeof(string));

            #endregion





        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_id", this._id);
            info.AddValue("_classifyname", this._classifyname);
            info.AddValue("_createtime", this._createtime);
            info.AddValue("_description", this._description);
            info.AddValue("_updatetime", this._updatetime);
            info.AddValue("_description", this._description);
        }

        #endregion
        public Classify_DRIVER Copy()
        {
            Classify_DRIVER driver = new Classify_DRIVER()
            {
                _classifyname = this._classifyname,
                _id = this._id,
                _createtime = this._createtime,
                _description = this._description,
                _updatetime = this._updatetime

            };
            return driver;
        }
        #endregion Model

    }
}

