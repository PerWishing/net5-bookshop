using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Application.Messages;
using BookShop.Application.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.UI.Pages.User
{
    public class MessageManagerModel : PageModel
    {
        [BindProperty]
        public IEnumerable<MessageService.Response> MessageInfo { get; set; }
        public async Task<IActionResult> OnGet([FromServices] MessageService messageService, [FromServices] GetUserPublic getUserPublic)
        {
            GetUserPublic.Response result = await getUserPublic.GetPublicUser(User.Identity.Name);
            var items = new List<MessageService.Response>(messageService.GetDialogsByUser(User.Identity.Name));
            
            MessageInfo = items.OrderByDescending(m => m.DateOfSend).ToList();
            return Page();
        }
    }
}
