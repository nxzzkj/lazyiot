
using Scada.FlowGraphEngine.GraphicsCusControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Business;
using Scada.DBUtility;

namespace ScadaFlowDesign.Core
{
    public class FlowDataBaseManager
    {


        //当前服务器加载的采集站
        public   Scada.Model.IO_SERVER IOServer = null;
        //当前服务器加载的通道
        public   List<Scada.Model.IO_COMMUNICATION> IOCommunications = null;
        //当前服务器加载的设备
        public   List<Scada.Model.IO_DEVICE> IODevices = null;
        public   int ProgressMaxNum = 0;
        private   string mServerID = "";
        public   event FlowDesignException OnFlowExceptionHanped;
        public   event FlowDesignLogger OnFlowDesignLogger;
        #region 异常处理，统一都输出到主任何界面
        private     void AddLogToMainLog(string msg)
        {
            if (OnFlowDesignLogger != null)
            {
                OnFlowDesignLogger(msg);
            }

        }
        /// <summary>
        /// 异常信息在日志端显示
        /// </summary>
        /// <param name="ex"></param>
        private   void ThrowExceptionToMain(Exception ex)
        {
            if (OnFlowExceptionHanped != null)
            {
                OnFlowExceptionHanped(ex);
            }

        }


        #endregion
        public   string ServerID
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

        public void InitBaseModel()
        {
            Task.Run(() =>
            {
                try
                {
                    DbHelperSQLite.connectionString = "Data Source=" + Application.StartupPath + "\\IOProject\\Station.station";
                    IO_SERVER serverBll = new IO_SERVER();
                    AddLogToMainLog("读取采集站信息......");
                    IOServer = serverBll.GetModel(ComputerInfo.GetInstall().ServerID);
                    if (IOServer == null)
                        return;
                    mServerID = IOServer.SERVER_ID;
                    //加载通道
                    AddLogToMainLog("读取采集站通道信息......");
                    IO_COMMUNICATION commBll = new IO_COMMUNICATION();
                    IOCommunications = commBll.GetModelList(" IO_SERVER_ID='" + IOServer.SERVER_ID + "'");
                    AddLogToMainLog("读取采集站通道下的所有设备信息......");
                    IO_DEVICE deviceBll = new IO_DEVICE();
                    IODevices = deviceBll.GetModelList(" IO_SERVER_ID='" + IOServer.SERVER_ID + "'");
                    AddLogToMainLog("数据处理中.....");

                    for (int i = 0; i < IOCommunications.Count; i++)
                    {
                        AddLogToMainLog("处理 " + IOCommunications[i].IO_COMM_NAME + "[" + IOCommunications[i].IO_COMM_LABEL + "]");
                        IOCommunications[i].Devices = IODevices.FindAll(x => x.IO_COMM_ID == IOCommunications[i].IO_COMM_ID && x.IO_SERVER_ID == IOCommunications[i].IO_SERVER_ID);


                    }
                    AddLogToMainLog("正在创建驱动.....");

                    AddLogToMainLog("读取工程完成!");
                    ProgressMaxNum = IOCommunications.Count + IODevices.Count;
                    FlowGraphEngineProject.IOServer = IOServer;
                    FlowGraphEngineProject.IOCommunications = IOCommunications;
                }
                catch (Exception ex)
                {
                    ThrowExceptionToMain(ex);
                }
            });

        }
    }
}
