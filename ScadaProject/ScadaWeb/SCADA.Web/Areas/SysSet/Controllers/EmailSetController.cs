using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScadaWeb.Web.Controllers;
using ScadaWeb.Web.Areas.SysSet.Models;

namespace ScadaWeb.Web.Areas.SysSet.Controllers
{
    public class EmailSetController : BaseController
    {
        // GET: SysSet/EmailSet
        public override ActionResult Index(int? id)
        {
            return View(new EmailModel().GetEmailInfo());
        }
        [HttpPost]
        public ActionResult Index(EmailModel model)
        {
            try
            {
                new EmailModel().SetEmailInfo(model);
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "Error:" + ex.Message;
                return View(new EmailModel().GetEmailInfo());
            }
            ViewBag.Msg = "修改成功！";
            return View(new EmailModel().GetEmailInfo());
        }
    }
}