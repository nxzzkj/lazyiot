
using Scada.Kernel;
using Scada.MakeAlarm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Business;
using Scada.DBUtility;
using Scada.Model;

namespace IOMonitor.Core
{
    public class SimulatorManager: ScadaTask
    {
        public  bool IsSimulator = false;
        public  List<Scada.Model.IO_SERVER> Servers = new List<Scada.Model.IO_SERVER>();
        public  List<Scada.Model.IO_COMMUNICATION> Communications = new List<Scada.Model.IO_COMMUNICATION>();
        public  List<Scada.Model.IO_DEVICE> Devices = new List<Scada.Model.IO_DEVICE>();
        public  string DataBaseFileName = Application.StartupPath + "\\IOProject\\Station.station";
        //常规日志处理事件
        public   event MonitorLog OnSimulatorLog;
        public  int Interval = 3;//默认是3秒

        /// <summary>
        /// 启动模拟器
        /// </summary>
        /// <param name="form"></param>
        public void InitSimulator(int mInterval)
        {
            Task.Run(() =>
            {
                Scada.Business.SCADA_DRIVER DriverBll = new Scada.Business.SCADA_DRIVER();
                Scada.Business.SCADA_DEVICE_DRIVER DeviceDriverBll = new Scada.Business.SCADA_DEVICE_DRIVER();
                Scada.Business.IO_DEVICE deviceBll = new Scada.Business.IO_DEVICE();
                Scada.Business.IO_COMMUNICATION commBll = new Scada.Business.IO_COMMUNICATION();
                Scada.Business.IO_SERVER serverBll = new Scada.Business.IO_SERVER();
                List<Scada.Model.SCADA_DRIVER> CommDrivers = null;
                List<Scada.Model.SCADA_DEVICE_DRIVER> DeviceDrivers = null;
                Interval = mInterval;//获取时间间隔

                Servers = serverBll.GetModelList("");
                Communications = commBll.GetModelList("");
                Devices = deviceBll.GetModelList("");
                CommDrivers = DriverBll.GetModelList("");
                DeviceDrivers = DeviceDriverBll.GetModelList("");
                for (int i = 0; i < Communications.Count; i++)
                {

                    Communications[i].DriverInfo = CommDrivers.Find(x => x.Id == Communications[i].IO_COMM_DRIVER_ID);
                    if (Communications[i].DriverInfo != null)
                    {
                        Communications[i].CommunicateDriver = DriverAssembly.CreateCommunicateDriver(Communications[i].DriverInfo);

                    }

                    Communications[i].Devices = Devices.FindAll(x => x.IO_COMM_ID == Communications[i].IO_COMM_ID && x.IO_SERVER_ID == Communications[i].IO_SERVER_ID);
                    for (int j = 0; j < Communications[i].Devices.Count; j++)
                    {
                        Communications[i].Devices[j].DriverInfo = DeviceDrivers.Find(x => x.Id == Communications[i].Devices[j].DEVICE_DRIVER_ID);

                        if (Communications[i].Devices[j].DriverInfo != null)
                        {
                            Communications[i].Devices[j].DeviceDrive = DriverAssembly.CreateDeviceDrive(Communications[i].Devices[j].DriverInfo);
                        }
                    }

                }
            });

        }
        public    void StartSimulator()
        {

        
         
            try
            {
              
                IsSimulator = true;
                RunSimulator();
            }
            catch  
            {
                
                ColseSimulator();
            }
        }


        private async void RunSimulator()
        {

            //创建驱动
            for (int i = 0; i < this.Communications.Count; i++)
            {
                await Task.Run(() =>
                {
                    if (this.Communications[i].CommunicateDriver == null)
                    {
                        MonitorDataBaseModel.IOCommunications[i].CommunicateDriver = DriverAssembly.CreateCommunicateDriver(MonitorDataBaseModel.IOCommunications[i].DriverInfo);
                    }
                    ScadaCommunicateKernel driverDll = (ScadaCommunicateKernel)MonitorDataBaseModel.IOCommunications[i].CommunicateDriver;
                    driverDll.IsCreateControl = false;
                    driverDll.InitKernel(this.Servers.Find(x => x.SERVER_ID == this.Communications[i].IO_SERVER_ID), this.Communications[i], Communications[i].Devices, Communications[i].DriverInfo);
                    driverDll.Simulator(Interval, false);
                    driverDll.SimulatorStart();
                    driverDll.SimulatorLog += DriverDll_SimulatorLog;
                    driverDll.CommunctionClose += IOMonitorManager.CDriverDll_CommunctionClose;
                    driverDll.CommunctionContinue += IOMonitorManager.CDriverDll_CommunctionContinue;
                    driverDll.CommunctionPause += IOMonitorManager.CDriverDll_CommunctionPause;
                    driverDll.CommunctionStart += IOMonitorManager.CDriverDll_CommunctionStart;
                    driverDll.CommunctionStop += IOMonitorManager.CDriverDll_CommunctionStop;

                    driverDll.DeviceSended += IOMonitorManager.CDriverDll_DeviceSended;
                    driverDll.DeviceStatusChanged += IOMonitorManager.CDriverDll_DeviceStatusChanged;
                    driverDll.Exception += IOMonitorManager.CDriverDll_Exception;
                    driverDll.OnDataReceived += IOMonitorManager.CDriverDll_OnDataReceived;
                    driverDll.OnShowFormLog += IOMonitorManager.CDriverDll_OnShowFormLog;

                });
            }

        }
        //模拟器日志
        private void DriverDll_SimulatorLog(string msg)
        {
            if (OnSimulatorLog != null)
                OnSimulatorLog(msg);
  
        }
 
        /// <summary>
        /// 结束模拟器
        /// </summary>
        public void ColseSimulator()
        {
            Task.WaitAll();
            IsSimulator = false;
            for (int i = 0; i < this.Communications.Count; i++)
            {
                try
                {
                    if (this.Communications[i].CommunicateDriver == null)
                    {
                        MonitorDataBaseModel.IOCommunications[i].CommunicateDriver = DriverAssembly.CreateCommunicateDriver(MonitorDataBaseModel.IOCommunications[i].DriverInfo);
                    }
                    ScadaCommunicateKernel driverDll = (ScadaCommunicateKernel)MonitorDataBaseModel.IOCommunications[i].CommunicateDriver;

                    driverDll.SimulatorClose();
                }
                catch
                {
                    continue;
                }
           


            }
           
            GC.Collect();

         
        }
      
        public override void Dispose()
        {
            Task.WaitAll();
            IsSimulator = false;
            Servers.Clear();
            Communications.Clear();
            Devices.Clear();
            base.Dispose();
            GC.Collect();
        }
    }
}
