$(function () {
    $('#adultQuantity').change(function (eventObj) {
        var selected_value = $('#adultQuantity').val();
        if (selected_value == '0') {
            selected_value = '';
        } else {
            //$(".hidden-div").addClass("display-div").removeClass("hidden-div");
            var msg = "Adult ticket - " + selected_value;
            var cost = $("#adultCost").text();
            var correctCost = (cost.substring(0, cost.length -1));
            var calc = parseFloat(selected_value * correctCost);
            var row = $("<tr>");
            row.append($("<td>").html(msg));
            row.append($("<td>").html(calc + "$"));
            $("#totalAmount").append(row);
        }
    });
});