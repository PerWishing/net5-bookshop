using BookShop.Application.Orders;
using BookShop.Application.Reviews;
using BookShop.Application.Users;
using BookShop.UI.ValidationContexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.UI.Pages
{
    public class OrderModel : PageModel
    {
        [BindProperty]
        public IEnumerable<ReviewService.Response> ReviewResponse { get; set; }
        [BindProperty]
        public GetOrder.Response Order { get; set; }
        [BindProperty]
        public  UpdateOrder.RequestForTrackNum TrackNumInfo { get; set; }
        [BindProperty]
        public UpdateOrder.RequestForSellerImage SellerImageInfo { get; set; }
        [BindProperty]
        public UpdateOrder.RequestForCommentOfCancel CommentOfCancel { get; set; }
        public async Task<IActionResult> OnGet(int id, [FromServices] GetOrder getOrder, [FromServices] GetUserPublic getUserPublic,
            [FromServices] IAuthorizationService authService, [FromServices] ReviewService reviewService)
        {
            Order = getOrder.Do(id);
            
            var IsAdmin = (await authService.AuthorizeAsync(User, "Admin")).Succeeded;

            if (User.Identity.Name == Order.Seller || User.Identity.Name == Order.Customer || IsAdmin)
            {
            ReviewResponse = reviewService.GetReviewsByOrder(id);
            return Page();
            }
            else
            {
                return RedirectToPage("/Index");
            }
        }
        //Post для покупателя
        public async Task<IActionResult> OnPostForCustomerReceive(int id, [FromServices] UpdateOrder updateOrder,
            [FromServices] GetOrder getOrder)
        {
            await updateOrder.UpdateStatusForCustomer(id, 1);
            Order = getOrder.Do(id);
            return Page();
        }
        public async Task<IActionResult> OnPostForCustomerCancel(int id, [FromServices] UpdateOrder updateOrder,
            [FromServices] GetOrder getOrder)
        {
            await updateOrder.UpdateStatusForCustomer(id, 3);
            await updateOrder.UpdateStatusOpenOrClosed(id, 1);
            Order = getOrder.Do(id);
            return Page();
        }
        //Post для продавца
        public async Task<IActionResult> OnPostForSellerAccept(int id, [FromServices] UpdateOrder updateOrder,
            [FromServices] GetOrder getOrder)
        {
            await updateOrder.UpdateStatusForSeller(id, 1);
            Order = getOrder.Do(id);
            return Page();
        }
        public async Task<IActionResult> OnPostForSellerSend(int id, IFormFile image, [FromServices] UpdateOrder updateOrder,
            [FromServices] GetOrder getOrder)
        {
            TrackNumInfo.Id = id;
            var validator = new UpdateOrderTrackNumValidation();
            var result = validator.Validate(TrackNumInfo);
            

            if (!result.IsValid)
            {
                Order = getOrder.Do(id);
                return Page();
            }
            SellerImageInfo.Id = id;
            SellerImageInfo.SellerImage = image;
            await updateOrder.UpdateTrackNumForSeller(TrackNumInfo);
            await updateOrder.UpdateSellerImage(SellerImageInfo);
            await updateOrder.UpdateStatusForSeller(id, 2);
            Order = getOrder.Do(id);
            return Page();
        }
        public async Task<IActionResult> OnPostForSellerRecMoney(int id, [FromServices] UpdateOrder updateOrder,
           [FromServices] GetOrder getOrder)
        {
            await updateOrder.UpdateStatusForSeller(id, 3);
            await updateOrder.UpdateStatusOpenOrClosed(id, 1);
            Order = getOrder.Do(id);
            return Page();
        }
        public async Task<IActionResult> OnPostForSellerCancel(int id, [FromServices] UpdateOrder updateOrder,
            [FromServices] GetOrder getOrder)
        {
            CommentOfCancel.Id = id;
            var validator = new UpdateOrderCancelCommentValidation();
            var result = validator.Validate(CommentOfCancel);

            if (!result.IsValid)
            {
                Order = getOrder.Do(id);
                return Page();
            }
            await updateOrder.UpdateCommentOfCancelForSeller(CommentOfCancel);
            await updateOrder.UpdateStatusForSeller(id, 4);
            await updateOrder.UpdateStatusOpenOrClosed(id, 1);
            Order = getOrder.Do(id);
            return Page();
        }
        public async Task<IActionResult> OnPostForSellerNoStatus(int id, [FromServices] UpdateOrder updateOrder,
           [FromServices] GetOrder getOrder)
        {
            await updateOrder.UpdateStatusForSeller(id, 0);
            Order = getOrder.Do(id);
            return Page();
        }
        public async Task<IActionResult> OnPostForStatusClosed(int id, [FromServices] UpdateOrder updateOrder,
           [FromServices] GetOrder getOrder)
        {
            await updateOrder.UpdateStatusOpenOrClosed(id, 1);
            Order = getOrder.Do(id);
            return Page();
        }

        public async Task<IActionResult> OnPostForAdminStatusClosed(int id, int status, [FromServices] UpdateOrder updateOrder,
           [FromServices] GetOrder getOrder)
        {
            await updateOrder.UpdateStatusOpenOrClosed(id, status);
            Order = getOrder.Do(id);
            return Redirect($"~/Order/{id}");
        }
        public async Task<IActionResult> OnPostForAdminStatusSeller(int id, int status1, [FromServices] UpdateOrder updateOrder,
           [FromServices] GetOrder getOrder)
        {
            await updateOrder.UpdateStatusForSeller(id, status1);
            Order = getOrder.Do(id);
            return Redirect($"~/Order/{id}");
        }
        public async Task<IActionResult> OnPostForAdminStatusCustomer(int id, int status2, [FromServices] UpdateOrder updateOrder,
           [FromServices] GetOrder getOrder)
        {
            await updateOrder.UpdateStatusForCustomer(id, status2);
            Order = getOrder.Do(id);
            return Redirect($"~/Order/{id}");
        }
        public async Task<IActionResult> OnPostForAdminDeleteReview(int id, int revId, [FromServices] ReviewService reviewService,
           [FromServices] GetOrder getOrder)
        {
            reviewService.DeleteReviewById(revId);
            Order = getOrder.Do(id);
            return Redirect($"~/Order/{id}");
        }

    }
}
