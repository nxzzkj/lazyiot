using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.IRepository;
using ScadaWeb.Model;
using Dapper;

namespace ScadaWeb.Repository
{
    public class OrganizeRepository : BaseRepository<OrganizeModel>, IOrganizeRepository
    {
        public IEnumerable<OrganizeModel> GetOrganizeList()
        {
            using (var conn=MySqlHelper.GetConnection())
            {
                string sql = @"SELECT a.Id,a.ParentId,a.EnCode,a.FullName,a.SortCode,b.ItemName as CategoryName,a.CreateTime FROM organize a
                               INNER JOIN itemsdetail b ON a.CategoryId=b.Id ORDER BY a.SortCode ASC";
                return conn.Query<OrganizeModel>(sql);
            }
        }
    }
}
