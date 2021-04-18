using ScadaWeb.DapperExtensions;
using System;
namespace ScadaWeb.Model
{
    /// <summary>
    /// ScadaFlowProject:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("ScadaFlowProject")]
    public partial class ScadaFlowProjectModel: Entity
    {
		public ScadaFlowProjectModel()
		{}
		#region Model
	 
		private string _title;
		private string _desc;
		private string _createdate;
		private string _projectid;
		private string _serverid;
       
        private string _servername = "";
        private string _flowuser = "";
        public string FlowUser
        {
            set { _flowuser = value; }
            get { return _flowuser; }
        }
        [Computed]
        public string ServerName
        {
            set { _servername = value; }
            get { return _servername; }
        }
        [Computed]
        public string ServerIP
        {
            set;
            get;
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
		public string Desc
		{
			set{ _desc=value;}
			get{return _desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjectId
		{
			set{ _projectid=value;}
			get{return _projectid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ServerID
		{
			set{ _serverid=value;}
			get{return _serverid;}
		}
		#endregion Model

	}
}

