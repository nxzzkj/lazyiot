namespace Scada.DBUtility
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    [Serializable]
    public class SCADAFlow_MultiChartDataBaseView : ISerializable
    {
        private string m_ConnectionString;

        public SCADAFlow_MultiChartDataBaseView()
        {
            this.m_ConnectionString = "";
            this.SqlString = "";
            this.JSON = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta charset='utf-8'>\r\n    <title>图表</title>\r\n    <!-- 引入 echarts.js -->\r\n    <script src='Content/js/echarts.js'></script>\r\n</head>\r\n<body style='height:100%; width:100%; overflow:hidden; margin:0;padding:0;'>\r\n    <!-- 为ECharts准备一个具备大小（宽高）的Dom -->\r\n    <div id='chart' style='width:{width}; height:{height};overflow:hidden; margin:0;padding:0;'></div>\r\n    <script type='text/javascript'>\r\n        // 基于准备好的dom，初始化echarts实例\r\n        var myChart = echarts.init(document.getElementById('chart'));\r\n        var data = genData(50);\r\n        option = {\r\n    title : {\r\n        text: '同名数量统计',\r\n        subtext: '纯属虚构',\r\n        x:'center'\r\n    },\r\n    tooltip : {\r\n        trigger: 'item',\r\n        formatter: '{a} <br/>{b} : {c} ({d}%)'\r\n    },\r\n    legend: {\r\n        type: 'scroll',\r\n        orient: 'vertical',\r\n        right: 10,\r\n        top: 20,\r\n        bottom: 20,\r\n        data: data.legendData,\r\n\r\n        selected: data.selected\r\n    },\r\n    series : [\r\n        {\r\n            name: '姓名',\r\n            type: 'pie',\r\n            radius : '55%',\r\n            center: ['40%', '50%'],\r\n            data: data.seriesData,\r\n            itemStyle: {\r\n                emphasis: {\r\n                    shadowBlur: 10,\r\n                    shadowOffsetX: 0,\r\n                    shadowColor: 'rgba(0, 0, 0, 0.5)'\r\n                }\r\n            }\r\n        }\r\n    ]\r\n};\r\n        function genData(count) {\r\n    var nameList = [\r\n        '赵', '钱', '孙', '李', '周', '吴', '郑', '王', '冯', '陈', '褚', '卫', '蒋', '沈', '韩', '杨', '朱', '秦', '尤', '许', '何', '吕', '施', '张', '孔', '曹', '严', '华', '金', '魏', '陶', '姜', '戚', '谢', '邹', '喻', '柏', '水', '窦', '章', '云', '苏', '潘', '葛', '奚', '范', '彭', '郎', '鲁', '韦', '昌', '马', '苗', '凤', '花', '方', '俞', '任', '袁', '柳', '酆', '鲍', '史', '唐', '费', '廉', '岑', '薛', '雷', '贺', '倪', '汤', '滕', '殷', '罗', '毕', '郝', '邬', '安', '常', '乐', '于', '时', '傅', '皮', '卞', '齐', '康', '伍', '余', '元', '卜', '顾', '孟', '平', '黄', '和', '穆', '萧', '尹', '姚', '邵', '湛', '汪', '祁', '毛', '禹', '狄', '米', '贝', '明', '臧', '计', '伏', '成', '戴', '谈', '宋', '茅', '庞', '熊', '纪', '舒', '屈', '项', '祝', '董', '梁', '杜', '阮', '蓝', '闵', '席', '季', '麻', '强', '贾', '路', '娄', '危'\r\n    ];\r\n    var legendData = [];\r\n    var seriesData = [];\r\n    var selected = {};\r\n    for (var i = 0; i < 50; i++) {\r\n        name = Math.random() > 0.65\r\n            ? makeWord(4, 1) + '\x00b7' + makeWord(3, 0)\r\n            : makeWord(2, 1);\r\n        legendData.push(name);\r\n        seriesData.push({\r\n            name: name,\r\n            value: Math.round(Math.random() * 100000)\r\n        });\r\n        selected[name] = i < 6;\r\n    }\r\n\r\n    return {\r\n        legendData: legendData,\r\n        seriesData: seriesData,\r\n        selected: selected\r\n    };\r\n\r\n    function makeWord(max, min) {\r\n        var nameLen = Math.ceil(Math.random() * max + min);\r\n        var name = [];\r\n        for (var i = 0; i < nameLen; i++) {\r\n            name.push(nameList[Math.round(Math.random() * nameList.length - 1)]);\r\n        }\r\n        return name.join('');\r\n    }\r\n}\r\n        // 使用刚指定的配置项和数据显示图表。\r\n        myChart.setOption(option);\r\n    </script>\r\n</body>\r\n</html>";
            this.ValueType = SCADAFlow_DataBaseType.Table;
            this.AutoPage = false;
        }

        protected SCADAFlow_MultiChartDataBaseView(SerializationInfo info, StreamingContext context)
        {
            this.m_ConnectionString = "";
            this.Connection = (ScadaConnectionBase) info.GetValue("Connection", typeof(ScadaConnectionBase));
            this.SqlString = (string) info.GetValue("SqlString", typeof(string));
            this.JSON = (string) info.GetValue("JSON", typeof(string));
            this.m_ConnectionString = (string) info.GetValue("m_ConnectionString", typeof(string));
            this.AutoPage = (bool) info.GetValue("AutoPage", typeof(bool));
            this.ValueType = (SCADAFlow_DataBaseType) info.GetValue("ValueType", typeof(SCADAFlow_DataBaseType));
        }

        public string GetHtmlDataString(string uid)
        {
            if (this.Connection != null)
            {
                this.ConnectionString = this.Connection.ConnectionString;
            }
            return (" data-dbmultiple='json_" + uid + "' data-datetime=''  ");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("JSON", this.JSON);
            info.AddValue("m_ConnectionString", this.m_ConnectionString);
            info.AddValue("Connection", this.Connection);
            info.AddValue("SqlString", this.SqlString);
            info.AddValue("ValueType", this.ValueType);
            info.AddValue("AutoPage", this.AutoPage);
        }

        public string GetObjectJson(string uid)
        {
            string str = ScadaJsonConvertor.ObjectToJson(this);
            string[] textArray1 = new string[] { " <script id='json_", uid, "' type='application/json'> ", str, "</script>" };
            return string.Concat(textArray1);
        }

        public override string ToString()
        {
            if (this.Connection != null)
            {
                return this.Connection.ToString();
            }
            return "";
        }

        public SCADAFlow_DataBaseType ValueType { get; set; }

        public string SqlString { get; set; }

        public string JSON { get; set; }

        public bool AutoPage { get; set; }

        public string ConnectionString
        {
            get
            {
                return this.m_ConnectionString;
            }
            set
            {
                this.m_ConnectionString = value;
            }
        }

        public ScadaConnectionBase Connection { get; set; }
    }
}

