using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_Commerce.Domain.Entities 
{
    public class Product
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        public string? Image { get; set; }
        [Required]
        public int Quentity { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
