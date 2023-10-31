using Microsoft.EntityFrameworkCore;
using Core.Domain;

namespace DAL.Seeds
{
    internal class StoreSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>().HasData(
            new Store()
            {
                Id = 1,
                NameEn = "Headquarter",
                NameAr = "المركز الرئيسى",
                Location = "Nasr city",
                CreatorId = 1
            },
            new Store()
            {
                Id = 2,
                NameEn = "First extension",
                NameAr = "الفرع الأول",
                Location =  "Giza",
                CreatorId = 1
            });
        }
    }
}
