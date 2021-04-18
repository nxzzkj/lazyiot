using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Scada.DBUtility;//Please add references
using System.Collections.Generic;
using System.Collections;

namespace Scada.Database
{
	/// <summary>
	/// 数据访问类:IO_DEVICE
	/// </summary>
	public partial class IO_DEVICE
	{
		public IO_DEVICE()
		{}
        #region  Method

        public void Add(List<Scada.Model.IO_DEVICE> models)
        {
            ArrayList sqlArray = new ArrayList();
            for(int i=0;i< models.Count;i++)
            {
                Scada.Model.IO_DEVICE model = models[i];
                model.IO_DEVICE_STATUS = 0;
                StringBuilder strSql = new StringBuilder();
                StringBuilder strSql1 = new StringBuilder();
                StringBuilder strSql2 = new StringBuilder();
                if (model.IO_DEVICE_ID != null)
                {
                    strSql1.Append("IO_DEVICE_ID,");
                    strSql2.Append("'" + model.IO_DEVICE_ID + "',");
                }
                if (model.IO_COMM_ID != null)
                {
                    strSql1.Append("IO_COMM_ID,");
                    strSql2.Append("'" + model.IO_COMM_ID + "',");
                }
                if (model.IO_SERVER_ID != null)
                {
                    strSql1.Append("IO_SERVER_ID,");
                    strSql2.Append("'" + model.IO_SERVER_ID + "',");
                }
                if (model.IO_DEVICE_NAME != null)
                {
                    strSql1.Append("IO_DEVICE_NAME,");
                    strSql2.Append("'" + model.IO_DEVICE_NAME + "',");
                }
                if (model.IO_DEVICE_LABLE != null)
                {
                    strSql1.Append("IO_DEVICE_LABLE,");
                    strSql2.Append("'" + model.IO_DEVICE_LABLE + "',");
                }
                if (model.IO_DEVICE_REMARK != null)
                {
                    strSql1.Append("IO_DEVICE_REMARK,");
                    strSql2.Append("'" + model.IO_DEVICE_REMARK + "',");
                }
               
                    strSql1.Append("IO_DEVICE_UPDATECYCLE,");
                    strSql2.Append("" + model.IO_DEVICE_UPDATECYCLE + ",");
               
                 
                    strSql1.Append("IO_DEVICE_STATUS,");
                    strSql2.Append("" + model.IO_DEVICE_STATUS + ",");
              
                    strSql1.Append("IO_DEVICE_OVERTIME,");
                    strSql2.Append("" + model.IO_DEVICE_OVERTIME + ",");
                
                if (model.IO_DEVICE_ADDRESS != null)
                {
                    strSql1.Append("IO_DEVICE_ADDRESS,");
                    strSql2.Append("'" + model.IO_DEVICE_ADDRESS + "',");
                }
                if (model.IO_DEVICE_PARASTRING != null)
                {
                    strSql1.Append("IO_DEVICE_PARASTRING,");
                    strSql2.Append("'" + model.IO_DEVICE_PARASTRING + "',");
                }
                if (model.DEVICE_DRIVER_ID != null)
                {
                    strSql1.Append("DEVICE_DRIVER_ID,");
                    strSql2.Append("'" + model.DEVICE_DRIVER_ID + "',");
                }
                strSql.Append("insert into IO_DEVICE(");
                strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
                strSql.Append(")");
                strSql.Append(" values (");
                strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
                strSql.Append(")");
                sqlArray.Add(strSql);
            }
          
           DbHelperSQLite.ExecuteSqlTran(sqlArray);
            sqlArray.Clear();
            sqlArray = null;
        }
        public StringBuilder GetInsertArray(Scada.Model.IO_DEVICE model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.IO_DEVICE_ID != null)
            {
                strSql1.Append("IO_DEVICE_ID,");
                strSql2.Append("'" + model.IO_DEVICE_ID + "',");
            }
            if (model.IO_COMM_ID != null)
            {
                strSql1.Append("IO_COMM_ID,");
                strSql2.Append("'" + model.IO_COMM_ID + "',");
            }
            if (model.IO_SERVER_ID != null)
            {
                strSql1.Append("IO_SERVER_ID,");
                strSql2.Append("'" + model.IO_SERVER_ID + "',");
            }
            if (model.IO_DEVICE_NAME != null)
            {
                strSql1.Append("IO_DEVICE_NAME,");
                strSql2.Append("'" + model.IO_DEVICE_NAME + "',");
            }
            if (model.IO_DEVICE_LABLE != null)
            {
                strSql1.Append("IO_DEVICE_LABLE,");
                strSql2.Append("'" + model.IO_DEVICE_LABLE + "',");
            }
            if (model.IO_DEVICE_REMARK != null)
            {
                strSql1.Append("IO_DEVICE_REMARK,");
                strSql2.Append("'" + model.IO_DEVICE_REMARK + "',");
            }
           
