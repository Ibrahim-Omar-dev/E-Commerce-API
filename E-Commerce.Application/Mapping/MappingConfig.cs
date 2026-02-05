using AutoMapper;
using E_Commerce.Application.Categorys;
using E_Commerce.Application.Dto.Categorys;
using E_Commerce.Application.Dto.Product;
using E_Commerce.Domain.Entities;
using DomainEntities = E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Product, GetProduct>().ReverseMap();
            CreateMap<Category, GetCategory>().ReverseMap();

            CreateMap<CreateProduct, Product>().ReverseMap();
            CreateMap<UpdateProduct, Product>().ReverseMap();

            CreateMap<UpdateProduct, Product>().ReverseMap();
            CreateMap<UpdateCategory, Category>().ReverseMap();
        }
    }
}
