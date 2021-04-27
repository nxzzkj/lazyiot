using Scada.Controls;
using ScadaFlowDesign;
using System;
using System.Collections.Generic;
using System.Text;


namespace ScadaFlowDesign
{
    /// <summary>
    /// Tab factory, handles the creation and uniqueness of tabs (docking forms)
    /// </summary>
    public class TabFactory
    {
        public event TabInfo OnTabCreation;
       private Mediator mediator;
       //
       #region 属性
       /// <summary>
       ///油藏公式字典
       /// </summary>
       private PropertiesForm _PropertiesForm;
       public PropertiesForm PropertiesForm
        {
           get
            {
                if (_PropertiesForm == null)
                    CreatePropertiesForm(new TabCodon("属性", "属性", TabTypes.Property));
               return _PropertiesForm;
           }
       }
       private void CreatePropertiesForm(TabCodon tabCodon)
       {
            if (_PropertiesForm == null || _PropertiesForm.IsDisposed)
            {
                _PropertiesForm = new PropertiesForm(this.mediator);
                _PropertiesForm.Text = "属性";
                _PropertiesForm.TabIdentifier = tabCodon.CodonName;
                RaiseNewTab(_PropertiesForm);
            }
          
       
       }

        #endregion
        #region 目录
        /// <summary>
        ///油藏公式字典
        /// </summary>
        private ToolForm _ToolForm;
        public ToolForm ToolForm
        {
            get
            {
                if (_ToolForm == null)
                    CreateToolForm(new TabCodon("工程", "工程", TabTypes.Project));
                return _ToolForm;
            }
        }
        private void CreateToolForm(TabCodon tabCodon)
        {
            if(_ToolForm == null|| _ToolForm.IsDisposed)
            {
                _ToolForm = new ToolForm(this.mediator);
                _ToolForm.Text = "工程";
                _ToolForm.TabIdentifier = tabCodon.CodonName;
                RaiseNewTab(_ToolForm);
            }
        
     
        }

        #endregion
        #region 工作区
        /// <summary>
        ///WorkForm
        /// </summary>
        private WorkForm _WorkForm;
      
        private void CreateWorkForm(TabCodon tabCodon,float mapwidth, float mapheight)
        {

            _WorkForm = new WorkForm(this.mediator, mapwidth, mapheight, tabCodon.Text);
            _WorkForm.Text = tabCodon.Text;
            _WorkForm.TabIdentifier = tabCodon.CodonName;
            RaiseNewTab(_WorkForm);
        }

        #endregion
        #region 日志
        /// <summary>
        ///WorkForm
        /// </summary>
        private LoggerForm _LogForm;
        public LoggerForm LogForm
        {
            get
            {
                if (_LogForm == null)
                    CreateLogForm(new TabCodon("日志", "日志", TabTypes.Logbook));
                return _LogForm;
            }
        }
        private void CreateLogForm(TabCodon tabCodon)
        {
            if (_LogForm == null || _LogForm.IsDisposed)
            {
                _LogForm = new LoggerForm(this.mediator);
                _LogForm.Text = "日志";
                _LogForm.TabIdentifier = tabCodon.CodonName;
                RaiseNewTab(_LogForm);
            }
      
        }

        #endregion
        #region 图元区域
        /// <summary>
        ///WorkForm
        /// </summary>
        private ShapeForm _ShapeForm;
        public ShapeForm ShapeForm
        {
            get
            {
                if(_ShapeForm==null)
                CreateShapeForm(new TabCodon("图元", "图元", TabTypes.Shape));
                return _ShapeForm;
            }
        }
        private void CreateShapeForm(TabCodon tabCodon)
        {

            _ShapeForm = new ShapeForm(this.mediator);
            _ShapeForm.Text = "图元";
            _ShapeForm.TabIdentifier = tabCodon.CodonName;
            RaiseNewTab(_ShapeForm);
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
                case TabTypes.Property:
                    CreatePropertiesForm(codon);
                    return _PropertiesForm;
                case TabTypes.Project:
                    CreateToolForm(codon);
                    return _ToolForm;
                case TabTypes.Logbook:
                    CreateLogForm(codon);
                    return _LogForm;
                case TabTypes.WorkArea:
                    CreateWorkForm(codon, codon.MapWidth, codon.MapHeight);
                    return _WorkForm;
                case TabTypes.Shape:
                    CreateShapeForm(codon);
                    return _ShapeForm;
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
