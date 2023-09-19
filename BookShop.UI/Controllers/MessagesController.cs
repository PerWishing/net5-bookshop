using BookShop.Application.Messages;
using BookShop.Application.Users;
using BookShop.UI.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.UI.Controllers
{
    [Route("[controller]")]
    public class MessagesController : Controller
    {
        private IHubContext<ChatHub> _hubContext;

        public MessagesController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetMessageByRecAndStat([FromServices] MessageService messageService, [FromServices] GetUserPublic getUserPublic)
        {
            var result = messageService.GetMessagesByRecipientByStatus(User.Identity.Name,0);
            return Ok(result);

        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetMessageBySenAndRec(string name,
            [FromServices] MessageService messageService, [FromServices] GetUserPublic getUserPublic)
        {
            GetUserPublic.Response result = await getUserPublic.GetPublicUser(User.Identity.Name);
            var items = new List<MessageService.Response>(messageService.GetMessagesBySenderAndRecipient(User.Identity.Name, name));
            foreach (var i in items)
            {
                i.Avatar = result.Avatar;
            }
            result = await getUserPublic.GetPublicUser(name);
            var items2 = messageService.GetMessagesBySenderAndRecipient(name, User.Identity.Name);
            foreach (var i in items2)
            {
                i.Avatar = result.Avatar;
            }
            items.AddRange(items2);
            return Ok(items.OrderBy(m => m.DateOfSend).ToList());
            
        }

        [HttpPost("{name}")]
        public async Task<IActionResult> CreateMessage(string name, IFormFile image, [FromBody] MessageService.Request request,
           [FromServices] MessageService createMessage, [FromServices] GetUserPublic checkAdmin) 
        {
            //await _hubContext.Clients.All.SendAsync("Notify", name);
            if (await checkAdmin.CheckRole(User.Identity.Name)){
                request.UserOrAdmin = 1;
            }
            else
            {
                request.UserOrAdmin = 0;
            }
            request.Sender = User.Identity.Name;
            request.Recipient = name;
            request.Status = 0;
            request.Image = image;
            request.DateOfSend = DateTime.Now;

            return Ok(await createMessage.CrateMessage(request));
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateMessageStatus([FromBody] MessageService.Request request,
           [FromServices] MessageService messageService)
        {
            var items = (List<MessageService.Response>)messageService.GetMessagesBySenderAndRecipient(request.Sender, User.Identity.Name);
            
            foreach (var i in items)
            {
                if(i.Status == 0)
                {
                    await messageService.UpdateMessage(i.Id, 1);
                }
            }
            
            return Ok(true);
        }
    }
}
