using Temporal.Net.InfluxDb.Models.Responses;
using Temporal.DbAPI;
using Scada.IOStructure;
using Scada.Controls;
using Scada.Controls.Controls;
using Scada.Controls.Forms;
using ScadaCenterServer.Controls;
using ScadaCenterServer.Pages;
using Scada.Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Business;
using Scada.DBUtility;


namespace ScadaCenterServer.Core
{
    public delegate void CenterServerExceptionHappened(string exmsg);
    public delegate void CenterServerLogHappened(string log);
    public   class IOCenterQueryFormManager: ScadaTask
    {
      

        public   IOCenterMainForm MainForm = null;
        public   Mediator Mediator = null;
        public   event CenterServerExceptionHappened CenterServerException;
        public   event CenterServerLogHappened CenterServerLog;
        public   Random MainRandom = new Random();
        /// <summary>
        /// 当当前对象释放的时候
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
          
            MainRandom = null;
            InfluxDbManager= null;


        }

        /// <summary>
        /// 异常信息在日志端显示
        /// </summary>
        /// <param name="ex"></param>
        public   void DisplyException(Exception ex)
        {
            if (MainForm != null)
            {
                for (int i = 0; i < MainForm.Controls.Count; i++)
                {
                    MainForm.Controls[i].Enabled = true;
                }
            }
            if (CenterServerException != null)
            {
                CenterServerException(ex.Message);
            }
            Scada.Logger.Logger.GetInstance().Debug(ex.Message);
        }
        public void DisplyException(string exmsg)
        {
            if (MainForm != null)
            {
                for (int i = 0; i < MainForm.Controls.Count; i++)
                {
                    MainForm.Controls[i].Enabled = true;
                }
            }
            if (CenterServerException != null)
            {
                CenterServerException(exmsg);
            }
            Scada.Logger.Logger.GetInstance().Debug(exmsg);
        }
        public   void AddLog(string log)
        {
            if (CenterServerLog != null)
            {
                CenterServerLog(log);
            }
            Scada.Logger.Logger.GetInstance().Info(log);
        }
        /// <summary>
        /// 初始化窗体任务
        /// </summary>
        public  void  InitQueryForm(IOCenterMainForm form)
        {
            MainForm = form;
            //加载数据中心数据库Sqlit
            Mediator = new Mediator(form);
         
            Mediator.DockPanel = form.dockPanel;
            Mediator.OpenIOPropeitesForm();
            Mediator.OpenIOTreeForm();
            Mediator.OpenOperatorLogForm();
        
           


            CenterServerException += IOCenterServerFormManager_CenterServerException;
            CenterServerLog += IOCenterServerFormManager_CenterServerLog;
           
        }

    
        #region 日志和错误异常
        private   void IOCenterServerFormManager_CenterServerLog(string log)
        {
            Mediator.OperatorLogForm.AppendLogItem(log);
        }

        private   void IOCenterServerFormManager_CenterServerException(string exmsg)
        {
            Mediator.OperatorLogForm.AppendLogItem(exmsg);
            Logger.GetInstance().Debug(exmsg);
        }
        #endregion
        #region 时序列数据库的管理
        public   Process influxdbApplication;
    
