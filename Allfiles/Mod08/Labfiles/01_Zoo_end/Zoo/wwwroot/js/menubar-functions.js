$(function () {
    var path = window.location.pathname;

    $(".nav li a").each(function (index, value) {
        var href = $(value).attr('href');
        if (path == href) {
            $(this).closest('li').addClass('active');
        }
    });
});
