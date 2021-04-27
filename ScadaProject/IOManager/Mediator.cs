using System;
using System.Collections.Generic;
using System.Text;


using System.Windows.Forms;



using System.Reflection;
using Scada.Controls;
using IOManager.Page;
 

namespace IOManager
{
    public class Mediator
    {
        
        #region Constructor
        public Mediator(Form main)
        {
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
        #region 工程区
        public IOTreeForm IOTreeForm
        {
            get
            {
                if (tabFactory.IOTreeForm == null)
                    return null;
                else
                    return tabFactory.IOTreeForm;
            }
        }
        public void OpenIOTreeForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("工程", "工程", TabTypes.Project)) as IOTreeForm;
            lastAdded.TabText = "工程";
            lastAdded.Text = "工程";
            OnShowTab(lastAdded);
        }
        #endregion
 
        #region 工作区
        public IOParaForm IOParaForm
        {
            get
            {
                if (tabFactory.IOParaForm == null)
                    return null;
                else
                    return tabFactory.IOParaForm;
            }
        }
        public void OpenIOParaForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("点表区", "点表区", TabTypes.PointArea)) as IOParaForm;
            lastAdded.TabText = "点表区";
            lastAdded.Text = "点表区";
            OnShowTab(lastAdded);
        }
        #endregion
        #region 日志
        public IOLogForm IOLogForm
        {
            get
            {
                if (tabFactory.IOLogForm == null)
                    return null;
                else
                    return tabFactory.IOLogForm;
            }
        }
        public void OpenLogForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("日志", "日志", TabTypes.Logbook)) as IOLogForm;
            lastAdded.TabText = "日志";
            lastAdded.Text = "日志";
            OnShowTab(lastAdded);
        }
        #endregion
        #region 日志
        public IODriveManageForm IODriveManageForm
        {
            get
            {
                if (tabFactory.IODriveManageForm == null)
                    return null;
                else
                    return tabFactory.IODriveManageForm;
            }
        }
        public void OpenIODriveManageForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("驱动管理", "驱动管理", TabTypes.DriverManagement)) as IODriveManageForm;
            lastAdded.TabText = "驱动管理";
            lastAdded.Text = "驱动管理";
            OnShowTab(lastAdded);
        }
        #endregion
        
        private void OnTabCall(DockContent tab)
        {
            TabTypes type = (tab as ICobaltTab).TabType;
            switch (type)
            {
               
                 
                    
                case TabTypes.PointArea:
                    tab.Show(dockPanel, DockState.Document);
                    break;

                case TabTypes.Project:
                    tab.Show(dockPanel, DockState.DockLeft);
                    break;
                case TabTypes.Logbook:
                    tab.Show(dockPanel, DockState.DockBottom);
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
