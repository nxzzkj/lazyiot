using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScadaCenterServer.Controls
{
    public partial class InfluxConfigBox : UserControl
    {
        private Label labelDesc;
        private SplitContainer splitContainer1;
        private Label labelKey;
        private Scada.Controls.Controls.UCCombox ucCombox;
        private Scada.Controls.Controls.UCTextBoxEx ucTextBoxEx;
        private Scada.Controls.Controls.UCSplitLine_H ucSplitLine_H1;
        private Scada.Controls.Controls.UCSplitLine_H ucSplitLine_H2;
        private Scada.Controls.Controls.UCBtnExt ucBtnBrowser;
        private ConfigItem _ConfigItem = null;
        public   ConfigItem ConfigItem
        {
            get
            {
                return _ConfigItem;
            }

            set
            {
                _ConfigItem = value;
                ResetConfig();

            }
        }
        
        public void SaveConfig()
        {
            string value = "";
            if (this.ucTextBoxEx.Visible)
            {
                value += this.ucTextBoxEx.InputText;
            }
            if (ucCombox.Visible)
            {
                value += this.ucCombox.SelectedValue;
            }
            if(ConfigItem!=null)
            {
                ConfigItem.Value = value;
            }
        }
        public void ResetConfig()
        {
          
            if (_ConfigItem != null)
            {
                if (_ConfigItem.ItemType == ConfigItemType.布尔值)
                {
                    ucBtnBrowser.Visible = false;
                    this.ucTextBoxEx.Visible = false;
                    this.ucCombox.Visible = true;
                    this.labelDesc.Text = _ConfigItem.Description;
                    this.labelKey.Text = _ConfigItem.Key + ":";
                    ucCombox.Source = new List<KeyValuePair<string, string>>();
                    ucCombox.Source.Add(new KeyValuePair<string, string>("true", "true"));
                    ucCombox.Source.Add(new KeyValuePair<string, string>("false", "false"));
                    ucCombox.TextValue = _ConfigItem.Value;
                    if (_ConfigItem.Value.Trim() == "false")
                        ucCombox.SelectedIndex = 1;
                    else
                        ucCombox.SelectedIndex = 0;
                    if (_ConfigItem.ReadOnly)
                    {
                        this.ucCombox.Enabled = !_ConfigItem.ReadOnly;
                    }
                }
                else if (_ConfigItem.ItemType == ConfigItemType.多项列表)
                {
                    ucBtnBrowser.Visible = false;
                    this.ucTextBoxEx.Visible = false;
                    this.ucCombox.Visible = true;

                    this.labelDesc.Text = _ConfigItem.Description;
                    this.labelKey.Text = _ConfigItem.Key + ":";
                    ucCombox.Source = new List<KeyValuePair<string, string>>();
                    for (int i = 0; i < _ConfigItem.SelectItems.Count; i++)
                    {
                        ucCombox.Source.Add(new KeyValuePair<string, string>(_ConfigItem.SelectItems[i], _ConfigItem.SelectItems[i]));
                        if (_ConfigItem.Value.Trim() == _ConfigItem.SelectItems[i])
                        {
                            ucCombox.SelectedIndex = i;
                        }
                    }

                    if (_ConfigItem.ReadOnly)
                    {
                        this.ucCombox.Enabled = !_ConfigItem.ReadOnly;
                    }
                }
                else if (_ConfigItem.ItemType == ConfigItemType.字符串 || _ConfigItem.ItemType == ConfigItemType.对象)
                {
                    ucBtnBrowser.Visible = false;
                    ucCombox.Source = new List<KeyValuePair<string, string>>();
                    this.ucCombox.Visible = false;
                    this.ucTextBoxEx.Visible = true;
                    this.labelDesc.Text = _ConfigItem.Description;
                    this.labelKey.Text = _ConfigItem.Key + ":";
                    ucTextBoxEx.InputText = _ConfigItem.Value;

                    if (_ConfigItem.ReadOnly)
                    {
                        this.ucTextBoxEx.Enabled = !_ConfigItem.ReadOnly;
                    }
                }
                else if (_ConfigItem.ItemType == ConfigItemType.数值)
                {
                    ucBtnBrowser.Visible = false;
                    ucCombox.Source = new List<KeyValuePair<string, string>>();
                    this.ucCombox.Visible = false;
                    this.ucTextBoxEx.Visible = true;
                    this.labelDesc.Text = _ConfigItem.Description;
                    this.labelKey.Text = _ConfigItem.Key + ":";
                    ucTextBoxEx.InputText = _ConfigItem.Value;
                    ucTextBoxEx.InputType = Scada.Controls.TextInputType.UnsignNumber;
                    ucTextBoxEx.MaxValue = 999999999999;
                    ucTextBoxEx.MinValue = 0;
                    if (_ConfigItem.ReadOnly)
                    {
                        this.ucTextBoxEx.Enabled = !_ConfigItem.ReadOnly;
                    }
                }
                else if (_ConfigItem.ItemType == ConfigItemType.时间单位)
                {
                    ucBtnBrowser.Visible = false;
                    this.ucCombox.Visible = true;
                    this.ucTextBoxEx.Visible = true;
                    this.labelDesc.Text = _ConfigItem.Description;
                    this.labelKey.Text = _ConfigItem.Key + ":";


                    ucCombox.Source = new List<KeyValuePair<string, string>>();
                    ucCombox.Source.Add(new KeyValuePair<string, string>("s", "s"));
                    ucCombox.Source.Add(new KeyValuePair<string, string>("m", "m"));
                    ucCombox.Source.Add(new KeyValuePair<string, string>("h", "h"));
                    if (_ConfigItem.Value.Contains("s"))
                    {
                        ucCombox.SelectedIndex = 0;

                    }
                    else if (_ConfigItem.Value.Contains("m"))
                    {
                        ucCombox.SelectedIndex = 1;

                    }
                    else if (_ConfigItem.Value.Contains("h"))
                    {
                        ucCombox.SelectedIndex = 2;

                    }
                    ucTextBoxEx.InputText = _ConfigItem.Value.Replace("s", "").Replace("m", "").Replace("h", "");
                    ucTextBoxEx.InputType = Scada.Controls.TextInputType.UnsignNumber;
                    ucTextBoxEx.MaxValue = 999999999999;
                    ucTextBoxEx.MinValue = 0;
                    if (_ConfigItem.ReadOnly)
                    {
                        this.ucCombox.Enabled = !_ConfigItem.ReadOnly;
                        this.ucTextBoxEx.Enabled = !_ConfigItem.ReadOnly;
                    }
                }
                else if (_ConfigItem.ItemType == ConfigItemType.存储单位)
                {
                    ucBtnBrowser.Visible = false;
                    this.ucCombox.Visible = true;
                    this.ucTextBoxEx.Visible = true;
                    this.labelDesc.Text = _ConfigItem.Description;
                    this.labelKey.Text = _ConfigItem.Key + ":";


                    ucCombox.Source = new List<KeyValuePair<string, string>>();
                    ucCombox.Source.Add(new KeyValuePair<string, string>("k", "k"));
                    ucCombox.Source.Add(new KeyValuePair<string, string>("m", "m"));
                    ucCombox.Source.Add(new KeyValuePair<string, string>("g", "g"));
                    if (_ConfigItem.Value.Contains("k"))
                    {
                        ucCombox.SelectedIndex = 0;

                    }
                    else if (_ConfigItem.Value.Contains("m"))
                    {
                        ucCombox.SelectedIndex = 1;

                    }
                    else if (_ConfigItem.Value.Contains("g"))
                    {
                        ucCombox.SelectedIndex = 2;

                    }
                    ucTextBoxEx.InputText = _ConfigItem.Value.Replace("k", "").Replace("m", "").Replace("g", "");
                    ucTextBoxEx.InputType = Scada.Controls.TextInputType.UnsignNumber;
                    ucTextBoxEx.MaxValue = 999999999999;
                    ucTextBoxEx.MinValue = 0;
                    if (_ConfigItem.ReadOnly)
                    {
                        this.ucCombox.Enabled = !_ConfigItem.ReadOnly;
                        this.ucTextBoxEx.Enabled = !_ConfigItem.ReadOnly;
                    }
                }
                else if (_ConfigItem.ItemType == ConfigItemType.路径)
                {
                    ucBtnBrowser.Visible = true;
                    this.ucCombox.Visible = false;
                    this.ucTextBoxEx.Visible = true;
                    this.ucTextBoxEx.ReadOnly = true;
                    this.labelDesc.Text = _ConfigItem.Description;
                    this.labelKey.Text = _ConfigItem.Key + ":";



                    ucTextBoxEx.InputText = _ConfigItem.Value;
                    ucTextBoxEx.InputType = Scada.Controls.TextInputType.NotControl;

                    if (_ConfigItem.ReadOnly)
                    {
                        this.ucCombox.Enabled = !_ConfigItem.ReadOnly;
                        this.ucTextBoxEx.Enabled = !_ConfigItem.ReadOnly;
                    }
                }
            }
        }
        public InfluxConfigBox():base()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.labelDesc = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucBtnBrowser = new Scada.Controls.Controls.UCBtnExt();
            this.ucCombox = new Scada.Controls.Controls.UCCombox();
            this.ucTextBoxEx = new Scada.Controls.Controls.UCTextBoxEx();
            this.labelKey = new System.Windows.Forms.Label();
            this.ucSplitLine_H1 = new Scada.Controls.Controls.UCSplitLine_H();
            this.ucSplitLine_H2 = new Scada.Controls.Controls.UCSplitLine_H();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDesc
            // 
            this.labelDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDesc.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDesc.Location = new System.Drawing.Point(0, 0);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(543, 42);
            this.labelDesc.TabIndex = 1;
            this.labelDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelDesc);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucBtnBrowser);
            this.splitContainer1.Panel2.Controls.Add(this.ucCombox);
            this.splitContainer1.Panel2.Controls.Add(this.ucTextBoxEx);
            this.splitContainer1.Panel2.Controls.Add(this.labelKey);
            this.splitContainer1.Size = new System.Drawing.Size(543, 84);
            this.splitContainer1.SplitterDistance = 42;
            this.splitContainer1.TabIndex = 2;
            // 
            // ucBtnBrowser
            // 
            this.ucBtnBrowser.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnBrowser.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnBrowser.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnBrowser.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnBrowser.BtnText = "选择";
            this.ucBtnBrowser.ConerRadius = 10;
            this.ucBtnBrowser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnBrowser.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucBtnBrowser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ucBtnBrowser.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnBrowser.ForeColor = System.Drawing.Color.White;
            this.ucBtnBrowser.IsRadius = true;
            this.ucBtnBrowser.IsShowRect = false;
            this.ucBtnBrowser.IsShowTips = false;
            this.ucBtnBrowser.Location = new System.Drawing.Point(428, 0);
            this.ucBtnBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnBrowser.Name = "ucBtnBrowser";
            this.ucBtnBrowser.RectColor = System.Drawing.Color.Gainsboro;
            this.ucBtnBrowser.RectWidth = 1;
            this.ucBtnBrowser.Size = new System.Drawing.Size(48, 38);
            this.ucBtnBrowser.TabIndex = 17;
            this.ucBtnBrowser.TabStop = false;
            this.ucBtnBrowser.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnBrowser.TipsText = "";
            this.ucBtnBrowser.BtnClick += new System.EventHandler(this.ucBtnBrowser_BtnClick);
            // 
            // ucCombox
            // 
            this.ucCombox.BackColor = System.Drawing.Color.Transparent;
            this.ucCombox.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucCombox.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ucCombox.ConerRadius = 5;
            this.ucCombox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCombox.DropPanelHeight = -1;
            this.ucCombox.FillColor = System.Drawing.Color.White;
            this.ucCombox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucCombox.IsRadius = true;
            this.ucCombox.IsShowRect = true;
            this.ucCombox.ItemWidth = 70;
            this.ucCombox.Location = new System.Drawing.Point(428, 0);
            this.ucCombox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucCombox.Name = "ucCombox";
            this.ucCombox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucCombox.RectWidth = 1;
            this.ucCombox.SelectedIndex = -1;
            this.ucCombox.SelectedValue = "";
            this.ucCombox.Size = new System.Drawing.Size(115, 38);
            this.ucCombox.Source = null;
            this.ucCombox.TabIndex = 3;
            this.ucCombox.TextValue = null;
            this.ucCombox.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucCombox.Visible = false;
            // 
            // ucTextBoxEx
            // 
            this.ucTextBoxEx.BackColor = System.Drawing.Color.Transparent;
            this.ucTextBoxEx.ConerRadius = 5;
            this.ucTextBoxEx.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ucTextBoxEx.DecLength = 2;
            this.ucTextBoxEx.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucTextBoxEx.FillColor = System.Drawing.Color.Empty;
            this.ucTextBoxEx.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucTextBoxEx.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBoxEx.InputText = "";
            this.ucTextBoxEx.InputType = Scada.Controls.TextInputType.NotControl;
            this.ucTextBoxEx.IsFocusColor = true;
            this.ucTextBoxEx.IsRadius = true;
            this.ucTextBoxEx.IsShowClearBtn = true;
            this.ucTextBoxEx.IsShowKeyboard = false;
            this.ucTextBoxEx.IsShowRect = true;
            this.ucTextBoxEx.IsShowSearchBtn = false;
            this.ucTextBoxEx.KeyBoardType = Scada.Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.ucTextBoxEx.Location = new System.Drawing.Point(122, 0);
            this.ucTextBoxEx.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTextBoxEx.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ucTextBoxEx.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.ucTextBoxEx.Name = "ucTextBoxEx";
            this.ucTextBoxEx.Padding = new System.Windows.Forms.Padding(5);
            this.ucTextBoxEx.PromptColor = System.Drawing.Color.Gray;
            this.ucTextBoxEx.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBoxEx.PromptText = "";
            this.ucTextBoxEx.ReadOnly = false;
            this.ucTextBoxEx.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucTextBoxEx.RectWidth = 1;
            this.ucTextBoxEx.RegexPattern = "";
            this.ucTextBoxEx.Size = new System.Drawing.Size(306, 38);
            this.ucTextBoxEx.TabIndex = 4;
            this.ucTextBoxEx.Visible = false;
            // 
            // labelKey
            // 
            this.labelKey.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelKey.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelKey.Location = new System.Drawing.Point(0, 0);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(122, 38);
            this.labelKey.TabIndex = 2;
            this.labelKey.Text = "label2";
            this.labelKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucSplitLine_H1
            // 
            this.ucSplitLine_H1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ucSplitLine_H1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucSplitLine_H1.Location = new System.Drawing.Point(0, 83);
            this.ucSplitLine_H1.Name = "ucSplitLine_H1";
            this.ucSplitLine_H1.Size = new System.Drawing.Size(543, 1);
            this.ucSplitLine_H1.TabIndex = 3;
            this.ucSplitLine_H1.TabStop = false;
            // 
            // ucSplitLine_H2
            // 
            this.ucSplitLine_H2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ucSplitLine_H2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSplitLine_H2.Location = new System.Drawing.Point(0, 0);
            this.ucSplitLine_H2.Name = "ucSplitLine_H2";
            this.ucSplitLine_H2.Size = new System.Drawing.Size(543, 1);
            this.ucSplitLine_H2.TabIndex = 4;
            this.ucSplitLine_H2.TabStop = false;
            // 
            // InfluxConfigBox
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.ucSplitLine_H1);
            this.Controls.Add(this.ucSplitLine_H2);
            this.Controls.Add(this.splitContainer1);
            this.Name = "InfluxConfigBox";
            this.Size = new System.Drawing.Size(543, 84);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void ucBtnBrowser_BtnClick(object sender, EventArgs e)
        {
            FolderBrowserDialog foldDig = new FolderBrowserDialog();
             if(foldDig.ShowDialog(this.FindForm())==DialogResult.OK)
            {
                ucTextBoxEx.InputText = foldDig.SelectedPath;
           
            }
        }
    }
}
