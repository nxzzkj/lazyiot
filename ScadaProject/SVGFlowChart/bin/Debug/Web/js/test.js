 
             var map_ID4773973801361806794 = new AMap.Map('containerID4773973801361806794', {
             resizeEnable: true, //是否监控地图容器尺寸变化
             zoom:11, //初始化地图层级
             center: [116.397428, 39.90923] //初始化地图中心点
             }); 
            map_ID4773973801361806794.plugin(['AMap.ToolBar'], function() {
                 map_ID4773973801361806794.addControl(new AMap.ToolBar());
            });
  
          //定义的标记点集合
          var Marks=[];
          //定义的矢量图集合
          var Shapes=[];
  var markM5710923645277142479=  new AMap.Marker({
            id:'M5710923645277142479',
            iovalue:'',
            iovisible:'',
            iocolor:'',
            icon: 'images/Point.png',
            position: [116.397428,39.90923],
            style:{
            'padding': '.75rem 1.25rem',
            'margin-bottom': '1rem',
            'border-radius': '.25rem',
            'background-color': 'white',
            'width': '15rem',
            'border-width': 0,
            'box-shadow': '0 2px 6px 0 rgba(114, 124, 245, .5)',
            'text-align': 'center',
            'font-size': '20px',
            'color': 'blue'
        },
            offset:  new AMap.Pixel(-13, -13)
           }).setMap(map_ID4773973801361806794);
           Marks.push(markM5710923645277142479);
            var markM5683469154678637727=  new AMap.Text({
            id:'M5683469154678637727',
            iovalue:'',
            iovisible:'',
            iocolor:'',
            enableiovalue:'false',
            text:'是的撒多',
            anchor:'center', // 设置文本标记锚点
            draggable:'true',
            cursor:'pointer',
            angle:0,
            position: [116.397428,39.90923],
            style:{
            'padding': '.75rem 1.25rem',
            'margin-bottom': '1rem',
            'border-radius': '.25rem',
            'background-color': 'white',
            'width': '15rem',
            'border-width': 0,
            'box-shadow': '0 2px 6px 0 rgba(114, 124, 245, .5)',
            'text-align': 'center',
            'font-size': '20px',
            'color': 'blue'
        },
            offset:  new AMap.Pixel(-13, -13)
           });
           markM5683469154678637727.setMap(map_ID4773973801361806794);
           Marks.push(markM5683469154678637727);
           