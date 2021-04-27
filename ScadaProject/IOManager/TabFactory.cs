using Scada.Controls;
using IOManager.Page;
using System;
using System.Collections.Generic;
using System.Text;


namespace IOManager
{
    /// <summary>
    /// Tab factory, handles the creation and uniqueness of tabs (docking forms)
    /// </summary>
    public class TabFactory
    {
        public event TabInfo OnTabCreation;
       private Mediator mediator;
       //
    
        #region 工程区
        /// <summary>
        ///
        /// </summary>
        private IOTreeForm _IOTreeForm;
        public IOTreeForm IOTreeForm
        {
            get
            {
                CreateIOTreeForm(new TabCodon("工程", "工程", TabTypes.Project));
                return _IOTreeForm;
            }
        }
        private void CreateIOTreeForm(TabCodon tabCodon)
        {
            if(_IOTreeForm == null|| _IOTreeForm.IsDisposed)
            {
                _IOTreeForm = new IOTreeForm(this.mediator);
                _IOTreeForm.Text = "工程";
                _IOTreeForm.TabIdentifier = tabCodon.CodonName;

            }
        
            RaiseNewTab(_IOTreeForm);
        }

        #endregion
        #region 工作区
        /// <summary>
        ///WorkForm
        /// </summary>
        private IOParaForm _IOParaForm;
        public IOParaForm IOParaForm
        {
            get
            {
                CreateIOParaForm(new TabCodon("点表区", "点表区", TabTypes.PointArea));
                return _IOParaForm;
            }
        }
        private void CreateIOParaForm(TabCodon tabCodon)
        {
            if (_IOParaForm == null || _IOParaForm.IsDisposed)
            {

                _IOParaForm = new IOParaForm(this.mediator);
                _IOParaForm.Text = "点表区";
                _IOParaForm.TabIdentifier = tabCodon.CodonName;
            }
            RaiseNewTab(_IOParaForm);
        }

        #endregion
        #region 日志
        /// <summary>
        ///WorkForm
        /// </summary>
        private IOLogForm _IOLogForm;
        public IOLogForm IOLogForm
        {
            get
            {
                CreateIOLogForm(new TabCodon("日志", "日志", TabTypes.Logbook));
                return _IOLogForm;
            }
        }
        private void CreateIOLogForm(TabCodon tabCodon)
        {
            if (_IOLogForm == null || _IOLogForm.IsDisposed)
            {
                _IOLogForm = new IOLogForm(this.mediator);
                _IOLogForm.Text = "日志";
                _IOLogForm.TabIdentifier = tabCodon.CodonName;
             
            }
            RaiseNewTab(_IOLogForm);
        }

        #endregion
        #region 驱动管理
        /// <summary>
        ///WorkForm
        /// </summary>
        private IODriveManageForm _IODriveManageForm;
        public IODriveManageForm IODriveManageForm
        {
            get
            {
                CreateIODriveManageForm(new TabCodon("驱动管理", "驱动管理", TabTypes.DriverManagement));
                return _IODriveManageForm;
            }
        }
        private void CreateIODriveManageForm(TabCodon tabCodon)
        {
            if (_IODriveManageForm == null || _IODriveManageForm.IsDisposed)
            {
                _IODriveManageForm = new IODriveManageForm(this.mediator);
                _IODriveManageForm.Text = "驱动管理";
                _IODriveManageForm.TabIdentifier = tabCodon.CodonName;

            }
            RaiseNewTab(_IODriveManageForm);
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
                case TabTypes.Project:
                    CreateIOTreeForm(codon);
                    return _IOTreeForm;
             
                case TabTypes.Logbook:
                    CreateIOLogForm(codon);
                    return _IOLogForm;
                case TabTypes.PointArea:
                    CreateIOParaForm(codon);
                    return _IOParaForm;
                case TabTypes.DriverManagement:
                    CreateIODriveManageForm(codon);
                    return _IODriveManageForm;
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
