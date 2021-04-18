using System;
namespace Scada.Model
{
	/// <summary>
	/// ScadaFlowProject:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ScadaFlowProject
	{
		public ScadaFlowProject()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _desc;
		private string _createdate;
		private string _projectid;
		private string _serverid;
        private string _flowuser = "";
        public string FlowUser
        {
            set { _flowuser = value; }
            get { return _flowuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int id
		{
			set{ _id=value;}
			get{return _id;}
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

