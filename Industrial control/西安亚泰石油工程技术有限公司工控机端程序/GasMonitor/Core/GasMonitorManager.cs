using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GasMonitor
{
    public class GasUnit
    {
        private int u = 0;
        public GasUnit(int _u)
        {
            u = _u;
        }
        public string Unit
        {
            get
            {

                switch (u)
                {
                    case 0: return "PPM";
                    case 1: return "%VOL";
                    case 2: return "%LEL";
                    case 3: return "PPHM";
                    case 4: return "Mg/m3";
                    case 5: return "ppb";
                    case 6: return "MgL";
                }
                return "PPM";
            }


        }
    }
    /// <summary>
    /// 整个客户端的服务管理类
    /// </summary>
    public static class GasMonitorManager
    {
        #region 系统变量
        public static ReceiveCachec ReceiveAlarmCachec = null;
        public static ReceiveCachec ReceiveAlarmStatusCachec = null;
        /// <summary>
        /// 数据缓存
        /// </summary>
        public static ReceiveCachec ReceiveCachec = null;
        /// <summary>
        /// MQTT物联网协议客户端
        /// </summary>
        public static IMqttClient MqttClient = null;
        /// <summary>
        /// 配置文件类
        /// </summary>
        public static GasMonitorConfig Config = null;

        public static RealDataFrm realDataFrm = new RealDataFrm();
        public static RealSeriesFrm realSeriesFrm = new RealSeriesFrm();
        public static AlarmSetFrm alarmSetFrm = new AlarmSetFrm();
        public static SystenSetFrm systenSetFrm = new SystenSetFrm();
        public static LogFrm logFrm = new LogFrm();
        public static MainForm MainForm = null;
        public static Modbus_Serial ModbusSlave = null;
        public static int MqttUpdateCycle = 60;
        /// <summary>
        /// 定义全局通道
        /// </summary>
        /// <returns></returns>
        public static List<ChannelElement> Chanels = new List<ChannelElement>();
        #endregion
        #region 系统服务类的方法
        public static void InitMonitorManager(MainForm mainForm)
        {

            try
            {

                MainForm = mainForm;
                //实时数据缓存池
                ReceiveCachec = new ReceiveCachec();
                ReceiveCachec.OnGeted += ReceiveCachec_OnGeted;
                ReceiveCachec.OnPushed += ReceiveCachec_OnPushed;
                ReceiveCachec.MaxNumber = 1000;
                //报警缓存池
                ReceiveAlarmCachec = new ReceiveCachec();
                ReceiveAlarmCachec.OnGeted += ReceiveAlarmCachec_OnGeted;
                ReceiveAlarmCachec.OnPushed += ReceiveAlarmCachec_OnPushed;
                ReceiveAlarmCachec.MaxNumber = 1000;

                ///报警状态
                ReceiveAlarmStatusCachec = new ReceiveCachec();
                ReceiveAlarmStatusCachec.OnGeted += ReceiveAlarmStatusCachec_OnGeted;
                ReceiveAlarmStatusCachec.OnPushed += ReceiveAlarmStatusCachec_OnPushed;
                ReceiveAlarmStatusCachec.MaxNumber = 1000;


                Config = new GasMonitorConfig();
                GasMonitorManager.Chanels = Config.Channels;
                //加载系统配置表单信息

                systenSetFrm.InitForms();
                realDataFrm.InitForms();
                realSeriesFrm.InitForms();
                alarmSetFrm.InitForms();
                //初始化主界面左边树结构
                MainForm.InitForms();
                SerialConfig serialConfig = new SerialConfig()
                {
                    BaudRate = int.Parse(Config.SerialPort.BaudRate),
                    CollectFaultsInternal = int.Parse(Config.SerialPort.CollectFaultsInternal),
                    CollectFaultsNumber = int.Parse(Config.SerialPort.CollectFaultsNumber),
                    ContinueCollect = string.IsNullOrEmpty(Config.SerialPort.ContinueCollect) || Config.SerialPort.ContinueCollect.Trim() == "0" ? false : true,
                    DataBits = int.Parse(Config.SerialPort.DataBits),
                    ModbusType = "RTU",
                    OffsetInterval = int.Parse(Config.SerialPort.OffsetInterval),
                    PackMaxSize = int.Parse(Config.SerialPort.PackMaxSize),
                    ReadTimeout = int.Parse(Config.SerialPort.ReadTimeout),
                    WriteTimeout = int.Parse(Config.SerialPort.WriteTimeout),
                    SerialCheck = (Parity)Enum.Parse(typeof(Parity), Config.SerialPort.CheckBit),
                    SerialPort = Config.SerialPort.Port,
                    UpdateCycle = Config.SerialPort.UpdateCycle,
                    RTSEnable = string.IsNullOrEmpty(Config.SerialPort.RTSEnable) || Config.SerialPort.RTSEnable.Trim() == "0" ? false : true,
                    RSTSendPreKeeyTime = int.Parse(Config.SerialPort.RSTSendPreKeeyTime),
                    RTSSendAfterKeeyTime = int.Parse(Config.SerialPort.RSTSendPreKeeyTime),
                    Chanels = Chanels,
                    StopBits = StopBits.One,
                    ModbusParas = Config.ModbusPara


                };
                switch (Config.SerialPort.StopBit.Trim())
                {
                    case "0":
                        serialConfig.StopBits = StopBits.None;
                        break;
                    case "1":
                        serialConfig.StopBits = StopBits.One;
                        break;
                    case "2":
                        serialConfig.StopBits = StopBits.Two;
                        break;
                    case "1.5":
                        serialConfig.StopBits = StopBits.OnePointFive;
                        break;
                    default:
                        serialConfig.StopBits = StopBits.One;
                        break;
                }
                ModbusSlave = new Modbus_Serial(serialConfig);
                ModbusSlave.LogOutput = new Action<string>((s) =>
                 {
                     if (logFrm != null && !logFrm.IsDisposed)
                     {
                         logFrm.AddLog(s);
                     }
                 });
                //接收到数据,在此处进行解析
                ModbusSlave.ReadDataSuccessed = new Action<List<RealData>>((s) =>
                {
                    try
                    {
                        if (s == null || s.Count <= 0)
                            return;
                        string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "," + DateTime.Now.Millisecond.ToString();
                        string str = "";
                        foreach (RealData d in s)
                        {
                            if (d.ReadSendByte == null || d.ReadSendByte.Length <= 0)
                            {
                                continue;
                            }
                            str += ModbusConvert.ByteToHexStr(d.ReadSendByte) + " ,";
                            try
                            {
                                ReceiveItem realData = new ReceiveItem();
                                ReceiveItem alarmData = new ReceiveItem();
                                ReceiveItem alarmstatus = new ReceiveItem();
                                realData.Id = d.SlaveId;
                                realData.Name = d.ParaName;
                                realData.Address = d.Address;
                                realData.DateTime = datetime;
                                realData.Value = "-9999";
                                alarmData.Id = d.SlaveId;
                                alarmData.Name = d.ParaName;
                                alarmData.Address = d.Address;
                                alarmData.DateTime = datetime;
                                alarmData.Value = "0.00";
                                alarmstatus.Id = d.SlaveId;
                                alarmstatus.Name = d.ParaName;
                                alarmstatus.Address = d.Address;
                                alarmstatus.DateTime = datetime;
                                alarmstatus.Value = "0.00";
                                //获取放大倍数
                                byte[] blxs = new byte[2];
                                Array.Copy(d.ReadSendByte, 12, blxs, 0, 2);
                                float blxsvalue = ModbusConvert.GetUShort(ModbusConvert.Bytes2Ushorts(blxs), 0);
                                blxsvalue = Convert.ToSingle(Math.Pow(10, blxsvalue));

                                //获取单位
                                byte[] unitb = new byte[2];
                                Array.Copy(d.ReadSendByte, 14, unitb, 0, 2);
                                realData.Unit = (new GasUnit(ModbusConvert.GetUShort(ModbusConvert.Bytes2Ushorts(unitb), 0))).Unit;

                                //获取气体值
                                realData.Address = d.Address;
                                realData.DateTime = datetime;
                                byte[] vub = new byte[4];
                                Array.Copy(d.ReadSendByte, 0, vub, 0, 4);
                                realData.Value = (ModbusConvert.GetUInt(ModbusConvert.Bytes2Ushorts(vub), 0) / blxsvalue).ToString("0.00");



                                //获取报警状态
                                alarmstatus.Address = d.Address;
                                alarmstatus.DateTime = datetime;
                                byte[] alarmstatusb = new byte[2];
                                Array.Copy(d.ReadSendByte, 4, alarmstatusb, 0, 2);
                                alarmstatus.Value = ModbusConvert.GetUShort(ModbusConvert.Bytes2Ushorts(alarmstatusb), 0).ToString();
                                //获取报警值

                                if (alarmstatus.Value == "0")//无报警
                                {
                                    alarmData.Address = d.Address;
                                    alarmData.DateTime = datetime;
                                    alarmData.Value = "0";


                                }
                                else if (alarmstatus.Value == "1")//低报警
                                {
                                    alarmData.Address = d.Address;
                                    alarmData.DateTime = datetime;
                                    byte[] alarmb = new byte[4];
                                    Array.Copy(d.ReadSendByte, 16, alarmb, 0, 4);
                                    alarmData.Value = (ModbusConvert.GetUInt(ModbusConvert.Bytes2Ushorts(alarmb), 0) / blxsvalue).ToString("0.00");


                                }
                                else if (alarmstatus.Value == "2")//高报警
                                {
                                    alarmData.Address = d.Address;
                                    alarmData.DateTime = datetime;
                                    byte[] alarmb = new byte[4];
                                    Array.Copy(d.ReadSendByte, 20, alarmb, 0, 4);
                                    alarmData.Value = (ModbusConvert.GetUInt(ModbusConvert.Bytes2Ushorts(alarmb), 0) / blxsvalue).ToString("0.00");

                                }
                                alarmData.Id = realData.Id;
                                alarmData.Unit = realData.Unit;
                                alarmData.Name = d.ParaName;
                                alarmData.Address = d.Address;
                                alarmData.DateTime = datetime;

                                if (realData != null && realData.Value != "-9999")
                                {

                                    realDataFrm.SetChannelStatus();
                                    realDataFrm.SetReadData(realData, alarmData, alarmstatus);
                                    realSeriesFrm.SetReadSeries(realData, alarmData, alarmstatus);
                                    GasMonitorManager.ReceiveCachec.PushItem(realData);
                                    GasMonitorManager.ReceiveAlarmCachec.PushItem(alarmData);
                                    GasMonitorManager.ReceiveAlarmStatusCachec.PushItem(alarmstatus);


                                }


                            }
                            catch
                            {
                                continue;
                            }



                        }
                        logFrm.AddLog(str);
                    }
                    catch (Exception emx)
                    {
                        logFrm.AddLog(emx.Message);
                    }


                });

                GasMonitorManager.Start();
                
            }
            catch (Exception emx)
            {
                logFrm.AddLog(emx.Message + " ERROR=01");
            }
        }

        private static void ReceiveAlarmStatusCachec_OnPushed(ReceiveItem item)
        {
             
        }

        private static void ReceiveAlarmStatusCachec_OnGeted(List<ReceiveItem> items)
        {
         
        }

        private static void ReceiveAlarmCachec_OnPushed(ReceiveItem item)
        {
             
        }

        private static void ReceiveAlarmCachec_OnGeted(List<ReceiveItem> items)
        {
         
        }

        private static void ReceiveCachec_OnPushed(ReceiveItem item)
        {
            
        }

        private static void ReceiveCachec_OnGeted(List<ReceiveItem> items)
        {
           
        }

        public static Task Start()
        {
            var task = Task.Run(() => {

                if (ModbusSlave!=null)
                {
                   
                    ModbusSlave.Start();
                }
                if(MqttClient==null)
                {
                    try
                    {
                        CreateMqttClient();
                   
                    }
                    catch
                    {

                    }
              
                }

            });

            return task;

        }
        public static Task Close()
        {
            var task = Task.Run(() => {

                //if(ReceiveCachec!=null)
                //{
                //    ReceiveCachec.Clear();
                //    ReceiveCachec.Dispose();
                //}
                if (ModbusSlave != null)
                {
                    ModbusSlave.Close();
                   
                }
            });

            return task;
        }
        #endregion
        #region 创建MQTT客户端
        private async static void CreateMqttClient()
        {

            try
            {
                string cleintID = Config.MQTT.ClientID.Trim();

                var options = new MqttClientOptions() { ClientId = cleintID };
                options.ChannelOptions = new MqttClientTcpOptions()
                {
                    Server = Config.MQTT.ServerIP.Trim(),
                    Port = Convert.ToInt32(Config.MQTT.Port)
                };
                options.Credentials = new MqttClientCredentials()
                {
                    Username = Config.MQTT.Account.Trim(),
                    Password = Config.MQTT.Password.Trim()
                };

                options.CleanSession = true;
                options.KeepAlivePeriod = TimeSpan.FromSeconds(100.5);
                options.KeepAliveSendInterval = TimeSpan.FromSeconds(20000);
               
                if (null != MqttClient)
                {
                    await MqttClient.DisconnectAsync();
                    MqttClient = null;
                }
                MqttClient = new MqttFactory().CreateMqttClient();
                ///接收到数据
           
                MqttClient.ApplicationMessageReceived += (sender, args) =>
                {
                    if (args.ClientId==null||args.ClientId == "")
                        return;
                    if (args.ApplicationMessage.Payload == null || args.ApplicationMessage.Payload .Length<=0)
                        return;
                    if (args.ApplicationMessage.Topic.Trim() == Config.MQTT.PassiveSubTopic.Trim())
                    {
                        Task.Run(() =>
                        {
                            ///获取当前的json字符串
                            string json = args.ApplicationMessage.ConvertPayloadToString();
                            //将json对象转换为c#对象
                            MQTTPassiveSubTopicObject subTopicObject = ScadaHexByteOperator.JsonToObject<MQTTPassiveSubTopicObject>(json);
                            logFrm.AddLog("服务器请求发布数据");
                            if (subTopicObject != null)
                            {
                                PublicRealDataJson(args.ClientId);//发布一次数据
                            }
                        });

                    }
                    else if (args.ApplicationMessage.Topic.Trim() == Config.MQTT.UpdateCycleSubTopic.Trim())//用户上位机读取数据的间隔,是秒
                    {
                        Task.Run(() =>
                        {
                            ///获取当前的json字符串
                            string json = args.ApplicationMessage.ConvertPayloadToString();
                            //将json对象转换为c#对象
                            MQTTPassiveSubTopicObject subTopicObject = ScadaHexByteOperator.JsonToObject<MQTTPassiveSubTopicObject>(json);
                            
                            if (subTopicObject != null)
                            {
                                logFrm.AddLog("服务器循环周期更新 更新周期"+ subTopicObject.updatecycle);
                                //修改客户端数据查询周期
                                MqttUpdateCycle = subTopicObject.updatecycle;
                            }
                        });


                    }
                    else if (args.ApplicationMessage.Topic.Trim() == Config.MQTT.CommandSubTopic.Trim())//用户上位机下置数据
                    {
                        //解析数据
                    }
                
                };

                MqttClient.Connected += (sender, args) =>
                {
                  


                    logFrm.AddLog("连接MQTT服务器成功");
                    MqttClient.SubscribeAsync(Config.MQTT.CommandSubTopic, MqttQualityOfServiceLevel.AtMostOnce);//服务器端下置命令的主题

                    if (Config.MQTT.PublicType == "被动")//一个被动订阅的主题
                    {
                        Task.Run(() =>
                        {

                            MqttClient.SubscribeAsync(Config.MQTT.UpdateCycleSubTopic, MqttQualityOfServiceLevel.AtMostOnce);//服务器端设置了更新数据周期后通知到客户端
                            MqttClient.SubscribeAsync(Config.MQTT.PassiveSubTopic, MqttQualityOfServiceLevel.AtMostOnce);//被动订阅循环主题
                        });
                     
                    }
                   else  if (Config.MQTT.PublicType == "主动")//一个被动订阅的主题
                    {
                        Task.Run(() =>
                        {

                            while (true)
                            {
                                if(MqttClient.IsConnected)
                                {
                                    PublicRealDataJson(cleintID);
                                  
                                }
                                Thread.Sleep(MqttUpdateCycle * 1000);
                            }
                        });
                    }
                };

                MqttClient.Disconnected +=  async  (sender, args) =>
                {
                    Thread.Sleep(30000);//30秒后尝试重连
                    try
                    {
                        await MqttClient.ConnectAsync(options);
                        logFrm.AddLog("连接MQTT服务器成功");
                    }
                    catch (Exception emx)
                    {
                        logFrm.AddLog(emx.Message);
                    }

                };
                try
                {
                  await  MqttClient.ConnectAsync(options);
                    logFrm.AddLog("连接MQTT服务器成功");
                }
                catch(Exception emx)
                {
                    logFrm.AddLog(emx.Message);
                }

            }
            catch (Exception emx)
            {
                logFrm.AddLog(emx.Message);
                return;
            }

            

        }
        /// <summary>
        /// 发布实时数据
        /// </summary>
        private async static void PublicRealDataJson(string clientid)
        {
            logFrm.AddLog("客户端发布数据 "+clientid);
            if (clientid == null || clientid == "")
                return;
            if (Config.MQTT.ClientID.Trim().ToLower() != clientid.Trim().ToLower())
                return;
            try
            {
            
                if (MqttClient != null && MqttClient.IsConnected)
                {
                    //构造一个对象

                    PublicMqttJsonObject publicJsonObject = new PublicMqttJsonObject();
                    publicJsonObject.device = new PublicMqttJsonDevice() {
                         uid="1"

                    };
                    publicJsonObject.paras = new List<PublicMqttJsonPara>();
                    for (int i = 0; i < Config.Channels.Count; i++)
                    {
                        if (Config.Channels[i].BindingArress.Trim() != "")
                        {

                         
                        
                                foreach (ModbusPara para in Config.ModbusPara)
                                {   //获取当前缓存的数据
                                    List<ReceiveItem> channelDatas = ReceiveCachec.GetItems(MqttUpdateCycle, Config.Channels[i].Id.Trim(), para.Name);
                                    List<ReceiveItem> channelAlarmDatas = ReceiveAlarmCachec.GetItems(MqttUpdateCycle, Config.Channels[i].Id.Trim(), para.Name);
                                    List<ReceiveItem> channelAlarmStatusDatas = ReceiveAlarmStatusCachec.GetItems(MqttUpdateCycle, Config.Channels[i].Id.Trim(), para.Name);

                                    //当前缓存最新的数据
                                    ReceiveItem receiveItem = channelDatas.Find(x => int.Parse(x.Address) == int.Parse(Config.Channels[i].BindingArress.Trim()));
                                    if (receiveItem != null)
                                    {
                                        PublicMqttJsonPara paraData = new PublicMqttJsonPara()
                                        {
                                            name = receiveItem.Name +"_"+ int.Parse(Config.Channels[i].Id).ToString()+ "_" + int.Parse(receiveItem.Address).ToString(),
                                            data = new List<object>() { receiveItem.DateTime, receiveItem.Value, receiveItem.Unit },

                                        };
                                        publicJsonObject.paras.Add(paraData);
                                    }
                                    //报警值
                                    ReceiveItem receiveAlarmItem = channelAlarmDatas.Find(x => int.Parse(x.Address) == int.Parse(Config.Channels[i].BindingArress.Trim()));
                                    if (receiveAlarmItem != null)
                                    {
                                        PublicMqttJsonPara paraData = new PublicMqttJsonPara()
                                        {
                                            name = receiveAlarmItem.Name + "_" + int.Parse(Config.Channels[i].Id).ToString() + "_" + int.Parse(receiveAlarmItem.Address).ToString()+ "_alarm",
                                            data = new List<object>() { receiveAlarmItem.DateTime, receiveAlarmItem.Value, receiveAlarmItem.Unit }
                                        };
                                        publicJsonObject.paras.Add(paraData);
                                    };
                                //报警值
                                ReceiveItem receiveAlarmStatusItem = channelAlarmStatusDatas.Find(x => int.Parse(x.Address) == int.Parse(Config.Channels[i].BindingArress.Trim()));
                                if (receiveAlarmStatusItem != null)
                                {
                                    PublicMqttJsonPara paraData = new PublicMqttJsonPara()
                                    {
                                        name = receiveAlarmStatusItem.Name + "_" + int.Parse(Config.Channels[i].Id).ToString() + "_" + int.Parse(receiveAlarmItem.Address).ToString() + "_status",
                                        data = new List<object>() { receiveAlarmStatusItem.DateTime, receiveAlarmStatusItem.Value, receiveAlarmStatusItem.Unit }
                                    };
                                    publicJsonObject.paras.Add(paraData);
                                };
                            }

                       

                        }

                    }
                    string json = ScadaHexByteOperator.ObjectToJson(publicJsonObject);
        
                  //发布订阅的数据
                  await MqttClient.PublishAsync(new MqttApplicationMessage()
                    {   
                        Payload = Encoding.UTF8.GetBytes(json),
                        QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,
                        Retain = false,
                        Topic = Config.MQTT.DataPublicTopic

                    });
                }

            }
            catch (Exception emx)
            { logFrm.AddLog(emx.Message);
                return; }

        }
        #endregion
    }
}
