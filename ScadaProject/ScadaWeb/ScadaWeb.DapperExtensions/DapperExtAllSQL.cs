using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;

namespace ScadaWeb.DapperExtensions
{
    public static class DapperExtAllSQL
    {
        /// <summary>
        /// 返回DataTable
        /// </summary>
        public static DataTable GetDataTableBase(this IDbConnection conn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (IDataReader reader = conn.ExecuteReader(sql, param, transaction, commandTimeout))
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }

        /// <summary>
        /// 返回DataSet
        /// </summary>
        public static DataSet GetDataSetBase(this IDbConnection conn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (IDataReader reader = conn.ExecuteReader(sql, param, transaction, commandTimeout))
            {
                DataSet ds = new DataSet();
                while (!reader.IsClosed)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    ds.Tables.Add(dt);
                }
                return ds;
            }
        }



    }
}
