using E_Commerce.Application.Dto;
using E_Commerce.Application.Dto.Cart;
using E_Commerce.Application.Dto.Product;
using E_Commerce.Application.Services.Interfaces.Cart;
using E_Commerce.Domain.Entities;
using Stripe;
using Stripe.Checkout;
using Product = E_Commerce.Domain.Entities.Product;

namespace E_Commerce.Infreastructure.Repository.Cart
{
    public class StripePaymentMethod : IPaymentServices
    {
        public async Task<ServicesResponse> Pay(
            decimal totalAmount,
            IEnumerable<GetProduct> cartProduct,
            IEnumerable<ProcessCart> cart)
        {
            try
            {
                var lineItems = new List<SessionLineItemOptions>();

                foreach (var product in cartProduct)
                {
                    var pQuantity = cart.FirstOrDefault(c => c.ProductId == product.Id);

                    if (pQuantity == null)
                        continue;

                    lineItems.Add(new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = product.Name,
                                Description = product.Description,
                            },
                            UnitAmount = (long)(product.Price * 100),
                        },
                        Quantity = pQuantity.Quantity
                    });
                }

                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string> { "card" },
                    LineItems = lineItems,
                    Mode = "payment",
                    SuccessUrl = "https://localhost:7025/payment-success",
                    CancelUrl = "https://localhost:7025/payment-cancel"
                };

                var service = new SessionService();
                Session session = await service.CreateAsync(options);

                return new ServicesResponse
                {
                    IsSuccess = true,
                    Message = session.Url
                };
            }
            catch (Exception ex)
            {
                return new ServicesResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
