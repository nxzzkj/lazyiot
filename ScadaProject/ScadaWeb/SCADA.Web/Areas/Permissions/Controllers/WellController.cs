using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScadaWeb.Common;
using ScadaWeb.IService;
using ScadaWeb.Model;
using ScadaWeb.Web.Controllers;
 

namespace ScadaWeb.Web.Areas.Permissions.Controllers
{
    public class WellController : BaseController
    {



        public IWellService WellService { get; set; }
        public IIO_ServerService IO_Server { get; set; }
        public IIO_CommunicateService IO_CommunicateServer { get; set; }
        public IWellOrganizeService WellOrganizeServer { get; set; }
        public IIO_DeviceService IO_DeviceServer { get; set; }
        public IIO_ParaService IO_ParaServer { get; set; }
        public IOrganizeService OrganizeService { set; get; }
    

        public override ActionResult Index(int? id)
        {
            base.Index(id);
            return View();
        }
        [HttpGet]
        public JsonResult List(WellModel model, PageInfo pageInfo)
        {
            var result = WellService.GetListByFilter(model, pageInfo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetOrganizeTreeSelect() 
        {
            var result = OrganizeService.GetOrganizeTreeSelect();
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetIOServerTreeSelect()
        {
    
               var result = IO_Server.GetIOServerTreeSelect();
            foreach (var item in result)
            {

                IEnumerable<IOCommunicateModel> communicateList = IO_CommunicateServer.GetByWhere(" where  IO_SERVER_ID='" + item.id + "'");
                if (communicateList != null && communicateList.Count() > 0)
                {
                    List<TreeSelect> _children = new List<TreeSelect>();
                    foreach (var comm in communicateList)
                    {
                        TreeSelect _tree = new TreeSelect
                        {
                            id = item.id+"/"+ comm.IO_COMM_ID,
                            name = comm.IO_COMM_NAME+"["+ comm.IO_COMM_LABEL + "]",
                            open = false
                        };
                        _children.Add(_tree);
                        item.children = _children;

                    }
                }
            }


            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetDeviceSelect(string serverId, string communicateId)
        {
            List<SelectOption> _select = new List<SelectOption>();


            IEnumerable<IODeviceModel> deviceList = IO_DeviceServer.GetAll("IO_DEVICE_ID,IO_COMM_ID,IO_SERVER_ID,IO_DEVICE_NAME,IO_DEVICE_LABLE ", "").Where(x => x.IO_SERVER_ID == serverId && x.IO_COMM_ID == communicateId);
            if (deviceList != null && deviceList.Count() > 0)
            {

                foreach (var device in deviceList)
                {
                    SelectOption _option = new SelectOption
                    {
                        id = device.IO_DEVICE_ID,
                        name = device.IO_DEVICE_NAME+"["+ device.IO_DEVICE_LABLE + "]",

                    };
                    _select.Add(_option);
                }
            }
            return Json(_select, JsonRequestBehavior.AllowGet);

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


        public ActionResult Add()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Add(WellModel model)
        {
            model.CreateTime = DateTime.Now;
            model.CreateUserId = Operator.UserId;
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            var result = WellService.AddWell(model) ? SuccessTip("添加成功") : ErrorTip("添加失败");
            return Json(result);
        }
        public ActionResult Edit(int id)
        {

            
            var model = WellService.GetById(id);
            model.IO_ServerID = model.IO_ServerID + "/" + model.IO_CommunicateID;
            IEnumerable<WellOrganizeModel> wos= WellOrganizeServer.GetListByWellId(id);
            foreach(var w in wos)
            {
                model.OrganizeId = w.OrganizeId;
            }
            return View(model);
        }
        public ActionResult Browser(int id)
        {


            var model = WellService.GetById(id);
            model.IO_ServerID = model.IO_ServerID + "/" + model.IO_CommunicateID;
            IEnumerable<WellOrganizeModel> wos = WellOrganizeServer.GetListByWellId(id);
            foreach (var w in wos)
            {
                model.OrganizeId = w.OrganizeId;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(WellModel model)
        {
            string sid = model.IO_ServerID.Split('/')[0];
            string cid = model.IO_ServerID.Split('/')[1];
            model.IO_ServerID = sid;
            model.IO_CommunicateID = cid;
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            var result = WellService.UpdateById(model) ? SuccessTip("修改成功") : ErrorTip("修改失败");
            return Json(result);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            if(WellOrganizeServer.DeleteByWellId(id))
            {
                var result = WellService.DeleteById(id) ? SuccessTip("删除成功") : ErrorTip("删除失败");
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = ErrorTip("删除失败");
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

    }
}