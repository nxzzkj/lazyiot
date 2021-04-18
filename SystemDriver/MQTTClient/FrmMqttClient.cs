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
    public partial class FrmMqttClient : Form
    {
        System.Threading.Timer timer = null;
        private List<IMqttClient> _mqttClients;

        private Action<string> _updaterichBoxAction;

        public FrmMqttClient()
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
         
            int num = int.Parse(this.tbClientNum.Text);
            for (int i = 0; i < num; i++)
            {
                IMqttClient _mqttClient = _mqttClients[i];
                if (null != _mqttClient && _mqttClient.IsConnected)
                {
                    await _mqttClient.DisconnectAsync();
                    _mqttClient.Dispose();
                    _mqttClient = null;
                }
                else
                {
                    _mqttClient.Dispose();
                    _mqttClient = null;
                }
            }
            _mqttClients.Clear();
            _mqttClients = new List<IMqttClient>();


        }



        Random random = new Random();
        //设备识别号:1000210021,版本号:1.0.0,软件版本:1.0.0,硬件版本:1.0.0,MQTT连接ID号:MQTT1001,订阅主题:Topic/MQTT1001/Read,命令主题:Topic/MQTT1001/Send,时间主题:Topic/MQTT1001/Cycle
        private async void MqttClient()
        {
            _mqttClients = new List<IMqttClient>();
            int num = int.Parse(this.tbClientNum.Text);
            for (int i = 0; i < num; i++)
            {
                try
                {
                    string cleintNum = "MQTT" + Convert.ToString((int.Parse(tbClientID.Text) + i));
                    IMqttClient _mqttClient = null;
                    var options = new MqttClientOptions() { ClientId = cleintNum };
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
                    _mqttClients.Add(_mqttClient);
                    await _mqttClient.ConnectAsync(options);

                 
                }
                catch (Exception)
                {
                    continue;
                }

            }
            timer = new System.Threading.Timer(delegate
            {

                CreateJson();
            }, null, 1000, 30000);

        }
        public void AddRichText(string value)
        {
            richTextBox1.BeginInvoke(_updaterichBoxAction, value);



        }

        private async void CreateJson()
        {
            for (int i = 0; i < _mqttClients.Count; i++)
            {
                try
                {
                    string cleintNum = "MQTT" + Convert.ToString((int.Parse(tbClientID.Text) + i));
                    string deviceNum = Convert.ToString((long.Parse(tbDeviceID.Text) + i));
                    IMqttClient _mqttClient = _mqttClients[i];
                    MqttJsonObject mqttJsonObject = new MqttJsonObject();
                    mqttJsonObject.paras = new List<MqttJsonPara>();
                    mqttJsonObject.device = new MqttJsonDevice()
                    {
                        hard_version = "1.0.0",
                        run_time = "",
                        soft_version = "1.0.0",
                        status = "normal",
                        uid = deviceNum
                    };
                    mqttJsonObject.paras.Add(new MqttJsonPara()
                    {
                        name = "current1",
                        datatype = "current",
                        iotype = "analog",
                        version = "1.0.0",
                        data = new List<object>()
                                          {
                                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                          0,
                                           10,
                                            random.Next(-10-100,100),
                                        random.Next(-10-100,100)
                                         }
                    });
                    mqttJsonObject.paras.Add(new MqttJsonPara()
                    {
                        name = "current2",
                        datatype = "current",
                        iotype = "analog",
                        version = "1.0.0",
                        data = new List<object>()
                                          {
                                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                          0,
                                           11,
                                            random.Next(-100,100),
                                        random.Next(-100,100)
                                         }
                    });
                    mqttJsonObject.paras.Add(new MqttJsonPara()
                    {
                        name = "current3",
                        datatype = "current",
                        iotype = "analog",
                        version = "1.0.0",
                        data = new List<object>()
                                          {
                                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                          0,
                                           12,
                                            random.Next(-100,100),
                                        random.Next(-100,100)
                                         }
                    });
                    mqttJsonObject.paras.Add(new MqttJsonPara()
                    {
                        name = "relevance1",
                        datatype = "current",
                        iotype = "analog",
                        version = "1.0.0",
                        data = new List<object>()
                                          {
                                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                          0,
                                           10,
                                            random.Next(-100,100),
                                        random.Next(-100,100)
                                         }
                    });
                    mqttJsonObject.paras.Add(new MqttJsonPara()
                    {
                        name = "pulse_width",
                        datatype = "current",
                        iotype = "analog",
                        version = "1.0.0",
                        data = new List<object>()
                                          {
                                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                          0,
                                           11,
                                            random.Next(-100,100),
                                        random.Next(-100,100)
                                         }
                    });
                    mqttJsonObject.paras.Add(new MqttJsonPara()
                    {
                        name = "pulse_width2",
                        datatype = "current",
                        iotype = "analog",
                        version = "1.0.0",
                        data = new List<object>()
                                          {
                                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                          1,
                                           11,
                                            random.Next(-100,100),
                                        random.Next(-100,100)
                                         }
                    });
                    mqttJsonObject.paras.Add(new MqttJsonPara()
                    {
                        name = "switch1",
                        datatype = "current",
                        iotype = "analog",
                        version = "1.0.0",
                        data = new List<object>()
                                          {
                                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                          0,
                                           10,
                                            random.Next(0,1),
                                        random.Next(0,1)
                                         }
                    });
                    mqttJsonObject.paras.Add(new MqttJsonPara()
                    {
                        name = "switch2",
                        datatype = "current",
                        iotype = "analog",
                        version = "1.0.0",
                        data = new List<object>()
                                          {
                                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                          0,
                                           11,
                                            random.Next(0,1),
                                        random.Next(0,1)
                                         }
                    });
                    string json = ScadaHexByteOperator.ObjectToJson(mqttJsonObject);
                    if(_mqttClient!=null&& _mqttClient.IsConnected)
                    {
                        await _mqttClient.PublishAsync(new MqttApplicationMessage()
                        {
                            Payload = Encoding.UTF8.GetBytes(json),
                            QualityOfServiceLevel = MqttQualityOfServiceLevel.AtLeastOnce,
                            Retain = true,
                            Topic = "Topic/" + cleintNum + "/Read/"+ deviceNum

                        });
                    }
                   
                }
                catch 
                { continue; }
                Thread.Sleep(500);
            }


            AddRichText("发布时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "发布一组数据成功\r\n");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CreateJson();
        }
    }
}
