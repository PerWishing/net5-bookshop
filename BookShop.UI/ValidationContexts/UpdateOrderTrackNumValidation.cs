using BookShop.Application.Orders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.UI.ValidationContexts
{
    public class UpdateOrderTrackNumValidation
        : AbstractValidator<UpdateOrder.RequestForTrackNum>
    {
        public UpdateOrderTrackNumValidation()
        {
            RuleFor(x => x.TrackNum).NotNull().WithMessage("Поле не может быть пустым").MinimumLength(14).WithMessage("Поле должно содержать минимум 14 цифр");
        }
    }
}
