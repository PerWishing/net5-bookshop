using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Application.ProductsUser;
using BookShop.Application.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.UI.Pages.User
{
    public class IndexModel : PageModel
    {
        public IEnumerable<GetProducts.ProductViewModel> Products { get; set; }
        public GetPublicUsers.IndexViewModel Users { get; set; }
        public void OnGet(string name, [FromServices] GetProducts getProducts, [FromServices] GetPublicUsers getPublicUsers)
        {
            Products = getProducts.Do(User.Identity.Name);
        }
    }
}
