using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scada.Controls
{
    public partial class ColorButton : Button
    {
        public ColorButton()
        {
            InitializeComponent();
        }
        private Color mColor = Color.White;
        public Color Color
        {
            set { mColor = value;
                this.BackColor = mColor;
            }
            get { return mColor; }
        }
    }
}
