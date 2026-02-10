using E_Commerce.Application.Dto;
using E_Commerce.Application.Dto.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Services.Interfaces.IAuthentication
{
    public interface IAuthenticationServices
    {
        Task<ServicesResponse> CreateUser(CreateUser createUser);
        Task<LoginResponse> Login(LoginUser loginUser);
        Task<LoginResponse> ReviveToken(string refreshToken);

    }
}
