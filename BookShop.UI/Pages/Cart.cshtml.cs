using System.Collections.Generic;
using BookShop.Application.Cart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.UI.Pages
{
    public class CartModel : PageModel
    {
 
        public IEnumerable<GetCart.Response> Cart { get; set; }

        public IActionResult OnGet([FromServices] GetCart getCart)
        {
            Cart = getCart.Do();

            return Page();
        }
    }
}
