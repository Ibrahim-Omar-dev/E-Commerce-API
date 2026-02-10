using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_Commerce.Application.Dto.User
{
    public class CreateUser : BaseModel
    {
        public required string FullName { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
