using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Application.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.UI.Pages.User
{
    public class ArchiveModel : PageModel
    {
        [BindProperty]
        public IEnumerable<GetOrders.Response> Orders { get; set; }
        [BindProperty]
        public IEnumerable<GetOrders.Product> Products { get; set; }
        public void OnGet([FromServices] GetOrders getOrders)
        {
            Orders = getOrders.GetBySellerClosed(User.Identity.Name);
        }

        public void OnPostForSeller([FromServices] GetOrders getOrders)
        {
            Orders = getOrders.GetBySellerClosed(User.Identity.Name);
        }
        public void OnPostForCustomer([FromServices] GetOrders getOrders)
        {
            Orders = getOrders.GetByCustomerClosed(User.Identity.Name);
        }
    }
}
