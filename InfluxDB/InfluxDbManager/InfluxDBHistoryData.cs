using Temporal.Net.InfluxDb.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temporal.DbAPI
{
    /// <summary>
    /// 定义实时数据库查询历史数据进行分页的类
    /// </summary>
  public   class InfluxDBHistoryData
    {
        public IEnumerable<Serie> Seres = null;
        public int PageSize = 5000;
        public int PageCount = 0;
        public int PageIndex = 1;
        public int RecordCount = 0;
        /// <summary>
        /// 查询成功与否的条件
        /// </summary>
        public bool ReturnResult = false;
        /// <summary>
        /// 返回的相关说明
        /// </summary>
        public string Msg = "";
    }
}
