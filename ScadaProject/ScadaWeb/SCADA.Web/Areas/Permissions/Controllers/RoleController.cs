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
    public class RoleController : BaseController
    {
        public IRoleService RoleService { get; set; }
        public IItemsDetailService ItemsDetailService { get; set; }
        public SelectList RoleTypeList { get { return new SelectList(ItemsDetailService.GetAll("Id,ItemName,ItemId", "ORDER BY SortCode ASC").Where(x=>x.ItemId==3), "Id", "ItemName"); } }

        // GET: Permissions/Role
        public override ActionResult Index(int? id)
        {
            base.Index(id);
            return View();
        }
        [HttpGet]
        public JsonResult List(RoleModel model, PageInfo pageInfo)
        {
            var result = RoleService.GetListByFilter(model, pageInfo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add() 
        {
            ViewBag.RoleTypeList = RoleTypeList;
            return View();
        }
        [HttpPost]
        public ActionResult Add(RoleModel model)
        {
            model.CreateTime = DateTime.Now;
            model.CreateUserId = Operator.UserId;
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            var result = RoleService.Insert(model) ? SuccessTip("添加成功") : ErrorTip("添加失败");
            return Json(result);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.RoleTypeList = RoleTypeList;
            var model = RoleService.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(RoleModel model)
        {
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            var result = RoleService.UpdateById(model) ? SuccessTip("修改成功") : ErrorTip("修改失败");
            return Json(result);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            var result = RoleService.DeleteById(id) ? SuccessTip("删除成功") : ErrorTip("删除失败");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Assign(int id) 
        {
            ViewBag.RoleId = id;
            return View();
        }
    }
}