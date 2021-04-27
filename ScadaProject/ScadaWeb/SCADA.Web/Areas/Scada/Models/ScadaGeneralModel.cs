using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScadaWeb.Web.Areas.Scada.Models
{
    public class ScadaTableSearchForm
    {
        public ScadaTableSearchForm()
        {
            GroupId = 0;
            DeviceID = "";
             ServerID = "";
             CommunicateID = "";
            StartDate = DateTime.Now.AddHours(-4).ToString("yyyy-MM-dd HH:mm:ss");
            EndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            IOPath = "";
            IOTitle = "";
        }
        public int  GroupId { set; get; }
        public string  DeviceID { set; get; }
        public string  ServerID { set; get; }
        public string CommunicateID { set; get; }
        public string  StartDate { set; get; }
        public string  EndDate { set; get; }
        /// <summary>
        /// 要获取的字段数据
        /// </summary>
        public string IOPath { set; get; }
        public string IOTitle { set; get; }

    }
    public class ScadaTableAlarmSearchForm
    {
        public ScadaTableAlarmSearchForm()
        {
            GroupId = 0;
            DeviceID = "";
            ServerID = "";
            CommunicateID = "";
            AlarmStartDate = DateTime.Now.AddHours(-4).ToString("yyyy-MM-dd HH:mm:ss");
            AlarmEndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            AlarmIOPath = "";
            AlarmIOTitle = "";
        }
        public int GroupId { set; get; }
        public string DeviceID { set; get; }
        public string ServerID { set; get; }
        public string CommunicateID { set; get; }
        public string AlarmStartDate { set; get; }
        public string AlarmEndDate { set; get; }
        /// <summary>
        /// 要获取的字段数据
        /// </summary>
        public string AlarmIOPath { set; get; }
        public string AlarmIOTitle { set; get; }

    }

    public class GeneralHistoryModel
    {
        public GeneralHistoryModel()
        {
            GroupId = 0;
            DeviceID = "";
            ServerID = "";
            CommunicateID = "";
            StartDate = DateTime.Now.AddHours(-4).ToString("yyyy-MM-dd HH:mm:ss");
            EndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public int GroupId { set; get; }
        public string DeviceID { set; get; }
        public string ServerID { set; get; }
        public string CommunicateID { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        /// <summary>
        /// 要获取的字段数据
        /// </summary>
        public string Fields { set; get; }
        public string SerieType { set; get; }
    }
    public class GeneralHistorySummaryModel
    {
        public GeneralHistorySummaryModel()
        {
            GroupId = 0;
            DeviceID = "";
            ServerID = "";
            CommunicateID = "";
            StartDate = DateTime.Now.AddHours(-4).ToString("yyyy-MM-dd HH:mm:ss");
            EndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Period = "10m";
            Method = "MEAN";
        }
        public string Method { set; get; }
        public string Period { set; get; }
        public int GroupId { set; get; }
        public string DeviceID { set; get; }
        public string ServerID { set; get; }
        public string CommunicateID { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        /// <summary>
        /// 要获取的字段数据
        /// </summary>
        public string Fields { set; get; }
    }
    public class GeneralRealModel
    {
        public GeneralRealModel()
        {
            GroupId = 0;
            DeviceID = "";
            ServerID = "";
            CommunicateID = "";
            StartDate = DateTime.Now.AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss");
            EndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public int GroupId { set; get; }
        public string DeviceID { set; get; }
        public string ServerID { set; get; }
        public string CommunicateID { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        /// <summary>
        /// 要获取的字段数据
        /// </summary>
        public string Fields { set; get; }
        public string SerieType { set; get; }
    }
}