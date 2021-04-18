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
using Scada.Business;

namespace ScadaCenterServer.Pages
{
    public partial class IOServerAdminForm : PopBaseForm
    {
        public IOServerAdminForm()
        {
            InitializeComponent();
            this.Load += IOServerAdminForm_Load;
        }

        private void IOServerAdminForm_Load(object sender, EventArgs e)
        {
            IO_SERVER serverBll = new IO_SERVER();
            List<Scada.Model.IO_SERVER> servers = serverBll.GetModelList("");
            this.listView.Items.Clear();
            for (int i = 0; i < servers.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(servers[i].SERVER_ID);
                lvi.Tag = servers[i].SERVER_ID;
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = servers[i].SERVER_NAME });
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = servers[i].SERVER_STATUS == 1 ? "在线" : "离线" });
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = servers[i].SERVER_IP });
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = servers[i].SERVER_CREATEDATE });
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = servers[i].SERVER_REMARK });
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "删除" });
                this.listView.Items.Add(lvi);
            }
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                ListViewItem.ListViewSubItem sbi = info.Item.GetSubItemAt(e.X, e.Y);
                if (sbi.Text == "删除")
                {
                    if (MessageBox.Show("是否要删除"+ info.Item.SubItems[1].Text+"采集站", "删除提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        IO_SERVER serverBll = new IO_SERVER();
                        serverBll.Delete(info.Item.Tag.ToString());
                        this.listView.Items.Remove(info.Item);
                        MessageBox.Show("删除某个采集站后需要重新启动数据中心服务！");
                    }

                }
            }
        }
    }
}
