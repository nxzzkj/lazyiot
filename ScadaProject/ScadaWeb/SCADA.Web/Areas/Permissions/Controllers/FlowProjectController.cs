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
    public class FlowProjectController : BaseController
    {
        public IScadaFlowProjectService FlowProjectService { get; set; }
        public IScadaFlowViewService FlowViewService { get; set; }
        // GET: Permissions/User
        public override ActionResult Index(int? id)
        {
            base.Index(id);
            return View();
        }
        [HttpGet]
        public JsonResult List(ScadaFlowProjectModel model, PageInfo pageInfo)
        {
            var result = FlowProjectService.GetListByFilter(model, pageInfo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
       
        public ActionResult Edit(int id)
        {
           
            var model = FlowProjectService.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ScadaFlowProjectModel model)
        {
            var newmodel = FlowProjectService.GetById(model.Id);
            newmodel.UpdateTime = DateTime.Now;
            newmodel.UpdateUserId = Operator.UserId;
            newmodel.CreateTime = DateTime.Now;
            newmodel.CreateUserId = Operator.UserId;
            newmodel.Title = model.Title;
        
            var result = FlowProjectService.UpdateById(newmodel) ? SuccessTip("修改成功") : ErrorTip("修改失败");
            return Json(result);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            bool res = FlowProjectService.DeleteById(id);
            if(res)
            {
                FlowViewService.DeleteByWhere(" ProjectId='"+ id + "'");
            }
            var result = res ? SuccessTip("删除成功") : ErrorTip("删除失败");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
      
 
    }
}