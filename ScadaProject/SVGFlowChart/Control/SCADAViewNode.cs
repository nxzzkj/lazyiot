using Scada.FlowGraphEngine.GraphicsMap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScadaFlowDesign.Control
{
    public class SCADAViewNode : TreeNode
    {
        // Fields
        private WorkForm mView;

        // Methods
        public SCADAViewNode()
        {
            base.ImageIndex = 2;
            base.SelectedImageIndex = 2;
        }

        private void SCADAViewNode_Click(object sender, EventArgs e)
        {
        }

        // Properties
        public WorkForm View
        {
            get
            {
                return this.mView;
            }
            set
            {
                this.mView = value;
                if (this.mView.GraphControl.Abstract.Index)
                {
                    base.ForeColor = Color.Red;
                }
                else
                {
                    base.ForeColor = Color.Black;
                }
            }
        }

        public GraphAbstract GraphSite
        {
            get
            {
                if (this.View.GraphControl.Abstract != null)
                {
                    return this.View.GraphControl.Abstract;
                }
                return null;
            }
        }
    }

}
