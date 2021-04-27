using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScadaWeb.Model;
using ScadaWeb.IService;
using ScadaWeb.Web.Controllers;

namespace ScadaWeb.Web.Areas.Security.Controllers
{
    public class LogonLogController : BaseController
    {
        public ILogonLogService LogonLogService { get; set; }
        // GET: Security/LogonLog
        //这里Index其实可以省略，不省略的话就重写父类，吧菜单Id传过去
        public override ActionResult Index(int? id)
        {
            base.Index(id);
            return View();
        }
        [HttpGet]
        public JsonResult List(LogonLogModel model, PageInfo pageInfo)
        {
            var result = LogonLogService.GetListByFilter(model, pageInfo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            var result = LogonLogService.DeleteById(id) ? SuccessTip("删除成功") : ErrorTip("删除失败");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult BatchDel(string idsStr)
        {
            var idsArray = idsStr.Substring(0, idsStr.Length - 1).Split(',');
            var result = LogonLogService.DeleteByIds(idsArray) ? SuccessTip("批量删除成功") : ErrorTip("批量删除失败");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}