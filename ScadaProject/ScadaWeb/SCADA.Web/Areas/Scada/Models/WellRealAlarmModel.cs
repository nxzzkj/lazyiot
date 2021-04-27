using ScadaWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScadaWeb.Web.Areas.Scada.Models
{
    public class WellRealAlarmModel
    {
        public List<WellModel> Wells = new List<WellModel>();
        public string JsonWells = "";
    }
    public class WellHistoryAlarmModel
    {
        public string JsonWells { set; get; }
        public WellHistoryAlarmModel()
        {
            StartDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss");
            EndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
       public string StartDate { set; get; }
        public string EndDate { set; get; }
    }
  
}