using Temporal.DbAPI;
using Scada.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;

namespace ScadaCenterServer.Core
{

    /// <summary>
    /// 任务管理器
    /// </summary>
  public  abstract  class IOCenterManager
    {    /// <summary>
         /// 是否在后头运行,前台不显示相关信息
         /// </summary>
        public static bool IsBackRun = true;
        public static IOCenterIOProject IOProject = null;
        public static SimulatorManager SimulatorManager = null;
        public static ScadaCommunicate TCPServer = null;
        public static  IOCenterQueryFormManager QueryFormManager = null;
        public static InfluxdbBackupManager InfluxdbBackupManager = null;
        
        public static bool EnableLoggger
        {
            get { return Logger.GetInstance().Enable; }
            set { Logger.GetInstance().Enable = value; }
        }
        public static void ReloadProject(string IO_SERVER_ID, EndPoint clientEndPoint)
        {
            Task.Run(() =>
            {

                try
                {
                    QueryFormManager.MainForm.Enabled = false;
                    SimulatorManager.IniSimulator();

                    if (TCPServer.ServerForm != null)
                        TCPServer.ServerForm.Enabled = false;
                    IOProject.ReloadProject(IO_SERVER_ID, clientEndPoint);
                }
                catch
                {

                }
                TCPServer.ServerForm.Enabled = true;
                QueryFormManager.MainForm.Enabled = true;
            });
        }
        //是否要新创建influxdb连接，做测试用
        public  static bool NewInfluxDB = false;
        public static InfluxDbManager InfluxDbManager
        {
            get
            {
                if (NewInfluxDB)
                {
                    InfluxDbManager mInfluxDbManager = new InfluxDbManager(IOCenterManager.IOProject.ServerConfig.influxdConfig.HttpAddress, IOCenterManager.IOProject.ServerConfig.InfluxDBGlobal.DataBaseName, IOCenterManager.IOProject.ServerConfig.InfluxDBGlobal.User, IOCenterManager.IOProject.ServerConfig.InfluxDBGlobal.Password, IOCenterManager.IOProject.ServerConfig.InfluxDBGlobal.InfluxDBVersion);
                     mInfluxDbManager.ShouldConnectInfluxDb();
                    return mInfluxDbManager;
                }
                else
                    return QueryFormManager.InfluxDbManager;
            }


        }
        public static bool EnableWriterLog = true;
        private static void LogMonitor()
        {
            Scada.Logger.Logger.GetInstance().Run();
            Task.Run(() => {
                while (EnableWriterLog)
                {
                    Thread.Sleep(1000 * 60);

                    Scada.Logger.Logger.GetInstance().WriteLog();
                }


            });
        }


        public static void LoadAll()
        {
            
                IOCenterManager.TCPServer.InitMonitorForm();


                IOCenterLoading frmLoading = new IOCenterLoading();
                frmLoading.BackgroundWorkAction = async delegate ()
               {
                   try
                   {

                       frmLoading.CurrentMsg = new KeyValuePair<int, string>(0, "正在初始化配置IO点信息...");
                       IOCenterManager.IOProject.LoadProject();

                       frmLoading.CurrentMsg = new KeyValuePair<int, string>(20, "正在初始化采集模拟器...");
                       IOCenterManager.SimulatorManager.IniSimulator();
                       frmLoading.CurrentMsg = new KeyValuePair<int, string>(40, "正在初始化查询管理器...");
                       IOCenterManager.QueryFormManager.StartInfluxDBServer();
                       frmLoading.CurrentMsg = new KeyValuePair<int, string>(60, "初始化采集站工程...");
                       IOCenterManager.QueryFormManager.LoadIOProject();
                       frmLoading.CurrentMsg = new KeyValuePair<int, string>(80, "初始化数据库...");
                       InfluxdbBackupManager = new InfluxdbBackupManager();
                       if (IOCenterManager.IOProject.ServerConfig.Backups.Enable)
                       {
                           InfluxdbBackupManager.Start();
                       }
                       else
                       {
                           InfluxdbBackupManager.Stop();
                       }
                       InfluxdbBackupManager.Run();
                       frmLoading.CurrentMsg = new KeyValuePair<int, string>(90, "系统启动网络通信服务...");
                       await IOCenterManager.TCPServer.Start();
                       frmLoading.CurrentMsg = new KeyValuePair<int, string>(100, "SCADA数据中心启动成功...");
                   }
                   catch (Exception ex)
                   {
                       Close();

                       MessageBox.Show(frmLoading, "加载资源时出现错误 " + ex.Message);
                       Application.ExitThread();
                       Application.Exit();
                   }
               };
                frmLoading.ShowDialog(QueryFormManager.MainForm);


                IOCenterManager.QueryFormManager.AddLog("等待创建采集服务树");
                IOCenterManager.TCPServer.LoadIOProject();
                IOCenterManager.QueryFormManager.AddLog("系统资源全部创建完成，启动服务成功");
           
        }
        public static void InitIOCenterManager()
        {

            IOProject = new IOCenterIOProject();
            IOProject.CenterServerException += IOProject_CenterServerException;
            IOProject.CenterServerLog += IOProject_CenterServerLog;
            SimulatorManager = new SimulatorManager();//模拟器服务
           
            TCPServer = new ScadaCommunicate();//网络通信服务
            QueryFormManager = new IOCenterQueryFormManager();//数据查询相关服务
          
            LogMonitor();
            //创建垃圾定时回收
            ClearMemoryTimer = new System.Threading.Timer(delegate {

                ClearMemory();

            }, null,50000, 30000);

        }
       
      
        #region
        /// <summary>
        /// IOProject日志写入
        /// </summary>
        /// <param name="log"></param>
        private static   void IOProject_CenterServerLog(string log)
        {
          if(QueryFormManager!=null)
            {
                QueryFormManager.AddLog(log);
            }
        }

        private static   void IOProject_CenterServerException(string exmsg)
        {
            if (QueryFormManager != null)
            {
                QueryFormManager.DisplyException(exmsg);
            }
        }
        #endregion
        /// <summary>
        /// 垃圾内存定时清理器
        /// </summary>
        private static System.Threading.Timer ClearMemoryTimer = null;
        public static  void Close()
        {
            if (IOProject != null)
                IOProject.Dispose();
            if (SimulatorManager != null)
                SimulatorManager.Dispose();
           
            if (QueryFormManager != null)
                QueryFormManager.Dispose();
        
            if (TCPServer != null)
                TCPServer.Stop().GetAwaiter();

            if(ClearMemoryTimer!=null)
            {
                ClearMemoryTimer.Dispose();
            }
            Application.ExitThread();
            GC.Collect();
        }
        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        private static void ClearMemory()
        {
            Task.Run(() => {

                try
                {
                    GC.Collect();

                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    {
                        SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
                    }
                }
                catch
                {

                }
            });
        }
        #endregion
    }
}
