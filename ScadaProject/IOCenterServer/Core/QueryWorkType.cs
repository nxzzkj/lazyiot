using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCenterServer.Core
{
    public enum QueryWorkType
    {
        实时数据,
        历史数据,
        实时报警,
        历史报警,
        日志查询
    }
}
