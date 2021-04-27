using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modbus.Globel;
using Scada.Kernel;

namespace Modbus
{
    public partial class ModbusSetCtrl : UserControl
    {
        public ModbusSetCtrl()
        {
            InitializeComponent();
             
        }

        public void InitCtrl()
        {
            ModbusFunction functions = new ModbusFunction();
            ModbusData DataType = new ModbusData();
            cbo_functioncode.Items.Clear();
            for(int i=0;i< functions.Functions.Count;i++)
            {
                cbo_functioncode.Items.Add(functions.Functions[i]);
            }
            cbo_functioncode.SelectedIndexChanged += Cbo_functioncode_SelectedIndexChanged;
            cbo_StoreType.Items.Clear();
            cbo_StoreType.SelectedIndexChanged += Cbo_StoreType_SelectedIndexChanged;
            for (int i = 0; i < DataType.DataTypes.Count; i++)
            {
                cbo_StoreType.Items.Add(DataType.DataTypes[i]);
            }
            cbo_StoreType.SelectedIndex = 0;
            cbo_datatype.SelectedIndex = 0;
        }
        //不同内存区域显示不同的类型
        private void Cbo_functioncode_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupStored.Visible = false;
            groupposition.Visible = false;
        
            if (cbo_functioncode.SelectedItem != null)
            {
                ModbusFunctionCode func = (ModbusFunctionCode)cbo_functioncode.SelectedItem;
                switch(func.Code)
                {
                    case "01":
                        {
                            groupStored.Visible = false;
                     
                   
                            rb_rw.Checked = true;
                        }
                        break;
                    case "02":
                        {
                            groupStored.Visible = false;
                      
                       
                            rb_r.Checked = true;
                        }
                        break;
                    case "03":
                        {
                            groupStored.Visible = true;
                         
                    
                            rb_rw.Checked = true;
                        }
                        break;
                    case "04":
                        {
                            groupStored.Visible = true;
                         
                          
                            rb_r.Checked = true;
                        }
                        break;
                }
            }

        }

        private void Cbo_StoreType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbo_StoreType.SelectedItem!=null)
            {
                cbo_datatype.Visible = false;
                this.labelbytesize.Visible = false;
                this.ndCharSize.Visible = false;
                groupposition.Visible = false;
                ModbusDataType dataType = (ModbusDataType)cbo_StoreType.SelectedItem;
                labelStoredDesc.Text = dataType.Description;
                switch(dataType.DataType)
                {
                    case Modbus_Type.无符号整数8位:
                        cbo_datatype.Visible = true;
                        break;
                    case Modbus_Type.有符号整数8位:
                        cbo_datatype.Visible = true;
                        break;
                    case Modbus_Type.字符型:
                        cbo_datatype.Visible = false;
                        this.labelbytesize.Visible = true;
                        this.ndCharSize.Visible = true;
                        break;
                    case Modbus_Type.无符号整数16位:
                        this.groupposition.Visible = true;
                        break;
                    case Modbus_Type.有符号整数16位:
                        this.groupposition.Visible = true;
                        break;
                    default:
                        cbo_datatype.Visible = false;
                        this.labelbytesize.Visible = false;
                        ndCharSize.Visible = false;
                        this.groupposition.Visible = false;
                        break;
                }
            }
          
        }
        public void SetParament(string parastr)
        {
            ParaPack para = new ParaPack(parastr);
            if(para.Count>0)
            {
                ///内存区
                for(int i=0;i< cbo_functioncode.Items.Count;i++)
                {
                    ModbusFunctionCode funCode = (ModbusFunctionCode)cbo_functioncode.Items[i];
                    if(funCode.Code== para.GetValue("内存区"))
                    {
                        cbo_functioncode.SelectedIndex = i;
                        break;
                    }
                }
                //数据类型
                for (int i = 0; i < cbo_StoreType.Items.Count; i++)
                {
                    ModbusDataType datatype = (ModbusDataType)cbo_StoreType.Items[i];
                    if (datatype.ToString() == para.GetValue("数据类型"))
                    {
                        cbo_StoreType.SelectedIndex = i;
                        break;
                    }
                }
                //偏置
                this.ndOffset.Value = para.GetValue("偏置") == "" ? 0: Convert.ToDecimal(para.GetValue("偏置"));
                this.ndCharSize.Value = para.GetValue("字节长度") == "" ? 0 : Convert.ToDecimal(para.GetValue("字节长度"));
                this.ndPosition.Value = para.GetValue("数据位") == "" ? 0 : Convert.ToDecimal(para.GetValue("数据位"));
                //存储位置
                for (int i = 0; i < cbo_datatype.Items.Count; i++)
                {
                    string datatype = (string)cbo_datatype.Items[i];
                    if (datatype.ToString() == para.GetValue("存储位置"))
                    {
                        cbo_datatype.SelectedIndex = i;
                        break;
                    }
                }
                //按位存取
                this.cbPosition.Checked = para.GetValue("按位存取") == "1" ? true : false;
       
            }
        }
        public string GetParament()
        {
           
            ParaPack para = new ParaPack();
            if(cbo_functioncode.SelectedItem!=null)
            {
                ModbusFunctionCode funCode = (ModbusFunctionCode)cbo_functioncode.SelectedItem;
                para.AddItem("内存区", funCode.Code);
            }
            para.AddItem("偏置", this.ndOffset.Text.Trim());
            if (cbo_StoreType.SelectedItem != null)
            {
                ModbusDataType datatype = (ModbusDataType)cbo_StoreType.SelectedItem;
                para.AddItem("数据类型", datatype.DataType.ToString());
            }
            if (cbo_datatype.SelectedItem != null)
            {
                string datatype = (string)cbo_datatype.SelectedItem;
                para.AddItem("存储位置", datatype.ToString());
            }
            para.AddItem("字节长度", this.ndCharSize.Text.Trim()==""?"0": this.ndCharSize.Text.Trim());
            para.AddItem("按位存取", this.cbPosition.Checked?"1":"0");
            para.AddItem("数据位", this.ndPosition.Text.Trim()==""?"0": this.ndPosition.Text.Trim());
     
            return para.ToString();


        }
        public ScadaResult IsValidParameter()
        {
            if (cbo_functioncode.SelectedItem == null)
                return new ScadaResult(false, "请选择Modbus内存区");

            return new ScadaResult(true,"参数有效");
        }
    }
}
