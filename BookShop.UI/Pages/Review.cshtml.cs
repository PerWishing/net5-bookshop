using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Application.Orders;
using BookShop.Application.Reviews;
using BookShop.UI.ValidationContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.UI.Pages
{
    public class ReviewModel : PageModel
    {
        [BindProperty]
        public ReviewService.Request ReviewInput { get; set; }
        [BindProperty]
        public ReviewService.Response ReviewResponse { get; set; }
        [BindProperty]
        public GetOrder.Response Order { get; set; }
        [BindProperty]
        public bool Create { get; set; }
        
        public IActionResult OnGet(int id, [FromServices] GetOrder getOrder, 
            [FromServices] ReviewService reviewService)
        {
            Order = getOrder.Do(id);
            //Проверка на доступ к отзыву

            if (Order.Customer != User.Identity.Name && Order.Seller != User.Identity.Name) {
                return Redirect("/Index");
            }

            //Проверка на существование отзыва

            ReviewResponse = reviewService.GetReviewBySenderAndOrder(User.Identity.Name, Order.Id);
            if (ReviewResponse == null)
            {
                Create = true;
            }
            else
            {
                Create = false;
            }


            return Page();
        }

        public async Task<IActionResult> OnPostForCreate(int id, 
           [FromServices] GetOrder getOrder, [FromServices] ReviewService reviewService)
        {
            Order = getOrder.Do(id);
            ReviewInput.OrderId = id;
            ReviewInput.Sender = User.Identity.Name;
            if(Order.Customer == User.Identity.Name)
            {
                ReviewInput.CustomerOrSeller = 0;
                ReviewInput.Recipient = Order.Seller;
            }
            if (Order.Seller == User.Identity.Name)
            {
                ReviewInput.CustomerOrSeller = 1;
                ReviewInput.Recipient = Order.Customer;
            }

            if (((int)Order.StatusForSeller == 1 || (int)Order.StatusForSeller == 2)
                  && (int)Order.StatusForCustomer == 3)
            {
                ReviewInput.PositiveOrNegative = 1;
            }

            //Влидация текста отзыва
            var validator = new CreateReviewValidation();
            var result = validator.Validate(ReviewInput);

            if (!result.IsValid)
            {
                Order = getOrder.Do(id);
                return Page();
            }

            await reviewService.CrateReview(ReviewInput);

            return Redirect($"~/Order/{id}");

        }
    }
}
