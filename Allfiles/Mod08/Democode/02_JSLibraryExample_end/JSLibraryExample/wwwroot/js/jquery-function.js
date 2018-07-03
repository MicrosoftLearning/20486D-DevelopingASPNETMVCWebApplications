var value = 300;
$(function () {
    $('button').click(function () {
        $('.box')
            .animate({ width: '+=' + value + 'px'})
            .animate({ height: '+=' + value + 'px' })
            .animate({ marginLeft: ($(window).width() - ($('.box').width() + value)) / 2 + 'px' })
            .animate({ borderWidth: '10px'})
            .animate({ opacity: 0.5 });
    });
});