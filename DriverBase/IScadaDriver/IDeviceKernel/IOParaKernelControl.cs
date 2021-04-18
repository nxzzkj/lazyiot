using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Model;

namespace Scada.Kernel
{
    public partial class IOParaKernelControl : UserControl
    {
        public IOParaKernelControl()
        {
            InitializeComponent();
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            ParaString = "";
        }

        /// <summary>
        /// 最后返回的参数配置界面列表
        /// </summary>
        public virtual string ParaString
        {
            set;
            get;
        }
        public IO_SERVER Server = null;
        public IO_DEVICE Device = null;
        public IO_PARA Para = null;
        /// <summary>
        /// 设置界面参数
        /// </summary>
        /// <param name="para"></param>
        public virtual void SetUIParameter(IO_SERVER server, IO_DEVICE device, IO_PARA para)
        {
           
            Server = server;
            Device = device;
            Para = para;
            ParaString = para.IO_PARASTRING;

        }
        //从界面返回用户设置的参数
        public virtual string GetUIParameter()
        {
            return "";
        }
        public virtual ScadaResult IsValidParameter()
        {
            return new ScadaResult(false,"请设置参数");
        }
        

    }
}
