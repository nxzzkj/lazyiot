using MQTTnet;
using MQTTnet.Protocol;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void Form1_Load(object sender, EventArgs e)
        {

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
                listBox.Items.Add(s);
                if (listBox.Items.Count > 1000)
                {
                    listBox.Items.RemoveAt(0);
                }
                var visibleItems = listBox.ClientRectangle.Height / listBox.ItemHeight;

                listBox.TopIndex = listBox.Items.Count - visibleItems + 1;

            });
            //添加按键事件，按c时清空listbox
            listBox.KeyPress += (o, args) =>
            {
                if (args.KeyChar == 'c' || args.KeyChar == 'C')
                {
                    listBox.Items.Clear();
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

            if (!String.IsNullOrEmpty( TxbServer.Text))
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
                if (!context.Username.Equals("admin"))
                {
                    context.ReturnCode = MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
                    return;
                }
                if (!context.Password.Equals("123456"))
                {
                    context.ReturnCode = MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
                    return;
                }
                context.ReturnCode = MqttConnectReturnCode.ConnectionAccepted;

            };


            _mqttServer = new MqttFactory().CreateMqttServer();
            _mqttServer.ClientConnected += (sender, args) =>
            {
                listBox.BeginInvoke(_updateListBoxAction, $">Client Connected:ClientId:{args.ClientId},ProtocalVersion:");

                var s = _mqttServer.GetClientSessionsStatusAsync();
                label3.BeginInvoke(new Action(() => { label3.Text = $"连接总数：{s.Result.Count}"; }));
            };

            _mqttServer.ClientDisconnected += (sender, args) =>
            {
                listBox.BeginInvoke(_updateListBoxAction, $"<Client DisConnected:ClientId:{args.ClientId}");
                var s = _mqttServer.GetClientSessionsStatusAsync();
                label3.BeginInvoke(new Action(() => { label3.Text = $"连接总数：{s.Result.Count}"; }));
            };

            _mqttServer.ApplicationMessageReceived += (sender, args) =>
            {
                listBox.BeginInvoke(_updateListBoxAction,
                    $"ClientId:{args.ClientId} Topic:{args.ApplicationMessage.Topic} Payload:{Encoding.UTF8.GetString(args.ApplicationMessage.Payload)} QualityOfServiceLevel:{args.ApplicationMessage.QualityOfServiceLevel}");

            };

            _mqttServer.ClientSubscribedTopic += (sender, args) =>
            {
                listBox.BeginInvoke(_updateListBoxAction, $"@ClientSubscribedTopic ClientId:{args.ClientId} Topic:{args.TopicFilter.Topic} QualityOfServiceLevel:{args.TopicFilter.QualityOfServiceLevel}");
            };
            _mqttServer.ClientUnsubscribedTopic += (sender, args) =>
            {
                listBox.BeginInvoke(_updateListBoxAction, $"%ClientUnsubscribedTopic ClientId:{args.ClientId} Topic:{args.TopicFilter.Length}");
            };

            _mqttServer.Started += (sender, args) =>
            {
                listBox.BeginInvoke(_updateListBoxAction, "Mqtt Server Start...");
            };

            _mqttServer.Stopped += (sender, args) =>
            {
                listBox.BeginInvoke(_updateListBoxAction, "Mqtt Server Stop...");

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
                foreach (var clientSessionStatuse in _mqttServer.GetClientSessionsStatusAsync().Result)
                {
                    clientSessionStatuse.DisconnectAsync();
                }
                _mqttServer.StopAsync();
                _mqttServer = null;
            }
            BtnStart.Enabled = true;
            BtnStop.Enabled = false;
            TxbServer.Enabled = true;
            TxbPort.Enabled = true;
        }
    }
}
