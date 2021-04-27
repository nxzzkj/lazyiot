using IOManager.Controls;
using Scada.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOManager.Page
{
    public partial class IOTreeForm : DockContent, ICobaltTab
    {
        public IOTreeForm()
        {
            InitializeComponent();
          
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public TreeNode SelectedNode
        {
            get { return this.IoTree.SelectedNode; }
        }
        public void AddMainNode(TreeNode tn)
        {
            if (this.IsHandleCreated)
            {
                this.IoTree.BeginInvoke(new EventHandler(delegate
            {
                IoTree.Nodes.Add(tn);

            }));
            }

          
        }
        public void AddChilndenNode(TreeNode tn, TreeNode Ptn)
        {
            if (this.IsHandleCreated)
            {
                this.IoTree.BeginInvoke(new EventHandler(delegate
            {
                Ptn.Nodes.Add(tn);

            }));
            }


      

      

      
        }
        public void ClearNode()
        {
            if (this.IsHandleCreated)
            {
                this.IoTree.BeginInvoke(new EventHandler(delegate
            {
                IoTree.Nodes.Clear();


            }));
            }
           
        }
        public IOTreeForm(Mediator m)
        {
            InitializeComponent();
            mediator = m;
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public IOServerNode FindServerTreeNode(Scada.Model.IO_SERVER Server)
        {
            for(int i=0;i<this.IoTree.Nodes.Count;i++)
            {
                if(this.IoTree.Nodes[i] is IOServerNode)
                {
                    IOServerNode sNode = this.IoTree.Nodes[i] as IOServerNode;
                    if (sNode.Server == Server)
                        return sNode;

                }
            }
            return null;
        }
        public IOCommunicationNode FindCommunicationTreeNode(Scada.Model.IO_SERVER Server, Scada.Model.IO_COMMUNICATION Communication)
        {
 
            for (int i = 0; i < this.IoTree.Nodes.Count; i++)
            {
                if (this.IoTree.Nodes[i] is IOServerNode)
                {
                    IOServerNode sNode = this.IoTree.Nodes[i] as IOServerNode;
                    if (sNode.Server == Server)
                    {
                        for (int j = 0; j < sNode.Nodes.Count; j++)
                        {
                            if (sNode.Nodes[j] is IOCommunicationNode)
                            {
                                IOCommunicationNode commNode = sNode.Nodes[j] as IOCommunicationNode;
                                if (commNode.Communication == Communication)
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
        public IODeviceNode FindDeviceTreeNode(Scada.Model.IO_SERVER Server, Scada.Model.IO_COMMUNICATION Communication,Scada.Model.IO_DEVICE Device)
        {
            for (int i = 0; i < this.IoTree.Nodes.Count; i++)
            {
                if (this.IoTree.Nodes[i] is IOServerNode)
                {
                    IOServerNode sNode = this.IoTree.Nodes[i] as IOServerNode;
                    if (sNode.Server == Server)
                    {
                        for (int j = 0; j < sNode.Nodes.Count; j++)
                        {
                            if (sNode.Nodes[j] is IOCommunicationNode)
                            {
                                IOCommunicationNode commNode = sNode.Nodes[j] as IOCommunicationNode;
                                if (commNode.Communication == Communication)
                                {
                                    for (int c = 0; c < commNode.Nodes.Count; c++)
                                    {
                                        if (commNode.Nodes[c] is IODeviceNode)
                                        {
                                            IODeviceNode deviceNode = commNode.Nodes[c] as IODeviceNode;
                                            if (deviceNode.Device == Device)
                                            {
                                                return deviceNode;

                                            }
                                        }

                                    }
                                }
                            }

                        }
                    }

                }
            }
            return null;
        }
        private Mediator mediator = null;
        private string identifier;
        public TabTypes TabType
        {
            get
            {
                return TabTypes.Project;
            }
        }
        public string TabIdentifier
        {
            get
            {
                return identifier;
            }
            set
            {
                identifier = value;
            }
        }
    }
}
