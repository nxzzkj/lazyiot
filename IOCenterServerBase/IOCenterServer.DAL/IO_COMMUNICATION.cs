using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Scada.DBUtility;//Please add references
using System.Collections;
using System.Collections.Generic;

namespace Scada.Database
{
	/// <summary>
	/// 数据访问类:IO_COMMUNICATION
	/// </summary>
	public partial class IO_COMMUNICATION
	{
		public IO_COMMUNICATION()
		{}
        #region  Method

        
     public void Add(List<Scada.Model.IO_COMMUNICATION> models)
        {
            ArrayList sqlArray = new ArrayList();
            for(int i=0;i< models.Count;i++)
            {
                Scada.Model.IO_COMMUNICATION model = models[i];
                model.IO_COMM_STATUS = 0;
                StringBuilder strSql = new StringBuilder();
                StringBuilder strSql1 = new StringBuilder();
                StringBuilder strSql2 = new StringBuilder();
                if (model.IO_COMM_ID != null)
                {
                    strSql1.Append("IO_COMM_ID,");
                    strSql2.Append("'" + model.IO_COMM_ID + "',");
                }
                if (model.IO_COMM_NAME != null)
                {
                    strSql1.Append("IO_COMM_NAME,");
                    strSql2.Append("'" + model.IO_COMM_NAME + "',");
                }
                if (model.IO_COMM_LABEL != null)
                {
                    strSql1.Append("IO_COMM_LABEL,");
                    strSql2.Append("'" + model.IO_COMM_LABEL + "',");
                }
                if (model.IO_COMM_REMARK != null)
                {
                    strSql1.Append("IO_COMM_REMARK,");
                    strSql2.Append("'" + model.IO_COMM_REMARK + "',");
                }
                if (model.IO_COMM_PARASTRING != null)
                {
                    strSql1.Append("IO_COMM_PARASTRING,");
                    strSql2.Append("'" + model.IO_COMM_PARASTRING + "',");
                }


                
                    strSql1.Append("IO_COMM_STATUS,");
                    strSql2.Append("" + model.IO_COMM_STATUS + ",");
                
                if (model.IO_COMM_DRIVER_ID != null)
                {
                    strSql1.Append("IO_COMM_DRIVER_ID,");
                    strSql2.Append("'" + model.IO_COMM_DRIVER_ID + "',");
                }
                if (model.IO_SERVER_ID != null)
                {
                    strSql1.Append("IO_SERVER_ID,");
                    strSql2.Append("'" + model.IO_SERVER_ID + "',");
                }
                strSql.Append("insert into IO_COMMUNICATION(");
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
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Scada.Model.IO_COMMUNICATION model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.IO_COMM_ID != null)
			{
				strSql1.Append("IO_COMM_ID,");
				strSql2.Append("'"+model.IO_COMM_ID+"',");
			}
			if (model.IO_COMM_NAME != null)
			{
				strSql1.Append("IO_COMM_NAME,");
				strSql2.Append("'"+model.IO_COMM_NAME+"',");
			}
			if (model.IO_COMM_LABEL != null)
			{
				strSql1.Append("IO_COMM_LABEL,");
				strSql2.Append("'"+model.IO_COMM_LABEL+"',");
			}
			if (model.IO_COMM_REMARK != null)
			{
				strSql1.Append("IO_COMM_REMARK,");
				strSql2.Append("'"+model.IO_COMM_REMARK+"',");
			}
            if (model.IO_COMM_PARASTRING != null)
            {
                strSql1.Append("IO_COMM_PARASTRING,");
                strSql2.Append("'" + model.IO_COMM_PARASTRING + "',");
            }
            

            
				strSql1.Append("IO_COMM_STATUS,");
				strSql2.Append(""+model.IO_COMM_STATUS+",");
			 
			if (model.IO_COMM_DRIVER_ID != null)
			{
				strSql1.Append("IO_COMM_DRIVER_ID,");
				strSql2.Append("'"+model.IO_COMM_DRIVER_ID+"',");
			}
			if (model.IO_SERVER_ID != null)
			{
				strSql1.Append("IO_SERVER_ID,");
				strSql2.Append("'"+model.IO_SERVER_ID+"',");
			}
			strSql.Append("insert into IO_COMMUNICATION(");
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
            string sql = "update IO_COMMUNICATION set IO_COMM_STATUS=" + status + " where IO_SERVER_ID='" + serverid + "'";
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
        public bool Update(Scada.Model.IO_COMMUNICATION model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update IO_COMMUNICATION set ");
			if (model.IO_COMM_ID != null)
			{
				strSql.Append("IO_COMM_ID='"+model.IO_COMM_ID+"',");
			}
			if (model.IO_COMM_NAME != null)
			{
				strSql.Append("IO_COMM_NAME='"+model.IO_COMM_NAME+"',");
			}
			if (model.IO_COMM_LABEL != null)
			{
				strSql.Append("IO_COMM_LABEL='"+model.IO_COMM_LABEL+"',");
			}
			if (model.IO_COMM_REMARK != null)
			{
				strSql.Append("IO_COMM_REMARK='"+model.IO_COMM_REMARK+"',");
			}
			else
			{
				strSql.Append("IO_COMM_REMARK= null ,");
			}
            if (model.IO_COMM_PARASTRING != null)
            {
                strSql.Append("IO_COMM_PARASTRING='" + model.IO_COMM_PARASTRING + "',");
            }
            else
            {
                strSql.Append("IO_COMM_PARASTRING= null ,");
            }

            

           
				strSql.Append("IO_COMM_STATUS="+model.IO_COMM_STATUS+",");
			 
			if (model.IO_COMM_DRIVER_ID != null)
			{
				strSql.Append("IO_COMM_DRIVER_ID='"+model.IO_COMM_DRIVER_ID+"',");
			}
			if (model.IO_SERVER_ID != null)
			{
				strSql.Append("IO_SERVER_ID='"+model.IO_SERVER_ID+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where IO_COMM_ID='"+model.IO_COMM_ID + "'");
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
		public bool Delete(string IO_COMM_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from IO_COMMUNICATION ");
			strSql.Append(" where IO_COMM_ID='"+ IO_COMM_ID + "'");
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
        public bool Clear(string IO_SERVER_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from IO_COMMUNICATION where  IO_SERVER_ID='" + IO_SERVER_ID + "'");

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
            strSql.Append("delete from IO_COMMUNICATION");

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
        public Scada.Model.IO_COMMUNICATION GetModel(string IO_COMM_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" IO_COMM_ID,IO_COMM_NAME,IO_COMM_LABEL,IO_COMM_REMARK,IO_COMM_STATUS,IO_COMM_DRIVER_ID,IO_SERVER_ID,IO_COMM_PARASTRING ");
			strSql.Append(" from IO_COMMUNICATION ");
			strSql.Append(" where IO_COMM_ID='"+ IO_COMM_ID + "'");
			Scada.Model.IO_COMMUNICATION model=new Scada.Model.IO_COMMUNICATION();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Scada.Model.IO_COMMUNICATION DataRowToModel(DataRow row)
		{
			Scada.Model.IO_COMMUNICATION model=new Scada.Model.IO_COMMUNICATION();
			if (row != null)
			{
				if(row["IO_COMM_ID"]!=null)
				{
					model.IO_COMM_ID=row["IO_COMM_ID"].ToString();
				}
				if(row["IO_COMM_NAME"]!=null)
				{
					model.IO_COMM_NAME=row["IO_COMM_NAME"].ToString();
				}
				if(row["IO_COMM_LABEL"]!=null)
				{
					model.IO_COMM_LABEL=row["IO_COMM_LABEL"].ToString();
				}
				if(row["IO_COMM_REMARK"]!=null && row["IO_COMM_REMARK"].ToString()!="")
				{
					model.IO_COMM_REMARK=row["IO_COMM_REMARK"].ToString();
				}
				if(row["IO_COMM_STATUS"]!=null && row["IO_COMM_STATUS"].ToString()!="")
				{
					model.IO_COMM_STATUS=int.Parse(row["IO_COMM_STATUS"].ToString());
				}
				if(row["IO_COMM_DRIVER_ID"]!=null)
				{
					model.IO_COMM_DRIVER_ID=row["IO_COMM_DRIVER_ID"].ToString();
				}
                if (row["IO_COMM_PARASTRING"] != null)
                {
                    model.IO_COMM_PARASTRING = row["IO_COMM_PARASTRING"].ToString();
                }
                

                if (row["IO_SERVER_ID"]!=null)
				{
					model.IO_SERVER_ID=row["IO_SERVER_ID"].ToString();
				}
                //加载通道驱动信息
                model.DriverInfo = driverDal.GetModel(model.IO_COMM_DRIVER_ID);

            }
			return model;
		}
        SCADA_DRIVER driverDal = new SCADA_DRIVER();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select IO_COMM_ID,IO_COMM_NAME,IO_COMM_LABEL,IO_COMM_REMARK,IO_COMM_STATUS,IO_COMM_DRIVER_ID,IO_SERVER_ID,IO_COMM_PARASTRING ");
			strSql.Append(" FROM IO_COMMUNICATION  where IO_COMM_STATUS=0 ");
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
			strSql.Append("select count(1) FROM IO_COMMUNICATION ");
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
			strSql.Append(")AS Row, T.*  from IO_COMMUNICATION T ");
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

