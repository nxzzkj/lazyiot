using ScadaCenterServer.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.Controls;
using Scada.Controls.Forms;
using ScadaCenterServer.Core;

namespace ScadaCenterServer.Pages
{
    public partial class InfluxConfigForm : DockForm
    {
        public CenterServerConfig Config = null;
        public InfluxConfigForm(Mediator m):base(m)
        {

            InitializeComponent();
    
            this.Load += InfluxConfigForm_Load;
        }
        public InfluxConfigForm()
        {
            InitializeComponent();
            this.Load += InfluxConfigForm_Load;
        }
        public override TabTypes TabType
        {
            get
            {
                return TabTypes.DatabaseConfiguration;
            }
        }
        List<InfluxConfigBox> boxs = new List<InfluxConfigBox>();
        private void InfluxConfigForm_Load(object sender, EventArgs e)
        {
            boxs.Clear();
               Config = new CenterServerConfig();
            labelHead.Text = Config.influxdConfig.HeadItem.Description;
            for(int i=0;i < Config.influxdConfig.HeadItem.Items.Count;i++)
            {
                InfluxConfigBox box = new InfluxConfigBox();
                box.Dock = DockStyle.Top;
                box.ConfigItem = Config.influxdConfig.HeadItem.Items[i];
                flowLayoutPanelHead.Controls.Add(box);
                boxs.Add(box);
            }
            labelMeta.Text = Config.influxdConfig.MetaItem.Description;
            for (int i = 0; i < Config.influxdConfig.MetaItem.Items.Count; i++)
            {
                InfluxConfigBox box = new InfluxConfigBox();
                box.Dock = DockStyle.Top;
                box.ConfigItem = Config.influxdConfig.MetaItem.Items[i];
                flowLayoutPanelMeta.Controls.Add(box);
                boxs.Add(box);
            }

            labelData.Text = Config.influxdConfig.DataItem.Description;
            for (int i = 0; i < Config.influxdConfig.DataItem.Items.Count; i++)
            {
                InfluxConfigBox box = new InfluxConfigBox();
                box.Dock = DockStyle.Top;
                box.ConfigItem = Config.influxdConfig.DataItem.Items[i];
                flowLayoutPanelData.Controls.Add(box);
                boxs.Add(box);
            }

            labelCoordinator.Text = Config.influxdConfig.CoordinatorItem.Description;
            for (int i = 0; i < Config.influxdConfig.CoordinatorItem.Items.Count; i++)
            {
                InfluxConfigBox box = new InfluxConfigBox();
                box.Dock = DockStyle.Top;
                box.ConfigItem = Config.influxdConfig.CoordinatorItem.Items[i];
                flowLayoutPanelCoordinator.Controls.Add(box);
                boxs.Add(box);
            }


            labelRetention.Text = Config.influxdConfig.RetentionItem.Description;
            for (int i = 0; i < Config.influxdConfig.RetentionItem.Items.Count; i++)
            {
                InfluxConfigBox box = new InfluxConfigBox();
                box.Dock = DockStyle.Top;
                box.ConfigItem = Config.influxdConfig.RetentionItem.Items[i];
                flowLayoutPanelRetention.Controls.Add(box);
                boxs.Add(box);
            }


            labelShard_Precreation.Text = Config.influxdConfig.Shard_PrecreationItem.Description;
            for (int i = 0; i < Config.influxdConfig.Shard_PrecreationItem.Items.Count; i++)
            {
                InfluxConfigBox box = new InfluxConfigBox();
                box.Dock = DockStyle.Top;
                box.ConfigItem = Config.influxdConfig.Shard_PrecreationItem.Items[i];
                flowLayoutPanelShard_Precreation.Controls.Add(box);
                boxs.Add(box);
            }

            labelMonitor.Text = Config.influxdConfig.MonitorItem.Description;
            for (int i = 0; i < Config.influxdConfig.MonitorItem.Items.Count; i++)
            {
                InfluxConfigBox box = new InfluxConfigBox();
                box.Dock = DockStyle.Top;
                box.ConfigItem = Config.influxdConfig.MonitorItem.Items[i];
                flowLayoutPanelMonitor.Controls.Add(box);
                boxs.Add(box);
            }


            labelHttp.Text = Config.influxdConfig.HttpItem.Description;
            for (int i = 0; i < Config.influxdConfig.HttpItem.Items.Count; i++)
            {
                InfluxConfigBox box = new InfluxConfigBox();
                box.Dock = DockStyle.Top;
                box.ConfigItem = Config.influxdConfig.HttpItem.Items[i];
                flowLayoutPanelHttp.Controls.Add(box);
                boxs.Add(box);
            }


            labelLogging.Text = Config.influxdConfig.LoggingItem.Description;
            for (int i = 0; i < Config.influxdConfig.LoggingItem.Items.Count; i++)
            {
                InfluxConfigBox box = new InfluxConfigBox();
                box.Dock = DockStyle.Top;
                box.ConfigItem = Config.influxdConfig.LoggingItem.Items[i];
                flowLayoutPanelLogging.Controls.Add(box);
                boxs.Add(box);
            }


            labelSubscriber.Text = Config.influxdConfig.SubscriberItem.Description;
            for (int i = 0; i < Config.influxdConfig.SubscriberItem.Items.Count; i++)
            {
                InfluxConfigBox box = new InfluxConfigBox();
                box.Dock = DockStyle.Top;
                box.ConfigItem = Config.influxdConfig.SubscriberItem.Items[i];
                flowLayoutPanelSubscriber.Controls.Add(box);
                boxs.Add(box);
            }

 

            labelContinuous_queries.Text = Config.influxdConfig.Continuous_queriesItem.Description;
            for (int i = 0; i < Config.influxdConfig.Continuous_queriesItem.Items.Count; i++)
            {
                InfluxConfigBox box = new InfluxConfigBox();
                box.Dock = DockStyle.Top;
                box.ConfigItem = Config.influxdConfig.Continuous_queriesItem.Items[i];
                flowLayoutPanelContinuous_queries.Controls.Add(box);
                boxs.Add(box);
            }

            

        }

