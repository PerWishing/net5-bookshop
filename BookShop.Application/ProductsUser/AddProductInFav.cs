using BookShop.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.ProductsUser
{
    [Service]
    public class AddProductInFav
    {
        private IUserManager _userManager;

        public AddProductInFav(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public class Request
        {
            public string Username { get; set; }
            public int ProductId { get; set; }
        }

        public async Task<bool> Check(Request request)
        {
            var success = await _userManager.CheckProductInFav(request.Username, request.ProductId);
            if (success)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(Request request)
        {
            var success = await _userManager.DeleteProductFromFav(request.Username, request.ProductId);
            if (success)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Do(Request request)
        {
            var success = await _userManager.AddProductInFav(request.Username, request.ProductId);
            if (success)
            {
                return true;
            }
            return false;
        }
    }
}
