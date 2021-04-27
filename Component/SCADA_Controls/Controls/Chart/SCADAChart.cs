using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Scada.Controls.Controls.SCADAChart
{
   public  class SCADAChart:Chart
    {
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem toolStripMenuItem1;
        private System.ComponentModel.IContainer components;

        public SCADAChart()
        {
            InitializeComponent();
         
            this.MouseDoubleClick += SCADAChart_MouseDoubleClick;
            
        }
        //设置颜色
        private void SCADAChart_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
           
            HitTestResult result = this.HitTest(e.X, e.Y);
            if(result.Series!=null)
            {
                ColorDialog dig = new ColorDialog();
                dig.Color = result.Series.Color;
                if(dig.ShowDialog()==DialogResult.OK)
                {
                    result.Series.Color = dig.Color;
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "导出图片";
            toolStripMenuItem1.Click += ToolStripMenuItem1_Click;
            // 
            // SCADAChart
            // 
            this.ContextMenuStrip = this.contextMenuStrip;
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dig = new SaveFileDialog();
            dig.Filter = "Jpg(*.jpg)|*.jpg";
            if(dig.ShowDialog()==DialogResult.OK)
            {
                this.SaveImage(dig.FileName, ChartImageFormat.Jpeg);
                MessageBox.Show("导出图片成功!");
            }
        }
    }
}
