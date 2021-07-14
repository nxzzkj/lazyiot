
namespace MQTTClientSimulator
{
    partial class AddDevice
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbDeviceID = new System.Windows.Forms.TextBox();
            this.dataGridViewPara = new System.Windows.Forms.DataGridView();
            this.IOName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulatormax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulatormin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btEdit = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.tbClientID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbUpdateCycle = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPara)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备ID";
            // 
            // tbDeviceID
            // 
            this.tbDeviceID.Location = new System.Drawing.Point(68, 12);
            this.tbDeviceID.Name = "tbDeviceID";
            this.tbDeviceID.Size = new System.Drawing.Size(256, 21);
            this.tbDeviceID.TabIndex = 1;
            // 
            // dataGridViewPara
            // 
            this.dataGridViewPara.AllowUserToAddRows = false;
            this.dataGridViewPara.AllowUserToDeleteRows = false;
            this.dataGridViewPara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPara.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IOName,
            this.simulatormax,
            this.simulatormin});
            this.dataGridViewPara.Location = new System.Drawing.Point(12, 142);
            this.dataGridViewPara.MultiSelect = false;
            this.dataGridViewPara.Name = "dataGridViewPara";
            this.dataGridViewPara.RowTemplate.Height = 23;
            this.dataGridViewPara.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPara.Size = new System.Drawing.Size(646, 270);
            this.dataGridViewPara.TabIndex = 2;
            // 
            // IOName
            // 
            this.IOName.DataPropertyName = "name";
            this.IOName.HeaderText = "IO 名称";
            this.IOName.Name = "IOName";
            // 
            // simulatormax
            // 
            this.simulatormax.DataPropertyName = "SimulatorMax";
            this.simulatormax.HeaderText = "模拟最大值";
            this.simulatormax.Name = "simulatormax";
            // 
            // simulatormin
            // 
            this.simulatormin.DataPropertyName = "SimulatorMin";
            this.simulatormin.HeaderText = "模拟最小值";
            this.simulatormin.Name = "simulatormin";
            // 
            // btEdit
            // 
            this.btEdit.Location = new System.Drawing.Point(84, 418);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(66, 23);
            this.btEdit.TabIndex = 19;
            this.btEdit.Text = "修改";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(12, 418);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(66, 23);
            this.btAdd.TabIndex = 18;
            this.btAdd.Text = "增加";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(592, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(520, 446);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(156, 418);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(66, 23);
            this.btDelete.TabIndex = 22;
            this.btDelete.Text = "删除";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(68, 39);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(256, 21);
            this.tbName.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "设备名称";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(536, 95);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 23);
            this.button4.TabIndex = 28;
            this.button4.Text = "自动分配";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tbClientID
            // 
            this.tbClientID.Location = new System.Drawing.Point(68, 95);
            this.tbClientID.Name = "tbClientID";
            this.tbClientID.Size = new System.Drawing.Size(458, 21);
            this.tbClientID.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "MQTT客户端ID:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(507, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 32;
            this.label13.Text = "ms";
            // 
            // tbUpdateCycle
            // 
            this.tbUpdateCycle.Location = new System.Drawing.Point(441, 39);
            this.tbUpdateCycle.Name = "tbUpdateCycle";
            this.tbUpdateCycle.Size = new System.Drawing.Size(51, 21);
            this.tbUpdateCycle.TabIndex = 31;
            this.tbUpdateCycle.Text = "1000";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(352, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 12);
            this.label12.TabIndex = 30;
            this.label12.Text = "数据更新周期:";
            // 
            // AddDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 502);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbUpdateCycle);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tbClientID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.dataGridViewPara);
            this.Controls.Add(this.tbDeviceID);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑设备";
            this.Load += new System.EventHandler(this.AddDevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPara)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDeviceID;
        private System.Windows.Forms.DataGridView dataGridViewPara;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn IOName;
        private System.Windows.Forms.DataGridViewTextBoxColumn simulatormax;
        private System.Windows.Forms.DataGridViewTextBoxColumn simulatormin;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tbClientID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbUpdateCycle;
        private System.Windows.Forms.Label label12;
    }
}