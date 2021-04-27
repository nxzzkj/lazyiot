using IOMonitor.Forms;
using Scada.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOMonitor
{
    public class Mediator
    {

        #region Constructor
        public   MonitorForm MonitorForm = null;
        public Mediator(MonitorForm main)
        {
            MonitorForm = main;
            this.parent = main;
            tabFactory = new TabFactory(this);
            tabFactory.OnTabCreation += new TabInfo(OnTabCall);
            rnd = new Random();
        }

        #endregion
        protected Random rnd;
        private TabFactory tabFactory;
        internal Form parent;
        private DockContent lastAdded;
        private DockPanel dockPanel;
        public DockPanel DockPanel
        {
            get { return dockPanel; }
            set { dockPanel = value; }
        }

        //
        #region 采集监视
        public IOMonitorForm IOMonitorForm
        {
            get
            {
                if (tabFactory.IOMonitorForm == null)
                    return null;
                else
                    return tabFactory.IOMonitorForm;
            }
        }
        public void OpenIOMonitorForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("采集监视", "采集监视", TabTypes.IOMonitoring)) as IOMonitorForm;
            lastAdded.TabText = "采集监视";
            lastAdded.Text = "采集监视";
            OnShowTab(lastAdded);
        }
        #endregion
 

        

        #region 采集日志
        public IOMonitorLogForm IOMonitorLogForm
        {
            get
            {
                if (tabFactory.IOMonitorLogForm == null)
                    return null;
                else
                    return tabFactory.IOMonitorLogForm;
            }
        }
        public void OpenLogForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("采集日志", "采集日志", TabTypes.IOLogbook)) as IOMonitorLogForm;
            lastAdded.TabText = "采集日志";
            lastAdded.Text = "采集日志";
            OnShowTab(lastAdded);
        }
        #endregion
        #region IO属性
        public IOPropertiesForm IOPropertiesForm
        {
            get
            {
                if (tabFactory.IOPropertiesForm == null)
                    return null;
                else
                    return tabFactory.IOPropertiesForm;
            }
        }
        public void OpenIOPropertiesForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("IO属性", "IO属性", TabTypes.Property)) as IOPropertiesForm;
            lastAdded.TabText = "IO属性";
            lastAdded.Text = "IO属性";
            OnShowTab(lastAdded);
        }
        #endregion
        #region IO状态
        public IOStatusForm IOStatusForm
        {
            get
            {
                if (tabFactory.IOStatusForm == null)
                    return null;
                else
                    return tabFactory.IOStatusForm;
            }
        }
        public void OpenIOStatusForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("IO状态", "IO状态", TabTypes.IOPoint)) as IOStatusForm;
            lastAdded.TabText = "IO状态";
            lastAdded.Text = "IO状态";
            OnShowTab(lastAdded);
        }
        #endregion

        
        private void OnTabCall(DockContent tab)
        {
            TabTypes type = (tab as ICobaltTab).TabType;
            switch (type)
            {



                case TabTypes.IOMonitoring:
                    tab.Show(dockPanel, DockState.Document);
                    break;
                case TabTypes.MonitorTool:
                    tab.Show(dockPanel, DockState.DockLeft);
                    break;
                case TabTypes.IOLogbook:
                    tab.Show(dockPanel, DockState.DockBottom);
                    break;
                case TabTypes.LogbookQuery:
                    tab.Show(dockPanel, DockState.Document);
                    break;
                case TabTypes.IOPoint:
                    tab.Show(dockPanel, DockState.DockLeft);
                    break;
                case TabTypes.Property:
                    tab.Show(dockPanel, DockState.DockRight);
                    break;
                default:
                    {
                        tab.Show(dockPanel, DockState.Document);
                        break;
                    }

            }
        }

        private void OnShowTab(DockContent tab)
        {
            if (tab == null) return;
            TabTypes type = (tab as ICobaltTab).TabType;
            tab.Show(dockPanel, tab.DockState);

        }


    }
}
