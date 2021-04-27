using System;
using Scada.Controls;
using Scada.DBUtility;
using Scada.FlowGraphEngine.GraphicsMap;

namespace ScadaFlowDesign
{
    public class Mediator
    {
        
        #region Constructor
        public Mediator(FlowDesign main)
        {
            this.Parent = main;
            tabFactory = new TabFactory(this);
            tabFactory.OnTabCreation += new TabInfo(OnTabCall);
            rnd = new Random();
        }
      
        #endregion
        protected Random rnd;
        private TabFactory tabFactory;
        internal FlowDesign Parent;
        private DockContent lastAdded;
        private DockPanel dockPanel;
        public DockPanel DockPanel
        {
            get { return dockPanel; }
            set { dockPanel = value; }
        }
        public DockContent ActiveWork
        {
            get
            {
                return DockPanel.ActiveDocument;

            }
        }
        //
        #region 属性
        public PropertiesForm PropertiesForm
        {
            get
            {
             
                    return tabFactory.PropertiesForm;
            }
        }
        public void OpenPropertiesForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("属性", "属性", TabTypes.Property)) as PropertiesForm;
            lastAdded.TabText = "属性";
            lastAdded.Text = "属性";
            OnShowTab(lastAdded);
        }
        #endregion
        #region 目录
        public ToolForm ToolForm
        {
            get
            {
             
                    return tabFactory.ToolForm;
            }
        }
        public void OpenToolForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("工程", "工程", TabTypes.Project)) as ToolForm;
            lastAdded.TabText = "工程";
            lastAdded.Text = "工程";
            OnShowTab(lastAdded);
        }
        #endregion
        #region 工作区
        
        public DockContent CreateWorkForm(string Title,float width, float height)
        {
            lastAdded = tabFactory.GetTab(new TabCodon("W" + GUIDTo16.GuidToLongID(), Title, TabTypes.WorkArea) {  MapHeight= height, MapWidth=  width }) as WorkForm;
            lastAdded.TabText = Title;
            lastAdded.Text = Title;
            OnShowTab(lastAdded);
            return lastAdded;
        }
        public DockContent CreateWorkForm(string Title, float width, float height, GraphAbstract site)
        {
            lastAdded = tabFactory.GetTab(new TabCodon("W" + GUIDTo16.GuidToLongID(), Title, TabTypes.WorkArea) { MapHeight = height, MapWidth = width }) as WorkForm;
            WorkForm work = lastAdded as WorkForm;
            work.GraphControl.Abstract = site;
            lastAdded.TabText = Title;
            lastAdded.Text = Title;
            OnShowTab(lastAdded);
            return lastAdded;
        }
        #endregion
        #region 日志
        public LoggerForm LogForm
        {
            get
            {
           
                    return tabFactory.LogForm;
            }
        }
        public void OpenLogForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("日志", "日志", TabTypes.Logbook)) as LoggerForm;
            lastAdded.TabText = "日志";
            lastAdded.Text = "日志";
            OnShowTab(lastAdded);
        }
        #endregion
        #region 图元
        public ShapeForm ShapeForm
        {
            get
            {
      
                    return tabFactory.ShapeForm;
            }
        }
        public void OpenShapeForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("图元", "图元", TabTypes.Shape)) as ShapeForm;
            lastAdded.TabText = "图元";
            lastAdded.Text = "图元";
            OnShowTab(lastAdded);
        }
        #endregion
        private void OnTabCall(DockContent tab)
        {
            TabTypes type = (tab as ICobaltTab).TabType;
            switch (type)
            {
               
                case TabTypes.Property:
                    tab.Show(dockPanel, DockState.DockRight);
                    break;
                case TabTypes.Shape:
                    tab.Show(dockPanel, DockState.DockLeft);
                    break;
                    
                case TabTypes.WorkArea:
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
