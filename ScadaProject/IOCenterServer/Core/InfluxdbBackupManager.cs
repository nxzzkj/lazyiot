using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Model;

namespace ScadaCenterServer.Core
{
public     class InfluxdbBackupManager
    {
        private    bool isRun = false;
        public bool IsRun
        {
            get { return isRun; }
        }
        public   void Start()
        {
            isRun = true;
        }
        private   DateTime LastBackupDate = DateTime.Now;
        /// <summary>
        /// 打开控制台执行拼接完成的批处理命令字符串
        /// </summary>
        /// <param name="inputAction">需要执行的命令委托方法：每次调用 <paramref name="inputAction"/> 中的参数都会执行一次</param>
        /// <summary>
        /// 打开控制台执行拼接完成的批处理命令字符串
        /// </summary>
        /// <param name="inputAction">需要执行的命令委托方法：每次调用 <paramref name="inputAction"/> 中的参数都会执行一次</param>
        private async   void ExecBatCommand(string batfile, string backuppath)
        {
            InfluxDBBackupLog backUp = null;
            try
            {
                string error = string.Empty;
                using (Process pro = new Process())
                {
                    FileInfo file = new FileInfo(batfile);
                    pro.StartInfo.WorkingDirectory = file.Directory.FullName;
                    pro.StartInfo.FileName = batfile;
                    pro.StartInfo.CreateNoWindow = true;
                    pro.StartInfo.RedirectStandardOutput = true;
                    pro.StartInfo.RedirectStandardError = true;
                    pro.StartInfo.UseShellExecute = false;

                    pro.Start();
                    pro.WaitForExit();

                    string outstring = pro.StandardOutput.ReadToEnd();
                    error = pro.StandardError.ReadToEnd();
                    backUp = new InfluxDBBackupLog();
                    backUp.BackUpID = DateTime.Now.ToString("yyyyMMddHHmmss");
                    backUp.BackUpDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    backUp.BackUpPath = backuppath;
                    backUp.BackUpFile = DateTime.Now.AddDays(-1).ToString("yyyyMMddTHH:mm:ssZ");
                }
                if (error == null || error == "")
                {
                    backUp.BackUpResult = "true";
                    IOCenterManager.QueryFormManager.AddLog("数据库备份成功！");

                }

                else

                {
                    backUp.BackUpResult = "false";
                    IOCenterManager.QueryFormManager.AddLog("数据库备份失败！");

                }

            }
            catch (Exception ex)
            {
                IOCenterManager.QueryFormManager.DisplyException(ex);
            }
            //写入备份日志
            if (backUp != null)
            {
              await  IOCenterManager.InfluxDbManager.DbWrite_BackupPoints(backUp, DateTime.Now);
            }
        }
 
