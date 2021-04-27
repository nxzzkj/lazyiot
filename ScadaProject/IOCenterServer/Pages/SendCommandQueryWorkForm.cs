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
using Scada.DBUtility;
using Scada.Model;

namespace ScadaCenterServer.Pages
{
    public partial class SendCommandQueryWorkForm : DockForm
    {
 
        private IO_DEVICE Device = null;
        private IO_SERVER Server = null;
        private IO_COMMUNICATION Communication = null;

        public SendCommandQueryWorkForm()
        {
            InitializeComponent();
            this.Load += SendCommandQueryWorkForm_Load;
     
            this.CloseButton = false;
          
        }

        private void Search_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.search.Server!=null && this.search.Communication!=null && this.search.Device!=null)
            {
                this.Text = this.search.Server.SERVER_NAME + "//" + this.search.Communication.IO_COMM_NAME + "//" + this.search.Device.IO_DEVICE_NAME;
                IO_DEVICE selectDevice = sender as IO_DEVICE;
                //初始化多选框
           
                Device = selectDevice;
                ReadCommandHistory();
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
      
                Device = selectDevice;
                ReadCommandHistory();
            }
            
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

        private void SendCommandQueryWorkForm_Load(object sender, EventArgs e)
        {
            InitTreeProject();
 
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
            ReadCommandHistory();
        }

        public   void InitDevice(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device)
        {
         
            Device = device;
            Server = server;
            Communication = communication;
            this.search.StartDate = DateTime.Now.AddDays(-10);
            this.search.EndDate = DateTime.Now;

         
            if (Device != null)
            {
                ///设置下拉菜单选中项
                this.search.SetSelectItem(this.Server, this.Communication, this.Device);

                ReadCommandHistory();

            }


           


        }

       
        private  async void ReadCommandHistory()
        {
            try
            {
                if (Device == null)
                {

                    return;
                }
                listViewSendCommand.Items.Clear();
                IO_DEVICE copyDevice = this.Device.Copy();
                //获取读取历史数据
                InfluxDBHistoryData resultData = await IOCenterManager.QueryFormManager.ReadHistoryCommandsDevice(this.Server, this.Communication, copyDevice, this.search.StartDate, this.search.EndDate, this.ucPagerControl.PageSize, this.ucPagerControl.PageIndex);
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
              
 
                if (resultData.Seres.Count() > 0)
                {
                  

                    Serie s = resultData.Seres.ElementAt(0);
                    //获取首个时间

                    for (int i = 0; i < s.Values.Count; i++)
                    {
                        int timeindex = s.Columns.IndexOf("time");
                        string time = UnixDateTimeConvert.ConvertDateTimeInt(Convert.ToDateTime(InfluxDbManager.GetInfluxdbValue(s.Values[i][timeindex]))).ToString();
                        int dateindex = s.Columns.IndexOf("field_command_date");

                        string date = InfluxDbManager.GetInfluxdbValue(s.Values[i][dateindex]);
                        ListViewItem lvi = new ListViewItem(time);
                        int io_name_index = s.Columns.IndexOf("field_name");
                        if (io_name_index >= 0)
                        {
                            lvi.SubItems.Add(InfluxDbManager.GetInfluxdbValue(s.Values[i][io_name_index]));
                        }
                        else
                        {
                            lvi.SubItems.Add("");
                        }
                        ///
                        int io_name_label = s.Columns.IndexOf("field_label");
                        if (io_name_label >= 0)
                        {
                            lvi.SubItems.Add(InfluxDbManager.GetInfluxdbValue(s.Values[i][io_name_label]));
                        }
                        else
                        {
                            lvi.SubItems.Add("");
                        }

                        ///
                        int field_command_value = s.Columns.IndexOf("field_command_value");
                        if (field_command_value >= 0)
                        {
                            lvi.SubItems.Add(InfluxDbManager.GetInfluxdbValue(s.Values[i][field_command_value]));
                        }
                        else
                        {
                            lvi.SubItems.Add("");
                        }

                        int field_command_result = s.Columns.IndexOf("field_command_result");
                        if (field_command_result >= 0)
                        {
                            lvi.SubItems.Add(InfluxDbManager.GetInfluxdbValue(s.Values[i][field_command_result]));
                        }
                        else
                        {
                            lvi.SubItems.Add("");
                        }

                        int field_command_user = s.Columns.IndexOf("field_command_user");
                        if (field_command_user >= 0)
                        {
                            lvi.SubItems.Add(InfluxDbManager.GetInfluxdbValue(s.Values[i][field_command_user]));
                        }
                        else
                        {
                            lvi.SubItems.Add("");
                        }
                        this.listViewSendCommand.Items.Add(lvi);
                    }
                }
            }
            catch(Exception ex)
            {
                IOCenterManager.QueryFormManager.DisplyException(ex);
            }
        }
    
        public SendCommandQueryWorkForm(Mediator m, IO_DEVICE mDevice) : base(m)
        {

            InitializeComponent();
            Device = mDevice;
            this.Load += SendCommandQueryWorkForm_Load;
            
        }
    
        public override TabTypes TabType
        {
            get
            {
                return TabTypes.LowerQuery;
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

           if(e.Column>=0&& this.listViewSendCommand.Columns[e.Column].Tag != null)
            {
                this.mediator.IOPropeitesForm.SetPara(this.Server, this.Communication, this.Device, null);
            }

        }
    }
}
