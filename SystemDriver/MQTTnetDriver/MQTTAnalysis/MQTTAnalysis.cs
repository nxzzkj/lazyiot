using Scada.IOStructure;
using Scada.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scada.Model;

namespace MQTTnet
{
    /// <summary>
    /// Mqtt物联网协议数据解析
    /// </summary>
    public class MQTTAnalysis : ScadaDeviceKernel
    {
        private const string mGuid = "98988BF9-A219-41AB-8459-9E40E81128B3";
        /// <summary>
        /// 驱动唯一标识，采用系统GUID分配
        /// </summary>
        public override string GUID
        {
            get
            {
                return mGuid;
            }
        }
        private string mTitle = "MQTT物联网协议数据解析";
        public override string Title
        {
            get
            {
                return mTitle;
            }

            set
            {
                mTitle = value;
            }
        }
        private  DateTime? GetDateTime(string dateTime)
        {
            try
            {
                string[] strArr = dateTime.Split(new char[] { '-', ' ', ':', ',' });
                if(strArr.Length==7)
                {
                    DateTime dt = new DateTime(int.Parse(strArr[0]),
                     int.Parse(strArr[1]),
                     int.Parse(strArr[2]),
                     int.Parse(strArr[3]),
                     int.Parse(strArr[4]),
                     int.Parse(strArr[5]),
                     int.Parse(strArr[6]));
                    return dt;

                }
                else if (strArr.Length ==6)
                {
                    DateTime dt = new DateTime(int.Parse(strArr[0]),
                     int.Parse(strArr[1]),
                     int.Parse(strArr[2]),
                     int.Parse(strArr[3]),
                     int.Parse(strArr[4]),
                     int.Parse(strArr[5]));
                    return dt;

                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        protected override IOData Analysis(IO_SERVER server, IO_COMMUNICATION Communication, IO_DEVICE device, IO_PARA para, byte[] datas, DateTime datatime, object sender)
        {
            ParaPack commPack = new ParaPack(Communication.IO_COMM_PARASTRING);
            ParaPack devicePack = new ParaPack(device.IO_DEVICE_PARASTRING);
            IOData data = new IOData();
            data.QualityStamp = QualityStamp.BAD;
            if (device == null)
                return data;

            if(para==null)
                return data;

            if(sender==null)
                return data;

            if (datas.Length<=0)
                return data;


            if (commPack.GetValue("数据格式") == "江苏协昌环保股份有限公司")
            {
                #region 江苏协昌环保股份有限公司
               
                    try
                    {



                        ParaPack paraPack = new ParaPack(para.IO_PARASTRING);

                        string deviceUid = devicePack.GetValue("设备识别号").Trim();
                        data.CommunicationID = Communication.IO_COMM_ID;
                        data.ID = device.IO_DEVICE_ADDRESS;
                        data.ParaName = para.IO_NAME;
                        data.ServerID = server.SERVER_ID;

                        data.Date = DateTime.Now;
                        string str = ScadaHexByteOperator.UTF8ByteToString(datas);

                        MqttJsonObject mqttJsonObject = (MqttJsonObject)sender;

                        if (mqttJsonObject != null && !string.IsNullOrEmpty(deviceUid) && mqttJsonObject.device.uid.Trim() == deviceUid.Trim())
                        {
                            //由于一次性获取的是所有数据,所以需要解析所有数据
                            data.QualityStamp = QualityStamp.GOOD;
                            string jsonname = paraPack.GetValue("JSON名称").Trim();
                            string boardAddress = paraPack.GetValue("版子地址");
                            string boardIndex = paraPack.GetValue("版子索引号");
                            string port = paraPack.GetValue("端口号");
                            string portIndex = paraPack.GetValue("端口索引号");
                            string DataType = paraPack.GetValue("数据类型");
                            string valueIndex = paraPack.GetValue("采集值索引号");
                            if (mqttJsonObject.paras != null)
                            {
                                MqttJsonPara selectObj = mqttJsonObject.paras.Find(x => x.name.Trim() == jsonname.Trim());
                                if (selectObj != null)
                                {
                                    if (selectObj.data != null && selectObj.data.Count > 0)
                                    {
                                        string date = selectObj.data[0].ToString();
                                        try
                                        {
                                            ///解析Json数据

                                            DateTime? dateTime = GetDateTime(date);
                                            if (dateTime != null)
                                            {
                                                string pboardAddress = selectObj.data[int.Parse(boardIndex)].ToString();
                                                string pport = selectObj.data[int.Parse(portIndex)].ToString();
                                                string value = selectObj.data[int.Parse(valueIndex)].ToString();
                                                data.QualityStamp = QualityStamp.GOOD;
                                                data.ParaValue = value;
                                                data.Date = dateTime;
                                            }
                                            else
                                            {
                                         
                                                data.QualityStamp = QualityStamp.BAD;
                                                data.ParaValue = data.QualityStampValue.ToString();

                                            }

                                        }
                                        catch (Exception emx)
                                        {
                                            this.DeviceException(emx.Message);
                                            data.QualityStamp = QualityStamp.BAD;
                                            data.ParaValue = data.QualityStampValue.ToString();
                                        }
                                    }

                                }
                                else
                                {

                                    data.QualityStamp = QualityStamp.BAD;
                                    data.ParaValue = data.QualityStampValue.ToString();
                                }
                            }


                        }
                        else
                        {
                           
                            data.QualityStamp = QualityStamp.BAD;
                            data.ParaValue = data.QualityStampValue.ToString();
                        }

                    }
                    catch (Exception emx)
                    {
                        data.QualityStamp = QualityStamp.BAD;
                        data.ParaValue = data.QualityStampValue.ToString();
                        this.DeviceException(emx.Message);
                    }
             
                #endregion
            }
            else if (commPack.GetValue("数据格式") == "通用MQTT解析")
            {
                #region 通用MQTT解析
               
                    try
                    {



                        ParaPack paraPack = new ParaPack(para.IO_PARASTRING);
                        string deviceUid = devicePack.GetValue("设备ID编码").Trim();
                        data.CommunicationID = Communication.IO_COMM_ID;
                        data.ID = device.IO_DEVICE_ADDRESS;
                        data.ParaName = para.IO_NAME;
                        data.ServerID = server.SERVER_ID;
                        data.Date = DateTime.Now;
                        string str = ScadaHexByteOperator.UTF8ByteToString(datas);

                        CommonMqttJsonObject mqttJsonObject = (CommonMqttJsonObject)sender;

                        if (mqttJsonObject != null && !string.IsNullOrEmpty(deviceUid) && mqttJsonObject.device.uid.Trim() == deviceUid.Trim())
                        {
                            //由于一次性获取的是所有数据,所以需要解析所有数据
                            data.QualityStamp = QualityStamp.GOOD;
                            string jsonname = paraPack.GetValue("IO标识").Trim();
                         
                            string timeIndex = paraPack.GetValue("时间值索引");
                            string DataType = paraPack.GetValue("数据类型");
                            string valueIndex = paraPack.GetValue("采集值索引");
                            if (DataType == "命令参数")
                            {
                                data.QualityStamp = QualityStamp.GOOD;
                                data.ParaValue = data.QualityStampValue.ToString();
                                return data;
                            }
                            //采集参数
                            if (mqttJsonObject.paras != null)
                            {
                                CommonMqttJsonPara selectObj = mqttJsonObject.paras.Find(x => x.name.Trim() == jsonname.Trim());
                                if (selectObj != null)
                                {
                                    if (selectObj.data != null && selectObj.data.Count > 0)
                                    {
                                        string date = selectObj.data.Count>(int.Parse(timeIndex)+1)? selectObj.data[int.Parse(timeIndex)].ToString():DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,f");
                                        try
                                        {
                                            ///解析Json数据

                                            DateTime? dateTime = GetDateTime(date);
                                            if (dateTime != null)
                                            {
                                       
                                                string value = selectObj.data.Count > (int.Parse(valueIndex) + 1) ? selectObj.data[int.Parse(valueIndex)].ToString():"-9999";
                                                data.QualityStamp = value!="-9999"?QualityStamp.GOOD: QualityStamp.BAD;
                                                data.ParaValue = value;
                                                data.Date = dateTime;
                                            }
                                            else
                                            {
                                               
                                                data.QualityStamp = QualityStamp.BAD;
                                                data.ParaValue = data.QualityStampValue.ToString();

                                            }

                                        }
                                        catch (Exception emx)
                                        {
                                            this.DeviceException(emx.Message);
                                            data.QualityStamp = QualityStamp.BAD;
                                            data.ParaValue = data.QualityStampValue.ToString();
                                        }
                                    }

                                }
                                else
                                {

                                    data.QualityStamp = QualityStamp.BAD;
                                    data.ParaValue = data.QualityStampValue.ToString();
                                }
                            }


                        }
                        else
                        {
                        
                            data.QualityStamp = QualityStamp.BAD;
                            data.ParaValue = data.QualityStampValue.ToString();
                        }

                    }
                    catch (Exception emx)
                    {
                        data.QualityStamp = QualityStamp.BAD;
                        data.ParaValue = data.QualityStampValue.ToString();
                        this.DeviceException(emx.Message);
                    }
            
                #endregion
            }

 
            return data;
        }
        protected override bool InitDeviceKernel(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device, IO_PARA para, SCADA_DEVICE_DRIVER driver)
        {

            if (IsCreateControl)
            {
                ParaPack commPack = new ParaPack(communication.IO_COMM_PARASTRING);
                ParaPack devicePack = new ParaPack(device.IO_DEVICE_PARASTRING);
                if (para != null)
                {

                    //数据格式
                    if (commPack.GetValue("数据格式") == "江苏协昌环保股份有限公司")
                    {
                        this.ParaCtrl = new IOParaCtrl();
                        this.ParaCtrl.SetUIParameter(server, device, para);
                    }
                    else if (commPack.GetValue("数据格式") == "通用MQTT解析")
                    {
                        this.ParaCtrl = new GasIOParaCtrl();
                        this.ParaCtrl.SetUIParameter(server, device, para);
                    }



                }
                if (commPack.GetValue("数据格式") == "江苏协昌环保股份有限公司")
                {
                    this.DeviceCtrl = new IODeviceCtrl();
                    this.DeviceCtrl.SetUIParameter(server, device);
                }
                else if (commPack.GetValue("数据格式") == "通用MQTT解析")
                {
                    this.DeviceCtrl = new GasIODeviceCtrl();
                    this.DeviceCtrl.SetUIParameter(server, device);
                }


            }
            if (para != null)
            {
                this.ParaString = para.IO_PARASTRING;
            }
            this.DeviceParaString = device.IO_DEVICE_PARASTRING;

            return true;
        }
         
    }
}
