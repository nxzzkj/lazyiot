
using Scada.Model;

using Scada.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
 
using System.Reflection;
using System.Windows.Forms;
using System.Net;

namespace Scada.Kernel
{  
    public   class ScadaCommunicateKernel
    {
        public virtual string GUID
        {
            get;
        }
        public virtual string Title { set; get; }
        public bool IsCreateControl = true;
        protected IO_SERVER IOServer = null;
        protected IO_COMMUNICATION IOCommunication = null;
        /// <summary>
        /// 当前通道下所有的设备
        /// </summary>
        protected List<IO_DEVICE> IODevices = new List<IO_DEVICE>();
        Scada.Business.SCADA_DRIVER driverBll = new Scada.Business.SCADA_DRIVER();
        Scada.Business.SCADA_DEVICE_DRIVER deviceDriverBll = new Scada.Business.SCADA_DEVICE_DRIVER();
        List<SCADA_DEVICE_DRIVER> DeviceDriverModels = new List<SCADA_DEVICE_DRIVER>();
        protected List<ScadaDeviceKernel> DeviceDrives = null;
        /// <summary>
        /// 判断服务是否在运行
        /// </summary>
        public bool ServerIsRun
        {
            get {
                if (TaskCancel != null)
                    return !TaskCancel.IsCancellationRequested;
                else
                    return false;

            }
        }
        private bool IsSuspend = false;
        /// <summary>
        /// 判断服务是否处于暂停状态
        /// </summary>
        public bool ServerIsSuspend
        {
            get { return IsSuspend; }
        }
        public SCADA_DRIVER Driver = null;
        public string CommunicationDriverID
        {
            get
            {
                if (Driver == null)
                    return "";
                return Driver.Id.ToString();
            }
        }
        public string ServerID
        {
            get
            {
                if (IOServer == null)
                    return "";
                return IOServer.SERVER_ID;
            }
        }
        public string CommunicationID
        {
            get
            {
                if (IOCommunication == null)
                    return "";
                return IOCommunication.IO_COMM_ID;
            }
        }
        //驱动参数配置
        public string ParaString = "";
        #region CreateObject

        //不使用缓存
        protected   object CreateObject(string fullname, string dllname)
        {
            try
            {
                object objType = Assembly.LoadFrom(Application.StartupPath + "/" + dllname + ".dll").CreateInstance(fullname, true);
                return objType;
            }
            catch
            {

                return null;
            }

        }
        /// <summary>
        /// 创建设备驱动
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected   List<ScadaDeviceKernel> CreateDeviceKernel(List<SCADA_DEVICE_DRIVER> driveModels)
        {
            List<ScadaDeviceKernel> drives = new List<ScadaDeviceKernel>();
            for (int i = 0; i < driveModels.Count; i++)
            {
                ScadaDeviceKernel river = (ScadaDeviceKernel)CreateObject(driveModels[i].DeviceFullName, driveModels[i].Dll_Name);
                if (river != null)
                {

                    river.Driver = driveModels[i];


                    drives.Add(river);
                }

            }
            return drives;


        }
        protected ScadaCommunicateKernel CreateCommunicateDrive(SCADA_DRIVER communicateModel)
        {
            ScadaCommunicateKernel river = (ScadaCommunicateKernel)CreateObject(communicateModel.CommunicationFullName, communicateModel.FillName);
            if (river != null)
            {
                river.Driver = communicateModel;
            }

            return river;


        }
        #endregion
        #region 接口属性和方法


