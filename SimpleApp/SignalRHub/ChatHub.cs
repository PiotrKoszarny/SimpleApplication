using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SimpleApp.Models;

namespace SimpleApp.SignalRHub
{
    public interface IChatHubClient
    {
        Task BroadcastMessage(Message message);
    }

    public class ChatHub : Hub<IChatHubClient>
    {
        public Task Send(Message message)
        {
            return Clients.All.BroadcastMessage(message);
        }
    }
}
