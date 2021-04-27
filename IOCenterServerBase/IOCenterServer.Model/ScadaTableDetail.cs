using System;
namespace Scada.Model
{
	/// <summary>
	/// ScadaTableDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ScadaTableDetail
	{
		public ScadaTableDetail()
		{}
		#region Model
		private int _id;
		private string _tableid;
		private string _fieldtitles;
		private string _fieldiopath;
		private string _createtime;
		private int? _sortcode;
		private int? _createuserid;
		private string _updatetime;
		private int? _updateuserid;
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
		public string TableId
		{
			set{ _tableid=value;}
			get{return _tableid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FieldTitles
		{
			set{ _fieldtitles=value;}
			get{return _fieldtitles;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FieldIOPath
		{
			set{ _fieldiopath=value;}
			get{return _fieldiopath;}
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
		public int? SortCode
		{
			set{ _sortcode=value;}
			get{return _sortcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreateUserId
		{
			set{ _createuserid=value;}
			get{return _createuserid;}
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
		public int? UpdateUserId
		{
			set{ _updateuserid=value;}
			get{return _updateuserid;}
		}
		#endregion Model

	}
}

