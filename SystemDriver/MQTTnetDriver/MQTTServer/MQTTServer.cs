using Scada.Kernel;
using MQTTnet.Protocol;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Scada.Model;

namespace MQTTnet
{
    public class MQTTTimer
    {
        public System.Threading.Timer Timer = null;
        public string ClientID = "";
        public  bool IsStop
        {
            get;
            set;
        }
        public void Close()
        {
            ClientID = "";
            if (Timer != null)
            {


                Timer.Dispose();
                Timer = null;
            }
        }
        public void Stop()
        {
            IsStop = true;
        }
        public void Continue()
        {
            IsStop = false;
        }
        
    }
    public class MQTTServer : ScadaCommunicateKernel
    {
        public int HeartTime = 60;
        public string UserName = "";
        public string Password = "";
        public MqttQualityOfServiceLevel MessageQulity =  MqttQualityOfServiceLevel.AtMostOnce;
        public string WillFlag = "";
        public string MqttDataType = "";
        /// <summary>
        /// Mqtt服务器的IP
        /// </summary>
        public string ServerIP = "127.0.0.1";
        public bool EaableAnonymousAuthentication = false;
        public bool EaableClientIDAuthentication = false;
        List<MQTTTimer> MqttClientTimes = new List<MQTTTimer>();
        /// <summary>
        /// MQtt服务器的端口号
        /// </summary>
        public int ServerPort = 1883;
        private const string mGuid = "CEA4530C-05DB-42FE-A8DC-A04EEEC79AF0";
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
        private string mTitle = "MQTT物联网通讯";
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
        /// <summary>
        /// 初始化驱动
        /// </summary>
        /// <param name="server"></param>
        /// <param name="communication"></param>
        /// <param name="ioDevices"></param>
        /// <param name="driver"></param>
        /// <returns></returns>
        protected override bool InitCommunicateKernel(IO_SERVER server, IO_COMMUNICATION communication, List<IO_DEVICE> ioDevices, SCADA_DRIVER driver)
        {
            try
            {
                ParaPack communicatePack = new ParaPack(communication.IO_COMM_PARASTRING);
                if (communication.IO_COMM_PARASTRING != null && communication.IO_COMM_PARASTRING != "")
                {
                    this.ServerIP = communicatePack.GetValue("服务器IP");
                    this.ServerPort = int.Parse(communicatePack.GetValue("端口号"));
                    this.UserName = communicatePack.GetValue("用户名");
                    this.Password = communicatePack.GetValue("密码");
                    this.EaableAnonymousAuthentication = bool.Parse(communicatePack.GetValue("开启匿名验证"));
                    this.HeartTime = int.Parse(communicatePack.GetValue("心跳时间"));

                    string msgqulity = communicatePack.GetValue("消息质量");
                    switch (msgqulity)
                    {
                        case "QoS 0 最多分发一次":
                            MessageQulity = MqttQualityOfServiceLevel.AtMostOnce;
                            break;
                        case "QoS 1 至少分发一次":
                            MessageQulity = MqttQualityOfServiceLevel.AtLeastOnce;
                            break;
                        case "QoS 2 只分发一次":
                            MessageQulity = MqttQualityOfServiceLevel.ExactlyOnce;
                            break;
                    }
                    this.WillFlag = communicatePack.GetValue("遗愿标志");
                    this.MqttDataType = communicatePack.GetValue("数据格式");
                    this.EaableClientIDAuthentication = bool.Parse(communicatePack.GetValue("开启Mqtt客户端识别"));

                }

                if (IsCreateControl)
                {
                    CommunicationControl = new MQTTServerCtrl();
                    if (communication != null && communication.IO_COMM_PARASTRING != "")
                        CommunicationControl.SetUIParameter(communication.IO_COMM_PARASTRING);
                }
            }
            catch (Exception emx)
            {
                this.DeviceException(emx.Message);
                return false;
            }
            return true;

        }
        #region 发送命令部分

