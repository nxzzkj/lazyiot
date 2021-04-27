using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOMonitor
{
    public delegate void SendMessageHandle(string msg);
    public partial class ClientForm : Form
    {
        public event EventHandler ConnectedServer;
        public event SendMessageHandle SendMessage;
        public ClientForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btConnect_Click(object sender, EventArgs e)
        {
            if(ConnectedServer!=null)
            {
                ConnectedServer(sender, e);
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if(rtbSend.Text.Trim()!="")
            {
                if (SendMessage != null)
                {
                    SendMessage(rtbSend.Text.Trim());
                }
            }
           
        }
        public void Receive(string msg)
        {
            rtbReceive.AppendText("\r\n"+msg);
        }
    }
}
