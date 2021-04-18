namespace ScadaCenterServer.Pages
{
    partial class OperatorLogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperatorLogForm));
            this.ucLateLogSIze = new Scada.Controls.Controls.SCADAPageCombox();
            this.uccbLog = new Scada.Controls.Controls.UCCheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listViewLog = new Scada.Controls.Controls.List.SCADAListView();
            this.columnEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEventContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucSplitLine_H1 = new Scada.Controls.Controls.UCSplitLine_H();
            this.SuspendLayout();
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
            this.ucLateLogSIze.Location = new System.Drawing.Point(235, 4);
            this.ucLateLogSIze.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucLateLogSIze.Name = "ucLateLogSIze";
            this.ucLateLogSIze.RectColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucLateLogSIze.RectWidth = 1;
            this.ucLateLogSIze.SelectedIndex = 0;
            this.ucLateLogSIze.SelectedValue = "100";
            this.ucLateLogSIze.Size = new System.Drawing.Size(173, 23);
            this.ucLateLogSIze.Source = ((System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>)(resources.GetObject("ucLateLogSIze.Source")));
            this.ucLateLogSIze.TabIndex = 24;
            this.ucLateLogSIze.TextValue = "显示最近100条";
            this.ucLateLogSIze.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // uccbLog
            // 
            this.uccbLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.uccbLog.Checked = true;
            this.uccbLog.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uccbLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.uccbLog.Location = new System.Drawing.Point(134, 4);
            this.uccbLog.Name = "uccbLog";
            this.uccbLog.Padding = new System.Windows.Forms.Padding(1);
            this.uccbLog.Size = new System.Drawing.Size(94, 22);
            this.uccbLog.TabIndex = 23;
            this.uccbLog.TextValue = "实时显示";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(714, 33);
            this.label4.TabIndex = 22;
            this.label4.Text = "系统事件日志:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listViewLog
            // 
            this.listViewLog.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listViewLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnEvent,
            this.columnEventContent});
            this.listViewLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLog.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewLog.FullRowSelect = true;
            this.listViewLog.GridLines = true;
            this.listViewLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewLog.Location = new System.Drawing.Point(0, 34);
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(714, 336);
            this.listViewLog.TabIndex = 25;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            // 
            // columnEvent
            // 
            this.columnEvent.Text = "事件时间";
            this.columnEvent.Width = 189;
            // 
            // columnEventContent
            // 
            this.columnEventContent.Text = "事件内容";
            this.columnEventContent.Width = 496;
            // 
            // ucSplitLine_H1
            // 
            this.ucSplitLine_H1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ucSplitLine_H1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSplitLine_H1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ucSplitLine_H1.Location = new System.Drawing.Point(0, 33);
            this.ucSplitLine_H1.Name = "ucSplitLine_H1";
            this.ucSplitLine_H1.Size = new System.Drawing.Size(714, 1);
            this.ucSplitLine_H1.TabIndex = 26;
            this.ucSplitLine_H1.TabStop = false;
            // 
            // OperatorLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 370);
            this.Controls.Add(this.listViewLog);
            this.Controls.Add(this.ucSplitLine_H1);
            this.Controls.Add(this.ucLateLogSIze);
            this.Controls.Add(this.uccbLog);
            this.Controls.Add(this.label4);
            this.Name = "OperatorLogForm";
            this.Text = "OperatorLogForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Scada.Controls.Controls.SCADAPageCombox ucLateLogSIze;
        private Scada.Controls.Controls.UCCheckBox uccbLog;
        private System.Windows.Forms.Label label4;
        private Scada.Controls.Controls.List.SCADAListView listViewLog;
        private System.Windows.Forms.ColumnHeader columnEvent;
        private System.Windows.Forms.ColumnHeader columnEventContent;
        private Scada.Controls.Controls.UCSplitLine_H ucSplitLine_H1;
    }
}