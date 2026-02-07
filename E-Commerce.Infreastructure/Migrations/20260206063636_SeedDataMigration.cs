using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.Infreastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Electronics" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Clothing" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Books" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Home & Kitchen" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Sports & Outdoors" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Toys & Games" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Beauty & Personal Care" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price", "Quentity" },
                values: new object[,]
                {
                    { new Guid("10101010-1010-1010-1010-101010101010"), new Guid("33333333-3333-3333-3333-333333333333"), "Classic novel by F. Scott Fitzgerald", "great-gatsby.jpg", "The Great Gatsby", 15.99m, 100 },
                    { new Guid("20202020-2020-2020-2020-202020202020"), new Guid("33333333-3333-3333-3333-333333333333"), "Handbook of Agile Software Craftsmanship", "clean-code.jpg", "Clean Code", 42.99m, 75 },
                    { new Guid("30303030-3030-3030-3030-303030303030"), new Guid("44444444-4444-4444-4444-444444444444"), "12-cup programmable coffee maker", "coffee-maker.jpg", "Coffee Maker Deluxe", 79.99m, 35 },
                    { new Guid("40404040-4040-4040-4040-404040404040"), new Guid("44444444-4444-4444-4444-444444444444"), "10-piece set, dishwasher safe", "cookware-set.jpg", "Non-Stick Cookware Set", 129.99m, 20 },
                    { new Guid("50505050-5050-5050-5050-505050505050"), new Guid("55555555-5555-5555-5555-555555555555"), "Non-slip, extra thick", "yoga-mat.jpg", "Yoga Mat Premium", 34.99m, 80 },
                    { new Guid("60606060-6060-6060-6060-606060606060"), new Guid("55555555-5555-5555-5555-555555555555"), "Waterproof, easy setup", "camping-tent.jpg", "Camping Tent 4-Person", 159.99m, 12 },
                    { new Guid("70707070-7070-7070-7070-707070707070"), new Guid("66666666-6666-6666-6666-666666666666"), "Millennium Falcon, 1351 pieces", "lego-starwars.jpg", "LEGO Star Wars Set", 169.99m, 45 },
                    { new Guid("80808080-8080-8080-8080-808080808080"), new Guid("66666666-6666-6666-6666-666666666666"), "Strategy game for 3-4 players", "catan.jpg", "Board Game - Catan", 44.99m, 55 },
                    { new Guid("90909090-9090-9090-9090-909090909090"), new Guid("77777777-7777-7777-7777-777777777777"), "Hydrating formula with hyaluronic acid", "face-cream.jpg", "Moisturizing Face Cream", 24.99m, 90 },
                    { new Guid("a0a0a0a0-a0a0-a0a0-a0a0-a0a0a0a0a0a0"), new Guid("77777777-7777-7777-7777-777777777777"), "Rechargeable, 5 cleaning modes", "electric-toothbrush.jpg", "Electric Toothbrush", 69.99m, 40 },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("11111111-1111-1111-1111-111111111111"), "15.6 inch Full HD display, Intel Core i5, 8GB RAM, 256GB SSD", "laptop-hp.jpg", "Laptop HP Pavilion", 699.99m, 25 },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("11111111-1111-1111-1111-111111111111"), "128GB, Titanium finish, A17 Pro chip", "iphone-15-pro.jpg", "iPhone 15 Pro", 999.99m, 50 },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("11111111-1111-1111-1111-111111111111"), "55 inch QLED display", "samsung-tv.jpg", "Samsung 4K Smart TV", 799.99m, 15 },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new Guid("22222222-2222-2222-2222-222222222222"), "Genuine leather, black color", "leather-jacket.jpg", "Men's Leather Jacket", 149.99m, 30 },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new Guid("22222222-2222-2222-2222-222222222222"), "Floral print, cotton blend", "summer-dress.jpg", "Women's Summer Dress", 49.99m, 40 },
                    { new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new Guid("22222222-2222-2222-2222-222222222222"), "Lightweight, breathable mesh", "nike-shoes.jpg", "Running Shoes Nike", 89.99m, 60 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10101010-1010-1010-1010-101010101010"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("20202020-2020-2020-2020-202020202020"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("30303030-3030-3030-3030-303030303030"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("40404040-4040-4040-4040-404040404040"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("50505050-5050-5050-5050-505050505050"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("60606060-6060-6060-6060-606060606060"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("70707070-7070-7070-7070-707070707070"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("80808080-8080-8080-8080-808080808080"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("90909090-9090-9090-9090-909090909090"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a0a0a0a0-a0a0-a0a0-a0a0-a0a0a0a0a0a0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));
        }
    }
}
