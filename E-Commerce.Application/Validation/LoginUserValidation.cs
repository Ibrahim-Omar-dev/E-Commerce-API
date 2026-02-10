using E_Commerce.Application.Dto.User;
using FluentValidation;

namespace E_Commerce.Application.Validation
{
    public class LoginUserValidation : AbstractValidator<LoginUser>
    {
        public LoginUserValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .Empty().WithMessage("Password is required");
        }

    }
}
