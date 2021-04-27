using System.Web;
using System.Web.Mvc;

namespace ScadaWeb.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //默认的异常提示 HandleErrorAttribute
            //自定义异常提示(Handler下的 HandlerErrorAttribute)
            filters.Add(new HandlerErrorAttribute());
        }
    }
}
