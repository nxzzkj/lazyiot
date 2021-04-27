using System;
using System.Text;

namespace Scada.Model
{
	/// <summary>
	/// ScadaFlowView:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ScadaFlowView
	{
		public ScadaFlowView()
		{}
		#region Model
		private int _id;
		private string _viewid;
		private string _viewtitle;
		private string _projectid;
		private string _isindex;
		private string _viewsvg;
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
		public string ViewId
		{
			set{ _viewid=value;}
			get{return _viewid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ViewTitle
		{
			set{ _viewtitle=value;}
			get{return _viewtitle;}
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
		public string IsIndex
		{
			set{ _isindex=value;}
			get{return _isindex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ViewSVG
		{
			set{ _viewsvg=value;}
			get{return _viewsvg;}
		}
        #endregion Model

        public StringBuilder ViewSb = new StringBuilder();

	}
}

