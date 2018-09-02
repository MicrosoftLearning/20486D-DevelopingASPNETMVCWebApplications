$(function() {
    $(".alert").hide();

    $("button").click(function () {
        $(".alert").show();
    });

    $('.close').on('click', function () {
        $(".alert").hide();
    });
});

