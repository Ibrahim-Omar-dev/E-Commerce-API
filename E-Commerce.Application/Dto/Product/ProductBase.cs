using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.Dto.Product
{
    public class ProductBase
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public decimal Price { get; set; }
        [Required]
        public string? Image { get; set; }
        [Required]
        public int Quentity { get; set; }

        public Guid CategoryId { get; set; }
    }
}
