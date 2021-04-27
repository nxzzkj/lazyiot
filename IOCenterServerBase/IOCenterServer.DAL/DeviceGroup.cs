using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
 
using Scada.DBUtility;

namespace Scada.Database
{
	/// <summary>
	/// 数据访问类:DeviceGroup
	/// </summary>
	public partial class DeviceGroup
	{
		public DeviceGroup()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("Id", "DeviceGroup"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DeviceGroup");
			strSql.Append(" where Id="+Id+" ");
			return DbHelperSQLite.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Scada.Model.DeviceGroup model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.GroupId != null)
			{
				strSql1.Append("GroupId,");
				strSql2.Append(""+model.GroupId+",");
			}
			if (model.IO_SERVER_ID != null)
			{
				strSql1.Append("IO_SERVER_ID,");
				strSql2.Append(""+model.IO_SERVER_ID+",");
			}
			if (model.IO_COMM_ID != null)
			{
				strSql1.Append("IO_COMM_ID,");
				strSql2.Append(""+model.IO_COMM_ID+",");
			}
			if (model.IO_DEVICE_ID != null)
			{
				strSql1.Append("IO_DEVICE_ID,");
				strSql2.Append(""+model.IO_DEVICE_ID+",");
			}
			strSql.Append("insert into DeviceGroup(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";select LAST_INSERT_ROWID()");
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Scada.Model.DeviceGroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DeviceGroup set ");
			if (model.GroupId != null)
			{
				strSql.Append("GroupId="+model.GroupId+",");
			}
			else
			{
				strSql.Append("GroupId= null ,");
			}
			if (model.IO_SERVER_ID != null)
			{
				strSql.Append("IO_SERVER_ID="+model.IO_SERVER_ID+",");
			}
			else
			{
				strSql.Append("IO_SERVER_ID= null ,");
			}
			if (model.IO_COMM_ID != null)
			{
				strSql.Append("IO_COMM_ID="+model.IO_COMM_ID+",");
			}
			else
			{
				strSql.Append("IO_COMM_ID= null ,");
			}
			if (model.IO_DEVICE_ID != null)
			{
				strSql.Append("IO_DEVICE_ID="+model.IO_DEVICE_ID+",");
			}
			else
			{
				strSql.Append("IO_DEVICE_ID= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where Id="+ model.Id+"");
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
		public bool Delete(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DeviceGroup ");
			strSql.Append(" where Id="+Id+"" );
			int rowsAffected=DbHelperSQLite.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DeviceGroup ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
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
		public Scada.Model.DeviceGroup GetModel(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" Id,GroupId,IO_SERVER_ID,IO_COMM_ID,IO_DEVICE_ID ");
			strSql.Append(" from DeviceGroup ");
			strSql.Append(" where Id="+Id+"" );
			Scada.Model.DeviceGroup model=new Scada.Model.DeviceGroup();
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
		public Scada.Model.DeviceGroup DataRowToModel(DataRow row)
		{
			Scada.Model.DeviceGroup model=new Scada.Model.DeviceGroup();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["GroupId"]!=null && row["GroupId"].ToString()!="")
				{
					model.GroupId=int.Parse(row["GroupId"].ToString());
				}
				if(row["IO_SERVER_ID"]!=null && row["IO_SERVER_ID"].ToString()!="")
				{
					model.IO_SERVER_ID=int.Parse(row["IO_SERVER_ID"].ToString());
				}
				if(row["IO_COMM_ID"]!=null && row["IO_COMM_ID"].ToString()!="")
				{
					model.IO_COMM_ID=int.Parse(row["IO_COMM_ID"].ToString());
				}
				if(row["IO_DEVICE_ID"]!=null && row["IO_DEVICE_ID"].ToString()!="")
				{
					model.IO_DEVICE_ID=int.Parse(row["IO_DEVICE_ID"].ToString());
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
			strSql.Append("select Id,GroupId,IO_SERVER_ID,IO_COMM_ID,IO_DEVICE_ID ");
			strSql.Append(" FROM DeviceGroup ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM DeviceGroup ");
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
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from DeviceGroup T ");
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

