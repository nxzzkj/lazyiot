using Scada.AsyncNetTcp;
using Scada.Controls.Forms;
using ScadaFlowDesign.Dialog;
using Scada.FlowGraphEngine;
using Scada.FlowGraphEngine.GraphicsMap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Scada.DBUtility;
using Scada.Model;

namespace ScadaFlowDesign.Core
{
    public abstract class FlowManager
    {
        private static System.Threading.Timer ClearMemoryTimer = null;
        public static FlowDataBaseManager FlowDataBaseManager = null;
        public static FlowDesign FlowDesign = null;
        public static Mediator Mediator = null;
        public static List<FlowProject> Projects = new List<FlowProject>();
        public static IOConfig Config = new IOConfig();
        public static IOFlowTCPClient TcpClient = null;
 
        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        private static void ClearMemory()
        {
            Task.Run(() => {
                try
                {
                    GC.Collect();

                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    {
                        SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
                    }
                }
                catch
                {

                }

            });
       
            
        }
        #endregion
        #region TCP/IP通讯
        public static void InitTcpClient(string remoteIp)
        {
            if (TcpClient == null || !TcpClient.IsClientConnected || TcpClient.IsClosed)
            {
                if (TcpClient != null)
                {
                    TcpClient.Dispose();
                }

                TcpClient = new IOFlowTCPClient();
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
        public static void FlowManagerClose()
        {
            if (TcpClient != null)
            {

                TcpClient.Dispose();
                TcpClient = null;
           
            }

            if (ClearMemoryTimer != null)
            {
                ClearMemoryTimer.Dispose();
            }
            GC.Collect();

        }
    
        private static void TcpClient_OnTCPClientLoged(string msg)
        {
            AddLogToMainLog(msg);
        }


        private static void TcpClient_OnExceptionHanped(Exception ex)
        {
            AddLogToMainLog(ex.Message);
        }

        private static void TcpClient_OnDisConnectedServer(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg, string ProjectID)
        {
            AddLogToMainLog(msg + "，正在尝试连接服务器....");
        }

        private static void TcpClient_OnConnectedServer(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg, string ProjectID)
        {
            AddLogToMainLog("与服务器断开连接成功!");
        }
        public static bool LoginManager(string user, string password)
        {
            STATION_TCP_INFO loginInfo = new STATION_TCP_INFO();
            loginInfo.USER = user;
            loginInfo.PASSWROD = password;
            loginInfo.IO_SERVER_ID = "";
            loginInfo.IO_SERVER_IP = "";
            loginInfo.RESULT = "false";
            loginInfo.FUNCTION = "IOFlow";
            Scada.AsyncNetTcp.TcpData tcpData = new Scada.AsyncNetTcp.TcpData();
            byte[] loginbytes = tcpData.StringToTcpByte(loginInfo.GetCommandString(), Scada.AsyncNetTcp.ScadaTcpOperator.流程设计器登录);
            //发送登录命令
            TcpClient.Send(new ArraySegment<byte>(loginbytes));
            return false;
        }
        #endregion

        #region 流程发布相关
        private static void TcpClient_OnPublishProjectSuccess(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg, string ProjectID)
        {
            AddLogToMainLog("流程图发布成功！");
            MessageBox.Show(FlowDesign, "发布流程图成功!");
        }

        private static void TcpClient_OnPublishProjectFault(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg, string ProjectID)
        {
            AddLogToMainLog("流程图发布失败！");
            MessageBox.Show(FlowDesign, "发布流程图成功!");
        }
        //开始发布流程图
        /// <summary>
        /// 临时保存要发布的数据合集
        /// </summary>
        private static Dictionary<int, byte[]> PublishObject = new Dictionary<int, byte[]>();
        private static void TcpClient_OnPublishProject(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg, string ProjectID)
        {
            bool res = Convert.ToBoolean(sender);
            if (res)
            {
                PublishObject.Clear();
                var pubProject = Projects.Find(x => x.ProjectID == ProjectID);
                if (pubProject == null)
                {
                    AddLogToMainLog("未找到ID" + ProjectID + "的工程,无法发布!");
                    return;
                }
                bool isindex = false;
                for (int i = 0; i < pubProject.GraphList.Count; i++)
                {
                    isindex = pubProject.GraphList[i].Index;
                    if (isindex)
                    {
                        break;
                    }

                }
                if (isindex == false)
                {
                    AddLogToMainLog("您发布的工程没有创建主视图，无法发布。请选择主先设置主视图后在尝试发布");
                    return;
                }
                StringBuilder sb = new StringBuilder();
                int ViewNum = pubProject.GraphList.Count;//当前发布的视图数量
                sb.AppendLine("\r\n--PROJ #" + pubProject.ProjectID + "#" + pubProject.Title + "\r\n");
                sb.AppendLine(" ");
                for (int i = 0; i < ViewNum; i++)
                {
                    sb.AppendLine("\r\n--VIEW #" + pubProject.GraphList[i].GID + "#" + pubProject.GraphList[i].ViewTitle + "#" + pubProject.GraphList[i].Index.ToString() + "\r\n");
                    sb.AppendLine(" ");
                    pubProject.GraphList[i].Site.IsPublish = true;
                    sb.Append(pubProject.GraphList[i].Site.ExportSVG());
                    sb.AppendLine("");
                    sb.AppendLine("\r\n--ENDVIEW\r\n");
                }
                //工程包含的用户数据
                for (int i = 0; i < pubProject.FlowUsers.Count; i++)
                {
                    sb.AppendLine("\r\n--USER #" + pubProject.FlowUsers[i].Nickname + "#" + pubProject.FlowUsers[i].UserName + "#" + pubProject.FlowUsers[i].Password.ToString() + "#" + pubProject.FlowUsers[i].Read.ToString() + "#" + pubProject.FlowUsers[i].Write.ToString() + "\r\n");
                    sb.AppendLine("\r\n--ENDUSER\r\n");
                }

                byte[] byteArray = System.Text.Encoding.Default.GetBytes(sb.ToString());
                int num = byteArray.Length / 8192;
                if (byteArray.Length % 8192 != 0)
                {
                    num++;
                }
                List<byte> tempBytes = new List<byte>();
                for (int i = 0; i < num; i++)
                {
                    byte[] subBytes;
                    if (i == num - 1 && byteArray.Length % 8192 != 0)
                    {
                        subBytes = byteArray.Skip(i * 8192).Take(byteArray.Length % 8192).ToArray();
                    }
                    else
                    {
                        subBytes = byteArray.Skip(i * 8192).Take(8192).ToArray();
                    }
                    PublishObject.Add(i + 1, subBytes);
                    tempBytes.AddRange(subBytes);
                }

                TcpData tcpData = new TcpData();
                tcpData.Items.Add(new TcpDataItem() { Key = "RELUST", Value = "" });
                tcpData.Items.Add(new TcpDataItem() { Key = "MSG", Value = "" });
                tcpData.Items.Add(new TcpDataItem() { Key = "IO_SERVER_ID", Value = FlowDataBaseManager.IOServer.SERVER_ID });
                tcpData.Items.Add(new TcpDataItem() { Key = "NUMBER", Value = num.ToString() });
                tcpData.Items.Add(new TcpDataItem() { Key = "BYTENUMBER", Value = byteArray.Length.ToString() });
                AddLogToMainLog("发布视图数量" + ViewNum);
                byte[] datas = tcpData.StringToTcpByte(tcpData.TcpItemToString(), Scada.AsyncNetTcp.ScadaTcpOperator.流程发布准备);
                TcpClient.Send(new ArraySegment<byte>(datas));

            }
            else
            {
                AddLogToMainLog(msg + ", 无法发布!");
            }


        }
        private static void TcpClient_OnPublishing(Scada.AsyncNetTcp.Net.AsyncTcpClient client, object sender, string msg, string ProjectID)
        {
            int index = int.Parse(sender.ToString());
            if (index <= PublishObject.Count)
            {
                if (index == PublishObject.Count)
                {
                    byte[] datas = PublishObject.ElementAt(index - 1).Value;
                    TcpClient.Send(new ArraySegment<byte>(datas), ScadaTcpOperator.流程发布数据);
                    AddLogToMainLog("已经发送第" + index + "条数据");
                    Thread.Sleep(3000);

                    TcpClient.Send("采集站数据已经发送完毕，等待服务器更新程序！", ScadaTcpOperator.流程发布成功);

                    AddLogToMainLog("流程图工程已经上传完毕，等待服务器更新程序！");
                }
                else
                {
                    byte[] datas = PublishObject.ElementAt(index - 1).Value;
                    TcpClient.Send(new ArraySegment<byte>(datas), ScadaTcpOperator.流程发布数据);
                }

            }
            AddLogToMainLog("数据接收进度 " + (Convert.ToSingle(index) / PublishObject.Count * 100) + "%");
        }

        /// <summary>
        /// 准备开始发布流程,要发布的流程工程
        /// </summary>
        public static  void PublishFlowStart(FlowProject project)
        {
            if(FlowDataBaseManager.IOServer==null)
            {
                AddLogToMainLog("发布流程失败，您当前所在的采集站没有采集站工程！");
                MessageBox.Show(FlowDesign, "发布流程失败，您当前所在的采集站没有采集站工程!");
                return;
            }
            TcpData tcpData = new TcpData();
            string commandStr = "PROJECTID:"+ project.ProjectID+ "#IO_SERVER_ID:" + FlowDataBaseManager.IOServer.SERVER_ID+ "#RESULT:#MSG:工程发布请求";
            byte[] publishbytes = tcpData.StringToTcpByte(commandStr, Scada.AsyncNetTcp.ScadaTcpOperator.流程发布请求);
            //发送登录命令
            TcpClient.Send(new ArraySegment<byte>(publishbytes));
            AddLogToMainLog("发布流程命令请求已经下发到服务器，请耐心等待服务器进一步提示！");

        }

        #endregion

        /// <summary>
        /// 初始胡InitFlow
        /// </summary>
        /// <returns></returns>
        public static   void StartFlowManager()
        {
            FlowDesign = new FlowDesign();
            Mediator = new Mediator(FlowDesign);
            FlowDesign.mediator = Mediator;
            Mediator.DockPanel = FlowDesign.DockPanel;
            //加载初始化界面
            Mediator.OpenLogForm();
            Mediator.OpenPropertiesForm();
            Mediator.OpenShapeForm();
            Mediator.OpenToolForm();


            //首先加载用户的工程树   
              FlowManager.LoadDataBase();

            //启动主界面
            Application.Run(FlowDesign);

            //创建垃圾定时回收
           
            ClearMemoryTimer = new System.Threading.Timer(delegate {

                ClearMemory();

            }, null, 50000, 50000);



        }
        //初始胡窗体后加载数据库中的工程数据
        public static void LoadDataBase()
        {
            FlowDataBaseManager = new FlowDataBaseManager();
            FlowDataBaseManager.OnFlowDesignLogger += FlowManager_OnFlowDesignLogger;
            FlowDataBaseManager.OnFlowExceptionHanped += FlowManager_OnFlowExceptionHanped;

              FlowDataBaseManager.InitBaseModel();
        }
        #region 异常处理，统一都输出到主任何界面
        public static  void AddLogToMainLog(string msg)
        {
            if (Mediator != null)
                Mediator.LogForm.AppendLogItem(msg);

        }
        /// <summary>
        /// 异常信息在日志端显示
        /// </summary>
        /// <param name="ex"></param>
        public static void ThrowExceptionToMain(Exception ex)
        {
            if (Mediator != null)
                Mediator.LogForm.AppendLogItem(ex.Message);

        }


        #endregion
        private static void FlowManager_OnFlowExceptionHanped(Exception ex)
        {
            ThrowExceptionToMain(ex);
        }

        private static void FlowManager_OnFlowDesignLogger(string log)
        {
            AddLogToMainLog(log);
        }

        #region 图件的保存于打开等相关操作
        public static bool LoadProject(string filename)
        {
           
                  bool res = false;
                  FileStream fs = null;
            try
            {
                FlowProject Project = null;
                fs = new FileStream(filename, FileMode.Open);
                fs.Seek(0, SeekOrigin.Current);
                IFormatter formatter = new BinaryFormatter();
                while (fs.Position < fs.Length)
                {
                    Project = (FlowProject)formatter.Deserialize(fs);

                }
                if (Project != null)
                {

                    if (Projects.Exists(x => x.ProjectID == Project.ProjectID))
                    {
                        FrmDialog.ShowDialog(null, "该工程已经被打开");
                    }
                    else
                    {
                        ProjectPasswordDialog confirmDig = new ProjectPasswordDialog(Project);
                        if (confirmDig.ShowDialog() == DialogResult.OK)
                        {


                            Project.FileFullName = filename;
                            //初始化所有图元
                            Mediator.ToolForm.InitTreeView(Project);
                            Mediator.ToolForm.InitTreeUser(Project);
                            Mediator.ToolForm.InitTreeConnections(Project);

                            Projects.Add(Project);
                            res = true;
                        }
                    }

                }

            }
            catch (Exception emx)
            {
                MessageBox.Show(emx.Message + " " + emx.InnerException);
                AddLogToMainLog(emx.Message);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
                  return res;
      
        }

        public static void OpenProject()
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Filter = "流程图(*.flow)|*.flow";
            if (dig.ShowDialog(FlowDesign) == DialogResult.OK)
            {
                try
                {
                    if(LoadProject(dig.FileName))
                    {
                        AddLogToMainLog("打开工程成功 " + dig.FileName);
                        //写入最近打开的列表
                        StreamWriter sw = new StreamWriter(Application.StartupPath + "//Lately.log", true, Encoding.Default);
                        sw.WriteLine(dig.FileName);
                        sw.Close();

                    }
                    else
                    {
                        AddLogToMainLog("打开工程失败 " + dig.FileName);
                    }
          
                }
                catch (Exception ex)
                {
                    FlowManager.ThrowExceptionToMain(ex);
                
                }
            }

        }
        public static void SaveAsProject(FlowProject Project)
        {
            if (Project == null)
            {
                FrmDialog.ShowDialog(FlowDesign, "没有工程可保存!");
                return;
            }
            SaveFileDialog dig = new SaveFileDialog();
            dig.Filter = "流程图(*.flow)|*.flow";
            if (dig.ShowDialog(FlowDesign) == DialogResult.OK)
            {
                try
                {
                    Project.FileFullName = dig.FileName;
                    Save(Project);
                }
                catch (Exception ex)
                {
                    FlowManager.ThrowExceptionToMain(ex);
                }
            }
        }
        public static void SaveProject(FlowProject Project)
        {
            if (Project == null)
            {
                FrmDialog.ShowDialog(FlowDesign, "没有工程可保存!");
                return;
            }
            if (Project.FileFullName == "")
            {
                SaveAsProject(Project);
            }
            else
            {
                Save(Project);
            }

        }
        public static void Save(FlowProject Project)
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream fs = null;
            try
            {
                fs = new FileStream(Project.FileFullName, FileMode.Create);
                formatter.Serialize(fs, Project);
           
                AddLogToMainLog("保存工程成功! " + Project.FileFullName);
                MessageBox.Show("保存工程成功!");
            }
            catch (Exception emx)
            {
                MessageBox.Show(emx.Message);
                AddLogToMainLog("保存工程失败! " + Project.FileFullName);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

        }
        public static void CreateNewProject()
        {

            CreateProjectDialog dig = new CreateProjectDialog();
            if (dig.ShowDialog(FlowDesign) == DialogResult.OK)
            {
                FlowProject Project = new FlowProject();
                Project.Title = dig.ProjectTitle;
                Project.Password = dig.Password;
                Project.ProjectID = GUIDTo16.GuidToLongID().ToString();
                Project.FileFullName = dig.FileFullName;
                Mediator.ToolForm.InitTreeView(Project);
                Mediator.ToolForm.InitTreeUser(Project);
                Mediator.ToolForm.InitTreeConnections(Project);

                Projects.Add(Project);

            }

        }
        public static GraphControl Graph
        {

            get
            {

                if (Mediator.ActiveWork == null)
                    return null;
                WorkForm form = Mediator.ActiveWork as WorkForm;
                return form.GraphControl;
            }
        }
        #region 视图操作
       
        public static void CreateView()
        {
            Mediator.ToolForm.CreateView();
            
        }
        public static void DeleteView(GraphControl graph)
        {
            Mediator.ToolForm.CreateView();
        }
        #endregion
        /// <summary>
        /// 发布工程
        /// </summary>
        public static void PublishProject()
        {
            Mediator.ToolForm.Publish();
        }
        /// <summary>
        /// 预览工程
        /// </summary>
        public static void ViewProject()
        {
            Mediator.ToolForm.Debug();

        }
        public static void SaveProject()
        {
            Mediator.ToolForm.SaveProject();

        }
        public static void SaveAsProject()
        {
            Mediator.ToolForm.SaveAsProject();

        }
        public static void DeleteProject()
        {
            Mediator.ToolForm.DeleteProject();

        }
        public static void DeleteView()
        {
            Mediator.ToolForm.DeleteView();

        }

        
        #endregion
    }
}
