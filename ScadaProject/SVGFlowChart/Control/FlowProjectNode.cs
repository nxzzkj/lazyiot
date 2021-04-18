using ScadaFlowDesign.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScadaFlowDesign.Control
{
    public class FlowProjectNode : TreeNode
    {
        // Fields
        public FlowProject Project;

        // Methods
        public FlowProjectNode(FlowProject project)
        {
            base.ImageIndex = 0;
            base.SelectedImageIndex = 0;
            this.Project = project;
            base.Text = project.Title;
            base.ToolTipText = "文件路径" + project.FileFullName;
        }
    }

}
