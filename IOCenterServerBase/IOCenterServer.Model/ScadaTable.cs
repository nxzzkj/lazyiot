using System;
namespace Scada.Model
{
	/// <summary>
	/// ScadaTable:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ScadaTable
	{
		public ScadaTable()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _roleuser;
		private int? _filterrule;
		private string _createtime;
		private int? _createuserid;
		private string _updatetime;
		private int? _updateuserid;
		private int? _sortcode;
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
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleUser
		{
			set{ _roleuser=value;}
			get{return _roleuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FilterRule
		{
			set{ _filterrule=value;}
			get{return _filterrule;}
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
		/// <summary>
		/// 
		/// </summary>
		public int? SortCode
		{
			set{ _sortcode=value;}
			get{return _sortcode;}
		}
		#endregion Model

	}
}

