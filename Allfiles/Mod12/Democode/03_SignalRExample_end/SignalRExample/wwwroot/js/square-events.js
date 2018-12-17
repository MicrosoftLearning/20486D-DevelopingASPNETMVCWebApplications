var connection = new signalR.HubConnectionBuilder()
    .withUrl("squareshub")
    .build();

connection.on("SwapSquareColor", (x, y) => {
    $('#' + x + y).toggleClass('blue red');
});

connection.start();

function onButtonClick(btn) {
    var x = $(btn).data('assigned-x');
    var y = $(btn).data('assigned-y');
    $(btn).toggleClass('blue red');
    connection.invoke("SwapColor", x, y);
}