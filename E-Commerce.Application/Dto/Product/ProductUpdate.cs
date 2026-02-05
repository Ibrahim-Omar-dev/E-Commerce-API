using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.Product
{
    public class ProductUpdate: ProductBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
