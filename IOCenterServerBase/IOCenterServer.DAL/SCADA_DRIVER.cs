using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Scada.DBUtility;

namespace Scada.Database
{
	/// <summary>
	/// 数据访问类:SCADA_DRIVER
	/// </summary>
	public partial class SCADA_DRIVER
	{
		public SCADA_DRIVER()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SCADA_DRIVER");
			strSql.Append(" where Id=@Id ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@Id", DbType.String)			};
			parameters[0].Value = Id;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Scada.Model.SCADA_DRIVER model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SCADA_DRIVER(");
			strSql.Append("Id,CreateTime,UpdateTime,CommunicationFullName,CommunicationName,DeviceName,Title,Description,Namespace,Anthor,Company,DeviceFullName,Version,FillName,GUID,ClassifyId,IsSystem)");
			strSql.Append(" values (");
			strSql.Append("@Id,@CreateTime,@UpdateTime,@CommunicationFullName,@CommunicationName,@DeviceName,@Title,@Description,@Namespace,@Anthor,@Company,@DeviceFullName,@Version,@FillName,@GUID,@ClassifyId,@IsSystem)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@Id", DbType.String),
					new SQLiteParameter("@CreateTime", DbType.String),
					new SQLiteParameter("@UpdateTime", DbType.String),
					new SQLiteParameter("@CommunicationFullName", DbType.String),
					new SQLiteParameter("@CommunicationName", DbType.String),
					new SQLiteParameter("@DeviceName", DbType.String),
					new SQLiteParameter("@Title", DbType.String),
					new SQLiteParameter("@Description", DbType.String),
					new SQLiteParameter("@Namespace", DbType.String),
					new SQLiteParameter("@Anthor", DbType.String),
					new SQLiteParameter("@Company", DbType.String),
					new SQLiteParameter("@DeviceFullName", DbType.String),
					new SQLiteParameter("@Version", DbType.String),
					new SQLiteParameter("@FillName", DbType.String),
					new SQLiteParameter("@GUID", DbType.String),
                     new SQLiteParameter("@ClassifyId", DbType.Int32,4),
                        new SQLiteParameter("@IsSystem", DbType.Int32,4)
            };
			parameters[0].Value = model.Id;
			parameters[1].Value = model.CreateTime;
			parameters[2].Value = model.UpdateTime;
			parameters[3].Value = model.CommunicationFullName;
			parameters[4].Value = model.CommunicationName;
			parameters[5].Value = model.DeviceName;
			parameters[6].Value = model.Title;
			parameters[7].Value = model.Description;
			parameters[8].Value = model.Namespace;
			parameters[9].Value = model.Anthor;
			parameters[10].Value = model.Company;
			parameters[11].Value = model.DeviceFullName;
			parameters[12].Value = model.Version;
			parameters[13].Value = model.FillName;
			parameters[14].Value = model.GUID;
            parameters[15].Value = model.ClassifyId;
            parameters[16].Value = model.IsSystem;
            
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Scada.Model.SCADA_DRIVER model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SCADA_DRIVER set ");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateTime=@UpdateTime,");
			strSql.Append("CommunicationFullName=@CommunicationFullName,");
			strSql.Append("CommunicationName=@CommunicationName,");
			strSql.Append("DeviceName=@DeviceName,");
			strSql.Append("Title=@Title,");
			strSql.Append("Description=@Description,");
			strSql.Append("Namespace=@Namespace,");
			strSql.Append("Anthor=@Anthor,");
			strSql.Append("Company=@Company,");
			strSql.Append("DeviceFullName=@DeviceFullName,");
			strSql.Append("Version=@Version,");
			strSql.Append("FillName=@FillName,");
            strSql.Append("ClassifyId=@ClassifyId,");
            strSql.Append("IsSystem=@IsSystem,");
            
            strSql.Append("GUID=@GUID");
			strSql.Append(" where Id=@Id ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@CreateTime", DbType.String),
					new SQLiteParameter("@UpdateTime", DbType.String),
					new SQLiteParameter("@CommunicationFullName", DbType.String),
					new SQLiteParameter("@CommunicationName", DbType.String),
					new SQLiteParameter("@DeviceName", DbType.String),
					new SQLiteParameter("@Title", DbType.String),
					new SQLiteParameter("@Description", DbType.String),
					new SQLiteParameter("@Namespace", DbType.String),
					new SQLiteParameter("@Anthor", DbType.String),
					new SQLiteParameter("@Company", DbType.String),
					new SQLiteParameter("@DeviceFullName", DbType.String),
					new SQLiteParameter("@Version", DbType.String),
					new SQLiteParameter("@FillName", DbType.String),
					new SQLiteParameter("@GUID", DbType.String),
					new SQLiteParameter("@Id", DbType.String),
                    new SQLiteParameter("@ClassifyId", DbType.Int32,4),
                           new SQLiteParameter("@IsSystem", DbType.Int32,4)
                    
            };
			parameters[0].Value = model.CreateTime;
			parameters[1].Value = model.UpdateTime;
			parameters[2].Value = model.CommunicationFullName;
			parameters[3].Value = model.CommunicationName;
			parameters[4].Value = model.DeviceName;
			parameters[5].Value = model.Title;
			parameters[6].Value = model.Description;
			parameters[7].Value = model.Namespace;
			parameters[8].Value = model.Anthor;
			parameters[9].Value = model.Company;
			parameters[10].Value = model.DeviceFullName;
			parameters[11].Value = model.Version;
			parameters[12].Value = model.FillName;
			parameters[13].Value = model.GUID;
			parameters[14].Value = model.Id;
            parameters[15].Value = model.ClassifyId;
            parameters[16].Value = model.IsSystem;
            

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
		public bool Delete(string Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SCADA_DRIVER ");
			strSql.Append(" where Id=@Id ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@Id", DbType.String)			};
			parameters[0].Value = Id;

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
			strSql.Append("delete from SCADA_DRIVER ");
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
		public Scada.Model.SCADA_DRIVER GetModel(string Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select IsSystem,ClassifyId,Id,CreateTime,UpdateTime,CommunicationFullName,CommunicationName,DeviceName,Title,Description,Namespace,Anthor,Company,DeviceFullName,Version,FillName,GUID from SCADA_DRIVER ");
			strSql.Append(" where Id=@Id ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@Id", DbType.String)			};
			parameters[0].Value = Id;

			Scada.Model.SCADA_DRIVER model=new Scada.Model.SCADA_DRIVER();
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
		public Scada.Model.SCADA_DRIVER DataRowToModel(DataRow row)
		{
			Scada.Model.SCADA_DRIVER model=new Scada.Model.SCADA_DRIVER();
			if (row != null)
			{
				if(row["Id"]!=null)
				{
					model.Id=row["Id"].ToString();
				}
				if(row["CreateTime"]!=null)
				{
					model.CreateTime=row["CreateTime"].ToString();
				}
				if(row["UpdateTime"]!=null)
				{
					model.UpdateTime=row["UpdateTime"].ToString();
				}
				if(row["CommunicationFullName"]!=null)
				{
					model.CommunicationFullName=row["CommunicationFullName"].ToString();
				}
				if(row["CommunicationName"]!=null)
				{
					model.CommunicationName=row["CommunicationName"].ToString();
				}
				if(row["DeviceName"]!=null)
				{
					model.DeviceName=row["DeviceName"].ToString();
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["Namespace"]!=null)
				{
					model.Namespace=row["Namespace"].ToString();
				}
				if(row["Anthor"]!=null)
				{
					model.Anthor=row["Anthor"].ToString();
				}
				if(row["Company"]!=null)
				{
					model.Company=row["Company"].ToString();
				}
				if(row["DeviceFullName"]!=null)
				{
					model.DeviceFullName=row["DeviceFullName"].ToString();
				}
				if(row["Version"]!=null)
				{
					model.Version=row["Version"].ToString();
				}
				if(row["FillName"]!=null)
				{
					model.FillName=row["FillName"].ToString();
				}
				if(row["GUID"]!=null)
				{
					model.GUID=row["GUID"].ToString();
				}

                if (row["ClassifyId"] != null)
                {
                    model.ClassifyId =int.Parse( row["ClassifyId"].ToString());
                }
                if (row["IsSystem"] != null)
                {
                    model.IsSystem = int.Parse(row["IsSystem"].ToString());
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
			strSql.Append("select  IsSystem,ClassifyId, Id,CreateTime,UpdateTime,CommunicationFullName,CommunicationName,DeviceName,Title,Description,Namespace,Anthor,Company,DeviceFullName,Version,FillName,GUID ");
			strSql.Append(" FROM SCADA_DRIVER ");
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
			strSql.Append("select count(1) FROM SCADA_DRIVER ");
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
			strSql.Append(")AS Row, T.*  from SCADA_DRIVER T ");
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
			parameters[0].Value = "SCADA_DRIVER";
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

