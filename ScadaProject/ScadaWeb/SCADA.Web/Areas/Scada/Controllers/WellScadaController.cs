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

namespace ScadaWeb.Web.Areas.Scada.Controllers
{
    public class WellScadaController : BaseController
    {

        public WebInfluxDbManager mWebInfluxDbManager = new WebInfluxDbManager();

        public IWellService WellService { get; set; }
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

        public override ActionResult Index(int? id)
        {

            base.Index(id);
            return View();
        }
        [HttpGet]
        public JsonResult WellGridReal(WellModel model, PageInfo pageInfo)
        {
            long total = 0;
            ///返回单井IO配置表信息
            var wellList = WellService.GetListObjectByFilter(model, pageInfo,out total);
            List<InfluxDBQueryPara> devices = new List<InfluxDBQueryPara>();
            foreach (WellModel res in wellList)
            {
                InfluxDBQueryPara data = new InfluxDBQueryPara();
                data.IOCommunicateID = res.IO_CommunicateID;
                data.IODeviceID = res.IO_DeviceID;
                data.IOServerID = res.IO_ServerID;
                data.UpdateCycle = res.UpdateCycle;

                devices.Add(data);
            }
            IEnumerable<IEnumerable<Serie>> realResult = mWebInfluxDbManager.MultiQueryReal(devices);
            if (realResult != null)
            {
                foreach (WellModel pItem in wellList)
                {
                    try
                    {

                        var data = realResult.Where(s => s.Last().Name == mWebInfluxDbManager.RealDataTablePrefix + "_" + pItem.IO_ServerID + "_" + pItem.IO_DeviceID);
                        if (!data.IsEmpty() && data.Count() > 0 && data.Last().Count() > 0)
                        {
                            Serie s = data.First().First();
                            if (s != null)
                            {


                                for (int i = 0; i < s.Columns.Count; i++)
                                {
                                    try
                                    {
                                        if (s.Columns[i].ToLower() == "time")
                                        {
                                            pItem.DateStampTime = s.Values.First()[i].ToString();
                                            pItem.WellStatus = 1;
                                        }
                                        else if (!s.Columns[i].ToLower().Contains("_value"))
                                        {
                                            continue;
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_BPQPL.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_BPQPL = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_DDLY.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_DDLY = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_DJGZDL.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_DJGZDL = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_DJGZDY.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_DJGZDY = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_DJNJ.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_DJNJ = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_DYM.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_DYM = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_GTCC.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_GTCC = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_GTCC1.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_GTCC1 = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_GTZH.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_GTZH = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_JKTY.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_JKTY = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_LJCQL.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_LJCQL = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_LJCSL.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_LJCSL = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_QTWD.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_QTWD = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_SSCQL.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_SSCQL = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_SSCSL.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_SSCSL = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_SXDL.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_SXDL = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_SXDY.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_SXDY = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_SXGL.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_SXGL = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_XTYL.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_XTYL = s.Values.First()[i].ToString();
                                        }
                                        if (s.Columns[i].ToLower() == "field_" + pItem.IO_YDL.Trim().ToLower().ToString() + "_value")
                                        {
                                            pItem.IO_YDL = s.Values.First()[i].ToString();
                                        }


                                    }
                                    catch 
                                    {

                                    }
                                }
                            }
                            else
                            {
                                pItem.Clear();
                                pItem.DateStampTime = "";
                                pItem.WellStatus = 0;
                            }
                        }

                        else
                        {
                            pItem.Clear();
                            pItem.DateStampTime = "";
                            pItem.WellStatus = 0;
                        }

                    }
                    catch
                    {
                        pItem.Clear();
                        pItem.DateStampTime = "";
                        pItem.WellStatus = 0;
                    }
                }
            }


            var result = Pager.Paging(wellList, total);
            //读取以下10行的实时数据，从influxDB中读取
            return Json(result, JsonRequestBehavior.AllowGet);
        }
       