        private void ucBtnSave_BtnClick(object sender, EventArgs e)
        {
          
            if(FrmDialog.ShowDialog(this, "修改配置后需要重新启动服务器，是否要修改配置？","配置保存",true,false,true,true) ==DialogResult.OK)
            {
                for(int i=0;i< boxs.Count;i++)
                {
                    boxs[i].SaveConfig();
                }
                try
                {
                    Config.WriteConfig();
                    IOCenterManager.QueryFormManager.AddLog("修改数据库配置文件成功");
                    FrmDialog.ShowDialog(this, "修改数据库配置文件成功");
                }
                catch(Exception emx)
                {
                    FrmDialog.ShowDialog(this, emx.Message);

                    IOCenterManager.QueryFormManager.DisplyException(emx);
                }
             
               
            }
        }

        private void ucBtnRedo_BtnClick(object sender, EventArgs e)
        {
            if (FrmDialog.ShowDialog(this, "是否要将配置信息恢复为默认值？", "配置保存", true, false, true, true) == DialogResult.OK)
            {
                Config.RecoveryConfig();
                for (int i = 0; i < boxs.Count; i++)
                {
                    boxs[i].ResetConfig();
                }
                try
                {

                    IOCenterManager.QueryFormManager.AddLog("将配置信息恢复为默认值成功");
                    FrmDialog.ShowDialog(this, "将配置信息恢复为默认值成功");
                }
                catch (Exception emx)
                {
                  
                    FrmDialog.ShowDialog(this, emx.Message);
                    IOCenterManager.QueryFormManager.DisplyException(emx);
                }


            }
        }
    }
}
