using IOManager.Core;
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
 
using Scada.Controls;

namespace IOManager.Page
{
    /// <summary>
    /// 通讯驱动管理
    /// </summary>
    public partial class IODriveManageForm : DockContent, ICobaltTab
    {
        public IODriveManageForm(Mediator m)
        {
            InitializeComponent();
            mediator = m;

        }

        private Mediator mediator = null;
        private string identifier;
        public TabTypes TabType
        {
            get
            {
                return TabTypes.DriverManagement;
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
        private   void btAdd_Click(object sender, EventArgs e)
        {

             FormManager.AddDrive();
        }

      
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private   void CommDriveManageForm_Load(object sender, EventArgs e)
        {
            FormManager.LoadDriver(this.treeView,this.contextMenuStrip);
        }

        private void 删除驱动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.treeView.SelectedNode.Level==1)
            {
                FormManager.DeleteDrive(this.treeView.SelectedNode);
                this.treeView.Nodes.Remove(this.treeView.SelectedNode);

            }
            
        }
    }
}