        public   InfluxDbManager InfluxDbManager = null;
        private   void  InstallInfluxDB()
        {
            string str = System.Windows.Forms.Application.StartupPath + "\\influxdb\\influxdbstart.bat";

            string strDirPath = System.IO.Path.GetDirectoryName(str);
            string strFilePath = System.IO.Path.GetFileName(str);

            string targetDir = string.Format(strDirPath);//this is where mybatch.bat lies
            influxdbApplication = new Process();
            influxdbApplication.StartInfo.WorkingDirectory = targetDir;
            influxdbApplication.StartInfo.FileName = strFilePath;

            influxdbApplication.StartInfo.CreateNoWindow = true;
            influxdbApplication.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            influxdbApplication.Start();
        }
        //启动实时数据库
        public   void  StartInfluxDBServer()
        {
            Task.Run(() => { 
            try
            {
              
                AddLog("正在启动时序数据库服务.....");

                //安装实时数据库

                  InstallInfluxDB();
               
                AddLog("时序数据库服务已经启动完成");
                InfluxDbManager = new InfluxDbManager(IOCenterManager.IOProject.ServerConfig.influxdConfig.HttpAddress, IOCenterManager.IOProject.ServerConfig.InfluxDBGlobal.DataBaseName, IOCenterManager.IOProject.ServerConfig.InfluxDBGlobal.User, IOCenterManager.IOProject.ServerConfig.InfluxDBGlobal.Password, IOCenterManager.IOProject.ServerConfig.InfluxDBGlobal.InfluxDBVersion);
                //此处要判断实时数据库是否已经启动，如果没有启动一直等待数据库服务器启动
                InfluxDbManager.InfluxException += InfluxDbManager_InfluxException;

                int num = 0;
                while (true)
                {
                    if (num > 10)
                    {
                        break;
                    }
                    AddLog("正在启动实时数据服务......" + (num + 1) + "秒");
                    Thread.Sleep(1000);
                    num++;
                }
                while (true)
                {
                    Process[] influx = Process.GetProcessesByName("influxd");
                    if (influx.Length > 0)
                    {
                        
                        break;
                    }
                    AddLog("正在启动实时数据服务......");
                    //每10秒循环判断一次实时数据库是否在启动中
                    Thread.Sleep(1000);
                }
                AddLog("SCADA实时数据库准备就绪!");
                //连接实时数据库
                AddLog("准备连接SCADA实时数据库......");
                  InfluxDbManager.ShouldConnectInfluxDb();
                AddLog("连接SCADA实时数据库已经完成!");
                Thread.Sleep(1000);
                //监视实时数据库状态，如果实时数据库因为某些原因被关闭，则要求及时自动将实时数据库重新驱动
                AddLog("启动监视服务.......!");
                  MonitorInfluxDB();
                Thread.Sleep(1000);
                AddLog("启动监视服务成功!");
              
            }
            catch (Exception ex)
            {
                DisplyException(ex);
                AddLog("系统服务启动失败，请尝试重新启动服务!");
                  CloseInfluxDBServer();
            }
            });
        }
        /// <summary>
        /// influx数据库报错异常返回
        /// </summary>
        /// <param name="ex"></param>
        private   void InfluxDbManager_InfluxException(Exception ex)
        {
            DisplyException(ex);
        }

