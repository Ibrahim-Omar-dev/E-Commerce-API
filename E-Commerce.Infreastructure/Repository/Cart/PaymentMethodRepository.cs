using E_Commerce.Domain.Entities.Cart;
using E_Commerce.Domain.Interface.Cart;
using E_Commerce.Infreastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infreastructure.Repository.Cart
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly AppDbContext context;

        public PaymentMethodRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync()
        {
            return await context.PaymentMethods
                                .AsNoTracking()
                                .ToListAsync();
        }
    }
}
