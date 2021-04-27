 
using Scada.Model;
using IOManager.Controls;
using IOManager.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;
using Scada.Kernel;

namespace IOManager.Dialogs
{
    public partial class IOParaForm : BasicDialogForm
    {
        public IO_COMMUNICATION Comunication = null;
        public IO_SERVER Server = null;
        public IO_DEVICE Device = null;
        
        public IO_PARA Para = null;
        public IOParaForm()
        {
            InitializeComponent();
        }
        public   void InitForm()
        {
            groupBoxMN.Visible = false;
            this.groupBoxKG.Visible = false;
            this.groupBoxGS.Visible = false;
            this.groupDatabase.Visible = false;
            if (Para == null)
            {
                Para = new IO_PARA();
                Para.IO_ID = ""; 
                Para.IO_ADDRESS = "1";
                Para.IO_COMM_ID = Comunication.IO_COMM_ID;
                Para.IO_DEVICE_ID = Device.IO_DEVICE_ID;
                Para.IO_SERVER_ID = Server.SERVER_ID;
                Para.IO_SYSTEM = 0;
                Para.IO_ENABLEALARM = 0;
                Para.IO_ENABLERANGECONVERSION = 0;
                cb_paratype.SelectedIndex = 0;
                cb_datatype.SelectedIndex = 0;
                cbo_minmin.SelectedIndex = 0;
                cbo_min.SelectedIndex = 0;
                cbo_max.SelectedIndex = 0;
                cbo_maxmax.SelectedIndex = 0;
             
            }
            if(Device!=null)
            {
                txtFormula.InitDevice(Device);

            }
            comconType.SelectedIndex = 0;
            this.cbDatabaseType.SelectedIndex = 0;
            this.txtDataSourceDateRecordRange.SelectedIndex = 0;
            this.txtDataSourceOrderRecordType.SelectedIndex = 0;
            this.txtDataSourceValueRecordType.Text = "NONE";
            this.tb_paraname.Text = Para.IO_NAME;
            this.tb_parachname.Text = Para.IO_LABEL;
            this.tb_initvalue.Text = Para.IO_INITALVALUE;
            this.cb_unittype.Text = Para.IO_UNIT;
            this.tb_address.Text = Para.IO_ADDRESS;

         
            for (int i = 0; i < cb_paratype.Items.Count; i++)
            {
                if (cb_paratype.Items[i].ToString() == Para.IO_POINTTYPE)
                {
                    cb_paratype.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < cb_datatype.Items.Count; i++)
            {
                if (cb_datatype.Items[i].ToString() == Para.IO_DATATYPE)
                {
                    cb_datatype.SelectedIndex = i;
                    break;
                }
            }
            cb_range.Checked = Convert.ToBoolean(Para.IO_ENABLERANGECONVERSION);
            tb_minrange.Text = Para.IO_RANGEMIN;
            tb_maxrange.Text = Para.IO_RANGEMAX;
            tb_valuemin.Text = Para.IO_MINVALUE;
            tb_valuemax.Text = Para.IO_MAXVALUE;
            ///小数位数
            this.tbDecimalplace.Text = Para.IO_OUTLIES;
            tb_zone.Text = Para.IO_ZERO;
            tb_one.Text = Para.IO_ONE;
          
            //报警属性设置
            cb_alarm.Checked = Convert.ToBoolean(Para.IO_ENABLEALARM);
            cb_minminenable.Checked = Convert.ToBoolean(Para.AlarmConfig.IO_ENABLE_MINMIN);
            cb_minenable.Checked = Convert.ToBoolean(Para.AlarmConfig.IO_ENABLE_MIN);
            cb_maxenable.Checked = Convert.ToBoolean(Para.AlarmConfig.IO_ENABLE_MAX);
            cb_maxmaxenable.Checked = Convert.ToBoolean(Para.AlarmConfig.IO_ENABLE_MAXMAX);
            //报警限值设置
            nb_maxmax.Value = Para.AlarmConfig.IO_MAXMAX_VALUE.Value;
            nb_max.Value = Para.AlarmConfig.IO_MAX_VALUE.Value;
            nb_min.Value = Para.AlarmConfig.IO_MIN_VALUE.Value;
            nb_minmin.Value = Para.AlarmConfig.IO_MINMIN_VALUE.Value;
            //报警类型
            for (int i = 0; i < cbo_minmin.Items.Count; i++)
            {
                if (cbo_minmin.Items[i].ToString() == Para.AlarmConfig.IO_MINMIN_TYPE)
                {
                    cbo_minmin.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cbo_min.Items.Count; i++)
            {
                if (cbo_min.Items[i].ToString() == Para.AlarmConfig.IO_MIN_TYPE)
                {
                    cbo_min.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < cbo_max.Items.Count; i++)
            {
                if (cbo_max.Items[i].ToString() == Para.AlarmConfig.IO_MAX_TYPE)
                {
                    cbo_max.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < cbo_maxmax.Items.Count; i++)
            {
                if (cbo_maxmax.Items[i].ToString() == Para.AlarmConfig.IO_MAXMAX_TYPE)
                {
                    cbo_maxmax.SelectedIndex = i;
                    break;
                }
            }
            //报警子项是否开启
            cb_minminenable.Checked = Convert.ToBoolean(Para.AlarmConfig.IO_ENABLE_MINMIN);
            cb_minenable.Checked = Convert.ToBoolean(Para.AlarmConfig.IO_ENABLE_MIN);
            cb_maxenable.Checked = Convert.ToBoolean(Para.AlarmConfig.IO_ENABLE_MAX);
            cb_maxmaxenable.Checked = Convert.ToBoolean(Para.AlarmConfig.IO_ENABLE_MAXMAX);
            string[] condions = Para.AlarmConfig.IO_CONDITION.Split(new char[1] { ',' },StringSplitOptions.RemoveEmptyEntries);
            this.listCons.Items.Clear();
            this.listCons.Items.AddRange(condions);
            listParas.Items.Clear();
            for(int i=0;i< FormManager.mediator.IOParaForm.IOListView.ListView.Items.Count;i++)
            {
                listParas.Items.Add(FormManager.mediator.IOParaForm.IOListView.ListView.Items[i].SubItems[1].Text);
            }
            //加载设备驱动
            Scada.Business.SCADA_DEVICE_DRIVER driverBll = new Scada.Business.SCADA_DEVICE_DRIVER();
            
            Scada.Model.SCADA_DEVICE_DRIVER driver = driverBll.GetModel(Device.DEVICE_DRIVER_ID) ;
            if(driver!=null)
            {
                DeviceKernel = FormManager.CreateDeviceDrive(driver);
                DeviceKernel.InitKernel(Server, Comunication, Device, Para, driver);
                DeviceKernel.ParaCtrl.SetUIParameter(Server, Device,Para);
                this.tabPage3.Controls.Clear();
                this.tabPage3.Controls.Add(DeviceKernel.ParaCtrl);
            }

            this.txtFormula.Text = Para.IO_FORMULA;
            //配置数据源连接
            string[] datasorces = Para.IO_DATASOURCE.Split(',');
            if (datasorces.Length == 13)
            {


                this.txtDataSourceIP.Text = datasorces[0];
                this.txtDataSourceName.Text = datasorces[1];
                this.cbDatabaseType.Text = datasorces[2];
                this.txtDataSourceUser.Text = datasorces[3];
                this.txtDataSourcePassword.Text = datasorces[4];
                this.txtDataSourceTable.Text = datasorces[5];
                this.txtDataSourceValueRecord.Text = datasorces[6];
                this.txtDataSourceValueRecordType.Text = datasorces[7];
                this.txtDataSourceDateRecord.Text = datasorces[8];
                this.txtDataSourceDateRecordRange.Text = datasorces[9];
                this.txtDataSourceOrderRecord.Text = datasorces[10];
                this.txtDataSourceOrderRecordType.Text = datasorces[11];
                this.txtDataSourceWhere.Text = datasorces[12];
            }

        }
        public ScadaDeviceKernel DeviceKernel = null;
        private  void wizardTabControl_ButtonCancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private  void wizardTabControl_ButtonOK(object sender, EventArgs e)
        {
            try
            {
                if (tb_paraname.Text.Trim() == "")
                {
                    MessageBox.Show("请输入IO参数名称");
                    return;
                }
               
                if (cb_paratype.SelectedItem == null)
                {
                    MessageBox.Show("请选择IO类型");
                    return;
                }
                if (cb_datatype.SelectedItem == null)
                {
                    MessageBox.Show("请选择IO模拟量数据类型");
                    return;
                }

        
                //量程转换输入判断
                if(this.cb_range.Checked)
                {
                    if (Convert.ToDouble(this.tb_maxrange.Text)<= Convert.ToDouble(this.tb_minrange.Text))
                    {
                        MessageBox.Show("量程范围不匹配");
                        return;
                    }
                    if (Convert.ToDouble(this.tb_valuemax.Text) <= Convert.ToDouble(this.tb_valuemin.Text))
                    {
                        MessageBox.Show("裸数据范围不匹配");
                        return;
                    }
                }
                if (cb_paratype.SelectedIndex == 5)
                {
                    cb_datatype.SelectedIndex = 8;
                }

                Para.IO_ADDRESS = this.tb_address.Text.Trim();
                Para.IO_ALERT_ENABLE = Convert.ToInt32(cb_alarm.Checked);
                Para.IO_COMM_ID = Comunication.IO_COMM_ID;
                Para.IO_DATATYPE = cb_datatype.SelectedItem.ToString();
                Para.IO_DEVICE_ID = Device.IO_DEVICE_ID;
                Para.IO_ENABLEALARM = Convert.ToInt32(cb_alarm.Checked);
                Para.IO_ENABLERANGECONVERSION = Convert.ToInt32(cb_range.Checked);
                Para.IO_HISTORY = 1;
                Para.IO_INITALVALUE = tb_initvalue.Text;
                Para.IO_LABEL = tb_parachname.Text;
                Para.IO_MAXVALUE = tb_valuemax.Text;
                Para.IO_MINVALUE = tb_valuemin.Text;
                Para.IO_NAME = tb_paraname.Text.Trim();
                Para.IO_ONE = tb_one.Text.Trim();
                Para.IO_OUTLIES = tbDecimalplace.Text.Trim();
                if(DeviceKernel != null)
                Para.IO_PARASTRING = DeviceKernel.ParaCtrl.GetUIParameter();
                Para.IO_POINTTYPE = cb_paratype.SelectedItem.ToString();
                Para.IO_RANGEMAX = tb_maxrange.Text;
                Para.IO_RANGEMIN = tb_minrange.Text;
                Para.IO_SERVER_ID = Server.SERVER_ID;
                Para.IO_SYSTEM = 0;
                Para.IO_UNIT = cb_unittype.Text.Trim();
                Para.IO_ZERO = tb_zone.Text;
                //公式配置部分
                Para.IO_FORMULA = txtFormula.Text.Trim();
                //数据源设置部分
                #region
                {
                    Para.IO_DATASOURCE = "";
                    Para.IO_DATASOURCE= this.txtDataSourceIP.Text;
                    Para.IO_DATASOURCE += ","+this.txtDataSourceName.Text;
                    Para.IO_DATASOURCE += "," + this.cbDatabaseType.Text;
                    Para.IO_DATASOURCE += "," + this.txtDataSourceUser.Text ;
                    Para.IO_DATASOURCE += "," + this.txtDataSourcePassword.Text;
                    Para.IO_DATASOURCE += "," + this.txtDataSourceTable.Text;
                    Para.IO_DATASOURCE += "," + this.txtDataSourceValueRecord.Text ;
                    Para.IO_DATASOURCE += "," + this.txtDataSourceValueRecordType.Text;
                    Para.IO_DATASOURCE += "," + this.txtDataSourceDateRecord.Text;
                    Para.IO_DATASOURCE += "," + this.txtDataSourceDateRecordRange.Text;
                    Para.IO_DATASOURCE += "," + this.txtDataSourceOrderRecord.Text;
                    Para.IO_DATASOURCE += "," + this.txtDataSourceOrderRecordType.Text;
                    Para.IO_DATASOURCE += "," + this.txtDataSourceWhere.Text;
                }
                #endregion
               
                //报警部分设置
                Para.AlarmConfig.IO_SERVER_ID = Para.IO_SERVER_ID;
                Para.AlarmConfig.IO_COMM_ID = Para.IO_COMM_ID;
                Para.AlarmConfig.IO_DEVICE_ID = Para.IO_DEVICE_ID;
                Para.AlarmConfig.IO_ID = Para.IO_ID;
                Para.AlarmConfig.IO_ENABLE_MAX = Convert.ToInt32(cb_maxenable.Checked);
                Para.AlarmConfig.IO_ENABLE_MAXMAX = Convert.ToInt32(cb_maxmaxenable.Checked);
                Para.AlarmConfig.IO_ENABLE_MIN = Convert.ToInt32(cb_minenable.Checked);
                Para.AlarmConfig.IO_ENABLE_MINMIN = Convert.ToInt32(cb_minminenable.Checked);
                if (cbo_minmin.SelectedItem!=null)
                Para.AlarmConfig.IO_MINMIN_TYPE = cbo_minmin.SelectedItem.ToString();
                if (cbo_min.SelectedItem != null)
                    Para.AlarmConfig.IO_MIN_TYPE = cbo_min.SelectedItem.ToString();
                if (cbo_max.SelectedItem != null)
                    Para.AlarmConfig.IO_MAX_TYPE = cbo_max.SelectedItem.ToString();
                if (cbo_maxmax.SelectedItem != null)
                    Para.AlarmConfig.IO_MAXMAX_TYPE = cbo_maxmax.SelectedItem.ToString();



                Para.AlarmConfig.IO_MINMIN_VALUE = nb_minmin.Value;
                Para.AlarmConfig.IO_MIN_VALUE = nb_min.Value;
                Para.AlarmConfig.IO_MAX_VALUE = nb_max.Value;
                Para.AlarmConfig.IO_MAXMAX_VALUE = nb_maxmax.Value;
                Para.AlarmConfig.IO_ALARM_LEVEL = "";

                if (this.cb_alarm.Checked)
                {


                    if (nb_maxmax.Value <= Para.AlarmConfig.IO_MIN_VALUE || nb_maxmax.Value <= Para.AlarmConfig.IO_MINMIN_VALUE || nb_maxmax.Value <= Para.AlarmConfig.IO_MAX_VALUE)
                    {
                        MessageBox.Show("超高限值不能小于等于高限、低限、超低限值");
                        return;
                    }
                    if (nb_max.Value <= Para.AlarmConfig.IO_MINMIN_VALUE || nb_max.Value <= Para.AlarmConfig.IO_MIN_VALUE)
                    {
                        MessageBox.Show("高限值不能小于等于低限、超低限值");
                        return;
                    }
                    if (nb_min.Value <= Para.AlarmConfig.IO_MINMIN_VALUE)
                    {
                        MessageBox.Show("超高限值不能小于等于高限、低限、超低限值");
                        return;
                    }
                }
                string strs = "";
                for (int i = 0; i < listCons.Items.Count; i++)
                {
                    strs += listCons.Items[i].ToString() + ",";
                }
                if (strs != "")
                {
                    strs = strs.Remove(strs.Length - 1, 1);
                }
                Para.AlarmConfig.IO_CONDITION = strs;
                if( Para.IO_ID==null|| Para.IO_ID == "")//新建
                {
                    for (int i = 0; i < this.Device.IOParas.Count; i++)
                    {
                        if (this.Device.IOParas[i] != Para && Para.IO_NAME.Trim() == this.Device.IOParas[i].IO_NAME.Trim())
                        {
                            MessageBox.Show("已经存" + Para.IO_NAME.Trim() + "名称的IO点");
                            return;
                        }
                        
                    }
                    Para.IO_ID = GUIDTo16.GuidToLongID().ToString();
                       IOListViewItem lvi = new IOListViewItem(Para);
                    this.Device.IOParas.Add(Para);
                    FormManager.mediator.IOParaForm.AddListViewItem(lvi);
                    FormManager.mediator.IOLogForm.AppendText(FormManager.mediator.IOParaForm.IOListView.IOPath + " 创建IO点" + Para.IO_NAME + "成功!");
                }
                else
                {

                    for (int i = 0; i < this.Device.IOParas.Count; i++)
                    {
                        if (this.Device.IOParas[i] != Para && Para.IO_NAME.Trim() == this.Device.IOParas[i].IO_NAME.Trim())
                        {
                            MessageBox.Show("已经存" + Para.IO_NAME.Trim() + "名称的IO点");
                            return;
                        }
                       
                    }
                    IOListViewItem lvi=  FormManager.mediator.IOParaForm.GetListViewItem(Para);
                    if(lvi!=null)
                    {
                        lvi.ResetSubItems();
                        FormManager.mediator.IOLogForm.AppendText(FormManager.mediator.IOParaForm.IOListView.IOPath + " 修改IO点" + Para.IO_NAME + "成功!");
                    }
                   
                }
               
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception emx)
            {
                  FormManager.DisplayException(emx);
            }
        }

        private   void IOParaForm_Load(object sender, EventArgs e)
        {
            this.wizardTabControl.InitWizard();
        }

        private void cb_alarm_CheckedChanged(object sender, EventArgs e)
        {
            groupalarm.Enabled = cb_alarm.Checked;
        }

        private void cb_range_CheckedChanged(object sender, EventArgs e)
        {
            groupRange.Enabled = cb_range.Checked;
        }

        private void cb_paratype_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.groupBoxKG.Visible = false;
            this.groupBoxGS.Visible = false;
            this.groupDatabase.Visible = false;
 
            if (cb_paratype.SelectedIndex==0)
            {
        
                groupBoxMN.Visible = true;
                groupBoxKG.Visible = false;
            }
            else if (cb_paratype.SelectedIndex == 1)
            {
               
                groupBoxMN.Visible = false;
                groupBoxKG.Visible = true;
            }
            else if (cb_paratype.SelectedIndex == 2)
            {
                groupBoxMN.Visible = false;
                groupBoxKG.Visible = false;
            }
            else if (cb_paratype.SelectedIndex == 3)
            {
                groupBoxMN.Visible = false;
                groupBoxKG.Visible = false;
                this.groupBoxGS.Visible = true;

            }
            else if (cb_paratype.SelectedIndex == 4)
            {
                groupBoxMN.Visible = false;
                groupBoxKG.Visible = false;
                this.groupBoxGS.Visible = false;
                this.groupDatabase.Visible = true;

            }
            else if (cb_paratype.SelectedIndex ==5)//常量值
            {
                groupBoxMN.Visible = false;
                groupBoxKG.Visible = false;
                this.groupBoxGS.Visible = false;
                this.groupDatabase.Visible = false;
               

            }

            
        }

        private void listParas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listParas.SelectedItem!=null)
            {
                lbalarmconshow.Text = listParas.SelectedItem.ToString();
            }
           
        }

        private void btconAdd_Click(object sender, EventArgs e)
        {
            if (listParas.SelectedItem == null)
            {
                MessageBox.Show(this, "请选择IO参数");
                return;
            }
            if (comconType.SelectedItem==null)
            {
                MessageBox.Show(this,"请选择运算符");
                return;
            }
            if (tbconValue.Text == "")
            {
                MessageBox.Show(this, "请输入条件值");
                return;
            }

            listCons.Items.Add(string.Format("{0}{1}{2}", listParas.SelectedItem, comconType.SelectedItem, tbconValue.Text));
        }

        private void btconDel_Click(object sender, EventArgs e)
        {
            if(listCons.SelectedItem!=null)
            {
                listCons.Items.Remove(this.listCons.SelectedItem);
            }
        }
        //刷新数据源并获取相关结构
        private void btDataSourceRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
