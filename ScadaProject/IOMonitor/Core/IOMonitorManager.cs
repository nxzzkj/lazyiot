

using Scada.AsyncNetTcp;
using Scada.IOStructure;
using IOMonitor.Core;
using IOMonitor.Forms;
using Scada.Kernel;
 
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;
using Scada.Model;

namespace IOMonitor.Core
{
   
 
    //监视采集主任务
    public abstract  class IOMonitorManager
    {
        /// <summary>
        /// 是否在后头运行,前台不显示相关信息
        /// </summary>
        public static bool IsBackRun = true;
        public  static IOMonitorTCPClient TcpClient = null;
    
        /// <summary>
        /// 垃圾内存定时清理器
        /// </summary>
        private static System.Threading.Timer ClearMemoryTimer = null;
        #region
        public static bool EnableWriterLog
        {
       get { return Scada.Logger.Logger.GetInstance().Enable; }
            set { Scada.Logger.Logger.GetInstance().Enable = value; }
        }
        //日志定时保存
        private static void MonitorLogRun()
        {
           

            Task.Run(() =>
            {
                while (EnableWriterLog)
                {
                    Thread.Sleep(1000 * 60);

                    Scada.Logger.Logger.GetInstance().WriteLog();
                }


            });
        }

        #endregion

        public static event MonitorOperator OnMonitorOperator;
        /// <summary>
        /// 加载系统配置
        /// </summary>
        public static IOConfig Config = null;
        //当前采集站的主要对象
        private static IO_SERVER IOServer = null;
        //创建读取数据的子任务
 
        private static Scada.Business.SCADA_DRIVER commDriverBll = null;
     
        /// <summary>
        /// 创建下发数据命令的子任务
        /// </summary>
 
        private static TaskOperator TaskOperator = TaskOperator.关闭;
    
 
        //异常报错事件
        public static  event MonitorException OnMonitorException;
        //常规日志处理事件
        public static  event MonitorLog OnMonitorLog;
 
        //接收数据并处理后返回的事件
        public static event MonitorReceive OnMonitorReceive;

        #region 日志显示的的信息都统一增加日志窗体中去
        private static void AddLogToMainLog(string log)
        {
            if (OnMonitorLog != null)
            {
                OnMonitorLog(log);
            }
            Scada.Logger.Logger.GetInstance().Info(log);
        }
        private static  void ThrowExceptionToMain(Exception emx)
        {
          
            if (OnMonitorException != null)
            {
                OnMonitorException(emx);
            }
            Scada.Logger.Logger.GetInstance().Debug(emx.Message);
        }
        #endregion
    
         
        /// <summary>
        /// 由于用户在登录前需要TCP与服务器通讯，所以在登录前要创建改服务
        /// </summary>
        /// <returns></returns>
        public static void CreateTCPServer(string Ip)
        {
            if(TcpClient!=null)
            {
                TcpClient.Stop();
                TcpClient.Dispose();
                TcpClient = null;
            }
            AddLogToMainLog("正在创建TCP连接信息");
            TcpClient = new IOMonitorTCPClient();
            TcpClient.ClientConfig = new IOConfig();
            //TcpClient.OnConnectedServer += TcpClient_OnConnectedServer;
            TcpClient.OnExceptionHanped += TcpClient_OnExceptionHanped;
            TcpClient.OnTCPClientLoged += TcpClient_OnTCPClientLoged;
            TcpClient.OnDisConnectedServer += TcpClient_OnDisConnectedServer;

            TcpClient.Start(Ip);

        }


        /// <summary>
        /// 用户登录成功的返回事件
        /// </summary>
        /// <param name="client"></param>
        /// <param name="sender"></param>
        /// <param name="msg"></param>
        private static void TcpClient_OnUserLogined(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg)
        {
    
        }

        /// <summary>
        ///下置命令
        /// </summary>
        /// <param name="receivebytes"></param>
        /// <returns></returns>

        private static void TcpClient_OnConnectedServer(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg)
        {
            AddLogToMainLog("与服务器成功连接!");
        }

        private static void TcpClient_OnTCPClientLoged(string msg)
        {
            AddLogToMainLog(msg);
        }

        private static void TcpClient_OnExceptionHanped(Exception ex)
        {
            ThrowExceptionToMain(ex);
        }

        private static void TcpClient_OnDisConnectedServer(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg)
        {
            AddLogToMainLog(msg+",系统自动尝试重新连接服务器中....");
        }

       
        public static void CreateConfig()
        {
    
            Config = new IOConfig();
            

        }

