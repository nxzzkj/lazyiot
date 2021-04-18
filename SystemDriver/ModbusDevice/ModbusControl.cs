using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeviceDriveBase;
using ZZSCADA.Model;
using IO_Structure;

namespace ModbusDevice
{
    public partial class ModbusControl : IOParaControl
    {
        public ModbusControl()
        {
            InitializeComponent();
        }
        public override void SetUIParameter(IO_SERVER server, IO_DEVICE device, IO_PARA para)
        {
            try
            {
                this.ParaString = para.IO_PARASTRING;
                cbo_functioncode.Items.Clear();
                cbo_functioncode.Items.Add(new FunctionListItem("01号功能码 (输出状态)", "01"));
                cbo_functioncode.Items.Add(new FunctionListItem("02号功能码 (输入状态)", "02"));
                cbo_functioncode.Items.Add(new FunctionListItem("03号功能码 (保持型寄存器)", "03"));
                cbo_functioncode.Items.Add(new FunctionListItem("04号功能码 (输入型寄存器)", "04"));
                cbo_functioncode.Items.Add(new FunctionListItem("05号功能码 (强制打开或复位单线圈)", "05"));
                cbo_functioncode.Items.Add(new FunctionListItem("10号功能码 (强制打开或复位多个线圈)", "10"));

                this.cbo_StoreType.Items.Clear();
                this.cbo_StoreType.Items.Add(BitStoreMode.低位字节在前);
                this.cbo_StoreType.Items.Add(BitStoreMode.高位字节在前);
                cbo_StoreType.SelectedIndex = 0;
                cbo_datatype.Items.Clear();
                cbo_datatype.Items.Add("8位有符号");
                cbo_datatype.Items.Add("8位无符号");
                cbo_datatype.Items.Add("16位有符号");
                cbo_datatype.Items.Add("16位无符号");
                cbo_datatype.Items.Add("32位有符号");
                cbo_datatype.Items.Add("32位无符号");
                cbo_datatype.Items.Add("字符型");
                cbo_datatype.Items.Add("32位浮点型");
                cbo_datatype.Items.Add("64位双精度浮点型");
                cbo_datatype.SelectedIndex = 0;
                cbo_datatype2.Items.Clear();
                cbo_datatype2.Items.Add("低8位");
                cbo_datatype2.Items.Add("高8位");
                cbo_datatype2.SelectedIndex = 0;
                if (ParaString == null || ParaString == "")
                    return;
                string[] strs = ParaString.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (strs.Length > 0)
                {
                    for (int i = 0; i < cbo_functioncode.Items.Count; i++)
                    {
                        FunctionListItem item = (FunctionListItem)cbo_functioncode.Items[i];
                        if (item.Code.Trim() == strs[0].Split(':')[1].Trim())
                        {
                            cbo_functioncode.SelectedIndex = i;
                            break;
                        }
                    }

                    tb_float.Text = strs[1].Split(':')[1];
                    cbo_datatype.SelectedItem = strs[2].Split(':')[1];
                    cbo_datatype2.SelectedItem = strs[3].Split(':')[1];
                    if (strs[4].Split(':')[1] == "可读可写")
                    {
                        this.rb_rw.Checked = true;
                    }
                    else if (strs[4].Split(':')[1] == "可读")
                    {
                        this.rb_r.Checked = true;
                    }
                    else if (strs[4].Split(':')[1] == "可写")
                    {
                        this.rb_w.Checked = true;
                    }

                    if (strs[5].Split(':')[1] == "0")
                    {
                        this.cb_position.Checked = false;
                    }
                    else if (strs[5].Split(':')[1] == "1")
                    {
                        this.cb_position.Checked = true;
                    }

                    this.tb_position.Text = strs[6].Split(':')[1];
                    InitData();
                }
            }
            catch
            {

            }
        }
        public override string GetUIParameter()
        {
            InitData();
            return this.ParaString;
        }
        private void InitData()
        {

            if (cbo_functioncode.SelectedIndex < 0)
                return;
            int flt = 0;
            int.TryParse(this.tb_float.Text, out flt);
            if (cbo_functioncode.SelectedIndex == 1)//寄存器地址从400000
            {
                this.groupData.Visible = true;
                this.groupRead.Enabled = false;
                groupposition.Visible = true;
                labeldata.Text = "寄存器地址从" + (400000 + flt).ToString() + "开始,偏置" + flt;
            }
            else if (cbo_functioncode.SelectedIndex == 2)//寄存器地址从300000
            {
                this.groupData.Visible = true;
                this.groupRead.Enabled = false;
                groupposition.Visible = true;
                labeldata.Text = "寄存器地址从" + (300000 + flt).ToString() + "开始,偏置" + flt;

            }



            if (cbo_functioncode.SelectedItem != null)
            {
                this.ParaString = "";
                this.ParaString += "内存区:" + ((FunctionListItem)cbo_functioncode.SelectedItem).Code.ToString();
                this.ParaString += ",偏置:" + this.tb_float.Text.Trim();
                this.ParaString += ",数据格式1:" + cbo_datatype.SelectedItem.ToString();
                this.ParaString += ",数据格式2:" + cbo_datatype2.SelectedItem.ToString();
                if (this.rb_rw.Checked)
                {
                    this.ParaString += ",读写状态:可读可写";
                }
                if (this.rb_r.Checked)
                {
                    this.ParaString += ",读写状态:可读";
                }
                if (this.rb_w.Checked)
                {
                    this.ParaString += ",读写状态:可写";
                }

                this.ParaString += ",按位读写:" + Convert.ToInt32(this.cb_position.Checked);
                int pos = 0;
                int.TryParse(this.tb_position.Text.Trim(), out pos);
                this.ParaString += ",数据位:" + pos.ToString();
                this.ParaString += ",存储方式:" + this.cbo_StoreType.SelectedItem.ToString();

            }
        }
        public override bool IsValidParameter()
        {
            return true;
        }

        private void cbo_functioncode_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitData();
        }

        private void tb_float_TextChanged(object sender, EventArgs e)
        {
            int num = -1;

            InitData();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            ParaString = "";
        }

        private void cb_position_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_position.ReadOnly = !cb_position.Checked;
            InitData();
        }

        private void tb_position_TextChanged(object sender, EventArgs e)
        {
            InitData();
        }

        private void rb_rw_CheckedChanged(object sender, EventArgs e)
        {
            InitData();
        }

        private void cbo_datatype_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitData();
        }

        private void cbo_datatype2_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitData();
        }

        private void cbo_StoreType_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitData();
        }
    }
}
