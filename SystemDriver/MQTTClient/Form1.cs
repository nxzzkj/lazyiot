using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebKit;

namespace MQTTClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebKitBrowser Browser = new WebKitBrowser();
            Browser.Url = new Uri("http://39.105.48.206:100/Scada/ScadaFlow?id=15");
            Browser.Dock = DockStyle.Fill;
          
            this.Controls.Add(Browser);
        }
    }
}
