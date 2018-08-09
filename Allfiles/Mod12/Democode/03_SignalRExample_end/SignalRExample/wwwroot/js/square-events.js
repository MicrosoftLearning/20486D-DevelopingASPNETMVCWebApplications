

function onButtonClick(btn) {
    var x = $(btn).data('assigned-x');
    var y = $(btn).data('assigned-y');
    $(btn).toggleClass('blue red');
}