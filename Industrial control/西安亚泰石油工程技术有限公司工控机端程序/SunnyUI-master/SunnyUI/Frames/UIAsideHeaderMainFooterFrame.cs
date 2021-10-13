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
 * 文件名称: UIAsideHeaderMainFooterFrame.cs
 * 文件说明: 页面框架(Aside-Header-Main-Footer)
 * 当前版本: V2.2
 * 创建日期: 2020-05-05
 *
 * 2020-05-05: V2.2.5 页面框架(Aside-Header-Main-Footer)
******************************************************************************/

namespace Sunny.UI
{
    public partial class UIAsideHeaderMainFooterFrame : UIAsideHeaderMainFrame
    {
        public UIAsideHeaderMainFooterFrame()
        {
            InitializeComponent();
            Controls.SetChildIndex(MainTabControl, 0);
            Header.Parent = this;
            Aside.Parent = this;
            MainTabControl.Parent = this;
            Footer.Parent = this;
            Header.BringToFront();
            Footer.BringToFront();
            MainTabControl.BringToFront();
            Aside.TabControl = MainTabControl;
        }
    }
}