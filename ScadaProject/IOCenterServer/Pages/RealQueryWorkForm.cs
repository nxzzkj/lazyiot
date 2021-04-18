using ScadaCenterServer.Controls;
using ScadaCenterServer.Core;
using Scada.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Scada.DBUtility;
using Scada.Model;

namespace ScadaCenterServer.Pages
{
    public partial class RealQueryWorkForm : DockForm
    {
        private IO_DEVICE Device = null;
        private IO_SERVER Server = null;
        private IO_COMMUNICATION Communication = null;
        List<IOParaSeries> IOSeries = new List<IOParaSeries>();


        private int SeriesIndex = -1;
        
        public void InitDevice(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device)
        {
          
            Device = device;
            Server = server;
            Communication = communication;
            SeriesIndex = -1;
            InitSeires();
            InitListView();

            if (Device != null)
            {
                //获取读取实时值
                IOCenterManager.QueryFormManager.ReadRealDevice(this.Server, this.Communication, this.Device); 
                TreeNode[] finders = this.hsComboBox.TreeView.Nodes.Find(Device.IO_DEVICE_ID, true);
                if (finders.Length > 0)
                {
                    IoDeviceTreeNode node = finders[0] as IoDeviceTreeNode;
                    this.hsComboBox.ShowItem(node);
                }
                realtimer.Interval = Device.IO_DEVICE_UPDATECYCLE * 1000;
   
            }
           
         
            if (Device != null)
            {
                realtimer.Interval = this.Device.IO_DEVICE_UPDATECYCLE * 1000;
                realtimer.Tick += Realtimer_Tick;
                realtimer.Start();
            }



        }
        private void InitSeires()
        {
            SeriesIndex = -1;
            IOSeries.Clear();
            this.RealChart.Series.Clear();
            if (Device != null)
            {
                for (int i = 0; i < Device.IOParas.Count; i++)
                {
                    if (Device.IOParas[i].IO_POINTTYPE.Trim() == "模拟量")
                    {
                        IOParaSeries s = new IOParaSeries(this.Server, this.Communication, this.Device, Device.IOParas[i]);
                        IOSeries.Add(s);

                    }

                }
            }
        }

        public RealQueryWorkForm()
        {
            InitializeComponent();
            this.RealChart.ChartAreas[0].IsSameFontSizeForAllAxes = true;
            Control.CheckForIllegalCrossThreadCalls = false;
            this.CloseButton = false;
            this.Load += QueryWorkForm_Load;
        }

