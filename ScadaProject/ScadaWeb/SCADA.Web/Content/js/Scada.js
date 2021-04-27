
//定义的标记点集合
var Marks=[];
//定义的矢量图集合
var Shapes=[];
//宁夏众智科技有限公司 Web SCADA 图形库
var SCADA = new SCADA_Application();
function SCADA_Application() {
    this.name = "宁夏众智科技有限公司SCADA系统";//公共属性
    this.refreshtime = "5s";//定义每10秒刷新一次

    //定义类的私有函数
    function newGuid() {

        var guid = "";
        for (var i = 1; i <= 32; i++) {
            var n = Math.floor(Math.random() * 16.0).toString(16);
            guid += n;
            if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                guid += "-";
        }

        return guid;
    };
    this.GetUrlParam = function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
        var r = window.location.search.substr(1).match(reg);  //匹配目标参数
        if (r != null) return unescape(r[2]); return null; //返回参数值
    }
    //定义一个实时数据读取定时器
    this.RealDataTimer = function (func) {
        func();
        $('#tableId').everyTime(refreshtime, func);
    };
    this.RealDataCustumTimer = function (func, time) {
        func();
        $('body').everyTime(time + 's', func);
    };

    Date.prototype.format = function (format) {
        var date = {
            "M+": this.getMonth() + 1,
            "d+": this.getDate(),
            "H+": this.getHours(),
            "m+": this.getMinutes(),
            "s+": this.getSeconds(),
            "q+": Math.floor((this.getMonth() + 3) / 3),
            "S+": this.getMilliseconds()
        };
        if (/(y+)/i.test(format)) {
            format = format.replace(RegExp.$1, (this.getFullYear() + '').substr(4 - RegExp.$1.length));
        }
        for (var k in date) {
            if (new RegExp("(" + k + ")").test(format)) {
                format = format.replace(RegExp.$1, RegExp.$1.length == 1
                       ? date[k] : ("00" + date[k]).substr(("" + date[k]).length));
            }
        }
        return format;
    }
    /**
     *  name layuiRowspan
     * @param fieldName  要合并列的field属性值
     * @param index 要合并列的索引值 从1开始(如果要合并第一列，则index = 1;) 
     * @desc 此方法适用于合并列冻结的单元格
     */
    this.LayuiRowspan = function (fieldName, index) {
        // 左侧列为冻结的情况
        var tbodyNode = document.getElementsByClassName("layui-table-fixed-l")[index - 1];
        var child = tbodyNode.getElementsByTagName("td");
        var childFilterArr = [];
        // 获取data-field属性为fieldName的td
        for (var i = 0; i < child.length; i++) {
            if (child[i].getAttribute("data-field") == fieldName) {
                childFilterArr.push(child[i]);
            }
        }
        // 获取td的个数和种类
        var childFilterTextObj = {};
        for (var i = 0; i < childFilterArr.length; i++) {
            var childText = childFilterArr[i].textContent;
            if (childFilterTextObj[childText] == undefined) {
                childFilterTextObj[childText] = 1;
            } else {
                var num = childFilterTextObj[childText];
                childFilterTextObj[childText] = num * 1 + 1;
            }
        }
        // 给获取到的td设置合并单元格属性
        for (var key in childFilterTextObj) {
            var tdNum = childFilterTextObj[key];
            var canRowspan = true;
            for (var i = 0; i < childFilterArr.length; i++) {
                if (childFilterArr[i].getAttribute("data-content") == key) {
                    if (canRowspan) {
                        childFilterArr[i].setAttribute("rowspan", tdNum);
                        canRowspan = false;
                    } else {
                        childFilterArr[i].style.display = "none";
                    }
                }
            }
        }
    }
    /**
     * name layui合并tbody中单元格的方法
     * @param fieldName  要合并列的field属性值
     * @param index 表格的索引值 从1开始
     * @desc 此方式适用于没有列冻结的单元格合并
     */
    this.AlarmTableRowSpan = function (fieldName, index) {
        var fixedNode = document.getElementsByClassName("layui-table-body")[index - 1];
        if (!fixedNode) {
            return false;
        }
        var child = fixedNode.getElementsByTagName("td");
        var childFilterArr = [];
        // 获取data-field属性为fieldName的td
        for (var i = 0; i < child.length; i++) {
            if (child[i].getAttribute("data-field") == fieldName) {
                childFilterArr.push(child[i]);
            }
        }
        // 获取td的个数和种类
        var childFilterTextObj = {};
        for (var i = 0; i < childFilterArr.length; i++) {
            var childText = childFilterArr[i].textContent;
            if (childFilterTextObj[childText] == undefined) {
                childFilterTextObj[childText] = 1;
            } else {
                var num = childFilterTextObj[childText];
                childFilterTextObj[childText] = num * 1 + 1;
            }
        }
        // 给获取到的td设置合并单元格属性
        for (var key in childFilterTextObj) {
            var tdNum = childFilterTextObj[key];
            var canRowSpan = true;
            for (var i = 0; i < childFilterArr.length; i++) {
                if (childFilterArr[i].textContent == key) {
                    if (canRowSpan) {
                        childFilterArr[i].setAttribute("rowspan", tdNum);
                        canRowSpan = false;
                    } else {
                        childFilterArr[i].style.display = "none";
                    }
                }
            }
        }
    }


    //Excel列与数字转换
    var stringArray = [];
    this.numToString = function (numm) {
        stringArray.length = 0;
        var numToStringAction = function (nnum) {
            var num = nnum;
            var a = parseInt(num / 26);
            var b = num % 26;
            stringArray.push(String.fromCharCode(64 + parseInt(b + 1)));
            if (a > 0) {
                numToStringAction(a);
            }
        }
        numToStringAction(numm);
        return stringArray.reverse().join("");
    }

    this.stringTonum = function (a) {
        var str = a.toLowerCase().split("");
        var num = 0;
        var al = str.length;
        var getCharNumber = function (charx) {
            return charx.charCodeAt() - 96;
        };
        var numout = 0;
        var charnum = 0;
        for (var i = 0; i < al; i++) {
            charnum = getCharNumber(str[i]);
            numout += charnum * Math.pow(26, al - i - 1);
        };
        return numout - 1;
    }
    ///
    function zero_fill_hex(num, digits) {
        var s = num.toString(16);
        while (s.length < digits)
            s = "0" + s;
        return s;
    }


    this.rgb2hex = function (rgb) {
        if (rgb == undefined || rgb == null)
            return "FFFFFF";
        if (rgb.charAt(0) == '#')
            return rgb;

        var ds = rgb.split(/\D+/);
        var decimal = Number(ds[1]) * 65536 + Number(ds[2]) * 256 + Number(ds[3]);

        return zero_fill_hex(decimal, 6);
    }
    /********************SVG图元部分*************************/
    //事件按钮执行程序，
    ///传入参数{ServerID:'6215D70759CD',CommunicateID:'4672485684583381463',DeviceID:'5587424197583872563',IOID:'5424964134456933629',Title:'事件名称',Message:'是否要写入？',IOType:'布尔值',ReturnResult:'False',SuccessResult:'1',FaultResult:'0',WriteFalseValue:'0',WriteTrueValue:'1'}

    ///角度转弧度
    function ConvertDegreesToRadians(degrees) {
        var radians = (3.1415926 / 180) * degrees;
        return (radians);
    }
    ///流程图统一的刷新时间
    this.UpdateFlowUpcycle = 3;
    ///动态修改svgShape的某个参数,value 采集值 eleid 是要修改的元素参数
    this.UpdateFlowValue = function (iovalue, time, status, datatype, uid) {
        var value = 0;
        if (iovalue == "-9999")
            return;

        if (!isNaN(iovalue)) {
            value = parseFloat(iovalue);
        }
        else {
            value = 0;
        }
        if (datatype == "Status") {
            value = parseInt(status);
        }
        else {
            value = parseFloat(iovalue);
        }

        try {



            //获取对应的shape 每个shape 有一个g,包含IO参数
            var shapeg = $("#shape" + uid);
            if (shapeg == undefined)
                return;
            var shapeName = shapeg.data("shape");
            var io = shapeg.data("iovalue");

            var ioserver = "";
            var iocommunicate = "";
            var iodevice = "";
            var iopara = "";
            var iotype = "";
            var ioformat = "";
            var iounit = "";

            if (io != undefined && io != "") {
                ioserver = io.split(",")[0];
                iocommunicate = io.split(",")[1];
                iodevice = io.split(",")[2];
                iopara = io.split(",")[3];
                iotype = io.split(",")[4];
                ioformat = io.split(",")[5];
                iounit = io.split(",")[6];

            }

            var rectstr = shapeg.data("rect");
            switch (shapeName) {
                //圆形进度条动态修改,此处重新修改Path参数
                case "SVG_ProcessEllipseShape":
                    {

                        var path = $("#shape" + uid + ">.ioupdate");
                        var text = $("#shape" + uid + ">.iotext");

                        var maxvalue = shapeg.data("maxvalue");
                        var showtype = shapeg.data("showtype");
                        var valuetype = shapeg.data("valuetype");
                        if (rectstr != undefined) {
                            var fltPercent = parseFloat(value) / maxvalue;
                            if (fltPercent > 1) {
                                fltPercent = 1;
                            }
                            var startAngle = parseFloat(shapeg.data("startangle"));
                            var sweepAngle = parseFloat(360 * fltPercent);
                            var arcflag = 0;
                            if (sweepAngle < 180) {
                                arcflag = 0;//绘制小圆弧
                            }
                            else {
                                arcflag = 1;//绘制大圆弧
                            }
                            var sweepflag = 1;
                            var rect = { x: parseFloat(rectstr.split(',')[0]), y: parseFloat(rectstr.split(',')[1]), width: parseFloat(rectstr.split(',')[2]), height: parseFloat(rectstr.split(',')[3]) };
                            var y = rect.height / 2 * Math.sin(ConvertDegreesToRadians(startAngle)) + (rect.y + rect.height / 2);
                            var x = rect.width / 2 * Math.cos(ConvertDegreesToRadians(startAngle)) + (rect.x + rect.width / 2);
                            var y2 = rect.height / 2 * Math.sin(ConvertDegreesToRadians(startAngle + sweepAngle)) + (rect.y + rect.height / 2)
                            var x2 = rect.width / 2 * Math.cos(ConvertDegreesToRadians(startAngle + sweepAngle)) + (rect.x + rect.width / 2);
                            var cy = (rect.y + rect.height / 2);
                            var cx = (rect.x + rect.width / 2);
                            if (showtype == "Ring") {
                                path.attr("d", "M" + x + "," + y + " A" + (rect.width / 2) + "," + rect.height / 2 + " 0 " + arcflag + "," + sweepflag + " " + x2 + "," + y2);
                            }
                            else {
                                path.attr("d", "M" + cx + "," + cy + " L" + x + "," + y + " A" + (rect.width / 2) + "," + rect.height / 2 + " 0 " + arcflag + "," + sweepflag + " " + x2 + "," + y2 + " L" + cx + "," + cy);

                            }

                            if (valuetype == "Percent") {
                                text.html(number_format(fltPercent * 100, ioformat, '.', ',', 'round') + "%");
                                text.text(number_format(fltPercent * 100, ioformat, '.', ',', 'round') + "%");
                            }
                            else {

                                text.html(number_format(value, ioformat, '.', ',', 'round'));
                                text.text(number_format(value, ioformat, '.', ',', 'round'));
                            }

                        };
                    }
                    break;
                //长方形进度条
                case "SVG_ProgressLineShape":
                    {


                        var linepath = $("#shape" + uid + ">.ioupdate");
                        var text = $("#shape" + uid + ">.iotext")
                        var rectstr = shapeg.data("rect");
                        var maxvalue = parseFloat(shapeg.data("maxvalue"));
                        var progressstyle = shapeg.data("progressstyle");
                        var startAngle = parseFloat(shapeg.data("startangle"));
                        if (rectstr != undefined) {

                            var baserect = { x: parseFloat(rectstr.split(',')[0]), y: parseFloat(rectstr.split(',')[1]), width: parseFloat(rectstr.split(',')[2]), height: parseFloat(rectstr.split(',')[3]) };
                            var fltPercent = Math.floor(value) / maxvalue;

                            if (progressstyle == "Horizontal") {
                                var num = parseFloat(value * (baserect.width - 2) / maxvalue);
                                var x1 = baserect.x;
                                var y1 = baserect.y + baserect.height / 2;
                                var x2 = baserect.x + (num + 1);
                                var y2 = baserect.y + baserect.height / 2;
                                linepath.attr("x1", x1);
                                linepath.attr("y1", y1);
                                linepath.attr("x2", x2);
                                linepath.attr("y2", y2);

                            }
                            else if (progressstyle == "Vertical") {
                                var num = parseFloat(value * (baserect.height - 2) / maxvalue);
                                var x1 = baserect.x + baserect.width / 2;
                                var y1 = baserect.y + baserect.height;
                                var x2 = baserect.x + baserect.width / 2;
                                var y2 = baserect.y + baserect.height - num;
                                linepath.attr("x1", x1);
                                linepath.attr("y1", y1);
                                linepath.attr("x2", x2);
                                linepath.attr("y2", y2);
                            }
                            else if (progressstyle == "Circular") {
                                var sweepAngle = parseFloat((value * 360) / maxvalue);

                                if (fltPercent > 1) {
                                    fltPercent = 1;
                                }
                                var arcflag = 0;
                                if (sweepAngle < 180) {
                                    arcflag = 0;//绘制小圆弧
                                }
                                else {
                                    arcflag = 1;//绘制大圆弧
                                }
                                var sweepflag = 1;
                                var arcrectstr = linepath.data("rect");
                                var arcrect = { x: parseFloat(arcrectstr.split(',')[0]), y: parseFloat(arcrectstr.split(',')[1]), width: parseFloat(arcrectstr.split(',')[2]), height: parseFloat(arcrectstr.split(',')[3]) };
                                var y = arcrect.height / 2 * Math.sin(ConvertDegreesToRadians(startAngle)) + (arcrect.y + arcrect.height / 2);
                                var x = arcrect.width / 2 * Math.cos(ConvertDegreesToRadians(startAngle)) + (arcrect.x + arcrect.width / 2);
                                var y2 = arcrect.height / 2 * Math.sin(ConvertDegreesToRadians(startAngle + sweepAngle)) + (arcrect.y + arcrect.height / 2)
                                var x2 = arcrect.width / 2 * Math.cos(ConvertDegreesToRadians(startAngle + sweepAngle)) + (arcrect.x + arcrect.width / 2);
                                var cy = (arcrect.y + arcrect.height / 2);
                                var cx = (arcrect.x + arcrect.width / 2);
                                linepath.attr("d", "M" + x + "," + y + " A" + (arcrect.width / 2) + "," + arcrect.height / 2 + " 0 " + arcflag + "," + sweepflag + " " + x2 + "," + y2);
                            }

                            var valuetype = shapeg.data("valuetype");

                            if (valuetype == "Percent") {
                                text.html(number_format(fltPercent * 100, ioformat, '.', ',', 'round') + "%");
                                text.text(number_format(fltPercent * 100, ioformat, '.', ',', 'round') + "%");
                            }
                            else {

                                text.html(number_format(value, ioformat, '.', ',', 'round'));
                                text.text(number_format(value, ioformat, '.', ',', 'round'));
                            }
                        };
                    }
                    break;
                case "SVG_AlarmLampShape":
                    {


                        var rectstr = shapeg.data("rect");
                        var animate = $("#animate" + uid);
                        var speed = shapeg.data("speed");
                        var truecolor = shapeg.data("truecolor");
                        var falsecolor = shapeg.data("falsecolor");
                        var lampcolor = shapeg.data("lampcolor");
                        var trueexpression = shapeg.data("iovaluetrue");
                        var trueop = trueexpression.split(":")[0];
                        var truevalue = parseFloat(trueexpression.split(":")[1]);
                        var falseexpression = shapeg.data("iovaluefalse");
                        var falseop = falseexpression.split(":")[0];
                        var falsevalue = parseFloat(falseexpression.split(":")[1]);
                        if (rectstr != undefined) {
                            var tv = analysisOpeartor(trueop, truevalue, value);
                            var fv = analysisOpeartor(falseop, falsevalue, value);
                            if (tv == true)
                                animate.attr("values", lampcolor + ";" + truecolor);
                            if (fv == true)
                                animate.attr("values", lampcolor + ";" + falsecolor);

                        };

                    }
                    break;
                case "SVG_ArrowShape":
                    {

                        var animate = $("#shape" + uid).find("animate");
                        var speed = shapeg.data("speed");
                        var truecolor = shapeg.data("truecolor");
                        var falsecolor = shapeg.data("falsecolor");
                        var arrowcolor = shapeg.data("arrowcolor");
                        var arrowcolor2 = shapeg.data("arrowcolor2");
                        var trueexpression = shapeg.data("iovaluetrue");
                        var trueop = trueexpression.split(":")[0];
                        var truevalue = parseFloat(trueexpression.split(":")[1]);
                        var falseexpression = shapeg.data("iovaluefalse");
                        var falseop = falseexpression.split(":")[0];
                        var falsevalue = parseFloat(falseexpression.split(":")[1]);
                        if (rectstr != undefined) {
                            var tv = analysisOpeartor(trueop, truevalue, value);
                            var fv = analysisOpeartor(falseop, falsevalue, value);
                            for (var i = 0; i < animate.length; i++) {
                                var values = animate[i].getAttribute("values");
                                var c1 = values.split(";")[0];
                                var c2 = values.split(";")[1];
                                if (tv == true) {
                                    c2 = truecolor;
                                }
                                else if (fv == true) {
                                    c2 = falsecolor;
                                }
                                animate[i].setAttribute("values", c1 + ";" + c2);
                            }


                        };

                    }
                    break;
                case "SVG_BatteryShape"://电池容器
                    {

                        var maxvalue = shapeg.data("maxvalue");
                        var batterystyle = shapeg.data("batterystyle");
                        var valuecolor = shapeg.data("valuecolor");
                        var valuetype = shapeg.data("valuecolor");

                        var rect = { x: parseFloat(rectstr.split(',')[0]), y: parseFloat(rectstr.split(',')[1]), width: parseFloat(rectstr.split(',')[2]), height: parseFloat(rectstr.split(',')[3]) };
                        var valuebody = $("#shape" + uid + ">.ioupdate")[0];
                        var valuetop = $("#shape" + uid + ">.ioupdate")[2];
                        var valuebottom = $("#shape" + uid + ">.ioupdate")[1];
                        if (batterystyle == "Horizontal")//水平
                        {
                            var x = (parseFloat(value) / parseFloat(maxvalue) * rect.width) * 0.86 + rect.width * 0.1;

                            valuebody.setAttribute("width", x);
                            valuetop.setAttribute("cx", rect.x + parseFloat(x) - rect.width * 0.03);
                        }
                        else { //垂直
                            var y = (rect.height - parseFloat(value) / parseFloat(maxvalue) * rect.height) * 0.86 + rect.height * 0.1 - rect.height * 0.03;

                            valuebody.setAttribute("y", rect.y + parseFloat(y));
                            valuebody.setAttribute("height", rect.height * 0.86 - ((parseFloat(y) - rect.height * 0.1)));

                            valuebottom.setAttribute("cy", rect.y + parseFloat(y) + rect.height * 0.05);

                            valuetop.setAttribute("cy", rect.y + parseFloat(y));

                        }
                        //修改文字内容
                        var fltPercent = parseFloat(value) / parseFloat(maxvalue);
                        var valuetype = shapeg.data("valuetype");
                        var text = $("#shape" + uid + ">.iotext");
                        if (valuetype == "Percent") {
                            text.html(number_format(fltPercent * 100, ioformat, '.', ',', 'round') + "%");
                            text.text(number_format(fltPercent * 100, ioformat, '.', ',', 'round') + "%");
                        }
                        else {

                            text.html(number_format(value, ioformat, '.', ',', 'round'));
                            text.text(number_format(value, ioformat, '.', ',', 'round'));
                        }

                    }
                    break;
                case "SVG_ClassifierShape"://分类器
                    {
                        var text = $("#shape" + uid + ">.iotext");
                        text.html(number_format(value, ioformat, '.', ',', 'round'));
                        text.text(number_format(value, ioformat, '.', ',', 'round'));
                    }
                    break;
                case "SVG_ClockShape"://时钟
                    {
                        var text = $("#shape" + uid + ">.iotext");
                        var timetype = shapeg.data("timetype");
                        var iolines = $("#shape" + uid + ">.ioupdate");
                        var valueDate = new Date(value.replace('-', '/'));
                        if (timetype == "系统时间") {
                            valueDate = new Date();
                            //时间循环函数

                        }
                        else {
                            try {
                                valueDate = new Date(time.replace('-', '/'));
                                //可能会导致错误的代码
                            } catch(e) {
                                //在错误发生时怎么处理
                                valueDate = "";
                            }


                        }
                        if (valueDate == "")
                            return;
                        var hh = valueDate.getHours();
                        var mm = valueDate.getMinutes();
                        var ss = valueDate.getSeconds();
                        var day = valueDate.getDay();
                        var ssangle = parseInt(ss) * 6 + 270;
                        var mmangle = parseInt(mm) * 6 + 270;//mm * 6 + 270
                        var hhangle = parseInt(hh) * 30 + parseInt(mm) * 1 / 2 + 270;
                        //重新修改秒针
                        var ssrotate = iolines[0].getAttribute('transform');

                        var newssrotate = "rotate(" + ssangle + "," + ssrotate.split(',')[1] + "," + ssrotate.split(',')[2] + "";
                        iolines[0].setAttribute('transform', newssrotate);
                        //重新修改分针
                        var mmrotate = iolines[1].getAttribute('transform');
                        var newmmrotate = "rotate(" + mmangle + "," + mmrotate.split(',')[1] + "," + mmrotate.split(',')[2] + "";
                        iolines[1].setAttribute('transform', newmmrotate);
                        //重新修改时针
                        var hhrotate = iolines[2].getAttribute('transform');
                        var newhhrotate = "rotate(" + hhangle + "," + hhrotate.split(',')[1] + "," + hhrotate.split(',')[2] + "";
                        iolines[2].setAttribute('transform', newhhrotate);
                        if (text != undefined) {
                            text.html(day);
                            text.text(day);

                        }
                        if (timetype == "系统时间") {

                            //时间循环函数
                            $('#scada_svg').everyTime('1s', function () {

                                valueDate = new Date();
                                var hh = valueDate.getHours();
                                var mm = valueDate.getMinutes();
                                var ss = valueDate.getSeconds();
                                var day = valueDate.getDay();
                                var ssangle = parseInt(ss) * 6 + 270;
                                var mmangle = parseInt(mm) * 6 + 270;//mm * 6 + 270
                                var hhangle = parseInt(hh) * 30 + parseInt(mm) * 1 / 2 + 270;
                                //重新修改秒针
                                var ssrotate = iolines[0].getAttribute('transform');

                                var newssrotate = "rotate(" + ssangle + "," + ssrotate.split(',')[1] + "," + ssrotate.split(',')[2] + "";
                                iolines[0].setAttribute('transform', newssrotate);
                                //重新修改分针
                                var mmrotate = iolines[1].getAttribute('transform');
                                var newmmrotate = "rotate(" + mmangle + "," + mmrotate.split(',')[1] + "," + mmrotate.split(',')[2] + "";
                                iolines[1].setAttribute('transform', newmmrotate);
                                //重新修改时针
                                var hhrotate = iolines[2].getAttribute('transform');
                                var newhhrotate = "rotate(" + hhangle + "," + hhrotate.split(',')[1] + "," + hhrotate.split(',')[2] + "";
                                iolines[2].setAttribute('transform', newhhrotate);
                                if (text != undefined) {
                                    text.html(day);
                                    text.text(day);

                                }

                            });
                        }


                    }
                    break;
                case "SVG_CncCenterShape"://处理中心
                    {
                        var ios = $("#shape" + uid + ">.ioupdate");
                        var redvalue = shapeg.data("lightred");
                        var greenvalue = shapeg.data("lightgreen");
                        var yellowvalue = shapeg.data("lightyellow");
                        var redobj = ios[0];
                        var greenobj = ios[1];
                        var yellowobj = ios[2];
                        redobj.setAttribute("fill", "#cccccc");
                        greenobj.setAttribute("fill", "#cccccc");
                        yellowobj.setAttribute("fill", "#cccccc");
                        if (redvalue == value) {
                            redobj.setAttribute("fill", "#ff0000");
                        }
                        if (greenvalue == value) {
                            greenobj.setAttribute("fill", "#00ff00");
                        }
                        if (yellowvalue == value) {
                            yellowobj.setAttribute("fill", "#FFFF00");
                        }
                    }
                    break;
                case "SVG_ConveyorShape"://传送带
                    {
                        var speed = shapeg.data("speed");
                        var trueexpression = shapeg.data("iovaluetrue");
                        var trueop = trueexpression.split(":")[0];
                        var truevalue = parseFloat(trueexpression.split(":")[1]);
                        var falseexpression = shapeg.data("iovaluefalse");
                        var falseop = falseexpression.split(":")[0];
                        var falsevalue = parseFloat(falseexpression.split(":")[1]);
                        var animate = $("#shape" + uid + ">.ioupdate>animate");
                        if (animate != undefined) {

                            var tv = analysisOpeartor(trueop, truevalue, value);
                            if (tv == true) {
                                animate.attr("dur", speed);

                            }
                            var fv = analysisOpeartor(falseop, falsevalue, value);
                            if (fv == true) {


                                animate.attr("dur", "9999999s");
                            }


                        }
                    }
                    break;
                case "SVG_CoolFanShape"://风机
                    {
                        var speed = shapeg.data("speed");
                        var animateTransform = $("#shape" + uid + ">.ioupdate>animateTransform");
                        var trueexpression = shapeg.data("iovaluetrue");
                        var trueop = trueexpression.split(":")[0];
                        var truevalue = parseFloat(trueexpression.split(":")[1]);
                        var falseexpression = shapeg.data("iovaluefalse");
                        var falseop = falseexpression.split(":")[0];
                        var falsevalue = parseFloat(falseexpression.split(":")[1]);
                        var tv = analysisOpeartor(trueop, truevalue, value);
                        var fv = analysisOpeartor(falseop, falsevalue, value);
                        if (tv == true) {
                            animateTransform[0].setAttribute("dur", speed);

                        }
                        else if (fv == true) {


                            animateTransform[0].setAttribute("dur", "999999999");
                        }
                    }
                    break;
                case "SVG_DashboardShape"://仪表盘
                    {
                        //确定相关尺寸
                        var rect = { x: parseFloat(rectstr.split(',')[0]), y: parseFloat(rectstr.split(',')[1]), width: parseFloat(rectstr.split(',')[2]), height: parseFloat(rectstr.split(',')[3]) };
                        var centerX = rect.x + rect.width / 2;//中心点X轴
                        var centerY = rect.y + rect.height / 2;//中心点Y轴
                        var startAngle = parseFloat(shapeg.data("startangle"));//开始角度
                        var sweepAngle = parseFloat(shapeg.data("sweepangle"));//结束角度
                        var displaymodel = shapeg.data("displaymodel");//显示模式
                        var valuetype = shapeg.data("valuetype");//值类型
                        var maxvalue = parseFloat(shapeg.data("maxvalue"));//值类型
                        var minvalue = parseFloat(shapeg.data("minvalue"));//值类型
                        var progress = (parseFloat(value) - parseFloat(minvalue)) / (parseFloat(maxvalue) - parseFloat(minvalue));
                        var indicatorCenterR = parseFloat(shapeg.data("indicatorcenter"));//指针大小
                        var indicatorAngle = parseFloat(shapeg.data("indicatorangle"));//指针角度
                        var roundSize = parseFloat(shapeg.data("roundsize"));//指针角度
                        var offsetOuter = parseFloat(shapeg.data("offsetouter"));//指针角度
                        var progressAngel = (sweepAngle * progress);//到达进度值所占用的角度
                        if (progressAngel < 1) {
                            progressAngel = 1;
                        }
                        var ios = $("#shape" + uid + ">.ioupdate");
                        var text = $("#shape" + uid + ">.iotext");
                        var a1 = ios[0];

                        //弧度重绘
                        var arcRectstr = ios[0].getAttribute("data-rect");
                        var arcRect = { x: parseFloat(arcRectstr.split(',')[0]), y: parseFloat(arcRectstr.split(',')[1]), width: parseFloat(arcRectstr.split(',')[2]), height: parseFloat(arcRectstr.split(',')[3]) };
                        var arcD = ios[0].getAttribute("d");
                        var tempD = ios[0].getAttribute("d");
                        if (displaymodel == "Fill") {
                            arcD = GetPieZ(ios[0], startAngle, sweepAngle * progress);

                        }
                        else {
                            arcD = GetArcZ(ios[0], startAngle, sweepAngle * progress);
                        }


                        ios[0].setAttribute("d", arcD);
                        //指针重绘
                        var R = Math.min(rect.width, rect.height) / 2 - offsetOuter;//确定圆的半径
                        var leftPointAngel = (progressAngel + (90 + 40) - indicatorAngle / 2);//计算出progressAngel向左侧偏移indicatorAngle/2的角度
                        var rightPointAngel = (progressAngel + (90 + 40) + indicatorAngle / 2);//计算出progressAngel向右侧偏移indicatorAngle/2的角度

                        //计算出向左偏移Progress点-indicatorAngle/2的坐标
                        var xLeft = centerX + indicatorCenterR * Math.cos(leftPointAngel * 3.1415926 / 180);
                        var yLeft = centerY + indicatorCenterR * Math.sin(leftPointAngel * 3.1415926 / 180);

                        //计算出向左偏移Progress点+indicatorAngle/2的坐标
                        var xRight = centerX + indicatorCenterR * Math.cos(rightPointAngel * 3.1415926 / 180);
                        var yRight = centerY + indicatorCenterR * Math.sin(rightPointAngel * 3.1415926 / 180);

                        //指针的半径
                        var indicatorR = R - R / 6 - roundSize * 3;

                        //计算指针终点的坐标
                        var xTarget = centerX + indicatorR * Math.cos((progressAngel + (90 + 40)) * 3.1415926 / 180);
                        var yTarget = centerY + indicatorR * Math.sin((progressAngel + (90 + 40)) * 3.1415926 / 180);


                        //绘制闭合指针
                        var pts = [];
                        pts.push({ x: xTarget, y: yTarget });
                        pts.push({ x: xLeft, y: yLeft });
                        pts.push({ x: centerX, y: centerY });
                        pts.push({ x: xRight, y: yRight });
                        pts.push({ x: xTarget, y: yTarget });
                        var points = "";
                        for (var i = 0; i < pts.length; i++) {
                            points += pts[i].x + "," + pts[i].y + " ";
                        }
                        ios[1].setAttribute("points", points);

                        //设置显示文本
                        var bottomStr = number_format(value, ioformat, '.', ',', 'round') + "/" + minvalue + "~" + maxvalue;
                        if (valuetype == "Percent") {
                            bottomStr = number_format(((value - minvalue) / (maxvalue - minvalue) * 100), ioformat, '.', ',', 'round');
                        }
                        text.html(bottomStr);
                        text.text(bottomStr);

                    }
                    break;
                case "SVG_DeviceStatusShape"://信号状态
                    {
                        var normalcolor = shapeg.data("normalcolor");
                        var normaltext = shapeg.data("normaltext");
                        var errortext = shapeg.data("errortext");
                        var errorcolor = shapeg.data("errorcolor");
                        var statustype = shapeg.data("statustype");
                        var rect = { x: parseFloat(rectstr.split(',')[0]), y: parseFloat(rectstr.split(',')[1]), width: parseFloat(rectstr.split(',')[2]), height: parseFloat(rectstr.split(',')[3]) };

                        var trueexpression = shapeg.data("iovaluetrue");
                        var trueop = trueexpression.split(":")[0];
                        var truevalue = parseFloat(trueexpression.split(":")[1]);
                        var falseexpression = shapeg.data("iovaluefalse");
                        var falseop = falseexpression.split(":")[0];
                        var falsevalue = parseFloat(falseexpression.split(":")[1]);
                        var tv = analysisOpeartor(trueop, truevalue, value);
                        var fv = analysisOpeartor(falseop, falsevalue, value);
                        if (statustype == "Text") {
                            var text = $("#shape" + uid + ">.iotext");

                            if (tv == true) {
                                text.html(normaltext);
                                text.text(normaltext);

                            }
                            else if (fv == true) {
                                text.html(errortext);
                                text.text(errortext);
                            }

                        }
                        else if (statustype == "Circle") {
                            var ioupdate = $("#shape" + uid + ">.ioupdate");

                            if (tv == true) {
                                ioupdate.setAttribute("fill", normalcolor)

                            }
                            else if (fv == true) {
                                ioupdate.setAttribute("fill", errorcolor)
                            }


                        }
                        else if (statustype == "Rect") {
                            var ioupdate = $("#shape" + uid + ">.ioupdate");

                            if (tv == true) {
                                ioupdate.setAttribute("fill", normalcolor)

                            }
                            else if (fv == true) {
                                ioupdate.setAttribute("fill", errorcolor)
                            }

                        }
                        else if (statustype == "Signal") {
                            var ioupdate = $("#shape" + uid + ">.ioupdate");
                            var num = 6;

                            for (var i = 0; i < num - 1; i++) {

                                if (tv == true) {
                                    ioupdate[i].setAttribute("fill", normalcolor)

                                }
                                else if (fv == true) {
                                    ioupdate[i].setAttribute("fill", errorcolor)
                                }

                            }

                        }
                    }
                    break;
                case "SVG_IOLabelShape"://IO显示器
                    {
                        var text = $("#shape" + uid + ">a>.iotext");
                        if (datatype == "DateTime") {
                            if (text != undefined) {
                                text.html(time);
                                text.text(time);

                            }
                        }
                        else {
                            if (text != undefined) {
                                text.html(value);
                                text.text(value);

                            }
                        }



                    }
                    break;
                case "SVG_MeterShape"://IO显示器
                    {
                        var meterDegrees = parseFloat(shapeg.data("meterdegrees"));
                        var minValue = parseFloat(shapeg.data("minvalue"));
                        var maxValue = parseFloat(shapeg.data("maxvalue"));
                        var valueType = shapeg.data("valuetype");
                        var fltStartAngle = -90 - (meterDegrees) / 2 + 360;
                        var rect = { x: parseFloat(rectstr.split(',')[0]), y: parseFloat(rectstr.split(',')[1]), width: parseFloat(rectstr.split(',')[2]), height: parseFloat(rectstr.split(',')[3]) };
                        var m_rectWorking = { x: rect.x + 10, y: rect.y + 10, width: rect.width - 20, height: rect.height - 20, top: rect.y + 10, bottom: rect.y + 10 + rect.height - 20, left: rect.x + 10, right: rect.x + 10 + rect.width - 20 };
                        var fltValueAngle = (fltStartAngle + ((value - minValue) / (maxValue - minValue)) * meterDegrees - 180) % 360;
                        var intValueY1 = (m_rectWorking.top + m_rectWorking.width / 2 - ((m_rectWorking.width / 2 - 30) * Math.sin(3.1415926 * (fltValueAngle / 180.00))));
                        var intValueX1 = (m_rectWorking.left + (m_rectWorking.width / 2 - ((m_rectWorking.width / 2 - 30) * Math.cos(3.1415926 * (fltValueAngle / 180.00)))));
                        var ioupdate = $("#shape" + uid + ">.ioupdate");
                        ioupdate[0].setAttribute("x1", intValueX1);
                        ioupdate[0].setAttribute("x2", m_rectWorking.left + m_rectWorking.width / 2);
                        ioupdate[0].setAttribute("y1", intValueY1);
                        ioupdate[0].setAttribute("y2", m_rectWorking.top + m_rectWorking.width / 2);

                        var text = $("#shape" + uid + ">.iotext");
                        if (text != undefined) {
                            var strFormat = number_format(parseFloat(value), ioformat, '.', ',', 'round');
                            if (valueType == "Percent") {
                                strFormat = number_format((parseFloat(value) - minValue) / (maxValue - minValue) * 100, ioformat, '.', ',', 'round') + "%";

                            }

                            text.html(strFormat);
                            text.text(strFormat);

                        }


                    }
                    break;
                case "SVG_PlayButton"://播放按钮
                    {
                        var path = $("#shape" + uid + ">.ioupdate");
                        var truetext = shapeg.data("truetext");
                        var falsetext = shapeg.data("falsetext");
                        var buttonmode = shapeg.data("buttonmode");
                        var truecolor = shapeg.data("truecolor");
                        var falsecolor = shapeg.data("falsecolor");

                        var trueexpression = shapeg.data("iovaluetrue");
                        var trueop = trueexpression.split(":")[0];
                        var truevalue = parseFloat(trueexpression.split(":")[1]);
                        var falseexpression = shapeg.data("iovaluefalse");
                        var falseop = falseexpression.split(":")[0];
                        var falsevalue = parseFloat(falseexpression.split(":")[1]);

                        if (rectstr != undefined) {
                            var tv = analysisOpeartor(trueop, truevalue, value);
                            var fv = analysisOpeartor(falseop, falsevalue, value);
                            if (buttonmode == "Text") {
                                var txt = $("#shape" + uid + ">.iotext");
                                if (tv == true) {


                                    txt.html(truetext);
                                    txt.text(truetext);
                                    txt[0].setAttribute("fill", truecolor);

                                }
                                else if (fv == true) {

                                    txt.html(falsetext);
                                    txt.text(falsetext);
                                    txt[0].setAttribute("fill", falsecolor);

                                }

                            }
                            else {
                                var c2 = path[0].getAttribute("fill");
                                if (tv == true) {


                                    path[0].setAttribute("style", "display:block;");
                                    path[1].setAttribute("style", "display:block;");
                                    path[2].setAttribute("style", "display:none;");

                                }
                                else if (fv == true) {

                                    path[0].setAttribute("style", "display:none;");
                                    path[1].setAttribute("style", "display:none;");
                                    path[2].setAttribute("style", "display:block;");
                                }

                            }

                        };
                    }
                    break;
                case "SVG_PotShape"://炉容器
                    {

                        var maxValue = parseFloat(shapeg.data("maxvalue"));
                        var mRadious = parseFloat(shapeg.data("radious"));
                        var rect = { x: parseFloat(rectstr.split(',')[0]), y: parseFloat(rectstr.split(',')[1]), width: parseFloat(rectstr.split(',')[2]), height: parseFloat(rectstr.split(',')[3]) };
                        if (value > maxValue) {
                            value = maxValue;
                        }
                        if (value < 0) {
                            value = 0;
                        }
                        var ytHeight = parseFloat(rect.height * parseFloat(value) / maxValue);
                        var ioupdate = $("#shape" + uid + ">.ioupdate");
                        if (ioupdate != undefined) {
                            ioupdate[0].setAttribute("y", parseFloat(rect.y + rect.height - ytHeight));
                            ioupdate[0].setAttribute("height", parseFloat(ytHeight));
                        }
                        var txt = $("#shape" + uid + ">.iotext");
                        if (txt != undefined) {
                            var strFormat = number_format(parseFloat(value), ioformat, '.', ',', 'round');
                            txt.html(strFormat);
                            txt.text(strFormat);
                        }
                    }
                    break;
                case "SVG_SignalLamShape"://信号状态显示器
                    {
                        var truecolor = shapeg.data("truecolor");
                        var falsecolor = shapeg.data("falsecolor");
                        var lampcolor = shapeg.data("lampcolor");
                        var trueexpression = shapeg.data("iovaluetrue");
                        var trueop = trueexpression.split(":")[0];
                        var truevalue = parseFloat(trueexpression.split(":")[1]);
                        var falseexpression = shapeg.data("iovaluefalse");
                        var falseop = falseexpression.split(":")[0];
                        var falsevalue = parseFloat(falseexpression.split(":")[1]);
                        var radialGradientStop = $("#shape" + uid).find("radialGradient").find("stop");
                        if (rectstr != undefined) {
                            var tv = analysisOpeartor(trueop, truevalue, value);
                            var fv = analysisOpeartor(falseop, falsevalue, value);
                            if (tv == true)
                                radialGradientStop[1].setAttribute("style", "stop-color:" + truecolor);
                            if (fv == true)
                                radialGradientStop[1].setAttribute("style", "stop-color:" + falsecolor);

                        };
                    }
                    break;
                case "SVG_SwitchButtonShape"://开关按钮
                    {
                        var truecolor = shapeg.data("truecolor");
                        var falsecolor = shapeg.data("falsecolor");
                        var lampcolor = shapeg.data("lampcolor");
                        var trueexpression = shapeg.data("iovaluetrue");
                        var trueop = trueexpression.split(":")[0];
                        var truevalue = parseFloat(trueexpression.split(":")[1]);
                        var falseexpression = shapeg.data("iovaluefalse");
                        var falseop = falseexpression.split(":")[0];
                        var falsevalue = parseFloat(falseexpression.split(":")[1]);
                        var radialGradientStop = $("#shape" + uid).find("radialGradient").find("stop");
                        if (rectstr != undefined) {
                            var tv = analysisOpeartor(trueop, truevalue, value);
                            var fv = analysisOpeartor(falseop, falsevalue, value);
                            if (tv == true)
                                radialGradientStop[1].setAttribute("style", "stop-color:" + truecolor);
                            if (fv == true)
                                radialGradientStop[1].setAttribute("style", "stop-color:" + falsecolor);

                        };
                    }
                    break;
                case "SVG_SwitchShape"://开关
                    {
                        var truetext = shapeg.data("truetext");
                        var falsetext = shapeg.data("falsetext");
                        var truecolor = shapeg.data("truecolor");
                        var falsecolor = shapeg.data("falsecolor");
                        var trueexpression = shapeg.data("iovaluetrue");
                        var trueop = trueexpression.split(":")[0];
                        var truevalue = parseFloat(trueexpression.split(":")[1]);
                        var falseexpression = shapeg.data("iovaluefalse");
                        var falseop = falseexpression.split(":")[0];
                        var falsevalue = parseFloat(falseexpression.split(":")[1]);
                        var iolines = $("#shape" + uid + ">.ioupdate");
                        var iorect = $("#shape" + uid + ">g>.ioupdate");
                        var iotext = $("#shape" + uid + ">g>.iotext");
                        if (rectstr != undefined) {
                            var tv = analysisOpeartor(trueop, truevalue, value);
                            var fv = analysisOpeartor(falseop, falsevalue, value);
                            if (tv == true) {
                                var myrotate = iolines[0].getAttribute('transform');
                                var newssrotate = "rotate(36," + myrotate.split(',')[1] + "," + myrotate.split(',')[2] + "";
                                iolines[0].setAttribute('transform', newssrotate);
                                iorect[0].setAttribute("fill", truecolor);

                                iotext[0].setAttribute("fill", truecolor);
                                iotext.html(truetext);
                                iotext.text(truetext);
                            }
                            else if (fv == true) {
                                var myrotate = iolines[0].getAttribute('transform');
                                var newssrotate = "rotate(-36," + myrotate.split(',')[1] + "," + myrotate.split(',')[2] + "";
                                iolines[0].setAttribute('transform', newssrotate);
                                iorect[0].setAttribute("fill", falsecolor);
                                iotext[0].setAttribute("fill", falsecolor);
                                iotext.html(falsetext);
                                iotext.text(falsetext);
                            }
                        };
                    }
                    break;
                case "SVG_ThermometerShape"://温度计
                    {
                        var minvalue = parseFloat(shapeg.data("minvalue"));
                        var maxvalue = parseFloat(shapeg.data("maxvalue"));

                        var iolines = $("#shape" + uid + ">.ioupdate");
                        var iotext = $("#shape" + uid + ">.iotext");
                        if (rectstr != undefined) {
                            var rect = { x: parseFloat(rectstr.split(',')[0]), y: parseFloat(rectstr.split(',')[1]), width: parseFloat(rectstr.split(',')[2]), height: parseFloat(rectstr.split(',')[3]) };
                            var strFormat = number_format(parseFloat(value), ioformat, '.', ',', 'round');
                            if (iotext != undefined) {
                                iotext.html(strFormat);
                                iotext.text(strFormat);
                            }
                            if (iolines != undefined) {

                                var m_rectWorking = { x: rect.x + rect.width / 2 - rect.width / 8, y: rect.y + rect.width / 4, width: rect.width / 4, height: rect.height - rect.width / 2 };
                                var m_rectLeft = { x: rect.x, y: m_rectWorking.y + m_rectWorking.width / 2, width: (rect.width - rect.width / 4) / 2 - 2, height: m_rectWorking.height - m_rectWorking.width * 2 };
                                var m_rectRight = { x: rect.x + rect.width - (rect.width - rect.width / 4) / 2 + 2, y: m_rectWorking.y + m_rectWorking.width / 2, width: (rect.width - rect.width / 4) / 2 - 2, height: m_rectWorking.height - m_rectWorking.width * 2 };
                                var fltHeightValue = parseFloat(value - minvalue) / (maxvalue - minvalue) * m_rectLeft.height;
                                iolines[0].setAttribute("y", rect.y + (m_rectLeft.height - fltHeightValue));
                                iolines[0].setAttribute("height", fltHeightValue + (m_rectWorking.height - m_rectWorking.width / 2 - m_rectLeft.height));
                            }
                        };
                    }
                    break;
                case "SVG_WheelGearShape"://旋转轮
                    {
                        var speed = shapeg.data("speed");
                        var animateTransform = $("#shape" + uid + ">.ioupdate>animateTransform");
                        var trueexpression = shapeg.data("iovaluetrue");
                        var trueop = trueexpression.split(":")[0];
                        var truevalue = parseFloat(trueexpression.split(":")[1]);
                        var falseexpression = shapeg.data("iovaluefalse");
                        var falseop = falseexpression.split(":")[0];
                        var falsevalue = parseFloat(falseexpression.split(":")[1]);
                        var tv = analysisOpeartor(trueop, truevalue, value);
                        var fv = analysisOpeartor(falseop, falsevalue, value);
                        if (tv == true) {
                            animateTransform[0].setAttribute("dur", speed);

                        }
                        else if (fv == true) {


                            animateTransform[0].setAttribute("dur", "9999999");
                        }
                    }
                    break;
                case "SVG_LedNumShape"://LED数字显示器
                    {
                        if (value.length <= 0)
                            return;
                        var rect = { X: parseFloat(rectstr.split(',')[0]), Y: parseFloat(rectstr.split(',')[1]), Width: parseFloat(rectstr.split(',')[2]), Height: parseFloat(rectstr.split(',')[3]), Top: parseFloat(rectstr.split(',')[1]), Bottom: parseFloat(rectstr.split(',')[1]) + parseFloat(rectstr.split(',')[3]), Left: parseFloat(rectstr.split(',')[0]), Right: parseFloat(rectstr.split(',')[0]) + parseFloat(rectstr.split(',')[2]) };
                        var linewidth = parseFloat(shapeg.data("linewidth"));
                        var linecolor = shapeg.data("linecolor");
                        var ledformat = shapeg.data("ledformat");
                        var lednumWidth = rect.Width / ledformat.toString().length;
                        var decimal = 0;
                        if (ledformat.split('.').length == 2) {
                            decimal = ledformat.split('.')[1].length;
                        }
                        if (ledformat.split('.')[0].length)
                            var newvalue = number_format(parseFloat(value), decimal, '.', undefined, 'round');
                        if (newvalue.split('.')[0].length < ledformat.split('.')[0].length) {
                            var pre = "";
                            for (var i = 0; i < ledformat.split('.')[0].length - newvalue.split('.')[0].length; i++) {
                                pre += "0";
                            }
                            newvalue = pre + newvalue;
                        }
                        else if (newvalue.split('.')[0].length > ledformat.split('.')[0].length) {
                            var s = newvalue.split('.')[0].length > ledformat.split('.')[0].length;
                            newvalue = newvalue.substr(s - 1, newvalue.length - s);
                        }



                        var nums = LedNum();
                        var nowpaths = $("#shape" + uid + ">.ioupdate>path");
                        for (var i = 0; i < nowpaths.length; i++) {
                            nowpaths[i].setAttribute("style", 'display:none;');
                        }
                        var index = 0;
                        for (var i = 0; i < newvalue.toString().length; i++) {
                            var obj = newvalue.toString().charAt(i);
                            //遍历字符串
                            var ledRect = { X: rect.X + lednumWidth * i + 2, Y: rect.Y + 2, Width: lednumWidth - 4, Height: rect.Height - 4, Top: rect.Y + 2, Bottom: rect.Y + 2 + rect.Height - 4, Left: rect.X + lednumWidth * i + 2, Right: rect.X + lednumWidth * i + 2 + lednumWidth - 4 };
                            var paths = LedDraw(obj, ledRect, linewidth, linecolor, nums);
                            var str = "";
                            for (var j = 0; j < paths.length; j++) {

                                nowpaths[index].setAttribute("d", paths[j]);
                                nowpaths[index].setAttribute("style", "display:block");
                                index++;
                            }

                        }
                    }
                    break;
                case "SVG_LedTimeShape"://LED日期显示器
                    {
                        if (value.length <= 0)
                            return;
                        var rect = { X: parseFloat(rectstr.split(',')[0]), Y: parseFloat(rectstr.split(',')[1]), Width: parseFloat(rectstr.split(',')[2]), Height: parseFloat(rectstr.split(',')[3]), Top: parseFloat(rectstr.split(',')[1]), Bottom: parseFloat(rectstr.split(',')[1]) + parseFloat(rectstr.split(',')[3]), Left: parseFloat(rectstr.split(',')[0]), Right: parseFloat(rectstr.split(',')[0]) + parseFloat(rectstr.split(',')[2]) };
                        var linewidth = parseFloat(shapeg.data("linewidth"));
                        var linecolor = shapeg.data("linecolor");
                        var ledformat = shapeg.data("ledformat");
                        var lednumWidth = rect.Width / ledformat.toString().length;
                        var newvalue = new Date(time.replace("-", "/")).format(ledformat);

                        var nums = LedNum();
                        var nowpaths = $("#shape" + uid + ">.ioupdate>path");
                        for (var i = 0; i < nowpaths.length; i++) {
                            nowpaths[i].setAttribute("style", 'display:none;');
                        }
                        var index = 0;
                        for (var i = 0; i < newvalue.toString().length; i++) {
                            var obj = newvalue.toString().charAt(i);
                            //遍历字符串
                            var ledRect = { X: rect.X + lednumWidth * i + 2, Y: rect.Y + 2, Width: lednumWidth - 4, Height: rect.Height - 4, Top: rect.Y + 2, Bottom: rect.Y + 2 + rect.Height - 4, Left: rect.X + lednumWidth * i + 2, Right: rect.X + lednumWidth * i + 2 + lednumWidth - 4 };
                            var paths = LedDraw(obj, ledRect, linewidth, linecolor, nums);
                            var str = "";
                            for (var j = 0; j < paths.length; j++) {

                                nowpaths[index].setAttribute("d", paths[j]);
                                nowpaths[index].setAttribute("style", "display:block");
                                index++;
                            }

                        }
                    }
                    break;
                case "SVG_BlowerShape"://绘制风机
                    {
                        var speed = shapeg.data("speed");
                        var animateTransform = $("#shape" + uid + ">.ioupdate>animateTransform");
                        var trueexpression = shapeg.data("iovaluetrue");
                        var trueop = trueexpression.split(":")[0];
                        var truevalue = parseFloat(trueexpression.split(":")[1]);
                        var falseexpression = shapeg.data("iovaluefalse");
                        var falseop = falseexpression.split(":")[0];
                        var falsevalue = parseFloat(falseexpression.split(":")[1]);
                        var tv = analysisOpeartor(trueop, truevalue, value);
                        var fv = analysisOpeartor(falseop, falsevalue, value);
                        if (tv == true) {
                            animateTransform[0].setAttribute("dur", speed);

                        }
                        else if (fv == true) {


                            animateTransform[0].setAttribute("dur", "999999999999");
                        }
                    }
                    break;
                case "SVG_BottleShape"://绘制容器瓶子
                    {
                        var maxvalue = parseFloat(shapeg.data("maxvalue"));//最大值
                        var bottlestyle = shapeg.data("bottlestyle");//瓶口方向
                        var liquidColor = shapeg.data("liquidcolor");//液体颜色
                        var ioupdate = $("#shape" + uid + ">.ioupdate");//获取动态设置参数

                        var rect = { X: parseFloat(rectstr.split(',')[0]), Y: parseFloat(rectstr.split(',')[1]), Width: parseFloat(rectstr.split(',')[2]), Height: parseFloat(rectstr.split(',')[3]), Top: parseFloat(rectstr.split(',')[1]), Bottom: parseFloat(rectstr.split(',')[1]) + parseFloat(rectstr.split(',')[3]), Left: parseFloat(rectstr.split(',')[0]), Right: parseFloat(rectstr.split(',')[0]) + parseFloat(rectstr.split(',')[2]) };
                        var decYTHeight = (value / maxvalue) * (rect.Height - 15);
                        var psYT = [];
                        var rectYT = { X: 0, Y: 0, Width: 0, Height: 0, Left: 0, Right: 0, Top: 0, Bottom: 0, CX: 0, CY: 0 };
                        if ("Down" == bottlestyle) {
                            if (decYTHeight < 15) {
                                psYT.push({ X: rect.Left + (15 - decYTHeight) + 3, Y: (rect.Bottom - decYTHeight) - 3 });
                                psYT.push({ X: rect.Right - (15 - decYTHeight) - 3, Y: (rect.Bottom - decYTHeight) - 3 });
                                psYT.push({ X: rect.Right - 3 - rect.Width / 4, Y: rect.Bottom - 3 });
                                psYT.push({ X: rect.Left + rect.Width / 4 + 3, Y: rect.Bottom - 3 });
                                rectYT.Left = rectYT.X = (rect.Left + (15 - decYTHeight)) + 3;
                                rectYT.Top = rectYT.Y = rect.Bottom - decYTHeight - 5;
                                rectYT.Width = rect.Width - (15 - decYTHeight) * 2 - 8;
                                rectYT.Height = 10;
                                rectYT.Right = rectYT.Left + rectYT.Width;
                                rectYT.Bottom = rectYT.Top + rectYT.Height;

                            }
                            else {
                                psYT.push({ X: rect.Left + 3, Y: (rect.Bottom - decYTHeight) - 3 });
                                psYT.push({ X: rect.Right - 3, Y: (rect.Bottom - decYTHeight) - 3 });
                                psYT.push({ X: rect.Right - 3, Y: rect.Bottom - 15 - 3 });
                                psYT.push({ X: rect.Right - 3 - rect.Width / 4, Y: rect.Bottom - 3 });
                                psYT.push({ X: rect.Left + rect.Width / 4, Y: rect.Bottom - 3 });
                                psYT.push({ X: rect.Left, Y: rect.Bottom - 15 - 3 });

                                rectYT.Left = rectYT.X = rect.Left;
                                rectYT.Top = rectYT.Y = rect.Bottom - decYTHeight - 5;
                                rectYT.Width = rectYT.Width;
                                rectYT.Height = 10;
                                rectYT.Right = rectYT.Left + rectYT.Width;
                                rectYT.Bottom = rectYT.Top + rectYT.Height;


                            }




                        }
                        else {
                            if (decYTHeight < 15) {
                                psYT.push({ X: (rect.Left + (15 - decYTHeight)) + 3, Y: (rect.Bottom - decYTHeight) - 3 });
                                psYT.push({ X: (rect.Right - (15 - decYTHeight)) - 3, Y: (rect.Bottom - decYTHeight) - 3 });
                                psYT.push({ X: rect.Right - 3 - rect.Width / 4, Y: rect.Bottom - 3 });
                                psYT.push({ X: rect.Left + rect.Width / 4 + 3, Y: rect.Bottom - 3 });

                                rectYT.Left = rectYT.X = (rect.Left + (15 - decYTHeight)) + 3;
                                rectYT.Top = rectYT.Y = rect.Bottom - decYTHeight - 5;
                                rectYT.Width = rect.Width - (15 - decYTHeight) * 2 - 8;
                                rectYT.Height = 10;
                                rectYT.Right = rectYT.Left + rectYT.Width;
                                rectYT.Bottom = rectYT.Top + rectYT.Height;


                            }
                            else {
                                psYT.push({ X: rect.Left + 3, Y: (rect.Bottom - decYTHeight - 3) });
                                psYT.push({ X: rect.Right - 3, Y: (rect.Bottom - decYTHeight - 3) });
                                psYT.push({ X: rect.Right - 3, Y: rect.Bottom - 3 });
                                psYT.push({ X: rect.Left + 3, Y: rect.Bottom - 3 });


                                rectYT.Left = rectYT.X = rect.Left;
                                rectYT.Top = rectYT.Y = rect.Bottom - decYTHeight - 5;
                                rectYT.Width = rect.Width;
                                rectYT.Height = 10;
                                rectYT.Right = rectYT.Left + rectYT.Width;
                                rectYT.Bottom = rectYT.Top + rectYT.Height;


                            }


                        }
                        var d = "M" + psYT[0].X + "," + psYT[0].Y;
                        for (var i = 1; i < psYT.length; i++) {
                            d += " L" + psYT[i].X + "," + psYT[i].Y;
                        }
                        d += " Z";
                        rectYT.CX = rectYT.X + rectYT.Width / 2;
                        rectYT.CY = rectYT.Y + rectYT.Height / 2;
                        ioupdate[0].setAttribute("d", d);
                        ioupdate[1].setAttribute("cx", rectYT.CX);
                        ioupdate[1].setAttribute("cy", rectYT.CY);
                        ioupdate[1].setAttribute("rx", rectYT.Width / 2);
                        ioupdate[1].setAttribute("ry", rectYT.Height / 2);

                        ioupdate[2].setAttribute("cx", rectYT.CX);
                        ioupdate[2].setAttribute("cy", rectYT.CY);
                        ioupdate[2].setAttribute("rx", rectYT.Width / 2);
                        ioupdate[2].setAttribute("ry", rectYT.Height / 2);

                        var txt = $("#shape" + uid + ">.iotext");
                        if (txt != undefined) {
                            var strFormat = number_format(parseFloat(value), ioformat, '.', ',', 'round');
                            txt.html(strFormat);
                            txt.text(strFormat);
                        }


                    }
                    break;
                case "SVG_ConduitShape"://管道
                    {
                        var ioupdate = $("#shape" + uid + ">.ioupdate");
                        var animate = $("#shape" + uid + ">.ioupdate>animate");
                        var speed = shapeg.data("speed");
                        if (animate != undefined) {
                            var trueexpression = shapeg.data("iovaluetrue");
                            var trueop = trueexpression.split(":")[0];
                            var truevalue = parseFloat(trueexpression.split(":")[1]);
                            var falseexpression = shapeg.data("iovaluefalse");
                            var falseop = falseexpression.split(":")[0];
                            var falsevalue = parseFloat(falseexpression.split(":")[1]);
                            var tv = analysisOpeartor(trueop, truevalue, value);
                            var fv = analysisOpeartor(falseop, falsevalue, value);
                            if (tv == true) {
                                ioupdate[0].setAttribute("style", "display:block;");
                            }
                            else if (fv == true) {

                                ioupdate[0].setAttribute("style", "display:none;");
                            }
                        }
                    }
                    break;
                case "SVG_PondShape"://水池
                    {
                        if (value.length <= 0)
                            return;
                        var lqrect = $("#shape" + uid + ">.ioupdate");
                        var maxvalue = shapeg.data("maxvalue");
                        var rect = { X: parseFloat(rectstr.split(',')[0]), Y: parseFloat(rectstr.split(',')[1]), Width: parseFloat(rectstr.split(',')[2]), Height: parseFloat(rectstr.split(',')[3]), Top: parseFloat(rectstr.split(',')[1]), Bottom: parseFloat(rectstr.split(',')[1]) + parseFloat(rectstr.split(',')[3]), Left: parseFloat(rectstr.split(',')[0]), Right: parseFloat(rectstr.split(',')[0]) + parseFloat(rectstr.split(',')[2]) };
                        if (lqrect != undefined) {
                            var intHeight = parseFloat(value / maxvalue * rect.Height);
                            lqrect[0].setAttribute("y", rect.Y + rect.Height - intHeight);
                            lqrect[0].setAttribute("height", intHeight);

                        }
                        var txt = $("#shape" + uid + ">.iotext");
                        if (txt != undefined) {
                            var strFormat = number_format(parseFloat(value), ioformat, '.', ',', 'round');
                            txt.html(strFormat);
                            txt.text(strFormat);
                        }
                    }
                    break;

                case "SVG_ValveShape"://阀门
                    {
                        var animate = $("#shape" + uid + ">.ioupdate>animate");
                        var speed = shapeg.data("speed");
                        if (animate != undefined) {
                            var trueexpression = shapeg.data("iovaluetrue");
                            var trueop = trueexpression.split(":")[0];
                            var truevalue = parseFloat(trueexpression.split(":")[1]);
                            var falseexpression = shapeg.data("iovaluefalse");
                            var falseop = falseexpression.split(":")[0];
                            var falsevalue = parseFloat(falseexpression.split(":")[1]);
                            var tv = analysisOpeartor(trueop, truevalue, value);
                            var fv = analysisOpeartor(falseop, falsevalue, value);
                            if (tv == true) {
                                animate[0].setAttribute("dur", speed);
                            }
                            else if (fv == true) {

                                animate[0].setAttribute("dur", "999999999");
                            }
                        }
                    }
                    break;
                case "SVG_ValveShape2"://阀门
                    {
                        var ioupdate = $("#shape" + uid + ">.ioupdate");
                        var animate = $("#shape" + uid + ">.ioupdate>animate");
                        var speed = shapeg.data("speed");
                        if (animate != undefined) {
                            var trueexpression = shapeg.data("iovaluetrue");
                            var trueop = trueexpression.split(":")[0];
                            var truevalue = parseFloat(trueexpression.split(":")[1]);
                            var falseexpression = shapeg.data("iovaluefalse");
                            var falseop = falseexpression.split(":")[0];
                            var falsevalue = parseFloat(falseexpression.split(":")[1]);
                            var tv = analysisOpeartor(trueop, truevalue, value);
                            var fv = analysisOpeartor(falseop, falsevalue, value);
                            if (tv == true) {
                                ioupdate[0].setAttribute("style", "display:block");
                            }
                            else if (fv == true) {

                                ioupdate[0].setAttribute("style", "display:none");
                            }
                        }
                    }
                    break;
                case "SVG_MachineFanShape"://风叶
                    {
                        var speed = shapeg.data("speed");
                        var animateTransform = $("#shape" + uid + ">.ioupdate>animateTransform");
                        var trueexpression = shapeg.data("iovaluetrue");
                        var trueop = trueexpression.split(":")[0];
                        var truevalue = parseFloat(trueexpression.split(":")[1]);
                        var falseexpression = shapeg.data("iovaluefalse");
                        var falseop = falseexpression.split(":")[0];
                        var falsevalue = parseFloat(falseexpression.split(":")[1]);
                        var tv = analysisOpeartor(trueop, truevalue, value);
                        var fv = analysisOpeartor(falseop, falsevalue, value);
                        if (tv == true) {
                            animateTransform[0].setAttribute("dur", speed);

                        }
                        else if (fv == true) {


                            animateTransform[0].setAttribute("dur", "9999999");
                        }
                    }
                    break;
                case "SVG_TableCellShape"://表格单元格
                    {

                        if (datatype == "DateTime") {
                            if (shapeg != undefined) {
                                shapeg.html(time);
                                shapeg.text(time);

                            }
                        }
                        else {
                            if (shapeg != undefined) {
                                shapeg.html(number_format(value, ioformat, null, null, null));
                                shapeg.text(number_format(value, ioformat, null, null, null));

                            }
                        }
                    }
                    break;

                case "SVG_Chart"://SVG实时曲线图处理
                    {


                        ///曲线图所在的实际区域
                        var serierect = { X: parseFloat(rectstr.split(',')[0]), Y: parseFloat(rectstr.split(',')[1]), Width: parseFloat(rectstr.split(',')[2]), Height: parseFloat(rectstr.split(',')[3]), Left: 0, Top: 0, Right: 0, Bottom: 0 };
                        serierect.Left = serierect.X;
                        serierect.Right = serierect.X + serierect.Width;
                        serierect.Top = serierect.Y;
                        serierect.Bottom = serierect.Y + serierect.Height;

                        var showpoint = shapeg.data("showpoint");//是否显示曲线点
                        var showlabel = shapeg.data("showlabel");//是否显示曲线值数据
                        var pointsize = parseFloat(shapeg.data("pointsize"));//点大小
                        var pointcolor = shapeg.data("pointcolor");//点颜色
                        var pointtype = shapeg.data("pointtype");//点样式
                        var seriename = shapeg.data("seriename");//曲线名称
                        var serietype = shapeg.data("serietype");//曲线类型
                        var maxvalue = parseFloat(value);//曲线最大值
                        var minvalue = parseFloat(value);//曲线最小值
                        var maxpoint = parseInt(shapeg.data("maxpoint"));//曲线点显示数量
                        var maxdate = new Date(time);//当前日期maxdate.toLocaleString()
                        var mindate = new Date(time);

                        var serielines = $("#shape" + uid + ">[serietype='line']>path");//获取曲线
                        var seriepoints = $("#shape" + uid + ">[serietype='point']>path");//获取曲线点的
                        var serielabels = $("#shape" + uid + ">[serietype='text']>text");//获取曲线点的

                        if (showpoint == "True" || point == "true") {
                            $("#shape" + uid + ">[serietype='point']")[0].setAttribute("style", "display:block;")
                        }
                        else {
                            $("#shape" + uid + ">[serietype='point']")[0].setAttribute("style", "display:none;")
                        }
                        if (showlabel == "True" || showlabel == "true") {
                            $("#shape" + uid + ">[serietype='text']")[0].setAttribute("style", "display:block;")
                        }
                        else {
                            $("#shape" + uid + ">[serietype='text']")[0].setAttribute("style", "display:none;")
                        }


                        //初始化曲线
                        for (var i = 0; i < maxpoint - 1; i++) {
                            serielines[i].setAttribute("d", "");
                            seriepoints[i].setAttribute("d", "");


                            serielabels[i].innerHtml = "";
                        }
                        var vstr = shapeg.data("value");


                        var datestr = shapeg.data("date");
                        if (datestr == "") {

                            datestr += time;
                            vstr += value;
                        }
                        else {
                            if (new Date(datestr.split(",")[datestr.split(",").length - 1].replace(/\-/g, "/")) < new Date(time.replace(/\-/g, "/"))) {
                                datestr += "," + time;
                                vstr += "," + value;
                            }
                        }
                        //如果超过了指定了的最大点数，则删除之前的点 100,12,21,25,38,90


                        if (vstr.split(",").length > maxpoint) {

                            vstr = vstr.substring(vstr.split(",")[0].length + 1, vstr.length - vstr.split(",")[0].length - 1);
                            datestr = datestr.substring(datestr.split(",")[0].length + 1, datestr.length - datestr.split(",")[0].length - 1);

                        }


                        shapeg.data("value", vstr);
                        shapeg.data("date", datestr);
                        for (var i = 0; i < vstr.split(",").length; i++) {
                            var nv = parseFloat(vstr.split(",")[i]);
                            if (i == 0) {
                                minvalue = nv;
                                maxvalue = nv;

                            }
                            else {
                                minvalue = Math.min(parseFloat(nv), parseFloat(minvalue));
                                maxvalue = Math.max(parseFloat(nv), parseFloat(maxvalue));
                            }

                        }
                        if (minvalue == maxvalue) {

                            maxvalue = minvalue + 100;
                        }

                        var dis = parseFloat(maxvalue - minvalue) / 5;
                        maxvalue = parseFloat(maxvalue) + parseFloat(dis);
                        if (minvalue < 0) {

                            minvalue = parseFloat(minvalue) - parseFloat(dis);

                        }
                        else {
                            //判断如果最小值大于零,则要处理是否从0开始
                            minvalue = parseFloat(minvalue) - parseFloat(dis);
                            if (minvalue < 0) {
                                minvalue = 0;
                            }
                        }

                        for (var i = 0; i < datestr.split(",").length; i++) {
                            var nd = new Date(datestr.split(",")[i].replace(/\-/g, "/"));
                            if (i == 0) {
                                maxdate = nd;
                                mindate = nd;
                            }
                            else {
                                if (maxdate < nd) {
                                    maxdate = nd;
                                }
                                if (mindate >= nd) {
                                    mindate = nd;
                                }
                            }

                        }
                        if (vstr.split(",").length < 2)
                            return;
                        for (var i = 0; i < vstr.split(",").length - 1; i++) {
                            try {


                                var pvalue1 = parseFloat(vstr.split(",")[i]);
                                var pdate1 = new Date(datestr.split(",")[i]);
                                var pvalue2 = parseFloat(vstr.split(",")[i + 1]);
                                var pdate2 = new Date(datestr.split(",")[i + 1]);

                                var seconds = parseFloat(GetDateSeconds(maxdate, mindate, "second"));
                                var secpoint1 = parseFloat(GetDateSeconds(pdate1, mindate, "second"));
                                var secpoint2 = parseFloat(GetDateSeconds(pdate2, mindate, "second"));
                                if (value != "-9999" && value != "") {

                                    var valuepoint1 = pvalue1 - parseFloat(minvalue);
                                    var valuepoint2 = pvalue2 - parseFloat(minvalue);
                                    var valuesrange = parseFloat(maxvalue) - parseFloat(minvalue);
                                    var x1 = parseFloat(serierect.X + (secpoint1 / seconds) * serierect.Width);
                                    var x2 = parseFloat(serierect.X + (secpoint2 / seconds) * serierect.Width);
                                    if (seconds == 0) {
                                        x1 = serierect.X;
                                        x2 = serierect.X;

                                    }
                                    var y1 = parseFloat(serierect.Bottom - (valuepoint1 / valuesrange) * serierect.Height);

                                    var y2 = parseFloat(serierect.Bottom - (valuepoint2 / valuesrange) * serierect.Height);
                                    if (valuesrange == 0) {
                                        y1 = serierect.Bottom;
                                        y2 = serierect.Bottom;

                                    }
                                    try {
                                        //保存曲线计算后的数据点
                                        serielines[i].setAttribute("d", "M" + x1 + "," + y1 + " L" + x2 + "," + y2);
                                        var pointpathd = "";
                                        switch (pointtype) {
                                            case "Column":
                                                {
                                                    //x, y - serie.PointSize / 2, x, y + serie.PointSize / 2
                                                    pointpathd = "M" + x1 + "," + parseFloat(y1 + pointsize / 2) + " L" + x1 + "," + parseFloat(y1 - pointsize / 2);
                                                    seriepoints[i].setAttribute("stroke", pointcolor);
                                                }
                                                break;
                                            case "Bar":
                                                {
                                                    // x - serie.PointSize / 2, y, x + serie.PointSize / 2, y
                                                    pointpathd = "M" + parseFloat(x1 + pointsize / 2) + "," + y1 + " L" + parseFloat(x1 - pointsize / 2) + "," + y1;
                                                    seriepoints[i].setAttribute("stroke", pointcolor);
                                                }
                                                break;
                                            case "Diamond":
                                                {



                                                    pointpathd = "M" + parseFloat(x1) + "," + parseFloat(y1 - pointsize / 2);
                                                    pointpathd += " L" + parseFloat(x1 + pointsize / 2) + "," + parseFloat(y1);
                                                    pointpathd += " L" + parseFloat(x1) + "," + parseFloat(y1 + pointsize / 2);
                                                    pointpathd += " L" + parseFloat(x1 - pointsize / 2) + "," + parseFloat(y1);
                                                    pointpathd += " L" + parseFloat(x1) + "," + parseFloat(y1 - pointsize / 2) + "Z";
                                                    seriepoints[i].setAttribute("fill", pointcolor);
                                                }
                                                break;
                                            case "Ellipse":
                                                {


                                                    pointpathd = "M" + parseFloat(x1) + "," + y1;
                                                    pointpathd += "m -" + pointsize / 2 + "," + 0;
                                                    pointpathd += " a" + pointsize / 2 + "," + pointsize / 2 + " 0 1,0 " + pointsize + ",0";
                                                    pointpathd += " a" + pointsize / 2 + "," + pointsize / 2 + " 0 1,0 -" + pointsize + ",0";
                                                    seriepoints[i].setAttribute("fill", pointcolor);
                                                }
                                                break;
                                            case "Rectangle":
                                                {
                                                    pointpathd = "M" + parseFloat(x1 - pointsize / 2) + "," + parseFloat(y1 - pointsize / 2) + " L" + parseFloat(x1 + pointsize / 2) + "," + parseFloat(y1 - pointsize / 2);
                                                    pointpathd += " L" + parseFloat(x1 + pointsize / 2) + "," + parseFloat(y1 + pointsize / 2);
                                                    pointpathd += " L" + parseFloat(x1 - pointsize / 2) + "," + parseFloat(y1 + pointsize / 2);
                                                    pointpathd += " L" + parseFloat(x1 - pointsize / 2) + "," + parseFloat(y1 - pointsize / 2) + "Z";
                                                    seriepoints[i].setAttribute("fill", pointcolor);
                                                }
                                                break;
                                            case "Triangle":
                                                {


                                                    pointpathd = "M" + parseFloat(x1 - pointsize / 2) + "," + parseFloat(y1);
                                                    pointpathd += " L" + parseFloat(x1) + "," + parseFloat(y1 - pointsize / 2);
                                                    pointpathd += " L" + parseFloat(x1 + pointsize / 2) + "," + parseFloat(y1);
                                                    pointpathd += " L" + parseFloat(x1 - pointsize / 2) + "," + parseFloat(y1) + "Z";
                                                    seriepoints[i].setAttribute("fill", pointcolor);
                                                }
                                                break;
                                            default:
                                                {
                                                    pointpathd = "";
                                                }
                                                break;
                                        }
                                        seriepoints[i].setAttribute("d", pointpathd);
                                        serielabels[i].setAttribute("x", x1);
                                        serielabels[i].setAttribute("y", y1 - 15);
                                        //设置内容
                                        serielabels[i].textContent = number_format(value, ioformat, null, null, null);

                                    }
                                    catch(e) {
                                        var strmsg = e.message;
                                    }
                                    console.log(serielines[i].getAttribute("d"));

                                }





                            }
                            catch(e) {

                            }



                        }
                        //设置对应的y轴标签axislabel='scale'
                        var parentGroup = $("#shape" + uid).parent();
                        if (parentGroup != undefined) {
                            var yaxis = $("#" + parentGroup[0].id + ">g[data-seriename='" + seriename + "']")[0];//获取Y轴对应的对象
                            var yaxislabels = $("#" + parentGroup[0].id + ">g[data-seriename='" + seriename + "']>text[axislabel='scale']");//获取Y轴对应的Labels
                            var xaxislabels = $("#" + parentGroup[0].id + ">g[class='xaxis']>text[axislabel='scale']");//获取X轴对应的Labels
                            var xdatetype = $("#" + parentGroup[0].id + ">g[class='xaxis']")[0].getAttribute("data-datetype");
                            var labelFormat = parseInt(yaxis.getAttribute("data-labelformat"));
                            if (labelFormat == undefined || labelFormat == "")
                                labelFormat = 0;

                            if (Math.abs(maxvalue) <= 1 && Math.abs(minvalue) <= 1) {
                                labelFormat = 1;
                            }
                            if (Math.abs(maxvalue) - Math.abs(minvalue) <= parseFloat(yaxislabels.length)) {
                                labelFormat = 1;
                            }
                            var valuesec = parseFloat(maxvalue - minvalue) / parseFloat(yaxislabels.length);
                            if (Math.abs(valuesec) <= 1) {
                                labelFormat = 1;
                            }
                            if (Math.abs(valuesec) <= 0.1) {
                                labelFormat = 2;
                            }
                            if (Math.abs(valuesec) <= 0.01) {
                                labelFormat = 3;
                            }

                            if (yaxislabels != undefined && yaxislabels.length > 0) {




                                var scalevalue = parseFloat(minvalue);
                                for (var i = 0; i < yaxislabels.length; i++) {
                                    yaxislabels[i].textContent = number_format(scalevalue, parseInt(labelFormat), null, null, null);
                                    scalevalue += parseFloat(valuesec);
                                }
                            }
                            if (xaxislabels != undefined && xaxislabels.length > 0) {
                                var datestr = "yyyy/MM/dd"
                                var timestr = "HH:mm:ss";
                                var timeNum = 0;
                                switch (xdatetype) {
                                    case "s":
                                        {
                                            timeNum = GetDateSeconds(maxdate, mindate, "second");
                                            datestr = "yyyy/MM/dd";
                                            timestr = " mm:ss";
                                        }
                                        break;
                                    case "m":
                                        {
                                            timeNum = GetDateSeconds(maxdate, mindate, "second");
                                            datestr = "yyyy/MM/dd";
                                            timestr = " mm:ss";
                                        }
                                        break;
                                    case "h":
                                        {
                                            timeNum = GetDateSeconds(maxdate, mindate, "minute");
                                            datestr = "yyyy/MM/dd";
                                            timestr = " hh:mm";
                                        }
                                        break;
                                    case "d":
                                        {
                                            timeNum = GetDateSeconds(maxdate, mindate, "hour");
                                            datestr = "yyyy/MM/dd";
                                            timestr = "hh";
                                        }
                                        break;
                                }


                                var xdis = serierect.Width / xaxislabels.length;
                                var timedis = parseInt(timeNum / xaxislabels.length);//计算
                                var currntDate = mindate;
                                for (var i = 0; i < xaxislabels.length; i++) {
                                    xaxislabels[i].textContent = "";
                                }
                                for (var i = 0; i < xaxislabels.length; i++) {

                                    currntDate = addSecond(currntDate, timedis);

                                    xaxislabels[i].textContent = currntDate.Format(timestr);

                                }

                            }
                        }

                        //设置对应的X轴标签


                    }
                    break;
                case "SVG_BarShape"://SVG实时柱图处理
                    {
                        //曲线图所在的实际区域
                        var serierect = { X: parseFloat(rectstr.split(',')[0]), Y: parseFloat(rectstr.split(',')[1]), Width: parseFloat(rectstr.split(',')[2]), Height: parseFloat(rectstr.split(',')[3]), Left: 0, Top: 0, Right: 0, Bottom: 0 };
                        serierect.Left = serierect.X;
                        serierect.Right = serierect.X + serierect.Width;
                        serierect.Top = serierect.Y;
                        serierect.Bottom = serierect.Y + serierect.Height;
                        var seriebar = $("#shape" + uid + ">[data-bar='1']");//获取柱图列表
                        var serielabels = $("#shape" + uid + ">[data-barlabel='1']");//获取柱图值显示的text
                        var parentShape = $("#shape" + uid).parent();//获取父容器的对象 
                        var showlabel = $("#shape" + uid).data("showlabel");
                        var majorinternal = parseFloat($("#shape" + uid).data("majorinternal"));//刻度间隔
                        var axisformat = parseInt($("#shape" + uid).data("axisformat"));//小数位数

                        $("#shape" + uid).data("value", value);//保存当前实时值，到柱图，主要是为了获取所有柱图中的最大值
                        //重新修改和绘制所有柱图
                        if (parentShape != undefined && parentShape != null) {
                            var maxvalue = 0;
                            var minvalue = 0;
                            var columns = $("#" + parentShape[0].id + ">g>[data-bar='1']");
                            var labels = $("#" + parentShape[0].id + ">g>[data-barlabel='1']");
                            var scales = $("#" + parentShape[0].id + ">g>[data-axisscale='1']");
                            for (var i = 0; i < columns.length; i++) {
                                try {
                                    var colparentShape = $("#" + columns[i].id).parent();//获取父容器的对象 
                                    if (colparentShape != undefined && colparentShape != null) {
                                        if ($("#" + colparentShape[0].id).data("value") != "-9999")
                                            maxvalue = Math.max(maxvalue, parseFloat($("#" + colparentShape[0].id).data("value")));
                                        minvalue = Math.min(minvalue, parseFloat($("#" + colparentShape[0].id).data("value")));
                                    }
                                }
                                catch(e) {
                                    continue;
                                }

                            }




                            if (minvalue == maxvalue) {

                                maxvalue = minvalue + 100;
                            }

                            var dis = parseFloat(maxvalue - minvalue) / 6;
                            maxvalue = parseFloat(maxvalue) + parseFloat(dis);
                            if (minvalue < 0) {

                                minvalue = parseFloat(minvalue) - parseFloat(dis);

                            }
                            else {
                                //判断如果最小值大于零,则要处理是否从0开始
                                minvalue = parseFloat(minvalue) - parseFloat(dis);
                                if (minvalue < 0) {
                                    minvalue = 0;
                                }
                            }

                            var maxdis = (maxvalue - minvalue) / majorinternal;


                            if (axisformat == undefined || axisformat == "")
                                axisformat = 0;

                            if (Math.abs(maxvalue) <= 1 && Math.abs(minvalue) <= 1) {
                                axisformat = 1;
                            }
                            if (Math.abs(maxvalue) - Math.abs(minvalue) <= parseFloat(majorinternal)) {
                                axisformat = 1;
                            }

                            if (Math.abs(maxdis) <= 1) {
                                axisformat = 1;
                            }
                            if (Math.abs(maxdis) <= 0.1) {
                                axisformat = 2;
                            }
                            if (Math.abs(maxdis) <= 0.01) {
                                axisformat = 3;
                            }

                            //重新计算刻度data-axisscale
                            for (var i = 0; i < scales.length; i++) {
                                var scale = minvalue + maxdis * i;
                                $("#" + scales[i].id).html(number_format(scale, axisformat, null, null, null).toString());
                                $("#" + scales[i].id).text(number_format(scale, axisformat, null, null, null).toString());

                            }
                            //重新计算每个柱图的高度
                            for (var i = 0; i < columns.length; i++) {

                                try {
                                    //重新计算高度
                                    var colparentShape = $("#" + columns[i].id).parent();//获取父容器的对象 
                                    if (colparentShape != undefined && colparentShape != null) {
                                        if ($("#" + colparentShape[0].id).data("value") != "-9999") {

                                            var colValue = parseFloat($("#" + colparentShape[0].id).data("value"));
                                            if (colValue != undefined && colValue != "-9999") {
                                                var h = colValue * serierect.Height / Math.abs(maxvalue - minvalue);
                                                $("#" + columns[i].id).attr("height", h);
                                                $("#" + columns[i].id).attr("y", serierect.Bottom - h - 1);
                                                //重新设置标签
                                                if (showlabel == "true" || showlabel == "True") {
                                                    $("#" + labels[i].id).html(colValue);
                                                    $("#" + labels[i].id).text(colValue);
                                                    $("#" + labels[i].id).attr("y", serierect.Bottom - 1 - h - 20);
                                                }
                                            }
                                            else {
                                                $("#" + columns[i].id).attr("height", "0");
                                                $("#" + columns[i].id).attr("y", serierect.Bottom - 1);
                                                //重新设置标签
                                                if (showlabel == "true" || showlabel == "True") {
                                                    $("#" + labels[i].id).html("");
                                                    $("#" + labels[i].id).text("");
                                                    $("#" + labels[i].id).attr("y", serierect.Bottom - 1);
                                                }
                                            }

                                        }

                                    }




                                }
                                catch(e) {
                                    continue;
                                }
                            }

                        }



                    }
                    break;
                case "SVG_PieShape"://SVG实时饼图处理
                    {
                        //曲线图所在的实际区域
                        var serierect = { X: parseFloat(rectstr.split(',')[0]), Y: parseFloat(rectstr.split(',')[1]), Width: parseFloat(rectstr.split(',')[2]), Height: parseFloat(rectstr.split(',')[3]), Left: 0, Top: 0, Right: 0, Bottom: 0 };
                        serierect.Left = serierect.X;
                        serierect.Right = serierect.X + serierect.Width;
                        serierect.Top = serierect.Y;
                        serierect.Bottom = serierect.Y + serierect.Height;
                        var parentShape = $("#shape" + uid).parent();//获取父容器的对象 
                        var showlabel = $("#shape" + uid).data("showlabel");//是否显示标注
                        var startangle = parseFloat($("#shape" + uid).data("startangle"));//饼图绘制的开始角度
                        var valuetype = $("#shape" + uid).data("valuetype");
                        $("#shape" + uid).data("value", value);//保存当前实时值，到饼图，主要是为了获取所有柱图中的最大值
                        //重新修改和绘制所有饼图
                        if (parentShape != undefined && parentShape != null) {
                            var allvalue = 0;
                            var pies = $("#" + parentShape[0].id + ">g>[data-pie='1']");//饼图
                            var labels = $("#" + parentShape[0].id + ">g>[data-pielabel='1']");//标注
                            var lines = $("#" + parentShape[0].id + ">g>[data-pieline='1']");//指示线
                            for (var i = 0; i < pies.length; i++) {
                                try {
                                    var colparentShape = $("#" + pies[i].id).parent();//获取父容器的对象 
                                    if (colparentShape != undefined && colparentShape != null) {
                                        if ($("#" + colparentShape[0].id).data("value") != "-9999")
                                            allvalue += parseFloat($("#" + colparentShape[0].id).data("value"));
                                    }
                                }
                                catch(e) {
                                    continue;
                                }

                            }
                            var angle = startangle;
                            //重新计算每个柱图的高度
                            for (var i = 0; i < pies.length; i++) {

                                try {
                                    //重新计算饼图
                                    var colparentShape = $("#" + pies[i].id).parent();//获取父容器的对象 
                                    if (colparentShape != undefined && colparentShape != null) {
                                        if ($("#" + colparentShape[0].id).data("value") != "-9999") {

                                            var colValue = parseFloat($("#" + colparentShape[0].id).data("value"));
                                            if (colValue != undefined && colValue != "-9999") {
                                                var percent = parseFloat(colValue / allvalue * 100);//百分比
                                                var absolute = parseFloat(colValue);
                                                var seriesAngle = parseFloat(colValue / allvalue * 360);
                                                var text = "";
                                                //绘制指示值
                                                if (valuetype == "Percentage") {
                                                    text = number_format(percent, 1, null, null, null) + "%";
                                                }
                                                else {
                                                    text = absolute.ToString();

                                                }
                                                if (seriesAngle > 0) {


                                                    var line = GetIndexLabelPos(angle, seriesAngle, serierect);
                                                    //修改指示线的
                                                    $("#" + lines[i].id).attr("x1", line.From.X);
                                                    $("#" + lines[i].id).attr("y1", line.From.Y);
                                                    $("#" + lines[i].id).attr("x2", line.To.X);
                                                    $("#" + lines[i].id).attr("y2", line.To.Y);
                                                    //修改指示标注
                                                    $("#" + labels[i].id).html(text);
                                                    $("#" + labels[i].id).text(text);
                                                    //修改标注位置
                                                    //   font-size='14' font-family='Microsoft YaHei'
                                                    var ts = TextSize($("#" + labels[i].id).attr("font-size"), $("#" + labels[i].id).attr("font-family"), text);
                                                    switch (line.Quadrant) {
                                                        case 1:
                                                            {

                                                                $("#" + labels[i].id).attr("x", line.To.X + ts.width / 2);
                                                                $("#" + labels[i].id).attr("y", line.To.Y - ts.height / 2);
                                                            }
                                                            break;
                                                        case 2:
                                                            {
                                                                $("#" + labels[i].id).attr("x", line.To.X + ts.width / 2);
                                                                $("#" + labels[i].id).attr("y", line.To.Y + ts.height / 2);
                                                            }
                                                            break;
                                                        case 3:
                                                            {

                                                                $("#" + labels[i].id).attr("x", line.To.X - ts.width / 2);
                                                                $("#" + labels[i].id).attr("y", line.To.Y + ts.height / 2);
                                                            }
                                                            break;
                                                        case 4:
                                                            {
                                                                $("#" + labels[i].id).attr("x", line.To.X - ts.width / 2);
                                                                $("#" + labels[i].id).attr("y", line.To.Y - ts.height / 2);
                                                            }
                                                            break;
                                                    }

                                                    //修改饼图范围
                                                    var ddata = GetPieData(angle, seriesAngle, serierect);
                                                    $("#" + pies[i].id).attr("d", ddata);

                                                    angle += seriesAngle;
                                                }
                                                else {
                                                    $("#" + pies[i].id).attr("d", "");
                                                    //重新设置标签
                                                    $("#" + labels[i].id).html("");
                                                    $("#" + labels[i].id).text("");
                                                    $("#" + lines[i].id).attr("x1", 0);
                                                    $("#" + lines[i].id).attr("y1", 0);
                                                    $("#" + lines[i].id).attr("x2", 0);
                                                    $("#" + lines[i].id).attr("y2", 0);
                                                }

                                            }
                                            else {
                                                $("#" + pies[i].id).attr("d", "");
                                                //重新设置标签
                                                $("#" + labels[i].id).html("");
                                                $("#" + labels[i].id).text("");
                                                $("#" + lines[i].id).attr("x1", 0);
                                                $("#" + lines[i].id).attr("y1", 0);
                                                $("#" + lines[i].id).attr("x2", 0);
                                                $("#" + lines[i].id).attr("y2", 0);
                                            }

                                        }

                                    }




                                }
                                catch(e) {
                                    continue;
                                }
                            }

                        }



                    }
                    break;
                case "SVG_TreeViewNodeShape"://树节点
                    {
                        var treeNode = $("#shape" + uid);
                        if (treeNode != undefined && treeNode != null) {

                            //获取节点文本对象
                            var treenodetext = $("#" + nodeId + ">g[data-filter='text']>a>text")[0];
                            if (treenodetext != undefined && treenodetext != null) {

                                $("#" + treenodetext.id).val(iovalue);
                                $("#" + treenodetext.id).text(iovalue);
                            }

                        }
                    }
                    break;
                case "SVG_TopologicalNodeShape"://拓扑图
                    {
                        var treeNode = $("#shape" + uid);
                        if (treeNode != undefined && treeNode != null) {

                            //获取节点文本对象
                            var treenodetext = $("#" + nodeId + ">g[data-filter='nodetext']>text")[0];
                            if (treenodetext != undefined && treenodetext != null) {

                                $("#" + treenodetext.id).val(iovalue);
                                $("#" + treenodetext.id).text(iovalue);
                            }

                        }
                    }
                    break;
                case "SVG_WaterLevelPondShape"://水位图
                    {
                        if (value.length <= 0)
                            return;
                        if (value == -9999 || value == "-9999")
                            return;
                        var lqrect = $("#shape" + uid + ">.ioupdate");
                        var maxvalue = shapeg.data("maxvalue");//水位最大值
                        var pondformat = shapeg.data("pondformat");//显示格式
                        var wavenum = parseInt(shapeg.data("wavenum"));//波纹数量
                        var current = parseInt(shapeg.data("current"));//获取上次显示的值
                        shapeg.data("current", value);//保存本次读取的值
                        var waveheight = parseInt(shapeg.data("waveheight"));//波纹高度
                        var pondLiq = $("#PondLiquid" + uid);  //获取液体显示对象
                        var rect = {
                            X: parseFloat(rectstr.split(',')[0]), Y: parseFloat(rectstr.split(',')[1]), Width: parseFloat(rectstr.split(',')[2]),

                            Height: parseFloat(rectstr.split(',')[3]), Top: parseFloat(rectstr.split(',')[1]), Bottom: parseFloat(rectstr.split(',')[1]) + parseFloat(rectstr.split

                                (',')[3]), Left: parseFloat(rectstr.split(',')[0]), Right: parseFloat(rectstr.split(',')[0]) + parseFloat(rectstr.split(',')[2])
                        };
                        if (pondLiq != undefined) {
                            var realValue = value / maxvalue;
                            var pointsNum = wavenum * 2.0 + 4;
                            var pointXGap = rect.Width / wavenum / 2.0;
                            var pondSource = pondLiq[0].getAttribute("d");
                            var pondData = [];
                            var startheight = (1 - realValue) * rect.Height;
                            var currentheight = (1 - current / maxvalue) * rect.Height;
                            var distance = startheight - currentheight ;
                            //重新设置波的所有的值
                            for (var i = 0; i < pondSource.split(' ').length; i++) {
                                if (pondSource.split(' ')[i].trim() != "") {
                                    var str = pondSource.split(' ')[i].trim();
                                    if (str.split(',').length == 2) {
                                        var xstr = str.split(',')[0];
                                        var ystr = str.split(',')[1];
                                        if (!isNaN(xstr)) {
                                            pondData.push({ Name: "", X: parseFloat(xstr), Y: parseFloat(ystr) });

                                        }
                                        else {
                                            pondData.push({ Name: xstr.substr(0, 1), X: parseFloat(xstr.substr(1, xstr.length - 1)), Y: parseFloat(ystr) });

                                        }

                                    }
                                    else {
                                        pondData.push({ Name: str.split(',')[0], X: -9999, Y: -9999 });

                                    }

                                }

                            }
                            for (var i = 0; i < pondData.length - 3; i++) {

                              
                                pondData[i].Y += distance;
                                 

                            }
                            var strD = "";
                            for (var i = 0; i < pondData.length; i++) {
                                if (pondData[i].X != -9999 && pondData[i].Y != -9999)
                                    strD += (strD == "" ? "" : " ") + (pondData[i].Name + "" + pondData[i].X + "," + pondData[i].Y);
                                else
                                    strD += (strD == "" ? "" : " ") + pondData[i].Name;
                            }
                            pondLiq[0].setAttribute("d", strD);
                            //设置动画变化的D
                            var animate = $("#animate" + uid);  //获取液体显示对象
                            var animateSource1 = animate[0].getAttribute("values").split(";")[0];
                            var animateSource2 = animate[0].getAttribute("values").split(";")[1];
                            var animateData1 = [];
                            var animateData2 = [];
                            //重新设置波的所有的值
                            for (var i = 0; i < animateSource1.split(' ').length; i++) {
                                if (animateSource1.split(' ')[i].trim() != "") {
                                    var str = animateSource1.split(' ')[i].trim();
                                    if (str.split(',').length == 2) {
                                        var xstr = str.split(',')[0];
                                        var ystr = str.split(',')[1];
                                        if (!isNaN(xstr)) {
                                            animateData1.push({ Name: "", X: parseFloat(xstr), Y: parseFloat(ystr) });

                                        }
                                        else {
                                            animateData1.push({
                                                Name: xstr.substr(0, 1), X: parseFloat(xstr.substr(1, xstr.length - 1)), Y: parseFloat(ystr)

                                            });

                                        }

                                    }
                                    else {
                                        animateData1.push({ Name: str.split(',')[0], X: -9999, Y: -9999 });

                                    }

                                }
                            }
                            for (var i = 0; i < animateData1.length - 3; i++) {
                            
                                animateData1[i].Y += distance;
                
                            }

                            for (var i = 0; i < animateSource2.split(' ').length; i++) {
                                if (animateSource2.split(' ')[i].trim() != "") {
                                    var str = animateSource2.split(' ')[i].trim();
                                    if (str.split(',').length == 2) {
                                        var xstr = str.split(',')[0];
                                        var ystr = str.split(',')[1];
                                        if (!isNaN(xstr)) {
                                            animateData2.push({ Name: "", X: parseFloat(xstr), Y: parseFloat(ystr) });

                                        }
                                        else {
                                            animateData2.push({
                                                Name: xstr.substr(0, 1), X: parseFloat(xstr.substr(1, xstr.length - 1)), Y: parseFloat(ystr)

                                            });

                                        }

                                    }
                                    else {
                                        animateData2.push({ Name: str.split(',')[0], X: -9999, Y: -9999 });

                                    }

                                }
                            }
                            for (var i = 0; i < animateData2.length - 3; i++) {
                               
                           
                                animateData2[i].Y += distance;
                            }

                            var animateStrD1 = "";
                            var animateStrD2 = "";
                            for (var i = 0; i < animateData1.length; i++) {
                                if (animateData1[i].X != -9999 && animateData1[i].Y != -9999)
                                    animateStrD1 += (animateStrD1 == "" ? "" : " ") + (animateData1[i].Name + "" + animateData1[i].X + "," + animateData1

                                    [i].Y);
                                else
                                    animateStrD1 += (animateStrD1 == "" ? "" : " ") + animateData1[i].Name;
                            }
                            for (var i = 0; i < animateData2.length; i++) {
                                if (animateData2[i].X != -9999 && animateData2[i].Y != -9999)
                                    animateStrD2 += (animateStrD2 == "" ? "" : " ") + (animateData2[i].Name + "" + animateData2[i].X + "," + animateData2

                                    [i].Y);
                                else
                                    animateStrD2 += (animateStrD2 == "" ? "" : " ") + animateData2[i].Name;
                            }

                            animate[0].setAttribute("values", animateStrD1 + ";" + animateStrD2);
                        }
                        //修改显示值信息
                        var txt = $("#PondText" + uid);
                        if (txt != undefined) {
                            if (pondformat == "percent") {
                                var strFormat = number_format(parseFloat(realValue * 100), ioformat, '.', ',', 'round');
                                txt.html(strFormat + "%");
                                txt.text(strFormat + "%");
                            }
                            else {
                              

                                var strFormat = number_format(parseFloat(value), ioformat, '.', ',', 'round');
                                txt.html(strFormat);
                                txt.text(strFormat);
                            }
                          
                        }
                    }
                    break;
                case "SVG_ActiveRingChartItemShape"://环装图子项
                    {
                        if (value.length <= 0)
                            return;
                        if (value == -9999 || value == "-9999")
                            return;
                        var ringitemgroup = $("#shape" + uid + "");
               
                        ringitemgroup.data("value", value);

                        SCADA.DrawRingChart(ringitemgroup.data("parentuid"))

                         
                    }
                    break;
                case "SVG_ProcessChartShape"://环装图子项
                    {
                        if (value.length <= 0)
                            return;
                        if (value == -9999 || value == "-9999")
                            return;
                        var progressBar = $("#shape" + uid + "");
                        var valueformat = progressBar.data("valueformat");
                        var maxvalue = parseFloat( progressBar.data("maxvalue"));
                        var progresslines = $("#shape" + uid + ">g[data-filter='progressline']>line");//获取所有当前的对象
                        for (var i = 0; i < progresslines.length; i++) {
                            var line = $("#" + progresslines[i].id);
                            var upvalue = parseFloat(line.data("upvalue"));
                            if (parseFloat(value) >= upvalue) {

                                line.show();
                                line.attr("style", "display:block;");
                                line.attr("visibility", "visible");
                            }
                            else {
                                line.hide();
                                line.attr("style", "display:none;");
                                line.attr("visibility", "hidden");
                            }

                        }
                        var realValue = parseFloat(value)/ maxvalue;
                        var txt = $("#ProgressText" + uid);
                        if (txt != undefined) {
                            if (valueformat == "percent") {
                                var strFormat = number_format(parseFloat(realValue * 100), ioformat, '.', ',', 'round');
                                txt.html(strFormat + "%");
                                txt.text(strFormat + "%");
                            }
                            else {


                                var strFormat = number_format(parseFloat(value), ioformat, '.', ',', 'round');
                                txt.html(strFormat);
                                txt.text(strFormat);
                            }

                        }


                    }
                    break;
                case "SVG_ConicalChartItemShape"://锥形图子项
                    {
                        if (value.length <= 0)
                            return;
                        if (value == -9999 || value == "-9999")
                            return;
                        var conicalitemgroup = $("#shape" + uid + "");
                        conicalitemgroup.data("value", value);//设置当前的子项值
                        SCADA.DrawConicalChart(conicalitemgroup.data("parentuid"));
                    }                
                    break;
                case "SVG_RankingBarChartItemShape"://轮播排名图
                    {
                        if (value.length <= 0)
                            return;
                        if (value == -9999 || value == "-9999")
                            return;
                        var rankgroup = $("#shape" + uid + "");
                        rankgroup.data("value", value);//设置当前的子项值
                        SCADA.DrawRankChart(rankgroup.data("parentuid"));
                    }
                    break;
            
            }

        }
        catch(e) {


        }


    }
    //动态设置RingChart效果
    this.DrawRankChart = function (uid) {

        var shapeg = $("#shape" + uid);
        if (shapeg == undefined)
            return;
        var maxvalue = 0;
        var itemobject = [];
        var rectstr = shapeg.data("rect");
        var number = parseInt( shapeg.data("number"));
        var rect = { X: parseFloat(rectstr.split(',')[0]), Y: parseFloat(rectstr.split(',')[1]), Width: parseFloat(rectstr.split(',')[2]), Height: parseFloat(rectstr.split(',')[3]) };
        rect.Left = rect.X;
        rect.Right = rect.X + rect.Width;
        rect.Top = rect.Y;
        rect.Bottom = rect.Y + rect.Height;
        rect.CX = rect.X + rect.Width / 2;//圆心
        rect.CY = rect.Y + rect.Height / 2;
        rect.RX = rect.Width / 2;//半径
        rect.RY = rect.Height / 2;//
        var items = $("#shape" + uid + ">g[data-filter='RankItem']");
        for (var i = 0; i < items.length; i++) {
            var groupid = items[i].id;
            var rankitemgroup = $("#" + groupid + "");
            var itemvalue = rankitemgroup.data("value");//获取当前值
            maxvalue = Math.max(parseFloat(itemvalue), maxvalue);//
            var groupid = items[i].id;
            var itemvalue = rankitemgroup.data("value");
            var itemtitle = rankitemgroup.data("title");
            itemobject.push({ gid: groupid, itemvalue: parseFloat(itemvalue), itemtitle: itemtitle, rect: rect });
        }

        itemobject.sort(({ itemvalue: a }, { itemvalue: b }) => {
            if (a < b) return -1;
            if (a > b) return 1;
            if (a === b) return 0;
        });
        var basiclinewidth = parseFloat( shapeg.data("basiclinewidth"));
        var titleheight = parseFloat(shapeg.data("titleheight"));
        var iconheight = parseFloat(shapeg.data("iconheight"));
        var currenty = parseFloat(shapeg.data("currenty"));
        maxvalue = maxvalue + maxvalue / 10;//当前所有项的最大值
        var x = rect.X;
        var y = currenty + Math.max(titleheight, iconheight);
        var space = titleheight + 10 + parseFloat(basiclinewidth);
        for (var i = 0; i < itemobject.length; i++) {
            var groupid = itemobject[i].gid;
            var w = itemobject[i].itemvalue / maxvalue * rect.Width;
            var rankitemgroup = $("#" + groupid + "");
            var rankmajorline = $("#" + groupid + ">line[data-filter='major']");
            var rankbasicline = $("#" + groupid + ">line[data-filter='basic']");
            var rankicon = $("#" + groupid + ">image");
            var ranktitle = $("#" + groupid + ">text[data-filter='title']");
            var rankvalue = $("#" + groupid + ">text[data-filter='value']");
            var majorlinewidth = rankitemgroup.data("majorlinewidth");
            var valueheight = parseFloat(rankitemgroup.data("valueheight"));
            rankbasicline.attr("y1", y + parseFloat(majorlinewidth) + parseFloat(basiclinewidth));
            rankbasicline.attr("y2", y + parseFloat(majorlinewidth) + parseFloat(basiclinewidth));


            rankmajorline.attr("y1", y + parseFloat(basiclinewidth));
            rankmajorline.attr("y2", y + parseFloat(basiclinewidth));
            rankmajorline.attr("x2", x + w);
            if (rankicon != undefined && rankicon != null) {
                rankicon.attr("y", y - iconheight - 5);
            }
            if (ranktitle != undefined && ranktitle != null) {
                ranktitle.attr("y", y - titleheight/2);
            }
            if (rankvalue != undefined && rankvalue != null) {
                var strFormat = number_format(itemobject[i].itemvalue, number, '.', ',', 'round');
                rankvalue.attr("y", y - valueheight/2);
                rankvalue.html(strFormat);
            }
            y += parseFloat(majorlinewidth)+ space;

        }

    }
    //动态设置DrawRankChart轮播效果 
    this.LoadRankAnimate = function (dur, uid,height) {
        var shapeg = $("#shape" + uid);
        if (shapeg == undefined)
            return;

        var distance = parseFloat(height);//每次轮播的实际移动的距离
        var rectstr = shapeg.data("rect");
        var enablescroll = shapeg.data("enablescroll");
        //如果不支持滚动，则直接跳过不执行动态播放
        if (enablescroll == "false") {
            return;
        }
        var rect = { X: parseFloat(rectstr.split(',')[0]), Y: parseFloat(rectstr.split(',')[1]), Width: parseFloat(rectstr.split(',')[2]), Height: parseFloat(rectstr.split(',')[3]) };
        rect.Left = rect.X;
        rect.Right = rect.X + rect.Width;
        rect.Top = rect.Y;
        rect.Bottom = rect.Y + rect.Height;
        rect.CX = rect.X + rect.Width / 2;//圆心
        rect.CY = rect.Y + rect.Height / 2;
        rect.RX = rect.Width / 2;//半径
        rect.RY = rect.Height / 2;//

        $('body').everyTime(dur + "s", function () {
            try {
                var currenty = parseFloat(shapeg.data("currenty"));
                currenty -= distance;
                if (currenty < rect.Y - rect.Height) {
                    currenty = rect.Y;
                }
                shapeg.data("currenty", currenty);
                //设置当前的值
                SCADA.DrawRankChart(uid);
            } catch (e) { }
        });
    }
    //动态设置RingChart效果
    this.LoadRingAnimate = function (dur,uid) {

        //设置定时器实时读取数据
      
        $('body').everyTime(dur + "s", function () {
            try {
                var shapeg = $("#shape" + uid);
                if (shapeg == undefined)
                    return;
                var items = $("#shape" + uid + ">g[data-filter='RingItem']");
                var activeIndex = 0;
                var total = 0;
                for (var i = 0; i < items.length; i++) {
                    var groupid = items[i].id;
                    var ringitemgroup = $("#" + groupid + "");
                    var itemvalue = ringitemgroup.data("value");
                    var active = ringitemgroup.data("active");
                    if (active == "true" || active == "True") {
                        activeIndex = (i + 1) % (items.length);
                    }
                    ringitemgroup.data("active", "false");
                    total += parseFloat(itemvalue);
                }
                var activeitem = $("#" + items[activeIndex].id + "");
                activeitem.data("active", "true");
                var txtvalue = $("#shape" + uid + ">.iotext")[0];
                var txttitle = $("#shape" + uid + ">.iotext")[1];
                if (txtvalue != undefined) {
                    var io = activeitem.data("iovalue");
 
                    var ioformat = "0";
                    if (io != undefined && io != "") {
                        ioformat = io.split(",")[5];
                    }
                    var itemvalue = activeitem.data("value");
                    var ringformat = activeitem.data("ringformat");
                    if (ringformat == "percent") {
                        var strFormat = number_format(parseFloat(itemvalue) / total * 100, ioformat, '.', ',', 'round');
                        $("#" + txtvalue.id).html(strFormat + "%");
                        $("#" + txtvalue.id).text(strFormat + "%");
                    }
                    else {
                        var strFormat = number_format(parseFloat(itemvalue), ioformat, '.', ',', 'round');
                        $("#" + txtvalue.id).html(strFormat );
                        $("#" + txtvalue.id).text(strFormat);
                    }
                    if (txttitle != undefined) {
                        var itemtitle = activeitem.data("title");
                        $("#" + txttitle.id).html(itemtitle );
                        $("#" + txttitle.id).text(itemtitle );
                    }
                }
                //设置当前的值
                SCADA.DrawRingChart(uid);
            } catch (e) { }
            });
       
    }
    this.DrawRingChart = function (uid) {

        var shapeg = $("#shape" + uid);
        if (shapeg == undefined)
            return;
        var items = $("#shape" + uid + ">g[data-filter='RingItem']");
        var itemobject = [];
        var total = 0;
        for (var i = 0; i < items.length; i++) {
            var groupid = items[i].id;
            var ringitemgroup = $("#" + groupid + "");
            var ringitempath = $("#" + groupid + ">.ioupdate");
            var itemvalue = ringitemgroup.data("value");
            var itemtitle = ringitemgroup.data("title");
            var linewidth = ringitemgroup.data("linewidth");
            var ringcolor = ringitemgroup.data("ringcolor");
            var ringcoloropacity = ringitemgroup.data("ringcoloropacity");
            var due = ringitemgroup.data("due");
            var startangle = ringitemgroup.data("startangle");
            var activeradius = ringitemgroup.data("activeradius");
            var ringformat = ringitemgroup.data("ringformat");
            var active = ringitemgroup.data("active");
            var rectstr = shapeg.data("rect");

            if (itemvalue == undefined || itemvalue == null || itemvalue == "" || itemvalue == "-9999") {
                itemvalue = 0;
            }
            itemobject.push({ gid: groupid, itemvalue: parseFloat(itemvalue), itemtitle: itemtitle, linewidth: linewidth, ringcolor: ringcolor, ringcoloropacity: ringcoloropacity, due: due, startangle: startangle, activeradius: activeradius, ringformat: ringformat, percent: 0, active: active, rect: rectstr, sweep: 0 });

            total += parseFloat(itemvalue);
        }


        ///计算百分比
        for (var i = 0; i < itemobject.length; i++) {
            if (total != 0)
                itemobject[i].percent = itemobject[i].itemvalue / total;
            else
                itemobject[i].percent = 0;
            itemobject[i].sweep = itemobject[i].percent * 360;//计算的实际角度
            if (i > 0)
                itemobject[i].startangle = (itemobject[i - 1].startangle + itemobject[i - 1].sweep) % 360;
        }
        //重新计算绘图
        for (var i = 0; i < itemobject.length; i++) {
            var groupid = itemobject[i].gid;
            var ringitemgroup = $("#" + groupid + "");
            var ringitempath = $("#" + groupid + ">.ioupdate");
            var acradious = 0;
            if (itemobject[i].active == "true") {
                acradious = parseFloat(itemobject[i].activeradius);
            }
            var rect = {
                X: parseFloat(itemobject[i].rect.split(',')[0]) - acradious / 2, Y: parseFloat(itemobject[i].rect.split(',')[1]) - acradious / 2, Width: parseFloat(itemobject[i].rect.split(',')[2]) + acradious,

                Height: parseFloat(itemobject[i].rect.split(',')[3]) + acradious, Top: parseFloat(itemobject[i].rect.split(',')[1]) - acradious / 2, Bottom: parseFloat(itemobject[i].rect.split(',')[1]) + parseFloat(itemobject[i].rect.split

                    (',')[3]) + acradious / 2, Left: parseFloat(itemobject[i].rect.split(',')[0]) - acradious / 2, Right: parseFloat(itemobject[i].rect.split(',')[0]) + parseFloat(itemobject[i].rect.split(',')[2]) + acradious / 2, CX: 0, CY: 0, RX: 0, RY: 0
            };
            rect.CX = rect.X + rect.Width / 2;//圆心
            rect.CY = rect.Y + rect.Height / 2;
            rect.RX = rect.Width / 2;//半径
            rect.RY = rect.Height / 2;
            var startangle = 3.1415926 / 180.0 * (itemobject[i].startangle) % 360;
            var cx = rect.CX + rect.RX * Math.cos(startangle);
            var cy = rect.CY + rect.RY * Math.sin(startangle);
            var sweep = 3.1415926 / 180.0 * (itemobject[i].startangle + itemobject[i].sweep) % 360;
            var ex = rect.CX + rect.RX * Math.cos(sweep);
            var ey = rect.CY + rect.RY * Math.sin(sweep);

            //M cx cy A rx ry x-axis-rotation large-arc-flag sweep-flag x y
            var sweepflg = 1;
            var largeflg = 0;
            if (itemobject[i].sweep > 180) {
                largeflg = 1;
            }
            var str = "M" + cx + "," + cy + " A" + rect.RX + "," + rect.RY + " 0 " + largeflg + "," + sweepflg + " " + ex + "," + ey;
            ringitempath.attr("d", str);


        }

    }

    //绘制锥形图
    this.DrawConicalChart = function (uid) {
        var shapeg = $("#shape" + uid);
        if (shapeg == undefined)
            return;
        var rectstr = shapeg.data("rect");
        //获取当前的所有子项
        var rect = { X: parseFloat(rectstr.split(',')[0]), Y: parseFloat(rectstr.split(',')[1]), Width: parseFloat(rectstr.split(',')[2]), Height: parseFloat(rectstr.split(',')[3]) };
        rect.Left = rect.X;
        rect.Right = rect.X + rect.Width;
        rect.Top = rect.Y;
        rect.Bottom = rect.Y + rect.Height;
        rect.CX = rect.X + rect.Width / 2;//圆心
        rect.CY = rect.Y + rect.Height / 2;
        rect.RX = rect.Width / 2;//半径
        rect.RY = rect.Height / 2;
        var itemsort = shapeg.data("sort");
        var items = $("#shape" + uid + ">g[data-filter='conicalitem']");
        var maxValue = -9999;
        var radious = rect.Width / (items.length + 1);
        var itemobject = [];
        for (var i = 0; i < items.length; i++) {
            var groupid = items[i].id;
            var itemgroup = $("#" + groupid + "");
            var number = itemgroup.data("number");
            var itemvalue = itemgroup.data("value");
            var itemtitle = itemgroup.data("title");
            var itemsort = itemgroup.data("sort");

            itemobject.push({ gid: groupid, itemvalue: parseFloat(itemvalue), itemtitle: itemtitle, number: number});
            maxValue = Math.max(maxValue, parseFloat(itemvalue));
        }
        itemobject.sort(({ itemvalue: a }, { itemvalue: b }) => {
            if (a < b) return -1;
            if (a > b) return 1;
            if (a === b) return 0;
        });
        var x = rect.X;
        var y = rect.Bottom;
        if (itemsort == "asc") {
            for (var i = 0; i < itemobject.length; i++) {
                var groupid = itemobject[i].gid;
                var itemgroup = $("#" + groupid + "");
                var itempath = $("#" + groupid + ">.ioupdate");
                var itemvalueobject = $("#" + groupid + ">.iotext");
                var itemtitleobject = $("#" + groupid + ">.itemtitle");
                var itemimage = $("#" + groupid + ">image");
                var iconwidth = itemgroup.data("iconwidth");
                var iconheight = itemgroup.data("iconheight");
                ///升序排列  
                    var h = itemobject[i].itemvalue / maxValue * rect.Height;
                    var middleXPos = rect.X + radious * (i + 1);
                    var leftXPos = rect.X + radious * i;
                    var rightXpos = rect.X + radious * (i + 2);
                    var middleYPos = y - h;
                    var controlYPos = h * 0.6 + middleYPos;
                    var pathD = "  M" + leftXPos + "," + rect.Bottom + " Q" + middleXPos + ", " + controlYPos + " " + middleXPos + "," + middleYPos + " M" + middleXPos + "," + middleYPos + " Q" + middleXPos + ", " + controlYPos + " " + rightXpos + ", " + rect.Bottom + " L" + leftXPos + ", " + rect.Bottom + " Z";
                    itempath.attr("d", pathD);
                //设置Icon路径
                if (itemimage != undefined && itemimage != null) {
                    itemimage.attr("y", middleYPos - iconheight - 10);
                    itemimage.attr("x", middleXPos - iconwidth / 4);
                }
                //设置值
                if (itemvalueobject != undefined && itemvalueobject != null) {
                    itemvalueobject.attr("y", middleYPos + 20);
                    itemvalueobject.attr("x", middleXPos);
                    var strFormat = number_format(parseFloat(itemobject[i].itemvalue), itemobject[i].number, '.', ',', 'round');
                    itemvalueobject.html(strFormat);
                    itemvalueobject.text(strFormat);
                }
                if (itemtitleobject != undefined && itemtitleobject != null) {
            
                    itemtitleobject.attr("x", middleXPos);
                }
                
            }
        }
        else {
            var ii = 0;
            for (var i = itemobject.length - 1; i >= 0; i--)
            {
                var groupid = itemobject[i].gid;
                var itemgroup = $("#" + groupid + "");
                var itempath = $("#" + groupid + ">.ioupdate");
                var itemvalueobject = $("#" + groupid + ">.iotext");
                var itemtitleobject = $("#" + groupid + ">.itemtitle");
                var itemimage = $("#" + groupid + ">image");
                var iconwidth = itemgroup.data("iconwidth");
                var iconheight = itemgroup.data("iconheight");
                ///升序排列
                    var h = itemobject[i].itemvalue / maxValue * rect.Height;
                    var middleXPos = rect.X + radious * (ii + 1);
                    var leftXPos = rect.X + radious * ii;
                    var rightXpos = rect.X + radious * (ii + 2);
                    var middleYPos = y - h;
                    var controlYPos = h * 0.6 + middleYPos;
                    var pathD = "  M" + leftXPos + "," + rect.Bottom + " Q" + middleXPos + ", " + controlYPos + " " + middleXPos + "," + middleYPos + " M" + middleXPos + "," + middleYPos + " Q" + middleXPos + ", " + controlYPos + " " + rightXpos + ", " + rect.Bottom + " L" + leftXPos + ", " + rect.Bottom + " Z";
                    itempath.attr("d", pathD);
                //设置Icon路径
                if (itemimage != undefined && itemimage != null) {
                    itemimage.attr("y", middleYPos - iconheight - 10);
                    itemimage.attr("x", middleXPos - iconwidth/4);
                }
                //设置值
                if (itemvalueobject != undefined && itemvalueobject != null) {
                    itemvalueobject.attr("y", middleYPos + 20);
                    itemvalueobject.attr("x", middleXPos );
                    var strFormat = number_format(parseFloat(itemobject[i].itemvalue), itemobject[i].number, '.', ',', 'round');
                    itemvalueobject.html(strFormat);
                    itemvalueobject.text(strFormat);
                }
                if (itemtitleobject != undefined && itemtitleobject != null) {

                    itemtitleobject.attr("x", middleXPos );
                }
                ii++;
            }
        }
     

        //重新绘制图形
    }
    //绘制环形图

    //动态更新实时报警
    this.UpdateFlowAlarm = function (alarms, reocrdnum, pagesize, pageindex, uid) {
        var shapeg = $("#shape" + uid);
        if (shapeg == undefined)
            return;
        var shapeName = shapeg.data("shape");
        var pagecolor = shapeg.data("pagecolor");
        var pagecount = parseInt(parseInt(reocrdnum) / parseInt(pagesize));
        if (parseInt(parseInt(reocrdnum) % parseInt(pagesize)) != 0) {
            pagecount++;
        }
        if (shapeName != undefined && shapeName == "SVG_AlarmListShape") {
            //g下包含 class='alarmtable'
            var alarmrows = $("#shape" + uid + ">g[class='alarmtable']>g[class='alarmrows']");
            for (var row = 0; row < alarmrows.length; row++) {
                if (row < alarms.length) {

                    var texts = alarmrows[row].children;
                    if (texts.length == 7) {
                        $("#" + texts[0].id).html(alarms[row].IO_ID);
                        $("#" + texts[1].id).html(alarms[row].IO_LABEL + " " + alarms[row].IO_NAME);
                        $("#" + texts[2].id).html(alarms[row].IO_ALARM_TYPE);
                        $("#" + texts[3].id).html(alarms[row].IO_ALARM_LEVEL);
                        $("#" + texts[4].id).html(alarms[row].IO_ALARM_VALUE);
                        $("#" + texts[5].id).html(alarms[row].IO_ALARM_DATE);
                        $("#" + texts[6].id).html(alarms[row].DEVICE_NAME);


                        $("#" + texts[0].id).text(alarms[row].IO_ID);
                        $("#" + texts[1].id).text(alarms[row].IO_LABEL + " " + alarms[row].IO_NAME);
                        $("#" + texts[2].id).text(alarms[row].IO_ALARM_TYPE);
                        $("#" + texts[3].id).text(alarms[row].IO_ALARM_LEVEL);
                        $("#" + texts[4].id).text(alarms[row].IO_ALARM_VALUE);
                        $("#" + texts[5].id).text(alarms[row].IO_ALARM_DATE);
                        $("#" + texts[6].id).text(alarms[row].DEVICE_NAME);
                    }
                }
                else {
                    var texts = alarmrows[row].children;
                    if (texts.length == 7) {
                        $("#" + texts[0].id).html("");
                        $("#" + texts[1].id).html("");
                        $("#" + texts[2].id).html("");
                        $("#" + texts[3].id).html("");
                        $("#" + texts[4].id).html("");
                        $("#" + texts[5].id).html("");
                        $("#" + texts[6].id).html("");

                        $("#" + texts[0].id).text("");
                        $("#" + texts[1].id).text("");
                        $("#" + texts[2].id).text("");
                        $("#" + texts[3].id).text("");
                        $("#" + texts[4].id).text("");
                        $("#" + texts[5].id).text("");
                        $("#" + texts[6].id).text("");
                    }
                }
            }
            var pages = $("#shape" + uid + ">g[class='pager']>g[class='pagebutton']");
            //设置页码
            //首页
            var firstbutton = pages[0].children;
            $("#" + firstbutton[1].id).bind("click", function () {
                pageindex = 1;
                shapeg.data("pagesize", pagesize);
                shapeg.data("pageindex", 1);
                SCADA.ReadFlowRealData();
            });
            //下一页
            var nextbutton = pages[1].children;
            $("#" + nextbutton[1].id).bind("click", function () {
                shapeg.data("pagesize", pagesize);
                if (pageindex < pagecount)
                    shapeg.data("pageindex", pageindex++);
                else
                    shapeg.data("pageindex", pagecount);
                SCADA.ReadFlowRealData();
            });
            //上一页
            var prebutton = pages[2].children;
            $("#" + prebutton[1].id).bind("click", function () {
                shapeg.data("pagesize", pagesize);
                if (pageindex > 1)
                    shapeg.data("pageindex", pageindex--);
                else
                    shapeg.data("pageindex", 1);
                SCADA.ReadFlowRealData();
            });
            //尾页
            var endbutton = pages[3].children;
            $("#" + endbutton[1].id).bind("click", function () {
                pageindex = pagecount;
                shapeg.data("pagesize", pagesize);
                shapeg.data("pageindex", pagecount);
                SCADA.ReadFlowRealData();
            });
            //说明
            var descbutton = pages[4].children;
            $("#" + descbutton[1].id).html("当前" + pageindex + "/" + pagecount + ",共计有" + reocrdnum + "条");
            $("#" + descbutton[1].id).text("当前" + pageindex + "/" + pagecount + ",共计有" + reocrdnum + "条");

        }
    }
    ///图元隐藏显示IO更新
    this.UpdateVisible = function (iovalue, time, status, datatype, uid) {
        //获取对应的shape 每个shape 有一个g,包含IO参数

        var value = parseFloat(iovalue);
        if (datatype == "Value") {
            value = parseFloat(iovalue);
        }
        else if (datatype == "Status") {
            value = parseInt(status);
        }
        var shapeg = $("#shape" + uid);
        if (shapeg == undefined)
            return;
        var shapeName = shapeg.data("shape");
        var shapetype = shapeg.data("baseshape");
        if (shapetype == undefined)
            return;
        if (shapetype == "SVG_IOShape")
            reutrn;
        var io = shapeg.data("iovisible");
        if (io == undefined)
            return;
        var ioserver = io.split(",")[0];
        var iocommunicate = io.split(",")[1];
        var iodevice = io.split(",")[2];
        var iopara = io.split(",")[3];
        var iotype = io.split(",")[4];
        var ioformat = io.split(",")[5];
        var iounit = io.split(",")[6];
        if (shapeg != undefined) {
            var trueexpression = shapeg.data("iovisibletrue");
            var trueop = trueexpression.split(":")[0];
            var truevalue = parseFloat(trueexpression.split(":")[1]);
            var falseexpression = shapeg.data("iovisiblefalse");
            var falseop = falseexpression.split(":")[0];
            var falsevalue = parseFloat(falseexpression.split(":")[1]);
            var tv = analysisOpeartor(trueop, truevalue, value);
            var fv = analysisOpeartor(falseop, falsevalue, value);
            if (tv == true) {
                shapeg.attr("style", "display:block");
                shapeg.show();
            }

            if (fv == true) {
                shapeg.attr("style", "display:none");
                shapeg.hide();
            }
        }

    }
    ///图元颜色变换IO更新
    this.UpdateColorChanged = function (iovalue, time, status, datatype, uid) {
        //获取对应的shape 每个shape 有一个g,包含IO参数

        var value = parseFloat(iovalue);
        if (datatype == "Value") {
            value = parseFloat(iovalue);
        }
        else if (datatype == "Status") {
            value = parseInt(status);
        }
        var shapeg = $("#shape" + uid);
        if (shapeg == undefined)
            return;
        var shapeName = shapeg.data("shape");
        var shapetype = shapeg.data("baseshape");
        if (shapetype == undefined)
            return;
        if (shapetype == "SVG_IOShape")
            reutrn;
        var io = shapeg.data("iochange");
        if (io == undefined)
            return;
        var ioserver = io.split(",")[0];
        var iocommunicate = io.split(",")[1];
        var iodevice = io.split(",")[2];
        var iopara = io.split(",")[3];
        var iotype = io.split(",")[4];
        var ioformat = io.split(",")[5];
        var iounit = io.split(",")[6];
        var sourcecolor = shapeg.data("sourcecolor");
        var changcolor = shapeg.data("changcolor");
        var rectstr = shapeg.data("rect");
        if (shapeg != undefined) {
            var trueexpression = shapeg.data("iochangetrue");
            var trueop = trueexpression.split(":")[0];
            var truevalue = parseFloat(trueexpression.split(":")[1]);
            var falseexpression = shapeg.data("iochangefalse");
            var falseop = falseexpression.split(":")[0];
            var falsevalue = parseFloat(falseexpression.split(":")[1]);
            var tv = analysisOpeartor(trueop, truevalue, value);
            var fv = analysisOpeartor(falseop, falsevalue, value);
            //分别处理颜色变化,目前只是笼统处理了一下
            if (shapetype == "SVG_CommonShape") {
                if (shapeg[0].children.length > 0) {
                    for (var i = 0; i < shapeg[0].children.length; i++) {
                        if (shapeg[0].children[i].tagName == "g" || shapeg[0].children[i].tagName == "a") {
                            for (var j = 0; j < shapeg[0].children[i].childNodes.length; j++) {

                                var fill = shapeg[0].children[i].childNodes[j].getAttribute("fill");
                                if (fill == "none")
                                    continue;
                                if (tv == true) {

                                    if (fill.indexOf("(") >= 0)//表示渐进填充
                                    {
                                        var linearId = fill.replace("(", "");
                                        linearId = linearId.replace("#", "");
                                        linearId = linearId.replace(")", "");
                                        linearId = linearId.replace("url", "");
                                        var stops = $("#" + linearId + ">stop");
                                        if (stops != undefined) {
                                            stops[0].setAttribute("style", "stop-color:" + changcolor + ";");
                                            if (stops.length == 3) {
                                                stops[2].setAttribute("style", "stop-color:" + changcolor + ";")
                                            }

                                        }
                                    }
                                    else {
                                        shapeg[0].children[i].childNodes[j].setAttribute("fill", changcolor);

                                    }

                                }
                                if (fv == true) {

                                    var fill = shapeg[0].children[i].childNodes[j].getAttribute("fill");
                                    if (fill.indexOf("(") >= 0)//表示渐进填充
                                    {
                                        var linearId = fill.replace("(", "");
                                        linearId = linearId.replace("#", "");
                                        linearId = linearId.replace(")", "");
                                        linearId = linearId.replace("url", "");
                                        var stops = $("#" + linearId + ">stop");
                                        if (stops != undefined) {
                                            stops[0].setAttribute("style", "stop-color:" + sourcecolor + ";");
                                            if (stops.length == 3) {
                                                stops[2].setAttribute("style", "stop-color:" + sourcecolor + ";")
                                            }

                                        }
                                    }
                                    else {
                                        shapeg[0].children[i].childNodes[j].setAttribute("fill", sourcecolor);

                                    }
                                }
                            }
                        }
                        else {

                            var fill = shapeg[0].children[i].getAttribute("fill");
                            if (fill == "none")
                                continue;
                            if (tv == true) {


                                if (fill.indexOf("(") >= 0)//表示渐进填充
                                {
                                    var linearId = fill.replace("(", "");
                                    linearId = linearId.replace("#", "");
                                    linearId = linearId.replace(")", "");
                                    linearId = linearId.replace("url", "");
                                    var stops = $("#" + linearId + ">stop");
                                    if (stops != undefined) {
                                        stops[0].setAttribute("style", "stop-color:" + changcolor + ";");
                                        if (stops.length == 3) {
                                            stops[2].setAttribute("style", "stop-color:" + changcolor + ";")
                                        }

                                    }
                                }
                                else {
                                    shapeg[0].children[i].setAttribute("fill", changcolor);

                                }

                            }
                            if (fv == true) {

                                var fill = shapeg[0].children[i].getAttribute("fill");
                                if (fill.indexOf("(") >= 0)//表示渐进填充
                                {
                                    var linearId = fill.replace("(", "");
                                    linearId = linearId.replace("#", "");
                                    linearId = linearId.replace(")", "");
                                    linearId = linearId.replace("url", "");
                                    var stops = $("#" + linearId + ">stop");
                                    if (stops != undefined) {
                                        stops[0].setAttribute("style", "stop-color:" + sourcecolor + ";");
                                        if (stops.length == 3) {
                                            stops[2].setAttribute("style", "stop-color:" + sourcecolor + ";")
                                        }

                                    }
                                }
                                else {
                                    shapeg[0].children[i].setAttribute("fill", sourcecolor);

                                }
                            }
                        }


                    }
                }
                else {
                    var fill = shapeg[0].children[i].getAttribute("fill");
                    if (fill == "none")
                        return;
                    if (tv == true) {


                        if (fill.indexOf("(") >= 0)//表示渐进填充
                        {
                            var linearId = fill.replace("(", "");
                            linearId = linearId.replace("#", "");
                            linearId = linearId.replace(")", "");
                            linearId = linearId.replace("url", "");
                            var stops = $("#" + linearId + ">stop");
                            if (stops != undefined) {
                                stops[0].setAttribute("style", "stop-color:" + changcolor + ";");
                                if (stops.length == 3) {
                                    stops[2].setAttribute("style", "stop-color:" + changcolor + ";")
                                }

                            }
                        }
                        else {
                            shapeg[0].setAttribute("fill", changcolor);

                        }

                    }
                    if (fv == true) {

                        var fill = shapeg[0].getAttribute("fill");
                        if (fill.indexOf("(") >= 0)//表示渐进填充
                        {
                            var linearId = fill.replace("(", "");
                            linearId = linearId.replace("#", "");
                            linearId = linearId.replace(")", "");
                            linearId = linearId.replace("url", "");
                            var stops = $("#" + linearId + ">stop");
                            if (stops != undefined) {
                                stops[0].setAttribute("style", "stop-color:" + sourcecolor + ";");
                                if (stops.length == 3) {
                                    stops[2].setAttribute("style", "stop-color:" + sourcecolor + ";")
                                }

                            }
                        }
                        else {
                            shapeg[0].setAttribute("fill", sourcecolor);

                        }
                    }
                }
            }
            else if (shapetype == "SVG_StaticShape")//重新设置静态图元的颜色
            {
                for (var i = 0; i < shapeg[0].children.length; i++) {
                    var fill = shapeg[0].children[i].getAttribute("fill");
                    if (fill == "none")
                        continue;
                    var originalfill = shapeg[0].children[i].getAttribute("data-originalfill");//每个子项的原始颜色
                    if (tv == true) {

                        if (originalfill != undefined) {
                            shapeg[0].children[i].setAttribute("fill", changcolor);
                        }


                    }
                    if (fv == true) {


                        if (originalfill != undefined) {
                            shapeg[0].children[i].setAttribute("fill", originalfill);
                        }

                    }



                }
            }

        }
    }
    //更新高德地图上的实时数据
    this.UpdateMap = function (ServerID, CommunicateID, DeviceID, ParaID, value, time, status, datatype, marker) {
        if (value == undefined || value == -9999 || value == "")
            return;

        var extData = marker.getExtData();
        if (extData == undefined || extData == null)
            return;
        if (extData.id == undefined || extData.mapid == undefined)
            return;
        //实时值 trueexpression:'',falseexpression
        if (extData.iovalue != undefined && extData.iovalue != null && extData.iovalue.SERVER_ID == ServerID && extData.iovalue.IO_COMM_ID == CommunicateID && extData.iovalue.IO_DEVICE_ID == DeviceID && extData.iovalue.IO_ID == ParaID) {
            //不同的实时值显示方式也不一样
            if (extData.enableiovalue != undefined) {
                var markertype = extData.markertype;
                if (markertype != undefined && markertype != null && value != "-9999") {
                    //不同的标记变化方式不一样
                    extData.value = value;
                    extData.unit = extData.iovalue.Unit;
                    marker.setExtData(extData);
                    var currentValue = value;
                    switch (markertype) {

                        case "text":
                            {
                                marker.setText(value + " " + extData.iovalue.Unit);
                            }
                            break;

                            break;
                        case "point":
                            {
                                var markerContent = '<img class="markerlnglat" src="' + marker.getIcon() + '"/><span style="' + extData.fontstyle + '">' + value + ' ' + extData.iovalue.Unit + '</span>';

                                marker.setContent(markerContent);
                            }
                            break;
                        case "circle":
                            {
                                //计算半径
                                var minrange = parseFloat(extData.minrange);
                                var maxrange = parseFloat(extData.maxrange);
                                var curr = parseFloat(value);
                                var maxpx = 64;
                                var currradious = curr / (maxrange - minrange) * 64;
                                if (currradious < 0)
                                    currradious = 0;
                                if (currradious > 64)
                                    currradious = 64;
                                marker.setRadius(currradious);

                            }
                            break;
                    }

                }

            }


        }
        //IO变化
        if (extData.iocolor != undefined && extData.iocolor != null && extData.iocolor.SERVER_ID == ServerID && extData.iocolor.IO_COMM_ID == CommunicateID && extData.iocolor.IO_DEVICE_ID == DeviceID && extData.iocolor.IO_ID == ParaID) {
            var markertype = extData.markertype;
            if (markertype != undefined && markertype != null && value != "-9999") {
                //不同的标记变化方式不一样
                var trueexpression = extData.iocolor.trueexpression;
                var trueop = trueexpression.split(":")[0];
                var truevalue = parseFloat(trueexpression.split(":")[1]);
                var falseexpression = extData.iocolor.falseexpression;
                var falseop = falseexpression.split(":")[0];
                var falsevalue = parseFloat(falseexpression.split(":")[1]);
                var tv = analysisOpeartor(trueop, truevalue, value);
                var fv = analysisOpeartor(falseop, falsevalue, value);

                var currentValue = value;
                switch (markertype) {

                    case "text":
                        {
                            var truetextcolor = extData.truetextcolor;
                            var falsetextcolor = extData.falsetextcolor;
                            if (tv == true) {
                                marker.setStyle({ 'color': truetextcolor });
                            }

                            if (fv == true) {
                                marker.setStyle({ 'color': falsetextcolor });
                            }
                        }
                        break;
                    case "point":
                        {
                            var trueimage = extData.trueimage;
                            var falseimage = extData.falseimage;
                            if (tv == true) {

                                marker.setIcon(trueimage);
                            }

                            if (fv == true) {

                                marker.setIcon(falseimage);
                            }
                            var markerContent = ' <img class="markerlnglat" src="' + marker.getIcon() + '"/><span style="' + extData.fontstyle + '">' + extData.value + ' ' + extData.unit + '</span>';

                            marker.setContent(markerContent);
                        }
                        break;

                    case "circle":
                        {
                            var truefillcolor = extData.truefillcolor;
                            var falsefillcolor = extData.falsefillcolor;
                            if (tv == true) {

                                marker.setOptions({ fillColor: truefillcolor });
                            }

                            if (fv == true) {

                                marker.setOptions({ fillColor: falsefillcolor });
                            }
                        }
                        break;
                }

            }

        }
        //IO隐藏
        if (extData.iovisible != undefined && extData.iovisible != null && extData.iovisible.SERVER_ID == ServerID && extData.iovisible.IO_COMM_ID == CommunicateID && extData.iovisible.IO_DEVICE_ID == DeviceID && extData.iovisible.IO_ID == ParaID) {
            var trueexpression = extData.iovisible.trueexpression;
            var trueop = trueexpression.split(":")[0];
            var truevalue = parseFloat(trueexpression.split(":")[1]);
            var falseexpression = extData.iovisible.falseexpression;
            var falseop = falseexpression.split(":")[0];
            var falsevalue = parseFloat(falseexpression.split(":")[1]);
            var tv = analysisOpeartor(trueop, truevalue, value);
            var fv = analysisOpeartor(falseop, falsevalue, value);
            if (tv == true) {
                marker.show();
            }

            if (fv == true) {
                marker.hide();
            }
        }
    }
    ///用户事件服务
    this.OnEventService = function () {
        var that = event.currentTarget;
        var shapeId = event.currentTarget.id;

        layui.use(["form", "okUtils", "okLayer", 'layer'], function () {
            let $ = layui.$;
            var shape = $("#" + shapeId);
            var event_servicetype = shape.data('event_servicetype');
            var event_title = shape.data('event_title');
            var event_confirm = shape.data('event_confirm');
            var event_msg = shape.data('event_msg');

            let okLayer = layui.okLayer;
            let layer = layui.layer;
            let okUtils = layui.okUtils;
            function LoadService(dagindex) {
                switch (event_servicetype) {
                    case "链接服务":
                        {
                            var index = layer.open({
                                type: 2,
                                title: event_title,
                                shadeClose: true,
                                shade: false,
                                id: 'LAY_layuipro', //设定一个id，防止重复弹出
                                zIndex: layer.zIndex, //重点1
                                maxmin: true, //开启最大化最小化按钮
                                area: ['400px', '250px'],
                                content: shape.data('event_url')
                            });
                            layer.full(index);

                        }
                        break;
                    case "打开视图服务":
                        {
                            var event_opendtype = shape.data('event_opendtype');
                            if (event_opendtype == "弹出窗体") {
                                var index = layer.open({
                                    type: 2,
                                    title: event_title,
                                    shadeClose: true,
                                    shade: false,
                                    id: 'LAY_layuipro', //设定一个id，防止重复弹出
                                    zIndex: layer.zIndex, //重点1
                                    maxmin: true, //开启最大化最小化按钮
                                    area: [shape.data('event_dialogwidth') + 'px', shape.data('event_dialogheight') + 'px'],
                                    content: "/Scada/ScadaFlow?id=0&vid=" + shape.data('event_viewid')
                                });

                            } else if (event_opendtype == "本视图转目标视图") {
                                location.href = "/Scada/ScadaFlow?id=0&vid=" + shape.data('event_viewid');
                            }



                        }
                        break;
                    case "隐藏显示服务":
                        {
                            var shows = shape.data('event_shows');
                            var hiddens = shape.data('event_hiddens');
                            for (var i = 0; i < shows.split(",").length; i++) {
                                var shapeid = shows.split(",")[i];
                                $("#shape" + shapeid).css("display", "block");
                                $("#shape" + shapeid).show();
                            }
                            for (var i = 0; i < hiddens.split(",").length; i++) {
                                var shapeid = hiddens.split(",")[i];
                                $("#shape" + shapeid).css("display", "none");
                                $("#shape" + shapeid).hide();
                            }
                        }
                        break;
                    case "下置命令服务":
                        {
                            var writevalue = shape.data('event_writevalue');
                            var event_valuetype = shape.data('event_valuetype');
                            var event_msg = shape.data('event_msg');
                            var event_successresult = shape.data('event_successresult');
                            var event_faultresult = shape.data('event_faultresult');
                            var event_returnresult = shape.data('event_returnresult');
                            var event_io = shape.data('event_io');
                            var event_return_io = shape.data('event_return_io');
                            var event_timeout = shape.data('event_timeout');
                            var cmd = {
                                writevalue: writevalue,
                                valuetype: event_valuetype,
                                msg: event_msg,
                                successresult: event_successresult,
                                faultresult: event_faultresult,
                                returnresult: event_returnresult,
                                io: event_io,
                                return_io: event_return_io,
                                timeout: event_timeout


                            };
                            if (event_valuetype == "模拟量") {
                                var index = layer.open({
                                    type: 1,
                                    title: event_title,
                                    btn: ['确定', '关闭'],
                                    shadeClose: true,
                                    shade: false,
                                    id: 'LAY_layuipro', //设定一个id，防止重复弹出
                                    zIndex: layer.zIndex, //重点1
                                    maxmin: true, //开启最大化最小化按钮
                                    area: ['400px', '250px'],
                                    success: function (layero) {
                                        var btn = layero.find('.layui-layer-btn');
                                        btn.find('.layui-layer-btn0').on('click', function () {
                                            cmd.writevalue = $('#cmd_write').val();
                                            SCADA.SendCommand(cmd, layero);
                                            layer.close(index);
                                        });


                                    },
                                    content: "<div id='container' class='ok-body'>"
                                               + "       <div class='layui-form-item' >"
                                                  + "     <label class='layui-form-label'>命令下置</label>"
                                                   + "     <div class='layui-input-block'>"
                                                   + "    <input type='text' id='cmd_write' name='cmd_write' placeholder='下置值' autocomplete='off' class='layui-input' lay-verify='required' value='" + writevalue + "'>"
                                                   + "      </div>"
                                                  + "     </div>"
                                                 + "   <div class='layui-form-item'>"
                                            + "   <div class='layui-input-block'>"

                                    + "    </div>"
                                  + "    </div>"

                                + "     </div>"
                                });
                            }
                            else if (event_valuetype == "布尔值") {
                                //布尔值量直接下置该命令
                                var index = layer.open({
                                    type: 1,
                                    title: event_title,
                                    btn: ['确定', '关闭'],
                                    shadeClose: true,
                                    shade: false,
                                    id: 'LAY_layuipro', //设定一个id，防止重复弹出
                                    zIndex: layer.zIndex, //重点1
                                    maxmin: true, //开启最大化最小化按钮
                                    area: ['400px', '250px'],
                                    success: function (layero) {
                                        var btn = layero.find('.layui-layer-btn');
                                        btn.find('.layui-layer-btn0').on('click', function () {
                                            cmd.writevalue = $("input[name='cmd_switch']:checked").val();
                                            SCADA.SendCommand(cmd, layero);
                                            layer.close(index);
                                        });
                                    
                                    },
                                    content: "<div id='container' class='ok-body'>"
                                        + "       <div class='layui-form-item' >"
                                        + "     <label class='layui-form-label'>命令下置</label>"
                                        + "     <div class='layui-input-block'>"
                                        + "      <input type='radio' name='cmd_switch' value='0' title='关[0]' checked>   < input type='radio' name='cmd_switch'    value='1' title='开[1]' >  "
                                        + "      </div>"
                                        + "     </div>"
                                        + "   <div class='layui-form-item'>"
                                        + "   <div class='layui-input-block'>"

                                        + "    </div>"
                                        + "    </div>"

                                        + "     </div>"
                                });
                            }

                        }

                        break;
                    case "无":
                        break;
                }

                if (dagindex >= 0)
                    layer.close(dagindex);

            }
            function EventExcute() {
                if (event_confirm == "true" || event_confirm == "True") {
                    layer.confirm(event_msg, function (index) {

                        LoadService(index)

                    });

                }
                else {
                    LoadService(-1);
                }
            }
            //执行程序
            EventExcute();


        });
    }
 
    this.InitTreeView = function () {
        //处理并获取所有的树
        var trees = $("g[data-shape='SVG_TreeViewShape']");
        if (trees == undefined || trees.length <= 0)
            return;
        for (var i = 0; i < trees.length; i++) {
            try {
                var treeView = trees[i];
                var shapeId = trees[i].id.replace("shape","");
                SCADA.RefreshTreeView(shapeId,"");
            }
            catch(e){
                continue;
            }

        }

    }
 
    this.RefreshTreeView = function (shapeid) {

        //获取所有节点
        var tree = $("#shape" + shapeid);
        var nodes = $("#shape" + shapeid).find($("g[data-filter='treenode']"));
        if (nodes == undefined || nodes.length <= 0)
            return;
        //保存展开的节点
        var expandnodes=[];
        //重新计算每个节点的
        for (var n = 0; n < nodes.length; n++) {
            var nodeId = nodes[n].id;
            //是否展开节点
            var expand = $("#" + nodeId).data("expand");
            //当前拥有的节点数量
            var childnum = parseInt($("#" + nodeId).data("childnum"));
            //父节点ID
            var parentid = $("#" + nodeId).data("parentid");
          
            //父节点对象
            var parentnode = null;
            if (parentid != undefined && parentid != "") {
                parentnode = $("#shape" + parentid);
            }
            if (expand.toString() == "true") {
                expandnodes.push(nodes[n]);
                $("#" + nodeId).show();
            }
            else {
                if (childnum > 0 && (parentnode == null || parentnode.data("expand").toString() == "true")) {
                    expandnodes.push(nodes[n]);
                    $("#" + nodeId).show();
                }
                else {
                    $("#" + nodeId).hide();
                }
            }
        }

        //循环计算要展开的节点
 
        for (var n = 0; n < expandnodes.length; n++) {
            var nodeId = expandnodes[n].id;
            var thisnode = $("#" + nodeId);
            ///获取区域
            var rectStr = $("#" + nodeId).data("rect");
            var position = { X: parseFloat(rectStr.split(",")[0]), Y: parseFloat(rectStr.split(",")[1]), Width: parseFloat(rectStr.split(",")[2]), Height: parseFloat(rectStr.split(",")[3]) };
            var textsize = { Width: parseFloat(rectStr.split(",")[2]), Height: parseFloat(rectStr.split(",")[3]) }
            //获取icon大小
            var iconStr = $("#" + nodeId).data("iconsize");
            var iconsize = { Width: parseFloat(iconStr.split(",")[0]), Height: parseFloat(iconStr.split(",")[1]) }
            //获取叠加符号的大小
            var symbolsizeStr = $("#" + nodeId).data("symbolsize");
            var symbolsizesize = { Width: parseFloat(symbolsizeStr.split(",")[0]), Height: parseFloat(symbolsizeStr.split(",")[1]) }
            //树左上角位置
            var localx = $("#" + nodeId).data("localx");
            var localy = $("#" + nodeId).data("localy");
            var local = { X: parseFloat(localx), Y: parseFloat(localy) };
            //是否展开节点
            var expand = $("#" + nodeId).data("expand");
            //当前拥有的节点数量
            var childnum = parseInt($("#" + nodeId).data("childnum"));
            //获取缩进距离
            var nodeindent = parseFloat($("#" + nodeId).data("nodeindent"));
            //两个节点之间的间距
            var nodespace = parseFloat($("#" + nodeId).data("nodespace"));
            //父节点ID
            var parentid = $("#" + nodeId).data("parentid");
            //父节点对象
            var parentnode = null;
            var parentposition = null;
            if (parentid != undefined && parentid != "") {
                parentnode = $("#shape" + parentid);
                var parentRectStr = $("#shape" + parentid).data("rect");
                parentposition = { X: parseFloat(parentRectStr.split(",")[0]), Y: parseFloat(parentRectStr.split(",")[1]), Width: parseFloat(parentRectStr.split(",")[2]), Height: parseFloat(parentRectStr.split(",")[3]) };
            }
            //整个树水平距离容器的边距
            var hmargin = parseFloat($("#" + nodeId).data("hmargin"));
            //整个树纵向距离容器的边距
            var vmargin = parseFloat($("#" + nodeId).data("vmargin"));
            //是否显示连接线
            var showline = $("#" + nodeId).data("showline");
            //获取节点等级
            var level = parseInt($("#" + nodeId).data("level"));
            // 是否显示图标   
            var showicon = $("#" + nodeId).data("showicon");
            //节点颜色
            var textcolor = $("#" + nodeId).data("textcolor");
            var previewY = parseFloat(local.Y);
      
            if (n == 0) {
                previewY = local.Y + vmargin;
            }
            else {
                var previewrectStr = $("#" + expandnodes[n - 1].id).data("rect");
                var previewposition = { X: parseFloat(previewrectStr.split(",")[0]), Y: parseFloat(previewrectStr.split(",")[1]), Width: parseFloat(previewrectStr.split(",")[2]), Height: parseFloat(previewrectStr.split(",")[3]) };
                previewY = previewposition.Y + previewposition.Height;
            }
            //计算重新节点的坐标
            var newposition = SCADA.CalcTreeNodePosition(previewY, position.X, textsize,nodespace);
            //设置节点的实际计算区域
            $("#" + nodeId).data("rect", newposition.X + "," + newposition.Y + "," + newposition.Width + "," + newposition.Height);
            $("#" + nodeId).attr("x", newposition.X);
            $("#" + nodeId).attr("y", newposition.Y);
            $("#" + nodeId).attr("width", newposition.Width);
            $("#" + nodeId).attr("height", newposition.Height);
            var linwidth = 3;
            //处理连接线
            if (showline.toString()=="true") {
                var vlines =$("#" + nodeId+">g[data-filter='vline']>line");//获取所有垂直连线
                var hline = $("#" + nodeId + ">g[data-filter='hline']>line")[0];//获取所有水平线直连线,水平线只有一条
                //绘制横向线
                if (parentnode == undefined || parentnode == null) {
                  
                    var pv1 = { X: newposition.X, Y: newposition.Y + newposition.Height / 2 - linwidth / 2 };
                    var pv2 = { X: newposition.X - 15, Y: newposition.Y + newposition.Height / 2 - linwidth / 2 };
                    $("#" + hline.id).attr("x1", pv1.X);
                    $("#" + hline.id).attr("y1", pv1.Y);
                    $("#" + hline.id).attr("x2", pv2.X);
                    $("#" + hline.id).attr("y2", pv2.Y);
                }
                else {
                    var pv1 = { X: newposition.X, Y: newposition.Y + newposition.Height / 2 - linwidth / 2 };
                    var pv2 = { X: parentposition.X, Y: newposition.Y + newposition.Height / 2 - linwidth / 2 };
                    $("#" + hline.id).attr("x1", pv1.X);
                    $("#" + hline.id).attr("y1", pv1.Y);
                    $("#" + hline.id).attr("x2", pv2.X);
                    $("#" + hline.id).attr("y2", pv2.Y);
                }
                //绘制纵向线
                for (var i = 0; i <=level; i++)
                {
                    if (parentnode != undefined && parentnode != null) {
                        var pv1 = { X: parentposition.X, Y: parentposition.Y + parentposition.Height / 2 };
                        var pv2 = { X: parentposition.X, Y: newposition.Y + newposition.Height / 2};
  
                        $("#" + vlines[i].id).attr("x1", pv1.X);
                        $("#" + vlines[i].id).attr("y1", pv1.Y);
                        $("#" + vlines[i].id).attr("x2", pv2.X);
                        $("#" + vlines[i].id).attr("y2", pv2.Y);
                    }
                    else {

                        var startRect = $("#" + expandnodes[0].id).data("rect");  
                        var startposition = { X: parseFloat(startRect.split(",")[0]), Y: parseFloat(startRect.split(",")[1]), Width: parseFloat(startRect.split(",")[2]), Height: parseFloat(startRect.split(",")[3]) };
                        var pv1 = { X: startposition.X - 15, Y: startposition.Y + startposition.Height / 2 };
                        var pv2 = { X: startposition.X - 15, Y: newposition.Y + newposition.Height / 2 - linwidth/2};
                        $("#" + vlines[i].id).attr("x1", pv1.X);
                        $("#" + vlines[i].id).attr("y1", pv1.Y);
                        $("#" + vlines[i].id).attr("x2", pv2.X);
                        $("#" + vlines[i].id).attr("y2", pv2.Y);
                    }
                }

            }
            //获取并设置背景对象
            var nodeback = $("#" + nodeId +">g[data-filter='nodebackground']>rect")[0];
            if (nodeback != undefined && nodeback != null) {
                $("#" + nodeback.id).attr("x", newposition.X);
                $("#" + nodeback.id).attr("y", newposition.Y);
                $("#" + nodeback.id).attr("width", newposition.Width);
                $("#" + nodeback.id).attr("height", newposition.Height);
            }
            //获取节点文本对象
            var treenodetext = $("#" + nodeId + ">g[data-filter='text']>a>text")[0];
            if (treenodetext != undefined && treenodetext != null) {
                $("#" + treenodetext.id).attr("x", newposition.X + newposition.Width / 2);
                $("#" + treenodetext.id).attr("y", newposition.Y + newposition.Height / 2);
              
            }
            //获取叠加和展开的符号对象
            var treesymbol = $("#" + nodeId + ">g[data-filter='expandsymbol']>a>text")[0];
            if (treesymbol != undefined && treesymbol != null) {
                $("#" + treesymbol.id).attr("x", newposition.X );
                $("#" + treesymbol.id).attr("y", newposition.Y + newposition.Height / 2);
                if (expand.toString() == "true") {
                    $("#" + treesymbol.id).html("-");
                    $("#" + treesymbol.id).val("-");
                }
                else {
                    $("#" + treesymbol.id).html("+");
                    $("#" + treesymbol.id).val("+");
                }
            }
            //显示要展开的节点
            $("#" + nodeId).show();
        }
    }
    this.CalcTreeNodePosition = function (previewY, oldx, nodeSize, space) {
            var position = { X: 0, Y: 0, Width: 0, Height: 0 };
            position.X = oldx;
            position.Width = nodeSize.Width;
            position.Height = nodeSize.Height;
            position.Y = previewY + space;
        return position;
    }
    //处理树节点展开和折叠状态
    this.TreeNodeExpand = function (expand, nodeid, shapeid) {
        try {
            var node = $("#shape" + nodeid);
            if (node != undefined && node != null) {
                if (node.data("expand").toString()=="true")
                    expand = "false";
                else
                    expand = "true";
                node.data("expand", expand);
                
                SCADA.TreeNodeExpandCycle(expand, nodeid, shapeid);
                SCADA.RefreshTreeView(shapeid);
            }
        }
        catch(e){

        }
      
    }
    this.TreeNodeExpandCycle = function (expand, parentid, shapeid)
    {
        var nodes = $("#shape" + shapeid).find($("g[data-parentid='" + parentid.replace("shape","") + "']"));
        for (var n = 0; n < nodes.length; n++) {
            var thisnode = $("#" + nodes[n].id);
            if (thisnode != undefined && thisnode != null) {
                thisnode.data("expand", expand);
                SCADA.TreeNodeExpandCycle(expand, nodes[n].id , shapeid);
            }
        }
    }
    this.TreeNodeSelect = function (selectNodeId, shapeid) {
        var tree = $("#shape" + shapeid);
        var nodes = $("#shape" + shapeid).find($("g[data-filter='treenode']"));
        if (nodes == undefined || nodes.length <= 0)
            return;

        //重新计算每个节点的
        for (var n = 0; n < nodes.length; n++) {
            var nodeId = nodes[n].id;
            var textcolor = $("#" + nodeId).data("textcolor");
            //获取节点文本对象
            var treenodetext = $("#" + nodeId + ">g[data-filter='text']>a>text")[0];
            if (treenodetext != undefined && treenodetext != null) {
                $("#" + treenodetext.id).attr("fill", textcolor);
                if ("shape" + selectNodeId == nodes[n].id) {
                    $("#" + treenodetext.id).attr("fill", "#FF0000");
                }
            }

           
           
        }
        

    }
    this.SendCommand = function (cmd, layindex) {
        if (layindex >= 0) {
            layer.close(layindex);
        }
        $.post("/Scada/ScadaDialog/SendCommand", cmd, function (result) {
            if (result.result) {
                var msgindex = layer.open({
                    type: 1
                   , id: 'layerok' //防止重复弹出
                   , content: '<div style="padding: 20px 100px;">' + result.msg + '</div>'
                   , btn: '确定'
                   , btnAlign: 'c' //按钮居中
                   , shade: 0 //不显示遮罩
                  , yes: function () {

                      layer.closeAll();

                  }
                });
            }
        });
    }
 
    ///实时读取和刷新流程图数据
    this.ScadaFlow = function () {
    
        //设置图形显示模式
        adjustToFreezeAll(document.getElementById('scada_svg'));
        window.onload = function () {
            window.zoomTiger = svgPanZoom('#scada_svg',
                {
                 zoomEnabled: false,
                 controlIconsEnabled: false,
                 fit: true,
                 center: true,
                 dblClickZoomEnabled: false

             });

        }
        $('#container').height($(window).height());
        //初始化相关树结构菜单
        try {
            SCADA.InitTreeView();
        } catch(e){}
        //第一次实时读取IO值
        try {
            SCADA.ReadFlowRealData();
        } catch(e){ }

       //设置定时器实时读取数据
        try {
            $('body').everyTime(SCADA.UpdateFlowUpcycle + "s", function () {
                SCADA.ReadFlowRealData();
            });
        } catch(e){ }
    }
    //当前流程图的登录用户
    this.FlowLoginUser = {};
    //当前流程图的所有用户
    this.FlowUsers = [];
    var isUsed = false;
    //读取IO参数的实时数据
    this.ReadFlowRealData = function () {


        if (isUsed)
            return;

        isUsed = true;
        //实时更新svg配置图形
        var ioelements = document.querySelectorAll('[data-iovalue]');
        var visibleelements = document.querySelectorAll('[data-iovisible]');
        var changeements = document.querySelectorAll('[data-iochange]');
        //由于高德地图数据比较特殊，此处需要单独对地图类的实时显示进行单独设置
        var mapelements = document.querySelectorAll("[data-shape='SVG_MapShape']");

           //根据用户权限进行判断，如果不包含该用户，则不显示此模块
        var ioroles = document.querySelectorAll('[data-role]');
        if (this.FlowLoginUser != undefined && this.FlowLoginUser != null) {


            for (var i = 0; i < ioroles.length; i++) {
                var role = ioroles[i].getAttribute("data-role");
                if (role != undefined && role.trim() != "") {
                    var users = role.split(",");
                    if (users.indexOf(this.FlowLoginUser.username) >= 0) {
                        $("#" + ioroles[i].id).show();
                        $("#" + ioroles[i].id).show();
                        ioroles[i].setAttribute("style", "display:block;");
                        ioroles[i].setAttribute("visibility", "visible");
                        $("#" + ioroles[i].id).attr("visibility", "visible");
                        $("#" + ioroles[i].id).attr("style", "display:block;");
                      
                    }

                    else {
                        $("#" + ioroles[i].id).hide();
                        ioroles[i].setAttribute("style", "display:none;");
                        ioroles[i].setAttribute("visibility", "hidden");
                        $("#" + ioroles[i].id).attr("visibility", "hidden");
                        $("#" + ioroles[i].id).attr("style", "display:none;");
                    }
                }
            }
        }
        var IoParas = [];
        try {
            for (var i = 0; i < ioelements.length; i++) {
                

                var parastr = ioelements[i].getAttribute("data-iovalue");
                if (parastr != undefined && parastr.trim() != "") {
                    IoParas.push({ ServerID: parastr.split(',')[0], CommunicateID: parastr.split(',')[1], DeviceID: parastr.split(',')[2], ParaID: parastr.split(',')[3], DataType: parastr.split(',')[4], Format: parastr.split(',')[5], Unit: parastr.split(',')[6], UpdateCycle: parastr.split(',')[7], IoName: parastr.split(',')[8], Value: '', DateTime: '', Status: 0, QualityStamp: 'BAD' });
                }

            }
            for (var i = 0; i < visibleelements.length; i++) {
                var parastr = visibleelements[i].getAttribute("data-iovisible");
                if (parastr != undefined && parastr.trim() != "") {
                    IoParas.push({ ServerID: parastr.split(',')[0], CommunicateID: parastr.split(',')[1], DeviceID: parastr.split(',')[2], ParaID: parastr.split(',')[3], DataType: parastr.split(',')[4], Format: parastr.split(',')[5], Unit: parastr.split(',')[6], UpdateCycle: parastr.split(',')[7], IoName: parastr.split(',')[8], Value: '', DateTime: '', Status: 0, QualityStamp: 'BAD' });
                }

            }
            for (var i = 0; i < changeements.length; i++) {
                var parastr = changeements[i].getAttribute("data-iochange");
                if (parastr != undefined && parastr.trim() != "") {
                    IoParas.push({ ServerID: parastr.split(',')[0], CommunicateID: parastr.split(',')[1], DeviceID: parastr.split(',')[2], ParaID: parastr.split(',')[3], DataType: parastr.split(',')[4], Format: parastr.split(',')[5], Unit: parastr.split(',')[6], UpdateCycle: parastr.split(',')[7], IoName: parastr.split(',')[8], Value: '', DateTime: '', Status: 0, QualityStamp: 'BAD' });
                }

            }
            for (var i = 0; i < Marks.length; i++) {
                if (Marks[i] == undefined || Marks[i] == null)
                    continue;
                var extData = Marks[i].getExtData();
                if (extData != undefined && extData != null) {
                    if (extData.id != undefined && extData.mapid != undefined) {
                        var markid = extData.id;
                        var mapid = extData.mapid;//获取地图ID
                        if (extData.iovalue != undefined && extData.iovalue != null)
                            IoParas.push({ ServerID: extData.iovalue.SERVER_ID, CommunicateID: extData.iovalue.IO_COMM_ID, DeviceID: extData.iovalue.IO_DEVICE_ID, ParaID: extData.iovalue.IO_ID, DataType: extData.iovalue.DataType, Format: extData.iovalue.Format, Unit: extData.iovalue.Unit, UpdateCycle: extData.iovalue.UpdateCycle, IoName: extData.iovalue.IoName, Value: '', DateTime: '', Status: 0, QualityStamp: 'BAD' });

                        if (extData.iovisible != undefined && extData.iovisible != null)
                            IoParas.push({ ServerID: extData.iovisible.SERVER_ID, CommunicateID: extData.iovisible.IO_COMM_ID, DeviceID: extData.iovisible.IO_DEVICE_ID, ParaID: extData.iovisible.IO_ID, DataType: extData.iovisible.DataType, Format: extData.iovisible.Format, Unit: extData.iovisible.Unit, UpdateCycle: extData.iovisible.UpdateCycle, IoName: extData.iovisible.IoName, Value: '', DateTime: '', Status: 0, QualityStamp: 'BAD' });

                        if (extData.iocolor != undefined && extData.iocolor != null)
                            IoParas.push({ ServerID: extData.iocolor.SERVER_ID, CommunicateID: extData.iocolor.IO_COMM_ID, DeviceID: extData.iocolor.IO_DEVICE_ID, ParaID: extData.iocolor.IO_ID, DataType: extData.iocolor.DataType, Format: extData.iocolor.Format, Unit: extData.iocolor.Unit, UpdateCycle: extData.iocolor.UpdateCycle, IoName: extData.iocolor.IoName, Value: '', DateTime: '', Status: 0, QualityStamp: 'BAD' });
                    }

                }
            }
        }
        catch(e) {
            return;
        }


        try {
            //获取实时数据
            $.post("/Scada/ScadaFlow/GetReadData", {IoParas},function (result) {
                //code = 0, msg = "", count = total, data = list
                for (var i = 0; i < result.data.length; i++) {
                    try {


                        var valueeles = document.querySelectorAll("[data-iovalue='" +result.data[i].IOStr + "']");
                        if (valueeles != undefined) {
                            for (var n = 0; n < valueeles.length; n++) {
                                var datatype = "Value"
                                var parastr = valueeles[n].getAttribute("data-iovalue");
                                if (parastr == undefined || parastr == null || parastr == "") {
                                    datatype = "Value";
            }
            else {
                                    datatype = parastr.split(",")[4];
            }
                                SCADA.UpdateFlowValue(result.data[i].Value, result.data[i].DateTime, result.data[i].Status, datatype, valueeles[n].id.replace("shape", ""));
            }

            }
                        var visibleeles = document.querySelectorAll("[data-iovisible='" +result.data[i].IOStr + "']");
                        if (visibleeles != undefined) {
                            for (var n = 0; n < visibleeles.length; n++) {
                                var datatype = "Value"
                                var parastr = visibleeles[n].getAttribute("data-iovisible");
                                if (parastr == undefined || parastr == null || parastr == "") {
                                    datatype = "Value";
            }
            else {
                                    datatype = parastr.split(",")[4];
            }

                                SCADA.UpdateVisible(result.data[i].Value, result.data[i].DateTime, result.data[i].Status, datatype, visibleeles[n].id.replace("shape", ""));
            }

            }
                        var changeeles = document.querySelectorAll("[data-iochange='" +result.data[i].IOStr + "']");
                        if (changeeles != undefined) {
                            for (var n = 0; n < changeeles.length; n++) {
                                var datatype = "Value"
                                var parastr = changeeles[n].getAttribute("data-iochange");
                                if (parastr == undefined || parastr == null || parastr == "") {
                                    datatype = "Value";
            }
            else {
                                    datatype = parastr.split(",")[4];
            }
                                SCADA.UpdateColorChanged(result.data[i].Value, result.data[i].DateTime, result.data[i].Status, datatype, changeeles[n].id.replace("shape", ""));
            }

            }
                        //刷新高德地图的值
                        for (var n = 0; n < Marks.length; n++) {
                            if (Marks[n]== undefined || Marks[n]== null)
                                continue;
                            var extData = Marks[n].getExtData();
                            if (extData != undefined && extData != null) {
                                if (extData.id != undefined && extData.mapid != undefined) {
                                    var markid = extData.id;
                                    var mapid = extData.mapid;//获取地图ID
                                    //刷新高德地图
                                    //解析返回的数据符合当前要求
                                    //服务器端返回的数据格式 
                                    // ServerID + "," + CommunicateID + "," + DeviceID + "," + ParaID + "," + DataType + "," + Format + "," + Unit + "," + UpdateCycle + "," + IoName;
                                    var restr = result.data[i].IOStr;
                                    var datatype = "Value"

                                    if (restr == undefined || restr == null || restr == "") {
                                        datatype = "Value";
                                    }
                                    else {
                                        datatype = restr.split(",")[4];
                                    }
                                    SCADA.UpdateMap(result.data[i].ServerID, result.data[i].CommunicateID, result.data[i].DeviceID, result.data[i].ParaID, result.data[i].Value, result.data[i].DateTime, result.data[i].Status, datatype, Marks[n]);
                                }

                            }



                        }

                    }
                    catch(e) {

                    }


                }

                isUsed = false;
            });
        }
        catch(e) {

        }

        //获取实时报警
        try {
            //当前页面上所有的报警表格
            var iotables = document.querySelectorAll('[data-ioalarm]');
            for (var a = 0; a < iotables.length; a++) {
                var pagesize = $("#" + iotables[a].id).data("pagesize");
                var pageindex = $("#" + iotables[a].id).data("pageindex");
                var id = iotables[a].id;
                $.post("/Scada/ScadaFlow/GetReadAlarm", { List: IoParas, PageSize: pagesize, PageIndex: pageindex }, function (result) {


                    SCADA.UpdateFlowAlarm(result.data, result.count, pagesize, pageindex, id.replace("shape", ""));

                });
            }
        }
        catch(e) {

        }
        //获取数据库数据
        //实时更新svg 数据库配置配置图形
        var dbelements = document.querySelectorAll('[data-dbsingle]');
        try {
            for (var e = 0; e < dbelements.length; e++) {
                var shape = $("#" + dbelements[e].id);
            
                //获取当前时间
                var valueDate = new Date().Format("yyyy-MM-dd hh:mm:ss");
                var dateString = shape.data("datetime");
                var oldDate = valueDate;
                var isfirst = false;
                //获取之前的实际
                if (dateString== null || dateString== "") {
                    shape.data("datetime", valueDate);
                    isfirst = true;
                }
                if (dateString) {
                    var arr1 = dateString.split(" ");
                    var sdate = arr1[0].split('-');
                    oldDate = new Date(sdate[0], sdate[1] - 1, sdate[2]).Format("yyyy-MM-dd hh:mm:ss");
                }
                var updatecycle = parseInt(shape.data("updatecycle"));//
                var newDate = addSecond(oldDate, updatecycle).Format("yyyy-MM-dd hh:mm:ss");
                let current_unix = parseInt(Date.parse(valueDate)); //將字符串格式日期转化为时间戳，就是1970年到当前日期的毫秒数
                let new_unix = parseInt(Date.parse(newDate)); //將字符串格式日期转化为时间戳，就是1970年到当前日期的毫秒数
                if (new_unix <= current_unix || isfirst) {
                    var uid = dbelements[e].id.replace("shape", "");
                    var jsonid = dbelements[e].getAttribute("data-dbsingle");
                    var subid = dbelements[e].id;
               
                    if (jsonid != undefined && jsonid.trim() != "") {
                        var jsonContent = JSON.parse(document.getElementById(jsonid).innerHTML);//获取当前的Json数据
                   
                        //向服务器请求数据
                        $.post("/Scada/ScadaFlow/GetDBSingleValues?elementId=" + subid, jsonContent, function (result) {
                            //此处特别注意的是后台返回的是一个将DataTableJson化的字符串，此处需要进行转化为Json对象
                            var returnObj = JSON.parse(result.data);
                  
                            SCADA.UpdateFlowSingleDBValue(returnObj, uid, jsonContent, result.elementId);
                        });
                    }
                    //设置保存当前时间
                    shape.data("datetime", valueDate);
                }
               
            }
        }
        catch (e) {

        }

    }
    ///更新数据库要显示的对象
    this.UpdateFlowSingleDBValue = function (dbvalue, uid,dbconfig,subid) {
        try {
            var value = 0;
            //获取对应的shape 每个shape 有一个g,包含IO参数
            var shapeg = $("#shape" + uid);
            if (shapeg == undefined)
                return;
            if (dbvalue.length <= 0)
                return;
            if (dbvalue[0][dbconfig.Record.Record] == undefined || dbvalue[0][dbconfig.Record.Record] == null || dbvalue[0][dbconfig.Record.Record] == "") {
                value = 0;
            }
            else {
                value = dbvalue[0][dbconfig.Record.Record];
            }
           
            var shapeName = shapeg.data("shape");
            var rectstr = shapeg.data("rect");
            switch (shapeName) {

                case "SVG_DataBaseValueLabelShape":
                    {
                        var text = $("#shape" + uid + ">a>text");
                        if (text != undefined) {
                            text.html(value);
                            text.text(value);
                        }
                    }
                    break;
                case "SVG_DataBaseRankingBarChartItemShape"://数据库轮播排名图
                    {
                         
                        var rankgroup = $("#" + subid + "");
                        if (isNumber(value)) {
                            rankgroup.data("value", value);//设置当前的子项值
                        }
                        else {
                            value = 0;
                            rankgroup.data("value", 0);//设置当前的子项值
                        }
                        SCADA.DrawDBRankChart(rankgroup.data("parentuid"));
                    }
                    break;
                case "SVG_DataBaseActiveRingChartItemShape"://数据库环图子项
                    {
                        var rankgroup = $("#" + subid + "");
                        if (isNumber(value)) {
                            rankgroup.data("value", value);//设置当前的子项值
                        }
                        else {
                            value = 0;
                            rankgroup.data("value", 0);//设置当前的子项值
                        }
                        SCADA.DrawDBRingChart(ringitemgroup.data("parentuid"))


                    }
                    break;
                case "SVG_DataBaseConicalChartItemShape"://锥形图子项
                    {
                        var rankgroup = $("#" + subid + "");
                        if (isNumber(value)) {
                            rankgroup.data("value", value);//设置当前的子项值
                        }
                        else {
                            value = 0;
                            rankgroup.data("value", 0);//设置当前的子项值
                        }
                        SCADA.DrawDBConicalChart(rankgroup.data("parentuid"));
                    }
                    break;
                case "SVG_DataBaseWaterLevelPondShape"://水位图
                    {
                        if (value.length <= 0)
                            return;
                        if (value == -9999 || value == "-9999")
                            return;
                        var lqrect = $("#shape" + uid + ">.ioupdate");
                        var maxvalue = shapeg.data("maxvalue");//水位最大值
                        var pondformat = shapeg.data("pondformat");//显示格式
                        var wavenum = parseInt(shapeg.data("wavenum"));//波纹数量
                        var current = parseInt(shapeg.data("current"));//获取上次显示的值
                        shapeg.data("current", value);//保存本次读取的值
                        var waveheight = parseInt(shapeg.data("waveheight"));//波纹高度
                        var pondLiq = $("#PondLiquid" + uid);  //获取液体显示对象
                        var rect = {
                            X: parseFloat(rectstr.split(',')[0]), Y: parseFloat(rectstr.split(',')[1]), Width: parseFloat(rectstr.split(',')[2]),

                            Height: parseFloat(rectstr.split(',')[3]), Top: parseFloat(rectstr.split(',')[1]), Bottom: parseFloat(rectstr.split(',')[1]) + parseFloat(rectstr.split

                                (',')[3]), Left: parseFloat(rectstr.split(',')[0]), Right: parseFloat(rectstr.split(',')[0]) + parseFloat(rectstr.split(',')[2])
                        };
                        if (pondLiq != undefined) {
                            var realValue = value / maxvalue;
                            var pointsNum = wavenum * 2.0 + 4;
                            var pointXGap = rect.Width / wavenum / 2.0;
                            var pondSource = pondLiq[0].getAttribute("d");
                            var pondData = [];
                            var startheight = (1 - realValue) * rect.Height;
                            var currentheight = (1 - current / maxvalue) * rect.Height;
                            var distance = startheight - currentheight;
                            //重新设置波的所有的值
                            for (var i = 0; i < pondSource.split(' ').length; i++) {
                                if (pondSource.split(' ')[i].trim() != "") {
                                    var str = pondSource.split(' ')[i].trim();
                                    if (str.split(',').length == 2) {
                                        var xstr = str.split(',')[0];
                                        var ystr = str.split(',')[1];
                                        if (!isNaN(xstr)) {
                                            pondData.push({ Name: "", X: parseFloat(xstr), Y: parseFloat(ystr) });

                                        }
                                        else {
                                            pondData.push({ Name: xstr.substr(0, 1), X: parseFloat(xstr.substr(1, xstr.length - 1)), Y: parseFloat(ystr) });

                                        }

                                    }
                                    else {
                                        pondData.push({ Name: str.split(',')[0], X: -9999, Y: -9999 });

                                    }

                                }

                            }
                            for (var i = 0; i < pondData.length - 3; i++) {


                                pondData[i].Y += distance;


                            }
                            var strD = "";
                            for (var i = 0; i < pondData.length; i++) {
                                if (pondData[i].X != -9999 && pondData[i].Y != -9999)
                                    strD += (strD == "" ? "" : " ") + (pondData[i].Name + "" + pondData[i].X + "," + pondData[i].Y);
                                else
                                    strD += (strD == "" ? "" : " ") + pondData[i].Name;
                            }
                            pondLiq[0].setAttribute("d", strD);
                            //设置动画变化的D
                            var animate = $("#animate" + uid);  //获取液体显示对象
                            var animateSource1 = animate[0].getAttribute("values").split(";")[0];
                            var animateSource2 = animate[0].getAttribute("values").split(";")[1];
                            var animateData1 = [];
                            var animateData2 = [];
                            //重新设置波的所有的值
                            for (var i = 0; i < animateSource1.split(' ').length; i++) {
                                if (animateSource1.split(' ')[i].trim() != "") {
                                    var str = animateSource1.split(' ')[i].trim();
                                    if (str.split(',').length == 2) {
                                        var xstr = str.split(',')[0];
                                        var ystr = str.split(',')[1];
                                        if (!isNaN(xstr)) {
                                            animateData1.push({ Name: "", X: parseFloat(xstr), Y: parseFloat(ystr) });

                                        }
                                        else {
                                            animateData1.push({
                                                Name: xstr.substr(0, 1), X: parseFloat(xstr.substr(1, xstr.length - 1)), Y: parseFloat(ystr)

                                            });

                                        }

                                    }
                                    else {
                                        animateData1.push({ Name: str.split(',')[0], X: -9999, Y: -9999 });

                                    }

                                }
                            }
                            for (var i = 0; i < animateData1.length - 3; i++) {

                                animateData1[i].Y += distance;

                            }

                            for (var i = 0; i < animateSource2.split(' ').length; i++) {
                                if (animateSource2.split(' ')[i].trim() != "") {
                                    var str = animateSource2.split(' ')[i].trim();
                                    if (str.split(',').length == 2) {
                                        var xstr = str.split(',')[0];
                                        var ystr = str.split(',')[1];
                                        if (!isNaN(xstr)) {
                                            animateData2.push({ Name: "", X: parseFloat(xstr), Y: parseFloat(ystr) });

                                        }
                                        else {
                                            animateData2.push({
                                                Name: xstr.substr(0, 1), X: parseFloat(xstr.substr(1, xstr.length - 1)), Y: parseFloat(ystr)

                                            });

                                        }

                                    }
                                    else {
                                        animateData2.push({ Name: str.split(',')[0], X: -9999, Y: -9999 });

                                    }

                                }
                            }
                            for (var i = 0; i < animateData2.length - 3; i++) {


                                animateData2[i].Y += distance;
                            }

                            var animateStrD1 = "";
                            var animateStrD2 = "";
                            for (var i = 0; i < animateData1.length; i++) {
                                if (animateData1[i].X != -9999 && animateData1[i].Y != -9999)
                                    animateStrD1 += (animateStrD1 == "" ? "" : " ") + (animateData1[i].Name + "" + animateData1[i].X + "," + animateData1

                                    [i].Y);
                                else
                                    animateStrD1 += (animateStrD1 == "" ? "" : " ") + animateData1[i].Name;
                            }
                            for (var i = 0; i < animateData2.length; i++) {
                                if (animateData2[i].X != -9999 && animateData2[i].Y != -9999)
                                    animateStrD2 += (animateStrD2 == "" ? "" : " ") + (animateData2[i].Name + "" + animateData2[i].X + "," + animateData2

                                    [i].Y);
                                else
                                    animateStrD2 += (animateStrD2 == "" ? "" : " ") + animateData2[i].Name;
                            }

                            animate[0].setAttribute("values", animateStrD1 + ";" + animateStrD2);
                        }
                        //修改显示值信息
                        var txt = $("#PondText" + uid);
                        if (txt != undefined) {
                            if (pondformat == "percent") {
                                var strFormat = number_format(parseFloat(realValue * 100), ioformat, '.', ',', 'round');
                                txt.html(strFormat + "%");
                                txt.text(strFormat + "%");
                            }
                            else {


                                var strFormat = number_format(parseFloat(value), ioformat, '.', ',', 'round');
                                txt.html(strFormat);
                                txt.text(strFormat);
                            }

                        }
                    }
                    break;
                case "SVG_DataBaseProcessChartShape"://环装图子项
                    {
                        if (value.length <= 0)
                            return;
                        if (value == -9999 || value == "-9999")
                            return;
                        var progressBar = $("#shape" + uid + "");
                        var valueformat = progressBar.data("valueformat");
                        var maxvalue = parseFloat(progressBar.data("maxvalue"));
                        var progresslines = $("#shape" + uid + ">g[data-filter='progressline']>line");//获取所有当前的对象
                        for (var i = 0; i < progresslines.length; i++) {
                            var line = $("#" + progresslines[i].id);
                            var upvalue = parseFloat(line.data("upvalue"));
                            if (parseFloat(value) >= upvalue) {

                                line.show();
                                line.attr("style", "display:block;");
                                line.attr("visibility", "visible");
                            }
                            else {
                                line.hide();
                                line.attr("style", "display:none;");
                                line.attr("visibility", "hidden");
                            }

                        }
                        var realValue = parseFloat(value) / maxvalue;
                        var txt = $("#ProgressText" + uid);
                        if (txt != undefined) {
                            if (valueformat == "percent") {
                                var strFormat = number_format(parseFloat(realValue * 100), ioformat, '.', ',', 'round');
                                txt.html(strFormat + "%");
                                txt.text(strFormat + "%");
                            }
                            else {


                                var strFormat = number_format(parseFloat(value), ioformat, '.', ',', 'round');
                                txt.html(strFormat);
                                txt.text(strFormat);
                            }

                        }


                    }
                    break;
            }
        }
        catch (e) {

        }
    }
    //动态设置数据库DBRankChart效果
    this.DrawDBRankChart = function (uid) {

        var shapeg = $("#shape" + uid);
        if (shapeg == undefined)
            return;
        var maxvalue = 0;
        var itemobject = [];
        var rectstr = shapeg.data("rect");
        var number = parseInt(shapeg.data("number"));
        var rect = { X: parseFloat(rectstr.split(',')[0]), Y: parseFloat(rectstr.split(',')[1]), Width: parseFloat(rectstr.split(',')[2]), Height: parseFloat(rectstr.split(',')[3]) };
        rect.Left = rect.X;
        rect.Right = rect.X + rect.Width;
        rect.Top = rect.Y;
        rect.Bottom = rect.Y + rect.Height;
        rect.CX = rect.X + rect.Width / 2;//圆心
        rect.CY = rect.Y + rect.Height / 2;
        rect.RX = rect.Width / 2;//半径
        rect.RY = rect.Height / 2;//
        var items = $("#shape" + uid + ">g[data-filter='RankItem']");
        for (var i = 0; i < items.length; i++) {
            var groupid = items[i].id;
            var rankitemgroup = $("#" + groupid + "");
            var itemvalue = rankitemgroup.data("value");//获取当前值
            var itemtitle = rankitemgroup.data("title");
            maxvalue = Math.max(parseFloat(itemvalue), maxvalue);  
            itemobject.push({ gid: groupid, itemvalue: parseFloat(itemvalue), itemtitle: itemtitle, rect: rect });
        }

        itemobject.sort(({ itemvalue: a }, { itemvalue: b }) => {
            if (a < b) return -1;
            if (a > b) return 1;
            if (a === b) return 0;
        });
        var basiclinewidth = parseFloat(shapeg.data("basiclinewidth"));
        var titleheight = parseFloat(shapeg.data("titleheight"));
        var iconheight = parseFloat(shapeg.data("iconheight"));
        var currenty = parseFloat(shapeg.data("currenty"));
        maxvalue = maxvalue + maxvalue / 10;//当前所有项的最大值
        var x = rect.X;
        var y = currenty + Math.max(titleheight, iconheight);
        var space = titleheight + 10 + parseFloat(basiclinewidth);
        for (var i = 0; i < itemobject.length; i++) {
            var groupid = itemobject[i].gid;
            var w = itemobject[i].itemvalue / maxvalue * rect.Width;
            var rankitemgroup = $("#" + groupid + "");
            var rankmajorline = $("#" + groupid + ">line[data-filter='major']");
            var rankbasicline = $("#" + groupid + ">line[data-filter='basic']");
            var rankicon = $("#" + groupid + ">image");
            var ranktitle = $("#" + groupid + ">text[data-filter='title']");
            var rankvalue = $("#" + groupid + ">text[data-filter='value']");
            var majorlinewidth = rankitemgroup.data("majorlinewidth");
            var valueheight = parseFloat(rankitemgroup.data("valueheight"));
            rankbasicline.attr("y1", y + parseFloat(majorlinewidth) + parseFloat(basiclinewidth));
            rankbasicline.attr("y2", y + parseFloat(majorlinewidth) + parseFloat(basiclinewidth));


            rankmajorline.attr("y1", y + parseFloat(basiclinewidth));
            rankmajorline.attr("y2", y + parseFloat(basiclinewidth));
            rankmajorline.attr("x2", x + w);
            if (rankicon != undefined && rankicon != null) {
                rankicon.attr("y", y - iconheight - 5);
            }
            if (ranktitle != undefined && ranktitle != null) {
                ranktitle.attr("y", y - titleheight / 2);
            }
            if (rankvalue != undefined && rankvalue != null) {
                var strFormat = number_format(itemobject[i].itemvalue, number, '.', ',', 'round');
                rankvalue.attr("y", y - valueheight / 2);
                rankvalue.html(strFormat);
            }
            y += parseFloat(majorlinewidth) + space;

        }

    }
    //动态设置DrawRankChart轮播效果 
    this.LoadDBRankAnimate = function (dur, uid, height) {
        var shapeg = $("#shape" + uid);
        if (shapeg == undefined)
            return;

        var distance = parseFloat(height);//每次轮播的实际移动的距离
        var rectstr = shapeg.data("rect");
        var enablescroll = shapeg.data("enablescroll");
        //如果不支持滚动，则直接跳过不执行动态播放
        if (enablescroll == "false") {
            return;
        }
        var rect = { X: parseFloat(rectstr.split(',')[0]), Y: parseFloat(rectstr.split(',')[1]), Width: parseFloat(rectstr.split(',')[2]), Height: parseFloat(rectstr.split(',')[3]) };
        rect.Left = rect.X;
        rect.Right = rect.X + rect.Width;
        rect.Top = rect.Y;
        rect.Bottom = rect.Y + rect.Height;
        rect.CX = rect.X + rect.Width / 2;//圆心
        rect.CY = rect.Y + rect.Height / 2;
        rect.RX = rect.Width / 2;//半径
        rect.RY = rect.Height / 2;//

        $('body').everyTime(dur + "s", function () {
            try {
                var currenty = parseFloat(shapeg.data("currenty"));
                currenty -= distance;
                if (currenty < rect.Y - rect.Height) {
                    currenty = rect.Y;
                }
                shapeg.data("currenty", currenty);
                //设置当前的值
                SCADA.DrawDBRankChart(uid);
            } catch (e) { }
        });
    }
    //动态设置RingChart效果--数据库读取的数据
    this.LoadDBRingAnimate = function (dur, uid) {

        //设置定时器实时读取数据

        $('body').everyTime(dur + "s", function () {
            try {
                var shapeg = $("#shape" + uid);
                if (shapeg == undefined)
                    return;
                var items = $("#shape" + uid + ">g[data-filter='RingItem']");
                var activeIndex = 0;
                var total = 0;
                for (var i = 0; i < items.length; i++) {
                    var groupid = items[i].id;
                    var ringitemgroup = $("#" + groupid + "");
                    var itemvalue = ringitemgroup.data("value");
                    var active = ringitemgroup.data("active");
                    if (active == "true" || active == "True") {
                        activeIndex = (i + 1) % (items.length);
                    }
                    ringitemgroup.data("active", "false");
                    total += parseFloat(itemvalue);
                }
                var activeitem = $("#" + items[activeIndex].id + "");
                activeitem.data("active", "true");
                var txtvalue = $("#shape" + uid + ">.iotext")[0];
                var txttitle = $("#shape" + uid + ">.iotext")[1];
                if (txtvalue != undefined) {
                    var io = activeitem.data("iovalue");

                    var ioformat = "0";
                    if (io != undefined && io != "") {
                        ioformat = io.split(",")[5];
                    }
                    var itemvalue = activeitem.data("value");
                    var ringformat = activeitem.data("ringformat");
                    if (ringformat == "percent") {
                        var strFormat = number_format(parseFloat(itemvalue) / total * 100, ioformat, '.', ',', 'round');
                        $("#" + txtvalue.id).html(strFormat + "%");
                        $("#" + txtvalue.id).text(strFormat + "%");
                    }
                    else {
                        var strFormat = number_format(parseFloat(itemvalue), ioformat, '.', ',', 'round');
                        $("#" + txtvalue.id).html(strFormat);
                        $("#" + txtvalue.id).text(strFormat);
                    }
                    if (txttitle != undefined) {
                        var itemtitle = activeitem.data("title");
                        $("#" + txttitle.id).html(itemtitle);
                        $("#" + txttitle.id).text(itemtitle);
                    }
                }
                //设置当前的值
                SCADA.DrawDBRingChart(uid);
            } catch (e) { }
        });

    }
    this.DrawDBRingChart = function (uid) {

        var shapeg = $("#shape" + uid);
        if (shapeg == undefined)
            return;
        var items = $("#shape" + uid + ">g[data-filter='RingItem']");
        var itemobject = [];
        var total = 0;
        for (var i = 0; i < items.length; i++) {
            var groupid = items[i].id;
            var ringitemgroup = $("#" + groupid + "");
            var ringitempath = $("#" + groupid + ">.ioupdate");
            var itemvalue = ringitemgroup.data("value");
            var itemtitle = ringitemgroup.data("title");
            var linewidth = ringitemgroup.data("linewidth");
            var ringcolor = ringitemgroup.data("ringcolor");
            var ringcoloropacity = ringitemgroup.data("ringcoloropacity");
            var due = ringitemgroup.data("due");
            var startangle = ringitemgroup.data("startangle");
            var activeradius = ringitemgroup.data("activeradius");
            var ringformat = ringitemgroup.data("ringformat");
            var active = ringitemgroup.data("active");
            var rectstr = shapeg.data("rect");

            if (itemvalue == undefined || itemvalue == null || itemvalue == "" || itemvalue == "-9999") {
                itemvalue = 0;
            }
            itemobject.push({ gid: groupid, itemvalue: parseFloat(itemvalue), itemtitle: itemtitle, linewidth: linewidth, ringcolor: ringcolor, ringcoloropacity: ringcoloropacity, due: due, startangle: startangle, activeradius: activeradius, ringformat: ringformat, percent: 0, active: active, rect: rectstr, sweep: 0 });

            total += parseFloat(itemvalue);
        }


        ///计算百分比
        for (var i = 0; i < itemobject.length; i++) {
            if (total != 0)
                itemobject[i].percent = itemobject[i].itemvalue / total;
            else
                itemobject[i].percent = 0;
            itemobject[i].sweep = itemobject[i].percent * 360;//计算的实际角度
            if (i > 0)
                itemobject[i].startangle = (itemobject[i - 1].startangle + itemobject[i - 1].sweep) % 360;
        }
        //重新计算绘图
        for (var i = 0; i < itemobject.length; i++) {
            var groupid = itemobject[i].gid;
            var ringitemgroup = $("#" + groupid + "");
            var ringitempath = $("#" + groupid + ">.ioupdate");
            var acradious = 0;
            if (itemobject[i].active == "true") {
                acradious = parseFloat(itemobject[i].activeradius);
            }
            var rect = {
                X: parseFloat(itemobject[i].rect.split(',')[0]) - acradious / 2, Y: parseFloat(itemobject[i].rect.split(',')[1]) - acradious / 2, Width: parseFloat(itemobject[i].rect.split(',')[2]) + acradious,

                Height: parseFloat(itemobject[i].rect.split(',')[3]) + acradious, Top: parseFloat(itemobject[i].rect.split(',')[1]) - acradious / 2, Bottom: parseFloat(itemobject[i].rect.split(',')[1]) + parseFloat(itemobject[i].rect.split

                    (',')[3]) + acradious / 2, Left: parseFloat(itemobject[i].rect.split(',')[0]) - acradious / 2, Right: parseFloat(itemobject[i].rect.split(',')[0]) + parseFloat(itemobject[i].rect.split(',')[2]) + acradious / 2, CX: 0, CY: 0, RX: 0, RY: 0
            };
            rect.CX = rect.X + rect.Width / 2;//圆心
            rect.CY = rect.Y + rect.Height / 2;
            rect.RX = rect.Width / 2;//半径
            rect.RY = rect.Height / 2;
            var startangle = 3.1415926 / 180.0 * (itemobject[i].startangle) % 360;
            var cx = rect.CX + rect.RX * Math.cos(startangle);
            var cy = rect.CY + rect.RY * Math.sin(startangle);
            var sweep = 3.1415926 / 180.0 * (itemobject[i].startangle + itemobject[i].sweep) % 360;
            var ex = rect.CX + rect.RX * Math.cos(sweep);
            var ey = rect.CY + rect.RY * Math.sin(sweep);

            //M cx cy A rx ry x-axis-rotation large-arc-flag sweep-flag x y
            var sweepflg = 1;
            var largeflg = 0;
            if (itemobject[i].sweep > 180) {
                largeflg = 1;
            }
            var str = "M" + cx + "," + cy + " A" + rect.RX + "," + rect.RY + " 0 " + largeflg + "," + sweepflg + " " + ex + "," + ey;
            ringitempath.attr("d", str);


        }

    }
    //数据库数据绘制锥形图
    this.DrawDBConicalChart = function (uid) {
        var shapeg = $("#shape" + uid);
        if (shapeg == undefined)
            return;
        var rectstr = shapeg.data("rect");
        //获取当前的所有子项
        var rect = { X: parseFloat(rectstr.split(',')[0]), Y: parseFloat(rectstr.split(',')[1]), Width: parseFloat(rectstr.split(',')[2]), Height: parseFloat(rectstr.split(',')[3]) };
        rect.Left = rect.X;
        rect.Right = rect.X + rect.Width;
        rect.Top = rect.Y;
        rect.Bottom = rect.Y + rect.Height;
        rect.CX = rect.X + rect.Width / 2;//圆心
        rect.CY = rect.Y + rect.Height / 2;
        rect.RX = rect.Width / 2;//半径
        rect.RY = rect.Height / 2;
        var itemsort = shapeg.data("sort");
        var items = $("#shape" + uid + ">g[data-filter='conicalitem']");
        var maxValue = -9999;
        var radious = rect.Width / (items.length + 1);
        var itemobject = [];
        for (var i = 0; i < items.length; i++) {
            var groupid = items[i].id;
            var itemgroup = $("#" + groupid + "");
            var number = itemgroup.data("number");
            var itemvalue = itemgroup.data("value");
            var itemtitle = itemgroup.data("title");
            var itemsort = itemgroup.data("sort");

            itemobject.push({ gid: groupid, itemvalue: parseFloat(itemvalue), itemtitle: itemtitle, number: number });
            maxValue = Math.max(maxValue, parseFloat(itemvalue));
        }
        itemobject.sort(({ itemvalue: a }, { itemvalue: b }) => {
            if (a < b) return -1;
            if (a > b) return 1;
            if (a === b) return 0;
        });
        var x = rect.X;
        var y = rect.Bottom;
        if (itemsort == "asc") {
            for (var i = 0; i < itemobject.length; i++) {
                var groupid = itemobject[i].gid;
                var itemgroup = $("#" + groupid + "");
                var itempath = $("#" + groupid + ">.ioupdate");
                var itemvalueobject = $("#" + groupid + ">.iotext");
                var itemtitleobject = $("#" + groupid + ">.itemtitle");
                var itemimage = $("#" + groupid + ">image");
                var iconwidth = itemgroup.data("iconwidth");
                var iconheight = itemgroup.data("iconheight");
                ///升序排列  
                var h = itemobject[i].itemvalue / maxValue * rect.Height;
                var middleXPos = rect.X + radious * (i + 1);
                var leftXPos = rect.X + radious * i;
                var rightXpos = rect.X + radious * (i + 2);
                var middleYPos = y - h;
                var controlYPos = h * 0.6 + middleYPos;
                var pathD = "  M" + leftXPos + "," + rect.Bottom + " Q" + middleXPos + ", " + controlYPos + " " + middleXPos + "," + middleYPos + " M" + middleXPos + "," + middleYPos + " Q" + middleXPos + ", " + controlYPos + " " + rightXpos + ", " + rect.Bottom + " L" + leftXPos + ", " + rect.Bottom + " Z";
                itempath.attr("d", pathD);
                //设置Icon路径
                if (itemimage != undefined && itemimage != null) {
                    itemimage.attr("y", middleYPos - iconheight - 10);
                    itemimage.attr("x", middleXPos - iconwidth / 4);
                }
                //设置值
                if (itemvalueobject != undefined && itemvalueobject != null) {
                    itemvalueobject.attr("y", middleYPos + 20);
                    itemvalueobject.attr("x", middleXPos);
                    var strFormat = number_format(parseFloat(itemobject[i].itemvalue), itemobject[i].number, '.', ',', 'round');
                    itemvalueobject.html(strFormat);
                    itemvalueobject.text(strFormat);
                }
                if (itemtitleobject != undefined && itemtitleobject != null) {

                    itemtitleobject.attr("x", middleXPos);
                }

            }
        }
        else {
            var ii = 0;
            for (var i = itemobject.length - 1; i >= 0; i--) {
                var groupid = itemobject[i].gid;
                var itemgroup = $("#" + groupid + "");
                var itempath = $("#" + groupid + ">.ioupdate");
                var itemvalueobject = $("#" + groupid + ">.iotext");
                var itemtitleobject = $("#" + groupid + ">.itemtitle");
                var itemimage = $("#" + groupid + ">image");
                var iconwidth = itemgroup.data("iconwidth");
                var iconheight = itemgroup.data("iconheight");
                ///升序排列
                var h = itemobject[i].itemvalue / maxValue * rect.Height;
                var middleXPos = rect.X + radious * (ii + 1);
                var leftXPos = rect.X + radious * ii;
                var rightXpos = rect.X + radious * (ii + 2);
                var middleYPos = y - h;
                var controlYPos = h * 0.6 + middleYPos;
                var pathD = "  M" + leftXPos + "," + rect.Bottom + " Q" + middleXPos + ", " + controlYPos + " " + middleXPos + "," + middleYPos + " M" + middleXPos + "," + middleYPos + " Q" + middleXPos + ", " + controlYPos + " " + rightXpos + ", " + rect.Bottom + " L" + leftXPos + ", " + rect.Bottom + " Z";
                itempath.attr("d", pathD);
                //设置Icon路径
                if (itemimage != undefined && itemimage != null) {
                    itemimage.attr("y", middleYPos - iconheight - 10);
                    itemimage.attr("x", middleXPos - iconwidth / 4);
                }
                //设置值
                if (itemvalueobject != undefined && itemvalueobject != null) {
                    itemvalueobject.attr("y", middleYPos + 20);
                    itemvalueobject.attr("x", middleXPos);
                    var strFormat = number_format(parseFloat(itemobject[i].itemvalue), itemobject[i].number, '.', ',', 'round');
                    itemvalueobject.html(strFormat);
                    itemvalueobject.text(strFormat);
                }
                if (itemtitleobject != undefined && itemtitleobject != null) {

                    itemtitleobject.attr("x", middleXPos);
                }
                ii++;
            }
        }


        //重新绘制图形
    }
    //用户点击图例的时候隐藏和显示曲线
    this.SeriesHideShow = function (shapename, seriename) {
        //  data-seriename='' 曲线名称
        var serie = $("#" + shapename + ">g[data-seriename='" + seriename + "']");
        var display = serie.css("display");
        if (display == undefined || display == null || display == "") {
            serie.css("display", 'none');
        }
        else if (display == "none") {
            serie.css("display", 'block');
        }
        else if (display == "block" || display == "inline") {
            serie.css("display", 'none');
        }
    }
    //////////////////////TabControl 页面切换///////////////////////////////////////////////////////////////////////////////
    this.TabShape_PageChanged = function (tab_id, tabpage_id, pageindex) {
        //Tab控件
        var tabShape = $("#" + tab_id);
        tabShape.data("pageindex", pageindex);
        //当前要切换的页面
        var currentPage = $("#" + tabpage_id);
        //处理选中后的tab导航显示颜色
        //首先获取所有page
        var pages = $("#" + tab_id + ">g[data-filter='pagecontent']>g[data-filter='pagecontentitem']");
        for (var i = 0; i < pages.length; i++) {

            $("#" + pages[i].id).hide();

        }
        $("#" + tabpage_id).show();


        for (var i = 0; i < pages.length; i++) {


            var eleStr = $("#" + pages[i].id).data("elements");
            if (eleStr != undefined && eleStr != "") {
                var eles = eleStr.split(",");
                for (var j = 0; j < eles.length; j++) {
                    if (pages[i].id == tabpage_id) {
                        $("#shape" + eles[j]).show();
                        $("#shape" + eles[j]).attr("style", "visibility:visible;");
                    }
                    else {
                        $("#shape" + eles[j]).hide();
                        $("#shape" + eles[j]).attr("style", "visibility:hidden;");
                    }
                }
            }

        }

        //重新设置颜色当前选中页面的导航颜色
        var pageheads = $("#" + tab_id + ">g[data-filter='head']>g[data-filter='headitem']");
        if (pageheads.length >= 0) {
            var selcolor = $("#" + tab_id).data("selectcolor");
            for (var i = 0; i < pageheads.length; i++) {

            }

        }
    }
    this.ScadaMessage = function (message) {
        layui.use(['form', 'layer'], function () {
            var form = layui.form;
            var oklayer = layui.layer;
            oklayer.msg(message);
        })

        return;
    }
    this.PopComboBox = function (combolistid) {
        if ($("#" + combolistid).attr("visibility") == "hidden") {
            $("#" + combolistid).show();
            $("#" + combolistid).attr("visibility","visible");
        }
        else {
            $("#" + combolistid).hide();
            $("#" + combolistid).attr("visibility", "hidden");
        }
       

    }
    this.ComboItemMove = function (textid, textcolor, selectcolor) {
        $("#textitem" + textid).attr("fill", selectcolor);
    }
    this.ComboItemMoveOut = function (textid, textcolor, selectcolor) {
        $("#textitem" + textid).attr("fill", textcolor);
    }
    this.ComboBoxSelected = function (text, siteid, combolistid) {
        $("#text" + siteid).text(text);
        $("#text" + siteid).html(text);
        $("#text" + siteid).val(text);
        $("#" + combolistid).hide();
        $("#" + combolistid).attr("visibility", "hidden");
    }
    this.ComboBoxClose = function (combolistid) {
        $("#" + combolistid).hide();
        $("#" + combolistid).attr("visibility", "hidden");
    }
    
    //用户登录后要转向的页面
    this.Login = function (proj) {
        if (proj == undefined || proj == null)
            return;
        /**
 * 根据form表单的id获取表单下所有可提交的表单数据，封装成数组对象
 */     var data = {};
        var results = $("#loginForm").serializeArray();
        $.each(results, function (index, item) {

            if (item.value && $.trim(item.value) != "") {
                if (!data[item.name]) {
                    data[item.name] = item.value;
                }
            }
        });
        data["viewId"] = proj.viewId;
        data["ReturnViewId"] = proj.ReturnViewId;
        if (data["username"] == undefined && data["username"] == null || data["username"] == "") {
            SCADA.ScadaMessage("请输入账号");
            return;
        }
        if (data["password"] == undefined && data["password"] == null || data["password"] == "") {
            SCADA.ScadaMessage("请输入密码");
            return;
        }
        //向服务器端发送数据
        var model = { username: data["username"], password: data["password"], ReturnViewId: data["ReturnViewId"], viewId: data["viewId"] }
        //获取实时数据
        $.post("/API/API/Login", { model }, function (result) {

            if (result.state == "success") {
                
                //保存登录用户信息
                SCADA.FlowLoginUser = model;
                //转向到指定的视图页面,并传递登录用户
                parent.location.href = "/Scada/ScadaFlow?id=0&vid=" + result.data.ReturnViewId + "&uid=" + model.username;
            }
            else {
                SCADA.ScadaMessage(result.message);
            }
        });
    }
    //退出登录
    this.LoginOut = function (viewId) {

        $.post("/API/API/LoginOut", function (result) {

            if (result.state == "success") {

                //保存登录用户信息
                SCADA.FlowLoginUser = null;
                //转向到指定的视图页面,并传递登录用户
                parent.location.href = "/Scada/ScadaFlow?id=0&vid=" + viewId;
            }
            else {
                SCADA.ScadaMessage(result.message);
            }
        });

 
    }
}
    function isDate(dateString) {
        if (dateString.trim() == "") return true;
        var r = dateString.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
        if (r == null) {

            return false;
        }
        var d = new Date(r[1], r[3] - 1, r[4]);
        var num = (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4]);
        if (num == 0) {
            return false;
        }
        return (num != 0);
    }
    function SetCursorByID() {
      var targid=  $(this).attr('id')
        if (document.getElementById) {
            if (document.getElementById(targid).style) {
                document.getElementById(targid).style.cursor = "'hand'";
            }
        }
    }
    function analysisOpeartor(op,res,v)
    {
        switch(op)
        {
            case "=":
                {
                    if(v==res)
                    {
                        return true;
                    }
                    else
                    {
                        return null;
                    }

                }
                break;
            case ">":
                {
                    if (parseFloat(v) > parseFloat(res)) {
                        return true;
                    }
                    else {
                        return null;
                    }

                }
                break;
            case "<":
                {
                    if (parseFloat(v) < parseFloat(res)) {
                        return true;
                    }
                    else {
                        return null;
                    }

                }
                break;
            case ">=":
                {
                    if (parseFloat(v) >= parseFloat(res)) {
                        return true;
                    }
                    else {
                        return null;
                    }

                }
                break;
            case "<=":
                {
                    if (parseFloat(v) <= parseFloat(res)) {
                        return true;
                    }
                    else {
                        return null;
                    }

                }
                break;
            case "!=":
                {
                    if (parseFloat(v) != parseFloat(res)) {
                        return true;
                    }
                    else {
                        return null;
                    }

                }
                break;
        }
    }
    function GetArcZ(arc, startAngle, sweepAngle) {
        var arcRectstr = arc.getAttribute("data-rect");
        var arcRect = { x: parseFloat(arcRectstr.split(',')[0]), y: parseFloat(arcRectstr.split(',')[1]), width: parseFloat(arcRectstr.split(',')[2]), height: parseFloat(arcRectstr.split(',')[3]) };

        var CenterPoint = { x: arcRect.x + arcRect.width / 2, y: arcRect.y + arcRect.height / 2 };
        var arcflag = "1";
        if (sweepAngle < 180) {
            arcflag = "0";//绘制小圆弧
        }
        else {
            arcflag = "1";//绘制大圆弧
        }
        var sweepflag = "1";//1标识顺指针绘制，0标识逆时针绘制
        var y = arcRect.height / 2 * Math.sin(ConvertDegreesToRadians(startAngle)) + CenterPoint.y;
        var x = arcRect.width / 2 * Math.cos(ConvertDegreesToRadians(startAngle)) + CenterPoint.x;
        var y2 = arcRect.height / 2 * Math.sin(ConvertDegreesToRadians(startAngle + sweepAngle)) + CenterPoint.y;
        var x2 = arcRect.width / 2 * Math.cos(ConvertDegreesToRadians(startAngle + sweepAngle)) + CenterPoint.x;
        //d='M"+ x+","+ y+" A"+ arcRect.Width/2 + ","+ arcRect.Width/2 + " 0 "+ arcflag +","+ sweepflag + " "+x2+","+y2+"' 
        return " M" + x + "," + y + " A" + arcRect.width / 2 + "," + arcRect.width / 2 + " 0 " + arcflag + "," + sweepflag + " " + x2 + "," + y2 + " ";

    }
    function GetPieZ(arc, startAngle, sweepAngle) {
        var arcRectstr = arc.getAttribute("data-rect");
        var arcRect = { x: parseFloat(arcRectstr.split(',')[0]), y: parseFloat(arcRectstr.split(',')[1]), width: parseFloat(arcRectstr.split(',')[2]), height: parseFloat(arcRectstr.split(',')[3]) };

        var CenterPoint = { x: arcRect.x + arcRect.width / 2, y: arcRect.y + arcRect.height / 2 };
        var arcflag = "1";
        if (sweepAngle < 180) {
            arcflag = "0";//绘制小圆弧
        }
        else {
            arcflag = "1";//绘制大圆弧
        }
        var sweepflag = "1";//1标识顺指针绘制，0标识逆时针绘制
        var y = arcRect.height / 2 * Math.sin(ConvertDegreesToRadians(startAngle)) + CenterPoint.y;
        var x = arcRect.width / 2 * Math.cos(ConvertDegreesToRadians(startAngle)) + CenterPoint.x;
        var y2 = arcRect.height / 2 * Math.sin(ConvertDegreesToRadians(startAngle + sweepAngle)) + CenterPoint.y;
        var x2 = arcRect.width / 2 * Math.cos(ConvertDegreesToRadians(startAngle + sweepAngle)) + CenterPoint.x;
        return " M" + CenterPoint.x + "," + CenterPoint.y + " L" + x + "," + y + " A" + arcRect.width / 2 + "," + arcRect.width / 2 + " 0 " + arcflag + "," + sweepflag + " " + x2 + "," + y2 + " L" + CenterPoint.x + "," + CenterPoint.y + "";

    }
    function GetPieData(startAngle, sweepAngle, arcRect) {
       
        var CenterPoint = { x: arcRect.X + arcRect.Width / 2, y: arcRect.Y + arcRect.Height / 2 };
        var arcflag = "1";
        if (sweepAngle < 180) {
            arcflag = "0";//绘制小圆弧
        }
        else {
            arcflag = "1";//绘制大圆弧
        }
        var sweepflag = "1";//1标识顺指针绘制，0标识逆时针绘制
        var y = arcRect.Height / 2 * Math.sin(ConvertDegreesToRadians(startAngle)) + CenterPoint.y;
        var x = arcRect.Width / 2 * Math.cos(ConvertDegreesToRadians(startAngle)) + CenterPoint.x;
        var y2 = arcRect.Height / 2 * Math.sin(ConvertDegreesToRadians(startAngle + sweepAngle)) + CenterPoint.y;
        var x2 = arcRect.Width / 2 * Math.cos(ConvertDegreesToRadians(startAngle + sweepAngle)) + CenterPoint.x;
        return " M" + CenterPoint.x + "," + CenterPoint.y + " L" + x + "," + y + " A" + arcRect.Width / 2 + "," + arcRect.Width / 2 + " 0 " + arcflag + "," + sweepflag + " " + x2 + "," + y2 + " L" + CenterPoint.x + "," + CenterPoint.y + "";

    }
    function LedDraw(str, m_drawRect, m_lineWidth, mvalueColor, nums) {
        var paths = [];
        if (str == ".") {
            var dStr = "";
            var x1 = parseFloat(m_drawRect.Left + (m_drawRect.Width - m_lineWidth) / 2);
            var y1 = parseFloat(m_drawRect.Bottom - m_lineWidth * 2);
            var x2 = parseFloat(x1 + m_lineWidth);
            var y2 = parseFloat(y1 + m_lineWidth);
            dStr = "M" + x1 + "," + y1 + " L" + x2 + "," + y1 + " L" + x2 + "," + y2 + " L" + x1 + "," + y2 + " L" + x1 + "," + y1 + " Z";
            paths.push(dStr);
        }
        else if (str == ":") {
            var dStr = "";
            var x1 = parseFloat(m_drawRect.Left + (m_drawRect.Width - m_lineWidth) / 2);
            var y1 = parseFloat(m_drawRect.Top + (m_drawRect.Height / 2 - m_lineWidth) / 2);
            var x2 = parseFloat(x1 + m_lineWidth);
            var y2 = parseFloat(y1 + m_lineWidth);
            dStr = "M" + x1 + "," + y1 + " L" + x2 + "," + y1 + " L" + x2 + "," + y2 + " L" + x1 + "," + y2 + " L" + x1 + "," + y1 + " Z";
            paths.push(dStr);


            dStr = "";
            x1 = parseFloat(m_drawRect.Left + (m_drawRect.Width - m_lineWidth) / 2);
            y1 = parseFloat(m_drawRect.Top + (m_drawRect.Height - m_lineWidth) / 2 + m_drawRect.Height / 2);
            x2 = parseFloat(x1 + m_lineWidth);
            y2 = parseFloat(y1 + m_lineWidth);
            dStr = "M" + x1 + "," + y1 + " L" + x2 + "," + y1 + " L" + x2 + "," + y2 + " L" + x1 + "," + y2 + " L" + x1 + "," + y1 + " Z";
            paths.push(dStr);
        }
        else {
            var vs = FindLedNumChartIndex(nums, str);
            if (vs.indexOf(1) >= 0) {
                var dStr = "";
                var p1 = { x: parseFloat(m_drawRect.Left + 2), y: parseFloat(m_drawRect.Top) };
                var p2 = { x: parseFloat(m_drawRect.Right - 2), y: parseFloat(m_drawRect.Top) };
                var p3 = { x: parseFloat(m_drawRect.Right - m_lineWidth - 2), y: parseFloat(m_drawRect.Top + m_lineWidth) };
                var p4 = { x: parseFloat(m_drawRect.Left + m_lineWidth + 2), y: parseFloat(m_drawRect.Top + m_lineWidth) };
                var p5 = { x: parseFloat(m_drawRect.Left + 2), y: parseFloat(m_drawRect.Top) };
                dStr = "M" + p1.x + "," + p1.y + " L" + p2.x + "," + p2.y + " L" + p3.x + "," + p3.y + " L" + p4.x + "," + p4.y + " L" + p5.x + "," + p5.y + " L" + p1.x + "," + p1.y + " Z";
                paths.push(dStr);
            }
            if (vs.indexOf(2) >= 0) {
                var dStr = "";
                var p1 = { x: parseFloat(m_drawRect.Right), y: parseFloat(m_drawRect.Top) };
                var p2 = { x: parseFloat(m_drawRect.Right), y: parseFloat(m_drawRect.Top + (m_drawRect.Height - m_lineWidth - 4) / 2) };
                var p3 = { x: parseFloat(m_drawRect.Right - m_lineWidth / 2), y: parseFloat(m_drawRect.Top + (m_drawRect.Height - m_lineWidth - 4) / 2 + m_lineWidth / 2) };
                var p4 = { x: parseFloat(m_drawRect.Right - m_lineWidth), y: parseFloat(m_drawRect.Top + (m_drawRect.Height - m_lineWidth - 4) / 2) };
                var p5 = { x: parseFloat(m_drawRect.Right - m_lineWidth), y: parseFloat(m_drawRect.Top + m_lineWidth) };
                var p6 = { x: parseFloat(m_drawRect.Right), y: parseFloat(m_drawRect.Top) };
                dStr = "M" + p1.x + "," + p1.y + " L" + p2.x + "," + p2.y + " L" + p3.x + "," + p3.y + " L" + p4.x + "," + p4.y + " L" + p5.x + "," + p5.y + " L" + p6.x + "," + p6.y + " L" + p1.x + "," + p1.y + " Z";
                paths.push(dStr);
            }
            if (vs.indexOf(3) >= 0) {
                var dStr = "";
                var p1 = { x: parseFloat(m_drawRect.Right), y: parseFloat(m_drawRect.Bottom - (m_drawRect.Height - m_lineWidth - 4) / 2) };
                var p2 = { x: parseFloat(m_drawRect.Right), y: parseFloat(m_drawRect.Bottom) };
                var p3 = { x: parseFloat(m_drawRect.Right - m_lineWidth), y: parseFloat(m_drawRect.Bottom - m_lineWidth) };
                var p4 = { x: parseFloat(m_drawRect.Right - m_lineWidth), y: parseFloat(m_drawRect.Bottom - (m_drawRect.Height - m_lineWidth - 4) / 2) };
                var p5 = { x: parseFloat(m_drawRect.Right - m_lineWidth / 2), y: parseFloat(m_drawRect.Bottom - (m_drawRect.Height - m_lineWidth - 4) / 2 - m_lineWidth / 2) };
                var p6 = { x: parseFloat(m_drawRect.Right), y: parseFloat(m_drawRect.Bottom - (m_drawRect.Height - m_lineWidth - 4) / 2) };
                dStr = "M" + p1.x + "," + p1.y + " L" + p2.x + "," + p2.y + " L" + p3.x + "," + p3.y + " L" + p4.x + "," + p4.y + " L" + p5.x + "," + p5.y + " L" + p6.x + "," + p6.y + " L" + p1.x + "," + p1.y + " Z";
                paths.push(dStr);
            }
            if (vs.indexOf(4) >= 0) {
                var dStr = "";
                var p1 = { x: parseFloat(m_drawRect.Left + 2), y: parseFloat(m_drawRect.Bottom) };
                var p2 = { x: parseFloat(m_drawRect.Right - 2), y: parseFloat(m_drawRect.Bottom) };
                var p3 = { x: parseFloat(m_drawRect.Right - m_lineWidth - 2), y: parseFloat(m_drawRect.Bottom - m_lineWidth) };
                var p4 = { x: parseFloat(m_drawRect.Left + m_lineWidth + 2), y: parseFloat(m_drawRect.Bottom - m_lineWidth) };
                var p5 = { x: parseFloat(m_drawRect.Left + 2), y: parseFloat(m_drawRect.Bottom) };
                dStr = "M" + p1.x + "," + p1.y + " L" + p2.x + "," + p2.y + " L" + p3.x + "," + p3.y + " L" + p4.x + "," + p4.y + " L" + p5.x + "," + p5.y + " Z";
                paths.push(dStr);
            }
            if (vs.indexOf(5) >= 0) {
                var dStr = "";
                var p1 = { x: parseFloat(m_drawRect.Left), y: parseFloat(m_drawRect.Bottom - (m_drawRect.Height - m_lineWidth - 4) / 2) };
                var p2 = { x: parseFloat(m_drawRect.Left), y: parseFloat(m_drawRect.Bottom) };
                var p3 = { x: parseFloat(m_drawRect.Left + m_lineWidth), y: parseFloat(m_drawRect.Bottom - m_lineWidth) };
                var p4 = { x: parseFloat(m_drawRect.Left + m_lineWidth), y: parseFloat(m_drawRect.Bottom - (m_drawRect.Height - m_lineWidth - 4) / 2) };
                var p5 = { x: parseFloat(m_drawRect.Left + m_lineWidth / 2), y: parseFloat(m_drawRect.Bottom - (m_drawRect.Height - m_lineWidth - 4) / 2 - m_lineWidth / 2) };
                var p6 = { x: parseFloat(m_drawRect.Left), y: parseFloat(m_drawRect.Bottom - (m_drawRect.Height - m_lineWidth - 4) / 2) };
                dStr = "M" + p1.x + "," + p1.y + " L" + p2.x + "," + p2.y + " L" + p3.x + "," + p3.y + " L" + p4.x + "," + p4.y + " L" + p5.x + "," + p5.y + " L" + p6.x + "," + p6.y + " L" + p1.x + "," + p1.y + " Z";
                paths.push(dStr);
            }
            if (vs.indexOf(6) >= 0) {
                var dStr = "";
                var p1 = { x: parseFloat(m_drawRect.Left), y: parseFloat(m_drawRect.Top) };
                var p2 = { x: parseFloat(m_drawRect.Left), y: parseFloat(m_drawRect.Top + (m_drawRect.Height - m_lineWidth - 4) / 2) };
                var p3 = { x: parseFloat(m_drawRect.Left + m_lineWidth / 2), y: parseFloat(m_drawRect.Top + (m_drawRect.Height - m_lineWidth - 4) / 2 + m_lineWidth / 2) };
                var p4 = { x: parseFloat(m_drawRect.Left + m_lineWidth), y: parseFloat(m_drawRect.Top + (m_drawRect.Height - m_lineWidth - 4) / 2) };
                var p5 = { x: parseFloat(m_drawRect.Left + m_lineWidth), y: parseFloat(m_drawRect.Top + m_lineWidth) };
                var p6 = { x: parseFloat(m_drawRect.Left), y: parseFloat(m_drawRect.Top) };
                dStr = "M" + p1.x + "," + p1.y + " L" + p2.x + "," + p2.y + " L" + p3.x + "," + p3.y + " L" + p4.x + "," + p4.y + " L" + p5.x + "," + p5.y + " L" + p6.x + "," + p6.y + " L" + p1.x + "," + p1.y + " Z";
                paths.push(dStr);
            }
            if (vs.indexOf(7) >= 0) {
                var dStr = "";
                var p1 = { x: parseFloat(m_drawRect.Left + m_lineWidth / 2), y: parseFloat(m_drawRect.Top + m_drawRect.Height / 2 + 1) };
                var p2 = { x: parseFloat(m_drawRect.Left + m_lineWidth), y: parseFloat(m_drawRect.Top + m_drawRect.Height / 2 - m_lineWidth / 2 + 1) };
                var p3 = { x: parseFloat(m_drawRect.Right - m_lineWidth), y: parseFloat(m_drawRect.Top + m_drawRect.Height / 2 - m_lineWidth / 2 + 1) };
                var p4 = { x: parseFloat(m_drawRect.Right - m_lineWidth / 2), y: parseFloat(m_drawRect.Top + m_drawRect.Height / 2 + 1) };
                var p5 = { x: parseFloat(m_drawRect.Right - m_lineWidth), y: parseFloat(m_drawRect.Top + m_drawRect.Height / 2 + m_lineWidth / 2 + 1) };
                var p6 = { x: parseFloat(m_drawRect.Left + m_lineWidth), y: parseFloat(m_drawRect.Top + m_drawRect.Height / 2 + m_lineWidth / 2 + 1) };
                var p7 = { x: parseFloat(m_drawRect.Left + m_lineWidth / 2), y: parseFloat(m_drawRect.Top + m_drawRect.Height / 2 + 1) };
                dStr = "M" + p1.x + "," + p1.y + " L" + p2.x + "," + p2.y + " L" + p3.x + "," + p3.y + " L" + p4.x + "," + p4.y + " L" + p5.x + "," + p5.y + " L" + p6.x + "," + p6.y + " L" + p7.x + "," + p7.y + " L" + p1.x + "," + p1.y + " Z";
                paths.push(dStr);
            }
        }
        return paths;

    }
    function LedNum() {
        var num = [];
        num.push({ name: '0', index: [1, 2, 3, 4, 5, 6] });
        num.push({ name: '1', index: [2, 3] });
        num.push({ name: '2', index: [1, 2, 5, 4, 7] });
        num.push({ name: '3', index: [1, 2, 7, 3, 4] });
        num.push({ name: '4', index: [2, 3, 6, 7] });
        num.push({ name: '5', index: [1, 6, 7, 3, 4] });
        num.push({ name: '6', index: [1, 6, 5, 4, 3, 7] });
        num.push({ name: '7', index: [1, 2, 3] });
        num.push({ name: '8', index: [1, 2, 3, 4, 5, 6, 7] });
        num.push({ name: '9', index: [1, 2, 3, 4, 6, 7] });
        num.push({ name: '-', index: [7] });
        num.push({ name: ':', index: [] });
        num.push({ name: '.', index: [] });
        num.push({ name: ' ', index: [] });
        num.push({ name: '/', index: [] });
        return num;
    }
    function FindLedNumChartIndex(nums, symbol) {
        for (var i = 0; i < nums.length; i++) {
            if (nums[i].name == symbol) {
                return nums[i].index;
            }
        }
        return [];
    }
    /*
* 获得时间差,时间格式为 年-月-日 小时:分钟:秒 或者 年/月/日 小时：分钟：秒
* 其中，年月日为全格式，例如 ： 2010-10-12 01:00:00
* 返回精度为：秒，分，小时，天
*/
    function GetDateSeconds(maxdate, mindate, diffType)
    {
        //将xxxx-xx-xx的时间格式，转换为 xxxx/xx/xx的格式
    //  var  startTime = mindate.replace(/\-/g, "/");
   //   var  endTime = maxdate.replace(/\-/g, "/");

        //将计算间隔类性字符转换为小写
        diffType = diffType.toLowerCase();
        var sTime = mindate; //开始时间
        var eTime =maxdate ; //结束时间
        //作为除数的数字
        var divNum = 1;
        switch (diffType) {
            case "second":
                divNum = 1000;
                break;
            case "minute":
                divNum = 1000 * 60;
                break;
            case "hour":
                divNum = 1000 * 3600;
                break;
            case "day":
                divNum = 1000 * 3600 * 24;
                break;
            default:
                break;
        }
        return parseInt((eTime.getTime() - sTime.getTime()) / parseInt(divNum));
    }
    function addHour(date, hour) {
        var d = new Date(date);
        d.setTime(d.setHours(d.getHours() + parseInt(hour)));
        return d;
    }
    function addSecond(date, second) {
        var d = new Date(date);
        d.setTime(d.setSeconds(d.getSeconds() + parseInt(second)));
        return d;
    }
    function addMinute(date, minute) {
        var d = new Date(date);
        d.setTime(d.setMinutes(d.getMinutes() + parseInt(minute)));
        return d;
    }
    function addDay(date, day) {
        var d = new Date(date);
        d.setTime(d.setDay(d.getDay() + parseInt(day)));
        return d;
    }
    function adjustToFreezeWidth(rootSvg) {
        var windowWidth = $(window).width();

        var viewBoxVal = rootSvg.getAttribute("viewBox");
        var viewBoxWidth = viewBoxVal.split(",")[2];
        var viewBoxHeight = viewBoxVal.split(",")[3];
        rootSvg.removeAttribute("width");
        rootSvg.removeAttribute("height");

        var setWidth = windowWidth;
        var setHeight = (setWidth * viewBoxHeight) / viewBoxWidth;
        rootSvg.setAttribute("width", setWidth);
        rootSvg.setAttribute("height", setHeight);
    }
    function adjustToNone(rootSvg) {

        var viewBoxVal = rootSvg.getAttribute("viewBox");
        var viewBoxWidth = viewBoxVal.split(",")[2];
        var viewBoxHeight = viewBoxVal.split(",")[3];
        rootSvg.removeAttribute("width");
        rootSvg.removeAttribute("height");

        rootSvg.setAttribute("width", viewBoxWidth);
        rootSvg.setAttribute("height", viewBoxHeight);

    }
    function adjustToFreezeHeight(rootSvg) {

        var windowHeight = $(window).height();

        var viewBoxVal = rootSvg.getAttribute("viewBox");
        var viewBoxWidth = viewBoxVal.split(",")[2];
        var viewBoxHeight = viewBoxVal.split(",")[3];
        rootSvg.removeAttribute("width");
        rootSvg.removeAttribute("height");

        var setHeight = windowHeight;
        var setWidth = (setHeight * viewBoxWidth) / viewBoxHeight;
        rootSvg.setAttribute("width", setWidth);
        rootSvg.setAttribute("height", setHeight);
    }
    function adjustToFreezeAll(rootSvg) {
        var windowHeight = $(window).height();
        var windowWidth = $(window).width();

        rootSvg.removeAttribute("width");
        rootSvg.removeAttribute("height");

        rootSvg.setAttribute("width", windowWidth);
        rootSvg.setAttribute("height", windowHeight);

    }
    function zoom(obj, svgid) {
        // 此处获取的元素Id是SVG文件中的<g>标签的id值
        $(obj.getSVGDocument().getElementById(svgid)).show();
        svgPanZoom(obj, {
            zoomEnabled: true, //开启缩放功能
            controlIconsEnabled: true //开启右下角缩放控件功能
        });
    }
    function number_format(number, decimals, dec_point, thousands_sep, roundtag) {
        return parseFloat(number).toFixed(decimals);
}
//判断字符串是否数值
function isNumber(val) {
    var regPos = /^\d+(\.\d+)?$/; //非负浮点数
    var regNeg = /^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$/; //负浮点数
    if (regPos.test(val) || regNeg.test(val)) {
        return true;
    } else {
        return false;
    }
}
    //计算饼图的指示线位置
    function  GetIndexLabelPos(startAngle, currentRate,PiePosition)
        {
             
        var cPoint =  {X:PiePosition.X + PiePosition.Width / 2, Y:PiePosition.Y + PiePosition.Height / 2};
    var relativeCurrentX = PiePosition.Width / 2 * Math.cos((360 - startAngle - currentRate / 2) * Math.PI / 180);
    var relativecurrentY = PiePosition.Height / 2 * Math.sin((360 - startAngle - currentRate / 2) * Math.PI / 180);
    var currentX = relativeCurrentX + cPoint.X;
    var currentY = cPoint.Y - relativecurrentY;
    //内圆上弧上的 浮点型坐标               
    var currentPoint =  {X:parseFloat(currentX),Y: parseFloat(currentY)};
    //外圆弧上的点          
    var largerRX = PiePosition.Width / 2 + 15;
    var largerRY = PiePosition.Height / 2 + 15;
    var relativeLargerX = largerRX * Math.cos((360 - startAngle - currentRate / 2) * Math.PI / 180);
    var relativeLargerY = largerRY * Math.sin((360 - startAngle - currentRate / 2) * Math.PI / 180);
    var largerX = relativeLargerX + cPoint.X;
    var largerY = cPoint.Y - relativeLargerY;
    //外圆上弧上的 浮点型坐标                
    var largerPoint =  {X:parseFloat(largerX), Y:parseFloat(largerY)};
    var circleTextPoint =  {X:parseFloat(largerX),Y:parseFloat(largerY)};
    var ToPoint = circleTextPoint;
 
    var line = { From: currentPoint, To: ToPoint, Quadrant:0};
    var px = circleTextPoint.X - currentPoint.X;
    var py = circleTextPoint.Y - currentPoint.Y;
    //在外圆上的点的附近合适的位置 写上说明                
    if (px >= 0 && py >= 0)//第1象限  实际第二象限                
    {
        line.Quadrant = 2;


    }
    if (px <= 0 && py >= 0)//第2象限  实际第三象限                
    {
        line.Quadrant = 3;
    }
    if (px <= 0 && py <= 0)//第3象限  实际第四象限                
    {
        line.Quadrant = 4;

    }
    if (px >= 0 && py <= 0)//第4象限  实际第一象限               
    {
        line.Quadrant = 1;

    }
      
    line.From = currentPoint;
    line.To = ToPoint;

    //象限差异解释：在数学中 二维坐标轴中 右上方 全为正，在计算机处理图像时，右下方全为正。相当于顺时针移了一个象限序号                              
    return line;
    }
    ///角度转弧度
    function ConvertDegreesToRadians(degrees) {
        var radians = (3.1415926 / 180) * degrees;
        return (radians);
    }
///获取文字对应的高度和宽度
    function TextSize(fontSize, fontFamily, text) {
        var span = document.createElement("span");
        var result = {};
        result.width = span.offsetWidth;
        result.height = span.offsetHeight;
        span.style.visibility = "hidden";
        span.style.fontSize = fontSize;
        span.style.fontFamily = fontFamily;
        span.style.display = "inline-block";
        document.body.appendChild(span);
        if (typeof span.textContent != "undefined") {
            span.textContent = text;
        } else {
            span.innerText = text;
        }
        result.width = parseFloat(window.getComputedStyle(span).width) - result.width;
        result.height = parseFloat(window.getComputedStyle(span).height) - result.height;
        return result;
}
//手机端的时候自动横屏