        public   async void Run()
        {
            

            await Task.Run(() =>
            {

                while (true)
                {
                    if (!isRun)
                        continue;
                    Thread.Sleep(4 * 1000);//每隔60秒循环一次
                    try
                    {   //备份周期
                        string cycle = IOCenterManager.IOProject.ServerConfig.Backups.BackupCycle;
                        if (cycle.Trim() == "")
                            continue;
                        //备份路径
                        string folder = IOCenterManager.IOProject.ServerConfig.Backups.BackupFullPath;
                        if (folder.Trim() == "")
                            continue;
                        //备份时间
                        string time = IOCenterManager.IOProject.ServerConfig.Backups.BackupTime;
                        LastBackupDate = IOCenterManager.IOProject.ServerConfig.Backups.LastBackupDate;
                        if (time.Trim() == "")
                        {
                            continue;
                        }
                        switch (cycle)
                        {
                            case "每天":
                                {
                                    TimeSpan tspan = (LastBackupDate - DateTime.Now);
                                    TimeSpan tspan2 = (Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")+" "+time) - DateTime.Now);
                                    if (Math.Abs(tspan.Days)>=1&& Math.Abs(tspan2.Minutes)<=5)
                                    {
                                        string content = "influxd backup -portable -database " + IOCenterManager.IOProject.ServerConfig.InfluxDBGlobal.DataBaseName + " -start " + DateTime.Now.ToString("yyyy-MM-ddT00:01:01Z") + " -end " + DateTime.Now.ToString("yyyy-MM-ddT23:59:59Z") + "  " + folder + "\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Today.ToString("yyyyMMdd");
                                        StreamWriter sw = new StreamWriter(Application.StartupPath + "\\influxdb\\influxdbbackup.bat", false, Encoding.Default);
                                        sw.WriteLine(content);
                                        sw.Close();
                                        ExecBatCommand(Application.StartupPath + "\\influxdb\\influxdbbackup.bat", folder + "\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Today.ToString("yyyyMMdd"));

                                        Thread.Sleep(60 * 12 * 1000);//每隔停止11分钟秒循环一次
                                        IOCenterManager.IOProject.ServerConfig.Backups.LastBackupDate = DateTime.Now;
                                        LastBackupDate = IOCenterManager.IOProject.ServerConfig.Backups.LastBackupDate;
                                        IOCenterManager.IOProject.ServerConfig.WriteConfig();

                                    }

                                 
                                }
                                break;
                            case "每月":
                                {
                                    TimeSpan tspan = (LastBackupDate - DateTime.Now);
                                    TimeSpan tspan2 = (Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + time) - DateTime.Now);
                                    if (Math.Abs(tspan.Days) >= 28 && DateTime.Now.Day == 1 && Math.Abs(tspan2.Minutes) <= 5)
                                    {
                                        string content = "influxd backup -portable -database " + IOCenterManager.IOProject.ServerConfig.InfluxDBGlobal.DataBaseName + " -start " + DateTime.Now.ToString("yyyy-MM-ddT00:01:01Z") + " -end " + DateTime.Now.ToString("yyyy-MM-ddT23:59:59Z") + "  " + folder + "\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Today.ToString("yyyyMMdd");
                                        StreamWriter sw = new StreamWriter(Application.StartupPath + "\\influxdb\\influxdbbackup.bat", false, Encoding.Default);
                                        sw.WriteLine(content);
                                        sw.Close();
                                        ExecBatCommand(Application.StartupPath + "\\influxdb\\influxdbbackup.bat", folder + "\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Today.ToString("yyyyMMdd"));

                                        Thread.Sleep(60 * 12 * 1000);//每隔停止11分钟秒循环一次
                                        IOCenterManager.IOProject.ServerConfig.Backups.LastBackupDate = DateTime.Now;
                                        LastBackupDate = IOCenterManager.IOProject.ServerConfig.Backups.LastBackupDate;
                                        IOCenterManager.IOProject.ServerConfig.WriteConfig();

                                    }

                           

                                  
                                }
                                break;
                            case "每周":
                                {


                                    TimeSpan tspan = (LastBackupDate - DateTime.Now);
                                    TimeSpan tspan2 = (Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + time) - DateTime.Now);
                                    if (Math.Abs(tspan.Days) >= 7 && DateTime.Now.DayOfWeek == DayOfWeek.Sunday && Math.Abs(tspan2.Minutes) <= 5)
                                    {
                                        string content = "influxd backup -portable -database " + IOCenterManager.IOProject.ServerConfig.InfluxDBGlobal.DataBaseName + " -start " + DateTime.Now.ToString("yyyy-MM-ddT00:01:01Z") + " -end " + DateTime.Now.ToString("yyyy-MM-ddT23:59:59Z") + "  " + folder + "\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Today.ToString("yyyyMMdd");
                                        StreamWriter sw = new StreamWriter(Application.StartupPath + "\\influxdb\\influxdbbackup.bat", false, Encoding.Default);
                                        sw.WriteLine(content);
                                        sw.Close();
                                        ExecBatCommand(Application.StartupPath + "\\influxdb\\influxdbbackup.bat", folder + "\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Today.ToString("yyyyMMdd"));
                                        Thread.Sleep(60 * 12 * 1000);//每隔停止11分钟秒循环一次
                                        IOCenterManager.IOProject.ServerConfig.Backups.LastBackupDate = DateTime.Now;
                                        LastBackupDate = IOCenterManager.IOProject.ServerConfig.Backups.LastBackupDate;
                                        IOCenterManager.IOProject.ServerConfig.WriteConfig();

                                    }
                                }
                                break;
                        }

                    }
                    catch  
                    {
                        continue;
                    }
                }

            });
        }
        public   void  Stop()
        {
            isRun = false;
        }
    }
}
