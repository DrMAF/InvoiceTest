using Microsoft.EntityFrameworkCore;
using Core.Domain;

namespace DAL.Seeds
{
    internal class UnitSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>().HasData(
            new Unit()
            {
                Id = 1,
                NameEn = "Item",
                NameAr = "وحدة",
                CreatorId = 1
            },
            new Unit()
            {
                Id = 2,
                NameEn = "Kilo",
                NameAr = "كيلو",
                CreatorId = 1
            },
            new Unit()
            {
                Id = 3,
                NameEn = "Packge",
                NameAr = "لفة",
                CreatorId = 1
            },
            new Unit()
            {
                Id = 4,
                NameEn = "Meter",
                NameAr = "متر",
                CreatorId = 1
            });
        }
    }
}
