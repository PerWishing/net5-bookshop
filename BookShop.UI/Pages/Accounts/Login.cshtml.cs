using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Application.Users;
using BookShop.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.UI.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        private SignInManager<ApplicationUser> _signInManager;

        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [BindProperty]
        public LoginViewModel Input { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public bool Block { get; set; }
        public void OnGet()
        {
            Success = true;
        }
        public async Task<IActionResult> OnPost([FromServices] GetUserPublic getUserPublic)
        {
            if (!ModelState.IsValid)
            {
                Success = true;
                return Page();
            }
            var userInfo = await getUserPublic.GetPublicUser(Input.Username);
            if (userInfo.Blocked == 1)
            {
                Success = true;
                Block = true;
            }
            else
            {
                Block = false;
            }
            if (Block)
            {
                return Page();
            }
            
            var result = await _signInManager.PasswordSignInAsync(Input.Username,
                Input.Password,false,false);
            Success = result.Succeeded;

            if (Success)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }

        public class LoginViewModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
