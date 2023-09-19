using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Application.Reviews;
using BookShop.Application.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.UI.Pages
{
    public class PublicUserModel : PageModel
    {
        [BindProperty]
        public GetUserPublic.Response UserPublicInfo { get; set; }
        [BindProperty]
        public GetUserPublic.Request UserRequest { get; set; }
        [BindProperty]
        public IEnumerable<ReviewService.Response> ReviewInfo { get; set; }
        [BindProperty]
        public int ReviewCount { get; set; }
        [BindProperty]
        public int ReviewCountPos { get; set; }
        [BindProperty]
        public int ReviewCountNeg { get; set; }
        [BindProperty]
        public bool IsAdmin { get; set; }

        public async Task<IActionResult> OnGet(string name, [FromServices] GetUserPublic getUserPublic,
            [FromServices] ReviewService reviewService)
        {
            UserPublicInfo = await getUserPublic.GetPublicUserWithProducts(name);
            IsAdmin = await getUserPublic.CheckRole(name);
            ReviewInfo = reviewService.GetReviewsByRecipient(name);
            ReviewCount = ReviewInfo.Count();
            ReviewCountPos = reviewService.GetReviewsByRecipientPos(name).Count();
            ReviewCountNeg = reviewService.GetReviewsByRecipientNeg(name).Count();
            return Page();
        }

        public async Task<IActionResult> OnPostForAvatar(string name, IFormFile image, [FromServices] GetUserPublic updateAvatar)
        {
            if (image!=null) { 
            UserRequest.UserName = name;
            UserRequest.Avatar = image;
            await updateAvatar.UpdateAvatar(UserRequest);
            }

            return RedirectToPage("/User/Index");
        }

        public async Task<IActionResult> OnPostForAll(string name, [FromServices] GetUserPublic getUserPublic,
            [FromServices] ReviewService reviewService)
        {
            UserPublicInfo = await getUserPublic.GetPublicUserWithProducts(name);
            IsAdmin = await getUserPublic.CheckRole(name);
            ReviewInfo = reviewService.GetReviewsByRecipient(name);
            ReviewCount = ReviewInfo.Count();
            ReviewCountPos = reviewService.GetReviewsByRecipientPos(name).Count();
            ReviewCountNeg = reviewService.GetReviewsByRecipientNeg(name).Count();
            return Page();
        }

        public async Task<IActionResult> OnPostForReviewPos(string name, [FromServices] GetUserPublic getUserPublic,
            [FromServices] ReviewService reviewService)
        {
            UserPublicInfo = await getUserPublic.GetPublicUserWithProducts(name);
            IsAdmin = await getUserPublic.CheckRole(name);
            ReviewInfo = reviewService.GetReviewsByRecipient(name);
            ReviewCount = ReviewInfo.Count();

            ReviewInfo = reviewService.GetReviewsByRecipientPos(name);
            
            ReviewCountPos = reviewService.GetReviewsByRecipientPos(name).Count();
            ReviewCountNeg = reviewService.GetReviewsByRecipientNeg(name).Count();
            return Page();
        }
        public async Task<IActionResult> OnPostForReviewNeg(string name, [FromServices] GetUserPublic getUserPublic,
            [FromServices] ReviewService reviewService)
        {
            UserPublicInfo = await getUserPublic.GetPublicUserWithProducts(name);
            IsAdmin = await getUserPublic.CheckRole(name);
            ReviewInfo = reviewService.GetReviewsByRecipient(name);
            ReviewCount = ReviewInfo.Count();

            ReviewInfo = reviewService.GetReviewsByRecipientNeg(name);
            
            ReviewCountPos = reviewService.GetReviewsByRecipientPos(name).Count();
            ReviewCountNeg = reviewService.GetReviewsByRecipientNeg(name).Count();
            return Page();
        }
        public async Task<IActionResult> OnPostForAdminBan(string name, [FromServices] GetUserPublic getUserPublic)
        {
            UserPublicInfo = await getUserPublic.GetPublicUserWithProducts(name);
            await getUserPublic.UpdateBlocked(name,1);
            return Redirect($"~/PublicUser/{name}");
        }
        public async Task<IActionResult> OnPostForAdminUnBan(string name, [FromServices] GetUserPublic getUserPublic)
        {
            UserPublicInfo = await getUserPublic.GetPublicUserWithProducts(name);
            await getUserPublic.UpdateBlocked(name, 0);
            return Redirect($"~/PublicUser/{name}");
        }
    }
}
