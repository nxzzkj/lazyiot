using DapperExtensions;
using ScadaWeb.DapperExtensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace ScadaWeb.Model
{
    [Table("LogonLog")]
    public class LogonLogModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DapperExtensions.Key(true)]
        public int Id { get; set; }
        /// <summary>
        /// 登录类型
        /// </summary>
        public string LogType { get; set; }
        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// IP所在城市
        /// </summary>
        public string IPAddressName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 日志查询时间范围
        /// </summary>
        [Computed]
        public string StartEndDate { get; set; }
    }
}
