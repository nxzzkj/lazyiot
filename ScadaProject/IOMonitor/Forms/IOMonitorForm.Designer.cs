using Scada.Controls.Controls;
using Scada.Controls.Controls.List;

namespace IOMonitor.Forms
{
    partial class IOMonitorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOMonitorForm));
            this.tabControlMonitor = new Scada.Controls.Controls.TabControlExt();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView = new Scada.Controls.Controls.List.SCADAListView();
            this.IO_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_NAME = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_LABEL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RealValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_UNIT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RealDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RealQualityStamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_POINTTYPE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucRollText = new Scada.Controls.Controls.UCRollText();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ucLateReceiveSize = new Scada.Controls.Controls.SCADAPageCombox();
            this.listViewReceive = new Scada.Controls.Controls.List.SCADAListView();
            this.columnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCommunication = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDevice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnReceiveContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucbReceive = new Scada.Controls.Controls.UCCheckBox();
            this.ucSplitLine_H3 = new Scada.Controls.Controls.UCSplitLine_H();
            this.label3 = new System.Windows.Forms.Label();
            this.ucLateCommandSize = new Scada.Controls.Controls.SCADAPageCombox();
            this.ucbSendCommand = new Scada.Controls.Controls.UCCheckBox();
            this.listViewSendCommand = new Scada.Controls.Controls.List.SCADAListView();
            this.columnCommandDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCommandResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCommandValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCommandServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCommandComm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCommandDevice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCommandIO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucSplitLine_H2 = new Scada.Controls.Controls.UCSplitLine_H();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listViewAlarm = new Scada.Controls.Controls.List.SCADAListView();
            this.columnAlarmID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAlarmDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAlarmIOName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAlarmValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAlarmType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAlarmLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAlarmServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAlarmCommunication = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAlarmDevice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAlarmResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucSplitLine_H1 = new Scada.Controls.Controls.UCSplitLine_H();
            this.ucLateAlarmSIze = new Scada.Controls.Controls.SCADAPageCombox();
            this.uccbRealAlarm = new Scada.Controls.Controls.UCCheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControlMonitor.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMonitor
            // 
            this.tabControlMonitor.Controls.Add(this.tabPage1);
            this.tabControlMonitor.Controls.Add(this.tabPage3);
            this.tabControlMonitor.Controls.Add(this.tabPage2);
            this.tabControlMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMonitor.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlMonitor.IsShowCloseBtn = false;
            this.tabControlMonitor.ItemSize = new System.Drawing.Size(0, 30);
            this.tabControlMonitor.Location = new System.Drawing.Point(0, 0);
            this.tabControlMonitor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControlMonitor.Name = "tabControlMonitor";
            this.tabControlMonitor.SelectedIndex = 0;
            this.tabControlMonitor.Size = new System.Drawing.Size(1370, 749);
            this.tabControlMonitor.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView);
            this.tabPage1.Controls.Add(this.ucRollText);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1362, 711);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "实时监控";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IO_ID,
            this.IO_NAME,
            this.IO_LABEL,
            this.RealValue,
            this.IO_UNIT,
            this.RealDate,
            this.RealQualityStamp,
            this.IO_POINTTYPE});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Location = new System.Drawing.Point(0, 52);
            this.listView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(1362, 659);
            this.listView.TabIndex = 3;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // IO_ID
            // 
            this.IO_ID.Text = "IO_ID";
            this.IO_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IO_ID.Width = 100;
            // 
            // IO_NAME
            // 
            this.IO_NAME.Text = "唯一名称";
            this.IO_NAME.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IO_NAME.Width = 100;
            // 
            // IO_LABEL
            // 
            this.IO_LABEL.Text = "中文名称";
            this.IO_LABEL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IO_LABEL.Width = 140;
            // 
            // RealValue
            // 
            this.RealValue.Text = "实时值";
            this.RealValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RealValue.Width = 143;
            // 
            // IO_UNIT
            // 
            this.IO_UNIT.Text = "单位";
            this.IO_UNIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RealDate
            // 
            this.RealDate.Text = "采集时间";
            this.RealDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RealDate.Width = 174;
            // 
            // RealQualityStamp
            // 
            this.RealQualityStamp.Text = "质量戳";
            this.RealQualityStamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RealQualityStamp.Width = 95;
            // 
            // IO_POINTTYPE
            // 
            this.IO_POINTTYPE.Text = "类型";
            this.IO_POINTTYPE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IO_POINTTYPE.Width = 80;
            // 
            // ucRollText
            // 
            this.ucRollText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucRollText.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucRollText.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucRollText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucRollText.Location = new System.Drawing.Point(0, 0);
            this.ucRollText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucRollText.MoveSleepTime = 100;
            this.ucRollText.Name = "ucRollText";
            this.ucRollText.RollStyle = Scada.Controls.Controls.RollStyle.LeftToRight;
            this.ucRollText.Size = new System.Drawing.Size(1362, 52);
            this.ucRollText.TabIndex = 2;
            this.ucRollText.Text = "滚动文字";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer3);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Size = new System.Drawing.Size(1362, 711);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "上传数据中心";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(4, 5);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.ucLateReceiveSize);
            this.splitContainer3.Panel1.Controls.Add(this.listViewReceive);
            this.splitContainer3.Panel1.Controls.Add(this.ucbReceive);
            this.splitContainer3.Panel1.Controls.Add(this.ucSplitLine_H3);
            this.splitContainer3.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.ucLateCommandSize);
            this.splitContainer3.Panel2.Controls.Add(this.ucbSendCommand);
            this.splitContainer3.Panel2.Controls.Add(this.listViewSendCommand);
            this.splitContainer3.Panel2.Controls.Add(this.ucSplitLine_H2);
            this.splitContainer3.Panel2.Controls.Add(this.label5);
            this.splitContainer3.Size = new System.Drawing.Size(1354, 701);
            this.splitContainer3.SplitterDistance = 424;
            this.splitContainer3.SplitterWidth = 7;
            this.splitContainer3.TabIndex = 0;
            // 
            // ucLateReceiveSize
            // 
            this.ucLateReceiveSize.BackColor = System.Drawing.Color.Transparent;
            this.ucLateReceiveSize.BackColorExt = System.Drawing.SystemColors.ControlLightLight;
            this.ucLateReceiveSize.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ucLateReceiveSize.ConerRadius = 5;
            this.ucLateReceiveSize.DropPanelHeight = -1;
            this.ucLateReceiveSize.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucLateReceiveSize.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucLateReceiveSize.IsRadius = true;
            this.ucLateReceiveSize.IsShowRect = true;
            this.ucLateReceiveSize.ItemWidth = 70;
            this.ucLateReceiveSize.Location = new System.Drawing.Point(382, 3);
            this.ucLateReceiveSize.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ucLateReceiveSize.Name = "ucLateReceiveSize";
            this.ucLateReceiveSize.RectColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucLateReceiveSize.RectWidth = 1;
            this.ucLateReceiveSize.SelectedIndex = 0;
            this.ucLateReceiveSize.SelectedValue = "100";
            this.ucLateReceiveSize.Size = new System.Drawing.Size(260, 38);
            this.ucLateReceiveSize.Source = ((System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>)(resources.GetObject("ucLateReceiveSize.Source")));
            this.ucLateReceiveSize.TabIndex = 14;
            this.ucLateReceiveSize.TextValue = "显示最近100条";
            this.ucLateReceiveSize.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // listViewReceive
            // 
            this.listViewReceive.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewReceive.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDate,
            this.columnServer,
            this.columnCommunication,
            this.columnDevice,
            this.columnResult,
            this.columnReceiveContent});
            this.listViewReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewReceive.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewReceive.FullRowSelect = true;
            this.listViewReceive.GridLines = true;
            this.listViewReceive.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewReceive.Location = new System.Drawing.Point(0, 47);
            this.listViewReceive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewReceive.Name = "listViewReceive";
            this.listViewReceive.Size = new System.Drawing.Size(1354, 377);
            this.listViewReceive.TabIndex = 12;
            this.listViewReceive.UseCompatibleStateImageBehavior = false;
            this.listViewReceive.View = System.Windows.Forms.View.Details;
            // 
            // columnDate
            // 
            this.columnDate.Text = "采集时间";
            this.columnDate.Width = 126;
            // 
            // columnServer
            // 
            this.columnServer.Text = "采集站";
            this.columnServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnCommunication
            // 
            this.columnCommunication.Text = "通道";
            this.columnCommunication.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnCommunication.Width = 161;
            // 
            // columnDevice
            // 
            this.columnDevice.Text = "设备";
            this.columnDevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnDevice.Width = 144;
            // 
            // columnResult
            // 
            this.columnResult.Text = "上传结果";
            this.columnResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnResult.Width = 144;
            // 
            // columnReceiveContent
            // 
            this.columnReceiveContent.Text = "采集字节";
            this.columnReceiveContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnReceiveContent.Width = 385;
            // 
            // ucbReceive
            // 
            this.ucbReceive.BackColor = System.Drawing.Color.Transparent;
            this.ucbReceive.Checked = true;
            this.ucbReceive.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucbReceive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ucbReceive.Location = new System.Drawing.Point(216, 5);
            this.ucbReceive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucbReceive.Name = "ucbReceive";
            this.ucbReceive.Padding = new System.Windows.Forms.Padding(2);
            this.ucbReceive.Size = new System.Drawing.Size(146, 37);
            this.ucbReceive.TabIndex = 13;
            this.ucbReceive.TextValue = "实时显示";
            // 
            // ucSplitLine_H3
            // 
            this.ucSplitLine_H3.BackColor = System.Drawing.Color.Gray;
            this.ucSplitLine_H3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSplitLine_H3.Location = new System.Drawing.Point(0, 45);
            this.ucSplitLine_H3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucSplitLine_H3.Name = "ucSplitLine_H3";
            this.ucSplitLine_H3.Size = new System.Drawing.Size(1354, 2);
            this.ucSplitLine_H3.TabIndex = 8;
            this.ucSplitLine_H3.TabStop = false;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1354, 45);
            this.label3.TabIndex = 7;
            this.label3.Text = "采集器采集接收数据:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucLateCommandSize
            // 
            this.ucLateCommandSize.BackColor = System.Drawing.Color.Transparent;
            this.ucLateCommandSize.BackColorExt = System.Drawing.SystemColors.ControlLightLight;
            this.ucLateCommandSize.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ucLateCommandSize.ConerRadius = 5;
            this.ucLateCommandSize.DropPanelHeight = -1;
            this.ucLateCommandSize.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucLateCommandSize.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucLateCommandSize.IsRadius = true;
            this.ucLateCommandSize.IsShowRect = true;
            this.ucLateCommandSize.ItemWidth = 70;
            this.ucLateCommandSize.Location = new System.Drawing.Point(426, 8);
            this.ucLateCommandSize.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ucLateCommandSize.Name = "ucLateCommandSize";
            this.ucLateCommandSize.RectColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucLateCommandSize.RectWidth = 1;
            this.ucLateCommandSize.SelectedIndex = 0;
            this.ucLateCommandSize.SelectedValue = "100";
            this.ucLateCommandSize.Size = new System.Drawing.Size(260, 38);
            this.ucLateCommandSize.Source = ((System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>)(resources.GetObject("ucLateCommandSize.Source")));
            this.ucLateCommandSize.TabIndex = 17;
            this.ucLateCommandSize.TextValue = "显示最近100条";
            this.ucLateCommandSize.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // ucbSendCommand
            // 
            this.ucbSendCommand.BackColor = System.Drawing.Color.Transparent;
            this.ucbSendCommand.Checked = true;
            this.ucbSendCommand.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucbSendCommand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ucbSendCommand.Location = new System.Drawing.Point(267, 8);
            this.ucbSendCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucbSendCommand.Name = "ucbSendCommand";
            this.ucbSendCommand.Padding = new System.Windows.Forms.Padding(2);
            this.ucbSendCommand.Size = new System.Drawing.Size(147, 38);
            this.ucbSendCommand.TabIndex = 14;
            this.ucbSendCommand.TextValue = "实时显示";
            // 
            // listViewSendCommand
            // 
            this.listViewSendCommand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewSendCommand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnCommandDateTime,
            this.columnCommandResult,
            this.columnCommandValue,
            this.columnCommandServer,
            this.columnCommandComm,
            this.columnCommandDevice,
            this.columnCommandIO});
            this.listViewSendCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSendCommand.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewSendCommand.FullRowSelect = true;
            this.listViewSendCommand.GridLines = true;
            this.listViewSendCommand.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSendCommand.Location = new System.Drawing.Point(0, 57);
            this.listViewSendCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewSendCommand.Name = "listViewSendCommand";
            this.listViewSendCommand.Size = new System.Drawing.Size(1354, 213);
            this.listViewSendCommand.TabIndex = 11;
            this.listViewSendCommand.UseCompatibleStateImageBehavior = false;
            this.listViewSendCommand.View = System.Windows.Forms.View.Details;
            // 
            // columnCommandDateTime
            // 
            this.columnCommandDateTime.Text = "下置时间";
            this.columnCommandDateTime.Width = 137;
            // 
            // columnCommandResult
            // 
            this.columnCommandResult.Text = "下置结果";
            this.columnCommandResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnCommandResult.Width = 132;
            // 
            // columnCommandValue
            // 
            this.columnCommandValue.Text = "下置值";
            this.columnCommandValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnCommandValue.Width = 163;
            // 
            // columnCommandServer
            // 
            this.columnCommandServer.Text = "采集站";
            this.columnCommandServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnCommandServer.Width = 108;
            // 
            // columnCommandComm
            // 
            this.columnCommandComm.Text = "通道";
            this.columnCommandComm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnCommandComm.Width = 161;
            // 
            // columnCommandDevice
            // 
            this.columnCommandDevice.Text = "设备";
            this.columnCommandDevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnCommandDevice.Width = 150;
            // 
            // columnCommandIO
            // 
            this.columnCommandIO.Text = "IO参数";
            this.columnCommandIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnCommandIO.Width = 148;
            // 
            // ucSplitLine_H2
            // 
            this.ucSplitLine_H2.BackColor = System.Drawing.Color.Gray;
            this.ucSplitLine_H2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSplitLine_H2.Location = new System.Drawing.Point(0, 55);
            this.ucSplitLine_H2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucSplitLine_H2.Name = "ucSplitLine_H2";
            this.ucSplitLine_H2.Size = new System.Drawing.Size(1354, 2);
            this.ucSplitLine_H2.TabIndex = 10;
            this.ucSplitLine_H2.TabStop = false;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1354, 55);
            this.label5.TabIndex = 9;
            this.label5.Text = "SCADA下置命令发送日志:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listViewAlarm);
            this.tabPage2.Controls.Add(this.ucSplitLine_H1);
            this.tabPage2.Controls.Add(this.ucLateAlarmSIze);
            this.tabPage2.Controls.Add(this.uccbRealAlarm);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1362, 711);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "报警日志";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listViewAlarm
            // 
            this.listViewAlarm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewAlarm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnAlarmID,
            this.columnAlarmDate,
            this.columnAlarmIOName,
            this.columnAlarmValue,
            this.columnAlarmType,
            this.columnAlarmLevel,
            this.columnAlarmServer,
            this.columnAlarmCommunication,
            this.columnAlarmDevice,
            this.columnAlarmResult});
            this.listViewAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAlarm.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewAlarm.FullRowSelect = true;
            this.listViewAlarm.GridLines = true;
            this.listViewAlarm.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewAlarm.Location = new System.Drawing.Point(0, 57);
            this.listViewAlarm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewAlarm.Name = "listViewAlarm";
            this.listViewAlarm.Size = new System.Drawing.Size(1362, 654);
            this.listViewAlarm.TabIndex = 13;
            this.listViewAlarm.UseCompatibleStateImageBehavior = false;
            this.listViewAlarm.View = System.Windows.Forms.View.Details;
            // 
            // columnAlarmID
            // 
            this.columnAlarmID.Text = "报警ID";
            this.columnAlarmID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnAlarmDate
            // 
            this.columnAlarmDate.Text = "报警时间";
            this.columnAlarmDate.Width = 137;
            // 
            // columnAlarmIOName
            // 
            this.columnAlarmIOName.Text = "IO参数";
            this.columnAlarmIOName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnAlarmIOName.Width = 102;
            // 
            // columnAlarmValue
            // 
            this.columnAlarmValue.Text = "报警值";
            this.columnAlarmValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnAlarmValue.Width = 102;
            // 
            // columnAlarmType
            // 
            this.columnAlarmType.Text = "报警类型";
            this.columnAlarmType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnAlarmType.Width = 102;
            // 
            // columnAlarmLevel
            // 
            this.columnAlarmLevel.Text = "报警等级";
            this.columnAlarmLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnAlarmLevel.Width = 102;
            // 
            // columnAlarmServer
            // 
            this.columnAlarmServer.Text = "采集站";
            this.columnAlarmServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnAlarmServer.Width = 118;
            // 
            // columnAlarmCommunication
            // 
            this.columnAlarmCommunication.Text = "通道";
            this.columnAlarmCommunication.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnAlarmCommunication.Width = 100;
            // 
            // columnAlarmDevice
            // 
            this.columnAlarmDevice.Text = "设备";
            this.columnAlarmDevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnAlarmDevice.Width = 99;
            // 
            // columnAlarmResult
            // 
            this.columnAlarmResult.Text = "上传结果";
            this.columnAlarmResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnAlarmResult.Width = 102;
            // 
            // ucSplitLine_H1
            // 
            this.ucSplitLine_H1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ucSplitLine_H1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSplitLine_H1.Location = new System.Drawing.Point(0, 55);
            this.ucSplitLine_H1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucSplitLine_H1.Name = "ucSplitLine_H1";
            this.ucSplitLine_H1.Size = new System.Drawing.Size(1362, 2);
            this.ucSplitLine_H1.TabIndex = 21;
            this.ucSplitLine_H1.TabStop = false;
            // 
            // ucLateAlarmSIze
            // 
            this.ucLateAlarmSIze.BackColor = System.Drawing.Color.Transparent;
            this.ucLateAlarmSIze.BackColorExt = System.Drawing.SystemColors.ControlLightLight;
            this.ucLateAlarmSIze.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ucLateAlarmSIze.ConerRadius = 5;
            this.ucLateAlarmSIze.DropPanelHeight = -1;
            this.ucLateAlarmSIze.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucLateAlarmSIze.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucLateAlarmSIze.IsRadius = true;
            this.ucLateAlarmSIze.IsShowRect = true;
            this.ucLateAlarmSIze.ItemWidth = 70;
            this.ucLateAlarmSIze.Location = new System.Drawing.Point(327, 10);
            this.ucLateAlarmSIze.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ucLateAlarmSIze.Name = "ucLateAlarmSIze";
            this.ucLateAlarmSIze.RectColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucLateAlarmSIze.RectWidth = 1;
            this.ucLateAlarmSIze.SelectedIndex = 0;
            this.ucLateAlarmSIze.SelectedValue = "100";
            this.ucLateAlarmSIze.Size = new System.Drawing.Size(260, 38);
            this.ucLateAlarmSIze.Source = ((System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>)(resources.GetObject("ucLateAlarmSIze.Source")));
            this.ucLateAlarmSIze.TabIndex = 18;
            this.ucLateAlarmSIze.TextValue = "显示最近100条";
            this.ucLateAlarmSIze.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // uccbRealAlarm
            // 
            this.uccbRealAlarm.BackColor = System.Drawing.Color.Transparent;
            this.uccbRealAlarm.Checked = true;
            this.uccbRealAlarm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uccbRealAlarm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.uccbRealAlarm.Location = new System.Drawing.Point(189, 10);
            this.uccbRealAlarm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uccbRealAlarm.Name = "uccbRealAlarm";
            this.uccbRealAlarm.Padding = new System.Windows.Forms.Padding(2);
            this.uccbRealAlarm.Size = new System.Drawing.Size(186, 37);
            this.uccbRealAlarm.TabIndex = 17;
            this.uccbRealAlarm.TextValue = "实时显示";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1362, 55);
            this.label4.TabIndex = 14;
            this.label4.Text = "采集数据报警日志:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IOMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.tabControlMonitor);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "IOMonitorForm";
            this.Text = "IOMonitorForm";
            this.Load += new System.EventHandler(this.IOMonitorForm_Load);
            this.tabControlMonitor.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Scada.Controls.Controls.TabControlExt tabControlMonitor;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        public SCADAListView  listViewReceive;
        private System.Windows.Forms.ColumnHeader columnDate;
        private System.Windows.Forms.ColumnHeader columnCommunication;
        private System.Windows.Forms.ColumnHeader columnDevice;
        private System.Windows.Forms.ColumnHeader columnReceiveContent;
        private Scada.Controls.Controls.UCSplitLine_H ucSplitLine_H3;
        private System.Windows.Forms.Label label3;
        public SCADAListView  listViewSendCommand;
        private System.Windows.Forms.ColumnHeader columnCommandDateTime;
        private System.Windows.Forms.ColumnHeader columnCommandComm;
        private System.Windows.Forms.ColumnHeader columnCommandDevice;
        private System.Windows.Forms.ColumnHeader columnCommandIO;
        private System.Windows.Forms.ColumnHeader columnCommandValue;
        private System.Windows.Forms.ColumnHeader columnCommandResult;
        private Scada.Controls.Controls.UCSplitLine_H ucSplitLine_H2;
        private System.Windows.Forms.Label label5;
        private Scada.Controls.Controls.UCRollText ucRollText;
        private System.Windows.Forms.ColumnHeader columnResult;
        private SCADAListView  listView;
        private System.Windows.Forms.ColumnHeader IO_NAME;
        private System.Windows.Forms.ColumnHeader IO_LABEL;
        private System.Windows.Forms.ColumnHeader RealValue;
        private System.Windows.Forms.ColumnHeader RealDate;
        private System.Windows.Forms.ColumnHeader RealQualityStamp;
        private System.Windows.Forms.ColumnHeader IO_ID;
        private System.Windows.Forms.ColumnHeader IO_POINTTYPE;
        private System.Windows.Forms.ColumnHeader IO_UNIT;
        private Scada.Controls.Controls.UCCheckBox ucbReceive;
        private Scada.Controls.Controls.UCCheckBox ucbSendCommand;
        private System.Windows.Forms.ColumnHeader columnServer;
        private System.Windows.Forms.TabPage tabPage2;
        public SCADAListView listViewAlarm;
        private System.Windows.Forms.ColumnHeader columnAlarmID;
        private System.Windows.Forms.ColumnHeader columnAlarmDate;
        private System.Windows.Forms.ColumnHeader columnAlarmIOName;
        private System.Windows.Forms.ColumnHeader columnAlarmValue;
        private System.Windows.Forms.ColumnHeader columnAlarmType;
        private System.Windows.Forms.ColumnHeader columnAlarmLevel;
        private System.Windows.Forms.ColumnHeader columnAlarmServer;
        private System.Windows.Forms.ColumnHeader columnAlarmCommunication;
        private System.Windows.Forms.ColumnHeader columnAlarmDevice;
        private System.Windows.Forms.ColumnHeader columnAlarmResult;
        private SCADAPageCombox ucLateReceiveSize;
        private SCADAPageCombox ucLateCommandSize;
        private System.Windows.Forms.Label label4;
        private Scada.Controls.Controls.UCSplitLine_H ucSplitLine_H1;
        private SCADAPageCombox ucLateAlarmSIze;
        private Scada.Controls.Controls.UCCheckBox uccbRealAlarm;
        private System.Windows.Forms.ColumnHeader columnCommandServer;
    }
}