$(function () {
    $("#btn-post").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: "http://localhost:54517/api/job",
            data: JSON.stringify($('#submit-job').serializeArray()),
            contentType: "application/json;charset=utf-8",
            success: function (result) {
                alert(result);
            },
            error: function (result) {
                alert('An error has occurred');
            }
        });
    });
});
