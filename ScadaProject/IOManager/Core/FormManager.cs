
using Scada.IOStructure;
using Scada.Business;
using IOManager.Controls;
using IOManager.Dialogs;

using Scada.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;
using System.Diagnostics;
using System.Net;
using Scada.Model;
using Scada.AsyncNetTcp;
using Scada.Kernel;

namespace IOManager.Core
{
    /// <summary>
    /// 主窗体任务
    /// </summary>
    public abstract class FormManager
    {
  
        public static void InitTcpClient(string remoteIp)
        {
            if (TcpClient == null || !TcpClient.IsClientConnected || TcpClient.IsClosed)
            {
                if (TcpClient != null)
                {
                    TcpClient.Dispose();
                }

                TcpClient = new IOManagerTCPClient();
                TcpClient.OnConnectedServer += TcpClient_OnConnectedServer;
                TcpClient.OnDisConnectedServer += TcpClient_OnDisConnectedServer;
                TcpClient.OnExceptionHanped += TcpClient_OnExceptionHanped;
                TcpClient.OnPublishProject += TcpClient_OnPublishProject;
                TcpClient.OnPublishProjectFault += TcpClient_OnPublishProjectFault;
                TcpClient.OnPublishProjectSuccess += TcpClient_OnPublishProjectSuccess;
                TcpClient.OnTCPClientLoged += TcpClient_OnTCPClientLoged;
                TcpClient.OnPublishing += TcpClient_OnPublishing;
                TcpClient.Start(remoteIp);
            }

        }
        #region TCPClient 通讯事件
        private static void TcpClient_OnTCPClientLoged(string msg)
        {
            AddLog(msg);
        }

        private static void TcpClient_OnConnectedServer(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg)
        {
            AddLog("与服务器断开连接成功!");
        }

        private static void TcpClient_OnDisConnectedServer(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg)
        {
            AddLog(msg + "，正在尝试连接服务器....");
        }




        private static void TcpClient_OnExceptionHanped(Exception ex)
        {

            AddLog(ex.Message);
        }
        #endregion
        #region 登录管理系统，要与服务器进行连接
        /// <summary>
        /// 登录管理系统，要与服务器进行连接
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        public static bool LoginManager(string user, string password)
        {
            STATION_TCP_INFO loginInfo = new STATION_TCP_INFO();
            loginInfo.USER = user;
            loginInfo.PASSWROD = password;
            loginInfo.IO_SERVER_ID = "";
            loginInfo.IO_SERVER_IP = "";
            loginInfo.RESULT = "false";
            loginInfo.FUNCTION = "IOManager";
            Scada.AsyncNetTcp.TcpData tcpData = new Scada.AsyncNetTcp.TcpData();
            byte[] loginbytes = tcpData.StringToTcpByte(loginInfo.GetCommandString(), Scada.AsyncNetTcp.ScadaTcpOperator.采集站登录);
            //发送登录命令
            TcpClient.Send(new ArraySegment<byte>(loginbytes));
            return true;
        }
        #endregion
        #region 属性定义
        //当前加载的工程
        public static string Project = "";
        //当前绑定的窗体

        private static System.Windows.Forms.ToolStripProgressBar progressBar = null;
        private static System.Windows.Forms.ToolStripStatusLabel progressStatus = null;
        private static IOMainForm mForm = null;
        public static string ServerID = ComputerInfo.GetInstall().ServerID.ToString();//每个采集站ID和主板信息绑定，确保唯一
        public static IOConfig Config = new IOConfig();
        public static IOManagerTCPClient TcpClient = null;
        public static IOMainForm MainForm
        {
            set
            {
                mForm = value;
                mediator = value.mediator;
                progressBar = mForm.progressBar;
                progressStatus = mForm.progressStatus;
            }
            get { return mForm; }
        }
        public static Mediator mediator = null;
        #endregion
        #region 主窗体进度条
        /// <summary>
        /// 初始化进度条
        /// </summary>
        /// <param name="MaxValue"></param>
        public static  void InitProgress(int MaxValue)
        {
            if (MainForm != null)
            {
                for (int i = 0; i < MainForm.Controls.Count; i++)
                {
                    MainForm.Controls[i].Enabled = true;
                }
            }
            progressBar.Value = 0;
            progressBar.Maximum = MaxValue;
            progressStatus.Text = "正在准备任务中......";
        }
        public static  void SetProgressMax(int MaxValue)
        {


            progressBar.Maximum = MaxValue;

        }
        public static  void EndProgress()
        {
            if (MainForm != null)
            {
                for (int i = 0; i < MainForm.Controls.Count; i++)
                {
                    MainForm.Controls[i].Enabled = true;
                }
            }
            progressBar.Value = 0;
            progressBar.Maximum = 100;
            progressStatus.Text = "";
        }
        /// <summary>
        /// 进度
        /// </summary>
        public static  void SetProgress()
        {
            if (MainForm != null)
            {
                for (int i = 0; i < MainForm.Controls.Count; i++)
                {
                    MainForm.Controls[i].Enabled = false;
                }
            }
            if (progressBar.Value + 1 == progressBar.Maximum)
            {
                progressBar.Value++;

                progressStatus.Text = "任务完成";
                EndProgress();

            }
            else
            {
                progressBar.Value++;
                progressStatus.Text = (progressBar.Value * 100.0f / progressBar.Maximum).ToString("0.0");
            }

        }
        public static  void SetProgress(int value)
        {
            if (MainForm != null)
            {
                for (int i = 0; i < MainForm.Controls.Count; i++)
                {
                    MainForm.Controls[i].Enabled = false;
                }
            }
            progressBar.Value = value;

        }
        #endregion
        #region 主窗体日志写入
        private static void AddLog(string msg)
        {
            if (mediator != null && mediator.IOLogForm != null)
                mediator.IOLogForm.AppendText(DateTime.Now.ToString("yyyy-MM-dd") + "  " + msg);
        }
        #endregion
        #region 工程管理
        //未完成的发布任务,需要进行网络通信将本采集站的数据库发送到数据服务中心
        public static async Task PublisProject()
        {
            if (Project == null || Project == "")
                return;
            ///删除发布数据的缓存
            PublishObject.Clear();
            //先保存当前工程
            if (MessageBox.Show(MainForm, "发布前是否保存工程", "保存提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                SaveProject();





            }
            else
            {
                isSaved = true;
            }
            await Task.Run(() =>
             {
                 while (true)
                 {

                     if (isSaved == false)
                     {
                         continue;
                     }
                     if (MessageBox.Show(MainForm, "是否发布此采集站工程，发布需要等待一段时间！", "发布提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                     {
                         TcpData publishUnit = new TcpData();
                         publishUnit.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = ServerID });//要发布的工程ID
                        publishUnit.Items.Add(new TcpDataItem() { Key = "RESULT", Value = "false" });//返回的结果
                        publishUnit.Items.Add(new TcpDataItem() { Key = "MSG", Value = "" });//返回的结果信息
                        publishUnit.ChangedToBytes();
                         TcpClient.Send(publishUnit.TcpItemToString(), ScadaTcpOperator.发布工程请求);



                         break;
                     }
                     else
                     {

                         isSaved = false;
                         return;
                     }


                 }
                 isSaved = false;
             });
        }
        private static void TcpClient_OnPublishing(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg)
        {
            int index = int.Parse(sender.ToString());
            if (index <= PublishObject.Count)
            {
                try
                {
                    if (index == PublishObject.Count)
                    {
                        byte[] sendbytes = ObjectSerialize.ObjectToBytesBinaryFormatter(PublishObject.ElementAt(index - 1).Value);
                        TcpClient.Send(new ArraySegment<byte>(sendbytes), ScadaTcpOperator.上传数据);
                        AddLog("已经发送第" + index + "条数据");
                   
                    }
                    else
                    {
                        byte[] sendbytes = ObjectSerialize.ObjectToBytesBinaryFormatter(PublishObject.ElementAt(index - 1).Value);
                        TcpClient.Send(new ArraySegment<byte>(sendbytes), ScadaTcpOperator.上传数据);
                        AddLog("已经发送第" + index + "条数据");
                    }
                }
                catch (Exception ex)
                {
             
                    byte[] sendbytes = ObjectSerialize.ObjectToBytesBinaryFormatter(PublishObject.ElementAt(index - 1).Value);
                    TcpClient.Send(new ArraySegment<byte>(sendbytes), ScadaTcpOperator.上传数据失败);
                    AddLog("上传数据失败" + ex.Message);
                }
            }


        }
        private static void TcpClient_OnPublishProjectSuccess(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg)
        {
            MessageBox.Show(MainForm, msg);
            AddLog(msg);
            AddLog("工程发布成功,正在启动采集服务器");
            if (MainForm != null)
            {
                for (int i = 0; i < MainForm.Controls.Count; i++)
                {
                    MainForm.Controls[i].Enabled = false;
                }
            }
            PublishObject.Clear();
            try
            {
                Process[] processes = Process.GetProcessesByName("IOMonitor");
               foreach( Process p in processes)
                {
                    p.Kill();
                }
            }
            catch
            {
                
            }
            try
            {
                //复制到发布目录
                File.Copy(Project, Application.StartupPath + "//IOProject/Station.station", true);
            }
            catch
            {
                AddLog("备份工程失败");

            }
          
            
            //重新启动监视服务器
            if (MainForm != null)
            {
                for (int i = 0; i < MainForm.Controls.Count; i++)
                {
                    MainForm.Controls[i].Enabled = true;
                }
            }

            Process.Start("IOMonitor.exe", Config.User + " " + Config.Password);

        }

