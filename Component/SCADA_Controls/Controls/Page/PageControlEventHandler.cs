// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-09-2019
//
// ***********************************************************************
// <copyright file="PageControlEventHandler.cs">
//     Copyright by Huang Zhenghui(黄正辉) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub：https://github.com/kwwwvagaa/NetWinformControl
// gitee：https://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Scada.Controls.Controls
{
    /// <summary>
    /// Delegate PageControlEventHandler
    /// </summary>
    /// <param name="currentSource">The current source.</param>
    [Serializable]
    [ComVisible(true)]
    public delegate void PageControlEventHandler(object currentSource);
    public class PageSizeItem
    {
        public PageSizeItem()
        { }
        public PageSizeItem(int pagesize,string text)
        {
            PageSize = pagesize;
            Text = text;
        }
        public string Text = "";
        public int PageSize = 100;
        public override string ToString()
        {
            return Text;
        }

    }
    [Serializable]
    [ComVisible(true)]
    public delegate void PageChanged(int pageindex);
}
