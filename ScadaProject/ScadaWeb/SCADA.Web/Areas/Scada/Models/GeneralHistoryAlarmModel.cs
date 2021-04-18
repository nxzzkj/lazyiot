using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScadaWeb.Web.Areas.Scada.Models
{
    public class GeneralHistoryAlarmFormModel
    {

        public GeneralHistoryAlarmFormModel()
        {
            StartDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss");
            EndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public string DeviceID { set; get; }
        public string ServerID { set; get; }
        public string CommunicateID { set; get; }
        public string Fields { set; get; }
        public int GroupID { set; get; }
        /// <summary>
        /// 报警类型
        /// </summary>
        public string IO_ALARM_TYPE
        { set; get; }
        /// <summary>
        /// 报警等级
        /// </summary>
        public string IO_ALARM_LEVEL
        { set; get; }
    }
}