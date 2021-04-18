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
    public class UserController : BaseController
    {
        public IUserService UserService { get; set; }
        public IOrganizeService OrganizeService { get; set; }
        public IRoleService RoleService { get; set; }
        public SelectList OrganizeList { get { return new SelectList(OrganizeService.GetAll("Id,FullName", "ORDER BY SortCode ASC"), "Id", "FullName"); } }
        public SelectList RoleList { get { return new SelectList(RoleService.GetAll("Id,FullName", "ORDER BY SortCode ASC"), "Id", "FullName"); } }

        // GET: Permissions/User
        public override ActionResult Index(int? id)
        {
            base.Index(id);
            return View();
        }
        [HttpGet]
        public JsonResult List(UserModel model, PageInfo pageInfo)
        {
            var result = UserService.GetListByFilter(model, pageInfo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            ViewBag.UploadFileSize = Configs.GetValue("UploadFileSize");
            ViewBag.UploadFileType = Configs.GetValue("UploadFileType");
            ViewBag.OrganizeList = OrganizeList;
            ViewBag.RoleList = RoleList;
            return View();
        }
        [HttpPost]
        public ActionResult Add(UserModel model)
        {
            model.UserPassword = Md5.md5(Configs.GetValue("InitUserPwd"), 32);
            model.CreateTime = DateTime.Now;
            model.CreateUserId = Operator.UserId;
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            var result = UserService.Insert(model) ? SuccessTip("添加成功") : ErrorTip("添加失败");
            return Json(result);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.UploadFileSize = Configs.GetValue("UploadFileSize");
            ViewBag.UploadFileType = Configs.GetValue("UploadFileType");
            ViewBag.OrganizeList = OrganizeList;
            ViewBag.RoleList = RoleList;
            var model = UserService.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            var result = UserService.UpdateById(model) ? SuccessTip("修改成功") : ErrorTip("修改失败");
            return Json(result);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            var result = UserService.DeleteById(id) ? SuccessTip("删除成功") : ErrorTip("删除失败");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult BatchDel(string idsStr)
        {
            var idsArray = idsStr.Substring(0, idsStr.Length - 1).Split(',');
            var result = UserService.DeleteByIds(idsArray) ? SuccessTip("批量删除成功") : ErrorTip("批量删除失败");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult InitPwd(int id)
        {
            var pwd = Configs.GetValue("InitUserPwd");
            var initPwd = Md5.md5(pwd, 32);
            UserModel model = new UserModel { Id = id, UserPassword = initPwd };
            var result = UserService.UpdateById(model, "UserPassword") ? SuccessTip("重置密码成功，新密码:" + pwd) : ErrorTip("重置密码失败");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserInfo()
        {
            ViewBag.UploadFileSize = Configs.GetValue("UploadFileSize");
            ViewBag.UploadFileType = Configs.GetValue("UploadFileType");
            int userId = Operator.UserId;
            var model = UserService.GetById(userId);
            return View(model);
        }
        public ActionResult UserPwd()
        {
            ViewBag.UserName = Operator.Account;
            return View();
        }
        [HttpPost]
        public ActionResult ModifyUserPwd(ModifyPwd model)
        {
            int userId = Operator.UserId;
            var result = ErrorTip("出现异常，密码修改失败");
            if (UserService.LoginOn(model.UserName, Md5.md5(model.OldPassword, 32)) == null)
            {
                result = ErrorTip("旧密码不正确");
            }
            else
            {
                result = UserService.ModifyUserPwd(model, userId) > 0 ? SuccessTip("密码修改成功") : ErrorTip("密码修改失败");
            }
            return Json(result);
        }
    }
}