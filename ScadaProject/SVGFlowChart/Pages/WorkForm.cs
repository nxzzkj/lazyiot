using Scada.FlowGraphEngine;
using Scada.Controls;
using Scada.FlowGraphEngine.GraphicsEngine;
using Scada.FlowGraphEngine.GraphicsMap;
using Scada.FlowGraphEngine.GraphicsShape;
using Scada.FlowGraphEngine.GraphicsShape.PipeLine;
using Scada.Model;
using ScadaFlowDesign.Core;
 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;

namespace ScadaFlowDesign
{
    public partial class WorkForm : DockContent, ICobaltTab
    {
        private Mediator mediator = null;
        public WorkForm(Mediator m, float mapwidth, float mapheight,string title)
        {
            InitializeComponent();
            this.HideOnClose = true;
            this.KeyPreview = true;//为了使OnKeyDown事件有效
            mediator = m;
            this.graphControl.InitGraph(mapwidth, mapheight, title);
            this.Load += (s, e) =>
            {
             
                graphControl.OnGraphMouseInfo += GraphControl_OnGraphMouseInfo;
                graphControl.StateText = this.mediator.Parent.ToolStatusInfo;

                SVG_DataVDecorationShape11 shape = new SVG_DataVDecorationShape11();
                shape.X = 200;
                shape.Y = 200;
                shape.Width = 200;
                shape.Height = 100;
                graphControl.AddShape(shape, AddShapeType.Create);


            };
            this.graphControl.OnShowProperties += GraphControl_OnShowProperties;
            this.graphControl.MakeCombinationShape = new Action<TemplateShape, string>((template, filepath) =>
            {
                FlowManager.Mediator.ShapeForm.LoadTemplate();

            });



        }

        private void GraphControl_OnGraphMouseInfo(object sender, Shape shape)
        {
            ServiceViewsGlobel.Views = null;
            List<GraphAbstract> list = new List<GraphAbstract>();
            List<ScadaFlowUser> list2 = new List<ScadaFlowUser>();
            List<ScadaConnectionBase> list3 = new List<ScadaConnectionBase>();
            foreach (FlowProject project in FlowManager.Projects)
            {
                list.AddRange(project.GraphList);
                list2.AddRange(project.FlowUsers);
                list3.AddRange(project.ScadaConnections);
            }
            ServiceViewsGlobel.Views = list;
            ServiceViewsGlobel.Users = list2;
            ServiceViewsGlobel.Connections = list3;
            if (sender != null)
            {
                this.mediator.Parent.SetHoverInformation(sender.ToString());
            }
            if (shape != null)
            {
                if (shape.GetType() == typeof(Combination))
                {
                    this.mediator.Parent.SetCombination();
                }
                else
                {
                    this.mediator.Parent.SetUnCombination();
                }
                this.mediator.Parent.SetUnLock(shape.Locked);
            }
            Task.Run(delegate {
                IOServerGlobel.Server = FlowManager.FlowDataBaseManager.IOServer;
                IOServerGlobel.Communications = FlowManager.FlowDataBaseManager.IOCommunications;
            });
        }

        public GraphControl GraphControl
        {
            get { return graphControl; }
        }
        public void SetDrawShape(ShapeElement select)
        {
            switch (select)
            {


                case ShapeElement.SVG_GroupPanelHeadShape:
                    {
                        SVG_GroupPanelHeadShape shapeModel = new SVG_GroupPanelHeadShape
                        {
                            SaveToTemplate = (template, filepath) => FlowManager.Mediator.ShapeForm.LoadTemplate()
                        };
                        this.graphControl.selector = new CommonSelector(this.graphControl, shapeModel);
                        return;
                    }
                case ShapeElement.SVG_GroupPanelTextShape:
                    {
                        SVG_GroupPanelTextShape shapeModel = new SVG_GroupPanelTextShape
                        {
                            SaveToTemplate = (template, filepath) => FlowManager.Mediator.ShapeForm.LoadTemplate()
                        };
                        this.graphControl.selector = new CommonSelector(this.graphControl, shapeModel);
                        return;
                    }
                case ShapeElement.SVG_TabPanelShape:
                    {
                        SVG_TabPanelShape shapeModel = new SVG_TabPanelShape
                        {
                            SaveToTemplate = (template, filepath) => FlowManager.Mediator.ShapeForm.LoadTemplate()
                        };
                        this.graphControl.selector = new CommonSelector(this.graphControl, shapeModel);
                        return;
                    }
                case ShapeElement.SVG_GeneralShape:
                    {
                        SVG_GeneralShape shapeModel = new SVG_GeneralShape
                        {
                            SaveToTemplate = (template, filepath) => FlowManager.Mediator.ShapeForm.LoadTemplate()
                        };
                        this.graphControl.selector = new CommonSelector(this.graphControl, shapeModel);
                        return;
                    }
            }
            this.graphControl.SetDrawShape(select);
        }


        /// <summary>
        /// 保存页面
        /// </summary>
        public void SavePage()
        {

        }
        /// <summary>
        /// 加载页面
        /// </summary>
        public void LoadPage()
        {

        }


        private void GraphControl_OnShowProperties(object sender, object[] props)
        {
            this.mediator.PropertiesForm.ShowProperties(sender, props);
        }

        private string identifier;
        public TabTypes TabType
        {
            get
            {
                return TabTypes.WorkArea;
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
        //打开文件后返回的消息
        private void graphControl_OnDiagramOpened(object sender, System.IO.FileInfo info)
        {

        }
        //清空所有图键返回的消息
        private void graphControl_OnClear(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 保存图件返回的消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="info"></param>
        private void graphControl_OnSavingDiagram(object sender, System.IO.FileInfo info)
        {

        }
        /// <summary>
        /// 新增加一个图元返回的消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="shape"></param>
        private void graphControl_OnShapeAdded(object sender, Shape shape)
        {
            FlowManager.AddLogToMainLog("增加图元" + shape.Name);
        }
        /// <summary>
        /// 删除一个图元返回的消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="shape"></param>
        private void graphControl_OnShapeRemoved(object sender, Shape shape)
        {
            FlowManager.AddLogToMainLog("删除图元" + shape.Name);
        }
        /// <summary>
        /// 鼠标相关通知消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       

        private void graphControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.mediator.ShapeForm.Cursor = Cursors.Default;
        }
    }


}
