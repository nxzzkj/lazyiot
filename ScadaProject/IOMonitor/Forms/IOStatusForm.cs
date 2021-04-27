using IOMonitor.Controls;
using IOMonitor.Core;
using Scada.Controls;
using Scada.Controls.Controls;
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
using Scada.Model;

namespace IOMonitor.Forms
{
    public partial class IOStatusForm : DockContent, ICobaltTab
    {
        public IOStatusForm(Mediator m)
        {
            mediator = m;
            InitializeComponent();
            this.CloseButton = false;
            this.HideOnClose = true;
        }
        private Mediator mediator = null;
        private string identifier;
        public TabTypes TabType
        {
            get
            {
                return TabTypes.IOPoint;
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

        private   void IOStatusForm_Load(object sender, EventArgs e)
        {
            computerInfoControl.Monitour();
            ControlHelper.FreezeControl(this, true);

        }
        public void LoadTreeStatus()
        {
            Task.Run(() =>
                  {
                      try
                      {

                          MonitorFormManager.LoadProject(this.IoTreeStatus);

                      }
                      catch (Exception ex)
                      {
                          MonitorFormManager.DisplyException(ex);
                      }
                  });

        }

        private void IoTreeStatus_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
          
                if (e.Node is IoDeviceTreeNode)
                {
                    try
                    {
                        IoDeviceTreeNode devNode = e.Node as IoDeviceTreeNode;
                    this.mediator.IOMonitorForm.Device = devNode.Device;
                    this.mediator.IOMonitorForm.Communication = devNode.Communication;
        
                    this.mediator.IOMonitorForm.ChangedBinds(devNode.Server, devNode.Communication, devNode.Device);
                        this.mediator.IOMonitorForm.SetIOValue(devNode.Server, devNode.Communication, devNode.Device);
                    }
                    catch (Exception ex)
                    {
                        MonitorFormManager.DisplyException(ex);
                    }
                }
           
        }
    }
}
