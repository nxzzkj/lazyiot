using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Kernel;
using Scada.Model;

namespace MQTTnet
{
    public partial class GasIOParaCtrl : IOParaKernelControl
    {
        public GasIOParaCtrl()
        {
            InitializeComponent();
            cbDataType.SelectedIndex = 0;
        }
        public override void SetUIParameter(IO_SERVER server, IO_DEVICE device, IO_PARA para)
        {
            base.SetUIParameter(server,device,para);
            if(para.IO_PARASTRING!=null&& para.IO_PARASTRING!="")
            {
                ParaPack paraPack = new ParaPack(para.IO_PARASTRING);
                paraPack.SetCtrlValue(tb_JsonName, paraPack.GetValue("IO标识"));
                paraPack.SetCtrlValue(nudTime, paraPack.GetValue("时间值索引"));
                paraPack.SetCtrlValue(cbDataType, paraPack.GetValue("数据类型"));
                paraPack.SetCtrlValue(nud_valueIndex, paraPack.GetValue("采集值索引"));
                paraPack.SetCtrlValue(tbCmdValue, paraPack.GetValue("命令默认值"));
            }
            this.ParaString = para.IO_PARASTRING;
        }
        public override string GetUIParameter()
        {
            return GetParament();
        }
        public string GetParament()
        {
            ParaPack para = new ParaPack();
            para.AddItem("IO标识", tb_JsonName.Text);
            para.AddItem("时间值索引", nudTime.Value.ToString("0"));
            para.AddItem("数据类型", cbDataType.SelectedItem.ToString());
            para.AddItem("采集值索引", nud_valueIndex.Text);
            para.AddItem("命令默认值", tbCmdValue.Text);
            return para.ToString();


        }
        public override ScadaResult IsValidParameter()
        {
            if (cbDataType.SelectedItem == null)
                return new ScadaResult(false, "请选择数据类型");
            if (tb_JsonName.Text.Trim() == null)
                return new ScadaResult(false, "请输入IO标识");

            return new ScadaResult();
        }

        private void cbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbDataType.SelectedIndex==0)
            {
                panel2.Visible = false;
                panel1.Visible = true;
                panel5.Visible = true;
            }
            else
            {
                panel2.Visible = true;
                panel1.Visible = false;
                panel5.Visible = false;
            }
        }
    }
}
