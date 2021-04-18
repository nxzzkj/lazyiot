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
using ScadaWeb.Web.Areas.Permissions.Models;
using System.Web.Script.Serialization;

namespace ScadaWeb.Web.Areas.Scada.Controllers
{
    /// <summary>
    /// 通用SCADA系统系统的控制模块
    /// </summary>
    public class ScadaTableController : BaseController
    {
        public WebInfluxDbManager mWebInfluxDbManager = new WebInfluxDbManager();

        public IIO_ServerService IO_Server { get; set; }
        public IIO_CommunicateService IO_CommunicateServer { get; set; }

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

        public IScadaTableService TableService { set; get; }
        public IScadaTableRowsService TableRowService { set; get; }
        public IScadaTableUserRoleService TableUserRoleService { set; get; }
        public IUserService UserService { get; set; }
        public IScadaTableService ScadaTableService { set; get; }
        public override ActionResult Index(int? id)
        {


            string para = Request.QueryString["id"].Split('?')[0];
            string idstr = Request.QueryString["id"].Split('?')[1].Split('=')[1];
            base.Index(int.Parse(idstr));



            var rowModel = TableRowService.GetByWhere("where TableId=" + int.Parse(para)).First();
            var tableUsers = TableUserRoleService.GetByWhere("where TableId=" + int.Parse(para));
            var tableModel = TableService.GetById(int.Parse(para));
            TableRealModel model = new TableRealModel();
            model.TableId = int.Parse(para);
            model.Title = tableModel != null ? tableModel.Title : "";
            model.RowNum = tableModel != null ? tableModel.RowNum : 100;

            var AllUsers = UserService.GetAll();
            model.AllUserJson = JsonConvert.SerializeObject(AllUsers);//获取当前的所有用户
            List<UserModel> privatemodels = new List<UserModel>();
            foreach (var item in tableUsers)
            {
                var whereItems = AllUsers.Where(x => x.Id == item.UserId);
                if (whereItems.Count() > 0)
                {
                    var extItem = whereItems.First();
                    privatemodels.Add(extItem);
                }

            }
            model.PrivateUserJson = JsonConvert.SerializeObject(privatemodels);//获取当前的所有用户
                                                                               //获取表的列宽度
            List<string> fontwidthmodels = new List<string>();
            if (tableModel != null && !string.IsNullOrWhiteSpace(tableModel.ColimnWidths))
            {
                fontwidthmodels = tableModel.ColimnWidths.Split(',').ToList();
            }
            else
            {
                for (int i = 0; i < 26; i++)
                {
                    fontwidthmodels.Add("120");
                }

            }

            model.colwidthmodels = JsonConvert.SerializeObject(fontwidthmodels);
            //获取列标题
            //获取表的列宽度
            List<string> columntitlemodels = new List<string>();
            if (tableModel != null && !string.IsNullOrWhiteSpace(tableModel.ColumnTitles))
            {
                columntitlemodels = tableModel.ColumnTitles.Split(',').ToList();
            }
            else
            {
                for (int i = 0; i < 26; i++)
                {
                    columntitlemodels.Add(ExcelConvert.ToName(i));
                }

            }
            model.coltitlesmodels = JsonConvert.SerializeObject(columntitlemodels);
            model.ScadaTable = tableModel;
            model.FieldBackColors = rowModel.FieldBackColors;
            model.FieldColors = rowModel.FieldColors;
            model.FieldFontSizes = rowModel.FieldFontSizes;
            model.FieldIOPaths = rowModel.FieldIOPaths;
            model.FieldWeights = rowModel.FieldWeights;
            ///获取设备列表
            JavaScriptSerializer js = new JavaScriptSerializer();   //实例化一个能够序列化数据的类
            List<ExcelModel> excelModels = js.Deserialize<List<ExcelModel>>(rowModel.FieldIOPaths);
            List<DeviceGroupModel> deviceAllModels = DeviceGroupService.GetAll().ToList();
            List<DeviceGroupModel> deviceModels = new List<DeviceGroupModel>();
            for (int i = 0; i < excelModels.Count; i++)
            {
                PropertyInfo[] properties = excelModels[i].GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                if (properties.Length <= 0)
                {
                    continue;
                }
                foreach (PropertyInfo item in properties)
                {
                    string name = item.Name;
                    object value = item.GetValue(excelModels[i], null);
                    if (value != null && value.ToString() != "")
                    {
                        if (value.ToString().Split('/').Length >= 8)
                        {
                            try
                            {


                                DeviceGroupModel groupDevice = new DeviceGroupModel();
                                groupDevice.GroupId = int.Parse(value.ToString().Split('/')[1]);
                                groupDevice.IO_SERVER_ID = value.ToString().Split('/')[2];
                                groupDevice.IO_COMM_ID = value.ToString().Split('/')[3];
                                groupDevice.IO_DEVICE_ID = value.ToString().Split('/')[4];
                                groupDevice.UpdateCycle = int.Parse(value.ToString().Split('/')[6]);
                                groupDevice.CurrentIO = value.ToString().Split('/')[5];//当前的iO
                                DeviceGroupModel exitItem = deviceAllModels.Find(x => x.IO_SERVER_ID == groupDevice.IO_SERVER_ID && x.IO_COMM_ID == groupDevice.IO_COMM_ID && x.IO_DEVICE_ID == groupDevice.IO_DEVICE_ID && x.GroupId == groupDevice.GroupId);
                                if (exitItem != null)
                                { if (!deviceModels.Exists(x => x.IO_SERVER_ID == groupDevice.IO_SERVER_ID && x.IO_COMM_ID == groupDevice.IO_COMM_ID && x.IO_DEVICE_ID == groupDevice.IO_DEVICE_ID && x.GroupId == groupDevice.GroupId))
                                    {
                                        exitItem.CurrentIO = groupDevice.CurrentIO;
                                        deviceModels.Add(exitItem);
                                    }
                                }
                            }
                            catch
                            {
                                continue;
                            }
                        }

                    }
                }



            }
            model.Devices = deviceModels;
            model.JsonDevices = js.Serialize(deviceModels);
            return View(model);


        }
        public sealed class JsonExcel
        {
            public List<ExcelModel> models { set; get; }
            public List<DeviceGroupModel> devices { set; get; }
            public string CurrentIOID { set; get; }
            public string CurrentServerID { set; get; }
            public string CurrentCommunicateID { set; get; }
            public string CurrentDeviceID { set; get; }
            public string CurrentGroupID { set; get; }
        }
        public sealed class CurrentPoint
        {
            public string IO { set; get; }
            public string Value { set; get; }
            public string Time { set; get; }
            public string Name { set; get; }
        }
        /// <summary>
        /// 获取实时数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult LoadRealTable(JsonExcel excelModels)
        {
            CurrentPoint current = new CurrentPoint();
            current.IO = excelModels.CurrentIOID;

            List<DeviceGroupModel> deviceModels = excelModels.devices;

            //读取所有的实时数据，并加载 mWebInfluxDbManager
            List<InfluxDBQueryPara> devices = new List<InfluxDBQueryPara>();
            foreach (DeviceGroupModel res in deviceModels)
            {
                InfluxDBQueryPara data = new InfluxDBQueryPara();
                data.IOCommunicateID = res.IO_COMM_ID;
                data.IODeviceID = res.IO_DEVICE_ID;
                data.IOServerID = res.IO_SERVER_ID;
                data.UpdateCycle = res.UpdateCycle;
                devices.Add(data);
            }

            IEnumerable<IEnumerable<Serie>> realResult = mWebInfluxDbManager.MultiQueryReal(devices);
            #region 获取当前选择的Io点的实时值
            if (!string.IsNullOrWhiteSpace(excelModels.CurrentCommunicateID) && !string.IsNullOrWhiteSpace(excelModels.CurrentDeviceID) && !string.IsNullOrWhiteSpace(excelModels.CurrentServerID) && !string.IsNullOrWhiteSpace(excelModels.CurrentIOID) && !string.IsNullOrWhiteSpace(excelModels.CurrentGroupID))
            {
                string IO_SERVER_ID = excelModels.CurrentServerID;
                string IO_COMM_ID = excelModels.CurrentCommunicateID;
                string IO_DEVICE_ID = excelModels.CurrentDeviceID;
                string IO_ID = excelModels.CurrentIOID;
                string GroupId = excelModels.CurrentGroupID;
                int devIndex = devices.FindIndex(x => x.IOServerID == IO_SERVER_ID && x.IOCommunicateID == IO_COMM_ID && x.IODeviceID == IO_DEVICE_ID);
                DeviceGroupModel selItem = deviceModels.Find(x => x.IO_SERVER_ID == IO_SERVER_ID && x.IO_COMM_ID == IO_COMM_ID && x.IO_DEVICE_ID == IO_DEVICE_ID && x.GroupId.ToString() == GroupId);
                List<string> paranames = selItem.IOPARANAMES.Split(',').ToList();
                List<string> ioids = selItem.IOPARAS.Split(',').ToList();
                List<string> titles = selItem.IOPARATITLES.Split(',').ToList();
                int ioIndex = ioids.FindIndex(x => x.Trim() == IO_ID);
                if (devIndex >= 0 && selItem != null && paranames.Count > 0 && ioids.Count > 0 && ioids.Count == paranames.Count && ioIndex >= 0)
                {
                    string ioName = paranames[ioIndex].Trim();
                    current.Name = titles[ioIndex].Trim();
                    var serie = realResult.ElementAt(devIndex).First();
                    if (serie.Values.Count > 0)
                    {
                        current.Time = serie.Values[0][serie.Columns.IndexOf("time")].ToString();//获取时间
                        int recordindex = serie.Columns.IndexOf("field_" + ioName.Trim().ToLower() + "_value");
                        if (recordindex >= 0)
                        {
                            current.Value = serie.Values[0][recordindex].ToString();
                        }
                       
                    }


                }

            }
            #endregion

            for (int i = 0; i < excelModels.models.Count; i++)
            {
                PropertyInfo[] properties = excelModels.models[i].GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                if (properties.Length <= 0)
                {
                    continue;
                }
                foreach (PropertyInfo item in properties)
                {
                    string name = item.Name;
                    object value = item.GetValue(excelModels.models[i], null);
                    if (value != null && value.ToString() != "")
                    {
                        if (value.ToString().Split('/').Length >= 8)
                        {
                            try
                            {
                                string GroupId = value.ToString().Split('/')[1];
                                string IO_SERVER_ID = value.ToString().Split('/')[2];
                                string IO_COMM_ID = value.ToString().Split('/')[3];
                                string IO_DEVICE_ID = value.ToString().Split('/')[4];
                                string IO_ID = value.ToString().Split('/')[5];
                                string vtype = value.ToString().Split('/')[7];
                                string iostatus = "异常";
                                string iotime = "";
                                string iovalue = "";
                                int devIndex = devices.FindIndex(x => x.IOServerID == IO_SERVER_ID && x.IOCommunicateID == IO_COMM_ID && x.IODeviceID == IO_DEVICE_ID);
                                DeviceGroupModel selItem = deviceModels.Find(x => x.IO_SERVER_ID == IO_SERVER_ID && x.IO_COMM_ID == IO_COMM_ID && x.IO_DEVICE_ID == IO_DEVICE_ID && x.GroupId.ToString() == GroupId);
                                List<string> paranames = selItem.IOPARANAMES.Split(',').ToList();
                                List<string> ioids = selItem.IOPARAS.Split(',').ToList();
                                int ioIndex = ioids.FindIndex(x => x.Trim() == IO_ID);
                                if (devIndex >= 0 && selItem != null && paranames.Count > 0 && ioids.Count > 0 && ioids.Count == paranames.Count && ioIndex >= 0)
                                {
                                    string ioName = paranames[ioIndex].Trim();
                                    var serie = realResult.ElementAt(devIndex).First();
                                    if (serie.Values.Count > 0)
                                    {
                                        iotime = serie.Values[0][serie.Columns.IndexOf("time")].ToString();//获取时间
                                        int recordindex = serie.Columns.IndexOf("field_" + ioName.Trim().ToLower() + "_value");
                                        if (recordindex >= 0)
                                        {
                                            iostatus = "正常";
                                            iovalue = serie.Values[0][recordindex].ToString();
                                        }
                                        else
                                        {
                                            iostatus = "异常";
                                        }

                                    }
                                    else
                                    {
                                        iostatus = "异常";
                                    }


                                }
                                else
                                {
                                    iostatus = "异常";
                                }

                                switch (vtype.Trim().ToLower())
                                {
                                    case "time":
                                        item.SetValue(excelModels.models[i], iotime);
                                        break;
                                    case "value":
                                        item.SetValue(excelModels.models[i], iovalue);
                                        break;
                                    case "status":
                                        item.SetValue(excelModels.models[i], iostatus);
                                        break;
                                }



                            }
                            catch
                            {
                                continue;
                            }
                        }

                    }
                }
            }
            var result = Pager.ScadaTablePaging(excelModels.models, current, excelModels.models.Count());
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 加载曲线默认一个小时前的数据
        /// </summary>
        /// <param name="groupid"></param>
        /// <param name="serverid"></param>
        /// <param name="communicateid"></param>
        /// <param name="deviceid"></param>
        /// <param name="fields"></param>
        /// <param name="series"></param>
        /// <param name="charttype"></param>
        /// <param name="sdate"></param>
        /// <param name="edate"></param>
        /// <param name="serieclassify"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult QueryDefaultSeriesData(string groupid, string serverid, string communicateid, string deviceid, string paraid)
        {
            string sdate = DateTime.Now.AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss");
            string edate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            IEnumerable<DeviceGroupModel> groupdevices = DeviceGroupService.GetByWhere(" where GroupId=" + groupid + " and  IO_SERVER_ID='" + serverid + "' and IO_COMM_ID='" + communicateid + "' and IO_DEVICE_ID='" + deviceid + "'");
            DeviceGroupModel pWell = null;
            if (groupdevices.Count() > 0)
            {
                pWell = groupdevices.First();
            }

            if (pWell == null)
                return Json(null, JsonRequestBehavior.AllowGet);

            List<string> ioids = pWell.IOPARAS.Split(',').ToList();
            List<string> names = pWell.IOPARANAMES.Split(',').ToList();
            List<string> titles = pWell.IOPARATITLES.Split(',').ToList();
            int index = ioids.FindIndex(X => X == paraid.Trim());
            string seriename = "";
            if (index >= 0)
            {
                seriename = names[index];
            }
            IEnumerable<SerieConfigModel> allItems = SerieServer.GetByWhere(" where SerieName='" + seriename + "' and SerieClassify='" + pWell.SerieType + "'");
            SerieConfigModel serieConfig = new SerieConfigModel();

            if (allItems.Count() > 0)
            {
                serieConfig = allItems.First();
            }
            else
            {
                serieConfig.SerieTitle = titles[index];
                serieConfig.SerieName = seriename;
                serieConfig.SerieType = "line";

            }
            ///初始化曲线对象
            EChartOption chartOption = new EChartOption();
            chartOption.xAxis = new Axis[1];
            chartOption.xAxis[0] = new Axis();
            chartOption.xAxis[0].gridIndex = 1;
            chartOption.xAxis[0].type = "time";
            chartOption.xAxis[0].name = "时间";
            chartOption.name = serieConfig.SerieTitle;
            List<Axis> yaxis = new List<Axis>();

            string legend = serieConfig.SerieTitle;
            yaxis.Add(new Axis() { gridIndex = 0, name = serieConfig.SerieTitle, type = "value" });
            chartOption.legend.data = new string[1] { legend };
            chartOption.yAxis = yaxis.ToArray();
            //初始化对象结束
            if (sdate == null || sdate == "")
                sdate = DateTime.Now.AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss");
            if (edate == null || edate == "")
                edate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            chartOption.series = new Series[1];

            InfluxDBHistoryResult realResult = mWebInfluxDbManager.DbQuery_History(serverid, communicateid, deviceid, Convert.ToDateTime(sdate), Convert.ToDateTime(edate), 10000, 1, " ASC ");
            if (realResult != null)
            {

                var datas = realResult.Seres;
                if (datas != null && datas.Count() > 0)
                {
                    var onedata = datas.First();

                    if (onedata != null)
                    {


                        chartOption.series[0] = new Series();
                        chartOption.series[0].name = serieConfig.SerieTitle;
                        chartOption.series[0].lineStyle.color = serieConfig.SerieColor;
                        chartOption.series[0].lineStyle.width = int.Parse(serieConfig.SerieWidth);
                        chartOption.series[0].itemStyle = null;
                        chartOption.series[0].data = new double[onedata.Values.Count];
                        chartOption.series[0].type = serieConfig.SerieType;
                        chartOption.series[0].showSymbol = serieConfig.ShowSymbol == "1" ? true : false;
                        chartOption.series[0].symbol = serieConfig.SymbolType;
                        chartOption.series[0].symbolSize = int.Parse(serieConfig.SymbolSize);


                        string[] axisData = new string[onedata.Values.Count];
                        //获取的数据按照时间先后
                        int dataindex = onedata.Values.Count() - 1;

                        foreach (var value in onedata.Values)
                        {
                            //获取采集时间
                            object objx = onedata.Values[dataindex][onedata.Columns.IndexOf("time")];
                            axisData[dataindex] = objx != null ? objx.ToString() : "";
                            //////////////////////////
                            try
                            {
                                int recordindex = onedata.Columns.IndexOf("field_" + serieConfig.SerieName.Trim().ToLower() + "_value");
                                if (recordindex >= 0)
                                {
                                    object objy = onedata.Values[dataindex][recordindex];
                                    chartOption.series[0].data[dataindex] = Convert.ToDouble(objy);
                                    chartOption.series[0].id = serieConfig.SerieName;
                                }

                            }
                            catch 
                            {

                            }
                            dataindex--;
                        }
                        chartOption.xAxis[0].data = axisData;//设置x轴数据，time格式的数据必须在Axis轴上进行设置
                    }
                }
            }

            //读取以下的实时数据，从influxDB中读取
            return Json(chartOption, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 读取自定义表格的实时数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult ScadaTableHistory(ScadaTableSearchForm model, PageInfo pageInfo)
        {
            if (model.IOPath.Trim() == "")
            {
                var result = Pager.Paging2(null, 0);
                return Json(result, "application/text", JsonRequestBehavior.AllowGet);
            }
            string[] paras = model.IOPath.Split('/');
            if (paras.Length < 4)
            {
                var result = Pager.Paging2(null, 0);
                return Json(result, "application/text", JsonRequestBehavior.AllowGet);
            }
            model.ServerID = paras[1];
            model.CommunicateID = paras[2];
            model.DeviceID = paras[3];
            model.GroupId = int.Parse(paras[0]);
            IEnumerable<DeviceGroupModel> groupdevices = DeviceGroupService.GetByWhere(" where GroupId=" + model.GroupId + " and  IO_SERVER_ID='" + model.ServerID + "' and IO_COMM_ID='" + model.CommunicateID + "' and IO_DEVICE_ID='" + model.DeviceID + "'");
            DeviceGroupModel pItem = null;
            if (groupdevices.Count() > 0)
            {
                pItem = groupdevices.First();
            }

            string items = "[";
            string[] columns = pItem.IOPARANAMES.Split(',');
            string[] titles = pItem.IOPARATITLES.Split(',');
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

        [HttpGet]
        /// <summary>
        /// 读取自定义表历史报警
        /// </summary>
        /// <returns></returns>
        public JsonResult ScadaTableHistoryAlarm(ScadaTableAlarmSearchForm model, PageInfo pageInfo)
        {
            var result = Pager.Paging(null, 0);
            if (model.AlarmIOPath.Trim() == "")
            {

                return Json(result, "application/text", JsonRequestBehavior.AllowGet);
            }
            string[] paras = model.AlarmIOPath.Split('/');
            if (paras.Length < 4)
            {

                return Json(result, "application/text", JsonRequestBehavior.AllowGet);
            }
            model.ServerID = paras[1];
            model.CommunicateID = paras[2];
            model.DeviceID = paras[3];
            model.GroupId = int.Parse(paras[0]);
            IEnumerable<DeviceGroupModel> groupdevices = DeviceGroupService.GetByWhere(" where GroupId=" + model.GroupId + " and  IO_SERVER_ID='" + model.ServerID + "' and IO_COMM_ID='" + model.CommunicateID + "' and IO_DEVICE_ID='" + model.DeviceID + "'");
            DeviceGroupModel deviceModel = null;
            if (groupdevices.Count() > 0)
            {
                deviceModel = groupdevices.First();
            }
            string[] columns = deviceModel.IOPARANAMES.Split(',');
            string[] titles = deviceModel.IOPARATITLES.Split(',');
            List<string> ioids = deviceModel.IOPARAS.Split(',').ToList();
            List<ScadaGreneralAlarmModel> alarms = new List<ScadaGreneralAlarmModel>();
            InfluxDBHistoryResult realResult = null;


            realResult = mWebInfluxDbManager.DbQuery_Alarms(model.ServerID, model.CommunicateID, model.DeviceID, Convert.ToDateTime(model.AlarmStartDate), Convert.ToDateTime(model.AlarmEndDate), "", "", pageInfo.limit, pageInfo.page);


            if (realResult != null && realResult.Seres.Count() > 0)
            {
                var s = realResult.Seres.First();
                for (int i = 0; i < s.Values.Count; i++)
                {
                    ScadaGreneralAlarmModel mymodel = new ScadaGreneralAlarmModel();

                    int index = s.Columns.IndexOf("time");

                    object time = s.Values[i][index];
                    mymodel.time = time != null ? time.ToString() : "";



                    index = -1;
                    index = s.Columns.IndexOf("field_io_alarm_date");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_ALARM_DATE = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("field_io_alarm_disposalidea");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_ALARM_DISPOSALIDEA = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("field_io_alarm_disposaluser");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_ALARM_DISPOSALUSER = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("field_io_alarm_level");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_ALARM_LEVEL = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("field_io_alarm_type");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_ALARM_TYPE = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("field_io_alarm_value");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_ALARM_VALUE = v != null ? v.ToString() : "";
                    }




                    index = -1;
                    index = s.Columns.IndexOf("field_io_name");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_NAME = v != null ? v.ToString() : "";
                    }


                    index = -1;
                    index = s.Columns.IndexOf("tag_did");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_DEVICE_ID = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("tag_cid");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_COMMUNICATE_ID = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("tag_sid");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_SERVER_ID = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("tag_ioid");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_ID = v != null ? v.ToString() : "";
                    }
                    index = -1;
                    index = s.Columns.IndexOf("tag_device_name");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.DEVICE_NAME = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("field_io_label");
                    if (index >= 0)
                    {

                        if (deviceModel != null)
                        {


                            int nameindex = ioids.FindIndex(x => x == mymodel.IO_ID);
                            if (nameindex >= 0)
                            {
                                mymodel.IO_LABEL = titles[nameindex];
                            }

                        }

                    }

                    alarms.Add(mymodel);
                }

            }

            result = Pager.Paging(alarms, realResult.RecordCount);
            //读取以下10行的实时数据，从influxDB中读取
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        /// <summary>
        /// 读取通用实时报警
        /// </summary>
        /// <returns></returns>
        public JsonResult ScadaTableRealAlarm(JsonExcel excelModels)
        {
            var result = Pager.Paging(null, 0);
            if (excelModels == null)
                return Json(result, JsonRequestBehavior.AllowGet);
            if (excelModels.devices == null || excelModels.devices.Count <= 0)
                return Json(result, JsonRequestBehavior.AllowGet);
            var objs = excelModels.devices;
            List<ScadaGreneralAlarmModel> alarms = new List<ScadaGreneralAlarmModel>();
            InfluxDBHistoryResult realResult = null;

            List<string> dids = new List<string>();
            List<string> tableioids = new List<string>();
            foreach (var item in excelModels.devices)
            {
                if(!dids.Contains(item.IO_DEVICE_ID.ToString()))
                dids.Add(item.IO_DEVICE_ID.ToString());
                if (!tableioids.Contains(item.CurrentIO))
                    tableioids.Add(item.CurrentIO);

            }
            realResult = mWebInfluxDbManager.DbQuery_Alarms(dids.ToList(), "6h","", "", 2000,1);



            if (realResult != null && realResult.Seres.Count() > 0)
            {
                var s = realResult.Seres.First();
                for (int i = 0; i < s.Values.Count; i++)
                {
                    ScadaGreneralAlarmModel mymodel = new ScadaGreneralAlarmModel();

                    int index = s.Columns.IndexOf("time");

                    object time = s.Values[i][index];
                    mymodel.time = time != null ? time.ToString() : "";



                    index = -1;
                    index = s.Columns.IndexOf("field_io_alarm_date");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_ALARM_DATE = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("field_io_alarm_disposalidea");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_ALARM_DISPOSALIDEA = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("field_io_alarm_disposaluser");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_ALARM_DISPOSALUSER = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("field_io_alarm_level");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_ALARM_LEVEL = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("field_io_alarm_type");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_ALARM_TYPE = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("field_io_alarm_value");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_ALARM_VALUE = v != null ? v.ToString() : "";
                    }




                    index = -1;
                    index = s.Columns.IndexOf("field_io_name");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_NAME = v != null ? v.ToString() : "";
                    }


                    index = -1;
                    index = s.Columns.IndexOf("tag_did");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_DEVICE_ID = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("tag_cid");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_COMMUNICATE_ID = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("tag_sid");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_SERVER_ID = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("tag_ioid");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_ID = v != null ? v.ToString() : "";
                    }
                    index = -1;
                    index = s.Columns.IndexOf("tag_device_name");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.DEVICE_NAME = v != null ? v.ToString() : "";
                    }

                    index = -1;
                    index = s.Columns.IndexOf("field_io_label");
                    if (index >= 0)
                    {
                        var search = objs.Find(x => x.IO_DEVICE_ID == mymodel.IO_DEVICE_ID);
                        if (search != null)
                        {
                            string[] titles = search.IOPARATITLES.Split(',');
                            List<string> ioids = search.IOPARAS.Split(',').ToList();
                            int nameindex = ioids.FindIndex(x => x == mymodel.IO_ID);
                            if (nameindex >= 0)
                            {
                                mymodel.IO_LABEL = titles[nameindex];
                            }

                        }

                    }
                    if(tableioids.Contains(mymodel.IO_ID))
                    {
                        alarms.Add(mymodel);
                    }
                
                }

            }

            result = Pager.Paging(alarms, realResult.RecordCount);
            //读取以下10行的实时数据，从influxDB中读取
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}