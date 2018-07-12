$(function () {
    $('#IceCreamFlavors').change(function (event) {
        var target = $(event.target);
        var value = parseInt(target.val());
        if (value) {
            var amount = parseInt($("#iceCreamAmout").val());
            var calc = (amount * value);
            //need to add meaning after the selected one to know its price
        }
    });
});
