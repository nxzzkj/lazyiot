using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScadaWeb.Web.Areas.Scada.Models
{
 
    public class WellCommandModel
    {
        public WellCommandModel()
        {
            writevalue = "0";
            valuetype = "布尔值";
            msg = "";
            successresult = "";
            timeout = 10;
            faultresult = "";
            returnresult = false;
         
        }
         
        public string writevalue { set; get; }
        public string valuetype { set; get; }
        public string msg { set; get; }
        public string successresult { set; get; }
        public string faultresult { set; get; }
        public bool returnresult { set; get; }
        public string io { set; get; }
        public string return_io { set; get; }
        public int timeout { set; get; }
    }
}