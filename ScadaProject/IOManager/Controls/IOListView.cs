using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;

using System.Windows.Forms.Design;
using System.Threading.Tasks;
using Scada.Model;
using IOManager.Core;
using System.Threading;

namespace IOManager.Controls
{
    [Designer(typeof(ListViewControlDesigner))]
    public partial class IOListView : UserControl
    {
        public string IOPath
        {
            set
            {
                this.txtPath.Text = value;

            }
            get
            {
                return this.txtPath.Text;
            }
        }
        public IOListView()
        {
            InitializeComponent();
            this.listView.MouseDoubleClick += ListView_MouseDoubleClick;
        }

 

        private   void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           if(e.Clicks==2&&e.Button== MouseButtons.Left)
            {
                if (Device != null && this.listView.SelectedItems.Count > 0)
                {
                    IOListViewItem lvi = this.listView.SelectedItems[0] as IOListViewItem;
                      FormManager.EditDevicePara(this.Server, this.Communication, this.Device, lvi.Para);

                }
                else
                {
                    MessageBox.Show("请选择要编辑的IO测点");
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ListView ListView
        {
            get { return this.listView; }


        }
        public IO_DEVICE Device
        {
            set;
            get;
        }
        public IO_SERVER Server
        {
            set;
            get;
        }
        public IO_COMMUNICATION Communication
        {
            set;
            get;
        }
        #region ListView操作

        public  void AddListViewItem(IOListViewItem lvi)
        {
            this.listView.Items.Add(lvi);
        }
        public  void RemoveListViewItem(IOListViewItem lvi)
        {
            this.listView.Items.Remove(lvi);
        }
        public  void RemoveListViewItem(IO_PARA para)
        {
            for(int i = this.listView.Items.Count-1;i>=0;i--)
            {
                IOListViewItem item = this.listView.Items[i] as IOListViewItem;
                if(item.Para== para)
                {
                    this.listView.Items.Remove(item);
                    break;
                }
                
            }
       
        }
        public  void RemoveAtListViewItem(int index)
        {
            this.listView.Items.RemoveAt(index);
        }
        /// <summary>
        /// 判断是否已存在此名称的点表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Exist(string name)
        {
            for (int i = 0; i < this.listView.Items.Count; i++)
            {
                IOListViewItem lvi = this.listView.Items[i] as IOListViewItem;
                if (lvi.Para.IO_NAME.Trim() == name.Trim())
                {
                    return true;
                }

            }
            return false;
        }
        /// <summary>
        /// 判断是否地址重复
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool ExistAddress(string address)
        {
            for (int i = 0; i < this.listView.Items.Count; i++)
            {
                IOListViewItem lvi = this.listView.Items[i] as IOListViewItem;
                if (lvi.Para.IO_ADDRESS.Trim() == address.Trim())
                {
                    return true;
                }

            }
            return false;
        }
        #endregion
        #region 鼠标右键操作

        public   void 添加参数ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (Device != null)
            {
                  FormManager.EditDevicePara(this.Server, this.Communication, this.Device, null);

            }
        }

        public  void 删除参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Device != null)
            {
                if (MessageBox.Show(this.FindForm(), "是否要删除选中的IO测点?", "删除提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                 
                    for (int i = this.listView.SelectedItems.Count-1; i >= 0; i--)
                    {
                        IOListViewItem lvi = this.listView.SelectedItems[i] as IOListViewItem;
                        
                        lvi.Remove();
                        this.Device.IOParas.Remove(lvi.Para);
                        string name = lvi.SubItems[1].Text;
                        FormManager.mediator.IOLogForm.AppendText("删除" + Device.IO_DEVICE_NAME + "设备下" + name + "IO点");
                    }
                }
            }
        }

