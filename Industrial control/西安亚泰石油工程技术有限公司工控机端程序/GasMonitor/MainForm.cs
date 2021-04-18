using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasMonitor
{
    public partial class MainForm : UIHeaderAsideMainFrame


    {
        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            Aside.ExpandAll();
            this.Load += MainForm_Load;
        }

        private  void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            GasMonitorManager.InitMonitorManager(this);


            AddPage(GasMonitorManager.realDataFrm, GasMonitorManager.realDataFrm.Guid);
            AddPage(GasMonitorManager.realSeriesFrm, GasMonitorManager.realSeriesFrm.Guid);
            AddPage(GasMonitorManager.alarmSetFrm, GasMonitorManager.alarmSetFrm.Guid);
            AddPage(GasMonitorManager.systenSetFrm, GasMonitorManager.systenSetFrm.Guid);
            AddPage(GasMonitorManager.logFrm, GasMonitorManager.logFrm.Guid);
            Header.SetNodePageIndex(this.Header.Nodes[0], 0);
            Header.SetNodePageIndex(this.Header.Nodes[1], 1);
            Header.SetNodePageIndex(this.Header.Nodes[2], 2);
            Header.SetNodePageIndex(this.Header.Nodes[3], 3);
            Header.SetNodePageIndex(this.Header.Nodes[4], 4);

        }
        public void InitForms()
        {
            Aside.Nodes[0].Nodes.Clear();
            Aside.CreateChildNode(Aside.Nodes[0], "全部通道", -1);
            for (int i = 0; i < GasMonitorManager.Chanels.Count; i++)
            {
                TreeNode treeNode = Aside.CreateChildNode(Aside.Nodes[0], 10 + i, string.IsNullOrEmpty(GasMonitorManager.Chanels[i].Text) ? GasMonitorManager.Chanels[i].Name : GasMonitorManager.Chanels[i].Text, -1);
                treeNode.Tag = GasMonitorManager.Chanels[i].Id;
            }

        }

        private void uiAvatar_Click(object sender, EventArgs e)
        {
            PasswordInputFrm frm = new PasswordInputFrm();
            frm.Text = "是否要重启系统";
            frm.Title = "重启系统";
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                ExitWindows.Reboot();

            }
        }

        private void Header_MenuItemClick(string itemText, int menuIndex, int pageIndex)
        {
            switch (menuIndex)
            {
                case 0:
                    this.SelectPage(GasMonitorManager.realDataFrm.Guid);
                    break;
                case 1:
                    this.SelectPage(GasMonitorManager.realSeriesFrm.Guid);
                    break;
                case 2:
                    this.SelectPage(GasMonitorManager.alarmSetFrm.Guid);
                    break;
                case 3:
                    PasswordInputFrm frm = new PasswordInputFrm();
                  
                    if(frm.ShowDialog(this)==DialogResult.OK)
                    {
                        this.ShowSuccessTip("登录成功");
                        this.SelectPage(GasMonitorManager.systenSetFrm.Guid);

                    }
                    else
                    {
                        this.ShowErrorTip("登录失败");
                    }
                    break;
                case 4:
                    this.SelectPage(GasMonitorManager.logFrm.Guid);
                    break;
            }


        }

        private void Aside_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
            if (node != null && node.Tag != null && node.Tag.GetType() != item.GetType())
            {
                for (int i = 0; i < GasMonitorManager.Chanels.Count; i++)
                {
                    GasMonitorManager.Chanels[i].ShowOrHide = false;
                    if (GasMonitorManager.Chanels[i].Id == node.Tag.ToString())
                    {
                        GasMonitorManager.Chanels[i].ShowOrHide = true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < GasMonitorManager.Chanels.Count; i++)
                {
                    GasMonitorManager.Chanels[i].ShowOrHide = true;

                }
            }
        }
    }
}
