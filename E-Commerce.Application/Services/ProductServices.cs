using AutoMapper;
using E_Commerce.Application.Dto;
using E_Commerce.Application.Dto.Product;
using E_Commerce.Application.Services.Interfaces;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Services
{
    internal class ProductServices : IProductServices
    {
        private readonly IMapper mapper;
        private readonly IRepository<Product> repository;

        public ProductServices(IMapper mapper, IRepository<Product> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public Task<ServicesResponse> AddAsync(CreateProduct product)
        {
            var productMap = mapper.Map<Product>(product);
            var result = repository.AddAsync(productMap);
            if (result != null)
            {
                return Task.FromResult(new ServicesResponse { IsSuccess = true, Message = "Product added successfully." });
            }
            return Task.FromResult(new ServicesResponse { IsSuccess = false, Message = "Failed to add product." });
        }



        public Task<ServicesResponse> DeleteById(Guid id)
        {
            var result = repository.DeleteById(id);
            if (result != null)
            {
                return Task.FromResult(new ServicesResponse { IsSuccess = true, Message = "Product deleted successfully." });
            }
            return Task.FromResult(new ServicesResponse { IsSuccess = false, Message = "product with this Id Was not found" });
        }  

        public Task<ServicesResponse> DeleteByName(string name)
        {
            var result = repository.DeleteByName(name);
            if (result != null)
            {
                return Task.FromResult(new ServicesResponse { IsSuccess = true, Message = "Product deleted successfully." });
            }
            return Task.FromResult(new ServicesResponse { IsSuccess = false, Message = "product with this name was not found" });
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var result=await repository.GetAll();
            if (result.Count() > 0)
            {
                var resultMap = mapper.Map<IEnumerable<GetProduct>>(result);
                return result;
            }
            return [];
        }

        public Task<Product?> GetById(int id)
        {
            var result = repository.GetById(id);

            var resultMap = mapper.Map<IEnumerable<GetProduct>>(result);
            return result;
        }

        public Task<Product?> GetByName(string name)
        {
            var result = repository.GetByName(name);
            var resultMap = mapper.Map<IEnumerable<GetProduct>>(result);
            return result;
        }

        public Task<ServicesResponse> Update(UpdateProduct product)
        {
            var productMap = mapper.Map<Product>(product);
            var result = repository.Update(productMap);
            if (result != null)
            {
                return Task.FromResult(new ServicesResponse { IsSuccess = true, Message = "Product updated successfully." });
            }
            return Task.FromResult(new ServicesResponse { IsSuccess = false, Message = "Failed to update product." });
        }
    }
}
