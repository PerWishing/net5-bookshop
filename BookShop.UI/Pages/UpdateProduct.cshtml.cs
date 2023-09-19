using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Application.Cart;
using BookShop.Application.Products;
using BookShop.Application.ProductsUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.UI.Pages
{
    public class UpdateProductModel : PageModel
    {

        [BindProperty]
        public AddToCart.Request CartViewModel { get; set; }
        [BindProperty]
        public bool CanEdit { get; set; }
        [BindProperty]
        public bool Succes { get; set; }
        public Application.Products.GetProduct.ProductViewModel Product { get; set; }
        [BindProperty]
        public UpdateProduct.Request ProductInfo { get; set; }

        public async Task<IActionResult> OnGet(int id, [FromServices] Application.Products.GetProduct getProduct,
            [FromServices] IAuthorizationService authService)
        {
            Succes = true;
            Product = await getProduct.Do(id);
            if (Product.Seller == User.Identity.Name || (await authService.AuthorizeAsync(User, "Admin")).Succeeded)
            {
                CanEdit = true;
            }
            else
                return RedirectToPage("Index");

            if (Product == null)
                return RedirectToPage("Index");
            else
                return Page();
        }

        public async Task<IActionResult> OnPostForUpdate(int id, IFormFile image, [FromServices] UpdateProduct updateProduct,
            [FromServices] Application.Products.GetProduct getProduct)
        {
            Succes = true;
            ProductInfo.Id = id;

            if (!ModelState.IsValid)
            {
                Succes = false;
                Product = await getProduct.Do(id);//Для валидации
                return Page();
                //return Redirect($"~/UpdateProduct/{id}");
            }

            ProductInfo.Image = image;
            await updateProduct.Do(ProductInfo);

            return Redirect($"~/Product/{id}");
        }
        public async Task<IActionResult> OnPostForDelete(int id, [FromServices] UpdateProduct updateProduct)
        {
            await updateProduct.UpdateAvailable(id, 1);

            return Redirect($"~/User/Index");
        }
    }
}
