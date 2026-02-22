using E_Commerce.Application.Dto;
using E_Commerce.Application.Dto.Cart;

namespace E_Commerce.Application.Services.Interfaces.Cart
{
    public interface ICartServices
    {
        Task<ServicesResponse> SaveCheckoutHistory(IEnumerable<CreateAcheive> createCarts);
        Task<ServicesResponse> Checkout(Checkout checkout);
    }
}
