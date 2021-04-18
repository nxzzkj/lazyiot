namespace ScadaFlowDesign.Dialog
{
    partial class SaveViewTemplateFrm
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbClassic = new System.Windows.Forms.ComboBox();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbName);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.cbClassic);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Size = new System.Drawing.Size(508, 149);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(508, 26);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(480, 0);
            // 
            // btMin
            // 
            this.btMin.Location = new System.Drawing.Point(448, 0);
            // 
            // btMax
            // 
            this.btMax.Location = new System.Drawing.Point(418, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "模板名称:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(103, 44);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(350, 26);
            this.tbName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "分类:";
            // 
            // cbClassic
            // 
            this.cbClassic.FormattingEnabled = true;
            this.cbClassic.Location = new System.Drawing.Point(103, 76);
            this.cbClassic.Name = "cbClassic";
            this.cbClassic.Size = new System.Drawing.Size(350, 28);
            this.cbClassic.TabIndex = 5;
            // 
            // SaveViewTemplateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 239);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveViewTemplateFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "模板保存";
            this.Load += new System.EventHandler(this.SaveViewTemplateFrm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbClassic;
    }
}