        //关闭时序数据库
        public   void CloseInfluxDBServer()
        {
            Task.Run(() => { 
            try
            {
                AddLog("正在关闭时序数据库服务.....");
                if (influxdbApplication != null)
                    influxdbApplication.Kill();
                Process[] influx = Process.GetProcessesByName("influxd");
                for (int i = 0; i < influx.Length; i++)
                {
                    influx[i].CloseMainWindow();
                    influx[i].Kill();
                }
                influxdbApplication.Close();
                influxdbApplication.Dispose();
                influxdbApplication = null;
                AddLog("时序数据库服务已经关闭");
            }
            catch (Exception ex)
            {
                DisplyException(ex);
            }
            });
        }
        //监视influxdb数据库，如果数据库被退出了，则要重新启动
        private     void  MonitorInfluxDB()
        {
            var influxTask = Task.Run(() =>
            {
                while (true)
                {
                    Process[] influx = Process.GetProcessesByName("influxd");
                    if (influx.Length <= 0)
                    {
                        AddLog("时序数据库服务未知原因而关闭");
                        CloseInfluxDBServer();
                        AddLog("准备重新启动时序数据库服务......");
                        Thread.Sleep(2000);
                        StartInfluxDBServer();

                        break;
                    }
                    //每10秒循环判断一次实时数据库是否在启动中
                    Thread.Sleep(10000);
                }
            });

        }
        #endregion
        #region 主窗体进度条
        /// <summary>
        /// 初始化进度条
        /// </summary>
        /// <param name="MaxValue"></param>
        public   void InitProgress(int MaxValue)
        {

            MainForm.ProgressBar.Value = 0;
            MainForm.ProgressBar.Maximum = MaxValue;
            MainForm.ProgressBar.Text = "";
        }
        public   void EndProgress()
        {

            MainForm.ProgressBar.Value = 0;
            MainForm.ProgressBar.Maximum = 100;
            MainForm.ProgressBar.Text = "";
        }
        /// <summary>
        /// 进度
        /// </summary>
        public   void SetProgress()
        {

            if (MainForm.ProgressBar.Value + 1 == MainForm.ProgressBar.Maximum)
            {
                MainForm.ProgressBar.Value++;
                EndProgress();
                MainForm.ProgressBar.Text = "任务完成";
            }
            else
            {
                MainForm.ProgressBar.Value++;
                MainForm.ProgressBar.Text = (MainForm.ProgressBar.Value * 100.0f / MainForm.ProgressBar.Maximum).ToString("0.0");
            }

        }
        #endregion
        #region IO树操作管理
        public   void LoadIOProject(TreeView tree)
        {
           if (tree.FindForm()!=null)
            {
                if (tree.Parent.IsHandleCreated)
                {
                    tree.BeginInvoke(new EventHandler(delegate
                    {




                        try
                        {
                            tree.Nodes.Clear();

                            int num = IOCenterManager.IOProject.Servers.Count + IOCenterManager.IOProject.Communications.Count + IOCenterManager.IOProject.Devices.Count;
                            TreeNode mainNode = new TreeNode();
                            mainNode.ImageIndex = 0;
                            mainNode.SelectedImageIndex = 0;
                            mainNode.Text = PubConstant.Product;
                            InitProgress(num);
                            ///加载采集站
                            for (int i = 0; i < IOCenterManager.IOProject.Servers.Count; i++)
                            {

                                IoServerTreeNode serverNode = new IoServerTreeNode();
                                serverNode.Server = IOCenterManager.IOProject.Servers[i];
                                serverNode.InitNode();
                                List<Scada.Model.IO_COMMUNICATION> serverComms = IOCenterManager.IOProject.Communications.FindAll(x => x.IO_SERVER_ID == IOCenterManager.IOProject.Servers[i].SERVER_ID);
                                for (int c = 0; c < serverComms.Count; c++)//通道
                                {
                                    IoCommunicationTreeNode commNode = new IoCommunicationTreeNode();
                                    commNode.Communication = serverComms[c];
                                    commNode.Server = IOCenterManager.IOProject.Servers[i];
                                    commNode.InitNode();
                                    List<Scada.Model.IO_DEVICE> commDevices = IOCenterManager.IOProject.Devices.FindAll(x => x.IO_SERVER_ID == IOCenterManager.IOProject.Servers[i].SERVER_ID && x.IO_COMM_ID == serverComms[c].IO_COMM_ID);
                                    for (int d = 0; d < commDevices.Count; d++)//设备
                                    {
                                        IoDeviceTreeNode deviceNode = new IoDeviceTreeNode();
                                        deviceNode.Device = commDevices[d];
                                        deviceNode.Server = IOCenterManager.IOProject.Servers[i];
                                        deviceNode.Communication = serverComms[c];
                                        //挂载右键菜单
                                        deviceNode.ContextMenuStrip = Mediator.IOTreeForm.contextMenuStrip;
                                        deviceNode.InitNode();
                                        commNode.Nodes.Add(deviceNode);
                                        SetProgress();
                                    }
                                    SetProgress();
                                    serverNode.Nodes.Add(commNode);
                                }

                                mainNode.Nodes.Add(serverNode);
                                SetProgress();
                            }
                            mainNode.ExpandAll();
                            tree.Nodes.Add(mainNode);

                            EndProgress();
                        }
                        catch (Exception exm)
                        {
                            DisplyException(exm);
                            FrmDialog.ShowDialog(MainForm, exm.Message);
                            EndProgress();
                        }
                    }));
                }
            }
            else
            {
                try
                {
                    tree.Nodes.Clear();

                    int num = IOCenterManager.IOProject.Servers.Count + IOCenterManager.IOProject.Communications.Count + IOCenterManager.IOProject.Devices.Count;
                    TreeNode mainNode = new TreeNode();
                    mainNode.ImageIndex = 0;
                    mainNode.SelectedImageIndex = 0;
                    mainNode.Text = PubConstant.Product;
                    InitProgress(num);
                    ///加载采集站
                    for (int i = 0; i < IOCenterManager.IOProject.Servers.Count; i++)
                    {

                        IoServerTreeNode serverNode = new IoServerTreeNode();
                        serverNode.Server = IOCenterManager.IOProject.Servers[i];
                        serverNode.InitNode();
                        List<Scada.Model.IO_COMMUNICATION> serverComms = IOCenterManager.IOProject.Communications.FindAll(x => x.IO_SERVER_ID == IOCenterManager.IOProject.Servers[i].SERVER_ID);
                        for (int c = 0; c < serverComms.Count; c++)//通道
                        {
                            IoCommunicationTreeNode commNode = new IoCommunicationTreeNode();
                            commNode.Communication = serverComms[c];
                            commNode.Server = IOCenterManager.IOProject.Servers[i];
                            commNode.InitNode();
                            List<Scada.Model.IO_DEVICE> commDevices = IOCenterManager.IOProject.Devices.FindAll(x => x.IO_SERVER_ID == IOCenterManager.IOProject.Servers[i].SERVER_ID && x.IO_COMM_ID == serverComms[c].IO_COMM_ID);
                            for (int d = 0; d < commDevices.Count; d++)//设备
                            {
                                IoDeviceTreeNode deviceNode = new IoDeviceTreeNode();
                                deviceNode.Device = commDevices[d];
                                deviceNode.Server = IOCenterManager.IOProject.Servers[i];
                                deviceNode.Communication = serverComms[c];
                                //挂载右键菜单
                                deviceNode.ContextMenuStrip = Mediator.IOTreeForm.contextMenuStrip;
                                deviceNode.InitNode();
                                commNode.Nodes.Add(deviceNode);
                                SetProgress();
                            }
                            SetProgress();
                            serverNode.Nodes.Add(commNode);
                        }

                        mainNode.Nodes.Add(serverNode);
                        SetProgress();
                    }
                    mainNode.ExpandAll();
                    tree.Nodes.Add(mainNode);

                    EndProgress();
                }
                catch (Exception exm)
                {
                    DisplyException(exm);
                    FrmDialog.ShowDialog(MainForm, exm.Message);
                    EndProgress();
                }

            }

         
           
        }
        public   void LoadIOProject()
        {

                LoadIOProject(Mediator.IOTreeForm.ioTree);
        }

