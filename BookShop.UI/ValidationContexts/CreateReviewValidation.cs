using BookShop.Application.Orders;
using BookShop.Application.Reviews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.UI.ValidationContexts
{
    public class CreateReviewValidation
        : AbstractValidator<ReviewService.Request>
    {
        public CreateReviewValidation()
        {
            RuleFor(x => x.Text).NotNull().WithMessage("Поле не может быть пустым")
                .MinimumLength(20).WithMessage("Поле должно содержать минимум 20 символов");
        }
    }
}
