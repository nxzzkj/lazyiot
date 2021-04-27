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
    public class IOServerNode : TreeNode
    {
        private int mCommunicationNumber = 0;
        public int CommunicationNumber
        {
            get
            {
                mCommunicationNumber++;
                return mCommunicationNumber;
            }
        }
       
        public IO_SERVER Server = null;
        public string Project = "";
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
            this.Text = LocalIp.GetLocalIp();
            this.ToolTipText = Server.SERVER_REMARK;
        
        }
        public void AddChildenNode(IOCommunicationNode node)
        {
            this.Nodes.Add(node);
            node.ChangedNode();
         

        }
        public IOServerNode(IO_SERVER mServer,string mProject)
        {
            Server = mServer;
            Project = mProject;
            mContextMenu = new ContextMenu();
            mContextMenu.MenuItems.Add(new MenuItem("新建通道")
            {
                Tag = 1
            });
            mContextMenu.MenuItems.Add(new MenuItem("编辑采集站")
            {
                Tag = 2
            });
            mContextMenu.MenuItems.Add(new MenuItem("删除采集站工程")
            {
                Tag = 3
            });
            mContextMenu.MenuItems[0].Click += IOServerNode_Click;
            mContextMenu.MenuItems[1].Click += IOServerNode_Click;
            this.ContextMenu = mContextMenu;
            if (Server.SERVER_ID==null || Server.SERVER_ID=="")
            {
         
                Server.SERVER_IP = LocalIp.GetLocalIp();
                Server.SERVER_ID= FormManager.ipToLong(Server.SERVER_IP);
            }
           
            this.Text = LocalIp.GetLocalIp();
            ///当前加载工程的文件路径
            this.Tag = Project;
         
            this.SelectedImageIndex = 0;
            this.StateImageIndex = 0;
            this.ImageIndex = 0;
            this.ExpandAll();
         

        }
    

        

        private   void IOServerNode_Click(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            switch(item.Tag.ToString())
            {
                case "1":
                      FormManager.CreateIOCommunicationNode();
                    break;
                case "2":
                      FormManager.EditIOServerNode();
                    
                    break;
                case "3":
                    if(MessageBox.Show(this.TreeView.FindForm(),"删除采集站工程","删除提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
                    {
                        this.Remove();
                    }
                 

                    break;
            }
           
        }
    }
}
