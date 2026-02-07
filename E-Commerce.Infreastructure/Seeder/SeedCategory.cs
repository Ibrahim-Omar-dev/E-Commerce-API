using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;

namespace E_Commerce.Infreastructure.Seeder
{
    public static class SeedCategory
    {
        public static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Electronics"
                },
                new Category
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Clothing"
                },
                new Category
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Books"
                },
                new Category
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Name = "Home & Kitchen"
                },
                new Category
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    Name = "Sports & Outdoors"
                },
                new Category
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    Name = "Toys & Games"
                },
                new Category
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    Name = "Beauty & Personal Care"
                }
            };
        }
    }
}