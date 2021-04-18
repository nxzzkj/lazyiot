using Scada.Controls.Forms;
using ScadaCenterServer;
using ScadaCenterServer.Core;
using ScadaCenterServer.Pages;
using Scada.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using Scada.DBUtility;

namespace ScadaCenterServer
{
    /// <summary>
    /// 
    /// </summary>
    public class TabFactory
    {
        public event TabInfo OnTabCreation;
       private Mediator mediator;
        //
        
    
        #region IO目录
        /// <summary>
        ///
        /// </summary>
        private IOTreeForm _IOTreeForm;
        public IOTreeForm IOTreeForm
        {
            get
            {
                CreateIOTreeForm(new TabCodon("IO目录", "IO目录", TabTypes.IOCatalog));
                return _IOTreeForm;
            }
        }
        private void CreateIOTreeForm(TabCodon tabCodon)
        {
            if (_IOTreeForm == null || _IOTreeForm.IsDisposed)
            {
                _IOTreeForm = new IOTreeForm(this.mediator);
                _IOTreeForm.Text = "采集监视";
                _IOTreeForm.TabIdentifier = tabCodon.CodonName;
                RaiseNewTab(_IOTreeForm);
            }


        }

        #endregion
        #region 属性
        /// <summary>
        ///
        /// </summary>
        private IOPropeitesForm _IOPropeitesForm;
        public IOPropeitesForm IOPropeitesForm
        {
            get
            {
                CreateIOPropeitesForm(new TabCodon("属性", "属性", TabTypes.Property));
                return _IOPropeitesForm;
            }
        }
        private void CreateIOPropeitesForm(TabCodon tabCodon)
        {
            if (_IOPropeitesForm == null || _IOPropeitesForm.IsDisposed)
            {
                _IOPropeitesForm = new IOPropeitesForm(this.mediator);
                _IOPropeitesForm.Text = "属性";
                _IOPropeitesForm.TabIdentifier = tabCodon.CodonName;
                RaiseNewTab(_IOPropeitesForm);
            }


        }

        #endregion
        #region 日志
        /// <summary>
        ///
        /// </summary>
        private OperatorLogForm _OperatorLogForm;
        public OperatorLogForm OperatorLogForm
        {
            get
            {
                CreateOperatorLogForm(new TabCodon("日志", "日志", TabTypes.Logbook));
                return _OperatorLogForm;
            }
        }
        private void CreateOperatorLogForm(TabCodon tabCodon)
        {
            if (_OperatorLogForm == null || _OperatorLogForm.IsDisposed)
            {
                _OperatorLogForm = new OperatorLogForm(this.mediator);
                _OperatorLogForm.Text = "日志";
                _OperatorLogForm.TabIdentifier = tabCodon.CodonName;
                RaiseNewTab(_OperatorLogForm);
            }


        }

        #endregion
        #region 实时数据
        /// <summary>
        ///
        /// </summary>
        private RealQueryWorkForm _RealQueryWorkForm;
        public RealQueryWorkForm RealQueryWorkForm
        {
            get
            {
                CreateRealQueryWorkForm(new TabCodon("实时数据", "实时数据", TabTypes.RealTimeData));
                return _RealQueryWorkForm;
            }
        }
        private    void CreateRealQueryWorkForm(TabCodon tabCodon)
        {
            if (_RealQueryWorkForm == null || _RealQueryWorkForm.IsDisposed)
            {
                _RealQueryWorkForm = new RealQueryWorkForm(this.mediator);
                _RealQueryWorkForm.Text = "实时数据";
                _RealQueryWorkForm.TabIdentifier = tabCodon.CodonName;
             
                RaiseNewTab(_RealQueryWorkForm);
 
            }


        }

        #endregion
        #region 历史数据
        /// <summary>
        ///
        /// </summary>
        private HistoryQueryWorkForm _HistoryQueryWorkForm;
        public HistoryQueryWorkForm HistoryQueryWorkForm
        {
            get
            {
                CreateHistoryQueryWorkForm(new TabCodon("历史数据", "历史数据", TabTypes.HistoricalData));
                return _HistoryQueryWorkForm;
            }
        }
        private void CreateHistoryQueryWorkForm(TabCodon tabCodon)
        {
            if (_HistoryQueryWorkForm == null || _HistoryQueryWorkForm.IsDisposed)
            {
                //初始的时候没有加载任何设备
                _HistoryQueryWorkForm = new HistoryQueryWorkForm(this.mediator,null);
                _HistoryQueryWorkForm.Text = "历史数据";
                _HistoryQueryWorkForm.TabIdentifier = tabCodon.CodonName;

                RaiseNewTab(_HistoryQueryWorkForm);

            }


        }

