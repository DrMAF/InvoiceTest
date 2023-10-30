using Microsoft.EntityFrameworkCore;
using Core.Domain;

namespace DAL.Seeds
{
    internal class UsersSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = 1,
                FirstName = "Admin",
                SecondName = "",
                LastName = "admin",
                UserName = "admin",
                Email= "admin@mail.com",
                Phone = "1234",
                CreatorId = 1
            });
        }
    }
}
