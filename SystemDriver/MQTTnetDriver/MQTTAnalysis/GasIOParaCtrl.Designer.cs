namespace MQTTnet
{
    partial class GasIOParaCtrl
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbDataType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudTime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tb_JsonName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.nud_valueIndex = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbCmdValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_valueIndex)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbDataType);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 30);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1485, 30);
            this.panel4.TabIndex = 5;
            // 
            // cbDataType
            // 
            this.cbDataType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDataType.FormattingEnabled = true;
            this.cbDataType.Items.AddRange(new object[] {
            "采集参数",
            "命令参数"});
            this.cbDataType.Location = new System.Drawing.Point(85, 0);
            this.cbDataType.Name = "cbDataType";
            this.cbDataType.Size = new System.Drawing.Size(1400, 28);
            this.cbDataType.TabIndex = 1;
            this.cbDataType.SelectedIndexChanged += new System.EventHandler(this.cbDataType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "数据类型:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nudTime);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1485, 30);
            this.panel1.TabIndex = 6;
            // 
            // nudTime
            // 
            this.nudTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudTime.Location = new System.Drawing.Point(85, 0);
            this.nudTime.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nudTime.Name = "nudTime";
            this.nudTime.Size = new System.Drawing.Size(1400, 26);
            this.nudTime.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "时间值索引:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tb_JsonName);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1485, 30);
            this.panel3.TabIndex = 8;
            // 
            // tb_JsonName
            // 
            this.tb_JsonName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_JsonName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_JsonName.Location = new System.Drawing.Point(85, 0);
            this.tb_JsonName.Name = "tb_JsonName";
            this.tb_JsonName.Size = new System.Drawing.Size(1400, 26);
            this.tb_JsonName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "IO标识:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.nud_valueIndex);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 90);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1485, 30);
            this.panel5.TabIndex = 9;
            // 
            // nud_valueIndex
            // 
            this.nud_valueIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_valueIndex.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_valueIndex.Location = new System.Drawing.Point(85, 0);
            this.nud_valueIndex.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nud_valueIndex.Name = "nud_valueIndex";
            this.nud_valueIndex.Size = new System.Drawing.Size(1400, 26);
            this.nud_valueIndex.TabIndex = 4;
            this.nud_valueIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 30);
            this.label8.TabIndex = 3;
            this.label8.Text = "采集值索引:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbCmdValue);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1485, 30);
            this.panel2.TabIndex = 10;
            // 
            // tbCmdValue
            // 
            this.tbCmdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCmdValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCmdValue.Location = new System.Drawing.Point(85, 0);
            this.tbCmdValue.Name = "tbCmdValue";
            this.tbCmdValue.Size = new System.Drawing.Size(1400, 26);
            this.tbCmdValue.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "命令默认值:";
            // 
            // GasIOParaCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "GasIOParaCtrl";
            this.Size = new System.Drawing.Size(1485, 871);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_valueIndex)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_JsonName;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nud_valueIndex;
        private System.Windows.Forms.ComboBox cbDataType;
        private System.Windows.Forms.NumericUpDown nudTime;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCmdValue;
    }
}
