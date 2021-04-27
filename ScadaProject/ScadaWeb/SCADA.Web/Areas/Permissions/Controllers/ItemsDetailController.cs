using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScadaWeb.Web.Controllers;
using ScadaWeb.IService;
using ScadaWeb.Model;

namespace ScadaWeb.Web.Areas.Permissions.Controllers
{
    public class ItemsDetailController : BaseController
    {
        public IItemsService ItemsService { get; set; }
        public IItemsDetailService ItemsDetailService { get; set; }
        // GET: Permissions/ItemsDetail
        public override ActionResult Index(int? id)
        {
            base.Index(id);
            return View();
        }
        [HttpGet]
        public JsonResult List(ItemsDetailModel model, PageInfo pageInfo)
        {
            var result = ItemsDetailService.GetListByFilter(model, pageInfo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ItemsDetailModel model)
        {
            model.CreateTime = DateTime.Now;
            model.CreateUserId = Operator.UserId;
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            var result = ItemsDetailService.Insert(model) ? SuccessTip("添加成功") : ErrorTip("添加失败");
            return Json(result);
        }
        public ActionResult Edit(int id)
        {
            var model = ItemsDetailService.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ItemsDetailModel model)
        {
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            var result = ItemsDetailService.UpdateById(model) ? SuccessTip("修改成功") : ErrorTip("修改失败");
            return Json(result);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            var result = ItemsDetailService.DeleteById(id) ? SuccessTip("删除成功") : ErrorTip("删除失败");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}