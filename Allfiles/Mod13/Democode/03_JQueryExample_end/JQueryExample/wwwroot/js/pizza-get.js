$(document).ready(function () {
    $(".btn-get").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: "GET",
            url: "http://localhost:59216/api/Pizzashop/1",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $(".result").text('Ajax Result: you ordered pizza with ' + response.toppings + ' for ' + response.price + '$');
            },
            error: function (response) {
                alert('An error has occurred');
            }
        });
    });
});


