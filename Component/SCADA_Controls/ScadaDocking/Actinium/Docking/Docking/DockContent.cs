// *****************************************************************************
// 
//  Copyright 2004, Weifen Luo
//  All rights reserved. The software and associated documentation 
//  supplied hereunder are the proprietary information of Weifen Luo
//  and are supplied subject to licence terms.
// 
//  WinFormsUI Library Version 1.0
// *****************************************************************************

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
 
 


namespace Scada.Controls
{
   
    /// <summary>
    /// Ä£·ÂVSÍ£¿¿´°Ìå
    /// </summary>
    public class DockContent  : Form
	{
       
        /// <summary>
        /// ¼ÓÔØÀúÊ·²ÎÊý
        /// </summary>
        public virtual void LoadHistory()
        {

        }
		public DockContent()
		{
			RefreshMdiIntegration();
            this.Width = 200;
            this.Font = new Font("Î¢ÈíÑÅºÚ", 11);
       
     
		}
        public virtual void DisposeData()
        {

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            DisposeData();
            
            base.OnClosing(e);
        }
		/// <exclude/>
		protected override void Dispose(bool disposing)
		{
            if (disposing)
            {
                if (m_hiddenMdiChild != null)
                {
                    m_hiddenMdiChild.Close();
                    m_hiddenMdiChild = null;
                }

                DockPanel = null;
                if (AutoHideTab != null)
                    AutoHideTab.Dispose();
                if (DockPaneTab != null)
                    DockPaneTab.Dispose();
            }

            base.Dispose(disposing);
        }

		private bool m_allowRedocking = true;
		/// <include file='CodeDoc\DockContent.xml' path='//CodeDoc/Class[@name="DockContent"]/Property[@name="AllowRedocking"]/*'/>
		[LocalizedCategory("Category.Docking")]
		[LocalizedDescription("DockContent.AllowRedocking.Description")]
		[DefaultValue(true)]
		public bool AllowRedocking
		{
			get	{	return m_allowRedocking;	}
			set	{	m_allowRedocking = value;	}
		}

		private DockAreas m_allowedAreas = DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.DockBottom | DockAreas.Document | DockAreas.Float;
		[LocalizedCategory("Category.Docking")]
		[LocalizedDescription("DockContent.DockableAreas.Description")]
		[DefaultValue(DockAreas.DockLeft|DockAreas.DockRight|DockAreas.DockTop|DockAreas.DockBottom|DockAreas.Document|DockAreas.Float)]
		public DockAreas DockableAreas
		{
			get	{	return m_allowedAreas;	}
			set
			{
				if (m_allowedAreas == value)
					return;

				if (!DockHelper.IsDockStateValid(DockState, value))
			

				m_allowedAreas = value;

				if (!DockHelper.IsDockStateValid(ShowHint, m_allowedAreas))
					ShowHint = DockState.Unknown;
			}
		}

		private double m_autoHidePortion = 0.25;
		[LocalizedCategory("Category.Docking")]
		[LocalizedDescription("DockContent.AutoHidePortion.Description")]
		[DefaultValue(0.25)]
		public double AutoHidePortion
		{
			get	{	return m_autoHidePortion;	}
			set
			{
                if (value <= 0 || value > 1)
                {
                }


				if (m_autoHidePortion == value)
					return;

				m_autoHidePortion = value;

				if (DockPanel == null)
					return;

				if (DockPanel.ActiveAutoHideContent == this)
					DockPanel.PerformLayout();
			}
		}

		private string m_tabText = null;
		[Localizable(true)]
		[LocalizedCategory("Category.Docking")]
		[LocalizedDescription("DockContent.TabText.Description")]
		[DefaultValue(null)]
		public string TabText
		{
			get	{	return DesignMode ? m_tabText : (m_tabText==null ? this.Text : m_tabText);	}
			set
			{
				if (m_tabText == value)
					return;

				m_tabText = value;
				if (Pane != null)
					Pane.RefreshChanges();
			}
		}
		private bool ShouldSerializeTabText()
		{
			return (m_tabText != null);
		}

