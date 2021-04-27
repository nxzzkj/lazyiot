layui.define(["jquery"], function (exprots) {
    var $ = layui.jquery;

    function GVerify(options) {
        this.options = {
            id: "",
            canvasId: "verifyCanvas",
            width: "100",
            height: "30",
            type: "blend",
            code: ""
        };

        if (Object.prototype.toString.call(options) == "[object Object]") {
            for (var i in options) {
                this.options[i] = options[i];
            }
        } else {
            this.options.id = options;
        }

        this.options.numArr = "0,1,2,3,4,5,6,7,8,9".split(",");
        this.options.letterArr = getAllLetter();

        this._init();
        this.refresh();
    }

    GVerify.prototype = {
        version: '1.0.0',

        _init: function () {
            var con = $(this.options.id);
            var canvas = document.createElement("canvas");
            this.options.width = con.outerWidth() > 0 ? con.outerWidth() : "100";
            this.options.height = con.outerHeight() > 0 ? con.outerHeight() : "30";
            canvas.id = this.options.canvasId;
            canvas.width = this.options.width;
            canvas.height = this.options.height;
            canvas.style.cursor = "pointer";
            canvas.innerHTML = "您的浏览器版本不支持canvas";
            con.append(canvas);
            var parent = this;

            canvas.onclick = function () {
                parent.refresh();
            }
        },

        refresh: function () {
            this.options.code = "";
            var canvas = document.getElementById(this.options.canvasId);
            if (canvas.getContext) {
                var ctx = canvas.getContext('2d');
            } else {
                return;
            }

            ctx.textBaseline = "middle";

            ctx.fillStyle = randomColor(180, 240);
            ctx.fillRect(0, 0, this.options.width, this.options.height);

            if (this.options.type == "blend") {
                var txtArr = this.options.numArr.concat(this.options.letterArr);
            } else if (this.options.type == "number") {
                var txtArr = this.options.numArr;
            } else {
                var txtArr = this.options.letterArr;
            }

            for (var i = 1; i <= 4; i++) {
                var txt = txtArr[randomNum(0, txtArr.length)];
                this.options.code += txt;
                ctx.font = randomNum(this.options.height / 2, this.options.height) + 'px SimHei';
                ctx.fillStyle = randomColor(50, 160);
                ctx.shadowOffsetX = randomNum(-3, 3);
                ctx.shadowOffsetY = randomNum(-3, 3);
                ctx.shadowBlur = randomNum(-3, 3);
                ctx.shadowColor = "rgba(0, 0, 0, 0.3)";
                var x = this.options.width / 5 * i;
                var y = this.options.height / 2;
                var deg = randomNum(-30, 30);
                ctx.translate(x, y);
                ctx.rotate(deg * Math.PI / 180);
                ctx.fillText(txt, 0, 0);
                ctx.rotate(-deg * Math.PI / 180);
                ctx.translate(-x, -y);
            }
            for (var i = 0; i < 4; i++) {
                ctx.strokeStyle = randomColor(40, 180);
                ctx.beginPath();
                ctx.moveTo(randomNum(0, this.options.width), randomNum(0, this.options.height));
                ctx.lineTo(randomNum(0, this.options.width), randomNum(0, this.options.height));
                ctx.stroke();
            }
            for (var i = 0; i < this.options.width / 4; i++) {
                ctx.fillStyle = randomColor(0, 255);
                ctx.beginPath();
                ctx.arc(randomNum(0, this.options.width), randomNum(0, this.options.height), 1, 0, 2 * Math.PI);
                ctx.fill();
            }
        },

        validate: function (code) {
            var code = code.toLowerCase();
            var v_code = this.options.code.toLowerCase();
            if (code == v_code) {
                return "true";
            } else {
                return "验证码不正确，请重新输入";
            }
        },
    };

    function getAllLetter() {
        var letterStr = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
        return letterStr.split(",");
    }

    function randomNum(min, max) {
        return Math.floor(Math.random() * (max - min) + min);
    }

    function randomColor(min, max) {
        var r = randomNum(min, max);
        var g = randomNum(min, max);
        var b = randomNum(min, max);
        return "rgb(" + r + "," + g + "," + b + ")";
    }

    exprots("okGVerify", GVerify);
});

