using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Model;

namespace ScadaCenterServer.Controls
{
    public interface INode
    {
       void  InitNode();
       
    }
    public class IoServerTreeNode : TreeNode, INode
    {
        public IO_SERVER Server = null;
        public string  MAC = "";
        public bool status = false;
        /// <summary>
        /// 保存客户端的IP
        /// </summary>
        public EndPoint ClientEndPoint = null;
        public void InitNode()
        {
            if (Server != null)
            {
                this.Text = Server.SERVER_NAME + "[未上线]";
                this.Name = Server.SERVER_ID;
                this.ImageIndex = 1;
                this.SelectedImageIndex = 1;
                this.Tag = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public override string ToString()
        {
            return this.Text;
        }
    }
    public class IoCommunicationTreeNode : TreeNode,INode
    {
        public bool status = false;
        public IO_COMMUNICATION Communication = null;
        public IO_SERVER Server = null;
        public void InitNode()
        {
            if (Communication != null)
            {
                this.Text = Communication.IO_COMM_LABEL + "[" + Communication.IO_COMM_NAME + "]";
                this.ToolTipText = "ID=" + Communication.IO_COMM_ID + " 备注=" + Communication.IO_COMM_REMARK;
                this.Name = Communication.IO_COMM_ID;
                this.ImageIndex =3;
                this.SelectedImageIndex = 3;
                this.Tag = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public override string ToString()
        {
            return Server.SERVER_IP+"["+ Server.SERVER_NAME+ "]"+"//"+this.Text;
        }
    }
    public class IoDeviceTreeNode : TreeNode,INode
    {
        public bool status = false;
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
                this.ImageIndex = 4;
                this.SelectedImageIndex =4;
                this.Tag = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public override string ToString()
        {
            return Server.SERVER_IP + "[" + Server.SERVER_NAME + "]" + "//" + Communication.IO_COMM_LABEL + "[" + Communication.IO_COMM_NAME + "]//"+this.Text;
        }
    }
}
