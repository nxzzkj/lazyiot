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
	/// 数据访问类:IO_ALARM_CONFIG
	/// </summary>
	public partial class IO_ALARM_CONFIG
	{
		public IO_ALARM_CONFIG()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Scada.Model.IO_ALARM_CONFIG model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.IO_ID != null)
			{
				strSql1.Append("IO_ID,");
				strSql2.Append("'"+model.IO_ID+"',");
			}
			if (model.IO_ALARM_TYPE != null)
			{
				strSql1.Append("IO_ALARM_TYPE,");
				strSql2.Append("'"+model.IO_ALARM_TYPE+"',");
			}
			if (model.IO_ALARM_LEVEL != null)
			{
				strSql1.Append("IO_ALARM_LEVEL,");
				strSql2.Append("'"+model.IO_ALARM_LEVEL+"',");
			}
			if (model.IO_ENABLE_MAXMAX != null)
			{
				strSql1.Append("IO_ENABLE_MAXMAX,");
				strSql2.Append(""+model.IO_ENABLE_MAXMAX+",");
			}
			if (model.IO_MAXMAX_VALUE != null)
			{
				strSql1.Append("IO_MAXMAX_VALUE,");
				strSql2.Append(""+model.IO_MAXMAX_VALUE+",");
			}
			if (model.IO_ENABLE_MAX != null)
			{
				strSql1.Append("IO_ENABLE_MAX,");
				strSql2.Append(""+model.IO_ENABLE_MAX+",");
			}
			if (model.IO_MAX_VALUE != null)
			{
				strSql1.Append("IO_MAX_VALUE,");
				strSql2.Append(""+model.IO_MAX_VALUE+",");
			}
			if (model.IO_ENABLE_MIN != null)
			{
				strSql1.Append("IO_ENABLE_MIN,");
				strSql2.Append(""+model.IO_ENABLE_MIN+",");
			}
			if (model.IO_MIN_VALUE != null)
			{
				strSql1.Append("IO_MIN_VALUE,");
				strSql2.Append(""+model.IO_MIN_VALUE+",");
			}
			if (model.IO_ENABLE_MINMIN != null)
			{
				strSql1.Append("IO_ENABLE_MINMIN,");
				strSql2.Append(""+model.IO_ENABLE_MINMIN+",");
			}
			if (model.IO_MINMIN_VALUE != null)
			{
				strSql1.Append("IO_MINMIN_VALUE,");
				strSql2.Append(""+model.IO_MINMIN_VALUE+",");
			}
			if (model.IO_MAXMAX_TYPE != null)
			{
				strSql1.Append("IO_MAXMAX_TYPE,");
				strSql2.Append("'"+model.IO_MAXMAX_TYPE+"',");
			}
			if (model.IO_MAX_TYPE != null)
			{
				strSql1.Append("IO_MAX_TYPE,");
				strSql2.Append("'"+model.IO_MAX_TYPE+"',");
			}
			if (model.IO_MINMIN_TYPE != null)
			{
				strSql1.Append("IO_MINMIN_TYPE,");
				strSql2.Append("'"+model.IO_MINMIN_TYPE+"',");
			}
			if (model.IO_CONDITION != null)
			{
				strSql1.Append("IO_CONDITION,");
				strSql2.Append("'"+model.IO_CONDITION+"',");
			}
			if (model.IO_COMM_ID != null)
			{
				strSql1.Append("IO_COMM_ID,");
				strSql2.Append("'"+model.IO_COMM_ID+"',");
			}
			if (model.IO_DEVICE_ID != null)
			{
				strSql1.Append("IO_DEVICE_ID,");
				strSql2.Append("'"+model.IO_DEVICE_ID+"',");
			}
			if (model.IO_SERVER_ID != null)
			{
				strSql1.Append("IO_SERVER_ID,");
				strSql2.Append("'"+model.IO_SERVER_ID+"',");
			}
			 
				strSql1.Append("IO_ALARM_NUMBER,");
				strSql2.Append(""+model.IO_ALARM_NUMBER+",");
			 
			if (model.IO_MIN_TYPE != null)
			{
				strSql1.Append("IO_MIN_TYPE,");
				strSql2.Append("'"+model.IO_MIN_TYPE+"',");
			}
            if (model.UPDATE_DATE != null)
            {
                strSql1.Append("UPDATE_DATE,");
                strSql2.Append("'" + model.UPDATE_DATE + "',");
            }
            if (model.UPDATE_RESULT != null)
            {
                strSql1.Append("UPDATE_RESULT,");
                strSql2.Append("'" + model.UPDATE_RESULT + "',");
            }
            if (model.UPDATE_UID != null)
            {
                strSql1.Append("UPDATE_UID,");
                strSql2.Append("'" + model.UPDATE_UID + "',");
            }
            
                strSql1.Append("IO_ALARM_STATUS,");
                strSql2.Append("" + model.IO_ALARM_STATUS + ",");
            
          
            strSql.Append("insert into IO_ALARM_CONFIG(");
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
        public void Add(List<Scada.Model.IO_ALARM_CONFIG> models)
        {

               ArrayList sqlArray = new ArrayList();
            for(int i=0;i< models.Count;i++)
            {
                Scada.Model.IO_ALARM_CONFIG model = models[i];
                model.IO_ALARM_STATUS = 0;
                StringBuilder strSql = new StringBuilder();
                StringBuilder strSql1 = new StringBuilder();
                StringBuilder strSql2 = new StringBuilder();
                if (model.IO_ID != null)
                {
                    strSql1.Append("IO_ID,");
                    strSql2.Append("'" + model.IO_ID + "',");
                }
                if (model.IO_ALARM_TYPE != null)
                {
                    strSql1.Append("IO_ALARM_TYPE,");
                    strSql2.Append("'" + model.IO_ALARM_TYPE + "',");
                }
                if (model.IO_ALARM_LEVEL != null)
                {
                    strSql1.Append("IO_ALARM_LEVEL,");
                    strSql2.Append("'" + model.IO_ALARM_LEVEL + "',");
                }
                if (model.IO_ENABLE_MAXMAX != null)
                {
                    strSql1.Append("IO_ENABLE_MAXMAX,");
                    strSql2.Append("" + model.IO_ENABLE_MAXMAX + ",");
                }
                if (model.IO_MAXMAX_VALUE != null)
                {
                    strSql1.Append("IO_MAXMAX_VALUE,");
                    strSql2.Append("" + model.IO_MAXMAX_VALUE + ",");
                }
                if (model.IO_ENABLE_MAX != null)
                {
                    strSql1.Append("IO_ENABLE_MAX,");
                    strSql2.Append("" + model.IO_ENABLE_MAX + ",");
                }
                if (model.IO_MAX_VALUE != null)
                {
                    strSql1.Append("IO_MAX_VALUE,");
                    strSql2.Append("" + model.IO_MAX_VALUE + ",");
                }
                if (model.IO_ENABLE_MIN != null)
                {
                    strSql1.Append("IO_ENABLE_MIN,");
                    strSql2.Append("" + model.IO_ENABLE_MIN + ",");
                }
                if (model.IO_MIN_VALUE != null)
                {
                    strSql1.Append("IO_MIN_VALUE,");
                    strSql2.Append("" + model.IO_MIN_VALUE + ",");
                }
                if (model.IO_ENABLE_MINMIN != null)
                {
                    strSql1.Append("IO_ENABLE_MINMIN,");
                    strSql2.Append("" + model.IO_ENABLE_MINMIN + ",");
                }
                if (model.IO_MINMIN_VALUE != null)
                {
                    strSql1.Append("IO_MINMIN_VALUE,");
                    strSql2.Append("" + model.IO_MINMIN_VALUE + ",");
                }
                if (model.IO_MAXMAX_TYPE != null)
                {
                    strSql1.Append("IO_MAXMAX_TYPE,");
                    strSql2.Append("'" + model.IO_MAXMAX_TYPE + "',");
                }
                if (model.IO_MAX_TYPE != null)
                {
                    strSql1.Append("IO_MAX_TYPE,");
                    strSql2.Append("'" + model.IO_MAX_TYPE + "',");
                }
                if (model.IO_MINMIN_TYPE != null)
                {
                    strSql1.Append("IO_MINMIN_TYPE,");
                    strSql2.Append("'" + model.IO_MINMIN_TYPE + "',");
                }
                if (model.IO_CONDITION != null)
                {
                    strSql1.Append("IO_CONDITION,");
                    strSql2.Append("'" + model.IO_CONDITION + "',");
                }
                if (model.IO_COMM_ID != null)
                {
                    strSql1.Append("IO_COMM_ID,");
                    strSql2.Append("'" + model.IO_COMM_ID + "',");
                }
                if (model.IO_DEVICE_ID != null)
                {
                    strSql1.Append("IO_DEVICE_ID,");
                    strSql2.Append("'" + model.IO_DEVICE_ID + "',");
                }
                if (model.IO_SERVER_ID != null)
                {
                    strSql1.Append("IO_SERVER_ID,");
                    strSql2.Append("'" + model.IO_SERVER_ID + "',");
                }
              
                    strSql1.Append("IO_ALARM_NUMBER,");
                    strSql2.Append("" + model.IO_ALARM_NUMBER + ",");
               
                if (model.IO_MIN_TYPE != null)
                {
                    strSql1.Append("IO_MIN_TYPE,");
                    strSql2.Append("'" + model.IO_MIN_TYPE + "',");
                }
                if (model.UPDATE_DATE != null)
                {
                    strSql1.Append("UPDATE_DATE,");
                    strSql2.Append("'" + model.UPDATE_DATE + "',");
                }
                if (model.UPDATE_RESULT != null)
                {
                    strSql1.Append("UPDATE_RESULT,");
                    strSql2.Append("'" + model.UPDATE_RESULT + "',");
                }
                if (model.UPDATE_UID != null)
                {
                    strSql1.Append("UPDATE_UID,");
                    strSql2.Append("'" + model.UPDATE_UID + "',");
                }
              
                    strSql1.Append("IO_ALARM_STATUS,");
                    strSql2.Append("" + model.IO_ALARM_STATUS + ",");
                 
                
                strSql.Append("insert into IO_ALARM_CONFIG(");
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
        public StringBuilder GetInsertArray(Scada.Model.IO_ALARM_CONFIG model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.IO_ID != null)
            {
                strSql1.Append("IO_ID,");
                strSql2.Append("'" + model.IO_ID + "',");
            }
            if (model.IO_ALARM_TYPE != null)
            {
                strSql1.Append("IO_ALARM_TYPE,");
                strSql2.Append("'" + model.IO_ALARM_TYPE + "',");
            }
            if (model.IO_ALARM_LEVEL != null)
            {
                strSql1.Append("IO_ALARM_LEVEL,");
                strSql2.Append("'" + model.IO_ALARM_LEVEL + "',");
            }
            if (model.IO_ENABLE_MAXMAX != null)
            {
                strSql1.Append("IO_ENABLE_MAXMAX,");
                strSql2.Append("" + model.IO_ENABLE_MAXMAX + ",");
            }
            if (model.IO_MAXMAX_VALUE != null)
            {
                strSql1.Append("IO_MAXMAX_VALUE,");
                strSql2.Append("" + model.IO_MAXMAX_VALUE + ",");
            }
            if (model.IO_ENABLE_MAX != null)
            {
                strSql1.Append("IO_ENABLE_MAX,");
                strSql2.Append("" + model.IO_ENABLE_MAX + ",");
            }
            if (model.IO_MAX_VALUE != null)
            {
                strSql1.Append("IO_MAX_VALUE,");
                strSql2.Append("" + model.IO_MAX_VALUE + ",");
            }
            if (model.IO_ENABLE_MIN != null)
            {
                strSql1.Append("IO_ENABLE_MIN,");
                strSql2.Append("" + model.IO_ENABLE_MIN + ",");
            }
            if (model.IO_MIN_VALUE != null)
            {
                strSql1.Append("IO_MIN_VALUE,");
                strSql2.Append("" + model.IO_MIN_VALUE + ",");
            }
            if (model.IO_ENABLE_MINMIN != null)
            {
                strSql1.Append("IO_ENABLE_MINMIN,");
                strSql2.Append("" + model.IO_ENABLE_MINMIN + ",");
            }
            if (model.IO_MINMIN_VALUE != null)
            {
                strSql1.Append("IO_MINMIN_VALUE,");
                strSql2.Append("" + model.IO_MINMIN_VALUE + ",");
            }
            if (model.IO_MAXMAX_TYPE != null)
            {
                strSql1.Append("IO_MAXMAX_TYPE,");
                strSql2.Append("'" + model.IO_MAXMAX_TYPE + "',");
            }
            if (model.IO_MAX_TYPE != null)
            {
                strSql1.Append("IO_MAX_TYPE,");
                strSql2.Append("'" + model.IO_MAX_TYPE + "',");
            }
            if (model.IO_MINMIN_TYPE != null)
            {
                strSql1.Append("IO_MINMIN_TYPE,");
                strSql2.Append("'" + model.IO_MINMIN_TYPE + "',");
            }
            if (model.IO_CONDITION != null)
            {
                strSql1.Append("IO_CONDITION,");
                strSql2.Append("'" + model.IO_CONDITION + "',");
            }
            if (model.IO_COMM_ID != null)
            {
                strSql1.Append("IO_COMM_ID,");
                strSql2.Append("'" + model.IO_COMM_ID + "',");
            }
            if (model.IO_DEVICE_ID != null)
            {
                strSql1.Append("IO_DEVICE_ID,");
                strSql2.Append("'" + model.IO_DEVICE_ID + "',");
            }
            if (model.IO_SERVER_ID != null)
            {
                strSql1.Append("IO_SERVER_ID,");
                strSql2.Append("'" + model.IO_SERVER_ID + "',");
            }
            
                strSql1.Append("IO_ALARM_NUMBER,");
                strSql2.Append("" + model.IO_ALARM_NUMBER + ",");
             
            if (model.IO_MIN_TYPE != null)
            {
                strSql1.Append("IO_MIN_TYPE,");
                strSql2.Append("'" + model.IO_MIN_TYPE + "',");
            }
            if (model.UPDATE_DATE != null)
            {
                strSql1.Append("UPDATE_DATE,");
                strSql2.Append("'" + model.UPDATE_DATE + "',");
            }
            if (model.UPDATE_RESULT != null)
            {
                strSql1.Append("UPDATE_RESULT,");
                strSql2.Append("'" + model.UPDATE_RESULT + "',");
            }
            if (model.UPDATE_UID != null)
            {
                strSql1.Append("UPDATE_UID,");
                strSql2.Append("'" + model.UPDATE_UID + "',");
            }
             
                strSql1.Append("IO_ALARM_STATUS,");
                strSql2.Append("" + model.IO_ALARM_STATUS + ",");
             

            strSql.Append("insert into IO_ALARM_CONFIG(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Scada.Model.IO_ALARM_CONFIG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update IO_ALARM_CONFIG set ");
			if (model.IO_ID != null)
			{
				strSql.Append("IO_ID='"+model.IO_ID+"',");
			}
			if (model.IO_ALARM_TYPE != null)
			{
				strSql.Append("IO_ALARM_TYPE='"+model.IO_ALARM_TYPE+"',");
			}
			else
			{
				strSql.Append("IO_ALARM_TYPE= null ,");
			}
			if (model.IO_ALARM_LEVEL != null)
			{
				strSql.Append("IO_ALARM_LEVEL='"+model.IO_ALARM_LEVEL+"',");
			}
			else
			{
				strSql.Append("IO_ALARM_LEVEL= null ,");
			}
			if (model.IO_ENABLE_MAXMAX != null)
			{
				strSql.Append("IO_ENABLE_MAXMAX="+model.IO_ENABLE_MAXMAX+",");
			}
			else
			{
				strSql.Append("IO_ENABLE_MAXMAX= null ,");
			}
			if (model.IO_MAXMAX_VALUE != null)
			{
				strSql.Append("IO_MAXMAX_VALUE="+model.IO_MAXMAX_VALUE+",");
			}
			else
			{
				strSql.Append("IO_MAXMAX_VALUE= null ,");
			}
			if (model.IO_ENABLE_MAX != null)
			{
				strSql.Append("IO_ENABLE_MAX="+model.IO_ENABLE_MAX+",");
			}
			else
			{
				strSql.Append("IO_ENABLE_MAX= null ,");
			}
			if (model.IO_MAX_VALUE != null)
			{
				strSql.Append("IO_MAX_VALUE="+model.IO_MAX_VALUE+",");
			}
			else
			{
				strSql.Append("IO_MAX_VALUE= null ,");
			}
			if (model.IO_ENABLE_MIN != null)
			{
				strSql.Append("IO_ENABLE_MIN="+model.IO_ENABLE_MIN+",");
			}
			else
			{
				strSql.Append("IO_ENABLE_MIN= null ,");
			}
			if (model.IO_MIN_VALUE != null)
			{
				strSql.Append("IO_MIN_VALUE="+model.IO_MIN_VALUE+",");
			}
			else
			{
				strSql.Append("IO_MIN_VALUE= null ,");
			}
			if (model.IO_ENABLE_MINMIN != null)
			{
				strSql.Append("IO_ENABLE_MINMIN="+model.IO_ENABLE_MINMIN+",");
			}
			else
			{
				strSql.Append("IO_ENABLE_MINMIN= null ,");
			}
			if (model.IO_MINMIN_VALUE != null)
			{
				strSql.Append("IO_MINMIN_VALUE="+model.IO_MINMIN_VALUE+",");
			}
			else
			{
				strSql.Append("IO_MINMIN_VALUE= null ,");
			}
			if (model.IO_MAXMAX_TYPE != null)
			{
				strSql.Append("IO_MAXMAX_TYPE='"+model.IO_MAXMAX_TYPE+"',");
			}
			else
			{
				strSql.Append("IO_MAXMAX_TYPE= null ,");
			}
			if (model.IO_MAX_TYPE != null)
			{
				strSql.Append("IO_MAX_TYPE='"+model.IO_MAX_TYPE+"',");
			}
			else
			{
				strSql.Append("IO_MAX_TYPE= null ,");
			}
			if (model.IO_MINMIN_TYPE != null)
			{
				strSql.Append("IO_MINMIN_TYPE='"+model.IO_MINMIN_TYPE+"',");
			}
			else
			{
				strSql.Append("IO_MINMIN_TYPE= null ,");
			}
			if (model.IO_CONDITION != null)
			{
				strSql.Append("IO_CONDITION='"+model.IO_CONDITION+"',");
			}
			else
			{
				strSql.Append("IO_CONDITION= null ,");
			}
			if (model.IO_COMM_ID != null)
			{
				strSql.Append("IO_COMM_ID='"+model.IO_COMM_ID+"',");
			}
			if (model.IO_DEVICE_ID != null)
			{
				strSql.Append("IO_DEVICE_ID='"+model.IO_DEVICE_ID+"',");
			}
			if (model.IO_SERVER_ID != null)
			{
				strSql.Append("IO_SERVER_ID='"+model.IO_SERVER_ID+"',");
			}
			 
				strSql.Append("IO_ALARM_NUMBER="+model.IO_ALARM_NUMBER+",");
			 
			if (model.IO_MIN_TYPE != null)
			{
				strSql.Append("IO_MIN_TYPE='"+model.IO_MIN_TYPE+"',");
			}
			else
			{
				strSql.Append("IO_MIN_TYPE= null ,");
			}

            if (model.UPDATE_DATE != null)
            {
                strSql.Append("UPDATE_DATE='" + model.UPDATE_DATE + "',");
            }
            else
            {
                strSql.Append("UPDATE_DATE= null ,");
            }

            if (model.UPDATE_RESULT != null)
            {
                strSql.Append("UPDATE_RESULT='" + model.UPDATE_RESULT + "',");
            }
            else
            {
                strSql.Append("UPDATE_RESULT= null ,");
            }
            if (model.UPDATE_UID != null)
            {
                strSql.Append("UPDATE_UID='" + model.UPDATE_UID + "',");
            }
            else
            {
                strSql.Append("UPDATE_UID= null ,");
            }
            
                strSql.Append("IO_ALARM_STATUS=" + model.IO_ALARM_STATUS + ",");
        
            
            int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where IO_ID='"+model.IO_ID+"'");
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
        public bool UserResultUpdate(Scada.Model.IO_ALARM_CONFIG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update IO_ALARM_CONFIG set ");
            if (model.IO_ID != null)
            {
                strSql.Append("IO_ID='" + model.IO_ID + "',");
            }
            if (model.IO_ALARM_TYPE != null)
            {
                strSql.Append("IO_ALARM_TYPE='" + model.IO_ALARM_TYPE + "',");
            }
            else
            {
                strSql.Append("IO_ALARM_TYPE= null ,");
            }
            if (model.IO_ALARM_LEVEL != null)
            {
                strSql.Append("IO_ALARM_LEVEL='" + model.IO_ALARM_LEVEL + "',");
            }
            else
            {
                strSql.Append("IO_ALARM_LEVEL= null ,");
            }
            if (model.IO_ENABLE_MAXMAX != null)
            {
                strSql.Append("IO_ENABLE_MAXMAX=" + model.IO_ENABLE_MAXMAX + ",");
            }
            else
            {
                strSql.Append("IO_ENABLE_MAXMAX= null ,");
            }
            if (model.IO_MAXMAX_VALUE != null)
            {
                strSql.Append("IO_MAXMAX_VALUE=" + model.IO_MAXMAX_VALUE + ",");
            }
            else
            {
                strSql.Append("IO_MAXMAX_VALUE= null ,");
            }
            if (model.IO_ENABLE_MAX != null)
            {
                strSql.Append("IO_ENABLE_MAX=" + model.IO_ENABLE_MAX + ",");
            }
            else
            {
                strSql.Append("IO_ENABLE_MAX= null ,");
            }
            if (model.IO_MAX_VALUE != null)
            {
                strSql.Append("IO_MAX_VALUE=" + model.IO_MAX_VALUE + ",");
            }
            else
            {
                strSql.Append("IO_MAX_VALUE= null ,");
            }
            if (model.IO_ENABLE_MIN != null)
            {
                strSql.Append("IO_ENABLE_MIN=" + model.IO_ENABLE_MIN + ",");
            }
            else
            {
                strSql.Append("IO_ENABLE_MIN= null ,");
            }
            if (model.IO_MIN_VALUE != null)
            {
                strSql.Append("IO_MIN_VALUE=" + model.IO_MIN_VALUE + ",");
            }
            else
            {
                strSql.Append("IO_MIN_VALUE= null ,");
            }
            if (model.IO_ENABLE_MINMIN != null)
            {
                strSql.Append("IO_ENABLE_MINMIN=" + model.IO_ENABLE_MINMIN + ",");
            }
            else
            {
                strSql.Append("IO_ENABLE_MINMIN= null ,");
            }
            if (model.IO_MINMIN_VALUE != null)
            {
                strSql.Append("IO_MINMIN_VALUE=" + model.IO_MINMIN_VALUE + ",");
            }
            else
            {
                strSql.Append("IO_MINMIN_VALUE= null ,");
            }
            if (model.IO_MAXMAX_TYPE != null)
            {
                strSql.Append("IO_MAXMAX_TYPE='" + model.IO_MAXMAX_TYPE + "',");
            }
            else
            {
                strSql.Append("IO_MAXMAX_TYPE= null ,");
            }
            if (model.IO_MAX_TYPE != null)
            {
                strSql.Append("IO_MAX_TYPE='" + model.IO_MAX_TYPE + "',");
            }
            else
            {
                strSql.Append("IO_MAX_TYPE= null ,");
            }
            if (model.IO_MINMIN_TYPE != null)
            {
                strSql.Append("IO_MINMIN_TYPE='" + model.IO_MINMIN_TYPE + "',");
            }
            else
            {
                strSql.Append("IO_MINMIN_TYPE= null ,");
            }
            if (model.IO_CONDITION != null)
            {
                strSql.Append("IO_CONDITION='" + model.IO_CONDITION + "',");
            }
            else
            {
                strSql.Append("IO_CONDITION= null ,");
            }
            if (model.IO_COMM_ID != null)
            {
                strSql.Append("IO_COMM_ID='" + model.IO_COMM_ID + "',");
            }
            if (model.IO_DEVICE_ID != null)
            {
                strSql.Append("IO_DEVICE_ID='" + model.IO_DEVICE_ID + "',");
            }
            if (model.IO_SERVER_ID != null)
            {
                strSql.Append("IO_SERVER_ID='" + model.IO_SERVER_ID + "',");
            }
            
                strSql.Append("IO_ALARM_NUMBER=" + model.IO_ALARM_NUMBER + ",");
             
            if (model.IO_MIN_TYPE != null)
            {
                strSql.Append("IO_MIN_TYPE='" + model.IO_MIN_TYPE + "',");
            }
            else
            {
                strSql.Append("IO_MIN_TYPE= null ,");
            }
            if (model.UPDATE_RESULT != null)
            {
                strSql.Append("UPDATE_RESULT='" + model.UPDATE_RESULT + "',");
            }
            else
            {
                strSql.Append("UPDATE_RESULT= null ,");
            }
            
                strSql.Append("IO_ALARM_STATUS=" + model.UPDATE_RESULT + ",");
          
            
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where IO_ID='" + model.IO_ID + "'");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string IO_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from IO_ALARM_CONFIG ");
			strSql.Append(" where IO_ID='"+ IO_ID + "'");
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
        public bool DeleteCommunication(string IO_SERVER_ID, string IO_COMM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from IO_ALARM_CONFIG ");
            strSql.Append(" where IO_COMM_ID='" + IO_COMM_ID + "' and IO_SERVER_ID'"+ IO_SERVER_ID + "'");
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
        public bool DeleteDevice(string IO_SERVER_ID,string IO_DEVICE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from IO_ALARM_CONFIG ");
            strSql.Append(" where IO_DEVICE_ID='" + IO_DEVICE_ID + "' and IO_SERVER_ID'" + IO_SERVER_ID + "'");
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
            strSql.Append("delete from IO_ALARM_CONFIG where  IO_SERVER_ID='" + IO_SERVER_ID+"'");
       
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
            strSql.Append("delete from IO_ALARM_CONFIG ");

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
        public Scada.Model.IO_ALARM_CONFIG GetModel(string IO_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" * ");
			strSql.Append(" from IO_ALARM_CONFIG ");
			strSql.Append(" where IO_ID='"+ IO_ID + "' and IO_ALARM_STATUS=0 ");
			Scada.Model.IO_ALARM_CONFIG model=new Scada.Model.IO_ALARM_CONFIG();
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
		public Scada.Model.IO_ALARM_CONFIG DataRowToModel(DataRow row)
		{
			Scada.Model.IO_ALARM_CONFIG model=new Scada.Model.IO_ALARM_CONFIG();
			if (row != null)
			{
				if(row["IO_ID"]!=null)
				{
					model.IO_ID=row["IO_ID"].ToString();
				}
				if(row["IO_ALARM_TYPE"]!=null)
				{
					model.IO_ALARM_TYPE=row["IO_ALARM_TYPE"].ToString();
				}
				if(row["IO_ALARM_LEVEL"]!=null)
				{
					model.IO_ALARM_LEVEL=row["IO_ALARM_LEVEL"].ToString();
				}
				if(row["IO_ENABLE_MAXMAX"]!=null && row["IO_ENABLE_MAXMAX"].ToString()!="")
				{
					model.IO_ENABLE_MAXMAX=int.Parse(row["IO_ENABLE_MAXMAX"].ToString());
				}
                if (row[" IO_ALARM_STATUS"] != null && row[" IO_ALARM_STATUS"].ToString() != "")
                {
                    model.IO_ALARM_STATUS = int.Parse(row[" IO_ALARM_STATUS"].ToString());
                }
               

                if (row["IO_MAXMAX_VALUE"]!=null && row["IO_MAXMAX_VALUE"].ToString()!="")
				{
					model.IO_MAXMAX_VALUE=decimal.Parse(row["IO_MAXMAX_VALUE"].ToString());
				}
				if(row["IO_ENABLE_MAX"]!=null && row["IO_ENABLE_MAX"].ToString()!="")
				{
					model.IO_ENABLE_MAX=int.Parse(row["IO_ENABLE_MAX"].ToString());
				}
				if(row["IO_MAX_VALUE"]!=null && row["IO_MAX_VALUE"].ToString()!="")
				{
					model.IO_MAX_VALUE=decimal.Parse(row["IO_MAX_VALUE"].ToString());
				}
				if(row["IO_ENABLE_MIN"]!=null && row["IO_ENABLE_MIN"].ToString()!="")
				{
					model.IO_ENABLE_MIN=int.Parse(row["IO_ENABLE_MIN"].ToString());
				}
				if(row["IO_MIN_VALUE"]!=null && row["IO_MIN_VALUE"].ToString()!="")
				{
					model.IO_MIN_VALUE=decimal.Parse(row["IO_MIN_VALUE"].ToString());
				}
				if(row["IO_ENABLE_MINMIN"]!=null && row["IO_ENABLE_MINMIN"].ToString()!="")
				{
					model.IO_ENABLE_MINMIN=int.Parse(row["IO_ENABLE_MINMIN"].ToString());
				}
				if(row["IO_MINMIN_VALUE"]!=null && row["IO_MINMIN_VALUE"].ToString()!="")
				{
					model.IO_MINMIN_VALUE=decimal.Parse(row["IO_MINMIN_VALUE"].ToString());
				}
				if(row["IO_MAXMAX_TYPE"]!=null)
				{
					model.IO_MAXMAX_TYPE=row["IO_MAXMAX_TYPE"].ToString();
				}
				if(row["IO_MAX_TYPE"]!=null)
				{
					model.IO_MAX_TYPE=row["IO_MAX_TYPE"].ToString();
				}
				if(row["IO_MINMIN_TYPE"]!=null)
				{
					model.IO_MINMIN_TYPE=row["IO_MINMIN_TYPE"].ToString();
				}
				if(row["IO_CONDITION"]!=null)
				{
					model.IO_CONDITION=row["IO_CONDITION"].ToString();
				}
				if(row["IO_COMM_ID"]!=null)
				{
					model.IO_COMM_ID=row["IO_COMM_ID"].ToString();
				}
				if(row["IO_DEVICE_ID"]!=null)
				{
					model.IO_DEVICE_ID=row["IO_DEVICE_ID"].ToString();
				}
				if(row["IO_SERVER_ID"]!=null)
				{
					model.IO_SERVER_ID=row["IO_SERVER_ID"].ToString();
				}
				if(row["IO_ALARM_NUMBER"]!=null && row["IO_ALARM_NUMBER"].ToString()!="")
				{
					model.IO_ALARM_NUMBER=int.Parse(row["IO_ALARM_NUMBER"].ToString());
				}
				if(row["IO_MIN_TYPE"]!=null)
				{
					model.IO_MIN_TYPE=row["IO_MIN_TYPE"].ToString();
				}
                if (row["UPDATE_UID"] != null)
                {
                    model.UPDATE_UID = row["UPDATE_UID"].ToString();
                }
                if (row["UPDATE_DATE"] != null)
                {
                    model.UPDATE_DATE = row["UPDATE_DATE"].ToString();
                }
                if (row["UPDATE_RESULT"] != null)
                {
                    model.UPDATE_RESULT = row["UPDATE_RESULT"].ToString();
                }
            }
			return model;
		}
        public bool UpdateStatus(int status, string serverid)
        {
            string sql = "update IO_ALARM_CONFIG set IO_ALARM_STATUS=" + status + " where IO_SERVER_ID='" + serverid + "'";
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM IO_ALARM_CONFIG where IO_ALARM_STATUS=0 ");
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
			strSql.Append("select count(1) FROM IO_ALARM_CONFIG ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from IO_ALARM_CONFIG T ");
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

