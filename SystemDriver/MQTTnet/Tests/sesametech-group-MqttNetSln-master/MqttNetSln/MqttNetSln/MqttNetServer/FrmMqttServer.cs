using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

using MQTTnet;
using MQTTnet.Server;
using MQTTnet.Protocol;
using ServiceStack;
using ServiceStack.Text.Common;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MqttNetServer
{
    public partial class FrmMqttServer : Form
    {

        private IMqttServer _mqttServer = null;

        private Action<string> _updateListBoxAction;
        public FrmMqttServer()
        {
            InitializeComponent();
        }
        string cleintId = "";
        private void FrmMqttServer_Load(object sender, EventArgs e)
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

            _updateListBoxAction = new Action<string>((s) =>
            {
                listBox1.Items.Add(s);
                if (listBox1.Items.Count > 1000)
                {
                    listBox1.Items.RemoveAt(0);
                }
                var visibleItems = listBox1.ClientRectangle.Height/listBox1.ItemHeight;

                listBox1.TopIndex = listBox1.Items.Count - visibleItems + 1;
            });
            

            listBox1.KeyPress += (o, args) =>
            {
                if (args.KeyChar == 'c' || args.KeyChar=='C')
                {
                    listBox1.Items.Clear();
                }
            };

            BtnStart.Enabled = true;
            BtnStop.Enabled = false;
            TxbServer.Enabled = true;
            TxbPort.Enabled = true;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            foreach (var value in Enum.GetValues(typeof(MqttQualityOfServiceLevel)))
            {
           
                CmbSubMqttQuality.Items.Add((int)value);
            }
            CmbSubMqttQuality.SelectedItem = 0;
            MqttServer();
            BtnStart.Enabled = false;
            BtnStop.Enabled = true;
            TxbServer.Enabled = false;
            TxbPort.Enabled = false;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (null != _mqttServer )
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

        private async void MqttServer()
        {
            if (null != _mqttServer)
            {
                return;
            }

            var optionBuilder =
                new MqttServerOptionsBuilder().WithConnectionBacklog(1000).WithDefaultEndpointPort(Convert.ToInt32(TxbPort.Text));

            if (!TxbServer.Text.IsNullOrEmpty())
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
                if (!context.Password.Equals("public"))
                {
                    context.ReturnCode = MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
                    return;
                }
                context.ReturnCode = MqttConnectReturnCode.ConnectionAccepted;
                cleintId = context.ClientId;
            };
        
            _mqttServer = new MqttFactory().CreateMqttServer();
            _mqttServer.ClientConnected += (sender, args) =>
            {
                listBox1.BeginInvoke(_updateListBoxAction, $">Client Connected:ClientId:{args.ClientId},ProtocalVersion:");

                var s = _mqttServer.GetClientSessionsStatusAsync();
                label3.BeginInvoke(new Action(() => { label3.Text = $"连接总数：{s.Result.Count}"; }));
            };

            _mqttServer.ClientDisconnected += (sender, args) =>
            {
                listBox1.BeginInvoke(_updateListBoxAction, $"<Client DisConnected:ClientId:{args.ClientId}");
                var s = _mqttServer.GetClientSessionsStatusAsync();
                label3.BeginInvoke(new Action(() => { label3.Text = $"连接总数：{s.Result.Count}"; }));
            };

            _mqttServer.ApplicationMessageReceived += (sender, args) =>
            {
                listBox1.BeginInvoke(_updateListBoxAction,
                    $"ClientId:{args.ClientId} Topic:{args.ApplicationMessage.Topic} Payload:{Encoding.UTF8.GetString(args.ApplicationMessage.Payload)} QualityOfServiceLevel:{args.ApplicationMessage.QualityOfServiceLevel}");

            };

            _mqttServer.ClientSubscribedTopic += (sender, args) =>
            {
                listBox1.BeginInvoke(_updateListBoxAction, $"@ClientSubscribedTopic ClientId:{args.ClientId} Topic:{args.TopicFilter.Topic} QualityOfServiceLevel:{args.TopicFilter.QualityOfServiceLevel}");
            };
            _mqttServer.ClientUnsubscribedTopic += (sender, args) =>
            {
                listBox1.BeginInvoke(_updateListBoxAction, $"%ClientUnsubscribedTopic ClientId:{args.ClientId} Topic:{args.TopicFilter.Length}");
            };

            _mqttServer.Started += (sender, args) =>
            {
                listBox1.BeginInvoke(_updateListBoxAction, "Mqtt Server Start...");
            };

            _mqttServer.Stopped += (sender, args) =>
            {
                listBox1.BeginInvoke(_updateListBoxAction, "Mqtt Server Stop...");
                
            };

            await _mqttServer.StartAsync(options);
        }

        private void BtnSubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Factory.StartNew(async () =>
                {
                    await _mqttServer.SubscribeAsync(cleintId,
                        new List<TopicFilter>
                        {
                            new TopicFilter(
                                txbSubscribe.Text,
                                (MqttQualityOfServiceLevel)
                                    Enum.Parse(typeof (MqttQualityOfServiceLevel),"0"))
                        });
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Factory.StartNew(async () =>
                {
                    var msg = new MqttApplicationMessage()
                    {
                        Topic = txbSubscribe.Text,
                        Payload = Encoding.UTF8.GetBytes("系统发布" + DateTime.Now.ToString()),
                        QualityOfServiceLevel =
                            (MqttQualityOfServiceLevel)
                                Enum.Parse(typeof(MqttQualityOfServiceLevel),"0"),
                        Retain = true
                    };
                    if (null != _mqttServer)
                    {
                        await _mqttServer.PublishAsync(msg);
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
