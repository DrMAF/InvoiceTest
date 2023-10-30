using Microsoft.EntityFrameworkCore;
using Core.Domain;

namespace DAL.Seeds
{
    internal class ProductsSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new Product()
            {
                Id = 1,
                NameEn = "TV",
                NameAr = "تليفزيون",
                Price = 11000,
                CreatorId = 1
            },
            new Product()
            {
                Id = 2,
                NameEn = "Mobile",
                NameAr = "محمول",
                Price = 8000,
                CreatorId = 1
            },
            new Product()
            {
                Id = 3,
                NameEn = "Labtop",
                NameAr = "جهاز حاسب",
                Price = 25000,
                CreatorId = 1
            });
        }
    }
}
