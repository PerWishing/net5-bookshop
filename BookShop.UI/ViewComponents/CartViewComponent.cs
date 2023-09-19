using BookShop.Application.Cart;
using BookShop.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.UI.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private GetCart _getCart;

        public CartViewComponent(GetCart getCart)
        {
            _getCart = getCart;
        }
       
        public IViewComponentResult Invoke(string view = "Deafault")
        {
            if (view == "Small")
            {
                var totalValue = _getCart.Do().Sum(x => Convert.ToInt32(x.Value) * x.Qty);
                return View(view, $"Р{totalValue}");
            }
            return View(view, _getCart.Do());
        }
    }
}
