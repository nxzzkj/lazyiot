 
             var map_ID4773973801361806794 = new AMap.Map('containerID4773973801361806794', {
             resizeEnable: true, //�Ƿ��ص�ͼ�����ߴ�仯
             zoom:11, //��ʼ����ͼ�㼶
             center: [116.397428, 39.90923] //��ʼ����ͼ���ĵ�
             }); 
            map_ID4773973801361806794.plugin(['AMap.ToolBar'], function() {
                 map_ID4773973801361806794.addControl(new AMap.ToolBar());
            });
  
          //����ı�ǵ㼯��
          var Marks=[];
          //�����ʸ��ͼ����
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
            text:'�ǵ�����',
            anchor:'center', // �����ı����ê��
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
           