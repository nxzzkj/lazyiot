namespace IOManager.Page
{
    partial class IOParaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOParaForm));
            this.ioListView = new IOManager.Controls.IOListView();
            this.IO_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_NAME = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_LABEL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_PARASTRING = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_DATATYPE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_OUTLIES = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_INITALVALUE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_MINVALUE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_MAXVALUE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_ENABLERANGECONVERSION = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_RANGEMIN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_RANGEMAX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_POINTTYPE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_ZERO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_ONE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_UNIT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_HISTORY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_ADDRESS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_ENABLEALARM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IO_SYSTEM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // ioListView
            // 
            this.ioListView.Communication = null;
            this.ioListView.Device = null;
            this.ioListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ioListView.IOPath = "";
            // 
            // ioListView.ListVIew
            // 
            this.ioListView.ListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ioListView.ListView.CheckBoxes = true;
            this.ioListView.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IO_ID,
            this.IO_NAME,
            this.IO_LABEL,
            this.IO_PARASTRING,
            this.IO_DATATYPE,
            this.IO_OUTLIES,
            this.IO_INITALVALUE,
            this.IO_MINVALUE,
            this.IO_MAXVALUE,
            this.IO_ENABLERANGECONVERSION,
            this.IO_RANGEMIN,
            this.IO_RANGEMAX,
            this.IO_POINTTYPE,
            this.IO_ZERO,
            this.IO_ONE,
            this.IO_UNIT,
            this.IO_HISTORY,
            this.IO_ADDRESS,
            this.IO_ENABLEALARM,
            this.IO_SYSTEM});
            this.ioListView.ListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ioListView.ListView.FullRowSelect = true;
            this.ioListView.ListView.GridLines = true;
            this.ioListView.ListView.LargeImageList = this.imageList1;
            this.ioListView.ListView.Location = new System.Drawing.Point(0, 0);
            this.ioListView.ListView.Name = "ListVIew";
            this.ioListView.ListView.Size = new System.Drawing.Size(745, 502);
            this.ioListView.ListView.SmallImageList = this.imageList1;
            this.ioListView.ListView.StateImageList = this.imageList1;
            this.ioListView.ListView.TabIndex = 0;
            this.ioListView.ListView.UseCompatibleStateImageBehavior = false;
            this.ioListView.ListView.View = System.Windows.Forms.View.Details;
            this.ioListView.Location = new System.Drawing.Point(0, 0);
            this.ioListView.Name = "ioListView";
            this.ioListView.Server = null;
            this.ioListView.Size = new System.Drawing.Size(745, 531);
            this.ioListView.TabIndex = 1;
            // 
            // IO_ID
            // 
            this.IO_ID.Text = "IO_ID";
            // 
            // IO_NAME
            // 
            this.IO_NAME.Text = "IO名称";
            // 
            // IO_LABEL
            // 
            this.IO_LABEL.Text = "IO中文名称";
            this.IO_LABEL.Width = 90;
            // 
            // IO_PARASTRING
            // 
            this.IO_PARASTRING.Text = "驱动参数";
            this.IO_PARASTRING.Width = 144;
            // 
            // IO_DATATYPE
            // 
            this.IO_DATATYPE.Text = "IO数据类型";
            this.IO_DATATYPE.Width = 90;
            // 
            // IO_OUTLIES
            // 
            this.IO_OUTLIES.Text = "小数位数";
            // 
            // IO_INITALVALUE
            // 
            this.IO_INITALVALUE.Text = "默认值";
            this.IO_INITALVALUE.Width = 71;
            // 
            // IO_MINVALUE
            // 
            this.IO_MINVALUE.Text = "裸数据最小值";
            this.IO_MINVALUE.Width = 93;
            // 
            // IO_MAXVALUE
            // 
            this.IO_MAXVALUE.Text = "裸数据最大值";
            this.IO_MAXVALUE.Width = 98;
            // 
            // IO_ENABLERANGECONVERSION
            // 
            this.IO_ENABLERANGECONVERSION.Text = "量程变化";
            this.IO_ENABLERANGECONVERSION.Width = 78;
            // 
            // IO_RANGEMIN
            // 
            this.IO_RANGEMIN.Text = "最小量程";
            this.IO_RANGEMIN.Width = 79;
            // 
            // IO_RANGEMAX
            // 
            this.IO_RANGEMAX.Text = "最大量程";
            this.IO_RANGEMAX.Width = 78;
            // 
            // IO_POINTTYPE
            // 
            this.IO_POINTTYPE.Text = "IO点类型";
            this.IO_POINTTYPE.Width = 90;
            // 
            // IO_ZERO
            // 
            this.IO_ZERO.Text = "开关0值标示";
            this.IO_ZERO.Width = 82;
            // 
            // IO_ONE
            // 
            this.IO_ONE.Text = "开关1值标示";
            this.IO_ONE.Width = 85;
            // 
            // IO_UNIT
            // 
            this.IO_UNIT.Text = "单位";
            // 
            // IO_HISTORY
            // 
            this.IO_HISTORY.Text = "保存历史";
            // 
            // IO_ADDRESS
            // 
            this.IO_ADDRESS.Text = "IO地址";
            this.IO_ADDRESS.Width = 70;
            // 
            // IO_ENABLEALARM
            // 
            this.IO_ENABLEALARM.Text = "启用报警";
            // 
            // IO_SYSTEM
            // 
            this.IO_SYSTEM.Text = "系统IO";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "network%20harddrive.ico");
            // 
            // IOParaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 531);
            this.Controls.Add(this.ioListView);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IOParaForm";
            this.Text = "IOParaForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.IOListView ioListView;
        private System.Windows.Forms.ColumnHeader IO_NAME;
        private System.Windows.Forms.ColumnHeader IO_LABEL;
        private System.Windows.Forms.ColumnHeader IO_PARASTRING;
        private System.Windows.Forms.ColumnHeader IO_DATATYPE;
        private System.Windows.Forms.ColumnHeader IO_INITALVALUE;
        private System.Windows.Forms.ColumnHeader IO_MINVALUE;
        private System.Windows.Forms.ColumnHeader IO_MAXVALUE;
        private System.Windows.Forms.ColumnHeader IO_ENABLERANGECONVERSION;
        private System.Windows.Forms.ColumnHeader IO_RANGEMIN;
        private System.Windows.Forms.ColumnHeader IO_RANGEMAX;
        private System.Windows.Forms.ColumnHeader IO_POINTTYPE;
        private System.Windows.Forms.ColumnHeader IO_ZERO;
        private System.Windows.Forms.ColumnHeader IO_ONE;
        private System.Windows.Forms.ColumnHeader IO_UNIT;
        private System.Windows.Forms.ColumnHeader IO_HISTORY;
        private System.Windows.Forms.ColumnHeader IO_ADDRESS;
        private System.Windows.Forms.ColumnHeader IO_ENABLEALARM;
        private System.Windows.Forms.ColumnHeader IO_SYSTEM;
        private System.Windows.Forms.ColumnHeader IO_OUTLIES;
        private System.Windows.Forms.ColumnHeader IO_ID;
        private System.Windows.Forms.ImageList imageList1;
    }
}