using BookShop.Domain.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using BookShop.Database;

namespace BookShop.Application.Users
{
    [Service]
    public class CreateUser
    {
        private IUserManager _userManager;

        public CreateUser(IUserManager userManager)
        {
            _userManager = userManager;
            
        }

        public class Request
        {
            public string Username{ get; set; }//Поля для валидации
            public string Password{ get; set; }
            public string Email{ get; set; }
        }

        public async Task<bool> Do(Request request)
        {
            var success = await _userManager.CreateManagerUser(request.Username, 
                request.Password, request.Email);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> GiveAdmin(string username)
        {
            return await _userManager.GiveRole(username);
        }
    }
}
