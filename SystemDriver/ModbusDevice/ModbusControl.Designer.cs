namespace ModbusDevice
{
    partial class ModbusControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupRead = new System.Windows.Forms.GroupBox();
            this.rb_w = new System.Windows.Forms.RadioButton();
            this.rb_r = new System.Windows.Forms.RadioButton();
            this.rb_rw = new System.Windows.Forms.RadioButton();
            this.groupposition = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_position = new System.Windows.Forms.TextBox();
            this.cb_position = new System.Windows.Forms.CheckBox();
            this.groupData = new System.Windows.Forms.GroupBox();
            this.cbo_datatype2 = new System.Windows.Forms.ComboBox();
            this.cbo_datatype = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbo_StoreType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_float = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btDelete = new System.Windows.Forms.Button();
            this.cbo_functioncode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labeldata = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupRead.SuspendLayout();
            this.groupposition.SuspendLayout();
            this.groupData.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupRead);
            this.groupBox1.Controls.Add(this.groupposition);
            this.groupBox1.Controls.Add(this.groupData);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btDelete);
            this.groupBox1.Controls.Add(this.labeldata);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 361);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // groupRead
            // 
            this.groupRead.Controls.Add(this.rb_w);
            this.groupRead.Controls.Add(this.rb_r);
            this.groupRead.Controls.Add(this.rb_rw);
            this.groupRead.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupRead.Location = new System.Drawing.Point(3, 265);
            this.groupRead.Name = "groupRead";
            this.groupRead.Size = new System.Drawing.Size(385, 49);
            this.groupRead.TabIndex = 9;
            this.groupRead.TabStop = false;
            // 
            // rb_w
            // 
            this.rb_w.AutoSize = true;
            this.rb_w.Location = new System.Drawing.Point(265, 20);
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
            this.rb_r.Location = new System.Drawing.Point(200, 20);
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
            this.rb_rw.Location = new System.Drawing.Point(112, 20);
            this.rb_rw.Name = "rb_rw";
            this.rb_rw.Size = new System.Drawing.Size(71, 16);
            this.rb_rw.TabIndex = 0;
            this.rb_rw.TabStop = true;
            this.rb_rw.Text = "可读可写";
            this.rb_rw.UseVisualStyleBackColor = true;
            this.rb_rw.CheckedChanged += new System.EventHandler(this.rb_rw_CheckedChanged);
            // 
            // groupposition
            // 
            this.groupposition.Controls.Add(this.label3);
            this.groupposition.Controls.Add(this.tb_position);
            this.groupposition.Controls.Add(this.cb_position);
            this.groupposition.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupposition.Location = new System.Drawing.Point(3, 215);
            this.groupposition.Name = "groupposition";
            this.groupposition.Size = new System.Drawing.Size(385, 50);
            this.groupposition.TabIndex = 15;
            this.groupposition.TabStop = false;
            this.groupposition.Text = "按位读取";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "数据位：";
            // 
            // tb_position
            // 
            this.tb_position.Location = new System.Drawing.Point(241, 19);
            this.tb_position.Name = "tb_position";
            this.tb_position.ReadOnly = true;
            this.tb_position.Size = new System.Drawing.Size(71, 21);
            this.tb_position.TabIndex = 5;
            this.tb_position.Text = "0";
            this.tb_position.TextChanged += new System.EventHandler(this.tb_position_TextChanged);
            // 
            // cb_position
            // 
            this.cb_position.AutoSize = true;
            this.cb_position.Location = new System.Drawing.Point(67, 23);
            this.cb_position.Name = "cb_position";
            this.cb_position.Size = new System.Drawing.Size(72, 16);
            this.cb_position.TabIndex = 0;
            this.cb_position.Text = "按位读写";
            this.cb_position.UseVisualStyleBackColor = true;
            this.cb_position.CheckedChanged += new System.EventHandler(this.cb_position_CheckedChanged);
            // 
            // groupData
            // 
            this.groupData.Controls.Add(this.cbo_datatype2);
            this.groupData.Controls.Add(this.cbo_datatype);
            this.groupData.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupData.Location = new System.Drawing.Point(3, 139);
            this.groupData.Name = "groupData";
            this.groupData.Size = new System.Drawing.Size(385, 76);
            this.groupData.TabIndex = 13;
            this.groupData.TabStop = false;
            this.groupData.Text = "数据格式";
            // 
            // cbo_datatype2
            // 
            this.cbo_datatype2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_datatype2.FormattingEnabled = true;
            this.cbo_datatype2.Location = new System.Drawing.Point(67, 40);
            this.cbo_datatype2.Name = "cbo_datatype2";
            this.cbo_datatype2.Size = new System.Drawing.Size(248, 20);
            this.cbo_datatype2.TabIndex = 12;
            this.cbo_datatype2.SelectedIndexChanged += new System.EventHandler(this.cbo_datatype2_SelectedIndexChanged);
            // 
            // cbo_datatype
            // 
            this.cbo_datatype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_datatype.FormattingEnabled = true;
            this.cbo_datatype.Location = new System.Drawing.Point(67, 14);
            this.cbo_datatype.Name = "cbo_datatype";
            this.cbo_datatype.Size = new System.Drawing.Size(248, 20);
            this.cbo_datatype.TabIndex = 5;
            this.cbo_datatype.SelectedIndexChanged += new System.EventHandler(this.cbo_datatype_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbo_StoreType);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tb_float);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cbo_functioncode);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(385, 122);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "内存设置";
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
            this.cbo_StoreType.Location = new System.Drawing.Point(67, 86);
            this.cbo_StoreType.Name = "cbo_StoreType";
            this.cbo_StoreType.Size = new System.Drawing.Size(248, 20);
            this.cbo_StoreType.TabIndex = 16;
            this.cbo_StoreType.SelectedIndexChanged += new System.EventHandler(this.cbo_StoreType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "存储方式：";
            // 
            // tb_float
            // 
            this.tb_float.Location = new System.Drawing.Point(68, 55);
            this.tb_float.Name = "tb_float";
            this.tb_float.Size = new System.Drawing.Size(248, 21);
            this.tb_float.TabIndex = 3;
            this.tb_float.Text = "0";
            this.tb_float.TextChanged += new System.EventHandler(this.tb_float_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "偏置：";
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(257, 330);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(70, 23);
            this.btDelete.TabIndex = 14;
            this.btDelete.Text = "删除";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // cbo_functioncode
            // 
            this.cbo_functioncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_functioncode.FormattingEnabled = true;
            this.cbo_functioncode.Items.AddRange(new object[] {
            "02号功能码 (DI离散输入量)",
            "01号和05号功能码 (DI离散输入量)",
            "03号功能码 (HR保持寄存器)",
            "04号功能码 (AR保持寄存器)",
            "08号功能码 (诊断)",
            "16号功能码 (强制单个寄存器)",
            "07号功能码 (读不正常状态)"});
            this.cbo_functioncode.Location = new System.Drawing.Point(68, 23);
            this.cbo_functioncode.Name = "cbo_functioncode";
            this.cbo_functioncode.Size = new System.Drawing.Size(248, 20);
            this.cbo_functioncode.TabIndex = 1;
            this.cbo_functioncode.SelectedIndexChanged += new System.EventHandler(this.cbo_functioncode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "内存区：";
            // 
            // labeldata
            // 
            this.labeldata.AutoSize = true;
            this.labeldata.Location = new System.Drawing.Point(98, 335);
            this.labeldata.Name = "labeldata";
            this.labeldata.Size = new System.Drawing.Size(23, 12);
            this.labeldata.TabIndex = 11;
            this.labeldata.Text = "---";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "提示寄存器地址：";
            // 
            // ModbusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ModbusControl";
            this.Size = new System.Drawing.Size(391, 361);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupRead.ResumeLayout(false);
            this.groupRead.PerformLayout();
            this.groupposition.ResumeLayout(false);
            this.groupposition.PerformLayout();
            this.groupData.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupRead;
        private System.Windows.Forms.RadioButton rb_w;
        private System.Windows.Forms.RadioButton rb_r;
        private System.Windows.Forms.RadioButton rb_rw;
        private System.Windows.Forms.GroupBox groupposition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_position;
        private System.Windows.Forms.CheckBox cb_position;
        private System.Windows.Forms.GroupBox groupData;
        private System.Windows.Forms.ComboBox cbo_datatype2;
        private System.Windows.Forms.ComboBox cbo_datatype;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbo_StoreType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_float;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.ComboBox cbo_functioncode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labeldata;
        private System.Windows.Forms.Label label5;
    }
}
