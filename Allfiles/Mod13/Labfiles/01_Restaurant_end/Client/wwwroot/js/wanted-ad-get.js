$(function () {
    $.ajax({
        type: "GET",
        url: "http://localhost:54517/api/RestaurantWantedAd",
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).done(function () {
        $.each(data, function (index, item) {
            var html = `<div class="photo-index-card-data">
                                  <div class="image-wrapper">
                                        <img class="photo-display-img" src="~/images/white-plate.jpg" />
                                  </div>
                                  <div class="display-picture-data">
                                        <h6 class="display-title">Job Title:</h6>
                                        <h6>${item.jobTitle}</h6>
                                        <h6 class="display-title">Hourly payment:</h6>
                                        <h6>$${item.pricePerHour}</h6>
                                        <h6 class="display-title">Job Description:</h6>
                                        <h6>${item.jobDescription}</h6>
                                  </div>
                             </div>`;
            $('.container').append(html);
        });
        $('.photo-display-img').attr('src', '/images/white-plate.jpg');
    }).fail(function () {
        alert('An error has occurred');
    });
});