		private bool m_closeButton = true;

		[LocalizedCategory("Category.Docking")]
		[LocalizedDescription("DockContent.CloseButton.Description")]
		[DefaultValue(true)]
		public bool CloseButton
		{
			get	{	return m_closeButton;	}
			set
			{
				if (m_closeButton == value)
					return;

				m_closeButton = value;
				if (Pane != null)
					if (Pane.ActiveContent == this)
						Pane.RefreshChanges();
			}
		}
		
		private DockPanel m_dockPanel = null;

		[Browsable(false)]
		public DockPanel DockPanel
		{
			get { return m_dockPanel; }
			set
			{
				if (m_dockPanel == value)
					return;

				Pane = null;

				if (m_dockPanel != null)
					m_dockPanel.RemoveContent(this);

				if (m_dockPaneTab != null)
				{
					m_dockPaneTab.Dispose();
					m_dockPaneTab = null;
				}

				if (m_autoHideTab != null)
				{
					m_autoHideTab.Dispose();
					m_autoHideTab = null;
				}

				m_dockPanel = value;

				if (m_dockPanel != null)
				{
					Size = Size.Empty;	// To reduce the screen flicker
					m_dockPanel.AddContent(this);
					TopLevel = false;
					FormBorderStyle = FormBorderStyle.None;
					ShowInTaskbar = false;
					Visible = true;
					m_dockPaneTab = DockPanel.DockPaneTabFactory.CreateDockPaneTab(this);
					m_autoHideTab = DockPanel.AutoHideTabFactory.CreateAutoHideTab(this);
				}

				RefreshMdiIntegration();
			}
		}

		private DockState DefaultShowState
		{
			get
			{
				if (ShowHint != DockState.Unknown)
					return ShowHint;

				if ((DockableAreas & DockAreas.Document) != 0)
					return DockState.Document;
				if ((DockableAreas & DockAreas.DockRight) != 0)
					return DockState.DockRight;
				if ((DockableAreas & DockAreas.DockLeft) != 0)
					return DockState.DockLeft;
				if ((DockableAreas & DockAreas.DockBottom) != 0)
					return DockState.DockBottom;
				if ((DockableAreas & DockAreas.DockTop) != 0)
					return DockState.DockTop;
				if ((DockableAreas & DockAreas.Float) != 0)
					return DockState.Float;

				return DockState.Unknown;
			}
		}

		private DockState DefaultDockState
		{
			get
			{
				if (ShowHint != DockState.Unknown && ShowHint != DockState.Hidden && ShowHint != DockState.Float)
					return ShowHint;

				if ((DockableAreas & DockAreas.Document) != 0)
					return DockState.Document;
				if ((DockableAreas & DockAreas.DockRight) != 0)
					return DockState.DockRight;
				if ((DockableAreas & DockAreas.DockLeft) != 0)
					return DockState.DockLeft;
				if ((DockableAreas & DockAreas.DockBottom) != 0)
					return DockState.DockBottom;
				if ((DockableAreas & DockAreas.DockTop) != 0)
					return DockState.DockTop;

				return DockState.Unknown;
			}
		}

		private DockState m_dockState = DockState.Unknown;
	
		[Browsable(false)]
		public DockState DockState
		{
			get	{	return m_dockState;	}
			set
			{
				if (m_dockState == value)
					return;

				if (value == DockState.Hidden)
					IsHidden = true;
				else
					SetDockState(false, value, Pane);
			}
		}

	
		public DockPane Pane
		{
			get {	return IsFloat ? FloatPane : PanelPane; }
			set
			{
				if (Pane == value)
					return;

				DockPane oldPane = Pane;

				SuspendSetDockState();
				FloatPane = (value == null ? null : (value.IsFloat ? value : FloatPane));
				PanelPane = (value == null ? null : (value.IsFloat ? PanelPane : value));
				ResumeSetDockState(IsHidden, value != null ? value.DockState : DockState.Unknown, oldPane);
			}
		}

