using MQTTnet;
using MQTTnet.Protocol;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MQTTServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public string clientId = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = GetMAC();
            var ips = Dns.GetHostAddressesAsync(Dns.GetHostName());

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

            //在load方法中定义
            //超过1000条数据时，自动删除第一个
            //出现滚动条时，滚动条自动向下移动
            _updateListBoxAction = new Action<string>((s) =>
            {
                richTextBox1.AppendText(s+"\r\n");
 

            });
            //添加按键事件，按c时清空listbox
            richTextBox1.KeyPress += (o, args) =>
            {
                if (args.KeyChar == 'c' || args.KeyChar == 'C')
                {
                    richTextBox1.Text = "";
                }
            };
            BtnStart.Enabled = true;
            BtnStop.Enabled = false;
            TxbServer.Enabled = true;
            TxbPort.Enabled = true;
        }

        private Action<string> _updateListBoxAction;
        IMqttServer _mqttServer = null;

        private async void MqttServer()
        {
            if (null != _mqttServer)
            {
                return;
            }

            var optionBuilder =
                new MqttServerOptionsBuilder().WithConnectionBacklog(1000).WithDefaultEndpointPort(Convert.ToInt32(TxbPort.Text));

            if (!String.IsNullOrEmpty(TxbServer.Text))
            {
                optionBuilder.WithDefaultEndpointBoundIPAddress(IPAddress.Parse(TxbServer.Text));
            }

            var options = optionBuilder.Build();


            (options as MqttServerOptions).ConnectionValidator += context =>
            {

                if (context.ClientId.Length < 1)
                {
                    context.ReturnCode = MqttConnectReturnCode.ConnectionRefusedIdentifierRejected;
                    return;
                }
               
                context.ReturnCode = MqttConnectReturnCode.ConnectionAccepted;
                clientId = context.ClientId;
            };


            _mqttServer = new MqttFactory().CreateMqttServer();
            _mqttServer.ClientConnected += (sender, args) =>
            {
                richTextBox1.BeginInvoke(_updateListBoxAction, $">Client Connected:ClientId:{args.ClientId},ProtocalVersion:");

                var s = _mqttServer.GetClientSessionsStatus();
                label3.BeginInvoke(new Action(() => { label3.Text = $"连接总数：{s.Count}"; }));

                TopicFilter topicFilter = new TopicFilter(this.tbTopic.Text + args.ClientId, MqttQualityOfServiceLevel.AtLeastOnce);
                _mqttServer.SubscribeAsync(args.ClientId, new List<TopicFilter>() { topicFilter });
            };

            _mqttServer.ClientDisconnected += (sender, args) =>
            {
                TopicFilter topicFilter = new TopicFilter(this.tbTopic.Text, MqttQualityOfServiceLevel.AtLeastOnce);
                _mqttServer.SubscribeAsync(clientId, new List<TopicFilter>() { topicFilter });
                richTextBox1.BeginInvoke(_updateListBoxAction, $"<Client DisConnected:ClientId:{args.ClientId}");
                var s = _mqttServer.GetClientSessionsStatus();
                label3.BeginInvoke(new Action(() => { label3.Text = $"连接总数：{s.Count}"; }));
            };

            _mqttServer.ApplicationMessageReceived += (sender, args) =>
            {
                richTextBox1.BeginInvoke(_updateListBoxAction,
                    $"ClientId:{args.ClientId} Topic:{args.ApplicationMessage.Topic} Payload:{Encoding.UTF8.GetString(args.ApplicationMessage.Payload)} QualityOfServiceLevel:{args.ApplicationMessage.QualityOfServiceLevel}");

            };

            _mqttServer.ClientSubscribedTopic += (sender, args) =>
            {
                richTextBox1.BeginInvoke(_updateListBoxAction, $"@ClientSubscribedTopic ClientId:{args.ClientId} Topic:{args.TopicFilter.Topic} QualityOfServiceLevel:{args.TopicFilter.QualityOfServiceLevel}");
            };
            _mqttServer.ClientUnsubscribedTopic += (sender, args) =>
            {
                richTextBox1.BeginInvoke(_updateListBoxAction, $"%ClientUnsubscribedTopic ClientId:{args.ClientId} Topic:{args.TopicFilter.Length}");
            };

            _mqttServer.Started += (sender, args) =>
            {
                richTextBox1.BeginInvoke(_updateListBoxAction, "Mqtt Server Start...");
            };

            _mqttServer.Stopped += (sender, args) =>
            {
                richTextBox1.BeginInvoke(_updateListBoxAction, "Mqtt Server Stop...");

            };

            await _mqttServer.StartAsync(options);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            MqttServer();
            BtnStart.Enabled = false;
            BtnStop.Enabled = true;
            TxbServer.Enabled = false;
            TxbPort.Enabled = false;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (null != _mqttServer)
            {
            
                _mqttServer.StopAsync();
                _mqttServer = null;
            }
            BtnStart.Enabled = true;
            BtnStop.Enabled = false;
            TxbServer.Enabled = true;
            TxbPort.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TopicFilter topicFilter = new TopicFilter(this.tbTopic.Text, MqttQualityOfServiceLevel.AtLeastOnce);
            _mqttServer.SubscribeAsync(clientId, new List<TopicFilter>() { topicFilter });
        }

        private void btConvert_Click(object sender, EventArgs e)
        {
            

            MqttJsonObject obj = ScadaHexByteOperator.JsonToObject<MqttJsonObject>(this.richTextBox1.Text);
        }

        public   string GetMAC()
        {
            string mac = "";
            if (mac == "")
            {
                //主板

                ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_baseboard");
                foreach (ManagementObject mo in mos.Get())
                {
                    mac = mo["SerialNumber"].ToString();

                }

                return mac;
            }

            return mac.Replace(":", "");
        }
    }
}
