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
    public partial class IOParaCtrl : IOParaKernelControl
    {
        public IOParaCtrl()
        {
            InitializeComponent();
            cbParaType.SelectedIndex = 0;
        }
        public override void SetUIParameter(IO_SERVER server, IO_DEVICE device, IO_PARA para)
        {
            base.SetUIParameter(server, device, para);
            if (para.IO_PARASTRING != null && para.IO_PARASTRING != "")
            {


                ParaPack paraPack = new ParaPack(para.IO_PARASTRING);
                paraPack.SetCtrlValue(tb_JsonName, paraPack.GetValue("JSON名称"));
                paraPack.SetCtrlValue(nud_boardAddress, paraPack.GetValue("版子地址"));
                paraPack.SetCtrlValue(nud_boardIndex, paraPack.GetValue("版子索引号"));
                paraPack.SetCtrlValue(nud_port, paraPack.GetValue("端口号"));
                paraPack.SetCtrlValue(nud_PortIndex, paraPack.GetValue("端口索引号"));
                paraPack.SetCtrlValue(cb_DataType, paraPack.GetValue("数据类型"));
                paraPack.SetCtrlValue(nud_valueIndex, paraPack.GetValue("采集值索引号"));
                paraPack.SetCtrlValue(cbParaType, paraPack.GetValue("是否命令参数"));
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
            para.AddItem("JSON名称", tb_JsonName.Text);
            para.AddItem("版子地址", nud_boardAddress.Value.ToString("0"));
            para.AddItem("版子索引号", nud_boardIndex.Value.ToString("0"));
            para.AddItem("端口号", nud_port.Value.ToString("0"));
            para.AddItem("端口索引号", nud_PortIndex.Value.ToString("0"));
            para.AddItem("数据类型", cb_DataType.SelectedItem.ToString());
            para.AddItem("采集值索引号", nud_valueIndex.Value.ToString());
            para.AddItem("是否命令参数", cbParaType.SelectedItem.ToString());
            return para.ToString();


        }
        public override ScadaResult IsValidParameter()
        {
            if (cb_DataType.SelectedItem == null)
                return new ScadaResult(false, "请选择数据类型");
            if (tb_JsonName.Text.Trim() == null)
                return new ScadaResult(false, "请输入JSON名称");
            if (cbParaType.SelectedItem == null)
                return new ScadaResult(false, "请设置是否命令参数");
            return new ScadaResult();
        }
    }
}
