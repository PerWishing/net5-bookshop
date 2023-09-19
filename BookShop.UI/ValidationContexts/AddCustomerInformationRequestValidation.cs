using BookShop.Application.Orders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.UI.ValidationContexts
{
    public class AddCustomerInformationRequestValidation
        : AbstractValidator<CreateOrder.Request>
    {
        public AddCustomerInformationRequestValidation()
        {
            RuleFor(x => x.FIO).NotNull().WithMessage("Поле не может быть пустым");
            RuleFor(x => x.Email).NotNull().WithMessage("Поле не может быть пустым")
                .EmailAddress().WithMessage("Неверный формат адреса");
            RuleFor(x => x.PhoneNumber).NotNull().WithMessage("Поле не может быть пустым")
                .MinimumLength(10).WithMessage("Поле должно содержать минимум 10 символов");
            RuleFor(x => x.Adress1).NotNull().WithMessage("Поле не может быть пустым");
            RuleFor(x => x.City).NotNull().WithMessage("Поле не может быть пустым");
            RuleFor(x => x.PostCode).NotNull().WithMessage("Поле не может быть пустым");
        }
    }
}
