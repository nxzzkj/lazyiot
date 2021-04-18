using Scada.FlowGraphEngine.GraphicsShape;

namespace ScadaFlowDesign
{
    partial class WorkForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkForm));
            this.graphControl = new Scada.FlowGraphEngine.GraphicsMap.GraphControl();
            this.SuspendLayout();
            // 
            // graphControl
            // 
            this.graphControl.Abstract = new Scada.FlowGraphEngine.GraphicsMap.GraphAbstract();
            this.graphControl.AllowAddShape = true;
            this.graphControl.AllowDeleteShape = true;
            this.graphControl.AllowMoveShape = true;
            this.graphControl.AutoScroll = true;
            this.graphControl.AutoScrollMinSize = new System.Drawing.Size(1200, 800);
            this.graphControl.BackgroundColor = System.Drawing.Color.White;
            this.graphControl.BackgroundImagePath = null;
            this.graphControl.BackgroundType = Scada.FlowGraphEngine.GraphicsMap.CanvasBackgroundType.FlatColor;
 
            this.graphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphControl.EnableContextMenu = true;
            this.graphControl.EnableLayout = false;
            this.graphControl.EnableToolTip = false;
            this.graphControl.FileName = null;
            this.graphControl.GradientBottom = System.Drawing.Color.White;
            this.graphControl.GradientTop = System.Drawing.Color.LightSteelBlue;
            this.graphControl.GridSize = 20;
            this.graphControl.Layers = null;
            this.graphControl.LinearGradientMode = SVGLinearMode.无渐变;
            this.graphControl.Location = new System.Drawing.Point(0, 0);
            this.graphControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.graphControl.Name = "graphControl";
            this.graphControl.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("graphControl.PageSettings")));
            this.graphControl.ShowGrid = true;
            this.graphControl.Size = new System.Drawing.Size(990, 743);
            this.graphControl.Snap = true;
            this.graphControl.TabIndex = 0;
            this.graphControl.Text = "graphControl1";
            this.graphControl.Zoom = 1F;
            this.graphControl.OnShapeAdded += new Scada.FlowGraphEngine.GraphicsMap.ShapeInfo(this.graphControl_OnShapeAdded);
            this.graphControl.OnShapeRemoved += new Scada.FlowGraphEngine.GraphicsMap.ShapeInfo(this.graphControl_OnShapeRemoved);
            this.graphControl.OnClear += new System.EventHandler(this.graphControl_OnClear);
          
            this.graphControl.OnSavingDiagram += new Scada.FlowGraphEngine.GraphicsMap.FileInfo(this.graphControl_OnSavingDiagram);
            this.graphControl.OnDiagramOpened += new Scada.FlowGraphEngine.GraphicsMap.FileInfo(this.graphControl_OnDiagramOpened);
            this.graphControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.graphControl_MouseDoubleClick);
            // 
            // WorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 743);
            this.Controls.Add(this.graphControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "WorkForm";
            this.Text = "WorkForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Scada.FlowGraphEngine.GraphicsMap.GraphControl graphControl;
    }
}