using FluentValidation;
using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Domain.Services
{
    public class UserValidator : AbstractValidator<EntityUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("User can't be empty")
                .MaximumLength(20).WithMessage("User can't be longer than 20 characters");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("User can't be empty")
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Passwords empty NOT permeted!")
                .MaximumLength(20).WithMessage("Max lenght = 20 chararctes/numbers")
                .MinimumLength(4).WithMessage("Min lenght form password = 4 characters/numbers");
        }
    }
}
