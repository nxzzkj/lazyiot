using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Controls;
using ScadaCenterServer.Controls;
using Scada.Model;
using System.Net;

namespace ScadaCenterServer.Pages
{
    public partial class IOTreeForm : DockForm
    {
        public IOTreeForm(Mediator m):base(m)
        {
           
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.CloseButton = false;
        }
        public IOTreeForm()
        {

            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public override TabTypes TabType
        {
            get
            {
                return TabTypes.IOCatalog;
            }
        }

        private void 实时数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ioTree.SelectedNode!=null&& ioTree.SelectedNode is IoDeviceTreeNode)
            {
                IoDeviceTreeNode Node = ioTree.SelectedNode as IoDeviceTreeNode;
                this.mediator.RealQueryWorkForm.InitDevice(Node.Server, Node.Communication,Node.Device);
            }
       
        }
        /// <summary>
        /// 当前实时设备状态改变信息
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public void DeviceStatus(string IO_SERVER_ID,IO_DEVICE device, bool status)
        {
            ioTree.BeginInvoke(new EventHandler(delegate
            {
                if (this.ioTree.Nodes.Count < 0)
                    return;
                for (int i = 0; i < this.ioTree.Nodes[0].Nodes.Count; i++)
                {

                    TreeNode[] tn = this.ioTree.Nodes[0].Nodes.Find(device.IO_DEVICE_ID.ToString(), true);
                    for(int j=0;j<tn.Length;j++)
                    {
                        if (tn.Length == 1 && tn[j] is Controls.IoDeviceTreeNode)
                        {
                            Controls.IoDeviceTreeNode deviceNode = tn[j] as Controls.IoDeviceTreeNode;
                            if (deviceNode != null&&deviceNode.Device.IO_SERVER_ID== IO_SERVER_ID)
                            {
                                deviceNode.status = status;


                                if (deviceNode.status)
                                {
                                    deviceNode.ForeColor = Color.Green;
                                    deviceNode.Parent.ForeColor = Color.Green;
                                    deviceNode.Parent.Parent.ForeColor = Color.Green;
                                    deviceNode.SelectedImageIndex = 5;
                                    deviceNode.ImageIndex = 5;
                                    deviceNode.Tag = null;
                                }

                                else
                                {
                                    deviceNode.ForeColor = Color.Red;
                                    deviceNode.SelectedImageIndex = 4;
                                    deviceNode.ImageIndex = 4;
                                    deviceNode.Tag = DateTime.Now.ToString("yyyy-MM-dd");

                                }
                            }
                        }

                    }
                }
            }));

        }
        public void ServerStatus(EndPoint clientEndPoint, IO_SERVER server, bool status)
        {
            this.ioTree.BeginInvoke(new EventHandler(delegate
            {
                if (this.ioTree.Nodes.Count < 0)
                    return;
                for (int i = 0; i < this.ioTree.Nodes[0].Nodes.Count; i++)
                {

                    TreeNode[] tn = this.ioTree.Nodes[0].Nodes.Find(server.SERVER_ID.ToString(), false);
                    if (tn.Length == 1)
                    {
                       IoServerTreeNode serverNode = tn[0] as  IoServerTreeNode;
                        if (serverNode != null)
                        {
                            serverNode.ClientEndPoint = clientEndPoint;
                          
                            if (status)
                            {
                                serverNode.ForeColor = Color.Green;
                                serverNode.Tag = null;
                                serverNode.ImageIndex = 2;
                                serverNode.StateImageIndex = 2;
                                serverNode.Text = clientEndPoint.ToString();
                            }
                            else
                            {
                                serverNode.ForeColor = Color.Red;
                                serverNode.Tag = DateTime.Now.ToString("yyyy-MM-dd");
                                serverNode.ImageIndex = 1;
                                serverNode.StateImageIndex = 1;
                                serverNode.Text = server.SERVER_NAME+ "未上线";
                            }

                        }

                    }
                }
            }));

        }

        private void 历史查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ioTree.SelectedNode != null && ioTree.SelectedNode is IoDeviceTreeNode)
            {
                IoDeviceTreeNode Node = ioTree.SelectedNode as IoDeviceTreeNode;
                this.mediator.HistoryQueryWorkForm.InitDevice(Node.Server, Node.Communication, Node.Device);
            }

        }

        private void 历史报警ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ioTree.SelectedNode != null && ioTree.SelectedNode is IoDeviceTreeNode)
            {
                IoDeviceTreeNode Node = ioTree.SelectedNode as IoDeviceTreeNode;
                this.mediator.HistoryAlarmQueryWorkForm.InitDevice(Node.Server, Node.Communication, Node.Device);
            }
        }

        private void 下置查询toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ioTree.SelectedNode != null && ioTree.SelectedNode is IoDeviceTreeNode)
            {
                IoDeviceTreeNode Node = ioTree.SelectedNode as IoDeviceTreeNode;
                this.mediator.SendCommandQueryWorkForm.InitDevice(Node.Server, Node.Communication, Node.Device);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ioTree.SelectedNode != null && ioTree.SelectedNode is IoDeviceTreeNode)
            {
                IoDeviceTreeNode Node = ioTree.SelectedNode as IoDeviceTreeNode;
                this.mediator.AlarmConfigQueryWorkForm.InitDevice(Node.Server, Node.Communication, Node.Device);
            }
        }

        private void 统计查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ioTree.SelectedNode != null && ioTree.SelectedNode is IoDeviceTreeNode)
            {
                IoDeviceTreeNode Node = ioTree.SelectedNode as IoDeviceTreeNode;
                this.mediator.HistoryStaticsQueryWorkForm.InitDevice(Node.Server, Node.Communication, Node.Device);
            }
        }
    }
}
