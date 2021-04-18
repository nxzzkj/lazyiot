namespace Scada.Controls.Controls
{
    partial class ComputerInfoControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.labelProcess_CPU = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1Process_StartTime = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelProcess_TotalTime = new System.Windows.Forms.Label();
            this.labelProcess_PSize = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTCount = new System.Windows.Forms.Label();
            this.labelPSize = new System.Windows.Forms.Label();
            this.labelIP = new System.Windows.Forms.Label();
            this.labelMAC = new System.Windows.Forms.Label();
            this.labelComputer = new System.Windows.Forms.Label();
            this.labelProcess_Name = new System.Windows.Forms.Label();
            this.timerProcess = new System.Windows.Forms.Timer(this.components);
            this.ucMeterPhysicalMemory = new Scada.Controls.Controls.FactoryControls.Meter.UCMeterEx();
            this.ucMeterCpu = new Scada.Controls.Controls.FactoryControls.Meter.UCMeterEx();
            this.ucSplitLine_H1 = new Scada.Controls.Controls.UCSplitLine_H();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucSplitLine_H1);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.labelProcess_CPU);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.labelTCount);
            this.groupBox1.Controls.Add(this.label1Process_StartTime);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.labelProcess_TotalTime);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelPSize);
            this.groupBox1.Controls.Add(this.labelIP);
            this.groupBox1.Controls.Add(this.labelMAC);
            this.groupBox1.Controls.Add(this.labelComputer);
            this.groupBox1.Controls.Add(this.labelProcess_Name);
            this.groupBox1.Controls.Add(this.labelProcess_PSize);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 253);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器信息";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.Navy;
            this.label17.Location = new System.Drawing.Point(18, 208);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 19);
            this.label17.TabIndex = 22;
            this.label17.Text = "CPU应用:";
            // 
            // labelProcess_CPU
            // 
            this.labelProcess_CPU.AutoSize = true;
            this.labelProcess_CPU.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelProcess_CPU.ForeColor = System.Drawing.Color.Red;
            this.labelProcess_CPU.Location = new System.Drawing.Point(87, 208);
            this.labelProcess_CPU.Name = "labelProcess_CPU";
            this.labelProcess_CPU.Size = new System.Drawing.Size(67, 19);
            this.labelProcess_CPU.TabIndex = 23;
            this.labelProcess_CPU.Text = " ---------";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(18, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 19);
            this.label11.TabIndex = 16;
            this.label11.Text = "开始时间:";
            // 
            // label1Process_StartTime
            // 
            this.label1Process_StartTime.AutoSize = true;
            this.label1Process_StartTime.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1Process_StartTime.ForeColor = System.Drawing.Color.Red;
            this.label1Process_StartTime.Location = new System.Drawing.Point(87, 143);
            this.label1Process_StartTime.Name = "label1Process_StartTime";
            this.label1Process_StartTime.Size = new System.Drawing.Size(67, 19);
            this.label1Process_StartTime.TabIndex = 17;
            this.label1Process_StartTime.Text = " ---------";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(18, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 19);
            this.label9.TabIndex = 14;
            this.label9.Text = "运行时间:";
            // 
            // labelProcess_TotalTime
            // 
            this.labelProcess_TotalTime.AutoSize = true;
            this.labelProcess_TotalTime.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelProcess_TotalTime.ForeColor = System.Drawing.Color.Red;
            this.labelProcess_TotalTime.Location = new System.Drawing.Point(87, 165);
            this.labelProcess_TotalTime.Name = "labelProcess_TotalTime";
            this.labelProcess_TotalTime.Size = new System.Drawing.Size(67, 19);
            this.labelProcess_TotalTime.TabIndex = 15;
            this.labelProcess_TotalTime.Text = " ---------";
            // 
            // labelProcess_PSize
            // 
            this.labelProcess_PSize.AutoSize = true;
            this.labelProcess_PSize.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelProcess_PSize.ForeColor = System.Drawing.Color.Red;
            this.labelProcess_PSize.Location = new System.Drawing.Point(87, 187);
            this.labelProcess_PSize.Name = "labelProcess_PSize";
            this.labelProcess_PSize.Size = new System.Drawing.Size(67, 19);
            this.labelProcess_PSize.TabIndex = 19;
            this.labelProcess_PSize.Text = " ---------";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(18, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 19);
            this.label8.TabIndex = 12;
            this.label8.Text = "应用程序:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(18, 187);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 19);
            this.label13.TabIndex = 18;
            this.label13.Text = "物理内存:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(7, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 19);
            this.label7.TabIndex = 5;
            this.label7.Text = "程序总线程:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(18, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "物理内存:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(31, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "IP地址:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "MAC地址:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器名称:";
            // 
            // labelTCount
            // 
            this.labelTCount.AutoSize = true;
            this.labelTCount.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTCount.ForeColor = System.Drawing.Color.Red;
            this.labelTCount.Location = new System.Drawing.Point(87, 227);
            this.labelTCount.Name = "labelTCount";
            this.labelTCount.Size = new System.Drawing.Size(67, 19);
            this.labelTCount.TabIndex = 11;
            this.labelTCount.Text = " ---------";
            // 
            // labelPSize
            // 
            this.labelPSize.AutoSize = true;
            this.labelPSize.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPSize.ForeColor = System.Drawing.Color.Red;
            this.labelPSize.Location = new System.Drawing.Point(85, 91);
            this.labelPSize.Name = "labelPSize";
            this.labelPSize.Size = new System.Drawing.Size(67, 19);
            this.labelPSize.TabIndex = 9;
            this.labelPSize.Text = " ---------";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelIP.ForeColor = System.Drawing.Color.Red;
            this.labelIP.Location = new System.Drawing.Point(85, 69);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(67, 19);
            this.labelIP.TabIndex = 8;
            this.labelIP.Text = " ---------";
            // 
            // labelMAC
            // 
            this.labelMAC.AutoSize = true;
            this.labelMAC.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMAC.ForeColor = System.Drawing.Color.Red;
            this.labelMAC.Location = new System.Drawing.Point(85, 49);
            this.labelMAC.Name = "labelMAC";
            this.labelMAC.Size = new System.Drawing.Size(67, 19);
            this.labelMAC.TabIndex = 7;
            this.labelMAC.Text = " ---------";
            // 
            // labelComputer
            // 
            this.labelComputer.AutoSize = true;
            this.labelComputer.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelComputer.ForeColor = System.Drawing.Color.Red;
            this.labelComputer.Location = new System.Drawing.Point(85, 29);
            this.labelComputer.Name = "labelComputer";
            this.labelComputer.Size = new System.Drawing.Size(67, 19);
            this.labelComputer.TabIndex = 6;
            this.labelComputer.Text = " ---------";
            // 
            // labelProcess_Name
            // 
            this.labelProcess_Name.AutoSize = true;
            this.labelProcess_Name.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelProcess_Name.ForeColor = System.Drawing.Color.Red;
            this.labelProcess_Name.Location = new System.Drawing.Point(87, 125);
            this.labelProcess_Name.Name = "labelProcess_Name";
            this.labelProcess_Name.Size = new System.Drawing.Size(67, 19);
            this.labelProcess_Name.TabIndex = 13;
            this.labelProcess_Name.Text = " ---------";
            // 
            // timerProcess
            // 
            this.timerProcess.Interval = 1000;
            this.timerProcess.Tick += new System.EventHandler(this.timerProcess_Tick);
            // 
            // ucMeterPhysicalMemory
            // 
            this.ucMeterPhysicalMemory.Location = new System.Drawing.Point(0, 460);
            this.ucMeterPhysicalMemory.Name = "ucMeterPhysicalMemory";
            this.ucMeterPhysicalMemory.Size = new System.Drawing.Size(199, 207);
            this.ucMeterPhysicalMemory.TabIndex = 17;
            this.ucMeterPhysicalMemory.Title = "物理内存占比";
            // 
            // ucMeterCpu
            // 
            this.ucMeterCpu.Location = new System.Drawing.Point(0, 259);
            this.ucMeterCpu.Name = "ucMeterCpu";
            this.ucMeterCpu.Size = new System.Drawing.Size(199, 204);
            this.ucMeterCpu.TabIndex = 15;
            this.ucMeterCpu.Title = "CPU利用率";
            // 
            // ucSplitLine_H1
            // 
            this.ucSplitLine_H1.BackColor = System.Drawing.Color.Silver;
            this.ucSplitLine_H1.Location = new System.Drawing.Point(6, 116);
            this.ucSplitLine_H1.Name = "ucSplitLine_H1";
            this.ucSplitLine_H1.Size = new System.Drawing.Size(200, 1);
            this.ucSplitLine_H1.TabIndex = 24;
            this.ucSplitLine_H1.TabStop = false;
            // 
            // ComputerInfoControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.ucMeterPhysicalMemory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucMeterCpu);
            this.Name = "ComputerInfoControl";
            this.Size = new System.Drawing.Size(223, 733);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private FactoryControls.Meter.UCMeterEx ucMeterCpu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelTCount;
        private System.Windows.Forms.Label labelPSize;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelMAC;
        private System.Windows.Forms.Label labelComputer;
        private FactoryControls.Meter.UCMeterEx ucMeterPhysicalMemory;
        private System.Windows.Forms.Timer timerProcess;
        private System.Windows.Forms.Label labelProcess_Name;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label labelProcess_CPU;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelProcess_PSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1Process_StartTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelProcess_TotalTime;
        private UCSplitLine_H ucSplitLine_H1;
    }
}
