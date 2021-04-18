using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScadaWeb.Web.Areas.SysSet.Models;
using ScadaWeb.Model;
using ScadaWeb.Common;
using System.IO;
using ScadaWeb.IService;
using ScadaWeb.Web.Controllers;

namespace ScadaWeb.Web.Areas.API.Controllers
{
    /// <summary>
    /// 系统web端口相关的API 所有方法返回均是Json
    /// </summary>
    public class APIController : Controller
    {
        public ActionResult Index()
        {

            return View(new WebModel().GetWebInfo());
        }
        public IUserService UserService { get; set; }
        public ILogonLogService LogonLogService { get; set; }
        public IScadaFlowProjectService ProjectServer { get; set; }
        public IScadaFlowViewService ViewServer { get; set; }
        public sealed class loginModel
        {
            public string username { set; get; }
            public string password { set; get; }
            public string viewId { set; get; }
            public string ReturnViewId { set; get; }
            public string projId { set; get; }


        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Login(loginModel model)
        {
            string username = model.username, password = model.password, viewId = model.viewId, projId= model.projId;
            AjaxResult error = new AjaxResult { state = ResultType.error.ToString(), message = "登录失败" };
            AjaxResult success = new AjaxResult { state = ResultType.success.ToString(), message = "登录成功" };
            var result = error.SetMsg("禁止登录");
            LogonLogModel logEntity = new LogonLogModel();
            logEntity.LogType = DbLogType.Login.ToString();
            try
            {
                ScadaFlowProjectModel Project = null;
                if (viewId != null && viewId != "" && viewId != "0")
                {
                    ScadaFlowViewModel view = ViewServer.GetByWhere(" where  ViewId='" + viewId + "'").First();
                    if (view != null)
                    {
                        Project = ProjectServer.GetByWhere(" where ProjectId='" + view.ProjectId + "'").First();
                        model.projId = Project.Id.ToString();
                        model.viewId = view.ViewId;
                    }
                    string nickname = "";
                    bool isUser = ProjectServer.LoginOn(username, password, Project.Id.ToString(), out nickname);
                    if (isUser == true)
                    {

                        OperatorModel operatorModel = new OperatorModel();
                        operatorModel.UserId = 0;
                        operatorModel.Account = username;
                        operatorModel.RealName = nickname;
                        operatorModel.HeadIcon = "";
                        operatorModel.RoleId = 0;
                        operatorModel.LoginIPAddress = Net.Ip;
                        operatorModel.LoginIPAddressName = Net.GetLocation(Net.Ip);
                        OperatorFlowProvider.Provider.AddCurrent(operatorModel);
                        logEntity.Account = username;
                        logEntity.RealName = nickname;
                        logEntity.Description = Project.Title + "(" + Project.Id + ")工程的 " + nickname + "登陆成功！";
                        LogonLogService.WriteDbLog(logEntity);
                        result = success.SetMsg(nickname + "登陆成功");
                        result.data = Json(model).Data;

                        return Json(result);
                    }
                    else
                    {
                        result = error.SetMsg("用户名或密码错误");
                        return Json(result);

                    }
                }
                else
                {
                    logEntity.Account = username;
                    logEntity.RealName = username;
                    logEntity.Description = "登录失败，登录页面不存在"; 
                    LogonLogService.WriteDbLog(logEntity);
                    result = error.SetMsg(logEntity.Description);
                    return Json(result);
                }
            }
            catch (Exception ex)
            {
                logEntity.Account = username;
                logEntity.RealName = username;
                logEntity.Description = "登录失败，" + ex.Message;
                LogonLogService.WriteDbLog(logEntity);
                result = error.SetMsg(logEntity.Description);
            
                return Json(result);


            }
        }
        /// <summary>
        /// 用户退出登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult LoginOut()
        {
            AjaxResult error = new AjaxResult { state = ResultType.error.ToString(), message = "退出登录失败" };
            AjaxResult success = new AjaxResult { state = ResultType.success.ToString(), message = "退出登录成功" };
            LogonLogService.WriteDbLog(new LogonLogModel
            {
                LogType = DbLogType.Exit.ToString(),
                Account = OperatorFlowProvider.Provider.GetCurrent().Account,
                RealName = OperatorFlowProvider.Provider.GetCurrent().RealName,
                Description = "安全退出系统",
            });
            Session.Abandon();
            Session.Clear();
            OperatorFlowProvider.Provider.RemoveCurrent();
            return Json(success);
        }
    }
}