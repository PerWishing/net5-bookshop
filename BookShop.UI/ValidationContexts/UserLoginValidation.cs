using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookShop.UI.Pages.Accounts.LoginModel;

namespace BookShop.UI.ValidationContexts
{
    public class UserLoginValidation : AbstractValidator<LoginViewModel>
    {
        public UserLoginValidation()
        {
            RuleFor(x => x.Username).NotNull().WithMessage("Поле не может быть пустым");
            RuleFor(x => x.Password).NotNull().WithMessage("Поле не может быть пустым");
        }
    }
}
