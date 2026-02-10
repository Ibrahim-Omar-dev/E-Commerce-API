using E_Commerce.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace E_Commerce.Domain.Interface
{
    public interface IUserManagement
    {
        Task<AppUser> GetUserByEmail(string email);
        Task<AppUser> GetUserById(string Id);
        Task<bool> CreateUser(AppUser user);
        Task<bool> LoginUser(AppUser User);
        Task<bool> DeleteUserByEmail(string Email);
        Task<bool> UpdateUserByEmail(AppUser user, string Email);
        Task<IEnumerable<AppUser>> GetAllUser();
        Task<IEnumerable<Claim>> GetUserClaims(string email);
    }
}