        public static void InitMonitor()
        {

          
                commDriverBll = new Scada.Business.SCADA_DRIVER();
                //开启日志保存服务
                MonitorLogRun();
                #region 创建通讯和设备驱动
                int num = MonitorDataBaseModel.ProgressMaxNum + 4;
                //执行方法
                #region 读取当前采集站工程数据
                try
                {


                    TaskOperator = TaskOperator.关闭;

                    IOServer = MonitorDataBaseModel.IOServer;
                    //创建驱动模块
                    for (int i = 0; i < MonitorDataBaseModel.IOCommunications.Count; i++)
                    {
                        if (MonitorDataBaseModel.IOCommunications[i].DriverInfo == null)
                        {
                            AddLogToMainLog("创建通道" + MonitorDataBaseModel.IOCommunications[i].IO_COMM_NAME.ToString() + @"[" + MonitorDataBaseModel.IOCommunications[i].IO_COMM_LABEL + @"]驱动失败,请在采集站中设置该通讯通道驱动!");
                            continue;
                        }
                        try
                        {

                            if (MonitorDataBaseModel.IOCommunications[i].CommunicateDriver == null)
                                continue;
                            else
                                ((ScadaCommunicateKernel)MonitorDataBaseModel.IOCommunications[i].CommunicateDriver).IsCreateControl = false;
                            AddLogToMainLog("创建通道" + MonitorDataBaseModel.IOCommunications[i].IO_COMM_NAME.ToString() + @"[" + MonitorDataBaseModel.IOCommunications[i].IO_COMM_LABEL + @"]驱动成功!");

                        ScadaCommunicateKernel driverDll = (ScadaCommunicateKernel)MonitorDataBaseModel.IOCommunications[i].CommunicateDriver;
                            driverDll.SetUIParameter(MonitorDataBaseModel.IOCommunications[i].IO_COMM_PARASTRING);
                            driverDll.IsCreateControl = false;
                            driverDll.InitKernel(MonitorDataBaseModel.IOServer, MonitorDataBaseModel.IOCommunications[i], MonitorDataBaseModel.IOCommunications[i].Devices, MonitorDataBaseModel.IOCommunications[i].DriverInfo);
                            driverDll.CommunctionClose += CDriverDll_CommunctionClose;
                            driverDll.CommunctionContinue += CDriverDll_CommunctionContinue;
                            driverDll.CommunctionPause += CDriverDll_CommunctionPause;
                            driverDll.CommunctionStart += CDriverDll_CommunctionStart;
                            driverDll.CommunctionStop += CDriverDll_CommunctionStop;

                            driverDll.DeviceSended += CDriverDll_DeviceSended;
                            driverDll.DeviceStatusChanged += CDriverDll_DeviceStatusChanged;
                            driverDll.Exception += CDriverDll_Exception;
                            driverDll.OnDataReceived += CDriverDll_OnDataReceived;
                            driverDll.OnShowFormLog += CDriverDll_OnShowFormLog;

                            AddLogToMainLog("准备创建该通道下的设备驱动.....");
                            for (int d = 0; d < MonitorDataBaseModel.IOCommunications[i].Devices.Count; d++)
                            {
                                Scada.Model.IO_DEVICE device = MonitorDataBaseModel.IOCommunications[i].Devices[d];
                                try
                                {
                                    if (MonitorDataBaseModel.IOCommunications[i].Devices[d].DriverInfo == null)
                                    {
                                        AddLogToMainLog("创建设备" + device.IO_DEVICE_LABLE.ToString() + @"[" + device.IO_DEVICE_NAME + @"]驱动失败,请在采集站中设置该设备驱动!");
                                        continue;
                                    }
                                    ((ScadaDeviceKernel)device.DeviceDrive).IsCreateControl = false;
                                    ((ScadaDeviceKernel)device.DeviceDrive).ExceptionEvent += CDriverDll_ExceptionEvent;
                                    ((ScadaDeviceKernel)device.DeviceDrive).InitKernel(MonitorDataBaseModel.IOServer, MonitorDataBaseModel.IOCommunications[i], device, null, device.DriverInfo);
                                }
                                catch (Exception ex)
                                {
                                    ThrowExceptionToMain(new Exception("创建设备" + MonitorDataBaseModel.IOCommunications[i].Devices[d].IO_DEVICE_LABLE.ToString() + @"[" + MonitorDataBaseModel.IOCommunications[i].Devices[d].IO_DEVICE_NAME + @"]驱动失败,!错误原因:" + ex.Message));

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            ThrowExceptionToMain(new Exception("ERROR600001" + ex.Message));
                        }

                    }

                    #endregion
                    //创建垃圾定时回收
                    ClearMemoryTimer = new System.Threading.Timer(delegate
                    {

                        ClearMemory();

                    }, null, 1000, 30000);

                }
                catch (Exception ex)
                {
                    ThrowExceptionToMain(new Exception("ERROR600002" + ex.Message));
                }
                #endregion
                Start();
           
        }

        private static void StationMDSServer_CenterServerLog(string log)
        {
            var analysisTask = Task.Run(() =>
            {

                AddLogToMainLog(log);
            });
        }

        private static void StationMDSServer_CenterServerException(Exception ex)
        {
            var analysisTask = Task.Run(() =>
            {

                ThrowExceptionToMain(ex);
            });
        }




        #region 设备驱动返回的异常信息
        private static    void CDriverDll_ExceptionEvent(string msg)
        {
            ThrowExceptionToMain(new Exception("ERROR600004" + msg));
        }
        #endregion
        #region 通讯驱动返回的各种数据事件 
        /// <summary>
        /// 返回要在日志窗体中显示的数据
        /// </summary>
        /// <param name="msg"></param>
        public static void CDriverDll_OnShowFormLog(string msg)
        {
            var analysisTask = Task.Run(() =>
            {

                AddLogToMainLog(msg);
            });
        }

        /// <summary>
        /// 返回服务器端接收的数据,此处主要将一个设备下的所有IO表数据统一获取后在一次性上传,
        /// </summary>
        /// <param name="server"></param>
        /// <param name="comm"></param>
        /// <param name="device"></param>
        /// <param name="para">为null,此参数不传递,根据用户驱动需要</param>
        /// <param name="receivedatas">接收的全部数据，要求在驱动中进行一次读取后返回</param>

        public static   void CDriverDll_OnDataReceived(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, byte[] receivedatas, string date,object sender)
        {
            //解析数据
            var analysisTask = Task.Run(  () =>
            {

                try
                {
                    if (device!=null&&device.DeviceDrive != null)
                    {
                       
                        //清理已经接收完成的数据
                        for (int i = 0; i < device.IOParas.Count; i++)
                        {
                            device.IOParas[i].IORealData = null;
                        }

                        device.GetedValueDate = DateTime.Now;
                        device.ReceiveBytes = receivedatas;
                        #region 循环解析实时数据接收的每个参数

                        ScadaDeviceKernel Driver = (ScadaDeviceKernel)device.DeviceDrive;
                        for (int i = 0; i < device.IOParas.Count; i++)
                        {
                            #region 解析开关量 模拟量 字符常量 数据
                            try
                            {
                                if (device.IOParas[i].IO_POINTTYPE == "模拟量" || device.IOParas[i].IO_POINTTYPE == "开关量" || device.IOParas[i].IO_POINTTYPE == "字符串量")
                                {
                                    try
                                    {
                                        Driver.InitKernel(server, comm, device, device.IOParas[i], device.DriverInfo);
                                        IOData recdata = Driver.AnalysisData(server, comm, device, device.IOParas[i], receivedatas, Convert.ToDateTime(date), sender);
                                        if (recdata != null)
                                        {
                                            device.IOParas[i].IORealData = recdata;
                                        }
                                    }
                                    catch
                                    {
                                        device.IOParas[i].IORealData = null;
                                    }


                                }
                            }
                            catch
                            {

                            }
                            #endregion
                            #region 解析关系数据库值
                            try
                            {
                                if (device.IOParas[i].IO_POINTTYPE == "关系数据库值" && device.IOParas[i].IO_DATASOURCE.Trim() != "")
                                {

                                    RelationalDatabase rlation = new RelationalDatabase(device.IOParas[i].IO_DATASOURCE);
                                    string sql = rlation.GetSql();
                                    string conn = rlation.ConnectString;
                                    switch (rlation.Database_Type)
                                    {
                                        case "SQL Server":
                                            {
                                                try
                                                {
                                                    if (conn != "" && sql != "")
                                                    {
                                                        DbHelperSQL sqlHealp = new DbHelperSQL();
                                                        sqlHealp.connectionString = conn;
                                                        DataSet ds = sqlHealp.Query(sql);
                                                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                                        {
                                                            device.IOParas[i].IORealData = new IOData();
                                                            device.IOParas[i].IORealData.CommunicationID = device.IO_COMM_ID;
                                                            device.IOParas[i].IORealData.ServerID = device.IO_SERVER_ID;
                                                            device.IOParas[i].IORealData.ID = device.IO_DEVICE_ID;
                                                            device.IOParas[i].IORealData.ParaName = device.IOParas[i].IO_NAME;
                                                            device.IOParas[i].IORealData.ParaString = device.IOParas[i].IO_PARASTRING;
                                                            device.IOParas[i].IORealData.ParaValue = ds.Tables[0].Rows[0]["value"].ToString();
                                                            device.IOParas[i].IORealData.QualityStamp = QualityStamp.GOOD;
                                                            device.IOParas[i].IORealData.Date = Convert.ToDateTime(ds.Tables[0].Rows[0]["datetime"].ToString());
                                                        }

                                                    }


                                                }
                                                catch
                                                {
                                                    device.IOParas[i].IORealData = null;
                                                }
                                            }
                                            break;
                                        case "ORACLE":
                                            {
                                                try
                                                {
                                                    if (conn != "" && sql != "")
                                                    {
                                                        DbHelperOra oracleHealp = new DbHelperOra();
                                                        oracleHealp.connectionString = conn;
                                                        DataSet ds = oracleHealp.Query(sql);
                                                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                                        {
                                                            device.IOParas[i].IORealData = new IOData();
                                                            device.IOParas[i].IORealData.CommunicationID = device.IO_COMM_ID;
                                                            device.IOParas[i].IORealData.ServerID = device.IO_SERVER_ID;
                                                            device.IOParas[i].IORealData.ID = device.IO_DEVICE_ID;
                                                            device.IOParas[i].IORealData.ParaName = device.IOParas[i].IO_NAME;
                                                            device.IOParas[i].IORealData.ParaString = device.IOParas[i].IO_PARASTRING;
                                                            device.IOParas[i].IORealData.ParaValue = ds.Tables[0].Rows[0]["value"].ToString();
                                                            device.IOParas[i].IORealData.QualityStamp = QualityStamp.GOOD;
                                                            device.IOParas[i].IORealData.Date = Convert.ToDateTime(ds.Tables[0].Rows[0]["datetime"].ToString());
                                                        }

                                                    }

                                                }
                                                catch
                                                {
                                                    device.IOParas[i].IORealData = null;
                                                }
                                            }
                                            break;
                                        case "MySql":
                                            {
                                                try
                                                {
                                                    if (conn != "" && sql != "")
                                                    {
                                                        DbHelperMySQL mysqlHealp = new DbHelperMySQL();
                                                        mysqlHealp.connectionString = conn;
                                                        DataSet ds = mysqlHealp.Query(sql);
                                                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                                        {
                                                            device.IOParas[i].IORealData = new IOData();
                                                            device.IOParas[i].IORealData.CommunicationID = device.IO_COMM_ID;
                                                            device.IOParas[i].IORealData.ServerID = device.IO_SERVER_ID;
                                                            device.IOParas[i].IORealData.ID = device.IO_DEVICE_ID;
                                                            device.IOParas[i].IORealData.ParaName = device.IOParas[i].IO_NAME;
                                                            device.IOParas[i].IORealData.ParaString = device.IOParas[i].IO_PARASTRING;
                                                            device.IOParas[i].IORealData.ParaValue = ds.Tables[0].Rows[0]["value"].ToString();
                                                            device.IOParas[i].IORealData.QualityStamp = QualityStamp.GOOD;
                                                            device.IOParas[i].IORealData.Date = Convert.ToDateTime(ds.Tables[0].Rows[0]["datetime"].ToString());
                                                            double d = 0;
                                                            if (double.TryParse(device.IOParas[i].IORealData.ParaValue, out d))
                                                            {
                                                                device.IOParas[i].IORealData.DataType = typeof(double);
                                                            }
                                                            else
                                                            {
                                                                device.IOParas[i].IORealData.DataType = typeof(string);

                                                            }
                                                        }

                                                    }
                                                }
                                                catch
                                                {
                                                    device.IOParas[i].IORealData = null;
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                            catch
                            {

                            }
                            #endregion
                            #region 解析计算值包含公式计算的

                            //

                            try
                            {
                                if (device.IOParas[i].IO_POINTTYPE == "计算值")
                                {
                                    if (device.IOParas[i].IO_FORMULA.Trim() != "")
                                    {
                                        device.IOParas[i].IORealData = new IOData();
                                        try
                                        {
                                            device.IOParas[i].IORealData.QualityStamp = QualityStamp.GOOD;
                                            device.IOParas[i].IORealData.Date = DateTime.Now;
                                            device.IOParas[i].IORealData.ParaName = device.IOParas[i].IO_NAME;
                                            device.IOParas[i].IORealData.DataType = typeof(double);
                                            //替换关键字为数值
                                            string formula = device.IOParas[i].IO_FORMULA;
                                            foreach (IO_PARA para in device.IOParas)
                                            {
                                                if (device.IOParas[i].IO_POINTTYPE != "字符串量" && device.IOParas[i].IO_POINTTYPE != "计算值" && device.IOParas[i].IORealData != null)
                                                {
                                                    if (device.IOParas[i].IORealData.QualityStamp == QualityStamp.GOOD && device.IOParas[i].IORealData.ParaValue != "-9999" && device.IOParas[i].IORealData.ParaValue != "")
                                                    {
                                                        formula = formula.Replace(device.IOParas[i].IO_NAME, device.IOParas[i].IORealData.ParaValue);
                                                    }

                                                }
                                            }
                                            if (formula != "")
                                            {
                                                //解析数学公式
                                                device.IOParas[i].IORealData.ParaValue = AnalyzeCalculate.Calculate(device.IOParas[i].IO_FORMULA);
                                                double d = 0;
                                                if (double.TryParse(device.IOParas[i].IORealData.ParaValue, out d))
                                                {
                                                    device.IOParas[i].IORealData.DataType = typeof(double);
                                                }
                                                else
                                                {
                                                    device.IOParas[i].IORealData.DataType = typeof(string);

                                                }
                                            }

                                            else
                                            {
                                                device.IOParas[i].IORealData.ParaValue = "-9999";
                                                device.IOParas[i].IORealData.QualityStamp = QualityStamp.BAD;
                                            }
                                        }
                                        catch
                                        {
                                            device.IOParas[i].IORealData.QualityStamp = QualityStamp.BAD;
                                            device.IOParas[i].IORealData.Date = DateTime.Now;
                                            device.IOParas[i].IORealData.ParaName = device.IOParas[i].IO_NAME;
                                        }

                                    }
                                    else
                                    {
                                        device.IOParas[i].IORealData = null;

                                    }
                                }
                            }
                            catch
                            {

                            }
                            #endregion
                            #region 进行量程转换  
                            try
                            {
                                if (device.IOParas[i].IO_POINTTYPE == "模拟量")
                                {

                                    if (device.IOParas[i].IORealData != null && device.IOParas[i].IO_ENABLERANGECONVERSION == 1 && device.IOParas[i].IORealData.QualityStamp == QualityStamp.GOOD)
                                    {
                                        if (device.IOParas[i].IORealData.ParaValue != "" && device.IOParas[i].IORealData.ParaValue != "-9999")
                                        {
                                            string value = ConvertParaTypeValue(device.IOParas[i].GetParaValueType(), device.IOParas[i].IORealData.ParaValue, double.Parse(device.IOParas[i].IO_RANGEMAX), double.Parse(device.IOParas[i].IO_RANGEMIN), double.Parse(device.IOParas[i].IO_MAXVALUE), double.Parse(device.IOParas[i].IO_MINVALUE));
                                            device.IOParas[i].IORealData.ParaValue = value;
                                        }
                                    }
                                }
                            }
                            catch
                            {

                            }

                            #endregion

                            #region 常量值  
                            try
                            {
                                if (device.IOParas[i].IO_POINTTYPE == "常量值")
                                {
                                    device.IOParas[i].IORealData = new IOData()
                                    {
                                        CommunicationID = device.IOParas[i].IO_COMM_ID,
                                        DataType = typeof(string),
                                        Date = device.GetedValueDate,
                                        ParaName = device.IOParas[i].IO_NAME,
                                        ParaString = device.IOParas[i].IO_PARASTRING,
                                        ParaValue = device.IOParas[i].IO_INITALVALUE,
                                        QualityStamp = QualityStamp.GOOD,
                                        ServerID = device.IOParas[i].IO_SERVER_ID
                                    };


                                }
                            }
                            catch
                            {

                            }

                            #endregion

                        }
                        #endregion
                        #region 将解析后的数据上传到数据中心服务器上
                        IO_DEVICE newDevice = device.Copy();
                        try
                        {
                            Task.Run(() =>
                            {
                                //上传实时数据,
                                bool res= RealDataDBUtility.UploadReal(server, comm, device);
                            MonitorFormManager.ShowMonitorUploadListView(server, comm, device, res?"上传成功":"上传失败");
                            });
                        }
                        catch (Exception emx)
                        {
                            ThrowExceptionToMain(emx);

                        }
                        //在事件接收窗体中显示接收的采集数据
                        if (OnMonitorReceive != null)
                        {
                            OnMonitorReceive(server, comm, newDevice, receivedatas);
                            
                        }

                        #endregion
                        #region 计算报警并上传
                        try
                        {
                            Task.Run(() =>
                            {
                                //计算并处理报警
                                List<IO_PARAALARM> res = RealDataDBUtility.UploadAlarm(server, comm, device);

                                for (int i = 0; i < res.Count; i++)
                                {
                                    MonitorFormManager.MonitorIODataAlarmShowView(server, comm, device, res[i], "上传成功");

                                }


                            });
                        }
                        catch (Exception emx)
                        {
                            ThrowExceptionToMain(emx);

                        }
                        #endregion
                    }


                }
                catch (Exception emx)
                {
                    ThrowExceptionToMain(emx);
                }
                if (receivedatas != null && receivedatas.Length > 0)
                    AddLogToMainLog(device.IO_DEVICE_NAME + "接收到数据 DATA=" + CVT.ByteToHexStr(receivedatas));

            });
         

        }
        #region 量程转换
        /// <summary>
        /// 量程变换，将下位机传输回来的数据进行数据转换
        /// </summary>
        /// <param name="strtype"></param>
        /// <param name="svalue"></param>
        /// <param name="rangemax"></param>
        /// <param name="rangemin"></param>
        /// <param name="valuemax"></param>
        /// <param name="valuemin"></param>
        /// <returns></returns>
        private  static  string ConvertParaTypeValue(Type strtype, string svalue, double rangemax, double rangemin, double valuemax, double valuemin)
        {
            try
            {
                //量程上限EULO+（裸数据上限PVRAWHI-裸数据下限PVRAWLO）*（量程上限EUHI-量程下限EULO）/（裸数据PVRAW-裸数据下限PVRAWLO）
                double value = -9999;
                if (double.TryParse(svalue, out value))
                {


                    svalue = (rangemin + (value - valuemin) * (rangemax - rangemin) / (valuemax - valuemin)).ToString();
                }
                else
                {
                    return "-9999";
                }

                if (strtype == typeof(sbyte))
                {
                    return Convert.ToSByte(svalue).ToString();
                }
                else if (typeof(byte) == strtype)
                {
                    return Convert.ToInt16(svalue).ToString();
                }
                else if (typeof(UInt16) == strtype)
                {
                    return Convert.ToUInt16(svalue).ToString();
                }
                else if (typeof(Int32) == strtype)
                {
                    return Convert.ToInt32(svalue).ToString();
                }
                else if (typeof(UInt32) == strtype)
                {
                    return Convert.ToUInt32(svalue).ToString();
                }
                else if (typeof(Int64) == strtype)
                {
                    return Convert.ToInt64(svalue).ToString();
                }
                else if (typeof(UInt64) == strtype)
                {
                    return Convert.ToUInt64(svalue).ToString();
                }
                else if (typeof(Single) == strtype)
                {
                    return Convert.ToSingle(svalue).ToString();
                }
                else if (typeof(Double) == strtype)
                {
                    return Convert.ToDouble(svalue).ToString();
                }
                else
                {
                    return value.ToString();
                }
            }
            catch
            {
                return "-9999";
            }


        }
        #endregion
        /// <summary>
        /// 返回通讯端口出现的异常错误
        /// </summary>
        /// <param name="msg"></param>

        public static void CDriverDll_Exception(string msg)
        {
            var analysisTask = Task.Run(() =>
            {

                ThrowExceptionToMain(new Exception("ERROR600005" + msg));
            });
        }
        /// <summary>
        /// 设备状态变化返回的事件
        /// </summary>
        /// <param name="server"></param>
        /// <param name="comm"></param>
        /// <param name="device"></param>
        /// <param name="para"></param>
        /// <param name="tag"></param>

        public static   void CDriverDll_DeviceStatusChanged(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, IO_PARA para, object tag)
        {
            var analysisTask = Task.Run(() =>
            {

                if (tag != null)
                {
                    if (tag.ToString() == "1")
                    {
                        //设备上线不需要通知，如果下线，则在系统日志中进行显示
                        device.IO_DEVICE_STATUS = 1;
                        MonitorFormManager.RefreshIOStatus(device);
                    }
                    else
                    {
                        AddLogToMainLog("设备" + device.IO_DEVICE_NAME + " 下线 ");
                        device.IO_DEVICE_STATUS = 0;
                        MonitorFormManager.RefreshIOStatus(device);
                    }

                }
            });

        }
        /// <summary>
        /// 本通讯通道内设备发送数据后返回的事件
        /// </summary>
        /// <param name="server"></param>
        /// <param name="comm"></param>
        /// <param name="device"></param>
        /// <param name="para"></param>
        /// <param name="value"></param>
        /// <param name="result"></param>

        public static   void CDriverDll_DeviceSended(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, IO_PARA para, string value, bool result)
        {
            var analysisTask = Task.Run(() =>
            {


                if (result)
                {
                    AddLogToMainLog("下置" + device.IO_DEVICE_NAME + "设备" + para.IO_NAME + "IO点值" + value + "成功!");
                }
                else
                {
                    AddLogToMainLog("下置" + device.IO_DEVICE_NAME + "设备" + para.IO_NAME + "IO点值" + value + "失败!");
                }
            });

        }
        /// <summary>
        /// 本通讯通道内设备上线后返回的事件
        /// </summary>
        /// <param name="server"></param>
        /// <param name="comm"></param>
        /// <param name="device"></param>
        /// <param name="para"></param>
        /// <param name="tag"></param>


        /// <summary>
        /// 通讯通道被停止后返回的事件
        /// </summary>
        /// <param name="server"></param>
        /// <param name="comm"></param>
        /// <param name="tag"></param>

        public static void CDriverDll_CommunctionStop(IO_SERVER server, IO_COMMUNICATION comm, object tag)
        {
            var analysisTask = Task.Run(() =>
            {

                AddLogToMainLog(comm.IO_COMM_NAME + "通讯通道被关闭!");
            });
        }
        /// <summary>
        /// 通讯通道启动服务返回的事件
        /// </summary>
        /// <param name="server"></param>
        /// <param name="comm"></param>
        /// <param name="tag"></param>

        public static void CDriverDll_CommunctionStart(IO_SERVER server, IO_COMMUNICATION comm, object tag)
        {
            var analysisTask = Task.Run(() =>
            {

                AddLogToMainLog(comm.IO_COMM_NAME + "通讯通道启动!");
            });
        }
        /// <summary>
        /// 通讯通道被暂停返回的事件
        /// </summary>
        /// <param name="server"></param>
        /// <param name="comm"></param>
        /// <param name="tag"></param>

        public static void CDriverDll_CommunctionPause(IO_SERVER server, IO_COMMUNICATION comm, object tag)
        {
            var analysisTask = Task.Run(() =>
            {

                AddLogToMainLog(comm.IO_COMM_NAME + "通讯通道暂停!");
            });
        }
        /// <summary>
        /// 通讯通道暂停后继续服务的返回事件
        /// </summary>
        /// <param name="server"></param>
        /// <param name="comm"></param>
        /// <param name="tag"></param>

        //通讯通道继续
        public static void CDriverDll_CommunctionContinue(IO_SERVER server, IO_COMMUNICATION comm, object tag)
        {
            var analysisTask = Task.Run(() =>
            {

                AddLogToMainLog(comm.IO_COMM_NAME + "通讯通道继续服务!");
            });
        }

        //通讯驱动被关闭后120秒后重新再连接
        public static   void CDriverDll_CommunctionClose(IO_SERVER server, IO_COMMUNICATION comm, object tag)
        {
            var analysisTask = Task.Run(() =>
            {

                AddLogToMainLog(comm.IO_COMM_NAME + "通讯通道已关闭!");
            });
        }
        #endregion
        #region 当然任务的启动停止暂停的方法

        //开始任务
        public static void Start()
        {
                //创建通信子任务
                for (int i = 0; i < MonitorDataBaseModel.IOCommunications.Count; i++)
                {
                    if (MonitorDataBaseModel.IOCommunications[i].CommunicateDriver != null)
                    {
                        try
                        {
                        ScadaCommunicateKernel driverDll = (ScadaCommunicateKernel)MonitorDataBaseModel.IOCommunications[i].CommunicateDriver;
                            //创建主任务
                            Task.Run(() =>
                            {
                                driverDll.StartServer();
                            });

                        }
                        catch (Exception emx)
                        {
                            ThrowExceptionToMain(emx);
                        }
                    }


                }
                TaskOperator = TaskOperator.运行;
                if (OnMonitorOperator != null)
                {
                    OnMonitorOperator(TaskOperator);
                }
                AddLogToMainLog("启动采集服务");
          

        }
        public static  void  UserLogin(string user, string password)
        {
            STATION_TCP_INFO loginInfo = new STATION_TCP_INFO();
            loginInfo.USER = user;
            loginInfo.PASSWROD = password;
            loginInfo.IO_SERVER_ID = MonitorDataBaseModel.ServerID;
            loginInfo.IO_SERVER_IP = "";
            loginInfo.RESULT = "false";
            loginInfo.FUNCTION = "IOMonitor";
            Scada.AsyncNetTcp.TcpData tcpData = new Scada.AsyncNetTcp.TcpData();
            byte[] loginbytes = tcpData.StringToTcpByte(loginInfo.GetCommandString(), Scada.AsyncNetTcp.ScadaTcpOperator.登录);
            //发送登录命令
            TcpClient.Send(new ArraySegment<byte>(loginbytes));
        }
     
        public static  void Suspend()
        {
            Task.Run(() => {
          
            for (int i = 0; i < MonitorDataBaseModel.IOCommunications.Count; i++)
            {
                
                    //此处不用线程，在具体实现中用户采用线程
                    if (MonitorDataBaseModel.IOCommunications[i].CommunicateDriver != null)
                    {
                        ScadaCommunicateKernel driverDll = (ScadaCommunicateKernel)MonitorDataBaseModel.IOCommunications[i].CommunicateDriver;
                        driverDll.PauseServer();

                    }

                
            }
            TaskOperator = TaskOperator.暂停;
            if (OnMonitorOperator != null)
            {
                OnMonitorOperator(TaskOperator);
            }
            AddLogToMainLog("暂停采集服务");
            });
        }
        public static  void  Continue()
        {
            Task.Run(() => {
            for (int i = 0; i < MonitorDataBaseModel.IOCommunications.Count; i++)
            {

                //此处不用线程，在具体实现中用户采用线程
                if (MonitorDataBaseModel.IOCommunications[i].CommunicateDriver != null)
                {
                        ScadaCommunicateKernel driverDll = (ScadaCommunicateKernel)MonitorDataBaseModel.IOCommunications[i].CommunicateDriver;
                    driverDll.ContinueServer();

                }


            }
            TaskOperator = TaskOperator.运行;
            if (OnMonitorOperator != null)
            {
                OnMonitorOperator(TaskOperator);
            }
            AddLogToMainLog("继续采集服务");
            });
        }
        public static void  Stop()
        {
            Task.Run(() => {
            try
            {
                if(MonitorDataBaseModel.IOCommunications!=null)
                for (int i = 0; i < MonitorDataBaseModel.IOCommunications.Count; i++)
                {

                    //此处不用线程，在具体实现中用户采用线程
                    if (MonitorDataBaseModel.IOCommunications[i].CommunicateDriver != null)
                    {
                                ScadaCommunicateKernel driverDll = (ScadaCommunicateKernel)MonitorDataBaseModel.IOCommunications[i].CommunicateDriver;
                        driverDll.StopServer();

                    }


                }

                if(MonitorDataBaseModel.IODevices!=null)
                for (int i = 0; i < MonitorDataBaseModel.IODevices.Count; i++)
                {
                    MonitorDataBaseModel.IODevices[i].ClearCollectDatas();

                }
              
                TaskOperator = TaskOperator.停止;
                if (OnMonitorOperator != null)
                {
                    OnMonitorOperator(TaskOperator);
                }
                AddLogToMainLog("停止采集服务");
            }
            catch (Exception emx)
            { ThrowExceptionToMain(emx); }
            });
        }
        //关闭并释放任务，该任务要求初始化所有任务
        public static void Close()
        {
            Task.Run(() => {
            try
            {

                for (int i = 0; i < MonitorDataBaseModel.IOCommunications.Count; i++)
                {

                    //此处不用线程，在具体实现中用户采用线程
                    if (MonitorDataBaseModel.IOCommunications[i].CommunicateDriver != null)
                    {
                            ScadaCommunicateKernel driverDll = (ScadaCommunicateKernel)MonitorDataBaseModel.IOCommunications[i].CommunicateDriver;
                        driverDll.CommunctionClose -= CDriverDll_CommunctionClose;
                        driverDll.CommunctionContinue -= CDriverDll_CommunctionContinue;
                        driverDll.CommunctionPause -= CDriverDll_CommunctionPause;
                        driverDll.CommunctionStart -= CDriverDll_CommunctionStart;
                        driverDll.CommunctionStop -= CDriverDll_CommunctionStop;

                        driverDll.DeviceSended -= CDriverDll_DeviceSended;
                        driverDll.DeviceStatusChanged -= CDriverDll_DeviceStatusChanged;
                        driverDll.Exception -= CDriverDll_Exception;
                        driverDll.OnDataReceived -= CDriverDll_OnDataReceived;
                        driverDll.OnShowFormLog -= CDriverDll_OnShowFormLog;
                        driverDll.StopServer();

                    }


                }
               
                TaskOperator = TaskOperator.关闭;
                if (OnMonitorOperator != null)
                {
                    OnMonitorOperator(TaskOperator);
                }
                AddLogToMainLog("停止并并关闭采集服务");
              
                if(ClearMemoryTimer!=null)
                {
                    ClearMemoryTimer.Dispose();
                    ClearMemoryTimer = null;
                }
                if(TcpClient!=null)
                {
                    TcpClient.Stop();
                    TcpClient.Dispose();
                    TcpClient = null;
                }
                
            }
            catch (Exception emx)
            { ThrowExceptionToMain(emx); }
            });
        }

        #endregion
        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        private static void ClearMemory()
        {
            var analysisTask = Task.Run(() =>
            {
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
