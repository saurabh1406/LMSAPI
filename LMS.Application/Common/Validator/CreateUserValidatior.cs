using FluentValidation;
using LMS.Application.Handlers.UserLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Common.Validator
{
    public class CreateUserValidatior : AbstractValidator<UserCreationCommand>
    {
        public CreateUserValidatior()
        {
            RuleFor(x => x.userDetails.Name)
               .NotEmpty().WithMessage("Name is required")
               .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");

            RuleFor(x => x.userDetails.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.userDetails.PasswordHash)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long");
        }
    }
}
