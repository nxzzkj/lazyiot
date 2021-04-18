using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMonitor
{
    public delegate void RecievedItemEventHandle(ReceiveItem item);
    public delegate void GetedItemEventHandle(List<ReceiveItem> items);
    public class ReceiveItem:IDisposable
    {
        public ReceiveItem()
        {
            Name = "";
            Id = "";
            Value = "-9999";
            DateTime = "";
            Address = "";
            Uid = "";
            Unit = "";
        }
        public string Name { set; get; }
        public string Id { set; get; }
        public string Value { set; get; }
        public string DateTime { set; get; }
        public string Address { set; get; }
        public string Uid { set; get; }
        public string Unit { set; get; }

        public void Dispose()
        {
            Id = "";
            Value = "";
            DateTime = "";
            Address = "";
            Uid = "";
 
        }
    }
    /// <summary>
    /// 定义一个缓存类,用于保存所有的数据
    /// </summary>
    public class ReceiveCachec:IDisposable
    {
        public event RecievedItemEventHandle OnPushed;
        public event GetedItemEventHandle OnGeted;
        private Object thisLock = new Object();
        /// <summary>
        /// 最大允许的缓存数据数量
        /// </summary>
        public  int MaxNumber = 200;
        public List<ReceiveItem> ReceiveItems = new List<ReceiveItem>();

        public void PushItem(ReceiveItem item)
        {
            lock(thisLock)
            {
                //总是将最新的数据放到最前头
                ReceiveItems.Insert(0, item);
                if (ReceiveItems.Count > MaxNumber)
                {
                    int rnum = ReceiveItems.Count - MaxNumber;
                    if (rnum > 0)
                        ReceiveItems.RemoveRange(ReceiveItems.Count - 1, rnum);
                }
                if (OnPushed != null)
                {
                    OnPushed(item);
                }
            }
           

        }
        /// <summary>
        /// 获取有效数据,每次获取数据则清空缓存
        /// </summary>
        public List<ReceiveItem> GetItems(int TimeSpan, string Id,string paraName)
        {
            List<ReceiveItem> items = new List<ReceiveItem>();

            DateTime end = DateTime.Now;
            DateTime start = DateTime.Now.AddSeconds(-TimeSpan);
            List<ReceiveItem> selectItems = ReceiveItems.FindAll(x => x.Id.ToString() == Id&& ScadaHexByteOperator.GetDateTime(x.DateTime) >start && ScadaHexByteOperator.GetDateTime(x.DateTime) <= end&&x.Name== paraName.Trim());
            
            if (OnGeted != null)
            {
                OnGeted(selectItems);
            }
            return selectItems;
        }
        public void Clear()
        {
            lock (thisLock)
            {
                ReceiveItems.Clear();
            }
        }

        public void Dispose()
        {
            lock (thisLock)
            {
                ReceiveItems.Clear();
                ReceiveItems = null;
            }

        }
    }
}
