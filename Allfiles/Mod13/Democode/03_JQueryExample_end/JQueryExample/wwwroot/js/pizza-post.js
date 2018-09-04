$(document).ready(function () {
    $(".btn-post").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: "http://localhost:59216/api/Pizzashop",
            data: JSON.stringify({
                id: 6,
                toppings: "Pineapple",
                price: 10.99
            }),
            contentType: "application/json;charset=utf-8",
            success: function (result) {
                $(".result").text('Ajax result: pizza object added successfully with the following information id ' + result.id + ', toppings: ' + result.toppings + ', price ' + result.price + '$');
            },
            error: function (result) {
                alert('An error has occurred');
            }
        });
    });
});