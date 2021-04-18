using Temporal.Net.InfluxDb.Models.Responses;
using ScadaWeb.IService;
using ScadaWeb.Model;
using ScadaWeb.Web.Areas.Scada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Temporal.WebDbAPI;

namespace ScadaWeb.Web.Areas.API.Controllers
{
    public class PageController : Controller
    {
        public WebInfluxDbManager mWebInfluxDbManager = new WebInfluxDbManager();
        public IIO_ServerService IO_Server { get; set; }
        public IIO_CommunicateService IO_CommunicateServer { get; set; }
        public IWellOrganizeService WellOrganizeServer { get; set; }
        public IIO_DeviceService IO_DeviceServer { get; set; }
        public IIO_ParaService IO_ParaServer { get; set; }
        public IOrganizeService OrganizeService { set; get; }


        public ISerieConfigService SerieServer
        {
            set;
            get;
        }
        public class ApiSerieConfigModel
        {
            public string IO_ID { set; get; }
            public string SerieName { set; get; }
            public string SerieTitle { get; set; }
            public string SerieWidth { get; set; }
            //"line","bar"
            public string SerieType { get; set; }
            public string SerieColor { get; set; }
            public string SymbolSize { get; set; }

            //'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
            public string SymbolType { get; set; }
            public string SymbolColor { get; set; }
            public string SymbolStep { get; set; }
            public string ShowSymbol { get; set; }
            public string ShowLegend { get; set; }
           
