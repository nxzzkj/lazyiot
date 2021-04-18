using System;
using System.Data;
using System.Collections.Generic;
using Scada.Common;
using Scada.Model;
using System.Threading.Tasks;

namespace Scada.Business
{
	/// <summary>
	/// IO_DEVICE
	/// </summary>
	public partial class IO_DEVICE
	{
		private readonly Scada.Database.IO_DEVICE dal=new Scada.Database.IO_DEVICE();
		public IO_DEVICE()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Scada.Model.IO_DEVICE model)
		{
			return dal.Add(model);
		}
        public void Add(List<Scada.Model.IO_DEVICE> models)
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
        public bool Update(Scada.Model.IO_DEVICE model)
		{
			return dal.Update(model);
		}
        IO_PARA paraDal = new IO_PARA();
        IO_ALARM_CONFIG configDal = new IO_ALARM_CONFIG();
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string IO_SERVER_ID, string IO_DEVICE_ID)
		{
			//该表无主键信息，请自定义主键/条件字段
			bool res= dal.Delete(IO_DEVICE_ID);
            if(res)
            {
              
                paraDal.DeleteDevice(IO_SERVER_ID, IO_DEVICE_ID);
                configDal.DeleteDevice(IO_SERVER_ID, IO_DEVICE_ID);
            }
            return res;

        }
        public bool DeleteCommunication(string serverid, string comm_id)
        {
            //该表无主键信息，请自定义主键/条件字段
            bool res = dal.DeleteCommunication(serverid, comm_id);
            
            return res;


        }

        public bool Clear(string SERVER_ID)
        {

            return dal.Clear(SERVER_ID.Trim());
        }
        public bool Clear()
        {

            return dal.Clear();
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Scada.Model.IO_DEVICE GetModel(string IO_DEVICE_ID)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel(IO_DEVICE_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Scada.Model.IO_DEVICE GetModelByCache(string IO_DEVICE_ID)
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "IO_DEVICEModel-"+ IO_DEVICE_ID;
			object objModel = Scada.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(IO_DEVICE_ID);
					if (objModel != null)
					{
						int ModelCache = Scada.Common.ConfigHelper.GetConfigInt("ModelCache");
						Scada.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Scada.Model.IO_DEVICE)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        IO_PARA paraBll = new IO_PARA();
       
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Scada.Model.IO_DEVICE> GetModelList(string strWhere)
        {
           

            DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0], strWhere);
		}
        SCADA_DEVICE_DRIVER driverBLL = new SCADA_DEVICE_DRIVER();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Scada.Model.IO_DEVICE> DataTableToList(DataTable dt,string strWhere)

        { 

            List<Scada.Model.SCADA_DEVICE_DRIVER> drivers = driverBLL.GetModelList("");


            List<Scada.Model.IO_PARA> allParas =   paraBll.GetModelList(strWhere);

            List<Task> tasks = new List<Task>();

            List<Scada.Model.IO_DEVICE> modelList = new List<Scada.Model.IO_DEVICE>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                int sid = dt.Rows.Count % 100 == 0 ? (dt.Rows.Count / 100) : (dt.Rows.Count / 100 + 1);
                for (int a = 1; a <= sid; a++)
                {
                    object aa = a.ToString() + "," + sid.ToString();
                    tasks.Add(Task.Run(() =>
                    {

                   
                        int startindex = Convert.ToInt32(aa.ToString().Split(',')[0]);
                        int limitstep = Convert.ToInt32(aa.ToString().Split(',')[1]);
                        for (int i = (startindex > 1 ? ((startindex - 1) * 100) : 0); i < (startindex == limitstep ? (dt.Rows.Count) : startindex * 100); i++)
                        {

                            Scada.Model.IO_DEVICE model = dal.DataRowToModel(dt.Rows[i], drivers);
                            if (model != null)
                            {
                            
                                model.IOParas = allParas.FindAll(x => x != null && x.IO_DEVICE_ID == model.IO_DEVICE_ID &&  x.IO_COMM_ID == model.IO_COMM_ID && x.IO_SERVER_ID == model.IO_SERVER_ID);
                                lock(modelList)
                                {
                                    
                                    modelList.Add(model);

                                }
                           
                            lock(allParas)
                                {
                                    for (int c = 0; c < model.IOParas.Count; c++)
                                    {
                                        allParas.Remove(model.IOParas[c]);//删除已经搜索到的
                                    }
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

