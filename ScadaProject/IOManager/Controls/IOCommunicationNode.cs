using Scada.Model;
using IOManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;

namespace IOManager.Controls
{
    public class IOCommunicationNode : TreeNode
    {
        private int mDeviceNumber = 0;
        public int DeviceNumber
        {
            get
            {
                mDeviceNumber++;
                return mDeviceNumber;
            }
            set
            {
                mDeviceNumber = value;
            }
        }
        public IO_COMMUNICATION Communication = null;
        ContextMenu mContextMenu = null;
        private bool mEnableContextMenu = true;
        public bool EnableContextMenu
        {
            set
            {
                mEnableContextMenu = value;
                if (value)
                {
                    this.ContextMenu = mContextMenu;

                }
                else
                {
                    this.ContextMenu = null;
                }
            }
            get { return mEnableContextMenu; }
        }
        public void ChangedNode()
        {
         
            this.Text = Communication.IO_COMM_LABEL+"["+ Communication.IO_COMM_NAME + "]";
            this.ToolTipText = "ID="+Communication.IO_COMM_ID+" "+ Communication.IO_COMM_REMARK;
        
        }
        public void AddChildenNode(IODeviceNode node)
        {
            this.Nodes.Add(node);
            node.ChangedNode();
           
        }
        private   void TreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (TreeView.SelectedNode is IOCommunicationNode)
            {
                //编辑通讯节点
                  FormManager.EditIOCommunicationNode(this);
            }
        }

        public IOCommunicationNode()
        {
            Communication = new IO_COMMUNICATION();
               mContextMenu = new ContextMenu();
            mContextMenu.MenuItems.Add(new MenuItem("删除通讯通道")
            {
                Tag = 1
            });
            mContextMenu.MenuItems.Add(new MenuItem("修改通讯通道") { Tag = 2 });
            mContextMenu.MenuItems.Add(new MenuItem("新增设备") { Tag = 3 });

            mContextMenu.MenuItems[0].Click += IOCommunicationNode_Click;
            mContextMenu.MenuItems[1].Click += IOCommunicationNode_Click;
            mContextMenu.MenuItems[2].Click += IOCommunicationNode_Click;
            this.ContextMenu = mContextMenu;
            Communication.IO_COMM_ID = GUIDTo16.GuidToLongID().ToString();

            this.SelectedImageIndex = 1;
            this.StateImageIndex = 1;
            this.ImageIndex = 1;
            ChangedNode();
        }

        private    void IOCommunicationNode_Click(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            switch(item.Tag.ToString())
            {
                case "1":
                    if (MessageBox.Show(this.TreeView.FindForm(), "是否要删除" + this.Communication.IO_COMM_LABEL + "通讯通道?", "删除提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Remove();
                    }
                    break;
                case "2":
                      FormManager.EditIOCommunicationNode(this);
                    break;
                case "3":
                      FormManager.CreateIODeviceNode();
                    break;
            }
        
        }

        
    }
}
