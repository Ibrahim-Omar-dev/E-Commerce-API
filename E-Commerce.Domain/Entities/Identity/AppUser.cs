

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        [Key]
        public Guid UserId { get; set; }=Guid.NewGuid();
       
    }
}