        protected override ScadaResult IOSendCommand(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, IO_PARA para, string value)
        {
            try
            {
                ParaPack deviceparaPack = new ParaPack(device.IO_DEVICE_PARASTRING);
                ParaPack paraPack = new ParaPack(para.IO_PARASTRING);
                ///向指定客户端的指定设备发送下置命令的数据
                Task.Run(async () =>
                {


                    if (deviceparaPack.GetValue("数据格式") == "江苏协昌环保股份有限公司")
                    {
                        string paraType = paraPack.GetValue("是否命令参数");
                        string cmdJson = "";
                        switch (paraType)
                        {
                            case "采集参数":
                                cmdJson = "{\"uid\":\"" + device.IO_DEVICE_ADDRESS + "\",\"paraname\":\"" + para.IO_NAME + "\",\"value\":\"" + value + "\",\"jsonname\":\"" + paraPack.GetValue("JSON名称") + "\",\"defaultvalue\":\"null\"}";
                                break;
                            case "升级命令":
                                cmdJson = "{\"uid\":\"" + device.IO_DEVICE_ADDRESS + "\",\"paraname\":\"" + para.IO_NAME + "\",\"value\":\"" + value + "\",\"jsonname\":\"oa\",\"defaultvalue\":\"null\"}";
                                break;
                            case "开关量扫描":
                                break;
                            case "复合采集扫描":
                                break;
                            case "脉宽扫描":
                                break;
                            case "电流扫描":
                                break;
                            case "重启命令":
                                break;
                        }

                        string topic = deviceparaPack.GetValue("命令主题").Trim();    // 将字符串转换为字符数组

                        await this._mqttServer.PublishAsync(new MqttApplicationMessage()
                        {
                            Topic = topic,
                            QualityOfServiceLevel = MessageQulity,
                            Retain = true,
                            Payload = Scada.Kernel.ScadaHexByteOperator.StringToAsciiByte(cmdJson)

                        });
                    }
                    else if (deviceparaPack.GetValue("数据格式") == "通用MQTT解析")
                    {

                        string cmdJson = "{\"uid\":\"" + device.IO_DEVICE_ADDRESS + "\",\"paraname\":\"" + para.IO_NAME + "\",\"value\":\"" + value + "\",\"jsonname\":\"" + paraPack.GetValue("IO标识") + "\",\"defaultvalue\":\"" + paraPack.GetValue("命令默认值") + "\"}";
                        string topic = deviceparaPack.GetValue("下置命令主题").Trim();    // 将字符串转换为字符数组
                        await this._mqttServer.PublishAsync(new MqttApplicationMessage()
                        {
                            Topic = topic,
                            QualityOfServiceLevel = MessageQulity,
                            Retain = true,
                            Payload = Scada.Kernel.ScadaHexByteOperator.StringToAsciiByte(cmdJson)

                        });
                    }
                });
                return new ScadaResult();
            }
            catch (Exception emx)
            {
                return new ScadaResult(false, emx.Message);
            }
        }
     