        #endregion
        #region 读取某个设备的实时值
        public   async void ReadRealDevice(Scada.Model.IO_SERVER server, Scada.Model.IO_COMMUNICATION communication, Scada.Model.IO_DEVICE device)
        {
            try
            {
                if (InfluxDbManager != null)
                {
                    var result = await InfluxDbManager.DbQuery_Real(server, communication, device);
                    if (result != null && result.Count() > 0)
                    {
                        Serie s = result.Last();
                        if (s != null && s.Values.Count > 0)
                        {
                            for (int i = 0; i < device.IOParas.Count; i++)
                            {
                                device.IOParas[i].IORealData = new Scada.IOStructure.IOData();
                            }
                            var values = s.Values[s.Values.Count - 1];
                            for (int i = 0; i < s.Columns.Count; i++)
                            {
                                if (s.Columns[i].Split('_')[0].ToLower() == "field")
                                {
                                    string paraname = s.Columns[i].Replace("field_", "").Replace("_value", "").Replace("_datetime", "").Replace("_qualitystamp", "");
                                    Scada.Model.IO_PARA para = device.IOParas.Find(x => x.IO_NAME.Trim().ToLower() == paraname.ToLower());
                                    if (para != null)
                                    {
                                        int length = s.Columns[i].Split('_').Length;
                                        if (s.Columns[i].Split('_')[length-1].ToLower() == "value")
                                        {
                                            para.IORealData.ParaValue = InfluxDbManager.GetInfluxdbValue(values[i]).ToString();
                                        }
                                        if (s.Columns[i].Split('_')[length - 1].ToLower() == "datetime")
                                        {
                                            para.IORealData.Date = Convert.ToDateTime(InfluxDbManager.GetInfluxdbValue(values[i]).ToString());
                                        }
                                        if (s.Columns[i].Split('_')[length - 1].ToLower() == "qualitystamp")
                                        {
                                            para.IORealData.QualityStamp = (QualityStamp)Enum.Parse(typeof(QualityStamp), InfluxDbManager.GetInfluxdbValue(values[i]).ToString());
                                        }
                                    }
                                }

                            }


                        }


                    }

                }
            }
            catch(Exception emx)
            {
                AddLog("ERROR=50001" + emx.Message);
            }

         
        }

