using Scada.Model;
using IOManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOManager.Controls
{
    public class IOTree : TreeView
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        protected override void WndProc(ref Message m)
        {

            if (m.Msg == 0x0014) // 禁掉清除背景消息WM_ERASEBKGND

                return;

            base.WndProc(ref m);

        }

        public IOServerNode GetServerNode(IO_SERVER server)
        {

            for(int i=0;i<this.Nodes.Count;i++)
            {
                if(this.Nodes[i] is IOServerNode)
                {
                    IOServerNode serNode = this.Nodes[i] as IOServerNode;
                    if(serNode.Server==server)
                    {
                        return serNode;
                    }
                }
               

            }
            return null;
        }
        public IOCommunicationNode GetCommunicationNode(IO_SERVER server, IO_COMMUNICATION communication)
        {

            for (int i = 0; i < this.Nodes.Count; i++)
            {
                if (this.Nodes[i] is IOServerNode)
                {
                    IOServerNode serNode = this.Nodes[i] as IOServerNode;
                    if (serNode.Server == server)
                    {
                        for (int j = 0; j < serNode.Nodes.Count; j++)
                        {
                            if (serNode.Nodes[j] is IOCommunicationNode)
                            {
                                IOCommunicationNode commNode = serNode.Nodes[j] as IOCommunicationNode;
                                if (commNode.Communication == communication)
                                {
                                    return commNode;
                                }
                            }


                        }
                    }
                }


            }

           
            return null;
        }
        public IOTree()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer |
                  ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
       
            this.LabelEdit = false;
            this.NodeMouseDoubleClick += IOTree_NodeMouseDoubleClick;
            this.NodeMouseClick += IOTree_NodeMouseClick;
        }

        private   void IOTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Clicks != 2)
                return;
            if (e.Node is IOCommunicationNode)
            {
                //编辑通讯节点
                  FormManager.EditIOCommunicationNode((IOCommunicationNode)e.Node);
            }
            else if (e.Node is IODeviceNode)
            {
                  FormManager.EditIODeviceNode((IODeviceNode)e.Node);
            }
            else if (e.Node is IOServerNode)
            {
                  FormManager.EditIOServerNode();
            }
        }

        private   void IOTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Clicks != 1)
                return;
             if (e.Node is IODeviceNode)
            {
                IOCommunicationNode comNode = e.Node.Parent as IOCommunicationNode;
                IOServerNode sNode = comNode.Parent as IOServerNode;
                IODeviceNode dNode = e.Node as IODeviceNode;
                  FormManager.OpenDeviceParas(sNode.Server, comNode.Communication, dNode.Device);
            }
            
        }

       

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // IOTree
            // 
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ItemHeight = 28;
            this.ResumeLayout(false);

        }
    }
}
