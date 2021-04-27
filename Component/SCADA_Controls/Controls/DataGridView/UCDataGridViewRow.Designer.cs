﻿// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-09-2019
//
// ***********************************************************************
// <copyright file="UCDataGridViewRow.Designer.cs">
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
    /// Class UCDataGridViewRow.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    partial class UCDataGridViewRow
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
            this.ucSplitLine_H1 = new Scada.Controls.Controls.UCSplitLine_H();
            this.panCells = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // ucSplitLine_H1
            // 
            this.ucSplitLine_H1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ucSplitLine_H1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucSplitLine_H1.Location = new System.Drawing.Point(0, 55);
            this.ucSplitLine_H1.Name = "ucSplitLine_H1";
            this.ucSplitLine_H1.Size = new System.Drawing.Size(661, 1);
            this.ucSplitLine_H1.TabIndex = 0;
            this.ucSplitLine_H1.TabStop = false;
            // 
            // panCells
            // 
            this.panCells.ColumnCount = 1;
            this.panCells.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panCells.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panCells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panCells.Location = new System.Drawing.Point(0, 0);
            this.panCells.Name = "panCells";
            this.panCells.RowCount = 1;
            this.panCells.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panCells.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panCells.Size = new System.Drawing.Size(661, 55);
            this.panCells.TabIndex = 1;
            // 
            // UCDataGridViewItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panCells);
            this.Controls.Add(this.ucSplitLine_H1);
            this.Name = "UCDataGridViewItem";
            this.Size = new System.Drawing.Size(661, 56);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The uc split line h1
        /// </summary>
        private UCSplitLine_H ucSplitLine_H1;
        /// <summary>
        /// The pan cells
        /// </summary>
        private System.Windows.Forms.TableLayoutPanel panCells;
    }
}
