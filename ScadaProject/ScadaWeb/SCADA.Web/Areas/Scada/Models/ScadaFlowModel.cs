using ScadaWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScadaWeb.Web.Areas.Scada.Models
{

    public class ScadaFlowModel
    {
        /// <summary>
        /// 当前工程
        /// </summary>
        public ScadaFlowProjectModel Project = null;
        /// <summary>
        /// 系统主页
        /// </summary>
        public ScadaFlowViewModel MainView = null;
    }
}