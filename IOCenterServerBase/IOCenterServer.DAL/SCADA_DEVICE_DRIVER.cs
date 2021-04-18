using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
 
using Scada.DBUtility;

namespace Scada.Database
{
	/// <summary>
	/// 数据访问类:SCADA_DEVICE_DRIVER
	/// </summary>
	public partial class SCADA_DEVICE_DRIVER
	{
		public SCADA_DEVICE_DRIVER()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SCADA_DEVICE_DRIVER");
			strSql.Append(" where Id=@Id ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@Id", DbType.String)			};
			parameters[0].Value = Id;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Scada.Model.SCADA_DEVICE_DRIVER model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SCADA_DEVICE_DRIVER(");
			strSql.Append("Id,DeviceName,Title,Namespace,DeviceFullName,FillName,Dll_GUID,Dll_Name,Dll_Title)");
			strSql.Append(" values (");
			strSql.Append("@Id,@DeviceName,@Title,@Namespace,@DeviceFullName,@FillName,@Dll_GUID,@Dll_Name,@Dll_Title)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@Id", DbType.String),
					new SQLiteParameter("@DeviceName", DbType.String),
					new SQLiteParameter("@Title", DbType.String),
					new SQLiteParameter("@Namespace", DbType.String),
					new SQLiteParameter("@DeviceFullName", DbType.String),
					new SQLiteParameter("@FillName", DbType.String),
					new SQLiteParameter("@Dll_GUID", DbType.String),
					new SQLiteParameter("@Dll_Name", DbType.String),
					new SQLiteParameter("@Dll_Title", DbType.String)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.DeviceName;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.Namespace;
			parameters[4].Value = model.DeviceFullName;
			parameters[5].Value = model.FillName;
			parameters[6].Value = model.Dll_GUID;
			parameters[7].Value = model.Dll_Name;
			parameters[8].Value = model.Dll_Title;

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
		public bool Update(Scada.Model.SCADA_DEVICE_DRIVER model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SCADA_DEVICE_DRIVER set ");
			strSql.Append("DeviceName=@DeviceName,");
			strSql.Append("Title=@Title,");
			strSql.Append("Namespace=@Namespace,");
			strSql.Append("DeviceFullName=@DeviceFullName,");
			strSql.Append("FillName=@FillName,");
			strSql.Append("Dll_GUID=@Dll_GUID,");
			strSql.Append("Dll_Name=@Dll_Name,");
			strSql.Append("Dll_Title=@Dll_Title");
			strSql.Append(" where Id=@Id ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@DeviceName", DbType.String),
					new SQLiteParameter("@Title", DbType.String),
					new SQLiteParameter("@Namespace", DbType.String),
					new SQLiteParameter("@DeviceFullName", DbType.String),
					new SQLiteParameter("@FillName", DbType.String),
					new SQLiteParameter("@Dll_GUID", DbType.String),
					new SQLiteParameter("@Dll_Name", DbType.String),
					new SQLiteParameter("@Dll_Title", DbType.String),
					new SQLiteParameter("@Id", DbType.String)};
			parameters[0].Value = model.DeviceName;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Namespace;
			parameters[3].Value = model.DeviceFullName;
			parameters[4].Value = model.FillName;
			parameters[5].Value = model.Dll_GUID;
			parameters[6].Value = model.Dll_Name;
			parameters[7].Value = model.Dll_Title;
			parameters[8].Value = model.Id;

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
			strSql.Append("delete from SCADA_DEVICE_DRIVER ");
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
			strSql.Append("delete from SCADA_DEVICE_DRIVER ");
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
		public Scada.Model.SCADA_DEVICE_DRIVER GetModel(string Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,DeviceName,Title,Namespace,DeviceFullName,FillName,Dll_GUID,Dll_Name,Dll_Title from SCADA_DEVICE_DRIVER ");
			strSql.Append(" where Id=@Id ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@Id", DbType.String)			};
			parameters[0].Value = Id;

			Scada.Model.SCADA_DEVICE_DRIVER model=new Scada.Model.SCADA_DEVICE_DRIVER();
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
		public Scada.Model.SCADA_DEVICE_DRIVER DataRowToModel(DataRow row)
		{
			Scada.Model.SCADA_DEVICE_DRIVER model=new Scada.Model.SCADA_DEVICE_DRIVER();
			if (row != null)
			{
				if(row["Id"]!=null)
				{
					model.Id=row["Id"].ToString();
				}
				if(row["DeviceName"]!=null)
				{
					model.DeviceName=row["DeviceName"].ToString();
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Namespace"]!=null)
				{
					model.Namespace=row["Namespace"].ToString();
				}
				if(row["DeviceFullName"]!=null)
				{
					model.DeviceFullName=row["DeviceFullName"].ToString();
				}
				if(row["FillName"]!=null)
				{
					model.FillName=row["FillName"].ToString();
				}
				if(row["Dll_GUID"]!=null)
				{
					model.Dll_GUID=row["Dll_GUID"].ToString();
				}
				if(row["Dll_Name"]!=null)
				{
					model.Dll_Name=row["Dll_Name"].ToString();
				}
				if(row["Dll_Title"]!=null)
				{
					model.Dll_Title=row["Dll_Title"].ToString();
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
			strSql.Append("select Id,DeviceName,Title,Namespace,DeviceFullName,FillName,Dll_GUID,Dll_Name,Dll_Title ");
			strSql.Append(" FROM SCADA_DEVICE_DRIVER ");
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
			strSql.Append("select count(1) FROM SCADA_DEVICE_DRIVER ");
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
			strSql.Append(")AS Row, T.*  from SCADA_DEVICE_DRIVER T ");
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
			parameters[0].Value = "SCADA_DEVICE_DRIVER";
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

