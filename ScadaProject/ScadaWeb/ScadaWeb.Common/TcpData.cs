using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Common
{

    /// <summary>
    /// 传递过来的数据标识
    /// </summary>
    public enum ScadaTcpOperator
    {
        
        下置命令 = 13,
        下置反馈 = 14,
        报警设置=38,
        报警设置反馈=39

    }
    public class TcpDataItem
    {
        public string Key = "";
        public string Value = "";
    }
    public class TcpData : IDisposable
    {
        public TcpData()
        {

        }
        public string TcpDataString = "";
        public List<TcpDataItem> Items = new List<TcpDataItem>();
        public ScadaTcpOperator TcpOperator = ScadaTcpOperator.下置命令;
        public byte[] Datas = null;
        public bool IsInvalid = false;
        public TcpDataItem GetItem(string key)
        {
            return Items.Find(x => x.Key.Trim() == key.Trim());
        }
        public string GetItemValue(string key)
        {
            TcpDataItem item = Items.Find(x => x.Key.Trim() == key.Trim());
            if (item != null)
                return item.Value.Trim();
            return "ERROR";
        }
        public void Dispose()
        {
            TcpDataString = "";

            Items = null;
            Datas = null;
        }
        public void ChangedToBytes()
        {
            Datas = Encoding.UTF8.GetBytes(TcpItemToString());

        }

        public void BytesToTcpItem(byte[] datas)
        {
            Dispose();
            Items = new List<TcpDataItem>();
            try
            {


                TcpDataString = Encoding.UTF8.GetString(datas, 0, datas.Length);
                string[] parastrs = TcpDataString.Split('#');
                for (int i = 0; i < parastrs.Length; i++)
                {
                    string[] itemstrs = parastrs[i].Split(':');
                    if (itemstrs.Length == 2)
                    {
                        TcpDataItem item = new TcpDataItem();
                        item.Key = itemstrs[0];
                        item.Value = itemstrs[1];
                        Items.Add(item);
                    }
                    else if (itemstrs.Length == 1)
                    {
                        TcpDataItem item = new TcpDataItem();
                        item.Key = itemstrs[0];
                        item.Value = "";
                        Items.Add(item);
                    }


                }
                Datas = datas;
                IsInvalid = true;
            }
            catch (Exception ex)
            {
                TcpDataString = ex.Message;
                IsInvalid = false;

            }

        }
        public string TcpItemToString(List<TcpDataItem> items)
        {
            string str = "";
            for (int i = 0; i < items.Count; i++)
            {
                str += items[i].Key + ":" + items[i].Value + "#";
            }
            if (str != "")
            {
                str = str.Remove(str.Length - 1, 1);
            }
            return str;
        }
        public string TcpItemToString()
        {
            string str = "";
            for (int i = 0; i < Items.Count; i++)
            {
                str += Items[i].Key + ":" + Items[i].Value + "#";
            }
            if (str != "")
            {
                str = str.Remove(str.Length - 1, 1);
            }
            return str;
        }
        /// <summary>
        /// 将字符串构造成一个网络单元数据体
        /// </summary>
        /// <param name="str"></param>
        /// <param name="heads"></param>
        /// <param name="op"></param>
        /// <returns></returns>
        public byte[] StringToTcpByte(string str, ScadaTcpOperator op)
        {
            byte[] contbytes = Encoding.UTF8.GetBytes(str);
            byte opbyte = (byte)op;
            List<byte> allbytes = new List<byte>();
            allbytes.Add(opbyte);
            allbytes.AddRange(contbytes);
            return allbytes.ToArray();
        }
        public byte[] StringToTcpByte(ScadaTcpOperator op)
        {
            byte[] contbytes = Encoding.UTF8.GetBytes(TcpItemToString());
            byte opbyte = (byte)op;
            List<byte> allbytes = new List<byte>();
            allbytes.Add(opbyte);
            allbytes.AddRange(contbytes);
            return allbytes.ToArray();
        }
        public static byte[] StaticStringToTcpByte(string str, ScadaTcpOperator op)
        {
            byte[] contbytes = Encoding.UTF8.GetBytes(str);
            byte opbyte = (byte)op;
            List<byte> allbytes = new List<byte>();
            allbytes.Add(opbyte);
            allbytes.AddRange(contbytes);
            return allbytes.ToArray();
        }

    }
}
