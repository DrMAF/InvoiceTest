using Microsoft.EntityFrameworkCore;
using Core.Domain;

namespace DAL.Seeds
{
    internal class ProductUnitSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductUnit>().HasData(
            new ProductUnit()
            {
                Id = 1,
                ProductId = 1,
                UnitId = 1,
                Price = 12000,
                CreatorId = 1
            },
            new ProductUnit()
            {
                Id = 2,
                ProductId = 2,
                UnitId = 1,
                Price = 8000,
                CreatorId = 1
            },
            new ProductUnit()
            {
                Id = 3,
                ProductId = 3,
                UnitId = 1,
                Price = 25000,
                CreatorId = 1
            },
            new ProductUnit()
            {
                Id = 4,
                ProductId = 4,
                UnitId = 3,
                Price = 1200,
                CreatorId = 1
            },
            new ProductUnit()
            {
                Id = 5,
                ProductId = 4,
                UnitId = 4,
                Price = 15,
                CreatorId = 1
            },
            new ProductUnit()
            {
                Id = 6,
                ProductId = 5,
                UnitId = 1,
                Price = 1,
                CreatorId = 1
            },
            new ProductUnit()
            {
                Id = 7,
                ProductId = 5,
                UnitId = 2,
                Price = 90,
                CreatorId = 1
            });
        }
    }
}
