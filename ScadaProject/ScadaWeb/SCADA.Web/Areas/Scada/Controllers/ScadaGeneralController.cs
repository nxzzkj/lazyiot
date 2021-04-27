using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScadaWeb.Common;
using ScadaWeb.IService;
using ScadaWeb.Model;
using ScadaWeb.Web.Controllers;
using Temporal.WebDbAPI;
using Temporal.Net.InfluxDb.Models.Responses;
using System.Collections;
using ScadaWeb.Web.Areas.Scada.Models;
using System.Reflection;
using ScadaWeb.Service;
using System.Dynamic;
using Newtonsoft.Json;

namespace ScadaWeb.Web.Areas.Scada.Controllers
{
    /// <summary>
    /// 通用SCADA系统系统的控制模块
    /// </summary>
    public class ScadaGeneralController: BaseController
    {
        public WebInfluxDbManager mWebInfluxDbManager = new WebInfluxDbManager();

        public IWellService WellService { get; set; }
        public IIO_ServerService IO_Server { get; set; }
        public IIO_CommunicateService IO_CommunicateServer { get; set; }
        public IWellOrganizeService WellOrganizeServer { get; set; }
        public IIO_DeviceService IO_DeviceServer { get; set; }
        public IIO_ParaService IO_ParaServer { get; set; }
        public IOrganizeService OrganizeService { set; get; }
    
        public IIO_ParaService ParaService { set; get; }
        public IDeviceGroupService DeviceGroupService { set; get; }
        public IScadaGroupService GroupService { get; set; }
        public ISerieConfigService SerieServer
        {
            set;
            get;
        }
        [HttpGet]
        public JsonResult GetSerieClassify(string SerieClassify,string MyClassify)
        {

            IEnumerable<SerieConfigModel> Items = SerieServer.GetByWhere(" where SerieClassify='" + SerieClassify + "'");
            List<SerieOption> _select = new List<SerieOption>();
            string[] myios = MyClassify.Split(',');

            if (Items != null && Items.Count() > 0)
            {

                foreach (var item in Items)
                {
                    if (!myios.Contains(item.SerieName))
                        continue;
                    SerieOption _option = new SerieOption
                    {
                        id = item.SerieName.ToString(),
                        name = item.SerieTitle,
                        value = item.SerieName,
                        SerieConfig = item
                    };
                    _select.Add(_option);
                }
            }

            return Json(_select, JsonRequestBehavior.AllowGet);
        }
        public override ActionResult Index(int? id)
        {
            base.Index(id);
            GeneralHistoryModel model = new GeneralHistoryModel();
            return View(model);
        }
        /// <summary>
        /// 通用历史数据查询模块
        /// </summary>
        /// <returns></returns>
        public ActionResult GeneralHistory()
        {
           
            GeneralHistoryModel model = new GeneralHistoryModel();
            return View(model);
        }
        [HttpGet]
        public JsonResult GroupTreeListSelect()
        {
            var result = GroupService.GetGroupTreeSelect();
            return Json(result, JsonRequestBehavior.AllowGet);


        }
        [HttpGet]
        public JsonResult GetGroupDevice(int groupId)
        {
            string idlist = GroupService.GetGroupNodeChildren(groupId);

            IEnumerable<DeviceGroupModel> Items = DeviceGroupService.GetListByGroupId(idlist);
            List<SelectOption> _select = new List<SelectOption>();
           

            if (Items != null && Items.Count() > 0)
            {

                foreach (var item in Items)
                {
                    SelectOption _option = new SelectOption
                    {
                        id = item.Id.ToString(),
                        name = item.ALIASNAME,
                        value = item.Id.ToString(),
                        value1 = item.IO_DEVICE_ID.ToString(),
                        value2 = item.IO_COMM_ID,
                        value3 = item.IO_SERVER_ID,
                        value4 = item.IOPARANAMES,
                        value5 = item.SerieType,
                   
                    };
                    _select.Add(_option);
                }
            }
            string deviceids = "'1'";
            foreach(var item in Items)
            {
                deviceids += ",'" + item.IO_DEVICE_ID + "'";
            }
            var deviceItems = IO_DeviceServer.GetByWhere(" where  IO_DEVICE_ID in (" + deviceids + ")");
            foreach (var item in _select)
            {
                var searchs = deviceItems.Where(x => x.IO_DEVICE_ID.Trim().ToLower() == item.value1.Trim().ToLower());
                if(searchs.Count()>0)
                {
                    var sItem = searchs.First();
                    if(string.IsNullOrWhiteSpace(sItem.IO_DEVICE_UPDATECYCLE))
                    {
                        item.value6 = "120";
                    }
                    else
                    {
                        item.value6 = sItem.IO_DEVICE_UPDATECYCLE;
                    }
                   
                }
            }
  
            return Json(_select, JsonRequestBehavior.AllowGet);


       


        }

