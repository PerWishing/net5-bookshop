using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Application.ProductsUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.UI.Pages
{
    public class FavoritesModel : PageModel
    {
        public IList<GetFavProducts.ProductViewModel> Products { get; set; }
        public void OnGet([FromServices] GetFavProducts getFavProducts)
        {
            Products = getFavProducts.Do(User.Identity.Name);
        }
    }
}
