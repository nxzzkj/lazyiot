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
 * 文件名称: UIDoughnutChart.cs
 * 文件说明: 甜甜圈图
 * 当前版本: V2.2
 * 创建日期: 2020-06-06
 *
 * 2020-06-06: V2.2.5 增加文件说明
******************************************************************************/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sunny.UI
{
    [ToolboxItem(true), Description("甜甜圈图")]
    public class UIDoughnutChart : UIChart
    {
        protected override void CreateEmptyOption()
        {
            if (emptyOption != null) return;

            UIDoughnutOption option = new UIDoughnutOption();

            option.Title = new UITitle();
            option.Title.Text = "SunnyUI";
            option.Title.SubText = "DoughnutChart";

            var series = new UIDoughnutSeries();
            series.Name = "饼状图";
            series.Center = new UICenter(50, 55);
            series.Radius.Inner = 40;
            series.Radius.Outer = 70;
            for (int i = 0; i < 5; i++)
            {
                series.AddData("Data" + i, (i + 1) * 20);
            }

            option.Series.Add(series);
            emptyOption = option;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            CalcData(DoughnutOption);
        }

        protected override void DrawOption(Graphics g)
        {
            if (DoughnutOption == null) return;
            DrawTitle(g, DoughnutOption.Title);
            DrawSeries(g, DoughnutOption.Series);
            DrawLegend(g, DoughnutOption.Legend);
        }

        protected override void CalcData(UIOption option)
        {
            Angles.Clear();
            UIDoughnutOption o = (UIDoughnutOption)option;
            if (o == null || o.Series == null || o.Series.Count == 0) return;

            for (int pieIndex = 0; pieIndex < o.Series.Count; pieIndex++)
            {
                var pie = o.Series[pieIndex];
                Angles.TryAdd(pieIndex, new ConcurrentDictionary<int, Angle>());

                double all = 0;
                foreach (var data in pie.Data)
                {
                    all += data.Value;
                }

                if (all.IsZero()) return;
                float start = 0;
                for (int i = 0; i < pie.Data.Count; i++)
                {
                    float angle = (float)(pie.Data[i].Value * 360.0f / all);
                    float percent = (float)(pie.Data[i].Value * 100.0f / all);
                    string text = "";
                    if (o.ToolTip != null)
                    {
                        try
                        {
                            UITemplate template = new UITemplate(o.ToolTip.Formatter);
                            template.Set("a", pie.Name);
                            template.Set("b", pie.Data[i].Name);
                            template.Set("c", pie.Data[i].Value.ToString(o.ToolTip.ValueFormat));
                            template.Set("d", percent.ToString("F2"));
                            text = template.Render();
                        }
                        catch
                        {
                            text = pie.Data[i].Name + " : " + pie.Data[i].Value.ToString("F2") + "(" + percent.ToString("F2") + "%)";
                            if (pie.Name.IsValid()) text = pie.Name + '\n' + text;
                        }
                    }

                    Angle pieAngle = new Angle(start, angle, text);
                    GetSeriesRect(pie, ref pieAngle);
                    Angles[pieIndex].AddOrUpdate(i, pieAngle);
                    start += angle;
                }
            }
        }

        private void DrawSeries(Graphics g, List<UIDoughnutSeries> series)
        {
            if (series == null || series.Count == 0) return;

            for (int pieIndex = 0; pieIndex < series.Count; pieIndex++)
            {
                var pie = series[pieIndex];

                for (int azIndex = 0; azIndex < pie.Data.Count; azIndex++)
                {
                    Angle angle = Angles[pieIndex][azIndex];
                    Color color = ChartStyle.GetColor(azIndex);
                    UIPieSeriesData data = pie.Data[azIndex];
                    if (data.StyleCustomMode) color = data.Color;

                    if (ActiveAzIndex == azIndex)
                        g.FillFan(color, angle.Center, angle.Inner, angle.Outer + 5, angle.Start - 90, angle.Sweep);
                    else
                        g.FillFan(color, angle.Center, angle.Inner, angle.Outer, angle.Start - 90, angle.Sweep);

                    Angles[pieIndex][azIndex].TextSize = g.MeasureString(Angles[pieIndex][azIndex].Text, LegendFont);

                    if (pie.Label.Show && ActiveAzIndex == azIndex)
                    {
                        if (pie.Label.Position == UIPieSeriesLabelPosition.Center)
                        {
                            SizeF sf = g.MeasureString(pie.Data[azIndex].Name, Font);
                            g.DrawString(pie.Data[azIndex].Name, Font, color, angle.Center.X - sf.Width / 2.0f, angle.Center.Y - sf.Height / 2.0f);
                        }
                    }
                }
            }
        }

        private readonly ConcurrentDictionary<int, ConcurrentDictionary<int, Angle>> Angles = new ConcurrentDictionary<int, ConcurrentDictionary<int, Angle>>();

        [Browsable(false)]
        private UIDoughnutOption DoughnutOption
        {
            get
            {
                UIOption option = Option ?? EmptyOption;
                UIDoughnutOption o = (UIDoughnutOption)option;
                return o;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (DoughnutOption.SeriesCount == 0)
            {
                SetPieAndAzIndex(-1, -1);
                return;
            }

            for (int pieIndex = 0; pieIndex < DoughnutOption.SeriesCount; pieIndex++)
            {
                for (int azIndex = 0; azIndex < DoughnutOption.Series[pieIndex].Data.Count; azIndex++)
                {
                    Angle angle = Angles[pieIndex][azIndex];
                    PointF pf = angle.Center;
                    if (MathEx.CalcDistance(e.Location, pf) > angle.Outer) continue;
                    if (MathEx.CalcDistance(e.Location, pf) < angle.Inner) continue;
                    double az = MathEx.CalcAngle(e.Location, pf);
                    if (az >= angle.Start && az <= angle.Start + angle.Sweep)
                    {
                        SetPieAndAzIndex(pieIndex, azIndex);
                        if (tip.Text != angle.Text)
                        {
                            tip.Text = angle.Text;
                            tip.Size = new Size((int)angle.TextSize.Width + 4, (int)angle.TextSize.Height + 4);
                        }

                        if (az >= 0 && az < 90)
                        {
                            tip.Top = e.Location.Y + 20;
                            tip.Left = e.Location.X - tip.Width;
                        }
                        else if (az >= 90 && az < 180)
                        {
                            tip.Left = e.Location.X - tip.Width;
                            tip.Top = e.Location.Y - tip.Height - 2;
                        }
                        else if (az >= 180 && az < 270)
                        {
                            tip.Left = e.Location.X;
                            tip.Top = e.Location.Y - tip.Height - 2;
                        }
                        else if (az >= 270 && az < 360)
                        {
                            tip.Left = e.Location.X + 15;
                            tip.Top = e.Location.Y + 20;
                        }

                        if (!tip.Visible) tip.Visible = angle.Text.IsValid();
                        return;
                    }
                }
            }

            SetPieAndAzIndex(-1, -1);
            tip.Visible = false;
        }

        private int ActiveAzIndex = -1;
        private int ActivePieIndex = -1;

        private void SetPieAndAzIndex(int pieIndex, int azIndex)
        {
            if (ActivePieIndex != pieIndex || ActiveAzIndex != azIndex)
            {
                ActivePieIndex = pieIndex;
                ActiveAzIndex = azIndex;
                Invalidate();
            }
        }

        private void GetSeriesRect(UIDoughnutSeries series, ref Angle angle)
        {
            int left = series.Center.Left;
            int top = series.Center.Top;
            left = Width * left / 100;
            top = Height * top / 100;

            angle.Center = new PointF(left, top);
            angle.Inner = Math.Min(Width, Height) * series.Radius.Inner / 200.0f;
            angle.Outer = Math.Min(Width, Height) * series.Radius.Outer / 200.0f;
        }

        private class Angle
        {
            public float Start { get; set; }

            public float Sweep { get; set; }

            public float Inner { get; set; }

            public float Outer { get; set; }

            public PointF Center { get; set; }

            public Angle(float start, float sweep, string text)
            {
                Start = start;
                Sweep = sweep;
                Text = text;
            }

            public string Text { get; set; }

            public SizeF TextSize { get; set; }
        }
    }
}