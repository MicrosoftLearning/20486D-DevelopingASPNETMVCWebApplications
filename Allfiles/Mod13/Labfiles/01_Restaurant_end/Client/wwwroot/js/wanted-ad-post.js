$(function () {
    $("#btn-post").click(function (e) {
        //const form = document.getElementByClassName('.submit-job')[0];
        console.log(formData);
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: "http://localhost:54517/api/job",
            //data: $(form).serializeArray().map(function (item) {
            //    if (config[item.name]) {
            //        if (typeof (config[item.name]) === "string") {
            //            config[item.name] = [config[item.name]];
            //        }
            //        config[item.name].push(item.value);
            //    } else {
            //        config[item.name] = item.value;
            //    }
            //}),
            contentType: "application/json;charset=utf-8",
            success: function (result) {
                alert('ok');
            },
            error: function (result) {
                alert('An error has occurred');
            }
        });
    });
});
