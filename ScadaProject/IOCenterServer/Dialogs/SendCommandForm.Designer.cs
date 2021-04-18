namespace ScadaCenterServer.Dialogs
{
    partial class SendCommandForm
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
            this.textBoxServer = new Scada.Controls.Controls.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDevice = new Scada.Controls.Controls.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCommunication = new Scada.Controls.Controls.TextBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.ucPanelQuote1 = new Scada.Controls.Controls.UCPanelQuote();
            this.label5 = new System.Windows.Forms.Label();
            this.tbValue = new Scada.Controls.Controls.TextBoxEx();
            this.ucStep = new Scada.Controls.Controls.UCStep();
            this.ucBtnSend = new Scada.Controls.Controls.UCBtnExt();
            this.comboIOPara = new System.Windows.Forms.ComboBox();
            this.ucSplitLine_H3 = new Scada.Controls.Controls.UCSplitLine_H();
            this.ucSplitLine_H4 = new Scada.Controls.Controls.UCSplitLine_H();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.ucPanelQuote1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.ucSplitLine_H3);
            this.panel3.Controls.Add(this.comboIOPara);
            this.panel3.Controls.Add(this.ucBtnSend);
            this.panel3.Controls.Add(this.ucStep);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.tbValue);
            this.panel3.Controls.Add(this.ucSplitLine_H4);
            this.panel3.Controls.Add(this.ucPanelQuote1);
            this.panel3.Size = new System.Drawing.Size(590, 500);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 485);
            this.panel2.Size = new System.Drawing.Size(590, 42);
            // 
            // btnOK
            // 
            this.btnOK.BtnClick += new System.EventHandler(this.btnOK_BtnClick);
            // 
            // btnCancel
            // 
            this.btnCancel.BtnClick += new System.EventHandler(this.btnCancel_BtnClick);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(590, 26);
            this.lblTitle.Text = "SCADA下置命令";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(562, 0);
            // 
            // btMin
            // 
            this.btMin.Location = new System.Drawing.Point(530, 0);
            this.btMin.Visible = false;
            // 
            // btMax
            // 
            this.btMax.Location = new System.Drawing.Point(500, 0);
            this.btMax.Visible = false;
            // 
            // textBoxServer
            // 
            this.textBoxServer.DecLength = 2;
            this.textBoxServer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxServer.InputType = Scada.Controls.TextInputType.NotControl;
            this.textBoxServer.Location = new System.Drawing.Point(26, 44);
            this.textBoxServer.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.textBoxServer.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.textBoxServer.MyRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.OldText = null;
            this.textBoxServer.PromptColor = System.Drawing.Color.Gray;
            this.textBoxServer.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxServer.PromptText = "";
            this.textBoxServer.ReadOnly = true;
            this.textBoxServer.RegexPattern = "";
            this.textBoxServer.Size = new System.Drawing.Size(534, 29);
            this.textBoxServer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "采集站：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(22, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "通道：";
            // 
            // textBoxDevice
            // 
            this.textBoxDevice.DecLength = 2;
            this.textBoxDevice.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDevice.InputType = Scada.Controls.TextInputType.NotControl;
            this.textBoxDevice.Location = new System.Drawing.Point(26, 167);
            this.textBoxDevice.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.textBoxDevice.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.textBoxDevice.MyRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.textBoxDevice.Name = "textBoxDevice";
            this.textBoxDevice.OldText = null;
            this.textBoxDevice.PromptColor = System.Drawing.Color.Gray;
            this.textBoxDevice.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxDevice.PromptText = "";
            this.textBoxDevice.ReadOnly = true;
            this.textBoxDevice.RegexPattern = "";
            this.textBoxDevice.Size = new System.Drawing.Size(534, 29);
            this.textBoxDevice.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(23, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "设备：";
            // 
            // textBoxCommunication
            // 
            this.textBoxCommunication.DecLength = 2;
            this.textBoxCommunication.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxCommunication.InputType = Scada.Controls.TextInputType.NotControl;
            this.textBoxCommunication.Location = new System.Drawing.Point(27, 105);
            this.textBoxCommunication.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.textBoxCommunication.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.textBoxCommunication.MyRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.textBoxCommunication.Name = "textBoxCommunication";
            this.textBoxCommunication.OldText = null;
            this.textBoxCommunication.PromptColor = System.Drawing.Color.Gray;
            this.textBoxCommunication.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxCommunication.PromptText = "";
            this.textBoxCommunication.ReadOnly = true;
            this.textBoxCommunication.RegexPattern = "";
            this.textBoxCommunication.Size = new System.Drawing.Size(533, 29);
            this.textBoxCommunication.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(13, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "IO参数：";
            // 
            // ucPanelQuote1
            // 
            this.ucPanelQuote1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.ucPanelQuote1.Controls.Add(this.textBoxCommunication);
            this.ucPanelQuote1.Controls.Add(this.textBoxServer);
            this.ucPanelQuote1.Controls.Add(this.label1);
            this.ucPanelQuote1.Controls.Add(this.label3);
            this.ucPanelQuote1.Controls.Add(this.textBoxDevice);
            this.ucPanelQuote1.Controls.Add(this.label2);
            this.ucPanelQuote1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucPanelQuote1.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.ucPanelQuote1.Location = new System.Drawing.Point(0, 0);
            this.ucPanelQuote1.Name = "ucPanelQuote1";
            this.ucPanelQuote1.Padding = new System.Windows.Forms.Padding(5, 1, 1, 1);
            this.ucPanelQuote1.Size = new System.Drawing.Size(590, 209);
            this.ucPanelQuote1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(282, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "下置值：";
            // 
            // tbValue
            // 
            this.tbValue.DecLength = 2;
            this.tbValue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbValue.InputType = Scada.Controls.TextInputType.Number;
            this.tbValue.Location = new System.Drawing.Point(361, 296);
            this.tbValue.MaxValue = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.tbValue.MinValue = new decimal(new int[] {
            1215752192,
            23,
            0,
            -2147483648});
            this.tbValue.MyRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tbValue.Name = "tbValue";
            this.tbValue.OldText = null;
            this.tbValue.PromptColor = System.Drawing.Color.Gray;
            this.tbValue.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbValue.PromptText = "";
            this.tbValue.RegexPattern = "";
            this.tbValue.Size = new System.Drawing.Size(167, 29);
            this.tbValue.TabIndex = 9;
            // 
            // ucStep
            // 
            this.ucStep.BackColor = System.Drawing.Color.Transparent;
            this.ucStep.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucStep.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucStep.ImgCompleted = null;
            this.ucStep.LineWidth = 2;
            this.ucStep.Location = new System.Drawing.Point(0, 210);
            this.ucStep.Name = "ucStep";
            this.ucStep.Size = new System.Drawing.Size(590, 80);
            this.ucStep.StepBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucStep.StepFontColor = System.Drawing.Color.White;
            this.ucStep.StepForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucStep.StepIndex = 0;
            this.ucStep.Steps = new string[] {
        "下置命令",
        "下置结果",
        "采集站反馈",
        "命令完成"};
            this.ucStep.StepWidth = 35;
            this.ucStep.TabIndex = 11;
            // 
            // ucBtnSend
            // 
            this.ucBtnSend.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnSend.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnSend.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnSend.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnSend.BtnText = "下发命令";
            this.ucBtnSend.ConerRadius = 34;
            this.ucBtnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnSend.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ucBtnSend.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnSend.ForeColor = System.Drawing.Color.White;
            this.ucBtnSend.IsRadius = true;
            this.ucBtnSend.IsShowRect = false;
            this.ucBtnSend.IsShowTips = false;
            this.ucBtnSend.Location = new System.Drawing.Point(393, 384);
            this.ucBtnSend.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnSend.Name = "ucBtnSend";
            this.ucBtnSend.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnSend.RectWidth = 1;
            this.ucBtnSend.Size = new System.Drawing.Size(135, 42);
            this.ucBtnSend.TabIndex = 16;
            this.ucBtnSend.TabStop = false;
            this.ucBtnSend.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnSend.TipsText = "";
            this.ucBtnSend.BtnClick += new System.EventHandler(this.ucBtnSend_BtnClick);
            this.ucBtnSend.Click += new System.EventHandler(this.ucBtnSend_BtnClick);
            // 
            // comboIOPara
            // 
            this.comboIOPara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIOPara.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboIOPara.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.comboIOPara.FormattingEnabled = true;
            this.comboIOPara.Location = new System.Drawing.Point(93, 296);
            this.comboIOPara.Name = "comboIOPara";
            this.comboIOPara.Size = new System.Drawing.Size(167, 29);
            this.comboIOPara.TabIndex = 8;
            // 
            // ucSplitLine_H3
            // 
            this.ucSplitLine_H3.BackColor = System.Drawing.Color.Red;
            this.ucSplitLine_H3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSplitLine_H3.Location = new System.Drawing.Point(0, 290);
            this.ucSplitLine_H3.Name = "ucSplitLine_H3";
            this.ucSplitLine_H3.Size = new System.Drawing.Size(590, 1);
            this.ucSplitLine_H3.TabIndex = 17;
            this.ucSplitLine_H3.TabStop = false;
            // 
            // ucSplitLine_H4
            // 
            this.ucSplitLine_H4.BackColor = System.Drawing.Color.Red;
            this.ucSplitLine_H4.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSplitLine_H4.Location = new System.Drawing.Point(0, 209);
            this.ucSplitLine_H4.Name = "ucSplitLine_H4";
            this.ucSplitLine_H4.Size = new System.Drawing.Size(590, 1);
            this.ucSplitLine_H4.TabIndex = 18;
            this.ucSplitLine_H4.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(23, 337);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(364, 21);
            this.label6.TabIndex = 19;
            this.label6.Text = "只允许设置模拟量和开关量，开关量设置值0或者1";
            // 
            // SendCommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 528);
            this.Name = "SendCommandForm";
            this.Text = "SCADA下置命令";
            this.Title = "SCADA下置命令";
            this.Load += new System.EventHandler(this.SendCommandForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ucPanelQuote1.ResumeLayout(false);
            this.ucPanelQuote1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Scada.Controls.Controls.TextBoxEx textBoxServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Scada.Controls.Controls.TextBoxEx textBoxDevice;
        private System.Windows.Forms.Label label3;
        private Scada.Controls.Controls.TextBoxEx textBoxCommunication;
        private System.Windows.Forms.Label label4;
        private Scada.Controls.Controls.UCPanelQuote ucPanelQuote1;
        private System.Windows.Forms.Label label5;
        private Scada.Controls.Controls.TextBoxEx tbValue;
        private Scada.Controls.Controls.UCStep ucStep;
        private Scada.Controls.Controls.UCBtnExt ucBtnSend;
        private System.Windows.Forms.ComboBox comboIOPara;
        private Scada.Controls.Controls.UCSplitLine_H ucSplitLine_H3;
        private Scada.Controls.Controls.UCSplitLine_H ucSplitLine_H4;
        private System.Windows.Forms.Label label6;
    }
}