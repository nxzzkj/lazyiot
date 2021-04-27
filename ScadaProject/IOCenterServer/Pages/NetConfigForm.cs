using Scada.AsyncNetTcp;
using Scada.Controls.Forms;
using ScadaCenterServer.Core;
using ScadaCenterServer.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScadaCenterServer.Pages
{
    public partial class NetConfigForm : PopBaseForm
    {
        public NetConfigForm()
        {
            InitializeComponent();
            this.Load += NetConfigForm_Load;   
        }

        private void NetConfigForm_Load(object sender, EventArgs e)
        {
            ucReceiveBufferSize.InputText = TcpPackConfig.ReceiveBufferSize.ToString();
            ucSendBufferSize.InputText = TcpPackConfig.SendBufferSize.ToString();
            ucReceiveTimeout.InputText = TcpPackConfig.ReceiveTimeout.ToString();
            ucSendTimeout.InputText = TcpPackConfig.SendTimeout.ToString();
           tbHeart.Text = TcpPackConfig.HeartBeat.ToString();
            tbHead.Text = TcpPackConfig.HeadPack.ToString();
            tbTail.Text = TcpPackConfig.TailPack.ToString();
            ucDelayTime.InputText = TcpPackConfig.DelayTime.ToString();
            ucLocalPort.InputText = IOCenterManager.IOProject.ServerConfig.LocalPort;
        }

        private void tbHead_TextChanged(object sender, EventArgs e)
        {
            byte[] datas = Encoding.UTF8.GetBytes(tbHead.Text.Trim());
            string str = "";
            for(int i=0;i< datas.Length;i++)
            {
                str += " " + datas[i].ToString();
            }
         lbHead.Text = str;
        }

        private void tbTail_TextChanged(object sender, EventArgs e)
        {
            byte[] datas = Encoding.UTF8.GetBytes(tbTail.Text.Trim());
            string str = "";
            for (int i = 0; i < datas.Length; i++)
            {
                str += " " + datas[i].ToString();
            }
            lbTail.Text = str;
        }

        private void tbHeart_TextChanged(object sender, EventArgs e)
        {
            byte[] datas = Encoding.UTF8.GetBytes(tbHeart.Text.Trim());
            string str = "";
            for (int i = 0; i < datas.Length; i++)
            {
                str += " " + datas[i].ToString();
            }
            lbHeart.Text = str;
        }

        private void btnOK_BtnClick(object sender, EventArgs e)
        {
            if (FrmDialog.ShowDialog(this, "保存后需要重新启动系统，是否要保存？", "保存提示", true, true, true, true) == DialogResult.OK)
            {
                try
                {

                    TcpPackConfig.ReceiveBufferSize = int.Parse(ucReceiveBufferSize.InputText);
                    TcpPackConfig.SendBufferSize = int.Parse(ucSendBufferSize.InputText);
                    TcpPackConfig.ReceiveTimeout = int.Parse(ucReceiveTimeout.InputText);
                    TcpPackConfig.SendTimeout = int.Parse(ucSendTimeout.InputText);
                    TcpPackConfig.HeartBeat = tbHeart.Text;
                    TcpPackConfig.HeadPack = tbHead.Text;
                    TcpPackConfig.TailPack = tbTail.Text;
                    TcpPackConfig.DelayTime = int.Parse(ucDelayTime.InputText);

                    IOCenterManager.IOProject.ServerConfig.WriteConfig();
                    this.DialogResult = DialogResult.OK;
                }
                catch(Exception ex)
                {
                    IOCenterManager.QueryFormManager.DisplyException(ex);
                }
            }
        }

        private void btnCancel_BtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
