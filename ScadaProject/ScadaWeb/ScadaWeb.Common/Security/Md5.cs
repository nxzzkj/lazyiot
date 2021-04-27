using System.Security.Cryptography;
using System.Text;

namespace ScadaWeb.Common
{
    public class Md5
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">加密字符</param>
        /// <param name="code">加密位数16/32</param>
        /// <returns></returns>
        public static string md5(string str, int bit)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedDataBytes;
            hashedDataBytes = md5Hasher.ComputeHash(Encoding.GetEncoding("gb2312").GetBytes(str));
            StringBuilder tmp = new StringBuilder();
            foreach (byte i in hashedDataBytes)
            {
                tmp.Append(i.ToString("x2"));
            }
            if (bit == 16)
                return tmp.ToString().Substring(8, 16);
            else
            if (bit == 32) return tmp.ToString();//默认情况
            else return string.Empty;
        }
    }
}
