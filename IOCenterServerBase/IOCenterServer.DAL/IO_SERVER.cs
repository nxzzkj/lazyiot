using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Scada.DBUtility;//Please add references
namespace Scada.Database
{
	/// <summary>
	/// 数据访问类:IO_SERVER
	/// </summary>
	public partial class IO_SERVER
	{
		public IO_SERVER()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SERVER_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from IO_SERVER");
			strSql.Append(" where SERVER_ID='"+SERVER_ID+"' ");
			return DbHelperSQLite.Exists(strSql.ToString());
		}
        public StringBuilder GetInsertArray(Scada.Model.IO_SERVER model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.SERVER_ID != null)
            {
                strSql1.Append("SERVER_ID,");
                strSql2.Append("'" + model.SERVER_ID + "',");
            }
            if (model.SERVER_NAME != null)
            {
                strSql1.Append("SERVER_NAME,");
                strSql2.Append("'" + model.SERVER_NAME + "',");
            }
             
                strSql1.Append("SERVER_STATUS,");
                strSql2.Append("" + model.SERVER_STATUS + ",");
             
            if (model.SERVER_IP != null)
            {
                strSql1.Append("SERVER_IP,");
                strSql2.Append("'" + model.SERVER_IP + "',");
            }
            if (model.SERVER_CREATEDATE != null)
            {
                strSql1.Append("SERVER_CREATEDATE,");
                strSql2.Append("'" + model.SERVER_CREATEDATE + "',");
            }
            if (model.SERVER_REMARK != null)
            {
                strSql1.Append("SERVER_REMARK,");
                strSql2.Append("'" + model.SERVER_REMARK + "',");
            }
            strSql.Append("insert into IO_SERVER(");
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
        public bool Add(Scada.Model.IO_SERVER model)
		{
            model.SERVER_STATUS = 0;
               StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.SERVER_ID != null)
			{
				strSql1.Append("SERVER_ID,");
				strSql2.Append("'"+model.SERVER_ID+"',");
			}
			if (model.SERVER_NAME != null)
			{
				strSql1.Append("SERVER_NAME,");
				strSql2.Append("'"+model.SERVER_NAME+"',");
			}
			
				strSql1.Append("SERVER_STATUS,");
				strSql2.Append(""+model.SERVER_STATUS+",");
			
			if (model.SERVER_IP != null)
			{
				strSql1.Append("SERVER_IP,");
				strSql2.Append("'"+model.SERVER_IP+"',");
			}
			if (model.SERVER_CREATEDATE != null)
			{
				strSql1.Append("SERVER_CREATEDATE,");
				strSql2.Append("'"+model.SERVER_CREATEDATE+"',");
			}
			if (model.SERVER_REMARK != null)
			{
				strSql1.Append("SERVER_REMARK,");
				strSql2.Append("'"+model.SERVER_REMARK+"',");
			}
			strSql.Append("insert into IO_SERVER(");
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
            string sql = "update IO_SERVER set SERVER_STATUS=" + status + " where SERVER_ID='" + serverid + "'";
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
        public bool Update(Scada.Model.IO_SERVER model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update IO_SERVER set ");
			if (model.SERVER_NAME != null)
			{
				strSql.Append("SERVER_NAME='"+model.SERVER_NAME+"',");
			}
			
				strSql.Append("SERVER_STATUS="+model.SERVER_STATUS+",");
			
			if (model.SERVER_IP != null)
			{
				strSql.Append("SERVER_IP='"+model.SERVER_IP+"',");
			}
			if (model.SERVER_CREATEDATE != null)
			{
				strSql.Append("SERVER_CREATEDATE='"+model.SERVER_CREATEDATE+"',");
			}
			else
			{
				strSql.Append("SERVER_CREATEDATE= null ,");
			}
			if (model.SERVER_REMARK != null)
			{
				strSql.Append("SERVER_REMARK='"+model.SERVER_REMARK+"',");
			}
			else
			{
				strSql.Append("SERVER_REMARK= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where SERVER_ID='"+ model.SERVER_ID+"' ");
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
		public bool Delete(string SERVER_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from IO_SERVER ");
			strSql.Append(" where SERVER_ID='"+SERVER_ID+"' " );
			int rowsAffected=DbHelperSQLite.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{ 
                //删除工程下面的所有相关的数据
                IO_COMMUNICATION commBll = new IO_COMMUNICATION();
                commBll.Clear(SERVER_ID);
                IO_DEVICE deviceBll = new IO_DEVICE();
                deviceBll.Clear(SERVER_ID);
                IO_PARA paraBll = new IO_PARA();
                paraBll.Clear(SERVER_ID);
                IO_ALARM_CONFIG configBll = new IO_ALARM_CONFIG();
                configBll.Clear(SERVER_ID);
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
            strSql.Append("delete from IO_SERVER where  SERVER_ID='" + IO_SERVER_ID + "'");

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
            strSql.Append("delete from IO_SERVER");

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string SERVER_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from IO_SERVER ");
			strSql.Append(" where SERVER_ID in ("+SERVER_IDlist + ")  ");
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


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Scada.Model.IO_SERVER GetModel(string SERVER_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" SERVER_ID,SERVER_NAME,SERVER_STATUS,SERVER_IP,SERVER_CREATEDATE,SERVER_REMARK ");
			strSql.Append(" from IO_SERVER ");
			strSql.Append(" where SERVER_ID='"+SERVER_ID+"' " );
			Scada.Model.IO_SERVER model=new Scada.Model.IO_SERVER();
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
        public Scada.Model.IO_SERVER GetModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" SERVER_ID,SERVER_NAME,SERVER_STATUS,SERVER_IP,SERVER_CREATEDATE,SERVER_REMARK ");
            strSql.Append(" from IO_SERVER  LIMIT 1");
        
            Scada.Model.IO_SERVER model = new Scada.Model.IO_SERVER();
            DataSet ds = DbHelperSQLite.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
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
        public Scada.Model.IO_SERVER DataRowToModel(DataRow row)
		{
			Scada.Model.IO_SERVER model=new Scada.Model.IO_SERVER();
			if (row != null)
			{
				if(row["SERVER_ID"]!=null)
				{
					model.SERVER_ID=row["SERVER_ID"].ToString();
				}
				if(row["SERVER_NAME"]!=null)
				{
					model.SERVER_NAME=row["SERVER_NAME"].ToString();
				}
				if(row["SERVER_STATUS"]!=null && row["SERVER_STATUS"].ToString()!="")
				{
					model.SERVER_STATUS=int.Parse(row["SERVER_STATUS"].ToString());
				}
				if(row["SERVER_IP"]!=null)
				{
					model.SERVER_IP=row["SERVER_IP"].ToString();
				}
				if(row["SERVER_CREATEDATE"]!=null)
				{
					model.SERVER_CREATEDATE=row["SERVER_CREATEDATE"].ToString();
				}
				if(row["SERVER_REMARK"]!=null)
				{
					model.SERVER_REMARK=row["SERVER_REMARK"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SERVER_ID,SERVER_NAME,SERVER_STATUS,SERVER_IP,SERVER_CREATEDATE,SERVER_REMARK ");
			strSql.Append(" FROM IO_SERVER where  SERVER_STATUS=0");
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
			strSql.Append("select count(1) FROM IO_SERVER ");
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
				strSql.Append("order by T.SERVER_ID desc");
			}
			strSql.Append(")AS Row, T.*  from IO_SERVER T ");
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

