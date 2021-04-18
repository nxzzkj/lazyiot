
using Scada.Controls.Forms;
using ScadaCenterServer.Controls;
using ScadaCenterServer.Core;
using ScadaCenterServer.Pages;
using Scada.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;

namespace ScadaCenterServer
{

    public partial class IOCenterMainForm : FrmWithTitle
    {

        public IOCenterMainForm()
        {
            InitializeComponent();

            this.Load += MainForm_Load;
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private bool isAuto = false;
        private string User = "";
        private string Password = "";
        public IOCenterMainForm(string user, string password)
        {
            InitializeComponent();

            this.Load += MainForm_Load;
            Control.CheckForIllegalCrossThreadCalls = false;
            User = user;
            Password = password;
            runBackMenu.Checked = IOCenterManager.IsBackRun;
            runBackToolMenu.Checked = IOCenterManager.IsBackRun;
        }

        private   void MainForm_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            timerDate.Start();
            IOCenterManager.InitIOCenterManager();
              IOCenterManager.QueryFormManager.InitQueryForm(this);
            if (isAuto)
            {
                  IOCenterManager.LoadAll();
            }
            else
            {
                LoginForm login = new LoginForm();
                if (login.ShowDialog() == DialogResult.OK)
                {
                      IOCenterManager.LoadAll();
                }
                else
                {
                    if (IOCenterManager.QueryFormManager != null)
                    {
                          IOCenterManager.QueryFormManager.CloseInfluxDBServer();

                    }
                    IOCenterManager.Close();

                    Application.Exit();
                    Application.ExitThread();
                }
            }




        }

        public override void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;

        }




