using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scada.Kernel
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
            TxdBuf = charToASCII.GetBytes(charBuf); 　　 // 转换为各字符对应的ASCII
            
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
        public static   string ByteToHexStr(byte[] da)
        {
            string str = "";
            for (int i = 0; i < da.Length; i++)
            {
                str = str + Convert.ToString(da[i], 0x10);
            }
            return str;
        }
    }
   public  class ScadaResult
    {
        public bool Result = false;
        public string Message = "";
        public ScadaResult()
        {
            Result = true;
            Message = "参数有效";

        }
        public ScadaResult(bool res,string msg)
        {
            Result = res;
            Message = msg;
        }
    }
    public class ParaItem
    {
        public string Key = "";
        public string Value = "";
    }
    public class ParaPack : IDisposable
    {
        private string ParaString = "";
        public ParaPack()
        {
            Items.Clear();
        }
        public void Dispose()
        {
            ParaString = "";
            Items.Clear();
            Items = null;


        }
        public ParaPack(string parastr)
        {
            Items.Clear();

            ParaString = parastr;
            if(ParaString!=null&& ParaString!="")
            {
                string[] items = parastr.Split(new char[2] { ',', ':' });
                for (int i = 0; i < items.Length; i += 2)
                {
                    try
                    {
                        Items.Add(new ParaItem()
                        {
                            Key = items[i],
                            Value = items[i + 1].Trim(),
                        });
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
           

        }
        List<ParaItem> Items = new List<ParaItem>();
        public string GetValue(string Key)
        {
            if (Items.Exists(x => x.Key.Trim() == Key.Trim()))
            {
                return Items.Find(x => x.Key.Trim() == Key.Trim()).Value.Trim();
            }
            return "";
        }
        public void AddItem(string mKey, string mValue)
        {
            Items.Add(new ParaItem()
            {
                Key = mKey,
                Value = mValue==null?"":mValue.Trim()

            });
        }
        public void AddItem(string mKey, Control mValue)
        {
            string v = "";
            if (mValue.GetType() == typeof(TextBox))
            {
                TextBox tb = (TextBox)mValue;
                v = tb.Text.Trim();
            }
            if (mValue.GetType() == typeof(NumericUpDown))
            {
                NumericUpDown tb = (NumericUpDown)mValue;
                v = tb.Value.ToString();
            }
            if (mValue.GetType() == typeof(ComboBox))
            {
                ComboBox tb = (ComboBox)mValue;
                v = tb.SelectedItem.ToString();
            }
            if (mValue.GetType() == typeof(CheckBox))
            {
                CheckBox tb = (CheckBox)mValue;
                v = tb.Checked ? "1" : "0";
                 
            }
            if (mValue.GetType() == typeof(RadioButton))
            {
                RadioButton tb = (RadioButton)mValue;
                v = tb.Checked ? "1" : "0";
               
            }
            Items.Add(new ParaItem()
            {
                Key = mKey,
                Value = mValue == null ? "" : v.Trim()

            });
        }
        public void SetCtrlValue(Control ctrl,object mKey)
        {
            if (mKey == null || mKey.ToString() == "")
                return;
            if(ctrl.GetType()==typeof(TextBox))
            {
                TextBox tb = (TextBox)ctrl;
                tb.Text = mKey.ToString();
            }
            if (ctrl.GetType() == typeof(NumericUpDown))
            {
                NumericUpDown tb = (NumericUpDown)ctrl;
                if(mKey!=null&& mKey.ToString()!="")
                tb.Value =decimal.Parse(mKey.ToString().Trim());
            }
            if (ctrl.GetType() == typeof(ComboBox))
            {
                ComboBox tb = (ComboBox)ctrl;
                for (int i = 0; i < tb.Items.Count; i++)
                {
                    if(tb.Items[i].ToString()== mKey.ToString())
                    {
                        tb.SelectedIndex = i;
                        break;
                    }
                }
            }
            if (ctrl.GetType() == typeof(CheckBox))
            {
                CheckBox tb = (CheckBox)ctrl;
                if(mKey.ToString()=="1"|| mKey.ToString().ToLower()=="true")
                {
                    tb.Checked = true;
                }
                else
                {
                    tb.Checked = false;
                }
            }
            if (ctrl.GetType() == typeof(RadioButton))
            {
                RadioButton tb = (RadioButton)ctrl;
                if (mKey.ToString() == "1" || mKey.ToString().ToLower() == "true")
                {
                    tb.Checked = true;
                }
                else
                {
                    tb.Checked = false;
                }
            }
        }
        public int Count
        {
            get { return Items.Count; }
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Items.Count; i++)
            {
                str += (str == "" ? "" : ",") + Items[i].Key + ":" + Items[i].Value.Trim();

            }
            ParaString = str;
            return ParaString.ToString();
        }


    }
}
