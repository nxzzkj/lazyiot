using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Scada.Logger
{
    public class LogEntity
    {
        private LogLevel currentLogLevel = LogLevel.Debug;
        private string logDirectory = "logs\\";
        private string currentFileName = string.Empty;
        private int fileSymbol = 0;
        private DateTime lastFileDate;
        private DateTime firstFileDate;
        private int maxFileSize = 2;
        private IList<LogItem> listLogItem = new List<LogItem>();
        private Thread logThread;

        /// <summary> 
        /// 当前日志记录等级 
        /// </summary> 
        public LogLevel CurrentLogLevel
        {
            get { return currentLogLevel; }
            set { currentLogLevel = value; }
        }

        /// <summary> 
        /// 日志文件存放目录（例如：logs\\） 
        /// </summary> 
        public string LogDirectory
        {
            get { return logDirectory; }
            set { logDirectory = value; }
        }

        /// <summary> 
        /// 当前负责记录日志文件的名称 
        /// </summary> 
        public string CurrentFileName
        {
            get { return currentFileName; }
            set { currentFileName = value; }
        }

        /// <summary> 
        /// 文件后缀号 
        /// </summary> 
        public int FileSymbol
        {
            get { return fileSymbol; }
            set { fileSymbol = value; }
        }

        /// <summary> 
        /// 最新创建的日志记录文件日期 
        /// </summary> 
        public DateTime LastFileDate
        {
            get { return lastFileDate; }
            set { lastFileDate = value; }
        }

        /// <summary> 
        /// 保留的最早的日志记录文件创建日期 
        /// </summary> 
        public DateTime FirstFileDate
        {
            get { return firstFileDate; }
            set { firstFileDate = value; }
        }

        /// <summary> 
        /// 单个日志文件默认大小(单位：兆) 
        /// </summary> 
        public int MaxFileSize
        {
            get { return maxFileSize; }
            set { maxFileSize = value; }
        }

        /// <summary> 
        /// 日志信息缓存集合 
        /// </summary> 
        public IList<LogItem> ListLogItem
        {
            get { return listLogItem; }
            set { listLogItem = value; }
        }

        /// <summary> 
        /// 负责写日志的线程 
        /// </summary> 
        public Thread LogThread
        {
            get { return logThread; }
            set { logThread = value; }
        }
    }
}
