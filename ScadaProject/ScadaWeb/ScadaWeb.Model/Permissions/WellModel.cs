using DapperExtensions;
using ScadaWeb.DapperExtensions;
using System;

namespace ScadaWeb.Model
{
    [Table("Well")]
    public class WellModel : Entity
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
        public string XZH { get; set; }
        public string YZH { get; set; }
        /// <summary>
        /// 非数据库字段
        /// </summary>
        [Computed]
        public int OrganizeId { get; set; }
        /// <summary>
        /// 非数据库字段
        /// </summary>
        [Computed]
        public string DateStampTime { get; set; }
        /// <summary>
        /// 非数据库字段
        /// </summary>
        [Computed]
        public int UpdateCycle
        {
            set;
            get;
        }
        public void Clear()
        {
            EnCode = "";
            IO_DDLY = "";
            IO_DYM = "";
            IO_JKTY = "";
            IO_XTYL = "";
            IO_LJCQL = "";
            IO_SSCQL = "";
            IO_QTWD = "";
            IO_SXGL = "";
            IO_BPQPL = "";
            IO_DJGZDL = "";
            IO_LJCSL = "";
            IO_SSCSL = "";
            IO_GTCC = "";
            IO_GTCC1 = "";
            IO_SXDY = "";
            IO_YDL = "";
            IO_DJNJ = "";
            IO_DJGZDY = "";
            DateStampTime = "";


        }

    }
}
