using Dapper;
using ScadaWeb.IRepository;
using ScadaWeb.Model;
using System.Collections.Generic;
using System.Linq;

namespace ScadaWeb.Repository
{
    public class DonationRepository : BaseRepository<DonationModel>, IDonationRepository
    {
        /// <summary>
        /// 获得捐赠排行榜
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public IEnumerable<DonationModel> GetSumPriceTop(int num)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                string sql = @"SELECT any_value(Id) Id,`Name`,any_value(SUM(Price)) Price FROM donation
                            GROUP BY `Name`
                            ORDER BY Price desc
                            LIMIT 0,@num";
                return conn.Query<DonationModel>(sql, new { num = num });
            }
        }
        /// <summary>
        /// 获得控制台显示数字
        /// </summary>
        /// <returns></returns>
        public DonationModel GetConsoleNumShow()
        {
            using (var conn=MySqlHelper.GetConnection())
            {
                string sql = @"SELECT 
                            (SELECT SUM(Price) TotalPrice FROM donation) TotalPrice,
                            (SELECT COUNT(1) TotalNum from donation) TotalNum,
                            (SELECT MAX(CAST(Price as DECIMAL(15,2))) MaxPrice FROM donation) MaxPrice,
                            (SELECT COUNT(1) PeopleNum FROM( SELECT `Name` FROM donation
                            GROUP BY `Name`) a) PeopleNum";
                return conn.Query<DonationModel>(sql).FirstOrDefault();
            }
        }
    }
}
