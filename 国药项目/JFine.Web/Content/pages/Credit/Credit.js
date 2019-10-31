//查看相似度
function openSim(id) {
    var pageii = layer.open({
        title: [
            '积分相似列表',
            'background-color:#FF9900; color:#fff;'
        ]
        , topClose: true
        , topClosePos: 'right'
       , type: 1
      , content: '<iframe src="/Credit/Credit/JFSimiList?JFId=' + id + '" width="100%" height="100%" frameborder="0">'
      , anim: 'up'
      , style: 'position:fixed; left:0; top:0; width:100%; height:100%; border: none; -webkit-animation-duration: .5s; animation-duration: .5s;'
    });
}