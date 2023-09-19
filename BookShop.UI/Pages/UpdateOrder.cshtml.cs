using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Application.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.UI.Pages
{
    public class UpdateOrderModel : PageModel
    {
        [BindProperty]
        public GetOrder.Response Order { get; set; }
        [BindProperty]
        public UpdateOrder.Request UpdatedInfo { get; set; }
        public async Task<IActionResult> OnGet(int id, [FromServices] GetOrder getOrder)
        {
            Order = getOrder.Do(id);
            return Page();
        }

        public async Task<IActionResult> OnPostForUpdate(int id, [FromServices] UpdateOrder updateOrder,
            [FromServices] GetOrder getOrder)
        {
            UpdatedInfo.Id = id;

            if (!ModelState.IsValid)
            {
                Order = getOrder.Do(id);//Для валидации
                return Page();
                //return Redirect($"~/UpdateProduct/{id}");
            }

            await updateOrder.UpdateAllOrder(UpdatedInfo);

            return Redirect($"~/Order/{id}");
        }
    }
}
