using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace Scada.Controls.Accordion
{

 
    public class Accordion : UserControl, IMessageFilter
    {

                          public static IResizeBarFactory GlobalResizeBarFactory = new DefaultResizeBarFactory();

                          public static ICheckBoxFactory GlobalCheckBoxFactory = new DefaultCheckBoxFactory();

                          public static String GlobalDownArrow = "\u25bc  ";

                          public static String GlobalUpArrow = "\u25b2  ";

                  
                          public int AnimateOpenMillis { get; set; }

                          public int AnimateCloseMillis { get; set; }

                                   public AnimateWindowFlags AnimateOpenEffect { get; set; }

                                   public AnimateWindowFlags AnimateCloseEffect { get; set; }

                                   public bool AddResizeBars { get; set; }

                          public int ResizeBarsFadeProximity { get; set; }

                 public int ResizeBarsFadeInMillis { get; set; }

                 public int ResizeBarsFadeOutMillis { get; set; }

                                            public bool ResizeBarsKeepFocusAfterMouseDrag { get; set; }

                                   public bool ResizeBarsKeepFocusOnClick { get; set; }

                          public bool ResizeBarsKeepFocusIfControlOutOfView { get; set; }

                          public bool ResizeBarsTabStop { get; set; }

                          public bool ResizeBarsStayVisibleIfFocused { get; set; }

                          public bool ResizeBarsStayInViewOnMouseDrag { get; set; }

                 public bool ResizeBarsStayInViewOnArrowKey { get; set; }

                          public int ResizeBarsArrowKeyDelta { get; set; }

                                   public Padding? ResizeBarsMargin { get; set; }

                                                              public bool ShowPartiallyVisibleResizeBars { get; set; }

                          public double ResizeBarsFill { get; set; }

                          public double ResizeBarsAlign { get; set; }

                          public int ResizeBarsMinimumLength { get; set; }

                          public IResizeBarFactory ResizeBarFactory { get; set; }

                          public bool AutoFixDockStyle { get; set; }

                                   public bool ControlMinimumHeightIsItsPreferredHeight { get; set; }

                                                              public bool ControlMinimumWidthIsItsPreferredWidth { get; set; }

         
                          public ICheckBoxFactory CheckBoxFactory { get; set; }

                          public bool OpenOneOnly { get; set; }

                                   public bool FillResetOnCollapse { get; set; }

                                   public bool FillModeGrowOnly { get; set; }

                                   public bool FillLastOpened { get; set; }

                                                     public Padding? ContentPadding { get; set; }

                          public Padding? ContentMargin { get; set; }

                          public Padding? CheckBoxMargin { get; set; }

                 public Color? ControlBackColor { get; set; }

                                   public Color? ContentBackColor { get; set; }

                          public bool FillWidth { get; set; }

                          public bool FillHeight { get; set; }

                                                                                                  public bool GrowAndShrink { get; set; }

                          public String DownArrow { get; set; }

                          public String UpArrow { get; set; }

                                   public bool ShowToolMenu { get; set; }

                 public bool ShowToolMenuRequiresPositiveFillWeight { get; set; }

                 public bool ShowToolMenuOnHoverWhenClosed { get; set; }

                          public bool ShowToolMenuOnRightClick { get; set; }

                 public bool OpenOnAdd { get; set; }

                                   public Padding Insets { get { return Padding; } set { Padding = value; } }

                          public bool AllowMouseResize { get; set; }

                                   public int GrabWidth { get; set; }

                 public Cursor GrabCursor { get; set; }

                          public bool GrabRequiresPositiveFillWeight { get; set; }

                 private List<Control> ResizeBarsList = new List<Control>();
        private List<Control2> Control2s = new List<Control2>();
        private bool isAnimating = false;
        private AccordionLayoutEngine layoutEngine = new AccordionLayoutEngine();
        private Control2 lastChecked = null;          private ToolTip tips = new ToolTip();
        private ToolBox toolBox = new ToolBox();
                          private bool isAdjusting = false;

                 private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_SETREDRAW = 11;
        private const int WM_NCCALCSIZE = 0x83;
        private const int WM_NCPAINT = 0x85;
        private const int WM_ERASEBKGND = 0x14;
        private const int VK_UP = 0x26;
        private const int VK_DOWN = 0x28;
        private Control2 grabControl = null;
        private Point grabPoint = Point.Empty;
        private Point oldPoint = Point.Empty;
        private int originalDH = 0;
        private bool isDragging = false;
        private bool isOpening = false;
        private bool wasDragged = false;
        private bool origLocked = false;
        private bool resetLocked = true;
        private bool scrollToBottom = false;
        private Control resizeBarHiding = null;
        private Control2 currentControl2 = null;          private IntPtr hwndPreviousFocus = IntPtr.Zero;          private bool ignoreNCCALCSIZE = false;
        private bool ignoreNCPAINT = false;
         
                                                                                         public Accordion()
        {
            AutoScroll = true;
                         AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Dock = DockStyle.Fill;
            DoubleBuffered = true;
                         FillHeight = true;
            FillWidth = true;
            GrowAndShrink = true;
            ShowToolMenu = true;
            AllowMouseResize = true;
            ShowToolMenuOnHoverWhenClosed = false;
            ShowToolMenuOnRightClick = true;
            GrabCursor = Cursors.SizeNS;
            GrabRequiresPositiveFillWeight = true;
            CheckBoxMargin = Padding.Empty;
                         ControlMinimumHeightIsItsPreferredHeight = true;
            ControlMinimumWidthIsItsPreferredWidth = true;
            ResizeBarsKeepFocusOnClick = true;
            ResizeBarsKeepFocusIfControlOutOfView = true;
            ResizeBarsTabStop = true;
            ResizeBarsStayVisibleIfFocused = true;
            ResizeBarsStayInViewOnMouseDrag = true;
            ResizeBarsStayInViewOnArrowKey = true;
            AddResizeBars = true;
            AutoFixDockStyle = true;
            AnimateOpenMillis = 300;
            AnimateCloseMillis = 300;
            ResizeBarsFadeInMillis = 800;
            ResizeBarsFadeOutMillis = 800;
            ResizeBarsFill = 1.0;
            ResizeBarsAlign = 0.5;
            AnimateOpenEffect = AnimateWindowFlags.Show | AnimateWindowFlags.Slide | AnimateWindowFlags.VerticalPositive;
            AnimateCloseEffect = AnimateWindowFlags.Hide | AnimateWindowFlags.Slide | AnimateWindowFlags.VerticalNegative;
                         using (var g = Graphics.FromHwnd(IntPtr.Zero))
            {
                float dpi = Math.Max(g.DpiX, g.DpiY);
                ResizeBarsFadeProximity = (int)(30 * (dpi / 120));
                GrabWidth = Math.Max(6, (int)(6 * (dpi / 120)));
                ContentPadding = new Padding(Math.Max(5, (int)(5 * (dpi / 120))));                  ResizeBarsArrowKeyDelta = Math.Max(10, (int)(10 * (dpi / 120)));
                ResizeBarsMinimumLength = Math.Max(50, (int)(50 * (dpi / 120)));
            }
                         Application.AddMessageFilter(this);
        }

        protected override Point ScrollToControl(Control activeControl)
        {
            Point pt = this.AutoScrollPosition;              if (isOpening)
            {
                pt.Y = base.ScrollToControl(activeControl).Y;
                if (scrollToBottom)
                    pt.Y -= activeControl.Height;
            }
            else if (isDragging && ResizeBarsStayInViewOnMouseDrag && grabControl != null)
            {
                                                                    
                                                                                    if (grabControl.ResizeBar != null)
                {
                    pt.Y = base.ScrollToControl(grabControl.ResizeBar).Y;
                }
                else
                {
                                         activeControl = grabControl;
                    Point pt2 = base.ScrollToControl(activeControl);
                    pt2.Y -= grabControl.Height;
                                         pt.Y = pt2.Y;
                }
            }

            return pt;
        }

        public class AddArgs
        {
            public Control c;
            public String text;
            public String toolTip;
            public double fillWt = 0;
            public bool? open;
            public Padding? contentPadding;
            public Padding? contentMargin;
            public Color? contentBackColor;
            public Padding? checkboxMargin;
            public Padding? resizeBarMargin;
            public bool? addResizeBar;
            public LayoutArgs layoutArgs;
            public Accordion Owner { get; internal set; }
            public CheckBox CheckBox { get; internal set; }
        }

                                            public class LayoutArgs
        {
                                      public double FillX = 0;

                                      public double FillY = 0;

                                                   public double AlignX = 0;

                                                   public double AlignY = 0;
        }

                                                                                                                                                                                                     public CheckBox Add(Control c, String text, String toolTip = null, double fillWt = 0, bool? open = null, Padding? contentPadding = null, Padding? contentMargin = null, Color? contentBackColor = null, Padding? checkboxMargin = null, bool? addResizeBar = null, Padding? resizeBarMargin = null, LayoutArgs layoutArgs = null)
        {
            AddArgs args = new AddArgs();
            args.c = c;
            args.text = text;
            args.toolTip = toolTip;
            args.fillWt = fillWt;
            args.open = open;
            args.contentPadding = contentPadding;
            args.contentMargin = contentMargin;
            args.contentBackColor = contentBackColor;
            args.checkboxMargin = checkboxMargin;
            args.addResizeBar = addResizeBar;
            args.resizeBarMargin = resizeBarMargin;
            args.layoutArgs = layoutArgs;
            return Add(args);
        }

                 public CheckBox Add(AddArgs args)
        {
            args.Owner = this;
            Control c = args.c;
            String toolTip = args.toolTip;
            double fillWt = args.fillWt;
            bool? open = args.open;
            Padding? contentPadding = args.contentPadding;
            Padding? contentMargin = args.contentMargin;
            Color? contentBackColor = args.contentBackColor;
            Padding? checkboxMargin = args.checkboxMargin;
            Padding? resizeBarMargin = args.resizeBarMargin;
            bool? addResizeBar = args.addResizeBar;
            LayoutArgs layoutArgs = args.layoutArgs;

            ICheckBoxFactory cbf = CheckBoxFactory ?? GlobalCheckBoxFactory;
            bool check = open.HasValue ? open.Value : OpenOnAdd;
            CheckBox cb = cbf.CreateCheckBox(args.text, check, Get(checkboxMargin, CheckBoxMargin));
            args.CheckBox = cb;

                         cb.Text = (cb.Checked ? GetUpArrow() : GetDownArrow()) + cb.Text;

            if (!addResizeBar.HasValue)
            {
                addResizeBar = AddResizeBars && AllowMouseResize && (fillWt > 0 || !GrabRequiresPositiveFillWeight);
            }

            if (AutoFixDockStyle && c.Dock != DockStyle.None)
            {
                c.Anchor = Map(c.Dock);
                c.Dock = DockStyle.None;
                                                  c.AutoSize = false;
            }

            Control resizeBar = null;
            Padding c2Padding = Get(contentPadding, ContentPadding);
            Padding c2Margin = Get(contentMargin, ContentMargin);

            if (addResizeBar.Value)
            {
                Padding rbMargin = c2Margin;

                if (resizeBarMargin.HasValue)
                    rbMargin = resizeBarMargin.Value;
                else if (ResizeBarsMargin.HasValue)
                    rbMargin = ResizeBarsMargin.Value;

                var rbf = (ResizeBarFactory != null ? ResizeBarFactory : GlobalResizeBarFactory);
                resizeBar = (rbf != null ? rbf.CreateResizeBar(rbMargin) : null);
            }

            Control2 c2 = new Control2(cb, c, resizeBar, fillWt, layoutArgs);
            c2.Padding = c2Padding;
            c2.Margin = c2Margin;
            Control2s.Add(c2);

            if (contentBackColor.HasValue)
                c2.BackColor = contentBackColor.Value;
            else if (ContentBackColor.HasValue)
                c2.BackColor = ContentBackColor.Value;

            if (ControlBackColor.HasValue)
                c.BackColor = ControlBackColor.Value;

            if (!String.IsNullOrEmpty(toolTip))
            {
                                 tips.SetToolTip(cb, toolTip);
            }

                                                                isAdjusting = true;
            Controls.Add(cb);

            if (resizeBar != null)
            {
                                 Controls.Add(resizeBar);
                ResizeBarsList.Add(resizeBar);
                resizeBar.TabStop = ResizeBarsTabStop;
                resizeBar.Visible = (ResizeBarsFadeProximity == 0 && open.HasValue && open.Value);
                resizeBar.Cursor = GrabCursor;
                resizeBar.GotFocus += delegate
                {
                    currentControl2 = c2;
                };
                resizeBar.LostFocus += delegate
                {
                    currentControl2 = null;
                                                                                                                                                  if (resizeBar == resizeBarHiding)
                    {
                        RestoreFocus(c);
                    }
                    else
                    {
                        if (ResizeBarsFadeProximity > 0)
                        {
                            Point pt = Cursor.Position;
                            Point pt2 = PointToClient(pt);                              FadeResizeBars(pt2, pt);
                        }
                    }
                };
            }
            Controls.Add(c2);
            if (resizeBar != null)
            {
                                                  int x = c2.TabIndex;
                c2.TabIndex = resizeBar.TabIndex;
                resizeBar.TabIndex = x;
            }
            isAdjusting = false;

            cb.MouseHover += delegate
            {
                bool stm = ShowToolMenu && (c2.fillWt > 0 || !ShowToolMenuRequiresPositiveFillWeight);
                if (stm && !toolBox.Visible && (cb.Checked || ShowToolMenuOnHoverWhenClosed))
                {
                    var p1 = cb.PointToClient(Control.MousePosition);
                                         int w = toolBox.GetPreferredSize(Size.Empty).Width + 1;
                    if (p1.X >= cb.Width - w)
                    {
                        Point p = new Point { X = cb.Width - w, Y = cb.Height };
                        toolBox.Current = c2;
                        toolBox.Show(cb, p);
                    }
                }
            };

            cb.MouseUp += (o, e) =>
            {
                bool stm = ShowToolMenu && (c2.fillWt > 0 || !ShowToolMenuRequiresPositiveFillWeight);
                if (stm && e.Button == MouseButtons.Right && ShowToolMenuOnRightClick)
                {
                    var p1 = cb.PointToClient(Control.MousePosition);
                    int w = toolBox.Width;
                    p1.X -= w / 2;
                    p1.Y -= w / 2;
                    toolBox.Current = c2;
                    toolBox.Show(cb, p1);
                }
            };

            cb.MouseLeave += delegate
            {
                if (toolBox.Visible)
                {
                                         if (!toolBox.Bounds.Contains(Control.MousePosition))
                        toolBox.Hide();
                }
            };

            Action<bool> layout = (ControlAdded) =>
            {
                bool b = cb.Checked;
                if (b)
                {
                    c2.lastClicked = DateTime.Now;
                    if (OpenOneOnly && lastChecked != null && c2 != lastChecked)
                    {
                        isAdjusting = true;
                        lastChecked.cb.Checked = false;
                        isAdjusting = false;
                    }
                    lastChecked = c2;
                }

                InternalPerformLayout();

                if (VerticalScroll.Visible)
                {
                    var r1 = new RECT();
                    var r2 = new RECT();
                    GetWindowRect(Handle, out r2);

                    if (cb.Checked)
                    {
                        GetWindowRect(c2.Handle, out r1);
                        if (r1.Bottom > r2.Bottom)
                        {
                            isOpening = true;
                            scrollToBottom = true;
                            ScrollControlIntoView(c2);
                            scrollToBottom = false;
                            ScrollControlIntoView(cb);
                            isOpening = false;
                        }
                    }
                    else
                    {
                                                                          GetWindowRect(cb.Handle, out r1);

                        if (r1.Bottom > r2.Bottom)
                        {
                            isOpening = true;
                            scrollToBottom = true;
                            ScrollControlIntoView(cb);
                            scrollToBottom = false;
                            isOpening = false;
                        }
                    }
                }
            };

            cb.CheckedChanged += delegate
            {
                bool b = cb.Checked;

                String downArrow = GetDownArrow();
                String upArrow = GetUpArrow();
                String text = cb.Text;
                isAnimating = true;
                if (b)
                {
                    if (text.StartsWith(downArrow))
                        text = text.Substring(downArrow.Length);
                    text = upArrow + text;
                }
                else
                {
                    if (text.StartsWith(upArrow))
                        text = text.Substring(upArrow.Length);
                    text = downArrow + text;
                                                                                   if (c2.ResizeBar != null)
                        c2.ResizeBar.FadeOut(0);

                                         if (FillResetOnCollapse)
                    {
                        c2.dh = 0;
                        c2.isLocked = false;
                    }
                }

                cb.Text = text;                  isAnimating = false;

                                                                   if (isAdjusting)
                {
                    c2.Visible = b;
                    return;
                }

                if (b && AnimateOpenEffect != AnimateWindowFlags.None && AnimateOpenMillis > 0)
                {
                    c2.lastClicked = DateTime.Now;
                    if (OpenOneOnly && lastChecked != null && c2 != lastChecked)
                    {
                        isAdjusting = true;
                        lastChecked.cb.Checked = false;
                        isAdjusting = false;
                    }
                    lastChecked = c2;

                                                              int max1 = (VerticalScroll.Visible ? VerticalScroll.Maximum : 0);

                                                                                                        SendMessage(this.Handle, WM_SETREDRAW, false, 0);
                                                                                                                                                                       isAnimating = true;
                    c2.c.Size = Size.Empty;
                    c2.Size = Size.Empty;
                    ignoreNCCALCSIZE = true;
                    c2.Visible = true;
                    ignoreNCCALCSIZE = false;
                    isAnimating = false;
                                                                                                                             ignoreNCPAINT = true;
                    var tma = InternalPerformLayout();

                                         isAnimating = true;

                                         int max2 = (VerticalScroll.Visible ? VerticalScroll.Maximum : 0);
                    bool holdSpace = (max2 > max1);
                    Padding mOrig = Padding.Empty;

                    if (holdSpace)
                    {
                                                                                                                                                                              RECT r1 = new RECT();
                        RECT r2 = new RECT();
                        GetWindowRect(c2.Handle, out r1);
                        GetWindowRect(Handle, out r2);

                                                 if (r1.Bottom > r2.Bottom)
                        {
                            mOrig = cb.Margin;
                            Padding m = mOrig;
                            m.Bottom += c2.Height + c2.Margin.Vertical;
                            cb.Margin = m;

                                                         isOpening = true;
                            scrollToBottom = true;
                            ScrollControlIntoView(c2);
                            scrollToBottom = false;
                            ScrollControlIntoView(cb);
                            isOpening = false;
                        }
                        else
                            holdSpace = false;
                    }

                                                                                                        c2.Visible = false;
                    ignoreNCPAINT = false;
                     
                                                                                                                             SendMessage(this.Handle, WM_SETREDRAW, true, 0);
                    tma.Refresh();                                                                                                                                                                                                          int x = Controls.IndexOf(c2);
                    AnimateWindow(c2, AnimateOpenMillis, AnimateOpenEffect);
                    Controls.SetChildIndex(c2, x);                      c2.Visible = true;                      if (holdSpace)
                        cb.Margin = mOrig;  
                    if (resizeBar != null && ResizeBarsFadeProximity == 0)
                        resizeBar.Visible = true;

                    isAnimating = false;
                }
                else if (!b && AnimateCloseEffect != AnimateWindowFlags.None && AnimateCloseMillis > 0)
                {
                    isAnimating = true;                                                                                                        AnimateWindow(c2, AnimateCloseMillis, AnimateCloseEffect);
                                                                                                        c2.c.Size = Size.Empty;
                    c2.Size = Size.Empty;
                    c2.Visible = false;
                    isAnimating = false;
                    InternalPerformLayout();                  }
                else
                {
                    isAnimating = true;
                    c2.Visible = b;
                    isAnimating = false;
                    layout(false);
                }

                if (b)
                {
                    c2.c.Focus();
                    if (!c2.c.CanSelect)
                        c.SelectNextControl(c, true, true, true, true);
                }
            };

            cb.VisibleChanged += delegate
            {
                bool b = cb.Visible && cb.Checked;
                if (c2.Visible != b)
                {
                    isAdjusting = true;
                    c2.Visible = b;
                    if (c2.ResizeBar != null && ResizeBarsFadeProximity == 0)
                    {
                        c2.ResizeBar.Visible = b;
                    }
                    isAdjusting = false;
                    InternalPerformLayout();
                }
            };

            layout(true);
            return cb;
        }

        protected override void WndProc(ref Message m)
        {
            if (ignoreNCCALCSIZE && m.Msg == WM_NCCALCSIZE || ignoreNCPAINT && (m.Msg == WM_NCPAINT || m.Msg == WM_ERASEBKGND))
            {
                return;
            }
            base.WndProc(ref m);
        }

        private Accordion InternalPerformLayout()
        {
                                                                PerformLayout();
            Control p = Parent;
            Accordion tma = this;
            while (p != null)
            {
                if (p is Accordion)
                {
                    p.PerformLayout();
                    tma = (Accordion)p;
                }
                p = p.Parent;
            }

            PerformLayout();
            tma.PerformLayout();
            return tma;
        }

                 public int Count
        {
            get
            {
                return Control2s.Count;
            }
        }

                 public CheckBox CheckBox(int i)
        {
            return Control2s[i].cb;
        }

                 public Control Content(int i)
        {
            return Control2s[i].c;
        }

                 public Control ResizeBar(int i)
        {
            return Control2s[i].ResizeBar;
        }

                 public IEnumerable<Control> ResizeBars
        {
            get
            {
                foreach (Control c in ResizeBarsList)
                    yield return c;
            }
        }

                                                     public CheckBox CheckBoxForControl(Control c)
        {
            c = c.Parent;
            while (c != null)
            {
                if (c is Control2 && c.Parent == this)
                    return ((Control2)c).cb;

                c = c.Parent;
            }
            return null;

                                                                                                                }

                                                                                          
        private static Padding Get(params Padding?[] arr)
        {
            foreach (Padding? p in arr)
                if (p.HasValue)
                    return p.Value;
            return Padding.Empty;
        }

        private String GetDownArrow()
        {
            return (this.DownArrow == null ? GlobalDownArrow : this.DownArrow);
        }

        private String GetUpArrow()
        {
            return (this.UpArrow == null ? GlobalUpArrow : this.UpArrow);
        }

                 public void Close(params Control[] controls)
        {
            Open(controls, false);
        }

                 public void Open(params Control[] controls)
        {
            Open(controls, true);
        }

        private void Open(Control[] controls, bool open)
        {
            isAdjusting = true;
            bool changed = false;
            Control2 last = null;
            foreach (Control2 c2 in Control2s)
            {
                Control2 c = null;
                if (controls == null)
                    c = c2;
                else
                {
                    foreach (Control cc in controls)
                    {
                        if (cc == c2.c)
                        {
                            c = c2;
                            break;
                        }
                    }
                }
                if (c != null)
                {
                    last = c;
                    if (c.cb.Checked != open)
                    {
                        changed = true;
                        c.cb.Checked = open;
                    }
                }
            }
            isAdjusting = false;

            if (changed)
            {
                                 InternalPerformLayout();
            }
        }

        private static AnchorStyles Map(DockStyle d)
        {
            if (d == DockStyle.Bottom)
                return AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            if (d == DockStyle.Fill)
                return AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            if (d == DockStyle.Left)
                return AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            if (d == DockStyle.Right)
                return AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            if (d == DockStyle.Top)
                return AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            return AnchorStyles.None;
        }


                 public bool PreFilterMessage(ref Message m)
        {
            if (!Enabled)
                return false;

            if (m.Msg == WM_KEYDOWN)
            {
                int key = m.WParam.ToInt32();
                if (ResizeBarsArrowKeyDelta != 0 && (key == VK_UP || key == VK_DOWN) && currentControl2 != null)
                {
                    var c2 = currentControl2;
                    int newDh = c2.dh;
                    if (key == VK_UP)
                        newDh = Math.Max(c2.dh - ResizeBarsArrowKeyDelta, c2.MinDH);
                    else if (key == VK_DOWN)
                        newDh = Math.Min(c2.dh + ResizeBarsArrowKeyDelta, c2.MaxDH);

                    if (c2.dh != newDh)
                    {
                        c2.isLocked = true;
                        c2.dh = newDh;
                        isOpening = ResizeBarsStayInViewOnArrowKey;
                        isDragging = true;                          InternalPerformLayout();
                        isDragging = false;
                        isOpening = false;
                    }
                    return true;
                }
            }
            else if (m.Msg == WM_MOUSEMOVE)
            {
                                                                   Point pt = Cursor.Position;

                if (isDragging)
                {
                    if (oldPoint == pt || !AllowMouseResize)
                    {
                                                 return false;
                    }
                    int newdh = originalDH + (pt.Y - grabPoint.Y);
                    int minDH = grabControl.MinDH;
                    if (newdh < minDH)
                        newdh = minDH;

                    int maxDH = grabControl.MaxDH;
                    if (newdh > maxDH)
                        newdh = maxDH;

                    if (newdh == grabControl.dh)
                        return false;

                    wasDragged = true;
                    grabControl.dh = newdh;
                    resetLocked = false;
                    PerformLayout();
                    oldPoint = pt;
                    return false;
                }
                else if (ResizeBarsFadeProximity > 0)
                {
                                         Point pt2 = PointToClient(pt);                      FadeResizeBars(pt2, pt);
                }

                                 var bounds = new Rectangle(PointToScreen(Point.Empty), Size);

                if (!bounds.Contains(pt))
                    return false;

                Control2 c2 = FindControl2(pt);

                if (c2 != null)
                {
                    Cursor = GrabCursor;
                }
                else
                {
                                                                                   if (Cursor == GrabCursor)
                        Cursor = DefaultCursor;
                }
            }
            else if (m.Msg == WM_LBUTTONDOWN)
            {
                wasDragged = false;
                Point pt = Cursor.Position;
                Control2 c2 = FindControl2(pt);

                if (c2 != null)
                {
                    var c3 = ControlAtPoint(pt);
                    if (c3 is ScrollBar)
                    {
                                                                                                                            c3.BeginInvoke((Action)delegate
                        {
                            ReleaseCapture();
                        });
                    }

                                         hwndPreviousFocus = GetFocus();
                    var h = hwndPreviousFocus;
                    while (h != IntPtr.Zero)
                    {
                        h = GetParent(h);
                        if (h == c2.Handle)
                            break;
                    }
                    if (h == IntPtr.Zero)
                        hwndPreviousFocus = h;

                    if (c2.ResizeBar != null)
                        c2.ResizeBar.Focus();

                    grabControl = c2;
                    origLocked = c2.isLocked;
                    c2.isLocked = true;
                    isDragging = true;
                    resetLocked = true;
                    originalDH = c2.dh;
                    grabPoint = pt;
                                                                                                    }
                else
                {
                    isDragging = false;
                }
            }
            else if (m.Msg == WM_LBUTTONUP)
            {
                Control2 c2 = grabControl;
                grabControl = null;
                isDragging = false;  
                if (c2 != null)
                {
                    if (resetLocked)
                        c2.isLocked = origLocked;

                    if (c2.ResizeBar != null && c2.ResizeBar.Visible)
                    {
                        if (wasDragged)
                        {
                            if (!ResizeBarsKeepFocusAfterMouseDrag)
                                RestoreFocus(c2.c);
                        }
                        else
                        {
                                                         if (!ResizeBarsKeepFocusOnClick)
                                RestoreFocus(c2.c);
                        }
                    }
                }
            }
            return false;
        }

                 private Control2 FindControl2(Point pt)
        {
                                                   var th = GetTopMostHandle(this.Handle);              var fg = GetForegroundWindow();

                                                   if (fg != th || !IsMouseOverThisControl(pt))
                return null;

            int gw = GrabWidth;
            Control2 c = null;

            foreach (Control2 c2 in Control2s)
            {
                if (!c2.Visible)
                    continue;

                                                   
                int y = 0;
                int dy = 0;
                bool canGrab = false;
                if (c2.ResizeBar != null)
                {
                    if (c2.ResizeBar.Visible)
                    {
                        canGrab = true;
                        var b3 = new Rectangle(c2.ResizeBar.PointToScreen(Point.Empty), c2.ResizeBar.Size);
                                                 if (b3.Contains(pt))
                        {
                            dy = 1;
                                                     }
                    }
                }
                else
                {
                    var b2 = new Rectangle(c2.PointToScreen(Point.Empty), c2.Size);
                    y = b2.Y + b2.Height;
                    dy = y - pt.Y;
                                         canGrab = !GrabRequiresPositiveFillWeight || GrabRequiresPositiveFillWeight && c2.fillWt > 0;
                }

                if (dy > 0 && dy <= gw && canGrab)
                {
                    c = c2;
                    break;
                }
            }
            return c;
        }

        private void RestoreFocus(Control c)
        {
                                       
            if (hwndPreviousFocus != IntPtr.Zero)
            {
                if (!ResizeBarsKeepFocusIfControlOutOfView)
                    SetFocus(hwndPreviousFocus);
                else
                {
                    Rectangle accBounds = new Rectangle(PointToScreen(Point.Empty), Size);
                    RECT r = new RECT();
                    GetWindowRect(hwndPreviousFocus, out r);
                    if (IsOverlapping(accBounds, r))
                        SetFocus(hwndPreviousFocus);
                }
            }
            else
            {
                if (!ResizeBarsKeepFocusIfControlOutOfView)
                {
                    c.Focus();
                    if (!c.CanSelect)
                        c.SelectNextControl(c, true, true, true, true);
                }
                else
                {
                    Rectangle accBounds = new Rectangle(PointToScreen(Point.Empty), Size);
                                                              if (!c.CanSelect)
                        c = c.GetNextControl(c, true);

                    if (c != null)
                    {
                        RECT r = new RECT();
                        GetWindowRect(c.Handle, out r);
                        if (IsOverlapping(accBounds, r))
                            c.Focus();
                    }
                }
            }
        }

        private static bool IsOverlapping(Rectangle r0, RECT r)
        {
            return (r.Top >= r0.Top && r.Top <= r0.Bottom ||
                    r.Bottom >= r0.Top && r.Bottom <= r0.Bottom ||
                    r.Top <= r0.Top && r.Bottom >= r0.Bottom);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (ResizeBarsFadeProximity > 0)
            {
                Point pt = Cursor.Position;
                Rectangle r = new Rectangle(PointToScreen(Point.Empty), Size);
                if (!r.Contains(pt))
                {
                    if (ResizeBarsFadeProximity > 0)
                    {
                        resizeBarHiding = null;
                        foreach (Control rb in ResizeBarsList)
                        {
                            if (rb.Focused)
                            {
                                if (ResizeBarsStayVisibleIfFocused)
                                    continue;
                                else
                                    resizeBarHiding = rb;
                            }

                            rb.FadeOut(ResizeBarsFadeOutMillis);
                        }
                    }
                }
            }
        }

        private void FadeResizeBars(Point pt, Point absPt)
        {
            bool isOverCheckBox = false;
            IntPtr hWnd = WindowFromPoint(absPt);
            foreach (Control2 c2 in Control2s)
            {
                var cb = c2.cb;
                if (cb.Visible)
                {
                    if (hWnd == cb.Handle)
                    {
                        isOverCheckBox = true;
                        break;
                    }
                }
            }

            resizeBarHiding = null;
            foreach (Control c in Controls)
            {
                if (!(c is Control2))
                    continue;

                Control2 c2 = (Control2)c;
                if (!c2.cb.Checked || c2.ResizeBar == null)
                    continue;

                var rb = c2.ResizeBar;
                var r = rb.Bounds;
                int distance = Distance(r, pt);
                bool isNear = (distance <= ResizeBarsFadeProximity);

                                 if (isNear && !isOverCheckBox)
                {
                                                              rb.FadeIn(ResizeBarsFadeInMillis);
                }
                else
                {
                                                              bool b = rb.Focused;
                    if (!b || b && !ResizeBarsStayVisibleIfFocused)
                    {
                        if (b)
                            resizeBarHiding = rb;

                        rb.FadeOut(ResizeBarsFadeOutMillis);
                    }
                }
            }
        }

        private static int Distance(Rectangle r, Point p)
        {
            var dx = Math.Max(r.X - p.X, p.X - (r.X + r.Width));
            if (dx < 0)
                dx = 0;
            var dy = Math.Max(r.Y - p.Y, p.Y - (r.Y + r.Height));
            if (dy < 0)
                dy = 0;
            return (int)Math.Sqrt(dx * dx + dy * dy);
        }

        private class Control2 : UserControl
        {
            internal Control c;
            internal CheckBox cb;
            internal double fillWt = 0;
            internal int dh = 0;
            internal DateTime lastClicked = DateTime.MinValue;
            internal bool isLocked = false;
                         internal LayoutArgs layoutArgs;
            internal Control ResizeBar { get; set; }
            internal bool ResizeBarIsPartiallyVisible = false;
            internal Padding resizeBarMargin = Padding.Empty;

            public Control2(CheckBox cb, Control c, Control resizeBar, double fillWt, LayoutArgs layoutArgs)
            {
                this.cb = cb;
                this.c = c;
                this.fillWt = fillWt;
                this.layoutArgs = layoutArgs;
                Visible = cb.Checked;
                Controls.Add(c);
                ResizeBar = resizeBar;
                                 AutoSize = true;
                Margin = Padding.Empty;
                                                  AutoSizeMode = AutoSizeMode.GrowAndShrink;
                BorderStyle = BorderStyle.None;
                                 if (resizeBar != null)
                {
                                                                                   resizeBarMargin = resizeBar.Margin;
                    resizeBar.Margin = Padding.Empty;
                    bool flag = false;
                    resizeBar.MarginChanged += delegate
                    {
                        if (flag)
                            return;
                        resizeBarMargin = resizeBar.Margin;
                        flag = true;
                        resizeBar.Margin = Padding.Empty;
                        flag = false;
                    };
                }
            }

            public override Size MinimumSize
            {
                get
                {
                    Size s = c.MinimumSize;
                    Padding p = this.Padding;
                    Padding m = c.Margin;
                    s.Width += p.Horizontal + m.Horizontal;
                    s.Height += p.Vertical + m.Vertical;
                    return s;
                }
                set
                {
                    base.MinimumSize = value;
                }
            }

                         public int MinDH
            {
                get
                {
                    Accordion a = (Accordion)Parent;
                    if (a.ControlMinimumHeightIsItsPreferredHeight)
                        return 0;

                    Size min = c.MinimumSize;
                    Size ps = c.PreferredSize;
                    return Math.Min(min.Height - ps.Height, 0);
                }
            }

                         public int MaxDH
            {
                get
                {
                    Size max = c.MaximumSize;
                    if (max.Height == 0)
                        return int.MaxValue;

                    Size ps = c.PreferredSize;
                    int maxDH = max.Height - ps.Height;
                    return Math.Max(maxDH, 0);
                }
            }

            public override Size MaximumSize
            {
                get
                {
                    Size s = c.MaximumSize;
                    Padding p = this.Padding;
                    Padding m = c.Margin;
                    if (s.Height > 0)
                        s.Height += (p.Vertical + m.Vertical);

                    if (s.Width > 0)
                        s.Width += (p.Horizontal + m.Horizontal);

                    return s;
                }
                set
                {
                    base.MaximumSize = value;
                }
            }

            public override Size GetPreferredSize(Size proposedSize)
            {
                Size s = GetPreferredSize(proposedSize, true, true);
                return s;
            }

            internal Size GetPackSize()
            {
                return GetPreferredSize(Size.Empty, false, false);
            }

            internal Size GetPreferredSize(Size proposedSize, bool addDH, bool returnEmptyIfClosed)
            {
                if (returnEmptyIfClosed && !cb.Checked)
                    return Size.Empty;

                                                                   Size s = c.GetPreferredSize(proposedSize);
                Padding p = this.Padding;
                Padding m = c.Margin;
                s.Width += p.Horizontal + m.Horizontal;
                s.Height += p.Vertical + m.Vertical;

                if (addDH)
                    s.Height += dh;

                return s;
            }
        }

        internal bool IsResizeBar(Control c)
        {
            if (c == null)
                return false;
            return ResizeBarsList.Contains(c);
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            bool includeInvisible = !this.Visible;
            return layoutEngine.GetPreferredSize(this, true, true, includeInvisible);
        }

        public override LayoutEngine LayoutEngine
        {
            get
            {
                return layoutEngine;
            }
        }

                 protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (VerticalScroll.Visible)
                UpdateResizeBarsPartiallyVisibleFlag();
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);

            if (se.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                UpdateResizeBarsPartiallyVisibleFlag();
            }
        }

        private void UpdateResizeBarsPartiallyVisibleFlag()
        {
                                                   var s = ClientSize;              Point ptTopLeft = PointToScreen(Point.Empty);
            Point ptBottomRight = PointToScreen(new Point(s.Width, s.Height));

            bool needsRefresh = false;
            foreach (Control c in Controls)
            {
                if (!c.Visible || !(c is Control2))
                    continue;

                Control2 c2 = (Control2)c;
                if (c2.ResizeBar == null)
                    continue;

                var r2 = c2.ResizeBar.Bounds;
                Point ptTopLeft2 = PointToScreen(r2.Location);
                Point ptBottomRight2 = PointToScreen(new Point(r2.X + r2.Width, r2.Y + r2.Height));

                bool isPartiallyVisible = ptTopLeft2.Y < ptTopLeft.Y || ptBottomRight2.Y > ptBottomRight.Y;
                c2.ResizeBarIsPartiallyVisible = isPartiallyVisible;

                if (ResizeBarsFadeProximity == 0)
                {
                    bool show = ShowPartiallyVisibleResizeBars || !isPartiallyVisible || c2.ResizeBar.Focused && ResizeBarsStayVisibleIfFocused;
                    if (c2.ResizeBar.Visible != show)
                    {
                        needsRefresh = true;
                        c2.ResizeBar.Visible = show;
                    }
                }
            }

            if (needsRefresh)
                Refresh();
        }

        internal class AccordionLayoutEngine : LayoutEngine
        {

                         int maxPreferredWidth = 0;
            int maxPreferredHeight = 0;

            public override bool Layout(Object container, LayoutEventArgs layoutEventArgs)
            {
                Accordion acc = (Accordion)container;
                if (acc.isAdjusting)
                    return false;

                if (acc.isAnimating || acc.IsResizeBar(layoutEventArgs.AffectedControl))
                    return false;

                Size clientSize = acc.ClientSize;                  Size avail = clientSize;

                Size prefNoDH = GetPreferredSize(acc, false, true, false);                  UpdateDeltaHeights(acc, avail.Height, prefNoDH.Height);

                Size pref = GetPreferredSize(acc, true, true, false);                  if (acc.FillWidth)
                {
                    if (avail.Width >= pref.Width) { }                      else
                    {
                                                                          if (!acc.GrowAndShrink || acc.ControlMinimumWidthIsItsPreferredWidth)
                            avail.Width = pref.Width;
                    }
                }
                else
                {
                    if (acc.GrowAndShrink)
                    {
                        maxPreferredWidth = 0;
                        avail.Width = pref.Width;
                    }
                    else
                    {
                        if (pref.Width > maxPreferredWidth)
                            maxPreferredWidth = pref.Width;
                        avail.Width = maxPreferredWidth;
                    }
                }

                if (!acc.FillHeight)
                {
                    if (acc.GrowAndShrink)
                    {
                        maxPreferredHeight = 0;
                        if (avail.Height > prefNoDH.Height)
                        {
                            avail.Height = prefNoDH.Height;
                            UpdateDeltaHeights(acc, avail.Height, prefNoDH.Height);
                        }
                    }
                    else
                    {
                        if (prefNoDH.Height > maxPreferredHeight)
                            maxPreferredHeight = prefNoDH.Height;

                        avail.Height = maxPreferredHeight;
                        UpdateDeltaHeights(acc, avail.Height, prefNoDH.Height);
                    }
                }

                Padding p = acc.Padding;
                avail.Height -= p.Vertical;
                avail.Width -= p.Horizontal;

                bool vScrollBarVisible = acc.VerticalScroll.Visible;
                bool hScrollBarVisible = acc.HorizontalScroll.Visible;
                int offsetX = 0;
                int offsetY = 0;
                if (hScrollBarVisible)
                    offsetX = -acc.HorizontalScroll.Value;

                if (vScrollBarVisible)
                    offsetY = -acc.VerticalScroll.Value;

                                 Size calcSize = LayoutInternal(false, acc, offsetX, offsetY, avail, p, false, clientSize, true, true, false);

                                                                                                                      int dww = 0;
                if (calcSize.Height > clientSize.Height)
                {
                    if (!vScrollBarVisible && acc.AutoScroll)
                    {
                        int dw = SystemInformation.VerticalScrollBarWidth;
                        avail.Width -= dw;

                                                                                                   Size calcSize2 = LayoutInternal(false, acc, offsetX, offsetY, avail, p, false, clientSize, true, true, false);
                        calcSize = calcSize2;
                        dww = dw;
                    }
                }

                if (calcSize.Width > clientSize.Width - dww)
                {
                    if (!hScrollBarVisible && acc.AutoScroll)
                    {
                        int dh = SystemInformation.HorizontalScrollBarHeight;
                        avail.Height -= dh;
                                                                          UpdateDeltaHeights(acc, avail.Height + p.Vertical, prefNoDH.Height);
                    }
                }

                LayoutInternal(true, acc, offsetX, offsetY, avail, p, false, clientSize, true, true, false);

                return false;
            }

                         private Size LayoutInternal(bool doLayout, Accordion acc, int offsetX, int offsetY, Size avail, Padding p, bool calcPreferredSize, Size clientSize, bool addDH, bool returnEmptyIfClosed, bool includeInvisible)
            {
                Control lastResizeBar = null;
                Point ptTopLeft = Point.Empty;
                Point ptBottomRight = Point.Empty;
                if (doLayout)
                {
                    ptTopLeft = acc.PointToScreen(Point.Empty);
                    ptBottomRight = acc.PointToScreen(new Point(clientSize.Width, clientSize.Height));
                    foreach (Control2 c2 in acc.Control2s)
                    {
                        if (c2.Visible)
                            lastResizeBar = c2.ResizeBar;
                        else if (c2.cb.Visible)
                            lastResizeBar = null;
                    }
                }

                Size s = Size.Empty;
                bool isRightToLeft = (acc.RightToLeft == RightToLeft.Yes);
                int px = p.Left;
                int py = p.Top;

                ControlCollection controls = acc.Controls;
                int n = controls.Count;

                for (int i = 0; i < n; i++)
                {
                    Control c = controls[i];
                    if (acc.IsResizeBar(c))                          continue;

                    Size ps = Size.Empty;
                    if (c is Control2)
                    {
                        Control2 c2 = (Control2)c;
                        if (includeInvisible || c2.cb.Visible)
                        {
                            if (returnEmptyIfClosed && !c2.cb.Checked)
                                continue;

                            ps = c2.GetPreferredSize(Size.Empty, addDH, returnEmptyIfClosed);
                        }
                        else
                        {
                                                         continue;
                        }
                    }
                    else
                    {
                        if (includeInvisible || c.Visible)
                            ps = c.GetPreferredSize(Size.Empty);
                        else
                        {
                                                         continue;
                        }
                    }

                    Padding cm = c.Margin;
                    int x = px + cm.Left + offsetX;
                    int y = py + cm.Top + offsetY;
                    int w = 0;
                    int h = 0;

                    bool isMin = false;

                    if (calcPreferredSize)
                    {
                        w = ps.Width;
                        h = ps.Height;
                    }
                    else
                    {
                        int minH = ps.Height;
                        int minW = ps.Width;
                        bool isMin2 = false;
                        if (!acc.ControlMinimumHeightIsItsPreferredHeight || !acc.ControlMinimumWidthIsItsPreferredWidth)
                        {
                            Size min = c.MinimumSize;
                            if (!acc.ControlMinimumHeightIsItsPreferredHeight)
                                minH = min.Height;
                            if (!acc.ControlMinimumWidthIsItsPreferredWidth)
                            {
                                minW = min.Width;
                                isMin2 = true;
                            }
                        }

                        Size max = c.MaximumSize;
                        w = avail.Width - (cm.Horizontal);
                        h = ps.Height;

                        if (w < minW)
                        {
                            w = minW;
                            isMin = isMin2;
                        }
                        if (h < minH)
                            h = minH;

                        if (max.Height > 0 && h > max.Height)
                            h = max.Height;

                        if (max.Width > 0 && w > max.Width)
                            w = max.Width;
                    }

                    py += (h + cm.Vertical);

                    int right = px + offsetX + cm.Horizontal + w;
                    if (right > s.Width)
                        s.Width = right;

                    if (doLayout)
                    {
                        if (!c.Visible)
                        {
                            continue;
                        }

                        c.SetBounds(x, y, w, h);

                        if (c is Control2)
                        {
                            Control2 c2 = (Control2)c;
                            Control d = c2.c;

                            if (c2.ResizeBar != null)
                            {
                                var rb = c2.ResizeBar;
                                Padding rm = c2.resizeBarMargin;
                                int rx = 0;
                                int rw = (int)((avail.Width - rm.Horizontal) * acc.ResizeBarsFill);
                                if (isMin && rw < w)
                                {
                                                                                                              rw = w;
                                    rx = x;
                                }
                                else
                                {
                                    if (rw < acc.ResizeBarsMinimumLength)
                                    {
                                                                                 rw = Math.Min(acc.ResizeBarsMinimumLength, avail.Width);
                                    }

                                    var cbBounds = c2.cb.Bounds;
                                    int r1 = x + w;
                                    int r2 = cbBounds.Right;
                                    int maxR = Math.Max(r1, r2);
                                    int align = Math.Max(0, (int)((avail.Width - (rm.Horizontal + rw)) * acc.ResizeBarsAlign));

                                    rx = (px + rm.Left + offsetX + align);
                                    if (rx + rw > maxR - rm.Left)
                                        rx = x + Math.Max(0, (maxR - (x + rw)) / 2);
                                }

                                int rh = rb.Height;
                                int ry = (y + h) - (rh / 2) + rm.Top;

                                if (c2.ResizeBar == lastResizeBar)
                                {
                                                                                                              if (ry + rh > y + h + cm.Bottom)
                                        ry = y + h + cm.Bottom - rh;
                                }

                                Point ptTopLeft2 = acc.PointToScreen(new Point(rx, ry));
                                Point ptBottomRight2 = acc.PointToScreen(new Point(rx + rw, ry + rh));

                                bool isPartiallyVisible = ptTopLeft2.Y < ptTopLeft.Y || ptBottomRight2.Y > ptBottomRight.Y;
                                c2.ResizeBarIsPartiallyVisible = isPartiallyVisible;

                                if (acc.ResizeBarsFadeProximity == 0)
                                {
                                                                                                              bool b = acc.ShowPartiallyVisibleResizeBars || !isPartiallyVisible || (rb.Focused && (acc.ResizeBarsStayVisibleIfFocused || acc.isDragging));
                                    rb.Visible = b;                                  }

                                rb.SetBounds(rx, ry, rw, rh);
                            }

                            if (d.Dock == DockStyle.None)
                            {
                                double alignX = 0;
                                double alignY = 0;
                                double fillX = 0;
                                double fillY = 0;
                                if (d.Anchor == AnchorStyles.None)
                                {
                                    if (c2.layoutArgs != null)
                                    {
                                        var la = c2.layoutArgs;
                                        alignX = la.AlignX;
                                        alignY = la.AlignY;
                                        fillX = la.FillX;
                                        fillY = la.FillY;
                                    }
                                }
                                else
                                {
                                    var a = d.Anchor;
                                    if (a == AnchorStyles.Bottom)
                                    {
                                        alignX = 0.5;
                                        alignY = 1.0;
                                    }
                                    else if (a == AnchorStyles.Top)
                                    {
                                        alignX = 0.5;
                                        alignY = 0.0;
                                    }
                                    else if (a == AnchorStyles.Left)
                                    {
                                        alignX = 0.0;
                                        alignY = 0.5;
                                    }
                                    else if (a == AnchorStyles.Right)
                                    {
                                        alignX = 1.0;
                                        alignY = 0.5;
                                    }
                                    else if (a == (AnchorStyles.Left | AnchorStyles.Right))
                                    {
                                        alignX = 0.0;
                                        alignY = 0.5;
                                        fillX = 1.0;
                                    }
                                    else if (a == (AnchorStyles.Left | AnchorStyles.Top))
                                    {
                                        alignX = 0.0;
                                        alignY = 0.0;
                                    }
                                    else if (a == (AnchorStyles.Left | AnchorStyles.Bottom))
                                    {
                                        alignX = 0.0;
                                        alignY = 1.0;
                                    }
                                    else if (a == (AnchorStyles.Right | AnchorStyles.Top))
                                    {
                                        alignX = 1.0;
                                        alignY = 0.0;
                                    }
                                    else if (a == (AnchorStyles.Right | AnchorStyles.Bottom))
                                    {
                                        alignX = 1.0;
                                        alignY = 1.0;
                                    }
                                    else if (a == (AnchorStyles.Top | AnchorStyles.Bottom))
                                    {
                                        alignX = 0.5;
                                        alignY = 0.0;
                                        fillY = 1.0;
                                    }
                                    else
                                    {
                                        alignX = 0;
                                        alignY = 0;
                                        fillX = 1;
                                        fillY = 1;
                                    }
                                }

                                if (isRightToLeft)
                                    alignX = 1.0 - alignX;

                                Padding c2p = c2.Padding;
                                Padding dm = d.Margin;

                                int availH1 = Math.Max(0, h - (dm.Vertical + c2p.Vertical));
                                int availW1 = Math.Max(0, w - (dm.Horizontal + c2p.Horizontal));

                                                                 Size ds = d.PreferredSize;
                                ds.Height = Math.Min(availH1, ds.Height);
                                ds.Width = Math.Min(availW1, ds.Width);

                                int extraW1 = Math.Max(0, availW1 - ds.Width);
                                int extraH1 = Math.Max(0, availH1 - ds.Height);

                                int w1 = ds.Width + (int)(fillX * extraW1);
                                int h1 = ds.Height + (int)(fillY * extraH1);
                                Size dMax = d.MaximumSize;
                                if (dMax.Width > 0 && w1 > dMax.Width)
                                    w1 = dMax.Width;
                                if (dMax.Height > 0 && h1 > dMax.Height)
                                    h1 = dMax.Height;

                                int freeh = (w - (w1 + dm.Horizontal + c2p.Horizontal));
                                int freev = (h - (h1 + dm.Vertical + c2p.Vertical));

                                int x1 = dm.Left + c2p.Left + (int)(alignX * freeh);
                                int y1 = dm.Top + c2p.Top + (int)(alignY * freev);

                                d.SetBounds(x1, y1, w1, h1);
                            }
                        }
                    }
                }

                s.Height = py;

                                                                   if (calcPreferredSize)
                {
                    s.Width += p.Right;
                    s.Height += p.Bottom;
                }

                return s;
            }

            public Size GetPreferredSize(Accordion a, bool addDH, bool returnEmptyIfClosed, bool includeInvisible)
            {
                Size s = LayoutInternal(false, a, 0, 0, Size.Empty, a.Padding, true, Size.Empty, addDH, returnEmptyIfClosed, includeInvisible);
                return s;
            }

            private void UpdateDeltaHeights(Accordion acc, int clientSizeHeight, int prefHeightNoDH)
            {
                bool fillLastOpened = acc.FillLastOpened;
                bool fillModeGrowOnly = acc.FillModeGrowOnly;

                double totalWt = 0;
                int mh = 0;                  Control2 fillControl = null;
                foreach (Control2 c2 in acc.Control2s)
                {
                    if (c2.cb.Checked)
                    {
                        if (c2.isLocked)
                        {
                                                                                      mh += c2.dh;
                        }
                        else
                        {
                                                         if (!acc.FillModeGrowOnly)
                                c2.dh = 0;

                            totalWt += c2.fillWt;

                            if (c2.fillWt > 0 && (fillControl == null || c2.lastClicked > fillControl.lastClicked))
                                fillControl = c2;
                        }
                    }
                }

                int eh = (clientSizeHeight - prefHeightNoDH) - mh;

                if (fillLastOpened)
                {
                    if (fillControl != null)
                    {
                        if (eh > 0)
                            eh = Math.Min(eh, fillControl.MaxDH);
                        else
                            eh = Math.Max(eh, fillControl.MinDH);

                        if (fillModeGrowOnly)
                        {
                            if (eh > fillControl.dh)
                                fillControl.dh = eh;
                        }
                        else
                        {
                            fillControl.dh = eh;
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    if (eh < 0 && totalWt > 0)
                    {
                                                                                                                            bool[] isLocked = new bool[acc.Control2s.Count];
                        int[] minDHs = new int[acc.Control2s.Count];
                        int mh2 = 0;
                        bool first = true;
                        do
                        {
                            mh2 = 0;
                            double pixels2 = 0;
                            for (int i = 0; i < acc.Control2s.Count; i++)
                            {
                                Control2 c2 = acc.Control2s[i];
                                if (c2.isLocked)
                                    isLocked[i] = true;

                                if (c2.cb.Checked && c2.fillWt > 0 && !isLocked[i])
                                {
                                    int minDH = 0;
                                    if (first)
                                    {
                                                                                                                          c2.dh = 0;
                                        minDH = c2.MinDH;
                                        minDHs[i] = minDH;                                      }
                                    else
                                    {
                                        minDH = minDHs[i];
                                    }

                                    double ddh = c2.fillWt * eh / totalWt;
                                    int dh = (int)ddh;

                                    pixels2 += ddh % 1;                                      if (pixels2 <= -0.5)
                                    {
                                        dh--;
                                        pixels2++;
                                    }

                                    int dhOrig = c2.dh;
                                    c2.dh = c2.dh + dh;
                                    if (c2.dh <= minDH)
                                    {
                                        c2.dh = minDH;
                                        isLocked[i] = true;
                                    }
                                    int shedded = c2.dh - dhOrig;
                                    mh2 += shedded;
                                }
                            }
                            eh = eh - mh2;
                            first = false;
                        } while (mh2 < 0 && eh < 0);
                    }
                    else if (eh > 0 && totalWt > 0)
                    {
                                                                                                                                                                                                       bool[] isLocked = new bool[acc.Control2s.Count];
                        int[] maxDHs = new int[acc.Control2s.Count];
                        int mh2 = 0;
                        bool first = true;
                        do
                        {
                            mh2 = 0;
                            double pixels2 = 0;
                            double totalWt2 = 0;
                            for (int i = 0; i < acc.Control2s.Count; i++)
                            {
                                Control2 c2 = acc.Control2s[i];
                                if (c2.isLocked)
                                    isLocked[i] = true;

                                if (c2.cb.Checked && c2.fillWt > 0 && !isLocked[i])
                                {
                                    double ddh = c2.fillWt * eh / totalWt;
                                    int dh = (int)ddh;

                                    pixels2 += ddh % 1;
                                    if (pixels2 >= 0.5)
                                    {
                                        dh++;
                                        pixels2--;
                                    }

                                    int maxDH = 0;
                                    if (first)
                                    {
                                                                                 maxDH = c2.MaxDH;
                                        maxDHs[i] = maxDH;

                                    }
                                    else
                                    {
                                        maxDH = maxDHs[i];
                                    }

                                    if (dh >= maxDH)
                                    {
                                        isLocked[i] = true;
                                        c2.dh = maxDH;
                                        mh2 += maxDH;
                                    }
                                    else
                                    {
                                        totalWt2 += c2.fillWt;
                                    }
                                }
                            }
                            totalWt = totalWt2;
                            eh = eh - mh2;
                            first = false;
                        } while (mh2 > 0 && eh > 0);

                        if (totalWt > 0)
                        {
                                                          
                            double pixels = 0;                              for (int i = 0; i < acc.Control2s.Count; i++)
                            {
                                if (isLocked[i])                                      continue;

                                Control2 c2 = acc.Control2s[i];
                                if (!c2.cb.Checked || c2.fillWt <= 0)
                                    continue;

                                double ddh = c2.fillWt * eh / totalWt;
                                int dh = (int)ddh;

                                pixels += ddh % 1;
                                if (pixels >= 0.5)
                                {
                                    dh++;
                                    pixels--;
                                }

                                if (fillModeGrowOnly)
                                {
                                    if (dh > c2.dh)
                                        c2.dh = dh;
                                    else { }                                  }
                                else
                                    c2.dh = dh;
                            }
                        }
                    }
                }
            }
        }

        private class ToolBox : ToolStripDropDown
        {
            ToolStripSplitButton miPack = new ToolStripSplitButton("\u2191") { ToolTipText = "Pack", Anchor = AnchorStyles.Left | AnchorStyles.Right };              ToolStripButton miPackAll = new ToolStripButton("\u21c8") { ToolTipText = "Pack All" };              ToolStripButton miCloseAll = new ToolStripButton("\u23EB") { ToolTipText = "Close All" };  
            ToolStripSplitButton miFill = new ToolStripSplitButton("\u2193") { ToolTipText = "Fill", Anchor = AnchorStyles.Left | AnchorStyles.Right };              ToolStripButton miFillAll = new ToolStripButton("\u21ca") { ToolTipText = "Fill All" };              ToolStripButton miOpenAll = new ToolStripButton("\u23EC") { ToolTipText = "Open All" };  
            ToolStripSplitButton miLock = new ToolStripSplitButton("\uD83D\uDD12") { ToolTipText = "", Anchor = AnchorStyles.Left | AnchorStyles.Right };              ToolStripButton miLockAll = new ToolStripButton("\uD83D\uDD10") { ToolTipText = "Lock All" };              ToolStripButton miUnlockAll = new ToolStripButton("\uD83D\uDD11") { ToolTipText = "Unlock All" };  
            Control2 _c2 = null;

            public ToolBox()
            {

                var menu = this;
                menu.Padding = Padding = new Padding(3, 2, 3, 1);
                                 menu.DropShadowEnabled = false;
                menu.Items.Add(miPack);
                menu.Items.Add(miFill);
                menu.Items.Add(miLock);
                menu.BackColor = Color.Transparent;
                 
                miPack.DropDown = new ToolStripDropDown();
                miPack.DropDown.Padding = new Padding(3, 2, 1, 1);
                                                  miPack.DropDown.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                miPack.DropDown.DropShadowEnabled = false;
                miPack.DropDown.Items.Add(miPackAll);
                miPack.DropDown.Items.Add(miCloseAll);

                miFill.DropDown = new ToolStripDropDown();
                miFill.DropDown.Padding = new Padding(3, 2, 1, 1);
                miFill.DropDown.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                miFill.DropDown.DropShadowEnabled = false;
                miFill.DropDown.Items.Add(miFillAll);
                miFill.DropDown.Items.Add(miOpenAll);

                miLock.DropDown = new ToolStripDropDown();
                miLock.DropDown.Padding = new Padding(3, 2, 1, 1);
                miLock.DropDown.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                miLock.DropDown.DropShadowEnabled = false;
                miLock.DropDown.Items.Add(miLockAll);
                miLock.DropDown.Items.Add(miUnlockAll);

                Action<Object> fillAction = (src) =>
                {
                    Current.cb.Focus();
                    Accordion a = (Accordion)Current.Parent;
                    Size ps = a.layoutEngine.GetPreferredSize(a, true, true, false);
                    Size cs = a.ClientSize;
                    int eh = cs.Height - ps.Height;
                    Current.lastClicked = DateTime.Now;

                    if (src == miFill)
                    {
                        if (eh > 0)
                        {
                            int oh = 0;
                            if (!Current.cb.Checked)
                            {
                                Current.dh = 0;
                                Size ps2 = Current.GetPackSize();
                                oh = ps2.Height;
                                if (ps.Width > cs.Width)
                                    oh += SystemInformation.HorizontalScrollBarHeight;
                            }
                            bool isLocked = Current.isLocked;
                            Current.isLocked = true;
                            Current.dh += Math.Min(Current.MaxDH, Math.Max(eh - oh, 0));
                                                                                                                   a.PerformLayout();
                            Current.isLocked = isLocked;
                        }
                        else
                        {
                                                                                      if (!Current.cb.Checked)
                            {
                                Current.dh = 0;
                            }

                                                                                      int numCheckBoxVisible = 0;
                            int numControl2Visible = 0;
                            foreach (Control2 c2 in a.Control2s)
                            {
                                if (c2.Visible)
                                {
                                    numControl2Visible++;
                                    if (numControl2Visible > 1)
                                        break;
                                }
                                if (c2.cb.Visible)
                                {
                                    numCheckBoxVisible++;
                                    if (numCheckBoxVisible > 1)
                                        break;
                                }
                            }
                            int padding = 0;
                            if (numCheckBoxVisible == 1 && numControl2Visible == 1)
                                padding = a.Padding.Vertical;

                            Size s = Current.GetPackSize();
                                                                                      int availH = cs.Height - (padding + Current.Margin.Top + Current.cb.Margin.Bottom + Current.cb.Height + s.Height);
                            if (Current.ResizeBar != null)
                                availH -= (Current.ResizeBar.Height / 2);

                            int dhNew = Math.Min(Current.MaxDH, Math.Max(Current.dh, availH));
                            if (Current.dh == dhNew)
                                return;

                            Current.dh = dhNew;
                            bool lockOrig = Current.isLocked;
                            Current.isLocked = true;
                            a.InternalPerformLayout();

                            a.isOpening = true;
                            a.scrollToBottom = true;
                            a.ScrollControlIntoView(Current);
                            a.scrollToBottom = false;
                            a.ScrollControlIntoView(Current.cb);
                            a.isOpening = false;
                            Current.isLocked = lockOrig;
                        }
                    }
                    else if (src == miFillAll)
                    {
                                                                          if (eh > 0)
                        {
                            int numOpen = 0;
                            int numOpenWithPositiveFillWt = 0;
                            foreach (Control2 c2 in a.Control2s)
                            {
                                if (c2.cb.Checked)
                                {
                                    numOpen++;
                                    if (c2.fillWt > 0)
                                        numOpenWithPositiveFillWt++;
                                }
                            }
                            if (numOpen == 0)
                                return;                              if (a.GrabRequiresPositiveFillWeight && numOpenWithPositiveFillWt == 0)
                                return;  
                            int x = (numOpenWithPositiveFillWt > 0 ? numOpenWithPositiveFillWt : numOpen);

                            double pixel = 0;
                            foreach (Control2 c2 in a.Control2s)
                            {
                                c2.Tag = c2.isLocked;
                                c2.isLocked = true;
                                if (c2.cb.Checked)
                                {
                                    if (numOpenWithPositiveFillWt > 0 && c2.fillWt <= 0)
                                        continue;

                                    double hh = 1.0 * eh / x;
                                    int ihh = (int)hh;
                                    pixel += hh % 1;
                                    if (pixel >= 0.5)
                                    {
                                        ihh++;
                                        pixel--;
                                    }
                                    int newDH = c2.dh + ihh;
                                    int maxDH = c2.MaxDH;
                                    if (newDH >= maxDH)
                                    {
                                        newDH = maxDH;
                                        int alloc = maxDH - c2.dh;
                                        eh = Math.Max(0, eh - alloc);
                                        x--;
                                    }
                                    c2.dh = newDH;
                                }
                            }
                            a.PerformLayout();
                            foreach (Control2 c2 in a.Control2s)
                                c2.isLocked = (bool)c2.Tag;
                        }
                    }
                    else if (src == miOpenAll)
                    {
                        Current.lastClicked = DateTime.Now;
                        a.Open(null);
                    }
                };

                miFill.ButtonClick += delegate
                {
                    fillAction(miFill);
                };

                miFill.DropDown.ItemClicked += (o, e) =>
                {
                    fillAction(e.ClickedItem);
                };

                Action<Object> packAction = (src) =>
                {
                                         var host = (Accordion)Current.Parent;
                    if (src == miPack || src == miPackAll)
                    {
                        foreach (Control2 c2 in host.Control2s)
                        {
                            c2.Tag = c2.isLocked;
                            c2.isLocked = true;
                            if (c2 == Current || src == miPackAll)
                            {
                                c2.dh = 0;
                                                             }
                        }

                                                 host.InternalPerformLayout();

                        foreach (Control2 c2 in host.Control2s)
                            c2.isLocked = (bool)c2.Tag;

                        Current.lastClicked = DateTime.Now;
                    }
                    else if (src == miCloseAll)
                    {
                        host.Close(null);
                    }
                };

                miPack.ButtonClick += delegate
                {
                    packAction(miPack);
                };

                miPack.DropDownItemClicked += (o, e) =>
                {
                    packAction(e.ClickedItem);
                };

                Action<Object> lockAction = (src) =>
                {
                    Current.cb.Focus();
                    Current.lastClicked = DateTime.Now;
                    Accordion host = (Accordion)Current.Parent;
                    if (src == miLockAll || src == miUnlockAll)
                    {
                        foreach (Control2 c2 in host.Control2s)
                            c2.isLocked = (src == miLockAll);
                    }
                    else
                    {
                        Current.isLocked = !Current.isLocked;
                                             }

                                         host.InternalPerformLayout();
                };

                miLock.ButtonClick += delegate
                {
                    lockAction(miLock);
                };
                miLock.DropDown.ItemClicked += (o, e) =>
                {
                    lockAction(e.ClickedItem);
                };
            }

            DateTime leaveTime;
            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                ToolBox toolBox = this;

                                                  leaveTime = DateTime.Now;
                new System.Threading.Thread((o) =>
                {
                                         System.Threading.Thread.Sleep(1000);
                    if ((DateTime)o != leaveTime)
                        return;

                                                              if (!toolBox.IsDisposed)
                    {
                        toolBox.BeginInvoke((Action)delegate
                        {
                            if (!IsMouseHit(Control.MousePosition))
                            {
                                toolBox.Hide();
                            }
                        });
                    }
                }).Start(leaveTime);
            }

            private bool IsMouseHit(Point pt)
            {
                if (this.Bounds.Contains(pt))
                    return true;

                if (miPack.DropDown.Visible && miPack.DropDown.Bounds.Contains(pt))
                    return true;

                if (miFill.DropDown.Visible && miFill.DropDown.Bounds.Contains(pt))
                    return true;

                if (miLock.DropDown.Visible && miLock.DropDown.Bounds.Contains(pt))
                    return true;

                return false;
            }


            public Control2 Current
            {
                get
                {
                    return _c2;
                }
                set
                {
                    _c2 = value;
                    if (_c2 == null)
                        return;

                    Accordion a = (Accordion)_c2.Parent;
                    Size ps = a.layoutEngine.GetPreferredSize(a, true, true, false);
                    Size cs = a.ClientSize;
                    int eh = cs.Height - ps.Height;

                    bool hasLocked = false;
                    bool hasUnlocked = false;
                    bool hasOpen = false;
                    bool hasOpenPositiveFillWt = false;
                    bool hasOpenPositiveExtraHeight = false;
                    int numClosed = 0;
                    foreach (Control2 c2 in a.Control2s)
                    {
                        if (!c2.cb.Visible)
                            continue;

                        if (c2.isLocked)
                            hasLocked = true;
                        else
                            hasUnlocked = true;

                        if (c2.cb.Checked)
                        {
                            hasOpen = true;
                            if (c2.fillWt > 0)
                                hasOpenPositiveFillWt = true;
                            if (c2.dh > 0)
                                hasOpenPositiveExtraHeight = true;
                        }
                        else
                            numClosed++;
                    }

                    miUnlockAll.Enabled = hasLocked;
                    miLockAll.Enabled = hasUnlocked;
                    miFillAll.Enabled = (hasOpenPositiveFillWt || hasOpen && !a.GrabRequiresPositiveFillWeight) && eh > 0;
                    miOpenAll.Enabled = numClosed > 0 && !a.OpenOneOnly;                      miCloseAll.Enabled = hasOpen;
                    miPack.Enabled = hasOpen;
                    miPackAll.Enabled = hasOpenPositiveExtraHeight;

                    if (_c2.isLocked)
                    {
                        miLock.ToolTipText = "Unlock height.";
                        miLock.Text = "\uD83D\uDD13";
                    }
                    else
                    {
                        miLock.ToolTipText = "Lock height.";
                        miLock.Text = "\uD83D\uDD12";
                    }
                }
            }

            protected override void OnFontChanged(EventArgs e)
            {
                base.OnFontChanged(e);
                                 foreach (ToolStripDropDownItem item in Items)
                {
                    if (item.DropDown != null)
                        item.DropDown.Font = Font;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (tips != null)
                    tips.Dispose();

                if (toolBox != null)
                    toolBox.Dispose();

                Application.RemoveMessageFilter(this);

                tips = null;
                toolBox = null;
            }
        }


        [DllImport("user32.dll")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        extern static IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point pt);

        [DllImport("user32.dll")]
        private static extern IntPtr GetFocus();  
        [DllImport("user32.dll")]
        private static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private static bool AnimateWindow(Control c, int dwTime, AnimateWindowFlags dwFlags)
        {
            int flags = (int)dwFlags;
            if (flags == 0)
                return false;

            return AnimateWindow(c.Handle, dwTime, flags);
        }

                          private bool IsMouseOverThisControl(Point pt)
        {
                         IntPtr hWnd = WindowFromPoint(pt);
            IntPtr h = this.Handle;
            while (hWnd != IntPtr.Zero)
            {
                if (hWnd == h)
                    return true;

                hWnd = GetParent(hWnd);
            }

            return false;
                                                                                                   }

        private static IntPtr GetTopMostHandle(IntPtr hWnd)
        {
            while (true)
            {
                IntPtr parent = GetParent(hWnd);
                if (parent == IntPtr.Zero)
                    break;
                hWnd = parent;
            }
            return hWnd;
        }

        private static Control ControlAtPoint(Point pt)
        {
            IntPtr hWnd = WindowFromPoint(pt);
            if (hWnd != IntPtr.Zero)
                return Control.FromHandle(hWnd);
            return null;
        }

         
        public interface ICheckBoxFactory
        {
            CheckBox CreateCheckBox(String text, bool check, Padding margin);
        }

                          public class DefaultCheckBoxFactory : ICheckBoxFactory
        {
            public virtual CheckBox CreateCheckBox(String text, bool check, Padding margin)
            {
                CheckBox cb = new CheckBox();
                cb.Appearance = Appearance.Button;
                                 cb.Checked = check;
                cb.Text = text;
                cb.Anchor = AnchorStyles.Left | AnchorStyles.Right;                  cb.Margin = margin;                  cb.AutoEllipsis = true;
                return cb;
            }
        }

        public interface IResizeBarFactory
        {
            Control CreateResizeBar(Padding margin);
        }

                          public class DefaultResizeBarFactory : IResizeBarFactory
        {
            public virtual Control CreateResizeBar(Padding margin)
            {
                ResizeBar bar = new ResizeBar();
                bar.Margin = new Padding(margin.Left, 0, margin.Right, 0);
                return bar;
            }
        }
    }

    [Flags]
    public enum AnimateWindowFlags : int
    {

                 None = 0,

                 Show = 0x00020000,

                 Hide = 0x00010000,

                           
                 Center = 0x00000010,

                 Slide = 0x00040000,

                 HorizontalPositive = 0x00000001,

                 HorizontalNegative = 0x00000002,

                 VerticalPositive = 0x00000004,

                 VerticalNegative = 0x00000008,
    }
    public class AccordionPanel : Panel
    {

        public Accordion acc = new Accordion();

        public AccordionPanel()
        {
            Dock = DockStyle.Fill;
            Controls.Add(acc);
        }

    }
}
