using System;
using System.Data;
using System.Collections.Generic;
using Scada.Common;
using Scada.Model;
using System.IO;
using System.Windows.Forms;

namespace Scada.Business
{
	/// <summary>
	/// IO_SERVER
	/// </summary>
	public partial class IO_SERVER
	{
		private readonly Scada.Database.IO_SERVER dal=new Scada.Database.IO_SERVER();
		public IO_SERVER()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SERVER_ID)
		{
			return dal.Exists(SERVER_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Scada.Model.IO_SERVER model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Scada.Model.IO_SERVER model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string SERVER_ID)
		{
			
			return dal.Delete(SERVER_ID);
		}
        public bool Clear(string SERVER_ID)
        {

            return dal.Clear(SERVER_ID);
        }
        public bool Clear()
        {

            return dal.Clear();
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SERVER_IDlist )
		{
			return dal.DeleteList(SERVER_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Scada.Model.IO_SERVER GetModel(string SERVER_ID)
		{
			
			return dal.GetModel(SERVER_ID);
		}
        public Scada.Model.IO_SERVER GetModel()
        {
            return dal.GetModel();
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Scada.Model.IO_SERVER GetModelByCache(string SERVER_ID)
		{
			
			string CacheKey = "IO_SERVERModel-" + SERVER_ID;
			object objModel = Scada.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SERVER_ID);
					if (objModel != null)
					{
						int ModelCache = Scada.Common.ConfigHelper.GetConfigInt("ModelCache");
						Scada.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Scada.Model.IO_SERVER)objModel;
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
		public List<Scada.Model.IO_SERVER> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Scada.Model.IO_SERVER> DataTableToList(DataTable dt)
		{
			List<Scada.Model.IO_SERVER> modelList = new List<Scada.Model.IO_SERVER>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Scada.Model.IO_SERVER model;
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
        public bool UpdateStatus(int status, string serverid)
        {
            return dal.UpdateStatus(status, serverid);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
 
    }
}

