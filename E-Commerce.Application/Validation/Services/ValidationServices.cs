using E_Commerce.Application.Dto;
using FluentValidation;

namespace E_Commerce.Application.Validation.Services
{
    public class ValidationServices : IValidationServices
    {
        public async Task<ServicesResponse> ValidateAsync<T>(T model, IValidator<T> validator)
        {
            var validateResult=await validator.ValidateAsync(model);
            if (!validateResult.IsValid)
            {
                var errors = validateResult.Errors.Select(e => e.ErrorMessage).ToList();
                string stringError = string.Join(",", errors);
                return new ServicesResponse { Message = stringError };
            }
            return new ServicesResponse { Message = string.Empty ,IsSuccess=true};
        }
    }
}
