using Dapper;
using ScadaWeb.IRepository;
using ScadaWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Repository
{
    public class ScadaGroupRepository : BaseRepository<ScadaGroupModel>, IScadaGroupRepository
    {
        public IEnumerable<ScadaGroupModel> GetGroupList()
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                string sql = @"SELECT a.Id,a.ParentId,a.SortCode,a.CreateTime,a.GroupTitle FROM ScadaGroup a ORDER BY a.SortCode ASC";
                return conn.Query<ScadaGroupModel>(sql);
            }
        }
    }
}
