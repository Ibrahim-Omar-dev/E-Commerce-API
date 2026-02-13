using E_Commerce.Domain.User;
using FluentValidation;

namespace E_Commerce.Application.Validation
{
    public class LoginUserValidation : AbstractValidator<LoginUser>
    {
        public LoginUserValidation()
        {

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required");
        }

    }
}
