using E_Commerce.Domain.Entities.Cart;

namespace E_Commerce.Domain.Interface.Cart
{
    public interface IPaymentMethodRepository
    {
        Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync();
    }
}
