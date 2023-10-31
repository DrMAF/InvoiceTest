using Microsoft.EntityFrameworkCore;
using Core.Domain;

namespace DAL.Seeds
{
    internal class ProductSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new Product()
            {
                Id = 1,
                NameEn = "TV",
                NameAr = "تليفزيون",
                CreatorId = 1
            },
            new Product()
            {
                Id = 2,
                NameEn = "Mobile",
                NameAr = "محمول",
                CreatorId = 1
            },
            new Product()
            {
                Id = 3,
                NameEn = "Labtop",
                NameAr = "جهاز حاسب",
                CreatorId = 1
            },
            new Product()
            {
                Id = 4,
                NameEn = "Network wire",
                NameAr = "سلك شبكات",
                CreatorId = 1
            },
            new Product()
            {
                Id = 5,
                NameEn = "Nail",
                NameAr = "مسمار",
                CreatorId = 1
            });
        }
    }
}
