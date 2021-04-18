using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;
using Scada.Model;

namespace IOManager.Controls
{
    public  class FormulaBox : UserControl
    {
        private SplitContainer splitContainer1;
        private Button bt_brackets;
        private Button bt_division;
        private Button bt_multi;
        private Button bt_Minus;
        private Button bt_Plus;
        private ComboBox cb_Formula;
        private Button button1;
        private ComboBox cbIo;
        private RichTextBox rtb_Formula;

        public FormulaBox()
        {
            InitializeComponent();
            this.Load += FormulaBox_Load;
        }
        public new string  Text
        {
            set { this.rtb_Formula.Text = value; }
            get { return this.rtb_Formula.Text; }
        }

        private void FormulaBox_Load(object sender, EventArgs e)
        {
            //加载公式
            cb_Formula.Items.Clear();
            List<FunctionItem> maps = AnalyzeCalculate.funMap;
            foreach (FunctionItem str in maps)
            {
                cb_Formula.Items.Add(str);
            }

        }
        /// <summary>
        /// 模拟量
        ///开关量
        ///字符串量
        ///计算值
        ///关系数据库值
        /// </summary>
        /// <param name="device"></param>
        public void InitDevice(IO_DEVICE device)
        {
            cbIo.Items.Clear();
            for (int i=0;i< device.IOParas.Count;i++)
            {
                if(device.IOParas[i].IO_POINTTYPE!="字符串量"&& device.IOParas[i].IO_POINTTYPE != "计算值")
                {
                    cbIo.Items.Add(device.IOParas[i].IO_NAME);
                }

            }
          
        }

        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_Formula = new System.Windows.Forms.ComboBox();
            this.bt_brackets = new System.Windows.Forms.Button();
            this.bt_division = new System.Windows.Forms.Button();
            this.bt_multi = new System.Windows.Forms.Button();
            this.bt_Minus = new System.Windows.Forms.Button();
            this.bt_Plus = new System.Windows.Forms.Button();
            this.rtb_Formula = new System.Windows.Forms.RichTextBox();
            this.cbIo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.cbIo);
            this.splitContainer1.Panel1.Controls.Add(this.cb_Formula);
            this.splitContainer1.Panel1.Controls.Add(this.bt_brackets);
            this.splitContainer1.Panel1.Controls.Add(this.bt_division);
            this.splitContainer1.Panel1.Controls.Add(this.bt_multi);
            this.splitContainer1.Panel1.Controls.Add(this.bt_Minus);
            this.splitContainer1.Panel1.Controls.Add(this.bt_Plus);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtb_Formula);
            this.splitContainer1.Size = new System.Drawing.Size(440, 316);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(361, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 25);
            this.button1.TabIndex = 8;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cb_Formula
            // 
            this.cb_Formula.Dock = System.Windows.Forms.DockStyle.Left;
            this.cb_Formula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Formula.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_Formula.FormattingEnabled = true;
            this.cb_Formula.Location = new System.Drawing.Point(119, 0);
            this.cb_Formula.Name = "cb_Formula";
            this.cb_Formula.Size = new System.Drawing.Size(121, 20);
            this.cb_Formula.TabIndex = 6;
            this.cb_Formula.SelectedIndexChanged += new System.EventHandler(this.cb_Formula_SelectedIndexChanged);
            // 
            // bt_brackets
            // 
            this.bt_brackets.Dock = System.Windows.Forms.DockStyle.Left;
            this.bt_brackets.Location = new System.Drawing.Point(81, 0);
            this.bt_brackets.Name = "bt_brackets";
            this.bt_brackets.Size = new System.Drawing.Size(38, 25);
            this.bt_brackets.TabIndex = 4;
            this.bt_brackets.Text = "()";
            this.bt_brackets.UseVisualStyleBackColor = true;
            this.bt_brackets.Click += new System.EventHandler(this.bt_brackets_Click);
            // 
            // bt_division
            // 
            this.bt_division.Dock = System.Windows.Forms.DockStyle.Left;
            this.bt_division.Location = new System.Drawing.Point(63, 0);
            this.bt_division.Name = "bt_division";
            this.bt_division.Size = new System.Drawing.Size(18, 25);
            this.bt_division.TabIndex = 3;
            this.bt_division.Text = "/";
            this.bt_division.UseVisualStyleBackColor = true;
            this.bt_division.Click += new System.EventHandler(this.bt_division_Click);
            // 
            // bt_multi
            // 
            this.bt_multi.Dock = System.Windows.Forms.DockStyle.Left;
            this.bt_multi.Location = new System.Drawing.Point(43, 0);
            this.bt_multi.Name = "bt_multi";
            this.bt_multi.Size = new System.Drawing.Size(20, 25);
            this.bt_multi.TabIndex = 2;
            this.bt_multi.Text = "*";
            this.bt_multi.UseVisualStyleBackColor = true;
            this.bt_multi.Click += new System.EventHandler(this.bt_multi_Click);
            // 
            // bt_Minus
            // 
            this.bt_Minus.Dock = System.Windows.Forms.DockStyle.Left;
            this.bt_Minus.Location = new System.Drawing.Point(20, 0);
            this.bt_Minus.Name = "bt_Minus";
            this.bt_Minus.Size = new System.Drawing.Size(23, 25);
            this.bt_Minus.TabIndex = 1;
            this.bt_Minus.Text = "~";
            this.bt_Minus.UseVisualStyleBackColor = true;
            this.bt_Minus.Click += new System.EventHandler(this.bt_Minus_Click);
            // 
            // bt_Plus
            // 
            this.bt_Plus.Dock = System.Windows.Forms.DockStyle.Left;
            this.bt_Plus.Location = new System.Drawing.Point(0, 0);
            this.bt_Plus.Name = "bt_Plus";
            this.bt_Plus.Size = new System.Drawing.Size(20, 25);
            this.bt_Plus.TabIndex = 0;
            this.bt_Plus.Text = "+";
            this.bt_Plus.UseVisualStyleBackColor = true;
            this.bt_Plus.Click += new System.EventHandler(this.bt_Plus_Click);
            // 
            // rtb_Formula
            // 
            this.rtb_Formula.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.rtb_Formula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_Formula.DetectUrls = false;
            this.rtb_Formula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Formula.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb_Formula.ForeColor = System.Drawing.Color.Maroon;
            this.rtb_Formula.Location = new System.Drawing.Point(0, 0);
            this.rtb_Formula.Name = "rtb_Formula";
            this.rtb_Formula.ShortcutsEnabled = false;
            this.rtb_Formula.Size = new System.Drawing.Size(440, 287);
            this.rtb_Formula.TabIndex = 0;
            this.rtb_Formula.Text = "";
            // 
            // cbIo
            // 
            this.cbIo.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbIo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbIo.FormattingEnabled = true;
            this.cbIo.Location = new System.Drawing.Point(240, 0);
            this.cbIo.Name = "cbIo";
            this.cbIo.Size = new System.Drawing.Size(121, 20);
            this.cbIo.TabIndex = 9;
            this.cbIo.SelectedIndexChanged += new System.EventHandler(this.cbIo_SelectedIndexChanged);
            // 
            // FormulaBox
            // 
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormulaBox";
            this.Size = new System.Drawing.Size(440, 316);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void bt_Plus_Click(object sender, EventArgs e)
        {
            insert("+");
        }
        /// <summary>
        /// 插入指定的字符串到RichTextBox控件的光标处
        /// </summary>
        /// <param name="inserted">被插入的字符串</param>
        private void insert(string inserted)
        {
            if (rtb_Formula.SelectionLength > 0)
            {
                //如果有选中的内容，则将光标移动到被选中内容之后
                rtb_Formula.SelectionStart = rtb_Formula.SelectionStart + rtb_Formula.SelectionLength;
            }
            rtb_Formula.SelectedText = inserted;
        }


        private void bt_Minus_Click(object sender, EventArgs e)
        {
            insert("~");
        }

        private void bt_multi_Click(object sender, EventArgs e)
        {
            insert("*");
        }

        private void bt_division_Click(object sender, EventArgs e)
        {
            insert("/");
        }

        private void bt_brackets_Click(object sender, EventArgs e)
        {
            insert("()");
        }
        //插入公式
        private void cb_Formula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_Formula!=null)
            {
                insert(cb_Formula.SelectedItem.ToString()+"()");
            }
       
        }

        private void cbIo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIo != null)
            {
                insert(cbIo.SelectedItem.ToString());
            }
        }
        /// <summary>
        /// 检验公式正确性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Check_Click(object sender, EventArgs e)
        {

        }
    }
}
