$(document).ready(function () {
    $(".btn-post").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: "http://localhost:59216/api/Pizza",
            data: JSON.stringify({
                id: 6,
                toppings: "pineapple",
                price: 10.99
            }),
            contentType: "application/json;charset=utf-8",
            success: function (result) {
                $(".result").text('Ajax result: pizza object was added successfully with id number ' + result.id + ', and ' + result.toppings + ' topping for the price of ' + result.price + '$');
            },
            error: function (result) {
                alert('An error has occurred');
            }
        });
    });
});