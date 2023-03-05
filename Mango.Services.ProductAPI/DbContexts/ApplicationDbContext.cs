using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                  new Product
                  {
                      productId = 1,
                      CategoryName = "Appetizer",
                      Description = "Shit",
                      ImageUrl = "https://dotnetmastery.blob.core.windows.net/mango/14.jpg",
                      Name = "Samosa",
                      Price = 15.0
                  });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    productId = 2,
                    CategoryName = "Appetizer",
                    Description = "Shit",
                    ImageUrl = "https://dotnetmastery.blob.core.windows.net/mango/12.jpg",
                    Name = "Cup Cake",
                    Price = 18.0
                });

            modelBuilder.Entity<Product>().HasData(
                 new Product
                 {
                     productId = 3,
                     CategoryName = "Appetizer",
                     Description = "Shit",
                     ImageUrl = "https://dotnetmastery.blob.core.windows.net/mango/11.jpg",
                     Name = "Shawarma",
                     Price = 22.0
                 });
            modelBuilder.Entity<Product>().HasData(
                 new Product
                 {
                     productId = 4,
                     CategoryName = "Appetizer",
                     Description = "Shit",
                     ImageUrl = "https://dotnetmastery.blob.core.windows.net/mango/13.jpg",
                     Name = "Pizza",
                     Price = 16.0
                 });
           
        }
    }
}
