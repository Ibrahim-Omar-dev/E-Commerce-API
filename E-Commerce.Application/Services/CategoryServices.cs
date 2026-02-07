using AutoMapper;
using E_Commerce.Application.Categorys;
using E_Commerce.Application.Dto;
using E_Commerce.Application.Dto.Categorys;
using E_Commerce.Application.Services.Interfaces;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.IRepository;

namespace E_Commerce.Application.Services
{
    internal class CategoryServices : ICategoryServices
    {
        private readonly IMapper mapper;
        private readonly IRepository<Category> repository;

        public CategoryServices(IMapper mapper, IRepository<Category> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<ServicesResponse> AddAsync(CreateCategory category)
        {
            var categoryMap = mapper.Map<Category>(category);
            var result = await repository.AddAsync(categoryMap);
            if (result != null)
            {
                return new ServicesResponse { IsSuccess = true, Message = "Category added successfully." };
            }
            return new ServicesResponse { IsSuccess = false, Message = "Failed to add category." };
        }

        public async Task<ServicesResponse> DeleteById(Guid id)
        {
            var result = await repository.DeleteById(id);
            if (result != null)
            {
                return new ServicesResponse { IsSuccess = true, Message = "Category deleted successfully." };
            }
            return new ServicesResponse { IsSuccess = false, Message = "Category with this Id was not found" };
        }

        public async Task<ServicesResponse> DeleteByName(string name)
        {
            var result = await repository.DeleteByName(name);
            if (result != null)
            {
                return new ServicesResponse { IsSuccess = true, Message = "Category deleted successfully." };
            }
            return new ServicesResponse { IsSuccess = false, Message = "Category with this name was not found" };
        }

        public async Task<IEnumerable<GetCategory>> GetAll()
        {
            var result = await repository.GetAll();
            if (result != null)
            {
                var resultMap = mapper.Map<IEnumerable<GetCategory>>(result);
                return resultMap;
            }
            return Enumerable.Empty<GetCategory>();
        }

        public async Task<GetCategory?> GetById(Guid id)
        {
            var result = await repository.GetById(id);
            if (result != null)
            {
                var resultMap = mapper.Map<GetCategory>(result);
                return resultMap;
            }
            return null;
        }

        public async Task<GetCategory?> GetByName(string name)
        {
            var result = await repository.GetByName(name);
            if (result != null)
            {
                var resultMap = mapper.Map<GetCategory>(result);
                return resultMap;
            }
            return null;
        }

        public async Task<ServicesResponse> Update(UpdateCategory category)
        {
            var categoryMap = mapper.Map<Category>(category);
            var result = await repository.Update(categoryMap);
            if (result != null)
            {
                return new ServicesResponse { IsSuccess = true, Message = "Category updated successfully." };
            }
            return new ServicesResponse { IsSuccess = false, Message = "Failed to update category." };
        }

       
    }
}