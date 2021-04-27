using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;
using Scada.Model;

namespace IOMonitor.Controls
{
    public interface INode
    {
       void  InitNode();
        void ChangedStatus(bool status);
    }
    public class IoServerTreeNode : TreeNode, INode
    {
        public IO_SERVER Server = null;

        public void ChangedStatus(bool status)
        {
            throw new NotImplementedException();
        }

        public void InitNode()
        {
            if(Server!=null)
            {
                this.Text = LocalIp.GetLocalIp();
                this.Name = Server.SERVER_ID;
                this.ImageIndex = 0;
                this.SelectedImageIndex =0;
            }
        }
        public override string ToString()
        {
            return this.Text;
        }
    }
    public class IoCommunicationTreeNode : TreeNode,INode
    {
        public IO_COMMUNICATION Communication = null;
        public IO_SERVER Server = null;

        public void ChangedStatus(bool status)
        {
            throw new NotImplementedException();
        }

        public void InitNode()
        {
            if (Communication != null)
            {
                this.Text = Communication.IO_COMM_LABEL + "[" + Communication.IO_COMM_NAME + "]";
                this.ToolTipText = "ID=" + Communication.IO_COMM_ID + " 备注=" + Communication.IO_COMM_REMARK;
                this.Name = Communication.IO_COMM_ID;
                this.ImageIndex = 1;
                this.SelectedImageIndex = 1;
            }
        }
        public override string ToString()
        {
            return Server.SERVER_IP+"["+ Server.SERVER_NAME+ "]"+"//"+this.Text;
        }
    }
    public class IoDeviceTreeNode : TreeNode,INode
    {
        public IO_DEVICE Device = null;
        public IO_COMMUNICATION Communication = null;
        public IO_SERVER Server = null;
        public void InitNode()
        {
            if (Device != null)
            {
                this.Text = Device.IO_DEVICE_LABLE + "[" + Device.IO_DEVICE_NAME + "]";
                this.ToolTipText ="ID="+ Device.IO_DEVICE_ID+" Address="+ Device.IO_DEVICE_ADDRESS;
                this.Name = Device.IO_DEVICE_ID;
                //默认显示是的非连接信号
                this.ImageIndex = 3;
                this.SelectedImageIndex = 3;
            }
        }
        public override string ToString()
        {
            return Server.SERVER_IP + "[" + Server.SERVER_NAME + "]" + "//" + Communication.IO_COMM_LABEL + "[" + Communication.IO_COMM_NAME + "]//"+this.Text;
        }

        public void ChangedStatus(bool status)
        {
          if(status)
            {
                this.ImageIndex = 2;
                this.SelectedImageIndex = 2;

            }
            else
            {
                this.ImageIndex = 3;
                this.SelectedImageIndex = 3;
            }
        }
        public void ChangedStatus(int status)
        {
            if (status==1)
            {
                this.ImageIndex = 2;
                this.SelectedImageIndex = 2;

            }
            else if (status == 0)
            {
                this.ImageIndex = 3;
                this.SelectedImageIndex = 3;
            }
        }
    }
}
