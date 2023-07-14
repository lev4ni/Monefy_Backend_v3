using FluentValidation;
using Monefy.Application.DTOs;


namespace Monefy.Application.Services
{
    public class CategoryDTOValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryDTOValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("User name cannot be empty");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description can't be empty");
     
        }

    }
}
