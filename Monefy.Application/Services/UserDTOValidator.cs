using FluentValidation;
using Monefy.Application.DTOs;


namespace Monefy.Application.Services
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("User name cannot be empty")
                .MaximumLength(20).WithMessage("User name cannot exceed 20 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .Length(4, 20).WithMessage("Password must be between 4 and 20 characters");
        }
    }
}