        public   void 编辑参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Device != null && this.listView.SelectedItems.Count > 0)
            {
                IOListViewItem lvi = this.listView.SelectedItems[0] as IOListViewItem;
                  FormManager.EditDevicePara(this.Server, this.Communication, this.Device, lvi.Para);

            }
            else
            {
                MessageBox.Show("请选择要编辑的IO测点");
            }
        }
        //复制的信息
        List<IO_PARA> copyIds = new List<IO_PARA>();
        //剪切的信息
        List<IO_PARA> cutIds = new List<IO_PARA>();
        IO_DEVICE copyDevice = null;
        public  void 复制参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Device != null)
            {
                copyDevice = null;
                cutIds.Clear();
                copyIds.Clear();
                for (int i = this.listView.SelectedItems.Count - 1; i >= 0; i--)
                {
                    IOListViewItem lvi = this.listView.SelectedItems[i] as IOListViewItem;
                    copyIds.Add(lvi.Para);
                }
                copyDevice = Device;

            }
        }

        public  void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Device != null)
            {
                try
                {


                    if (this.IsHandleCreated)
                    {
                        this.listView.BeginInvoke(new EventHandler(delegate
                    {

                        if (copyIds.Count > 0)
                        {
                            if (MessageBox.Show(this.FindForm(), "是否要粘贴复制的IO点?", "粘贴提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {


                                for (int i = copyIds.Count - 1; i >= 0; i--)
                                {

                                    IO_PARA newPara = copyIds[i].Copy();
                                    string oldName = newPara.IO_NAME;
                                    newPara.IO_DEVICE_ID = Device.IO_DEVICE_ID;
                                    newPara.IO_COMM_ID = Device.IO_COMM_ID;
                                    newPara.IO_SERVER_ID = Device.IO_SERVER_ID;
                                    newPara.IO_ID = Scada.DBUtility.GUIDTo16.GuidToLongID().ToString();//分配新的ID
                                    bool existName = false;
                                    for (int p = 0; p < Device.IOParas.Count; p++)
                                    {
                                        if (newPara.IO_NAME.Trim() == Device.IOParas[p].IO_NAME.Trim())
                                        {
                                            existName = true;
                                            break;
                                        }
                                    }
                                    //出现相同名称的时候要重新命名
                                    if (existName)
                                    {
                                        newPara.IO_NAME = newPara.IO_NAME + "_C" + DateTime.Now.ToString("yyyyMMddHHmmss");
                                    }

                                    //不是同一个设备的时候要考虑驱动参数
                                 
                                        this.AddListViewItem(new IOListViewItem(newPara));
                                        FormManager.mediator.IOLogForm.AppendText("从设备" + copyDevice.IO_DEVICE_NAME + "复制IO点" + oldName + " 到设备" + Device.IO_DEVICE_NAME + "成功,新IO名称是" + newPara.IO_NAME);

                   
                                    Device.IOParas.Add(newPara);
                                    Thread.Sleep(400);

                                }
                            }
                        }
                        if (cutIds.Count > 0)
                        {
                            if (copyDevice == Device)
                            {
                                MessageBox.Show("不能剪贴到同一设备下");
                                return;
                            }
                            if (MessageBox.Show(this.FindForm(), "是否要粘贴剪贴的IO点?", "粘贴提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                for (int i = cutIds.Count - 1; i >= 0; i--)
                                {

                                    IO_PARA newPara = cutIds[i].Copy();
                                    string oldName = newPara.IO_NAME;
                                    newPara.IO_DEVICE_ID = Device.IO_DEVICE_ID;
                                    newPara.IO_COMM_ID = Device.IO_COMM_ID;
                                    newPara.IO_SERVER_ID = Device.IO_SERVER_ID;
                                    newPara.IO_ID = Scada.DBUtility.GUIDTo16.GuidToLongID().ToString();//分配新的ID
                                    bool existName = false;
                                    for (int p = 0; p < Device.IOParas.Count; p++)
                                    {
                                        if (newPara.IO_NAME.Trim() == Device.IOParas[p].IO_NAME.Trim())
                                        {
                                            existName = true;
                                            break;
                                        }
                                    }
                                    //出现相同名称的时候要重新命名
                                    if (existName)
                                    {
                                        newPara.IO_NAME = newPara.IO_NAME + "_C" + DateTime.Now.ToString("yyyyMMddHHmmss");
                                    }

                                    //不是同一个设备的时候要考虑驱动参数
                                    if (copyDevice != Device)
                                    {
                                        newPara.IO_PARASTRING = "";
                                        this.AddListViewItem(new IOListViewItem(newPara));
                                        FormManager.mediator.IOLogForm.AppendText("从设备" + copyDevice.IO_DEVICE_NAME + "剪贴IO点" + oldName + " 到设备" + Device.IO_DEVICE_NAME + "成功,新IO名称是" + newPara.IO_NAME + "。由于设备驱动不同，需要重新配置此IO点驱动信息");
                                    }
                                    else
                                    {
                                        this.AddListViewItem(new IOListViewItem(newPara));
                                        FormManager.mediator.IOLogForm.AppendText("从设备" + copyDevice.IO_DEVICE_NAME + "剪贴IO点" + oldName + " 到设备" + Device.IO_DEVICE_NAME + "成功,新IO名称是" + newPara.IO_NAME);

                                    }
                                    //增加新的IO点
                                    Device.IOParas.Add(newPara);
                                    //删除原来的点表信息
                                    copyDevice.IOParas.Remove(cutIds[i]);
                                    if (copyDevice == Device)
                                    {
                                        this.RemoveListViewItem(cutIds[i]);
                                    }
                                    Thread.Sleep(400);
                                }
                                copyDevice = null;
                                cutIds.Clear();
                                copyIds.Clear();
                            }

                        }

                    }));
                    }
                }
                catch (Exception ex)
                {
                      FormManager.DisplayException(ex);
                }
            }

        }
   

        public  void 取消全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Device != null)
            {
                for (int i = 0; i < this.listView.Items.Count; i++)
                {
                    this.listView.Items[i].Selected = false;
                }
            }
        }

        public  void toolStripMenuItem全选_Click(object sender, EventArgs e)
        {
            if (Device != null)
            {
                for(int i=0;i<this.listView.Items.Count;i++)
                {
                    this.listView.Items[i].Selected = true;
                }

            }
        }

        public  void 剪贴toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Device != null)
            {
                copyDevice = null;
                cutIds.Clear();
                copyIds.Clear();
                for (int i = this.listView.SelectedItems.Count - 1; i >= 0; i--)
                {
                    IOListViewItem lvi = this.listView.SelectedItems[i] as IOListViewItem;
                    cutIds.Add(lvi.Para);
                }
                copyDevice = Device;

            }
        }
        #endregion
    }
    public class IOListViewItem : ListViewItem
    {
        public IO_PARA Para = null;
        public IOListViewItem()
        {

        }
        public IOListViewItem(IO_PARA d)
            : base(d.IO_ID)
        {
            Para = d;

            this.SubItems.Add(Para.IO_NAME);
            this.SubItems.Add(Para.IO_LABEL);
            this.SubItems.Add(Para.IO_PARASTRING);
            this.SubItems.Add(Para.IO_DATATYPE);
            this.SubItems.Add(Para.IO_OUTLIES);
            this.SubItems.Add(Para.IO_INITALVALUE);
            this.SubItems.Add(Para.IO_MINVALUE);
            this.SubItems.Add(Para.IO_MAXVALUE);
            if (Para.IO_ENABLERANGECONVERSION == 1)
                this.SubItems.Add("是");
            else
                this.SubItems.Add("否");
            this.SubItems.Add(Para.IO_RANGEMIN);
            this.SubItems.Add(Para.IO_RANGEMAX);
            this.SubItems.Add(Para.IO_POINTTYPE);
            this.SubItems.Add(Para.IO_ZERO);
            this.SubItems.Add(Para.IO_ONE);
            this.SubItems.Add(Para.IO_UNIT);

            if (Para.IO_HISTORY == 1)
                this.SubItems.Add("是");
            else
                this.SubItems.Add("否");
            this.SubItems.Add(Para.IO_ADDRESS);
            if (Para.IO_ENABLEALARM == 1)
                this.SubItems.Add("是");
            else
                this.SubItems.Add("否");
            if (Para.IO_SYSTEM == 1)
                this.SubItems.Add("是");
            else
                this.SubItems.Add("否");

        }
        public void ResetSubItems()
        {
            this.SubItems.Clear();
            if (Para != null)
            {

                this.Text = Para.IO_ID;
                this.SubItems.Add(Para.IO_NAME);
                this.SubItems.Add(Para.IO_LABEL);
                this.SubItems.Add(Para.IO_PARASTRING);
                this.SubItems.Add(Para.IO_DATATYPE);
                this.SubItems.Add(Para.IO_OUTLIES);
                this.SubItems.Add(Para.IO_INITALVALUE);
                this.SubItems.Add(Para.IO_MINVALUE);
                this.SubItems.Add(Para.IO_MAXVALUE);
                if (Para.IO_ENABLERANGECONVERSION == 1)
                    this.SubItems.Add("是");
                else
                    this.SubItems.Add("否");
                this.SubItems.Add(Para.IO_RANGEMIN);
                this.SubItems.Add(Para.IO_RANGEMAX);
                this.SubItems.Add(Para.IO_POINTTYPE);
                this.SubItems.Add(Para.IO_ZERO);
                this.SubItems.Add(Para.IO_ONE);
                this.SubItems.Add(Para.IO_UNIT);

                if (Para.IO_HISTORY == 1)
                    this.SubItems.Add("是");
                else
                    this.SubItems.Add("否");
                this.SubItems.Add(Para.IO_ADDRESS);
                if (Para.IO_ENABLEALARM == 1)
                    this.SubItems.Add("是");
                else
                    this.SubItems.Add("否");
                if (Para.IO_SYSTEM == 1)
                    this.SubItems.Add("是");
                else
                    this.SubItems.Add("否");
            }


        }
    }
}
