$(function () {
    $(".btn-post").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: "http://localhost:59216/api/Pizza",
            data: JSON.stringify({
                toppings: "pineapple",
                price: 10.99
            }),
            contentType: "application/json;charset=utf-8"
        }).done(function (result) {
            $(".result").text('Ajax result: pizza object was added successfully with id number ' + result.id + ', and ' + result.toppings + ' topping for the price of ' + result.price + '$');
        }).fail(function () {
            alert('An error has occurred');
        });
    });
});