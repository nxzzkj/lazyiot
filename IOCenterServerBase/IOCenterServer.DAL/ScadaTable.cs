using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Scada.DBUtility;

namespace Scada.Database
{
	/// <summary>
	/// 数据访问类:ScadaTable
	/// </summary>
	public partial class ScadaTable
	{
		public ScadaTable()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("Id", "ScadaTable"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ScadaTable");
			strSql.Append(" where Id="+Id+" ");
			return DbHelperSQLite.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Scada.Model.ScadaTable model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.Title != null)
			{
				strSql1.Append("Title,");
				strSql2.Append("'"+model.Title+"',");
			}
			if (model.RoleUser != null)
			{
				strSql1.Append("RoleUser,");
				strSql2.Append("'"+model.RoleUser+"',");
			}
			if (model.FilterRule != null)
			{
				strSql1.Append("FilterRule,");
				strSql2.Append(""+model.FilterRule+",");
			}
			if (model.CreateTime != null)
			{
				strSql1.Append("CreateTime,");
				strSql2.Append("'"+model.CreateTime+"',");
			}
			if (model.CreateUserId != null)
			{
				strSql1.Append("CreateUserId,");
				strSql2.Append(""+model.CreateUserId+",");
			}
			if (model.UpdateTime != null)
			{
				strSql1.Append("UpdateTime,");
				strSql2.Append("'"+model.UpdateTime+"',");
			}
			if (model.UpdateUserId != null)
			{
				strSql1.Append("UpdateUserId,");
				strSql2.Append(""+model.UpdateUserId+",");
			}
			if (model.SortCode != null)
			{
				strSql1.Append("SortCode,");
				strSql2.Append(""+model.SortCode+",");
			}
			strSql.Append("insert into ScadaTable(");
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
		public bool Update(Scada.Model.ScadaTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ScadaTable set ");
			if (model.Title != null)
			{
				strSql.Append("Title='"+model.Title+"',");
			}
			else
			{
				strSql.Append("Title= null ,");
			}
			if (model.RoleUser != null)
			{
				strSql.Append("RoleUser='"+model.RoleUser+"',");
			}
			else
			{
				strSql.Append("RoleUser= null ,");
			}
			if (model.FilterRule != null)
			{
				strSql.Append("FilterRule="+model.FilterRule+",");
			}
			else
			{
				strSql.Append("FilterRule= null ,");
			}
			if (model.CreateTime != null)
			{
				strSql.Append("CreateTime='"+model.CreateTime+"',");
			}
			else
			{
				strSql.Append("CreateTime= null ,");
			}
			if (model.CreateUserId != null)
			{
				strSql.Append("CreateUserId="+model.CreateUserId+",");
			}
			else
			{
				strSql.Append("CreateUserId= null ,");
			}
			if (model.UpdateTime != null)
			{
				strSql.Append("UpdateTime='"+model.UpdateTime+"',");
			}
			else
			{
				strSql.Append("UpdateTime= null ,");
			}
			if (model.UpdateUserId != null)
			{
				strSql.Append("UpdateUserId="+model.UpdateUserId+",");
			}
			else
			{
				strSql.Append("UpdateUserId= null ,");
			}
			if (model.SortCode != null)
			{
				strSql.Append("SortCode="+model.SortCode+",");
			}
			else
			{
				strSql.Append("SortCode= null ,");
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
			strSql.Append("delete from ScadaTable ");
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
			strSql.Append("delete from ScadaTable ");
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
		public Scada.Model.ScadaTable GetModel(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" Id,Title,RoleUser,FilterRule,CreateTime,CreateUserId,UpdateTime,UpdateUserId,SortCode ");
			strSql.Append(" from ScadaTable ");
			strSql.Append(" where Id="+Id+"" );
			Scada.Model.ScadaTable model=new Scada.Model.ScadaTable();
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
		public Scada.Model.ScadaTable DataRowToModel(DataRow row)
		{
			Scada.Model.ScadaTable model=new Scada.Model.ScadaTable();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["RoleUser"]!=null)
				{
					model.RoleUser=row["RoleUser"].ToString();
				}
				if(row["FilterRule"]!=null && row["FilterRule"].ToString()!="")
				{
					model.FilterRule=int.Parse(row["FilterRule"].ToString());
				}
				if(row["CreateTime"]!=null)
				{
					model.CreateTime=row["CreateTime"].ToString();
				}
				if(row["CreateUserId"]!=null && row["CreateUserId"].ToString()!="")
				{
					model.CreateUserId=int.Parse(row["CreateUserId"].ToString());
				}
				if(row["UpdateTime"]!=null)
				{
					model.UpdateTime=row["UpdateTime"].ToString();
				}
				if(row["UpdateUserId"]!=null && row["UpdateUserId"].ToString()!="")
				{
					model.UpdateUserId=int.Parse(row["UpdateUserId"].ToString());
				}
				if(row["SortCode"]!=null && row["SortCode"].ToString()!="")
				{
					model.SortCode=int.Parse(row["SortCode"].ToString());
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
			strSql.Append("select Id,Title,RoleUser,FilterRule,CreateTime,CreateUserId,UpdateTime,UpdateUserId,SortCode ");
			strSql.Append(" FROM ScadaTable ");
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
			strSql.Append("select count(1) FROM ScadaTable ");
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
			strSql.Append(")AS Row, T.*  from ScadaTable T ");
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

