using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.Dto.Product
{
    public class UpdateProduct: ProductBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
