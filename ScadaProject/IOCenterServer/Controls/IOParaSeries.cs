using ScadaCenterServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using Scada.Model;

namespace ScadaCenterServer.Controls
{
    public class IOSeriesDataPoint : DataPoint
    {
        public IOSeriesDataPoint(string date)
        {
            DateTimeString = date;
        }
        public string DateTimeString = "";
    }
    /// <summary>
    /// 定义实时曲线类
    /// </summary>
    public class IOParaSeries : Series
    {

        public IOParaSeries(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device, IO_PARA para)
        {
            this.Name = para.IO_NAME;
            this.LegendText = para.IO_LABEL;
            this.ChartType = SeriesChartType.Line;
            this.BorderWidth = 4;
            this.MarkerSize = 4;
            this.MarkerStep = 1;
            this.MarkerStyle = MarkerStyle.Circle;
            this.MarkerColor = System.Drawing.Color.Black;
            this.ChartArea = "IOChartArea";
            this.Para = para;
            this.Server = server;
            this.Communication = communication;
            this.Device = device;
            this.XValueType = ChartValueType.Time;
            this.YValueType = ChartValueType.Double;
            this.Color = System.Drawing.Color.FromArgb(155 + IOCenterManager.QueryFormManager.MainRandom.Next(100), 155 + IOCenterManager.QueryFormManager.MainRandom.Next(100), IOCenterManager.QueryFormManager.MainRandom.Next(255));


        }
        public IO_DEVICE Device = null;
        public IO_COMMUNICATION Communication = null;
        public IO_SERVER Server = null;
        public IO_PARA Para = null;
        /// <summary>
        /// 刷新实时数据,只绘制模拟量曲线
        /// </summary>
        public void RefreshRealData()
        {
            ///只绘制模拟量曲线
            if (Para != null && Para.IO_POINTTYPE.Trim() == "模拟量")
            {
                if (this.Points.Count > 100)
                {
                    this.Points.RemoveAt(0);

                }
                IOSeriesDataPoint dp = new IOSeriesDataPoint(Para.RealDate);
                dp.SetValueXY(Para.RealDate, new object[1] { Para.RealValue });
                if(this.Points.Count>0)
                {
                    if (((IOSeriesDataPoint)this.Points[this.Points.Count - 1]).DateTimeString.Trim() == Para.RealDate.Trim())
                    {
                        return;
                    }

                }
                  
                this.Points.Add(dp);
                if (Para.RealQualityStamp == Scada.IOStructure.QualityStamp.GOOD)
                {
                    this.Points[this.Points.Count - 1].IsEmpty = false;
                }
                else
                {
                    this.Points[this.Points.Count - 1].IsEmpty = true;
                }
                this.Points[this.Points.Count - 1].ToolTip = "时间:" + Para.RealDate + ",值:" + Para.RealValue;


            }
        }

    }
}