		private bool m_isHidden = false;
	
		[Browsable(false)]
		public bool IsHidden
		{
			get	{	return m_isHidden;	}
			set
			{
				if (m_isHidden == value)
					return;

				SetDockState(value, VisibleState, Pane);
			}
		}

		private DockState m_visibleState = DockState.Unknown;
		
		[Browsable(false)]
		public DockState VisibleState
		{
			get	{	return m_visibleState;	}
			set
			{
				if (m_visibleState == value)
					return;

				SetDockState(IsHidden, value, Pane);
			}
		}

		private bool m_isFloat = false;
	
		[Browsable(false)]
		public bool IsFloat
		{
			get	{	return m_isFloat;	}
			set
			{
				DockState visibleState;

				if (m_isFloat == value)
					return;

				DockPane oldPane = Pane;

				if (value)
				{
					if (!IsDockStateValid(DockState.Float))
						throw new InvalidOperationException("Error");
					visibleState = DockState.Float;
				}
				else
					visibleState = (PanelPane != null) ? PanelPane.DockState : DefaultDockState;

				if (visibleState == DockState.Unknown)
                    throw new InvalidOperationException("Error");

				SetDockState(IsHidden, visibleState, oldPane);
			}
		}

		private DockPane m_panelPane = null;
	
		[Browsable(false)]
		public DockPane PanelPane
		{
			get	{	return m_panelPane;	}
			set
			{
				if (m_panelPane == value)
					return;

				if (value != null)
				{
					if (value.IsFloat || value.DockPanel != DockPanel)
                        throw new InvalidOperationException("InvalidValue");
				}

				DockPane oldPane = Pane;

				if (m_panelPane != null)
					m_panelPane.RemoveContent(this);

				m_panelPane = value;
				if (m_panelPane != null)
				{
					m_panelPane.AddContent(this);
					SetDockState(IsHidden, IsFloat ? DockState.Float : m_panelPane.DockState, oldPane);
				}
				else
					SetDockState(IsHidden, DockState.Unknown, oldPane);
			}
		}

		private DockPane m_floatPane = null;
	
		[Browsable(false)]
		public DockPane FloatPane
		{
			get	{	return m_floatPane;	}
			set
			{
				if (m_floatPane == value)
					return;

				if (value != null)
				{
					if (!value.IsFloat || value.DockPanel != DockPanel)
                        throw new InvalidOperationException("InvalidValue");
				}

				DockPane oldPane = Pane;

				if (m_floatPane != null)
					m_floatPane.RemoveContent(this);

				m_floatPane = value;
				if (m_floatPane != null)
				{
					m_floatPane.AddContent(this);
					SetDockState(IsHidden, IsFloat ? DockState.Float : VisibleState, oldPane);
				}
				else
					SetDockState(IsHidden, DockState.Unknown, oldPane);
			}
		}

		private int m_countSetDockState = 0;
		private void SuspendSetDockState()
		{
			m_countSetDockState ++;
		}

		private void ResumeSetDockState()
		{
			m_countSetDockState --;
			if (m_countSetDockState < 0)
				m_countSetDockState = 0;
		}

		private void ResumeSetDockState(bool isHidden, DockState visibleState, DockPane oldPane)
		{
			ResumeSetDockState();
			SetDockState(isHidden, visibleState, oldPane);
		}

