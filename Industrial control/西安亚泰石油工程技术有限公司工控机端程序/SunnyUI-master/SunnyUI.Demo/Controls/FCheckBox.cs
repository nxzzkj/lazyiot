﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sunny.UI.Demo
{
    public partial class FCheckBox : UITitlePage
    {
        public FCheckBox()
        {
            InitializeComponent();
            uiCheckBoxGroup1.SelectedIndexes = new List<int>() { 2, 4 };
        }

        private void uiCheckBoxGroup1_ValueChanged(object sender, int index, string text, bool isChecked)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SelectedIndexes: ");
            foreach (var selectedIndex in uiCheckBoxGroup1.SelectedIndexes)
            {
                sb.Append(selectedIndex);
                sb.Append(", ");
            }

            Console.WriteLine("SelectedIndex: " + index + ", SelectedText: " + text + "\n" + sb.ToString());
        }

        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            uiCheckBoxGroup1.SelectAll();
        }

        private void uiButton2_Click(object sender, System.EventArgs e)
        {
            uiCheckBoxGroup1.UnSelectAll();
        }

        private void uiButton3_Click(object sender, System.EventArgs e)
        {
            uiCheckBoxGroup1.ReverseSelected();
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            uiCheckBoxGroup1.SelectedIndexes = new List<int>() { 2, 4 };
        }
    }
}