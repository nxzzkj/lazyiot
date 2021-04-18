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
using Scada.DBUtility;
using System.Data;
using Microsoft.CSharp.RuntimeBinder;
using System.Runtime.CompilerServices;

namespace ScadaWeb.Web.Areas.Scada.Controllers
{

    /// <summary>
    /// 通用SCADA系统的控制模块
    /// </summary>
    public class ScadaFlowController : Controller
    {
        public WebInfluxDbManager mWebInfluxDbManager = new WebInfluxDbManager();

        public IScadaFlowProjectService ProjectServer { get; set; }
        public IScadaFlowViewService ViewServer { get; set; }
        public   ActionResult Index(int? id)
        {

            string vid = Request["vid"];
            if (vid == null || vid.ToString().Trim() == "")
                vid = "";
            ScadaFlowModel model = new ScadaFlowModel();
            if (vid == "")
            {


                string para = Request.QueryString["id"].Split('?')[0];
                string[] idarray = Request.QueryString["id"].Split('?').Length >= 2 ? Request.QueryString["id"].Split('?')[1].Split('=') : null;
                string idstr = "0";
                if (idarray != null && idarray.Length >= 2)
                {
                    idstr = Request.QueryString["id"].Split('?')[1].Split('=')[1];
                }
                else
                {
                    idstr = id.ToString();
                }
           
                if (para != null && para != "")
                    id = int.Parse(para);
            }
            ScadaFlowProjectModel Project = ProjectServer.GetById(id.Value);
            if (Project != null && vid == "")
            {
                ScadaFlowViewModel view = ViewServer.GetByWhere(" where ProjectId='" + Project.ProjectId + "'").First();
                model.Project = Project;
                model.MainView = view;
            }
            else if (vid != "")
            {
                ScadaFlowViewModel view = ViewServer.GetByWhere(" where  ViewId='" + vid + "'").First();
                if (view != null)
                {
                    Project = ProjectServer.GetByWhere(" where ProjectId='" + view.ProjectId + "'").First();
                    model.Project = Project;
                    model.MainView = view;
                }

            }
            return View(model);
        }
        public sealed class JsIOPara
        {
            public JsIOPara()
            {
                ServerID = "";
                CommunicateID = "";
                DeviceID = "";
                ParaID = "";
                DataType = "";
                Format = "";
                Unit = "";
                UpdateCycle = "120";
                IoName = "";
                Value = "";
                DateTime = "";
                Status = 0;
                QualityStamp = "BAD";
            }
            public string IOStr
            {
                get { return ServerID + "," + CommunicateID + "," + DeviceID + "," + ParaID + "," + DataType + "," + Format + "," + Unit + "," + UpdateCycle + "," + IoName; }
            }
            public string ServerID
            {
                set; get;
            }
            public string CommunicateID
            {
                set; get;
            }
            public string DeviceID
            {
                set; get;
            }
            public string ParaID
            {
                set; get;
            }
            public string DataType
            {
                set;
                get;
            }
            public string Format
            {
                set;
                get;
            }
            public string Unit
            {
                set;
                get;
            }
            public string UpdateCycle
            {
                set; get;
            }
            public string IoName
            {
                set;
                get;
            }
            /// <summary>
            /// 对应获取的实时值
            /// </summary>
            public string Value
            {
                set;
                get;
            }
            /// <summary>
            /// 对应获取的数据时间戳
            /// </summary>
            public string DateTime
            {
                set;
                get;
            }
            public int Status
            {
                set;
                get;
            }
            public string QualityStamp
            {
                set;
                get;
            }

        }
        /// <summary>
        /// 获取流程图的所有实时数据
        ///IoParas.push({ ServerID: parastr.split(',')[0], CommunicateID: parastr.split(',')[1], DeviceID: parastr.split(',')[2], ParaID: parastr.split(',')[3], DataType: parastr.split(',')[4], Format: parastr.split(',')[5], Format: parastr.split(',')[6], Unit: parastr.split(',')[7], UpdateCycle: parastr.split(',')[8] });
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetReadData(List<JsIOPara> ioparas)
        {

            List<JsIOPara> results = new List<JsIOPara>();
            if (ioparas != null)
            {
                ///删除重复项

                for (int i = ioparas.Count - 1; i >= 0; i--)
                {
                    if (string.IsNullOrWhiteSpace(ioparas.ElementAt(i).ServerID) || string.IsNullOrWhiteSpace(ioparas.ElementAt(i).DeviceID) || string.IsNullOrWhiteSpace(ioparas.ElementAt(i).ParaID) || string.IsNullOrWhiteSpace(ioparas.ElementAt(i).CommunicateID))
                    {
                        ioparas.Remove(ioparas.ElementAt(i));
                    }

                }
                //读取所有的实时数据，并加载 mWebInfluxDbManager
                List<InfluxDBQueryPara> devices = new List<InfluxDBQueryPara>();
                foreach (JsIOPara res in ioparas)
                {
                    InfluxDBQueryPara data = new InfluxDBQueryPara();
                    data.IOCommunicateID = res.CommunicateID;
                    data.IODeviceID = res.DeviceID;
                    data.IOServerID = res.ServerID;
                    data.UpdateCycle = int.Parse(res.UpdateCycle);
                    if (!devices.Exists(x => x.IOCommunicateID == data.IOCommunicateID && x.IOServerID == data.IOServerID && x.IODeviceID == data.IODeviceID))
                        devices.Add(data);
                }


                IEnumerable<IEnumerable<Serie>> realResult = mWebInfluxDbManager.MultiQueryReal(devices.ToList());
                for (int i = 0; i < devices.Count; i++)
                {
                    InfluxDBQueryPara influxpara = devices[i];
                    List<JsIOPara> deviceparas = ioparas.FindAll(x => x.CommunicateID == devices[i].IOCommunicateID && x.DeviceID == devices[i].IODeviceID && x.ServerID == devices[i].IOServerID);
                    try
                    {
                        Serie serie = realResult.ElementAt(i).First();//获取当前设备的查询数据
                        if (serie != null)
                        {

                            int timeindex = serie.Columns.IndexOf("time");
                            for (int c = 0; c < deviceparas.Count; c++)
                            {
                                JsIOPara para = deviceparas[c];
                                int valueindex = serie.Columns.IndexOf("field_" + deviceparas[c].IoName.Trim().ToLower() + "_value");
                                if (timeindex >= 0 && valueindex >= 0)
                                {
                                    para.Value = serie.Values[i][valueindex].ToString();
                                    para.Status = 1;
                                    para.DateTime = serie.Values[i][timeindex].ToString();
                                    DateTime dt;
                                    if (DateTime.TryParse(para.DateTime, out dt))
                                    {
                                        para.DateTime = Convert.ToDateTime(para.DateTime).ToString("yyyy-MM-dd HH:mm:ss");
                                    }
                                    else
                                    {
                                        para.QualityStamp = "BAD";
                                    }
                                    if (para.Value == "" || para.Value == "-9999")
                                    {
                                        para.QualityStamp = "BAD";

                                    }
                                    para.QualityStamp = "GOOD";
                                }
                                else
                                {
                                    para.Value = "";
                                    para.DateTime = "";
                                    para.Status = 0;
                                    para.QualityStamp = "BAD";
                                }
                                results.Add(para);
                            }


                        }


                    }
                    catch 
                    {

                    }
                }
            }
            else
            {
                results = new List<JsIOPara>();
            }
            var result = Pager.Paging(results, results.Count);
            //读取以下10行的实时数据，从influxDB中读取
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public sealed class JsIOAlarm
        {
            List<JsIOPara> mList = new List<JsIOPara>();
            public List<JsIOPara> List
            {
                set { mList = value; }
                get { return mList; }
            }
            private int mPageSize = 0;
            public int PageSize
            {
                set { mPageSize = value; }
                get { return mPageSize; }
            }
            private int mPageIndex = 0;
            public int PageIndex
            {
                set { mPageIndex = value; }
                get { return mPageIndex; }
            }
        }
        /// <summary>
        /// 获取实时报警数据
        /// </summary>
        /// <param name="alarms"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetReadAlarm(JsIOAlarm alarm)
        {
            List<JsIOPara> alarms = alarm.List;
            int pagesize = alarm.PageSize;
            int pageindex = alarm.PageIndex;


            List<ScadaGreneralAlarmModel> results = new List<ScadaGreneralAlarmModel>();

            ///删除重复项

            for (int i = alarms.Count - 1; i >= 0; i--)
            {
                if (string.IsNullOrWhiteSpace(alarms.ElementAt(i).ServerID) || string.IsNullOrWhiteSpace(alarms.ElementAt(i).DeviceID) || string.IsNullOrWhiteSpace(alarms.ElementAt(i).ParaID) || string.IsNullOrWhiteSpace(alarms.ElementAt(i).CommunicateID))
                {
                    alarms.Remove(alarms.ElementAt(i));
                }
            }

            //读取所有的实时数据，并加载 mWebInfluxDbManager

            List<string> DeviceIds = new List<string>();
            foreach (JsIOPara res in alarms)
            {
                if (!DeviceIds.Contains(res.DeviceID))
                {
                    DeviceIds.Add(res.DeviceID);
                }
            }
            //6小时内的实时报警
            InfluxDBHistoryResult realResult = mWebInfluxDbManager.DbQuery_Alarms(DeviceIds, "1h", "", "", pagesize, pageindex);
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
                        object v = s.Values[i][index];
                        mymodel.IO_LABEL = v != null ? v.ToString() : "";



                    }
                    results.Add(mymodel);
                }
            }
            var result = Pager.Paging(results, realResult.RecordCount);
            //读取以下10行的实时数据，从influxDB中读取
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetDBMultiDBValues(SCADAFlow_MultiDataBaseView obj, PageInfo pageInfo)
        {
            try
            {
                if (obj.Connection != null)
                {
                    DataSet set = new ScadaDBHelper(obj.Connection).Query(obj.SqlString);
                    object obj2 = Pager.ScadaDataTablePaging(set.Tables[0].ToJson(), (long)set.Tables[0].Rows.Count, base.Request["elementId"].Trim());
                    
                    return Json( obj2, JsonRequestBehavior.AllowGet);
                }
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                return Json(exception.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult GetDBSingleValues(SCADAFlow_SingleDataBaseValue dbvalue)
        {
            try
            {
                if (dbvalue.Connection != null)
                {
                    SCADAFlow_SingleDataBaseValue value2 = dbvalue;
                    DataSet set = new ScadaDBHelper(value2.Connection).Query(value2.SqlString);
                    object obj2 = Pager.ScadaDataTablePaging(set.Tables[0].ToJson(), (long)set.Tables[0].Rows.Count, base.Request["elementId"].Trim());

                    return Json(obj2, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception exception)
            {
                return base.Json(exception.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}