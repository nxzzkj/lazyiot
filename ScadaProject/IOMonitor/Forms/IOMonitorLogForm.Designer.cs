namespace IOMonitor.Forms
{
    partial class IOMonitorLogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOMonitorLogForm));
            this.label4 = new System.Windows.Forms.Label();
            this.ucSplitLine_H1 = new Scada.Controls.Controls.UCSplitLine_H();
            this.listViewLog = new Scada.Controls.Controls.List.SCADAListView();
            this.columnEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEventContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucLateLogSIze = new Scada.Controls.Controls.SCADAPageCombox();
            this.uccbLog = new Scada.Controls.Controls.UCCheckBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1028, 55);
            this.label4.TabIndex = 19;
            this.label4.Text = "系统事件日志:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucSplitLine_H1
            // 
            this.ucSplitLine_H1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ucSplitLine_H1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSplitLine_H1.Location = new System.Drawing.Point(0, 55);
            this.ucSplitLine_H1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucSplitLine_H1.Name = "ucSplitLine_H1";
            this.ucSplitLine_H1.Size = new System.Drawing.Size(1028, 2);
            this.ucSplitLine_H1.TabIndex = 22;
            this.ucSplitLine_H1.TabStop = false;
            // 
            // listViewLog
            // 
            this.listViewLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnEvent,
            this.columnEventContent});
            this.listViewLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLog.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewLog.FullRowSelect = true;
            this.listViewLog.GridLines = true;
            this.listViewLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewLog.Location = new System.Drawing.Point(0, 55);
            this.listViewLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(1028, 320);
            this.listViewLog.TabIndex = 4;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            // 
            // columnEvent
            // 
            this.columnEvent.Text = "事件事件";
            this.columnEvent.Width = 156;
            // 
            // columnEventContent
            // 
            this.columnEventContent.Text = "事件内容";
            this.columnEventContent.Width = 496;
            // 
            // ucLateLogSIze
            // 
            this.ucLateLogSIze.BackColor = System.Drawing.Color.Transparent;
            this.ucLateLogSIze.BackColorExt = System.Drawing.SystemColors.ControlLightLight;
            this.ucLateLogSIze.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ucLateLogSIze.ConerRadius = 5;
            this.ucLateLogSIze.DropPanelHeight = -1;
            this.ucLateLogSIze.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucLateLogSIze.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucLateLogSIze.IsRadius = true;
            this.ucLateLogSIze.IsShowRect = true;
            this.ucLateLogSIze.ItemWidth = 70;
            this.ucLateLogSIze.Location = new System.Drawing.Point(344, 8);
            this.ucLateLogSIze.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ucLateLogSIze.Name = "ucLateLogSIze";
            this.ucLateLogSIze.RectColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucLateLogSIze.RectWidth = 1;
            this.ucLateLogSIze.SelectedIndex = 0;
            this.ucLateLogSIze.SelectedValue = "100";
            this.ucLateLogSIze.Size = new System.Drawing.Size(260, 38);
            this.ucLateLogSIze.Source = ((System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>)(resources.GetObject("ucLateLogSIze.Source")));
            this.ucLateLogSIze.TabIndex = 21;
            this.ucLateLogSIze.TextValue = "显示最近100条";
            this.ucLateLogSIze.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // uccbLog
            // 
            this.uccbLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.uccbLog.Checked = true;
            this.uccbLog.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uccbLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.uccbLog.Location = new System.Drawing.Point(192, 8);
            this.uccbLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uccbLog.Name = "uccbLog";
            this.uccbLog.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uccbLog.Size = new System.Drawing.Size(141, 37);
            this.uccbLog.TabIndex = 20;
            this.uccbLog.TextValue = "实时显示";
            // 
            // IOMonitorLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 375);
            this.Controls.Add(this.ucSplitLine_H1);
            this.Controls.Add(this.listViewLog);
            this.Controls.Add(this.ucLateLogSIze);
            this.Controls.Add(this.uccbLog);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "IOMonitorLogForm";
            this.Text = "IOMonitorLogForm";
            this.Load += new System.EventHandler(this.IOMonitorLogForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Scada.Controls.Controls.List.SCADAListView listViewLog;
        private System.Windows.Forms.ColumnHeader columnEvent;
        private System.Windows.Forms.ColumnHeader columnEventContent;
        private Scada.Controls.Controls.SCADAPageCombox ucLateLogSIze;
        private Scada.Controls.Controls.UCCheckBox uccbLog;
        private System.Windows.Forms.Label label4;
        private Scada.Controls.Controls.UCSplitLine_H ucSplitLine_H1;
    }
}