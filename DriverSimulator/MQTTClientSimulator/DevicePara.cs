using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MQTTClientSimulator
{
    public partial class DevicePara : Form
    {
        public DevicePara()
        {
            InitializeComponent();
            this.Load += DevicePara_Load;
        }

        private void DevicePara_Load(object sender, EventArgs e)
        {
            if(Pata!=null)
            {
                tbName.Text = Pata.name;
                tbMax.Text = Pata.SimulatorMax.ToString();
                tbMin.Text = Pata.SimulatorMin.ToString();
            }
          
        }

        public CommonMqttJsonPara Pata { set; get; }
        private void btStart_Click(object sender, EventArgs e)
        {
            if (Pata == null)
                Pata = new CommonMqttJsonPara()
                {
                    name = tbName.Text.Trim(),
                    SimulatorMax = int.Parse(tbMax.Text.Trim()),
                    SimulatorMin = int.Parse(tbMin.Text.Trim()),
                };
            else
            {
                Pata.name = tbName.Text.Trim();
                Pata.SimulatorMax = int.Parse(tbMax.Text.Trim());
                Pata.SimulatorMin = int.Parse(tbMin.Text.Trim());
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
