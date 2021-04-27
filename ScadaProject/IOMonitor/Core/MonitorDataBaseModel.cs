
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Business;
using Scada.DBUtility;

namespace IOMonitor.Core
{
    public class MonitorDataBaseModel
    {


        //当前服务器加载的采集站
        public static Scada.Model.IO_SERVER IOServer = null;
        //当前服务器加载的通道
        public static List<Scada.Model.IO_COMMUNICATION> IOCommunications = null;
        //当前服务器加载的设备
        public static List<Scada.Model.IO_DEVICE> IODevices = null;
        public static List<Scada.Model.SCADA_DRIVER> CommDrivers = null;
        public static List<Scada.Model.SCADA_DEVICE_DRIVER> DeviceDrivers = null;
        public static int ProgressMaxNum = 0;
        private static string mServerID = "";
        public static event MonitorException OnDataBaseExceptionHanped;
        public static event MonitorLog OnDataBaseLoged;
        #region 异常处理，统一都输出到主任何界面
        private static   void AddLogToMainLog(string msg)
        {
            if (OnDataBaseLoged != null)
            {
                OnDataBaseLoged(msg);
            }

        }
        /// <summary>
        /// 异常信息在日志端显示
        /// </summary>
        /// <param name="ex"></param>
        private static void ThrowExceptionToMain(Exception ex)
        {
            if (OnDataBaseExceptionHanped != null)
            {
                OnDataBaseExceptionHanped(ex);
            }

        }


        #endregion
        public static string ServerID
        {
            get
            {
                if (mServerID == "")
                {
                    DbHelperSQLite.connectionString = "Data Source=" + Application.StartupPath + "\\IOProject\\Station.station";
                    IO_SERVER serverBll = new IO_SERVER();
                    AddLogToMainLog("读取采集站信息......");
                    IOServer = serverBll.GetModel();
                    mServerID = IOServer.SERVER_ID;
                    return mServerID;
                }
                return mServerID;
            }
        }
    
        public static void InitBaseModel()
        {
  
            if (ServerID == "")
                return;
            try
            {
                DbHelperSQLite.connectionString = "Data Source=" + Application.StartupPath + "\\IOProject\\Station.station";
                IO_SERVER serverBll = new IO_SERVER();
                AddLogToMainLog("读取采集站信息......");
                IOServer = serverBll.GetModel(mServerID);
                if (IOServer == null)
                    return;
                mServerID = IOServer.SERVER_ID;
                IOServer.SERVER_IP = LocalIp.GetLocalIp();
                serverBll.Update(IOServer);
                //加载通道
                AddLogToMainLog("读取采集站通道信息......");
                IO_COMMUNICATION commBll = new IO_COMMUNICATION();
                SCADA_DRIVER DriverBll = new SCADA_DRIVER();
                SCADA_DEVICE_DRIVER DeviceDriverBll = new SCADA_DEVICE_DRIVER();
                CommDrivers = DriverBll.GetModelList("");
                DeviceDrivers = DeviceDriverBll.GetModelList("");
                IOCommunications = commBll.GetModelList(" IO_SERVER_ID='" + IOServer.SERVER_ID + "'");
               
                AddLogToMainLog("读取采集站通道下的所有设备信息......");
                IO_DEVICE deviceBll = new IO_DEVICE();
                IODevices = deviceBll.GetModelList(" IO_SERVER_ID='" + IOServer.SERVER_ID + "'");
                AddLogToMainLog("数据处理中.....");

                for (int i = 0; i < IOCommunications.Count; i++)
                {
                    IOCommunications[i].DriverInfo = CommDrivers.Find(x => x.Id == IOCommunications[i].IO_COMM_DRIVER_ID);
                    if (IOCommunications[i].DriverInfo != null)
                    {
                        IOCommunications[i].CommunicateDriver = DriverAssembly.CreateCommunicateDriver(IOCommunications[i].DriverInfo);

                    }
                    AddLogToMainLog("处理 " + IOCommunications[i].IO_COMM_NAME + "[" + IOCommunications[i].IO_COMM_LABEL + "]");
                    IOCommunications[i].Devices = IODevices.FindAll(x => x.IO_COMM_ID == IOCommunications[i].IO_COMM_ID && x.IO_SERVER_ID == IOCommunications[i].IO_SERVER_ID);
                    for (int j = 0; j < IOCommunications[i].Devices.Count; j++)
                    {
                        IOCommunications[i].Devices[j].DriverInfo = DeviceDrivers.Find(x => x.Id == IOCommunications[i].Devices[j].DEVICE_DRIVER_ID);

                        if (IOCommunications[i].Devices[j].DriverInfo!=null)
                        {
                            IOCommunications[i].Devices[j].DeviceDrive = DriverAssembly.CreateDeviceDrive(IOCommunications[i].Devices[j].DriverInfo);
                        }
                    }


                }
                AddLogToMainLog("正在创建驱动.....");

                AddLogToMainLog("读取工程完成!");
                ProgressMaxNum = IOCommunications.Count + IODevices.Count;
            }
            catch(Exception ex)
            {
                ThrowExceptionToMain(ex);
            }
        

        }
    }
}
