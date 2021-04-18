using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GasMonitor
{
    public class Admin
    {
        public string UserName { set; get; }
        public string Password { set; get; }
    }
    public class ModbusPara
    {
        public int StartRegister { set; get; }
        public string Name { set; get; }
        public int RegisterNum { set; get; }
        public int Enable { set; get; }
        public string ModbusCode { set; get; }
    }
    public class ChannelAlarm
    {
        public string ChanelID { set; get; }
        public List<ParaAlarm> ParaAlarms { set; get; }

    }
    public class ParaAlarm
    {
        public string Name { set; get; }
   
        public string Enable { set; get; }
        public string Low { set; get; }
        public string High { set; get; }
    }

    public class SerialPortConfig
    {
        public SerialPortConfig()
        {
            Port = "";
            CheckBit = "None";
            BaudRate = "9600";
            StopBit = "1";
            DataBits = "8";
            WriteTimeout = "5000";
            ReadTimeout = "5000";
            OffsetInterval = "10";
            RTSEnable = "0";
            RSTSendPreKeeyTime = "15";
            RTSSendAfterKeeyTime = "15";
            PackMaxSize = "64";
            ContinueCollect = "1";
            CollectFaultsNumber = "3";
            CollectFaultsInternal = "";
            ModbusType = "RTU";
            UpdateCycle = 10;
        }
        public int UpdateCycle = 10;
        public string Port
        { set; get; }
        public string CheckBit
        { set; get; }
        public string BaudRate
        { set; get; }
        public string StopBit
        { set; get; }
        public string DataBits
        { set; get; }

        //写超时时间
        public string WriteTimeout
        { set; get; }
        //读超时时间
        public string ReadTimeout
        { set; get; }

        //偏移间隔
        public string OffsetInterval
        { set; get; }
        //是否开启RTS
        public string RTSEnable
        { set; get; }
        //发送前RTS保持时间RTS
        public string RSTSendPreKeeyTime
        { set; get; }

        //发送后RTS保持时间
        public string RTSSendAfterKeeyTime
        { set; get; }
        //包最大长度
        public string PackMaxSize
        { set; get; }
        //是否连续采集
        public string ContinueCollect
        { set; get; }
        //重试次数
        public string CollectFaultsNumber
        { set; get; }
        //重试间隔
        public string CollectFaultsInternal
        { set; get; }
        public string ModbusType { set; get; }

    }
    public class MQTTConfig
    {
        public string ClientID
        { set; get; }
        public string ServerIP
        { set; get; }
        public string Port
        { set; get; }
        public string Account
        { set; get; }
        public string Password
        { set; get; }
        public string DataPublicTopic
        { set; get; }
        public string CommandSubTopic
        { set; get; }
        public string UpdateCycleSubTopic
        { set; get; }
        public string PassiveSubTopic
        { set; get; }
        public string UpdateCycle
        { set; get; }
        public string PublicType
        { set; get; }

    }
    /// <summary>
    /// 相关配置文件类
    /// </summary>
    public class GasMonitorConfig
    {
        public GasMonitorConfig()
        {
            ReadConfig();
        }
        public SerialPortConfig SerialPort = new SerialPortConfig();
        public MQTTConfig MQTT = new MQTTConfig();
        public List<ChannelElement> Channels = new List<ChannelElement>();

        public List<ChannelAlarm> ChannelAlarms = new List<ChannelAlarm>();
        public List<ModbusPara> ModbusPara = new List<ModbusPara>();
        public Admin AdminUser = new Admin();
        public void ReadConfig()
        {
            AdminUser = new Admin();
            AdminUser.UserName = "admin";
            AdminUser.Password = "gas2020";
            ModbusPara = new List<ModbusPara>();
            SerialPort = new SerialPortConfig();
            MQTT = new MQTTConfig();
            Channels = new List<ChannelElement>();
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath + "/config.xml");
            XmlNode list = doc.SelectSingleNode("/Config");
            foreach (XmlNode item in list.ChildNodes)
            {
                if (item.Name == "SerialPort")
                {

                    SerialPort.BaudRate = item["BaudRate"].InnerText.Trim();
                    SerialPort.CheckBit = item["CheckBit"].InnerText.Trim();
                    SerialPort.DataBits = item["DataBits"].InnerText.Trim();
                    SerialPort.Port = item["Port"].InnerText.Trim();
                    SerialPort.StopBit = item["StopBit"].InnerText.Trim();
                    SerialPort.CollectFaultsInternal = item["CollectFaultsInternal"].InnerText.Trim();
                    SerialPort.CollectFaultsNumber = item["CollectFaultsNumber"].InnerText.Trim();
                    SerialPort.ContinueCollect = item["ContinueCollect"].InnerText.Trim();
                    SerialPort.OffsetInterval = item["OffsetInterval"].InnerText.Trim();
                    SerialPort.PackMaxSize = item["PackMaxSize"].InnerText.Trim();
                    SerialPort.ReadTimeout = item["ReadTimeout"].InnerText.Trim();
                    SerialPort.RSTSendPreKeeyTime = item["RSTSendPreKeeyTime"].InnerText.Trim();
                    SerialPort.RTSEnable = item["RTSEnable"].InnerText.Trim();
                    SerialPort.RTSSendAfterKeeyTime = item["RTSSendAfterKeeyTime"].InnerText.Trim();
                    SerialPort.WriteTimeout = item["WriteTimeout"].InnerText.Trim();
                    SerialPort.ModbusType = item["ModbusType"].InnerText.Trim();




                }
                else if (item.Name == "MQTT")
                {

                    MQTT.Account = item["Account"].InnerText.Trim();
                    MQTT.ClientID = item["ClientID"].InnerText.Trim();
                    MQTT.CommandSubTopic = item["CommandSubTopic"].InnerText.Trim();
                    MQTT.DataPublicTopic = item["DataPublicTopic"].InnerText.Trim();
                    MQTT.PassiveSubTopic = item["PassiveSubTopic"].InnerText.Trim();
                    MQTT.Password = item["Password"].InnerText.Trim();
                    MQTT.Port = item["Port"].InnerText.Trim();
                    MQTT.PublicType = item["PublicType"].InnerText.Trim();
                    MQTT.ServerIP = item["ServerIP"].InnerText.Trim();
                    MQTT.UpdateCycle = item["UpdateCycle"].InnerText.Trim();
                    MQTT.UpdateCycleSubTopic = item["UpdateCycleSubTopic"].InnerText.Trim();


                }
                else if (item.Name == "Admin")
                {

                    AdminUser.UserName = item["UserName"].InnerText.Trim();
                    AdminUser.Password = item["Password"].InnerText.Trim();
                

                }
                if (item.Name == "Channels")
                {

                    foreach (XmlNode subNode in item.ChildNodes)
                    {
                        if (subNode.Name == "Channel")
                        {
                            ChannelElement channelElement = new ChannelElement();
                            channelElement.BindingArress = subNode["DeviceAddress"].InnerText.Trim();
                            channelElement.Id = subNode["ChannelID"].InnerText.Trim();
                            channelElement.Name = subNode["ChannelName"].InnerText.Trim();
                            channelElement.Text = subNode["ChannelText"].InnerText.Trim();
                            Channels.Add(channelElement);

                        }

                    }
                }
                if (item.Name == "Modbus")
                {

                    foreach (XmlNode subNode in item.ChildNodes)
                    {
                        if (subNode.Name == "ModbusParaItem")
                        {
                            ModbusPara paraElement = new ModbusPara();
                            paraElement.Name = subNode.Attributes["Name"].Value.Trim();
                            paraElement.StartRegister = string.IsNullOrEmpty(subNode.Attributes["StartRegister"].Value.Trim())?0:int.Parse(subNode.Attributes["StartRegister"].Value.Trim());
                   
                            paraElement.RegisterNum = string.IsNullOrEmpty(subNode.Attributes["RegisterNum"].Value.Trim()) ? 0 : int.Parse(subNode.Attributes["RegisterNum"].Value.Trim());
                            paraElement.Enable = string.IsNullOrEmpty(subNode.Attributes["Enable"].Value.Trim()) ? 0 : int.Parse(subNode.Attributes["Enable"].Value.Trim());
                            paraElement.ModbusCode = subNode.Attributes["ModbusCode"].Value.Trim();
                            
                            ModbusPara.Add(paraElement);

                        }

                    }
                }
                if (item.Name == "ChannelAlarms")
                {
                    XmlNodeList alarmList = item.SelectNodes("Alarm");
                    foreach (XmlNode alarmNode in alarmList)
                    {
                        ChannelAlarm channelAlarm = new ChannelAlarm();
                        channelAlarm.ParaAlarms = new List<ParaAlarm>();
                        channelAlarm.ChanelID = alarmNode.Attributes["ChanelID"].Value.Trim();
                        foreach (XmlNode paraNode in alarmNode.ChildNodes)
                        {
                            channelAlarm.ParaAlarms.Add(new ParaAlarm {

                                Enable = paraNode.Attributes["Enable"].Value.Trim(),
                                Name = paraNode.Attributes["Name"].Value.Trim(),
                                High = paraNode["AlarmHigh"].InnerText.Trim(),
                                Low = paraNode["AlarmLow"].InnerText.Trim()
                            });
                        }
                        this.ChannelAlarms.Add(channelAlarm);

                    }
                }

            }


        }
        public bool WriterConfig()
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                doc.Load(Application.StartupPath + "/config.xml");
                XmlNode list = doc.SelectSingleNode("/Config");
                foreach (XmlNode item in list.ChildNodes)
                {
                    if (item.Name == "SerialPort")
                    {
                        item["BaudRate"].InnerText = SerialPort.BaudRate;
                        item["CheckBit"].InnerText = SerialPort.CheckBit;
                        item["DataBits"].InnerText = SerialPort.DataBits;
                        item["Port"].InnerText = SerialPort.Port;
                        item["StopBit"].InnerText = SerialPort.StopBit;
                        item["CollectFaultsInternal"].InnerText=  SerialPort.CollectFaultsInternal;
                        item["CollectFaultsNumber"].InnerText=  SerialPort.CollectFaultsNumber;
                        item["ContinueCollect"].InnerText=SerialPort.ContinueCollect;
                        item["OffsetInterval"].InnerText= SerialPort.OffsetInterval;
                        item["PackMaxSize"].InnerText= SerialPort.PackMaxSize ;
                        item["ReadTimeout"].InnerText=SerialPort.ReadTimeout;
                        item["RSTSendPreKeeyTime"].InnerText= SerialPort.RSTSendPreKeeyTime;
                        item["RTSEnable"].InnerText=  SerialPort.RTSEnable ;
                        item["RTSSendAfterKeeyTime"].InnerText= SerialPort.RTSSendAfterKeeyTime;
                        item["WriteTimeout"].InnerText = SerialPort.WriteTimeout ;
                        item["ModbusType"].InnerText = SerialPort.ModbusType;
                        

                    }
                    else if (item.Name == "MQTT")
                    {
                        item["Account"].InnerText = MQTT.Account;
                        item["ClientID"].InnerText = MQTT.ClientID;
                        item["CommandSubTopic"].InnerText = MQTT.CommandSubTopic;
                        item["DataPublicTopic"].InnerText = MQTT.DataPublicTopic;
                        item["PassiveSubTopic"].InnerText = MQTT.PassiveSubTopic;
                        item["Password"].InnerText = MQTT.Password;
                        item["Port"].InnerText = MQTT.Port;
                        item["PublicType"].InnerText = MQTT.PublicType;
                        item["ServerIP"].InnerText = MQTT.ServerIP;
                        item["UpdateCycle"].InnerText = MQTT.UpdateCycle;
                        item["UpdateCycleSubTopic"].InnerText = MQTT.UpdateCycleSubTopic;

                    }
                    if (item.Name == "Channels")
                    {
                        for (int i = 0; i < item.ChildNodes.Count; i++)
                        {
                            if (item.ChildNodes[i].Name == "Channel")
                            {
                                ChannelElement channelElement = Channels[i];
                                item.ChildNodes[i]["DeviceAddress"].InnerText = channelElement.BindingArress;
                                item.ChildNodes[i]["ChannelID"].InnerText = channelElement.Id;
                                item.ChildNodes[i]["ChannelName"].InnerText = channelElement.Name;
                                item.ChildNodes[i]["ChannelText"].InnerText = channelElement.Text;

                            }

                        }

                    }
                    if (item.Name == "ChannelAlarms")
                    {
                        XmlNodeList alarmList = item.SelectNodes("Alarm");
                        for (int i = 0; i < alarmList.Count; i++)
                        {
                            XmlNode alarmNode = alarmList[i];
                            ChannelAlarm channelAlarm = this.ChannelAlarms[i];
                            alarmNode.Attributes["ChanelID"].Value = channelAlarm.ChanelID;
                            for (int j = 0; j < alarmNode.ChildNodes.Count; j++)
                            {
                                XmlNode paraNode = alarmList[i].ChildNodes[j];
                                paraNode.Attributes["Enable"].Value = channelAlarm.ParaAlarms[j].Enable;
                                paraNode.Attributes["Name"].Value = channelAlarm.ParaAlarms[j].Name;
                                paraNode["AlarmHigh"].InnerText = channelAlarm.ParaAlarms[j].High;
                                paraNode["AlarmLow"].InnerText = channelAlarm.ParaAlarms[j].Low;
                              
                            }
                        }
                       
                    }
                }
            
                doc.Save(Application.StartupPath + "/config.xml");
            
                return true;
            }
            catch
            {
                return false;
            }
        }



    }
}
