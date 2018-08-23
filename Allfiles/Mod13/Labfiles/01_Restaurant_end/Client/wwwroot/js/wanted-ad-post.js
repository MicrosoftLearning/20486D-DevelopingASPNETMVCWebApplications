$(function () {
    $(".btn-post").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: "http://localhost:54517/api/RestaurantWantedAd",
            data: $('#myForm').serialize(),
            contentType: "application/json;charset=utf-8",
            success: function (result) {
                $(".result").text(result);
            },
            error: function (result) {
                alert('An error has occurred');
            }
        });
    });
});
