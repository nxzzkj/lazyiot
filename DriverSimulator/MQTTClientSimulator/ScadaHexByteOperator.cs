

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 宁夏众智科技有限公司 版权所有。 
// 开源版本代码仅限个人技术研究使用，未经作者允许严禁商用。宁夏众智科技有限公司是一家油田自动化行业经营多年的软件开发公司，公司承接OA、工控、组态、微信小程序等开发。
// 对于本系统的相关版权归属宁夏众智科技所有，如果本系统使用第三方开源模块，该模块版权归属原作者所有。
// 请大家尊重作者的劳动成果，共同促进行业健康发展。
// 相关技术交流群89226196 ,作者QQ:249250126 作者微信18695221159 邮箱:my820403@126.com
// 创建者：马勇
//----------------------------------------------------------------*/
#endregion
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTClientSimulator
{
    public class ScadaHexByteOperator
    {
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
            catch (Exception emx)
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
}
