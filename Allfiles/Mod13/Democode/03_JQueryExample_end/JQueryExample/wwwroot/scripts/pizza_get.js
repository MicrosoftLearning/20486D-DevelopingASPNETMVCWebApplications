$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "http://localhost:59216/api/Pizzashop/1",
        contentType: "application/json",
        dataType: "json",
        success: function (response) {
            
        },
        failure: function (response) {
            
        }
    });
});