		internal void SetDockState(bool isHidden, DockState visibleState, DockPane oldPane)
		{
			if (m_countSetDockState != 0)
				return;

			if (DockPanel == null && visibleState != DockState.Unknown)
                throw new InvalidOperationException("InvalidValue");

			if (visibleState == DockState.Hidden || (visibleState != DockState.Unknown && !IsDockStateValid(visibleState)))
                throw new InvalidOperationException("InvalidValue");

			SuspendSetDockState();

			DockState oldDockState = DockState;

			if (m_isHidden != isHidden)
			{
				m_isHidden = isHidden;
				Visible = !isHidden;
				if (HiddenMdiChild != null)
					HiddenMdiChild.Visible = (!IsHidden);
			}
			m_visibleState = visibleState;
			m_dockState = isHidden ? DockState.Hidden : visibleState;

			if (visibleState != DockState.Unknown)
			{
				m_isFloat = (m_visibleState == DockState.Float);

				if (Pane == null)
					Pane = DockPanel.DockPaneFactory.CreateDockPane(this, visibleState, true);
				else if (Pane.DockState != visibleState)
				{
					if (Pane.Contents.Count == 1)
						Pane.SetDockState(visibleState);
					else
						Pane = DockPanel.DockPaneFactory.CreateDockPane(this, visibleState, true);
				}
			}
			else
				Pane = null;

			SetParent(Pane);

			if (oldPane != null && !oldPane.IsDisposed && oldDockState == oldPane.DockState)
				RefreshDockPane(oldPane);

			if (Pane != null && DockState == Pane.DockState)
			{
				if ((Pane != oldPane) ||
					(Pane == oldPane && oldDockState != oldPane.DockState))
					RefreshDockPane(Pane);
			}

			if (oldDockState != DockState)
			{
				RefreshMdiIntegration();
				OnDockStateChanged(EventArgs.Empty);
			}
			ResumeSetDockState();
		}

		private void RefreshDockPane(DockPane pane)
		{
			pane.RefreshChanges();
			pane.ValidateActiveContent();
		}

		internal string PersistString
		{
			get	{	return GetPersistString();	}
		}
	
		protected virtual string GetPersistString()
		{
			return GetType().ToString();
		}

		private HiddenMdiChild m_hiddenMdiChild = null;
		internal HiddenMdiChild HiddenMdiChild
		{
			get	{	return m_hiddenMdiChild;	}
		}

		private bool m_hideOnClose = false;

		[LocalizedCategory("Category.Docking")]
		[LocalizedDescription("DockContent.HideOnClose.Description")]
		[DefaultValue(false)]
		public bool HideOnClose
		{
			get	{	return m_hideOnClose;	}
			set	{	m_hideOnClose = value;	}
		}

		/// <exclude/>
		public new MainMenu Menu
		{
			get	{	return HiddenMdiChild == null ? base.Menu : HiddenMdiChild.Menu;	}
			set
			{
				if (HiddenMdiChild == null)
					base.Menu = value;
				else
					HiddenMdiChild.Menu = value;
			}
		}

		private DockState m_showHint = DockState.Unknown;

		[LocalizedCategory("Category.Docking")]
		[LocalizedDescription("DockContent.ShowHint.Description")]
		[DefaultValue(DockState.Unknown)]
		public DockState ShowHint
		{
			get	{	return m_showHint;	}
			set
			{	
				if (!DockHelper.IsDockStateValid(value, DockableAreas))
                    throw new InvalidOperationException("InvalidValue");

				if (m_showHint == value)
					return;

				m_showHint = value;
			}
		}

		private bool m_isActivated = false;

		[Browsable(false)]
		public bool IsActivated
		{
			get	{	return m_isActivated;	}
		}
		internal void SetIsActivated(bool value)
		{
			if (m_isActivated == value)
				return;

			m_isActivated = value;
		}


		public bool IsDockStateValid(DockState dockState)
		{
			return DockHelper.IsDockStateValid(dockState, DockableAreas);
		}

		private ContextMenu m_tabPageContextMenu = null;

		[LocalizedCategory("Category.Docking")]
		[LocalizedDescription("DockContent.TabPageContextMenu.Description")]
		[DefaultValue(null)]
		public ContextMenu TabPageContextMenu
		{
			get	{	return m_tabPageContextMenu;	}
			set	{	m_tabPageContextMenu = value;	}
		}

