using AutoMapper;
using E_Commerce.Application.Dto;
using E_Commerce.Application.Dto.Cart;
using E_Commerce.Application.Dto.Product;
using E_Commerce.Application.Services.Interfaces.Cart;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Entities.Cart;
using E_Commerce.Domain.Interface.Cart;

namespace E_Commerce.Application.Services.Cart
{
    public class CartServices : ICartServices
    {
        private readonly ICart cart;
        private readonly IMapper mapper;
        private readonly ProductServices productServices;
        private readonly IPaymentMethodServices paymentMethodServices;
        private readonly IPaymentServices paymentServices;

        public CartServices(ICart cart,IMapper mapper,ProductServices productServices,
            IPaymentMethodServices paymentMethodServices,IPaymentServices paymentServices)
        {
            this.cart = cart;
            this.mapper = mapper;
            this.productServices = productServices;
            this.paymentMethodServices = paymentMethodServices;
            this.paymentServices = paymentServices;
        }

        public async Task<ServicesResponse> Checkout(Checkout checkout)
        {
            var (products, totalAmount) = await GetTotalAmount(checkout.Carts);
            var paymentMethods = await paymentMethodServices.GetPaymentMethods();
            var paymentMethod = paymentMethods.FirstOrDefault();

            if (paymentMethod == null)
                return new ServicesResponse { IsSuccess = false, Message = "No payment method found." };

            if (checkout.PaymentMethodId == paymentMethod.Id)
                return await paymentServices.Pay(totalAmount, products, checkout.Carts);

            return new ServicesResponse { IsSuccess = false, Message = "Invalid payment method." };
        }
        public async Task<ServicesResponse> SaveCheckoutHistory(IEnumerable<CreateAcheive> createCarts)
        {
            var mappedData = mapper.Map<IEnumerable<Achieve>>(createCarts);
            var result = await cart.SaveCheckoutHistory(mappedData);
            return result > 0 ? new ServicesResponse { IsSuccess = true, Message = "Checkout Successful" } :
                new ServicesResponse { IsSuccess = false, Message = "Error occur in saving" };
        }
        public async Task<(IEnumerable<GetProduct>, decimal)> GetTotalAmount(IEnumerable<ProcessCart> cart)
        {
            if (!cart.Any()) return ([], 0);
            var products = await productServices.GetAll();
            if (!products.Any()) return ([], 0);
            var cartsProduct = cart
                .Select(c => products.FirstOrDefault(p => p.Id == c.ProductId))
                .Where(p => p != null)
                .ToList();
            var totalAmount = cart
                .Where(c => cartsProduct.Any(p => p.Id == c.ProductId))
                .Sum(c => c.Quantity * cartsProduct.First(p => p.Id == c.ProductId)!.Price);
            return (cartsProduct!, totalAmount);
        }
    }
}