        #endregion
        #region 模拟器部分
        private int Internal = 120;
        private Timer simulatorTimer = null;
        /// <summary>
        /// 模拟器部分
        /// </summary>
        /// <param name="times"></param>
        /// <param name="IsSystem"></param>
        public override void Simulator(int times, bool IsSystem)
        {
            Internal = times;
        
        }
        public override void SimulatorClose()
        {
            simulatorTimer.Dispose();
            simulatorTimer = null;
        }
        private Random random = new Random();
        public override void SimulatorStart()
        {

            if (simulatorTimer == null)
            {
                simulatorTimer = new Timer(delegate
                {
                    Task.Run(() =>
                    {
                        for (int i = 0; i < this.IODevices.Count; i++)
                        {
                            try
                            {
                                ParaPack devicePack = new ParaPack(this.IODevices[i].IO_DEVICE_PARASTRING);
                                //构造Json模拟数据
                                MqttJsonObject mqttJsonObject = new MqttJsonObject();
                                mqttJsonObject.paras = new List<MqttJsonPara>();
                                mqttJsonObject.device = new MqttJsonDevice()
                                {
                                    hard_version = "1.0.0",
                                    run_time = "",
                                    soft_version = "1.0.0",
                                    status = "normal",
                                    uid = devicePack.GetValue("设备识别号")
                                };
                                for (int p = 0; p < this.IODevices[i].IOParas.Count; p++)
                                {
                                    if (this.IODevices[i].IOParas[p].IO_POINTTYPE == "模拟量" || this.IODevices[i].IOParas[p].IO_POINTTYPE == "开关量")
                                    {
                                        int simulatorValue = 0;
                                        if (this.IODevices[i].IOParas[p].IO_MINVALUE != this.IODevices[i].IOParas[p].IO_MAXVALUE)
                                        {
                                            int min = -100;
                                            if (this.IODevices[i].IOParas[p].IO_MINVALUE != null && this.IODevices[i].IOParas[p].IO_MINVALUE != "")
                                            {
                                                min = int.Parse(this.IODevices[i].IOParas[p].IO_MINVALUE);
                                            }
                                            int max = 100;
                                            if (this.IODevices[i].IOParas[p].IO_MAXVALUE != null && this.IODevices[i].IOParas[p].IO_MAXVALUE != "")
                                            {
                                                min = int.Parse(this.IODevices[i].IOParas[p].IO_MAXVALUE);
                                            }
                                            simulatorValue = random.Next(min, max);

                                        }
                                        else
                                        {
                                            simulatorValue = random.Next(-100, 100);

                                        }
                                        ParaPack paraPack = new ParaPack(this.IODevices[i].IOParas[p].IO_PARASTRING);

                                        mqttJsonObject.paras.Add(new MqttJsonPara()
                                        {
                                            name = paraPack.GetValue("JSON名称"),
                                            datatype = paraPack.GetValue("数据类型"),
                                            iotype = "analog",
                                            version = "1.0.0",
                                            data = new List<object>()
                                          {
                                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                           paraPack.GetValue("版子地址"),
                                           paraPack.GetValue("端口号"),
                                            simulatorValue

                                         }
                                        });

                                    }


                                }
                                //
                                string json = ScadaHexByteOperator.ObjectToJson(mqttJsonObject);

                                if (mqttJsonObject != null)
                                {
                                    byte[] datas = ScadaHexByteOperator.StringToUTF8Byte(json);
                                    this.ReceiveData(this.IOServer, this.IOCommunication, this.IODevices[i], datas, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                                }
                                this.SimulatorAppendLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 时间初始化一条设备模拟数据!");
                            }
                            catch(Exception emx)
                            {
                                this.SimulatorAppendLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 接收数据错误! "+ emx.Message);
                            }
                        }
                    });

                }, null, 1000, Internal * 1000);
            }


        }
        #endregion
        #region 服务器管理部分
        IMqttServer _mqttServer = null;
     

        protected override void Start()
        {
            if (null != _mqttServer)
            {
                return;
            }
            ///相关参数不能为空
            if (this.IOServer == null || this.IOCommunication == null)
                return;

            var optionBuilder =
                new MqttServerOptionsBuilder().WithConnectionBacklog(1000).WithDefaultEndpointPort(ServerPort);

            if (!String.IsNullOrEmpty(ServerIP))
            {
                optionBuilder.WithDefaultEndpointBoundIPAddress(IPAddress.Parse(ServerIP));
            }

            var options = optionBuilder.Build();

     
            //连接验证
            (options as MqttServerOptions).ConnectionValidator += context =>
            {
                string clientId = "";
                Task.Run(() =>
                {
                    try
                    {
                        ParaPack paraPack = new ParaPack(this.IOCommunication.IO_COMM_PARASTRING);

                        if (context.ClientId.Length < 2)
                        {
                            context.ReturnCode = MqttConnectReturnCode.ConnectionRefusedIdentifierRejected;
                            return;
                        }
                        if (EaableAnonymousAuthentication)
                        {
                            if (!context.Username.Equals(this.UserName))
                            {
                                context.ReturnCode = MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
                                return;
                            }
                            if (!context.Password.Equals(this.Password))
                            {
                                context.ReturnCode = MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
                                return;
                            }
                        }
                        bool isValidCleint = false;

                        for (int i = 0; i < IODevices.Count; i++)
                        {

                            ParaPack deviceparaPack = new ParaPack(IODevices[i].IO_DEVICE_PARASTRING);
                            clientId = deviceparaPack.GetValue("MQTT连接ID号").Trim();    // 将字符串转换为字符数组
                            if (clientId.Trim() == context.ClientId.Trim())
                            {
                                isValidCleint = true;
                                IODevices[i].Tag = clientId.Trim();//标记对应的客户端ID号
                                break;
                            }

                        }
                        if (isValidCleint)
                            context.ReturnCode = MqttConnectReturnCode.ConnectionAccepted;
                        else
                            context.ReturnCode = MqttConnectReturnCode.ConnectionRefusedIdentifierRejected;
                    }
                    catch
                    {
                        context.ReturnCode = MqttConnectReturnCode.ConnectionRefusedIdentifierRejected;
                    }
                    if(string.IsNullOrEmpty(clientId))
                    {
                        context.ReturnCode = MqttConnectReturnCode.ConnectionRefusedIdentifierRejected;
                    }
                });
            };


            _mqttServer = new MqttFactory().CreateMqttServer();
        

            //开始连接
            _mqttServer.ClientConnected += (sender, args) =>
            {

                if (args.ClientId == null || args.ClientId == "")
                    return;

               
                IO_DEVICE device = this.IODevices.Find(x => x.Tag.ToString().Trim() == args.ClientId.Trim());
                if (device == null)
                {
                    for (int i = 0; i < IODevices.Count; i++)
                    {

                        ParaPack deviceparaPack = new ParaPack(IODevices[i].IO_DEVICE_PARASTRING);
                        string clientId = deviceparaPack.GetValue("MQTT连接ID号").Trim();    // 将字符串转换为字符数组
                        if (clientId.Trim() == args.ClientId.Trim())
                        {

                            IODevices[i].Tag = clientId.Trim();//标记对应的客户端ID号
                            device = IODevices[i];
                            break;
                        }

                    }
                }
                if (device == null)
                    return;

           

                ParaPack commPack = new ParaPack(this.IOCommunication.IO_COMM_PARASTRING);
                ParaPack devicePack = new ParaPack(device.IO_DEVICE_PARASTRING);
                if (commPack.GetValue("数据格式") == "江苏协昌环保股份有限公司")
                {
                    #region 江苏协昌环保解析
                    {

                        //客户端连接上后发布订阅数据
                        List<TopicFilter> topicFilters = new List<TopicFilter>();
                        device.IO_DEVICE_STATUS = 1;
                        this.DeviceStatus(this.IOServer, IOCommunication, device, null, "1");

                        string clientId = devicePack.GetValue("MQTT连接ID号").Trim();    // 将字符串转换为字符数组
                        device.Tag = clientId;
                        if (clientId.Trim() == args.ClientId.Trim())
                        {
                            TopicFilter topicFilter = new TopicFilter(devicePack.GetValue("订阅主题").Trim(), MessageQulity);
                            topicFilters.Add(topicFilter);

                            try
                            {
                                Task.Run(async () =>
                                {

                                    await _mqttServer.SubscribeAsync(args.ClientId.Trim(), topicFilters);
                                });

                            }
                            catch (Exception)
                            {
                                this.DeviceException("ERROR=MQTTNet_20006,发布订阅主题失败 ");
                            }

                        }
                        else
                        {
                            this.DeviceException("ERROR=MQTTNet_20006,MQTT ID与设备配置ID不匹配 ");
                        }


                    }
                    #endregion
                }
                else if (commPack.GetValue("数据格式") == "通用MQTT解析")
                {
                    #region 通用MQTT解析
                    {

                        //客户端连接上后发布订阅数据
                        List<TopicFilter> topicFilters = new List<TopicFilter>();
                        device.IO_DEVICE_STATUS = 1;
                        this.DeviceStatus(this.IOServer, IOCommunication, device, null, "1");

                        string clientId = devicePack.GetValue("MQTT连接ID号").Trim();    // 将字符串转换为字符数组
                        device.Tag = clientId;
                        if (clientId.Trim() == args.ClientId.Trim())
                        {

                            TopicFilter topicFilter = new TopicFilter(devicePack.GetValue("数据订阅主题").Trim(), MessageQulity);
                            topicFilters.Add(topicFilter);
                            try
                            {
                                Task.Run(async () =>
                                {

                                    await _mqttServer.SubscribeAsync(args.ClientId.Trim(), topicFilters);
                                });

                            }
                            catch (Exception)
                            {
                                this.DeviceException("ERROR=MQTTNet_20006,发布订阅主题失败 ");
                            }

                        }
                        else
                        {
                            this.DeviceException("ERROR=MQTTNet_20006,MQTT ID与设备配置ID不匹配 ");
                        }
                        //定时向客户端发布一个读取数据的订阅
                        if (commPack.GetValue("接收方式") == "主动")
                        {
                            MQTTTimer cleintMqtt = new MQTTTimer()
                            {
                                ClientID = args.ClientId
                            };
                            MqttClientTimes.Add(cleintMqtt);

                            cleintMqtt.Timer = new Timer(delegate
                            {
                                if (!cleintMqtt.IsStop)
                                {
                                    try
                                    {
                                        _mqttServer.PublishAsync(
                                          new MqttApplicationMessage()
                                          {
                                              QualityOfServiceLevel = MessageQulity,
                                              Retain = false,
                                              Topic = devicePack.GetValue("主动请求主题").Trim(),
                                              Payload = Encoding.UTF8.GetBytes("{\"uid\":\"" + devicePack.GetValue("设备ID编码").Trim() + "\",\"updatecycle\":\"" + device.IO_DEVICE_UPDATECYCLE + "\",\"topic\":\"" + devicePack.GetValue("数据订阅主题").Trim() + "\"}")

                                          }

                                          );
                                            ///服务端向客户端发送一个服务器端循环查询数据的周期

                                            _mqttServer.PublishAsync(
                                          new MqttApplicationMessage()
                                          {
                                              QualityOfServiceLevel = MessageQulity,
                                              Retain = false,
                                              Topic = devicePack.GetValue("循环周期主题").Trim(),
                                              Payload = Encoding.UTF8.GetBytes("{\"uid\":\"" + devicePack.GetValue("设备ID编码").Trim() + "\",\"updatecycle\":\"" + device.IO_DEVICE_UPDATECYCLE + "\",\"topic\":\"" + devicePack.GetValue("数据订阅主题").Trim() + "\"}")

                                          }

                                          );



                                    }
                                    catch (Exception)
                                    {
                                        this.DeviceException("ERROR=MQTTNet_20006,发布订阅主题失败 ");
                                    }
                                }

                            }, args, 1000, device.IO_DEVICE_UPDATECYCLE * 1000);

                        }
                    }
                    #endregion
                }

            };
            ///断开连接
            _mqttServer.ClientDisconnected += (sender, args) =>
            {
                Task.Run(() =>
                {
                   
                    if (args.WasCleanDisconnect)
                    {
                        IO_DEVICE device = this.IODevices.Find(x => x.Tag.ToString().Trim() == args.ClientId.Trim());
                        if (device != null)
                        {
                            device.IO_DEVICE_STATUS = 0;
                            this.DeviceStatus(this.IOServer, IOCommunication, device, null, "0");


                        }

                    }

                });
                MQTTTimer cleintTimer = MqttClientTimes.Find(x => x.ClientID == args.ClientId);
                if(cleintTimer!=null)
                {
                    cleintTimer.Close();
                    MqttClientTimes.Remove(cleintTimer);
                }
               
            };
            ///接收到订阅主题的数据数据

            _mqttServer.ApplicationMessageReceived += (sender, args) =>
            {
                if(args.ClientId==null||args.ClientId.Trim()=="")
                return;

                if (args.ApplicationMessage.Payload == null || args.ApplicationMessage.Payload.Length <= 0)
                {
                    this.DeviceException("接收的数据为空");

                    return;
                }
                ParaPack commPack = new ParaPack(this.IOCommunication.IO_COMM_PARASTRING);

                try
                {
                    Task.Run(() =>
                    {
             
                        string cleintId = args.ClientId.Trim();
                        //将接收到的数据发送到实际的对应的解析数据库中
              
                        List<IO_DEVICE> selects = this.IODevices.FindAll(x => x.Tag.ToString().Trim() == args.ClientId.Trim());
                        if (selects.Count <= 0)
                            return;

                        string strs = ScadaHexByteOperator.UTF8ByteToString(args.ApplicationMessage.Payload);

                        IO_DEVICE device = null;
                        for (int i = 0; i < selects.Count; i++)
                        {
                            ParaPack selePack = new ParaPack(selects[i].IO_DEVICE_PARASTRING);
                            if (commPack.GetValue("数据格式") == "江苏协昌环保股份有限公司")
                            {
                                #region
                                MqttJsonObject mqttJsonObject = ScadaHexByteOperator.JsonToObject<MqttJsonObject>(strs);
                                if (mqttJsonObject == null || mqttJsonObject.paras == null || mqttJsonObject.paras.Count <= 0)
                                {

                                    this.DeviceException("接收数据对象转换失败了,没有数据" + strs.Count());
                                    this.DeviceException(strs);
                                    continue;

                                }
                                string selectUid = selePack.GetValue("设备识别号");
                                if (selectUid.Trim() == mqttJsonObject.device.uid.Trim())
                                {
                                    device = selects[i];
                                    break;
                                }
                                #endregion
                            }
                            else if (commPack.GetValue("数据格式") == "通用MQTT解析")
                            {
                                #region
                                CommonMqttJsonObject mqttJsonObject = ScadaHexByteOperator.JsonToObject<CommonMqttJsonObject>(strs);
                                if (mqttJsonObject == null || mqttJsonObject.paras == null || mqttJsonObject.paras.Count <= 0)
                                {

                                    this.DeviceException("接收数据对象转换失败了,没有数据" + strs.Count());
                                    this.DeviceException(strs);
                                    continue;

                                }

                                string selectUid = selePack.GetValue("设备ID编码");
                                if (selectUid.Trim() == mqttJsonObject.device.uid.Trim())
                                {
                                    device = selects[i];
                                    break;
                                }
                                #endregion
                            }

                        }
                        if (device == null)
                        {
                            return;
                        }
                        device.IO_DEVICE_STATUS = 1;
                        ParaPack paraPack = new ParaPack(device.IO_DEVICE_PARASTRING);
                        if (commPack.GetValue("数据格式") == "江苏协昌环保股份有限公司")
                        {
                            #region
                            string deviceUid = paraPack.GetValue("设备识别号");
                            if (!string.IsNullOrEmpty(device.IO_DEVICE_PARASTRING) && args.ApplicationMessage.Topic.Trim() == paraPack.GetValue("订阅主题").Trim())
                            {
                                MqttJsonObject mqttJsonObject = ScadaHexByteOperator.JsonToObject<MqttJsonObject>(strs);
                                this.ReceiveData(this.IOServer, IOCommunication, device, args.ApplicationMessage.Payload, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), mqttJsonObject);
                            }

                            #endregion
                        }
                        else if (commPack.GetValue("数据格式") == "通用MQTT解析")
                        {
                            #region
                            string deviceUid = paraPack.GetValue("设备ID编码");
                            if (!string.IsNullOrEmpty(device.IO_DEVICE_PARASTRING) && args.ApplicationMessage.Topic.Trim() == paraPack.GetValue("数据订阅主题").Trim())
                            {
                                CommonMqttJsonObject mqttJsonObject = ScadaHexByteOperator.JsonToObject<CommonMqttJsonObject>(strs);
                                this.ReceiveData(this.IOServer, IOCommunication, device, args.ApplicationMessage.Payload, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), mqttJsonObject);
                            }
                            #endregion
                        }

                    });
                }
                catch
                {
                    return;
                }

            
            };
            ///订阅主题