        [HttpGet]
        public JsonResult GetOrganizeTreeSelect()
        {
            var result = OrganizeService.GetOrganizeTreeSelect();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetWellType(string EnCode)
        {

            ItemsModel Item = ItemServer.GetItemByEnCode(EnCode);
            List<SelectOption> _select = new List<SelectOption>();


            IEnumerable<ItemsDetailModel> detailList = ItemDetailServer.GetByWhere(" where ItemId=" + Item.Id, null, " Id,ItemName");


            if (detailList != null && detailList.Count() > 0)
            {

                foreach (var detail in detailList)
                {
                    SelectOption _option = new SelectOption
                    {
                        id = detail.Id.ToString(),
                        name = detail.ItemName,
                         value= detail.Id.ToString()
                    };
                    _select.Add(_option);
                }
            }
            SelectOption nonopt = new SelectOption()
            {
                id = "0",
                name = "全部",
            };
            _select.Insert(0, nonopt);
            return Json(_select, JsonRequestBehavior.AllowGet);
        }
        //单井实时曲线

        public ActionResult SingleWellRealChart(string wellid = "0", int updatecycle = 120)
        {
            WellModel model = WellService.GetById(int.Parse(wellid));
            model.UpdateCycle = updatecycle;
            return View(model);
        }
        //单井历史曲线
        public ActionResult SingleWellHistoryChart(string wellid = "0", string sdate="",string edate="")
        {
            
            WellModel model = WellService.GetById(int.Parse(wellid));
     
            return View(model);
        }

        /// <summary>
        /// 获取曲线配置信息
        /// </summary>
        /// <param name="SerieClassify"></param>
        /// <returns></returns>
        
        public JsonResult GetSerieClassify(string SerieClassify)
        {

            IEnumerable<SerieConfigModel> Items = SerieServer.GetByWhere(" where SerieClassify='" + SerieClassify + "'");
            List<SerieOption> _select = new List<SerieOption>();


            if (Items != null && Items.Count() > 0)
            {

                foreach (var item in Items)
                {
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
        [HttpGet]
        public JsonResult GetOrganizeWells(int OrganizeId=0)
        {
         
            string oidList = OrganizeService.GetOrganizeNodeChildren(OrganizeId);
            IEnumerable<WellModel> Items = WellService.GetListObjectByOrganize(oidList);
            List<SelectOption> _select = new List<SelectOption>();


            if (Items != null && Items.Count() > 0)
            {

                foreach (var item in Items)
                {
                    SelectOption _option = new SelectOption
                    {
                        id = item.Id.ToString(),
                        name = item.WellName,
                        value = item.Id.ToString(),
                        value2 = item.UpdateCycle.ToString(),

                    };
                    _select.Add(_option);
                }
            }

            return Json(_select, JsonRequestBehavior.AllowGet);

        }
        public JsonResult WellSearch(string key="")
        {
            List<SelectOption> _select = new List<SelectOption>();
            IEnumerable<WellModel>  wells = WellService.GetByWhere(" where WellName like '%"+ key + "%'");
            foreach (var item in wells)
            {
                SelectOption _option = new SelectOption
                {
                    id = item.Id.ToString(),
                    name = item.WellName,
                    value = item.Id.ToString(),
                   
                };
                _select.Add(_option);
            }
            return Json(_select, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取实时数据
        /// </summary>
        /// <param name="wellId"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult QueryWellRealData(string wellid, string serverid, string communicateid, string deviceid, int updatecycle)
        {
        
            IEnumerable<Serie> realResult = mWebInfluxDbManager.DbQuery_Real(serverid, communicateid, deviceid, updatecycle).Result;
            WellModel pItem = WellService.GetById(int.Parse(wellid));
            pItem.UpdateCycle = updatecycle;
            var data = realResult;
            if (data != null && data.Count() > 0)
            {
                Serie s = data.First();
                if (s != null)
                {


                    for (int i = 0; i < s.Columns.Count; i++)
                    {
                        try
                        {
                            if (s.Columns[i].ToLower() == "time")
                            {
                                pItem.DateStampTime = s.Values.First()[i].ToString();
                                pItem.WellStatus = 1;
                            }
                            else if (!s.Columns[i].ToLower().Contains("_value"))
                            {
                                continue;
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_BPQPL.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_BPQPL = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_DDLY.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_DDLY = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_DJGZDL.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_DJGZDL = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_DJGZDY.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_DJGZDY = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_DJNJ.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_DJNJ = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_DYM.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_DYM = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_GTCC.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_GTCC = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_GTCC1.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_GTCC1 = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_GTZH.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_GTZH = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_JKTY.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_JKTY = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_LJCQL.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_LJCQL = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_LJCSL.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_LJCSL = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_QTWD.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_QTWD = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_SSCQL.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_SSCQL = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_SSCSL.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_SSCSL = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_SXDL.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_SXDL = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_SXDY.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_SXDY = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_SXGL.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_SXGL = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_XTYL.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_XTYL = s.Values.First()[i].ToString();
                            }
                            if (s.Columns[i].ToLower() == "field_" + pItem.IO_YDL.Trim().ToLower().ToString() + "_value")
                            {
                                pItem.IO_YDL = s.Values.First()[i].ToString();
                            }


                        }
                        catch 
                        {

                        }
                    }
                }
                else
                {
                    pItem.Clear();
                    pItem.DateStampTime = "";
                    pItem.WellStatus = 0;
                }
            }

            else
            {
                pItem.Clear();
                pItem.DateStampTime = "";
                pItem.WellStatus = 0;
            }


            //读取以下的实时数据，从influxDB中读取
            return Json(pItem, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取某一段时间的历史数据,实时曲线默认加载某一个时间段的数据
        /// </summary>
        /// <param name="wellid"></param>
        /// <param name="serverid"></param>
        /// <param name="communicateid"></param>
        /// <param name="deviceid"></param>
        /// <param name="sdate"></param>
        /// <param name="edate"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult QueryWellHistorySeriesDefaultData(string wellid, string serverid, string communicateid, string deviceid, string series = "",int charttype=1,string serieclassify="")
        {
            ///传递的曲线指标信息
            string serieindex = "'" + series.Trim().Replace(",", "','") + "'";
            //获取对应的曲线配置信息
            IEnumerable<SerieConfigModel> Items = SerieServer.GetByWhere(" where SerieName in(" + serieindex + ") and SerieClassify='"+ serieclassify + "'");
            WellModel pWell= WellService.GetById(int.Parse(wellid));
            ///初始化曲线对象
            EChartOption chartOption = new EChartOption();
            chartOption.communicateid = communicateid;
            chartOption.serverid = serverid;
            chartOption.deviceid = deviceid;
            chartOption.xAxis = new Axis[1];
            chartOption.xAxis[0] = new Axis();
            chartOption.xAxis[0].gridIndex = 1;
            chartOption.xAxis[0].type = "time";
            chartOption.xAxis[0].name = "时间";
            List<Axis> yaxis = new List<Axis>();
            int index = 0;
            string[] legend = new string[Items.Count()];
          
            foreach(var item in Items)
            {
                yaxis.Add(new Axis() { gridIndex=index, name= item.SerieTitle ,type="value"});
                legend[index] = item.SerieTitle;
                index++;
            }
            chartOption.legend.data = legend;
            chartOption.yAxis = yaxis.ToArray();
            //初始化对象结束

            string sdate = DateTime.Now.AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss");

            string edate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            chartOption.series = new Series[Items.Count()];
           
            InfluxDBHistoryResult realResult = mWebInfluxDbManager.DbQuery_History(serverid, communicateid, deviceid, Convert.ToDateTime(sdate), Convert.ToDateTime(edate), 1000, 1," ASC ");
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
                        chartOption.series[sindex].showSymbol = item.ShowSymbol=="1"?true:false;
                        chartOption.series[sindex].symbol = item.SymbolType;
                        chartOption.series[sindex].symbolSize = int.Parse(item.SymbolSize);
                        sindex++;
                    }
                    string[] axisData = new string[onedata.Values.Count];
                    //获取的数据按照时间先后
                    int dataindex = onedata.Values.Count()-1;
                 
                    foreach (var value in onedata.Values)
                    {
                        //获取采集时间
                        object objx = onedata.Values[dataindex][onedata.Columns.IndexOf("time")];
                        axisData[dataindex] = objx != null? objx.ToString():"";
                        //////////////////////////
                          sindex = 0;
                        foreach (var item in Items)
                        {

                            try
                            {


                                PropertyInfo name = pWell.GetType().GetProperty(item.SerieName);
                                string record = name.GetValue(pWell).ToString().ToLower();
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
        [HttpGet]
        public JsonResult QueryWellHistorySeriesData(string wellid, string serverid, string communicateid, string deviceid, string series = "", int charttype = 1,string sdate = "",string edate="", string serieclassify = "",int pagesize=1000)
        {
            ///传递的曲线指标信息
            string serieindex = "'" + series.Trim().Replace(",", "','") + "'";
            //获取对应的曲线配置信息
            IEnumerable<SerieConfigModel> Items = SerieServer.GetByWhere(" where SerieName in(" + serieindex + ") and SerieClassify='" + serieclassify + "'");

            WellModel pWell = WellService.GetById(int.Parse(wellid));
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
            if(sdate==null|| sdate=="")
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


                                PropertyInfo name = pWell.GetType().GetProperty(item.SerieName);
                                string record = name.GetValue(pWell).ToString().ToLower();
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
        ///////历史数据查询//////////
        public ActionResult WellHistory()
        {
            WellHistorySearchModel model = new WellHistorySearchModel();
            return View(model);
        }
        [HttpGet]
        public JsonResult WellGridHistory(WellHistorySearchModel model, PageInfo pageInfo)
        {
 
            List<WellModel> models = new List<WellModel>();
            if (model.WellID > 0)
            {
                WellModel pItem = WellService.GetById(model.WellID);

  
                string sdate = model.StartDate;

                string edate = model.EndDate;


                InfluxDBHistoryResult realResult = mWebInfluxDbManager.DbQuery_History(pItem.IO_ServerID, pItem.IO_CommunicateID, pItem.IO_DeviceID, Convert.ToDateTime(sdate), Convert.ToDateTime(edate), pageInfo.limit, pageInfo.page, " DESC ");
                foreach(var s in realResult.Seres)
                {
                    List<int> indexs = new List<int>();
                    for (int i = 0; i < s.Values.Count; i++)
                    {
                        WellModel well = new WellModel();
                        try
                        {
                             
                                int index = s.Columns.IndexOf("time");
                               
                                    object time = s.Values[i][index];
                            well.DateStampTime = time != null ? time.ToString() : "";
                            


                               index = -1;
                                 index = s.Columns.IndexOf("field_" + pItem.IO_BPQPL.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                    object v = s.Values[i][index];
                                well.IO_BPQPL = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_DDLY.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_DDLY = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_DJGZDL.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_DJGZDL = v != null ? v.ToString() : "";
                                }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_DJGZDY.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_DJGZDY = v != null ? v.ToString() : "";
                            }
                            index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_DJNJ.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_DJNJ = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_DYM.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_DYM = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_GTCC.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_GTCC = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_GTCC1.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_GTCC1 = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_GTZH.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_GTZH = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_JKTY.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_JKTY = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_LJCQL.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_LJCQL = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_LJCSL.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_LJCSL = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_QTWD.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_QTWD = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_SSCQL.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_SSCQL = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_SSCSL.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_SSCSL = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_SXDL.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_SXDL = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_SXDY.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_SXDY = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_SXGL.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_SXGL = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_XTYL.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_XTYL = v != null ? v.ToString() : "";
                                }
                                index = -1;
                                index = s.Columns.IndexOf("field_" + pItem.IO_YDL.Trim().ToLower().ToString() + "_value");
                                if (index >= 0)
                                {
                                object v = s.Values[i][index];
                                well.IO_YDL = v != null ? v.ToString() : "";
                                }
                            models.Add(well);
                        }
                        catch 
                        {

                        }

                    }
                }
                var result = Pager.Paging(models, realResult.RecordCount);
                //读取以下的实时数据，从influxDB中读取
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        ///////历史统计数据查询//////////
        public ActionResult WellHistorySummary()
        {
            WellHistorySearchModel model = new WellHistorySearchModel();
            return View(model);
        }
        [HttpGet]
        public JsonResult WellGridHistorySummary(WellHistorySearchModel model, PageInfo pageInfo)
        {

            List<WellModel> models = new List<WellModel>();
            if (model.WellID > 0)
            {
                WellModel pItem = WellService.GetById(model.WellID);
                string sdate = model.StartDate;
                string edate = model.EndDate;
                string returnFields = "  time";
                #region
                {
                    returnFields += "," + model.Method + "(field_" + pItem.IO_BPQPL.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_BPQPL.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_DDLY.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_DDLY.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_DJGZDL.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_DJGZDL.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_DJGZDY.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_DJGZDY.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_DJNJ.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_DJNJ.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_DYM.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_DYM.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_GTCC.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_GTCC.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_GTCC1.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_GTCC1.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_GTZH.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_GTZH.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_JKTY.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_JKTY.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_LJCQL.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_LJCQL.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_LJCSL.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_LJCSL.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_QTWD.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_QTWD.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_SSCQL.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_SSCQL.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_SSCSL.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_SSCSL.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_SXDL.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_SXDL.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_SXDY.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_SXDY.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_SXGL.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_SXGL.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_XTYL.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_XTYL.Trim().ToLower().ToString() + "_value";
                    returnFields += "," + model.Method + "(field_" + pItem.IO_YDL.Trim().ToLower().ToString() + "_value) as field_" + pItem.IO_YDL.Trim().ToLower().ToString() + "_value ";
                       }
                #endregion
                InfluxDBHistoryResult realResult = mWebInfluxDbManager.DbQuery_HistoryStatics(pItem.IO_ServerID, pItem.IO_CommunicateID, pItem.IO_DeviceID, Convert.ToDateTime(sdate), Convert.ToDateTime(edate), pageInfo.limit, pageInfo.page, " DESC ", model.Period, returnFields );
                foreach (var s in realResult.Seres)
                {
                    List<int> indexs = new List<int>();
                    for (int i = 0; i < s.Values.Count; i++)
                    {
                        WellModel well = new WellModel();
                        try
                        {

                            int index = s.Columns.IndexOf("time");

                            object time = s.Values[i][index];
                            well.DateStampTime = time != null ? time.ToString() : "";



                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_BPQPL.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_BPQPL = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_DDLY.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_DDLY = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_DJGZDL.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_DJGZDL = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_DJGZDY.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_DJGZDY = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_DJNJ.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_DJNJ = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_DYM.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_DYM = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_GTCC.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_GTCC = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_GTCC1.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_GTCC1 = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_GTZH.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_GTZH = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_JKTY.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_JKTY = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_LJCQL.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_LJCQL = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_LJCSL.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_LJCSL = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_QTWD.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_QTWD = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_SSCQL.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_SSCQL = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_SSCSL.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_SSCSL = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_SXDL.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_SXDL = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_SXDY.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_SXDY = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_SXGL.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_SXGL = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_XTYL.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_XTYL = v != null ? v.ToString() : "";
                            }
                            index = -1;
                            index = s.Columns.IndexOf("field_" + pItem.IO_YDL.Trim().ToLower().ToString() + "_value");
                            if (index >= 0)
                            {
                                object v = s.Values[i][index];
                                well.IO_YDL = v != null ? v.ToString() : "";
                            }
                            models.Add(well);
                        }
                        catch  
                        {

                        }

                    }
                }
                var result = Pager.Paging(models, realResult.RecordCount);
                //读取以下的实时数据，从influxDB中读取
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        ///////////////某个单井的历史数据查询////////////////

        public ActionResult SingleWellHistoryGrid(int wellid=0)
        {
            WellHistorySearchModel model = new WellHistorySearchModel();
            model.WellID = wellid;
 
            return View(model);
        }
        ///////////////某个单井的历史汇总数据查询////////////////

        public ActionResult SingleWellHistorySummary(int wellid = 0)
        {
            WellHistorySearchModel model = new WellHistorySearchModel();
            model.WellID = wellid;

            return View(model);
        }
        
        /////////////单井历史汇总曲线查询//////////////////
        [HttpGet]
        public JsonResult QueryWellHistorySummarySeriesData(string wellid, string serverid, string communicateid, string deviceid,string period, string method, string series = "", int charttype = 1, string sdate = "", string edate = "", string serieclassify = "", int pagesize = 1000)
        {
            ///传递的曲线指标信息
            string serieindex = "'" + series.Trim().Replace(",", "','") + "'";
            //获取对应的曲线配置信息
            IEnumerable<SerieConfigModel> Items = SerieServer.GetByWhere(" where SerieName in(" + serieindex + ") and SerieClassify='" + serieclassify + "'");

            WellModel pWell = WellService.GetById(int.Parse(wellid));
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
                returnFields += "," + method + "(field_" + pWell.IO_BPQPL.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_BPQPL.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_DDLY.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_DDLY.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_DJGZDL.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_DJGZDL.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_DJGZDY.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_DJGZDY.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_DJNJ.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_DJNJ.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_DYM.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_DYM.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_GTCC.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_GTCC.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_GTCC1.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_GTCC1.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_GTZH.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_GTZH.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_JKTY.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_JKTY.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_LJCQL.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_LJCQL.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_LJCSL.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_LJCSL.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_QTWD.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_QTWD.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_SSCQL.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_SSCQL.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_SSCSL.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_SSCSL.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_SXDL.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_SXDL.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_SXDY.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_SXDY.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_SXGL.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_SXGL.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_XTYL.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_XTYL.Trim().ToLower().ToString() + "_value";
                returnFields += "," + method + "(field_" + pWell.IO_YDL.Trim().ToLower().ToString() + "_value) as field_" + pWell.IO_YDL.Trim().ToLower().ToString() + "_value ";
            }
            #endregion
            InfluxDBHistoryResult realResult = mWebInfluxDbManager.DbQuery_HistoryStatics(pWell.IO_ServerID, pWell.IO_CommunicateID, pWell.IO_DeviceID, Convert.ToDateTime(sdate), Convert.ToDateTime(edate), pagesize, 1, " DESC ", period, returnFields);
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


                                PropertyInfo name = pWell.GetType().GetProperty(item.SerieName);
                                string record = name.GetValue(pWell).ToString().ToLower();
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
        /// <summary>
        /// 从单井实时监控中点击查看某个单井历史统计曲线
        /// </summary>
        /// <param name="wellid"></param>
        /// <returns></returns>
        public ActionResult SingleWellHistorySummaryChart(int wellid = 0)
        {
            WellModel model = WellService.GetById(wellid);
           
            return View(model);
        }
        /// <summary>
        /// 用户自由选择任意井进行专门的历史曲线查询模块
        /// </summary>
        /// <returns></returns>

       public ActionResult WellHistorySeries()
        {
            return View();
        }
        /// <summary>
        /// 用户自由选择任意井进行专门的历史统计曲线查询模块
        /// </summary>
        /// <returns></returns>
        public ActionResult WellHistorySummarySeries()
        {
            return View();
        }
        public ActionResult WellRealSeries()
        {
            return View();
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
        public JsonResult CustumQueryWellHistorySeriesData(string wellid, string series = "", int charttype = 1, string sdate = "", string edate = "", string serieclassify = "", int pagesize = 1000)
        {
            WellModel pWell = WellService.GetById(int.Parse(wellid));

            string serverid = pWell.IO_ServerID, communicateid = pWell.IO_CommunicateID, deviceid = pWell.IO_DeviceID;

            return QueryWellHistorySeriesData(wellid, serverid, communicateid, deviceid, series, charttype, sdate, edate, serieclassify, pagesize);
        }


        public JsonResult CustumQueryWellHistorySummarySeriesData(string wellid,string period, string method, string series = "", int charttype = 1, string sdate = "", string edate = "", string serieclassify = "", int pagesize = 1000)
        {
            WellModel pWell = WellService.GetById(int.Parse(wellid));

            string serverid = pWell.IO_ServerID, communicateid = pWell.IO_CommunicateID, deviceid = pWell.IO_DeviceID;

            return QueryWellHistorySummarySeriesData(wellid, serverid, communicateid, deviceid, period, method, series, charttype, sdate, edate, serieclassify, pagesize);
        }
        public JsonResult CustumQueryWellRealData(string wellid, string serverid, string communicateid, string deviceid, int updatecycle)
        {
            return QueryWellRealData(wellid, serverid, communicateid, deviceid, updatecycle);
        }
        public JsonResult CustumQueryWellHistorySeriesDefaultData(string wellid,string series = "", int charttype = 1, string serieclassify = "")
        {
            WellModel pWell = WellService.GetById(int.Parse(wellid));
            string serverid = pWell.IO_ServerID, communicateid = pWell.IO_CommunicateID, deviceid = pWell.IO_DeviceID;
            return QueryWellHistorySeriesDefaultData(wellid, serverid, communicateid, deviceid, series, charttype, serieclassify);
        }
    }
}