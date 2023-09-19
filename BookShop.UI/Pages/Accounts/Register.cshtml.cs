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
    public class RegisterModel : PageModel
    {
        private SignInManager<ApplicationUser> _signInManager;

        public RegisterModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public CreateUser.Request UserInfo { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        public void OnGet()
        {
            Success = true;
        }

        public async Task<IActionResult> OnPost([FromServices] CreateUser createUser)
        {
            
            if (!ModelState.IsValid)
            {
                Success = true;
                return Page();
            }
            Success =  await createUser.Do(UserInfo);
            if (!Success)
            {
                return Page();
            }
            await _signInManager.PasswordSignInAsync(UserInfo.Username, UserInfo.Password, false, false);
            return RedirectToPage("/Index");
        }
        
    }
}
