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
using ScadaFlowDesign.Dialog;
using ScadaFlowDesign.Core;
using Scada.FlowGraphEngine.GraphicsMap;
using Scada.Controls.Forms;
using Scada.FlowGraphEngine.GraphicsCusControl;
using Scada.DBUtility;
using Scada.Model;
using Scada.FlowGraphEngine.GraphicsEngine;
using System.IO;
using Scada.FlowGraphEngine;

namespace ScadaFlowDesign
{
    public partial class ToolForm : DockContent, ICobaltTab
    {
        private Mediator mediator;
        private string identifier;


        public ToolForm(Mediator m)
        {
            this.InitializeComponent();
            this.mediator = m;
            base.HideOnClose = true;
            base.Load += new EventHandler(this.ToolForm_Load);
        }

        public void AddFlowUser()
        {
            if ((this.treeViewUser.SelectedNode.Tag != null) && (this.treeViewUser.SelectedNode.Tag.GetType() == typeof(FlowProject)))
            {
                FlowUserManagerForm form = new FlowUserManagerForm();
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    FlowProject tag = (FlowProject)this.treeViewUser.SelectedNode.Tag;
                    for (int i = 0; i < tag.FlowUsers.Count; i++)
                    {
                        if (tag.FlowUsers[i].UserName.Trim() == form.EditUser.UserName.Trim())
                        {
                            MessageBox.Show(this, "已经存在此用户名", "提示");
                            return;
                        }
                    }
                    tag.FlowUsers.Add(form.EditUser);
                    TreeNode node = new TreeNode
                    {
                        Text = form.EditUser.ToString(),
                        Tag = form.EditUser,
                        ImageIndex = 4,
                        StateImageIndex = 4
                    };
                    this.treeViewUser.SelectedNode.Nodes.Add(node);
                }
            }
        }

