using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;
using System.IO;

namespace Scada.Controls.Controls
{
    public partial class ComputerInfoControl : UserControl
    {
        public ComputerInfoControl()
        {
            InitializeComponent();
            this.Load += ComputerInfoControl_Load;
        }
        public string ProgramName = "";

        private void ComputerInfoControl_Load(object sender, EventArgs e)
        {
         



        }
        public void Monitour()
        {
            try
            {
                mComputerInfo = ComputerInfo.GetInstall();
                this.labelComputer.Text = mComputerInfo.ComputerName;
                this.labelIP.Text = mComputerInfo.IP;
                this.labelMAC.Text = mComputerInfo.MAC;
                this.labelPSize.Text = decimal.Round(Convert.ToDecimal(mComputerInfo.PhysicalMemory / (1024.0d * 1024.0d * 1024.0d)), 1).ToString() + "G";



                timerProcess.Start();
            }
            catch
            { }
        }

        private ComputerInfo mComputerInfo = null;

        private void timerProcess_Tick(object sender, EventArgs e)
        {
            ProgramName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            if (ProgramName!="")
            {
                ///应用程序信息
                ProcessInfo process = mComputerInfo.GetProcessInfo(ProgramName);
                if(process!=null)
                {
                    try
                    {
                        this.label1Process_StartTime.Text = process.StartTime;
                        this.labelProcess_CPU.Text = process.CpuRate.ToString("0.00") + "%";
                        this.labelProcess_Name.Text = process.ProcessName;
                        this.labelProcess_PSize.Text = Convert.ToDecimal(process.WorkingSet64 / (1024.0f * 1024.0f * 1024.0f)).ToString("0.0") + "G";
                        this.labelTCount.Text = process.ThreadsCount.ToString();
                       this.labelProcess_TotalTime.Text = process.TotalProcessorTime + "h";
                       
                        this.ucMeterCpu.ucMeter.Value = Convert.ToDecimal(process.CpuRate);
                        this.ucMeterCpu.ucMeter.MinValue = 0;
                        this.ucMeterCpu.ucMeter.MaxValue = 100;

                        this.ucMeterPhysicalMemory.ucMeter.Value = Convert.ToDecimal(process.WorkingSet64 / (1024.0f * 1024.0f * 1024.0f));
                        this.ucMeterPhysicalMemory.ucMeter.MinValue = 0;
                        this.ucMeterPhysicalMemory.ucMeter.MaxValue =100;

 
                    }
                    catch { }
                }

            }
   
        }
    }
}
