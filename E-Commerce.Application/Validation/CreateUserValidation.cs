using E_Commerce.Application.Dto.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Validation
{
    public class CreateUserValidation : AbstractValidator<CreateUser>
    {
        public CreateUserValidation() {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("FullName is required");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password required")
                .MinimumLength(6).WithMessage("Password must be at least")
                .Matches(@"[a-z] ^ [A-Z]").WithMessage("mush contain characters")
                .Matches(@"[0-9]").WithMessage("mush contain numbers");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Password Not Match");
                
        }
    }
}
