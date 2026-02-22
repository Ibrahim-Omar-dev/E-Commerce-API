using E_Commerce.Application.Dto;
using E_Commerce.Application.Dto.Cart;
using E_Commerce.Application.Dto.Product;
using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Services.Interfaces.Cart
{
    public interface IPaymentServices
    {
        Task<ServicesResponse> Pay(decimal totalAmount, IEnumerable<GetProduct> cartProduct, IEnumerable<ProcessCart> processes);
    }
}