		private string m_toolTipText = null;

		[Localizable(true)]
		[Category("Appearance")]
		[LocalizedDescription("DockContent.ToolTipText.Description")]
		[DefaultValue(null)]
		public string ToolTipText
		{
			get	{	return m_toolTipText;	}
			set {	m_toolTipText = value;	}
		}


		public new void Activate()
		{
			if (DockPanel == null)
				base.Activate();
			else if (Pane == null)
				Show(DockPanel);
			else
			{
				IsHidden = false;
				Pane.ActiveContent = this;
				Pane.Activate();
			}
		}

		/// <exclude/>
		public new void Hide()
		{
			IsHidden = true;
		}

		internal void SetParent(Control value)
		{
			if (Parent == value)
				return;

			Control oldParent = Parent;

			//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
			// Workaround for .Net Framework bug: removing control from Form may cause form
			// unclosable. Set focus to another dummy control.
			//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
			Form form = null;
			if (Parent is DockPane)
				form = ((DockPane)Parent).FindForm();
			if (ContainsFocus)
			{
				if (form is FloatWindow)
				{
					((FloatWindow)form).DummyControl.Focus();
					form.ActiveControl = ((FloatWindow)form).DummyControl;
				}
				else if (DockPanel != null)
				{
					DockPanel.DummyControl.Focus();
					if (form != null)
						form.ActiveControl = DockPanel.DummyControl;
				}
			}
			//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

			Size = Size.Empty;	// To reduce screen flicker
			Parent = value;
		}

		public new void Show()
		{
			if (DockPanel == null)
				base.Show();
			else
				Show(DockPanel);
		}


		public void Show(DockPanel dockPanel)
		{
			if (dockPanel == null)
                throw new InvalidOperationException("InvalidValue");

			if (DockState == DockState.Unknown)
				Show(dockPanel, DefaultShowState);
			else			
				Activate();
		}


		public void Show(DockPanel dockPanel, DockState dockState)
		{
			if (dockPanel == null)
                return;

            if (dockState == DockState.Unknown || dockState == DockState.Hidden)
                return;

			DockPanel = dockPanel;

			if (dockState == DockState.Float && FloatPane == null)
				Pane = DockPanel.DockPaneFactory.CreateDockPane(this, DockState.Float, true);
			else if (PanelPane == null)
			{
				DockPane paneExisting = null;
				foreach (DockPane pane in DockPanel.Panes)
					if (pane.DockState == dockState)
					{
						paneExisting = pane;
						break;
					}

				if (paneExisting == null)
					Pane = DockPanel.DockPaneFactory.CreateDockPane(this, dockState, true);
				else
					Pane = paneExisting;
			}

			DockState = dockState;
			Activate();
		}


		public void Show(DockPanel dockPanel, Rectangle floatWindowBounds)
		{
			if (dockPanel == null)
                throw new InvalidOperationException("InvalidValue");

			DockPanel = dockPanel;
			if (FloatPane == null)
			{
				IsHidden = true;	// to reduce the screen flicker
				FloatPane = DockPanel.DockPaneFactory.CreateDockPane(this, DockState.Float, false);
				FloatPane.FloatWindow.StartPosition = FormStartPosition.Manual;
			}

			FloatPane.FloatWindow.Bounds = floatWindowBounds;
			
			Show(dockPanel, DockState.Float);
			Activate();
		}


		public void Show(DockPane pane, DockContent beforeContent)
		{
			if (pane == null)
                throw new InvalidOperationException("InvalidValue");

			if (beforeContent != null && pane.Contents.IndexOf(beforeContent) == -1)
                throw new InvalidOperationException("InvalidValue");

			DockPanel = pane.DockPanel;
			Pane = pane;
			pane.SetContentIndex(this, pane.Contents.IndexOf(beforeContent));
			Show();
		}

