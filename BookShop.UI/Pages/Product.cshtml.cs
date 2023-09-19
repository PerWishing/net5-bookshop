using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Application.Cart;
using BookShop.Application.Products;
using BookShop.Application.ProductsUser;
using BookShop.Application.Users;
using BookShop.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.UI.Pages
{
    public class ProductModel : PageModel
    {
        [BindProperty]
        public GetUserPublic.Response SellerInfo { get; set; }
        [BindProperty]
        public AddToCart.Request CartViewModel { get; set; }
        [BindProperty]
        public AddProductInFav.Request FavInfo { get; set; }
        
        [BindProperty]
        public bool AddedInFav { get; set; }
        [BindProperty]
        public Application.Products.GetProduct.ProductViewModel Product { get; set; }

        public async Task<IActionResult> OnGet(int id, [FromServices] Application.Products.GetProduct getProduct,
            [FromServices] AddProductInFav addProductInFav, [FromServices] GetUserPublic getUserPublic)
        {
            Product = await getProduct.Do(id);
            if (User.Identity.Name != null) { 
            FavInfo = new AddProductInFav.Request();
            FavInfo.Username = User.Identity.Name;
            FavInfo.ProductId = id;
            AddedInFav = await addProductInFav.Check(FavInfo);
            
            }
            SellerInfo = await getUserPublic.GetPublicUser(Product.Seller);
            if (Product == null)
                return RedirectToPage("Index");
            else
                return Page();

        }

        public async Task<IActionResult> OnPostForBuy([FromServices] AddToCart addToCart)
        {
            var stockAdded = await addToCart.Do(CartViewModel);

            if (stockAdded)
                return RedirectToPage("Cart");
            else
                //TODO: add a warning
                return Page();
        }

        public async Task<IActionResult> OnPostForFavor(int id, [FromServices] AddProductInFav addProductInFav)
        {
            FavInfo.Username = User.Identity.Name;
            FavInfo.ProductId = id;

            var result =  await addProductInFav.Do(FavInfo);

            if (result)
                return RedirectToPage("Favorites");
            else
                //TODO: add a warning
                
                return RedirectToPage();
        }
        public async Task<IActionResult> OnPostForFavorDelete(int id, [FromServices] AddProductInFav addProductInFav)
        {
            FavInfo.Username = User.Identity.Name;
            FavInfo.ProductId = id;

            var result = await addProductInFav.Delete(FavInfo);

            if (result)
                return RedirectToPage();
            else
                //TODO: add a warning

                return RedirectToPage();
        }
        public async Task<IActionResult> OnPostForAvailableOpen(int id, [FromServices] Application.Products.GetProduct getProduct,
            [FromServices] UpdateProduct updateProduct)
        {
            Product = await getProduct.Do(id);
            await updateProduct.UpdateAvailable(id,0);
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostForAvailableClose(int id, [FromServices] Application.Products.GetProduct getProduct,
            [FromServices] UpdateProduct updateProduct)
        {
            Product = await getProduct.Do(id);
            await updateProduct.UpdateAvailable(id, 1);
            return RedirectToPage();
        }
    }
}
