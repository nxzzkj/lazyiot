using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DriveInterface;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Diagnostics;

using MQTTnet.Protocol;

namespace MqttNetClient
{
    public partial class FrmMqttClient2 : Form
    {
        System.Threading.Timer timer = null;
        IMqttClient _mqttClient;

        private Action<string> _updaterichBoxAction;

        public FrmMqttClient2()
        {
            InitializeComponent();



        }

        private void FrmMqttClient_Load(object sender, EventArgs e)
        {
            var ips = Dns.GetHostAddressesAsync(Dns.GetHostName());
            TxbServer.Text = ips.Result[1].ToString();
            foreach (var ip in ips.Result)
            {
                switch (ip.AddressFamily)
                {
                    case AddressFamily.InterNetwork:
                        TxbServer.Text = ip.ToString();
                        break;
                    case AddressFamily.InterNetworkV6:
                        break;
                }
            }
            _updaterichBoxAction = new Action<string>((s) =>
            {
                this.richTextBox1.AppendText(s);

            });



        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            MqttClient();
        }

        private async void BtnDisConnect_Click(object sender, EventArgs e)
        {

         await   _mqttClient.DisconnectAsync();
            _mqttClient.Dispose();
            _mqttClient = null;


        }



        Random random = new Random();
        //设备识别号:1000210021,版本号:1.0.0,软件版本:1.0.0,硬件版本:1.0.0,MQTT连接ID号:MQTT1001,订阅主题:Topic/MQTT1001/Read,命令主题:Topic/MQTT1001/Send,时间主题:Topic/MQTT1001/Cycle
        private async void MqttClient()
        {
             
                try
            {
                string cleintID = "xc_cloud_master_0036001b3438511035303434";
         
                var options = new MqttClientOptions() { ClientId = cleintID };
                options.ChannelOptions = new MqttClientTcpOptions()
                {
                    Server = TxbServer.Text,
                    Port = Convert.ToInt32(TxbPort.Text)
                };
                options.Credentials = new MqttClientCredentials()
                {
                    Username = "admin",
                    Password = "public"
                };

                options.CleanSession = true;
                options.KeepAlivePeriod = TimeSpan.FromSeconds(100.5);
                options.KeepAliveSendInterval = TimeSpan.FromSeconds(20000);

                if (null != _mqttClient)
                {
                    await _mqttClient.DisconnectAsync();
                    _mqttClient = null;
                }
                _mqttClient = new MqttFactory().CreateMqttClient();

                _mqttClient.ApplicationMessageReceived += (sender, args) =>
                {
                    AddRichText("接收到服务器数据\r\n");
                };

                _mqttClient.Connected += (sender, args) =>
                {
                    AddRichText("连接服务器成功\r\n");


                };

                _mqttClient.Disconnected += (sender, args) =>
                {
                    AddRichText("与服务器连接失败\r\n");
                    timer.Dispose();
                    timer = null;
                };

                await _mqttClient.ConnectAsync(options);


            }
            catch (Exception emx)
            {
                MessageBox.Show(emx.Message);
                return;
            }

            timer = new System.Threading.Timer(delegate
            {

                CreateJson();
            }, null, 1000, 5000);

        }
        public void AddRichText(string value)
        {
            richTextBox1.BeginInvoke(_updaterichBoxAction, value);



        }

        private async void CreateJson()
        {
            try
            {
 
                string deviceUid = "0036001b3438511035303434";
    
                MqttJsonObject mqttJsonObject = new MqttJsonObject();
                mqttJsonObject.paras = new List<MqttJsonPara>();
                mqttJsonObject.device = new MqttJsonDevice()
                {
                    hard_version = "1.0.0",
                    run_time = "",
                    soft_version = "1.0.0",
                    status = "normal",
                    uid = deviceUid
                };
                for (int j = 0; j < 3; j++)
                {


                    ///写入电流
                    for (int i = 1; i <= 8; i++)
                    {
                        mqttJsonObject.paras.Add(new MqttJsonPara()
                        {
                            name = "current_0_" + i,
                            datatype = "current",
                            iotype = "analog",
                            version = "1.0.0",
                            data = new List<object>()
                                          {
                                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                          0,
                                           10,
                                            random.Next(-100,100)
                                         }
                        });
                    }

                    ///写入脉宽
                    for (int i = 1; i <= 8; i++)
                    {
                        mqttJsonObject.paras.Add(new MqttJsonPara()
                        {
                            name = "pulse_width_0_" + i,
                            datatype = "pulse_width",
                            iotype = "analog",
                            version = "1.0.0",
                            data = new List<object>()
                                          {
                                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                          0,
                                           10,
                                            random.Next(-100,100)
                                         }
                        });
                    }
                    ///写入开关量
                    for (int i = 1; i <= 8; i++)
                    {
                        mqttJsonObject.paras.Add(new MqttJsonPara()
                        {
                            name = "switch_0_" + i,
                            datatype = "switch",
                            iotype = "switch",
                            version = "1.0.0",
                            data = new List<object>()
                                          {
                                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                          0,
                                           10,
                                            random.Next(0,1)
                                         }
                        });
                    }
                    ///写入符合采集
                    for (int i = 1; i <= 8; i++)
                    {
                        mqttJsonObject.paras.Add(new MqttJsonPara()
                        {
                            name = "relevance_0_" + i,
                            datatype = "relevance",
                            iotype = "switch",
                            version = "1.0.0",
                            data = new List<object>()
                                          {
                                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                          0,
                                           10,
                                            random.Next(-100,100),
                                             random.Next(0,100),
                                              random.Next(0,1)
                                         }
                        });
                    }
                }
                string json = ScadaHexByteOperator.ObjectToJson(mqttJsonObject);
                if (_mqttClient != null && _mqttClient.IsConnected)
                {
                    await _mqttClient.PublishAsync(new MqttApplicationMessage()
                    {
                        Payload = Encoding.UTF8.GetBytes(json),
                        QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,
                        Retain = true,
                        Topic = "/xc_cloud_master/cs/0036001b3438511035303434"

                    });
                }

            }
            catch 
            { return; }


            AddRichText("发布时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "发布一组数据成功\r\n");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CreateJson();
        }
    }
}
