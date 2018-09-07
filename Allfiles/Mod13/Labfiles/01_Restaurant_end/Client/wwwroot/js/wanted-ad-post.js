$(function() {
    $("#btn-post").click(function (e) {
        var formData = {};
        $('#submit-form').serializeArray().map(function (item) {
            item.name = item.name[0].toLowerCase() + item.name.slice(1);
            if (formData[item.name]) {
                if (formData[item.name] === "string") {
                    formData[item.name] = [formData[item.name]];
                }
                formData[item.name].push(item.value);
            } else {
                formData[item.name] = item.value;
            }
        });
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: "http://localhost:54517/api/job",
            data: JSON.stringify(formData),
            contentType: "application/json;charset=utf-8",
            success: function() {
                location.href = 'http://localhost:54508/JobApplication/ThankYou';
            },
            error: function (result) {
                alert('An error has occurred');
            }
        });
    });
});
