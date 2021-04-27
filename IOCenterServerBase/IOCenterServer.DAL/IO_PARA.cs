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
	/// 数据访问类:IO_PARA
	/// </summary>
	public partial class IO_PARA
	{
		public IO_PARA()
		{}
        #region  Method

        public StringBuilder GetInsertArray(Scada.Model.IO_PARA model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.IO_ID != null)
            {
                strSql1.Append("IO_ID,");
                strSql2.Append("'" + model.IO_ID + "',");
            }
            if (model.IO_SERVER_ID != null)
            {
                strSql1.Append("IO_SERVER_ID,");
                strSql2.Append("'" + model.IO_SERVER_ID + "',");
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
            if (model.IO_NAME != null)
            {
                strSql1.Append("IO_NAME,");
                strSql2.Append("'" + model.IO_NAME + "',");
            }
            if (model.IO_LABEL != null)
            {
                strSql1.Append("IO_LABEL,");
                strSql2.Append("'" + model.IO_LABEL + "',");
            }
            if (model.IO_PARASTRING != null)
            {
                strSql1.Append("IO_PARASTRING,");
                strSql2.Append("'" + model.IO_PARASTRING + "',");
            }
            if (model.IO_ALERT_ENABLE != null)
            {
                strSql1.Append("IO_ALERT_ENABLE,");
                strSql2.Append("" + model.IO_ALERT_ENABLE + ",");
            }
            if (model.IO_DATATYPE != null)
            {
                strSql1.Append("IO_DATATYPE,");
                strSql2.Append("'" + model.IO_DATATYPE + "',");
            }
            if (model.IO_INITALVALUE != null)
            {
                strSql1.Append("IO_INITALVALUE,");
                strSql2.Append("'" + model.IO_INITALVALUE + "',");
            }
            if (model.IO_MAXVALUE != null)
            {
                strSql1.Append("IO_MAXVALUE,");
                strSql2.Append("'" + model.IO_MAXVALUE + "',");
            }
            if (model.IO_MINVALUE != null)
            {
                strSql1.Append("IO_MINVALUE,");
                strSql2.Append("'" + model.IO_MINVALUE + "',");
            }
            if (model.IO_ENABLERANGECONVERSION != null)
            {
                strSql1.Append("IO_ENABLERANGECONVERSION,");
                strSql2.Append("" + model.IO_ENABLERANGECONVERSION + ",");
            }
            if (model.IO_RANGEMIN != null)
            {
                strSql1.Append("IO_RANGEMIN,");
                strSql2.Append("'" + model.IO_RANGEMIN + "',");
            }
            if (model.IO_RANGEMAX != null)
            {
                strSql1.Append("IO_RANGEMAX,");
                strSql2.Append("'" + model.IO_RANGEMAX + "',");
            }
            if (model.IO_OUTLIES != null)
            {
                strSql1.Append("IO_OUTLIES,");
                strSql2.Append("'" + model.IO_OUTLIES + "',");
            }
            if (model.IO_POINTTYPE != null)
            {
                strSql1.Append("IO_POINTTYPE,");
                strSql2.Append("'" + model.IO_POINTTYPE + "',");
            }
            if (model.IO_ZERO != null)
            {
                strSql1.Append("IO_ZERO,");
                strSql2.Append("'" + model.IO_ZERO + "',");
            }
            if (model.IO_ONE != null)
            {
                strSql1.Append("IO_ONE,");
                strSql2.Append("'" + model.IO_ONE + "',");
            }
            if (model.IO_UNIT != null)
            {
                strSql1.Append("IO_UNIT,");
                strSql2.Append("'" + model.IO_UNIT + "',");
            }
            if (model.IO_HISTORY != null)
            {
                strSql1.Append("IO_HISTORY,");
                strSql2.Append("" + model.IO_HISTORY + ",");
            }
            if (model.IO_ADDRESS != null)
            {
                strSql1.Append("IO_ADDRESS,");
                strSql2.Append("'" + model.IO_ADDRESS + "',");
            }
            if (model.IO_ENABLEALARM != null)
            {
                strSql1.Append("IO_ENABLEALARM,");
                strSql2.Append("" + model.IO_ENABLEALARM + ",");
            }
            if (model.IO_SYSTEM != null)
            {
                strSql1.Append("IO_SYSTEM,");
                strSql2.Append("" + model.IO_SYSTEM + ",");
            }
            if (model.IO_FORMULA != null)
            {
                strSql1.Append("IO_FORMULA,");
                strSql2.Append("'" + model.IO_FORMULA + "',");
            }
            if (model.IO_DATASOURCE != null)
            {
                strSql1.Append("IO_DATASOURCE,");
                strSql2.Append("'" + model.IO_DATASOURCE + "',");
            }
            
            
                strSql1.Append("IO_STATUS,");
                strSql2.Append("" + model.IO_STATUS + ",");
            
            strSql.Append("insert into IO_PARA(");
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
        public bool Add(Scada.Model.IO_PARA model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.IO_ID != null)
			{
				strSql1.Append("IO_ID,");
				strSql2.Append("'"+model.IO_ID+"',");
			}
			if (model.IO_SERVER_ID != null)
			{
				strSql1.Append("IO_SERVER_ID,");
				strSql2.Append("'"+model.IO_SERVER_ID+"',");
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
			if (model.IO_NAME != null)
			{
				strSql1.Append("IO_NAME,");
				strSql2.Append("'"+model.IO_NAME+"',");
			}
			if (model.IO_LABEL != null)
			{
				strSql1.Append("IO_LABEL,");
				strSql2.Append("'"+model.IO_LABEL+"',");
			}
			if (model.IO_PARASTRING != null)
			{
				strSql1.Append("IO_PARASTRING,");
				strSql2.Append("'"+model.IO_PARASTRING+"',");
			}
			if (model.IO_ALERT_ENABLE != null)
			{
				strSql1.Append("IO_ALERT_ENABLE,");
				strSql2.Append(""+model.IO_ALERT_ENABLE+",");
			}
			if (model.IO_DATATYPE != null)
			{
				strSql1.Append("IO_DATATYPE,");
				strSql2.Append("'"+model.IO_DATATYPE+"',");
			}
			if (model.IO_INITALVALUE != null)
			{
				strSql1.Append("IO_INITALVALUE,");
				strSql2.Append("'"+model.IO_INITALVALUE+"',");
			}
			if (model.IO_MAXVALUE != null)
			{
				strSql1.Append("IO_MAXVALUE,");
				strSql2.Append("'"+model.IO_MAXVALUE+"',");
			}
			if (model.IO_MINVALUE != null)
			{
				strSql1.Append("IO_MINVALUE,");
				strSql2.Append("'"+model.IO_MINVALUE+"',");
			}
			if (model.IO_ENABLERANGECONVERSION != null)
			{
				strSql1.Append("IO_ENABLERANGECONVERSION,");
				strSql2.Append(""+model.IO_ENABLERANGECONVERSION+",");
			}
			if (model.IO_RANGEMIN != null)
			{
				strSql1.Append("IO_RANGEMIN,");
				strSql2.Append("'"+model.IO_RANGEMIN+"',");
			}
			if (model.IO_RANGEMAX != null)
			{
				strSql1.Append("IO_RANGEMAX,");
				strSql2.Append("'"+model.IO_RANGEMAX+"',");
			}
			if (model.IO_OUTLIES != null)
			{
				strSql1.Append("IO_OUTLIES,");
				strSql2.Append("'"+model.IO_OUTLIES+"',");
			}
			if (model.IO_POINTTYPE != null)
			{
				strSql1.Append("IO_POINTTYPE,");
				strSql2.Append("'"+model.IO_POINTTYPE+"',");
			}
			if (model.IO_ZERO != null)
			{
				strSql1.Append("IO_ZERO,");
				strSql2.Append("'"+model.IO_ZERO+"',");
			}
			if (model.IO_ONE != null)
			{
				strSql1.Append("IO_ONE,");
				strSql2.Append("'"+model.IO_ONE+"',");
			}
			if (model.IO_UNIT != null)
			{
				strSql1.Append("IO_UNIT,");
				strSql2.Append("'"+model.IO_UNIT+"',");
			}
			if (model.IO_HISTORY != null)
			{
				strSql1.Append("IO_HISTORY,");
				strSql2.Append(""+model.IO_HISTORY+",");
			}
			if (model.IO_ADDRESS != null)
			{
				strSql1.Append("IO_ADDRESS,");
				strSql2.Append("'"+model.IO_ADDRESS+"',");
			}
			if (model.IO_ENABLEALARM != null)
			{
				strSql1.Append("IO_ENABLEALARM,");
				strSql2.Append(""+model.IO_ENABLEALARM+",");
			}
			if (model.IO_SYSTEM != null)
			{
				strSql1.Append("IO_SYSTEM,");
				strSql2.Append(""+model.IO_SYSTEM+",");
			}
            if (model.IO_FORMULA != null)
            {
                strSql1.Append("IO_FORMULA,");
                strSql2.Append("'" + model.IO_FORMULA + "',");
            }
            if (model.IO_DATASOURCE != null)
            {
                strSql1.Append("IO_DATASOURCE,");
                strSql2.Append("'" + model.IO_DATASOURCE + "',");
            }
            

           
                strSql1.Append("IO_STATUS,");
                strSql2.Append("" + model.IO_STATUS + ",");
            
            strSql.Append("insert into IO_PARA(");
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
        public void  Add(List<Scada.Model.IO_PARA> models)
        {
            ArrayList sqlArray = new ArrayList();
            for (int i = 0; i < models.Count; i++)
            {
                Scada.Model.IO_PARA model = models[i];
                model.IO_STATUS = 0;
                StringBuilder strSql = new StringBuilder();
                StringBuilder strSql1 = new StringBuilder();
                StringBuilder strSql2 = new StringBuilder();
                if (model.IO_ID != null)
                {
                    strSql1.Append("IO_ID,");
                    strSql2.Append("'" + model.IO_ID + "',");
                }
                if (model.IO_SERVER_ID != null)
                {
                    strSql1.Append("IO_SERVER_ID,");
                    strSql2.Append("'" + model.IO_SERVER_ID + "',");
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
                if (model.IO_NAME != null)
                {
                    strSql1.Append("IO_NAME,");
                    strSql2.Append("'" + model.IO_NAME + "',");
                }
                if (model.IO_LABEL != null)
                {
                    strSql1.Append("IO_LABEL,");
                    strSql2.Append("'" + model.IO_LABEL + "',");
                }
                if (model.IO_PARASTRING != null)
                {
                    strSql1.Append("IO_PARASTRING,");
                    strSql2.Append("'" + model.IO_PARASTRING + "',");
                }
                if (model.IO_ALERT_ENABLE != null)
                {
                    strSql1.Append("IO_ALERT_ENABLE,");
                    strSql2.Append("" + model.IO_ALERT_ENABLE + ",");
                }
                if (model.IO_DATATYPE != null)
                {
                    strSql1.Append("IO_DATATYPE,");
                    strSql2.Append("'" + model.IO_DATATYPE + "',");
                }
                if (model.IO_INITALVALUE != null)
                {
                    strSql1.Append("IO_INITALVALUE,");
                    strSql2.Append("'" + model.IO_INITALVALUE + "',");
                }
                if (model.IO_MAXVALUE != null)
                {
                    strSql1.Append("IO_MAXVALUE,");
                    strSql2.Append("'" + model.IO_MAXVALUE + "',");
                }
                if (model.IO_MINVALUE != null)
                {
                    strSql1.Append("IO_MINVALUE,");
                    strSql2.Append("'" + model.IO_MINVALUE + "',");
                }
                if (model.IO_ENABLERANGECONVERSION != null)
                {
                    strSql1.Append("IO_ENABLERANGECONVERSION,");
                    strSql2.Append("" + model.IO_ENABLERANGECONVERSION + ",");
                }
                if (model.IO_RANGEMIN != null)
                {
                    strSql1.Append("IO_RANGEMIN,");
                    strSql2.Append("'" + model.IO_RANGEMIN + "',");
                }
                if (model.IO_RANGEMAX != null)
                {
                    strSql1.Append("IO_RANGEMAX,");
                    strSql2.Append("'" + model.IO_RANGEMAX + "',");
                }
                if (model.IO_OUTLIES != null)
                {
                    strSql1.Append("IO_OUTLIES,");
                    strSql2.Append("'" + model.IO_OUTLIES + "',");
                }
                if (model.IO_POINTTYPE != null)
                {
                    strSql1.Append("IO_POINTTYPE,");
                    strSql2.Append("'" + model.IO_POINTTYPE + "',");
                }
                if (model.IO_ZERO != null)
                {
                    strSql1.Append("IO_ZERO,");
                    strSql2.Append("'" + model.IO_ZERO + "',");
                }
                if (model.IO_ONE != null)
                {
                    strSql1.Append("IO_ONE,");
                    strSql2.Append("'" + model.IO_ONE + "',");
                }
                if (model.IO_UNIT != null)
                {
                    strSql1.Append("IO_UNIT,");
                    strSql2.Append("'" + model.IO_UNIT + "',");
                }
                if (model.IO_HISTORY != null)
                {
                    strSql1.Append("IO_HISTORY,");
                    strSql2.Append("" + model.IO_HISTORY + ",");
                }
                if (model.IO_ADDRESS != null)
                {
                    strSql1.Append("IO_ADDRESS,");
                    strSql2.Append("'" + model.IO_ADDRESS + "',");
                }
                if (model.IO_ENABLEALARM != null)
                {
                    strSql1.Append("IO_ENABLEALARM,");
                    strSql2.Append("" + model.IO_ENABLEALARM + ",");
                }
                if (model.IO_SYSTEM != null)
                {
                    strSql1.Append("IO_SYSTEM,");
                    strSql2.Append("" + model.IO_SYSTEM + ",");
                }
                if (model.IO_FORMULA != null)
                {
                    strSql1.Append("IO_FORMULA,");
                    strSql2.Append("'" + model.IO_FORMULA + "',");
                }
                if (model.IO_DATASOURCE != null)
                {
                    strSql1.Append("IO_DATASOURCE,");
                    strSql2.Append("'" + model.IO_DATASOURCE + "',");
                }
                
               
                    strSql1.Append("IO_STATUS,");
                    strSql2.Append("" + model.IO_STATUS + ",");
                

                
                strSql.Append("insert into IO_PARA(");
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
        public bool UpdateStatus(int status, string serverid)
        {
            string sql = "update IO_PARA set IO_STATUS=" + status + " where IO_SERVER_ID='" + serverid + "'";
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
        public bool Update(Scada.Model.IO_PARA model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update IO_PARA set ");
			if (model.IO_ID != null)
			{
				strSql.Append("IO_ID='"+model.IO_ID+"',");
			}
			if (model.IO_SERVER_ID != null)
			{
				strSql.Append("IO_SERVER_ID='"+model.IO_SERVER_ID+"',");
			}
			if (model.IO_COMM_ID != null)
			{
				strSql.Append("IO_COMM_ID='"+model.IO_COMM_ID+"',");
			}
			if (model.IO_DEVICE_ID != null)
			{
				strSql.Append("IO_DEVICE_ID='"+model.IO_DEVICE_ID+"',");
			}
			if (model.IO_NAME != null)
			{
				strSql.Append("IO_NAME='"+model.IO_NAME+"',");
			}
			else
			{
				strSql.Append("IO_NAME= null ,");
			}
			if (model.IO_LABEL != null)
			{
				strSql.Append("IO_LABEL='"+model.IO_LABEL+"',");
			}
			else
			{
				strSql.Append("IO_LABEL= null ,");
			}
			if (model.IO_PARASTRING != null)
			{
				strSql.Append("IO_PARASTRING='"+model.IO_PARASTRING+"',");
			}
			else
			{
				strSql.Append("IO_PARASTRING= null ,");
			}
			if (model.IO_ALERT_ENABLE != null)
			{
				strSql.Append("IO_ALERT_ENABLE="+model.IO_ALERT_ENABLE+",");
			}
			else
			{
				strSql.Append("IO_ALERT_ENABLE= null ,");
			}
			if (model.IO_DATATYPE != null)
			{
				strSql.Append("IO_DATATYPE='"+model.IO_DATATYPE+"',");
			}
			else
			{
				strSql.Append("IO_DATATYPE= null ,");
			}
			if (model.IO_INITALVALUE != null)
			{
				strSql.Append("IO_INITALVALUE='"+model.IO_INITALVALUE+"',");
			}
			else
			{
				strSql.Append("IO_INITALVALUE= null ,");
			}
			if (model.IO_MAXVALUE != null)
			{
				strSql.Append("IO_MAXVALUE='"+model.IO_MAXVALUE+"',");
			}
			else
			{
				strSql.Append("IO_MAXVALUE= null ,");
			}
			if (model.IO_MINVALUE != null)
			{
				strSql.Append("IO_MINVALUE='"+model.IO_MINVALUE+"',");
			}
			else
			{
				strSql.Append("IO_MINVALUE= null ,");
			}
			if (model.IO_ENABLERANGECONVERSION != null)
			{
				strSql.Append("IO_ENABLERANGECONVERSION="+model.IO_ENABLERANGECONVERSION+",");
			}
			else
			{
				strSql.Append("IO_ENABLERANGECONVERSION= null ,");
			}
			if (model.IO_RANGEMIN != null)
			{
				strSql.Append("IO_RANGEMIN='"+model.IO_RANGEMIN+"',");
			}
			else
			{
				strSql.Append("IO_RANGEMIN= null ,");
			}
			if (model.IO_RANGEMAX != null)
			{
				strSql.Append("IO_RANGEMAX='"+model.IO_RANGEMAX+"',");
			}
			else
			{
				strSql.Append("IO_RANGEMAX= null ,");
			}
			if (model.IO_OUTLIES != null)
			{
				strSql.Append("IO_OUTLIES='"+model.IO_OUTLIES+"',");
			}
			else
			{
				strSql.Append("IO_OUTLIES= null ,");
			}
			if (model.IO_POINTTYPE != null)
			{
				strSql.Append("IO_POINTTYPE='"+model.IO_POINTTYPE+"',");
			}
			else
			{
				strSql.Append("IO_POINTTYPE= null ,");
			}
			if (model.IO_ZERO != null)
			{
				strSql.Append("IO_ZERO='"+model.IO_ZERO+"',");
			}
			else
			{
				strSql.Append("IO_ZERO= null ,");
			}
			if (model.IO_ONE != null)
			{
				strSql.Append("IO_ONE='"+model.IO_ONE+"',");
			}
			else
			{
				strSql.Append("IO_ONE= null ,");
			}
			if (model.IO_UNIT != null)
			{
				strSql.Append("IO_UNIT='"+model.IO_UNIT+"',");
			}
			else
			{
				strSql.Append("IO_UNIT= null ,");
			}
			if (model.IO_HISTORY != null)
			{
				strSql.Append("IO_HISTORY="+model.IO_HISTORY+",");
			}
			else
			{
				strSql.Append("IO_HISTORY= null ,");
			}
			if (model.IO_ADDRESS != null)
			{
				strSql.Append("IO_ADDRESS='"+model.IO_ADDRESS+"',");
			}
			else
			{
				strSql.Append("IO_ADDRESS= null ,");
			}
			if (model.IO_ENABLEALARM != null)
			{
				strSql.Append("IO_ENABLEALARM="+model.IO_ENABLEALARM+",");
			}
			else
			{
				strSql.Append("IO_ENABLEALARM= null ,");
			}
			if (model.IO_SYSTEM != null)
			{
				strSql.Append("IO_SYSTEM="+model.IO_SYSTEM+",");
			}
			else
			{
				strSql.Append("IO_SYSTEM= null ,");
			}
            if (model.IO_SYSTEM != null)
            {
                strSql.Append("IO_STATUS=" + model.IO_STATUS + ",");
            }
            else
            {
                strSql.Append("IO_STATUS= null ,");
            }
            if (model.IO_FORMULA != null)
            {
                strSql.Append("IO_FORMULA='" + model.IO_FORMULA + "',");
            }
            else
            {
                strSql.Append("IO_FORMULA= null ,");
            }
            if (model.IO_DATASOURCE != null)
            {
                strSql.Append("IO_DATASOURCE='" + model.IO_DATASOURCE + "',");
            }
            else
            {
                strSql.Append("IO_DATASOURCE= null ,");
            }
            
            int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where IO_ID='"+ model.IO_ID + "'");
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
		public bool Delete(string IO_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from IO_PARA ");
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
            strSql.Append("delete from IO_PARA ");
            strSql.Append(" where IO_COMM_ID='" + IO_COMM_ID + "' and IO_SERVER_ID'" + IO_SERVER_ID.Trim() + "'");
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
        public bool DeleteDevice(string IO_SERVER_ID, string IO_DEVICE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from IO_PARA ");
            strSql.Append(" where IO_DEVICE_ID='" + IO_DEVICE_ID + "' and IO_SERVER_ID'" + IO_SERVER_ID.Trim() + "'");
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
            strSql.Append("delete from IO_PARA where  IO_SERVER_ID='" + IO_SERVER_ID.Trim() + "'");

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
            strSql.Append("delete from IO_PARA ");

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
        public bool ClearView(string IO_SERVER_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from V_IO_PARA where  IO_SERVER_ID='" + IO_SERVER_ID.Trim() + "'");

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
        public Scada.Model.IO_PARA GetModel(string IO_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" *  ");
			strSql.Append(" from V_IO_PARA ");
			strSql.Append(" where IO_ID='"+ IO_ID + "' and IO_STATUS=0 ");
			Scada.Model.IO_PARA model=new Scada.Model.IO_PARA();
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
		public Scada.Model.IO_PARA DataRowToModel(DataRow row)
		{
			Scada.Model.IO_PARA model=new Scada.Model.IO_PARA();
			if (row != null)
			{
				if(row["IO_ID"]!=null)
				{
					model.IO_ID=row["IO_ID"].ToString();
				}
				if(row["IO_SERVER_ID"]!=null)
				{
					model.IO_SERVER_ID=row["IO_SERVER_ID"].ToString();
				}
				if(row["IO_COMM_ID"]!=null)
				{
					model.IO_COMM_ID=row["IO_COMM_ID"].ToString();
				}
				if(row["IO_DEVICE_ID"]!=null)
				{
					model.IO_DEVICE_ID=row["IO_DEVICE_ID"].ToString();
				}
				if(row["IO_NAME"]!=null)
				{
					model.IO_NAME=row["IO_NAME"].ToString();
				}
				if(row["IO_LABEL"]!=null)
				{
					model.IO_LABEL=row["IO_LABEL"].ToString();
				}
				if(row["IO_PARASTRING"]!=null)
				{
					model.IO_PARASTRING=row["IO_PARASTRING"].ToString();
				}
				if(row["IO_ALERT_ENABLE"]!=null && row["IO_ALERT_ENABLE"].ToString()!="")
				{
					model.IO_ALERT_ENABLE=int.Parse(row["IO_ALERT_ENABLE"].ToString());
				}
				if(row["IO_DATATYPE"]!=null)
				{
					model.IO_DATATYPE=row["IO_DATATYPE"].ToString();
				}
				if(row["IO_INITALVALUE"]!=null)
				{
					model.IO_INITALVALUE=row["IO_INITALVALUE"].ToString();
				}
				if(row["IO_MAXVALUE"]!=null)
				{
					model.IO_MAXVALUE=row["IO_MAXVALUE"].ToString();
				}
				if(row["IO_MINVALUE"]!=null)
				{
					model.IO_MINVALUE=row["IO_MINVALUE"].ToString();
				}
                if (row["IO_ENABLERANGECONVERSION"] != null && row["IO_ENABLERANGECONVERSION"].ToString() != "")
                {
                    model.IO_ENABLERANGECONVERSION = int.Parse(row["IO_ENABLERANGECONVERSION"].ToString());
                }

                
				if(row["IO_RANGEMIN"]!=null)
				{
					model.IO_RANGEMIN=row["IO_RANGEMIN"].ToString();
				}
				if(row["IO_RANGEMAX"]!=null)
				{
					model.IO_RANGEMAX=row["IO_RANGEMAX"].ToString();
				}
				if(row["IO_OUTLIES"]!=null)
				{
					model.IO_OUTLIES=row["IO_OUTLIES"].ToString();
				}
				if(row["IO_POINTTYPE"]!=null)
				{
					model.IO_POINTTYPE=row["IO_POINTTYPE"].ToString();
				}
				if(row["IO_ZERO"]!=null)
				{
					model.IO_ZERO=row["IO_ZERO"].ToString();
				}
				if(row["IO_ONE"]!=null)
				{
					model.IO_ONE=row["IO_ONE"].ToString();
				}
				if(row["IO_UNIT"]!=null)
				{
					model.IO_UNIT=row["IO_UNIT"].ToString();
				}
				if(row["IO_HISTORY"]!=null && row["IO_HISTORY"].ToString()!="")
				{
					model.IO_HISTORY=int.Parse(row["IO_HISTORY"].ToString());
				}
				if(row["IO_ADDRESS"]!=null)
				{
					model.IO_ADDRESS=row["IO_ADDRESS"].ToString();
				}
				if(row["IO_ENABLEALARM"]!=null && row["IO_ENABLEALARM"].ToString()!="")
				{
					model.IO_ENABLEALARM=int.Parse(row["IO_ENABLEALARM"].ToString());
				}
				if(row["IO_SYSTEM"]!=null && row["IO_SYSTEM"].ToString()!="")
				{
					model.IO_SYSTEM=int.Parse(row["IO_SYSTEM"].ToString());
				}
                if (row["IO_STATUS"] != null && row["IO_STATUS"].ToString() != "")
                {
                    model.IO_STATUS = int.Parse(row["IO_STATUS"].ToString());
                }
                if (row["IO_FORMULA"] != null)
                {
                    model.IO_FORMULA = row["IO_FORMULA"].ToString();
                }
                if (row["IO_DATASOURCE"] != null)
                {
                    model.IO_DATASOURCE = row["IO_DATASOURCE"].ToString();
                }
                
                //报警信息的IO
                model.AlarmConfig = new Model.IO_ALARM_CONFIG();
                if (row["IO_ID"] != null)
                {
                    model.AlarmConfig.IO_ID = row["IO_ID"].ToString();
                }
                if (row["IO_ALARM_TYPE"] != null)
                {
                    model.AlarmConfig.IO_ALARM_TYPE = row["IO_ALARM_TYPE"].ToString();
                }
                if (row["IO_ALARM_LEVEL"] != null)
                {
                    model.AlarmConfig.IO_ALARM_LEVEL = row["IO_ALARM_LEVEL"].ToString();
                }
                if (row["IO_ENABLE_MAXMAX"] != null && row["IO_ENABLE_MAXMAX"].ToString() != "")
                {
                    model.AlarmConfig.IO_ENABLE_MAXMAX = int.Parse(row["IO_ENABLE_MAXMAX"].ToString());
                }
                if (row["IO_MAXMAX_VALUE"] != null && row["IO_MAXMAX_VALUE"].ToString() != "")
                {
                    model.AlarmConfig.IO_MAXMAX_VALUE = decimal.Parse(row["IO_MAXMAX_VALUE"].ToString());
                }
                if (row["IO_ENABLE_MAX"] != null && row["IO_ENABLE_MAX"].ToString() != "")
                {
                    model.AlarmConfig.IO_ENABLE_MAX = int.Parse(row["IO_ENABLE_MAX"].ToString());
                }
                if (row["IO_MAX_VALUE"] != null && row["IO_MAX_VALUE"].ToString() != "")
                {
                    model.AlarmConfig.IO_MAX_VALUE = decimal.Parse(row["IO_MAX_VALUE"].ToString());
                }
                if (row["IO_ENABLE_MIN"] != null && row["IO_ENABLE_MIN"].ToString() != "")
                {
                    model.AlarmConfig.IO_ENABLE_MIN = int.Parse(row["IO_ENABLE_MIN"].ToString());
                }
                if (row["IO_MIN_VALUE"] != null && row["IO_MIN_VALUE"].ToString() != "")
                {
                    model.AlarmConfig.IO_MIN_VALUE = decimal.Parse(row["IO_MIN_VALUE"].ToString());
                }
                if (row["IO_ENABLE_MINMIN"] != null && row["IO_ENABLE_MINMIN"].ToString() != "")
                {
                    model.AlarmConfig.IO_ENABLE_MINMIN = int.Parse(row["IO_ENABLE_MINMIN"].ToString());
                }
                if (row["IO_MINMIN_VALUE"] != null && row["IO_MINMIN_VALUE"].ToString() != "")
                {
                    model.AlarmConfig.IO_MINMIN_VALUE = decimal.Parse(row["IO_MINMIN_VALUE"].ToString());
                }
                if (row["IO_MAXMAX_TYPE"] != null)
                {
                    model.AlarmConfig.IO_MAXMAX_TYPE = row["IO_MAXMAX_TYPE"].ToString();
                }
                if (row["IO_MAX_TYPE"] != null)
                {
                    model.AlarmConfig.IO_MAX_TYPE = row["IO_MAX_TYPE"].ToString();
                }
                if (row["IO_MINMIN_TYPE"] != null)
                {
                    model.AlarmConfig.IO_MINMIN_TYPE = row["IO_MINMIN_TYPE"].ToString();
                }
                if (row["IO_CONDITION"] != null)
                {
                    model.AlarmConfig.IO_CONDITION = row["IO_CONDITION"].ToString();
                }
                if (row["IO_COMM_ID"] != null)
                {
                    model.AlarmConfig.IO_COMM_ID = row["IO_COMM_ID"].ToString();
                }
                if (row["IO_DEVICE_ID"] != null)
                {
                    model.AlarmConfig.IO_DEVICE_ID = row["IO_DEVICE_ID"].ToString();
                }
                if (row["IO_SERVER_ID"] != null)
                {
                    model.AlarmConfig.IO_SERVER_ID = row["IO_SERVER_ID"].ToString();
                }
                if (row["IO_ALARM_NUMBER"] != null && row["IO_ALARM_NUMBER"].ToString() != "")
                {
                    model.AlarmConfig.IO_ALARM_NUMBER = int.Parse(row["IO_ALARM_NUMBER"].ToString());
                }
                if (row["IO_MIN_TYPE"] != null)
                {
                    model.AlarmConfig.IO_MIN_TYPE = row["IO_MIN_TYPE"].ToString();
                }
                if (row["IO_ALARM_STATUS"] != null)
                {
                    model.AlarmConfig.IO_ALARM_STATUS =int.Parse( row["IO_ALARM_STATUS"].ToString());
                }
        

            }
			return model;
		}
        IO_ALARM_CONFIG alarmDal = new IO_ALARM_CONFIG();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select *  ");
			strSql.Append(" FROM V_IO_PARA where IO_STATUS=0 ");
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
			strSql.Append("select count(1) FROM V_IO_PARA ");
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
			strSql.Append(")AS Row, T.*  from IO_PARA T ");
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

