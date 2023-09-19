using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Application.Cart;
using BookShop.Application.Orders;
using BookShop.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.UI.Pages.Checkout
{
    public class CustomerInformationModel : PageModel
    {
       
        [BindProperty]
        public CreateOrder.Request CustomerInformation { get; set; }
        [BindProperty]
        public Application.Products.GetProduct.ProductViewModel Product { get; set; }
       
        public async Task<IActionResult> OnGet(int id,[FromServices] Application.Products.GetProduct getProduct)
        {
            Product = await getProduct.Do(id);
            return Page();
            
        }

        public async Task<IActionResult> OnPost(int id,[FromServices] CreateOrder createOrder,
            [FromServices] Application.Products.GetProduct getProduct)
        {
            Product = await getProduct.Do(id);

            if (!ModelState.IsValid)
            {

                return Page();
            }
            CustomerInformation.CustomerName = User.Identity.Name;
            CustomerInformation.ProductId = id;
            CustomerInformation.SellerName = Product.Seller;
            await createOrder.Do(CustomerInformation);
            return Redirect("~/User/OrderManagement");
        }
    }
}
