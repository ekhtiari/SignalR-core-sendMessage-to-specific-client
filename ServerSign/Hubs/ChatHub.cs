using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerSign.Models;

namespace WebSignal.Hubs
{
    public class ChatHub : Hub
    {

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }


        public async Task SendMessage(string clientId, string command, string message)
        {
            //await Clients.All.SendAsync("ReceiveMessage", "Iman", "test");
            await Clients.Client(clientId).SendAsync(command, message);

        }


        public override Task OnConnectedAsync()
        {
            var q = Context.ConnectionId;
            if (string.IsNullOrEmpty(Connection.Id))
            {
                Connection.Id = q;
            }
            Console.WriteLine("connection id is :" + q);
            return base.OnConnectedAsync();
        }
    }
}
