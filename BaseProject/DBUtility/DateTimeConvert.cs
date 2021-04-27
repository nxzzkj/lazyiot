using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.DBUtility
{
  public  class UnixDateTimeConvert
    {
        /// <summary>
        /// 将Unix时间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="d">double 型数字</param>
        /// <returns>DateTime</returns>
        public static System.DateTime ConvertIntDateTime(long d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddMilliseconds(d);
            return time;
        }

        /// <summary>
        /// 将c# DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>long</returns>
        public static long ConvertDateTimeInt(System.DateTime time)
        {
            if (time != null)
            {


                System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
                //intResult = (time- startTime).TotalMilliseconds;
                long t = (time.Ticks - startTime.Ticks) / 10000;            //除10000调整为13位
                return t;
            }
            else
            {
                return 0;
            }
        }
    }
}
