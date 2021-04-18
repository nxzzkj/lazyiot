 
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
    public partial class IOCommunicationForm : BasicDialogForm
    {
        public IO_COMMUNICATION Comunication = null;
        public IO_SERVER Server = null;
        public IOCommunicationForm()
        {
            InitializeComponent();


        }
        public   void InitForm()
        {
              FormManager.IOCommunicationDriveCombox(comboDrive);

            if (Comunication == null)
            {
                Comunication = new IO_COMMUNICATION();
                Comunication.IO_COMM_ID = GUIDTo16.GuidToLongID().ToString();
                IOServerNode serverNode = FormManager.mediator.IOTreeForm.IoTree.GetServerNode(Server);
                if(serverNode!=null)
                {
                  
                    Comunication.IO_COMM_LABEL= "Communication" + serverNode.CommunicationNumber;
                    Comunication.IO_COMM_NAME = "";
                }
             
                Comunication.IO_COMM_STATUS = 1;
            }
            Comunication.IO_SERVER_ID = Server.SERVER_ID;

            this.txtID.Text = Comunication.IO_COMM_ID;
            this.txtLabel.Text = Comunication.IO_COMM_LABEL;
            this.txtName.Text = Comunication.IO_COMM_NAME;
            this.txtRemark.Text = Comunication.IO_COMM_REMARK;
            for (int i = 0; i < this.comboDrive.Items.Count; i++)
            {
                Scada.Model.SCADA_DRIVER driver = this.comboDrive.Items[i] as Scada.Model.SCADA_DRIVER;
                if (driver.Id == Comunication.IO_COMM_DRIVER_ID)
                {
                    this.comboDrive.SelectedIndex = i;
                    break;
                }
            }
            if (this.comboDrive.SelectedIndex <= 0 && this.comboDrive.Items.Count > 0)
            {
                this.comboDrive.SelectedIndex = 0;
            }

        }

        private void wizardTabControl_ButtonCancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private   void wizardTabControl_ButtonOK(object sender, EventArgs e)
        {
            if (comboDrive.SelectedItem == null)
            {
                MessageBox.Show("请选择通讯驱动");
                return;
            }
            if (this.txtLabel.Text.Trim() == "")
            {
                MessageBox.Show("请输入中文名称");
                return;
            }
            if (this.txtName.Text.Trim() == "")
            {
                MessageBox.Show("请输入通道标识");
                return;
            }
            IOServerNode serverNode = FormManager.mediator.IOTreeForm.IoTree.GetServerNode(Server);

            if (serverNode != null)
            {
                for (int i = 0; i < serverNode.Nodes.Count; i++)
                {
                    IOCommunicationNode commNode = serverNode.Nodes[i] as IOCommunicationNode;
                    if (commNode.Communication.IO_COMM_NAME.Trim() == Comunication.IO_COMM_NAME.Trim()&& commNode.Communication!= Comunication)
                    {
                        MessageBox.Show("通讯通道" + commNode.Communication.IO_COMM_NAME.Trim() + " 的标识重复!");
                        return;
                    }
                }
            }
            if (DriverCom != null)
            {
                ScadaResult res = DriverCom.CommunicationControl.IsValidParameter();
               
                if (res.Result)
                {
                    Scada.Model.SCADA_DRIVER driver = comboDrive.SelectedItem as Scada.Model.SCADA_DRIVER;
                    Comunication.IO_COMM_DRIVER_ID = driver.Id;
                    Comunication.IO_COMM_LABEL = this.txtLabel.Text.Trim();
                    Comunication.IO_COMM_NAME = this.txtName.Text.Trim();
                    Comunication.IO_COMM_REMARK = this.txtRemark.Text;
                    Comunication.IO_COMM_STATUS = 1;
                    Comunication.IO_SERVER_ID = Server.SERVER_ID;
                    Comunication.IO_COMM_PARASTRING = DriverCom.GetUIParameter();
                      FormManager.InsertIOCommunicationNode(this.Server, Comunication);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(res.Message);
                }

            }


        }

        private void wizardTabControl_ButtonNext(object sender, EventArgs e)
        {

        }

        private void wizardTabControl_ButtonPrevious(object sender, EventArgs e)
        {

        }

        private   void IOCommunicationForm_Load(object sender, EventArgs e)
        {
            this.wizardTabControl.InitWizard();
       

        }
        public ScadaCommunicateKernel DriverCom = null;
        private   void comboDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDrive.SelectedItem != null)
            {
                try
                {


                    Scada.Model.SCADA_DRIVER driver = comboDrive.SelectedItem as Scada.Model.SCADA_DRIVER;

                    DriverCom= FormManager.CreateCommunicateDriver(driver);
                    if (DriverCom == null)
                        return;
                    try
                    {
                       
                        DriverCom.InitKernel(this.Server, this.Comunication, null, driver);
                    }
                    catch(Exception emx)
                    {
                         FormManager.DisplayException(new Exception("通讯驱动初始化InitDriver失败" + emx.Message));

                    }
           
                    
                    try
                    {
                     

                        if (DriverCom.CommunicationControl!=null)
                            DriverCom.CommunicationControl.SetUIParameter(Comunication.IO_COMM_PARASTRING);
                    }
                    catch (Exception emx)
                    {
                         FormManager.DisplayException(new Exception("解析通讯驱动参数失败(SetUIParameter)" + emx.Message));

                    }
                    this.tabPage2.Controls.Clear();
                    this.tabPage2.Controls.Add(DriverCom.CommunicationControl);
                }
                catch(Exception emx)
                {
                     FormManager.DisplayException(new Exception("加载通讯驱动失败" + emx.Message));
                }
            }
        }
    }
}
