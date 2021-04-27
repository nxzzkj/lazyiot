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
    public class RoleAuthorizeController : BaseController
    {
        public IRoleAuthorizeService RoleAuthorizeService { get; set; }

        // GET: Permissions/RoleAuthorize
        public override ActionResult Index(int? id)
        {
            base.Index(id);
            return View();
        }

        [HttpPost]
        public ActionResult InsertBatch(IEnumerable<RoleAuthorizeModel> list, int roleId)
        {
            var result = RoleAuthorizeService.SavePremission(list, roleId) > 0 ? SuccessTip("保存成功") : ErrorTip("保存失败");
            return Json(result);
        }
    }
}