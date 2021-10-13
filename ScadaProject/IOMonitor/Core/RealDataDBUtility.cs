
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
        /// 获取要上传的实时数据字符串组合
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static string GetRealDataCacheString(IO_DEVICE device)
        {


            List<IO_PARA> paras = new List<IO_PARA>();


            string str = "IO_COMM_ID:" + device.IO_COMM_ID + "#IO_DEVICE_ID:" + device.IO_DEVICE_ID + "#IO_SERVER_ID:" + device.IO_SERVER_ID + "#IO_DEVICE_NAME:" + device.IO_DEVICE_NAME + "#DATE:" + (device.GetedValueDate == null ? "" : UnixDateTimeConvert.ConvertDateTimeInt(device.GetedValueDate.Value).ToString()) + "";
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
            return str;
        }
        
        /// <summary>
        /// 上传实时数据
        /// </summary>
        /// <param name="server"></param>
        /// <param name="comm"></param>
        /// <param name="device"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static bool UploadReal(List<ReceiveCacheObject> receiveCaches)
        {
            bool result = false;
            string sendString = "";
            receiveCaches.ForEach(delegate (ReceiveCacheObject p) {

                sendString += p.DataString + "^";
            });

            try
            {
                TcpData tcpData = new TcpData();
             
                byte[] simuBytes = tcpData.StringToTcpByte(sendString, Scada.AsyncNetTcp.ScadaTcpOperator.实时值);
                if (IOMonitorManager.TcpClient != null && IOMonitorManager.TcpClient.IsClientConnected)
                {
                    IOMonitorManager.TcpClient.Send(new ArraySegment<byte>(simuBytes));
                    result = true;
                }
                else
                {
                    result = false;
                }
                return result;
            }
            catch (Exception ex)
            {

                result = false;
                //写入错误日志，并将错误日志返回的日志窗体
                MonitorFormManager.DisplyException(ex);
            }
            sendString = "";
            receiveCaches.Clear();
            receiveCaches = null;
            return result;

        }

        public static string GetAlarmCacheString(IO_DEVICE device, out List<IO_PARAALARM> alarms)
        {
            alarms = new List<IO_PARAALARM>();

            IODeviceParaMaker paraMaker = new IODeviceParaMaker();
            string alarmString = "";
            for (int i = 0; i < device.IOParas.Count; i++)
            {
                try
                {

                    IO_PARAALARM alarm = paraMaker.MakeAlarm(device.IOParas, device.IOParas[i], device.IOParas[i].IORealData, device.IO_DEVICE_LABLE);
                    if (alarm != null && !string.IsNullOrEmpty(alarm.IO_ALARM_DATE))
                    {
                        alarmString += "^" + alarm.GetCommandString();
                        alarms.Add(alarm);
                    }
                }
                catch
                {
                    continue;
                }

            }
            return alarmString;
        }
        


        /// <summary>
        /// 从采集站端上传报警值
        /// </summary>
        /// <param name="server"></param>
        /// <param name="comm"></param>
        /// <param name="device"></param>
        /// <returns></returns>
        public static bool UploadAlarm(List<AlarmCacheObject> receiveCaches)
        {


            bool result = false;
            string sendString = "";
            receiveCaches.ForEach(delegate (AlarmCacheObject p) {

                sendString += p.DataString + "^";
            });

            try
            {

                Scada.AsyncNetTcp.TcpData tcpData = new Scada.AsyncNetTcp.TcpData();
                byte[] simuBytes = tcpData.StringToTcpByte(sendString, Scada.AsyncNetTcp.ScadaTcpOperator.报警值);


              
                if (IOMonitorManager.TcpClient != null && IOMonitorManager.TcpClient.IsClientConnected)
                {
                    IOMonitorManager.TcpClient.Send(new ArraySegment<byte>(simuBytes));
                    result = true;
                }
            }
            catch (Exception ex)
            {

                result = false;
                //写入错误日志，并将错误日志返回的日志窗体
                MonitorFormManager.DisplyException(ex);
            }
            receiveCaches.Clear();
            receiveCaches = null;
            sendString = "";
            return result;

        }

    }


}
    
