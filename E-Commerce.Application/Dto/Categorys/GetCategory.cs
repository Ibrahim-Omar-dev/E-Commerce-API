using E_Commerce.Application.Categorys;
using E_Commerce.Application.Dto.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_Commerce.Application.Dto.Categorys
{
    public class GetCategory : CategoryBase
    {
        [Required]
        public Guid Id { get; set; }
        public ICollection<GetProduct>? Products { get; set; }
    }
}