        #endregion
        #region 读取某个设备的指定时间段的历史数据
        public async Task<InfluxDBHistoryData>   ReadHistoryDevice(Scada.Model.IO_SERVER server, Scada.Model.IO_COMMUNICATION communication, Scada.Model.IO_DEVICE device,DateTime SDate, DateTime EDate,int PageSize,int PageIndex)
        {
            if (InfluxDbManager != null)
            {
                var result = await InfluxDbManager.DbQuery_History(server, communication, device,SDate, EDate, PageSize, PageIndex);

                return result;

            }
            return null;

        }

        #endregion
        #region 读取某个设备的指定时间段的统计数据
        public async Task<InfluxDBHistoryData> ReadHistoryStaticsDevice(Scada.Model.IO_SERVER server, Scada.Model.IO_COMMUNICATION communication, Scada.Model.IO_DEVICE device, DateTime SDate, DateTime EDate, int PageSize, int PageIndex,string selected,string timespan )
        {
            if (InfluxDbManager != null)
            {
                var result = await InfluxDbManager.DbQuery_HistoryStatics(server, communication, device, SDate, EDate, PageSize, PageIndex, selected, timespan);

                return result;

            }
            return null;

        }

        #endregion
        #region 读取某个设备的指定时间段的报警
        public async Task<InfluxDBHistoryData> ReadHistoryAlarmDevice(Scada.Model.IO_SERVER server, Scada.Model.IO_COMMUNICATION communication, Scada.Model.IO_DEVICE device, DateTime SDate, DateTime EDate,string AlarmType, string AlarmLevel,int PageSize, int PageIndex)
        {
            if (InfluxDbManager != null)
            {
                var result = await InfluxDbManager.DbQuery_Alarms(server, communication, device, SDate, EDate, AlarmType, AlarmLevel,PageSize, PageIndex);

                return result;

            }
            return null;

        }

        #endregion
        #region 读取某个设备的指定时间段的下置结果
        public async Task<InfluxDBHistoryData> ReadHistoryCommandsDevice(Scada.Model.IO_SERVER server, Scada.Model.IO_COMMUNICATION communication, Scada.Model.IO_DEVICE device, DateTime SDate, DateTime EDate,int PageSize, int PageIndex)
        {
            if (InfluxDbManager != null)
            {
                var result = await InfluxDbManager.DbQuery_Commands(server, communication, device, SDate, EDate, PageSize, PageIndex);

                return result;

            }
            return null;

        }

        #endregion
        #region 读取某个设备的指定时间段的用户修改报警配置的信息
        public async Task<InfluxDBHistoryData> ReadHistoryAlarmConfigsDevice(Scada.Model.IO_SERVER server, Scada.Model.IO_COMMUNICATION communication, Scada.Model.IO_DEVICE device, DateTime SDate, DateTime EDate, int PageSize, int PageIndex)
        {
            if (InfluxDbManager != null)
            {
                var result = await InfluxDbManager.DbQuery_AlarmConfigs(server, communication, device, SDate, EDate, PageSize, PageIndex);

                return result;

            }
            return null;

        }

        #endregion
        #region 读取数据库备份日志
        public async Task<InfluxDBHistoryData> ReadBackupHistory(int PageSize, int PageIndex)
        {
            if (InfluxDbManager != null)
            {
                var result = await InfluxDbManager.DbQuery_Backup( PageSize, PageIndex);

                return result;

            }
            return null;

        }

        #endregion
    }
}