            _mqttServer.ClientSubscribedTopic += (sender, args) =>
            {
              

            };
            ///取消订阅主题
            _mqttServer.ClientUnsubscribedTopic += (sender, args) =>
            {

            };

            _mqttServer.Started += (sender, args) =>
            {
                this.IOCommunication.IO_COMM_STATUS = 1;
            };

            _mqttServer.Stopped += (sender, args) =>
            {
                this.IOCommunication.IO_COMM_STATUS = 0;

            };
            _mqttServer.StartAsync(options);
         
            ParaPack commpack = new ParaPack(this.IOCommunication.IO_COMM_PARASTRING);
      
           
            this.CommunctionStartChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "启动服务");

        }

        protected override void Close()
        {

            try
            {
                for(int i=0;i< MqttClientTimes.Count;i++)
                {
                    MqttClientTimes[i].Close();
                }
                MqttClientTimes.Clear();
                _mqttServer.StopAsync();
                _mqttServer = null;
                this.CommunctionCloseChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "关闭网络服务");
            }
            catch (Exception emx)
            {
                this.DeviceException("ERROR=MQTTNet_10006," + emx.Message);
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "关闭网络服务失败");
            }
        }
        protected override void Continue()
        {
            
            try
            {
                for (int i = 0; i < MqttClientTimes.Count; i++)
                {
                    MqttClientTimes[i].Continue();
                }
                this.CommunctionContinueChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "继续网络服务");
            }
            catch (Exception emx)
            {
                this.DeviceException("ERROR=MQTTNet_10003," + emx.Message);
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "继续网络服务失败");
            }
        }
        protected override void Pause()
        {
            try
            {
                for (int i = 0; i < MqttClientTimes.Count; i++)
                {
                    MqttClientTimes[i].Stop();
                }
                this.CommunctionPauseChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "暂停网络服务");
            }
            catch (Exception emx)
            {
                this.DeviceException("ERROR=MQTTNet_10005," + emx.Message);
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "暂停网络服务失败");
            }
        }
        protected override void Stop()
        {
            try
            {
                for (int i = 0; i < MqttClientTimes.Count; i++)
                {
                    MqttClientTimes[i].Stop();
                }
                MqttClientTimes.Clear();
                _mqttServer.StopAsync();
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "停止网络服务");


            }
            catch (Exception emx)
            {
                this.DeviceException("ERROR=MQTTNet_10003," + emx.Message);
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "停止网络服务失败");
            }


        }
        private MQTTServerCtrl mQTTServerCtrl = null;

        public override CommunicationKernelControl CommunicationControl
        {
            set
            {
                if(mQTTServerCtrl==null)
                mQTTServerCtrl = (MQTTServerCtrl)value;
                mQTTServerCtrl.SetUIParameter(this.IOCommunication.IO_COMM_PARASTRING);
            }
            get { return mQTTServerCtrl; }
        }

        #endregion

  

    }
}
