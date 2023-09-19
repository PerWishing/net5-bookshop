using BookShop.Application.ProductsUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.UI.ValidationContexts
{
    public class ProductRegisterValidation : AbstractValidator<CreateProduct.Request>
    {
        public ProductRegisterValidation()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Поле не может быть пустым");
            RuleFor(x => x.Description).NotNull().WithMessage("Поле не может быть пустым");
            RuleFor(x => x.Value).NotNull().WithMessage("Поле не может быть пустым").Must(x => Math.Truncate(x) == x);
            RuleFor(x => x.Author).NotNull().WithMessage("Поле не может быть пустым");
            RuleFor(x => x.Genre).NotNull().WithMessage("Поле не может быть пустым");
            RuleFor(x => x.Publishing).NotNull().WithMessage("Поле не может быть пустым");
            RuleFor(x => x.Year).NotNull().WithMessage("Поле не может быть пустым");

        }
    }
}
