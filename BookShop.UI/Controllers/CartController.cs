using BookShop.Application.Cart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class CartController : Controller
    {
        [HttpPost("{stockId}")]
        public async Task<IActionResult> AddOne(int stockId, [FromServices] AddToCart addToCart)
        {
            var request = new AddToCart.Request
            {
                StockId = stockId,
                Qty = 1
            };


            var success = await addToCart.Do(request);
            if (success)
            {
                return Ok("Item addet to cart");
            }
            return BadRequest("Failed to add to cart");
        }
        

        [HttpPost("{stockId}/{qty}")]
        public async Task<IActionResult> Remove(int stockId, int qty,
            [FromServices] RemoveFromCart removeFromCart)
        {
            var request = new RemoveFromCart.Request
            {
                StockId = stockId,
                Qty = qty
            };


            var success = await removeFromCart.Do(request);
            if (success)
            {
                return Ok("Item removed from cart");
            }
            return BadRequest("Failed removing from cart");
        }
        //[HttpGet]
        //public IActionResult GetCartComponent([FromServices] GetCart getCart)
        //{
        //    var totalValue = getCart.Do().Sum(x => Convert.ToInt32(x.Value) * x.Qty);
        //    return View("Components/Cart/Small", $"Р{totalValue}");
        //}

        [HttpGet]
        public IActionResult GetCartMain([FromServices] GetCart getCart) 
        {
            var cart = getCart.Do();
            return PartialView("_CartPartial", cart);
        }
        
    }
}
