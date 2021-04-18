namespace Scada.Controls.Controls.Page
{
    partial class SCADAPager
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
            this.comboBoxPage = new System.Windows.Forms.ComboBox();
            this.labelPageInfo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ucBtnFirst = new Scada.Controls.Controls.UCBtnExt();
            this.ucBtnNext = new Scada.Controls.Controls.UCBtnExt();
            this.ucBtnPreview = new Scada.Controls.Controls.UCBtnExt();
            this.ucBtnEnd = new Scada.Controls.Controls.UCBtnExt();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPage
            // 
            this.comboBoxPage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboBoxPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxPage.FormattingEnabled = true;
            this.comboBoxPage.Location = new System.Drawing.Point(351, 3);
            this.comboBoxPage.Name = "comboBoxPage";
            this.comboBoxPage.Size = new System.Drawing.Size(114, 25);
            this.comboBoxPage.TabIndex = 20;
            this.comboBoxPage.SelectedIndexChanged += new System.EventHandler(this.comboBoxPage_SelectedIndexChanged);
            // 
            // labelPageInfo
            // 
            this.labelPageInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPageInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPageInfo.Location = new System.Drawing.Point(471, 0);
            this.labelPageInfo.Name = "labelPageInfo";
            this.labelPageInfo.Size = new System.Drawing.Size(224, 32);
            this.labelPageInfo.TabIndex = 21;
            this.labelPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ucBtnFirst, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelPageInfo, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucBtnNext, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxPage, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucBtnPreview, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucBtnEnd, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(698, 32);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // ucBtnFirst
            // 
            this.ucBtnFirst.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnFirst.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnFirst.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnFirst.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnFirst.BtnText = "首页";
            this.ucBtnFirst.ConerRadius = 8;
            this.ucBtnFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnFirst.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ucBtnFirst.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnFirst.ForeColor = System.Drawing.Color.White;
            this.ucBtnFirst.IsRadius = true;
            this.ucBtnFirst.IsShowRect = false;
            this.ucBtnFirst.IsShowTips = false;
            this.ucBtnFirst.Location = new System.Drawing.Point(0, 0);
            this.ucBtnFirst.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnFirst.Name = "ucBtnFirst";
            this.ucBtnFirst.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnFirst.RectWidth = 1;
            this.ucBtnFirst.Size = new System.Drawing.Size(86, 31);
            this.ucBtnFirst.TabIndex = 16;
            this.ucBtnFirst.TabStop = false;
            this.ucBtnFirst.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnFirst.TipsText = "";
            this.ucBtnFirst.BtnClick += new System.EventHandler(this.ucBtnFirst_BtnClick);
            // 
            // ucBtnNext
            // 
            this.ucBtnNext.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnNext.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnNext.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnNext.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnNext.BtnText = "下一页";
            this.ucBtnNext.ConerRadius = 8;
            this.ucBtnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnNext.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.ucBtnNext.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnNext.ForeColor = System.Drawing.Color.White;
            this.ucBtnNext.IsRadius = true;
            this.ucBtnNext.IsShowRect = false;
            this.ucBtnNext.IsShowTips = false;
            this.ucBtnNext.Location = new System.Drawing.Point(87, 0);
            this.ucBtnNext.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnNext.Name = "ucBtnNext";
            this.ucBtnNext.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnNext.RectWidth = 1;
            this.ucBtnNext.Size = new System.Drawing.Size(86, 31);
            this.ucBtnNext.TabIndex = 18;
            this.ucBtnNext.TabStop = false;
            this.ucBtnNext.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnNext.TipsText = "";
            this.ucBtnNext.BtnClick += new System.EventHandler(this.ucBtnNext_BtnClick);
            // 
            // ucBtnPreview
            // 
            this.ucBtnPreview.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnPreview.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnPreview.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnPreview.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnPreview.BtnText = "上一页";
            this.ucBtnPreview.ConerRadius = 8;
            this.ucBtnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnPreview.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.ucBtnPreview.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnPreview.ForeColor = System.Drawing.Color.White;
            this.ucBtnPreview.IsRadius = true;
            this.ucBtnPreview.IsShowRect = false;
            this.ucBtnPreview.IsShowTips = false;
            this.ucBtnPreview.Location = new System.Drawing.Point(174, 0);
            this.ucBtnPreview.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnPreview.Name = "ucBtnPreview";
            this.ucBtnPreview.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnPreview.RectWidth = 1;
            this.ucBtnPreview.Size = new System.Drawing.Size(86, 31);
            this.ucBtnPreview.TabIndex = 19;
            this.ucBtnPreview.TabStop = false;
            this.ucBtnPreview.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnPreview.TipsText = "";
            this.ucBtnPreview.BtnClick += new System.EventHandler(this.ucBtnPreview_BtnClick);
            // 
            // ucBtnEnd
            // 
            this.ucBtnEnd.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnEnd.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnEnd.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnEnd.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnEnd.BtnText = "尾页";
            this.ucBtnEnd.ConerRadius = 8;
            this.ucBtnEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnEnd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.ucBtnEnd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnEnd.ForeColor = System.Drawing.Color.White;
            this.ucBtnEnd.IsRadius = true;
            this.ucBtnEnd.IsShowRect = false;
            this.ucBtnEnd.IsShowTips = false;
            this.ucBtnEnd.Location = new System.Drawing.Point(261, 0);
            this.ucBtnEnd.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnEnd.Name = "ucBtnEnd";
            this.ucBtnEnd.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnEnd.RectWidth = 1;
            this.ucBtnEnd.Size = new System.Drawing.Size(86, 31);
            this.ucBtnEnd.TabIndex = 17;
            this.ucBtnEnd.TabStop = false;
            this.ucBtnEnd.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnEnd.TipsText = "";
            this.ucBtnEnd.BtnClick += new System.EventHandler(this.ucBtnEnd_BtnClick);
            // 
            // SCADAPager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SCADAPager";
            this.Size = new System.Drawing.Size(698, 32);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCBtnExt ucBtnFirst;
        private UCBtnExt ucBtnEnd;
        private UCBtnExt ucBtnNext;
        private UCBtnExt ucBtnPreview;
        private System.Windows.Forms.ComboBox comboBoxPage;
        private System.Windows.Forms.Label labelPageInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
