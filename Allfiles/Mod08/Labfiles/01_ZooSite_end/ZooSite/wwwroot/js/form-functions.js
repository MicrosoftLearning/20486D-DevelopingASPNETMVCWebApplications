
$(function() {
    $('.pricing select').change(function(event) {
        var target = $(event.target);
        var value = parseInt(target.val());
        var container = target.parent();
        var price = container.prev();
        var label = price.prev();

        $("#" + label.text()).remove();

        if (value) {
            $("#summery").addClass("display-div").removeClass("hidden-div");

            var correctCost = (price.text().substring(1, price.text().length));
            var calc = parseInt(value * correctCost);

            var msg = label.text() + " ticket - " + value.toString() + "x" + price.text() + " = <span class='sum'>" +'$' + calc + '</span>';
            var row = $("<tr id='" + label.text() + "'>");
            row.append($("<td>").html(msg));
            $("#totalAmount").append(row);
        }
        if ($("#totalAmount tr").length === 0) {
            $("#summery").addClass("hidden-div").removeClass("display-div");
            $("#formButtons input").attr('disabled', 'disabled');
            $("#comment").show();
        } 
        else {
            $("#formButtons input").removeAttr('disabled');
            $("#comment").hide();
        }

        calculateSum();
    });

    function calculateSum() {
        var rows = document.querySelectorAll("#totalAmount tr .sum");
        var sum = 0;

        for (var i = 0; i < rows.length; i++) {
            sum = sum + parseFloat(parseFloat(rows[i].innerHTML.substring(1, rows[i].innerHTML.length)).toFixed(2));
        }

        document.getElementById("sum").innerHTML = "Total: $" + sum;
    }
});