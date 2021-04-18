using System;
using Scada.Kernel;
using Scada.Model;

namespace Modbus.ModbusAnalysis
{
    public partial class IOParaCtrl : IOParaKernelControl
    {
        public IOParaCtrl()
        {
            InitializeComponent();
        
        }
        public override void SetUIParameter(IO_SERVER server, IO_DEVICE device, IO_PARA para)
        {
            this.modbusSetCtrl1.InitCtrl();
            this.modbusSetCtrl1.SetParament(para.IO_PARASTRING);
            this.ParaString = para.IO_PARASTRING;


        }
        public override string GetUIParameter()
        {
            this.ParaString = this.modbusSetCtrl1.GetParament();
            return this.ParaString;
        }
        public override ScadaResult IsValidParameter()
        {
            return this.modbusSetCtrl1.IsValidParameter();
        }

       
    }
}