		/// <include file='CodeDoc\DockContent.xml' path='//CodeDoc/Class[@name="DockContent"]/Method[@name="Show(DockPane, DockAlignment, double)"]/*'/>
		public void Show(DockPane prevPane, DockAlignment alignment, double proportion)
		{
			if (prevPane == null)
                throw new InvalidOperationException("InvalidValue");

			if (DockHelper.IsDockStateAutoHide(prevPane.DockState))
                throw new InvalidOperationException("InvalidValue");

			DockPanel = prevPane.DockPanel;
			DockPanel.DockPaneFactory.CreateDockPane(this, prevPane, alignment, proportion, true);
			Show();
		}

		/// <exclude/>
		protected override void OnClosed(EventArgs e)
		{
			//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
			// Workaround of .Net Framework bug to avoid main form unclosable
			//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
			if (Environment.Version.Major == 1)
			{
				if (DockPanel != null)
					DockPanel = null;
			}

			base.OnClosed (e);
		}

		/// <exclude/>
		protected override void OnTextChanged(EventArgs e)
		{
			if (m_hiddenMdiChild != null)
				m_hiddenMdiChild.Text = this.Text;
			if (DockHelper.IsDockStateAutoHide(DockState))
				DockPanel.RefreshAutoHideStrip();
			else if (Pane != null)
			{
				if (Pane.FloatWindow != null)
					Pane.FloatWindow.SetText();
				Pane.RefreshChanges();
			}

			base.OnTextChanged(e);
		}

		internal void RefreshMdiIntegration()
		{
			Form mdiParent = GetMdiParentForm();

			if (mdiParent == null)
			{
				if (HiddenMdiChild != null)
				{
					m_hiddenMdiChild.Close();
					m_hiddenMdiChild = null;
				}
			}
			else
			{
				if (HiddenMdiChild == null)
					m_hiddenMdiChild = new HiddenMdiChild(this);

				m_hiddenMdiChild.SetMdiParent(mdiParent);
			}
			
			if (DockPanel != null)
				if (DockPanel.ActiveDocument != null)
					if (DockPanel.ActiveDocument.HiddenMdiChild != null)
						DockPanel.ActiveDocument.HiddenMdiChild.Activate();
		}
		private Form GetMdiParentForm()
		{
			if (DockPanel == null)
				return null;

			if (!DockPanel.MdiIntegration)
				return null;

			if (DockState != DockState.Document)
				return null;

			Form parentMdi = DockPanel.FindForm();
			if (parentMdi != null)
				if (!parentMdi.IsMdiContainer)
					parentMdi = null;

			return parentMdi;
		}

		private DockPaneTab m_dockPaneTab = null;
		internal DockPaneTab DockPaneTab
		{
			get	{	return m_dockPaneTab;	}
		}

		private AutoHideTab m_autoHideTab = null;
		internal AutoHideTab AutoHideTab
		{
			get	{	return m_autoHideTab;	}
		}

		#region Events
		private static readonly object DockStateChangedEvent = new object();

		[LocalizedCategory("Category.PropertyChanged")]
		[LocalizedDescription("Pane.DockStateChanged.Description")]
		public event EventHandler DockStateChanged
		{
			add	{	Events.AddHandler(DockStateChangedEvent, value);	}
			remove	{	Events.RemoveHandler(DockStateChangedEvent, value);	}
		}

		protected virtual void OnDockStateChanged(EventArgs e)
		{
			EventHandler handler = (EventHandler)Events[DockStateChangedEvent];
			if (handler != null)
				handler(this, e);
		}
		#endregion

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContent));
            this.SuspendLayout();
            // 
            // DockContent
            // 
            this.ClientSize = new System.Drawing.Size(224, 262);
            this.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DockContent";
            this.ResumeLayout(false);

        }
	}

   
}
