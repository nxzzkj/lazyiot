
using Scada.Controls;
using ScadaFlowDesign;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScadaFlowDesign.Control;
 
using Scada.FlowGraphEngine;
 
using Scada.FlowGraphEngine.GraphicsShape;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Controls;
using Scada.DBUtility;
using Scada.FlowGraphEngine.GraphicsMap;
using ScadaFlowDesign.Dialog;
using Scada.FlowGraphEngine.GraphicsCusControl;

namespace ScadaFlowDesign
{
    public partial class ShapeForm : DockContent, ICobaltTab
    {

        private Mediator mediator = null;

        public ShapeForm(Mediator m)
        {

            mediator = m;
            this.HideOnClose = true;
            InitializeComponent();
            this.Load += (s, e) =>
            {
                this.Width = 250;
                ScadaAnalysisSymbol.LoadedSymbol += ScadaAnalysisSymbol_LoadedSymbol;
                ScadaAnalysisSymbol.EndLoadedSymbol += ScadaAnalysisSymbol_EndLoadedSymbol;
                SymbolListView.OnSelectSymbol += SymbolListView_OnSelectSymbol;
                LoadTemplate();
           
            };



        }
        /// <summary>
        /// 用户选择某个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SymbolListView_OnSelectSymbol(object sender, EventArgs e)
        {
            if (sender != null)
            {
                DataObject data = new DataObject("Scada.FlowGraphEngine.GraphicsMap.Shape.Draw", sender);

                ScadaSymbol_Shape selectShape = (ScadaSymbol_Shape)sender;
                this.Cursor = new Cursor(selectShape.GetCursor());
                if (this.mediator.ActiveWork != null)
                {
                    ((WorkForm)this.mediator.ActiveWork).GraphControl.Cursor = this.Cursor;
                    SVG_StaticShape shape = new SVG_StaticShape();
                    shape.SvgShape = data.GetData("Scada.FlowGraphEngine.GraphicsMap.Shape.Draw") as ScadaSymbol_Shape;
                    ((WorkForm)this.mediator.ActiveWork).GraphControl.selector = new CommonSelector(((WorkForm)this.mediator.ActiveWork).GraphControl, shape);
                }
            }



        }
        /// <summary>
        /// 加载用户自定义的模板
        /// </summary>
        public Task LoadTemplate()
        {
            flowLayoutPanelTemplate.Controls.Clear();
            var task = Task.Run(() =>
            {
                string path = Application.StartupPath + "/ScadaTemplate/TemplateShapes/";
                string[] temps = Directory.GetFiles(path, "*.tpl");
                for (int i = 0; i < temps.Length; i++)
                {
                    FileStream fs = null;
                    try
                    {

                        TemplateShape shape = null;
                        fs = new FileStream(temps[i], FileMode.Open);
                        fs.Seek(0, SeekOrigin.Current);
                        IFormatter formatter = new BinaryFormatter();
                        while (fs.Position < fs.Length)
                        {
                            shape = (TemplateShape)formatter.Deserialize(fs);

                        }
                        System.Windows.Forms.Label button = new System.Windows.Forms.Label()
                        {
                            Text = shape.Title,
                            Tag = shape.Path,
                            Width = 120,
                            Height = 40,
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = Color.White,
                            ForeColor = Color.Blue,
                            Font = new Font("微软雅黑", 13),
                            ContextMenuStrip = this.contextMenuStrip1,
                            TextAlign = ContentAlignment.MiddleCenter,
                        };

                        button.MouseDoubleClick += Button_MouseDoubleClick;
                        button.MouseClick += Button_MouseClick;
                        if (this.IsHandleCreated)
                        {
                            this.BeginInvoke(new Action(delegate
                            {
                                flowLayoutPanelTemplate.Controls.Add(button);

                            }));
                        }



                    }
                    catch 
                    {
#if DEBUG
                        throw ;
#else

#endif
                    }
                    finally
                    {
                        if (fs != null)
                            fs.Close();
                    }

                }
            });
            return task;
        }

