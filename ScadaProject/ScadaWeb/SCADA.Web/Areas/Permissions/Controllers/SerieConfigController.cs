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
    public class SerieConfigController : BaseController
    {
        public ISerieConfigService SerieService { get; set; }
            // GET: Permissions/User
        public override ActionResult Index(int? id)
        {
            base.Index(id);
            return View();
        }
        [HttpGet]
        public JsonResult List(SerieConfigModel model, PageInfo pageInfo)
        {
            var result = SerieService.GetListByFilter(model, pageInfo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Add(SerieConfigModel model)
        {
           
            model.CreateTime = DateTime.Now;
            model.CreateUserId = Operator.UserId;
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            var result = SerieService.Insert(model) ? SuccessTip("添加成功") : ErrorTip("添加失败");
            return Json(result);
        }
        public ActionResult Edit(int id)
        {
         
       
            var model = SerieService.GetById(id);
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(SerieConfigModel model)
        {
            if (model.ShowLegend == "on")
                model.ShowLegend = "1";
            else
                model.ShowLegend = "0";

            if (model.ShowSymbol == "on")
                model.ShowSymbol = "1";
            else
                model.ShowSymbol = "0";

            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            var result = SerieService.UpdateById(model) ? SuccessTip("修改成功") : ErrorTip("修改失败");
            return Json(result);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            var result = SerieService.DeleteById(id) ? SuccessTip("删除成功") : ErrorTip("删除失败");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult BatchDel(string idsStr)
        {
            var idsArray = idsStr.Substring(0, idsStr.Length - 1).Split(',');
            var result = SerieService.DeleteByIds(idsArray) ? SuccessTip("批量删除成功") : ErrorTip("批量删除失败");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
         
    }
}