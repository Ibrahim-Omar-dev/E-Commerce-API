using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.Dto.Cart
{
    public class Checkout
    {
        [Required]
        public Guid PaymentMethodId { get; set; }
        [Required]
        public IEnumerable<ProcessCart> Carts{ get; set; }
    }
}
