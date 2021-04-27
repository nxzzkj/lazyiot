using System;
using System.Data;
using System.Collections.Generic;
using Scada.Common;
using Scada.Model;
namespace Scada.Business
{
	/// <summary>
	/// ScadaFlowView
	/// </summary>
	public partial class ScadaFlowView
	{
		private readonly Scada.Database.ScadaFlowView dal=new Scada.Database.ScadaFlowView();
		public ScadaFlowView()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Scada.Model.ScadaFlowView model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Scada.Model.ScadaFlowView model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ProjectId)
		{
			
			return dal.Delete(ProjectId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			return dal.DeleteList(Idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Scada.Model.ScadaFlowView GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}
        public List<Scada.Model.ScadaFlowView> GetProjectViews(string ProjectId)
        {
            return GetModelList(" ProjectId='" + ProjectId + "'");
             
        }
        /// <summary>
        /// 获取流程图主页(主视图)
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        public Scada.Model.ScadaFlowView GetProjectIndexView(string ProjectId)
        {
            List<Scada.Model.ScadaFlowView> views=  GetModelList(" ProjectId='" + ProjectId + "' and  IsIndex='True'");
            if(views.Count>0)
            {
                return views[0];
            }
            return null;

        }
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Scada.Model.ScadaFlowView GetModelByCache(int Id)
		{
			
			string CacheKey = "ScadaFlowViewModel-" + Id;
			object objModel = Scada.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Scada.Common.ConfigHelper.GetConfigInt("ModelCache");
						Scada.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Scada.Model.ScadaFlowView)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Scada.Model.ScadaFlowView> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Scada.Model.ScadaFlowView> DataTableToList(DataTable dt)
		{
			List<Scada.Model.ScadaFlowView> modelList = new List<Scada.Model.ScadaFlowView>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Scada.Model.ScadaFlowView model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

