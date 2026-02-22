using E_Commerce.Domain.Entities.Cart;
using E_Commerce.Domain.Interface.Cart;
using E_Commerce.Infreastructure.Data;

namespace E_Commerce.Infreastructure.Repository.Cart
{
    public class CartRepository : ICart
    {
        private readonly AppDbContext context;

        public CartRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<int> SaveCheckoutHistory(IEnumerable<Achieve> checkout)
        {
            await context.CheckoutAchieve.AddRangeAsync(checkout);
            return await context.SaveChangesAsync();
        }
    }
}
