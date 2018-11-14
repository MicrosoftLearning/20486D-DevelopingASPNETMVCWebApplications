(function () {
    $('input[type="submit"]').attr('disabled', 'disabled');

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
        var user = document.getElementById("inputUserName").value;
        var message = document.getElementById("inputMessage").value;
        connection.invoke("SendMessageAll", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });

    $("input[id^='input']").change(function () {
        var user = document.getElementById("inputUserName").value;
        var message = document.getElementById("inputMessage").value;
        if (user && message) {
            $('input[type="submit"]').removeAttr('disabled');
        } else {
            $('input[type="submit"]').attr('disabled', 'disabled');
        }
    });
})();