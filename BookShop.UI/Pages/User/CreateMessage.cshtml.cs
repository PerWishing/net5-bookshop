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
    public class CreateMessageModel : PageModel
    {
        [BindProperty]
        public MessageService.Request MessageInput { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public GetUserPublic.Response UserPublicInfo { get; set; }
        public void OnGet(string name)
        {
            Username = name;
            
        }
        public async Task<IActionResult> OnPostForCreate(int id, string name, [FromServices] MessageService messageService)
        {

            MessageInput.Sender = User.Identity.Name;
            

            //Влидация текста сообщения
            //var validator = new CreateReviewValidation();
            //var result = validator.Validate(ReviewInput);

            //if (!result.IsValid)
            //{
            //    Order = getOrder.Do(id);
            //    return Page();
            //}

            await messageService.CrateMessage(MessageInput);

            return Redirect($"~/Order/{id}");

        }
    }
}
