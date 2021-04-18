using Scada.AsyncNetTcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Business;
using Scada.DBUtility;

namespace ScadaCenterServer.Core
{
    public class IOCenterIOProject : ScadaTask
    {
        public IOCenterIOProject()
        {
            ServerConfig = new CenterServerConfig();
        }
        public  event CenterServerLogHappened CenterServerLog;
        /// <summary>
        /// 错误日志
        /// </summary>
        public  event CenterServerExceptionHappened CenterServerException;
        /// <summary>
        /// 数据库名称
        /// </summary>
        public  string DataBaseFileName = Application.StartupPath + "\\IOProject\\IOCenterServer.station";
        public  CenterServerConfig ServerConfig = null;
        public  List<Scada.Model.IO_SERVER> Servers = new List<Scada.Model.IO_SERVER>();
        public  List<Scada.Model.IO_COMMUNICATION> Communications = new List<Scada.Model.IO_COMMUNICATION>();
        public  List<Scada.Model.IO_DEVICE> Devices = new List<Scada.Model.IO_DEVICE>();
        public void LoadProject()
        {
            Task.Run(() =>
            {
                DataBaseFileName = Application.StartupPath + "\\IOProject\\IOCenterServer.station";
                //设置数据库数据源
                DbHelperSQLite.connectionString = "Data Source=" + DataBaseFileName;
                IO_SERVER serverBll = new IO_SERVER();
                IO_COMMUNICATION commBll = new IO_COMMUNICATION();
                IO_DEVICE deviceBll = new IO_DEVICE();
                AddLog("初始化采集站数据......");
                Servers = serverBll.GetModelList("");
                AddLog("采集站数据已经完成！");
                AddLog("加载通道数据......");
                Communications = commBll.GetModelList("");
                AddLog("通道数据已经完成!");
                AddLog("加载设备及其IO点表......");
                Devices = deviceBll.GetModelList("");
                AddLog("加载设备及其IO点表已经完成");
                for (int i = 0; i < Communications.Count; i++)
                {
                    Communications[i].Devices = Devices.FindAll(x => x.IO_COMM_ID == Communications[i].IO_COMM_ID && x.IO_SERVER_ID == Communications[i].IO_SERVER_ID);
                }
            });
        }
        /// <summary>
        /// 卸载并重新加载资源
        /// </summary>
        /// <param name="IO_SERVER_ID"></param>
        /// <returns></returns>
        public void ReloadProject(string IO_SERVER_ID, EndPoint clientEndPoint)
        {
            Task.Run(() =>
            {
                if (IO_SERVER_ID == "")
                    return;
                IOCenterManager.TCPServer.TcpServerStatus = TcpServerStatus.暂停;//暂停TCP服务
                try
                {



                    IO_SERVER serverBll = new IO_SERVER();
                    IO_COMMUNICATION commBll = new IO_COMMUNICATION();
                    IO_DEVICE deviceBll = new IO_DEVICE();
                    AddLog("重新初始化采集站");
                    lock (Servers)
                    {
                        Scada.Model.IO_SERVER deleteServer = Servers.Find(x => x.SERVER_ID == IO_SERVER_ID);
                        if (deleteServer != null)
                        {
                            Servers.Remove(deleteServer);//删除这个采集站信息
                        }

                        Scada.Model.IO_SERVER newsServer = serverBll.GetModel(IO_SERVER_ID);
                        if (newsServer != null)
                        {
                            Servers.Add(newsServer);
                        }
                        else
                        {
                            return;
                        }
                    }

                    lock (Communications)
                    {
                        AddLog("重新初始化采集站通道.....");
                        for (int i = Communications.Count - 1; i >= 0; i--)
                        {
                            if (Communications[i].IO_SERVER_ID == IO_SERVER_ID)
                            {
                                //首先删除设备
                                for (int d = Communications[i].Devices.Count - 1; d >= 0; d--)
                                {
                                    Devices.Remove(Communications[i].Devices[d]);
                                }
                                Communications.RemoveAt(i);
                            }
                        }
                        AddLog("重新初始化采集站设备信息.....");
                        List<Scada.Model.IO_COMMUNICATION> newsCommunications = commBll.GetModelList(" IO_SERVER_ID='" + IO_SERVER_ID + "' ");
                        Communications.AddRange(newsCommunications);
                        List<Scada.Model.IO_DEVICE> newsDevices = deviceBll.GetModelList("  IO_SERVER_ID='" + IO_SERVER_ID + "'");
                        Devices.AddRange(newsDevices);
                        AddLog("处理通道与设备关系.....");
                        for (int i = 0; i < newsCommunications.Count; i++)
                        {
                            newsCommunications[i].Devices = newsDevices.FindAll(x => x.IO_COMM_ID == newsCommunications[i].IO_COMM_ID && x.IO_SERVER_ID == newsCommunications[i].IO_SERVER_ID);
                        }

                        AddLog("重新初始化功能树.......");
                        IOCenterManager.QueryFormManager.LoadIOProject();
                        AddLog("重新初始化模拟器.......");
                        IOCenterManager.SimulatorManager.ReloadSimulator(IO_SERVER_ID);
                        AddLog("重新初始化监视器.......");
                        IOCenterManager.TCPServer.InitTree();
                        AddLog("发布工程完成！");
                        TcpData sendData = new TcpData();
                        sendData.Items.Add(new TcpDataItem() { Key = "RELUST", Value = "true" });
                        sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "采集站工程发布成功,正在重新初始化数据中心服务器，请耐心等待......" });
                        sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = IO_SERVER_ID });
                        IOCenterManager.TCPServer.SendData(clientEndPoint, sendData.TcpItemToString(), ScadaTcpOperator.发布工程成功);
                    }
                }
                catch (Exception ex)
                {
                    DisplyException(new Exception("更新服务器失败" + ex.Message));
                    TcpData sendData = new TcpData();
                    sendData.Items.Add(new TcpDataItem() { Key = "RELUST", Value = "true" });
                    sendData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "更新服务器失败" });
                    sendData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = IO_SERVER_ID });
                    IOCenterManager.TCPServer.SendData(clientEndPoint, sendData.TcpItemToString(), ScadaTcpOperator.发布工程失败);
                }
                IOCenterManager.TCPServer.TcpServerStatus = TcpServerStatus.运行;//暂停TCP服务
            });
        }
        /// <summary>
        /// 异常信息在日志端显示
        /// </summary>
        /// <param name="ex"></param>
        public  void DisplyException(Exception ex)
        {
            
            if (CenterServerException != null)
            {
                CenterServerException(ex.Message);
            }
            Scada.Logger.Logger.GetInstance().Debug(ex.Message);

        }
        public  void AddLog(string log)
        {
            if (CenterServerLog != null)
            {
                CenterServerLog(log);
            }
            Scada.Logger.Logger.GetInstance().Debug(log);
        }
        public  override void Dispose()
        {
            if (Servers != null)
                Servers.Clear();
            if (Communications != null)
                Communications.Clear();
            if (Devices != null)
                Devices.Clear();
            Communications = null;
            Devices = null;
            Servers = null;
            ServerConfig = null;
            base.Dispose();
        }
    }
}
