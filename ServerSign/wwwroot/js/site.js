﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//connection.start().then().catch(function (err) {
//    return console.error(err.toString());
//});



function Call() {

    $.ajax({
        url: '/Home/Test',
        success: function (e) {
            $("#result").text(e);
        }
    })


}