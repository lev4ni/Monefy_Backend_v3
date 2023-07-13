using FluentValidation;
using Monefy.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Application.Services
{
    public class WalletDTOValidator : AbstractValidator<WalletDTO>
    {
        public WalletDTOValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Name for this wallet can't be empty");
        }
    }
}
