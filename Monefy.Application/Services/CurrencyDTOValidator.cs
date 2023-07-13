using FluentValidation;
using Monefy.Application.DTOs;

namespace Monefy.Application.Services
{
    public class CurrencyDTOValidator : AbstractValidator<WalletDTO>
    {
        public CurrencyDTOValidator() 
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name for this currrency can't be empty");
        }
    }
}
