using Temporal.Net.InfluxDb.Models.Responses;
using Temporal.DbAPI;
using Scada.Controls.Controls;
using Scada.Controls.Forms;
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
using Scada.Model;

namespace ScadaCenterServer.Pages
{
    public partial class HistoryStaticsQueryWorkForm : DockForm
    {
        List<IOParaSeries> IOSeries = new List<IOParaSeries>();
        private IO_DEVICE Device = null;
        private IO_SERVER Server = null;
        private IO_COMMUNICATION Communication = null;

        public HistoryStaticsQueryWorkForm()
        {
            InitializeComponent();
            this.Load += HistoryStaticsQueryWorkForm_Load;
     
            this.CloseButton = false;
          
        }

        private void Search_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.search.Server!=null && this.search.Communication!=null && this.search.Device!=null)
            {
                this.Text = this.search.Server.SERVER_NAME + "//" + this.search.Communication.IO_COMM_NAME + "//" + this.search.Device.IO_DEVICE_NAME;
                IO_DEVICE selectDevice = sender as IO_DEVICE;
                //初始化多选框
                InitSeriesListBox(selectDevice);
                Device = selectDevice;
                ReadHistory();
            }
          
        }

        /// <summary>
        /// 用户点击查询按钮进行数据查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_SearchClick(object sender, EventArgs e)
        {
            if(sender!=null)
            {
                IO_DEVICE selectDevice = sender as IO_DEVICE;
                //初始化多选框
                InitSeriesListBox(selectDevice);
                Device = selectDevice;
                ReadHistory();
            }
            
        }

        private void InitChart()
        {
            IOSeries.Clear();
            SwitchChart();
        }
        private void SwitchChart()
        {
            this.RealChart.Series.Clear();
            this.RealChart.ChartAreas.Clear();
            ChartArea area = new ChartArea();
            area.AxisX.Title = "时间";
            area.AxisX.LineColor = Color.Black;
            area.AxisX.LineWidth = 2;
            area.AxisX.IntervalType = DateTimeIntervalType.Auto;
            area.AxisY.Title = "采集值";
            area.AxisY.LineColor = Color.Black;
            area.AxisY.LineWidth = 2;
            area.AxisY.IntervalType = DateTimeIntervalType.Auto;
            area.Name = "IOChartArea";
            this.RealChart.ChartAreas.Add(area);
        }
      
       
        /// <summary>
        /// 加载目录树结构
        /// </summary>
        public async void InitTreeProject()
        {
           await Task.Run(() => {

                search.LoadTreeProject();

            });

        }

        private void HistoryStaticsQueryWorkForm_Load(object sender, EventArgs e)
        {
            InitTreeProject();
            ///初始化曲线图
            InitChart();
            //初始化分页控件
            InitPage();
        }
        private void InitPage()
        {
            List<PageSizeItem> lstCom = new List<PageSizeItem>();
  
    
            lstCom.Add(new PageSizeItem(200, "每页200条"));
            lstCom.Add(new PageSizeItem(500, "每页500条"));
            lstCom.Add(new PageSizeItem(1000, "每页1000条"));
            lstCom.Add(new PageSizeItem(2000, "每页2000条"));
            lstCom.Add(new PageSizeItem(5000, "每页5000条"));
            lstCom.Add(new PageSizeItem(8000, "每页8000条"));
            lstCom.Add(new PageSizeItem(10000, "每页10000条"));
            this.ucPagerControl.SetPageItems (lstCom,3);
            this.ucPagerControl.OnPageIndexed += UcPagerControl_OnPageIndexed;


        }

        private void UcPagerControl_OnPageIndexed(int pageindex)
        {
            ReadHistory();
        }

        public   void InitDevice(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device)
        {
            InitSeriesListBox(device);
            Device = device;
            Server = server;
            Communication = communication;
            this.search.StartDate = DateTime.Now.AddDays(-10);
            this.search.EndDate = DateTime.Now;

            this.listBoxSeries.Items.Clear();
            //此处只增加模拟量的IO点
            for (int i = 0; i < Device.IOParas.Count; i++)
            {
                if (Device.IOParas[i].IO_POINTTYPE == "模拟量")
                {
                    this.listBoxSeries.Items.Add(Device.IOParas[i]);
                }
            }

            if (Device != null)
            {
                ///设置下拉菜单选中项
                this.search.SetSelectItem(this.Server, this.Communication, this.Device);

                ReadHistory();

            }


           


        }

       
        private  async void ReadHistory()
        {
            try
            {
                if (Device == null)
                {

                    return;
                }
                this.listView.Items.Clear();
                this.listView.Columns.Clear();
                IO_DEVICE copyDevice = this.Device.Copy();
                //构造查询语句 
                string selected = "";
            

                for (int i = 0; i < copyDevice.IOParas.Count; i++)
                {
                    //只能统计模拟量的
                    if (Device.IOParas[i].IO_POINTTYPE == "模拟量")
                    {
                        selected +=","+this.search.MethType+"(field_" + copyDevice.IOParas[i].IO_NAME.ToLower()+"_value) as field_"+ copyDevice.IOParas[i].IO_NAME.ToLower() + "_value";
                    
                    }
                    
                  

                }
                if (selected != "")
                    selected = selected.Remove(0, 1);
                
                    //获取读取历史数据
                    InfluxDBHistoryData resultData = await IOCenterManager.QueryFormManager.ReadHistoryStaticsDevice(this.Server, this.Communication, copyDevice, this.search.StartDate, this.search.EndDate, this.ucPagerControl.PageSize, this.ucPagerControl.PageIndex,selected,search.TimeType);
                if (resultData == null || !resultData.ReturnResult)
                {
                    if (resultData != null)
                    {
                        FrmDialog.ShowDialog(this, resultData.Msg);
                    }
                    else
                    {
                        FrmDialog.ShowDialog(this, "查询失败");
                    }

                    return;
                }
                //设置页眉控件参数
                this.ucPagerControl.PageCount = resultData.PageCount;
                this.ucPagerControl.RecordCount = resultData.RecordCount;
                //删除曲线
                InitChart();

                //循环读取每个历史数据
                //首先构造ListColumn
        
                ColumnHeader listColumn = new ColumnHeader();
                listColumn.Name = "field_device_date";
                listColumn.Text = "采集时间";
                listColumn.Width = 200;
                listColumn.Tag = null;
                this.listView.Columns.Add(listColumn);
                //每个参数都创建一列,-9999表示质量戳是坏的值
                for (int i = 0; i < copyDevice.IOParas.Count; i++)
                {
                    if (Device.IOParas[i].IO_POINTTYPE == "模拟量")
                    {

                        listColumn = new ColumnHeader();
                        listColumn.Name = copyDevice.IOParas[i].ToString() + "_value";
                        listColumn.Tag = copyDevice.IOParas[i];
                        listColumn.Text = copyDevice.IOParas[i].IO_LABEL;
                        listColumn.Width = 100;
                        this.listView.Columns.Add(listColumn);

                        //创建曲线
                        IOParaSeries series = new IOParaSeries(this.Server, this.Communication, copyDevice, copyDevice.IOParas[i]);
                        IOSeries.Add(series);

                    }

                }
                if (resultData.Seres.Count() > 0)
                {

                    Serie s = resultData.Seres.ElementAt(0);
                    //获取首个时间
                    int dateindex = s.Columns.IndexOf("time");
                    if (dateindex >= 0)
                    {
                        for (int i = 0; i < s.Values.Count; i++)
                        {
                            string date = InfluxDbManager.GetInfluxdbValue(s.Values[i][dateindex]);


                            ListViewItem lvi = new ListViewItem(date);
                            for (int c = 0; c < copyDevice.IOParas.Count; c++)
                            {
                                int paraindex = s.Columns.IndexOf("field_" + copyDevice.IOParas[c].IO_NAME.ToLower() + "_value");
                                if (paraindex >= 0)
                                {
                                    IOParaSeries series = IOSeries.Find(x => x.Name.Trim() == copyDevice.IOParas[c].IO_NAME.Trim());
                              
                                    double yValue = -9999;
                                    double.TryParse(InfluxDbManager.GetInfluxdbValue(s.Values[i][paraindex]),out yValue);
                                    string xValue = date;

                                    lvi.SubItems.Add(InfluxDbManager.GetInfluxdbValue(s.Values[i][paraindex]).ToString());

                                    if (series != null)
                                    {
                                        int pointIndex = series.Points.AddXY(date, new object[1] { yValue });
                                        if (xValue != "")
                                        {
                                            if (yValue == -9999)
                                            {
                                                series.Points[pointIndex].IsEmpty = true;
                                                series.Points[pointIndex].ToolTip = "坏数据";
                                            }
                                            else
                                            {
                                                series.Points[pointIndex].ToolTip = "时间=" + date + ",采集值=" + yValue;
                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    lvi.SubItems.Add("");

                                }


                            }
                            listView.Items.Add(lvi);
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                IOCenterManager.QueryFormManager.DisplyException(ex);
            }
        }
        private void listBoxSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSeries.SelectedItem != null)
            {
                IO_PARA para = listBoxSeries.SelectedItem as IO_PARA;
                SwitchChart();
                IOParaSeries series = IOSeries.Find(x => x.Name.Trim() == para.IO_NAME.Trim());
                if (series != null)
                {
                    this.RealChart.Series.Add(series);
                }
            }
        }
        public HistoryStaticsQueryWorkForm(Mediator m, IO_DEVICE mDevice) : base(m)
        {

            InitializeComponent();
            Device = mDevice;
            this.Load += HistoryStaticsQueryWorkForm_Load;
            
        }
        private void InitSeriesListBox(IO_DEVICE selectDevice)
        {
            if (Device != null)
            {
                
                if (selectDevice!=null&& Device!= selectDevice)
                {
                    Device = selectDevice;
                  
                    InitChart();
                    this.listBoxSeries.Items.Clear();
                    //此处只增加模拟量的IO点
                    for (int i = 0; i < Device.IOParas.Count; i++)
                    {
                        if (Device.IOParas[i].IO_POINTTYPE == "模拟量")
                        {
                            this.listBoxSeries.Items.Add(Device.IOParas[i]);
                        }
                    }
                }
               

            }
        }
        public override TabTypes TabType
        {
            get
            {
                return TabTypes.HistoricalStatistics;
            }
        }
        //分页事件
        private void ucPagerControl_ShowSourceChanged(object currentSource)
        {
           
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {

           if(e.Column>=0&& this.listView.Columns[e.Column].Tag != null)
            {
                this.mediator.IOPropeitesForm.SetPara(this.Server, this.Communication, this.Device, this.listView.Columns[e.Column].Tag as IO_PARA);
            }

        }
    }
}
