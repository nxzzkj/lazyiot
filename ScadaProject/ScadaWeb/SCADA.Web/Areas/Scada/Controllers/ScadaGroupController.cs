using ScadaWeb.IService;
using ScadaWeb.Model;
using ScadaWeb.Service;
using ScadaWeb.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScadaWeb.Web.Areas.Scada.Controllers
{
    public class ScadaGroupController : BaseController
    {
        public IIO_ParaService ParaService { set; get; }
        public IDeviceGroupService DeviceGroupService { set; get; }
        public IScadaGroupService GroupService { get; set; }

        // GET: Permissions/Organize
        public override ActionResult Index(int? id)
        {
            base.Index(id);
            return View();
        }
        [HttpGet]
        public JsonResult List()
        {

            var list = GroupService.GetGroupList();
            var result = new { code = 0, count = list.Count(), data = list };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetGroupTreeSelect()
        {
            var result = GroupService.GetGroupTreeSelect();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(ScadaGroupModel model)
        {
            model.CreateTime = DateTime.Now;
            model.CreateUserId = Operator.UserId;
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            var result = GroupService.Insert(model) ? SuccessTip("添加成功") : ErrorTip("添加失败");
            return Json(result);
        }
        public ActionResult Edit(int id)
        {

            var model = GroupService.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ScadaGroupModel model)
        {
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            var result = GroupService.UpdateById(model) ? SuccessTip("修改成功") : ErrorTip("修改失败");
            return Json(result);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            var result = ErrorTip("删除失败");
            if (GroupService.DeleteById(id))
            {
                DeviceGroupService.DeleteByWhere(" where  GroupId=" + id);
                result = SuccessTip("删除成功");
            }
            else
            {
                result = ErrorTip("删除失败");
            }


            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeviceGroup(int Id)
        {

            ViewData["GroupId"] = Id;
            return View();

        }

        [HttpGet]
        public JsonResult DeviceGroupList(int groupId)
        {
            var myList = DeviceGroupService.GetByWhere(" where GroupId=" + groupId);
            var unioaList = DeviceGroupService.GetListAll();
            foreach (var item in unioaList)
            {
                item.GroupId = groupId;
                var source = myList.Where(x => x.IO_SERVER_ID == item.IO_SERVER_ID && x.IO_COMM_ID == item.IO_COMM_ID && x.IO_DEVICE_ID == item.IO_DEVICE_ID);
                if (source.Count() > 0)
                {
                    var sorItem = source.First();
                    item.LAY_CHECKED = true;
                    item.ALIASNAME = sorItem.ALIASNAME;
                    item.IOPARAS = sorItem.IOPARAS;
                    item.IOPARATITLES = sorItem.IOPARATITLES;
                    item.IOPARANAMES = sorItem.IOPARANAMES;
                    item.SerieType = sorItem.SerieType;
                    item.UpdateCycle = sorItem.UpdateCycle;

                }
                else
                {
                 
                    item.ALIASNAME = item.IODeviceName;
                    item.LAY_CHECKED = false;
                    item.IOPARAS = "";
                    item.IOPARATITLES = "";
                    item.IOPARANAMES = "";
                    item.SerieType = "";
                }
            }
            var result = new { code = 0, count = unioaList.Count(), data = unioaList };
            return Json(result, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        public JsonResult SaveGroupSet(IEnumerable<DeviceGroupModel> list, int groupId)
        {
            var result = ErrorTip("失败");
         
            result = DeviceGroupService.SaveDeviceGroup(list, groupId) > 0 ? SuccessTip("保存成功") : ErrorTip("保存失败");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //获取用户所有当前归属的Device配置信息页面
        public ActionResult DeviceSet(int Id)
        {

            ViewData["GroupId"] = Id;
            return View();
        }

        [HttpGet]
        public JsonResult GetGroupDevice(int Id)
        {
            var myList = DeviceGroupService.GetByWhere(" where GroupId=" + Id);
            List<IOTreeSelect> treeSelectList = new List<IOTreeSelect>();
            foreach (var item in myList)
            {
                IOTreeSelect tree = new IOTreeSelect
                {
                    id = item.IO_DEVICE_ID.ToString(),
                    name = item.ALIASNAME,
                    CommunicateID = item.IO_COMM_ID,
                    DeviceID = item.IO_DEVICE_ID,
                    ServerID = item.IO_SERVER_ID,
                    UpdateCycle= item.UpdateCycle,
                    value = item.IO_DEVICE_ID,
                    open = false
                };

                treeSelectList.Add(tree);
            }
            return Json(treeSelectList, JsonRequestBehavior.AllowGet);


        }
        [HttpGet]
        public JsonResult GetDevicePara(string ServerID, string CommunicateID, string DeviceID, string GroupID)
        {

            var myList = DeviceGroupService.GetByWhere(" where GroupId=" + GroupID);

            var selectItems = myList.Where(x => x.IO_SERVER_ID == ServerID && x.IO_COMM_ID == CommunicateID && x.IO_DEVICE_ID == DeviceID);
            var myItem = selectItems.First();
            if (myItem != null)
            {
                List<string> ids = myItem.IOPARAS.ToString().Split(',').ToList();
                List<string> titles = myItem.IOPARATITLES.ToString().Split(',').ToList();
                var paras = ParaService.GetByWhere(" where IO_SERVER_ID='" + ServerID + "' and IO_COMM_ID='" + CommunicateID + "' and IO_DEVICE_ID='" + DeviceID + "'");
                foreach (var item in paras)
                {
                    int index = ids.FindIndex(x => x == item.IO_ID);
                    if (index >= 0)
                    {
                        if(index< titles.Count)
                        {
                            item.IO_ALIASNAME = titles[index];
                       

                        }
            
                        item.LAY_CHECKED = true;
                       
                    }
                    else
                    {
                        item.IO_ALIASNAME = item.IO_LABEL;
                        item.LAY_CHECKED = false;
                    }
                }
                var result = new { code = 0, count = paras.Count(), data = paras };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {

                return Json(null, JsonRequestBehavior.AllowGet);
            }


        }
        [HttpPost]
        public JsonResult SaveGroupDevicePara(IEnumerable<IOParaModel> list, int groupId,string deviceid,string communicateid,string serverid)
        {
            var result = ErrorTip("失败");
            if (list!=null&& list.Count()>0&& !string.IsNullOrWhiteSpace(deviceid) && !string.IsNullOrWhiteSpace(communicateid) && !string.IsNullOrWhiteSpace(serverid))
            {
                DeviceGroupModel model = DeviceGroupService.GetModel(groupId, serverid, communicateid, deviceid);
                if (model != null)
                {
                    model.IO_COMM_ID = communicateid;
                    model.IO_DEVICE_ID = deviceid;
                    model.IO_SERVER_ID = serverid;
                    model.GroupId = groupId;
                    model.IOPARAS = "";
                    model.IOPARATITLES = "";
                    model.IOPARANAMES = "";
              //      DeviceGroupService.DeleteByWhere(" where  GroupId=" + groupId + " and IO_SERVER_ID='" + serverid + "' and IO_COMM_ID='" + communicateid + "' and IO_DEVICE_ID='" + deviceid + "'");
                    foreach (var item in list)
                    {
                        if (!string.IsNullOrWhiteSpace(item.IO_ID))
                        {
                            model.IOPARAS += item.IO_ID + ",";
                            model.IOPARANAMES += item.IO_NAME + ",";
                            if (item.IO_ALIASNAME != "")
                                model.IOPARATITLES += item.IO_ALIASNAME + ",";
                            else
                                model.IOPARATITLES += item.IO_LABEL + ",";
                            
                        }

                    }
                    if (!string.IsNullOrWhiteSpace(model.IOPARAS))
                    {
                        model.IOPARAS = model.IOPARAS.Remove(model.IOPARAS.Length-1,1);
                        model.IOPARATITLES = model.IOPARATITLES.Remove(model.IOPARATITLES.Length - 1, 1);
                        model.IOPARANAMES = model.IOPARANAMES.Remove(model.IOPARANAMES.Length - 1, 1);
                    }
                    result = DeviceGroupService.UpdateModelByIOPara(model) ? SuccessTip("保存成功") : ErrorTip("保存失败");
                }
       

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}