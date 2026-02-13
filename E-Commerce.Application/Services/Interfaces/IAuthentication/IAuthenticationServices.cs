using E_Commerce.Application.Dto;
using E_Commerce.Domain.Entities.Identity;
using E_Commerce.Domain.User;

namespace E_Commerce.Application.Services.Interfaces.IAuthentication
{
    public interface IAuthenticationServices
    {
        public Task<bool> CreateUser(CreateUser user);
        Task<LoginResponse> Login(LoginUser loginUser);
        Task<LoginResponse> ReviveToken(string refreshToken);

    }
}