        [HttpGet]
        public JsonResult GetDeviceColumns(int id)
        {


            DeviceGroupModel  model = DeviceGroupService.GetById(id);
      
            List<GridColumn> columns = new List<GridColumn>();

            if (model != null)
            {
                string[] fields = model.IOPARANAMES.Split(',');
                string[] titles = model.IOPARATITLES.Split(',');
                if(fields.Length== titles.Length)
                {
                    for (int i = 0; i < fields.Length; i++)
                    {
                        GridColumn _option = new GridColumn
                        {
                            field = fields[i],
                            title = titles[i],
                            width = "120"


                        };
                        columns.Add(_option);

                    }
                }
               
                
            }

            columns.Insert(0, new GridColumn() {
                field = "DateStampTime",
                title = "采集时间",
                width = "120"

            });
            return Json(columns, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public JsonResult GeneralGridHistory(GeneralHistoryModel model, PageInfo pageInfo)
        {
     string items = "[";
        

            string[] columns = model.Fields.Split(',');
            if (!string.IsNullOrWhiteSpace(model.DeviceID))
            {
                string sdate = model.StartDate;
                string edate = model.EndDate;
                InfluxDBHistoryResult realResult = mWebInfluxDbManager.DbQuery_History(model.ServerID, model.CommunicateID, model.DeviceID, Convert.ToDateTime(sdate), Convert.ToDateTime(edate), pageInfo.limit, pageInfo.page, " DESC ");
                foreach (var s in realResult.Seres)
                {
          
                    List<int> indexs = new List<int>();
                    for (int i = 0; i < s.Values.Count; i++)
                    {
                        string jsonrow = "";
                        int index = s.Columns.IndexOf("time");
                        object time = s.Values[i][index];
                        jsonrow += "{";
                        jsonrow += "\"DateStampTime\":\""+ (time != null ? time.ToString() : "") + "\"";
                      
                        foreach (string str in columns)
                        {
                            try
                            {

                                index = -1;
                                index = s.Columns.IndexOf("field_" + str.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                    object v = s.Values[i][index];
                                 
                                    jsonrow += ",\""+ str + "\":\"" + (v != null ? v.ToString() : "") + "\"";
                                }

                            }
                            catch
                            {
                                continue;
                            }
                        }
                        jsonrow += "},";

                        items += jsonrow;
              
                }
            }
                items += "]";
                var result = Pager.Paging2(items, realResult.RecordCount);
                //读取以下的实时数据，从influxDB中读取
                return Json(result, "application/text",JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = Pager.Paging2("", 0);
                return Json(result, "application/text", JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 通用历史数据查询模块
        /// </summary>
        /// <returns></returns>
        public ActionResult GeneralHistorySummary()
        {

            GeneralHistorySummaryModel model = new GeneralHistorySummaryModel();
            return View(model);
        }
        /// <summary>
        /// 通用实时曲线页面
        /// </summary>
        /// <returns></returns>
        public ActionResult GeneralRealSeries()
        {
            GeneralRealModel model = new GeneralRealModel();


            return View(model);
        }
        
        [HttpGet]
        public JsonResult GeneralGridHistorySummary(GeneralHistorySummaryModel model, PageInfo pageInfo)
        {
            string items = "[";


            string[] columns = model.Fields.Split(',');
            if (!string.IsNullOrWhiteSpace(model.DeviceID))
            {
                string sdate = model.StartDate;
                string edate = model.EndDate;
      
                string returnFields = "  time";
                #region
                {
                    for (int i=0;i< columns.Length;i++)
                    {
                        returnFields += "," + model.Method + "(field_" + columns[i].Trim().ToLower().ToString() + "_value) as field_" + columns[i].Trim().ToLower().ToString() + "_value";
                    }
                  
                
                }
                #endregion
                InfluxDBHistoryResult realResult = mWebInfluxDbManager.DbQuery_HistoryStatics(model.ServerID, model.CommunicateID, model.DeviceID, Convert.ToDateTime(sdate), Convert.ToDateTime(edate), pageInfo.limit, pageInfo.page, " DESC ", model.Period, returnFields);
                foreach (var s in realResult.Seres)
                {

                    List<int> indexs = new List<int>();
                    for (int i = 0; i < s.Values.Count; i++)
                    {
                        string jsonrow = "";
                        int index = s.Columns.IndexOf("time");
                        object time = s.Values[i][index];
                        jsonrow += "{";
                        jsonrow += "\"DateStampTime\":\"" + (time != null ? time.ToString() : "") + "\"";

                        foreach (string str in columns)
                        {
                            try
                            {

                                index = -1;
                                index = s.Columns.IndexOf("field_" + str.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                    object v = s.Values[i][index];

                                    jsonrow += ",\"" + str + "\":\"" + (v != null ? v.ToString() : "") + "\"";
                                }

                            }
                            catch
                            {
                                continue;
                            }
                        }
                        jsonrow += "},";

                        items += jsonrow;

                    }
                }
                items += "]";
                var result = Pager.Paging2(items, realResult.RecordCount);
                //读取以下的实时数据，从influxDB中读取
                return Json(result, "application/text", JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = Pager.Paging2("", 0);
                return Json(result, "application/text", JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 通用历史曲线查询模块
        /// </summary>
        /// <returns></returns>
        public ActionResult GeneralHistorySeries()
        {
            GeneralHistoryModel model = new GeneralHistoryModel();
            return View(model);
        }
        public ActionResult GeneralHistorySummarySeries()
        {
            GeneralHistoryModel model = new GeneralHistoryModel();
            return View(model);
        }
        
        /// <summary>
        /// 用户自由选择任意井进行专门的历史曲线查询模块的实际查询数据的功能
        /// </summary>
        /// <param name="wellid"></param>
        /// <param name="series"></param>
        /// <param name="charttype"></param>
        /// <param name="sdate"></param>
        /// <param name="edate"></param>
        /// <param name="serieclassify"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult QueryHistorySeriesData(string groupid,string serverid,string communicateid,string deviceid,string fields="", string series = "", int charttype = 1, string sdate = "", string edate = "", string serieclassify = "", int pagesize = 1000)
        {
            return QueryHistoryData(groupid, serverid, communicateid, deviceid, fields, series, charttype, sdate, edate, serieclassify, pagesize);
        }
      
        private JsonResult QueryHistoryData(string groupid, string serverid, string communicateid, string deviceid, string fields = "", string series = "", int charttype = 1, string sdate = "", string edate = "", string serieclassify = "", int pagesize = 1000)
        {
            string[] myfields = fields.Split(',');
            ///传递的曲线指标信息
            string serieindex = "'" + series.Trim().Replace(",", "','") + "'";
            //获取对应的曲线配置信息
            IEnumerable<SerieConfigModel> allItems = SerieServer.GetByWhere(" where SerieName in(" + serieindex + ") and SerieClassify='" + serieclassify + "'");
            List<SerieConfigModel> Items = new List<SerieConfigModel>();
            foreach(var item in allItems)
            {
                if (myfields.Contains(item.SerieName))
                {
                    Items.Add(item);
                }
            }
            DeviceGroupModel pWell = DeviceGroupService.GetById(int.Parse(groupid));
            ///初始化曲线对象
            EChartOption chartOption = new EChartOption();
            chartOption.xAxis = new Axis[1];
            chartOption.xAxis[0] = new Axis();
            chartOption.xAxis[0].gridIndex = 1;
            chartOption.xAxis[0].type = "time";
            chartOption.xAxis[0].name = "时间";
            List<Axis> yaxis = new List<Axis>();
            int index = 0;
            string[] legend = new string[Items.Count()];

            foreach (var item in Items)
            {
                yaxis.Add(new Axis() { gridIndex = index, name = item.SerieTitle, type = "value" });
                legend[index] = item.SerieTitle;
                index++;
            }
            chartOption.legend.data = legend;
            chartOption.yAxis = yaxis.ToArray();
            //初始化对象结束
            if (sdate == null || sdate == "")
                sdate = DateTime.Now.AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss");
            if (edate == null || edate == "")
                edate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            chartOption.series = new Series[Items.Count()];

            InfluxDBHistoryResult realResult = mWebInfluxDbManager.DbQuery_History(serverid, communicateid, deviceid, Convert.ToDateTime(sdate), Convert.ToDateTime(edate), 10000, 1, " ASC ");
            if (realResult != null)
            {

                var datas = realResult.Seres;
                if (datas != null && datas.Count() > 0)
                {
                    var onedata = datas.First();
                    int sindex = 0;
                    foreach (var item in Items)
                    {
                        chartOption.series[sindex] = new Series();

                        chartOption.series[sindex].name = item.SerieTitle;
                        chartOption.series[sindex].lineStyle.color = item.SerieColor;
                        chartOption.series[sindex].lineStyle.width = int.Parse(item.SerieWidth);
                        chartOption.series[sindex].itemStyle = null;
                        chartOption.series[sindex].data = new double[onedata.Values.Count];
                        chartOption.series[sindex].type = item.SerieType;
                        chartOption.series[sindex].showSymbol = item.ShowSymbol == "1" ? true : false;
                        chartOption.series[sindex].symbol = item.SymbolType;
                        chartOption.series[sindex].symbolSize = int.Parse(item.SymbolSize);
                        sindex++;
                    }
                    string[] axisData = new string[onedata.Values.Count];
                    //获取的数据按照时间先后
                    int dataindex = onedata.Values.Count() - 1;

                    foreach (var value in onedata.Values)
                    {
                        //获取采集时间
                        object objx = onedata.Values[dataindex][onedata.Columns.IndexOf("time")];
                        axisData[dataindex] = objx != null ? objx.ToString() : "";
                        //////////////////////////
                        sindex = 0;
                        foreach (var item in Items)
                        {

                            try
                            {


                             
                                int recordindex = onedata.Columns.IndexOf("field_" + item.SerieName.Trim().ToLower() + "_value");
                                if (recordindex >= 0)
                                {
                                    object objy = onedata.Values[dataindex][recordindex];
                                    chartOption.series[sindex].data[dataindex] = Convert.ToDouble(objy);
                                    chartOption.series[sindex].id = item.SerieName;
                                }


                            }
                            catch
                            {

                            }

                            sindex++;
                        }
                        dataindex--;
                    }
                    chartOption.xAxis[0].data = axisData;//设置x轴数据，time格式的数据必须在Axis轴上进行设置


                }


            }

            //读取以下的实时数据，从influxDB中读取
            return Json(chartOption, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult QueryHistorySummarySeriesData(string groupid, string serverid, string communicateid, string deviceid, string period, string method, string fields = "", string series = "", int charttype = 1, string sdate = "", string edate = "", string serieclassify = "", int pagesize = 1000)
        {
 

            return QueryHistorySummaryData(groupid, serverid, communicateid, deviceid, period, method, fields,series, charttype, sdate, edate, serieclassify, pagesize);
        }
        private JsonResult QueryHistorySummaryData(string groupid, string serverid, string communicateid, string deviceid, string period, string method, string fields = "", string series = "", int charttype = 1, string sdate = "", string edate = "", string serieclassify = "", int pagesize = 1000)
        {
            ///传递的曲线指标信息
            string serieindex = "'" + series.Trim().Replace(",", "','") + "'";
            string[] myfields = fields.Split(',');
            //获取对应的曲线配置信息
            IEnumerable<SerieConfigModel> allItems = SerieServer.GetByWhere(" where SerieName in(" + serieindex + ") and SerieClassify='" + serieclassify + "'");
            List<SerieConfigModel> Items = new List<SerieConfigModel>();
            foreach (var item in allItems)
            {
                if (myfields.Contains(item.SerieName))
                {
                    Items.Add(item);
                }
            }
            DeviceGroupModel pWell = DeviceGroupService.GetById(int.Parse(groupid));
            ///初始化曲线对象
            EChartOption chartOption = new EChartOption();
            chartOption.xAxis = new Axis[1];
            chartOption.xAxis[0] = new Axis();
            chartOption.xAxis[0].gridIndex = 1;
            chartOption.xAxis[0].type = "time";
            chartOption.xAxis[0].name = "时间";
            List<Axis> yaxis = new List<Axis>();
            int index = 0;
            string[] legend = new string[Items.Count()];

            foreach (var item in Items)
            {
                yaxis.Add(new Axis() { gridIndex = index, name = item.SerieTitle, type = "value" });
                legend[index] = item.SerieTitle;
                index++;
            }
            chartOption.legend.data = legend;
            chartOption.yAxis = yaxis.ToArray();
            //初始化对象结束
            if (sdate == null || sdate == "")
                sdate = DateTime.Now.AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss");
            if (edate == null || edate == "")
                edate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            chartOption.series = new Series[Items.Count()];
            string returnFields = "  time";
            #region
            {
                foreach(var item in Items)
                {
                    returnFields += "," + method + "(field_" + item.SerieName.Trim().ToLower().ToString() + "_value) as field_" + item.SerieName.Trim().ToLower().ToString() + "_value";
                }
             
                
            }
            #endregion
            InfluxDBHistoryResult realResult = mWebInfluxDbManager.DbQuery_HistoryStatics(serverid, communicateid, deviceid, Convert.ToDateTime(sdate), Convert.ToDateTime(edate), pagesize, 1, " DESC ", period, returnFields);
            if (realResult != null)
            {

                var datas = realResult.Seres;
                if (datas != null && datas.Count() > 0)
                {
                    var onedata = datas.First();
                    int sindex = 0;
                    foreach (var item in Items)
                    {
                        chartOption.series[sindex] = new Series();

                        chartOption.series[sindex].name = item.SerieTitle;
                        chartOption.series[sindex].lineStyle.color = item.SerieColor;
                        chartOption.series[sindex].lineStyle.width = int.Parse(item.SerieWidth);
                        chartOption.series[sindex].itemStyle = null;
                        chartOption.series[sindex].data = new double[onedata.Values.Count];
                        chartOption.series[sindex].type = item.SerieType;
                        chartOption.series[sindex].showSymbol = item.ShowSymbol == "1" ? true : false;
                        chartOption.series[sindex].symbol = item.SymbolType;
                        chartOption.series[sindex].symbolSize = int.Parse(item.SymbolSize);
                        sindex++;
                    }
                    string[] axisData = new string[onedata.Values.Count];
                    //获取的数据按照时间先后
                    int dataindex = onedata.Values.Count() - 1;

                    foreach (var value in onedata.Values)
                    {
                        //获取采集时间
                        object objx = onedata.Values[dataindex][onedata.Columns.IndexOf("time")];
                        axisData[dataindex] = objx != null ? objx.ToString() : "";
                        //////////////////////////
                        sindex = 0;
                        foreach (var item in Items)
                        {

                            try
                            {


                         
                                string record = item.SerieName.ToString().ToLower();
                                int recordindex = onedata.Columns.IndexOf("field_" + record + "_value");
                                if (recordindex >= 0)
                                {
                                    object objy = onedata.Values[dataindex][recordindex];
                                    chartOption.series[sindex].data[dataindex] = Convert.ToDouble(objy);
                                    chartOption.series[sindex].id = item.SerieName;
                                }


                            }
                            catch 
                            {

                            }

                            sindex++;
                        }
                        dataindex--;
                    }
                    chartOption.xAxis[0].data = axisData;//设置x轴数据，time格式的数据必须在Axis轴上进行设置


                }


            }

            //读取以下的实时数据，从influxDB中读取
            return Json(chartOption, JsonRequestBehavior.AllowGet);
        }
      
      public sealed class PointData
        {
            public string Value = "";
            public string Name = "";
 
            public int Status = 0;
        } 
        public sealed class RealSerieData
        {
            public string Date = "";
   
            public int Status = 0;
            public List<PointData> Data = new List<PointData>();
        } 
        /// <summary>
        /// 获取曲线实时数据
        /// </summary>
        /// <param name="wellId"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult QueryRealSeriesData( string serverid, string communicateid, string deviceid, int updatecycle, string fields = "")
        {

            IEnumerable<Serie> realResult = mWebInfluxDbManager.DbQuery_Real(serverid, communicateid, deviceid, updatecycle).Result;
            string[] fs = fields.Split(',');
            RealSerieData resDatas = new RealSerieData();
            var data = realResult;
            if (data != null && data.Count() > 0)
            {
                Serie s = data.First();
                if (s != null)
                {

                    if (s.Values.First().Count > 0)
                    {
                        int timeindex = s.Columns.IndexOf("time");
                        resDatas.Date = s.Values.First()[timeindex].ToString();
                        foreach (string ioName in fs)
                        {
                            string record = ioName.ToString().ToLower();
                            int recordindex = s.Columns.IndexOf("field_" + record + "_value");
                        
                            if (recordindex >= 0)
                            {
                                PointData rdata = new PointData();
                             
                                object objy = s.Values.First()[recordindex];
                                rdata.Value = objy == null ? "" : objy.ToString();
                                rdata.Name = ioName;
                                resDatas.Data.Add(rdata);
                            }
                            else
                            {
                                PointData rdata = new PointData();
                       
                                rdata.Value = "";
                                rdata.Name = ioName;
                                resDatas.Data.Add(rdata);
                            }
                          
                        }

                    }
                }
            }


            //读取以下的实时数据，从influxDB中读取
            return Json(resDatas, JsonRequestBehavior.AllowGet);
        }
    }
}