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
  public  class IODeviceNode: TreeNode
    {
       
        public IO_DEVICE Device = null;
        ContextMenu mContextMenu = null;
        private bool mEnableContextMenu = true;
        public bool EnableContextMenu
        {
            set
            {
                mEnableContextMenu = value;
                if(value)
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
            this.Text = Device.IO_DEVICE_LABLE+"["+ Device.IO_DEVICE_NAME + "]";
            this.ToolTipText ="ID="+ Device.IO_DEVICE_ID+" Address="+Device.IO_DEVICE_ADDRESS;
          
        }

       

        public IODeviceNode()
        {
            Device = new IO_DEVICE();
               mContextMenu = new ContextMenu();
    
            mContextMenu.MenuItems.Add(new MenuItem("删除设备")
            {
                Tag =1
            });
            mContextMenu.MenuItems.Add(new MenuItem("修改设备") { Tag=2 });
            mContextMenu.MenuItems.Add(new MenuItem("编辑IO表") { Tag = 3 });
            mContextMenu.MenuItems[0].Click += DeviceNode_Click;
            mContextMenu.MenuItems[1].Click += DeviceNode_Click;
            mContextMenu.MenuItems[2].Click += DeviceNode_Click;

            this.ContextMenu = mContextMenu;
            Device.IO_DEVICE_ID = GUIDTo16.GuidToLongID().ToString();
            this.SelectedImageIndex = 2;
            this.StateImageIndex = 2;
            this.ImageIndex = 2;
            ChangedNode();
        }

        private   void DeviceNode_Click(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            switch (item.Tag.ToString())
            {
                case "1":
                    if (MessageBox.Show(this.TreeView.FindForm(), "是否要删除" + this.Device.IO_DEVICE_LABLE + "设备?", "删除提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Remove();
                    }
                    break;
                case "2":
                      FormManager.EditIODeviceNode(this);
                    break;
                case "3":
                    {
                        IOCommunicationNode comNode = this.Parent as IOCommunicationNode;
                        IOServerNode sNode = comNode.Parent as IOServerNode;
                          FormManager.OpenDeviceParas(sNode.Server, comNode.Communication, this.Device);
                    }

                    break;
            }
        }
    }
}
