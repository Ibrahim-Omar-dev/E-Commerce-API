using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;

namespace E_Commerce.Infreastructure.Seeder
{
    public static class SeedProduct
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    Name = "Laptop HP Pavilion",
                    Description = "15.6 inch Full HD display, Intel Core i5, 8GB RAM, 256GB SSD",
                    Price = 699.99m,
                    Image = "laptop-hp.jpg",
                    Quentity = 25,
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111")
                },
                new Product
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    Name = "iPhone 15 Pro",
                    Description = "128GB, Titanium finish, A17 Pro chip",
                    Price = 999.99m,
                    Image = "iphone-15-pro.jpg",
                    Quentity = 50,
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111")
                },
                new Product
                {
                    Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                    Name = "Samsung 4K Smart TV",
                    Description = "55 inch QLED display",
                    Price = 799.99m,
                    Image = "samsung-tv.jpg",
                    Quentity = 15,
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111")
                },
                new Product
                {
                    Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                    Name = "Men's Leather Jacket",
                    Description = "Genuine leather, black color",
                    Price = 149.99m,
                    Image = "leather-jacket.jpg",
                    Quentity = 30,
                    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222")
                },
                new Product
                {
                    Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                    Name = "Women's Summer Dress",
                    Description = "Floral print, cotton blend",
                    Price = 49.99m,
                    Image = "summer-dress.jpg",
                    Quentity = 40,
                    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222")
                },
                new Product
                {
                    Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                    Name = "Running Shoes Nike",
                    Description = "Lightweight, breathable mesh",
                    Price = 89.99m,
                    Image = "nike-shoes.jpg",
                    Quentity = 60,
                    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222")
                },
                new Product
                {
                    Id = Guid.Parse("10101010-1010-1010-1010-101010101010"),
                    Name = "The Great Gatsby",
                    Description = "Classic novel by F. Scott Fitzgerald",
                    Price = 15.99m,
                    Image = "great-gatsby.jpg",
                    Quentity = 100,
                    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333")
                },
                new Product
                {
                    Id = Guid.Parse("20202020-2020-2020-2020-202020202020"),
                    Name = "Clean Code",
                    Description = "Handbook of Agile Software Craftsmanship",
                    Price = 42.99m,
                    Image = "clean-code.jpg",
                    Quentity = 75,
                    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333")
                },
                new Product
                {
                    Id = Guid.Parse("30303030-3030-3030-3030-303030303030"),
                    Name = "Coffee Maker Deluxe",
                    Description = "12-cup programmable coffee maker",
                    Price = 79.99m,
                    Image = "coffee-maker.jpg",
                    Quentity = 35,
                    CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444")
                },
                new Product
                {
                    Id = Guid.Parse("40404040-4040-4040-4040-404040404040"),
                    Name = "Non-Stick Cookware Set",
                    Description = "10-piece set, dishwasher safe",
                    Price = 129.99m,
                    Image = "cookware-set.jpg",
                    Quentity = 20,
                    CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444")
                },
                new Product
                {
                    Id = Guid.Parse("50505050-5050-5050-5050-505050505050"),
                    Name = "Yoga Mat Premium",
                    Description = "Non-slip, extra thick",
                    Price = 34.99m,
                    Image = "yoga-mat.jpg",
                    Quentity = 80,
                    CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555")
                },
                new Product
                {
                    Id = Guid.Parse("60606060-6060-6060-6060-606060606060"),
                    Name = "Camping Tent 4-Person",
                    Description = "Waterproof, easy setup",
                    Price = 159.99m,
                    Image = "camping-tent.jpg",
                    Quentity = 12,
                    CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555")
                },
                new Product
                {
                    Id = Guid.Parse("70707070-7070-7070-7070-707070707070"),
                    Name = "LEGO Star Wars Set",
                    Description = "Millennium Falcon, 1351 pieces",
                    Price = 169.99m,
                    Image = "lego-starwars.jpg",
                    Quentity = 45,
                    CategoryId = Guid.Parse("66666666-6666-6666-6666-666666666666")
                },
                new Product
                {
                    Id = Guid.Parse("80808080-8080-8080-8080-808080808080"),
                    Name = "Board Game - Catan",
                    Description = "Strategy game for 3-4 players",
                    Price = 44.99m,
                    Image = "catan.jpg",
                    Quentity = 55,
                    CategoryId = Guid.Parse("66666666-6666-6666-6666-666666666666")
                },
                new Product
                {
                    Id = Guid.Parse("90909090-9090-9090-9090-909090909090"),
                    Name = "Moisturizing Face Cream",
                    Description = "Hydrating formula with hyaluronic acid",
                    Price = 24.99m,
                    Image = "face-cream.jpg",
                    Quentity = 90,
                    CategoryId = Guid.Parse("77777777-7777-7777-7777-777777777777")
                },
                new Product
                {
                    Id = Guid.Parse("a0a0a0a0-a0a0-a0a0-a0a0-a0a0a0a0a0a0"),
                    Name = "Electric Toothbrush",
                    Description = "Rechargeable, 5 cleaning modes",
                    Price = 69.99m,
                    Image = "electric-toothbrush.jpg",
                    Quentity = 40,
                    CategoryId = Guid.Parse("77777777-7777-7777-7777-777777777777")
                }
            };
        }
    }
}