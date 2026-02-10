using E_Commerce.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Domain.Interface
{
    public interface IRoleManagement
    {
        Task<string?> GetUserRole(string email);
        Task<bool> AddUserRole(AppUser user,string roleName);
    }
}
