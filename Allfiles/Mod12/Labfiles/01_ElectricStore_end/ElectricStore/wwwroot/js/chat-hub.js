(function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

    connection.on("NewMessage", function (user, message) {
        var displayedMessage = user +"'s"+ " message: " + message;
        var li = document.createElement("li");
        li.textContent = displayedMessage;
        document.getElementById("messagesList").appendChild(li);
    });

    connection.start().catch(function (err) {
        return console.error(err.toString());
    });

    document.getElementById("sendMessageBtn").addEventListener("click", function (event) {
        var user = document.getElementById("userName").value;
        var message = document.getElementById("message").value;
        connection.invoke("SendMessageAll", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
})();

