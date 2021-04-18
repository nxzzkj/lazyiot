﻿// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-11
//
// ***********************************************************************
// <copyright file="UCMindMappingPanel.Designer.cs">
//     Copyright by Huang Zhenghui(黄正辉) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub：https://github.com/kwwwvagaa/NetWinformControl
// gitee：https://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
namespace Scada.Controls.Controls
{
    /// <summary>
    /// Class UCMindMappingPanel.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    partial class UCMindMappingPanel
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ucMindMapping1 = new Scada.Controls.Controls.UCMindMapping();
            this.SuspendLayout();
            // 
            // ucMindMapping1
            // 
            this.ucMindMapping1.Location = new System.Drawing.Point(0, 0);
            this.ucMindMapping1.Name = "ucMindMapping1";
            this.ucMindMapping1.Size = new System.Drawing.Size(200, 200);
            this.ucMindMapping1.TabIndex = 0;
            // 
            // UCMindMappingPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucMindMapping1);
            this.Name = "UCMindMappingPanel";
            this.Size = new System.Drawing.Size(200, 200);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The uc mind mapping1
        /// </summary>
        private UCMindMapping ucMindMapping1;
    }
}
