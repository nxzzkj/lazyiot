using Scada.Business;
using IOMonitor.Core;

using Scada.Controls;
using Scada.Controls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;
using System.Diagnostics;
using IOMonitor.Forms;

namespace IOMonitor
{
    public partial class MonitorForm : FrmWithTitle
    {
 
        public MonitorForm()
        {
            InitializeComponent();
            this.Load += MonitorForm_Load;
            Control.CheckForIllegalCrossThreadCalls = false;

        }
        public Mediator mediator = null;
        private   void MonitorForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = PubConstant.Product;
            timer.Start();
            
            DbHelperSQLite.connectionString = "Data Source=" + Application.StartupPath + "\\IOProject\\Station.station";
          
            btnClose.Location = new Point(this.Width - btnClose.Width, btnClose.Location.Y);
            btMin.Location = new Point(this.Width - btnClose.Width - btMin.Width - 4, btnClose.Location.Y);
            btMax.Location = new Point(this.Width - btnClose.Width - btMin.Width - btMax.Width - 6, btnClose.Location.Y);
             
            try
            {
                 runBakcMenu.Checked= IOMonitorManager.IsBackRun;
                runBackToolMenu.Checked= IOMonitorManager.IsBackRun;
                MonitorFormManager.InitMonitorMainForm(this);

                IOMonitorManager.OnMonitorException += MonitorManager_OnMonitorException;
         

                IOMonitorManager.OnMonitorReceive += IOMonitorManager_OnMonitorReceive;




            }
            catch (Exception ex)
            {
               MonitorFormManager.AppendLogItem(ex.Message);
            }
        }

        private   void IOMonitorManager_OnMonitorReceive(Scada.Model.IO_SERVER server, Scada.Model.IO_COMMUNICATION comm, Scada.Model.IO_DEVICE device, byte[] sourceBytes)
        {
              MonitorFormManager.MonitorIODataShowView(server, comm, device);
        }



        //采集服务器操作返回事件




        //写入之日
        private   void MonitorManager_OnMonitorLog(string log)
        {
             MonitorFormManager.AppendLogItem(log);
        }
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="ex"></param>

        private    void MonitorManager_OnMonitorException(Exception ex)
        {
              MonitorFormManager.AppendLogItem(ex.Message);
        }

        public override void btnClose_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

      

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private   void 退出采集站ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "是否要退出IO采集站，退出后设备将无法获取传输数据!", "退出提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
           
                MonitorFormManager.ApplicationExit();
            
            }


        }

        private void 打卡监视器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel5.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
        }

        private void 采集工程管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process ioMonitor = Process.Start(Application.StartupPath + "//IOManager.exe");
        }

        private void btMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private   void 采集站模拟器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimulatorForm simulatorForm = new SimulatorForm();
            simulatorForm.Show(this);
            


        }

        private void 采集站编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "//IOMonitor.exe");
        }

        private void 网络配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetConfigForm form = new NetConfigForm();
            form.ShowDialog(this);
        }

        private void 正常窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private   void 停止服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(this,"是否要停止数据采集?","操作提示",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                  IOMonitorManager.Stop();
            }
        }

        private   void 启动服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "是否要启动数据采集服务?", "操作提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                 IOMonitorManager.Start();
            }
        }

        private void MonitorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;

        }

        private void runBakcMenu_Click(object sender, EventArgs e)
        {
            runBakcMenu.Checked = !runBakcMenu.Checked;
            IOMonitorManager.IsBackRun = runBakcMenu.Checked;
            runBackToolMenu.Checked = runBakcMenu.Checked;
        }

        private void runBackToolMenu_Click(object sender, EventArgs e)
        {
            runBackToolMenu.Checked = !runBackToolMenu.Checked;
            IOMonitorManager.IsBackRun = runBackToolMenu.Checked;
            runBakcMenu.Checked = runBackToolMenu.Checked;
        }
    }
}
