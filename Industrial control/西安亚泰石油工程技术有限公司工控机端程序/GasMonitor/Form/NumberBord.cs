using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasMonitor
{
    public partial class NumberBord : UIForm
    {
        public NumberBord()
        {
            InitializeComponent();
        }

      
        

        private void NumberClick(object sender, EventArgs e)
        {
            string text = uiTextBox.Text;
            UIButton uIButton = (UIButton)sender;
            text += uIButton.Text.Trim();
            uiTextBox.Text = Convert.ToDecimal(text).ToString();
        }

     

        private void uiButton44_Click(object sender, EventArgs e)
        {
            uiTextBox.Text = "0";
        }
        public decimal InputNumber
        {
            get { return  decimal.Parse(uiTextBox.Text.Trim()); }
            set { uiTextBox.Text = value.ToString(); }
        }

        private void uiButtonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
