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
 * 文件名称: UIIntegerUpDown.cs
 * 文件说明: 数字上下选择框
 * 当前版本: V2.2
 * 创建日期: 2020-01-01
 *
 * 2020-01-01: V2.2.0 增加文件说明
 * 2020-04-25: V2.2.4 更新主题配置类
 * 2020-08-14: V2.2.7 增加字体调整
******************************************************************************/

using System;
using System.ComponentModel;

namespace Sunny.UI
{
    [DefaultEvent("ValueChanged")]
    [DefaultProperty("Value")]
    public sealed partial class UIIntegerUpDown : UIPanel
    {
        public delegate void OnValueChanged(object sender, int value);

        public UIIntegerUpDown()
        {
            InitializeComponent();
            ShowText = false;
        }

        public event OnValueChanged ValueChanged;

        private int _value;

        [DefaultValue(0)]
        [Description("选中数值"), Category("SunnyUI")]
        public int Value
        {
            get => _value;
            set
            {
                value = CheckMaxMin(value);
                _value = value;
                pnlValue.Text = _value.ToString();
                ValueChanged?.Invoke(this, _value);
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (pnlValue != null) pnlValue.Font = Font;
        }

        private int step = 1;

        [DefaultValue(1)]
        [Description("步进值"), Category("SunnyUI")]
        public int Step
        {
            get => step;
            set { step = Math.Max(1, value); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Value += Step;
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            Value -= Step;
        }

        private int _maximum = int.MaxValue;
        private int _minimum = int.MinValue;

        [Description("最大值"), Category("SunnyUI")]
        [DefaultValue(int.MaxValue)]
        public int Maximum
        {
            get => _maximum;
            set
            {
                _maximum = value;
                if (_maximum < _minimum)
                    _minimum = _maximum;

                Value = CheckMaxMin(Value);
                Invalidate();
            }
        }

        [Description("最小值"), Category("SunnyUI")]
        [DefaultValue(int.MinValue)]
        public int Minimum
        {
            get => _minimum;
            set
            {
                _minimum = value;
                if (_minimum > _maximum)
                    _maximum = _minimum;

                Value = CheckMaxMin(Value);
                Invalidate();
            }
        }

        private int CheckMaxMin(int value)
        {
            if (hasMaximum)
            {
                if (value > _maximum)
                    value = _maximum;
            }

            if (hasMinimum)
            {
                if (value < _minimum)
                    value = _minimum;
            }

            return value;
        }

        private bool hasMaximum;
        private bool hasMinimum;

        [DefaultValue(false)]
        [Description("检查最大值"), Category("SunnyUI")]
        public bool HasMaximum
        {
            get => hasMaximum;
            set
            {
                if (hasMaximum != value)
                {
                    hasMaximum = value;
                    Value = CheckMaxMin(Value);
                    Invalidate();
                }
            }
        }

        [DefaultValue(false)]
        [Description("检查最小值"), Category("SunnyUI")]
        public bool HasMinimum
        {
            get => hasMinimum;
            set
            {
                if (hasMinimum != value)
                {
                    hasMinimum = value;
                    Value = CheckMaxMin(Value);
                    Invalidate();
                }
            }
        }
    }
}