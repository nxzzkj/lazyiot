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
using Newtonsoft.Json;

namespace ScadaWeb.Web.Areas.Scada.Controllers
{
    public class ScadaAlarmController : BaseController
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
        public IDeviceGroupService DeviceGroupService { set; get; }
        public IScadaGroupService GroupService { get; set; }
        public override ActionResult Index(int? id)
        {
            WellScadaAlarmModel pageModel = new WellScadaAlarmModel();
          var Wells = WellService.GetAll(null, null).ToList();
                List<string> dids = new List<string>();
            foreach(var item in Wells)
            {
                dids.Add(item.IO_DeviceID);
            }
            pageModel.JsonWells = string.Join(",", dids.ToArray());
            base.Index(id);
            return View(pageModel);

        }
        public ActionResult WellHistoryAlarm()
        {
            WellScadaAlarmModel pageModel = new WellScadaAlarmModel();
            return View(pageModel);
        }
        [HttpGet]
        public JsonResult GetWells(int OrganizeId = 0)
        {
 
            IEnumerable<WellModel> Items = WellService.GetListObjectByOrganize("");
            return Json(Items.ToList(), JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult GetAllDevices()
        {

            IEnumerable<DeviceGroupModel> Items = DeviceGroupService.GetAll();
            return Json(Items.ToList(), JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult GetOrganizeWells(int OrganizeId = 0)
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
                        id = item.IO_DeviceID.ToString(),
                        name = item.WellName,
                        value = item.IO_DeviceID.ToString()

                    };
                    _select.Add(_option);
                }
            }

            return Json(_select, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult GetOrganizeWellsDeviceID(int OrganizeId = 0)
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
                        value = item.Id.ToString()

                    };
                    _select.Add(_option);
                }
            }

            return Json(_select, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        /// <summary>
        /// 读取单井实时报警
        /// </summary>
        /// <returns></returns>
        public JsonResult WellRealAlarm(WellScadaAlarmModel model, PageInfo pageInfo)
        {
         
            List<WellScadaAlarmModel> alarms = new List<WellScadaAlarmModel>();
            InfluxDBHistoryResult realResult = null;
            if(model.OrganizeId==0|| model.OrganizeId==1)
            {
                if(model.WellID==null||model.WellID=="" || model.WellID == "0")
                {
                    //if(string.IsNullOrEmpty(model.AllDeviceIDList))
                    //{
                    //    var Wells = WellService.GetAll(null, null).ToList();
                    //    List<string> strs = new List<string>();
                    //    foreach (var item in Wells)
                    //    {
                    //        strs.Add(item.IO_DeviceID);
                    //    }
                    //    model.AllDeviceIDList = string.Join(",", strs.ToArray());

                    //}
                    string[] dids = model.AllDeviceIDList.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    realResult = mWebInfluxDbManager.DbQuery_Alarms(dids.ToList(), "6h", model.IO_ALARM_TYPE, model.IO_ALARM_LEVEL, pageInfo.limit, pageInfo.page);
                }
                else
                {
                    string[] dids = model.WellID.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    realResult = mWebInfluxDbManager.DbQuery_Alarms(dids.ToList(), "6h", model.IO_ALARM_TYPE, model.IO_ALARM_LEVEL, pageInfo.limit, pageInfo.page);

                }
            
            }
            else
            {
                if (model.WellID == null || model.WellID == "")
                {
                    string[] dids = model.WellID.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    realResult = mWebInfluxDbManager.DbQuery_Alarms(dids.ToList(), "6h", model.IO_ALARM_TYPE, model.IO_ALARM_LEVEL, pageInfo.limit, pageInfo.page);
                }
            }
          
            if (realResult != null && realResult.Seres.Count() > 0)
            {
                var s = realResult.Seres.First();
                for (int i = 0; i < s.Values.Count; i++)
                {
                    WellScadaAlarmModel mymodel = new WellScadaAlarmModel();

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
                    index = s.Columns.IndexOf("field_io_label");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_LABEL = v != null ? v.ToString() : "";
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
                    alarms.Add(mymodel);
                }

            }
       
            var result = Pager.Paging(alarms, realResult.RecordCount);
            //读取以下10行的实时数据，从influxDB中读取
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult QueryWellHistoryAlarm(WellScadaAlarmModel model, PageInfo pageInfo)
        {
            
            List<WellScadaAlarmModel> alarms = new List<WellScadaAlarmModel>();
            InfluxDBHistoryResult realResult = null;
           
            if (string.IsNullOrEmpty(model.WellID))
            {
                realResult = null;

            }
            else
            {
                WellModel well = WellService.GetById(int.Parse(model.WellID));
                if(well!=null)
                realResult = mWebInfluxDbManager.DbQuery_Alarms(well.IO_ServerID, well.IO_CommunicateID, well.IO_DeviceID,Convert.ToDateTime(model.StartDate),Convert.ToDateTime(model.EndDate),model.IO_ALARM_TYPE, model.IO_ALARM_LEVEL, pageInfo.limit, pageInfo.page);
            }
            if (realResult != null && realResult.Seres.Count() > 0)
            {
                var s = realResult.Seres.First();
                for (int i = 0; i < s.Values.Count; i++)
                {
                    WellScadaAlarmModel mymodel = new WellScadaAlarmModel();

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
                    index = s.Columns.IndexOf("field_io_label");
                    if (index >= 0)
                    {
                        object v = s.Values[i][index];
                        mymodel.IO_LABEL = v != null ? v.ToString() : "";
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
                    alarms.Add(mymodel);
                }

            }

            var result = Pager.Paging(alarms, realResult.RecordCount);
            //读取以下10行的实时数据，从influxDB中读取
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult WriterScadaAlarmDisposal(WellScadaAlarmModel model)
        {
            bool res = false;
            if (model != null && model.time != null && model.time != "")
            {
                res = mWebInfluxDbManager.DbUpdate_AlarmPoints(model);
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public  ActionResult GeneralAlarm()
        {
            ScadaGreneralAlarmModel model = new ScadaGreneralAlarmModel();
            model.AllDeviceList = DeviceGroupService.GetAll();

 
            Session["AllDeviceList"] = model.AllDeviceList;
            return View(model);
        }
        public ActionResult GeneralHistoryAlarm()
        {
            ScadaGreneralAlarmModel model = new ScadaGreneralAlarmModel();
            return View(model);
        }
         
   
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
            foreach (var item in Items)
            {
                deviceids += ",'" + item.IO_DEVICE_ID + "'";
            }
            var deviceItems = IO_DeviceServer.GetByWhere(" where  IO_DEVICE_ID in (" + deviceids + ")");
            foreach (var item in _select)
            {
                var searchs = deviceItems.Where(x => x.IO_DEVICE_ID.Trim().ToLower() == item.value1.Trim().ToLower());
                if (searchs.Count() > 0)
                {
                    var sItem = searchs.First();
                    if (string.IsNullOrWhiteSpace(sItem.IO_DEVICE_UPDATECYCLE))
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
        public JsonResult GetGroupDevicePara(int id,string serverid,string communicateid,string deviceid)
        {
 

            
            DeviceGroupModel deviceModel = DeviceGroupService.GetById(id);
            List<SelectOption> _select = new List<SelectOption>();


            if (deviceModel != null )
            {

                string[] titles = deviceModel.IOPARATITLES.Split(',');
                string[] ionames = deviceModel.IOPARANAMES.Split(',');
                string[] ioids = deviceModel.IOPARAS.Split(',');
                for (int i=0;i< titles.Length;i++)
                {
                    SelectOption _option = new SelectOption
                    {
                        id = ioids[i],
                        name = titles[i],
                        value = ioids[i],
                        value1 ="/"+ deviceModel.GroupId+"/" + deviceModel.IO_SERVER_ID+"/" + deviceModel.IO_COMM_ID+"/"+ deviceModel.IO_DEVICE_ID+"/"+ ioids[i]+"/"+ deviceModel.UpdateCycle,
                    };
                    _select.Add(_option);
                }
                
            }
            
            return Json(_select, JsonRequestBehavior.AllowGet);





        }
        [HttpGet]
        /// <summary>
        /// 读取通用实时报警
        /// </summary>
        /// <returns></returns>
        public JsonResult GeneralRealAlarm(ScadaGreneralAlarmModel model, PageInfo pageInfo)
        {
            if (string.IsNullOrWhiteSpace(model.GroupIDString))
                 model.GroupIDString = "";
            if (string.IsNullOrWhiteSpace(model.DeviceIDString))
                model.DeviceIDString = "";
            var objs =(List<DeviceGroupModel>) Session["AllDeviceList"];
            List<ScadaGreneralAlarmModel> alarms = new List<ScadaGreneralAlarmModel>();
            InfluxDBHistoryResult realResult = null;
            if (model.DeviceIDString ==null|| model.DeviceIDString=="")
            {
                List<string> dids = new List<string>();
                string[] groups = model.GroupIDString.Split(',');
                foreach (var item in objs)
                {
                    if(model.GroupId==0|| model.GroupId==1)
                    {
                        dids.Add(item.IO_DEVICE_ID.ToString());
                    }
                    else
                    {
                        if (groups.Contains(item.GroupId.ToString()))
                        {
                            dids.Add(item.IO_DEVICE_ID.ToString());
                        }
                    }
                   
                   
                }
                realResult = mWebInfluxDbManager.DbQuery_Alarms(dids.ToList(), "6h", model.IO_ALARM_TYPE, model.IO_ALARM_LEVEL, pageInfo.limit, pageInfo.page);
               

            }
            else
            {
              
                List<string> dids = model.DeviceIDString.Split(',').ToList();
               
                realResult = mWebInfluxDbManager.DbQuery_Alarms(dids.ToList(), "6h", model.IO_ALARM_TYPE, model.IO_ALARM_LEVEL, pageInfo.limit, pageInfo.page);

            }

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
                        if(search!=null)
                        {
                            string[] titles = search.IOPARATITLES.Split(',');
                            List<string> ioids = search.IOPARAS.Split(',').ToList();
                            int nameindex = ioids.FindIndex(x => x == mymodel.IO_ID);
                         if(nameindex>=0)
                            {
                                mymodel.IO_LABEL = titles[nameindex];
                            }
                         
                        }
                       
                    }

                    alarms.Add(mymodel);
                }

            }

            var result = Pager.Paging(alarms, realResult.RecordCount);
            //读取以下10行的实时数据，从influxDB中读取
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        /// <summary>
        /// 读取通用历史报警
        /// </summary>
        /// <returns></returns>
        public JsonResult GeneralQueryHistoryAlarm(GeneralHistoryAlarmFormModel model, PageInfo pageInfo)
        {
            if (string.IsNullOrWhiteSpace(model.DeviceID))
                model.DeviceID = "";
            if (string.IsNullOrWhiteSpace(model.ServerID))
                model.ServerID = "";
            if (string.IsNullOrWhiteSpace(model.CommunicateID))
                model.ServerID = "";
            if (string.IsNullOrWhiteSpace(model.Fields))
                model.Fields = "";
         
            var deviceModel = DeviceGroupService.GetModel(model.GroupID,model.ServerID,model.CommunicateID,model.DeviceID);
           
            List<ScadaGreneralAlarmModel> alarms = new List<ScadaGreneralAlarmModel>();
            InfluxDBHistoryResult realResult = null;
            
     
            realResult = mWebInfluxDbManager.DbQuery_Alarms(model.ServerID, model.CommunicateID,model.DeviceID,Convert.ToDateTime( model.StartDate), Convert.ToDateTime(model.EndDate),model.IO_ALARM_TYPE, model.IO_ALARM_LEVEL, pageInfo.limit, pageInfo.page);


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
                            string[] titles = deviceModel.IOPARATITLES.Split(',');
                            List<string> ioids = deviceModel.IOPARAS.Split(',').ToList();
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

            var result = Pager.Paging(alarms, realResult.RecordCount);
            //读取以下10行的实时数据，从influxDB中读取
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
    }
}