using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;

namespace Scada.Business
{
    public class PublishServer
    {
        #region  ExtensionMethod
        public string tempFile = "";
        /// <summary>
        /// 备份工程
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public bool Backups(string project)
        {
            try
            {
                tempFile = Application.StartupPath + "\\temp\\" + Guid.NewGuid();
                //路径合法性判断
                //构造读取文件流对象
                using (FileStream fsRead = new FileStream(project, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) //打开文件，不能创建新的
                {
                    //构建写文件流对象
                    using (FileStream fsWrite = new FileStream(tempFile, FileMode.Create)) //没有找到就创建
                    {
                        //开辟临时缓存内存
                        byte[] byteArrayRead = new byte[1024 * 1024]; // 1字节*1024 = 1k 1k*1024 = 1M内存

                        //通过死缓存去读文本中的内容
                        while (true)
                        {
                            //readCount 这个是保存真正读取到的字节数
                            int readCount = fsRead.Read(byteArrayRead, 0, byteArrayRead.Length);

                            //开始写入读取到缓存内存中的数据到目标文本文件中
                            fsWrite.Write(byteArrayRead, 0, readCount);


                            //既然是死循环 那么什么时候我们停止读取文本内容 我们知道文本最后一行的大小肯定是小于缓存内存大小的
                            if (readCount < byteArrayRead.Length)
                            {
                                break; //结束循环
                            }
                        }

                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        
           

       }
        public    bool ClearServers(string serverid)
        {
            try
            {
                SCADA_DRIVER DriverBll = new SCADA_DRIVER();
        
                IO_ALARM_CONFIG alarmBll = new IO_ALARM_CONFIG();
                IO_COMMUNICATION commBll = new IO_COMMUNICATION();
                IO_DEVICE deviceBll = new IO_DEVICE();
                IO_PARA paraBll = new IO_PARA();
                IO_SERVER serverBll = new IO_SERVER();
                alarmBll.Clear(serverid.Trim());
                commBll.Clear(serverid.Trim());
                deviceBll.Clear(serverid.Trim());
                paraBll.Clear(serverid.Trim());
                serverBll.Clear(serverid.Trim());
                DbHelperSQLite.Compress();
                return true;
            }
            catch
            {
                return false;
            }


        }
        public   bool Recovery( string sourceFile)
        {
            bool exist = File.Exists(tempFile);
            //路径合法性判断
            if (exist)
            {
                //构造读取文件流对象
                using (FileStream fsRead = new FileStream(tempFile, FileMode.Open)) //打开文件，不能创建新的
                {
                    //构建写文件流对象
                    using (FileStream fsWrite = new FileStream(sourceFile, FileMode.Create)) //没有找到就创建
                    {
                        //开辟临时缓存内存
                        byte[] byteArrayRead = new byte[1024 * 1024]; // 1字节*1024 = 1k 1k*1024 = 1M内存

                        //通过死缓存去读文本中的内容
                        while (true)
                        {
                            //readCount 这个是保存真正读取到的字节数
                            int readCount = fsRead.Read(byteArrayRead, 0, byteArrayRead.Length);

                            //开始写入读取到缓存内存中的数据到目标文本文件中
                            fsWrite.Write(byteArrayRead, 0, readCount);


                            //既然是死循环 那么什么时候我们停止读取文本内容 我们知道文本最后一行的大小肯定是小于缓存内存大小的
                            if (readCount < byteArrayRead.Length)
                            {
                                break; //结束循环
                            }
                        }

                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 发布工程
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public bool Publish(string project)
        {

            //路径合法性判断
            try { 
                //构造读取文件流对象
                using (FileStream fsRead = new FileStream(project, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) //打开文件，不能创建新的
                {
                    //构建写文件流对象
                    using (FileStream fsWrite = new FileStream(tempFile, FileMode.Create)) //没有找到就创建
                    {
                        //开辟临时缓存内存
                        byte[] byteArrayRead = new byte[1024 * 1024]; // 1字节*1024 = 1k 1k*1024 = 1M内存

                        //通过死缓存去读文本中的内容
                        while (true)
                        {
                            //readCount 这个是保存真正读取到的字节数
                            int readCount = fsRead.Read(byteArrayRead, 0, byteArrayRead.Length);

                            //开始写入读取到缓存内存中的数据到目标文本文件中
                            fsWrite.Write(byteArrayRead, 0, readCount);


                            //既然是死循环 那么什么时候我们停止读取文本内容 我们知道文本最后一行的大小肯定是小于缓存内存大小的
                            if (readCount < byteArrayRead.Length)
                            {
                                break; //结束循环
                            }
                        }

                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion  ExtensionMethod
    }
}
