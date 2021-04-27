using ScadaWeb.DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Model.Scada
{
    /// <summary>
    /// 单井实时数据表
    /// </summary>
  public  class WellRealGridModel
    {
        /// <summary>
        /// 井名
        /// </summary>
        public string WellName { get; set; }
        /// <summary>
        /// 井状态0,1
        /// </summary>
        public int WellStatus { get; set; }
        /// <summary>
        /// 绑定的IO参数
        /// </summary>
        public string IO_ServerID { get; set; }
        public string IO_CommunicateID { get; set; }
        public string IO_DeviceID { get; set; }
        public string EnCode { get; set; }
        public string Contractor { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Computed]
        public string FullName { get; set; }
        public string IO_DDLY { get; set; }
        public string IO_DYM { get; set; }
        public string IO_JKTY { get; set; }

        public string IO_XTYL { get; set; }
        public string IO_LJCQL { get; set; }
        public string IO_SSCQL { get; set; }
        public string IO_QTWD { get; set; }
        public string IO_SXGL { get; set; }
        public string IO_BPQPL { get; set; }
        public string IO_DJGZDL { get; set; }
        public string IO_LJCSL { get; set; }
        public string IO_SSCSL { get; set; }
        public string IO_GTCC { get; set; }
        public string IO_GTCC1 { get; set; }
        public string IO_SXDY { get; set; }
        public string IO_GTZH { get; set; }
        public string IO_SXDL { get; set; }
        public string IO_YDL { get; set; }
        public string IO_DJNJ { get; set; }
        public string IO_DJGZDY { get; set; }
        public string WellType { get; set; }

        [Computed]
        public int OrganizeId { get; set; }
    }
}
