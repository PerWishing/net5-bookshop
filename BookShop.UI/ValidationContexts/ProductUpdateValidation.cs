using BookShop.Application.ProductsUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.UI.ValidationContexts
{
    public class ProductUpdateValidation : AbstractValidator<UpdateProduct.Request>
    {
        public ProductUpdateValidation()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Поле не может быть пустым");
            RuleFor(x => x.Description).NotNull().WithMessage("Поле не может быть пустым");
            RuleFor(x => x.Value).NotNull().WithMessage("Поле не может быть пустым").Must(x => Math.Truncate(x) == x);
        }
    }
}
