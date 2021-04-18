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
    public class ModuleController : BaseController
    {
        public IModuleService ModuleService { get; set; }
        // GET: Permissions/Module
        public override ActionResult Index(int? id)
        {
            base.Index(id);
            return View();
        }
        [HttpGet]
        public JsonResult List() 
        {
            var list = ModuleService.GetAll();
            var result = new { code = 0, count = list.Count(), data = list };
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetModuleList()
        {
            object result = ModuleService.GetModuleList(Operator.RoleId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetModuleTreeSelect()
        {
            var result = ModuleService.GetModuleTreeSelect();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(ModuleModel model)
        {
            model.FontFamily = "ok-icon";
            model.CreateTime = DateTime.Now;
            model.CreateUserId = Operator.UserId;
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            model.IsSystem = 0;
            var result = ModuleService.Insert(model) ? SuccessTip("添加成功") : ErrorTip("添加失败");
            return Json(result);
        }
        public ActionResult Edit(int id)
        {
            var model = ModuleService.GetById(id);
            if (model.IsSystem==1)
            {
                return View();
            }
            else
            {
                return View(model);
            }
           
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ModuleModel model)
        {
         if(model.IsSystem==0)
            {
                model.UpdateTime = DateTime.Now;
                model.UpdateUserId = Operator.UserId;
                model.IsSystem = 0;
                var result = ModuleService.UpdateById(model) ? SuccessTip("修改成功") : ErrorTip("修改失败");
                return Json(result);
            }
            else
            {
                var result =  ErrorTip("修改失败,系统模块不能进行编辑");
                return Json(result);
            }
        
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            var model = ModuleService.GetById(id);
            if (model.IsSystem == 1)
            {
                var result =  ErrorTip("删除失败,系统模块不能删除");
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = ModuleService.DeleteById(id) ? SuccessTip("删除成功") : ErrorTip("删除失败");
                return Json(result, JsonRequestBehavior.AllowGet);
            }

       
        }
        [HttpGet]
        public JsonResult ModuleButtonList(int roleId)
        {
            var list = ModuleService.GetModuleButtonList(roleId);
            var result = new { code = 0, count = list.Count(), data = list };
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}