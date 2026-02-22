using AutoMapper;
using E_Commerce.Application.Dto.Cart;
using E_Commerce.Application.Services.Interfaces.Cart;
using E_Commerce.Domain.Interface.Cart;

namespace E_Commerce.Application.Services.Cart
{
    public class PaymentMethodServices : IPaymentMethodServices
    {
        private readonly IPaymentMethodRepository payment;
        private readonly IMapper mapper;

        public PaymentMethodServices(IPaymentMethodRepository payment,IMapper mapper)
        {
            this.payment = payment;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<GetPaymentMethod>> GetPaymentMethods()
        {
            var method=await payment.GetPaymentMethodsAsync();
            if (!method.Any()) return [];

            return mapper.Map<IEnumerable<GetPaymentMethod>>(method);
        }
    }
}
