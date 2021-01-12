using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using ServerSign.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebSignal.Hubs;

namespace ServerSign.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ChatHub chatHub;
      

        public HomeController(ILogger<HomeController> logger, ChatHub chatHub)
        {
            _logger = logger;
            this.chatHub = chatHub;
           
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> Test()
        {
            //if (!string.IsNullOrEmpty(Connection.Id))
            //{
            //    await chatHub.Clients.Client(Connection.Id).SendAsync("notif","Hello from server");
            //}

            //await chatHub.SendMessage(Connection.Id, "notif", "Hello from server");


            // await chatHub.Clients.Client(Connection.Id).SendAsync("notif","Hellow");

            //var url = HttpContext.Request.Host.Value.ToString() + "/chathub";

            var url = "https://localhost:5001/chathub";
           

            Console.WriteLine("Url is :" + url);


            var connection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();
            await connection.StartAsync();

            await connection.InvokeAsync("SendMessage", Connection.Id, "notif", "hello");


            return Json("ok");
        }
    }
}
