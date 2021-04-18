namespace Modbus
{
    partial class ModbusSetCtrl
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
            this.groupRead = new System.Windows.Forms.GroupBox();
            this.rb_w = new System.Windows.Forms.RadioButton();
            this.rb_r = new System.Windows.Forms.RadioButton();
            this.rb_rw = new System.Windows.Forms.RadioButton();
            this.groupposition = new System.Windows.Forms.GroupBox();
            this.cbPosition = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupStored = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelbytesize = new System.Windows.Forms.Label();
            this.cbo_datatype = new System.Windows.Forms.ComboBox();
            this.labelStoredDesc = new System.Windows.Forms.Label();
            this.cbo_StoreType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_functioncode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ndOffset = new System.Windows.Forms.NumericUpDown();
            this.ndCharSize = new System.Windows.Forms.NumericUpDown();
            this.ndPosition = new System.Windows.Forms.NumericUpDown();
            this.groupRead.SuspendLayout();
            this.groupposition.SuspendLayout();
            this.groupStored.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndCharSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // groupRead
            // 
            this.groupRead.Controls.Add(this.rb_w);
            this.groupRead.Controls.Add(this.rb_r);
            this.groupRead.Controls.Add(this.rb_rw);
            this.groupRead.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupRead.Enabled = false;
            this.groupRead.Location = new System.Drawing.Point(0, 239);
            this.groupRead.Name = "groupRead";
            this.groupRead.Size = new System.Drawing.Size(383, 49);
            this.groupRead.TabIndex = 4;
            this.groupRead.TabStop = false;
            // 
            // rb_w
            // 
            this.rb_w.AutoSize = true;
            this.rb_w.Enabled = false;
            this.rb_w.Location = new System.Drawing.Point(219, 20);
            this.rb_w.Name = "rb_w";
            this.rb_w.Size = new System.Drawing.Size(47, 16);
            this.rb_w.TabIndex = 2;
            this.rb_w.TabStop = true;
            this.rb_w.Text = "只写";
            this.rb_w.UseVisualStyleBackColor = true;
            // 
            // rb_r
            // 
            this.rb_r.AutoSize = true;
            this.rb_r.Enabled = false;
            this.rb_r.Location = new System.Drawing.Point(154, 20);
            this.rb_r.Name = "rb_r";
            this.rb_r.Size = new System.Drawing.Size(47, 16);
            this.rb_r.TabIndex = 1;
            this.rb_r.TabStop = true;
            this.rb_r.Text = "只读";
            this.rb_r.UseVisualStyleBackColor = true;
            // 
            // rb_rw
            // 
            this.rb_rw.AutoSize = true;
            this.rb_rw.Checked = true;
            this.rb_rw.Enabled = false;
            this.rb_rw.Location = new System.Drawing.Point(66, 20);
            this.rb_rw.Name = "rb_rw";
            this.rb_rw.Size = new System.Drawing.Size(71, 16);
            this.rb_rw.TabIndex = 0;
            this.rb_rw.TabStop = true;
            this.rb_rw.Text = "可读可写";
            this.rb_rw.UseVisualStyleBackColor = true;
            // 
            // groupposition
            // 
            this.groupposition.Controls.Add(this.ndPosition);
            this.groupposition.Controls.Add(this.cbPosition);
            this.groupposition.Controls.Add(this.label3);
            this.groupposition.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupposition.Location = new System.Drawing.Point(0, 189);
            this.groupposition.Name = "groupposition";
            this.groupposition.Size = new System.Drawing.Size(383, 50);
            this.groupposition.TabIndex = 3;
            this.groupposition.TabStop = false;
            this.groupposition.Text = "按位读取";
            this.groupposition.Visible = false;
            // 
            // cbPosition
            // 
            this.cbPosition.AutoSize = true;
            this.cbPosition.Location = new System.Drawing.Point(68, 22);
            this.cbPosition.Name = "cbPosition";
            this.cbPosition.Size = new System.Drawing.Size(72, 16);
            this.cbPosition.TabIndex = 6;
            this.cbPosition.Text = "按位存取";
            this.cbPosition.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "数据位：";
            // 
            // groupStored
            // 
            this.groupStored.Controls.Add(this.ndCharSize);
            this.groupStored.Controls.Add(this.label5);
            this.groupStored.Controls.Add(this.labelbytesize);
            this.groupStored.Controls.Add(this.cbo_datatype);
            this.groupStored.Controls.Add(this.labelStoredDesc);
            this.groupStored.Controls.Add(this.cbo_StoreType);
            this.groupStored.Controls.Add(this.label7);
            this.groupStored.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupStored.Location = new System.Drawing.Point(0, 92);
            this.groupStored.Name = "groupStored";
            this.groupStored.Size = new System.Drawing.Size(383, 97);
            this.groupStored.TabIndex = 2;
            this.groupStored.TabStop = false;
            this.groupStored.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "存储位置：";
            // 
            // labelbytesize
            // 
            this.labelbytesize.AutoSize = true;
            this.labelbytesize.Location = new System.Drawing.Point(1, 71);
            this.labelbytesize.Name = "labelbytesize";
            this.labelbytesize.Size = new System.Drawing.Size(65, 12);
            this.labelbytesize.TabIndex = 19;
            this.labelbytesize.Text = "字节长度：";
            // 
            // cbo_datatype
            // 
            this.cbo_datatype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_datatype.FormattingEnabled = true;
            this.cbo_datatype.Items.AddRange(new object[] {
            "高八位",
            "低八位"});
            this.cbo_datatype.Location = new System.Drawing.Point(68, 43);
            this.cbo_datatype.Name = "cbo_datatype";
            this.cbo_datatype.Size = new System.Drawing.Size(248, 20);
            this.cbo_datatype.TabIndex = 12;
            this.cbo_datatype.Visible = false;
            // 
            // labelStoredDesc
            // 
            this.labelStoredDesc.AutoSize = true;
            this.labelStoredDesc.Location = new System.Drawing.Point(66, 71);
            this.labelStoredDesc.Name = "labelStoredDesc";
            this.labelStoredDesc.Size = new System.Drawing.Size(77, 12);
            this.labelStoredDesc.TabIndex = 18;
            this.labelStoredDesc.Text = "寄存器数量 1";
            // 
            // cbo_StoreType
            // 
            this.cbo_StoreType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_StoreType.FormattingEnabled = true;
            this.cbo_StoreType.Items.AddRange(new object[] {
            "02号功能码 (DI离散输入量)",
            "01号和05号功能码 (DI离散输入量)",
            "03号功能码 (HR保持寄存器)",
            "04号功能码 (AR保持寄存器)",
            "08号功能码 (诊断)",
            "16号功能码 (强制单个寄存器)",
            "07号功能码 (读不正常状态)"});
            this.cbo_StoreType.Location = new System.Drawing.Point(68, 17);
            this.cbo_StoreType.Name = "cbo_StoreType";
            this.cbo_StoreType.Size = new System.Drawing.Size(248, 20);
            this.cbo_StoreType.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "数据类型：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ndOffset);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbo_functioncode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 92);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "内存设置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "10进制";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "偏置：";
            // 
            // cbo_functioncode
            // 
            this.cbo_functioncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_functioncode.FormattingEnabled = true;
            this.cbo_functioncode.Items.AddRange(new object[] {
            "02号功能码 (DI离散输入量)",
            "01号和05号功能码 (DI离散输入量)",
            "03号功能码 (HR保持寄存器)",
            "04号功能码 (AR保持寄存器)"});
            this.cbo_functioncode.Location = new System.Drawing.Point(68, 23);
            this.cbo_functioncode.Name = "cbo_functioncode";
            this.cbo_functioncode.Size = new System.Drawing.Size(248, 20);
            this.cbo_functioncode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "内存区：";
            // 
            // ndOffset
            // 
            this.ndOffset.Location = new System.Drawing.Point(66, 55);
            this.ndOffset.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ndOffset.Name = "ndOffset";
            this.ndOffset.Size = new System.Drawing.Size(191, 21);
            this.ndOffset.TabIndex = 18;
            // 
            // ndCharSize
            // 
            this.ndCharSize.Location = new System.Drawing.Point(66, 69);
            this.ndCharSize.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ndCharSize.Name = "ndCharSize";
            this.ndCharSize.Size = new System.Drawing.Size(250, 21);
            this.ndCharSize.TabIndex = 22;
            // 
            // ndPosition
            // 
            this.ndPosition.Location = new System.Drawing.Point(233, 19);
            this.ndPosition.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.ndPosition.Name = "ndPosition";
            this.ndPosition.Size = new System.Drawing.Size(53, 21);
            this.ndPosition.TabIndex = 23;
            // 
            // ModbusSetCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupRead);
            this.Controls.Add(this.groupposition);
            this.Controls.Add(this.groupStored);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModbusSetCtrl";
            this.Size = new System.Drawing.Size(383, 326);
            this.groupRead.ResumeLayout(false);
            this.groupRead.PerformLayout();
            this.groupposition.ResumeLayout(false);
            this.groupposition.PerformLayout();
            this.groupStored.ResumeLayout(false);
            this.groupStored.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndCharSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndPosition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupRead;
        private System.Windows.Forms.RadioButton rb_w;
        private System.Windows.Forms.RadioButton rb_r;
        private System.Windows.Forms.RadioButton rb_rw;
        private System.Windows.Forms.GroupBox groupposition;
        private System.Windows.Forms.CheckBox cbPosition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupStored;
        private System.Windows.Forms.Label labelbytesize;
        private System.Windows.Forms.ComboBox cbo_datatype;
        private System.Windows.Forms.Label labelStoredDesc;
        private System.Windows.Forms.ComboBox cbo_StoreType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_functioncode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown ndOffset;
        private System.Windows.Forms.NumericUpDown ndCharSize;
        private System.Windows.Forms.NumericUpDown ndPosition;
    }
}