        public void CreateView()
        {
            if ((this.treeView.SelectedNode != null) && (this.treeView.SelectedNode.GetType() == typeof(FlowProjectNode)))
            {
                FlowProjectNode selectedNode = this.treeView.SelectedNode as FlowProjectNode;
                CreateViewDialog dialog = new CreateViewDialog();
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    SCADAViewNode node = new SCADAViewNode
                    {
                        Text = dialog.ViewName,
                        ContextMenuStrip = this.contextMenuView,
                        View = (WorkForm)this.mediator.CreateWorkForm(dialog.ViewName, (float)dialog.PageWidth, (float)dialog.PageHeight)
                    };
                    node.View.GraphControl.SaveViewResult = delegate (bool res, string msg) {
                        if (res)
                        {
                            this.LoadTreeViewTemplate();
                        }
                        else
                        {
                            MessageBox.Show(this, msg);
                        }
                    };
                    selectedNode.Nodes.Add(node);
                    selectedNode.Project.GraphList.Add(node.View.GraphControl.Abstract);
                }
            }
        }

        public void Debug()
        {
            try
            {
                if (this.treeView.SelectedNode is FlowProjectNode)
                {
                    new DebugForm((this.treeView.SelectedNode as FlowProjectNode).Project).ShowDialog(this.mediator.Parent);
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        public void DeleteFlowUser()
        {
            if (((this.treeViewUser.SelectedNode.Tag != null) && (this.treeViewUser.SelectedNode.Tag.GetType() == typeof(ScadaFlowUser))) && (MessageBox.Show(this, "是否要删除用户", "删除提示", MessageBoxButtons.OKCancel) == DialogResult.OK))
            {
                ((FlowProject)this.treeViewUser.SelectedNode.Parent.Tag).FlowUsers.Remove((ScadaFlowUser)this.treeViewUser.SelectedNode.Tag);
                this.treeViewUser.Nodes.Remove(this.treeViewUser.SelectedNode);
            }
        }

        public void DeleteProject()
        {
            if (this.treeView.SelectedNode is FlowProjectNode)
            {
                FlowProjectNode selectedNode = this.treeView.SelectedNode as FlowProjectNode;
                FlowManager.AddLogToMainLog("正在保存工程" + selectedNode.Project.Title + " 到" + selectedNode.Project.FileFullName);
                FlowManager.Save(selectedNode.Project);
                FlowManager.AddLogToMainLog("正在保存工程成功");
                this.treeView.Nodes.Remove(this.treeView.SelectedNode);
                foreach (GraphAbstract @abstract in selectedNode.Project.GraphList)
                {
                    for (int k = 0; k < this.mediator.DockPanel.Documents.Count<DockContent>(); k++)
                    {
                        if ((this.mediator.DockPanel.Documents[k] is WorkForm) && ((this.mediator.DockPanel.Documents[k] as WorkForm).GraphControl.Abstract == @abstract))
                        {
                            this.mediator.DockPanel.Documents[k].Hide();
                            this.mediator.DockPanel.Documents[k].Dispose();
                        }
                    }
                }
                for (int i = 0; i < this.treeViewUser.Nodes.Count; i++)
                {
                    if ((this.treeViewUser.Nodes[i].Tag != null) && (((FlowProject)this.treeViewUser.Nodes[i].Tag) == selectedNode.Project))
                    {
                        this.treeViewUser.Nodes.Remove(this.treeViewUser.Nodes[i]);
                    }
                }
                for (int j = 0; j < this.treeViewConnections.Nodes.Count; j++)
                {
                    if ((this.treeViewConnections.Nodes[j].Tag != null) && (((FlowProject)this.treeViewConnections.Nodes[j].Tag) == selectedNode.Project))
                    {
                        this.treeViewConnections.Nodes.Remove(this.treeViewConnections.Nodes[j]);
                    }
                }
                FlowManager.Projects.Remove(selectedNode.Project);
            }
        }

        public void DeleteView()
        {
            if ((this.treeView.SelectedNode is SCADAViewNode) && (MessageBox.Show("是否要删除" + this.treeView.SelectedNode.Text + "视图?", "删除提示", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                try
                {
                    SCADAViewNode selectedNode = (SCADAViewNode)this.treeView.SelectedNode;
                    FlowProjectNode parent = (FlowProjectNode)this.treeView.SelectedNode.Parent;
                    parent.Project.GraphList.Remove(selectedNode.GraphSite);
                    parent.Nodes.Remove(selectedNode);
                    for (int i = 0; i < this.mediator.DockPanel.Documents.Count<DockContent>(); i++)
                    {
                        if ((this.mediator.DockPanel.Documents[i] is WorkForm) && ((this.mediator.DockPanel.Documents[i] as WorkForm) == selectedNode.View))
                        {
                            this.mediator.DockPanel.Documents[i].Hide();
                            this.mediator.DockPanel.Documents[i].Dispose();
                            this.mediator.DockPanel.Documents[i] = null;
                        }
                    }
                    FlowManager.AddLogToMainLog("删除视图成功!" + parent.Text + "//" + selectedNode.Text);
                }
                catch (Exception exception)
                {
                    FlowManager.AddLogToMainLog("删除视图失败!" + exception.InnerException);
                }
            }
        }

      

        public void EditFlowUser()
        {
            if ((this.treeViewUser.SelectedNode.Tag != null) && (this.treeViewUser.SelectedNode.Tag.GetType() == typeof(ScadaFlowUser)))
            {
                FlowUserManagerForm form = new FlowUserManagerForm
                {
                    EditUser = (ScadaFlowUser)this.treeViewUser.SelectedNode.Tag
                };
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    FlowProject tag = (FlowProject)this.treeViewUser.SelectedNode.Parent.Tag;
                    for (int i = 0; i < tag.FlowUsers.Count; i++)
                    {
                        if ((tag.FlowUsers[i].UserName.Trim() == form.EditUser.UserName.Trim()) && (tag.FlowUsers[i] != form.EditUser))
                        {
                            MessageBox.Show(this, "已经存在此用户名", "提示");
                            return;
                        }
                    }
                    this.treeViewUser.SelectedNode.Text = form.EditUser.ToString();
                }
            }
        }

        public void EditView()
        {
            if (this.treeView.SelectedNode is SCADAViewNode)
            {
                SCADAViewNode selectedNode = this.treeView.SelectedNode as SCADAViewNode;
                if (selectedNode.View != null)
                {
                    selectedNode.View.Activate();
                }
                else
                {
                    selectedNode.View = (WorkForm)this.mediator.CreateWorkForm(selectedNode.GraphSite.GraphInformation.Title, selectedNode.GraphSite.MapWidth, selectedNode.GraphSite.MapHeight, selectedNode.GraphSite);
                }
            }
        }

 

        public void InitTreeConnections(FlowProject project)
        {
            FlowProjectNode node = new FlowProjectNode(project)
            {
                Text = project.Title,
                Tag = project,
                ImageIndex = 0,
                StateImageIndex = 0,
                ContextMenuStrip = this.contextMenuConnection
            };
            for (int i = 0; i < project.ScadaConnections.Count; i++)
            {
                ScadaConnectionNode node2 = new ScadaConnectionNode(project.ScadaConnections[i])
                {
                    ContextMenuStrip = this.contextMenuConnectionDelete
                };
                node.Nodes.Add(node2);
            }
            this.treeViewConnections.Nodes.Add(node);
        }

        public void InitTreeUser(FlowProject project)
        {
            TreeNode node = new TreeNode
            {
                Text = project.Title,
                Tag = project,
                ImageIndex = 3,
                StateImageIndex = 3
            };
            for (int i = 0; i < project.FlowUsers.Count; i++)
            {
                TreeNode node2 = new TreeNode
                {
                    Text = project.FlowUsers[i].ToString(),
                    Tag = project.FlowUsers[i],
                    ImageIndex = 4,
                    StateImageIndex = 4
                };
                node.Nodes.Add(node2);
            }
            this.treeViewUser.Nodes.Add(node);
        }

        public void InitTreeView(FlowProject project)
        {
            TreeNodeEx ex = new TreeNodeEx(TreeNodeType.View);
            if (this.treeView.Nodes.Count <= 0)
            {
                ex.Text = "SCADA流程图";
                this.treeView.Nodes.Add(ex);
            }
            else
            {
                ex = (TreeNodeEx)this.treeView.Nodes[0];
            }
            FlowProjectNode node = new FlowProjectNode(project)
            {
                ToolTipText = project.FileFullName,
                ContextMenuStrip = this.contextMenuProject
            };
            for (int i = 0; i < project.GraphList.Count; i++)
            {
                SCADAViewNode node2 = new SCADAViewNode
                {
                    ContextMenuStrip = this.contextMenuView,
                    View = (WorkForm)this.mediator.CreateWorkForm(project.GraphList[i].ViewTitle, project.GraphList[i].MapWidth, project.GraphList[i].MapHeight, project.GraphList[i])
                };
                node2.View.GraphControl.Abstract = project.GraphList[i];
                node2.View.GraphControl.Abstract.Site = node2.View.GraphControl;
                node2.View.GraphControl.BasicLayer = project.GraphList[i].Layers[0];
                for (int j = 0; j < project.GraphList[i].Shapes.Count; j++)
                {
                    project.GraphList[i].Shapes[j].Layer = node2.View.GraphControl.BasicLayer;
                }
                node2.Text = node2.GraphSite.ViewTitle;
                node2.View.GraphControl.LoadPropertiesEvent();
                node2.View.GraphControl.SaveViewResult = delegate (bool res, string msg) {
                    if (res)
                    {
                        this.LoadTreeViewTemplate();
                    }
                    else
                    {
                        MessageBox.Show(this, msg);
                    }
                };
                node.Nodes.Add(node2);
            }
            node.ExpandAll();
            ex.Nodes.Add(node);
        }

        public void LoadTempViewToProject(string tempFile)
        {
            FlowProjectNode selectedNode = null;
            if (this.treeView.SelectedNode != null)
            {
                if (this.treeView.SelectedNode is FlowProjectNode)
                {
                    selectedNode = this.treeView.SelectedNode as FlowProjectNode;
                }
                else if (this.treeView.SelectedNode is SCADAViewNode)
                {
                    selectedNode = this.treeView.SelectedNode.Parent as FlowProjectNode;
                }
                CreateViewDialog dialog = new CreateViewDialog();
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    SCADAViewNode node2 = new SCADAViewNode
                    {
                        Text = dialog.ViewName,
                        ContextMenuStrip = this.contextMenuView,
                        View = (WorkForm)this.mediator.CreateWorkForm(dialog.ViewName, (float)dialog.PageWidth, (float)dialog.PageHeight)
                    };
                    GraphAbstract @abstract = node2.View.GraphControl.LoadView(tempFile);
                    node2.View.GraphControl.Abstract.MapHeight = @abstract.MapHeight;
                    node2.View.GraphControl.Abstract.MapWidth = @abstract.MapWidth;
                    node2.View.GraphControl.Abstract.ViewTitle = dialog.ViewName;
                    node2.View.GraphControl.Layers.Clear();
                    node2.View.GraphControl.AddLayer(@abstract.Layers[0]);
                    node2.View.GraphControl.BasicLayer = @abstract.Layers[0];
                    for (int i = 0; i < @abstract.Shapes.Count; i++)
                    {
                        node2.View.GraphControl.AddShape(@abstract.Shapes[i], AddShapeType.Create, null, -1);
                    }
                    node2.View.GraphControl.SaveViewResult = delegate (bool res, string msg) {
                        if (res)
                        {
                            this.LoadTreeViewTemplate();
                        }
                        else
                        {
                            MessageBox.Show(this, msg);
                        }
                    };
                    node2.View.GraphControl.LoadViewResult = (res, msg) => MessageBox.Show(this, msg);
                    selectedNode.Nodes.Add(node2);
                    selectedNode.Project.GraphList.Add(node2.View.GraphControl.Abstract);
                }
            }
        }

        public void LoadTreeViewTemplate()
        {
            try
            {
                this.treeViewTemplate.Nodes[0].Nodes.Clear();
                this.treeViewTemplate.Nodes[0].Tag = null;
                this.treeViewTemplate.Nodes[0].ExpandAll();
                string[] directories = Directory.GetDirectories(Application.StartupPath + "/ScadaTemplate/TemplateViews/");
                for (int i = 0; i < directories.Length; i++)
                {
                    TreeNode node = new TreeNode
                    {
                        Text = Path.GetFileName(directories[i]),
                        Tag = null,
                        ImageIndex = 1,
                        SelectedImageIndex = 1,
                        StateImageIndex = 1
                    };
                    string[] files = Directory.GetFiles(directories[i], "*.vtpl");
                    for (int j = 0; j < files.Length; j++)
                    {
                        TreeNode node2 = new TreeNode
                        {
                            Text = Path.GetFileNameWithoutExtension(files[j]),
                            Tag = files[j],
                            ImageIndex = 2,
                            SelectedImageIndex = 2,
                            StateImageIndex = 2
                        };
                        node.Nodes.Add(node2);
                    }
                    this.treeViewTemplate.Nodes[0].Nodes.Add(node);
                    node.ExpandAll();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message);
            }
        }

        public void Publish()
        {
            try
            {
                if (this.treeView.SelectedNode is FlowProjectNode)
                {
                    FlowManager.PublishFlowStart((this.treeView.SelectedNode as FlowProjectNode).Project);
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        public void SaveAsProject()
        {
            if (this.treeView.SelectedNode is FlowProjectNode)
            {
                FlowManager.SaveAsProject((this.treeView.SelectedNode as FlowProjectNode).Project);
            }
        }

        public void SaveProject()
        {
            if (this.treeView.SelectedNode is FlowProjectNode)
            {
                FlowManager.SaveProject((this.treeView.SelectedNode as FlowProjectNode).Project);
            }
        }

        private void ToolForm_Load(object sender, EventArgs e)
        {
            this.LoadTreeViewTemplate();
        }

        private void toolStripSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveProject();
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void toolStripSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveAsProject();
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void toolStripSaveTemplateView_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeView.SelectedNode is SCADAViewNode)
                {
                    SCADAViewNode selectedNode = this.treeView.SelectedNode as SCADAViewNode;
                    SaveViewTemplateFrm frm = new SaveViewTemplateFrm
                    {
                        TemplateName = selectedNode.GraphSite.ViewTitle
                    };
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        if (!Directory.Exists(Application.StartupPath + "/ScadaTemplate/TemplateViews/" + frm.TemplateClassic))
                        {
                            Directory.CreateDirectory(Application.StartupPath + "/ScadaTemplate/TemplateViews/" + frm.TemplateClassic);
                        }
                        string[] files = Directory.GetFiles(Application.StartupPath + "/ScadaTemplate/TemplateViews/" + frm.TemplateClassic, "*.vtpl");
                        bool flag = false;
                        for (int i = 0; i < files.Length; i++)
                        {
                            if (Path.GetFileNameWithoutExtension(files[i]).Trim().ToLower() == frm.TemplateName.Trim().ToLower())
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            MessageBox.Show(this, "已经存在此名称的模板,请重新命名");
                        }
                        else
                        {
                            string[] textArray1 = new string[] { Application.StartupPath, "/ScadaTemplate/TemplateViews/", frm.TemplateClassic, "/", frm.TemplateName, ".vtpl" };
                            ((GraphControl)selectedNode.GraphSite.Site).SaveView(string.Concat(textArray1), frm.TemplateName);
                        }
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node is SCADAViewNode)
                {
                    SCADAViewNode node = e.Node as SCADAViewNode;
                    if (node.View != null)
                    {
                        node.View.Activate();
                    }
                    else
                    {
                        node.View = (WorkForm)this.mediator.CreateWorkForm(node.GraphSite.GraphInformation.Title, node.GraphSite.MapWidth, node.GraphSite.MapHeight, node.GraphSite);
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void treeViewTemplate_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if ((e.Node.Level == 2) && (e.Node.Tag != null))
            {
                try
                {
                    this.LoadTempViewToProject(e.Node.Tag.ToString());
                }
                catch (Exception exception1)
                {
                    MessageBox.Show(exception1.Message);
                }
            }
        }

        private void treeViewUser_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if ((e.Node.Tag != null) && (e.Node.Tag.GetType() == typeof(ScadaFlowUser)))
            {
                FlowUserManagerForm form = new FlowUserManagerForm
                {
                    EditUser = (ScadaFlowUser)e.Node.Tag
                };
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    FlowProject tag = (FlowProject)e.Node.Parent.Tag;
                    for (int i = 0; i < tag.FlowUsers.Count; i++)
                    {
                        if ((tag.FlowUsers[i].UserName.Trim() == form.EditUser.UserName.Trim()) && (tag.FlowUsers[i] != form.EditUser))
                        {
                            MessageBox.Show(this, "已经存在此用户名", "提示");
                            return;
                        }
                    }
                    e.Node.Text = form.EditUser.ToString();
                }
            }
        }

        private void 编辑名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeView.SelectedNode is SCADAViewNode)
                {
                    SCADAViewNode selectedNode = this.treeView.SelectedNode as SCADAViewNode;
                    EditViewDialog dialog = new EditViewDialog(selectedNode.View);
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        selectedNode.Text = dialog.ViewName;
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 编辑权限ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeView.SelectedNode is SCADAViewNode)
                {
                    SCADAViewNode selectedNode = this.treeView.SelectedNode as SCADAViewNode;
                    FlowUserPickerEditor editor = new FlowUserPickerEditor();
                    editor.InitUsers(ServiceViewsGlobel.Users, selectedNode.View.GraphControl.Abstract.RoleUsers);
                    if (editor.ShowDialog(this) == DialogResult.OK)
                    {
                        selectedNode.View.GraphControl.Abstract.RoleUsers = editor.GetCheckUsers();
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 编辑数据源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeViewConnections.SelectedNode is ScadaConnectionNode)
                {
                    FlowProjectNode parent = this.treeViewConnections.SelectedNode.Parent as FlowProjectNode;
                    ScadaConnectionNode selectedNode = this.treeViewConnections.SelectedNode as ScadaConnectionNode;
                    if (selectedNode.ScadaConnection.DataBaseType == DataBaseType.SQLServer)
                    {
                        SqlServerConnectionFrm frm = new SqlServerConnectionFrm
                        {
                            Connection = (SqlServer_Connection)selectedNode.ScadaConnection
                        };
                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {
                            ScadaConnectionNode node = new ScadaConnectionNode(frm.Connection)
                            {
                                ContextMenuStrip = this.contextMenuConnectionDelete
                            };
                            parent.Nodes.Add(node);
                        }
                    }
                    else if (selectedNode.ScadaConnection.DataBaseType == DataBaseType.Oracle)
                    {
                        OracleConnectionFrm frm2 = new OracleConnectionFrm
                        {
                            Connection = (Oracle_Connection)selectedNode.ScadaConnection
                        };
                        if (frm2.ShowDialog(this) == DialogResult.OK)
                        {
                            ScadaConnectionNode node = new ScadaConnectionNode(frm2.Connection)
                            {
                                ContextMenuStrip = this.contextMenuConnectionDelete
                            };
                            parent.Nodes.Add(node);
                        }
                    }
                    else if (selectedNode.ScadaConnection.DataBaseType == DataBaseType.MySQL)
                    {
                        MySqlConnectionFrm frm3 = new MySqlConnectionFrm
                        {
                            Connection = (MySQL_Connection)selectedNode.ScadaConnection
                        };
                        if (frm3.ShowDialog(this) == DialogResult.OK)
                        {
                            ScadaConnectionNode node = new ScadaConnectionNode(frm3.Connection)
                            {
                                ContextMenuStrip = this.contextMenuConnectionDelete
                            };
                            parent.Nodes.Add(node);
                        }
                    }
                    else if (selectedNode.ScadaConnection.DataBaseType == DataBaseType.SQLite)
                    {
                        SQLiteConnectionFrm frm4 = new SQLiteConnectionFrm
                        {
                            Connection = (SQLite_Connection)selectedNode.ScadaConnection
                        };
                        if (frm4.ShowDialog(this) == DialogResult.OK)
                        {
                            ScadaConnectionNode node = new ScadaConnectionNode(frm4.Connection)
                            {
                                ContextMenuStrip = this.contextMenuConnectionDelete
                            };
                            parent.Nodes.Add(node);
                        }
                    }
                    else if (selectedNode.ScadaConnection.DataBaseType == DataBaseType.SyBase)
                    {
                        SyBaseConnectionFrm frm5 = new SyBaseConnectionFrm
                        {
                            Connection = (SyBase_Connection)selectedNode.ScadaConnection
                        };
                        if (frm5.ShowDialog(this) == DialogResult.OK)
                        {
                            ScadaConnectionNode node = new ScadaConnectionNode(frm5.Connection)
                            {
                                ContextMenuStrip = this.contextMenuConnectionDelete
                            };
                            parent.Nodes.Add(node);
                        }
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 编辑用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.EditFlowUser();
        }

        private void 发布工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Publish();
        }

        private void 拷贝视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeView.SelectedNode is SCADAViewNode)
                {
                    Clipboard.Clear();
                    SCADAViewNode selectedNode = this.treeView.SelectedNode as SCADAViewNode;
                    Clipboard.SetDataObject(new DataObject("Scada.FlowGraphEngine.GraphicsMap.GraphSite.Copy", selectedNode.GraphSite));
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 全部打开视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeView.SelectedNode is FlowProjectNode)
                {
                    foreach (GraphAbstract @abstract in (this.treeView.SelectedNode as FlowProjectNode).Project.GraphList)
                    {
                        for (int i = 0; i < this.mediator.DockPanel.Documents.Count<DockContent>(); i++)
                        {
                            if ((this.mediator.DockPanel.Documents[i] is WorkForm) && ((this.mediator.DockPanel.Documents[i] as WorkForm).GraphControl.Abstract == @abstract))
                            {
                                this.mediator.DockPanel.Documents[i].Show();
                            }
                        }
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 全部关闭视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeView.SelectedNode is FlowProjectNode)
                {
                    foreach (GraphAbstract @abstract in (this.treeView.SelectedNode as FlowProjectNode).Project.GraphList)
                    {
                        for (int i = 0; i < this.mediator.DockPanel.Documents.Count<DockContent>(); i++)
                        {
                            if ((this.mediator.DockPanel.Documents[i] is WorkForm) && ((this.mediator.DockPanel.Documents[i] as WorkForm).GraphControl.Abstract == @abstract))
                            {
                                this.mediator.DockPanel.Documents[i].Hide();
                            }
                        }
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 删除工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.DeleteProject();
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 删除视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.DeleteView();
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 删除数据源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.treeViewConnections.SelectedNode is ScadaConnectionNode) && (MessageBox.Show(this, "是否要删除选中的数据源?", "删除提示", MessageBoxButtons.OKCancel) == DialogResult.Yes))
                {
                    ScadaConnectionNode selectedNode = this.treeViewConnections.SelectedNode as ScadaConnectionNode;
                    FlowProjectNode parent = this.treeViewConnections.SelectedNode.Parent as FlowProjectNode;
                    parent.Nodes.Remove(selectedNode);
                    parent.Project.ScadaConnections.Remove(selectedNode.ScadaConnection);
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 删除用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DeleteFlowUser();
        }

        private void 设为主视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeView.SelectedNode is SCADAViewNode)
                {
                    FlowProjectNode parent = this.treeView.SelectedNode.Parent as FlowProjectNode;
                    for (int i = 0; i < parent.Project.GraphList.Count; i++)
                    {
                        parent.Project.GraphList[i].Index = false;
                    }
                    SCADAViewNode selectedNode = this.treeView.SelectedNode as SCADAViewNode;
                    selectedNode.GraphSite.Index = true;
                    selectedNode.ForeColor = Color.Red;
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 添加MySql数据源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeViewConnections.SelectedNode is FlowProjectNode)
                {
                    FlowProjectNode selectedNode = this.treeViewConnections.SelectedNode as FlowProjectNode;
                    MySqlConnectionFrm frm = new MySqlConnectionFrm();
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        ScadaConnectionNode node = new ScadaConnectionNode(frm.Connection)
                        {
                            ContextMenuStrip = this.contextMenuConnectionDelete
                        };
                        selectedNode.Nodes.Add(node);
                        selectedNode.Project.ScadaConnections.Add(frm.Connection);
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 添加Oracle数据源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeViewConnections.SelectedNode is FlowProjectNode)
                {
                    FlowProjectNode selectedNode = this.treeViewConnections.SelectedNode as FlowProjectNode;
                    OracleConnectionFrm frm = new OracleConnectionFrm();
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        ScadaConnectionNode node = new ScadaConnectionNode(frm.Connection)
                        {
                            ContextMenuStrip = this.contextMenuConnectionDelete
                        };
                        selectedNode.Nodes.Add(node);
                        selectedNode.Project.ScadaConnections.Add(frm.Connection);
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 添加SQLit数据源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeViewConnections.SelectedNode is FlowProjectNode)
                {
                    FlowProjectNode selectedNode = this.treeViewConnections.SelectedNode as FlowProjectNode;
                    SQLiteConnectionFrm frm = new SQLiteConnectionFrm();
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        ScadaConnectionNode node = new ScadaConnectionNode(frm.Connection)
                        {
                            ContextMenuStrip = this.contextMenuConnectionDelete
                        };
                        selectedNode.Nodes.Add(node);
                        selectedNode.Project.ScadaConnections.Add(frm.Connection);
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 添加SqlServer数据源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeViewConnections.SelectedNode is FlowProjectNode)
                {
                    FlowProjectNode selectedNode = this.treeViewConnections.SelectedNode as FlowProjectNode;
                    SqlServerConnectionFrm frm = new SqlServerConnectionFrm();
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        ScadaConnectionNode node = new ScadaConnectionNode(frm.Connection)
                        {
                            ContextMenuStrip = this.contextMenuConnectionDelete
                        };
                        selectedNode.Nodes.Add(node);
                        selectedNode.Project.ScadaConnections.Add(frm.Connection);
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 添加SyBase数据源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeViewConnections.SelectedNode is FlowProjectNode)
                {
                    FlowProjectNode selectedNode = this.treeViewConnections.SelectedNode as FlowProjectNode;
                    SyBaseConnectionFrm frm = new SyBaseConnectionFrm();
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        ScadaConnectionNode node = new ScadaConnectionNode(frm.Connection)
                        {
                            ContextMenuStrip = this.contextMenuConnectionDelete
                        };
                        selectedNode.Nodes.Add(node);
                        selectedNode.Project.ScadaConnections.Add(frm.Connection);
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AddFlowUser();
        }

        private void 新增视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateView();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeView.SelectedNode is FlowProjectNode)
                {
                    FlowProjectNode selectedNode = this.treeView.SelectedNode as FlowProjectNode;
                    ProjectUpdatePasswordDialog dialog = new ProjectUpdatePasswordDialog(selectedNode.Project);
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        selectedNode.Project.Password = dialog.Password;
                        selectedNode.Project.Title = dialog.ProjectTitle;
                        selectedNode.Text = dialog.ProjectTitle;
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 应用背景到其它视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.treeView.SelectedNode is SCADAViewNode) && (FrmDialog.ShowDialog(this, "是否应用到其它视图?", "提示", true, false, false, true, null) == DialogResult.OK))
                {
                    SCADAViewNode selectedNode = this.treeView.SelectedNode as SCADAViewNode;
                    FlowProjectNode parent = this.treeView.SelectedNode.Parent as FlowProjectNode;
                    for (int i = 0; i < parent.Project.GraphList.Count; i++)
                    {
                        if (selectedNode.GraphSite.backImage != null)
                        {
                            parent.Project.GraphList[i].backImage = (Image)selectedNode.GraphSite.backImage.Clone();
                        }
                        parent.Project.GraphList[i].mBackgroundColor = selectedNode.GraphSite.mBackgroundColor;
                        parent.Project.GraphList[i].mBackgroundImagePath = selectedNode.GraphSite.mBackgroundImagePath;
                        parent.Project.GraphList[i].mBackgroundType = selectedNode.GraphSite.mBackgroundType;
                        parent.Project.GraphList[i].mGradientBottom = selectedNode.GraphSite.mGradientBottom;
                        parent.Project.GraphList[i].mGradientMode = selectedNode.GraphSite.mGradientMode;
                        parent.Project.GraphList[i].mGradientTop = selectedNode.GraphSite.mGradientTop;
                        parent.Project.GraphList[i].MapHeight = selectedNode.GraphSite.MapHeight;
                        parent.Project.GraphList[i].MapWidth = selectedNode.GraphSite.MapWidth;
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void 预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Debug();
        }

        private void 粘贴视图ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeView.SelectedNode is FlowProjectNode)
                {
                    GraphAbstract data = null;
                    IDataObject dataObject = Clipboard.GetDataObject();
                    if (dataObject.GetDataPresent("Scada.FlowGraphEngine.GraphicsMap.GraphSite.Copy"))
                    {
                        data = dataObject.GetData("Scada.FlowGraphEngine.GraphicsMap.GraphSite.Copy") as GraphAbstract;
                    }
                    if (data != null)
                    {
                        FlowProjectNode selectedNode = this.treeView.SelectedNode as FlowProjectNode;
                        CreateViewDialog dialog = new CreateViewDialog();
                        if (dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            data.GID = "V_" + GUIDTo16.GuidToLongID();
                            SCADAViewNode node = new SCADAViewNode
                            {
                                Text = dialog.ViewName,
                                ContextMenuStrip = this.contextMenuView,
                                View = (WorkForm)this.mediator.CreateWorkForm(dialog.ViewName, (float)dialog.PageWidth, (float)dialog.PageHeight)
                            };
                            node.View.GraphControl.Abstract = data;
                            node.View.GraphControl.Abstract.Site = node.View.GraphControl;
                            node.View.GraphControl.BasicLayer = data.Layers[0];
                            node.View.GraphControl.SaveViewResult = delegate (bool res, string msg) {
                                if (res)
                                {
                                    this.LoadTreeViewTemplate();
                                }
                                else
                                {
                                    MessageBox.Show(this, msg);
                                }
                            };
                            selectedNode.Nodes.Add(node);
                            selectedNode.Project.GraphList.Add(node.View.GraphControl.Abstract);
                        }
                        Clipboard.Clear();
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        // Properties
        public TabTypes TabType =>
            TabTypes.Project;

        public string TabIdentifier
        {
            get
            {
                return this.identifier;
            }
            set
            {
                this.identifier = value;
            }
        }

        public TreeNode SelectNode =>
            this.treeView.SelectedNode;

    }
}
