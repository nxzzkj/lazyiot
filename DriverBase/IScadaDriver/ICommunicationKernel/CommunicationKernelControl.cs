using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scada.Kernel
{
    public partial class CommunicationKernelControl : UserControl
    {
      
        /// <summary>
        /// 保存用户的界面参数
        /// </summary>
        public string ParameterString = "";
        public CommunicationKernelControl()
        {
            InitializeComponent();
            ParameterString = "";
        }
        /// <summary>
        /// 设置界面参数
        /// </summary>
        /// <param name="para"></param>
        public virtual void SetUIParameter(string para)
        {
            
            ParameterString = para;
        }
        //从界面返回用户设置的参数
        public virtual string GetUIParameter()
        {
            return ParameterString;
        }
        public virtual ScadaResult IsValidParameter()
        {
            return new ScadaResult(true,"参数有效");
        }

    }
}
