using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MQTTClientSimulator
{
    public partial class SimulatorClient : Form
    {
        public SimulatorClient()
        {
            InitializeComponent();
            this.Load += SimulatorClient_Load;
        }

        private void SimulatorClient_Load(object sender, EventArgs e)
        {
            MqttJson = new MqttJson();
            MqttClients = new List<IMqttClient>();
            MqttOptions = new List<MqttClientOptions>();
            this.dataGridViewPara.AutoGenerateColumns = false;
            this.dataGridViewDevice.AutoGenerateColumns = false;
        }

        public MqttJson MqttJson = new MqttJson();
        public List<IMqttClient> MqttClients { set; get; }
        private MqttQualityOfServiceLevel MqttQualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce;

        List<MqttClientOptions> MqttOptions { set; get; }
        public void CreateMQTTClient()
        {
            for (int i = 0; i < MqttClients.Count; i++)
            {
                MqttClients[i].DisconnectAsync();
            }
            MqttClients.Clear();
            MqttOptions.Clear();
            for (int i = 0; i < MqttJson.Devices.Count; i++)
            {


                try
                {
                    string cleintID = MqttJson.Devices[i].device.ClientID;

                    MqttClientOptions option = new MqttClientOptions() { ClientId = cleintID };
                    option.ChannelOptions = new MqttClientTcpOptions()
                    {
                        Server = this.tbClientIP.Text.Trim(),
                        Port = Convert.ToInt32(this.tbPort.Text.Trim())
                    };
                    option.Credentials = new MqttClientCredentials()
                    {
                        Username = this.tbUser.Text.Trim(),
                        Password = this.tbPassword.Text.Trim()
                    };

                    option.CleanSession = true;
                    option.KeepAlivePeriod = TimeSpan.FromSeconds(float.Parse(tbPeried.Text.Trim()));
                    option.KeepAliveSendInterval = TimeSpan.FromSeconds(20000);
                    MqttOptions.Add(option);

                    IMqttClient MqttClient = new MqttFactory().CreateMqttClient();
                    ///接收到数据

                    MqttClient.ApplicationMessageReceived += (sender, args) =>
                    {
                        if (args.ClientId == null || args.ClientId == "")
                            return;
                        if (args.ApplicationMessage.Payload == null || args.ApplicationMessage.Payload.Length <= 0)
                            return;
                        if (args.ApplicationMessage.Topic.Trim() == this.tbDataPassiveTopic.Text.Trim())
                        {
                            IMqttClient mqttClient = MqttClients.Find(x => x.Options.ClientId == args.ClientId);
                            Task.Run(() =>
                            {
                                ///获取当前的json字符串
                                string json = args.ApplicationMessage.ConvertPayloadToString();
                                //将json对象转换为c#对象
                                MQTTPassiveSubTopicObject subTopicObject = ScadaHexByteOperator.JsonToObject<MQTTPassiveSubTopicObject>(json);
                                AddText("服务器请求发布数据");
                                if (subTopicObject != null)
                                {
                                    PublicRealDataJson(mqttClient);//发布一次数据
                                }
                            });

                        }
                        else if (args.ApplicationMessage.Topic.Trim() == this.tbUpdateCycleTopic.Text.Trim())//用户上位机读取数据的间隔,是秒
                        {
                            Task.Run(() =>
                            {
                                ///获取当前的json字符串
                                string json = args.ApplicationMessage.ConvertPayloadToString();
                                //将json对象转换为c#对象
                                MQTTPassiveSubTopicObject subTopicObject = ScadaHexByteOperator.JsonToObject<MQTTPassiveSubTopicObject>(json);

                                if (subTopicObject != null)
                                {
                                    CommonMqttJsonObject device = MqttJson.Devices.Find(x => x.ClientID == args.ClientId);
                                    if (device != null)
                                        AddText("服务器循环周期更新 更新周期" + subTopicObject.updatecycle);
                                    //修改客户端数据查询周期
                                    device.device.UpdateCycle = subTopicObject.updatecycle;
                                }
                            });


                        }
                        else if (args.ApplicationMessage.Topic.Trim() == this.tbCommandTopic.Text.Trim())//用户上位机下置数据
                        {
                            //解析数据
                            AddText("服务器端下置一条数据");
                        }

                    };

                    MqttClient.Connected += (sender, args) =>
                    {
                        IMqttClient mqttClient =(IMqttClient) sender;
                        AddText("客户端与服务器连接正常");
                        MqttClient.SubscribeAsync(tbCommandTopic.Text, MqttQualityOfServiceLevel);//服务器端下置命令的主题

                        if (cbAuto.Checked)//一个被动订阅的主题
                        {
                            Task.Run(() =>
                            {

                                MqttClient.SubscribeAsync(tbUpdateCycleTopic.Text, MqttQualityOfServiceLevel);//服务器端设置了更新数据周期后通知到客户端
                                MqttClient.SubscribeAsync(tbDataPassiveTopic.Text, MqttQualityOfServiceLevel);//被动订阅循环主题
                            });

                        }
                        else//一个被动订阅的主题
                        {
                            Task.Run(() =>
                            {
                          
                                while (true && mqttClient != null)
                                {
                                    if (mqttClient.IsConnected)
                                    {
                                        PublicRealDataJson(mqttClient);

                                    }
                                    CommonMqttJsonObject device = MqttJson.Devices.Find(x => x.ClientID == mqttClient.Options.ClientId);
                                    if (device != null)
                                        Thread.Sleep(device.device.UpdateCycle);
                                }
                            });
                        }

                    };

                    MqttClient.Disconnected += async (sender, args) =>
                    {
                        AddText("客户端与服务器断开链接" + (args.Exception!=null?args.Exception.Message:""));

                    };
                    MqttClients.Add(MqttClient);


                }
                catch (Exception emx)
                {
                    return;
                }
            }
        }
        /// <summary>
        /// 发布实时数据
        /// </summary>
        private void PublicRealDataJson(IMqttClient MqttClient)
        {
            string clientid = MqttClient.Options.ClientId;
            AddText("客户端发布数据 " + clientid);
            if (clientid == null || clientid == "")
                return;
            try
            {
                if (MqttClient != null && MqttClient.IsConnected)
                {
                    //构造一个对象
                    Random random = new Random();
                    for (int i = 0; i < MqttJson.Devices.Count; i++)
                    {
                        for (int p = 0; p < MqttJson.Devices[i].paras.Count; p++)
                        {
                            float v = random.Next(MqttJson.Devices[i].paras[p].SimulatorMin, MqttJson.Devices[i].paras[p].SimulatorMax);
                            string dateString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            MqttJson.Devices[i].paras[p].data.Clear();
                            MqttJson.Devices[i].paras[p].data.Add(dateString);//日期
                            MqttJson.Devices[i].paras[p].data.Add(v.ToString());//值
                            MqttJson.Devices[i].paras[p].data.Add("无");//单位

                        }

                        string json = ScadaHexByteOperator.ObjectToJson(MqttJson.Devices[i]);
                        //发布订阅的数据
                        MqttClient.PublishAsync(new MqttApplicationMessage()
                        {
                            Payload = Encoding.UTF8.GetBytes(json),
                            QualityOfServiceLevel = MqttQualityOfServiceLevel,
                            Retain = false,
                            Topic = tbDataTopic.Text.Trim()

                        });
                        AddText(MqttJson.Devices[i].Name + " 发布了一条数据集合");

                    }



                }

            }
            catch (Exception emx)
            {
                AddText(emx.Message);
                return;
            }

        }
        private void AddText(string msg)
        {


            if (this.IsHandleCreated && listBoxLog.InvokeRequired)
            {
                listBoxLog.BeginInvoke(new EventHandler(delegate
                {

                    this.listBoxLog.Items.Insert(0, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + msg + "\r\n");
                    if (this.listBoxLog.Items.Count >= 500)
                    {
                        this.listBoxLog.Items.RemoveAt(this.listBoxLog.Items.Count - 1);


                    }
                }));
            }
        }

        private void btAddDevice_Click(object sender, EventArgs e)
        {
            AddDevice form = new AddDevice();
            if(form.ShowDialog()==DialogResult.OK)
            {
                if (MqttJson.Devices == null)
                    MqttJson.Devices = new List<CommonMqttJsonObject>();
                MqttJson.Devices.Add(form.Device);
                dataGridViewDevice.DataSource = null;
                dataGridViewDevice.DataSource = MqttJson.Devices;

            }

        }

        private void btEditDevice_Click(object sender, EventArgs e)
        {
            if (dataGridViewDevice.SelectedRows.Count <= 0)
                return;
            AddDevice form = new AddDevice();
            form.Device = (CommonMqttJsonObject)dataGridViewDevice.SelectedRows[0].DataBoundItem;
            if (form.ShowDialog() == DialogResult.OK)
            {
                dataGridViewDevice.DataSource = null;
                dataGridViewDevice.DataSource = MqttJson.Devices;

            }
        }

        private void btDeleteDevice_Click(object sender, EventArgs e)
        {
            if (dataGridViewDevice.SelectedRows.Count <= 0)
                return;
            MqttJson.Devices.Remove((CommonMqttJsonObject)dataGridViewDevice.SelectedRows[0].DataBoundItem);
            dataGridViewDevice.DataSource = null;
            dataGridViewDevice.DataSource = MqttJson.Devices;
        }

        

        private void btSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dig = new SaveFileDialog();
            dig.Filter = "IO点表(*.lio)|*.lio";
            if (dig.ShowDialog(this) == DialogResult.OK)
            {
           
                MqttJson.ServerIP = this.tbClientIP.Text;
                MqttJson.Password = this.tbPassword.Text;
                MqttJson.HeartPeried = this.tbPeried.Text;
                MqttJson.Port = this.tbPort.Text;
                MqttJson.User = this.tbUser.Text;
                MqttJson.UpdateCycleTopic = this.tbUpdateCycleTopic.Text;
                MqttJson.DataTopic = this.tbDataTopic.Text;
                MqttJson.DataPassiveTopic = this.tbDataPassiveTopic.Text;
                MqttJson.CommandTopic = this.tbCommandTopic.Text;
          
                IFormatter formatter = new BinaryFormatter();
                FileStream fs = null;
                try
                {
                    fs = new FileStream(dig.FileName, FileMode.Create);
                    formatter.Serialize(fs, MqttJson);


                    MessageBox.Show(this, "保存点表成功");
                }
                catch (Exception emx)
                {
                    MessageBox.Show(emx.Message);
               
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                }

            
            }
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Filter = "IO点表(*.lio)|*.lio";
            if (dig.ShowDialog(this) == DialogResult.OK)
            {
 
                FileStream fs = null;
                try
                {
                    MqttJson tempMqttJson = null;
                    fs = new FileStream(dig.FileName, FileMode.Open);
                    fs.Seek(0, SeekOrigin.Current);
                    IFormatter formatter = new BinaryFormatter();
                    while (fs.Position < fs.Length)
                    {
                        tempMqttJson  = (MqttJson)formatter.Deserialize(fs);
                        if (tempMqttJson != null)
                            break;

                    }
                    if (tempMqttJson != null)
                    {
                        MqttJson = tempMqttJson;
                        this.dataGridViewDevice.DataSource = MqttJson.Devices;
                
                        this.tbClientIP.Text = MqttJson.ServerIP;
                        this.tbPassword.Text = MqttJson.Password;
                        this.tbPeried.Text = MqttJson.HeartPeried;
                        this.tbPort.Text = MqttJson.Port;
                        this.tbUser.Text = MqttJson.User;
                        this.tbUpdateCycleTopic.Text = MqttJson.UpdateCycleTopic;
                        this.tbDataTopic.Text = MqttJson.DataTopic;
                        this.tbDataPassiveTopic.Text = MqttJson.DataPassiveTopic;
                        this.tbCommandTopic.Text = MqttJson.CommandTopic;
                        MessageBox.Show(this, "打开文件成功!");
                       
                    }
                    else
                    {
                        MessageBox.Show(this, "打开文件失败");
                    }

                }
                catch (Exception emx)
                {
                    MessageBox.Show(emx.Message + " " + emx.InnerException);
          
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                }
           
 

            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                this.CreateMQTTClient();
                for (int i = 0; i < MqttClients.Count; i++)
                {
                    MqttClients[i].ConnectAsync(MqttOptions[i]);
                }
             

            }
            catch (Exception emx)
            {

            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            for(int i=0;i< MqttClients.Count;i++)
            {
                MqttClients[i].DisconnectAsync();
            }
            
        }

        private void dataGridViewDevice_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewDevice.SelectedRows.Count <= 0)
                return;
         
            dataGridViewPara.DataSource = null;
            dataGridViewPara.DataSource = ((CommonMqttJsonObject)dataGridViewDevice.SelectedRows[0].DataBoundItem).paras;
        }

   
    }
}
