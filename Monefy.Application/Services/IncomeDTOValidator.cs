using FluentValidation;
using Monefy.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Application.Services
{
    public class IncomeDTOValidator : AbstractValidator<IncomeDTO>
    {
        public IncomeDTOValidator() 
        {
            RuleFor(x => x.Description)
             .NotEmpty().WithMessage("Description can't be empty");
            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Please, add Amount!");
        }

    }
}