        #endregion
        #region 历史报警
        /// <summary>
        ///
        /// </summary>
        private HistoryAlarmQueryWorkForm _HistoryAlarmQueryWorkForm;
        public HistoryAlarmQueryWorkForm HistoryAlarmQueryWorkForm
        {
            get
            {
                CreateHistoryAlarmQueryWorkForm(new TabCodon("历史报警", "历史报警", TabTypes.HistoricalAlarm));
                return _HistoryAlarmQueryWorkForm;
            }
        }
        private void CreateHistoryAlarmQueryWorkForm(TabCodon tabCodon)
        {
            if (_HistoryAlarmQueryWorkForm == null || _HistoryAlarmQueryWorkForm.IsDisposed)
            {
                //初始的时候没有加载任何设备
                _HistoryAlarmQueryWorkForm = new HistoryAlarmQueryWorkForm(this.mediator, null);
                _HistoryAlarmQueryWorkForm.Text = "历史报警";
                _HistoryAlarmQueryWorkForm.TabIdentifier = tabCodon.CodonName;

                RaiseNewTab(_HistoryAlarmQueryWorkForm);

            }


        }

        #endregion

        #region 历史下置
        /// <summary>
        ///
        /// </summary>
        private SendCommandQueryWorkForm _SendCommandQueryWorkForm;
        public SendCommandQueryWorkForm SendCommandQueryWorkForm
        {
            get
            {
                CreateSendCommandQueryWorkForm(new TabCodon("下置查询", "下置查询", TabTypes.LowerQuery));
                return _SendCommandQueryWorkForm;
            }
        }
        private void CreateSendCommandQueryWorkForm(TabCodon tabCodon)
        {
            if (_SendCommandQueryWorkForm == null || _SendCommandQueryWorkForm.IsDisposed)
            {
                //初始的时候没有加载任何设备
                _SendCommandQueryWorkForm = new SendCommandQueryWorkForm(this.mediator, null);
                _SendCommandQueryWorkForm.Text = "下置查询";
                _SendCommandQueryWorkForm.TabIdentifier = tabCodon.CodonName;

                RaiseNewTab(_SendCommandQueryWorkForm);

            }


        }

        #endregion

        #region 报警规则配置日志
        /// <summary>
        ///
        /// </summary>
        private AlarmConfigQueryWorkForm _AlarmConfigQueryWorkForm;
        public AlarmConfigQueryWorkForm AlarmConfigQueryWorkForm
        {
            get
            {
                CreateAlarmConfigQueryWorkForm(new TabCodon("报警配置日志", "报警配置日志", TabTypes.AlarmConfigurationLog));
                return _AlarmConfigQueryWorkForm;
            }
        }
        private void CreateAlarmConfigQueryWorkForm(TabCodon tabCodon)
        {
            if (_AlarmConfigQueryWorkForm == null || _AlarmConfigQueryWorkForm.IsDisposed)
            {
                //初始的时候没有加载任何设备
                _AlarmConfigQueryWorkForm = new AlarmConfigQueryWorkForm(this.mediator, null);
                _AlarmConfigQueryWorkForm.Text = "报警配置日志";
                _AlarmConfigQueryWorkForm.TabIdentifier = tabCodon.CodonName;

                RaiseNewTab(_AlarmConfigQueryWorkForm);

            }


        }

        #endregion

        #region 报警规则配置日志
        /// <summary>
        ///
        /// </summary>
        private HistoryStaticsQueryWorkForm _HistoryStaticsQueryWorkForm;
        public HistoryStaticsQueryWorkForm HistoryStaticsQueryWorkForm
        {
            get
            {
                CreateHistoryStaticsQueryWorkForm(new TabCodon("历史统计", "历史统计", TabTypes.HistoricalStatistics));
                return _HistoryStaticsQueryWorkForm;
            }
        }
        private void CreateHistoryStaticsQueryWorkForm(TabCodon tabCodon)
        {
            if (_HistoryStaticsQueryWorkForm == null || _HistoryStaticsQueryWorkForm.IsDisposed)
            {
                //初始的时候没有加载任何设备
                _HistoryStaticsQueryWorkForm = new HistoryStaticsQueryWorkForm(this.mediator, null);
                _HistoryStaticsQueryWorkForm.Text = "历史统计";
                _HistoryStaticsQueryWorkForm.TabIdentifier = tabCodon.CodonName;

                RaiseNewTab(_HistoryStaticsQueryWorkForm);

            }


        }

