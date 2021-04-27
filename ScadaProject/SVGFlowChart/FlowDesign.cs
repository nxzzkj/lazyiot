using Scada.Controls.Forms;
using ScadaFlowDesign.Control;
using ScadaFlowDesign.Core;
using Scada.FlowGraphEngine;
using Scada.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScadaFlowDesign
{
    public partial class FlowDesign : FrmWithTitle
    {
        public Mediator mediator;
        public DockPanel DockPanel
        {
            get { return this.dockPanel; }
        }
        public FlowDesign()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            this.Load += FlowDesign_Load;


        }

        private void FlowDesign_Load(object sender, EventArgs e)
        {
            toolStripZoom.SelectedIndex = 6;
            List<string> fiels = new List<string>();
            StreamReader sr = new StreamReader(Application.StartupPath + "//Lately.log", Encoding.Default);
            while (!sr.EndOfStream)
            {
                fiels.Add(sr.ReadLine());
                if (fiels.Count > 10)
                {
                    fiels.RemoveAt(0);
                }
            }
            sr.Close();
            foreach (string str in fiels)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = str;
                item.Click += Item_Click;
                最近打开ToolStripMenuItem.DropDownItems.Add(item);
            }
            Task.Run(delegate
            {
                ScadaAnalysisSymbol.LoadSymbol();
            });
        }

        private void Item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            FlowManager.LoadProject(item.Text);
        }



        private void 属性区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            属性区ToolStripMenuItem.Checked = !属性区ToolStripMenuItem.Checked;
            if (属性区ToolStripMenuItem.Checked)
            {
                this.mediator.PropertiesForm.DockState = DockState.DockRight;
            }
            else
            {
                this.mediator.PropertiesForm.DockState = DockState.Hidden;
            }

        }

        private void 目录区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            目录区ToolStripMenuItem.Checked = !目录区ToolStripMenuItem.Checked;
            if (目录区ToolStripMenuItem.Checked)
            {
                this.mediator.ToolForm.DockState = DockState.DockLeft;
            }
            else
            {
                this.mediator.ToolForm.DockState = DockState.Hidden;
            }


        }

        private void 图元视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            图元视图ToolStripMenuItem.Checked = !图元视图ToolStripMenuItem.Checked;
            if (图元视图ToolStripMenuItem.Checked)
            {
                this.mediator.ShapeForm.DockState = DockState.DockLeft;
            }
            else
            {
                this.mediator.ShapeForm.DockState = DockState.Hidden;
            }

        }
        private void 日志视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            日志视图ToolStripMenuItem.Checked = !日志视图ToolStripMenuItem.Checked;
            if (日志视图ToolStripMenuItem.Checked)
            {
                this.mediator.LogForm.DockState = DockState.DockBottom;
            }
            else
            {
                this.mediator.LogForm.DockState = DockState.Hidden;
            }
        }
        private void 新建页面ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            mediator.ToolForm.CreateView();

        }
        public ToolStripStatusLabel ToolStatusInfo
        {
            get { return toolStripInfo; }
        }
        public void SetStatusText(string msg)
        {
            toolStripInfo.Text = msg;
        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,this.mediator.DockPanel.Documents.Length.ToString());
        }

        private void 新建工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlowManager.CreateNewProject();
        }

        private void 保存工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < FlowManager.Projects.Count; i++)
            {

                FlowManager.SaveProject(FlowManager.Projects[i]);

            }

        }

        private void 发布工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(FrmDialog.ShowDialog(this,"是否要发布选中的流程","发布流程提示",true)==DialogResult.OK)
            {
                FlowManager.PublishProject();
            }
   
        }

        private void 预览工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlowManager.ViewProject();
    
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlowManager.SaveAsProject();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                this.Close();

        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmDialog.ShowDialog(this, "是否要删除当前活动视图中选择的图元", "删除提示", true, true, true, true) == DialogResult.OK)
            {
                if (FlowManager.Graph != null)
                {
                    FlowManager.Graph.Delete();
                }
            }
        }



        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlowManager.Graph == null)
                return;
            FlowManager.Graph.Paste();
        }





        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlowManager.Graph == null)
                return;
            FlowManager.Graph.Copy();

        }

        private void 上移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlowManager.Graph == null)
                return;
            if (FlowManager.Graph.Hover != null)
            {
                FlowManager.Graph.SendForwards(FlowManager.Graph.Hover);
            }

        }

        private void 下移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlowManager.Graph == null)
                return;
            if (FlowManager.Graph.Hover != null)
            {
                FlowManager.Graph.SendBackwards(FlowManager.Graph.Hover);
            }
        }

        private void 置顶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlowManager.Graph == null)
                return;
            if (FlowManager.Graph.Hover != null)
            {
                FlowManager.Graph.SendToFront(FlowManager.Graph.Hover);
            }
        }

        private void 置底ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlowManager.Graph == null)
                return;
            if (FlowManager.Graph.Hover != null)
            {
                FlowManager.Graph.SendToBack(FlowManager.Graph.Hover);
            }
        }

        private void 打开工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlowManager.OpenProject();
        }


        private void 剪贴toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlowManager.Graph == null)
                return;
            FlowManager.Graph.Cut();
        }

        private void 删除工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlowManager.DeleteProject();
 
        }

        private void 删除视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlowManager.DeleteView();
        }
        public void SetHoverInformation(string msg)
        {
            this.toolStripHitHover.Text = msg;

        }
        public void SetGraphMouseInformation(string msg)
        {
            this.toolStripMapXY.Text = msg;
        }
        public void SetCombination()
        {
            toolCombination.Visible = false;
            toolUnCombination.Visible = true;
        }
        public void SetUnCombination()
        {
            toolCombination.Visible = true;
            toolUnCombination.Visible = false;

        }
        public void SetUnLock(bool res)
        {
            this.toolLocked.Checked = res;
        }

        private void toolCombination_Click(object sender, EventArgs e)
        {
            if (this.mediator.ActiveWork != null)
            {
                ((WorkForm)this.mediator.ActiveWork).GraphControl.Combination();

            }
        }

        private void toolUnCombination_Click(object sender, EventArgs e)
        {
            if (this.mediator.ActiveWork != null)
            {
                ((WorkForm)this.mediator.ActiveWork).GraphControl.UnCombination();

            }
        }

        private void toolLocked_Click(object sender, EventArgs e)
        {
            toolLocked.Checked = !toolLocked.Checked;
            ((WorkForm)this.mediator.ActiveWork).GraphControl.LockedShape(toolLocked.Checked);
        }

        private void FlowDesign_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FrmDialog.ShowDialog(this, "退出系统前请先保存工程,是否要退出当前系统?", "退出提示", true, true, true, true) == DialogResult.OK)
            {
                FlowManager.FlowManagerClose();
               

            }
            else
            {
                e.Cancel=true;
            }
            
        }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mediator.ToolForm.AddFlowUser();
        }

        private void 编辑用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mediator.ToolForm.EditFlowUser();
        }

        private void 删除用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mediator.ToolForm.DeleteFlowUser();
        }

        private void 图标资源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://icon.52112.com");
        }

        private void toolStripZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.mediator.ActiveWork!=null)
            {
                WorkForm workForm =(WorkForm) this.mediator.ActiveWork;
                workForm.GraphControl.Zoom = float.Parse(toolStripZoom.SelectedItem.ToString()) / 100;
            }

        }

        private void dockPanel_ActiveDocumentChanged(object sender, EventArgs e)
        {
            if (this.mediator.ActiveWork != null)
            {
                WorkForm workForm = (WorkForm)this.mediator.ActiveWork;
                for(int i=0;i< toolStripZoom.Items.Count;i++)
                {
                    if (toolStripZoom.Items[i].ToString()==Convert.ToInt32(workForm.GraphControl.Zoom*100).ToString())
                    {
                        toolStripZoom.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
    }
}