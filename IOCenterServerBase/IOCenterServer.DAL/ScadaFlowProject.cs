using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Scada.DBUtility;//Please add references
namespace Scada.Database
{
	/// <summary>
	/// 数据访问类:ScadaFlowProject
	/// </summary>
	public partial class ScadaFlowProject
	{
		public ScadaFlowProject()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("id", "ScadaFlowProject"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProjectId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ScadaFlowProject");
			strSql.Append(" where ProjectId=@ProjectId");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ProjectId", DbType.String)
			};
			parameters[0].Value = ProjectId;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Scada.Model.ScadaFlowProject model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ScadaFlowProject(");
			strSql.Append("Title,Desc,CreateDate,ProjectId,ServerID,FlowUser)");
			strSql.Append(" values (");
			strSql.Append("@Title,@Desc,@CreateDate,@ProjectId,@ServerID,@FlowUser)");
			strSql.Append(";select LAST_INSERT_ROWID()");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@Title", DbType.String),
					new SQLiteParameter("@Desc", DbType.String),
					new SQLiteParameter("@CreateDate", DbType.String),
					new SQLiteParameter("@ProjectId", DbType.String),
					new SQLiteParameter("@ServerID", DbType.String),
            new SQLiteParameter("@FlowUser", DbType.String)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Desc;
			parameters[2].Value = model.CreateDate;
			parameters[3].Value = model.ProjectId;
			parameters[4].Value = model.ServerID;
            parameters[5].Value = model.FlowUser;
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
		public bool Update(Scada.Model.ScadaFlowProject model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ScadaFlowProject set ");
			strSql.Append("Title=@Title,");
			strSql.Append("Desc=@Desc,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("ProjectId=@ProjectId,");
            strSql.Append("FlowUser=@FlowUser,");
            strSql.Append("ServerID=@ServerID");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@Title", DbType.String),
					new SQLiteParameter("@Desc", DbType.String),
					new SQLiteParameter("@CreateDate", DbType.String),
					new SQLiteParameter("@ProjectId", DbType.String),
					new SQLiteParameter("@ServerID", DbType.String),
					new SQLiteParameter("@id", DbType.Int32,8),
                new SQLiteParameter("@FlowUser", DbType.String)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Desc;
			parameters[2].Value = model.CreateDate;
			parameters[3].Value = model.ProjectId;
			parameters[4].Value = model.ServerID;
			parameters[5].Value = model.id;
            parameters[6].Value = model.FlowUser;
            


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
        public bool UpdateFromProjectId(Scada.Model.ScadaFlowProject model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ScadaFlowProject set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Desc=@Desc,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("FlowUser=@FlowUser,");

            
            strSql.Append("ServerID=@ServerID");
            strSql.Append(" where ProjectId=@ProjectId");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Title", DbType.String),
                    new SQLiteParameter("@Desc", DbType.String),
                    new SQLiteParameter("@CreateDate", DbType.String),
                    new SQLiteParameter("@ProjectId", DbType.String),
                    new SQLiteParameter("@ServerID", DbType.String),
                    new SQLiteParameter("@FlowUser", DbType.String)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Desc;
            parameters[2].Value = model.CreateDate;
            parameters[3].Value = model.ProjectId;
            parameters[4].Value = model.ServerID;
            parameters[5].Value = model.FlowUser;
            
            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ScadaFlowProject ");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

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
        public bool DeleteFromProjectId(int ProjectId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ScadaFlowProject ");
            strSql.Append(" where ProjectId=@ProjectId");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@ProjectId", DbType.String)
            };
            parameters[0].Value = ProjectId;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ScadaFlowProject ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public Scada.Model.ScadaFlowProject GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,Title,Desc,CreateDate,ProjectId,ServerID,FlowUser from ScadaFlowProject ");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

			Scada.Model.ScadaFlowProject model=new Scada.Model.ScadaFlowProject();
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
        public Scada.Model.ScadaFlowProject GetModelFromProjectId(int ProjectId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,Title,Desc,CreateDate,ProjectId,ServerID,FlowUser from ScadaFlowProject ");
            strSql.Append(" where ProjectId=@ProjectId");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@ProjectId", DbType.String)
            };
            parameters[0].Value = ProjectId;

            Scada.Model.ScadaFlowProject model = new Scada.Model.ScadaFlowProject();
            DataSet ds = DbHelperSQLite.Query(strSql.ToString(), parameters);
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
        public Scada.Model.ScadaFlowProject DataRowToModel(DataRow row)
		{
			Scada.Model.ScadaFlowProject model=new Scada.Model.ScadaFlowProject();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Desc"]!=null)
				{
					model.Desc=row["Desc"].ToString();
				}
				if(row["CreateDate"]!=null)
				{
					model.CreateDate=row["CreateDate"].ToString();
				}
				if(row["ProjectId"]!=null && row["ProjectId"].ToString()!="")
				{
					model.ProjectId=row["ProjectId"].ToString();
				}
				if(row["ServerID"]!=null)
				{
					model.ServerID=row["ServerID"].ToString();
				}
                if (row["FlowUser"] != null)
                {
                    model.FlowUser = row["FlowUser"].ToString();
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
			strSql.Append("select id,Title,Desc,CreateDate,ProjectId,ServerID,FlowUser");
			strSql.Append(" FROM ScadaFlowProject ");
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
			strSql.Append("select count(1) FROM ScadaFlowProject ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from ScadaFlowProject T ");
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
			parameters[0].Value = "ScadaFlowProject";
			parameters[1].Value = "id";
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