        private  void QueryWorkForm_Load(object sender, EventArgs e)
        {
            this.RealChart.ChartAreas[0].AxisX.Title = "时间";
            this.RealChart.ChartAreas[0].AxisX.LineColor = Color.Black;
            this.RealChart.ChartAreas[0].AxisX.LineWidth = 2;
            this.RealChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
            this.RealChart.ChartAreas[0].AxisY.Title = "实时值";
            this.RealChart.ChartAreas[0].AxisY.LineColor = Color.Black;
            this.RealChart.ChartAreas[0].AxisY.LineWidth = 2;
            this.RealChart.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Auto;
            LoadTreeProject();




        }
        public async void LoadTreeProject()
        {
        
            if (this.hsComboBox.TreeView.Nodes.Count <= 0)
            {
                await Task.Run(() =>
                {
                    this.BeginInvoke(new EventHandler(delegate {

                        try
                        {
                            this.hsComboBox.TreeView.Nodes.Clear();

                            int num = IOCenterManager.IOProject.Servers.Count + IOCenterManager.IOProject.Communications.Count + IOCenterManager.IOProject.Devices.Count;
                            TreeNode mainNode = new TreeNode();
                            mainNode.ImageIndex = 0;
                            mainNode.SelectedImageIndex = 0;
                            mainNode.Text = PubConstant.Product;
                           
                            ///加载采集站
                            for (int i = 0; i < IOCenterManager.IOProject.Servers.Count; i++)
                            {

                                IoServerTreeNode serverNode = new IoServerTreeNode();
                                serverNode.Server = IOCenterManager.IOProject.Servers[i];
                                serverNode.InitNode();
                                List<Scada.Model.IO_COMMUNICATION> serverComms = IOCenterManager.IOProject.Communications.FindAll(x => x.IO_SERVER_ID == IOCenterManager.IOProject.Servers[i].SERVER_ID);
                                for (int c = 0; c < serverComms.Count; c++)//通道
                                {
                                    IoCommunicationTreeNode commNode = new IoCommunicationTreeNode();
                                    commNode.Communication = serverComms[c];
                                    commNode.Server = IOCenterManager.IOProject.Servers[i];
                                    commNode.InitNode();
                                    List<Scada.Model.IO_DEVICE> commDevices = IOCenterManager.IOProject.Devices.FindAll(x => x.IO_SERVER_ID == IOCenterManager.IOProject.Servers[i].SERVER_ID && x.IO_COMM_ID == serverComms[c].IO_COMM_ID);
                                    for (int d = 0; d < commDevices.Count; d++)//设备
                                    {
                                        IoDeviceTreeNode deviceNode = new IoDeviceTreeNode();
                                        deviceNode.Device = commDevices[d];
                                        deviceNode.Server = IOCenterManager.IOProject.Servers[i];
                                        deviceNode.Communication = serverComms[c];
                                        //挂载右键菜单
                                      
                                        deviceNode.InitNode();
                                        commNode.Nodes.Add(deviceNode);
                                       
                                    }
                                  
                                    serverNode.Nodes.Add(commNode);
                                }

                                mainNode.Nodes.Add(serverNode);
                             
                            }
                            mainNode.Expand();
                            this.hsComboBox.TreeView.Nodes.Add(mainNode);

                          
                        }
                        catch 
                        {
                            
                        }
                    }));
                });
            }
        }
        Random random = new Random(255);
        private async void Realtimer_Tick(object sender, EventArgs e)
        {

 
        await    Task.Run(() =>
            {
                try
                {

                    //获取读取实时值
                    IOCenterManager.QueryFormManager.ReadRealDevice(this.Server, this.Communication, this.Device);

                    for (int i = 0; i < this.listView.Items.Count; i++)
                    {
                        IORealListViewItem lvi = this.listView.Items[i] as IORealListViewItem;
                        lvi.RefreshParaValue();

                    }
                    this.listView.Refresh();
                    ///刷新曲线数据
                    for (int i = 0; i < IOSeries.Count; i++)
                    {
                        IOSeries[i].RefreshRealData();
                    }

                }
                catch (Exception ex)
                {
                    IOCenterManager.QueryFormManager.DisplyException(ex);

                }
            });

        }

        public RealQueryWorkForm(Mediator m) : base(m)
        {

            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.Load += QueryWorkForm_Load;

        }
        public override TabTypes TabType
        {
            get
            {
                return TabTypes.RealTimeData;
            }
        }

        private void hsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            if (hsComboBox.SelectedItem != null)
            {

                IoDeviceTreeNode node = hsComboBox.SelectedItem as IoDeviceTreeNode;
                //如果选择的还是同一个设备，就不做处理
                if (this.Device != node.Device)
                {
                    this.realtimer.Stop();
                    this.Server = node.Server;
                    this.Communication = node.Communication;
                    this.Device = node.Device;
                     this.realtimer.Interval = this.Device.IO_DEVICE_UPDATECYCLE * 1000;
                 
                 
          
                    InitListView();
                    InitSeires();
                    this.realtimer.Start();

                }

            }

        }
        private void InitListView()
        {
            if (Device != null)
            {

          
                this.listView.Items.Clear();
                for (int i = 0; i < Device.IOParas.Count; i++)
                {
                    IORealListViewItem lvi = new IORealListViewItem(Device.IOParas[i]);
                    this.listView.Items.Add(lvi);
                }
                //处理实时曲线
                this.RealChart.Series.Clear();
               
            }
        }



        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                LoadTreeProject();
                IORealListViewItem lvi = listView.SelectedItems[0] as IORealListViewItem;
                this.RealChart.Series.Clear();
                this.RealChart.ChartAreas.Clear();
                this.RealChart.ChartAreas.Add(new ChartArea() {  Name= "IOChartArea" });
                
