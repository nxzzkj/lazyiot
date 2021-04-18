using ScadaFlowDesign.Core;
using Scada.FlowGraphEngine.GraphicsMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScadaFlowDesign.Control
{
    public enum TreeNodeType
    {
        View, Dialog,Node
    }
    public class TreeNodeEx : TreeNode
    {
        public TreeNodeType NodeType = TreeNodeType.View;
        public TreeNodeEx(TreeNodeType type)
        {
            NodeType = type;
            this.ImageIndex = 1;
            this.SelectedImageIndex = 1;
        }

    }
 
    
}
