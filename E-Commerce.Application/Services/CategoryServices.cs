using E_Commerce.Application.Categorys;
using E_Commerce.Application.Dto;
using E_Commerce.Application.Dto.Categorys;
using E_Commerce.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Services
{
    internal class CategoryServices : ICategoryServices
    {
        public Task<ServicesResponse> AddAsync(CreateCategory category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetCategory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetCategory> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServicesResponse> UpdateAsync(UpdateCategory category)
        {
            throw new NotImplementedException();
        }
    }
}
