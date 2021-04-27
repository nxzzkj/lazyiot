using Dapper;
using System;
using System.Data;
using System.Linq;

namespace ScadaWeb.Repository
{
    public class Common
    {
        public static string DBConnString = System.Configuration.ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public static System.Data.IDbConnection GetConn()
        {
            return new System.Data.SqlClient.SqlConnection(Common.DBConnString);
        }

        public static PageDataView<T> GetPageData<T>(PageCriteria criteria, object param = null)
        {
            using (var conn = Common.GetConn())
            {
                var p = new DynamicParameters();
                string proName = "ProcGetPageData";
                p.Add("TableName", criteria.TableName);
                p.Add("PrimaryKey", criteria.PrimaryKey);
                p.Add("Fields", criteria.Fields);
                p.Add("Condition", criteria.Condition);
                p.Add("CurrentPage", criteria.CurrentPage);
                p.Add("PageSize", criteria.PageSize);
                p.Add("Sort", criteria.Sort);
                p.Add("RecordCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

                conn.Open();
                var pageData = new PageDataView<T>();
                pageData.Items = conn.Query<T>(proName, p, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                pageData.TotalNum = p.Get<int>("RecordCount");
                pageData.TotalPageCount = Convert.ToInt32(Math.Ceiling(pageData.TotalNum * 1.0 / criteria.PageSize));
                pageData.CurrentPage = criteria.CurrentPage > pageData.TotalPageCount ? pageData.TotalPageCount : criteria.CurrentPage;
                return pageData;
            }
        }
    }
}
