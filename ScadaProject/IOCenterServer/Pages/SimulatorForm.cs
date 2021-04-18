using Scada.Controls.Forms;
using ScadaCenterServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;

namespace ScadaCenterServer.Pages
{
    public partial class SimulatorForm : FrmWithTitle
    {
     
        public SimulatorForm()
        {
            InitializeComponent();
            this.Load += SimulatorForm_Load;
        }
        public override void btnClose_Click(object sender, EventArgs e)
        {
            if(FrmDialog.ShowDialog(this,"是否要退出模拟器","提醒",true,true,true,true)==DialogResult.OK)
            {
            
      
                this.Close();
            }
        }
        public bool IsCustomTimer
        {
            get {

                return ucRadioCustom.Checked == true ? ucRadioCustom.Checked : ucRadioDevice.Checked;
            }
        }
        private bool mEnableTool = true;
        public bool EnableTool
        {
            set { mEnableTool = value;
                ucNumTextBoxTime.Enabled = value;
                ucRadioCustom.Enabled = value;
                ucRadioDevice.Enabled = value;
            }
            get { return mEnableTool; }
        }

        public int Interval
        {
            get { return Convert.ToInt32(ucNumTextBoxTime.Num); }
        }
        private void SimulatorForm_Load(object sender, EventArgs e)
        {
            this.computerInfoControl.Monitour();
           
        }
        

      
        public void AddLog(string msg)
        {
            if (uccbShowReport.Checked)
            {


                this.BeginInvoke(new EventHandler(delegate
                {
                    ListViewItem lvi = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    lvi.SubItems.Add(msg);
                    listView.Items.Insert(0, lvi);

                    if (this.listView.Items.Count > 100)
                    {
                        this.listView.Items.RemoveAt(this.listView.Items.Count - 1);
                    }

                }));
            }
            Scada.Logger.Logger.GetInstance().Info(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + msg);
        }

  

        private void SimulatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IOCenterManager.SimulatorManager.ColseSimulator();
 
        }

        private void ucSwitch_Click(object sender, EventArgs e)
        {
            if (ucSwitch.Checked)
            {
                if (FrmDialog.ShowDialog(this, "是否要启动模拟器,启动后系统会随机向数据中心传送255内的数字，该模块主要检测大批量IO下采集站服务器压力情况", "提示", true, true, true, true) == DialogResult.OK)
                {
                    IOCenterManager.SimulatorManager.StartSimulator();
                    ucSwitch.Checked = true;
                    IOCenterManager.SimulatorManager.IsMakeAlarm = ucSwitch.Checked;
                }
                else
                {
                    ucSwitch.Checked = false;
                }
            }
            else
            {
                if (FrmDialog.ShowDialog(this, "是否要停止模拟器运行", "提示", true, true, true, true) == DialogResult.OK)
                {
                    ucSwitch.Checked = false;
                    IOCenterManager.SimulatorManager.ColseSimulator();
                }
                else
                {
                    ucSwitch.Checked = true;
                }
            }
        }
    }
}
