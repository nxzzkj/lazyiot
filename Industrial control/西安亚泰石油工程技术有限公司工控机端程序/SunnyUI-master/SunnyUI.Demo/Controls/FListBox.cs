﻿using System;
using System.IO;

namespace Sunny.UI.Demo
{
    public partial class FListBox : UITitlePage
    {
        public FListBox()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            uiListBox1.Items.Clear();
            for (int i = 0; i < 50; i++)
            {
                uiListBox1.Items.Add(i);
            }

            uiImageListBox1.Items.Clear();
            string[] files = System.IO.Directory.GetFiles(DirEx.CurrentDir() + "Team",
                "*.png", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                uiImageListBox1.AddImage(file, file.FileInfo().Name);
            }
        }

        private void uiImageListBox1_ItemDoubleClick(object sender, System.EventArgs e)
        {
            this.ShowInfoDialog(uiImageListBox1.SelectedItem.ImagePath);
        }

        private void uiCheckBox1_ValueChanged(object sender, bool value)
        {
            uiImageListBox1.ShowDescription = !uiImageListBox1.ShowDescription;
            uiImageListBox1.ItemHeight = uiImageListBox1.ShowDescription ? 80 : 50;
        }

        private void uiListBox1_ItemDoubleClick(object sender, System.EventArgs e)
        {
            this.ShowInfoDialog(uiListBox1.SelectedItem.ToString());
        }

        private int num = 0;
        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            uiListBox1.Items.Add(DateTime.Now.ToString("yyyyMMdd") + "_" + num);
            num++;
        }

        private void uiButton1_DoubleClick(object sender, EventArgs e)
        {
            uiListBox1.Items.Add(DateTime.Now.ToString("yyyyMMdd") + "_double_" + num);
            num++;
        }
    }
}