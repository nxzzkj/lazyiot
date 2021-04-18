﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
//using LTP.Accounts.Bus;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.Text;
namespace Maticsoft.Common
{
	/// <summary>
	/// 页面层(表示层)基类,所有页面继承该页面
	/// </summary>
	public class PageBase:System.Web.UI.Page
	{
        public int PermissionID = -1;//默认-1为无限制，可以在不同页面继承里来控制不同页面的权限
        string virtualPath = Maticsoft.Common.ConfigHelper.GetConfigString("VirtualPath");
        		
		/// <summary>
		/// 构造函数
		/// </summary>
		public PageBase()
		{
            //this.Load+=new EventHandler(PageBase_Load);
		}
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new System.EventHandler(PageBase_Load);
            this.Error += new System.EventHandler(PageBase_Error);
        }
        //错误处理
        protected void PageBase_Error(object sender, System.EventArgs e)
        {
            string errMsg;
            Exception currentError = Server.GetLastError();
            errMsg = "<link rel=\"stylesheet\" href=\"/style.css\">";
            errMsg += "<h1>系统错误：</h1><hr/>系统发生错误， " +
                "该信息已被系统记录，请稍后重试或与管理员联系。<br/>" +
                "错误地址： " + Request.Url.ToString() + "<br/>" +
                "错误信息： <font class=\"ErrorMessage\">" + currentError.Message.ToString() + "</font><hr/>" +
                "<b>Stack Trace:</b><br/>" +  currentError.ToString();
            Response.Write(errMsg);
            Server.ClearError();

        }
		private void PageBase_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack )
			{

                //权限验证
                if (Context.User.Identity.IsAuthenticated)
                {
                    AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
                    if (Session["UserInfo"] == null)
                    {
                        LTP.Accounts.Bus.User currentUser = new LTP.Accounts.Bus.User(user);
                        Session["UserInfo"] = currentUser;
                        Session["Style"] = currentUser.Style;
                        Response.Write("<script defer>location.reload();</script>");
                    }
                    if ((PermissionID != -1) && (!user.HasPermissionID(PermissionID)))
                    {
                        Response.Clear();
                        Response.Write("<script defer>window.alert('您没有权限进入本页！\\n请重新登录或与管理员联系');history.back();</script>");
                        Response.End();
                    }
                }
                else
                {
                    FormsAuthentication.SignOut();
                    Session.Clear();
                    Session.Abandon();
                    Response.Clear();
                    Response.Write("<script defer>window.alert('您没有权限进入本页或当前登录用户已过期！\\n请重新登录或与管理员联系！');parent.location='" + virtualPath + "/Login.aspx';</script>");
                    Response.End();
                }		
			}            
			
		}
	}
}
