using E_Commerce.Application.Dto.Cart;

namespace E_Commerce.Application.Services.Interfaces.Cart
{
    public interface IPaymentMethodServices
    {
        Task<IEnumerable<GetPaymentMethod>> GetPaymentMethods();
    }
}
