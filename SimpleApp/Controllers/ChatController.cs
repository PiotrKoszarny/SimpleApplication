using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SimpleApp.Models;
using SimpleApp.SignalRHub;

namespace SimpleApp.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub, IChatHubClient> _hubContext;

        public ChatController(
            IHubContext<ChatHub, IChatHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost,Route("chat-hub")]
        public async Task<IActionResult> Post(Message message)
        {
            await _hubContext.Clients.All.BroadcastMessage(message);

            return Ok();
        }
    }
}