using System;
using System.Data;
using System.Collections.Generic;
using Scada.Model;
namespace Scada.Business
{
	/// <summary>
	/// ScadaFlowProject
	/// </summary>
	public partial class ScadaFlowProject
	{
		private readonly Scada.Database.ScadaFlowProject dal=new Scada.Database.ScadaFlowProject();
		public ScadaFlowProject()
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
        public bool Exists(string ProjectId)
        {
			return dal.Exists(ProjectId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Scada.Model.ScadaFlowProject model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Scada.Model.ScadaFlowProject model)
		{
			return dal.Update(model);
        }
        public bool UpdateFromProjectId(Scada.Model.ScadaFlowProject model)
        {
            return dal.UpdateFromProjectId(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
        public bool DeleteFromProjectId(int ProjectId)
        {
            return dal.DeleteFromProjectId(ProjectId);

        }
        public Scada.Model.ScadaFlowProject GetModelFromProjectId(int ProjectId)
        {

            return dal.GetModelFromProjectId(ProjectId);

        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Scada.Model.ScadaFlowProject GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Scada.Model.ScadaFlowProject GetModelByCache(int id)
		{
			
			string CacheKey = "ScadaFlowProjectModel-" + id;
			object objModel = Scada.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = Scada.Common.ConfigHelper.GetConfigInt("ModelCache");
						Scada.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Scada.Model.ScadaFlowProject)objModel;
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
		public List<Scada.Model.ScadaFlowProject> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Scada.Model.ScadaFlowProject> DataTableToList(DataTable dt)
		{
			List<Scada.Model.ScadaFlowProject> modelList = new List<Scada.Model.ScadaFlowProject>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Scada.Model.ScadaFlowProject model;
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