                this.RealChart.ChartAreas[0].AxisX.Title = "时间";
                this.RealChart.ChartAreas[0].AxisX.LineColor = Color.Black;
                this.RealChart.ChartAreas[0].AxisX.LineWidth = 2;
                this.RealChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
                this.RealChart.ChartAreas[0].AxisY.Title = lvi.Para.IO_LABEL.Trim();
                this.RealChart.ChartAreas[0].AxisY.LineColor = Color.Black;
                this.RealChart.ChartAreas[0].AxisY.LineWidth = 2;
                this.RealChart.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Auto;
                
                this.mediator.IOPropeitesForm.SetPara(this.Server, this.Communication, this.Device, lvi.Para);

                int index = IOSeries.FindIndex(x => x.Name.Trim() == lvi.Para.IO_NAME.Trim());
                if (index >=0)
                {
                    this.SeriesIndex = index;
                }
                IOSeries[this.SeriesIndex].ChartArea = "IOChartArea";
                this.RealChart.Series.Add(IOSeries[this.SeriesIndex]);

            }
        }
        //切换下条曲线
        private void ucArrowNext_Click(object sender, EventArgs e)
        {
            if (this.SeriesIndex < this.IOSeries.Count - 1)
            {
                this.SeriesIndex++;
            }
            else
            {
                this.SeriesIndex = this.IOSeries.Count - 1;
            }

            if (this.SeriesIndex >= 0)
            {
                IOSeries[this.SeriesIndex].ChartArea = "IOChartArea";
                this.RealChart.Series.Clear();
                this.RealChart.ChartAreas.Clear();
                this.RealChart.ChartAreas.Add(new ChartArea() { Name = "IOChartArea" });
                this.RealChart.Series.Add(IOSeries[this.SeriesIndex]);
                this.RealChart.ChartAreas[0].AxisX.Title = "时间";
                this.RealChart.ChartAreas[0].AxisX.LineColor = Color.Black;
                this.RealChart.ChartAreas[0].AxisX.LineWidth = 2;
                this.RealChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
                this.RealChart.ChartAreas[0].AxisY.Title = IOSeries[this.SeriesIndex].LegendText;
                this.RealChart.ChartAreas[0].AxisY.LineColor = Color.Black;
                this.RealChart.ChartAreas[0].AxisY.LineWidth = 2;
                this.RealChart.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Auto;
            }
        }
        //切换上条曲线
        private void ucArrowPre_Click(object sender, EventArgs e)
        {
            if (SeriesIndex <= 0)
                SeriesIndex = 0;
            else
                SeriesIndex--;
            this.RealChart.Series.Clear();
            this.RealChart.ChartAreas.Clear();
            this.RealChart.ChartAreas.Add(new ChartArea() { Name = "IOChartArea" });
            if (this.SeriesIndex >= 0)
            {
                IOSeries[this.SeriesIndex].ChartArea = "IOChartArea";
                this.RealChart.Series.Add(IOSeries[this.SeriesIndex]);
                this.RealChart.ChartAreas[0].AxisX.Title = "时间";
                this.RealChart.ChartAreas[0].AxisX.LineColor = Color.Black;
                this.RealChart.ChartAreas[0].AxisX.LineWidth = 2;
                this.RealChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
                this.RealChart.ChartAreas[0].AxisY.Title = IOSeries[this.SeriesIndex].LegendText;
                this.RealChart.ChartAreas[0].AxisY.LineColor = Color.Black;
                this.RealChart.ChartAreas[0].AxisY.LineWidth = 2;
                this.RealChart.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Auto;
            }
            

        }
    }
}