        /// <summary>
        /// 初始化驱动
        /// </summary>
        public   bool InitKernel(IO_SERVER server, IO_COMMUNICATION communication, List<IO_DEVICE> ioDevices, SCADA_DRIVER driver)
        {
            try
            {

                this.ParaString = "";
                if (communication != null && server != null)
                {
                    this.IOServer = server;
                    this.IOCommunication = communication;
                    this.IODevices = ioDevices;
                    if (driver == null)
                    {
                      driver = driverBll.GetModel(communication.IO_COMM_DRIVER_ID);
                    }
                    if (driver != null)
                    {
                        this.Driver = driver;
                        this.DeviceDriverModels = deviceDriverBll.GetModelList(" Dll_GUID='" + driver.GUID + "'");
                        if(DeviceDriverModels!=null&& DeviceDriverModels.Count>0)
                        DeviceDrives = CreateDeviceKernel(DeviceDriverModels);
                    }

                    if (communication != null)
                        this.ParaString = communication.IO_COMM_PARASTRING;

                }
                return InitCommunicateKernel(server, communication, ioDevices, driver);

            }
            catch (Exception ex)
            {
                this.DeviceException(ex.Message);
                return false;
            }


        }

        protected virtual bool InitCommunicateKernel(IO_SERVER server, IO_COMMUNICATION communication, List<IO_DEVICE> ioDevices, SCADA_DRIVER driver)
        {
            try
            {


           
                return true;
            }
            catch
            {
                return false;
            }


        }
        public void CloseServer()
        {
            try
            {
                this.IsSuspend = true;
                
                if (TaskCancel != null)
                    TaskCancel.Cancel();
                Close();
            }
            catch (Exception ex)
            {
                this.DeviceException(ex.Message);
            }
        }
        protected virtual void Close()
        {
           
        }
        #region 通讯驱动事件
        public event CommunicationEvent CommunctionStart;
        protected void CommunctionStartChanged(IO_SERVER server,object tag)
        {
            if(CommunctionStart!=null)
            {
                CommunctionStart(server,IOCommunication,tag);
            }
        }
        public event CommunicationEvent CommunctionPause;
        protected void CommunctionPauseChanged(IO_SERVER server, object tag)
        {
            if (CommunctionPause != null)
            {
                CommunctionPause(server, IOCommunication,tag);
            }
        }
        public event CommunicationEvent CommunctionStop;
        protected void CommunctionStopChanged(IO_SERVER server, object tag)
        {
            if (CommunctionStop != null)
            {
                CommunctionStop(server, IOCommunication, tag);
            }
        }
        public event CommunicationEvent CommunctionClose;
        protected void CommunctionCloseChanged(IO_SERVER server, object tag)
        {
            if (CommunctionClose != null)
            {
                CommunctionClose(server, IOCommunication, tag);
            }
        }
        public event CommunicationEvent CommunctionContinue;
        protected void CommunctionContinueChanged(IO_SERVER server, object tag)
        {
            if (CommunctionContinue != null)
            {
                CommunctionContinue(server, IOCommunication,tag);
            }
        }
        #endregion
 
     
        /// <summary>
        /// 定义用户的驱动配置界面
        /// </summary>
        public virtual CommunicationKernelControl CommunicationControl
        {
            set;
            get;
        }
        
        //
        public event DriverEvent DeviceStatusChanged;
        /// <summary>
        /// 设备通讯状态变化的时候修改对应的界面显示效果，树结构中的参数
        /// </summary>
        /// <param name="server"></param>
        /// <param name="device"></param>
        /// <param name="para"></param>
        /// <param name="tag"></param>
        protected void DeviceStatus(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, IO_PARA para, object tag)
        {
            if (device != null)
            {
                if (DeviceStatusChanged != null)
                {
                    DeviceStatusChanged(server, comm, device, para, tag);
                }
            }
          
        }
       

