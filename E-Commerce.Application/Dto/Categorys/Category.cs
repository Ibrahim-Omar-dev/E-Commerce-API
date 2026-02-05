using System;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.Categorys
{
    public class CategoryBase
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
    }
}