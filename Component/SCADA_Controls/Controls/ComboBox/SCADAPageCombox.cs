using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Controls.Controls
{
    /// <summary>
    /// 定义一个通用的页面显示数量的控件
    /// </summary>
    public class SCADAPageCombox : UCCombox
    {
        public SCADAPageCombox()
        {
            this.Load += SCADAPageCombox_Load;

        }

        private void SCADAPageCombox_Load(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> lstCom = new List<KeyValuePair<string, string>>();

            lstCom.Add(new KeyValuePair<string, string>("100", "显示最近100条"));
            lstCom.Add(new KeyValuePair<string, string>("200", "显示最近200条"));
            lstCom.Add(new KeyValuePair<string, string>("300", "显示最近300条"));
            lstCom.Add(new KeyValuePair<string, string>("400", "显示最近400条"));
            lstCom.Add(new KeyValuePair<string, string>("500", "显示最近500条"));
            lstCom.Add(new KeyValuePair<string, string>("600", "显示最近600条"));
            lstCom.Add(new KeyValuePair<string, string>("700", "显示最近700条"));
            lstCom.Add(new KeyValuePair<string, string>("800", "显示最近800条"));
            lstCom.Add(new KeyValuePair<string, string>("900", "显示最近900条"));
            lstCom.Add(new KeyValuePair<string, string>("1000", "显示最近1000条"));
            this.Source = lstCom;
            this.SelectedIndex = 0;
        }
    }
}
