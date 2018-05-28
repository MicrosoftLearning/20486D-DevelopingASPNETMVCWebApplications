//$(function () {
//    $("select").change(function () {
//        var str = "";
//        $("select option:selected").each(function (index, value) {
//            if (str != "0") {
//                str += $(value).val() + " ";
//            }
//        });
//        var row = $("<tr>");
//        row.append($("<td>").html(str));
//        $("#totalAmount").append(row);
//    })
//        .trigger("change");
//});


$(function () {
    $("#select").change(function () {
        var quan = $("#adultQuantity option:selected").text();

    }).trigger("change");

});