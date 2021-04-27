using Scada.Business;

using Scada.Controls;
using Scada.Controls.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;
using IOMonitor.Controls;
using IOMonitor.Forms;
using System.Windows.Threading;
using Scada.Controls.Forms;
using System.Diagnostics;

namespace IOMonitor.Core
{
    /// <summary>
    /// 系统管理类
    /// </summary>
    public abstract  class MonitorFormManager
    {/// <summary>
     /// 模拟器
     /// </summary>
      
       
        #region 属性
        private static MonitorForm mForm = null;
        /// <summary>
        /// 系统服务
        /// </summary>
        public static IOMonitorManager MonitorManager = null;
        public static MonitorForm MainForm
        {
            set
            {
                mForm = value;
                mediator = value.mediator;

            }
            get { return mForm; }
        }

        public static Mediator mediator = null;


        #endregion
        #region 初始化窗体信息
        public static void InitMonitorMainForm(MonitorForm form)
        {
            ControlHelper.FreezeControl(form, true);
            MainForm = form;
            mediator = new Mediator(form);
            mediator.DockPanel = form.dockPanel;
            mediator.parent = form;
            mediator = new Mediator(form);
            mediator.DockPanel = form.dockPanel;

            //读取发布工程的数据库          
            form.WindowState = FormWindowState.Maximized;
            form.FormClosed += Form_FormClosed;
            mediator.OpenLogForm();
       
            mediator.OpenIOStatusForm();
            mediator.OpenIOPropertiesForm();
            mediator.OpenIOMonitorForm();

            //加载IO树
            mediator.IOStatusForm.LoadTreeStatus();

            //开启日志功能
            Scada.Logger.Logger.GetInstance().Run();
            //将系统监视的事件和日志输出到日志窗体
            IOMonitorManager.OnMonitorException += Monitor_ExceptionHanped;
            IOMonitorManager.OnMonitorLog += IOMonitor_MakeLog;
          
            MonitorDataBaseModel.OnDataBaseExceptionHanped += Monitor_ExceptionHanped;
            MonitorDataBaseModel.OnDataBaseLoged += IOMonitor_MakeLog;

        }

    


        #region 日志输出到主日志界面上

        private static void Monitor_ExceptionHanped(Exception ex)
        {
            AppendLogItem(ex.Message);
            Scada.Logger.Logger.GetInstance().Debug(ex.Message);
        }
  
        private static void IOMonitor_MakeLog(string msg)
        {
            AppendLogItem(msg);
            Scada.Logger.Logger.GetInstance().Info(msg);
        }
        #endregion

        private static   void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
             ApplicationExit();
        }




        /// <summary>
        /// 刷新树状态
        /// </summary>
        public static void RefreshIOStatus(Scada.Model.IO_DEVICE device)
        {
            if (device == null)
                return;
            if (mediator.IOStatusForm.IsHandleCreated)
            {
                mediator.IOStatusForm.IoTreeStatus.BeginInvoke(new EventHandler(delegate
                {
                    

                    if(mediator.IOStatusForm.IoTreeStatus.Nodes.Find(device.IO_DEVICE_ID, true).Length>0)
                    {
                        IoDeviceTreeNode treeNode = (IoDeviceTreeNode)mediator.IOStatusForm.IoTreeStatus.Nodes.Find(device.IO_DEVICE_ID, true).First();
                        treeNode.ChangedStatus(device.IO_DEVICE_STATUS);
                    }
                
                   
                }));
            }
        }

        //功能树点击事件

        #endregion
        #region 异常处理
        /// <summary>
        /// 异常信息在日志端显示
        /// </summary>
        /// <param name="ex"></param>
        public static  void DisplyException(Exception ex)
        {

            Scada.Logger.Logger.GetInstance().Debug(ex.Message);
        }
        

        #endregion
        #region 主窗体进度条
        /// <summary>
        /// 初始化进度条
        /// </summary>
        /// <param name="MaxValue"></param>
        public static void InitProgress(int MaxValue)
        {

            MainForm.ProgressBar.Value = 0;
            MainForm.ProgressBar.Maximum = MaxValue;
            MainForm.ProgressBar.Text = "";
        }
        public static void EndProgress()
        {

            MainForm.ProgressBar.Value = 0;
            MainForm.ProgressBar.Maximum = 100;
            MainForm.ProgressBar.Text = "";
        }
        /// <summary>
        /// 进度
        /// </summary>
        public static void SetProgress()
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
        #region 发布工程管理

