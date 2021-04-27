
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Scada.Controls
{
    [Description("选取颜色(可选透明度)")]
    public class ColorEditorExt : ColorEditor
    {
        private ColorEditorUIWrapper colorEditorUIWrapper;

        public ColorEditorExt()
        {

        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (edSvc != null)
                {
                    if (this.colorEditorUIWrapper == null)
                    {
                        this.colorEditorUIWrapper = new ColorEditorUIWrapper(this);
                    }
                    this.colorEditorUIWrapper.Start(edSvc, value);
                    edSvc.DropDownControl(this.colorEditorUIWrapper.Control);
                    if ((colorEditorUIWrapper.Value != null) && ((Color)this.colorEditorUIWrapper.Value != Color.Empty))
                    {
                        value = this.colorEditorUIWrapper.Value;
                    }
                    this.colorEditorUIWrapper.End();
                }
            }
            return value;
        }

        public override void PaintValue(PaintValueEventArgs e)
        {
            if (!(e.Value is Color))
                return;
            Color color = (Color)e.Value;
            Pen pen = new Pen(Color.Gray);
            SolidBrush solidBrush1 = new SolidBrush((color == Color.Empty || color == Color.Transparent) ? Color.Empty : Color.FromArgb(color.R, color.G, color.B));
            SolidBrush solidBrush2 = new SolidBrush(color);
            e.Graphics.FillRectangle(solidBrush1, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width / 2, e.Bounds.Height));
            if (!(color == Color.Empty || color == Color.Transparent))
                e.Graphics.DrawLine(pen, e.Bounds.Width / 2 + 1, e.Bounds.Y, e.Bounds.Width / 2 + 1, e.Bounds.Bottom - 2);
            e.Graphics.FillRectangle(solidBrush2, new Rectangle(e.Bounds.Width / 2, e.Bounds.Y, e.Bounds.Width / 2, e.Bounds.Height));
            solidBrush1.Dispose();
            solidBrush2.Dispose();
            pen.Dispose();
        }

        [Description("颜色编辑器面板")]
        public class ColorEditorUIWrapper
        {
            private Control ower;
            private Panel alphaPanel;
            private Label alphadesLabel;
            private TrackBar alphaTrackBar;
            private Label alphaLabel;
            private Label alphacolorLabel;
            private MethodInfo startMethodInfo;
            private MethodInfo endMethodInfo;
            private PropertyInfo valuePropertyInfo;

            public ColorEditorUIWrapper(ColorEditorExt _ower)
            {
                Type colorUiType = typeof(ColorEditor).GetNestedType("ColorUI", BindingFlags.CreateInstance | BindingFlags.NonPublic);
                ConstructorInfo constructorInfo = colorUiType.GetConstructor(new Type[] { typeof(ColorEditor) });
                this.ower = (Control)constructorInfo.Invoke(new object[] { _ower });
                this.startMethodInfo = this.ower.GetType().GetMethod("Start");
                this.endMethodInfo = this.ower.GetType().GetMethod("End");
                this.valuePropertyInfo = this.ower.GetType().GetProperty("Value");

                this.alphaPanel = new Panel();
                this.alphadesLabel = new Label();
                this.alphaTrackBar = new TrackBar();
                this.alphaLabel = new Label();
                this.alphacolorLabel = new Label();
                this.alphaPanel.BackColor = this.ower.BackColor;
                this.alphaPanel.Dock = DockStyle.Right;
                this.alphaPanel.Width = 45;
                this.alphaPanel.Controls.Add(this.alphaTrackBar);
                this.alphaPanel.Controls.Add(this.alphadesLabel);
                this.alphaPanel.Controls.Add(this.alphaLabel);
                this.alphaPanel.Controls.Add(this.alphacolorLabel);
                this.alphaTrackBar.BackColor = this.ower.BackColor;
                this.alphaTrackBar.Dock = DockStyle.Fill;
                this.alphaTrackBar.Orientation = Orientation.Vertical;
                this.alphaTrackBar.TickStyle = TickStyle.Both;
                this.alphaTrackBar.Maximum = byte.MaxValue;
                this.alphaTrackBar.Minimum = byte.MinValue;
                this.alphaTrackBar.SmallChange = 1;
                this.alphaTrackBar.LargeChange = 1;
                this.alphaTrackBar.ValueChanged += new EventHandler(this.alphaTrackBar_ValueChanged);
                this.alphadesLabel.BackColor = this.ower.BackColor;
                this.alphadesLabel.Dock = DockStyle.Top;
                this.alphadesLabel.Text = "透明度";
                this.alphadesLabel.TextAlign = ContentAlignment.MiddleCenter;
                this.alphaLabel.BackColor = this.ower.BackColor;
                this.alphaLabel.Dock = DockStyle.Bottom;
                this.alphaLabel.Text = "0";
                this.alphaLabel.TextAlign = ContentAlignment.MiddleCenter;
                this.alphacolorLabel.BackColor = this.ower.BackColor;
                this.alphacolorLabel.Dock = DockStyle.Bottom;
                this.alphacolorLabel.AutoSize = false;
                this.alphacolorLabel.Height = 24;
                this.alphacolorLabel.Text = "";
                this.alphacolorLabel.TextAlign = ContentAlignment.MiddleCenter;
                this.alphacolorLabel.Paint += new PaintEventHandler(this.alphacolorLabel_Paint);

                this.ower.Controls.Add(this.alphaPanel);
            }

            public Control Control
            {
                get { return this.ower; }
            }

            public object Value
            {
                get
                {
                    object result = this.valuePropertyInfo.GetValue(ower, new object[0]);
                    if (result is Color)
                    {
                        if ((Color)result != Color.Transparent)
                        {
                            if (this.alphaTrackBar.Value == 0)
                            {
                                this.alphaTrackBar.Value = byte.MaxValue;
                            }
                            result = Color.FromArgb(this.alphaTrackBar.Value, (Color)result);
                        }
                    }
                    return result;
                }
            }

            public void Start(IWindowsFormsEditorService service, object value)
            {
                if (value is Color)
                    this.alphaTrackBar.Value = ((Color)value).A;

                this.startMethodInfo.Invoke(ower, new object[] { service, value });
            }

            public void End()
            {
                this.endMethodInfo.Invoke(ower, new object[0]);
            }

            private void alphaTrackBar_ValueChanged(object sender, EventArgs e)
            {
                this.alphaLabel.Text = this.alphaTrackBar.Value.ToString();
                this.alphacolorLabel.Invalidate();
            }

            private void alphacolorLabel_Paint(object sender, PaintEventArgs e)
            {
                object result = this.valuePropertyInfo.GetValue(ower, new object[0]);
                if (result != null && result is Color)
                {
                    Color color = (Color)this.Value;
                    Graphics g = e.Graphics;
                    Pen pen = new Pen(Color.Silver);
                    SolidBrush solidBrush1 = new SolidBrush(Color.FromArgb(color.R, color.G, color.B));
                    SolidBrush solidBrush2 = new SolidBrush(color);
                    g.FillRectangle(solidBrush1, new RectangleF(g.ClipBounds.X, g.ClipBounds.Y, g.ClipBounds.Width / 2 - 1, g.ClipBounds.Height - 3));
                    g.FillRectangle(solidBrush2, new RectangleF(g.ClipBounds.Width / 2 - 1, g.ClipBounds.Y, g.ClipBounds.Width / 2 - 1, g.ClipBounds.Height - 3));
                    g.DrawRectangle(pen, g.ClipBounds.X, g.ClipBounds.Y, g.ClipBounds.Width - 3, g.ClipBounds.Height - 4);
                    solidBrush1.Dispose();
                    solidBrush2.Dispose();
                    pen.Dispose();
                }
            }

        }
    }
}
