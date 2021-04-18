using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ScadaWeb.Web.Areas.Scada.Models
{
    /// <summary>
    /// 定义Echart对象
    /// </summary>
    public class EChartOption
    {
        public EChartOption()
        {
            legend = new Legend();
            grid = new Grid();
            toolbox = new toolbox();
        }
        public string serverid
        {
            set;
            get;
        }
        public string communicateid
        {
            set;get;
        }
        public string deviceid
        {
            set; get;
        }
        /// <summary>
        /// 曲线图例
        /// </summary>
        public Legend legend
        {
            set;
            get;
        }
        public Grid grid
        {
            set;
            get;
        }
        public Axis[] xAxis { set; get; }
        public Axis[] yAxis { set; get; }
        public Series[] series { set; get; }
        public toolbox toolbox { set; get; }
        public string name { set; get; }


    }
    public class Legend
    {
        public Legend()
        {
            this.show = true;
            this.orient = "horizontal";
            this.align = "auto";
            this.backgroundColor = "transparent";
            this.borderColor = "#ccc";
            this.borderWidth = 1;
            this.borderRadius = 5;
            type = "plain";
        }
        /// <summary>
        /// 定义图例的data
        /// </summary>
        public string[] data
        {
            set;
            get;
        }
        public string type
        {
            set;
            get;
        }
        
        public bool show
        {
            set;
            get;
        }
        public string orient
        { set; get; }
        public string align
        {
            set;
            get;
        }
        public string backgroundColor
        {
            set;
            get;
        }
        public string borderColor
        {
            set;
            get;
        }
        public int borderWidth
        { set; get; }
        public int borderRadius
        {
            set;
            get;
        }
    }
    public class Grid
    {
        public Grid()
        {
            this.show = true;
       
            this.backgroundColor = "transparent";
            this.borderColor = "#ccc";
            this.borderWidth = 1;
        
        }
 
        public bool show { set; get; }
        public string backgroundColor
        {
            set;
            get;
        }
        public string borderColor
        {
            set;
            get;
        }
        public int borderWidth
        { set; get; }
      
    }
    public class Axis
    {
        public Axis()
        {
            show = true;
            gridIndex = 1;
            position = "bottom";
            nameLocation = "center";
            splitNumber = 5;
            nameTextStyle = new nameTextStyle();
            interval = 5;
            silent = false;
            axisLine = new axisLine();
            axisTick = new axisTick();
            minorTick = new minorTick();
            axisLabel = new axisLabel();
            splitLine = new splitLine();
            scale = true;


        }
      
        public bool show { set; get; }
        public int gridIndex { set; get; }
        public string position { set; get; }
        [DataMember(Name = "type")]
        public string type { set; get; }
        public string name
        {
            set;
            get;
        }
        public bool scale
        { set; get; }
        public string nameLocation
        { set; get; }
        public int splitNumber
        { set; get; }
        public nameTextStyle nameTextStyle
        { set; get; }
        public int minInterval
        { set; get; }
      
        public int interval { set; get; }
        public bool silent { set; get; }
        public axisLine axisLine { set; get; }
        public axisTick axisTick { set; get; }
        public minorTick minorTick { set; get; }
        public axisLabel axisLabel { set; get; }
        public splitLine splitLine { set; get; }
        public string[] data { set; get; }
 
    }
    public class nameTextStyle
    {
        public nameTextStyle()
        {
            fontStyle = "normal";
            fontWeight = "normal";
            fontFamily = "sans-serif";
            fontSize = 12;
            align = "center";
        }
        
        public string fontStyle { set; get; }
        public string fontWeight { set; get; }
        public string fontFamily { set; get; }
        public int fontSize { set; get; }
        public string align { set; get; }
    }
    public class axisLine
    {
        public axisLine()
        {
            show = true;
            onZero = false;
            symbol = "none";
            lineStyle = new lineStyle();
        }
        public bool show { set; get; }
        public bool onZero { set; get; }
        public string symbol { set; get; }
        public lineStyle lineStyle { set; get; }

    }
    public class lineStyle
    {
        public lineStyle()
        {
            color = "#333";
            width = 1;
           type = "solid";
        }
       public string color { set; get; }
        public int width { set; get; }
        [DataMember(Name = "type")]
        public string type { set; get; }
    }
    public class axisTick
    {
        public axisTick()
        {
            show = true;
            alignWithLabel = true;
            interval = 5;
            length = 5;
            lineStyle = new lineStyle();
        }
        public bool show { set; get; }
        public bool alignWithLabel { set; get; }
        public int interval { set; get; }
        public int length { set; get; }
        public lineStyle lineStyle { set; get; }
    }
    public class minorTick
    {
        public minorTick()
        {
            show = true;
            splitNumber = 5;
            length = 5;
            lineStyle = new lineStyle();
        }
        public bool show { set; get; }
        public int splitNumber { set; get; }
        public int length { set; get; }
        public lineStyle lineStyle { set; get; }


    }
    public class axisLabel
    {
        public axisLabel()
        {
            show = true;
            interval = "auto";
            rotate = 0;
            fontFamily = "sans-serif";
            fontStyle = "normal";
            fontWeight = "normal";
            fontSize = 12;
            align = "center";
            verticalAlign = "middle";
            backgroundColor = "transparent";
            borderColor = "transparent";
            borderWidth = 0;
            textBorderColor = "transparent";

        }
        public bool show { set; get; }
        public string interval { set; get; }
        public int rotate { set; get; }
 
        public string fontStyle { set; get; }
        public string fontWeight { set; get; }
        public string fontFamily { set; get; }
        public int fontSize { set; get; }
        public string align { set; get; }
        public string verticalAlign { set; get; }
        public string backgroundColor { set; get; }
        public string borderColor { set; get; }
        public int borderWidth { set; get; }
 public string textBorderColor { set; get; }





    }
    public class splitLine
    {
        public splitLine()
        {
            show = true;
            interval = "auto";
            lineStyle = new lineStyle();

        }
        public bool show { set; get; }
        public string interval { set; get; }
        public lineStyle lineStyle { set; get; }

    }
  
  
    public class splitArea
    {
        public splitArea()
        {
            show = false;
            interval = "auto";
        }
        public string interval { set; get; }
        public bool show { set; get; }
    }

    public class Series
    {
        public string id
        { set; get; }
        public Series()
        {
            xAxisIndex = 0;
            yAxisIndex = 0;
             type = "line";
            symbol = "emptyCircle";
            coordinateSystem = "cartesian2d";
            symbolSize = 3;
            showSymbol = true;
            stack = false;
            connectNulls = false;
            clip = true;
            step = false;
            label = new Label();
            itemStyle = new ItemStyle();
            lineStyle = new lineStyle();
            areaStyle = new areaStyle();
            smooth = false;
            sampling = false;
       
        }

        [DataMember(Name = "type")]
        public string type { set; get; }

        public string name { set; get; }
        public string coordinateSystem { set; get; }
        public int xAxisIndex { set; get; }
        public int yAxisIndex { set; get; }
        public string symbol { set; get; }
        public int symbolSize { set; get; }
        public bool showSymbol { set; get; }
        public bool stack { set; get; }
        public bool connectNulls { set; get; }
        public bool clip { set; get; }
        public bool step { set; get; }
        public Label label { set; get; }
        public ItemStyle itemStyle { set; get; }
        public lineStyle lineStyle { set; get; }
        public areaStyle areaStyle { set; get; }
        public bool smooth { set; get; }
        public bool sampling { set; get; }
        public double[] data { set; get; }
    }
    public class Label
    {
        public Label()
        {
            show = false;
            position = "top";
            distance = 5;
            color = "#fff";
            fontStyle = "normal";
            fontWeight = "normal";
            fontFamily = "sans-serif";
            fontSize = 12;
            align = "center";
            verticalAlign = "middle";
            backgroundColor = "transparent";
            borderColor = "transparent";
            borderWidth = 0;
          
        }
        public bool show { set; get; }
        public string position { set; get; }
        public int distance { set; get; }
        public int rotate { set; get; }
        public string formatter { set; get; }
        public string color { set; get; }
        public string fontStyle { set; get; }
        public string fontWeight { set; get; }
        public string fontFamily { set; get; }
        public int fontSize { set; get; }
        public string align { set; get; }
        public string verticalAlign { set; get; }
        public string backgroundColor { set; get; }
        public string borderColor { set; get; }
        public int borderWidth { set; get; }

    }

    public class ItemStyle
    {
        public ItemStyle()
        {
            borderColor = "#000";
            borderWidth = 0;
            borderType = "solid";
        }
 
        public string borderColor { set; get; }
        public int borderWidth { set; get; }
        public string borderType { set; get; }
      
    }
    public class areaStyle
    {
        public areaStyle()
        {
            color = "#000";
            origin = "auto";
        }
  
        public string color { set; get; }
        public string origin { set; get; }
    }
    public class toolbox
    {
        public toolbox()
        {
            show = true;
            orient = "horizontal";
            showTitle = false;
            feature = new feature();
        }
     
        public bool show { set; get; }
        public string orient { set; get; }
        public bool showTitle { set; get; }
        public feature feature { set; get; }

    }
    public class feature
    {
        public feature()
        {
            saveAsImage = true;
            restore = true;
            dataView = true;
            dataZoom = true;
            magicType = true;
        }
        public bool saveAsImage { set; get; }
        public bool restore { set; get; }
        public bool dataView { set; get; }
        public bool dataZoom { set; get; }
        public bool magicType { set; get; }
    }

}