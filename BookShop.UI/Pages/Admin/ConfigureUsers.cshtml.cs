using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Application.Users;
using BookShop.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.UI.Pages.Admin
{
    public class ConfigureUsersModel : PageModel
    {
        private SignInManager<ApplicationUser> _signInManager;

        public ConfigureUsersModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public CreateUser.Request UserInfo { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public bool SuccessRole { get; set; }

        public void OnGet()
        {
            Success = true;
            SuccessRole = true;
        }

        public async Task<IActionResult> OnPost([FromServices] CreateUser createUser)
        {

            if (!ModelState.IsValid)
            {
                Success = true;
                SuccessRole = true;
                return Page();
            }
            Success = await createUser.Do(UserInfo);
            SuccessRole = await createUser.GiveAdmin(UserInfo.Username);
            
            if (!Success || !SuccessRole)
            {
                return Page();
            }
            return RedirectToPage("/User");
        }
    }
}