                strSql1.Append("IO_DEVICE_UPDATECYCLE,");
                strSql2.Append("" + model.IO_DEVICE_UPDATECYCLE + ",");
             
                strSql1.Append("IO_DEVICE_STATUS,");
                strSql2.Append("" + model.IO_DEVICE_STATUS + ",");
          
                strSql1.Append("IO_DEVICE_OVERTIME,");
                strSql2.Append("" + model.IO_DEVICE_OVERTIME + ",");
           
                strSql1.Append("IO_DEVICE_ADDRESS,");
                strSql2.Append("'" + model.IO_DEVICE_ADDRESS + "',");
           
                strSql1.Append("IO_DEVICE_PARASTRING,");
                strSql2.Append("'" + model.IO_DEVICE_PARASTRING + "',");
            
                strSql1.Append("DEVICE_DRIVER_ID,");
                strSql2.Append("'" + model.DEVICE_DRIVER_ID + "',");
            
            strSql.Append("insert into IO_DEVICE(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql;

        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Scada.Model.IO_DEVICE model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.IO_DEVICE_ID != null)
			{
				strSql1.Append("IO_DEVICE_ID,");
				strSql2.Append("'"+model.IO_DEVICE_ID+"',");
			}
			if (model.IO_COMM_ID != null)
			{
				strSql1.Append("IO_COMM_ID,");
				strSql2.Append("'"+model.IO_COMM_ID+"',");
			}
			if (model.IO_SERVER_ID != null)
			{
				strSql1.Append("IO_SERVER_ID,");
				strSql2.Append("'"+model.IO_SERVER_ID+"',");
			}
			if (model.IO_DEVICE_NAME != null)
			{
				strSql1.Append("IO_DEVICE_NAME,");
				strSql2.Append("'"+model.IO_DEVICE_NAME+"',");
			}
			if (model.IO_DEVICE_LABLE != null)
			{
				strSql1.Append("IO_DEVICE_LABLE,");
				strSql2.Append("'"+model.IO_DEVICE_LABLE+"',");
			}
			if (model.IO_DEVICE_REMARK != null)
			{
				strSql1.Append("IO_DEVICE_REMARK,");
				strSql2.Append("'"+model.IO_DEVICE_REMARK+"',");
			}
			 
				strSql1.Append("IO_DEVICE_UPDATECYCLE,");
				strSql2.Append(""+model.IO_DEVICE_UPDATECYCLE+",");
		 
				strSql1.Append("IO_DEVICE_STATUS,");
				strSql2.Append(""+model.IO_DEVICE_STATUS+",");
		 
				strSql1.Append("IO_DEVICE_OVERTIME,");
				strSql2.Append(""+model.IO_DEVICE_OVERTIME+",");
			 
