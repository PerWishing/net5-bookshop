using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Application.ProductsUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.UI.Pages.User
{
    public class CreateProductModel : PageModel
    {
        [BindProperty]
        public CreateProduct.Request ProductInfo { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(IFormFile image, [FromServices] CreateProduct createProduct)
        {

            if (!ModelState.IsValid)
            {
                Success = true;
                return Page();
            }
            ProductInfo.Username = User.Identity.Name;
            ProductInfo.Image = image;
            await createProduct.Do(ProductInfo);
            
            return RedirectToPage("/User/Index");
        }
    }
}
