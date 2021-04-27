using Scada.Kernel;
using Modbus.ModbusAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOMonitor.Core
{
  public abstract   class DriverAssembly
    {
        #region 加载通讯设备驱动Dll
        private static object CreateObject(string fullname, string dllname)
        {
            try
            {
                Assembly assm = Assembly.LoadFrom(Application.StartupPath + "\\" + dllname + ".dll");//第一步：通过程序集名称加载程序集
                object objType = assm.CreateInstance(fullname, true);// 第二步：通过命名空间+类名创建类的实例。
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
        public static ScadaDeviceKernel CreateDeviceDrive(Scada.Model.SCADA_DEVICE_DRIVER driveModel)
        {
            try
            {

                ScadaDeviceKernel river = (ScadaDeviceKernel)CreateObject(driveModel.DeviceFullName, driveModel.Dll_Name);
 
                return river;
            }
            catch 
            {
                return null;
            }
       
        }
        /// <summary>
        /// 创建通讯驱动
        /// </summary>
        /// <param name="commModel"></param>
        /// <returns></returns>
        public static ScadaCommunicateKernel CreateCommunicateDriver(Scada.Model.SCADA_DRIVER commModel)
        {
            try
            {

                ScadaCommunicateKernel river = (ScadaCommunicateKernel)CreateObject(commModel.CommunicationFullName, commModel.FillName);
 
                
 
                return river;
            }
            catch  
            {
                return null;
            }
       
        }
        #endregion
    }
}
