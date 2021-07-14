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
    public partial class AddDevice : Form
    {
        public AddDevice()
        {
            InitializeComponent();
        }
        public CommonMqttJsonObject Device { set; get; }
        private void AddDevice_Load(object sender, EventArgs e)
        {
            if (Device == null)
            {
                Device = new CommonMqttJsonObject();
            }
            this.dataGridViewPara.AutoGenerateColumns = false;
            this.dataGridViewPara.DataSource = Device.paras;
            this.tbDeviceID.Text = Device.device.uid;
            this.tbName.Text = Device.device.name;
            this.tbClientID.Text = Device.device.ClientID;
            this.tbUpdateCycle.Text = Device.device.UpdateCycle.ToString();

          

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewPara.SelectedRows.Count <= 0)
                return;
            DevicePara form = new DevicePara();
            form.Pata = (CommonMqttJsonPara)this.dataGridViewPara.SelectedRows[0].DataBoundItem;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (Device == null)
                {
                    Device = new CommonMqttJsonObject();
                }
            }
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            DevicePara form = new DevicePara();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (Device == null)
                {
                    Device = new CommonMqttJsonObject();
                }
                Device.paras.Add(form.Pata);
                this.dataGridViewPara.DataSource = null;
                this.dataGridViewPara.DataSource = Device.paras;
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewPara.SelectedRows.Count <= 0)
                return;

            Device.paras.Remove((CommonMqttJsonPara)this.dataGridViewPara.SelectedRows[0].DataBoundItem);
            this.dataGridViewPara.DataSource = null;
            this.dataGridViewPara.DataSource = Device.paras;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Device.device.name = this.tbName.Text.Trim();
            Device.device.uid = this.tbDeviceID.Text.Trim();
            Device.device.ClientID = this.tbClientID.Text.Trim();
            Device.device.UpdateCycle = int.Parse(this.tbUpdateCycle.Text.Trim());
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Device != null && Device.paras.Count <= 0)
                Device = null;
            this.DialogResult = DialogResult.Cancel;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbDeviceID.Text = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tbClientID.Text = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
        }
    }
}
