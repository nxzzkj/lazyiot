using System.Web.Mvc;

namespace ScadaWeb.Web.Areas.WebRTC
{
    /// <summary>
    /// WebRTC音视频管理
    /// </summary>
    public class WebRTCAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WebRTC";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WebRTC_default",
                "WebRTC/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}