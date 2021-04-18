using Scada.IOStructure;
using Scada.Model;
using Scada.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Kernel
{
    /// <summary>
    ///定义设备驱动，主要用来解析设备传递过来的IO点表
    /// </summary>
    public  class ScadaDeviceKernel : IDisposable
    {
          /// <summary>
        /// 驱动唯一标识，采用系统GUID分配
        /// </summary>
        public virtual string GUID
        {
            get;
            
        }
        public virtual string Title { set; get; }
        /// <summary>
        /// 判断用户是否创建控件
        /// </summary>
        public bool IsCreateControl = true;
        public SCADA_DEVICE_DRIVER Driver = null;
        protected IO_SERVER IOServer = null;
        protected IO_COMMUNICATION IOCommunication = null;
        protected IO_DEVICE IODevice = null;
        public string DeviceID
        {
            get
            {
                if (IODevice == null)
                    return "";
                return IODevice.IO_DEVICE_ID;
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
        public string DeviceDriverID
        {
            get {
                if (Driver == null)
                    return "";
                return Driver.Id.ToString();
            }
        }
        public ScadaDeviceKernel()
        {

        }
         
        public  bool InitKernel(IO_SERVER server, IO_COMMUNICATION communication,IO_DEVICE device, IO_PARA para, SCADA_DEVICE_DRIVER driver)
        {
            try
            {
                this.ParaString = "";
                this.DeviceParaString = "";
                this.IOServer = server;
                this.IOCommunication = communication;
                this.IODevice = device;
                this.Driver = driver;

                if (para != null)
                {
                    this.ParaString = para.IO_PARASTRING;
                }
                if (device != null)
                {
                    this.DeviceParaString = device.IO_DEVICE_PARASTRING;
                }
                return InitDeviceKernel(server, communication, device,para, driver);
            }
            catch
            {
                return false;
            }
        }
       
        protected virtual bool InitDeviceKernel(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device, IO_PARA para, SCADA_DEVICE_DRIVER driver)
        {
           
            return true;
        }

        /// <summary>
        /// 要解析的单个参数，下位机单独打包每个参数并返回，在此结构中需要用到ioaddress作为标识符号，并且要给本身接口的PataString 赋值
        /// </summary>
        /// <param name="datas">需要解析的数据</param>
        /// <param name="datatime">数据接收的时间</param>
        /// <param name="key">参数名称</param>
        /// <param name="modemaddress">设备地址</param>
        /// <param name="savehis">是否保存历史</param>
        /// <param name="ioaddress">参数通道或者地址，用户根据需要在接口中实现与否</param>
        /// <returns></returns>
        protected virtual IOData Analysis(IO_SERVER server, IO_COMMUNICATION Communication,IO_DEVICE device, IO_PARA para,byte[] datas, DateTime datatime, object sender)
        {

            return null;
        }
        public IOData AnalysisData(IO_SERVER server, IO_COMMUNICATION Communication, IO_DEVICE device, IO_PARA para, byte[] datas, DateTime datatime, object sender)
        {
            try
            {
                return Task<IOData>.Run(() =>
                {
                    IOData data = Analysis(server, Communication, device, para, datas, datatime, sender);

                    return data;
                }).Result;
            }
            catch(Exception emx)
            {
                DeviceException(emx.Message);
                return null;
            }
        }
        /// <summary>
        /// 解析当前设备下的所有IO点
        /// </summary>
        /// <param name="server"></param>
        /// <param name="device"></param>
        /// <param name="paras"></param>
        /// <param name="datas"></param>
        /// <param name="datatime"></param>
        /// <returns></returns>


 
 
        /// <summary>
        /// 当前设备自定义驱动的参数字符串
        /// </summary>
        private string _ParaString = "";
        /// <summary>
        /// 当前设备自定义驱动的参数字符串
        /// </summary>
        public string ParaString
        {

            get
            {

                return _ParaString;

            }
            set
            {

                _ParaString = value;

            }
        }

        public IOParaKernelControl ParaCtrl
        {
            set;
            get;
        }


        /// <summary>
        /// 当前设备自定义驱动的参数字符串
        /// </summary>
        private string _DeviceParaString = "";
        /// <summary>
        /// 当前设备自定义驱动的参数字符串
        /// </summary>
        public string DeviceParaString
        {

            get
            {

                return _DeviceParaString;

            }
            set
            {

                _DeviceParaString = value;

            }
        }
        public IODeviceKernelControl DeviceCtrl
        {
            set;
            get;
        }
        /// <summary>
        /// 程序异常的事件
        /// </summary>
        public event DeviceDriveError ExceptionEvent;
        /// <summary>
        /// 程序异常处理
        /// </summary>
        /// <param name="msg"></param>
        protected   void DeviceException(string msg)
        {
            Logger.Logger.GetInstance().Debug(msg);
            if (this.ExceptionEvent != null)
                this.ExceptionEvent(msg);
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        public  void Dispose()
        {
            try
            {
                DeviceDriveDispose();
            }
            catch(Exception emx)
            {
                DeviceException(emx.Message);
            }
        }
        protected virtual void DeviceDriveDispose()
        {

        }
    }
}
