using E_Commerce.Application.Categorys;
using E_Commerce.Application.Dto;
using E_Commerce.Application.Dto.Categorys;
using E_Commerce.Application.Dto.Product;
using E_Commerce.Application.Product;

namespace E_Commerce.Application.Services.Interfaces
{
    public interface ICategoryServices
    {
        Task<IEnumerable<GetCategory>> GetAllAsync();
        Task<GetCategory> GetAsync(Guid id);
        Task<ServicesResponse> UpdateAsync(UpdateCategory category);
        Task<ServicesResponse> AddAsync(CreateCategory category);
        Task<bool> DeleteAsync(Guid id);
    }
}
