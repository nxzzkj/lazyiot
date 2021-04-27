namespace Scada.Controls.Controls.FactoryControls.Meter
{
    partial class UCMeterEx
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
            this.ucMeter = new Scada.Controls.Controls.UCMeter();
            this.labelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucMeter
            // 
            this.ucMeter.BoundaryLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMeter.ExternalRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter.FixedText = "%";
            this.ucMeter.InsideRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ucMeter.Location = new System.Drawing.Point(0, 0);
            this.ucMeter.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ucMeter.MeterDegrees = 250;
            this.ucMeter.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucMeter.Name = "ucMeter";
            this.ucMeter.PointerColor = System.Drawing.Color.Blue;
            this.ucMeter.ScaleColor = System.Drawing.Color.Black;
            this.ucMeter.ScaleValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter.Size = new System.Drawing.Size(199, 187);
            this.ucMeter.SplitCount = 10;
            this.ucMeter.TabIndex = 12;
            this.ucMeter.TextColor = System.Drawing.Color.RoyalBlue;
            this.ucMeter.TextFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucMeter.TextLocation = Scada.Controls.Controls.MeterTextLocation.Bottom;
            this.ucMeter.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelTitle.Location = new System.Drawing.Point(0, 187);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(199, 31);
            this.labelTitle.TabIndex = 13;
            this.labelTitle.Text = "名称";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCMeterEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucMeter);
            this.Controls.Add(this.labelTitle);
            this.Name = "UCMeterEx";
            this.Size = new System.Drawing.Size(199, 218);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelTitle;
        public UCMeter ucMeter;
    }
}