        private void 系统管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
        }


        private   void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmDialog.ShowDialog(this, "是否要退出数据中心服务", "退出系统", true, true, true, true) == DialogResult.OK)
            {
       
                  IOCenterManager.QueryFormManager.CloseInfluxDBServer();
                IOCenterManager.Close();
               
                Application.ExitThread();
                Application.Exit();
                Process[] pross = Process.GetProcessesByName(Application.ProductName);
                if (pross.Length > 0)
                {
                    pross[0].Kill();
                }

            }

        }

        private   void 模拟器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IOCenterManager.SimulatorManager != null )
            IOCenterManager.SimulatorManager.ShowSimulator();
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void IOCenterMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        //用户启动服务


        private   void 启动服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {



                IOCenterManager.TCPServer.ServerForm.btStart_Click(sender, e);
                启动服务ToolStripMenuItem.Enabled = false;
                停止服务toolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                FrmDialog.ShowDialog(this, ex.Message);
                Scada.Logger.Logger.GetInstance().Debug(ex.Message);
            }

        }

        private   void 停止服务toolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                IOCenterManager.TCPServer.ServerForm.btClose_Click(sender, e);
                启动服务ToolStripMenuItem.Enabled = true;
                停止服务toolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                FrmDialog.ShowDialog(this, ex.Message);
                Scada.Logger.Logger.GetInstance().Debug(ex.Message);
            }
        }

        private void 监视器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOCenterManager.TCPServer.ServerForm.Visible = true;
        }
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOCenterMainForm));
        private void timerDate_Tick(object sender, EventArgs e)
        {
            labelDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (IOCenterManager.TCPServer.TcpServerStatus == TcpServerStatus.运行)
            {
                if (this.notifyIcon.Tag == null)
                    this.notifyIcon.Tag = 0;
                if (this.notifyIcon.Tag.ToString() == "1")
                {
                    this.notifyIcon.Tag = 0;
                    this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
                }

                else
                {
                    this.notifyIcon.Tag = 1;
                    this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                }


            }
            else
            {
                this.notifyIcon.Tag = 0;
                this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            }

        }

        private   void 实时库配置toolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOCenterManager.QueryFormManager.Mediator.OpenInfluxConfigForm();
        }

        private void 实时数据查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOCenterManager.QueryFormManager.Mediator.OpenRealQueryWorkForm();
        }

        private void 历史数据查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOCenterManager.QueryFormManager.Mediator.OpenHistoryQueryWorkForm();
        }

        private void 历史报警查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOCenterManager.QueryFormManager.Mediator.OpenHistoryAlarmQueryWorkForm();
        }

        private void 下置命令查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOCenterManager.QueryFormManager.Mediator.OpenSendCommandQueryWorkForm();
        }

        private void 报警配置日志toolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOCenterManager.QueryFormManager.Mediator.OpenAlarmConfigQueryWorkForm();
        }

        private void iO树ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IOCenterManager.QueryFormManager.Mediator.IOTreeForm.DockState == DockState.Hidden)
            {
                IOCenterManager.QueryFormManager.Mediator.IOTreeForm.DockState = Scada.Controls.DockState.DockLeft;
            }
            else
            {
                IOCenterManager.QueryFormManager.Mediator.IOTreeForm.DockState = Scada.Controls.DockState.Hidden;
            }

        }

        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IOCenterManager.QueryFormManager.Mediator.IOPropeitesForm.DockState == Scada.Controls.DockState.Hidden)
            {
                IOCenterManager.QueryFormManager.Mediator.IOPropeitesForm.DockState = Scada.Controls.DockState.DockLeft;
            }
            else
            {
                IOCenterManager.QueryFormManager.Mediator.IOPropeitesForm.DockState = Scada.Controls.DockState.Hidden;
            }
        }

        private void 日志窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (IOCenterManager.QueryFormManager.Mediator.OperatorLogForm.DockState == Scada.Controls.DockState.Hidden)
            {
                IOCenterManager.QueryFormManager.Mediator.OperatorLogForm.DockState = Scada.Controls.DockState.DockLeft;
            }
            else
            {
                IOCenterManager.QueryFormManager.Mediator.OperatorLogForm.DockState = Scada.Controls.DockState.Hidden;
            }
        }

        private void 关闭ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void 统计汇总查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOCenterManager.QueryFormManager.Mediator.OpenHistoryStaticsQueryWorkForm();
        }

        private void 备份管理toolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOCenterManager.QueryFormManager.Mediator.OpenInfluxDBBackupForm();
        }

        private void 网络设置toolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetConfigForm form = new NetConfigForm();
            form.ShowDialog(this);
        }

        private void 账户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserAccountForm form = new UserAccountForm();
            form.ShowDialog(this);
        }

        private void 关于我们ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> sb = new List<string>();
            OpenFileDialog dig = new OpenFileDialog();
            if (dig.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(dig.FileName, Encoding.Default);
                while (!sr.EndOfStream)
                {
                    sb.Add(sr.ReadLine());
                }
                sr.Close();
                foreach (string sql in sb)
                {
                  string  sql2 = sql.Replace(";", "");
                    if (sql2 != "")
                        DbHelperSQLite.ExecuteSql(sql2);
                }
                MessageBox.Show(this,"保存成功");

            }
        }

        private void 流程图管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOServerAdminForm form = new IOServerAdminForm();
            if(form.ShowDialog(this)==DialogResult.OK)
            {

            }

        }

        private void 消息队列配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
       


        }

        private   void 退出系统ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (FrmDialog.ShowDialog(this, "是否要退出数据中心服务", "退出系统", true, true, true, true) == DialogResult.OK)
            {

                  IOCenterManager.QueryFormManager.CloseInfluxDBServer();
                IOCenterManager.Close();

                Application.ExitThread();
                Application.Exit();
                Process[] pross = Process.GetProcessesByName(Application.ProductName);
                for(int i=0;i< pross.Length;i++)
                {
                    pross[i].Kill();
                }
                
            }

        }

        private void runBackMenu_Click(object sender, EventArgs e)
        {
            runBackMenu.Checked = !runBackMenu.Checked;
            IOCenterManager.IsBackRun = runBackMenu.Checked;
            runBackToolMenu.Checked = runBackMenu.Checked;
        }

        private void runBackToolMenu_Click(object sender, EventArgs e)
        {
            runBackToolMenu.Checked = !runBackToolMenu.Checked;
            IOCenterManager.IsBackRun = runBackToolMenu.Checked;
            runBackMenu.Checked = runBackToolMenu.Checked;
        }
    }
}
