using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Entities.Cart;
using E_Commerce.Domain.Entities.Identity;
using E_Commerce.Infreastructure.Seeder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Infreastructure.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<RefreshToken> RefreshTokens{ get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Achieve> CheckoutAchieve {  get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PaymentMethod>().HasData(
    new PaymentMethod()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567890"),
        Name = "Credit Card"
    },
    new PaymentMethod()
    {
        Id = Guid.Parse("b2c3d4e5-f6a7-8901-bcde-f12345678901"),
        Name = "Cash"
    }
);


            modelBuilder.Entity<Product>().HasData(SeedProduct.GetProducts());
            modelBuilder.Entity<Category>().HasData(SeedCategory.GetCategories());
        }
    }
}
