using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Scada.Logger
{
    public class Logger : ILogger
    {
        private static readonly Logger instance = new Logger();

        private Logger() { }

        public static Logger GetInstance()
        {
            return instance;
        }

        private LogEntity logEntity = new LogEntity();

        private static object syncRoot = new object();
        public bool Enable = true;

        /// <summary> 
        /// 启动日志组件 
        /// </summary> 
        /// <returns></returns> 
        public bool Run()
        {
            return Run(LogLevel.Debug, "logs\\", 2);
        }

        public bool Run(LogLevel logLevel, string logDirectory, int maxFileSize)
        {
            if (logLevel < LogLevel.Debug && logLevel >= LogLevel.Off)
                return false;

            if (maxFileSize <= 0)
                return false;

            logEntity.CurrentLogLevel = logLevel;
            logEntity.LogDirectory = logDirectory;
            logEntity.MaxFileSize = maxFileSize;

            string logDir = AppDomain.CurrentDomain.BaseDirectory + logEntity.LogDirectory;
            if (!File.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }

            IList<string> listFileName = GetFileList(logDir);

            if (listFileName.Count <= 0)
            {
                logEntity.CurrentFileName = DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                logEntity.FileSymbol = 0;
                logEntity.FirstFileDate = DateTime.Now;
                logEntity.LastFileDate = DateTime.Now;
                CreateFile(logDir + logEntity.CurrentFileName);
            }
            else if (listFileName.Count == 1)
            {
                logEntity.CurrentFileName = listFileName[0];
                logEntity.FirstFileDate = DateTime.Parse(logEntity.CurrentFileName.Substring(0, 10));
                logEntity.LastFileDate = logEntity.FirstFileDate;
                logEntity.FileSymbol = 0;
            }
            else
            {
                LoadLogger(listFileName);
            }

            // 
            logEntity.LogThread = new Thread(new ThreadStart(WriteLog));
            logEntity.LogThread.IsBackground = true;
            logEntity.LogThread.Start();

            return true;
        }

        /// <summary> 
        /// 记录日志 
        /// </summary> 
        public void WriteLog()
        {
            while (true)
            {
                DateTime dtNow = DateTime.Now;
                double timeSpan = (dtNow - logEntity.LastFileDate).TotalMinutes;
                // 一刻钟扫描一次 
                if (timeSpan > 15 || timeSpan < 0)
                {
                    logEntity.LastFileDate = dtNow;
                    MonitorLog();
                }

                if (logEntity.ListLogItem.Count > 0)
                {
                    lock (syncRoot)
                    {
                        string logDir = AppDomain.CurrentDomain.BaseDirectory + logEntity.LogDirectory;

                        CreateFile(logDir + logEntity.CurrentFileName);

                        FileStream write = File.Open(logDir + logEntity.CurrentFileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                        foreach (LogItem item in logEntity.ListLogItem)
                        {
                            StringBuilder logMsg = new StringBuilder("日志级别：");
                            logMsg.Append(item.LogLevel.ToString());
                            logMsg.Append("\n\r\n\r-------------------------------------------\n\r\n\r");
                            logMsg.Append(item.LogMsg);
                            logMsg.Append("\n\r\n\r-------------------------------------------\n\r\n\r");
                            logMsg.Append("记录时间：");
                            logMsg.Append(item.LogDate);
                            logMsg.Append("\n\r\n\r\n\r\n\r");

                            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(logMsg.ToString());
                            write.Write(bytes, 0, bytes.Length);

                            double fileSize = ((double)write.Length / 1048576);
                            if (fileSize > logEntity.MaxFileSize)
                            {
                                logEntity.FileSymbol += 1;
                                logEntity.CurrentFileName = logEntity.CurrentFileName.Substring(0, 10) + "_" + logEntity.FileSymbol + ".log";
                                CreateFile(logDir + logEntity.CurrentFileName);
                                write.Flush();
                                write.Close();
                                write.Dispose();

                                write = File.Open(logDir + logEntity.CurrentFileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                            }
                        }

                        write.Flush();
                        write.Close();
                        write.Dispose();

                        logEntity.ListLogItem.Clear();
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        private void CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                FileStream fs = File.Create(filePath);
                fs.Flush();
                fs.Close();
            }
        }

        /// <summary> 
        /// 检测并删除过期文件（只保留最近一个月的日志文件） 
        /// </summary> 
        private void MonitorLog()
        {
            string dtNow = DateTime.Now.ToString("yyyy-MM-dd");
            string dtOld = logEntity.CurrentFileName.Substring(0, 10);
            if (dtNow != dtOld)
            {
                lock (syncRoot)
                {
                    logEntity.CurrentFileName = dtNow + ".log";
                    logEntity.FileSymbol = 0;
                    CreateFile(AppDomain.CurrentDomain.BaseDirectory + logEntity.LogDirectory + logEntity.CurrentFileName);
                }
            }

            DateTime dtNewTime = DateTime.Parse(dtNow);
            double day = (dtNewTime - logEntity.FirstFileDate).TotalDays;
            if (day > 60 || day < 0)
            {
                string logDir = AppDomain.CurrentDomain.BaseDirectory + logEntity.LogDirectory;
                string[] strFullName = Directory.GetFiles(logDir);
                foreach (string str in strFullName)
                {
                    DateTime dt = DateTime.Parse(Path.GetFileName(str).Substring(0, 10));
                    day = (dtNewTime - dt).TotalDays;
                    if (day > 30 || day < 0)
                    {
                        File.Delete(str);
                    }
                }
            }
        }

        /// <summary> 
        /// 当日志文件不止一个时, 初始化组件运行所需参数 
        /// </summary> 
        /// <param name="listFileName"></param> 
        public void LoadLogger(IList<string> listFileName)
        {
            JsonList tempJsonList = new JsonList();

            foreach (string fileName in listFileName)
            {
                int index = fileName.IndexOf('_');
                int symbol = 0;
                if (index != -1)
                {
                    int endIndex = fileName.IndexOf('.');
                    symbol = int.Parse(fileName.Substring(index + 1, endIndex - index - 1));
                }

                DateTime dt = DateTime.Parse(fileName.Substring(0, 10));
                index = tempJsonList.GetIndexByKey(tempJsonList, dt);
                if (index != -1)
                {
                    if (tempJsonList[index].Value < symbol)
                        tempJsonList[index].Value = symbol;
                }
                else
                {
                    tempJsonList.Add(new Json<DateTime, int>(dt, symbol));
                }
            }

            int maxIndex = 0, minIndex = 0;
            for (int i = 1; i != tempJsonList.Count; i++)
            {
                if (tempJsonList[minIndex].Key > tempJsonList[i].Key)
                    minIndex = i;

                if (tempJsonList[maxIndex].Key < tempJsonList[i].Key)
                    maxIndex = i;
            }

            logEntity.CurrentFileName = tempJsonList[maxIndex].Key.ToString("yyyy-MM-dd") + (tempJsonList[maxIndex].Value == 0 ? "" : "_" + tempJsonList[maxIndex].Value) + ".log";
            logEntity.FileSymbol = tempJsonList[maxIndex].Value;
            logEntity.LastFileDate = tempJsonList[maxIndex].Key;
            logEntity.FirstFileDate = tempJsonList[minIndex].Key;

            tempJsonList.Clear();
            tempJsonList = null;
        }

        /// <summary> 
        /// 获取指定目录的文件名称列表 
        /// </summary> 
        /// <param name="logDir"></param> 
        /// <returns></returns> 
        public IList<string> GetFileList(string logDir)
        {
            if (!Directory.Exists(logDir))
                throw new Exception("Error：指定的目录不存在！");

            string[] strFullName = Directory.GetFiles(logDir,"*.log");
            IList<string> listFileName = new List<string>();
            foreach (string fullName in strFullName)
            {
                listFileName.Add(Path.GetFileName(fullName));
            }

            return listFileName;
        }

        public string GetLevel()
        {
            return logEntity.CurrentLogLevel.ToString();
        }

        public bool SetLevel(LogLevel logLevel)
        {
            if (logLevel < LogLevel.Debug || logLevel >= LogLevel.Off)
            {
                return false;
            }
            else
            {
                logEntity.CurrentLogLevel = logLevel;

                return true;
            }
        }

        public void AddLogItem(LogLevel logLevel, string logMsg, DateTime noteTime)
        {
            if (logLevel < LogLevel.Debug || logLevel >= LogLevel.Off)
                return;

            lock (syncRoot)
            {
                logEntity.ListLogItem.Add(new LogItem(logLevel, logMsg, noteTime.ToString("yyyy-MM-dd hh:mm:ss")));
            }
        }

        public void Debug(string msg)
        {
            if (!Enable)
                return;
            if (msg != null)
            {
                if (logEntity.CurrentLogLevel <= LogLevel.Debug)
                {
                    AddLogItem(LogLevel.Debug, msg, DateTime.Now);
                }
            }
        }

        public void Info(string msg)
        {
            if (!Enable)
                return;
            if (msg != null)
            {
                if (logEntity.CurrentLogLevel <= LogLevel.Info)
                {
                    AddLogItem(LogLevel.Info, msg, DateTime.Now);
                }
            }
        }

        public void Warn(string msg)
        {
            if (!Enable)
                return;
            if (msg != null)
            {
                if (logEntity.CurrentLogLevel <= LogLevel.Warn)
                {
                    AddLogItem(LogLevel.Warn, msg, DateTime.Now);
                }
            }
        }

        public void Error(string msg)
        {
            if (!Enable)
                return;
            if (msg != null)
            {
                if (logEntity.CurrentLogLevel <= LogLevel.Error)
                {
                    AddLogItem(LogLevel.Error, msg, DateTime.Now);
                }
            }
        }

        public void Fatal(string msg)
        {
            if (!Enable)
                return;
            if (msg != null)
            {
                if (logEntity.CurrentLogLevel <= LogLevel.Fatal)
                {
                    AddLogItem(LogLevel.Fatal, msg, DateTime.Now);
                }
            }
        }
    }
}
