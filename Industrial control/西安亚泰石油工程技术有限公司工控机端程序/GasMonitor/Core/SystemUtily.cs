using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMonitor
{
  public static  class SystemUtily
    {
        public static long GuidToLongID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        public static long GuidToLongID(Guid GUID)
        {
            byte[] buffer = GUID.ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }
        /// <summary>
        /// 获取本机所有串口
        /// </summary>
        /// <returns></returns>
        public static string[]  GetSeriePort()
        {
            try
            {
                string[] ArryPort = SerialPort.GetPortNames();
                return ArryPort;
            }
            catch
            {
                return new string[0];
            }
        }
    }
}
