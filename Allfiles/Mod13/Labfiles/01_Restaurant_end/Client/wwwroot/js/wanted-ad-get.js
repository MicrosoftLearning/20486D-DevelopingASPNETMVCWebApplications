$(function() {
    $.ajax({
        type: "GET",
        url: "http://localhost:54517/api/RestaurantWantedAd",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function (index,item) {
                $('<tr>').html(
                    $('td').text(item.minimumAge),
                    $('td').text(item.job),
                    $('td').text(item.pricePerHour),
                    $('td').text(item.jobDescription)
                ).appendTo('#info');
            });
        },
        error: function () {
            alert('An error has occurred');
        }
    });
});


//<div class="container">
//    <div class="photo-index-card">
//        <div class="image-wrapper">
//            <img class="photo-display-img" src="~/images/white-plate.jpg" />
//        </div>
//        <div class="display-picture-title">
//        </div>
//    </div>
//</div>

