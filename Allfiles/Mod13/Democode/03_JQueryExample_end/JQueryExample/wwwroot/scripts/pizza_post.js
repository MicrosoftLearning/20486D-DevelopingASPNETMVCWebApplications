$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "http://localhost:59216/api/Pizzashop/post",
        
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            
        },
        failure: function (response) {
            
        }
    });
});