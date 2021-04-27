using ScadaWeb.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScadaWeb.Web
{
    public class HandlerErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
            context.Result = new ContentResult { Content = new AjaxResult { state = ResultType.error.ToString(), message = context.Exception.Message }.ToJson() };
        }
    }
}