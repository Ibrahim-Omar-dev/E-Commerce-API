using E_Commerce.Domain.Entities.Cart;

namespace E_Commerce.Domain.Interface.Cart
{
    public interface ICart
    {
        Task<int> SaveCheckoutHistory(IEnumerable<Achieve> checkour);
    }
}
