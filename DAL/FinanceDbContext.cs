using DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Core.Domain;

namespace DAL
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AuthenticationToken> AuthenticationTokens { get; set; }        

        public void Seed(ModelBuilder modelBuilder)
        {
            UsersSeed.Seed(modelBuilder);
            ProductsSeed.Seed(modelBuilder);
        }
    }
}
