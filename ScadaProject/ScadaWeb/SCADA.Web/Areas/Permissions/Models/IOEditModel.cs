using ScadaWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScadaWeb.Web.Areas.Permissions.Models
{
    public class TableRealModel
    {
        public int TableId
        { set; get; }
        public TableRealModel()
        {
            colwidthmodels = "";
            Title = "";
            RowNum = 100;
            SDate = DateTime.Now.AddHours(-6).ToString("yyyy-MM-dd 00:00:00");
            EDate = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
        }
        public string colwidthmodels { set; get; }
        public string coltitlesmodels { set; get; }
        public string Title
        { set; get; }
        public int RowNum
        {
            set; get;
        }
        public string AllUserJson = "";
        public string PrivateUserJson = "";
        public string FieldIOPaths { set; get; }
        public string FieldColors { set; get; }
        public string FieldFontSizes { set; get; }
        public string FieldBackColors { set; get; }
        public string FieldWidths { set; get; }
        public string FieldWeights { set; get; }
        public ScadaTableModel ScadaTable { set; get; }
        /// <summary>
        /// 设备列表
        /// </summary>
        public List<DeviceGroupModel> Devices { set; get; }
        public string JsonDevices { set; get; }
        public string SDate { set; get; }
        public string EDate { set; get; }

    }
    public class TableEditModel
    {
        public int TableId
        { set; get; }
        public TableEditModel()
        {
            colwidthmodels = "";
            Title = "";
            RowNum = 100;
        }
        public string colwidthmodels { set; get; }
        public string coltitlesmodels { set; get; }
        public string Title
        { set; get; }
        public int RowNum
        {
            set;get;
        }
        public string AllUserJson = "";
        public string PrivateUserJson = "";
        public string FieldIOPaths { set; get; }
        public string FieldColors { set; get; }
        public string FieldFontSizes { set; get; }
        public string FieldBackColors { set; get; }
        public string FieldWidths { set; get; }
        public string FieldWeights { set; get; }
        public ScadaTableModel ScadaTable { set; get; }

    }

    public class IOEditModel
    {
        public IOEditModel()
        {
            Column = "";
            Value = "";
            GroupId = "";
            ServerID = "";
            CommunicateID = "";
            DeviceID = "";
            IOID = "";
            UnitType = "4";
            BackColor = "#ffffff";
            FontColor = "#000000";
            FontWeight = "normal";
            UpdateCycle = 120;

        }
   
     

        public string Column { set; get; }
        public string Value { set; get; }
        public string IOPath { set; get; }
        public string GroupId { set; get; }
        public string ServerID { set; get; }
        public string CommunicateID { set; get; }
        public string DeviceID { set; get; }
        public string IOID { set; get; }
        public string UnitType { set; get; }
        public string FontColor { set; get; }
        public string BackColor { set; get; }
        public string FontWeight { set; get; }
        public int UpdateCycle { set; get; }
        public string Id
        { set; get; }
    }
}