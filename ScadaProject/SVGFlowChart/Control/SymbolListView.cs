using Scada.FlowGraphEngine;
using Scada.FlowGraphEngine.GraphicsShape;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScadaFlowDesign.Control
{
    
    public class SymbolListView : ListView
    {
        public event EventHandler OnSelectSymbol;
        public SymbolGroup FieldSymbol = null;
        public SymbolListView() :
            base()
        {
            this.View = View.Tile;
            this.Font = new Font("宋体",9);
            

            this.GridLines = true;
            this.MultiSelect = false;
            this.OwnerDraw = true;
         
            this.Columns.Add("符号");
            this.DrawItem += SymbolListView_DrawItem;

            this.MouseDoubleClick += SymbolListView_MouseDoubleClick;
            this.MouseDown += SymbolListView_MouseDown;

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);//双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true); //禁止擦除背景.
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true); //禁止擦除背景.
            this.UpdateStyles();
         

        }
 

        private void SymbolListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            Pen selectPen = Pens.Black;
        
            if (e.Item.Selected)
            {
                selectPen = Pens.Red;
            }
            Rectangle r = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
         
          
            Graphics g = e.Graphics;
            ScadaSymbol_Shape symbol = (ScadaSymbol_Shape)e.Item.Tag;

 
            if (symbol.Paths != null && symbol.Paths.Count > 0&& symbol.Bmp== null)
            {
                symbol.Bmp = new Bitmap(e.Bounds.Width, e.Bounds.Height);
                RectangleF mr = new RectangleF(0,0, e.Bounds.Width, e.Bounds.Height);
                Graphics mg = Graphics.FromImage(symbol.Bmp);
                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.AddRectangle(r);
                symbol.Paint("", mg, mr, 0,new SVG_Color(Color.Red), SVTFillType.Original, null);
                mg.Dispose();
                g.DrawImage(symbol.Bmp, e.Bounds.X, e.Bounds.Y);


            }
            else
            {
                g.DrawImage(symbol.Bmp, e.Bounds.X, e.Bounds.Y);
            }
          

            g.DrawRectangle(selectPen, r);

        }

       

        private void SymbolListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {


                ListViewItem liv = this.GetItemAt(e.X, e.Y);
                if (liv != null)
                {
                    SelectSymbol = (ScadaSymbol_Shape)liv.Tag;
                    if (liv != null)
                    {

                        if (OnSelectSymbol != null)
                        {
                            OnSelectSymbol(SelectSymbol, e);
                        }
                    }

                }
                else
                {
                    this.Parent.Cursor = Cursors.Default;
                }
            }
            else
            {
                this.Parent.Cursor = Cursors.Default;
                SelectSymbol = null;
            }
        }

        private void SymbolListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Parent.Cursor = Cursors.Default;
            SelectSymbol = null;
        }
     
    
        public ScadaSymbol_Shape SelectSymbol = null;
        public void InitItems()
        {
            if (FieldSymbol == null)
                return;
            
            this.Items.Clear();
            int num = 1;
            foreach(ScadaSymbol_Shape s in FieldSymbol.Shapes)
            {
                ListViewItem listViewItem = new ListViewItem(num.ToString());
                listViewItem.Font = new Font("宋体", 8);
                listViewItem.Tag = s;
              
                this.Items.Add(listViewItem);
                num++;
            }
           
        }
 

      

    }
}
