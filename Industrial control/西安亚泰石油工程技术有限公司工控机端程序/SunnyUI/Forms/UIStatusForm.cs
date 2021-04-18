﻿/******************************************************************************
 * SunnyUI 开源控件库、工具类库、扩展类库、多页面开发框架。
 * CopyRight (C) 2012-2020 ShenYongHua(沈永华).
 * QQ群：56829229 QQ：17612584 EMail：SunnyUI@qq.com
 *
 * Blog:   https://www.cnblogs.com/yhuse
 * Gitee:  https://gitee.com/yhuse/SunnyUI
 * GitHub: https://github.com/yhuse/SunnyUI
 *
 * SunnyUI.dll can be used for free under the GPL-3.0 license.
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 文件名称: UIStatusForm.cs
 * 文件说明: 进度提示窗体
 * 当前版本: V2.2
 * 创建日期: 2020-05-05
 *
 * 2020-05-05: V2.2.5 增加文件
******************************************************************************/

using System.ComponentModel;

namespace Sunny.UI
{
    public sealed partial class UIStatusForm : UIForm
    {
        public UIStatusForm()
        {
            InitializeComponent();
        }

        [DefaultValue(100)]
        public int Maximum
        {
            get => processBar.Maximum;
            set => processBar.Maximum = value;
        }

        [DefaultValue(0)]
        public int Value
        {
            get => processBar.Value;
            set => processBar.Value = value;
        }

        public void StepIt()
        {
            processBar.StepIt();
        }

        [DefaultValue(1)]
        public int Step
        {
            get => processBar.Step;
            set => processBar.Step = value;
        }

        [DefaultValue(true)]
        public bool ShowValue
        {
            get => processBar.ShowValue;
            set => processBar.ShowValue = value;
        }

        /// <summary>
        /// 进度到达最大值时自动隐藏
        /// </summary>
        [DefaultValue(true)]
        public bool MaxAutoHide { get; set; } = true;

        private void processBar_ValueChanged(object sender, int value)
        {
            if (MaxAutoHide && value == Maximum)
            {
                Hide();
            }
        }

        public void Show(string title, string desc, int max = 100, int value = 0)
        {
            Text = title;
            labelDescription.Text = desc;
            processBar.Maximum = max;
            processBar.Value = value;
            Show();
        }

        public string Description
        {
            get => labelDescription.Text;
            set => labelDescription.Text = value;
        }

    }
}
