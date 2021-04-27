using Scada.Controls;
using ScadaFlowDesign;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScadaFlowDesign
{
    public partial class PropertiesForm : DockContent, ICobaltTab
    {
        private Mediator mediator = null;
        public PropertiesForm(Mediator m)
        {
            InitializeComponent();
            mediator = m;
            this.HideOnClose = true;
        }
      public void   ShowProperties(object sender, object[] props)
        {
            this.propertyGrid.SelectedObjects = props;
        }

        private string identifier;
        public TabTypes TabType
        {
            get
            {
                return TabTypes.Property;
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
    }
}
