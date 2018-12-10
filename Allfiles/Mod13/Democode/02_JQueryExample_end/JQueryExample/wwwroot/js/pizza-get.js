$(function () {
    $(".btn-get").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: "GET",
            url: "http://localhost:59216/api/Pizza/1",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (response) {
            $(".result").text('Information for pizza with id 1: ' + 'has the following toppings ' + response.toppings + ' for the price of ' + response.price + '$');
        }).fail(function () {
            alert('An error has occurred');
        });
    });
});


