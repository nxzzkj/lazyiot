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
    public partial class KeyBord : UIForm
    {
        public KeyBord()
        {
            InitializeComponent();
        }

        private void uiCheckBox1_ValueChanged(object sender, bool value)
        {
            
        }
        //用户点击字母
        private void AlphaClick(object sender, EventArgs e)
        {
            UIButton uIButton = (UIButton)sender;
            uiTextBox.Text += uiCheckBox1.Checked ? uIButton.Text.Trim().ToUpper() : uIButton.Text.Trim().ToLower();
        }

        private void NumberClick(object sender, EventArgs e)
        {
            UIButton uIButton = (UIButton)sender;
            uiTextBox.Text += uIButton.Text.Trim();
        }

        private void uiButton43_Click(object sender, EventArgs e)
        {
            if(uiTextBox.Text.Length>0)
            {
                uiTextBox.Text = uiTextBox.Text.Substring(0,uiTextBox.Text.Length-1);
            }
        }

        private void uiButton44_Click(object sender, EventArgs e)
        {
            uiTextBox.Text = "";
        }
        public string InputText
        {
            get { return uiTextBox.Text.Trim(); }
            set { uiTextBox.Text = value; }
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
