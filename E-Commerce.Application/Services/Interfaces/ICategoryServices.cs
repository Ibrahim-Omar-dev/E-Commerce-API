using E_Commerce.Application.Categorys;
using E_Commerce.Application.Dto;
using E_Commerce.Application.Dto.Categorys;
using E_Commerce.Application.Dto.Product;
using E_Commerce.Domain.Entities;
namespace E_Commerce.Application.Services.Interfaces
{
    public interface ICategoryServices
    {
        Task<IEnumerable<GetCategory>> GetAll();
        Task<GetCategory?> GetById(Guid id);
        Task<GetCategory?> GetByName(string name);
        Task<ServicesResponse> AddAsync(CreateCategory category);
        Task<ServicesResponse> DeleteById(Guid id);
        Task<ServicesResponse> DeleteByName(string name);
        Task<ServicesResponse> Update(UpdateCategory category);
    }
}
