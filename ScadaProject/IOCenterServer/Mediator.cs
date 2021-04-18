
using ScadaCenterServer.Core;
using ScadaCenterServer.Pages;
using Scada.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Model;

namespace ScadaCenterServer
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

        #region  
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
            
                lastAdded = tabFactory.GetTab(new TabCodon("IO目录", "IO目录", TabTypes.IOCatalog)) as IOTreeForm;
                lastAdded.TabText = "IO目录";
                lastAdded.Text = "IO目录";
           
            OnShowTab(lastAdded);
        }
        #endregion
        #region  
        public IOPropeitesForm IOPropeitesForm
        {
            get
            {
                if (tabFactory.IOPropeitesForm == null)
                    return null;
                else
                    return tabFactory.IOPropeitesForm;
            }
        }
        public void OpenIOPropeitesForm()
        {
            
                lastAdded = tabFactory.GetTab(new TabCodon("属性", "属性", TabTypes.Property)) as IOPropeitesForm;
                lastAdded.TabText = "属性";
                lastAdded.Text = "属性";
           
            OnShowTab(lastAdded);
        }
        #endregion


        
  
        #region   打开日志
        public OperatorLogForm OperatorLogForm
        {
            get
            {
                if (tabFactory.OperatorLogForm == null)
                    return null;
                else
                    return tabFactory.OperatorLogForm;
            }
        }
        public void OpenOperatorLogForm()
        {
           
                lastAdded = tabFactory.GetTab(new TabCodon("日志", "日志", TabTypes.Logbook)) as OperatorLogForm;
                lastAdded.TabText = "日志";
                lastAdded.Text = "日志";
           
         
            OnShowTab(lastAdded);
        }
        #endregion
        #region  实时数据
        public RealQueryWorkForm RealQueryWorkForm
        {
            get
            {
                if (tabFactory.RealQueryWorkForm == null)
                    return null;
                else
                    return tabFactory.RealQueryWorkForm;
            }
        }
        public void OpenRealQueryWorkForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("实时数据", "实时数据", TabTypes.RealTimeData)) as RealQueryWorkForm;
            lastAdded.TabText = "实时数据";
            lastAdded.Text = "实时数据";
            OnShowTab(lastAdded);

        }
        #endregion
        #region  历史数据查询
        public HistoryQueryWorkForm HistoryQueryWorkForm
        {
            get
            {
                if (tabFactory.HistoryQueryWorkForm == null)
                    return null;
                else
                    return tabFactory.HistoryQueryWorkForm;
            }
        }
        public void OpenHistoryQueryWorkForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("历史数据", "历史数据", TabTypes.HistoricalData)) as HistoryQueryWorkForm;
            lastAdded.TabText = "历史数据";
            lastAdded.Text = "历史数据";
            OnShowTab(lastAdded);

        }
        #endregion
        #region  历史报警查询
        public HistoryAlarmQueryWorkForm HistoryAlarmQueryWorkForm
        {
            get
            {
                if (tabFactory.HistoryAlarmQueryWorkForm == null)
                    return null;
                else
                    return tabFactory.HistoryAlarmQueryWorkForm;
            }
        }
        public void OpenHistoryAlarmQueryWorkForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("历史报警", "历史报警", TabTypes.HistoricalAlarm)) as HistoryAlarmQueryWorkForm;
            lastAdded.TabText = "历史报警";
            lastAdded.Text = "历史报警";
            OnShowTab(lastAdded);

        }
        #endregion

        #region  历史下置查询
        public SendCommandQueryWorkForm SendCommandQueryWorkForm
        {
            get
            {
                if (tabFactory.SendCommandQueryWorkForm == null)
                    return null;
                else
                    return tabFactory.SendCommandQueryWorkForm;
            }
        }
        public void OpenSendCommandQueryWorkForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("下置查询", "下置查询", TabTypes.LowerQuery)) as SendCommandQueryWorkForm;
            lastAdded.TabText = "下置查询";
            lastAdded.Text = "下置查询";
            OnShowTab(lastAdded);

        }
        #endregion
        #region  历史报警配置日志
        public AlarmConfigQueryWorkForm AlarmConfigQueryWorkForm
        {
            get
            {
                if (tabFactory.AlarmConfigQueryWorkForm == null)
                    return null;
                else
                    return tabFactory.AlarmConfigQueryWorkForm;
            }
        }
        public void OpenAlarmConfigQueryWorkForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("报警配置日志", "报警配置日志", TabTypes.AlarmConfigurationLog)) as AlarmConfigQueryWorkForm;
            lastAdded.TabText = "报警配置日志";
            lastAdded.Text = "报警配置日志";
            OnShowTab(lastAdded);

        }
        #endregion
        #region  历史统计
        public HistoryStaticsQueryWorkForm HistoryStaticsQueryWorkForm
        {
            get
            {
                if (tabFactory.HistoryStaticsQueryWorkForm == null)
                    return null;
                else
                    return tabFactory.HistoryStaticsQueryWorkForm;
            }
        }
        public void OpenHistoryStaticsQueryWorkForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("历史统计", "历史统计", TabTypes.HistoricalStatistics)) as HistoryStaticsQueryWorkForm;
            lastAdded.TabText = "历史统计";
            lastAdded.Text = "历史统计";
            OnShowTab(lastAdded);

        }
        #endregion
        #region  数据库备份
        public InfluxDBBackupForm InfluxDBBackupForm
        {
            get
            {
                if (tabFactory.InfluxDBBackupForm == null)
                    return null;
                else
                    return tabFactory.InfluxDBBackupForm;
            }
        }
        public void OpenInfluxDBBackupForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("数据库备份", "数据库备份", TabTypes.DatabaseBackup)) as InfluxDBBackupForm;
            lastAdded.TabText = "数据库备份";
            lastAdded.Text = "数据库备份";
            OnShowTab(lastAdded);

        }
        #endregion
        
        #region  
        public InfluxConfigForm InfluxConfigForm
        {
            get
            {
                if (tabFactory.InfluxConfigForm == null)
                    return null;
                else
                    return tabFactory.InfluxConfigForm;
            }
        }
        public void OpenInfluxConfigForm()
        {
            lastAdded = tabFactory.GetTab(new TabCodon("时序数据库配置", "时序数据库配置", TabTypes.DatabaseConfiguration)) as InfluxConfigForm;
            lastAdded.TabText = "时序数据库配置";
            lastAdded.Text = "时序数据库配置";
            OnShowTab(lastAdded);
        }
        #endregion
        
        private void OnTabCall(DockContent tab)
        {
            TabTypes type = (tab as ICobaltTab).TabType;
            switch (type)
            {

                case TabTypes.Logbook:
                    tab.Show(dockPanel, DockState.DockBottom);
                    break;
                case TabTypes.Property:
                    tab.Show(dockPanel, DockState.DockRight);
                    break;
                case TabTypes.IOCatalog:
                    tab.Show(dockPanel, DockState.DockLeft);
                    break;
                case TabTypes.PointArea:
                    tab.Show(dockPanel, DockState.Document);
                    break;
                case TabTypes.DatabaseConfiguration:
                    tab.Show(dockPanel, DockState.Document);
                    break;
                case TabTypes.RealTimeData:
                    tab.Show(dockPanel, DockState.Document);
                    break;
                case TabTypes.HistoricalData:
                    tab.Show(dockPanel, DockState.Document);
                    break;
                case TabTypes.HistoricalAlarm:
                    tab.Show(dockPanel, DockState.Document);
                    break;
                case TabTypes.LowerQuery:
                    tab.Show(dockPanel, DockState.Document);
                    break;
                case TabTypes.AlarmConfigurationLog:
                    tab.Show(dockPanel, DockState.Document);
                    break;
                case TabTypes.HistoricalStatistics:
                    tab.Show(dockPanel, DockState.Document);
                    break;
                case TabTypes.DatabaseBackup:
                    tab.Show(dockPanel, DockState.Document);
                    break;
                case TabTypes.MessageServiceConfiguration:
                    tab.Show(dockPanel, DockState.Document);
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
