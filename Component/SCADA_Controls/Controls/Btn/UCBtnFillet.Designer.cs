﻿// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="UCBtnFillet.Designer.cs">
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
    /// Class UCBtnFillet.
    /// Implements the <see cref="Scada.Controls.Controls.UCControlBase" />
    /// </summary>
    /// <seealso cref="Scada.Controls.Controls.UCControlBase" />
    partial class UCBtnFillet
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
            this.lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbl.Image = global::Scada.Controls.Properties.Resources.alarm;
            this.lbl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl.Location = new System.Drawing.Point(0, 0);
            this.lbl.Name = "lbl";
            this.lbl.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbl.Size = new System.Drawing.Size(120, 76);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "按钮1   ";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_MouseDown);
            // 
            // UCBtnFillet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ConerRadius = 5;
            this.Controls.Add(this.lbl);
            this.IsShowRect = true;
            this.IsRadius = true;
            this.Name = "UCBtnFillet";
            this.Size = new System.Drawing.Size(120, 76);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The label
        /// </summary>
        private System.Windows.Forms.Label lbl;
    }
}
