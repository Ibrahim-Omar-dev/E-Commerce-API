using E_Commerce.Application.Dto;
using E_Commerce.Application.Dto.Product;
using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Services.Interfaces
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product?> GetById(int id);
        Task<Product?> GetByName(string name);
        Task<ServicesResponse> AddAsync(CreateProduct product);
        Task<ServicesResponse> DeleteById(Guid id);
        Task<ServicesResponse> DeleteByName(string name);
        Task<ServicesResponse> Update(UpdateProduct product);
    }
}
