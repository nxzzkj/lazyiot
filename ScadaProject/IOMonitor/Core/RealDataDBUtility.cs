
using Scada.AsyncNetTcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scada.DBUtility;
using Scada.Model;
using Scada.MakeAlarm;

namespace IOMonitor.Core
{
    /// <summary>
    /// 实际数据插入接口,目前采用TCP/IP的方式进行数据向服务器传输
    /// </summary>
    public class RealDataDBUtility
    {

        /// <summary>
        /// 插入实时数据
        /// </summary>
        /// <param name="server"></param>
        /// <param name="comm"></param>
        /// <param name="device"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static  bool UploadReal(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device)
        {
            bool result = false;
            string devicestring = device.GetCommandString() + "#";
            List<IO_PARA> paras = new List<IO_PARA>();


            string str = "IO_COMM_ID:" + device.IO_COMM_ID + "#IO_DEVICE_ID:" + device.IO_DEVICE_ID + "#IO_SERVER_ID:" + device.IO_SERVER_ID + "#IO_DEVICE_NAME:" + device.IO_DEVICE_NAME + "#DATE:" + (device.GetedValueDate==null?"":UnixDateTimeConvert.ConvertDateTimeInt(device.GetedValueDate.Value).ToString()) + "";
            for (int i = 0; i < device.IOParas.Count; i++)
            {
                if (device.IOParas[i].IORealData == null)
                    continue;
                string QualityStampStr = "BAD";
                if (device.IOParas[i].RealQualityStamp == Scada.IOStructure.QualityStamp.NONE)
                {
                    device.IOParas[i].IORealData.QualityStamp = Scada.IOStructure.QualityStamp.NONE;
                    QualityStampStr = "NONE";
                }
                else if (device.IOParas[i].RealQualityStamp == Scada.IOStructure.QualityStamp.GOOD)
                {
                    device.IOParas[i].IORealData.QualityStamp = Scada.IOStructure.QualityStamp.GOOD;
                    QualityStampStr = "GOOD";
                }
                else
                {
                    device.IOParas[i].IORealData.QualityStamp = Scada.IOStructure.QualityStamp.BAD;
                    QualityStampStr = "BAD";
                }
                if (device.IOParas[i].RealValue == "")
                {
                    device.IOParas[i].IORealData.ParaValue = "-9999";
                    device.IOParas[i].IORealData.QualityStamp = Scada.IOStructure.QualityStamp.BAD;
                    QualityStampStr = "BAD";
                }

                str += "#" + device.IOParas[i].IO_NAME + ":" + device.IOParas[i].IO_ID + "|" + device.IOParas[i].RealValue + "|" + QualityStampStr;
            }
             
            byte[] simuBytes = TcpData.StaticStringToTcpByte(str, Scada.AsyncNetTcp.ScadaTcpOperator.实时值);
     
            try
            {
                if(IOMonitorManager.TcpClient!=null&& IOMonitorManager.TcpClient.IsClientConnected)
                {
                    IOMonitorManager.TcpClient.Send(new ArraySegment<byte>(simuBytes));
                    result = true;
                }
                else
                    {
                    result = false;
                }
                
         

            }
            catch (Exception ex)
            {

                result = false;
                //写入错误日志，并将错误日志返回的日志窗体
                MonitorFormManager.DisplyException(ex);
            }

            return result;

        }
        /// <summary>
        /// 从采集站端上传报警值
        /// </summary>
        /// <param name="server"></param>
        /// <param name="comm"></param>
        /// <param name="device"></param>
        /// <returns></returns>
        public static List<IO_PARAALARM> UploadAlarm(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device)
        {
            List<IO_PARAALARM> alarms = new List<IO_PARAALARM>();

            IODeviceParaMaker paraMaker = new IODeviceParaMaker();

            for (int i = 0; i < device.IOParas.Count; i++)
            {
                try
                {

                    IO_PARAALARM alarm = paraMaker.MakeAlarm(device.IOParas, device.IOParas[i], device.IOParas[i].IORealData, device.IO_DEVICE_LABLE);
                    if (alarm != null)
                    {
                        byte[] simuBytes = TcpData.StaticStringToTcpByte(alarm.GetCommandString(), Scada.AsyncNetTcp.ScadaTcpOperator.报警值);

                        try
                        {
                            if (IOMonitorManager.TcpClient != null && IOMonitorManager.TcpClient.IsClientConnected)
                            {
                                IOMonitorManager.TcpClient.Send(new ArraySegment<byte>(simuBytes));
                                alarms.Add(alarm);
                            }
                           


                        }
                        catch (Exception ex)
                        {
                            //写入错误日志，并将错误日志返回的日志窗体
                            MonitorFormManager.DisplyException(ex);
                        }
                    }
                }
                catch (Exception emx)
                {
                    continue;
                }

            }



            return alarms;
        }
    }


}
    
