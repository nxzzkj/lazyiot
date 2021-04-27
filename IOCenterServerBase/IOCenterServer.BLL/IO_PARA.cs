using System;
using System.Data;
using System.Collections.Generic;
using Scada.Common;
using Scada.Model;
using System.Threading.Tasks;
using System.Threading;

namespace Scada.Business
{
	/// <summary>
	/// IO_PARA
	/// </summary>
	public partial class IO_PARA
	{
		private readonly Scada.Database.IO_PARA dal=new Scada.Database.IO_PARA();
		public IO_PARA()
		{}
        #region  BasicMethod
        IO_ALARM_CONFIG alarmBll = new IO_ALARM_CONFIG();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Scada.Model.IO_PARA model)
		{
            if (dal.Add(model))
            {
                alarmBll.Add(model.AlarmConfig);
                return true;
            }
            else
                return false;
          
          
		}
        public void Add(List<Scada.Model.IO_PARA> models, List<Scada.Model.IO_ALARM_CONFIG> configs)
        {
            dal.Add(models);
            
            alarmBll.Add(configs);
        }
        public bool UpdateStatus(int status, string serverid)
        {
            return dal.UpdateStatus(status, serverid);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Scada.Model.IO_PARA model)
		{
            if(dal.Update(model))
            {
                alarmBll.Update(model.AlarmConfig);
                return true;
            }

            return false;
           
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string IO_ID)
		{
            //该表无主键信息，请自定义主键/条件字段
            if(dal.Delete(IO_ID))
            {
                alarmBll.Delete(IO_ID);
            }
            

            return dal.Delete(IO_ID);
		}
        /// <summary>
        /// 删除通道下的
        /// </summary>
        /// <param name="serverid"></param>
        /// <param name="comm_id"></param>
        /// <returns></returns>
        public bool DeleteCommunication(string serverid,string comm_id)
        {
            //该表无主键信息，请自定义主键/条件字段
            bool res = dal.DeleteCommunication(serverid, comm_id);
            if (res)
            {
                alarmBll.DeleteCommunication(serverid,comm_id);
            }
            return res;

     
        }
        /// <summary>
        /// 删除设备下的
        /// </summary>
        /// <param name="serverid"></param>
        /// <param name="deviceid"></param>
        /// <returns></returns>
        public bool DeleteDevice(string serverid, string deviceid)
        {
            //该表无主键信息，请自定义主键/条件字段
            bool res = dal.DeleteDevice(serverid, deviceid);
            if (res)
            {
                alarmBll.DeleteDevice(serverid, deviceid);
            }
            return res;


        }
     
        public bool Clear(string SERVER_ID)
        {
            if( dal.Clear(SERVER_ID.Trim()))
            {
             //   dal.ClearView(SERVER_ID.Trim());
                   alarmBll.Clear(SERVER_ID.Trim());
                return true;
            }
            return false;
        }
        public bool Clear()
        {
            if (dal.Clear())
            {
                //   dal.ClearView(SERVER_ID.Trim());
                alarmBll.Clear();
                return true;
            }
            return false;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Scada.Model.IO_PARA GetModel(string IO_ID)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel(IO_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Scada.Model.IO_PARA GetModelByCache(string IO_ID)
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "IO_PARAModel-"+ IO_ID;
			object objModel = Scada.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(IO_ID);
					if (objModel != null)
					{
						int ModelCache = Scada.Common.ConfigHelper.GetConfigInt("ModelCache");
						Scada.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Scada.Model.IO_PARA)objModel;
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
		public   List<Scada.Model.IO_PARA> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
            List<Scada.Model.IO_PARA> res =    DataTableToList(ds.Tables[0]);
            return res;

        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public    List<Scada.Model.IO_PARA> DataTableToList(DataTable dt)
        {
            List<Scada.Model.IO_PARA> modelList = new List<Scada.Model.IO_PARA>();
           
                 List<Task> tasks = new List<Task>();
             
                int rowsCount = dt.Rows.Count;
                if (rowsCount > 0)
                {
                   
                     
                    int sid = dt.Rows.Count % 100 == 0 ? (dt.Rows.Count / 100) : (dt.Rows.Count / 100 + 1);
                    for (int a = 1; a <= sid; a++)
                    {
                        object aa = a.ToString() + "," + sid.ToString();
                        tasks.Add( Task.Run(() =>
                        {

                       
                            int startindex = Convert.ToInt32(aa.ToString().Split(',')[0]);
                            int limitstep = Convert.ToInt32(aa.ToString().Split(',')[1]);
                            for (int i = (startindex > 1 ? ((startindex - 1) * 100) : 0); i < (startindex == limitstep ? (dt.Rows.Count) : startindex * 100); i++)
                            {
                                Scada.Model.IO_PARA model = dal.DataRowToModel(dt.Rows[i]);
                                if (model != null)
                                {
                                    lock (modelList)
                                    {
                              
                                        modelList.Add(model);
                                    }

                                }
                            }

                        }));
                    }

                }
             
               
            
        
            Task.WaitAll(tasks.ToArray());
            tasks.Clear();
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

