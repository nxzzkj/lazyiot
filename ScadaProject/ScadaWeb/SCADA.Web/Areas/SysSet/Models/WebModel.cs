using ScadaWeb.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScadaWeb.Web.Areas.SysSet.Models
{
    public class WebModel
    {
        /// <summary>
        /// 网站名称
        /// </summary>
        public string SiteName { get; set; }
        /// <summary>
        /// 网站域名
        /// </summary>
        public string SiteDomain { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Corporate { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 公司座机
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 首页标题
        /// </summary>
        public string HomeTitle { get; set; }
        /// <summary>
        /// META关键词:多个关键词用英文状态 , 号分割
        /// </summary>
        public string MetaKey { get; set; }
        /// <summary>
        /// META描述
        /// </summary>
        public string MetaDescribe { get; set; }
        /// <summary>
        /// 网站备案号
        /// </summary>
        public string Record { get; set; }
        /// <summary>
        /// 版权信息
        /// </summary>
        public string CopyRight { get; set; }
        public WebModel GetWebInfo()
        {
            return new WebModel
            {
                SiteName = Configs.GetValue("SiteName"),
                SiteDomain = Configs.GetValue("SiteDomain"),
                Corporate = Configs.GetValue("Corporate"),
                Address = Configs.GetValue("Address"),
                Tel = Configs.GetValue("Tel"),
                Phone = Configs.GetValue("Phone"),
                Email = Configs.GetValue("Email"),
                HomeTitle = Configs.GetValue("HomeTitle"),
                MetaKey = Configs.GetValue("MetaKey"),
                MetaDescribe = Configs.GetValue("MetaDescribe"),
                Record = Configs.GetValue("Record"),
                CopyRight = Configs.GetValue("CopyRight")
            };
        }

        public void SetWebInfo(WebModel model)
        {
            Configs.SetValue("SiteName", model.SiteName);
            Configs.SetValue("SiteDomain", model.SiteDomain);
            Configs.SetValue("Corporate", model.Corporate);
            Configs.SetValue("Address", model.Address);
            Configs.SetValue("Tel", model.Tel);
            Configs.SetValue("Phone", model.Phone);
            Configs.SetValue("Email", model.Email);
            Configs.SetValue("HomeTitle", model.HomeTitle);
            Configs.SetValue("MetaKey", model.MetaKey);
            Configs.SetValue("MetaDescribe", model.MetaDescribe);
            Configs.SetValue("Record", model.Record);
            Configs.SetValue("CopyRight", model.CopyRight);
        }
    }
}