        public static void  LoadProject(TreeView tree)
        {



            AppendLogItem("正在加载采集站工程......");
             MonitorDataBaseModel.InitBaseModel();
            AppendLogItem("正在加载驱动信息......");
            IOMonitorManager.InitMonitor();
            AppendLogItem("正在加载IO树......");

              Task.Run(() =>
              {
                 try
                 {
                      if (tree.Parent.IsHandleCreated)
                      {

                          tree.BeginInvoke(new EventHandler(delegate
                          {



                              tree.Nodes.Clear();

                              int num = MonitorDataBaseModel.IOCommunications.Count * MonitorDataBaseModel.IODevices.Count;

                              InitProgress(num);


                              IoServerTreeNode serverNode = new IoServerTreeNode();
                              serverNode.Server = MonitorDataBaseModel.IOServer;
                              serverNode.InitNode();
                              List<Scada.Model.IO_COMMUNICATION> serverComms = MonitorDataBaseModel.IOCommunications.FindAll(x => x.IO_SERVER_ID == MonitorDataBaseModel.IOServer.SERVER_ID);
                              for (int c = 0; c < serverComms.Count; c++)//通道
                              {
                                  IoCommunicationTreeNode commNode = new IoCommunicationTreeNode();
                                  commNode.Communication = serverComms[c];
                                  commNode.Server = MonitorDataBaseModel.IOServer;
                                  commNode.InitNode();
                                  List<Scada.Model.IO_DEVICE> commDevices = MonitorDataBaseModel.IODevices.FindAll(x => x.IO_SERVER_ID == MonitorDataBaseModel.IOServer.SERVER_ID && x.IO_COMM_ID == serverComms[c].IO_COMM_ID);
                                  for (int d = 0; d < commDevices.Count; d++)//设备
                                  {
                                      IoDeviceTreeNode deviceNode = new IoDeviceTreeNode();
                                      deviceNode.Device = commDevices[d];
                                      deviceNode.Server = MonitorDataBaseModel.IOServer;
                                      deviceNode.Communication = serverComms[c];
                                      deviceNode.InitNode();
                                      commNode.Nodes.Add(deviceNode);
                                      SetProgress();
                                  }
                                  SetProgress();
                                  serverNode.Nodes.Add(commNode);
                              }


                              serverNode.Expand();

                              EndProgress();
                              tree.Nodes.Add(serverNode);
                         
                             
                          }));
                      }

                 }
                 catch (Exception exm)
                 {
                     DisplyException(exm);
                     FrmDialog.ShowDialog(MainForm, exm.Message);
                     EndProgress();
                 }
           
        });
        }

     

        #endregion
        #region 进度加载窗体
  
        
      

        #endregion
        //写入操作和异常错误等日志
        public static   void  AppendLogItem(string msg)
        {
            if (mediator == null)
                return;
             mediator.IOMonitorLogForm.AppendLogItem(msg);
            Scada.Logger.Logger.GetInstance().Info(msg);
            
        }
        public static void AppendSendCommand(Scada.Model.IO_SERVER server, Scada.Model.IO_COMMUNICATION communication, Scada.Model.IO_DEVICE device, Scada.Model.IO_PARA para, Scada.Model.IO_COMMANDS command)
        {
            if (mediator == null)
                return;
            mediator.IOMonitorForm.InsertMonitorCommandListView(server, communication, device, para,command);
            Scada.Logger.Logger.GetInstance().Info(command.GetCommandString());

        }
        /// <summary>
        /// 显示最近产生的报警
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>

        #region 加载IO属性
        public static void SetIOPara(Scada.Model.IO_SERVER server, Scada.Model.IO_COMMUNICATION comm, Scada.Model.IO_DEVICE device, Scada.Model.IO_PARA  para)
        {
            if (mediator.IOMonitorForm.IsHandleCreated)
            {
                mediator.IOMonitorForm.BeginInvoke(new EventHandler(delegate
            {
                mediator.IOPropertiesForm.SetPara(server, comm, device, para);
            }));
            }
        }

        #endregion
        #region 采集站采集数据实时显示

        public static   void  MonitorIODataShowView(Scada.Model.IO_SERVER server, Scada.Model.IO_COMMUNICATION comm, Scada.Model.IO_DEVICE device)
        {
            if (mediator.IOMonitorForm.IsHandleCreated)
            {
                mediator.IOMonitorForm.BeginInvoke(new EventHandler(delegate
            {
                if (mediator.IOMonitorForm.Device != null && mediator.IOMonitorForm.Device.IO_COMM_ID == device.IO_COMM_ID && mediator.IOMonitorForm.Device.IO_DEVICE_ID == device.IO_DEVICE_ID && mediator.IOMonitorForm.Device.IO_SERVER_ID == device.IO_SERVER_ID)
                {
                    mediator.IOMonitorForm.SetIOValue(server, comm, device);
                }

                //清空接收的数据
                device.ClearCollectDatas();
            }));
            }
        }
        /// <summary>
        /// 显示上传到数据中心结果日志的显示
        /// </summary>
        /// <param name="server"></param>
        /// <param name="communication"></param>
        /// <param name="device"></param>
        /// <param name="uploadresult"></param>
        public static void ShowMonitorUploadListView(Scada.Model.IO_SERVER server, Scada.Model.IO_COMMUNICATION communication, Scada.Model.IO_DEVICE device, string uploadresult)
        {
            if (mediator.IOMonitorForm.IsHandleCreated)
            {
                
                    mediator.IOMonitorForm.ShowMonitorUploadListView(server, communication, device, uploadresult);

              
            }
        }
        #endregion
        #region 退出系统采集
        public static   void  ApplicationExit()
        {
            try
            {
                GC.Collect();
                  IOMonitorManager.Stop();
                  IOMonitorManager.Close();
                Application.ExitThread();
                Application.Exit();
                Process[] pross = Process.GetProcessesByName(Application.ProductName);
                for (int i = 0; i < pross.Length; i++)
                {
                    pross[i].Kill();
                }
            }
            catch
            {

            }
        }
        #endregion


    }
}
