﻿

var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:5001/chatHub").build();


connection.start().catch(err => console.error(err.toString())).then(function () {
    connection.invoke('getConnectionId')
        .then(function (connectionId) {
            // Send the connectionId to controller
            console.log("connectionID: " + connectionId);
            $("#signalRconnectionId").attr("value", connectionId);
        });
});

connection.on("notif", (message) => {

    console.log("message is :" + message);
});


////Disable send button until connection is established
//document.getElementById("sendButton").disabled = true;

//connection.on("ReceiveMessage", function (user, message) {
//    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
//    var encodedMsg = user + " says " + msg;
//    var li = document.createElement("li");
//    li.textContent = encodedMsg;
//    document.getElementById("messagesList").appendChild(li);
//});

//connection.start().then(function () {
//    document.getElementById("sendButton").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});