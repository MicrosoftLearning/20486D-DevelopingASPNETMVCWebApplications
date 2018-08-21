var images = ['/images/header.jpg', '/images/waters.jpg'];
var current = 0;

function nextImage() {
    current++;
    if (current === images.length) {
        current = 0;
    }
    $('.header-container').css('background-image', 'url(' + images[current] + ')');
}

function prevImage() {
    current--;
    if (current < 0) {
        current = images.length-1;
    }
    $('.header-container').css('background-image', 'url(' + images[current] + ')');
}