        private static void TcpClient_OnPublishProjectFault(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg)
        {
            if (MainForm != null)
            {
                for (int i = 0; i < MainForm.Controls.Count; i++)
                {
                    MainForm.Controls[i].Enabled = true;
                }
            }
            PublishObject.Clear();
            AddLog(msg);
            MessageBox.Show(MainForm,msg);
        }
        /// <summary>
        /// 临时保存要发布的数据合集
        /// </summary>
        private static Dictionary<string, Object> PublishObject = new Dictionary<string, Object>();
        //返回服务器端是否准许工程发布
        private static void TcpClient_OnPublishProject(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg)
        {
            PublishObject.Clear();
            if (Convert.ToBoolean(sender))
            {
                AddLog("复制当前工程到发布目录......");
                File.Copy(Project, Application.StartupPath + "//Publish/Publish.station", true);
                AddLog("与服务器进行通信，准备上传工程,需要耐心等待一段时间......");

                Task.Run(() =>
                {
                    try
                    {


                        AddLog("准备发布数据中......");
                        InitProgress(100);
                        //循环写入数据到数据库
                        #region 发布数据

                        AddLog("正在收集要发布的数据......");
                        //直接读取树节点的信息并发布
                        int allnum = mediator.IOTreeForm.IoTree.GetNodeCount(true);
                        InitProgress(allnum);
                        for (int i = 0; i < mediator.IOTreeForm.IoTree.Nodes.Count; i++)
                        {
                            if (mediator.IOTreeForm.IoTree.Nodes[i] is IOServerNode)
                            {
                                IOServerNode sNode = mediator.IOTreeForm.IoTree.Nodes[i] as IOServerNode;
                                Scada.Model.IO_SERVER server = sNode.Server;
                                if (server.SERVER_ID == null || server.SERVER_ID == "")
                                {
                                    server.SERVER_IP = LocalIp.GetLocalIp();

                                }
                                server.SERVER_ID = ServerID;
                                server.SERVER_IP = LocalIp.GetLocalIp();
                                PublishObject.Add(Guid.NewGuid().ToString(), server);




                                for (int j = 0; j < sNode.Nodes.Count; j++)
                                {
                                    if (sNode.Nodes[j] is IOCommunicationNode)
                                    {
                                        IOCommunicationNode cNode = sNode.Nodes[j] as IOCommunicationNode;
                                        Scada.Model.IO_COMMUNICATION Communication = cNode.Communication;
                                        Communication.IO_SERVER_ID = ServerID;
                                        if (Communication.IO_COMM_ID == null || Communication.IO_COMM_ID == "")
                                        {
                                            Communication.IO_COMM_ID = GUIDTo16.GuidToLongID().ToString();
                                        }
                                        PublishObject.Add(Guid.NewGuid().ToString(), Communication);


                                        for (int d = 0; d < cNode.Nodes.Count; d++)
                                        {
                                            if (cNode.Nodes[d] is IODeviceNode)
                                            {
                                                IODeviceNode dNode = cNode.Nodes[d] as IODeviceNode;
                                                Scada.Model.IO_DEVICE Device = dNode.Device;
                                                Device.IO_SERVER_ID = ServerID;
                                                Device.IO_COMM_ID = Communication.IO_COMM_ID;
                                                if (Device.IO_DEVICE_ID == null || Device.IO_DEVICE_ID == "")
                                                {
                                                    Device.IO_DEVICE_ID = GUIDTo16.GuidToLongID().ToString();
                                                }

                                                for (int p = 0; p < Device.IOParas.Count; p++)
                                                {
                                                    Device.IOParas[p].AlarmConfig.IO_SERVER_ID = ServerID;
                                                   Device.IOParas[p].IO_SERVER_ID = ServerID;

                                                }
                                                PublishObject.Add(Guid.NewGuid().ToString(), Device);
                                                SetProgress();
                                            }

                                        }
                                        SetProgress();
                                    }


                                }
                                SetProgress();

                            }

                        }


                        #endregion
                        //同时服务器端开始接收数据
                        Thread.Sleep(3000);

                        //提前告知服务器数据的数量
                        TcpData data = new TcpData();
                        data.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = ServerID });
                        data.Items.Add(new TcpDataItem() { Key = "NUMBER", Value = PublishObject.Count().ToString() });

                        TcpClient.Send(data.TcpItemToString(), ScadaTcpOperator.上传数据开始);

                    }
                    catch (Exception ex)
                    {
                        TcpData data = new TcpData();
                        data.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = ServerID });
                        data.Items.Add(new TcpDataItem() { Key = "IO_SERVER", Value = "0" });
                        data.Items.Add(new TcpDataItem() { Key = "IO_COMMUNICATION", Value = "0" });
                        data.Items.Add(new TcpDataItem() { Key = "IO_DEVICE", Value = "0" });
                        data.Items.Add(new TcpDataItem() { Key = "IO_PARA", Value = "0" });
                        data.Items.Add(new TcpDataItem() { Key = "IO_ALARM_CONFIG", Value = "0" });
                        data.Items.Add(new TcpDataItem() { Key = "COMM_DRIVER", Value = "0" });
                        data.Items.Add(new TcpDataItem() { Key = "DEVICE_DRIVER", Value = "0" });
                        TcpClient.Send(data.TcpItemToString(), ScadaTcpOperator.上传数据失败);
                        AddLog("上传数据失败，请再次重新发布工程,原因" + ex.Message);
                        MessageBox.Show("发布工程失败");
                    }

                });


            }
            else
            {
                AddLog("发布失败  " + msg);
                MessageBox.Show(MainForm, msg);
            }
        }
        /// <summary>
        /// 发送文件的进度
        /// </summary>
        /// <param name="tcpClient"></param>
        /// <param name="total"></param>
        /// <param name="current"></param>
        /// <param name="isend"></param>
        private static void Client_OnSendingFile(Scada.AsyncNetTcp.Net.AsyncTcpClient tcpClient, long total, long current, bool isend)
        {
            int bl = Convert.ToInt16(current * 1.0d / total * 100);
            if (isend)
            {



                AddLog("上传工程结束！");
                EndProgress();
                AddLog("等待服务器更新工程指令......");
            }
            else
            {
                SetProgress(bl);
            }

        }
        public    static void LoadProject()
        {
            try
            {



                OpenFileDialog dialog = new OpenFileDialog();
                dialog.FileName = @"C:\";
                dialog.Filter = "SCADA IO表(*.station)|*.station";
                if (dialog.ShowDialog() == DialogResult.OK)
                {

                    Project = dialog.FileName;
                    DbHelperSQLite.connectionString = "Data Source=" + Project + ";Version=3;";
                    InitProject();

                }
            }
            catch (Exception emx)
            {
                  DisplayException(emx);
            }
        }
        public static   void LoadProject(string filename)
        {
            try
            {





                Project = filename;
                DbHelperSQLite.connectionString = "Data Source=" + Project;

                InitProject();
                MainForm.Text = PubConstant.Product + "  " + Project;
                mediator.IOLogForm.AppendText("加载工程成功 " + Project);





            }
            catch (Exception emx)
            {
                  DisplayException(emx);
            }
        }
        public static string ipToLong(string ip)
        {
            char[] separator = new char[] { '.' };
            string[] items = ip.Split(separator);
            long value = long.Parse(items[0]) << 24
                    | long.Parse(items[1]) << 16
                    | long.Parse(items[2]) << 8
                    | long.Parse(items[3]);
            return value.ToString();
        }
        /// <summary>
        /// IP地址转换为数字
        /// </summary>
        /// <param name="ip">ip地址</param>
        /// <returns></returns>
        static string LongToip(long ip)
        {
            long IntIp = ip;
            StringBuilder sb = new StringBuilder();
            sb.Append(IntIp >> 0x18 & 0xff).Append(".");
            sb.Append(IntIp >> 0x10 & 0xff).Append(".");
            sb.Append(IntIp >> 0x8 & 0xff).Append(".");
            sb.Append(IntIp & 0xff);
            return sb.ToString();

        }
        /// <summary>
        /// 初始加载工程数据
        /// </summary>
        private static void InitProject()
        {
            mediator.OpenIOParaForm();
            Task.Run(() =>
            {

                try
                {

                    InitProgress(100);

                    Scada.Business.IO_SERVER serverBll = new Scada.Business.IO_SERVER();
                    Scada.Model.IO_SERVER server = serverBll.GetModel();

                    if (server == null)
                    {
                        server = new Scada.Model.IO_SERVER();
                        server.SERVER_IP = LocalIp.GetLocalIp();
                        server.SERVER_ID = ServerID;//将IP地址转换为数字形式
                    }
                    string oldServerid = server.SERVER_ID;
                    bool isChanged = false;
                    if (server.SERVER_ID != ServerID)
                    {
                        if (MessageBox.Show(MainForm, "您加载的采集站工程并不是由该采集站服务器上创建，如果要加载将进行本地化转换！是否要加载工程?", "工程加载提醒", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            isChanged = true;
                        }
                        else
                        {
                            return;
                        }
                    }
                    server.SERVER_ID = ServerID;
                    server.SERVER_IP = LocalIp.GetLocalIp();
                    IOServerNode serverNode = new IOServerNode(server, Project);

                    serverNode.Server = server;
                    mediator.IOTreeForm.ClearNode();
                    mediator.IOTreeForm.AddMainNode(serverNode);
                    serverNode.ChangedNode();


                    mediator.IOLogForm.AppendText("加载采集站 " + oldServerid + " " + server.SERVER_NAME);
                    //加载通道
                    mediator.IOLogForm.AppendText("准备加载通道信息......");
                    Scada.Business.IO_COMMUNICATION commBll = new Scada.Business.IO_COMMUNICATION();
                    List<Scada.Model.IO_COMMUNICATION> comms = commBll.GetModelList(" IO_SERVER_ID='" + oldServerid + "'");
                    mediator.IOLogForm.AppendText("加载通道信息成功!");
                    mediator.IOLogForm.AppendText("准备加载设备与IO点表信息......");
                    Scada.Business.IO_DEVICE deviceBll = new Scada.Business.IO_DEVICE();
                    List<Scada.Model.IO_DEVICE> devies = deviceBll.GetModelList(" IO_SERVER_ID='" + oldServerid + "'");
                    mediator.IOLogForm.AppendText("加载设备与IO点表信息成功!");
                    int allnum = comms.Count + devies.Count;
                    InitProgress(allnum);
                    mediator.IOLogForm.AppendText("准备构建树......!");
                    comms.ForEach(delegate (Scada.Model.IO_COMMUNICATION c)
                    {

                        IOCommunicationNode commNode = new IOCommunicationNode();
                        commNode.Communication = c;
                        List<Scada.Model.IO_DEVICE> comm_devices = devies.FindAll(x => x != null && x.IO_COMM_ID == c.IO_COMM_ID && x.IO_SERVER_ID == c.IO_SERVER_ID);

                        if (isChanged)
                        {
                            c.IO_SERVER_ID = server.SERVER_ID;
                            commNode.Communication.IO_COMM_ID = GUIDTo16.GuidToLongID().ToString();
                        }
                        mediator.IOTreeForm.AddChilndenNode(commNode, serverNode);

                        commNode.ChangedNode();
                        mediator.IOLogForm.AppendText(" 加载完成通讯通道 " + c.IO_COMM_NAME + " " + c.IO_COMM_LABEL);
                        SetProgress();

                        commNode.DeviceNumber = comm_devices.Count;
                        comm_devices.ForEach(delegate (Scada.Model.IO_DEVICE d)
                        {

                            IODeviceNode deviceNode = new IODeviceNode();
                            deviceNode.Device = d;
                            if (isChanged)
                            {

                                d.IO_DEVICE_ID = GUIDTo16.GuidToLongID().ToString();
                                Thread.Sleep(2);
                            }
                            deviceNode.Device.IO_SERVER_ID = server.SERVER_ID;
                            deviceNode.Device.IO_COMM_ID = commNode.Communication.IO_COMM_ID;
                            for (int dv = 0; dv < deviceNode.Device.IOParas.Count; dv++)
                            {
                                deviceNode.Device.IOParas[dv].IO_SERVER_ID = server.SERVER_ID;
                                deviceNode.Device.IOParas[dv].IO_COMM_ID = c.IO_COMM_ID;
                                deviceNode.Device.IOParas[dv].IO_DEVICE_ID = d.IO_DEVICE_ID;
                                if (isChanged)
                                {

                                    deviceNode.Device.IOParas[dv].IO_ID = GUIDTo16.GuidToLongID().ToString();
                                    Thread.Sleep(2);
                                }
                                deviceNode.Device.IOParas[dv].AlarmConfig.IO_ID = deviceNode.Device.IOParas[dv].IO_ID;
                                deviceNode.Device.IOParas[dv].AlarmConfig.IO_SERVER_ID = server.SERVER_ID;
                                deviceNode.Device.IOParas[dv].AlarmConfig.IO_COMM_ID = deviceNode.Device.IOParas[dv].IO_COMM_ID;
                                deviceNode.Device.IOParas[dv].AlarmConfig.IO_DEVICE_ID = deviceNode.Device.IOParas[dv].IO_DEVICE_ID;
                            }
                            mediator.IOTreeForm.AddChilndenNode(deviceNode, commNode);
                            deviceNode.ChangedNode();
                            mediator.IOLogForm.AppendText(" 加载完成通讯通道 " + c.IO_COMM_NAME + " 下设备 " + d.IO_DEVICE_NAME + " " + d.IO_DEVICE_LABLE);
                            SetProgress();
                        });
                    });

                    mediator.IOLogForm.AppendText("工程准备就绪,请开始工作吧!");

                    mediator.IOLogForm.AppendText("准备构建树完成!");
                    mediator.IOLogForm.AppendText("工程加载完成!");
                    EndProgress();
                }
                catch (Exception ex)
                {
                    EndProgress();
                    DisplayException(ex);
                }
            });
            EndProgress();

        }
        //新建立工程
        public static void CreateProject()
        {



            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = @"C:\" + DateTime.Today.ToString("yyyyMMdd") + ".station";
            dialog.Filter = "SCADA IO表(*.station)|*.station";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Copy(Application.StartupPath + "/db/IOConfig.station", dialog.FileName, true);
                    Project = dialog.FileName;
                    DbHelperSQLite.connectionString = "Data Source=" + Project;
                    InitProject();
                    mediator.IOLogForm.AppendText("创建工程成功 " + dialog.FileName);


                }
                catch (Exception emx)
                {
                    DisplayException(emx);
                }
            }

        }
        private static bool isSaved = false;
        //保存工程
        public async static void SaveProject()
        {
            isSaved = false;
            PublishServer mPublishServer = new PublishServer();
            await Task.Factory.StartNew(a =>
             {
                //保存文件之前将数据先备份下防止意外导致数据丢失


                Scada.Business.IO_SERVER serverBll = new Scada.Business.IO_SERVER();
                 Scada.Business.IO_PARA paraBll = new Scada.Business.IO_PARA();
                 Scada.Business.IO_DEVICE deviceBll = new Scada.Business.IO_DEVICE();
                 Scada.Business.IO_COMMUNICATION commBll = new Scada.Business.IO_COMMUNICATION();
                 Scada.Model.IO_SERVER myserver = serverBll.GetModel();
                //备份结束后在加载数据
                try
                 {
 
                    int allnum = mediator.IOTreeForm.IoTree.GetNodeCount(true);
                    //当前所有的IO点表

                    List<Scada.Model.IO_DEVICE> Devices = new List<Scada.Model.IO_DEVICE>();
                     Scada.Model.IO_SERVER Server = null;
                     List<Scada.Model.IO_COMMUNICATION> Communications = new List<Scada.Model.IO_COMMUNICATION>();
                     List<Scada.Model.IO_PARA> Paras = new List<Scada.Model.IO_PARA>();
                     List<Scada.Model.IO_ALARM_CONFIG> ParaConfigs = new List<Scada.Model.IO_ALARM_CONFIG>();
                     InitProgress(allnum + 10);
                     for (int i = 0; i < mediator.IOTreeForm.IoTree.Nodes.Count; i++)
                     {
                         if (mediator.IOTreeForm.IoTree.Nodes[i] is IOServerNode)
                         {
                             IOServerNode sNode = mediator.IOTreeForm.IoTree.Nodes[i] as IOServerNode;
                             Scada.Model.IO_SERVER server = sNode.Server;
                             if (server.SERVER_ID == null || server.SERVER_ID == "")
                             {
                                 server.SERVER_IP = LocalIp.GetLocalIp();

                             }
                             server.SERVER_ID = ServerID;
                             Server = server;

                             for (int j = 0; j < sNode.Nodes.Count; j++)
                             {
                                 if (sNode.Nodes[j] is IOCommunicationNode)
                                 {
                                     IOCommunicationNode cNode = sNode.Nodes[j] as IOCommunicationNode;
                                     Scada.Model.IO_COMMUNICATION Communication = cNode.Communication;
                                     Communication.IO_SERVER_ID = ServerID;
                                     if (Communication.IO_COMM_ID == null || Communication.IO_COMM_ID == "")
                                     {
                                         Communication.IO_COMM_ID = GUIDTo16.GuidToLongID().ToString();
                                     }

                                     Communications.Add(Communication);
                                     for (int d = 0; d < cNode.Nodes.Count; d++)
                                     {
                                         if (cNode.Nodes[d] is IODeviceNode)
                                         {
                                             IODeviceNode dNode = cNode.Nodes[d] as IODeviceNode;
                                             Scada.Model.IO_DEVICE Device = dNode.Device;
                                             Device.IO_SERVER_ID = ServerID;

                                             Device.IO_COMM_ID = Communication.IO_COMM_ID;
                                             if (Device.IO_DEVICE_ID == null || Device.IO_DEVICE_ID == "")
                                             {
                                                 Device.IO_DEVICE_ID = GUIDTo16.GuidToLongID().ToString();
                                             }

                                             for (int p = 0; p < Device.IOParas.Count; p++)
                                             {

                                                 Device.IOParas[p].IO_SERVER_ID = ServerID;
                                                 Device.IOParas[p].IO_COMM_ID = Communication.IO_COMM_ID;
                                                 Device.IOParas[p].IO_DEVICE_ID = Device.IO_DEVICE_ID;
                                                 Device.IOParas[p].AlarmConfig.IO_DEVICE_ID = Device.IO_DEVICE_ID;
                                                 Device.IOParas[p].AlarmConfig.IO_COMM_ID = Communication.IO_COMM_ID;
                                                 Device.IOParas[p].AlarmConfig.IO_SERVER_ID = ServerID;
                                                 if (Device.IOParas[p].IO_ID == null || Device.IOParas[p].IO_ID == "")
                                                 {
                                                     Device.IOParas[p].IO_ID = GUIDTo16.GuidToLongID().ToString();

                                                 }
                                                 Device.IOParas[p].AlarmConfig.IO_ID = Device.IOParas[p].IO_ID;
                                                 ParaConfigs.Add(Device.IOParas[p].AlarmConfig);
                                             }
                                             Devices.Add(Device);
                                             Paras.AddRange(Device.IOParas);

                                             SetProgress();
                                         }


                                     }
                                     SetProgress();
                                 }


                             }
                             SetProgress();

                         }





                     }

                    //Sqlit视图有问题，必须先建立条件之外的数据后在插入建立视图相关的数据，否则数据视图会非常多
                    serverBll.Clear();
                     Server.SERVER_IP = LocalIp.GetLocalIp();
                     serverBll.Add(Server);
                     mediator.IOLogForm.AppendText("准备保存通道信息......");
                     commBll.Clear();
                     commBll.Add(Communications);
                     mediator.IOLogForm.AppendText("保存通道信息成功!");
                     mediator.IOLogForm.AppendText("准备保存设备信息......");
                     deviceBll.Clear();
                     deviceBll.Add(Devices);
                     mediator.IOLogForm.AppendText("保存设备信息成功!");
                     mediator.IOLogForm.AppendText("准备保存IO点表及其预警配置信息......");
                     paraBll.Clear();
                     paraBll.Add(Paras, ParaConfigs);

                     mediator.IOLogForm.AppendText("保存IO点表保存成功!");

                     EndProgress();

                    //删除老的数据 也就是标记为1的数据

                    isSaved = true;
                     mediator.IOLogForm.AppendText("工程保存完成");
                     Devices.Clear();
                     Devices = null;
                     Paras.Clear();
                     Paras = null;
                     Communications.Clear();
                     Communications = null;
                    //保存用户最近使用的路径,系统默认直接加载
                    IOConfig config = new IOConfig();
                     config.Project = Project;
                     config.WriteConfig();
                    //执行数据库的压缩
                    DbHelperSQLite.Compress();


                 }
                 catch (Exception emx)
                 {
                    //出错误，要恢复之前的老数据
                    if (!mPublishServer.Recovery(Project))
                     {

                         return;
                     }


                    //删除老的数据 也就是标记为1的数据

                    DisplayException(emx);
                 }
             }, mPublishServer);
        }
        public static void SaveAsProject()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = @"C:\";
            dialog.Filter = "SCADA IO表(*.station)|*.station";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {


                    //此处要先保存点表工程
                    SaveProject();

                    //复制
                    File.Copy(Project, dialog.FileName);
                    mediator.IOLogForm.AppendText("另存工程成功 " + dialog.FileName);


                }
                catch (Exception emx)
                {
                    DisplayException(emx);
                }

            }
        }
        #endregion
        #region 异常处理
        /// <summary>
        /// Displays an unexpected exception that occured in the application to the user.
        /// </summary>
        /// <param name="ex">The exception that occured.</param>
        /// <param name="caption">The optional error message caption to display.</param>
        /// <param name="stackTrace">Determines whether or not the exception's stack trace should be displayed.</param>
        public static  void DisplayException(Exception ex)
        {
            if (MainForm != null)
            {
                for (int i = 0; i < MainForm.Controls.Count; i++)
                {
                    MainForm.Controls[i].Enabled = true;
                }
            }

            if (ex == null) throw new ArgumentNullException("ex");

            Logger.GetInstance().Debug(ex.Message);
            mediator.IOLogForm.AppendText("程序错误 " + ex.Message);
        }
        #endregion
        #region TreeView  相关处理
        /// <summary>
        ///将通信驱动加载到下拉列表中
        /// </summary>
        /// <param name="cbx"></param>
        /// <returns></returns>
        public static void IOCommunicationDriveCombox(ComboBox cbx)
        {
            try
            {


                Scada.Business.SCADA_DRIVER driverBll = new Scada.Business.SCADA_DRIVER();
                List<Scada.Model.SCADA_DRIVER> Drives = driverBll.GetModelList("");
                cbx.Items.Clear();
                for (int i = 0; i < Drives.Count; i++)
                {
                    cbx.Items.Add(Drives[i]);

                }
            }
            catch (Exception emx)
            {
                  DisplayException(emx);
            }

        }
        public static void IODeviceDriveCombox(ComboBox cbx,string driverId)
        {
            try
            {
                Scada.Business.SCADA_DRIVER comdriverBll = new Scada.Business.SCADA_DRIVER();
                Scada.Model.SCADA_DRIVER comDriver = comdriverBll.GetModel(driverId);
                if(comDriver!=null)
                {
                    Scada.Business.SCADA_DEVICE_DRIVER driverBll = new Scada.Business.SCADA_DEVICE_DRIVER();
                    List<Scada.Model.SCADA_DEVICE_DRIVER> Drives = driverBll.GetModelList(" Dll_GUID='" + comDriver.GUID + "'");
                    cbx.Items.Clear();
                    for (int i = 0; i < Drives.Count; i++)
                    {
                        cbx.Items.Add(Drives[i]);

                    }
                }
             
            }
            catch (Exception emx)
            {
                  DisplayException(emx);

            }

        }
        /// <summary>
        /// 新建通道
        /// </summary>
        /// <returns></returns>
        public static void CreateIOCommunicationNode()
        {
            try
            {


                if (mediator.IOTreeForm.SelectedNode != null && mediator.IOTreeForm.SelectedNode is IOServerNode)
                {
                    IOServerNode serverNode = mediator.IOTreeForm.SelectedNode as IOServerNode;
                    IOCommunicationForm form = new IOCommunicationForm();
                    form.Server = serverNode.Server;
                    form.InitForm();
                    if (form.ShowDialog(mForm) == DialogResult.OK)
                    {

                          InsertIOCommunicationNode(form.Server, form.Comunication);
                        mediator.IOLogForm.AppendText("创建通道" + form.Comunication.IO_COMM_NAME + "成功");
                    }
                }
            }
            catch (Exception emx)
            {
                  DisplayException(emx);
            }

        }
        /// <summary>
        /// 编辑通讯节点
        /// </summary>
        /// <param name="commNode"></param>
        /// <returns></returns>
        public static void EditIOCommunicationNode(IOCommunicationNode commNode)
        {
            try
            {


                if (commNode != null && commNode is IOCommunicationNode)
                {
                    IOServerNode serverNode = commNode.Parent as IOServerNode;
                    IOCommunicationForm form = new IOCommunicationForm();
                    form.Server = serverNode.Server;
                    form.Comunication = commNode.Communication;
                    form.InitForm();
                    if (form.ShowDialog(mForm) == DialogResult.OK)
                    {

                          InsertIOCommunicationNode(form.Server, form.Comunication);
                        mediator.IOLogForm.AppendText("编辑通道" + form.Comunication.IO_COMM_NAME + "成功");
                    }
                }
            }
            catch (Exception ex)
            {
                  DisplayException(ex);
            }

        }
        /// <summary>
        /// 插入通信节点
        /// </summary>
        /// <param name="server"></param>
        /// <param name="Communication"></param>
        /// <returns></returns>
        public static void InsertIOCommunicationNode(Scada.Model.IO_SERVER server, Scada.Model.IO_COMMUNICATION Communication)
        {
            IOCommunicationNode commNode = mediator.IOTreeForm.FindCommunicationTreeNode(server, Communication);
            if (commNode == null)
            {
                IOServerNode serverNode = mediator.IOTreeForm.FindServerTreeNode(server);
                if (serverNode != null)
                {
                    commNode = new IOCommunicationNode();
                    commNode.Communication = Communication;
                    serverNode.AddChildenNode(commNode);


                }
                serverNode.Expand();

            }
            else
            {
                commNode.ChangedNode();
            }
        }
        public static void CreateIODeviceNode()
        {
            try
            {
                if (mediator.IOTreeForm.SelectedNode != null && mediator.IOTreeForm.SelectedNode is IOCommunicationNode)
                {
                    IOCommunicationNode commNode = mediator.IOTreeForm.SelectedNode as IOCommunicationNode;
                    IOServerNode serverNode = commNode.Parent as IOServerNode;
                    IODeviceForm form = new IODeviceForm();
                    form.Server = serverNode.Server;
                    form.Communication = commNode.Communication;
                    form.InitForm();
                    if (form.ShowDialog(mForm) == DialogResult.OK)
                    {
                          InsertIODeviceNode(form.Server, form.Communication, form.Device);
                        mediator.IOLogForm.AppendText("创建设备" + form.Device.IO_DEVICE_NAME + "成功");
                    }
                }
            }
            catch (Exception ex)
            {
                  DisplayException(ex);
            }

        }
        /// <summary>
        /// 编辑通讯节点
        /// </summary>
        /// <param name="commNode"></param>
        /// <returns></returns>
        public static void EditIODeviceNode(IODeviceNode deviceNode)
        {
            try
            {
                if (deviceNode != null && deviceNode is IODeviceNode)
                {
                    IOCommunicationNode commNode = deviceNode.Parent as IOCommunicationNode;
                    IOServerNode serverNode = commNode.Parent as IOServerNode;

                    IODeviceForm form = new IODeviceForm();
                    form.Server = serverNode.Server;
                    form.Communication = commNode.Communication;
                    form.Device = deviceNode.Device;
                    form.InitForm();
                    if (form.ShowDialog(mForm) == DialogResult.OK)
                    {

                          InsertIODeviceNode(form.Server, form.Communication, form.Device);
                        mediator.IOLogForm.AppendText("编辑设备" + form.Device.IO_DEVICE_NAME + "成功");
                    }
                }
            }
            catch (Exception ex)
            {
                  DisplayException(ex);
            }

        }
        /// <summary>
        /// 插入通信节点
        /// </summary>
        /// <param name="server"></param>
        /// <param name="Communication"></param>
        /// <returns></returns>
        public static void  InsertIODeviceNode(Scada.Model.IO_SERVER server, Scada.Model.IO_COMMUNICATION Communication, Scada.Model.IO_DEVICE Device)
        {
            IOServerNode serverNode = mediator.IOTreeForm.FindServerTreeNode(server);
            IOCommunicationNode commNode = mediator.IOTreeForm.FindCommunicationTreeNode(server, Communication);
            IODeviceNode deviceNode = mediator.IOTreeForm.FindDeviceTreeNode(server, Communication, Device);
            if (deviceNode == null)
            {

                if (serverNode != null && commNode != null)
                {
                    deviceNode = new IODeviceNode();
                    deviceNode.Device = Device;
                    commNode.AddChildenNode(deviceNode);
                    commNode.Expand();
                }


            }
            else
            {
                deviceNode.ChangedNode();
            }
        }
        //编辑采集站节点
        public static void EditIOServerNode()
        {
            try
            {
                if (mediator.IOTreeForm.SelectedNode is IOServerNode)
                {
                    IOServerForm form = new IOServerForm();
                    IOServerNode serverNode = mediator.IOTreeForm.SelectedNode as IOServerNode;
                    form.Server = serverNode.Server;


                    if (form.ShowDialog(mForm) == DialogResult.OK)
                    {
                        serverNode.Server = form.Server;
                        serverNode.ChangedNode();
                        mediator.IOLogForm.AppendText("编辑站点" + form.Server.SERVER_NAME + "成功");
                    }

                }
            }
            catch (Exception ex)
            {
                  DisplayException(ex);
            }

        }

        #endregion
        #region 加载通讯设备驱动Dll
        private static object CreateObject(string fullname, string dllname)
        {
            try
            {
                Assembly assm = Assembly.LoadFrom(Application.StartupPath + "\\" + dllname + ".dll");//第一步：通过程序集名称加载程序集
                object objType = assm.CreateInstance(fullname, true);// 第二步：通过命名空间+类名创建类的实例。
                return objType;


            }
            catch (System.Exception ex)
            {
                DisplayException(ex);
                return null;
            }

        }

        /// <summary>
        /// 获取驱动信息程序集信息
        /// </summary>
        /// <param name="fullname"></param>
        /// <returns></returns>
        public static DllInfo GetDriverAssembly(string fullname)
        {
            DllInfo dllInfo = new DllInfo();
            try
            {
                Assembly assembly = Assembly.LoadFrom(fullname);

                foreach (Attribute attr in Attribute.GetCustomAttributes(assembly))
                {
                  
                    if (attr.GetType() == typeof(AssemblyTitleAttribute))
                    {
                        dllInfo.Title = ((AssemblyTitleAttribute)attr).Title;
                    }
                    else if (attr.GetType() == typeof(AssemblyDescriptionAttribute))
                    {
                        dllInfo.Description = ((AssemblyDescriptionAttribute)attr).Description;

                    }
                    else if (attr.GetType() == typeof(AssemblyCompanyAttribute))
                    {
                        dllInfo.Company = ((AssemblyCompanyAttribute)attr).Company;
                    }
                    else if (attr.GetType() == typeof(AssemblyVersionAttribute))
                    {
                        dllInfo.Version = ((AssemblyVersionAttribute)attr).Version;
                    }
                    else if (attr.GetType() == typeof(GuidAttribute))
                    {
                        dllInfo.GUID = ((GuidAttribute)attr).Value;
                    }
                }
                dllInfo.FillName = Path.GetFileNameWithoutExtension(fullname);
                dllInfo.FullName = assembly.FullName;
                Type[] types = assembly.GetTypes();
                FileInfo fn = new FileInfo(fullname);
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i].BaseType == typeof(ScadaCommunicateKernel))
                    {
                        ScadaCommunicateKernel obj =(ScadaCommunicateKernel) Activator.CreateInstance(types[i]);

                        DriverInfo driverInfo = new DriverInfo();
                        driverInfo.ClassName = types[i].Name;
                        driverInfo.FullName = types[i].FullName;
                        driverInfo.Title = obj.Title;
                        driverInfo.Guid = obj.GUID;
                        driverInfo.DllGuid = dllInfo.GUID;
                        dllInfo.CommDrivers.Add(driverInfo);

                    }
                    if (types[i].BaseType == typeof(ScadaDeviceKernel))
                    {
                        ScadaDeviceKernel obj = (ScadaDeviceKernel)Activator.CreateInstance(types[i]);

                        DriverInfo driverInfo = new DriverInfo();
                        driverInfo.ClassName = types[i].Name;
                        driverInfo.FullName = types[i].FullName;
                        driverInfo.Title = obj.Title;
                        driverInfo.Guid= obj.GUID;
                        driverInfo.DllGuid = dllInfo.GUID;
                        dllInfo.DeviceDrivers.Add(driverInfo);

                    }
                }
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }

            return dllInfo;

        }
        /// <summary>
        /// 创建设备驱动
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ScadaDeviceKernel CreateDeviceDrive(Scada.Model.SCADA_DEVICE_DRIVER driveModel)
        {
            try
            {
                ScadaDeviceKernel river = (ScadaDeviceKernel)CreateObject(driveModel.DeviceFullName, driveModel.Dll_Name);

                return river;
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
            return null;
        }
        /// <summary>
        /// 创建通讯驱动
        /// </summary>
        /// <param name="commModel"></param>
        /// <returns></returns>
        public static ScadaCommunicateKernel CreateCommunicateDriver(Scada.Model.SCADA_DRIVER commModel)
        {
            try
            {
                ScadaCommunicateKernel river = (ScadaCommunicateKernel)CreateObject(commModel.CommunicationFullName, commModel.FillName);

                return river;
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
            return null;
        }

    
        #endregion
        #region 通讯驱动管理
        /// <summary>
        /// 增加驱动
        /// </summary>
        /// <param name="lv"></param>
        /// <returns></returns>
        public static void AddDrive()
        {
            try
            {
                OpenFileDialog dig = new OpenFileDialog();
                dig.Filter = "通讯驱动(*.dll)|*.dll";
                if (dig.ShowDialog(MainForm) == DialogResult.OK)
                {
                    DllInfo dllInfo = GetDriverAssembly(dig.FileName);

                    if (dllInfo == null)
                    {
                        mediator.IOLogForm.AppendText("您加载的不是本系统的驱动，请检测驱动接口是否正确");
                        MessageBox.Show("您加载的不是本系统的驱动，请检测驱动接口是否正确");

                    }
                    else
                    {
                        Scada.Business.SCADA_DRIVER DriverBll = new Scada.Business.SCADA_DRIVER();
              
                        bool res = false;
                        for (int i = 0; i < dllInfo.CommDrivers.Count; i++)
                        {
                            try
                            {


                                DriverInfo info = dllInfo.CommDrivers[i];

                                Scada.Model.SCADA_DRIVER commDriver = new Scada.Model.SCADA_DRIVER();
                                commDriver.Id = GUIDTo16.GuidToLongID(Guid.Parse(info.Guid)).ToString();
                                commDriver.DeviceName = "";
                                commDriver.Company = dllInfo.Company;
                                commDriver.Description = dllInfo.Description;
                                commDriver.IsSystem = 0;
                                commDriver.UpdateTime = DateTime.Now.ToString();
                                commDriver.CreateTime = DateTime.Now.ToString();
                                commDriver.Anthor = dllInfo.Company;
                                commDriver.CommunicationFullName = info.FullName;
                                commDriver.CommunicationName = info.ClassName;
                                commDriver.Title = info.Title;
                                commDriver.Version = dllInfo.Version;
                                commDriver.GUID = dllInfo.GUID;
                                commDriver.Namespace = info.FullName;
                                commDriver.ClassifyId = 12;//用户自定义驱动默认在12扩展驱动目录下
                                //dll名称
                                commDriver.FillName = dllInfo.FillName;

                                Scada.Model.SCADA_DRIVER existDriver = DriverBll.GetModel(commDriver.Id);
                           

                                if (existDriver == null)
                                {
                                    res = DriverBll.Add(commDriver);
                                  
                                }
                                else
                                {
                                    res = DriverBll.Update(commDriver);
                                }
                                string oldconn = DbHelperSQLite.connectionString;
                                DbHelperSQLite.connectionString = "Data Source = " + Application.StartupPath + "/db/IOConfig.station";
                                Scada.Model.SCADA_DRIVER existOldDriver = DriverBll.GetModel(commDriver.Id);
                                if (existOldDriver == null)
                                {
                                    res = DriverBll.Add(commDriver);

                                }
                                else
                                {
                                    res = DriverBll.Update(commDriver);
                                }
                                DbHelperSQLite.connectionString = oldconn;

                            }
                            catch (Exception emx)
                            {
                                AddLog(emx.Message);
                                res = false;
                            }

                        }



                        //更新驱动
                        if (res)
                        {
                            //添加设备驱动
                            Scada.Business.SCADA_DEVICE_DRIVER DeviceDriverBll = new Scada.Business.SCADA_DEVICE_DRIVER();
                            for (int i = 0; i < dllInfo.DeviceDrivers.Count; i++)
                            {
                                try
                                {


                                    DriverInfo info = dllInfo.DeviceDrivers[i];

                                    Scada.Model.SCADA_DEVICE_DRIVER deviceDriver = new Scada.Model.SCADA_DEVICE_DRIVER();
                                    deviceDriver.Id = GUIDTo16.GuidToLongID(Guid.Parse(info.Guid)).ToString();
                                    deviceDriver.DeviceName = info.ClassName;
                                    deviceDriver.Dll_GUID = dllInfo.GUID;
                                    deviceDriver.DeviceFullName = info.FullName;
                                    deviceDriver.Title = info.Title;
                                    deviceDriver.Namespace = info.FullName;

                                    deviceDriver.Dll_Name = dllInfo.FillName;
                                    deviceDriver.FillName = dllInfo.FillName;
                                    deviceDriver.Dll_Title = dllInfo.Title;
                                    Scada.Model.SCADA_DEVICE_DRIVER existDriver = DeviceDriverBll.GetModel(deviceDriver.Id);


                                    if (existDriver == null)
                                    {
                                        string oldconn = DbHelperSQLite.connectionString;
                                        DbHelperSQLite.connectionString = "Data Source = " + Application.StartupPath + "/db/IOConfig.station";
                                        DeviceDriverBll.Add(deviceDriver);
                                        DbHelperSQLite.connectionString = oldconn;
                                        DeviceDriverBll.Add(deviceDriver);
                                    }
                                    else
                                    {
                                        string oldconn = DbHelperSQLite.connectionString;
                                        DbHelperSQLite.connectionString = "Data Source = " + Application.StartupPath + "/db/IOConfig.station";
                                        DeviceDriverBll.Update(deviceDriver);
                                        DbHelperSQLite.connectionString = oldconn;
                                        DeviceDriverBll.Update(deviceDriver);
                                    }
                                }
                                catch (Exception emx)
                                {
                                    AddLog(emx.Message);
                                    res = false;
                                }

                            }


                            //实际驱动的调用目录
                            File.Copy(dig.FileName, Application.StartupPath + "/" + dllInfo.FillName + ".dll", true);
                            //驱动的备份
                            File.Copy(dig.FileName, Application.StartupPath + "/Drivers/" + dllInfo.FillName + ".dll", true);
                            
                            MessageBox.Show(MainForm, "保存成功");
                            AddLog("新增驱动" + dllInfo.Title.ToString() + "成功");
                 
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                  DisplayException(ex);
            }

        }
        public static void LoadDriver(TreeView tree, ContextMenuStrip contextMenuStrip)
        {
            #region 加载驱动和目录
            Scada.Business.Classify_DRIVER claBll = new Scada.Business.Classify_DRIVER();
            Scada.Business.SCADA_DRIVER driverBll = new Scada.Business.SCADA_DRIVER();
            List<Scada.Model.Classify_DRIVER> cls = claBll.GetModelList("");
            tree.Nodes.Clear();
            for (int i = 0; i < cls.Count; i++)
            {
                TreeNode tn = new TreeNode();
                tn.Text = cls[i].ClassifyName;
                tn.Tag = cls[i].Id;
                tn.Name = cls[i].Id.ToString();
                tree.Nodes.Add(tn);
                List<Scada.Model.SCADA_DRIVER> drivers = driverBll.GetModelList(" ClassifyId=" + cls[i].Id + " ");
                for (int j = 0; j < drivers.Count; j++)
                {

                    TreeNode drivertn = new TreeNode();
                    drivertn.Text = drivers[j].Title;
                    drivertn.Tag =drivers[j].Id;
                    drivertn.Name = "device_" + drivers[j].Id;
                    if(drivers[j].IsSystem==0)
                    drivertn.ContextMenuStrip = contextMenuStrip;
                    tn.Nodes.Add(drivertn);
                }
            }

            #endregion
        }
        /// <summary>
        /// 删除某个驱动
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static void  DeleteDrive(TreeNode lv)
        {
            try
            {
                if (MessageBox.Show(MainForm, "删除正在使用的驱动非常危险,是否要删除选中的驱动?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Scada.Business.SCADA_DRIVER commDriverBll = new Scada.Business.SCADA_DRIVER();
                
                    if (commDriverBll.Delete(lv.Tag.ToString()))
                    {
                         
                     AddLog("删除"+ lv .Text+ "驱动成功");
                    }

                }
            }
            catch (Exception ex)
            {
                  DisplayException(ex);
            }
        }
        #endregion  
        #region 日志管理部分
        //导出日志

        public static void  ExportLog()
        {
            SaveFileDialog dig = new SaveFileDialog();
            dig.Filter = "文本文件(*.txt)|*.txt";
            if (dig.ShowDialog(MainForm) == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(dig.FileName, false, Encoding.Default);
                List<string> sb = mediator.IOLogForm.GetLogContent();
                InitProgress(sb.Count);
                for (int i = 0; i < sb.Count; i++)
                {
                    SetProgress();
                    sw.WriteLine(sb[i]);
                }
                sw.Close();
            }
        }
        #endregion
        #region IO点表管理
        public static void OpenDeviceParas(Scada.Model.IO_SERVER Server, Scada.Model.IO_COMMUNICATION Communication, Scada.Model.IO_DEVICE Device)
        {
            try
            {
                mediator.IOParaForm.InitListView(Server, Communication, Device);
                mediator.IOLogForm.AppendText("编辑设备" + Server.SERVER_NAME + "\\" + Communication.IO_COMM_NAME + "\\" + Device.IO_DEVICE_NAME + "下的IO点");
            }
            catch (Exception ex)
            {
                  DisplayException(ex);
            }
        }
        public static void EditDevicePara(Scada.Model.IO_SERVER Server, Scada.Model.IO_COMMUNICATION Communication, Scada.Model.IO_DEVICE Device, Scada.Model.IO_PARA Para)
        {
            try
            {

                IOParaForm form = new IOParaForm();
                form.Server = Server;
                form.Comunication = Communication;
                form.Device = Device;
                form.Para = Para;
                form.InitForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    mediator.IOLogForm.AppendText("在" + Device.IO_DEVICE_NAME + "设备上创建" + form.Para.IO_NAME + "成功!");
                }
            }
            catch (Exception ex)
            {
                  DisplayException(ex);
            }

        }
        #endregion
    }
}
