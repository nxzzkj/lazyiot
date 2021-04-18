using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScadaWeb.Common;

namespace ScadaWeb.Web.Areas.SysSet.Models
{
    public class EmailModel
    {
        /// <summary>
        /// SMTP服务器
        /// </summary>
        public string EmailSmtp { get; set; }
        /// <summary>
        /// SSL加密连接
        /// </summary>
        public string EmailSSL { get; set; }
        /// <summary>
        /// SMTP端口
        /// </summary>
        public string EmailPort { get; set; }
        /// <summary>
        /// 发件人地址
        /// </summary>
        public string EmailFrom { get; set; }
        /// <summary>
        /// 邮箱账号
        /// </summary>
        public string MailUserName { get; set; }
        /// <summary>
        /// 邮箱密码
        /// </summary>
        public string MailPassword { get; set; }
        /// <summary>
        /// 发件人昵称
        /// </summary>
        public string MailName { get; set; }

        public EmailModel GetEmailInfo()
        {
            return new EmailModel
            {
                EmailSmtp = Configs.GetValue("EmailSmtp"),
                EmailSSL = Configs.GetValue("EmailSSL"),
                EmailPort = Configs.GetValue("EmailPort"),
                EmailFrom = Configs.GetValue("EmailFrom"),
                MailUserName = Configs.GetValue("MailUserName"),
                MailPassword = Configs.GetValue("MailPassword"),
                MailName = Configs.GetValue("MailName")
            };
        }

        public void SetEmailInfo(EmailModel model)
        {
            Configs.SetValue("EmailSmtp", model.EmailSmtp);
            Configs.SetValue("EmailSSL", model.EmailSSL);
            Configs.SetValue("EmailPort", model.EmailPort);
            Configs.SetValue("EmailFrom", model.EmailFrom);
            Configs.SetValue("MailUserName", model.MailUserName);
            Configs.SetValue("MailPassword", model.MailPassword);
            Configs.SetValue("MailName", model.MailName);
        }
    }
}