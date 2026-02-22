using AutoMapper;
using E_Commerce.Application.Dto;
using E_Commerce.Application.Dto.Product;
using E_Commerce.Application.Services.Interfaces;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IMapper mapper;
        private readonly IRepository<Product> repository;

        public ProductServices(IMapper mapper, IRepository<Product> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<ServicesResponse> AddAsync(CreateProduct product)
        {
            var productMap = mapper.Map<Product>(product);
            var result = await repository.AddAsync(productMap);
            if (result != null)
            {
                return new ServicesResponse { IsSuccess = true, Message = "Product added successfully." };
            }
            return new ServicesResponse { IsSuccess = false, Message = "Failed to add product." };
        }

        public async Task<ServicesResponse> DeleteById(Guid id)
        {
            var result = await repository.DeleteById(id);
            if (result)
            {
                return new ServicesResponse { IsSuccess = true, Message = "Product deleted successfully." };
            }
            return new ServicesResponse { IsSuccess = false, Message = "Product with this Id was not found" };
        }

        public async Task<ServicesResponse> DeleteByName(string name)
        {
            var result = await repository.DeleteByName(name);
            if (result)
            {
                return new ServicesResponse { IsSuccess = true, Message = "Product deleted successfully." };
            }
            return new ServicesResponse { IsSuccess = false, Message = "Product with this name was not found" };
        }

        public async Task<IEnumerable<GetProduct>> GetAll()
        {
            var result = await repository.GetAll();
            if (result != null && result.Any())
            {
                var resultMap = mapper.Map<IEnumerable<GetProduct>>(result);
                return resultMap;
            }
            return Enumerable.Empty<GetProduct>();
        }

        public async Task<GetProduct?> GetById(Guid id)
        {
            var result = await repository.GetById(id);
            if (result != null)
            {
                var resultMap = mapper.Map<GetProduct>(result);
                return resultMap;
            }
            return null;
        }

        public async Task<GetProduct?> GetByName(string name)
        {
            var result = await repository.GetByName(name);
            if (result != null)
            {
                var resultMap = mapper.Map<GetProduct>(result);
                return resultMap;
            }
            return null;
        }

        public async Task<ServicesResponse> Update(UpdateProduct product)
        {
            var productMap = mapper.Map<Product>(product);

            var exists = await repository.GetByIdNoTracking(productMap.Id);
            if (exists == null)
            {
                return new ServicesResponse
                {
                    IsSuccess = false,
                    Message = "Product not found."
                };
            }

            var result = await repository.Update(productMap);

            return result
                ? new ServicesResponse { IsSuccess = true, Message = "Product updated successfully." }
                : new ServicesResponse { IsSuccess = false, Message = "Failed to update product." };
        }
    }
}