using AutoMapper;
using E_Commerce.Application.Dto;
using E_Commerce.Application.Dto.User;
using E_Commerce.Application.Services.Interfaces.IAuthentication;
using E_Commerce.Application.Validation.Services;
using E_Commerce.Domain.Entities.Identity;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.Services.Authentication
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IValidationServices validationServices;
        private readonly IValidator<CreateUser> validator;
        private readonly IMapper mapper;

        public AuthenticationServices(IValidationServices validationServices,IValidator<CreateUser> validator,
            IMapper mapper
            )
        {
            this.validationServices = validationServices;
            this.validator = validator;
            this.mapper = mapper;
        }
        public async Task<ServicesResponse> CreateUser(CreateUser createUser)
        {
            var validationResult =await validationServices.ValidateAsync(createUser, validator);
            if(!validationResult.IsSuccess)
            {
                return validationResult;
            }
            var mapModel=mapper.Map<AppUser>(createUser);
            mapModel.UserName = createUser.Email;
            mapModel.PasswordHash = createUser.Password;
            return validationResult;
        }

        public Task<LoginResponse> Login(LoginUser loginUser)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponse> ReviveToken(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
