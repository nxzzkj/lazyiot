using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOManager.Controls
{
    public partial class TextBoxEx : TextBox
    {
        public TextBoxEx()
        {
            this.KeyPress += (s, e) => {
                //if (e.KeyChar == Convert.ToChar(System.Windows.Forms.Keys.Enter))
                if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z')|| e.KeyChar == Convert.ToChar(System.Windows.Forms.Keys.Back)|| e.KeyChar == Convert.ToChar(System.Windows.Forms.Keys.Delete) || e.KeyChar == '_')
                {

                }
                else
                {
                    e.Handled = true;
               
                }
            };
        }

       
 
    }
    public partial class NumberTextBoxEx : TextBox
    {
        public NumberTextBoxEx()
        {
            this.KeyPress += (s, e) => {
                //if (e.KeyChar == Convert.ToChar(System.Windows.Forms.Keys.Enter))VK_DECIMAL
                if ((e.KeyChar >= '0' && e.KeyChar <= '9') ||  e.KeyChar == Convert.ToChar(System.Windows.Forms.Keys.Back) || e.KeyChar == Convert.ToChar(System.Windows.Forms.Keys.Delete)|| e.KeyChar == '.'|| e.KeyChar == '-')//SUBSTRACT
                {

                }
                else
                {
                    e.Handled = true;

                }
            };
        }
        public override string Text
        {
            get
            {
               
                return base.Text;
            }

            set
            {
                base.Text = value;
                if (base.Text == "")
                    base.Text = "0";
            }
        }


    }
}
