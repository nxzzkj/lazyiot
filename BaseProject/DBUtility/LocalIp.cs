using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Scada.DBUtility
{
 public   class LocalIp
    {
        public  static string GetLocalIp()
        {
            ///获取本地的IP地址
            //string AddressIP = "127.0.0.1";
            //foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            //{
            //    if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
            //    {
            //        AddressIP = _IPAddress.ToString();
            //    }
            //}
            //return AddressIP;
           return  IPAddressSelector.Instance().AddressIP;
        }
    }
}
