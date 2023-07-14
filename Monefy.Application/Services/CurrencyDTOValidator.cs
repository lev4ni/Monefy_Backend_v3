using FluentValidation;
using Monefy.Application.DTOs;

namespace Monefy.Application.Services
{
    public class CurrencyDTOValidator : AbstractValidator<CurrencyDTO>
    {
        public CurrencyDTOValidator() 
        {
            RuleFor(x => x.CurrencyName)
            .NotEmpty().WithMessage("Name for this currrency can't be empty");
        }
    }
}
