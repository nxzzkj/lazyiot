using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Model
{
    public class PageInfo
    {
        //当前页码
        public int page { get; set; }
        //每页数据量
        public int limit { get; set; }
        //排序字段
        public string field { get; set; }
        //排序方式
        public string order { get; set; }
        //返回字段逗号分隔
        public string returnFields { get; set; }
        public string prefix { get; set; }
        public string Tag { set; get; }
    }
}
