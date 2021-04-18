using ScadaWeb.DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Model
{
    [Table("DeviceGroup")]
    public class DeviceGroupModel : Entity
    {

        public DeviceGroupModel()
        {
            LAY_CHECKED = false;
            IOPARAS = "";
            IOPARATITLES = "";
            ALIASNAME = "";
            IOPARANAMES = "";
            ///曲线标识
            SerieType = "";
            UpdateCycle = 120;
        }
        public string SerieType { set; get; }
        /// <summary>
        /// 分组ID
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// 采集站
        /// </summary>
        public string IO_SERVER_ID { get; set; }
        /// <summary>
        /// 通道ID
        /// </summary>
        public string IO_COMM_ID { get; set; }
        /// <summary>
        /// 设备ID
        /// </summary>
        public string IO_DEVICE_ID { set; get; }
        /// <summary>
        /// 设备别名,主要是用来进行专业分组用的
        /// </summary>
        public string ALIASNAME { set; get; }
        public string IOPARAS { set; get; }
        public string IOPARATITLES { set; get; }

        public string IOPARANAMES { set; get; }

        public int UpdateCycle { set; get; }
        /// <summary>
        /// 非数据库字段
        /// </summary>
        [Computed]
        public string IOServerName
        { set; get; }
        /// <summary>
        /// 非数据库字段
        /// </summary>
        [Computed]
        public string IOCommunicateName
        { set; get; }
        /// <summary>
        /// 非数据库字段
        /// </summary>
        [Computed]
        public string IODeviceName
        { set; get; }
        /// <summary>
        /// 非数据库字段 
        /// </summary>
        [Computed]
        public bool LAY_CHECKED
        { set; get; }
        [Computed]
        public string CurrentIO
        { set; get; }
    }
}
