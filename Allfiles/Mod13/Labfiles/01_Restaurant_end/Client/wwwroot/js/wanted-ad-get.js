$(function() {
    $.ajax({
        type: "GET",
        url: "http://localhost:59216/api/Pizzashop/1",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $(".result").text(response);
        },
        error: function (response) {
            alert('An error has occurred');
        }
    });
});
