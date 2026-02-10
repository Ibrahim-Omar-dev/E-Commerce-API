using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Entities.Identity;
using E_Commerce.Infreastructure.Seeder;
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
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(SeedProduct.GetProducts());
            modelBuilder.Entity<Category>().HasData(SeedCategory.GetCategories());
        }
    }
}