        #endregion
        

        #region 数据库配置
        /// <summary>
        ///
        /// </summary>
        private InfluxConfigForm _InfluxConfigForm;
        public InfluxConfigForm InfluxConfigForm
        {
            get
            {
                CreateInfluxConfigForm(new TabCodon("时序数据库配置", "时序数据库配置", TabTypes.DatabaseConfiguration));
                return _InfluxConfigForm;
            }
        }
        private void CreateInfluxConfigForm(TabCodon tabCodon)
        {
            if (_InfluxConfigForm == null || _InfluxConfigForm.IsDisposed)
            {
                _InfluxConfigForm = new InfluxConfigForm(this.mediator);
                _InfluxConfigForm.Text = "时序数据库配置";
                _InfluxConfigForm.TabIdentifier = tabCodon.CodonName;
                RaiseNewTab(_InfluxConfigForm);
            }


        }

        #endregion
        #region 数据备份配置
        /// <summary>
        ///
        /// </summary>
        private InfluxDBBackupForm _InfluxDBBackupForm;
        public InfluxDBBackupForm InfluxDBBackupForm
        {
            get
            {
                CreateInfluxDBBackupForm(new TabCodon("数据库备份", "数据库备份", TabTypes.DatabaseBackup));
                return _InfluxDBBackupForm;
            }
        }
        private void CreateInfluxDBBackupForm(TabCodon tabCodon)
        {
            if (_InfluxDBBackupForm == null || _InfluxDBBackupForm.IsDisposed)
            {
                _InfluxDBBackupForm = new InfluxDBBackupForm(this.mediator);
                _InfluxDBBackupForm.Text = "数据库备份";
                _InfluxDBBackupForm.TabIdentifier = tabCodon.CodonName;
                RaiseNewTab(_InfluxDBBackupForm);
            }


        }

        #endregion

        

        #region Constructor
        public TabFactory(Mediator mediator)
        {
            this.mediator = mediator;
        }
        #endregion
        #region Methods
        public object GetTab(TabCodon codon)
        {
            switch (codon.TabType)
            {

                case TabTypes.IOCatalog:
                    CreateIOTreeForm(codon);
                    return _IOTreeForm;
                case TabTypes.Property:
                    CreateIOPropeitesForm(codon);
                    return _IOPropeitesForm;
                case TabTypes.Logbook:
                    CreateOperatorLogForm(codon);
                    return _OperatorLogForm;
                case TabTypes.PointArea:
                    CreateRealQueryWorkForm(codon);
                    return _RealQueryWorkForm;
                case TabTypes.DatabaseConfiguration:
                    CreateInfluxConfigForm(codon);
                    return _InfluxConfigForm;
                case TabTypes.RealTimeData:
                    CreateRealQueryWorkForm(codon);
                    return _RealQueryWorkForm;
                case TabTypes.HistoricalData:
                    CreateHistoryQueryWorkForm(codon);
                    return _HistoryQueryWorkForm;
                case TabTypes.HistoricalAlarm:
                    CreateHistoryAlarmQueryWorkForm(codon);
                    return _HistoryAlarmQueryWorkForm;
                case TabTypes.LowerQuery:
                    CreateSendCommandQueryWorkForm(codon);
                    return _SendCommandQueryWorkForm;
                case TabTypes.AlarmConfigurationLog:
                    this.CreateAlarmConfigQueryWorkForm(codon);
                    return _AlarmConfigQueryWorkForm;
                case TabTypes.HistoricalStatistics:
                    this.CreateHistoryStaticsQueryWorkForm(codon);
                    return _HistoryStaticsQueryWorkForm;
                case TabTypes.DatabaseBackup:
                    this.CreateInfluxDBBackupForm(codon);
                    return _InfluxDBBackupForm;
              
            }
            
            return null;
        }
        //
        private void RaiseNewTab(DockContent tab)
        {
            if (OnTabCreation != null)
                OnTabCreation(tab);
        }
        #endregion
    }
    /// <summary>
    /// Passes the tab created, to be added on a higher level in a TabControl
    /// </summary>
    public delegate void TabInfo(DockContent tab);
}
