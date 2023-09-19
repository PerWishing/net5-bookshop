using BookShop.Application.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.UI.ValidationContexts
{
    public class UserRegisterValidation : AbstractValidator<CreateUser.Request>
    {
        public UserRegisterValidation()
        {
            RuleFor(x => x.Username).NotNull().WithMessage("Поле не может быть пустым");
            RuleFor(x => x.Password).NotNull().WithMessage("Поле не может быть пустым");
            RuleFor(x => x.Email).NotNull().WithMessage("Поле не может быть пустым").EmailAddress().WithMessage("Не верный формат адреса");
        }
    }
}
