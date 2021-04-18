using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Scada.DBUtility;//Please add references
namespace Scada.Database
{
	/// <summary>
	/// 数据访问类:ScadaFlowView
	/// </summary>
	public partial class ScadaFlowView
	{
		public ScadaFlowView()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("Id", "ScadaFlowView"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ScadaFlowView");
			strSql.Append(" where Id=@Id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@Id", DbType.Int32,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Scada.Model.ScadaFlowView model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ScadaFlowView(");
			strSql.Append("ViewId,ViewTitle,ProjectId,IsIndex,ViewSVG)");
			strSql.Append(" values (");
			strSql.Append("@ViewId,@ViewTitle,@ProjectId,@IsIndex,@ViewSVG)");
			strSql.Append(";select LAST_INSERT_ROWID()");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ViewId", DbType.String),
					new SQLiteParameter("@ViewTitle", DbType.String),
					new SQLiteParameter("@ProjectId", DbType.String),
					new SQLiteParameter("@IsIndex", DbType.String),
					new SQLiteParameter("@ViewSVG", DbType.String)};
			parameters[0].Value = model.ViewId;
			parameters[1].Value = model.ViewTitle;
			parameters[2].Value = model.ProjectId.Trim();
			parameters[3].Value = model.IsIndex;
			parameters[4].Value = model.ViewSVG;

			object obj = DbHelperSQLite.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(Scada.Model.ScadaFlowView model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ScadaFlowView set ");
			strSql.Append("ViewId=@ViewId,");
			strSql.Append("ViewTitle=@ViewTitle,");
			strSql.Append("ProjectId=@ProjectId,");
			strSql.Append("IsIndex=@IsIndex,");
			strSql.Append("ViewSVG=@ViewSVG");
			strSql.Append(" where Id=@Id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ViewId", DbType.String),
					new SQLiteParameter("@ViewTitle", DbType.String),
					new SQLiteParameter("@ProjectId", DbType.String),
					new SQLiteParameter("@IsIndex", DbType.String),
					new SQLiteParameter("@ViewSVG", DbType.String),
					new SQLiteParameter("@Id", DbType.Int32,8)};
			parameters[0].Value = model.ViewId;
			parameters[1].Value = model.ViewTitle;
			parameters[2].Value = model.ProjectId.Trim();
			parameters[3].Value = model.IsIndex;
			parameters[4].Value = model.ViewSVG;
			parameters[5].Value = model.Id;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string  ProjectId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ScadaFlowView ");
			strSql.Append(" where ProjectId=@ProjectId");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ProjectId", DbType.String)
			};
			parameters[0].Value = ProjectId.Trim();

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ScadaFlowView ");
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
		public Scada.Model.ScadaFlowView GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,ViewId,ViewTitle,ProjectId,IsIndex,ViewSVG from ScadaFlowView ");
			strSql.Append(" where Id=@Id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@Id", DbType.Int32,4)
			};
			parameters[0].Value = Id;

			Scada.Model.ScadaFlowView model=new Scada.Model.ScadaFlowView();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
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
		public Scada.Model.ScadaFlowView DataRowToModel(DataRow row)
		{
			Scada.Model.ScadaFlowView model=new Scada.Model.ScadaFlowView();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["ViewId"]!=null)
				{
					model.ViewId=row["ViewId"].ToString();
				}
				if(row["ViewTitle"]!=null)
				{
					model.ViewTitle=row["ViewTitle"].ToString();
				}
				if(row["ProjectId"]!=null)
				{
					model.ProjectId=row["ProjectId"].ToString();
				}
				if(row["IsIndex"]!=null)
				{
					model.IsIndex=row["IsIndex"].ToString();
				}
				if(row["ViewSVG"]!=null)
				{
					model.ViewSVG=row["ViewSVG"].ToString();
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
			strSql.Append("select Id,ViewId,ViewTitle,ProjectId,IsIndex,ViewSVG ");
			strSql.Append(" FROM ScadaFlowView ");
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
			strSql.Append("select count(1) FROM ScadaFlowView ");
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
			strSql.Append(")AS Row, T.*  from ScadaFlowView T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tblName", DbType.VarChar, 255),
					new SQLiteParameter("@fldName", DbType.VarChar, 255),
					new SQLiteParameter("@PageSize", DbType.Int32),
					new SQLiteParameter("@PageIndex", DbType.Int32),
					new SQLiteParameter("@IsReCount", DbType.bit),
					new SQLiteParameter("@OrderType", DbType.bit),
					new SQLiteParameter("@strWhere", DbType.VarChar,1000),
					};
			parameters[0].Value = "ScadaFlowView";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQLite.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

