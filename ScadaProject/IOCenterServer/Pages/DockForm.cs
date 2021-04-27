using Scada.Controls;
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
    public partial class DockForm : DockContent, ICobaltTab
    {
       
       
        public DockForm(Mediator m)
        {
        
            InitializeComponent();
               mediator = m;
        }
         

        public DockForm()
        {
      
            InitializeComponent();
           
        }
        public  Mediator mediator = null;
        protected string identifier;
        public    string TabIdentifier
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

        public  virtual  TabTypes TabType
        {
            get
            {
                return TabTypes.Unknown;
            }
        }
    }
}
