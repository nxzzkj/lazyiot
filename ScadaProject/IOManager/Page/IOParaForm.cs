 
using Scada.Model;
using IOManager.Controls;
using System;

using IOManager.Core;
using Scada.Controls;

namespace IOManager.Page
{
    public partial class IOParaForm : DockContent, ICobaltTab
    {
        public IOParaForm(Mediator m)
        {
            InitializeComponent();
            mediator = m;
        }
        public IOListView IOListView
        {
            get { return this.ioListView; }
        }
        public  void AddListViewItem(IOListViewItem lvi)
        {
            ioListView.AddListViewItem(lvi);
        }
        public IOListViewItem GetListViewItem(IO_PARA para)
        {
            for(int i=0;i< ioListView.ListView.Items.Count;i++)
            {
                IOListViewItem item = ioListView.ListView.Items[i] as IOListViewItem;
                if(item.Para== para)
                {
                    return item;
                }
            }
            return null;
        }
        private Mediator mediator = null;
        private string identifier;
        /// <summary>
        /// 异步初始化ListView控件
        /// </summary>
        /// <param name="device"></param>
        public  void InitListView(IO_SERVER Server, IO_COMMUNICATION Communication, IO_DEVICE Device)
        {
            this.ioListView.ListView.Items.Clear();
            this.ioListView.Server = Server;
            this.ioListView.Communication = Communication;
            this.ioListView.Device = Device;
            this.ioListView.IOPath= Server.SERVER_NAME + "\\" + Communication.IO_COMM_NAME + "\\" + Device.IO_DEVICE_NAME;
            try
            {
                for (int i = 0; i < Device.IOParas.Count; i++)
                {
                    IOListViewItem lvi = new IOListViewItem(Device.IOParas[i]);
                    this.ioListView.AddListViewItem(lvi);
                }
            }
            catch(Exception ex)
            {
                  FormManager.DisplayException(ex);
            }
           
        }
        public TabTypes TabType
        {
            get
            {
                return TabTypes.PointArea;
            }
        }
        public string TabIdentifier
        {
            get
            {
                return identifier;
            }
            set
            {
                identifier = value;
            }
        }
    }
}
