using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Application.Orders;
using BookShop.Application.ProductsUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.UI.Pages.User
{
    public class OrderManagementForCustomerModel : PageModel
    {
        [BindProperty]
        public IEnumerable<GetOrders.Response> Orders { get; set; }

        public void OnGet([FromServices] GetOrders getOrders)
        {
            Orders = getOrders.GetByCustomer(User.Identity.Name);
        }
    }
}
