using BookShop.Application.Orders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.UI.ValidationContexts
{
    public class UpdateOrderCancelCommentValidation
        : AbstractValidator<UpdateOrder.RequestForCommentOfCancel>
    {
        public UpdateOrderCancelCommentValidation()
        {
            RuleFor(x => x.Comment).NotNull().WithMessage("Поле не может быть пустым").MinimumLength(10).WithMessage("Поле должно содержать минимум 10 символов");
        }
    }
}
