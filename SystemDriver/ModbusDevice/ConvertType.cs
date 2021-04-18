using IO_Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ModbusDevice
{
    /// <summary>
    /// 类型转换类
    /// </summary>
    public class ConvertType
    {
        public ConvertType()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 返回一个byte[]从第index个元素后长度为length的byte[]
        /// </summary>
        /// <param name="by"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] SubByteArray(byte[] by, int index, int length)
        {
            byte[] byr = new byte[length];
            for (int i = index; i < index + length; i++)
            {
                byr[i - index] = by[i];
            }
            return byr;
        }
        /// <summary>
        /// 返回一个byte[]从第index个元素后的byte[]
        /// </summary>
        /// <param name="by"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] SubByteArray(byte[] by, int index)
        {
            return SubByteArray(by, index, by.Length - index);

        }
        /// <summary>
        /// 返回两个byte数组连接后的byte数组。.
        /// </summary>
        public static byte[] ByteAdd(byte[] by1, byte[] by2)
        {
            int l1 = by1.Length;
            int l2 = by2.Length;
            byte[] by = new byte[l1 + l2];
            for (int i = 0; i < l1; i++)
            {
                by[i] = by1[i];
            }
            for (int i = 0; i < l2; i++)
            {
                by[i + l1] = by2[i];
            }
            return by;
        }
        /// <summary>
        /// "aabbcc"变为"ccbbaa"
        /// </summary>
        /// <param name="str">长度必需是偶数</param>
        /// <returns></returns>
        public static string StrTOStrV(string str)
        {
            string retn = "";
            int length = str.Length;
            for (int i = 0; i <= length - 2; i += 2)
            {
                retn = str.Substring(i, 2) + retn;
            }
            return retn;
        }


        /// <summary>
        /// 带空格的16进制字符串
        /// </summary>
        /// <param name="da"></param>
        /// <returns></returns>
        public static string ByteToHexStr(byte[] da)
        {
            string str = "";
            for (int i = 0; i < da.Length; i++)
            {
                str = str + Convert.ToString(da[i], 0x10).PadLeft(2, '0') + " ";
            }
            return str;
        }
        /// <summary>
        /// 不带空格的16进制字符串
        /// </summary>
        /// <param name="da"></param>
        /// <returns></returns>
        public static string ByteToHexStr2(byte[] da)
        {
            string str = "";
            for (int i = 0; i < da.Length; i++)
            {
                str = str + Convert.ToString(da[i], 0x10);
            }
            return str;
        }
        /// <summary>
        /// 把一个字节数组转化成十六进制的字符串形式
        /// </summary>
        public static string SingleByteToHexStr(byte da)
        {
            string s = "";

            s = Convert.ToString(da, 16).PadLeft(2, '0');

            return s;
        }
        /// <summary>
        /// 把诸如：23 fe e3 的字符串转化成byte[]
        /// </summary>
        /// <param name="da"></param>
        /// <returns></returns>
        public static byte[] StrToHexByte(string da)
        {
            string sends = da;
            sends = sends.Replace(" ", "");//去掉空格
            sends = sends.Replace("\n", "");
            sends = sends.Replace("\r", "");
            int length = sends.Length / 2;
            byte[] sendb = new byte[length];

            for (int i = 0; i < length; i++)
            {
                sendb[i] = Convert.ToByte(sends.Substring(i * 2, 2), 16);
            }

            return (sendb);
        }
        /// <summary>
        /// 判断是否数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDigit(string str)//判断是否数字
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!(str[i] >= '0' && str[i] <= '9'))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 把8位字符byt的从第begin字符到end字符转化为二进制字符串
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="byt"></param>
        /// <returns></returns>
        public static string BitDivision(int begin, int end, byte byt)
        {
            string str1 = "1";
            str1 = str1.PadRight(end - begin + 1, '1');
            str1 = str1.PadLeft(end, '0');
            str1 = str1.PadRight(8, '0');
            int a = Convert.ToInt32(str1, 2);
            int b = byt;
            int c = a & b;
            c = c >> (8 - end);
            return Convert.ToString(c, 2).PadLeft(end - begin + 1, '0');
        }

        /// <summary>
        /// 把二进制字符串转化为十六进制字符串.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToSix(string str)
        {
            long l = Convert.ToInt64(str, 2);
            return "0x" + Convert.ToString(l, 16).PadLeft(2, '0');
        }
        /// <summary>
        /// 把二进制字符串转化为十进制字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToTen(string str)
        {
            long l = Convert.ToInt64(str, 2);
            return Convert.ToString(l, 10);
        }
        /// <summary>
        /// "ef"-----"11101111"
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static string HexStrToBinStr(string hex)
        {
            int l = hex.Length * 4;
            return Convert.ToString(Convert.ToInt32(hex, 16), 2).PadLeft(l, '0');

        }
        /// <summary>
        /// "1110010"--------"1,1,1,0,0,1,0"
        /// </summary>
        /// <param name="bin"></param>
        /// <returns></returns>
        public static string BinDotBin(string bin)
        {
            string rtn = "";
            for (int i = 0; i < bin.Length; i++)
            {
                rtn += bin.Substring(i, 1) + ",";

            }
            return rtn.TrimEnd(new char[] { ',' });
        }
        #region  数据转换方法
        /// <summary>
        /// 将二进制值转ASCII格式十六进制字符串
        /// </summary>
        /// <paramname="data">二进制值</param>
        /// <paramname="length">定长度的二进制</param>
        /// <returns>ASCII格式十六进制字符串</returns>
        public static string toHexString(int data, int length)
        {
            string result = "";
            if (data > 0)
                result = Convert.ToString(data, 16).ToUpper();
            if (result.Length < length)
            {
                // 位数不够补0
                StringBuilder msg = new StringBuilder(0);
                msg.Length = 0;
                msg.Append(result);
                for (; msg.Length < length; msg.Insert(0, "0")) ;
                result = msg.ToString();
            }
            return result;
        }

        /// <summary>
        ///将16进制字符串转为指定类型的值
        /// </summary>
        /// <param name="data">16进制字符串</param>
        /// <returns></returns>
        public static object StringToBit(String data, Type type)
        {

            data = data.Replace(" ", "");//去掉空格
            data = data.Replace("\n", "");
            data = data.Replace("\r", "");
            if (data.Length <= 0)//必须大于0
                return -9999;
            if (data.Length % 2 != 0)//必须小于0
                return -9999;
            if (type == typeof(byte))
            {
                data = data.PadLeft(4, '0');
                byte[] intBuffer = new byte[2];

                intBuffer = StrToHexByte(data);
                return BitConverter.ToInt16(intBuffer, 0);

            }
            else if (type == typeof(sbyte))
            {

                data = data.PadLeft(4, '0');
                byte[] intBuffer = new byte[2];

                intBuffer = StrToHexByte(data);
                return BitConverter.ToInt16(intBuffer, 0);

            }
            else if (type == typeof(Int16))
            {

                data = data.PadLeft(4, '0');

                byte[] intBuffer = new byte[2];
                // 将16进制串按字节逆序化（一个字节2个ASCII码）
                intBuffer = StrToHexByte(data);
                return BitConverter.ToInt16(intBuffer, 0);

            }
            else if (type == typeof(UInt16))
            {

                data = data.PadLeft(4, '0');
                byte[] intBuffer = new byte[2];
                // 将16进制串按字节逆序化（一个字节2个ASCII码）
                intBuffer = StrToHexByte(data);
                return BitConverter.ToUInt16(intBuffer, 0);

            }
            ///int32
            else if (type == typeof(Int32))
            {

                data = data.PadLeft(8, '0');
                byte[] intBuffer = new byte[4];
                // 将16进制串按字节逆序化（一个字节2个ASCII码）
                intBuffer = StrToHexByte(data);
                return BitConverter.ToInt32(intBuffer, 0);

            }
            else if (type == typeof(UInt32))
            {

                data = data.PadLeft(8, '0');
                byte[] intBuffer = new byte[4];
                // 将16进制串按字节逆序化（一个字节2个ASCII码）
                intBuffer = StrToHexByte(data);
                return BitConverter.ToUInt32(intBuffer, 0);

            }
            ///int64
            else if (type == typeof(Int64))
            {

                data = data.PadLeft(16, '0');
                byte[] intBuffer = new byte[8];
                // 将16进制串按字节逆序化（一个字节2个ASCII码）
                intBuffer = StrToHexByte(data);
                return BitConverter.ToInt64(intBuffer, 0);

            }
            else if (type == typeof(UInt64))
            {

                data = data.PadLeft(16, '0');
                byte[] intBuffer = new byte[8];
                // 将16进制串按字节逆序化（一个字节2个ASCII码）
                intBuffer = StrToHexByte(data);
                return BitConverter.ToUInt64(intBuffer, 0);

            }
            ///int64
            else if (type == typeof(float))
            {

                data = data.PadLeft(8, '0');
                byte[] intBuffer = new byte[4];
                // 将16进制串按字节逆序化（一个字节2个ASCII码）
                intBuffer = StrToHexByte(data);
                return BitConverter.ToSingle(intBuffer, 0);

            }
            else if (type == typeof(double))
            {

                data = data.PadLeft(16, '0');
                byte[] intBuffer = new byte[8];
                // 将16进制串按字节逆序化（一个字节2个ASCII码）
                intBuffer = StrToHexByte(data);
                return BitConverter.ToDouble(intBuffer, 0);

            }
            else if (type == typeof(string))
            {

                int l = data.Length / 2;
                byte[] intBuffer = new byte[l];

                intBuffer = StrToHexByte(data);
                return ASCIIEncoding.Default.GetString(intBuffer);

            }
            else if (type == typeof(IPAddress))
            {
                string ipaddress = "";
                data = data.PadLeft(8, '0');
                byte[] intBuffer = new byte[4];
                // 将16进制串按字节逆序化（一个字节2个ASCII码）
                intBuffer = StrToHexByte(data);

                ipaddress += Convert.ToInt16(intBuffer[0]);
                ipaddress += "," + Convert.ToInt16(intBuffer[1]);
                ipaddress += "," + Convert.ToInt16(intBuffer[2]);
                ipaddress += "," + Convert.ToInt16(intBuffer[3]);
                return ipaddress;

            }
            return null;
        }

        /// <summary>
        ///将字节数组转为对应数值类
        /// </summary>
        /// <param name="data">16进制字符串</param>
        /// <returns></returns>
        public static object BytesToBit(byte[] ndatas, Type type, BitStoreMode storemodem)
        {
            //当前电脑是高位字节在前低位字节在后
            if (ndatas.Length <= 0)//必须大于0
                return -9999;
            if (ndatas.Length % 2 != 0)
            {
                return -9999;
            }

            byte[] data = new byte[ndatas.Length];
            if (storemodem == BitStoreMode.低位字节在前)
            {//如果是低位字节在前，则转换成当前的高位字节在前
                //for (int i = 0; i < ndatas.Length / 2; i++)
                //{
                //    data[i] = ndatas[i + 1];
                //    data[i + 1] = ndatas[i];
                //}
                data = ndatas.Reverse().ToArray();
            }
            else
            {
                //for (int i = 0; i < ndatas.Length / 2; i++)
                //{
                //    data[i] = ndatas[i];
                //    data[i + 1] = ndatas[i + 1];
                //}
                data = ndatas;
            }
            if (type == typeof(byte))
            {
                if (data.Length == 2)
                {


                    return BitConverter.ToInt16(data, 0);
                }



            }
            else if (type == typeof(sbyte))
            {

                if (data.Length == 2)
                {

                    return BitConverter.ToInt16(data, 0);
                }

            }
            else if (type == typeof(Int16))
            {
                if (data.Length == 2)
                {

                    return BitConverter.ToInt16(data, 0);

                }

            }
            else if (type == typeof(UInt16))
            {

                if (data.Length == 2)
                {

                    return BitConverter.ToUInt16(data, 0);

                }

            }
            ///int32
            else if (type == typeof(Int32))
            {

                if (data.Length == 4)
                {

                    return BitConverter.ToInt32(data, 0);

                }

            }
            else if (type == typeof(UInt32))
            {


                if (data.Length == 4)
                {

                    return BitConverter.ToUInt32(data, 0);

                }

            }
            ///int64
            else if (type == typeof(Int64))
            {


                if (data.Length == 8)
                {

                    return BitConverter.ToInt64(data, 0);

                }

            }
            else if (type == typeof(UInt64))
            {

                if (data.Length == 8)
                {

                    return BitConverter.ToUInt64(data, 0);

                }

            }
            ///int64
            else if (type == typeof(float))
            {

                if (data.Length == 4)
                {

                    return BitConverter.ToSingle(data, 0);

                }

            }
            else if (type == typeof(double))
            {

                if (data.Length == 8)
                {

                    return BitConverter.ToDouble(data, 0);

                }

            }
            else if (type == typeof(IPAddress))
            {

                if (data.Length == 4)
                {
                    string ipaddress = "";
                    ipaddress += Convert.ToInt16(data[0]);
                    ipaddress += "," + Convert.ToInt16(data[1]);
                    ipaddress += "," + Convert.ToInt16(data[2]);
                    ipaddress += "," + Convert.ToInt16(data[3]);
                    return ipaddress;

                }

            }
            else if (type == typeof(string))
            {


                return ASCIIEncoding.Default.GetString(data);

            }
            return null;
        }


        /// <summary>
        /// 将某个类型的数值转为在16进制字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static String BitToString(object data, BitStoreMode storemodem)
        {
            StringBuilder stringBuffer = new StringBuilder(0);
            byte[] intBuffer = new byte[0];
            if (typeof(sbyte) == data.GetType())//8位有符号
            {
                intBuffer = BitConverter.GetBytes((sbyte)data);
            }
            else if (typeof(byte) == data.GetType())//8位无符号
            {
                intBuffer = BitConverter.GetBytes((byte)data);
            }
            else if (typeof(Int16) == data.GetType())
            {
                intBuffer = BitConverter.GetBytes((Int16)data);
            }
            else if (typeof(UInt16) == data.GetType())
            {
                intBuffer = BitConverter.GetBytes((UInt16)data);
            }
            else if (typeof(Int32) == data.GetType())
            {
                intBuffer = BitConverter.GetBytes((Int32)data);
            }
            else if (typeof(UInt32) == data.GetType())
            {
                intBuffer = BitConverter.GetBytes((UInt32)data);
            }
            else if (typeof(Int64) == data.GetType())
            {
                intBuffer = BitConverter.GetBytes((Int64)data);
            }
            else if (typeof(UInt64) == data.GetType())
            {
                intBuffer = BitConverter.GetBytes((UInt64)data);
            }
            else if (typeof(float) == data.GetType())
            {
                intBuffer = BitConverter.GetBytes((float)data);
            }
            else if (typeof(double) == data.GetType())
            {
                intBuffer = BitConverter.GetBytes((double)data);
            }
            else if (typeof(string) == data.GetType())
            {
                intBuffer = ASCIIEncoding.Default.GetBytes(data.ToString());
            }
            else if (typeof(IPAddress) == data.GetType())
            {

            }
            byte[] ndatas = new byte[intBuffer.Length];
            if (storemodem == BitStoreMode.低位字节在前)
            {
                for (int i = 0; i < ndatas.Length / 2; i++)
                {
                    ndatas[i] = intBuffer[i + 1];
                    ndatas[i + 1] = intBuffer[i];
                }
            }
            else
            {
                ndatas = intBuffer;
            }
            for (int i = 0; i < ndatas.Length; i++)
            {
                stringBuffer.Insert(0, toHexString(ndatas[i] & 0xff, 2));
            }



            return stringBuffer.ToString();
        }

        /// <summary>
        /// 将某个类型的数值转转为字节数组
        /// </summary>
        /// <param name="data">要转换的值</param>
        /// <param name="unitnumber">输出的寄存器数量</param>
        /// <returns></returns>
        public static byte[] BitTobytes(object data, out int unitnumber, BitStoreMode storemodem)
        {
            StringBuilder stringBuffer = new StringBuilder(0);
            byte[] intBuffer = new byte[0];
            if (typeof(sbyte) == data.GetType())//8位有符号
            {
                intBuffer = BitConverter.GetBytes((sbyte)data);
            }
            else if (typeof(byte) == data.GetType())//8位无符号
            {
                intBuffer = BitConverter.GetBytes((byte)data);
            }
            else if (typeof(Int16) == data.GetType())
            {
                intBuffer = BitConverter.GetBytes((Int16)data);
            }
            else if (typeof(UInt16) == data.GetType())
            {
                intBuffer = BitConverter.GetBytes((UInt16)data);
            }
            else if (typeof(Int32) == data.GetType())
            {
                intBuffer = BitConverter.GetBytes((Int32)data);
            }
            else if (typeof(UInt32) == data.GetType())
            {
                intBuffer = BitConverter.GetBytes((UInt32)data);
            }
            else if (typeof(Int64) == data.GetType())
            {
                intBuffer = BitConverter.GetBytes((Int64)data);
            }
            else if (typeof(UInt64) == data.GetType())
            {
                intBuffer = BitConverter.GetBytes((UInt64)data);
            }
            else if (typeof(float) == data.GetType())
            {
                intBuffer = BitConverter.GetBytes((float)data);
            }
            else if (typeof(double) == data.GetType())
            {
                intBuffer = BitConverter.GetBytes((double)data);
            }
            else if (typeof(string) == data.GetType())
            {
                intBuffer = ASCIIEncoding.Default.GetBytes(data.ToString());
            }

            unitnumber = intBuffer.Length / 2;
            if (intBuffer.Length % 2 != 0)
            {
                unitnumber++;
                intBuffer[intBuffer.Length] = 0;

            }

            byte[] ndatas = new byte[intBuffer.Length];
            if (storemodem == BitStoreMode.低位字节在前)
            {
                for (int i = 0; i < ndatas.Length / 2; i++)
                {
                    ndatas[i] = intBuffer[i + 1];
                    ndatas[i + 1] = intBuffer[i];
                }
            }
            else
            {
                ndatas = intBuffer;
            }
            return ndatas;
        }


        #endregion
    }
}
