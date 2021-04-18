using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GasMonitor
{
    public class ScadaHexByteOperator
    {
        /// <summary>
        /// 将时间字符串转换为时间对象
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime? GetDateTime(string dateTime)
        {
            try
            {
                string[] strArr = dateTime.Split(new char[] { '-', ' ', ':', ',' });
                if(strArr.Length==7)
                {
                    DateTime dt = new DateTime(int.Parse(strArr[0]),
                   int.Parse(strArr[1]),
                   int.Parse(strArr[2]),
                   int.Parse(strArr[3]),
                   int.Parse(strArr[4]),
                   int.Parse(strArr[5]),
                   int.Parse(strArr[6]));
                    return dt;
                }
                else if (strArr.Length == 6)
                {
                    DateTime dt = new DateTime(int.Parse(strArr[0]),
                      int.Parse(strArr[1]),
                      int.Parse(strArr[2]),
                      int.Parse(strArr[3]),
                      int.Parse(strArr[4]),
                      int.Parse(strArr[5]));
                    return dt;

                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public static string ObjectToJson(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// Json字符串转内存对象
        /// </summary>
        /// <param name="jsonString"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch 
            {
                return default(T);
            }
        }

        public static string AsciiToString(string ascii)
        {
            string result = "";
            byte[] RxdBuf = StrToHexByte(ascii);       //  定义接收缓冲区；
            for (int i = 0; i < RxdBuf.Length; i++)
            {
                ASCIIEncoding ASCIITochar = new ASCIIEncoding();
                char[] asc = ASCIITochar.GetChars(RxdBuf);      // 将接收字节解码为ASCII字符数组
                result += asc[i];

            }
            return result;
        }
        public static string StringToAscii(string value)
        {

            string result = "";
            string str = value.Trim();   // 去掉字符串首尾处的空格
            char[] charBuf = str.ToArray();    // 将字符串转换为字符数组
            ASCIIEncoding charToASCII = new ASCIIEncoding();

            byte[] TxdBuf = new byte[charBuf.Length];    // 定义发送缓冲区；
            TxdBuf = charToASCII.GetBytes(charBuf); 　　 // 转换为各字符对应的ASCII
            result = ByteToHexStr(TxdBuf);//将字节转为不带空格的16进制字符串
            return result;
        }
        public static byte[] StringToAsciiByte(string value)
        {
            string str = value.Trim();   // 去掉字符串首尾处的空格
            char[] charBuf = str.ToArray();    // 将字符串转换为字符数组
            ASCIIEncoding charToASCII = new ASCIIEncoding();
            byte[] TxdBuf = new byte[charBuf.Length];    // 定义发送缓冲区；
            TxdBuf = charToASCII.GetBytes(charBuf);    // 转换为各字符对应的ASCII

            return TxdBuf;
        }
        public static string AsciiByteToString(byte[] value)
        {
            ASCIIEncoding charToASCII = new ASCIIEncoding();
            string result = charToASCII.GetString(value);      // 将接收字节解码为ASCII字符数组

            return result;


        }

        public static byte[] StringToUTF8Byte(string value)
        {
            string str = value.Trim();   // 去掉字符串首尾处的空格
            byte[] TxdBuf = Encoding.UTF8.GetBytes(str);    // 将字符串转换为字符数组


            return TxdBuf;
        }
        public static string UTF8ByteToString(byte[] value)
        {

            string result = Encoding.UTF8.GetString(value);  // 将接收字节解码为ASCII字符数组

            return result;


        }
        /// <summary>
        /// 将16进制字符串转为字节
        /// </summary>
        /// <param name="da"></param>
        /// <returns></returns>
        public static byte[] StrToHexByte(string da)
        {
            string str = da;
            str = str.Replace(" ", "").Replace("\n", "").Replace("\r", "");
            int num = str.Length / 2;
            byte[] buffer = new byte[num];
            for (int i = 0; i < num; i++)
            {
                buffer[i] = Convert.ToByte(str.Substring(i * 2, 2), 0x10);
            }
            return buffer;
        }
        public static string ByteToHexStr(byte[] da)
        {
            string str = "";
            for (int i = 0; i < da.Length; i++)
            {
                str = str + Convert.ToString(da[i], 0x10);
            }
            return str;
        }
    }
    ///主动请求主题的Object
    [Serializable]
    public class MQTTPassiveSubTopicObject
    {
        /// <summary>
        /// 设备唯一标识,一般是工控机端唯一标识
        /// </summary>
        public string uid { set; get; }
        /// <summary>
        /// 服务器端刷新数据的时间
        /// </summary>
        public int updatecycle { set; get; }
        /// <summary>
        /// 服务器端数据订阅主题,用来接收用户的数据
        /// </summary>
        public string topic { set; get; }
    }
    ///定义西安亚泰的数据解析类
    [Serializable]
    public class PublicMqttJsonPara
    {
        public string name { set; get; }
        public List<Object> data { set; get; }

    }
    [Serializable]
    public class PublicMqttJsonDevice
    {
        public string uid { set; get; }
    }

    [Serializable]
    public class PublicMqttJsonObject
    {
        public PublicMqttJsonDevice device { set; get; }
        public List<PublicMqttJsonPara> paras
        {
            set; get;
        }
    }
}
