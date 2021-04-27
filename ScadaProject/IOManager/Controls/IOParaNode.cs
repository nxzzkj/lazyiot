using Scada.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;

namespace IOManager.Controls
{
   public class IOParaNode:TreeNode
    {
        public IO_PARA IOPara = new IO_PARA();
        public IOParaNode()
        {
            this.ContextMenu = new  ContextMenu();
            this.ContextMenu.MenuItems.Add(new MenuItem("删除") {  });
            this.ContextMenu.MenuItems.Add(new MenuItem("修改") { });
            this.ContextMenu.MenuItems[0].Click += IOParaNode_Click;
            this.ContextMenu.MenuItems[1].Click += IOParaNode_Click;
            IOPara.IO_ID = GUIDTo16.GuidToLongID().ToString();
            this.SelectedImageIndex = 3;
            this.StateImageIndex = 3;
            this.ImageIndex = 3;
        }

        private void IOParaNode_Click(object sender, EventArgs e)
        {
            
        }
    }
}