            public ApiSerieConfigModel()
            {
                SerieWidth = "2";
                SerieColor = "#FF0000";
                SymbolColor = "#0000FF";
                SymbolType = "circle";
                SymbolSize = "8";
                SymbolStep = "8";
                ShowSymbol = "true";
                ShowLegend = "true";

                IO_ID = "";
                SerieName = "";
                SerieType = "line";
            }


        }
        public sealed class ApiSerieConfig
        {
            public string IO_DEVICE_ID
            {

                set; get;
            }
            public List<ApiSerieConfigModel> Series { set; get; }
        }
        /// <summary>
        /// 根据曲线分类获取用户的曲线设置
        /// </summary>
        /// <param name="SerieClassify"></param>
        /// <param name="MyClassify"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ApiGetSerieConfig(ApiSerieConfig device)
        {


            List<SerieOption> _select = new List<SerieOption>();

            if (device.Series != null && device.IO_DEVICE_ID != "")
            {
                foreach (var item in device.Series)
                {

                    SerieOption _option = new SerieOption
                    {
                        id = item.SerieName.ToString(),
                        name = item.SerieTitle,
                        value = item.SerieName,
                        SerieConfig = new SerieConfigModel()
                        {
                            CreateTime = DateTime.Now,
                            CreateUserId = 0,
                            Id = 0,
                            SerieClassify = "",
                            SerieColor = item.SerieColor,
                            SerieName = item.SerieName,
                            SerieTitle = item.SerieTitle,
                            SerieType = item.SerieType,
                            SerieWidth = item.SerieWidth.ToString(),
                            ShowLegend = item.ShowLegend.ToString().ToLower(),
                            ShowSymbol = item.ShowSymbol.ToLower(),
                            SymbolColor = item.SymbolColor,
                            SymbolSize = item.SymbolSize,
                            SymbolStep = item.SymbolStep,
                            SymbolType = item.SymbolType

                        }
                    };
                    _select.Add(_option);
                }
            }
            return Json(_select, JsonRequestBehavior.AllowGet);
        }
        #region 历史数据查询模块
        /// <summary>
        /// 用户传入的所有device id列表,返回到界面的下来菜单
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult ApiGetDevice(string list = "0")
        {
            List<SelectOption> _select = new List<SelectOption>();
            if (list == null || list == "" || list == "0")
                return Json(null, JsonRequestBehavior.AllowGet);

            IEnumerable<IODeviceModel> Items = IO_DeviceServer.GetByWhere(" where IO_DEVICE_ID in('" + list.Replace(",", "','") + "')");




            if (Items != null && Items.Count() > 0)
            {
                foreach (var item in Items)
                {
                    IEnumerable<IOParaModel> ParaItems = IO_ParaServer.GetByWhere("where IO_DEVICE_ID='" + item.IO_DEVICE_ID + "'");
                    string IOPARANAMES = "";
                    string IOPARATITLES = "";
                    foreach (var para in ParaItems)
                    {
                        string label = para.IO_LABEL == "" ? para.IO_NAME : para.IO_LABEL;
                        IOPARANAMES += (IOPARANAMES == "" ? para.IO_NAME : "," + para.IO_NAME);
                        IOPARATITLES += (IOPARATITLES == "" ? label : "," + label);
                    }

                    SelectOption _option = new SelectOption
                    {
                        id = item.IO_DEVICE_ID.ToString(),
                        name = item.IO_DEVICE_LABLE,
                        value = item.IO_DEVICE_ID.ToString(),
                        value1 = item.IO_DEVICE_ID.ToString(),
                        value2 = item.IO_COMM_ID,
                        value3 = item.IO_SERVER_ID,
                        value4 = IOPARANAMES,
                        value5 = IOPARATITLES,

                    };
                    _select.Add(_option);
                }
            }
            return Json(_select, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取指定的设备的用户列表信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult ApiGetDeviceParasGridColumn(string id)
        {
            if (id == null || id == "")
                return Json(null, JsonRequestBehavior.AllowGet);

            IODeviceModel model = IO_DeviceServer.GetByWhere("where IO_DEVICE_ID='" + id + "'").First();
            if (model == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);

            }
            List<GridColumn> columns = new List<GridColumn>();

            if (model != null)
            {
                IEnumerable<IOParaModel> Items = IO_ParaServer.GetByWhere("where IO_DEVICE_ID='" + model.IO_DEVICE_ID + "'");
                string IOPARANAMES = "";
                string IOPARATITLES = "";
                foreach (var item in Items)
                {
                    string label = item.IO_LABEL == "" ? item.IO_NAME : item.IO_LABEL;
                    IOPARANAMES += (IOPARANAMES == "" ? item.IO_NAME : "," + item.IO_NAME);
                    IOPARATITLES += (IOPARATITLES == "" ? label : "," + label);
                }
                string[] fields = IOPARANAMES.Split(',');
                string[] titles = IOPARATITLES.Split(',');
                if (fields.Length == titles.Length)
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

            columns.Insert(0, new GridColumn()
            {
                field = "DateStampTime",
                title = "采集时间",
                width = "120"

            });
            return Json(columns, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public JsonResult ApiScadaHistory(GeneralHistoryModel model, PageInfo pageInfo)
        {
            string items = "[";
            IEnumerable<IOParaModel> paras = IO_ParaServer.GetByWhere(" where IO_DEVICE_ID='" + model.DeviceID.ToString() + "'");
            string namestr = "";
            foreach (var para in paras)
            {
                namestr += (namestr == "" ? para.IO_NAME : "," + para.IO_NAME);

            }

            string[] columns = namestr.Split(',');
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
        /// <summary>
        /// 通用历史数据查询模块
        /// </summary>
        /// <returns></returns>
        public ActionResult History()
        {

            GeneralHistoryModel model = new GeneralHistoryModel();
            return View(model);
        }
        #endregion

        #region

        public ActionResult HistorySeries()
        {

            GeneralHistoryModel model = new GeneralHistoryModel();
            return View(model);
        }
        public  class SeriesPara
        {
            public string serverid { set; get; }
            public string communicateid { set; get; }
            public string deviceid { set; get; }
          
            public int charttype { set; get; }
            public string sdate { set; get; }
            public string edate { set; get; }
            private int _pagesize = 1000;
            public int pagesize
            {
                set { _pagesize = value; }
                get { return _pagesize; }
            }
            private int _updatecycle = 120;
            public int updatecycle { set { _updatecycle = value; } get { return _updatecycle; } }

            public ApiSerieConfig serieConfig { set; get; }
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
        [HttpPost]
        public JsonResult ApiQueryHistorySeriesData(SeriesPara para)
        {
            ApiSerieConfig serieConfig = para.serieConfig;
            string serverid = para.serverid;
            string communicateid = para.communicateid;
            string deviceid = para.deviceid;
            int charttype = para.charttype;
            string sdate = para.sdate;
            string edate = para.edate;
            int pagesize = para.pagesize;
            return ApiQueryHistoryData(serieConfig, serverid, communicateid, deviceid,charttype, sdate, edate, pagesize);
        }

        private JsonResult ApiQueryHistoryData(ApiSerieConfig serieConfig,string serverid, string communicateid, string deviceid, int charttype = 1, string sdate = "", string edate = "",  int pagesize = 1000)
        {
          
         
            //获取对应的曲线配置信息

            List<ApiSerieConfigModel> Items = serieConfig.Series;


          
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

        #endregion

        #region
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
        [HttpPost]
        public JsonResult QueryRealSeriesData(SeriesPara para)
        {
            string serverid = para.serverid, communicateid = para.communicateid, deviceid = para.deviceid;
            int updatecycle = para.updatecycle;

            IEnumerable<Serie> realResult = mWebInfluxDbManager.DbQuery_Real(serverid, communicateid, deviceid, updatecycle).Result;
            List<string> fs = new List<string>();
            foreach(var s in para.serieConfig.Series)
            {
                fs.Add(s.SerieName);
            }
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

        #endregion
    }
}