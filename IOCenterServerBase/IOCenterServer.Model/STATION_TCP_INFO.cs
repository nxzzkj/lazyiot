using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Model
{
    /// <summary>
    /// 用户连接登录信息
    /// </summary>
    public class STATION_TCP_INFO
    {
        public string USER = "";
        public string PASSWROD = "";
        public string IO_SERVER_ID = "";
        public string IO_SERVER_IP = "";
        public string RESULT = "false";
        public string MSG = "";
        public string FUNCTION = "IOMonitor";
        public string GetCommandString()
        {
            return "USER:" + USER + "#PASSWROD:" + PASSWROD + "#IO_SERVER_ID:" + IO_SERVER_ID + "#IO_SERVER_IP:" + IO_SERVER_IP.Split(':')[0] + "#RESULT:" + RESULT+ "#MSG:"+ MSG+ "#FUNCTION:"+ FUNCTION;
        }
    }
   
}
