using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScadaWeb.Web.Areas.Scada.Models
{
    public class WellHistorySearchModel
    {
      
        public WellHistorySearchModel()
        {
            OrganizeId = 0;
            WellID = 0;
            StartDate = DateTime.Now.AddHours(-6).ToString("yyyy-MM-dd HH:mm:ss");
            EndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public int OrganizeId { set; get; }
        public int WellID { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public string Method { set; get; }
        public string Period { set; get; }
    }
    public class GeneralHistorySearchModel
    {

        public GeneralHistorySearchModel()
        {
           GroupId = 0;
            DeviceID = "";
            ServerID = "";
            CommunicateID = "";
            StartDate = DateTime.Now.AddHours(-6).ToString("yyyy-MM-dd HH:mm:ss");
            EndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public int GroupId { set; get; }
        public string DeviceID { set; get; }
        public string ServerID { set; get; }
        public string CommunicateID { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public string Method { set; get; }
        public string Period { set; get; }
    }
    public class GeneralHistorySerieSearchModel
    {

        public GeneralHistorySerieSearchModel()
        {
            GroupId = 0;
            DeviceID = "";
            ServerID = "";
            CommunicateID = "";
            StartDate = DateTime.Now.AddHours(-6).ToString("yyyy-MM-dd HH:mm:ss");
            EndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public int GroupId { set; get; }
        public string DeviceID { set; get; }
        public string ServerID { set; get; }
        public string CommunicateID { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public string Method { set; get; }
        public string Period { set; get; }
        public string SerieIndex { set; get; }
    }
}