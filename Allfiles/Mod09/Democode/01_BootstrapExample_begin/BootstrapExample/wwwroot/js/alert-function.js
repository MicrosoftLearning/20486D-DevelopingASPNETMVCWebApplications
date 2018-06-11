$(function () {
    $(".alert").hide();

    $("button").click(function () {
        $(".alert").show();
    });

    $('.alert').on('closed.bs.alert', function () {
        $(".alert").alert('close');
    });
});

