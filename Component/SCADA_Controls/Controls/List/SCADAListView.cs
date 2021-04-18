using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scada.Controls.Controls.List
{
    /// <summary>
    /// 解决闪烁的问题
    /// </summary>
    public class SCADAListView : ListView
    {
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem toolStripMenuItemExport;
        private ToolStripMenuItem toolStripMenuItemClear;
        private System.ComponentModel.IContainer components;

        public SCADAListView()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            this.FullRowSelect = true;
            this.HeaderStyle = ColumnHeaderStyle.Nonclickable;
           


        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCADAListView));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemExport,
            this.toolStripMenuItemClear});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(193, 114);
            // 
            // toolStripMenuItemExport
            // 
            this.toolStripMenuItemExport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemExport.Image")));
            this.toolStripMenuItemExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItemExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemExport.Name = "toolStripMenuItemExport";
            this.toolStripMenuItemExport.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItemExport.Text = "导出";
            this.toolStripMenuItemExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripMenuItemExport.Click += ToolStripMenuItemExport_Click;
            // 
            // toolStripMenuItemClear
            // 
            this.toolStripMenuItemClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemClear.Image")));
            this.toolStripMenuItemClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItemClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            this.toolStripMenuItemClear.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItemClear.Text = "清空内容";
            this.toolStripMenuItemClear.Click += ToolStripMenuItemClear_Click;
            this.toolStripMenuItemClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SCADAListView
            // 
            this.ContextMenuStrip = this.contextMenuStrip;
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void ToolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            this.Items.Clear();
        }
        private void Export()  //filePath为保存到本地磁盘的位置
        {
            SaveFileDialog dig = new SaveFileDialog();
            dig.Filter = "Excel(*.csv)|*.csv";
            if (dig.ShowDialog() == DialogResult.OK)
            {


                using (StreamWriter sw = new StreamWriter(dig.FileName,false,Encoding.Default))
                {
                   

                    string col_txt = "";
                    string row_txt = "";

                    foreach (ColumnHeader item in this.Columns)  // dt  为DataTable  循环写入列标题
                    {
                        col_txt += item.Text + ",";
                    }
                    col_txt = col_txt.Substring(0, col_txt.Length - 1);  //去掉最后多于的逗号
                    sw.WriteLine(col_txt);


                    foreach (ListViewItem item in this.Items)//循环写入行数据

                    {
                        row_txt = "";//容易漏写，造成数据的重复写入
                        for (int i = 0; i < item.SubItems.Count; i++)
                        {
                            row_txt += item.SubItems[i].Text.ToString() + ",";
                        }
                        row_txt = row_txt.Substring(0, row_txt.Length - 1); //去掉最后多于的逗号

                        sw.WriteLine(row_txt);//写入更改
                    }
                    sw.Flush();   //此处必须有此操作
                    sw.Close();
                }
            }
        }


        private void ToolStripMenuItemExport_Click(object sender, EventArgs e)
        {
            Export();
        }
    }
}