        private void Button_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < flowLayoutPanelTemplate.Controls.Count; i++)
            {
                System.Windows.Forms.Label label = flowLayoutPanelTemplate.Controls[i] as System.Windows.Forms.Label;
                label.BackColor = Color.White;
            }
            System.Windows.Forms.Label button = sender as System.Windows.Forms.Label;
            button.BackColor = Color.Red;//选中状态
        }

        private void Button_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.Label button = sender as System.Windows.Forms.Label;
            if (e.Clicks == 2)
            {
                button.BackColor = Color.White;
                if (this.mediator.ActiveWork != null && button.Tag != null)
                {
                    TemplateShape newShape = null;
                    FileStream fs = null;
                    try
                    {


                        fs = new FileStream(Application.StartupPath + "/ScadaTemplate/TemplateShapes/" + button.Tag.ToString(), FileMode.Open);
                        fs.Seek(0, SeekOrigin.Current);
                        IFormatter formatter = new BinaryFormatter();
                        while (fs.Position < fs.Length)
                        {
                            newShape = (TemplateShape)formatter.Deserialize(fs);

                        }

                    }
                    catch (Exception emx)
                    {
#if DEBUG
                        throw emx;
#else
                               MessageBox.Show(this, emx.Message);
#endif
                    }
                    finally
                    {
                        if (fs != null)
                            fs.Close();
                    }

                    try
                    {


                        if (newShape == null)
                        {
                            return;
                        }
                        Point cp = new Point();

                        cp.X = ((WorkForm)this.mediator.ActiveWork).GraphControl.ClientRectangle.Width / 2 - Convert.ToInt32(newShape.TplShape.Width) / 2;
                        cp.Y = ((WorkForm)this.mediator.ActiveWork).GraphControl.ClientRectangle.Height / 2 - Convert.ToInt32(newShape.TplShape.Height) / 2;

                        ///重新获取GUID
                        
                        GetTemplateShape(newShape.TplShape,  newShape.shapes);
                        for (int i = 0; i < newShape.shapes.Count; i++)
                        {
                            //此处要做无限循环处理,读取容器内容
                            newShape.shapes[i].Site = ((WorkForm)this.mediator.ActiveWork).GraphControl;
                            newShape.shapes[i].Layer = ((WorkForm)this.mediator.ActiveWork).GraphControl.BasicLayer;
                            newShape.shapes[i].LayerName = ((WorkForm)this.mediator.ActiveWork).GraphControl.BasicLayer.Name;
                            newShape.shapes[i].GID = ((WorkForm)this.mediator.ActiveWork).GraphControl.Abstract.GID;
                    
                        }
                        newShape.TplShape.GenerateNewUID();
                        newShape.TplShape.Site = ((WorkForm)this.mediator.ActiveWork).GraphControl;
                        newShape.TplShape.Layer = ((WorkForm)this.mediator.ActiveWork).GraphControl.BasicLayer;
                        newShape.TplShape.LayerName = ((WorkForm)this.mediator.ActiveWork).GraphControl.BasicLayer.Name;
                        newShape.TplShape.GID = ((WorkForm)this.mediator.ActiveWork).GraphControl.Abstract.GID;
                        ((WorkForm)this.mediator.ActiveWork).GraphControl.AddShape(newShape.TplShape, AddShapeType.Create);

                        for (int i = 0; i < newShape.shapes.Count; i++)
                        {
                            //此处要做无限循环处理,读取容器内容
                            ((WorkForm)this.mediator.ActiveWork).GraphControl.AddShape(newShape.shapes[i], AddShapeType.Create);
                        }
                        newShape.TplShape.MoveOffiset(cp.X - newShape.TplShape.X, cp.Y - newShape.TplShape.Y);
                       

                    }
                    catch (Exception emx)
                    {

#if DEBUG
                        throw emx;
#else
                                     MessageBox.Show(this, emx.Message);
#endif

                    }
                }
            }
        }

        private void GetTemplateShape(Shape shape,   List<Shape> shapes)
        {
            if (shape.GetType().BaseType == typeof(SVGContainer))
            {
                SVGContainer container = (SVGContainer)shape;
                for (int c = container.Shapes.Count - 1; c >= 0; c--)
                {
                    Shape existShape = shapes.Find(x => x.UID == container.Shapes[c].UID);
                    if (existShape != null)
                    {

                        container.Shapes[c].Shape = existShape;
                        if (container.Shapes[c].Shape != null)
                        {
                            container.Shapes[c].ChangedUid();
                            container.Shapes[c].Shape.Name = "Element" + container.Shapes[c].UID;
                            GetTemplateShape(container.Shapes[c].Shape,   shapes);
                        }
                        else
                        {
                            container.Shapes.RemoveAt(c);
                        }
                    }

                }

            }
            else if (shape.GetType() == typeof(SVG_TabPanelShape))//tab页面
            {
                SVG_TabPanelShape container = (SVG_TabPanelShape)shape;
                for (int c = 0; c < container.TabPages.Count; c++)
                {
                    for (int s = container.TabPages[c].Shapes.Count-1; s >=0; s--)
                    {
                        Shape existShape = shapes.Find(x => x.UID == container.TabPages[c].Shapes[s].UID);
                        if (existShape != null)
                        {

                            container.TabPages[c].Shapes[s].Shape = existShape;
                            if (container.TabPages[c].Shapes[s].Shape != null)
                            {
                                container.TabPages[c].Shapes[s].ChangedUid();
                                container.TabPages[c].Shapes[s].Shape.Name = "Element" + container.TabPages[c].Shapes[s].UID;
                                GetTemplateShape(container.TabPages[c].Shapes[s].Shape,  shapes);
                            }

                        }
                        else
                        {
                            container.TabPages[c].Shapes.RemoveAt(s);
                        }
                    }

                }

            }
            else if (shape.GetType() == typeof(Combination))//组合体
            {
                Combination container = (Combination)shape;
                for (int c = container.Shapes.Count-1; c >=0; c--)
                {
                    Shape existShape = shapes.Find(x => x.UID == container.Shapes[c]);
                    if (existShape != null)
                    {
                        existShape.UID = "ID"+GUIDTo16.GuidToLongID().ToString();
                        existShape.Name = "Element" + existShape.UID;
                        container.Shapes[c] = existShape.UID;
                        GetTemplateShape(existShape,  shapes);
                    }
                    else
                    {
                        container.Shapes.RemoveAt(c);
                    }

                }

            }
     

        }
        private void ScadaAnalysisSymbol_EndLoadedSymbol(string path)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new EventHandler(delegate
            {
                comboBoxSymbol.Items.Clear();
                for (int i = 0; i < ScadaAnalysisSymbol.Groups.Count; i++)
                {
                    comboBoxSymbol.Items.Add(ScadaAnalysisSymbol.Groups[i]);
                }
                comboBoxSymbol.SelectedIndex = 0;

            }));
            }
          
        }

        private void ScadaAnalysisSymbol_LoadedSymbol(string path)
        {
            this.mediator.LogForm.AppendLogItem(path);
        
        }

        private string identifier;
        public TabTypes TabType
        {
            get
            {
                return TabTypes.Shape;
            }
        }
        public string TabIdentifier
        {
            get
            {
                return identifier;
            }
            set
            {
                identifier = value;
            }
        }
        private void ButtonShape_Click(object sender, EventArgs e)
        {
            SCADAShapeButton button = sender as SCADAShapeButton;
            if (this.mediator.ActiveWork != null && (this.mediator.ActiveWork is WorkForm))
            {
                WorkForm mWorkForm = this.mediator.ActiveWork as WorkForm;
                mWorkForm.SetDrawShape(button.ShapeElement);
                ((WorkForm)this.mediator.ActiveWork).GraphControl.Cursor =new Cursor( button.GetCursor());
            }
           

        }

        private void comboBoxSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxSymbol.SelectedItem!=null)
            {
                SymbolListView.FieldSymbol = (SymbolGroup)comboBoxSymbol.SelectedItem;
                SymbolListView.InitItems();
            }
        }

        private void flowLayoutPanelNormal_MouseDown(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
            ((WorkForm)this.mediator.ActiveWork).GraphControl.selector = null;
        }

        private void flowLayoutPanelNormal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
            ((WorkForm)this.mediator.ActiveWork).GraphControl.selector = null;
        }

        private void 删除模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
            if(MessageBox.Show(this,"是否要删除此模板?","删除提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                for (int i = 0; i < flowLayoutPanelTemplate.Controls.Count; i++)
                {
                    System.Windows.Forms.Label label = flowLayoutPanelTemplate.Controls[i] as System.Windows.Forms.Label;
                    if(label.BackColor == Color.Red)
                    {
                        File.Delete(Application.StartupPath + "/ScadaTemplate/TemplateShapes/" + label.Tag.ToString());
                        flowLayoutPanelTemplate.Controls.Remove(label);
                        break;
                    }
                }
            }
        }

      
    }
}
