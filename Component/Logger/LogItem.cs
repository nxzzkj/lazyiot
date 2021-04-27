using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scada.Logger
{
    public enum LogLevel
    {
        Debug = 0,
        Info,
        Warn,
        Error,
        Fatal,
        Off
    }

    public class LogItem
    {
        private LogLevel logLevel;
        private string logMsg;
        private string logDate;

        /// <summary> 
        /// 记录等级 
        /// </summary> 
        public LogLevel LogLevel
        {
            get { return logLevel; }
            set { logLevel = value; }
        }

        /// <summary> 
        /// 记录信息 
        /// </summary> 
        public string LogMsg
        {
            get { return logMsg; }
            set { logMsg = value; }
        }

        /// <summary> 
        /// 记录时间 
        /// </summary> 
        public string LogDate
        {
            get { return logDate; }
            set { logDate = value; }
        }

        public LogItem(LogLevel logLevel, string logMsg, string logDate)
        {
            this.logLevel = logLevel;
            this.logMsg = logMsg;
            this.logDate = logDate;
        }
    }

    public class Json<K, V>
    {
        private K key;
        private V val;

        public K Key
        {
            get { return key; }
            set { key = value; }
        }

        public V Value
        {
            get { return val; }
            set { val = value; }
        }

        public Json(K key, V val)
        {
            this.key = key;
            this.val = val;
        }
    }

    public class JsonList : List<Json<DateTime, int>>
    {
        public int GetIndexByKey(JsonList jsonList, DateTime key)
        {
            int i = 0;
            foreach (Json<DateTime, int> json in jsonList)
            {
                if (json.Key == key)
                {
                    return i;
                }

                i++;
            }

            return -1;
        }
    }
}
