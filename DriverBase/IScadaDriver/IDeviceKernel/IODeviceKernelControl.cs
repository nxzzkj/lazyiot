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
    public partial class IODeviceKernelControl : UserControl
    {
        public IODeviceKernelControl()
        {
            InitializeComponent();
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
        /// <summary>
        /// 设置界面参数
        /// </summary>
        /// <param name="para"></param>
        public virtual void SetUIParameter(IO_SERVER server, IO_DEVICE device)
        {
            Server = server;
            Device = device;
               ParaString = device.IO_DEVICE_PARASTRING;
        }
        //从界面返回用户设置的参数
        public virtual string GetUIParameter()
        {
            return "";
        }
        public virtual ScadaResult IsValidParameter()
        {
            return new ScadaResult();
        }
        public virtual ScadaResult ControlIsValidParameter()
        {
            return new ScadaResult();
        }
    }
}
