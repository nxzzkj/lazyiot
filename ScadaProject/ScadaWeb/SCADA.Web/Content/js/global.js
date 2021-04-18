Date.prototype.Format = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
};
function showDate(str) {
    if (str == '/Date(-62135596800000)/') return '';
    var d = eval('new ' + str.substr(1, str.length - 2)); //new Date()
    return d.Format("yyyy-MM-dd hh:mm:ss");
}
function showIcon(icon) {
    return "<i class='ok-icon'>" + icon + "</i>";
}
function openSetIcon() {
    layer.open({
        title: '选择图标',
        type: 2,
        area: ['100%', '100%'],
        fixed: false, //不固定
        maxmin: true,
        content: '/Icon.html'
    });
}