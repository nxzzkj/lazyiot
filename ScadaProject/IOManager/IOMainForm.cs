using IOManager.Controls;
using IOManager.Core;
using IOManager.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;

namespace IOManager
{
    public partial class IOMainForm : Form
    {
        public Mediator mediator = null;
        public IOMainForm()
        {
            InitializeComponent();

            mediator = new Mediator(this);
            mediator.DockPanel = dockPanel;
            mediator.parent = this;
            this.WindowState = FormWindowState.Maximized;
            Control.CheckForIllegalCrossThreadCalls = false;


            FormManager.MainForm = this;
        }


        private   void 加载工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                FormManager.LoadProject();
        }

        private   void 新建工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             FormManager.CreateProject();
        }

        private   void 保存工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormManager.Project == "")
                return;
            if (MessageBox.Show(this, "是否要保存采集站工程?", "保存提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                 FormManager.SaveProject();
            }

        }



        private   void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void 驱动管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormManager.Project == "")
                return;
            this.mediator.OpenIODriveManageForm();

        }

        private void 设备驱动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormManager.Project == "")
                return;
            this.mediator.OpenIODriveManageForm();
        }

        private void 工程视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormManager.Project == "")
                return;
            this.mediator.OpenIOTreeForm();
        }

        private void iO表视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormManager.Project == "")
                return;
            this.mediator.OpenIOParaForm();
        }

        private void 日志视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormManager.Project == "")
                return;
            this.mediator.OpenLogForm();
        }

        private  void toolStripMenuItem另存为_Click(object sender, EventArgs e)
        {
            if (FormManager.Project == "")
                return;
             FormManager.SaveAsProject();
        }

        private async void 发布工程toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormManager.Project == "")
                return;
           await  FormManager.PublisProject();
        }

        private void 导出CSVToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private   void IOMainForm_Load(object sender, EventArgs e)
        {
            this.mediator.OpenLogForm();
            this.Text = PubConstant.Product;
            this.mediator.OpenIOTreeForm();
            IOConfig config = new IOConfig();
            if (config.Project != null && config.Project != "")
            {
                FormManager.LoadProject(config.Project);
            }
            
        }

        private   void IOMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (FormManager.Project != null && FormManager.Project != "")
                {


                    if (MessageBox.Show(this, "是否要退出当前工程，退出前系统前请先保存当前工程，以防数据丢失！", "关闭提示", MessageBoxButtons.YesNo,  MessageBoxIcon.Warning) == DialogResult.Yes)
                    {


                        Application.ExitThread();
                        Application.Exit();

                    }
                    else
                    {
                        e.Cancel = false;
                    }

                }





            }
            catch
            {
                e.Cancel = true;
            }
        }

        private   void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mediator.IOParaForm.IOListView.删除参数ToolStripMenuItem_Click(sender, e);
        }

        private void 创建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mediator.IOParaForm.IOListView.添加参数ToolStripMenuItem1_Click(sender, e);
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mediator.IOParaForm.IOListView.编辑参数ToolStripMenuItem_Click(sender, e);
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mediator.IOParaForm.IOListView.toolStripMenuItem全选_Click(sender, e);
        }

        private void 取消全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mediator.IOParaForm.IOListView.取消全选ToolStripMenuItem_Click(sender, e);
        }



        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mediator.IOParaForm.IOListView.粘贴ToolStripMenuItem_Click(sender, e);
        }

        private void 剪贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mediator.IOParaForm.IOListView.剪贴toolStripMenuItem_Click(sender, e);
        }

        private void 复制toolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mediator.IOParaForm.IOListView.复制参数ToolStripMenuItem_Click(sender, e);
        }

        private   void 添加设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mediator.IOTreeForm.SelectedNode is IOCommunicationNode)
            {
                  FormManager.CreateIODeviceNode();
            }

        }

        private void 删除设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mediator.IOTreeForm.SelectedNode is IODeviceNode)
            {
                IODeviceNode deviceNode = this.mediator.IOTreeForm.SelectedNode as IODeviceNode;
                if (MessageBox.Show(this, "是否要删除" + deviceNode.Device.IO_DEVICE_LABLE + "设备?", "删除提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.mediator.IOTreeForm.SelectedNode.Remove();
                }
            }

        }

        private   void 修改设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mediator.IOTreeForm.SelectedNode is IODeviceNode)
            {
                IODeviceNode deviceNode = this.mediator.IOTreeForm.SelectedNode as IODeviceNode;
                  FormManager.EditIODeviceNode(deviceNode);
            }

        }

        private void 删除通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mediator.IOTreeForm.SelectedNode is IOCommunicationNode)
            {
                IOCommunicationNode commNode = this.mediator.IOTreeForm.SelectedNode as IOCommunicationNode;
                if (MessageBox.Show(this, "是否要删除" + commNode.Communication.IO_COMM_LABEL + "设备?", "删除提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.mediator.IOTreeForm.SelectedNode.Remove();
                }
            }
        }

        private   void 修改通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mediator.IOTreeForm.SelectedNode is IOCommunicationNode)
            {
                IOCommunicationNode commNode = this.mediator.IOTreeForm.SelectedNode as IOCommunicationNode;
                  FormManager.EditIOCommunicationNode(commNode);
            }
        }

        private   void 添加通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mediator.IOTreeForm.SelectedNode is IOServerNode)
            {
                  FormManager.CreateIOCommunicationNode();
            }

        }

        private   void 编辑点表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mediator.IOTreeForm.SelectedNode is IODeviceNode)
            {
                IODeviceNode devNode = this.mediator.IOTreeForm.SelectedNode as IODeviceNode;
                IOCommunicationNode comNode = devNode.Parent as IOCommunicationNode;
                IOServerNode sNode = comNode.Parent as IOServerNode;
                  FormManager.OpenDeviceParas(sNode.Server, comNode.Communication, devNode.Device);
            }



        }
    }
}
