
using Scada.FlowGraphEngine;
using ScadaFlowDesign.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScadaFlowDesign.Control
{
  public   class SCADAShapeButton:PictureBox
    {
        public SCADAShapeButton()
        {

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);//双缓冲

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true); //禁止擦除背景.
            this.UpdateStyles();
            this.MouseDown += SCADAShapeButton_MouseDown;
            this.MouseUp += SCADAShapeButton_MouseUp;
            this.Paint += SCADAShapeButton_Paint;
            this.MouseDoubleClick += SCADAShapeButton_MouseDoubleClick;

        }

        private void SCADAShapeButton_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selected = false;
            this.Parent.Cursor = Cursors.Default;
        }

        private void SCADAShapeButton_Paint(object sender, PaintEventArgs e)
        {
        
            if(selected)
            {
                e.Graphics.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Black,4),e.ClipRectangle);
            }
        }

        private bool selected = false;

        private void SCADAShapeButton_MouseUp(object sender, MouseEventArgs e)
        {
            selected = false;
            this.Invalidate();
        }
     

        private void SCADAShapeButton_MouseDown(object sender, MouseEventArgs e)
        {
            selected = true;
            this.Invalidate();
            if(this.Image!=null)
            {
                Bitmap bmp = (Bitmap)this.Image;
                this.FindForm().Cursor = new Cursor(bmp.GetHicon());
            }
        
        }
        public IntPtr GetCursor()
        {
            if (this.Image != null)
            {
                Bitmap bmp = (Bitmap)this.Image;
                return bmp.GetHicon();
            }
            return IntPtr.Zero;
        }

        private ShapeElement mShapeElement = ShapeElement.None;
        public ShapeElement ShapeElement
        {
            set { mShapeElement = value; }
            get { return mShapeElement; }
        }
       
    }
}
