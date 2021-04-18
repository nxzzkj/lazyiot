namespace ScadaFlowDesign.Dialog
{
    partial class CreateViewDialog
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
            this.tbViewName = new System.Windows.Forms.TextBox();
            this.nubWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nubHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxShowModel = new System.Windows.Forms.ComboBox();
            this.comboBoxBL = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nubWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nubHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBoxBL);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.comboBoxShowModel);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.nubHeight);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.nubWidth);
            this.panel3.Controls.Add(this.tbViewName);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Size = new System.Drawing.Size(430, 278);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(430, 26);
            this.lblTitle.Text = "创建视图";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(402, 0);
            // 
            // btMin
            // 
            this.btMin.Location = new System.Drawing.Point(370, 0);
            this.btMin.Visible = false;
            // 
            // btMax
            // 
            this.btMax.Location = new System.Drawing.Point(340, 0);
            this.btMax.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(47, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "视图名称:";
            // 
            // tbViewName
            // 
            this.tbViewName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbViewName.Location = new System.Drawing.Point(121, 38);
            this.tbViewName.Name = "tbViewName";
            this.tbViewName.Size = new System.Drawing.Size(274, 26);
            this.tbViewName.TabIndex = 1;
            // 
            // nubWidth
            // 
            this.nubWidth.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nubWidth.Location = new System.Drawing.Point(121, 78);
            this.nubWidth.Maximum = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            this.nubWidth.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nubWidth.Name = "nubWidth";
            this.nubWidth.Size = new System.Drawing.Size(120, 26);
            this.nubWidth.TabIndex = 2;
            this.nubWidth.Value = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(47, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "页面宽度:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(47, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "页面高度:";
            // 
            // nubHeight
            // 
            this.nubHeight.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nubHeight.Location = new System.Drawing.Point(121, 118);
            this.nubHeight.Maximum = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            this.nubHeight.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nubHeight.Name = "nubHeight";
            this.nubHeight.Size = new System.Drawing.Size(120, 26);
            this.nubHeight.TabIndex = 4;
            this.nubHeight.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(247, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "(px)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(247, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "(px)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(47, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "显示终端:";
            // 
            // comboBoxShowModel
            // 
            this.comboBoxShowModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShowModel.FormattingEnabled = true;
            this.comboBoxShowModel.Items.AddRange(new object[] {
            "电脑端",
            "移动端"});
            this.comboBoxShowModel.Location = new System.Drawing.Point(121, 159);
            this.comboBoxShowModel.Name = "comboBoxShowModel";
            this.comboBoxShowModel.Size = new System.Drawing.Size(262, 25);
            this.comboBoxShowModel.TabIndex = 10;
            this.comboBoxShowModel.SelectedIndexChanged += new System.EventHandler(this.comboBoxShowModel_SelectedIndexChanged);
            // 
            // comboBoxBL
            // 
            this.comboBoxBL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBL.FormattingEnabled = true;
            this.comboBoxBL.Items.AddRange(new object[] {
            "4:3",
            "6:9",
            "3:2"});
            this.comboBoxBL.Location = new System.Drawing.Point(121, 199);
            this.comboBoxBL.Name = "comboBoxBL";
            this.comboBoxBL.Size = new System.Drawing.Size(262, 25);
            this.comboBoxBL.TabIndex = 12;
            this.comboBoxBL.SelectedIndexChanged += new System.EventHandler(this.comboBoxBL_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(47, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "显示比例:";
            // 
            // CreateViewDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 368);
            this.Name = "CreateViewDialog";
            this.Text = "CreateViewDialog";
            this.Title = "创建视图";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nubWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nubHeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nubWidth;
        private System.Windows.Forms.TextBox tbViewName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nubHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxShowModel;
        private System.Windows.Forms.ComboBox comboBoxBL;
        private System.Windows.Forms.Label label7;
    }
}