using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMonitor
{
    public delegate void ChannelShowOrHide(bool res);
    public class ChannelElement
    {
        public event ChannelShowOrHide ShowOrHideChanged;
        public ChannelElement()
        {
            ReceiveCachec = new ReceiveCachec();
            ReceiveCachec.MaxNumber = 100;
        }
        public string Name { set; get; }
        public string Id { set; get; }
        public string Text { set; get; }
        /// <summary>
        /// 通道绑定的设备地址
        /// </summary>

        public string BindingArress { set; get; }

        public ReceiveCachec ReceiveCachec
        { set; get; }
        public override string ToString()
        {
            return Name.ToString();
        }
        private bool _ShowOrHide = true;
        public bool ShowOrHide
        {
            get { return _ShowOrHide; }
            set
            {
                _ShowOrHide = value;
                if (ShowOrHideChanged != null)
                {
                    ShowOrHideChanged(value);
                }
            }
        }
    }


}