        public   string GetUIParameter()
        {
            if (CommunicationControl != null)
                return CommunicationControl.GetUIParameter();
            else
                return "";
        }
        public   void SetUIParameter(string patastring)
        {
            this.ParaString = patastring;
            if (CommunicationControl != null)
                CommunicationControl.SetUIParameter(patastring);
        }
        public void PauseServer()
        {
            try
            {
                IsSuspend = true;
                Pause();
            }
            catch (Exception ex)
            {
                this.DeviceException(ex.Message);
            }
        }
        protected virtual void Pause()
        {
            
        }
        public void ContinueServer()
        {
            try
            {
                IsSuspend = false;
                Continue();
            }
            catch (Exception ex)
            {
                this.DeviceException(ex.Message);
            }
        }
        protected virtual void Continue()
        {
          
        }
        /// <summary>
        /// 设备中的下置命令后的事件
        /// </summary>
        public event DeviceSendedEvent DeviceSended;
        Task ServerTask = null;
        CancellationTokenSource TaskCancel = null;
        //发送下置命令,没有返回结构的值
        public  ScadaResult SendCommand(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, IO_PARA para, string value)
        {
            try
            {
                ScadaResult result= IOSendCommand(server, comm, device, para, value);
                if (DeviceSended != null)
                {
                    DeviceSended(server, comm, device, para, value, false);
                }
                return result;
            }
            catch
            {
                return new ScadaResult(false, "发送数据失败");
            }
        }
        protected virtual ScadaResult IOSendCommand(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, IO_PARA para, string value)
        {
            return new ScadaResult(false, "发送数据失败");
        }

        /// <summary>
        /// 发送数据完成的事件
        /// </summary>
        /// <param name="server"></param>
        /// <param name="device"></param>
        /// <param name="para"></param>
        /// <param name="value"></param>
        protected void DataSended(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, IO_PARA para, string value,bool result)
        {
            if (DeviceSended != null)
            {
                DeviceSended(server, comm, device, para, value, result);
            }
        }
        public void StartServer()
        {
            try
            {
                TaskCancel = new CancellationTokenSource();
                ServerTask = Task.Run(() =>
                 {
                     while (true)
                     {
                         if (TaskCancel.IsCancellationRequested == true)
                         {
                             break;
                         }
                     }
                 }, TaskCancel.Token);
            }
            catch (Exception ex)
            {
                this.DeviceException(ex.Message);
            }
        }
        protected virtual void Start()
        {
            
        }
        public void StopServer()
        {
            try
            {


                TaskCancel.Cancel();
                TaskCancel.Dispose();
                TaskCancel = null;
                ServerTask.Dispose();
                ServerTask = null;
                IsSuspend = true;
                Stop();
            }
            catch(Exception ex)
            {
                this.DeviceException(ex.Message);
            }

        }
        protected virtual void Stop()
        {
          
        }
        /// <summary>
        /// 程序异常的事件
        /// </summary>
        public event CommunicationDriveError Exception;
        public event ShowFormLog OnShowFormLog;
        /// <summary>
        /// 程序异常处理
        /// </summary>
        /// <param name="msg"></param>
        protected  void DeviceException(string msg)
        {

            Logger.Logger.GetInstance().Debug(msg);
            if (this.Exception != null)
                this.Exception(msg);
        }
        protected void ShowFormLog(string msg)
        {
            if (this.OnShowFormLog != null)
                this.OnShowFormLog(msg);
        }
        public event DataReceived OnDataReceived;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="comm"></param>
        /// <param name="device"></param>
        /// <param name="receivedatas">接收的数据的字节</param>
        /// <param name="date">接收数据的日期</param>
        /// <param name="sender">接收数据的其它限定参数</param>
        protected  void ReceiveData(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, byte[] receivedatas,string date,object sender=null)
        {
             Task.Run(() => { 
            if(OnDataReceived!=null)
            {
                OnDataReceived(server, comm,device, receivedatas,date, sender);
            }
            });
        }

        #endregion
        #region 下位机模拟器模拟
        //模拟器返回的日志信息
        public event ShowFormLog SimulatorLog;
        public virtual   void Simulator(int times,bool IsSystem)
        {

        }
        public virtual   void SimulatorStart()
        {

        }
        public virtual   void SimulatorClose()
        {

        }
        public    void SimulatorAppendLog(string msg)
        {
            if (SimulatorLog != null)
                SimulatorLog(msg);
        }
        #endregion
    }
}