			if (model.IO_DEVICE_ADDRESS != null)
			{
				strSql1.Append("IO_DEVICE_ADDRESS,");
				strSql2.Append("'"+model.IO_DEVICE_ADDRESS+"',");
			}
			if (model.IO_DEVICE_PARASTRING != null)
			{
				strSql1.Append("IO_DEVICE_PARASTRING,");
				strSql2.Append("'"+model.IO_DEVICE_PARASTRING+"',");
			}
			if (model.DEVICE_DRIVER_ID != null)
			{
				strSql1.Append("DEVICE_DRIVER_ID,");
				strSql2.Append("'"+model.DEVICE_DRIVER_ID+"',");
			}
			strSql.Append("insert into IO_DEVICE(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
        public bool UpdateStatus(int status, string serverid)
        {
            string sql = "update IO_DEVICE set IO_DEVICE_STATUS=" + status + " where IO_SERVER_ID='" + serverid + "'";
            int rowsAffected = DbHelperSQLite.ExecuteSql(sql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Scada.Model.IO_DEVICE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update IO_DEVICE set ");
			if (model.IO_DEVICE_ID != null)
			{
				strSql.Append("IO_DEVICE_ID='"+model.IO_DEVICE_ID+"',");
			}
			if (model.IO_COMM_ID != null)
			{
				strSql.Append("IO_COMM_ID='"+model.IO_COMM_ID+"',");
			}
			if (model.IO_SERVER_ID != null)
			{
				strSql.Append("IO_SERVER_ID='"+model.IO_SERVER_ID+"',");
			}
			if (model.IO_DEVICE_NAME != null)
			{
				strSql.Append("IO_DEVICE_NAME='"+model.IO_DEVICE_NAME+"',");
			}
			if (model.IO_DEVICE_LABLE != null)
			{
				strSql.Append("IO_DEVICE_LABLE='"+model.IO_DEVICE_LABLE+"',");
			}
			if (model.IO_DEVICE_REMARK != null)
			{
				strSql.Append("IO_DEVICE_REMARK='"+model.IO_DEVICE_REMARK+"',");
			}
			else
			{
				strSql.Append("IO_DEVICE_REMARK= null ,");
			}
			 
				strSql.Append("IO_DEVICE_UPDATECYCLE="+model.IO_DEVICE_UPDATECYCLE+",");
			 
				strSql.Append("IO_DEVICE_STATUS="+model.IO_DEVICE_STATUS+",");
			 
				strSql.Append("IO_DEVICE_OVERTIME="+model.IO_DEVICE_OVERTIME+",");
		 
				strSql.Append("IO_DEVICE_ADDRESS='"+model.IO_DEVICE_ADDRESS+"',");
			 
			if (model.IO_DEVICE_PARASTRING != null)
			{
				strSql.Append("IO_DEVICE_PARASTRING='"+model.IO_DEVICE_PARASTRING+"',");
			}
			if (model.DEVICE_DRIVER_ID != null)
			{
				strSql.Append("DEVICE_DRIVER_ID='"+model.DEVICE_DRIVER_ID+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
            strSql.Append(" where IO_DEVICE_ID='" + model.IO_DEVICE_ID + "");
            int rowsAffected=DbHelperSQLite.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string IO_DEVICE_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from IO_DEVICE ");
			strSql.Append(" where IO_DEVICE_ID='"+ IO_DEVICE_ID + "'");
			int rowsAffected=DbHelperSQLite.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
        public bool DeleteCommunication(string IO_SERVER_ID,string IO_COMM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from IO_DEVICE ");
            strSql.Append(" where IO_COMM_ID='" + IO_COMM_ID + "' and IO_SERVER_ID='"+ IO_SERVER_ID + "'");
            int rowsAffected = DbHelperSQLite.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Clear(string IO_SERVER_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from IO_DEVICE where  IO_SERVER_ID='" + IO_SERVER_ID + "'");

            int rowsAffected = DbHelperSQLite.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Clear()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from IO_DEVICE ");

            int rowsAffected = DbHelperSQLite.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Scada.Model.IO_DEVICE GetModel(string IO_DEVICE_ID)
		{
            DataSet drids = driverDal.GetList("");

            List<Scada.Model.SCADA_DEVICE_DRIVER> drivers = new List<Model.SCADA_DEVICE_DRIVER>();
            for(int i=0;i< drids.Tables[0].Rows.Count;i++)
            {
                drivers.Add(driverDal.DataRowToModel(drids.Tables[0].Rows[i]));
            }
           StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" IO_DEVICE_ID,IO_COMM_ID,IO_SERVER_ID,IO_DEVICE_NAME,IO_DEVICE_LABLE,IO_DEVICE_REMARK,IO_DEVICE_UPDATECYCLE,IO_DEVICE_STATUS,IO_DEVICE_OVERTIME,IO_DEVICE_ADDRESS,IO_DEVICE_PARASTRING,DEVICE_DRIVER_ID ");
			strSql.Append(" from IO_DEVICE ");
            strSql.Append(" where IO_DEVICE_ID='" + IO_DEVICE_ID + "");

            Scada.Model.IO_DEVICE model=new Scada.Model.IO_DEVICE();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{

				return DataRowToModel(ds.Tables[0].Rows[0], drivers);
			}
			else
			{
				return null;
			}
		}
      
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Scada.Model.IO_DEVICE DataRowToModel(DataRow row,List<Model.SCADA_DEVICE_DRIVER> Drives)
		{
			Scada.Model.IO_DEVICE model=new Scada.Model.IO_DEVICE();
			if (row != null)
			{
				if(row["IO_DEVICE_ID"]!=null)
				{
					model.IO_DEVICE_ID=row["IO_DEVICE_ID"].ToString();
				}
				if(row["IO_COMM_ID"]!=null)
				{
					model.IO_COMM_ID=row["IO_COMM_ID"].ToString();
				}
				if(row["IO_SERVER_ID"]!=null)
				{
					model.IO_SERVER_ID=row["IO_SERVER_ID"].ToString();
				}
				if(row["IO_DEVICE_NAME"]!=null)
				{
					model.IO_DEVICE_NAME=row["IO_DEVICE_NAME"].ToString();
				}
				if(row["IO_DEVICE_LABLE"]!=null)
				{
					model.IO_DEVICE_LABLE=row["IO_DEVICE_LABLE"].ToString();
				}
				if(row["IO_DEVICE_REMARK"]!=null)
				{
					model.IO_DEVICE_REMARK=row["IO_DEVICE_REMARK"].ToString();
				}
				if(row["IO_DEVICE_UPDATECYCLE"]!=null && row["IO_DEVICE_UPDATECYCLE"].ToString()!="")
				{
					model.IO_DEVICE_UPDATECYCLE=int.Parse(row["IO_DEVICE_UPDATECYCLE"].ToString());
				}
				if(row["IO_DEVICE_STATUS"]!=null && row["IO_DEVICE_STATUS"].ToString()!="")
				{
					model.IO_DEVICE_STATUS=int.Parse(row["IO_DEVICE_STATUS"].ToString());
				}
				if(row["IO_DEVICE_OVERTIME"]!=null && row["IO_DEVICE_OVERTIME"].ToString()!="")
				{
					model.IO_DEVICE_OVERTIME=int.Parse(row["IO_DEVICE_OVERTIME"].ToString());
				}
				if(row["IO_DEVICE_ADDRESS"]!=null)
				{
					model.IO_DEVICE_ADDRESS=row["IO_DEVICE_ADDRESS"].ToString();
				}
				if(row["IO_DEVICE_PARASTRING"]!=null)
				{
					model.IO_DEVICE_PARASTRING=row["IO_DEVICE_PARASTRING"].ToString();
				}
				if(row["DEVICE_DRIVER_ID"]!=null)
				{
					model.DEVICE_DRIVER_ID=row["DEVICE_DRIVER_ID"].ToString();
				}

                //获取对应的IO点
                model.DriverInfo = Drives.Find(x => x.Id.ToString() == model.DEVICE_DRIVER_ID);

            }
			return model;
		}
        SCADA_DEVICE_DRIVER driverDal = new SCADA_DEVICE_DRIVER();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  *  ");
			strSql.Append(" FROM IO_DEVICE  where IO_DEVICE_STATUS=0 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" and  "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM IO_DEVICE ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQLite.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.COMMAND_ID desc");
			}
			strSql.Append(")AS Row, T.*  from IO_DEVICE T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/*
		*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

