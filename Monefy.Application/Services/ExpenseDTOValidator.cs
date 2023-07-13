using FluentValidation;
using Monefy.Application.DTOs;


namespace Monefy.Application.Services
{
    public class ExpenseDTOValidator : AbstractValidator<ExpenseDTO>
    {
        public ExpenseDTOValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description can't be empty");
            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Please, add Amount!");
        }
    }
}
