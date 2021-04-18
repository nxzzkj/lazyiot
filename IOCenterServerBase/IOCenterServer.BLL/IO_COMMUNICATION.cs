using System;
using System.Data;
using System.Collections.Generic;
using Scada.Common;
using Scada.Model;
namespace Scada.Business
{
	/// <summary>
	/// IO_COMMUNICATION
	/// </summary>
	public partial class IO_COMMUNICATION
	{
		private readonly Scada.Database.IO_COMMUNICATION dal=new Scada.Database.IO_COMMUNICATION();
		public IO_COMMUNICATION()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Scada.Model.IO_COMMUNICATION model)
		{
			return dal.Add(model);
		}
        public void Add(List<Scada.Model.IO_COMMUNICATION> models)
        {
             dal.Add(models);
        }
        public bool UpdateStatus(int status, string serverid)
        {
            return dal.UpdateStatus(status, serverid);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Scada.Model.IO_COMMUNICATION model)
		{
			return dal.Update(model);
		}
        IO_DEVICE deviceDal = new IO_DEVICE();
        IO_PARA paraDal = new IO_PARA();
        IO_ALARM_CONFIG configDal = new IO_ALARM_CONFIG();
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string IO_SERVER_ID, string IO_COMM_ID)
        {
            //该表无主键信息，请自定义主键/条件字段
            bool res = dal.Delete(IO_COMM_ID);
            if (res)
            {
                deviceDal.DeleteCommunication(IO_SERVER_ID, IO_COMM_ID);
                paraDal.DeleteCommunication(IO_SERVER_ID, IO_COMM_ID);
                configDal.DeleteCommunication(IO_SERVER_ID, IO_COMM_ID);
            }
            return res;
        }
        public bool Clear(string IO_SERVER_ID)
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.Clear(IO_SERVER_ID.Trim());
        }
        public bool Clear()
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.Clear();
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Scada.Model.IO_COMMUNICATION GetModel(string IO_COMM_ID)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel(IO_COMM_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Scada.Model.IO_COMMUNICATION GetModelByCache(string IO_COMM_ID)
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "IO_COMMUNICATIONModel-" ;
			object objModel = Scada.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(IO_COMM_ID);
					if (objModel != null)
					{
						int ModelCache = Scada.Common.ConfigHelper.GetConfigInt("ModelCache");
						Scada.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Scada.Model.IO_COMMUNICATION)objModel;
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
		public List<Scada.Model.IO_COMMUNICATION> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Scada.Model.IO_COMMUNICATION> DataTableToList(DataTable dt)
		{
			List<Scada.Model.IO_COMMUNICATION> modelList = new List<Scada.Model.IO_COMMUNICATION>();
 
            int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Scada.Model.IO_COMMUNICATION model;
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

