using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scada.Logger
{
 
        /// <summary> 
        /// 日志组件 
        /// </summary> 
        public interface ILogger
        {
            /// <summary> 
            /// 启动日志组件 
            /// </summary> 
            bool Run();

            /// <summary> 
            /// 启动日志组件 
            /// </summary> 
            /// <param name="logLevel">等级</param> 
            /// <param name="logDirectory">日志文件存放目录（例如：logs\\）</param> 
            /// <param name="maxFileSize">单个日志文件默认大小(单位：MB)</param> 
            /// <returns></returns> 
            bool Run(LogLevel logLevel, string logDirectory, int maxFileSize);

            /// <summary> 
            /// 获取当前设置的日志记录等级 
            /// </summary> 
            /// <returns></returns> 
            string GetLevel();

            /// <summary> 
            /// 设置日志记录等级 
            /// </summary> 
            /// <param name="logLevel"></param> 
            /// <returns></returns> 
            bool SetLevel(LogLevel logLevel);

            /// <summary> 
            /// 记录调试信息 
            /// </summary> 
            /// <param name="msg"></param> 
            void Debug(string msg);

            /// <summary> 
            /// 记录一般信息 
            /// </summary> 
            /// <param name="msg"></param> 
            void Info(string msg);

            /// <summary> 
            /// 记录警告信息 
            /// </summary> 
            /// <param name="msg"></param> 
            void Warn(string msg);

            /// <summary> 
            /// 记录一般错误信息 
            /// </summary> 
            /// <param name="msg"></param> 
            void Error(string msg);

            /// <summary> 
            /// 记录严重错误信息 
            /// </summary> 
            /// <param name="msg"></param> 
            void Fatal(string msg);
        }
 
}
